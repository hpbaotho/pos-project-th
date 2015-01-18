namespace POS.KC.KitchenOrderList
{
    partial class KitchenOrderDetail
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdBomDetail = new POS.Control.GridView.BaseGrid();
            this.grdBomHead = new POS.Control.GridView.BaseGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtMenu = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.baseAddEditMasterDetail = new POS.Control.BaseAddEditMaster();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdBomDetail);
            this.groupBox2.Controls.Add(this.grdBomHead);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(18, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(989, 520);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // grdBomDetail
            // 
            this.grdBomDetail.btnAddEnable = true;
            this.grdBomDetail.btnDeleteEnable = true;
            this.grdBomDetail.btnSearchEnable = true;
            this.grdBomDetail.DataKeyName = null;
            this.grdBomDetail.DataKeyValue = null;
            this.grdBomDetail.DataSourceDataSet = null;
            this.grdBomDetail.DataSourceTable = null;
            this.grdBomDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.grdBomDetail.FormMode = ObjectState.Nothing;
            this.grdBomDetail.HiddenColumnName = null;
            this.grdBomDetail.Location = new System.Drawing.Point(8, 279);
            this.grdBomDetail.Name = "grdBomDetail";
            this.grdBomDetail.Size = new System.Drawing.Size(975, 238);
            this.grdBomDetail.TabIndex = 19;
            // 
            // grdBomHead
            // 
            this.grdBomHead.btnAddEnable = true;
            this.grdBomHead.btnDeleteEnable = true;
            this.grdBomHead.btnSearchEnable = true;
            this.grdBomHead.DataKeyName = null;
            this.grdBomHead.DataKeyValue = null;
            this.grdBomHead.DataSourceDataSet = null;
            this.grdBomHead.DataSourceTable = null;
            this.grdBomHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.grdBomHead.FormMode = ObjectState.Nothing;
            this.grdBomHead.HiddenColumnName = null;
            this.grdBomHead.Location = new System.Drawing.Point(8, 19);
            this.grdBomHead.Name = "grdBomHead";
            this.grdBomHead.Size = new System.Drawing.Size(975, 254);
            this.grdBomHead.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.txtMenu);
            this.groupBox1.Controls.Add(this.txtTableName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblReason);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(18, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 122);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Head";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Location = new System.Drawing.Point(161, 84);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(149, 20);
            this.txtQuantity.TabIndex = 3;
            // 
            // txtMenu
            // 
            this.txtMenu.Enabled = false;
            this.txtMenu.Location = new System.Drawing.Point(161, 55);
            this.txtMenu.Name = "txtMenu";
            this.txtMenu.Size = new System.Drawing.Size(149, 20);
            this.txtMenu.TabIndex = 3;
            // 
            // txtTableName
            // 
            this.txtTableName.Enabled = false;
            this.txtTableName.Location = new System.Drawing.Point(161, 26);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(149, 20);
            this.txtTableName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(80, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantity :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(96, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Menu :";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReason.Location = new System.Drawing.Point(59, 29);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(83, 13);
            this.lblReason.TabIndex = 2;
            this.lblReason.Text = "Table Name :";
            // 
            // baseAddEditMasterDetail
            // 
            this.baseAddEditMasterDetail.BackColor = System.Drawing.Color.Transparent;
            this.baseAddEditMasterDetail.btnBackEnable = true;
            this.baseAddEditMasterDetail.btnResetEnable = true;
            this.baseAddEditMasterDetail.btnSaveEnable = true;
            this.baseAddEditMasterDetail.Location = new System.Drawing.Point(26, 14);
            this.baseAddEditMasterDetail.Name = "baseAddEditMasterDetail";
            this.baseAddEditMasterDetail.Size = new System.Drawing.Size(166, 51);
            this.baseAddEditMasterDetail.TabIndex = 34;
            this.baseAddEditMasterDetail.backHandler += new POS.Control.BaseAddEditMaster.BackHandler(this.baseAddEditMasterDetail_backHandler);
            // 
            // KitchenOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.baseAddEditMasterDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "KitchenOrderDetail";
            this.Size = new System.Drawing.Size(1024, 750);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtMenu;
        private System.Windows.Forms.GroupBox groupBox2;
        private Control.GridView.BaseGrid grdBomHead;
        private Control.GridView.BaseGrid grdBomDetail;
        private Control.BaseAddEditMaster baseAddEditMasterDetail;
    }
}
