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
            this.label14 = new System.Windows.Forms.Label();
            this.cboMaterailGroup = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
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
            this.label4.Location = new System.Drawing.Point(32, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "UOM Receive";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "UOM Count";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "UOM Use";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Active";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Maximum Stock";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Minimum Stock";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Shelf life";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 372);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Material Cost";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 398);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Acceptable Variance";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 423);
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
            this.txtMaterialPic.Location = new System.Drawing.Point(149, 420);
            this.txtMaterialPic.Name = "txtMaterialPic";
            this.txtMaterialPic.Size = new System.Drawing.Size(159, 20);
            this.txtMaterialPic.TabIndex = 30;
            // 
            // txtMaxStock
            // 
            this.txtMaxStock.Location = new System.Drawing.Point(149, 293);
            this.txtMaxStock.Name = "txtMaxStock";
            this.txtMaxStock.Size = new System.Drawing.Size(159, 20);
            this.txtMaxStock.TabIndex = 25;
            // 
            // txtMinStock
            // 
            this.txtMinStock.Location = new System.Drawing.Point(149, 317);
            this.txtMinStock.Name = "txtMinStock";
            this.txtMinStock.Size = new System.Drawing.Size(159, 20);
            this.txtMinStock.TabIndex = 26;
            // 
            // txtShelfLife
            // 
            this.txtShelfLife.Location = new System.Drawing.Point(149, 343);
            this.txtShelfLife.Name = "txtShelfLife";
            this.txtShelfLife.Size = new System.Drawing.Size(159, 20);
            this.txtShelfLife.TabIndex = 27;
            // 
            // txtMaterialCost
            // 
            this.txtMaterialCost.Location = new System.Drawing.Point(149, 369);
            this.txtMaterialCost.Name = "txtMaterialCost";
            this.txtMaterialCost.Size = new System.Drawing.Size(159, 20);
            this.txtMaterialCost.TabIndex = 28;
            // 
            // txtAcceptableVariance
            // 
            this.txtAcceptableVariance.Location = new System.Drawing.Point(149, 395);
            this.txtAcceptableVariance.Name = "txtAcceptableVariance";
            this.txtAcceptableVariance.Size = new System.Drawing.Size(159, 20);
            this.txtAcceptableVariance.TabIndex = 29;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(149, 271);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 24;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // cboUOMReceive
            // 
            this.cboUOMReceive.FormattingEnabled = true;
            this.cboUOMReceive.Location = new System.Drawing.Point(149, 191);
            this.cboUOMReceive.Name = "cboUOMReceive";
            this.cboUOMReceive.Size = new System.Drawing.Size(159, 21);
            this.cboUOMReceive.TabIndex = 21;
            // 
            // cboUOMCount
            // 
            this.cboUOMCount.FormattingEnabled = true;
            this.cboUOMCount.Location = new System.Drawing.Point(149, 219);
            this.cboUOMCount.Name = "cboUOMCount";
            this.cboUOMCount.Size = new System.Drawing.Size(159, 21);
            this.cboUOMCount.TabIndex = 22;
            // 
            // cboUOMUse
            // 
            this.cboUOMUse.FormattingEnabled = true;
            this.cboUOMUse.Location = new System.Drawing.Point(149, 244);
            this.cboUOMUse.Name = "cboUOMUse";
            this.cboUOMUse.Size = new System.Drawing.Size(159, 21);
            this.cboUOMUse.TabIndex = 23;
            // 
            // picMaterial
            // 
            this.picMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMaterial.Location = new System.Drawing.Point(149, 446);
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
            this.btnBrowse.Location = new System.Drawing.Point(329, 418);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(80, 23);
            this.btnBrowse.TabIndex = 31;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "Material Group";
            // 
            // cboMaterailGroup
            // 
            this.cboMaterailGroup.FormattingEnabled = true;
            this.cboMaterailGroup.Location = new System.Drawing.Point(149, 164);
            this.cboMaterailGroup.Name = "cboMaterailGroup";
            this.cboMaterailGroup.Size = new System.Drawing.Size(159, 21);
            this.cboMaterailGroup.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(314, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(314, 117);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(314, 167);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 13);
            this.label17.TabIndex = 54;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(314, 194);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 13);
            this.label18.TabIndex = 55;
            this.label18.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(314, 222);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 13);
            this.label19.TabIndex = 56;
            this.label19.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(314, 247);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 13);
            this.label20.TabIndex = 57;
            this.label20.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(314, 296);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 13);
            this.label21.TabIndex = 58;
            this.label21.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(314, 320);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 13);
            this.label22.TabIndex = 59;
            this.label22.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(314, 346);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 13);
            this.label23.TabIndex = 60;
            this.label23.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(314, 372);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(11, 13);
            this.label24.TabIndex = 61;
            this.label24.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(314, 398);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(11, 13);
            this.label25.TabIndex = 62;
            this.label25.Text = "*";
            // 
            // AddEditSetupMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboMaterailGroup);
            this.Controls.Add(this.label14);
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
            this.Size = new System.Drawing.Size(441, 607);
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboMaterailGroup;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
    }
}
