namespace POS.SU.SetupEmployee
{
    partial class AddEditEmployee
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtEmployeeNo = new POS.Control.BaseTextBox();
            this.txtFirstName = new POS.Control.BaseTextBox();
            this.txtMidName = new POS.Control.BaseTextBox();
            this.txtLastName = new POS.Control.BaseTextBox();
            this.txtUserName = new POS.Control.BaseTextBox();
            this.txtPassword = new POS.Control.BaseTextBox();
            this.SuspendLayout();
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.Description = "Employee No";
            this.txtEmployeeNo.Location = new System.Drawing.Point(106, 127);
            this.txtEmployeeNo.MaxLength = 50;
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(100, 20);
            this.txtEmployeeNo.TabIndex = 20;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Description = "First Name";
            this.txtFirstName.Location = new System.Drawing.Point(106, 158);
            this.txtFirstName.MaxLength = 300;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 27;
            // 
            // txtMidName
            // 
            this.txtMidName.Description = "Mid Name";
            this.txtMidName.Location = new System.Drawing.Point(282, 158);
            this.txtMidName.MaxLength = 300;
            this.txtMidName.Name = "txtMidName";
            this.txtMidName.Size = new System.Drawing.Size(100, 20);
            this.txtMidName.TabIndex = 29;
            // 
            // txtLastName
            // 
            this.txtLastName.Description = "Last Name";
            this.txtLastName.Location = new System.Drawing.Point(464, 158);
            this.txtLastName.MaxLength = 300;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 31;
            // 
            // txtUserName
            // 
            this.txtUserName.Description = "User Name";
            this.txtUserName.Location = new System.Drawing.Point(106, 190);
            this.txtUserName.MaxLength = 300;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 33;
            // 
            // txtPassword
            // 
            this.txtPassword.Description = "Password";
            this.txtPassword.Location = new System.Drawing.Point(282, 190);
            this.txtPassword.MaxLength = 300;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 35;
            // 
            // AddEditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtMidName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtEmployeeNo);
            this.Name = "AddEditEmployee";
            this.Size = new System.Drawing.Size(681, 334);
            this.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.AddEditEmployee_saveHandler);
            this.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.AddEditEmployee_resetHandler);
            this.Load += new System.EventHandler(this.AddEditEmployee_Load_1);
            this.Controls.SetChildIndex(this.txtEmployeeNo, 0);
            this.Controls.SetChildIndex(this.txtFirstName, 0);
            this.Controls.SetChildIndex(this.txtMidName, 0);
            this.Controls.SetChildIndex(this.txtLastName, 0);
            this.Controls.SetChildIndex(this.txtUserName, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.BaseTextBox txtEmployeeNo;
        private Control.BaseTextBox txtFirstName;
        private Control.BaseTextBox txtMidName;
        private Control.BaseTextBox txtLastName;
        private Control.BaseTextBox txtUserName;
        private Control.BaseTextBox txtPassword;




    }
}
