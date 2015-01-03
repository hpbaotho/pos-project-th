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

namespace POS.IN.ReceiveMaterial
{
    public partial class AddEditReceiveMaterial : BaseAddEditMaster
    {
         #region :: Properties ::
        private string mode { get; set; }
        private string keyCode { get; set; }
        public AddEditReceiveMaterial()
        {
            mode = ObjectState.Add;
            InitializeComponent();
            this.Load += new EventHandler(AddEditEmployee_Load);
        }
        public AddEditReceiveMaterial(string Code)
        {
            mode = ObjectState.Update;
            keyCode = Code;
            InitializeComponent();
            this.Load += new EventHandler(AddEditEmployee_Load);
        }
        #endregion
      
        #region :: Private Function ::
        private void AddEditEmployee_Load(object sender, EventArgs e)
        {
            //LoadData();
        }
        //private void LoadData()
        //{
        //    Employee entity = new Employee();
        //    if (mode == ObjectState.Update && !string.IsNullOrEmpty(keyCode))
        //    {
        //        entity.employee_id = Converts.ParseLong(keyCode);
        //        entity = ServiceProvider.EmployeeService.FindByKeys(entity, true);

        //        txtEmployeeNo.Text = entity.employee_no;
        //        txtFirstName.Text = entity.first_name;
        //        txtMidName.Text = entity.mid_name;
        //        txtLastName.Text = entity.last_name;
        //    }
        //    else
        //    {
        //        txtEmployeeNo.Text = string.Empty;
        //        txtFirstName.Text = string.Empty;
        //        txtMidName.Text = string.Empty;
        //        txtLastName.Text = string.Empty;
        //    }
        //    EnableMode();
        //}
        //private void EnableMode()
        //{
        //    if (mode == ObjectState.Update)
        //    {
        //        txtEmployeeNo.Enabled = false;
        //    }
        //    else
        //    {
        //        txtEmployeeNo.Enabled = true;
        //    }
        //}
        //private Employee GetData()
        //{
        //    Employee entity = new Employee();
        //    entity.employee_id = Converts.ParseLong(keyCode);
        //    entity.employee_group_id = 1;
        //    entity.employee_no = txtEmployeeNo.Text;
        //    entity.first_name = txtFirstName.Text;
        //    entity.mid_name = txtMidName.Text;
        //    entity.last_name = txtLastName.Text;
        //    entity.created_by = "SYSTEM";
        //    entity.created_date = DateTime.Now;
        //    entity.updated_by = "SYSTEM";
        //    entity.updated_date = DateTime.Now;
        //    return entity;
        //}
        //#endregion

        //#region :: Event Action ::
        //private void AddEditEmployee_saveHandler()
        //{
        //    Employee entity = GetData();
        //    if (mode == ObjectState.Add)
        //    {
        //        ServiceProvider.EmployeeService.Insert(entity);
        //    }
        //    else
        //    {
        //        ServiceProvider.EmployeeService.Update(entity);
        //    }
        //    base.formBase.ShowMessage(GeneralMessage.SaveComplete);
        //}

        //private void AddEditEmployee_resetHandler()
        //{
        //    LoadData();
        //}
        #endregion
    }
}
