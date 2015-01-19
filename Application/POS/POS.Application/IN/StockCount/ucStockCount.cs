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
using POS.BL.DTO;

namespace POS.IN.StockCount
{
    public partial class ucStockCount : BaseUserControl
    {
        TabPage tabPageAddEdit = new TabPage();
        string DataKeyName = "stock_head_id";
        AddEditStockCount addEditStockCount = new AddEditStockCount();
        string programName = ProgramName.SetupINStockCount;
        string tabName = "List Stock Material";
        private string _documentTypeCode { get { return DocumentTypeCode.IN.StockCount; } }

        public ucStockCount()
        {
            InitializeComponent();

            SetInitialControl();

            this.Dock = DockStyle.Fill;
            tabPage1.Text = tabName;

            grdBase.onAddNewRow += new EventHandler(grdBase_onAddNewRow);
            grdBase.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(grdBase_onSelectedDataRow);
            grdBase.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(grdBase_onLoadDataGrid);
            grdBase.onCellFormatting += new EventHandler<DataGridViewCellFormattingEventArgs>(grdBase_onCellFormatting);

            grdBase.LoadData();
        }
        #region :: Event Gridview ::
        public void grdBase_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            //hide the damn column
            grdBase.HiddenColumnName = new List<string>() { "stock_head_id" };
            DataSet ds = ServiceProvider.StockHeadService.GetStockHead();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Status"].ToStringNullable() == TransactionStatus.IN.NormalCode)
                    {
                        row["Status"] = TransactionStatus.IN.NormalText;
                    }
                    else if (row["Status"].ToStringNullable() == TransactionStatus.IN.FinalCode)
                    {
                        row["Status"] = TransactionStatus.IN.FinalText;
                    }
                    
                    row["Document Date"] = DateTime.Parse(row["Document Date"].ToString()).ConvertDateToDisplay();
                    row["Period"] = DateTime.Parse(row["Period"].ToString()).ConvertDateToDisplay();
                }
            }

            grdBase.DataSourceDataSet = ds;
            grdBase.DataKeyName = new string[] { DataKeyName };

            //try to set its visibility 
            grdBase.btnDeleteEnable = false;
            grdBase.RearrangeButton();

        }
        public void grdBase_onAddNewRow(object sender, EventArgs e)
        {
            addEditStockCount = new AddEditStockCount();
            this.AddEditTab(string.Format(TabName.Add, programName), addEditStockCount);
        }
        public void grdBase_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            addEditStockCount = new AddEditStockCount(dataKey[DataKeyName].ToString());
            this.AddEditTab(string.Format(TabName.Edit, programName), addEditStockCount);
        }
        public void grdBase_onDeleteDataRows(object sender, Control.GridView.RowsEventArgs e)
        {
            try
            {
                List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)sender;
                List<TranHead> listTranHead = new List<TranHead>();
                foreach (Dictionary<string, object> item in list)
                {
                    listTranHead.Add(new TranHead() { tran_head_id = Converts.ParseLong(item[DataKeyName].ToString()) });
                }
                ServiceProvider.TranHeadService.Delete(listTranHead);
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
        private void AddEditTab(string TabTitle, AddEditStockCount controlAddEdit)
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
        private void SetInitialControl()
        {
            List<PeriodGroup> lstSupplier = ServiceProvider.PeriodGroupService.FindAll(false).ToList();
            List<ComboBoxDTO> lstComboBoxDTOSupplier = new List<ComboBoxDTO>();
            foreach (PeriodGroup periodGroup in lstSupplier)
            {
                ComboBoxDTO DTO = new ComboBoxDTO();
                DTO.Value = periodGroup.period_group_id.ToString();
                DTO.Display = periodGroup.period_group_name;
                lstComboBoxDTOSupplier.Add(DTO);
            }
            lstComboBoxDTOSupplier.SetPleaseSelect();
            ddlPeriodGroup.DataSource = lstComboBoxDTOSupplier;
            ddlPeriodGroup.ValueMember = "Value";
            ddlPeriodGroup.DisplayMember = "Display";

        }
        #endregion


    }
}
