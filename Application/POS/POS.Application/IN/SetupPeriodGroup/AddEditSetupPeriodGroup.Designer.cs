namespace POS.IN.SetupPeriodGroup
{
    partial class AddEditSetupPeriodGroup
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
            this.baseAddEditMaster1 = new POS.Control.BaseAddEditMaster();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPeriodGrCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPeriodGrName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPeriodGrDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // baseAddEditMaster1
            // 
            this.baseAddEditMaster1.BackColor = System.Drawing.Color.Transparent;
            this.baseAddEditMaster1.btnBackEnable = true;
            this.baseAddEditMaster1.btnBackVisible = true;
            this.baseAddEditMaster1.btnResetEnable = true;
            this.baseAddEditMaster1.btnResetVisible = true;
            this.baseAddEditMaster1.btnSaveEnable = true;
            this.baseAddEditMaster1.btnSaveVisible = true;
            this.baseAddEditMaster1.Location = new System.Drawing.Point(0, 3);
            this.baseAddEditMaster1.Name = "baseAddEditMaster1";
            this.baseAddEditMaster1.Size = new System.Drawing.Size(498, 54);
            this.baseAddEditMaster1.TabIndex = 0;
            this.baseAddEditMaster1.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.AddEditSetupPeriodGroup_saveHandler);
            this.baseAddEditMaster1.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.AddEditSetupPeriodGroup_resetHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Period Group Code";
            // 
            // txtPeriodGrCode
            // 
            this.txtPeriodGrCode.Location = new System.Drawing.Point(163, 81);
            this.txtPeriodGrCode.MaxLength = 20;
            this.txtPeriodGrCode.Name = "txtPeriodGrCode";
            this.txtPeriodGrCode.Size = new System.Drawing.Size(143, 20);
            this.txtPeriodGrCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Period Group Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(312, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 54;
            this.label15.Text = "*";
            // 
            // txtPeriodGrName
            // 
            this.txtPeriodGrName.Location = new System.Drawing.Point(163, 109);
            this.txtPeriodGrName.MaxLength = 1000;
            this.txtPeriodGrName.Name = "txtPeriodGrName";
            this.txtPeriodGrName.Size = new System.Drawing.Size(143, 20);
            this.txtPeriodGrName.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(312, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Period Group Description";
            // 
            // txtPeriodGrDesc
            // 
            this.txtPeriodGrDesc.Location = new System.Drawing.Point(163, 136);
            this.txtPeriodGrDesc.MaxLength = 1000;
            this.txtPeriodGrDesc.Name = "txtPeriodGrDesc";
            this.txtPeriodGrDesc.Size = new System.Drawing.Size(143, 20);
            this.txtPeriodGrDesc.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Active";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(163, 165);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 60;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // AddEditSetupPeriodGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPeriodGrDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPeriodGrName);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPeriodGrCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseAddEditMaster1);
            this.Name = "AddEditSetupPeriodGroup";
            this.Size = new System.Drawing.Size(498, 438);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.BaseAddEditMaster baseAddEditMaster1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPeriodGrCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPeriodGrName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPeriodGrDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkActive;
    }
}
