namespace POS.IN.ReceiveOrder
{
    partial class AddEditReceiveOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditReceiveOrder));
            this.ddlReason = new System.Windows.Forms.ComboBox();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblDocumentDate = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlOrderNo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ddlWarehouse = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlMenu = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUOM = new System.Windows.Forms.Label();
            this.baseAddEditMasterDetail = new POS.Control.BaseAddEditMaster();
            this.pictureBoxMaterial = new System.Windows.Forms.PictureBox();
            this.baseGridDetail = new POS.Control.GridView.BaseGrid();
            this.label10 = new System.Windows.Forms.Label();
            this.ddlMaterial = new System.Windows.Forms.ComboBox();
            this.txtLotNo = new POS.Control.BaseTextBox();
            this.txtQuantity = new POS.Control.BaseTextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.txtRemarkDetails = new System.Windows.Forms.TextBox();
            this.lblRemarkDetails = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlReason
            // 
            this.ddlReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddlReason.FormattingEnabled = true;
            this.ddlReason.Location = new System.Drawing.Point(121, 96);
            this.ddlReason.Name = "ddlReason";
            this.ddlReason.Size = new System.Drawing.Size(481, 21);
            this.ddlReason.TabIndex = 1;
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReferenceNo.Location = new System.Drawing.Point(40, 21);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(70, 13);
            this.lblReferenceNo.TabIndex = 1;
            this.lblReferenceNo.Text = "Order No. :";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReason.Location = new System.Drawing.Point(52, 100);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(58, 13);
            this.lblReason.TabIndex = 2;
            this.lblReason.Text = "Reason :";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRemark.Location = new System.Drawing.Point(52, 124);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(58, 13);
            this.lblRemark.TabIndex = 18;
            this.lblRemark.Text = "Remark :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(686, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Document No. :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(679, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Document Date :";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDocumentNo.Location = new System.Drawing.Point(788, 21);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(29, 13);
            this.lblDocumentNo.TabIndex = 23;
            this.lblDocumentNo.Text = "label";
            // 
            // lblDocumentDate
            // 
            this.lblDocumentDate.AutoSize = true;
            this.lblDocumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDocumentDate.Location = new System.Drawing.Point(788, 73);
            this.lblDocumentDate.Name = "lblDocumentDate";
            this.lblDocumentDate.Size = new System.Drawing.Size(41, 13);
            this.lblDocumentDate.TabIndex = 24;
            this.lblDocumentDate.Text = "label10";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(121, 124);
            this.txtRemark.MaxLength = 1000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(665, 43);
            this.txtRemark.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlOrderNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.ddlWarehouse);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblReferenceNo);
            this.groupBox1.Controls.Add(this.ddlMenu);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ddlReason);
            this.groupBox1.Controls.Add(this.lblReason);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.lblDocumentDate);
            this.groupBox1.Controls.Add(this.lblDocumentNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblRemark);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(1, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 188);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Head";
            // 
            // ddlOrderNo
            // 
            this.ddlOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddlOrderNo.FormattingEnabled = true;
            this.ddlOrderNo.Location = new System.Drawing.Point(121, 17);
            this.ddlOrderNo.Name = "ddlOrderNo";
            this.ddlOrderNo.Size = new System.Drawing.Size(481, 21);
            this.ddlOrderNo.TabIndex = 46;
            this.ddlOrderNo.SelectedIndexChanged += new System.EventHandler(this.ddlOrderNo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(608, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "*";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblStatus.Location = new System.Drawing.Point(788, 48);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 38;
            this.lblStatus.Text = "label10";
            // 
            // ddlWarehouse
            // 
            this.ddlWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddlWarehouse.FormattingEnabled = true;
            this.ddlWarehouse.Location = new System.Drawing.Point(121, 69);
            this.ddlWarehouse.Name = "ddlWarehouse";
            this.ddlWarehouse.Size = new System.Drawing.Size(481, 21);
            this.ddlWarehouse.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(31, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Warehouse :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(670, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Document Status :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(608, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(608, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(608, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "*";
            // 
            // ddlMenu
            // 
            this.ddlMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddlMenu.FormattingEnabled = true;
            this.ddlMenu.Location = new System.Drawing.Point(121, 44);
            this.ddlMenu.Name = "ddlMenu";
            this.ddlMenu.Size = new System.Drawing.Size(481, 21);
            this.ddlMenu.TabIndex = 1;
            this.ddlMenu.SelectedIndexChanged += new System.EventHandler(this.ddlMenu_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(64, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Menu :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblUOM);
            this.groupBox2.Controls.Add(this.baseAddEditMasterDetail);
            this.groupBox2.Controls.Add(this.pictureBoxMaterial);
            this.groupBox2.Controls.Add(this.baseGridDetail);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.ddlMaterial);
            this.groupBox2.Controls.Add(this.txtLotNo);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.lblQuantity);
            this.groupBox2.Controls.Add(this.lblMaterial);
            this.groupBox2.Controls.Add(this.lblLotNo);
            this.groupBox2.Controls.Add(this.txtRemarkDetails);
            this.groupBox2.Controls.Add(this.lblRemarkDetails);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(1, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1020, 600);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(275, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "*";
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblUOM.Location = new System.Drawing.Point(305, 124);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(43, 13);
            this.lblUOM.TabIndex = 37;
            this.lblUOM.Text = "UOM :";
            // 
            // baseAddEditMasterDetail
            // 
            this.baseAddEditMasterDetail.BackColor = System.Drawing.Color.Transparent;
            this.baseAddEditMasterDetail.btnBackEnable = true;
            this.baseAddEditMasterDetail.btnBackVisible = true;
            this.baseAddEditMasterDetail.btnResetEnable = true;
            this.baseAddEditMasterDetail.btnResetVisible = true;
            this.baseAddEditMasterDetail.btnSaveEnable = true;
            this.baseAddEditMasterDetail.btnSaveVisible = true;
            this.baseAddEditMasterDetail.Location = new System.Drawing.Point(6, 14);
            this.baseAddEditMasterDetail.Name = "baseAddEditMasterDetail";
            this.baseAddEditMasterDetail.Size = new System.Drawing.Size(166, 51);
            this.baseAddEditMasterDetail.TabIndex = 33;
            this.baseAddEditMasterDetail.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.baseAddEditMasterDetail_saveHandler);
            this.baseAddEditMasterDetail.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.baseAddEditMasterDetail_resetHandler);
            // 
            // pictureBoxMaterial
            // 
            this.pictureBoxMaterial.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxMaterial.ErrorImage")));
            this.pictureBoxMaterial.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMaterial.Image")));
            this.pictureBoxMaterial.Location = new System.Drawing.Point(632, 17);
            this.pictureBoxMaterial.Name = "pictureBoxMaterial";
            this.pictureBoxMaterial.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxMaterial.TabIndex = 26;
            this.pictureBoxMaterial.TabStop = false;
            // 
            // baseGridDetail
            // 
            this.baseGridDetail.btnAddEnable = true;
            this.baseGridDetail.btnAddVisible = true;
            this.baseGridDetail.btnDeleteEnable = true;
            this.baseGridDetail.btnDeleteVisible = true;
            this.baseGridDetail.btnSearchEnable = true;
            this.baseGridDetail.btnSearchVisible = true;
            this.baseGridDetail.DataKeyName = null;
            this.baseGridDetail.DataKeyValue = null;
            this.baseGridDetail.DataSourceDataSet = null;
            this.baseGridDetail.DataSourceTable = null;
            this.baseGridDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.baseGridDetail.FormMode = ObjectState.Nothing;
            this.baseGridDetail.HiddenColumnName = null;
            this.baseGridDetail.Location = new System.Drawing.Point(19, 222);
            this.baseGridDetail.Name = "baseGridDetail";
            this.baseGridDetail.Size = new System.Drawing.Size(976, 218);
            this.baseGridDetail.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(608, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "*";
            // 
            // ddlMaterial
            // 
            this.ddlMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddlMaterial.FormattingEnabled = true;
            this.ddlMaterial.Location = new System.Drawing.Point(121, 67);
            this.ddlMaterial.Name = "ddlMaterial";
            this.ddlMaterial.Size = new System.Drawing.Size(481, 21);
            this.ddlMaterial.TabIndex = 24;
            // 
            // txtLotNo
            // 
            this.txtLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLotNo.Location = new System.Drawing.Point(121, 92);
            this.txtLotNo.MaxLength = 20;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(481, 20);
            this.txtLotNo.TabIndex = 21;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQuantity.Location = new System.Drawing.Point(121, 121);
            this.txtQuantity.MaxLength = 20;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(148, 20);
            this.txtQuantity.TabIndex = 19;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblQuantity.Location = new System.Drawing.Point(52, 124);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(62, 13);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Quantity :";
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMaterial.Location = new System.Drawing.Point(54, 70);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(60, 13);
            this.lblMaterial.TabIndex = 2;
            this.lblMaterial.Text = "Material :";
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLotNo.Location = new System.Drawing.Point(57, 95);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(57, 13);
            this.lblLotNo.TabIndex = 1;
            this.lblLotNo.Text = "Lot No. :";
            // 
            // txtRemarkDetails
            // 
            this.txtRemarkDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemarkDetails.Location = new System.Drawing.Point(123, 149);
            this.txtRemarkDetails.MaxLength = 1000;
            this.txtRemarkDetails.Multiline = true;
            this.txtRemarkDetails.Name = "txtRemarkDetails";
            this.txtRemarkDetails.Size = new System.Drawing.Size(481, 43);
            this.txtRemarkDetails.TabIndex = 8;
            // 
            // lblRemarkDetails
            // 
            this.lblRemarkDetails.AutoSize = true;
            this.lblRemarkDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRemarkDetails.Location = new System.Drawing.Point(56, 149);
            this.lblRemarkDetails.Name = "lblRemarkDetails";
            this.lblRemarkDetails.Size = new System.Drawing.Size(58, 13);
            this.lblRemarkDetails.TabIndex = 18;
            this.lblRemarkDetails.Text = "Remark :";
            // 
            // AddEditReceiveOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEditReceiveOrder";
            this.Size = new System.Drawing.Size(1024, 617);
            this.saveHandler += new POS.Control.BaseAddEditMaster.SaveHandler(this.AddEditReceiveOrder_saveHandler);
            this.resetHandler += new POS.Control.BaseAddEditMaster.ResetHandler(this.AddEditReceiveOrder_resetHandler);
            this.Load += new System.EventHandler(this.AddEditReceiveOrder_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlReason;
        private System.Windows.Forms.Label lblReferenceNo;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblDocumentDate;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBoxMaterial;
        private Control.GridView.BaseGrid baseGridDetail;
        private System.Windows.Forms.ComboBox ddlMaterial;
        private Control.BaseTextBox txtLotNo;
        private Control.BaseTextBox txtQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.TextBox txtRemarkDetails;
        private System.Windows.Forms.Label lblRemarkDetails;
        private System.Windows.Forms.Label label10;
        private Control.BaseAddEditMaster baseAddEditMasterDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUOM;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlWarehouse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ddlMenu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddlOrderNo;

    }
}
