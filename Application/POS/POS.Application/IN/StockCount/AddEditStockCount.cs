using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Control;
using POS.BL.Utilities;
using POS.BL.Entities.Entity;
using POS.BL;
using Core.Standards.Converters;
using Core.Standards.Exceptions;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using POS.BL.DTO;

namespace POS.IN.StockCount
{
    public partial class AddEditStockCount : BaseAddEditMaster
    {
        #region :: Constructure ::
        public AddEditStockCount()
        {
            base.FormMode = ObjectState.Add;
            InitializeComponent();
        }
        public AddEditStockCount(string Code)
        {
            base.FormMode = ObjectState.Edit;
            base.FormKeyCode = Code;
            InitializeComponent();
        }
        #endregion :: Constructure ::

        #region :: Properties ::
        string DataKeyName = "stock_detail_id";
        private long _documentTypeID { get; set; }
        private string _documentTypeCode { get { return DocumentTypeCode.IN.StockCount; } }
        private DataSet dsStockDetail { get; set; }
        private string _documentStatus { get; set; }
        #endregion :: Properties ::

        #region :: Private Function ::
        private void LoadHeadData()
        {
            StockHead entity = new StockHead();

            if (base.FormMode == ObjectState.Edit && !string.IsNullOrEmpty(base.FormKeyCode))
            {
                entity.stock_head_id = Converts.ParseLong(base.FormKeyCode);
                entity = ServiceProvider.StockHeadService.FindByKeys(entity, true);
                Period periodEntity = new Period() { period_id = entity.period_id };
                periodEntity = ServiceProvider.PeriodService.FindByKeys(periodEntity, false);

                PeriodGroup periodGroupEntity = new PeriodGroup() { period_group_id = periodEntity.period_group_id };

                ddlPeriodGroup.DataSource = ServiceProvider.PeriodGroupService.FindByActiveOrID(periodGroupEntity);
                ddlPeriodGroup.ValueMember = "Value";
                ddlPeriodGroup.DisplayMember = "Display";

                ddlPeriodGroup.SelectedValue = periodGroupEntity.period_group_id.ToString();
                
                DataSet ds = ServiceProvider.PeriodService.FindDataSetByParentKey(periodEntity);
                List<ComboBoxDTO> lstComboboxDTO = new List<ComboBoxDTO>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ComboBoxDTO dto = new ComboBoxDTO();
                    dto.Value = dr["period_id"].ToString();
                    dto.Display = dr["period_code"].ToString() + ":" + DateTime.Parse(dr["period_date"].ToString()).ConvertDateToDisplay();
                    lstComboboxDTO.Add(dto);

                }
                lstComboboxDTO.SetPleaseSelect();

                ddlPeriod.DataSource = lstComboboxDTO;
                ddlPeriod.ValueMember = "Value";
                ddlPeriod.DisplayMember = "Display";

                ddlPeriod.SelectedValue = entity.period_id.ToString();

                ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID(new WareHouse() { warehouse_id = entity.warehouse_id });
                ddlWarehouse.ValueMember = "Value";
                ddlWarehouse.DisplayMember = "Display";

                ddlWarehouse.SelectedValue = entity.warehouse_id.ToString();

                txtRemark.Text = entity.remark;
                lblDocumentNo.Text = entity.transaction_no;
                lblDocumentDate.Text = entity.transaction_date.ConvertDateToDisplay();
                lblStatus.Text = (entity.transaction_status == TransactionStatus.IN.FinalCode) ? TransactionStatus.IN.FinalText : TransactionStatus.IN.NormalText;
                this._documentStatus = entity.transaction_status;
            }
            else
            {
                ddlPeriodGroup.DataSource = ServiceProvider.PeriodGroupService.FindByActiveOrID();
                ddlPeriodGroup.ValueMember = "Value";
                ddlPeriodGroup.DisplayMember = "Display";

                List<ComboBoxDTO> lstCombobox = new List<ComboBoxDTO>();
                lstCombobox.SetPleaseSelect();

                ddlPeriod.DataSource = lstCombobox;
                ddlPeriod.ValueMember = "Value";
                ddlPeriod.DisplayMember = "Display";

                ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                ddlWarehouse.ValueMember = "Value";
                ddlWarehouse.DisplayMember = "Display";

                txtRemark.Text = string.Empty;
                lblDocumentNo.Text = GeneralMessage.AutoRunningDocumentNo;
                lblDocumentDate.Text = DateTime.Now.ConvertDateToDisplay();
                lblStatus.Text = TransactionStatus.IN.FinalText;
            }

            InitialDetailData();
            EnableModeHead();
            EnableModeDetail();
        }
        private void LoadDetailData()
        {
            DataRow dr = this.GetDataRowDetail(baseGridDetail.DataKeyValue[1].ToLong(), baseGridDetail.DataKeyValue[2].ToDecimal()).First();

            this.ddlMaterial.SelectedValue = dr["material_id"].ToString();

            string lotNo = dr["Lot No."].ToStringNullable();
            if (!string.IsNullOrEmpty(lotNo)) { lotNo = string.Format(Format.DecimalNumberFormat, lotNo.ToDouble()); }

            txtLotNo.Text = lotNo;

            string count = dr["Count"].ToStringNullable();
            if (!string.IsNullOrEmpty(count)) { count = string.Format(Format.DecimalNumberFormat, count.ToDouble()); }

            txtCount.Text = count;

            string adjust = dr["Adjust"].ToStringNullable();
            if (!string.IsNullOrEmpty(adjust)) { adjust = string.Format(Format.DecimalNumberFormat, adjust.ToDouble()); }

            txtAdjust.Text = adjust;

            txtRemarkDetails.Text = dr["Remark"].ToStringNullable();
            lblUOMCount.Text = dr["UOM"].ToStringNullable();
            lblUOMAdjust.Text = dr["UOM"].ToStringNullable();
        }
        private void InitialDetailData()
        {
            this.ddlMaterial.DataSource = ServiceProvider.MaterialService.FindByActiveOrID();
            this.ddlMaterial.ValueMember = "Value";
            this.ddlMaterial.DisplayMember = "Display";

            lblUOMCount.Text = string.Empty;
            lblUOMAdjust.Text = string.Empty;

            baseAddEditMasterDetail.btnBackVisible = false;

            baseGridDetail.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(baseGridDetail_onSelectedDataRow);
            baseGridDetail.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(baseGridDetail_onLoadDataGrid);
            baseGridDetail.onCellFormatting += new EventHandler<DataGridViewCellFormattingEventArgs>(baseGridDetail_onCellFormatting);
            baseGridDetail.LoadData();
        }
        private void EnableModeHead()
        {
            this.baseGridDetail.btnSearchVisible = false;
            this.baseGridDetail.btnDeleteVisible = false;
            this.baseGridDetail.btnAddVisible = false;
            this.baseGridDetail.btnDeleteVisible = false;

            if (base.FormMode == ObjectState.Edit)
            {
                ddlPeriodGroup.Enabled = false;
                ddlPeriod.Enabled = false;
                ddlWarehouse.Enabled = false;
                txtRemark.Enabled = false;
                base.btnResetEnable = false;
                base.btnSaveEnable = false;

                this.btnGenerate.Visible = false;
            }
            else
            {
                ddlPeriodGroup.Enabled = true;
                ddlPeriod.Enabled = true;
                ddlWarehouse.Enabled = true;
                base.btnResetEnable = true;
                base.btnSaveEnable = true;

                this.btnGenerate.Visible = true;
            }
        }
        private void EnableModeDetail()
        {
            if (baseGridDetail.FormMode == ObjectState.Edit)
            {
                ddlMaterial.Enabled = false;
                txtLotNo.Enabled = false;
                txtCount.Enabled = false;
                txtAdjust.Enabled = true;
                txtRemarkDetails.Enabled = true;

                baseAddEditMasterDetail.btnSaveEnable = true;
                baseAddEditMasterDetail.btnResetEnable = true;
            }
            else 
            {
                txtAdjust.Enabled = false;
                txtRemarkDetails.Enabled = false;
                baseAddEditMasterDetail.btnSaveEnable = false;
                baseAddEditMasterDetail.btnResetEnable = false;
            }

            if (base.FormMode == ObjectState.Edit)
            {
                ddlMaterial.Enabled = false;
                txtLotNo.Enabled = false;
                txtCount.Enabled = false;
                txtAdjust.Enabled = false;
                txtRemarkDetails.Enabled = false;

                baseAddEditMasterDetail.btnSaveEnable = false;
                baseAddEditMasterDetail.btnResetEnable = false;
            }
        }
        private StockHead GetHeadData()
        {
            StockHead entity = new StockHead();
            entity.period_id = ddlPeriod.SelectedValue.ToLong();
            entity.warehouse_id = ddlWarehouse.SelectedValue.ToLong();
            entity.document_type_id = this._documentTypeID;
            entity.remark = txtRemark.Text;
            entity.created_by = "SYSTEM";
            entity.created_date = DateTime.Now;
            entity.transaction_date = DateTime.Now;
            entity.transaction_status = TransactionStatus.IN.FinalCode;
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        private StockDetail GetDetailData()
        {
            StockDetail entity = new StockDetail();
            entity.material_id = ddlMaterial.SelectedValue.ToLong();
            entity.lot_no = txtLotNo.Text.ToDecimal();
            entity.bf_qty = txtCount.Text.ToDecimal();
            entity.bal_qty = txtAdjust.Text.ToDecimal();
            entity.remark = txtRemarkDetails.Text;
            entity.created_by = "SYSTEM";
            entity.created_date = DateTime.Now;
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        private void ValidationHead(StockHead entity)
        {
            ValidationResults results = new ValidationResults();
            if (ddlPeriodGroup.SelectedIndex == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Period Group"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (entity.period_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Period"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (entity.warehouse_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Warehouse"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (results.Count > 0) { throw new ValidationException(results); }
        }
        private void ValidationDetail(StockDetail entity)
        {
            ValidationResults results = new ValidationResults();

            if (string.IsNullOrEmpty(txtAdjust.Text))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Adjust"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (Converts.ParseDecimalNullable(txtAdjust.Text) == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IncorrectFormatOne, "Adjust"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (entity.bal_qty <= 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.CompareValueMore, "Adjust", "0"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else
            {
                Material entityMaterial = new Material() { material_id = entity.material_id };
                entityMaterial = ServiceProvider.MaterialService.FindByKeys(entityMaterial, false);
                if (entity.bal_qty > entityMaterial.max_stock)
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.CompareValueLessOrEqual, "Adjust", "Max Stock"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
            }

            if (results.Count > 0) { throw new ValidationException(results); }
        }
        private void ClearDataDetail()
        {
            ddlMaterial.SelectedIndex = 0;
            txtLotNo.Text = string.Empty;
            txtCount.Text = string.Empty;
            txtAdjust.Text = string.Empty;
            txtRemarkDetails.Text = string.Empty;
            pictureBoxMaterial.Image = global::POS.Properties.Resources.image_not_found;
        }
        private StockHead SaveTransactionHead(StockHead entity)
        {
            if (base.FormMode == ObjectState.Add)
            {
                //insert in_tran_head
                entity.transaction_no = ServiceProvider.DocumentTypeService.GetDocumentNumberByDocumentTypeCode(this._documentTypeCode, entity.transaction_date);
                entity.stock_head_id = ServiceProvider.StockHeadService.Insert<long>(entity);
            }

            return entity;
        }
        private void SaveTransactionDetail(StockHead entityStockHead)
        {
            foreach (DataRow dr in this.dsStockDetail.Tables[0].Rows)
            {
                StockDetail entityDetail = new StockDetail();

                entityDetail.material_id = dr["material_id"].ToLong();                
                entityDetail.bal_qty = dr["Adjust"].ToDecimal();
                entityDetail.bf_qty = dr["Count"].ToDecimal();
                entityDetail.bf_date = DateTime.Now;
                entityDetail.lot_no = dr["Lot No."].ToDecimal();
                entityDetail.remark = dr["Remark"].ToStringNullable();
                entityDetail.stock_head_id = entityStockHead.stock_head_id;

                ServiceProvider.StockDetailService.Insert(entityDetail);
                SaveLots(entityDetail, entityStockHead);
            }
        }
        private void SaveLots(StockDetail entityDetail, StockHead entityStockHead)
        {
            //update into in_phy_lot
            PhyLot entityPhyLot = ServiceProvider.PhyLotService.GetPhyLot(entityDetail.material_id, entityStockHead.warehouse_id, entityDetail.lot_no, false);
            entityPhyLot.bal_qty = entityDetail.bal_qty;
            entityPhyLot.bf_qty = entityDetail.bf_qty;
            entityPhyLot.bf_date = entityDetail.bf_date;
            ServiceProvider.PhyLotService.Update(entityPhyLot);

            //update into in_log_lot
            LogLot entityLogLot = ServiceProvider.LogLotService.GetLogLot(entityDetail.material_id, entityStockHead.warehouse_id);
            entityLogLot.bal_qty = entityDetail.bal_qty;
            entityLogLot.bf_qty = entityDetail.bf_qty;
            entityLogLot.bf_date = entityDetail.bf_date;
            ServiceProvider.LogLotService.Update(entityLogLot);

            //Insert 
            BFLogical bfLogical = new BFLogical();
            bfLogical.period_id = entityStockHead.period_id;
            bfLogical.warehouse_id = entityStockHead.warehouse_id;
            bfLogical.material_id = entityDetail.material_id;
            bfLogical.bf_qty = entityDetail.bf_qty;
            bfLogical.bal_qty = entityDetail.bal_qty;
            ServiceProvider.BFLogicalService.Insert(bfLogical);

            BFPhysical bfPhysical = new BFPhysical();
            bfPhysical.period_id = entityStockHead.period_id;
            bfPhysical.warehouse_id = entityStockHead.warehouse_id;
            bfPhysical.material_id = entityDetail.material_id;
            bfPhysical.bf_qty = entityDetail.bf_qty;
            bfPhysical.bal_qty = entityDetail.bal_qty;
            bfPhysical.lot_no = entityDetail.lot_no;
            ServiceProvider.BFPhysicalService.Insert(bfPhysical);

        }
        private DataRow[] GetDataRowDetail(long material_id, decimal lot_no)
        {
            DataRow[] dr = (from row in this.dsStockDetail.Tables[0].AsEnumerable()
                            where row.Field<long>("material_id") == material_id
                              && row.Field<decimal>("Lot No.") == lot_no
                            select row).ToArray<DataRow>();
            return dr;
        }
        #endregion

        #region :: Event Control ::
        private void AddEditStockCount_Load(object sender, EventArgs e)
        {
            this._documentTypeID = ServiceProvider.DocumentTypeService.GetDocumentTypeIDByDocumentTypeCode(this._documentTypeCode);
            ddlPeriodGroup.Focus();
            LoadHeadData();
        }
        private void AddEditStockCount_saveHandler()
        {
            StockHead entity = GetHeadData();
            try
            {
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    this.ValidationHead(entity);

                    entity = this.SaveTransactionHead(entity);
                    this.SaveTransactionDetail(entity);
                    ServiceProvider.PeriodService.ClosePeriod(entity.period_id);
                    ts.Complete();
                }
                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }
        private void AddEditStockCount_resetHandler()
        {
            LoadHeadData();
        }
        public void baseGridDetail_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            if (base.FormMode == ObjectState.Edit) 
            {
                this.dsStockDetail = ServiceProvider.StockDetailService.GetStockDetail(base.FormKeyCode.ToLong());
            }
            else if (base.FormMode == ObjectState.Add)
            {
                this.dsStockDetail = ServiceProvider.StockDetailService.GetStockDetail(ddlPeriodGroup.SelectedValue.ToLong(), ddlWarehouse.SelectedValue.ToLong());
            }

            if (this.dsStockDetail != null && this.dsStockDetail.Tables.Count > 0)
            {
                foreach (DataRow dr in this.dsStockDetail.Tables[0].Rows)
                {
                    string lotNo = dr["Lot No."].ToStringNullable();
                    if (!string.IsNullOrEmpty(lotNo)) { dr["Lot No."] = string.Format(Format.DecimalNumberFormat, lotNo.ToDouble()); }

                    string count = dr["Count"].ToStringNullable();
                    if (!string.IsNullOrEmpty(count)) { dr["Count"] = string.Format(Format.DecimalNumberFormat, count.ToDouble()); }

                    string adjust = dr["Adjust"].ToStringNullable();
                    if (!string.IsNullOrEmpty(adjust)) { dr["Adjust"] = string.Format(Format.DecimalNumberFormat, adjust.ToDouble()); }
                }
            }

            baseGridDetail.HiddenColumnName = new List<string>() { "material_id", "stock_detail_id" };
            baseGridDetail.DataSourceDataSet = this.dsStockDetail;
            baseGridDetail.DataKeyName = new string[] { DataKeyName, "material_id", "Lot No." };
        }
        public void baseGridDetail_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            this.ClearDataDetail();
            txtCount.Focus();
            baseGridDetail.FormMode = ObjectState.Edit;
            baseGridDetail.DataKeyValue = new string[] { null, dataKey["material_id"].ToString(), dataKey["Lot No."].ToString() };
            this.LoadDetailData();
            this.EnableModeDetail();
        }
        public void baseGridDetail_onCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            object grd = sender;
            object val = e.Value;
            e.CellStyle.WrapMode = DataGridViewTriState.True;

            if (val != null)
            {
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
        }
        private void baseAddEditMasterDetail_saveHandler()
        {
            StockDetail entity = this.GetDetailData();
            try
            {
                this.ValidationDetail(entity);
                string adjust = string.Format(Format.DecimalNumberFormat, txtAdjust.Text.ToDecimal());

                if (baseGridDetail.FormMode == ObjectState.Edit)
                {
                    DataRow dr = this.GetDataRowDetail(baseGridDetail.DataKeyValue[1].ToLong(), baseGridDetail.DataKeyValue[2].ToDecimal()).First();
                    dr["Adjust"] = adjust;
                    dr["Remark"] = txtRemarkDetails.Text;
                }

                this.ClearDataDetail();
                txtAdjust.Focus();
                baseGridDetail.FormMode = ObjectState.Add;
                baseGridDetail.DataKeyValue = null;

                this.EnableModeDetail();
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }
        private void baseAddEditMasterDetail_resetHandler()
        {
            if (baseGridDetail.FormMode == ObjectState.Edit)
            {
                this.LoadDetailData();
            }
            else if (baseGridDetail.FormMode == ObjectState.Add)
            {
                this.ClearDataDetail();
            }
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                ValidationResults results = new ValidationResults();

                if (ddlPeriodGroup.SelectedIndex == 0)
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Period Group"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }

                if (ddlPeriod.SelectedIndex == 0)
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Period"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }

                if (ddlWarehouse.SelectedIndex == 0)
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Warehouse"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }

                if (results.Count == 0)
                {
                    this.dsStockDetail = ServiceProvider.StockDetailService.GetStockDetail(ddlPeriodGroup.SelectedValue.ToLong(), ddlWarehouse.SelectedValue.ToLong());
                    baseGridDetail.LoadData();

                    ddlPeriodGroup.Enabled = false;
                    ddlPeriod.Enabled = false;
                    ddlWarehouse.Enabled = false;
                    btnGenerate.Enabled = false;
                }
                else
                {
                    throw new ValidationException(results);
                }
            }
            catch (ValidationException ex)
            {
                base.formBase.ShowErrorMessage(ex);
            }
        }
        private void ddlPeriodGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            long PeriodGroupID = ddlPeriodGroup.SelectedValue.ToLong();
            ddlPeriod.DataSource = ServiceProvider.PeriodService.GetOpenPeriod(PeriodGroupID); ;
            ddlPeriod.ValueMember = "Value";
            ddlPeriod.DisplayMember = "Display";
        }
        #endregion :: Event Control ::
    }
}
