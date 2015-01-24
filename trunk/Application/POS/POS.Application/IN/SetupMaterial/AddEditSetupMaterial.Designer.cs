namespace POS.IN.SetupMaterial
{
    partial class AddEditSetupMaterial
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMaterialCode = new POS.Control.BaseTextBox();
            this.txtMaterialName = new POS.Control.BaseTextBox();
            this.txtMaterialDescription = new POS.Control.BaseTextBox();
            this.txtMaterialPic = new POS.Control.BaseTextBox();
            this.txtMaxStock = new POS.Control.NumericTextBox();
            this.txtMinStock = new POS.Control.NumericTextBox();
            this.txtShelfLife = new POS.Control.NumericTextBox();
            this.txtMaterialCost = new POS.Control.NumericTextBox();
            this.txtAcceptableVariance = new POS.Control.NumericTextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.cboUOMReceive = new System.Windows.Forms.ComboBox();
            this.cboUOMCount = new System.Windows.Forms.ComboBox();
            this.cboUOMUse = new System.Windows.Forms.ComboBox();
            this.picMaterial = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new POS.Control.BaseButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picMaterial)).BeginInit();
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
            this.baseAddEditMaster1.Size = new System.Drawing.Size(435, 52);
            this.baseAddEditMaster1.TabIndex = 0;
            this.baseAddEditMaster1.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.AddEditSetupMaterial_saveHandler);
            this.baseAddEditMaster1.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.AddEditSetupMaterial_resetHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Material Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Material Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "UOM Receive";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "UOM Count";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "UOM Use";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Active";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Maximum Stock";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Minimum Stock";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Shelf life";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 345);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Material Cost";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 371);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Acceptable Variance";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 396);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Material Picture";
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Description = "";
            this.txtMaterialCode.Location = new System.Drawing.Point(149, 88);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(159, 20);
            this.txtMaterialCode.TabIndex = 14;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Description = "";
            this.txtMaterialName.Location = new System.Drawing.Point(149, 114);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(159, 20);
            this.txtMaterialName.TabIndex = 17;
            // 
            // txtMaterialDescription
            // 
            this.txtMaterialDescription.Description = "";
            this.txtMaterialDescription.Location = new System.Drawing.Point(149, 138);
            this.txtMaterialDescription.Name = "txtMaterialDescription";
            this.txtMaterialDescription.Size = new System.Drawing.Size(159, 20);
            this.txtMaterialDescription.TabIndex = 19;
            // 
            // txtMaterialPic
            // 
            this.txtMaterialPic.Description = "";
            this.txtMaterialPic.Location = new System.Drawing.Point(149, 393);
            this.txtMaterialPic.Name = "txtMaterialPic";
            this.txtMaterialPic.Size = new System.Drawing.Size(159, 20);
            this.txtMaterialPic.TabIndex = 31;
            // 
            // txtMaxStock
            // 
            this.txtMaxStock.Location = new System.Drawing.Point(149, 266);
            this.txtMaxStock.Name = "txtMaxStock";
            this.txtMaxStock.Size = new System.Drawing.Size(159, 20);
            this.txtMaxStock.TabIndex = 32;
            // 
            // txtMinStock
            // 
            this.txtMinStock.Location = new System.Drawing.Point(149, 290);
            this.txtMinStock.Name = "txtMinStock";
            this.txtMinStock.Size = new System.Drawing.Size(159, 20);
            this.txtMinStock.TabIndex = 33;
            // 
            // txtShelfLife
            // 
            this.txtShelfLife.Location = new System.Drawing.Point(149, 316);
            this.txtShelfLife.Name = "txtShelfLife";
            this.txtShelfLife.Size = new System.Drawing.Size(159, 20);
            this.txtShelfLife.TabIndex = 34;
            // 
            // txtMaterialCost
            // 
            this.txtMaterialCost.Location = new System.Drawing.Point(149, 342);
            this.txtMaterialCost.Name = "txtMaterialCost";
            this.txtMaterialCost.Size = new System.Drawing.Size(159, 20);
            this.txtMaterialCost.TabIndex = 35;
            // 
            // txtAcceptableVariance
            // 
            this.txtAcceptableVariance.Location = new System.Drawing.Point(149, 368);
            this.txtAcceptableVariance.Name = "txtAcceptableVariance";
            this.txtAcceptableVariance.Size = new System.Drawing.Size(159, 20);
            this.txtAcceptableVariance.TabIndex = 36;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(149, 244);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 37;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // cboUOMReceive
            // 
            this.cboUOMReceive.FormattingEnabled = true;
            this.cboUOMReceive.Location = new System.Drawing.Point(149, 164);
            this.cboUOMReceive.Name = "cboUOMReceive";
            this.cboUOMReceive.Size = new System.Drawing.Size(159, 21);
            this.cboUOMReceive.TabIndex = 38;
            // 
            // cboUOMCount
            // 
            this.cboUOMCount.FormattingEnabled = true;
            this.cboUOMCount.Location = new System.Drawing.Point(149, 192);
            this.cboUOMCount.Name = "cboUOMCount";
            this.cboUOMCount.Size = new System.Drawing.Size(159, 21);
            this.cboUOMCount.TabIndex = 39;
            // 
            // cboUOMUse
            // 
            this.cboUOMUse.FormattingEnabled = true;
            this.cboUOMUse.Location = new System.Drawing.Point(149, 217);
            this.cboUOMUse.Name = "cboUOMUse";
            this.cboUOMUse.Size = new System.Drawing.Size(159, 21);
            this.cboUOMUse.TabIndex = 40;
            // 
            // picMaterial
            // 
            this.picMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMaterial.Location = new System.Drawing.Point(149, 419);
            this.picMaterial.Name = "picMaterial";
            this.picMaterial.Size = new System.Drawing.Size(159, 132);
            this.picMaterial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMaterial.TabIndex = 41;
            this.picMaterial.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.CommandArg = null;
            this.btnBrowse.DataObject = null;
            this.btnBrowse.Location = new System.Drawing.Point(329, 391);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(80, 23);
            this.btnBrowse.TabIndex = 42;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddEditSetupMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.picMaterial);
            this.Controls.Add(this.cboUOMUse);
            this.Controls.Add(this.cboUOMCount);
            this.Controls.Add(this.cboUOMReceive);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtAcceptableVariance);
            this.Controls.Add(this.txtMaterialCost);
            this.Controls.Add(this.txtShelfLife);
            this.Controls.Add(this.txtMinStock);
            this.Controls.Add(this.txtMaxStock);
            this.Controls.Add(this.txtMaterialPic);
            this.Controls.Add(this.txtMaterialDescription);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.txtMaterialCode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseAddEditMaster1);
            this.Name = "AddEditSetupMaterial";
            this.Size = new System.Drawing.Size(441, 590);
            ((System.ComponentModel.ISupportInitialize)(this.picMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.BaseAddEditMaster baseAddEditMaster1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Control.BaseTextBox txtMaterialCode;
        private Control.BaseTextBox txtMaterialName;
        private Control.BaseTextBox txtMaterialDescription;
        private Control.BaseTextBox txtMaterialPic;
        private Control.NumericTextBox txtMaxStock;
        private Control.NumericTextBox txtMinStock;
        private Control.NumericTextBox txtShelfLife;
        private Control.NumericTextBox txtMaterialCost;
        private Control.NumericTextBox txtAcceptableVariance;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ComboBox cboUOMReceive;
        private System.Windows.Forms.ComboBox cboUOMCount;
        private System.Windows.Forms.ComboBox cboUOMUse;
        private System.Windows.Forms.PictureBox picMaterial;
        private Control.BaseButton btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
