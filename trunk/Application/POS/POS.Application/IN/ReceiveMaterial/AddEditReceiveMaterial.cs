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
            this.Load += new EventHandler(AddEditEmployee_Load);
        }
        public AddEditReceiveMaterial(string Code)
        {
            mode = ObjectState.Edit;
            keyCode = Code;
            InitializeComponent();
            this.Load += new EventHandler(AddEditEmployee_Load);
        }
        #endregion
      
        #region :: Private Function ::
        private void AddEditEmployee_Load(object sender, EventArgs e)
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

                if (entity.supplier_id != null) { rdoSupplier.Checked = true; }
                else if (entity.warehouse_id != null) { rdoWarehouse.Checked = true; }
                else if (!string.IsNullOrEmpty(entity.other_source)) { rdoOther.Checked = true; }

                txtRemark.Text = entity.remark;

                lblStatus.Text = "";
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

                lblStatus.Text = "";
                lblDocumentNo.Text = "";
                lblDocumentDate.Text = "";
            }
            EnableMode();
        }
        private void EnableMode()
        {
            if (mode == ObjectState.Edit)
            {
                //txtEmployeeNo.Enabled = false;
            }
            else
            {
                //txtEmployeeNo.Enabled = true;
            }
        }
        private TranHead GetData()
        {
            TranHead entity = new TranHead();


            entity.reference_no = txtReferenceNo.Text;
            
            entity.reason_id = Converts.ParseLong(ddlReason.SelectedValue.ToString());

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
        private void AddEditEmployee_saveHandler()
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

        private void AddEditEmployee_resetHandler()
        {
            LoadData();
        }
        #endregion
    }
}
