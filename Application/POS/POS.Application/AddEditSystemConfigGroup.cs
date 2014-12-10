using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POS.Control;
using POS.BL.Utilities;
using POS.BL.Service.SU;
using POS.BL.Entities.Entity;

namespace POS
{
    public partial class AddEditSystemConfigGroup : BaseUserContorl
    {
        #region :: Local Attribute ::
        SystemConfigGroupService service = new SystemConfigGroupService();
        #endregion
        #region :: Properties ::
        private string mode { get; set; }
        private string keyCode { get; set; }
        public AddEditSystemConfigGroup()
        {
            mode = ObjectState.Add;
            InitializeComponent();

        }
        public AddEditSystemConfigGroup(string Code)
        {
            mode = ObjectState.Update;
            keyCode = Code;
            InitializeComponent();

        }
        #endregion


        #region :: Private Function ::
        private void LoadData()
        {
            SystemConfigGroup entity = new SystemConfigGroup();
            if (mode == ObjectState.Update && !string.IsNullOrEmpty(keyCode))
            {
                entity.system_configuration_group_code = keyCode;
                entity = service.FindByKeys(entity, true);

                txtCode.Text = entity.system_configuration_group_code;
                txtName.Text = entity.system_configuration_group_name;
                txtDescription.Text = entity.system_configuration_group_description;
            }
            else
            {
                txtCode.Text = string.Empty;
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
            }
            EnableMode();
        }
        private void EnableMode()
        {
            if (mode == ObjectState.Update)
            {
                txtCode.Enabled = false;
            }
            else
            {
                txtCode.Enabled = true;
            }
        }
        private SystemConfigGroup GetData()
        {
            SystemConfigGroup entity = new SystemConfigGroup();
            entity.system_configuration_group_code = txtCode.Text;
            entity.system_configuration_group_name = txtName.Text;
            entity.system_configuration_group_description = txtDescription.Text;
            entity.created_by = "";
            entity.created_date = DateTime.Now;
            entity.updated_by = "";
            entity.updated_date = DateTime.Now;
            return entity;
        }
        #endregion

        #region :: Event Action ::
        private void btnSave_Click(object sender, EventArgs e)
        {
            SystemConfigGroup entity = GetData();


            if (mode == ObjectState.Add)
            {
                service.Insert(entity);
            }
            else
            {
                service.Update(entity);
            }
            TabPage tp = this.Parent as TabPage;
            TabControl tc = tp.Parent as TabControl;
            tc.SelectedIndex = 0;
            base.onNotifyReturnEvent(true);
        

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.onNotifyReturnEvent(false);
           
        }

        private void AddEditSystemConfigGroup_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion


    }
}
