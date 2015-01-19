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

namespace POS.IN.IssueMaterial
{
    public partial class AddEditIssueMaterial : BaseAddEditMaster
    {
        #region :: Constructure ::
        public AddEditIssueMaterial()
        {
            base.FormMode = ObjectState.Add;
            InitializeComponent();
        }
        public AddEditIssueMaterial(string Code)
        {
            base.FormMode = ObjectState.Edit;
            base.FormKeyCode = Code;
            InitializeComponent();
        }
        #endregion :: Constructure ::

        #region :: Properties ::
        string DataKeyName = "tran_detail_id";
        private long _documentTypeID { get; set; }
        private string _documentTypeCode { get { return DocumentTypeCode.IN.IssueMaterial; } }
        private DataSet dsTranDetail { get; set; }
        private string _documentStatus { get; set; }
        #endregion :: Properties ::

        #region :: Private Function ::
        private void LoadHeadData()
        {
            TranHead entity = new TranHead();

            if (base.FormMode == ObjectState.Edit && !string.IsNullOrEmpty(base.FormKeyCode))
            {
                entity.tran_head_id = Converts.ParseLong(base.FormKeyCode);
                entity = ServiceProvider.TranHeadService.FindByKeys(entity, true);

                txtReferenceNo.Text = entity.reference_no;

                ddlReason.DataSource = ServiceProvider.ReasonService.GetReasonComboBoxDTOByDocumentTypeID(this._documentTypeID, entity.reason_id);
                ddlReason.ValueMember = "Value";
                ddlReason.DisplayMember = "Display";

                ddlReason.SelectedValue = entity.reason_id.ToString();

                if (entity.warehouse_id != null)
                {
                    rdoWarehouse.Checked = true;

                    ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID(new WareHouse() { warehouse_id = entity.warehouse_id.Value });
                    ddlWarehouse.ValueMember = "Value";
                    ddlWarehouse.DisplayMember = "Display";

                    ddlWarehouse.SelectedValue = entity.warehouse_id.Value.ToString();
                }
                else if (entity.is_waste != null && entity.is_waste.Value)
                {
                    rdoWaste.Checked = true;

                    ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                    ddlWarehouse.ValueMember = "Value";
                    ddlWarehouse.DisplayMember = "Display";
                }
                else if (!string.IsNullOrEmpty(entity.other_source))
                {
                    rdoOther.Checked = true;

                    ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                    ddlWarehouse.ValueMember = "Value";
                    ddlWarehouse.DisplayMember = "Display";

                    txtOther.Text = entity.other_source;
                }

                txtRemark.Text = entity.remark;
                lblDocumentNo.Text = entity.transaction_no;
                lblDocumentDate.Text = entity.transaction_date.ConvertDateToDisplay();
                lblStatus.Text = (entity.transaction_status == TransactionStatus.IN.FinalCode) ? TransactionStatus.IN.FinalText : TransactionStatus.IN.NormalText;
                this._documentStatus = entity.transaction_status;
            }
            else
            {
                txtReferenceNo.Text = string.Empty;

                ddlReason.DataSource = ServiceProvider.ReasonService.GetReasonComboBoxDTOByDocumentTypeID(this._documentTypeID);
                ddlReason.ValueMember = "Value";
                ddlReason.DisplayMember = "Display";

                rdoWarehouse.Checked = true;
                rdoWaste.Checked = false;
                rdoOther.Checked = false;

                ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                ddlWarehouse.ValueMember = "Value";
                ddlWarehouse.DisplayMember = "Display";

                txtRemark.Text = string.Empty;
                lblDocumentNo.Text = GeneralMessage.AutoRunningDocumentNo;
                lblDocumentDate.Text = DateTime.Now.ConvertDateToDisplay();
                lblStatus.Text = TransactionStatus.IN.NormalText;
            }

            InitialDetailData();
            EnableModeHead();
            EnableModeDetail();
        }
        private void LoadDetailData()
        {
            DataRow dr = this.GetDataRowDetail(baseGridDetail.DataKeyValue[1].ToLong(), baseGridDetail.DataKeyValue[2].ToLong()).First();

            this.ddlMaterial.SelectedValue = dr["material_id"].ToString();
            this.ddlWarehouseDetails.SelectedValue = dr["warehouse_id_dest"].ToString();

            string lotNo = dr["Lot No."].ToStringNullable();
            if (!string.IsNullOrEmpty(lotNo)) { lotNo = string.Format(Format.DecimalNumberFormat, lotNo.ToDouble()); }

            txtLotNo.Text = lotNo;

            string quantity = dr["Quantity"].ToStringNullable();
            if (!string.IsNullOrEmpty(quantity)) { quantity = string.Format(Format.DecimalNumberFormat, quantity.ToDouble()); }

            txtQuantity.Text = quantity;

            txtRemarkDetails.Text = dr["Remark"].ToStringNullable();
            lblUOM.Text = dr["UOM"].ToStringNullable();

            if (dr.RowState != DataRowState.Added)
            {
                baseAddEditMasterDetail.btnSaveEnable = false;
                baseAddEditMasterDetail.btnResetEnable = false;
                ddlMaterial.Enabled = false;
                ddlWarehouseDetails.Enabled = false;
                txtLotNo.Enabled = false;
                txtQuantity.Enabled = false;
                txtRemarkDetails.Enabled = false;
            }
        }
        private void InitialDetailData()
        {
            this.ddlMaterial.DataSource = ServiceProvider.MaterialService.FindByActiveOrID();
            this.ddlMaterial.ValueMember = "Value";
            this.ddlMaterial.DisplayMember = "Display";

            this.ddlWarehouseDetails.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
            this.ddlWarehouseDetails.ValueMember = "Value";
            this.ddlWarehouseDetails.DisplayMember = "Display";

            lblUOM.Text = string.Empty;

            baseAddEditMasterDetail.btnBackVisible = false;

            baseGridDetail.onAddNewRow += new EventHandler(baseGridDetail_onAddNewRow);
            baseGridDetail.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(baseGridDetail_onSelectedDataRow);
            baseGridDetail.onDeleteDataRows += new EventHandler<Control.GridView.RowsEventArgs>(baseGridDetail_onDeleteDataRows);
            baseGridDetail.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(baseGridDetail_onLoadDataGrid);
            baseGridDetail.onCellFormatting += new EventHandler<DataGridViewCellFormattingEventArgs>(baseGridDetail_onCellFormatting);
            baseGridDetail.LoadData();
        }
        private void EnableModeHead()
        {
            this.baseGridDetail.btnSearchVisible = false;

            if (base.FormMode == ObjectState.Edit)
            {                
                this.btnLoadPortFolio.Visible = false;

                if (this._documentStatus == TransactionStatus.IN.NormalCode)
                {
                    ddlReason.Enabled = true;
                    rdoWaste.Enabled = true;
                    rdoWarehouse.Enabled = true;
                    rdoOther.Enabled = true;
                    ddlWarehouse.Enabled = false;
                    txtOther.Enabled = false;
                    txtRemark.Enabled = true;
                    base.btnResetEnable = true;
                    base.btnSaveEnable = true;
                    
                    if (rdoWarehouse.Checked) { ddlWarehouse.Enabled = true; }
                    if (rdoOther.Checked) { txtOther.Enabled = true; }

                    this.baseGridDetail.btnAddEnable = true;
                    this.baseGridDetail.btnDeleteEnable = true;
                }
                else if (this._documentStatus == TransactionStatus.IN.FinalCode)
                {
                    txtReferenceNo.Enabled = false;
                    ddlReason.Enabled = false;
                    rdoWaste.Enabled = false;
                    rdoWarehouse.Enabled = false;
                    rdoOther.Enabled = false;
                    ddlWarehouse.Enabled = false;
                    txtOther.Enabled = false;
                    txtRemark.Enabled = false;
                    base.btnResetEnable = false;
                    base.btnSaveEnable = false;

                    this.baseGridDetail.btnAddEnable = false;
                    this.baseGridDetail.btnDeleteEnable = false;
                }
            }
            else
            {
                txtReferenceNo.Enabled = true;
                rdoOther.Enabled = true;
                rdoWaste.Enabled = true;
                rdoWarehouse.Enabled = true;
                ddlReason.Enabled = true;
                txtRemark.Enabled = true;
                base.btnResetEnable = true;
                base.btnSaveEnable = true;

                this.baseGridDetail.btnAddEnable = true;
                this.baseGridDetail.btnDeleteEnable = true;

                this.btnLoadPortFolio.Visible = true;
            }
        }
        private void EnableModeDetailEdit()
        {
            if (baseGridDetail.FormMode == ObjectState.Edit)
            {
                ddlMaterial.Enabled = false;
                ddlWarehouseDetails.Enabled = false;
            }
            else
            {
                ddlMaterial.Enabled = true;
                ddlWarehouseDetails.Enabled = true;
                txtLotNo.Enabled = true;
                txtQuantity.Enabled = true;
                txtRemarkDetails.Enabled = true;
                baseAddEditMasterDetail.btnSaveEnable = true;
                baseAddEditMasterDetail.btnResetEnable = true;
            }
        }
        private void EnableModeDetail()
        {
            if (base.FormMode == ObjectState.Edit)
            {
                if (this._documentStatus == TransactionStatus.IN.NormalCode)
                {
                    ddlMaterial.Enabled = true;
                    ddlWarehouseDetails.Enabled = true;
                    txtLotNo.Enabled = true;
                    txtQuantity.Enabled = true;
                    txtRemarkDetails.Enabled = true;
                    baseAddEditMasterDetail.btnSaveEnable = true;
                    baseAddEditMasterDetail.btnResetEnable = true;
                }
                else if (this._documentStatus == TransactionStatus.IN.FinalCode)
                {
                    ddlMaterial.Enabled = false;
                    ddlWarehouseDetails.Enabled = false;
                    txtLotNo.Enabled = false;
                    txtQuantity.Enabled = false;
                    txtRemarkDetails.Enabled = false;
                    baseAddEditMasterDetail.btnSaveEnable = false;
                    baseAddEditMasterDetail.btnResetEnable = false;
                }
            }
            else if (base.FormMode == ObjectState.Add)
            {
                ddlMaterial.Enabled = true;
                ddlWarehouseDetails.Enabled = true;
                txtLotNo.Enabled = true;
                txtQuantity.Enabled = true;
                txtRemarkDetails.Enabled = true;
                baseAddEditMasterDetail.btnSaveEnable = true;
                baseAddEditMasterDetail.btnResetEnable = true;
            }
        }
        private TranHead GetHeadData()
        {
            TranHead entity = new TranHead();
            if (base.FormMode == ObjectState.Edit)
            {
                entity.tran_head_id = base.FormKeyCode.ToLong();
                entity = ServiceProvider.TranHeadService.FindByKeys(entity, false);
            }

            entity.reference_no = txtReferenceNo.Text;
            entity.transaction_date = DateTime.Now;
            entity.document_type_id = this._documentTypeID;
            entity.reason_id = Converts.ParseLong(ddlReason.SelectedValue.ToString());

            if (rdoWaste.Checked) { entity.is_waste = true; entity.warehouse_id = null; entity.other_source = null; }
            else if (rdoWarehouse.Checked) { entity.warehouse_id = Converts.ParseLong(ddlWarehouse.SelectedValue.ToString()); entity.is_waste = null; entity.other_source = null; }
            else if (rdoOther.Checked) { entity.other_source = txtOther.Text; entity.warehouse_id = null; entity.is_waste = null; }

            entity.remark = txtRemark.Text;
            if (base.FormMode == ObjectState.Add)
            {
                entity.created_by = "SYSTEM";
                entity.created_date = DateTime.Now;
                entity.transaction_status = TransactionStatus.IN.NormalCode;
            }
            else if (base.FormMode == ObjectState.Edit)
            {
                entity.transaction_status = TransactionStatus.IN.FinalCode;
            }
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        private TranDetail GetDetailData()
        {
            TranDetail entity = new TranDetail();
            entity.material_id = Converts.ParseLong(ddlMaterial.SelectedValue.ToString());
            entity.warehouse_id_dest = Converts.ParseLong(ddlWarehouseDetails.SelectedValue.ToString());
            entity.lot_no = Converts.ParseDecimalNullable(txtLotNo.Text);
            entity.quantity = Converts.ParseDecimalNullable(txtQuantity.Text);
            entity.remark = txtRemarkDetails.Text;

            if (base.FormMode == ObjectState.Add)
            {
                entity.created_by = "SYSTEM";
                entity.created_date = DateTime.Now;
            }
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        private void ValidationHead(TranHead entity)
        {
            ValidationResults results = new ValidationResults();
            if (entity.reason_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Reason"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (rdoWarehouse.Checked && entity.warehouse_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Destination Warehouse"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (rdoOther.Checked && string.IsNullOrEmpty(entity.other_source))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Destination other"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }

            if (!(this.dsTranDetail.Tables.Count > 0 && this.dsTranDetail.Tables[0].Rows.Count > 0))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Details"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (results.Count > 0) { throw new ValidationException(results); }
        }
        private void ValidationDetail(TranDetail entity)
        {
            ValidationResults results = new ValidationResults();
            if (baseGridDetail.FormMode == ObjectState.Add)
            {
                if (entity.material_id == 0)
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Material"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
                else
                {
                    if (entity.warehouse_id_dest != 0)
                    {
                        DataRow[] drs = this.GetDataRowDetail(entity.material_id, entity.warehouse_id_dest);
                        if (drs.Count() >= 1)
                        {
                            ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsDuplicate, "Material"), this, string.Empty, string.Empty, null);
                            results.AddResult(result);
                        }
                    }
                }

                if (entity.warehouse_id_dest == 0)
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Warehouse"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
            }

            if (string.IsNullOrEmpty(txtLotNo.Text))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Lot No."), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (Converts.ParseDoubleNullable(txtLotNo.Text) == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IncorrectFormatOne, "Lot No."), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (entity.lot_no == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.CompareValueMore, "Lot No.", "0"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else {
                if (entity.material_id != 0 && entity.warehouse_id_dest != 0)
                {
                    PhyLot entityPhyLot = ServiceProvider.PhyLotService.GetPhyLot(entity.material_id, entity.warehouse_id_dest, entity.lot_no.Value, false);
                    if (entityPhyLot == null || entityPhyLot.phy_lot_id == 0)
                    {
                        ValidationResult result = new ValidationResult(string.Format(ErrorMessage.NotExistsField, "Lot No.", entity.lot_no.Value), this, string.Empty, string.Empty, null);
                        results.AddResult(result);
                    }
                    else {
                        if ((entityPhyLot.bal_qty - entity.quantity) < 0)
                        {
                            ValidationResult result = new ValidationResult(string.Format(ErrorMessage.CompareValueMore, "Quantity", "material in stock"), this, string.Empty, string.Empty, null);
                            results.AddResult(result);
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Quantity"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (Converts.ParseDoubleNullable(txtQuantity.Text) == null)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IncorrectFormatOne, "Quantity"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (entity.quantity == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.CompareValueMore, "Quantity", "0"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }

            if (results.Count > 0) { throw new ValidationException(results); }
        }
        private void ClearDataDetail()
        {
            ddlMaterial.SelectedIndex = 0;
            ddlWarehouseDetails.SelectedIndex = 0;
            txtLotNo.Text = "1";
            txtQuantity.Text = string.Empty;
            txtRemarkDetails.Text = string.Empty;
            pictureBoxMaterial.Image = global::POS.Properties.Resources.image_not_found;
        }
        private double GetLastLotNo()
        {
            if (ddlMaterial.SelectedIndex != 0 && ddlWarehouseDetails.SelectedIndex != 0)
            {
                PhyLot entity = new PhyLot() { warehouse_id = ddlWarehouseDetails.SelectedValue.ToLong(), material_id = ddlMaterial.SelectedValue.ToLong() };
                return ServiceProvider.PhyLotService.GetCurrentLotNo(entity) + 1;
            }
            return 1;
        }
        private TranHead SaveTransactionHead(TranHead entity)
        {
            if (base.FormMode == ObjectState.Add)
            {
                //insert in_tran_head
                entity.transaction_no = ServiceProvider.DocumentTypeService.GetDocumentNumberByDocumentTypeCode(this._documentTypeCode, entity.transaction_date);
                entity.tran_head_id = ServiceProvider.TranHeadService.Insert<long>(entity);
            }
            else if (base.FormMode == ObjectState.Edit)
            {
                ServiceProvider.TranHeadService.Update(entity);
            }

            return entity;
        }
        private void SaveTransactionDetail(TranHead entityTranHead)
        {
            foreach (DataRow dr in this.dsTranDetail.Tables[0].Rows)
            {
                TranDetail entityDetail = new TranDetail();
                if (dr.RowState == DataRowState.Added)
                {
                    entityDetail.material_id = dr["material_id"].ToLong();
                    entityDetail.warehouse_id_dest = dr["warehouse_id_dest"].ToLong();
                    entityDetail.quantity = dr["Quantity"].ToDecimal();
                    entityDetail.remark = dr["Remark"].ToStringNullable();
                    entityDetail.lot_no = dr["Lot No."].ToDecimal();
                    entityDetail.tran_head_id = entityTranHead.tran_head_id;

                    ServiceProvider.TranDetailService.Insert(entityDetail);
                    SaveLots(entityDetail, entityTranHead);
                }
            }
        }
        private void SaveLots(TranDetail entityDetail, TranHead entityTranHead)
        {
            //get in_material
            Material entityMaterial = new Material() { material_id = entityDetail.material_id };
            entityMaterial = ServiceProvider.MaterialService.FindByKeys(entityMaterial, false);

            //update into in_phy_lot
            PhyLot entityPhyLot = ServiceProvider.PhyLotService.GetPhyLot(entityDetail.material_id, entityDetail.warehouse_id_dest, entityDetail.lot_no.Value);
            entityPhyLot.bal_qty = (entityPhyLot.bal_qty - entityDetail.quantity.Value);
            ServiceProvider.PhyLotService.Update(entityPhyLot);

            //update into in_log_lot
            LogLot entityLogLot = ServiceProvider.LogLotService.GetLogLot(entityDetail.material_id, entityDetail.warehouse_id_dest);
            entityLogLot.bal_qty = (entityLogLot.bal_qty - entityDetail.quantity.Value);
            ServiceProvider.LogLotService.Update(entityLogLot);
        }
        private void AddNewTranDetail()
        {
            this.ClearDataDetail();
            ddlMaterial.Focus();
            baseGridDetail.FormMode = ObjectState.Add;
            baseGridDetail.DataKeyValue = null;
            EnableModeDetailEdit();
        }
        private DataRow[] GetDataRowDetail(long material_id, long warehouse_id_dest)
        {
            DataRow[] dr = (from row in this.dsTranDetail.Tables[0].AsEnumerable()
                            where row.Field<long>("material_id") == material_id
                              && row.Field<long>("warehouse_id_dest") == warehouse_id_dest
                            select row).ToArray<DataRow>();
            return dr;
        }
        #endregion

        #region :: Event Control ::
        private void AddEditIssueMaterial_Load(object sender, EventArgs e)
        {
            this._documentTypeID = ServiceProvider.DocumentTypeService.GetDocumentTypeIDByDocumentTypeCode(this._documentTypeCode);
            txtReferenceNo.Focus();
            LoadHeadData();
        }
        private void AddEditIssueMaterial_saveHandler()
        {
            TranHead entity = GetHeadData();
            try
            {
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    this.ValidationHead(entity);

                    entity = this.SaveTransactionHead(entity);
                    this.SaveTransactionDetail(entity);
                    ts.Complete();
                }
                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }
        private void AddEditIssueMaterial_resetHandler()
        {
            LoadHeadData();
        }
        private void rdoWaste_CheckedChanged(object sender, EventArgs e)
        {            
            this.ddlWarehouse.Enabled = false;
            this.txtOther.Enabled = false;
        }
        private void rdoWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlWarehouse.Enabled = true;
            this.txtOther.Enabled = false;
        }
        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlWarehouse.Enabled = false;
            this.txtOther.Enabled = true;
        }
        public void baseGridDetail_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            if (!(this.dsTranDetail != null && this.dsTranDetail.Tables.Count > 0 && this.dsTranDetail.Tables[0].Rows.Count > 0))
            {
                this.dsTranDetail = ServiceProvider.TranDetailService.GetGridTranDetail(Converts.ParseLong(base.FormKeyCode));
            }

            if (this.dsTranDetail.Tables.Count > 0)
            {
                foreach (DataRow dr in this.dsTranDetail.Tables[0].Rows)
                {
                    string lotNo = dr["Lot No."].ToStringNullable();
                    if (!string.IsNullOrEmpty(lotNo)) { dr["Lot No."] = string.Format(Format.DecimalNumberFormat, lotNo.ToDouble()); }

                    string quantity = dr["Quantity"].ToStringNullable();
                    if (!string.IsNullOrEmpty(quantity)) { dr["Quantity"] = string.Format(Format.DecimalNumberFormat, quantity.ToDouble()); }
                }
            }

            baseGridDetail.HiddenColumnName = new List<string>() { "tran_detail_id", "tran_head_id", "material_id", "warehouse_id_dest" };
            baseGridDetail.DataSourceDataSet = this.dsTranDetail;
            baseGridDetail.DataKeyName = new string[] { DataKeyName, "material_id", "warehouse_id_dest" };
        }
        public void baseGridDetail_onAddNewRow(object sender, EventArgs e)
        {
            AddNewTranDetail();
        }
        public void baseGridDetail_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            this.ClearDataDetail();
            txtLotNo.Focus();
            baseGridDetail.FormMode = ObjectState.Edit;
            baseGridDetail.DataKeyValue = new string[] { null, dataKey["material_id"].ToString(), dataKey["warehouse_id_dest"].ToString() };
            this.LoadDetailData();
            ddlMaterial.Enabled = false;
            ddlWarehouseDetails.Enabled = false;
            EnableModeDetailEdit();
        }
        public void baseGridDetail_onDeleteDataRows(object sender, Control.GridView.RowsEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in e.RowsSelected)
                {
                    DataRow dr = this.dsTranDetail.Tables[0].Rows[row.Index];
                    if (dr.RowState == DataRowState.Added)
                    {
                        if (baseGridDetail.FormMode == ObjectState.Edit && baseGridDetail.DataKeyValue[1].ToLong() == dr["material_id"].ToLong() && baseGridDetail.DataKeyValue[2].ToLong() == dr["warehouse_id_dest"].ToLong()) { this.AddNewTranDetail(); }
                        dr.Delete();
                    }
                    else
                    {
                        MessageBox.Show("Some of data Cannot delete or modified", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (ValidationException ex)
            {
                base.formBase.ShowErrorMessage(ex);
            }
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
            TranDetail entity = this.GetDetailData();
            try
            {
                this.ValidationDetail(entity);
                string lotNo = string.Format(Format.DecimalNumberFormat, txtLotNo.Text.ToDouble());
                string quantity = string.Format(Format.DecimalNumberFormat, txtQuantity.Text.ToDouble());

                if (baseGridDetail.FormMode == ObjectState.Edit)
                {
                    DataRow dr = this.GetDataRowDetail(baseGridDetail.DataKeyValue[1].ToLong(), baseGridDetail.DataKeyValue[2].ToLong()).First();
                    dr["Quantity"] = quantity;
                    dr["Remark"] = txtRemarkDetails.Text;
                    dr["Lot No."] = lotNo;
                }
                else if (baseGridDetail.FormMode == ObjectState.Add || baseGridDetail.FormMode == ObjectState.Nothing)
                {
                    DataRow dr = this.dsTranDetail.Tables[0].NewRow();
                    if (string.IsNullOrEmpty(base.FormKeyCode))
                    {
                        dr["tran_head_id"] = base.FormKeyCode.ToLong();
                    }

                    dr["material_id"] = ddlMaterial.SelectedValue.ToLong();
                    dr["warehouse_id_dest"] = ddlWarehouseDetails.SelectedValue.ToLong();
                    dr["Quantity"] = quantity;
                    dr["Remark"] = txtRemarkDetails.Text;
                    dr["Material"] = ddlMaterial.Text.Substring(ddlMaterial.Text.LastIndexOf(":") + 1);
                    dr["Warehouse"] = ddlWarehouseDetails.Text.Substring(ddlWarehouseDetails.Text.LastIndexOf(":") + 1);
                    dr["Lot No."] = lotNo;
                    dr["UOM"] = lblUOM.Text;
                    this.dsTranDetail.Tables[0].Rows.Add(dr);
                }

                this.ClearDataDetail();
                ddlMaterial.Focus();
                baseGridDetail.FormMode = ObjectState.Add;
                baseGridDetail.DataKeyValue = null;
                EnableModeDetailEdit();
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
        #endregion :: Event Control ::
    }
}