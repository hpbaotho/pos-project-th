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

namespace POS.IN.BillOfMaterial
{
    public partial class ucBillOfMaterial : BaseUserControl
    {
        TabPage tabPageAddEdit = new TabPage();
        string DataKeyName = "ID";
        AddEditBillOfMaterial addEditBillOfMaterial = new AddEditBillOfMaterial();
        string programName = ProgramName.MappingMenu;
        string tabName = "List Bill Of Material";

        public ucBillOfMaterial()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            tabPage1.Text = tabName;

            //---DDL
            ddlBOMGroup.DataSource = ServiceProvider.BillOfMaterialGroupService.GetBillOfMaterialGroupComboBoxDTO();
            ddlBOMGroup.ValueMember = "Value";
            ddlBOMGroup.DisplayMember = "Display";

            //---Gridview
            grdBase.onAddNewRow += new EventHandler(grdBase_onAddNewRow);
            grdBase.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(grdBase_onSelectedDataRow);
            grdBase.onDeleteDataRows += new EventHandler<Control.GridView.RowsEventArgs>(grdBase_onDeleteDataRows);
            grdBase.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(grdBase_onLoadDataGrid);
            grdBase.onCellFormatting += new EventHandler<DataGridViewCellFormattingEventArgs>(grdBase_onCellFormatting);
            grdBase.LoadData();
        }
        #region :: Event Gridview ::
        public void grdBase_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            grdBase.DataSourceDataSet = ServiceProvider.BillOfMaterialHeadService.GetGridBOMHead(Converts.ParseLongNullable(ddlBOMGroup.SelectedValue.ToStringNullable()),txtBOMCode.Text,txtBOMName.Text);
            grdBase.DataKeyName = new string[] { DataKeyName };
        }
        public void grdBase_onAddNewRow(object sender, EventArgs e)
        {
            addEditBillOfMaterial = new AddEditBillOfMaterial();
            this.AddEditTab(string.Format(TabName.Add, programName), addEditBillOfMaterial);
        }
        public void grdBase_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            addEditBillOfMaterial = new AddEditBillOfMaterial(dataKey[DataKeyName].ToString());
            this.AddEditTab(string.Format(TabName.Edit, programName), addEditBillOfMaterial);
        }
        public void grdBase_onDeleteDataRows(object sender, Control.GridView.RowsEventArgs e)
        {
            try
            {
                List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)sender;
                List<SOMenu> listEntity = new List<SOMenu>();
                foreach (Dictionary<string, object> item in list)
                {
                    listEntity.Add(new SOMenu() { menu_id = Converts.ParseLong(item[DataKeyName].ToString()) });
                }

                ServiceProvider.MenuService.DeleteSOMenuAndMappingMenu(listEntity);
            }
            catch (ValidationException ex)
            {
                base.formBase.ShowErrorMessage(ex);
            }
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
                if (controlMode == ControlMode.Back)
                {
                    if (tabControl1.TabPages.Count > 1)
                    {
                        tabControl1.TabPages.RemoveAt(1);
                    }

                    grdBase.LoadData();
                    tabControl1.SelectedTab = tabPage1;
                }
            }
        }

        #region :: Private Function ::
        private void AddEditTab(string TabTitle, AddEditBillOfMaterial controlAddEdit)
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
        #endregion
    }
}
