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

namespace POS.IN.ReceiveOrder
{
    public partial class AddEditReceiveOrder : BaseAddEditMaster
    {
        #region :: Constructure ::
        public AddEditReceiveOrder()
        {
            base.FormMode = ObjectState.Add;
            InitializeComponent();
        }
        public AddEditReceiveOrder(string Code)
        {
            base.FormMode = ObjectState.Edit;
            base.FormKeyCode = Code;
            InitializeComponent();
        }
        #endregion :: Constructure ::

        #region :: Properties ::
        string DataKeyName = "tran_detail_id";
        private long _documentTypeID { get; set; }
        private string _documentTypeCode { get { return DocumentTypeCode.IN.ReceiveOrder; } }
        private DataSet dsTranDetail { get; set; }
        private string _documentStatus { get; set; }
        #endregion :: Properties ::

        #region :: Private Function ::
        private void LoadHeadData()
        {
            TranHead entity = new TranHead();

            if (base.FormMode == ObjectState.Edit && !string.IsNullOrEmpty(base.FormKeyCode))
            {
                //entity.tran_head_id = Converts.ParseLong(base.FormKeyCode);
                //entity = ServiceProvider.TranHeadService.FindByKeys(entity, true);                

                //ddlReason.DataSource = ServiceProvider.ReasonService.GetReasonComboBoxDTOByDocumentTypeID(this._documentTypeID, entity.reason_id);
                //ddlReason.ValueMember = "Value";
                //ddlReason.DisplayMember = "Display";

                //ddlReason.SelectedValue = entity.reason_id.ToString();

                //WareHouse entityWarehouse = new WareHouse() { warehouse_id = entity.warehouse_id.Value };
                //ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID(entityWarehouse);
                //ddlWarehouse.ValueMember = "Value";
                //ddlWarehouse.DisplayMember = "Display";

                //ddlWarehouse.SelectedValue = entity.warehouse_id.Value.ToString();

                //txtRemark.Text = entity.remark;
                //lblDocumentNo.Text = entity.transaction_no;
                //lblDocumentDate.Text = entity.transaction_date.ConvertDateToDisplay();
                //lblStatus.Text = (entity.transaction_status == TransactionStatus.IN.FinalCode) ? TransactionStatus.IN.FinalText : TransactionStatus.IN.NormalText;
                //this._documentStatus = entity.transaction_status;
            }
            else
            {
                ddlOrderNo.DataSource = ServiceProvider.SaleOrderHeaderService.GetAllCancelOrder();
                ddlOrderNo.ValueMember = "Value";
                ddlOrderNo.DisplayMember = "Display";

                ddlReason.DataSource = ServiceProvider.ReasonService.GetReasonComboBoxDTOByDocumentTypeID(this._documentTypeID);
                ddlReason.ValueMember = "Value";
                ddlReason.DisplayMember = "Display";

                ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                ddlWarehouse.ValueMember = "Value";
                ddlWarehouse.DisplayMember = "Display";

                List<ComboBoxDTO> lstComboBox = new List<ComboBoxDTO>();
                lstComboBox.SetPleaseSelect();
                ddlMenu.DataSource = lstComboBox;
                ddlMenu.ValueMember = "Value";
                ddlMenu.DisplayMember = "Display";

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

            lblUOM.Text = string.Empty;

            baseAddEditMasterDetail.btnBackVisible = false;

            //baseGridDetail.onAddNewRow += new EventHandler(baseGridDetail_onAddNewRow);
            baseGridDetail.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(baseGridDetail_onSelectedDataRow);
            //baseGridDetail.onDeleteDataRows += new EventHandler<Control.GridView.RowsEventArgs>(baseGridDetail_onDeleteDataRows);
            baseGridDetail.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(baseGridDetail_onLoadDataGrid);
            baseGridDetail.onCellFormatting += new EventHandler<DataGridViewCellFormattingEventArgs>(baseGridDetail_onCellFormatting);
            baseGridDetail.LoadData();
        }
        private void EnableModeHead()
        {
            this.baseGridDetail.btnSearchVisible = false;

            if (base.FormMode == ObjectState.Edit)
            {
                ddlOrderNo.Enabled = false;

                if (this._documentStatus == TransactionStatus.IN.NormalCode)
                {
                    ddlReason.Enabled = true;
                    ddlWarehouse.Enabled = false;
                    txtRemark.Enabled = true;
                    base.btnResetEnable = true;
                    base.btnSaveEnable = true;

                    this.baseGridDetail.btnAddEnable = true;
                    this.baseGridDetail.btnDeleteEnable = true;
                }
                else if (this._documentStatus == TransactionStatus.IN.FinalCode)
                {
                    ddlReason.Enabled = false;
                    ddlWarehouse.Enabled = false;
                    txtRemark.Enabled = false;
                    base.btnResetEnable = false;
                    base.btnSaveEnable = false;

                    this.baseGridDetail.btnAddEnable = false;
                    this.baseGridDetail.btnDeleteEnable = false;
                }
            }
            else
            {
                ddlOrderNo.Enabled = true;
                ddlReason.Enabled = true;
                txtRemark.Enabled = true;
                base.btnResetEnable = true;
                base.btnSaveEnable = true;

                this.baseGridDetail.btnAddEnable = true;
                this.baseGridDetail.btnDeleteEnable = true;
            }
        }
        private void EnableModeDetailEdit()
        {
            if (baseGridDetail.FormMode == ObjectState.Edit)
            {
                ddlMaterial.Enabled = false;
            }
            else
            {
                ddlMaterial.Enabled = true;
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
                    txtLotNo.Enabled = true;
                    txtQuantity.Enabled = true;
                    txtRemarkDetails.Enabled = true;
                    baseAddEditMasterDetail.btnSaveEnable = true;
                    baseAddEditMasterDetail.btnResetEnable = true;
                }
                else if (this._documentStatus == TransactionStatus.IN.FinalCode)
                {
                    ddlMaterial.Enabled = false;
                    txtLotNo.Enabled = false;
                    txtQuantity.Enabled = false;
                    txtRemarkDetails.Enabled = false;
                    baseAddEditMasterDetail.btnSaveEnable = false;
                    baseAddEditMasterDetail.btnResetEnable = false;
                }
            }
            else if (base.FormMode == ObjectState.Add)
            {
                ddlMaterial.Enabled = false;
                txtLotNo.Enabled = false;
                txtQuantity.Enabled = false;
                txtRemarkDetails.Enabled = true;
                baseAddEditMasterDetail.btnSaveEnable = false;
                baseAddEditMasterDetail.btnResetEnable = false;                
                baseGridDetail.btnAddVisible = false;
                baseGridDetail.btnDeleteVisible = false;
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

            //entity.or = txtOrderNo.Text;
            entity.transaction_date = DateTime.Now;
            entity.document_type_id = this._documentTypeID;
            entity.reason_id = Converts.ParseLong(ddlReason.SelectedValue.ToString());
            entity.warehouse_id = ddlWarehouse.SelectedValue.ToLong();

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
            if (base.FormMode == ObjectState.Add)
            {
                if (entity.order_no_id != null)
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Order No."), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
                if (ddlMenu.SelectedIndex == 0)
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Menu"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
                if (entity.warehouse_id == 0)
                {
                    ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Warehose"), this, string.Empty, string.Empty, null);
                    results.AddResult(result);
                }
            }
            if (entity.reason_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Reason"), this, string.Empty, string.Empty, null);
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
            else
            {
                if (entity.warehouse_id_dest != 0 && entity.material_id != 0)
                {
                    if (!ServiceProvider.PhyLotService.CheckLimitMaterial(entity.material_id, entity.warehouse_id_dest, entity.quantity.Value))
                    {
                        ValidationResult result = new ValidationResult(string.Format(ErrorMessage.CompareValueLessOrEqual, "Quantity", "Max Stock"), this, string.Empty, string.Empty, null);
                        results.AddResult(result);
                    }
                }
            }

            if (results.Count > 0) { throw new ValidationException(results); }
        }
        private void ClearDataDetail()
        {
            ddlMaterial.SelectedIndex = 0;
            txtLotNo.Text = "1";
            txtQuantity.Text = string.Empty;
            txtRemarkDetails.Text = string.Empty;
            pictureBoxMaterial.Image = global::POS.Properties.Resources.image_not_found;
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
            entityPhyLot.bal_qty = (entityPhyLot.bal_qty + entityDetail.quantity.Value);
            entityPhyLot.expire_date = entityTranHead.transaction_date.AddDays(entityMaterial.shelf_life);
            ServiceProvider.PhyLotService.Update(entityPhyLot);

            //update into in_log_lot
            LogLot entityLogLot = ServiceProvider.LogLotService.GetLogLot(entityDetail.material_id, entityDetail.warehouse_id_dest);
            entityLogLot.bal_qty = (entityLogLot.bal_qty + entityDetail.quantity.Value);
            ServiceProvider.LogLotService.Update(entityLogLot);
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
        private void AddEditReceiveOrder_Load(object sender, EventArgs e)
        {
            this._documentTypeID = ServiceProvider.DocumentTypeService.GetDocumentTypeIDByDocumentTypeCode(this._documentTypeCode);
            ddlOrderNo.Focus();
            LoadHeadData();
        }
        private void AddEditReceiveOrder_saveHandler()
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
        private void AddEditReceiveOrder_resetHandler()
        {
            LoadHeadData();
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

            baseGridDetail.HiddenColumnName = new List<string>() { "tran_detail_id", "tran_head_id", "material_id" };
            baseGridDetail.DataSourceDataSet = this.dsTranDetail;
            baseGridDetail.DataKeyName = new string[] { DataKeyName, "material_id" };
        }
        public void baseGridDetail_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            this.ClearDataDetail();
            txtLotNo.Focus();
            baseGridDetail.FormMode = ObjectState.Edit;
            baseGridDetail.DataKeyValue = new string[] { null, dataKey["material_id"].ToString() };
            this.LoadDetailData();
            ddlMaterial.Enabled = false;
            EnableModeDetailEdit();
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
                    dr["Quantity"] = quantity;
                    dr["Remark"] = txtRemarkDetails.Text;
                    dr["Material"] = ddlMaterial.Text.Substring(ddlMaterial.Text.LastIndexOf(":") + 1);
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
        private void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.dsTranDetail = ServiceProvider.MaterialService.GetMaterialFromMenuOrder(ddlMenu.SelectedValue.ToLong());
        }
        #endregion :: Event Control ::

        private void ddlOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrderNo.SelectedIndex != 0)
            {
                ddlMenu.DataSource = ServiceProvider.SaleOrderDetailService.GetCancelMenu(ddlOrderNo.SelectedValue.ToLong());
                ddlMenu.ValueMember = "Value";
                ddlMenu.DisplayMember = "Display";
            }
        }
    }
}