namespace POS.IN.ReceiveOrder
{
    partial class ucReceiveOrder
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
            this.ddlFNPeriod = new System.Windows.Forms.ComboBox();
            this.dpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFNPeriod = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtDocNo = new POS.Control.BaseTextBox();
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
            this.panelWrapGrid.Location = new System.Drawing.Point(6, 97);
            this.panelWrapGrid.Name = "panelWrapGrid";
            this.panelWrapGrid.Size = new System.Drawing.Size(976, 293);
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
            this.grdBase.Size = new System.Drawing.Size(976, 293);
            this.grdBase.TabIndex = 3;
            // 
            // gbSearchPanel
            // 
            this.gbSearchPanel.Controls.Add(this.ddlFNPeriod);
            this.gbSearchPanel.Controls.Add(this.dpDateFrom);
            this.gbSearchPanel.Controls.Add(this.dpDateTo);
            this.gbSearchPanel.Controls.Add(this.label2);
            this.gbSearchPanel.Controls.Add(this.lblFNPeriod);
            this.gbSearchPanel.Controls.Add(this.label1);
            this.gbSearchPanel.Controls.Add(this.lblReason);
            this.gbSearchPanel.Controls.Add(this.txtDocNo);
            this.gbSearchPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gbSearchPanel.Location = new System.Drawing.Point(6, 6);
            this.gbSearchPanel.Name = "gbSearchPanel";
            this.gbSearchPanel.Size = new System.Drawing.Size(956, 85);
            this.gbSearchPanel.TabIndex = 31;
            this.gbSearchPanel.TabStop = false;
            this.gbSearchPanel.Text = "Search Criteria";
            // 
            // ddlFNPeriod
            // 
            this.ddlFNPeriod.FormattingEnabled = true;
            this.ddlFNPeriod.Location = new System.Drawing.Point(121, 17);
            this.ddlFNPeriod.Name = "ddlFNPeriod";
            this.ddlFNPeriod.Size = new System.Drawing.Size(163, 21);
            this.ddlFNPeriod.TabIndex = 32;
            // 
            // dpDateFrom
            // 
            this.dpDateFrom.Location = new System.Drawing.Point(444, 17);
            this.dpDateFrom.Name = "dpDateFrom";
            this.dpDateFrom.Size = new System.Drawing.Size(222, 20);
            this.dpDateFrom.TabIndex = 30;
            // 
            // dpDateTo
            // 
            this.dpDateTo.Location = new System.Drawing.Point(444, 44);
            this.dpDateTo.Name = "dpDateTo";
            this.dpDateTo.Size = new System.Drawing.Size(222, 20);
            this.dpDateTo.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(304, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Document Date From :";
            // 
            // lblFNPeriod
            // 
            this.lblFNPeriod.AutoSize = true;
            this.lblFNPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFNPeriod.Location = new System.Drawing.Point(59, 21);
            this.lblFNPeriod.Name = "lblFNPeriod";
            this.lblFNPeriod.Size = new System.Drawing.Size(51, 13);
            this.lblFNPeriod.TabIndex = 1;
            this.lblFNPeriod.Text = "Period :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(316, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Document Date To :";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReason.Location = new System.Drawing.Point(18, 48);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(92, 13);
            this.lblReason.TabIndex = 2;
            this.lblReason.Text = "Document No :";
            // 
            // txtDocNo
            // 
            this.txtDocNo.Description = "";
            this.txtDocNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDocNo.Location = new System.Drawing.Point(121, 44);
            this.txtDocNo.MaxLength = 100;
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(163, 20);
            this.txtDocNo.TabIndex = 0;
            // 
            // ucReceiveOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucReceiveOrder";
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
        private Control.GridView.BaseGrid grdBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFNPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.DateTimePicker dpDateFrom;
        private System.Windows.Forms.DateTimePicker dpDateTo;
        private Control.BaseTextBox txtDocNo;
        private System.Windows.Forms.ComboBox ddlFNPeriod;
    }
}
