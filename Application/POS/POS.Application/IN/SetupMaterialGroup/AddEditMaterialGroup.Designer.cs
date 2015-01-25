namespace POS.IN.SetupMaterialGroup
{
    partial class AddEditMaterialGroup
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
            this.txtMatGroupCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatGroupName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatGroupDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.baseAddEditMaster1.Location = new System.Drawing.Point(3, 3);
            this.baseAddEditMaster1.Name = "baseAddEditMaster1";
            this.baseAddEditMaster1.Size = new System.Drawing.Size(498, 51);
            this.baseAddEditMaster1.TabIndex = 0;
            this.baseAddEditMaster1.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.AddEditMaterialGroup_saveHandler);
            this.baseAddEditMaster1.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.AddEditMaterialGroup_resetHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Material Group Code";
            // 
            // txtMatGroupCode
            // 
            this.txtMatGroupCode.Location = new System.Drawing.Point(159, 90);
            this.txtMatGroupCode.Name = "txtMatGroupCode";
            this.txtMatGroupCode.Size = new System.Drawing.Size(152, 20);
            this.txtMatGroupCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Material Group Name";
            // 
            // txtMatGroupName
            // 
            this.txtMatGroupName.Location = new System.Drawing.Point(159, 117);
            this.txtMatGroupName.Name = "txtMatGroupName";
            this.txtMatGroupName.Size = new System.Drawing.Size(152, 20);
            this.txtMatGroupName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Material Group Description";
            // 
            // txtMatGroupDesc
            // 
            this.txtMatGroupDesc.Location = new System.Drawing.Point(159, 146);
            this.txtMatGroupDesc.Name = "txtMatGroupDesc";
            this.txtMatGroupDesc.Size = new System.Drawing.Size(152, 20);
            this.txtMatGroupDesc.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Active";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(159, 175);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 8;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // AddEditMaterialGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMatGroupDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMatGroupName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMatGroupCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseAddEditMaster1);
            this.Name = "AddEditMaterialGroup";
            this.Size = new System.Drawing.Size(460, 477);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.BaseAddEditMaster baseAddEditMaster1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatGroupCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatGroupName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatGroupDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkActive;
    }
}
