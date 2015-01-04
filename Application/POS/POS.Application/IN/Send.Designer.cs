namespace POS.IN
{
    partial class Send
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
            POS.Control.Office2010White office2010White2 = new POS.Control.Office2010White();
            this.txtReferenceNo = new POS.Control.BaseTextBox();
            this.baseGrid1 = new POS.Control.GridView.BaseGrid();
            this.btnSave = new POS.Control.BaseButton();
            this.btnClear = new POS.Control.BaseButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDocumentNo = new System.Windows.Forms.Label();
            this.lblDocumentDate = new System.Windows.Forms.Label();
            this.ddlWarehouse = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(140, 8);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(121, 20);
            this.txtReferenceNo.TabIndex = 0;
            // 
            // baseGrid1
            // 
            this.baseGrid1.DataKeyName = null;
            this.baseGrid1.DataSourceDataSet = null;
            this.baseGrid1.DataSourceTable = null;
            this.baseGrid1.Location = new System.Drawing.Point(43, 135);
            this.baseGrid1.Name = "baseGrid1";
            this.baseGrid1.Size = new System.Drawing.Size(431, 304);
            this.baseGrid1.TabIndex = 1;
            // 
            // btnSave
            // 
          
            this.btnSave.CommandArg = null;
            this.btnSave.Location = new System.Drawing.Point(196, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            //this.btnClear.ColorTable = office2010White1;
            this.btnClear.CommandArg = null;
            this.btnClear.Location = new System.Drawing.Point(337, 470);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reference No";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Warehouse";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Remark";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(400, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(400, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Document No";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(400, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Document Date";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(490, 11);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "label7";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.Location = new System.Drawing.Point(490, 46);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(35, 13);
            this.lblDocumentNo.TabIndex = 0;
            this.lblDocumentNo.Text = "label8";
            // 
            // lblDocumentDate
            // 
            this.lblDocumentDate.Location = new System.Drawing.Point(490, 81);
            this.lblDocumentDate.Name = "lblDocumentDate";
            this.lblDocumentDate.Size = new System.Drawing.Size(35, 13);
            this.lblDocumentDate.TabIndex = 0;
            this.lblDocumentDate.Text = "label9";
            // 
            // ddlWarehouse
            // 
            this.ddlWarehouse.Location = new System.Drawing.Point(140, 43);
            this.ddlWarehouse.Name = "ddlWarehouse";
            this.ddlWarehouse.Size = new System.Drawing.Size(121, 21);
            this.ddlWarehouse.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(140, 81);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(121, 30);
            this.listBox1.TabIndex = 4;
            // 
            // Send
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ddlWarehouse);
            this.Controls.Add(this.lblDocumentDate);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.baseGrid1);
            this.Controls.Add(this.txtReferenceNo);
            this.Name = "Send";
            this.Size = new System.Drawing.Size(712, 522);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.BaseTextBox txtReferenceNo;
        private Control.GridView.BaseGrid baseGrid1;
        private Control.BaseButton btnSave;
        private Control.BaseButton btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDocumentNo;
        private System.Windows.Forms.Label lblDocumentDate;
        private System.Windows.Forms.ComboBox ddlWarehouse;
        private System.Windows.Forms.ListBox listBox1;
    }
}
