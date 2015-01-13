namespace POS.IN.ReceiveMaterial
{
    partial class AddEditReceiveMaterial
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
            this.ddlReason = new System.Windows.Forms.ComboBox();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.txtReferenceNo = new POS.Control.BaseTextBox();
            this.rdoSupplier = new System.Windows.Forms.RadioButton();
            this.rdoWarehouse = new System.Windows.Forms.RadioButton();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.lblRemark = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblDocumentDate = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.ddlSupplier = new System.Windows.Forms.ComboBox();
            this.ddlWarehouse = new System.Windows.Forms.ComboBox();
            this.txtOther = new POS.Control.BaseTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.baseGrid1 = new POS.Control.GridView.BaseGrid();
            this.ddlMaterial = new System.Windows.Forms.ComboBox();
            this.ddlWarehouseDetails = new System.Windows.Forms.ComboBox();
            this.txtLotNo = new POS.Control.BaseTextBox();
            this.txtQuantity = new POS.Control.BaseTextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.txtRemarkDetails = new System.Windows.Forms.TextBox();
            this.lblRemarkDetails = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnLoadPortFolio = new POS.Control.BaseButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlReason
            // 
            this.ddlReason.FormattingEnabled = true;
            this.ddlReason.Location = new System.Drawing.Point(121, 43);
            this.ddlReason.Name = "ddlReason";
            this.ddlReason.Size = new System.Drawing.Size(481, 21);
            this.ddlReason.TabIndex = 1;
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReferenceNo.Location = new System.Drawing.Point(16, 16);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(98, 13);
            this.lblReferenceNo.TabIndex = 1;
            this.lblReferenceNo.Text = "Reference No. :";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReason.Location = new System.Drawing.Point(52, 43);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(58, 13);
            this.lblReason.TabIndex = 2;
            this.lblReason.Text = "Reason :";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSource.Location = new System.Drawing.Point(55, 70);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(55, 13);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "Source :";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Description = "";
            this.txtReferenceNo.Location = new System.Drawing.Point(121, 16);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(481, 20);
            this.txtReferenceNo.TabIndex = 0;
            // 
            // rdoSupplier
            // 
            this.rdoSupplier.AutoSize = true;
            this.rdoSupplier.Checked = true;
            this.rdoSupplier.Location = new System.Drawing.Point(121, 70);
            this.rdoSupplier.Name = "rdoSupplier";
            this.rdoSupplier.Size = new System.Drawing.Size(63, 17);
            this.rdoSupplier.TabIndex = 2;
            this.rdoSupplier.TabStop = true;
            this.rdoSupplier.Text = "Supplier";
            this.rdoSupplier.UseVisualStyleBackColor = true;
            // 
            // rdoWarehouse
            // 
            this.rdoWarehouse.AutoSize = true;
            this.rdoWarehouse.Location = new System.Drawing.Point(121, 93);
            this.rdoWarehouse.Name = "rdoWarehouse";
            this.rdoWarehouse.Size = new System.Drawing.Size(80, 17);
            this.rdoWarehouse.TabIndex = 4;
            this.rdoWarehouse.Text = "Warehouse";
            this.rdoWarehouse.UseVisualStyleBackColor = true;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Location = new System.Drawing.Point(121, 116);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(51, 17);
            this.rdoOther.TabIndex = 6;
            this.rdoOther.Text = "Other";
            this.rdoOther.UseVisualStyleBackColor = true;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRemark.Location = new System.Drawing.Point(52, 142);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(58, 13);
            this.lblRemark.TabIndex = 18;
            this.lblRemark.Text = "Remark :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(690, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Document No. :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(679, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Document Date :";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Location = new System.Drawing.Point(788, 16);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(29, 13);
            this.lblDocumentNo.TabIndex = 23;
            this.lblDocumentNo.Text = "Auto";
            // 
            // lblDocumentDate
            // 
            this.lblDocumentDate.AutoSize = true;
            this.lblDocumentDate.Location = new System.Drawing.Point(788, 43);
            this.lblDocumentDate.Name = "lblDocumentDate";
            this.lblDocumentDate.Size = new System.Drawing.Size(41, 13);
            this.lblDocumentDate.TabIndex = 24;
            this.lblDocumentDate.Text = "label10";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(121, 142);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(705, 43);
            this.txtRemark.TabIndex = 8;
            // 
            // ddlSupplier
            // 
            this.ddlSupplier.FormattingEnabled = true;
            this.ddlSupplier.Location = new System.Drawing.Point(224, 67);
            this.ddlSupplier.Name = "ddlSupplier";
            this.ddlSupplier.Size = new System.Drawing.Size(378, 21);
            this.ddlSupplier.TabIndex = 25;
            // 
            // ddlWarehouse
            // 
            this.ddlWarehouse.FormattingEnabled = true;
            this.ddlWarehouse.Location = new System.Drawing.Point(224, 92);
            this.ddlWarehouse.Name = "ddlWarehouse";
            this.ddlWarehouse.Size = new System.Drawing.Size(378, 21);
            this.ddlWarehouse.TabIndex = 26;
            // 
            // txtOther
            // 
            this.txtOther.Description = "";
            this.txtOther.Location = new System.Drawing.Point(224, 116);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(378, 20);
            this.txtOther.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadPortFolio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblReferenceNo);
            this.groupBox1.Controls.Add(this.txtOther);
            this.groupBox1.Controls.Add(this.ddlReason);
            this.groupBox1.Controls.Add(this.ddlWarehouse);
            this.groupBox1.Controls.Add(this.lblReason);
            this.groupBox1.Controls.Add(this.ddlSupplier);
            this.groupBox1.Controls.Add(this.lblSource);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.lblDocumentDate);
            this.groupBox1.Controls.Add(this.txtReferenceNo);
            this.groupBox1.Controls.Add(this.lblDocumentNo);
            this.groupBox1.Controls.Add(this.rdoSupplier);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rdoWarehouse);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rdoOther);
            this.groupBox1.Controls.Add(this.lblRemark);
            this.groupBox1.Location = new System.Drawing.Point(1, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 242);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Head";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(608, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(608, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(608, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "*";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.baseGrid1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.ddlMaterial);
            this.groupBox2.Controls.Add(this.ddlWarehouseDetails);
            this.groupBox2.Controls.Add(this.txtLotNo);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.lblQuantity);
            this.groupBox2.Controls.Add(this.lblMaterial);
            this.groupBox2.Controls.Add(this.lblLotNo);
            this.groupBox2.Controls.Add(this.lblWarehouse);
            this.groupBox2.Controls.Add(this.txtRemarkDetails);
            this.groupBox2.Controls.Add(this.lblRemarkDetails);
            this.groupBox2.Location = new System.Drawing.Point(4, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1020, 600);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(693, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 96);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // baseGrid1
            // 
            this.baseGrid1.DataKeyName = null;
            this.baseGrid1.DataSourceDataSet = null;
            this.baseGrid1.DataSourceTable = null;
            this.baseGrid1.Location = new System.Drawing.Point(19, 222);
            this.baseGrid1.Name = "baseGrid1";
            this.baseGrid1.Size = new System.Drawing.Size(976, 218);
            this.baseGrid1.TabIndex = 25;
            // 
            // ddlMaterial
            // 
            this.ddlMaterial.FormattingEnabled = true;
            this.ddlMaterial.Location = new System.Drawing.Point(121, 120);
            this.ddlMaterial.Name = "ddlMaterial";
            this.ddlMaterial.Size = new System.Drawing.Size(481, 21);
            this.ddlMaterial.TabIndex = 24;
            // 
            // ddlWarehouseDetails
            // 
            this.ddlWarehouseDetails.FormattingEnabled = true;
            this.ddlWarehouseDetails.Location = new System.Drawing.Point(121, 67);
            this.ddlWarehouseDetails.Name = "ddlWarehouseDetails";
            this.ddlWarehouseDetails.Size = new System.Drawing.Size(481, 21);
            this.ddlWarehouseDetails.TabIndex = 23;
            // 
            // txtLotNo
            // 
            this.txtLotNo.Description = "";
            this.txtLotNo.Location = new System.Drawing.Point(121, 94);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(481, 20);
            this.txtLotNo.TabIndex = 21;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Description = "";
            this.txtQuantity.Location = new System.Drawing.Point(121, 147);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(481, 20);
            this.txtQuantity.TabIndex = 19;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblQuantity.Location = new System.Drawing.Point(52, 150);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(62, 13);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Quantity :";
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMaterial.Location = new System.Drawing.Point(54, 123);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(60, 13);
            this.lblMaterial.TabIndex = 2;
            this.lblMaterial.Text = "Material :";
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.Location = new System.Drawing.Point(57, 97);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(57, 13);
            this.lblLotNo.TabIndex = 1;
            this.lblLotNo.Text = "Lot No. :";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblWarehouse.Location = new System.Drawing.Point(35, 73);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(79, 13);
            this.lblWarehouse.TabIndex = 0;
            this.lblWarehouse.Text = "Warehouse :";
            // 
            // txtRemarkDetails
            // 
            this.txtRemarkDetails.Location = new System.Drawing.Point(121, 176);
            this.txtRemarkDetails.Multiline = true;
            this.txtRemarkDetails.Name = "txtRemarkDetails";
            this.txtRemarkDetails.Size = new System.Drawing.Size(705, 43);
            this.txtRemarkDetails.TabIndex = 8;
            // 
            // lblRemarkDetails
            // 
            this.lblRemarkDetails.AutoSize = true;
            this.lblRemarkDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRemarkDetails.Location = new System.Drawing.Point(56, 176);
            this.lblRemarkDetails.Name = "lblRemarkDetails";
            this.lblRemarkDetails.Size = new System.Drawing.Size(58, 13);
            this.lblRemarkDetails.TabIndex = 18;
            this.lblRemarkDetails.Text = "Remark :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(608, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(608, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(608, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(608, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "*";
            // 
            // btnLoadPortFolio
            // 
            this.btnLoadPortFolio.CommandArg = null;
            this.btnLoadPortFolio.DataObject = null;
            this.btnLoadPortFolio.Location = new System.Drawing.Point(374, 200);
            this.btnLoadPortFolio.Name = "btnLoadPortFolio";
            this.btnLoadPortFolio.Size = new System.Drawing.Size(174, 23);
            this.btnLoadPortFolio.TabIndex = 33;
            this.btnLoadPortFolio.Text = "Load   PortFolio";
            this.btnLoadPortFolio.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnLoadPortFolio.UseVisualStyleBackColor = true;
            // 
            // AddEditReceiveMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEditReceiveMaterial";
            this.Size = new System.Drawing.Size(1024, 617);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlReason;
        private System.Windows.Forms.Label lblReferenceNo;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblSource;
        private Control.BaseTextBox txtReferenceNo;
        private System.Windows.Forms.RadioButton rdoSupplier;
        private System.Windows.Forms.RadioButton rdoWarehouse;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblDocumentDate;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.ComboBox ddlSupplier;
        private System.Windows.Forms.ComboBox ddlWarehouse;
        private Control.BaseTextBox txtOther;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Control.GridView.BaseGrid baseGrid1;
        private System.Windows.Forms.ComboBox ddlMaterial;
        private System.Windows.Forms.ComboBox ddlWarehouseDetails;
        private Control.BaseTextBox txtLotNo;
        private Control.BaseTextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.TextBox txtRemarkDetails;
        private System.Windows.Forms.Label lblRemarkDetails;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private Control.BaseButton btnLoadPortFolio;

    }
}
