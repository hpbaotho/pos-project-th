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

namespace POS.IN.ReceiveMaterial
{
    public partial class AddEditReceiveMaterial : BaseAddEditMaster
    {
        #region :: Constructure ::
        public AddEditReceiveMaterial()
        {
            base.FormMode = ObjectState.Add;
            InitializeComponent();
        }
        public AddEditReceiveMaterial(string Code)
        {
            base.FormMode = ObjectState.Edit;
            base.FormKeyCode = Code;
            InitializeComponent();
        }
        #endregion :: Constructure ::

        #region :: Properties ::
        string DataKeyName = "tran_detail_id";
        private long _documentTypeID { get; set; }
        private string _documentTypeCode { get { return DocumentTypeCode.IN.ReceiveMaterial; } }
        private DataSet dsTranDetail { get; set; }
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

                if (entity.supplier_id != null)
                {
                    rdoSupplier.Checked = true;

                    ddlSupplier.DataSource = ServiceProvider.SupplierService.FindByActiveOrID(new Supplier() { supplier_id = entity.supplier_id.Value });
                    ddlSupplier.ValueMember = "Value";
                    ddlSupplier.DisplayMember = "Display";

                    ddlSupplier.SelectedValue = entity.supplier_id.Value.ToString();

                    ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                    ddlWarehouse.ValueMember = "Value";
                    ddlWarehouse.DisplayMember = "Display";
                }
                else if (entity.warehouse_id != null)
                {
                    rdoWarehouse.Checked = true;

                    ddlSupplier.DataSource = ServiceProvider.SupplierService.FindByActiveOrID();
                    ddlSupplier.ValueMember = "Value";
                    ddlSupplier.DisplayMember = "Display";

                    ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID(new WareHouse() { warehouse_id = entity.warehouse_id.Value });
                    ddlWarehouse.ValueMember = "Value";
                    ddlWarehouse.DisplayMember = "Display";

                    ddlWarehouse.SelectedValue = entity.warehouse_id.Value.ToString();
                }
                else if (!string.IsNullOrEmpty(entity.other_source))
                {
                    rdoOther.Checked = true;

                    ddlSupplier.DataSource = ServiceProvider.SupplierService.FindByActiveOrID();
                    ddlSupplier.ValueMember = "Value";
                    ddlSupplier.DisplayMember = "Display";

                    ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                    ddlWarehouse.ValueMember = "Value";
                    ddlWarehouse.DisplayMember = "Display";
                }

                txtRemark.Text = entity.remark;
                lblDocumentNo.Text = entity.transaction_no;
                lblDocumentDate.Text = entity.transaction_date.ConvertDateToDisplay();

            }
            else
            {
                txtReferenceNo.Text = string.Empty;

                ddlReason.DataSource = ServiceProvider.ReasonService.GetReasonComboBoxDTOByDocumentTypeID(this._documentTypeID);
                ddlReason.ValueMember = "Value";
                ddlReason.DisplayMember = "Display";

                rdoSupplier.Checked = true;
                rdoWarehouse.Checked = false;
                rdoOther.Checked = false;

                ddlSupplier.DataSource = ServiceProvider.SupplierService.FindByActiveOrID();
                ddlSupplier.ValueMember = "Value";
                ddlSupplier.DisplayMember = "Display";

                ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                ddlWarehouse.ValueMember = "Value";
                ddlWarehouse.DisplayMember = "Display";

                txtRemark.Text = string.Empty;
                lblDocumentNo.Text = GeneralMessage.AutoRunningDocumentNo;
                lblDocumentDate.Text = DateTime.Now.ConvertDateToDisplay();
            }

            InitialDetailData();
            EnableModeHead();
        }
        private void LoadDetailData(int index)
        {
            DataRow dr = this.dsTranDetail.Tables[0].Rows[index];

            this.ddlMaterial.SelectedValue = dr["material_id"].ToString();
            this.ddlWarehouseDetails.SelectedValue = dr["warehouse_id_dest"].ToString();

            txtLotNo.Text = dr["lot_no"].ToStringNullable();
            txtQuantity.Text = dr["quantity"].ToStringNullable();
            txtRemarkDetails.Text = dr["remark"].ToStringNullable();
        }
        private void InitialDetailData()
        {
            this.ddlMaterial.DataSource = ServiceProvider.MaterialService.FindByActiveOrID();
            this.ddlMaterial.ValueMember = "Value";
            this.ddlMaterial.DisplayMember = "Display";


            this.ddlWarehouseDetails.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
            this.ddlWarehouseDetails.ValueMember = "Value";
            this.ddlWarehouseDetails.DisplayMember = "Display";

            baseGridDetail.onAddNewRow += new EventHandler(baseGridDetail_onAddNewRow);
            baseGridDetail.onSelectedDataRow += new EventHandler<Control.GridView.RowEventArgs>(baseGridDetail_onSelectedDataRow);
            baseGridDetail.onDeleteDataRows += new EventHandler<Control.GridView.RowsEventArgs>(baseGridDetail_onDeleteDataRows);
            baseGridDetail.onLoadDataGrid += new EventHandler<Control.GridView.DataBindArgs>(baseGridDetail_onLoadDataGrid);
            //baseGridDetail.onCellFormatting += new EventHandler<DataGridViewCellFormattingEventArgs>(baseGridDetail_onCellFormatting);
            baseGridDetail.LoadData();
        }
        private void EnableModeHead()
        {
            if (base.FormMode == ObjectState.Edit)
            {
                txtReferenceNo.Enabled = false;
                ddlReason.Enabled = false;
                rdoSupplier.Enabled = false;
                rdoWarehouse.Enabled = false;
                rdoOther.Enabled = false;
                ddlSupplier.Enabled = false;
                ddlWarehouse.Enabled = false;
                txtOther.Enabled = false;
                txtRemark.Enabled = false;
                base.btnResetEnable = false;
                base.btnSaveEnable = false;

                this.baseGridDetail.btnAddEnable = false;
                this.baseGridDetail.btnDeleteEnable = false;
                this.baseGridDetail.btnSearchEnable = true;

                this.btnLoadPortFolio.Enabled = false;

                this.EnableModeDetail(false);
            }
            else
            {
                txtReferenceNo.Enabled = true;
                rdoOther.Enabled = true;
                rdoSupplier.Enabled = true;
                rdoWarehouse.Enabled = true;
                ddlReason.Enabled = true;
                txtRemark.Enabled = true;
                ddlSupplier.Enabled = true;
                base.btnResetEnable = true;
                base.btnSaveEnable = true;

                this.baseGridDetail.btnAddEnable = true;
                this.baseGridDetail.btnDeleteEnable = true;
                this.baseGridDetail.btnSearchEnable = true;

                this.btnLoadPortFolio.Enabled = true;
            }
        }
        private void EnableModeDetail(bool Enable)
        {
            ddlMaterial.Enabled = Enable;
            ddlWarehouseDetails.Enabled = Enable;
            txtLotNo.Enabled = Enable;
            txtQuantity.Enabled = Enable;
            txtRemarkDetails.Enabled = Enable;
            baseAddEditMasterDetail.btnSaveEnable = Enable;
            baseAddEditMasterDetail.btnResetEnable = Enable;
            baseAddEditMasterDetail.btnBackEnable = Enable;
        }
        private TranHead GetHeadData()
        {
            TranHead entity = new TranHead();

            entity.reference_no = txtReferenceNo.Text;
            entity.transaction_date = DateTime.Now;
            entity.document_type_id = this._documentTypeID;
            entity.reason_id = Converts.ParseLong(ddlReason.SelectedValue.ToString());

            if (rdoSupplier.Checked) { entity.supplier_id = Converts.ParseLong(ddlSupplier.SelectedValue.ToString()); }
            else if (rdoWarehouse.Checked) { entity.warehouse_id = Converts.ParseLong(ddlWarehouse.SelectedValue.ToString()); }
            else if (rdoOther.Checked) { entity.other_source = txtOther.Text; }

            entity.remark = txtRemark.Text;
            if (base.FormMode == ObjectState.Add)
            {
                entity.created_by = "SYSTEM";
                entity.created_date = DateTime.Now;
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
            entity.lot_no = Converts.ParseLong(txtLotNo.Text);
            entity.quantity = Converts.ParseLong(txtQuantity.Text);
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

            if (string.IsNullOrEmpty(entity.reference_no))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Reference No."), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (entity.reason_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Reason"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            if (rdoSupplier.Checked && entity.supplier_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Source Supllier"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (rdoWarehouse.Checked && entity.warehouse_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Source Warehouse"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (rdoOther.Checked && string.IsNullOrEmpty(entity.remark))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Source other"), this, string.Empty, string.Empty, null);
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

            if (entity.material_id == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Material"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }

            if (entity.warehouse_id_dest == 0)
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Warehouse"), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }

            if (string.IsNullOrEmpty(txtLotNo.Text))
            {
                ValidationResult result = new ValidationResult(string.Format(ErrorMessage.IsRequired, "Lot No."), this, string.Empty, string.Empty, null);
                results.AddResult(result);
            }
            else if (Converts.ParseLongNullable(txtLotNo.Text) == null)
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
            else if (Converts.ParseLongNullable(txtQuantity.Text) == null)
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
            txtLotNo.Text = string.Empty;
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
        #endregion

        #region :: Event Control ::
        private void AddEditReceiveMaterial_Load(object sender, EventArgs e)
        {
            this._documentTypeID = ServiceProvider.DocumentTypeService.GetDocumentTypeIDByDocumentTypeCode(this._documentTypeCode);
            txtReferenceNo.Focus();
            LoadHeadData();
        }
        private void AddEditReceiveMaterial_saveHandler()
        {
            TranHead entity = GetHeadData();
            try
            {
                this.ValidationHead(entity);

                if (base.FormMode == ObjectState.Add)
                {
                    entity.transaction_no = ServiceProvider.DocumentTypeService.GetDocumentNumberByDocumentTypeCode(this._documentTypeCode, entity.transaction_date);
                    long transactionHeadID = ServiceProvider.TranHeadService.Insert<long>(entity);
                    
                    foreach(DataRow dr in this.dsTranDetail.Tables[0].Rows)
                    {
                        TranDetail entityDetail = dr.ToDTO<TranDetail>();
                        entityDetail.tran_head_id = transactionHeadID;
                        ServiceProvider.TranDetailService.Insert(entityDetail);
                    }
                }
                else
                {
                    ServiceProvider.TranHeadService.Update(entity);
                }
                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }
        private void AddEditReceiveMaterial_resetHandler()
        {
            LoadHeadData();
        }
        private void rdoSupplier_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlSupplier.Enabled = true;
            this.ddlWarehouse.Enabled = false;
            this.txtOther.Enabled = false;
        }
        private void rdoWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlSupplier.Enabled = false;
            this.ddlWarehouse.Enabled = true;
            this.txtOther.Enabled = false;
        }
        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlSupplier.Enabled = false;
            this.ddlWarehouse.Enabled = false;
            this.txtOther.Enabled = true;
        }
        public void baseGridDetail_onLoadDataGrid(object sender, POS.Control.GridView.DataBindArgs e)
        {
            if (!(this.dsTranDetail != null && this.dsTranDetail.Tables.Count > 0 && this.dsTranDetail.Tables[0].Rows.Count > 0))
            {
                TranDetail entity = new TranDetail() { tran_head_id = Converts.ParseLong(base.FormKeyCode) };
                this.dsTranDetail = ServiceProvider.TranDetailService.FindDataSetByParentKey(entity);
            }

            baseGridDetail.DataSourceDataSet = this.dsTranDetail;
            baseGridDetail.DataKeyName = new string[] { DataKeyName };
        }
        public void baseGridDetail_onAddNewRow(object sender, EventArgs e)
        {
            this.ClearDataDetail();
            ddlMaterial.Focus();
            baseGridDetail.FormMode = ObjectState.Add;
            baseGridDetail.DataKeyValue = null;
            this.EnableModeDetail(true);
        }
        public void baseGridDetail_onSelectedDataRow(object sender, Control.GridView.RowEventArgs e)
        {
            Dictionary<string, object> dataKey = (Dictionary<string, object>)sender;
            this.ClearDataDetail();
            ddlMaterial.Focus();
            baseGridDetail.FormMode = ObjectState.Edit;
            baseGridDetail.DataKeyValue = new string[] { e.RowIndex.ToString() };
            this.LoadDetailData(e.RowIndex);
            this.EnableModeDetail(true);
        }
        public void baseGridDetail_onDeleteDataRows(object sender, Control.GridView.RowsEventArgs e)
        {
            try
            {
                foreach(DataGridViewRow row in e.RowsSelected)
                {
                    this.dsTranDetail.Tables[0].Rows.RemoveAt(row.Index);
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
        private void baseAddEditMasterDetail_backHandler()
        {
            this.ClearDataDetail();
        }
        private void baseAddEditMasterDetail_saveHandler()
        {
            TranDetail entity = this.GetDetailData();
            try
            {
                this.ValidationDetail(entity);
                DataRow dr = this.dsTranDetail.Tables[0].NewRow();
                entity.ToDataRow(ref dr);
                this.dsTranDetail.Tables[0].Rows.Add(dr);

                this.ClearDataDetail();
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
                this.LoadDetailData(Converts.ParseInt(baseGridDetail.DataKeyValue[0].ToString()));
            }
            else if (baseGridDetail.FormMode == ObjectState.Add)
            {
                this.ClearDataDetail();
            }
        }
        #endregion :: Event Control ::

        private void ddlMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLotNo.Text = this.GetLastLotNo().ToString();
        }

        private void ddlWarehouseDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLotNo.Text = this.GetLastLotNo().ToString();
        }


    }
}
