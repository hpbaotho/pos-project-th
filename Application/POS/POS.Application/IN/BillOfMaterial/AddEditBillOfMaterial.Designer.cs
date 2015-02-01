namespace POS.IN.BillOfMaterial
{
    partial class AddEditBillOfMaterial
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new POS.Control.BaseTextBox();
            this.txtBOMHeadName = new POS.Control.BaseTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlBOMGroup = new System.Windows.Forms.ComboBox();
            this.txtBOMHeadCode = new POS.Control.BaseTextBox();
            this.txtBOMHeadDescription = new POS.Control.BaseTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbMaterial = new System.Windows.Forms.RadioButton();
            this.rdbBOM = new System.Windows.Forms.RadioButton();
            this.txtUOM = new POS.Control.BaseTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlBOMDetail = new System.Windows.Forms.ComboBox();
            this.grdDetail = new POS.Control.GridView.BaseGrid();
            this.baseAddEditMaster1 = new POS.Control.BaseAddEditMaster();
            this.txtAmount = new POS.Control.BaseTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlMaterial = new System.Windows.Forms.ComboBox();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.txtBOMHeadName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ddlBOMGroup);
            this.groupBox1.Controls.Add(this.txtBOMHeadCode);
            this.groupBox1.Controls.Add(this.txtBOMHeadDescription);
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 232);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Head";
            // 
            // txtRemark
            // 
            this.txtRemark.Description = "Remark";
            this.txtRemark.Location = new System.Drawing.Point(160, 172);
            this.txtRemark.MaxLength = 1000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(418, 48);
            this.txtRemark.TabIndex = 37;
            // 
            // txtBOMHeadName
            // 
            this.txtBOMHeadName.Description = "BOM Name";
            this.txtBOMHeadName.Location = new System.Drawing.Point(163, 84);
            this.txtBOMHeadName.MaxLength = 500;
            this.txtBOMHeadName.Name = "txtBOMHeadName";
            this.txtBOMHeadName.Size = new System.Drawing.Size(418, 20);
            this.txtBOMHeadName.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "BOM Group";
            // 
            // ddlBOMGroup
            // 
            this.ddlBOMGroup.FormattingEnabled = true;
            this.ddlBOMGroup.Location = new System.Drawing.Point(163, 31);
            this.ddlBOMGroup.Name = "ddlBOMGroup";
            this.ddlBOMGroup.Size = new System.Drawing.Size(415, 21);
            this.ddlBOMGroup.TabIndex = 31;
            // 
            // txtBOMHeadCode
            // 
            this.txtBOMHeadCode.Description = "BOM Code";
            this.txtBOMHeadCode.Location = new System.Drawing.Point(163, 58);
            this.txtBOMHeadCode.MaxLength = 500;
            this.txtBOMHeadCode.Name = "txtBOMHeadCode";
            this.txtBOMHeadCode.Size = new System.Drawing.Size(418, 20);
            this.txtBOMHeadCode.TabIndex = 26;
            // 
            // txtBOMHeadDescription
            // 
            this.txtBOMHeadDescription.Description = "BOM Description";
            this.txtBOMHeadDescription.Location = new System.Drawing.Point(160, 118);
            this.txtBOMHeadDescription.MaxLength = 1000;
            this.txtBOMHeadDescription.Multiline = true;
            this.txtBOMHeadDescription.Name = "txtBOMHeadDescription";
            this.txtBOMHeadDescription.Size = new System.Drawing.Size(418, 48);
            this.txtBOMHeadDescription.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtUOM);
            this.groupBox2.Controls.Add(this.grdDetail);
            this.groupBox2.Controls.Add(this.baseAddEditMaster1);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 407);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbMaterial);
            this.groupBox3.Controls.Add(this.rdbBOM);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.ddlBOMDetail);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.ddlMaterial);
            this.groupBox3.Location = new System.Drawing.Point(87, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 82);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // rdbMaterial
            // 
            this.rdbMaterial.AutoSize = true;
            this.rdbMaterial.Location = new System.Drawing.Point(6, 22);
            this.rdbMaterial.Name = "rdbMaterial";
            this.rdbMaterial.Size = new System.Drawing.Size(14, 13);
            this.rdbMaterial.TabIndex = 15;
            this.rdbMaterial.TabStop = true;
            this.rdbMaterial.UseVisualStyleBackColor = true;
            this.rdbMaterial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbMaterial_MouseClick);
            // 
            // rdbBOM
            // 
            this.rdbBOM.AutoSize = true;
            this.rdbBOM.Location = new System.Drawing.Point(6, 52);
            this.rdbBOM.Name = "rdbBOM";
            this.rdbBOM.Size = new System.Drawing.Size(14, 13);
            this.rdbBOM.TabIndex = 16;
            this.rdbBOM.TabStop = true;
            this.rdbBOM.UseVisualStyleBackColor = true;
            this.rdbBOM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rdbBOM_MouseClick);
            // 
            // txtUOM
            // 
            this.txtUOM.Description = "UOM";
            this.txtUOM.Enabled = false;
            this.txtUOM.Location = new System.Drawing.Point(662, 87);
            this.txtUOM.MaxLength = 10;
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(104, 20);
            this.txtUOM.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "BOM";
            // 
            // ddlBOMDetail
            // 
            this.ddlBOMDetail.FormattingEnabled = true;
            this.ddlBOMDetail.Location = new System.Drawing.Point(70, 49);
            this.ddlBOMDetail.Name = "ddlBOMDetail";
            this.ddlBOMDetail.Size = new System.Drawing.Size(418, 21);
            this.ddlBOMDetail.TabIndex = 7;
            // 
            // grdDetail
            // 
            this.grdDetail.btnAddEnable = true;
            this.grdDetail.btnAddVisible = true;
            this.grdDetail.btnDeleteEnable = true;
            this.grdDetail.btnDeleteVisible = true;
            this.grdDetail.btnSearchEnable = false;
            this.grdDetail.btnSearchVisible = true;
            this.grdDetail.DataKeyName = null;
            this.grdDetail.DataKeyValue = null;
            this.grdDetail.DataSourceDataSet = null;
            this.grdDetail.DataSourceTable = null;
            this.grdDetail.FormMode = ObjectState.Nothing;
            this.grdDetail.HiddenColumnName = null;
            this.grdDetail.Location = new System.Drawing.Point(0, 186);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(1018, 318);
            this.grdDetail.TabIndex = 5;
            // 
            // baseAddEditMaster1
            // 
            this.baseAddEditMaster1.BackColor = System.Drawing.Color.Transparent;
            this.baseAddEditMaster1.btnBackEnable = false;
            this.baseAddEditMaster1.btnBackVisible = true;
            this.baseAddEditMaster1.btnResetEnable = true;
            this.baseAddEditMaster1.btnResetVisible = true;
            this.baseAddEditMaster1.btnSaveEnable = true;
            this.baseAddEditMaster1.btnSaveVisible = true;
            this.baseAddEditMaster1.Location = new System.Drawing.Point(0, 19);
            this.baseAddEditMaster1.Name = "baseAddEditMaster1";
            this.baseAddEditMaster1.Size = new System.Drawing.Size(172, 59);
            this.baseAddEditMaster1.TabIndex = 4;
            this.baseAddEditMaster1.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.AddEditDetail_saveHandler);
            this.baseAddEditMaster1.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.AddEditDetail_resetHandler);
            this.baseAddEditMaster1.Load += new System.EventHandler(this.AddEditDetail_Load);
            // 
            // txtAmount
            // 
            this.txtAmount.Description = "Amount";
            this.txtAmount.Location = new System.Drawing.Point(163, 160);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(418, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Material";
            // 
            // ddlMaterial
            // 
            this.ddlMaterial.FormattingEnabled = true;
            this.ddlMaterial.Location = new System.Drawing.Point(70, 19);
            this.ddlMaterial.Name = "ddlMaterial";
            this.ddlMaterial.Size = new System.Drawing.Size(418, 21);
            this.ddlMaterial.TabIndex = 0;
            this.ddlMaterial.SelectedIndexChanged += new System.EventHandler(this.ddlMaterial_SelectedIndexChanged);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.groupBox2);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail.Location = new System.Drawing.Point(0, 329);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1024, 407);
            this.pnlDetail.TabIndex = 25;
            // 
            // AddEditBillOfMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlDetail);
            this.Name = "AddEditBillOfMaterial";
            this.Size = new System.Drawing.Size(1024, 736);
            this.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.AddEditHead_saveHandler);
            this.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.AddEditHead_resetHandler);
            this.Load += new System.EventHandler(this.AddEditHead_Load);
            this.Controls.SetChildIndex(this.pnlDetail, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Control.BaseTextBox txtBOMHeadCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.ComboBox ddlMaterial;
        private System.Windows.Forms.Label label2;
        private Control.BaseTextBox txtAmount;
        private Control.BaseAddEditMaster baseAddEditMaster1;
        private Control.GridView.BaseGrid grdDetail;
        private System.Windows.Forms.ComboBox ddlBOMGroup;
        private System.Windows.Forms.Label label3;
        private Control.BaseTextBox txtBOMHeadDescription;
        private Control.BaseTextBox txtBOMHeadName;
        private Control.BaseTextBox txtRemark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlBOMDetail;
        private Control.BaseTextBox txtUOM;
        private System.Windows.Forms.RadioButton rdbMaterial;
        private System.Windows.Forms.RadioButton rdbBOM;
        private System.Windows.Forms.GroupBox groupBox3;







    }
}
