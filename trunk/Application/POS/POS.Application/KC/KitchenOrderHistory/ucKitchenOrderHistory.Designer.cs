namespace POS.KC.KitchenOrderHistory
{
    partial class ucKitchenOrderHistory
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelWrapGrid = new System.Windows.Forms.Panel();
            this.grdBase = new POS.Control.GridView.BaseGrid();
            this.gbSearchPanel = new System.Windows.Forms.GroupBox();
            this.ddlStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtMenuName = new POS.Control.BaseTextBox();
            this.txtTableName = new POS.Control.BaseTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelWrapGrid.SuspendLayout();
            this.gbSearchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(976, 396);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelWrapGrid);
            this.tabPage1.Controls.Add(this.gbSearchPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(968, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelWrapGrid
            // 
            this.panelWrapGrid.Controls.Add(this.grdBase);
            this.panelWrapGrid.Location = new System.Drawing.Point(6, 112);
            this.panelWrapGrid.Name = "panelWrapGrid";
            this.panelWrapGrid.Size = new System.Drawing.Size(976, 341);
            this.panelWrapGrid.TabIndex = 0;
            // 
            // grdBase
            // 
            this.grdBase.btnAddEnable = true;
            this.grdBase.btnAddVisible = true;
            this.grdBase.btnDeleteEnable = true;
            this.grdBase.btnDeleteVisible = true;
            this.grdBase.btnSearchEnable = true;
            this.grdBase.btnSearchVisible = true;
            this.grdBase.DataKeyName = null;
            this.grdBase.DataKeyValue = null;
            this.grdBase.DataSourceDataSet = null;
            this.grdBase.DataSourceTable = null;
            this.grdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase.FormMode = ObjectState.Nothing;
            this.grdBase.HiddenColumnName = null;
            this.grdBase.Location = new System.Drawing.Point(0, 0);
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(976, 341);
            this.grdBase.TabIndex = 3;
            // 
            // gbSearchPanel
            // 
            this.gbSearchPanel.Controls.Add(this.ddlStatus);
            this.gbSearchPanel.Controls.Add(this.label1);
            this.gbSearchPanel.Controls.Add(this.lblReferenceNo);
            this.gbSearchPanel.Controls.Add(this.lblReason);
            this.gbSearchPanel.Controls.Add(this.txtMenuName);
            this.gbSearchPanel.Controls.Add(this.txtTableName);
            this.gbSearchPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gbSearchPanel.Location = new System.Drawing.Point(6, 6);
            this.gbSearchPanel.Name = "gbSearchPanel";
            this.gbSearchPanel.Size = new System.Drawing.Size(956, 100);
            this.gbSearchPanel.TabIndex = 31;
            this.gbSearchPanel.TabStop = false;
            this.gbSearchPanel.Text = "Search Criteria";
            // 
            // ddlStatus
            // 
            this.ddlStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddlStatus.FormattingEnabled = true;
            this.ddlStatus.Location = new System.Drawing.Point(188, 56);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(163, 21);
            this.ddlStatus.TabIndex = 26;
            this.ddlStatus.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(111, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Status :";
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReferenceNo.Location = new System.Drawing.Point(79, 27);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(83, 13);
            this.lblReferenceNo.TabIndex = 1;
            this.lblReferenceNo.Text = "Table Name :";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReason.Location = new System.Drawing.Point(402, 26);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(82, 13);
            this.lblReason.TabIndex = 2;
            this.lblReason.Text = "Menu Name :";
            // 
            // txtMenuName
            // 
            this.txtMenuName.Description = "";
            this.txtMenuName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMenuName.Location = new System.Drawing.Point(523, 23);
            this.txtMenuName.MaxLength = 100;
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(163, 20);
            this.txtMenuName.TabIndex = 0;
            // 
            // txtTableName
            // 
            this.txtTableName.Description = "";
            this.txtTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTableName.Location = new System.Drawing.Point(188, 24);
            this.txtTableName.MaxLength = 100;
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(163, 20);
            this.txtTableName.TabIndex = 0;
            // 
            // ucKitchenOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucKitchenOrderHistory";
            this.Size = new System.Drawing.Size(976, 396);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelWrapGrid.ResumeLayout(false);
            this.gbSearchPanel.ResumeLayout(false);
            this.gbSearchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelWrapGrid;
        private System.Windows.Forms.GroupBox gbSearchPanel;
        private Control.BaseTextBox txtTableName;
        private Control.GridView.BaseGrid grdBase;
        private System.Windows.Forms.Label lblReferenceNo;
        private System.Windows.Forms.Label lblReason;
        private Control.BaseTextBox txtMenuName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlStatus;
    }
}
