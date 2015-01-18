namespace POS.SO.MappingMenu
{
    partial class AddEditMappingMenu
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
            this.txtMenuCode = new POS.Control.BaseTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtMenuName = new POS.Control.BaseTextBox();
            this.txtMenuDescription = new POS.Control.BaseTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdDetail = new POS.Control.GridView.BaseGrid();
            this.baseAddEditMaster1 = new POS.Control.BaseAddEditMaster();
            this.txtQuantity = new POS.Control.BaseTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlBomHead = new System.Windows.Forms.ComboBox();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMenuCode
            // 
            this.txtMenuCode.Description = "Menu Code";
            this.txtMenuCode.Location = new System.Drawing.Point(163, 32);
            this.txtMenuCode.MaxLength = 50;
            this.txtMenuCode.Name = "txtMenuCode";
            this.txtMenuCode.Size = new System.Drawing.Size(418, 20);
            this.txtMenuCode.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.txtMenuName);
            this.groupBox1.Controls.Add(this.txtMenuDescription);
            this.groupBox1.Controls.Add(this.txtMenuCode);
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 141);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Head";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Active";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(163, 111);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 27;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtMenuName
            // 
            this.txtMenuName.Description = "Menu Name";
            this.txtMenuName.Location = new System.Drawing.Point(163, 58);
            this.txtMenuName.MaxLength = 50;
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(418, 20);
            this.txtMenuName.TabIndex = 26;
            // 
            // txtMenuDescription
            // 
            this.txtMenuDescription.Description = "Menu Description";
            this.txtMenuDescription.Location = new System.Drawing.Point(163, 84);
            this.txtMenuDescription.MaxLength = 50;
            this.txtMenuDescription.Name = "txtMenuDescription";
            this.txtMenuDescription.Size = new System.Drawing.Size(418, 20);
            this.txtMenuDescription.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdDetail);
            this.groupBox2.Controls.Add(this.baseAddEditMaster1);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ddlBomHead);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 517);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // grdDetail
            // 
            this.grdDetail.btnAddEnable = true;
            this.grdDetail.btnDeleteEnable = true;
            this.grdDetail.btnSearchEnable = false;
            this.grdDetail.DataKeyName = null;
            this.grdDetail.DataKeyValue = null;
            this.grdDetail.DataSourceDataSet = null;
            this.grdDetail.DataSourceTable = null;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdDetail.FormMode = ObjectState.Nothing;
            this.grdDetail.HiddenColumnName = null;
            this.grdDetail.Location = new System.Drawing.Point(3, 137);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(1018, 377);
            this.grdDetail.TabIndex = 5;
            // 
            // baseAddEditMaster1
            // 
            this.baseAddEditMaster1.BackColor = System.Drawing.Color.Transparent;
            this.baseAddEditMaster1.btnBackEnable = false;
            this.baseAddEditMaster1.btnResetEnable = true;
            this.baseAddEditMaster1.btnSaveEnable = true;
            this.baseAddEditMaster1.Location = new System.Drawing.Point(0, 19);
            this.baseAddEditMaster1.Name = "baseAddEditMaster1";
            this.baseAddEditMaster1.Size = new System.Drawing.Size(172, 59);
            this.baseAddEditMaster1.TabIndex = 4;
            this.baseAddEditMaster1.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.AddEditDetail_saveHandler);
            this.baseAddEditMaster1.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.AddEditDetail_resetHandler);
            this.baseAddEditMaster1.Load += new System.EventHandler(this.AddEditDetail_Load);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Description = "Quantity";
            this.txtQuantity.Location = new System.Drawing.Point(163, 111);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(418, 20);
            this.txtQuantity.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bill Of Material Head";
            // 
            // ddlBomHead
            // 
            this.ddlBomHead.FormattingEnabled = true;
            this.ddlBomHead.Location = new System.Drawing.Point(163, 84);
            this.ddlBomHead.Name = "ddlBomHead";
            this.ddlBomHead.Size = new System.Drawing.Size(418, 21);
            this.ddlBomHead.TabIndex = 0;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.groupBox2);
            this.pnlDetail.Location = new System.Drawing.Point(3, 205);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1024, 517);
            this.pnlDetail.TabIndex = 25;
            // 
            // AddEditMappingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEditMappingMenu";
            this.Size = new System.Drawing.Size(1024, 736);
            this.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.AddEditHead_saveHandler);
            this.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.AddEditHead_resetHandler);
            this.Load += new System.EventHandler(this.AddEditHead_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.pnlDetail, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.BaseTextBox txtMenuCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private Control.BaseTextBox txtMenuName;
        private Control.BaseTextBox txtMenuDescription;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.ComboBox ddlBomHead;
        private System.Windows.Forms.Label label2;
        private Control.BaseTextBox txtQuantity;
        private Control.BaseAddEditMaster baseAddEditMaster1;
        private Control.GridView.BaseGrid grdDetail;







    }
}
