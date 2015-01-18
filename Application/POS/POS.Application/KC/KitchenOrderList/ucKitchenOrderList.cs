using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.BL;
using POS.Control;
using POS.BL.Utilities;
using POS.BL.Entities.Entity;
using Core.Standards.Converters;
using Core.Standards.Exceptions;
using Core.Standards.Validations;
using POS.IN.ReceiveMaterial;
using POS.Control.BaseMessageBox;
using POS.Control.GridView;

namespace POS.KC.KitchenOrderList
{
    public partial class ucKitchenOrderList : BaseUserControl
    {
        TabPage tabPageAddEdit = new TabPage();
        string DataKeyName = "ID";
        KitchenOrderDetail addEditReceiveMaterial = new KitchenOrderDetail();
        string programName = ProgramName.KitchenOrderListDetail;
        string tabName = "Kitchen Order List";

        private const string btnProcessName = "btnProcess"
            , btnProcessCompleteName = "btnProcessComplete"
            , btnProcessCancelName = "btnProcessCancel";

        /// <summary>
        /// all the controls that cannot tolerate each other
        /// </summary>
        List<System.Windows.Forms.Control> IntoleranceControl;

        public ucKitchenOrderList()
        {
            InitializeComponent();

            // SetInitialControl();

            this.Dock = DockStyle.Fill;
            tabPage1.Text = tabName;

           // grdBase.onAddNewRow += new EventHandler(grdBase_onAddNewRow);
            grdBase.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(grdBase_onSelectedDataRow);
            grdBase.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(grdBase_onLoadDataGrid);
            grdBase.onCellFormatting += new EventHandler<DataGridViewCellFormattingEventArgs>(grdBase_onCellFormatting);

            ///manually add event to each button
            grdBase.AttachEventToButton( btnProcessName, new EventHandler(grdBase_KitchenCommand));
            grdBase.AttachEventToButton( btnProcessCancelName , new EventHandler(grdBase_KitchenCommand));
            grdBase.AttachEventToButton( btnProcessCompleteName , new EventHandler(grdBase_KitchenCommand));

            grdBase.LoadData();
        }
        #region :: Event Gridview ::
        public void grdBase_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            //hide the damn column
            grdBase.HiddenColumnName = new List<string>() { "ID" };//, "Supplier", "Warehouse" };
            //grdBase.SetColumnFit();

            grdBase.DataSourceDataSet =
            ServiceProvider.KCSaleOrderDetailService.FindOrderInKitchenList(txtTableName.Text.Trim(), txtMenuName.Text.Trim());

            grdBase.DataKeyName = new string[] { DataKeyName };

            //try to set its visibility 
            grdBase.btnDeleteEnable = false;
            grdBase.btnAddEnable = false;
            grdBase.RearrangeButton();



        }

        public void grdBase_KitchenCommand(object sender, EventArgs e)
        {
            try
            {
                //get the selected rows
                List<DataGridViewRow> selectedRows = grdBase.GridSelectedRows;

                if (selectedRows.Count <= 0)
                    UtilityMessage.Warning(GeneralMessage.NoSelectedDataUpdate, GeneralMessage.MessageBoxTitle);
                //else if (!UtilityMessage.Confirm(GeneralMessage.ConfirmDelete, GeneralMessage.MessageBoxTitle))
                //{
                //    return;
                //}
                else
                {
                    //Button currenButton = 
                    List<string> OrderDetailKeyList = selectedRows.Select(x => x.Cells["ID"].Value.ToString()).ToList();

                    string StatusToUpdate = string.Empty;

                    //sould have gone with hieritiing EventArgs , but ain't nobody got time for that shit
                    Button currentCommand = sender as Button;
                    if (currentCommand != null)
                        StatusToUpdate = DetermineStatusFromButton(currentCommand);

                    ServiceProvider.KCSaleOrderDetailService.UpdateOrderDetailStatus(OrderDetailKeyList, StatusToUpdate);

                    grdBase.LoadData(true);
                    UtilityMessage.Alert(GeneralMessage.UpdateStatusCompleted , GeneralMessage.MessageBoxTitle);

                    /*string answer = string.Empty;
                    foreach (string key in OrderDetailKeyList) answer += key;
                    MessageBox.Show(answer);*/
                }
            }
            catch (ValidationException ex)
            {
                base.formBase.ShowErrorMessage(ex);
            }
        }

        public string DetermineStatusFromButton(Button CurrentBUtton)
        {
            string answer = string.Empty;
            switch (CurrentBUtton.Name)
            {
                case btnProcessCancelName:
                    answer = KitichenStatus.Cancel; break;
                case btnProcessCompleteName:
                    answer = KitichenStatus.Finish ; break;
                case btnProcessName:
                    answer = KitichenStatus.Process; break;
            }
            return answer;
        }

   
        public void grdBase_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            addEditReceiveMaterial = new KitchenOrderDetail(dataKey[DataKeyName].ToString() );//, tabControl1, tabPageAddEdit);
            this.AddEditTab(string.Format(TabName.Edit, programName), addEditReceiveMaterial);
        }

        public void grdBase_onCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            object grd = sender;
            object val = e.Value;
            e.CellStyle.WrapMode = DataGridViewTriState.True;

            Type dataType = val.GetType();

            if (e.ColumnIndex == 2)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                if (typeof(int) == dataType || typeof(decimal) == dataType || typeof(float) == dataType || typeof(long) == dataType || typeof(double) == dataType)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (typeof(DateTime) == dataType)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.CellStyle.Format = FormatString.FormatDate;
                }
                else
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        #endregion

        protected void NotifyReturnEvent(object param)
        {
            if (param != null)
            {
                ControlMode controlMode = (ControlMode)param;
                if (tabControl1.TabPages.Count > 1)
                {
                    tabControl1.TabPages.RemoveAt(1);
                }
                if (controlMode == ControlMode.Save)
                {
                    grdBase.LoadData();
                }
                tabControl1.SelectedTab = tabPage1;
            }
        }

        #region :: Private Function ::
        private void AddEditTab(string TabTitle, KitchenOrderDetail controlAddEdit)
        {
            if (tabControl1.TabPages.Count == 1 || (tabControl1.TabPages.Count > 1 && base.formBase.ShowConfirmMessage(GeneralMessage.ConfirmNewTab, "Confirm")))
            {
                controlAddEdit.NotifyReturnEvent += new Control.BaseUserControl.NotifyReturnHandler(NotifyReturnEvent);
                tabPageAddEdit = new TabPage();
                tabPageAddEdit.Controls.Clear();
                tabPageAddEdit.Controls.Add(controlAddEdit);
                tabPageAddEdit.Text = TabTitle;
                controlAddEdit.Dock = DockStyle.Fill;

                if (tabControl1.TabPages.Count > 1)
                {
                    tabControl1.TabPages.RemoveAt(1);
                }
                tabControl1.TabPages.Remove(tabPageAddEdit);
                tabControl1.TabPages.Add(tabPageAddEdit);
            }
            tabControl1.SelectedTab = tabPageAddEdit;
        }

        private void rdoItolerate_CheckedChanged(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control control in IntoleranceControl)
            {
                RadioButton clickedCb = sender as RadioButton;
                if (clickedCb != null && control.Tag.ToString() == clickedCb.Name)
                {
                    control.Enabled = true;
                }
                else
                    control.Enabled = false;
            }
        }

        #endregion


    }
}
