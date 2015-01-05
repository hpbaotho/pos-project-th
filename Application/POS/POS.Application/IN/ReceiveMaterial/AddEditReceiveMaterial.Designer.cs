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
            this.txtSupplier = new POS.Control.BaseTextBox();
            this.txtWarehouse = new POS.Control.BaseTextBox();
            this.txtOther = new POS.Control.BaseTextBox();
            this.baseGrid1 = new POS.Control.GridView.BaseGrid();
            this.rdoSupplier = new System.Windows.Forms.RadioButton();
            this.rdoWarehouse = new System.Windows.Forms.RadioButton();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.lblRemark = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblDocumentDate = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ddlReason
            // 
            this.ddlReason.FormattingEnabled = true;
            this.ddlReason.Location = new System.Drawing.Point(126, 91);
            this.ddlReason.Name = "ddlReason";
            this.ddlReason.Size = new System.Drawing.Size(541, 21);
            this.ddlReason.TabIndex = 0;
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReferenceNo.Location = new System.Drawing.Point(21, 64);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(94, 13);
            this.lblReferenceNo.TabIndex = 1;
            this.lblReferenceNo.Text = "Reference No :";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReason.Location = new System.Drawing.Point(57, 91);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(58, 13);
            this.lblReason.TabIndex = 2;
            this.lblReason.Text = "Reason :";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSource.Location = new System.Drawing.Point(60, 118);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(55, 13);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "Source :";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(126, 64);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(541, 20);
            this.txtReferenceNo.TabIndex = 4;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(204, 117);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(463, 20);
            this.txtSupplier.TabIndex = 5;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.Location = new System.Drawing.Point(204, 140);
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.Size = new System.Drawing.Size(463, 20);
            this.txtWarehouse.TabIndex = 6;
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(204, 163);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(463, 20);
            this.txtOther.TabIndex = 7;
            // 
            // baseGrid1
            // 
            this.baseGrid1.DataKeyName = null;
            this.baseGrid1.DataSourceDataSet = null;
            this.baseGrid1.DataSourceTable = null;
            this.baseGrid1.Location = new System.Drawing.Point(24, 239);
            this.baseGrid1.Name = "baseGrid1";
            this.baseGrid1.Size = new System.Drawing.Size(975, 304);
            this.baseGrid1.TabIndex = 11;
            // 
            // rdoSupplier
            // 
            this.rdoSupplier.AutoSize = true;
            this.rdoSupplier.Location = new System.Drawing.Point(126, 118);
            this.rdoSupplier.Name = "rdoSupplier";
            this.rdoSupplier.Size = new System.Drawing.Size(63, 17);
            this.rdoSupplier.TabIndex = 14;
            this.rdoSupplier.TabStop = true;
            this.rdoSupplier.Text = "Supplier";
            this.rdoSupplier.UseVisualStyleBackColor = true;
            // 
            // rdoWarehouse
            // 
            this.rdoWarehouse.AutoSize = true;
            this.rdoWarehouse.Location = new System.Drawing.Point(126, 141);
            this.rdoWarehouse.Name = "rdoWarehouse";
            this.rdoWarehouse.Size = new System.Drawing.Size(80, 17);
            this.rdoWarehouse.TabIndex = 15;
            this.rdoWarehouse.TabStop = true;
            this.rdoWarehouse.Text = "Warehouse";
            this.rdoWarehouse.UseVisualStyleBackColor = true;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Location = new System.Drawing.Point(126, 164);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(51, 17);
            this.rdoOther.TabIndex = 16;
            this.rdoOther.TabStop = true;
            this.rdoOther.Text = "Other";
            this.rdoOther.UseVisualStyleBackColor = true;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRemark.Location = new System.Drawing.Point(57, 190);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(58, 13);
            this.lblRemark.TabIndex = 18;
            this.lblRemark.Text = "Remark :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(735, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Status :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(694, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Document No :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(683, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Document Date :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(792, 63);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 22;
            this.lblStatus.Text = "label8";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Location = new System.Drawing.Point(792, 90);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(35, 13);
            this.lblDocumentNo.TabIndex = 23;
            this.lblDocumentNo.Text = "label9";
            // 
            // lblDocumentDate
            // 
            this.lblDocumentDate.AutoSize = true;
            this.lblDocumentDate.Location = new System.Drawing.Point(792, 117);
            this.lblDocumentDate.Name = "lblDocumentDate";
            this.lblDocumentDate.Size = new System.Drawing.Size(41, 13);
            this.lblDocumentDate.TabIndex = 24;
            this.lblDocumentDate.Text = "label10";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(122, 190);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(877, 43);
            this.txtRemark.TabIndex = 25;
            // 
            // AddEditReceiveMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblDocumentDate);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.rdoOther);
            this.Controls.Add(this.rdoWarehouse);
            this.Controls.Add(this.rdoSupplier);
            this.Controls.Add(this.baseGrid1);
            this.Controls.Add(this.txtOther);
            this.Controls.Add(this.txtWarehouse);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.txtReferenceNo);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblReferenceNo);
            this.Controls.Add(this.ddlReason);
            this.Name = "AddEditReceiveMaterial";
            this.Size = new System.Drawing.Size(1024, 617);
            this.Controls.SetChildIndex(this.ddlReason, 0);
            this.Controls.SetChildIndex(this.lblReferenceNo, 0);
            this.Controls.SetChildIndex(this.lblReason, 0);
            this.Controls.SetChildIndex(this.lblSource, 0);
            this.Controls.SetChildIndex(this.txtReferenceNo, 0);
            this.Controls.SetChildIndex(this.txtSupplier, 0);
            this.Controls.SetChildIndex(this.txtWarehouse, 0);
            this.Controls.SetChildIndex(this.txtOther, 0);
            this.Controls.SetChildIndex(this.baseGrid1, 0);
            this.Controls.SetChildIndex(this.rdoSupplier, 0);
            this.Controls.SetChildIndex(this.rdoWarehouse, 0);
            this.Controls.SetChildIndex(this.rdoOther, 0);
            this.Controls.SetChildIndex(this.lblRemark, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.lblDocumentNo, 0);
            this.Controls.SetChildIndex(this.lblDocumentDate, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlReason;
        private System.Windows.Forms.Label lblReferenceNo;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblSource;
        private Control.BaseTextBox txtReferenceNo;
        private Control.BaseTextBox txtSupplier;
        private Control.BaseTextBox txtWarehouse;
        private Control.BaseTextBox txtOther;
        private Control.GridView.BaseGrid baseGrid1;
        private System.Windows.Forms.RadioButton rdoSupplier;
        private System.Windows.Forms.RadioButton rdoWarehouse;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblDocumentDate;
        private System.Windows.Forms.TextBox txtRemark;

    }
}
