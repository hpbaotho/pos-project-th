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

namespace POS.IN.SendMaterial
{
    public partial class AddEditSendMaterial : BaseAddEditMaster
    {
        #region :: Properties ::
        private ObjectState mode { get; set; }
        private string keyCode { get; set; }
        public AddEditSendMaterial()
        {
            mode = ObjectState.Add;
            InitializeComponent();
            this.Load += new EventHandler(AddEditSendMaterial_Load);
        }
        public AddEditSendMaterial(string Code)
        {
            mode = ObjectState.Edit;
            keyCode = Code;
            InitializeComponent();
            this.Load += new EventHandler(AddEditSendMaterial_Load);
        }
        #endregion
      
        #region :: Private Function ::
        private void AddEditSendMaterial_Load(object sender, EventArgs e)
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


                //ddlWarehouse.DataSource = ServiceProvider.WareHouseService.FindByActiveOrID();
                ddlWarehouse.ValueMember = "warehouse_id";
                ddlWarehouse.DisplayMember = "warehouse_id";

              
            

                txtRemark.Text = entity.remark;

                lblStatus.Text = "";
                lblDocumentNo.Text = "";
                lblDocumentNo.Text = "";

            }
            else
            {
                txtReferenceNo.Text = string.Empty;

                lblStatus.Text = "";
                lblDocumentNo.Text = "";
                lblDocumentNo.Text = "";

            }
            EnableMode();
        }
        private void EnableMode()
        {
            if (mode == ObjectState.Edit)
            {
                txtReferenceNo.Enabled = false;
                txtRemark.Enabled = false;
                ddlWarehouse.Enabled = false;
                base.btnResetEnable = false;
                base.btnSaveEnable = false;

            }
            else
            {
                txtReferenceNo.Enabled = true;
                txtRemark.Enabled = true;
                ddlWarehouse.Enabled = true;
                base.btnResetEnable = true;
                base.btnSaveEnable = true;

            }
        }
        private TranHead GetData()
        {
            TranHead entity = new TranHead();


            entity.reference_no = txtReferenceNo.Text;
            entity.transaction_date = DateTime.Now;
            entity.transaction_no = "";

            //   entity.reason_id = Converts.ParseLong(ddlReason.SelectedValue.ToString());


            entity.remark = txtRemark.Text;
            entity.created_by = "SYSTEM";
            entity.created_date = DateTime.Now;
            entity.updated_by = "SYSTEM";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        #endregion
    }
}
