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

namespace POS.IN.ReceiveMaterial
{
    public partial class AddEditReceiveMaterial : BaseAddEditMaster
    {
         #region :: Properties ::
        private ObjectState mode { get; set; }
        private string keyCode { get; set; }
        public AddEditReceiveMaterial()
        {

            mode = ObjectState.Add;
            InitializeComponent();
            this.Load += new EventHandler(AddEditReceiveMaterial_Load);
            
        }
        public AddEditReceiveMaterial(string Code)
        {

            mode = ObjectState.Edit;
            keyCode = Code;
            InitializeComponent();
            this.Load += new EventHandler(AddEditReceiveMaterial_Load);
        }
        #endregion
      
        #region :: Private Function ::
        private void AddEditReceiveMaterial_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            TranHead entity = new TranHead();
            if (mode == ObjectState.Edit && !string.IsNullOrEmpty(keyCode))
            {
                
                entity.tran_head_id = Converts.ParseLong(keyCode);
                entity = ServiceProvider.TranHeadService.FindByKeys(entity, true);

                txtReferenceNo.Text = entity.reference_no;
                ddlReason.SelectedValue = entity.reason_id;
                

                ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                ddlWarehouse.ValueMember = "Value";
                ddlWarehouse.DisplayMember = "Display";

                //ddlSupplier.DataSource = ServiceProvider.SupplierService.FindSupplierActive();
                //ddlSupplier.ValueMember = "supplier_id";
                //ddlSupplier.DisplayMember = "supplier_id";


                
                                
                if (entity.supplier_id != null) { rdoSupplier.Checked = true; }
                else if (entity.warehouse_id != null) { rdoWarehouse.Checked = true; }
                else if (!string.IsNullOrEmpty(entity.other_source)) { rdoOther.Checked = true; }

                txtRemark.Text = entity.remark;

                lblDocumentNo.Text = "";
                lblDocumentDate.Text = "";

            }
            else
            {
                txtReferenceNo.Text = string.Empty;
                //ddlReason.SelectedIndex = 0;

                rdoSupplier.Checked = false;
                rdoWarehouse.Checked = false;
                rdoOther.Checked = false;

                txtReferenceNo.Text = string.Empty;

                //lblStatus.Text = "";
                lblDocumentNo.Text = "";
                lblDocumentDate.Text = "";

            }
            EnableMode();
        }
        private void EnableMode()
        {
            if (mode == ObjectState.Edit)
            {
                txtReferenceNo.Enabled = false;
                txtOther.Enabled = false;
                txtRemark.Enabled = false;
                ddlSupplier.Enabled = false;
                ddlWarehouse.Enabled = false;
                ddlReason.Enabled = false;
                base.btnResetEnable = false;
                base.btnSaveEnable = false;
                rdoOther.Enabled = false;
                rdoSupplier.Enabled = false;
                rdoWarehouse.Enabled = false;
            }
            else
            {
                txtReferenceNo.Enabled = true;
                txtOther.Enabled = true;
                txtRemark.Enabled = true;
                ddlSupplier.Enabled = true;
                ddlWarehouse.Enabled = true;
                ddlReason.Enabled = true;
                base.btnResetEnable = true;
                base.btnSaveEnable = true;
                rdoOther.Enabled = true;
                rdoSupplier.Enabled = true;
                rdoWarehouse.Enabled = true;
            }
        }
        private TranHead GetData()
        {
            TranHead entity = new TranHead();


            entity.reference_no = txtReferenceNo.Text;
            entity.transaction_date = DateTime.Now;
            entity.transaction_no = "";

         //   entity.reason_id = Converts.ParseLong(ddlReason.SelectedValue.ToString());

            if (rdoSupplier.Checked) {  }
            else if (rdoWarehouse.Checked ) {  }
            else if (rdoOther.Checked) {  }

            entity.remark = txtRemark.Text;
            entity.created_by = "SYSTEM";
            entity.created_date = DateTime.Now;
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        #endregion

        #region :: Event Action ::
        private void AddEditReceiveMaterial_saveHandler()
        {
            TranHead entity = GetData();
            if (mode == ObjectState.Add)
            {
                ServiceProvider.TranHeadService.Insert(entity);
            }
            else
            {
                ServiceProvider.TranHeadService.Update(entity);
            }
            base.formBase.ShowMessage(GeneralMessage.SaveComplete);
        }

        private void AddEditReceiveMaterial_resetHandler()
        {
            LoadData();
        }
        #endregion
    }
}
