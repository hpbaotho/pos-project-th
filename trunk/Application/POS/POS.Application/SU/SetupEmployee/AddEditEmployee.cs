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
using Core.Standards.Converters;
using POS.BL;
using Core.Standards.Exceptions;
using Core.Standards.Validations;

namespace POS.SU.SetupEmployee
{
    public partial class AddEditEmployee : BaseAddEditMaster
    {
        #region :: Properties ::
        private ObjectState mode { get; set; }
        private string keyCode { get; set; }
        public AddEditEmployee()
        {
            mode = ObjectState.Add;
            InitializeComponent();
            this.Load += new EventHandler(AddEditEmployee_Load);
        }
        public AddEditEmployee(string Code)
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
            Employee entity = new Employee();
            if (mode == ObjectState.Edit && !string.IsNullOrEmpty(keyCode))
            {
                entity.employee_id = Converts.ParseLong(keyCode);
                entity = ServiceProvider.EmployeeService.FindByKeys(entity, true);

                txtEmployeeNo.Text = entity.employee_no;
                txtFirstName.Text = entity.first_name;
                txtMidName.Text = entity.mid_name;
                txtLastName.Text = entity.last_name;
                txtUserName.Text = entity.user_name;
                txtPassword.Text = entity.user_password;
            }
            else
            {
                txtEmployeeNo.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtMidName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
            EnableMode();
        }
        private void EnableMode()
        {
            if (mode == ObjectState.Edit)
            {
                txtEmployeeNo.Enabled = false;
            }
            else
            {
                txtEmployeeNo.Enabled = true;
            }
        }
        private Employee GetData()
        {
            Employee entity = new Employee();
            entity.employee_id = Converts.ParseLong(keyCode);
            entity.employee_group_id = 1;
            entity.employee_no = txtEmployeeNo.Text;
            entity.first_name = txtFirstName.Text;
            entity.mid_name = txtMidName.Text;
            entity.last_name = txtLastName.Text;
            entity.user_name = txtUserName.Text;
            entity.user_password = txtPassword.Text;
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
            try
            {
                Employee entity = GetData();
                if (mode == ObjectState.Add)
                {
                    ServiceProvider.EmployeeService.Insert(entity, new string[] { ValidationRuleset.Insert });
                }
                else
                {
                    ServiceProvider.EmployeeService.Update(entity, new string[] { ValidationRuleset.Update });
                }
                base.formBase.ShowMessage(GeneralMessage.SaveComplete);
            }
            catch (ValidationException ex)
            {
                throw ex;
            }
        }

        private void AddEditEmployee_resetHandler()
        {
            LoadData();
        }
        #endregion

        private void AddEditEmployee_Load_1(object sender, EventArgs e)
        {

        }
    }
}
