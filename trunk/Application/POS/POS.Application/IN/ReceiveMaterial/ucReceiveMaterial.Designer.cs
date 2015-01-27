namespace POS.IN.ReceiveMaterial
{
    partial class ucReceiveMaterial
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
            this.dpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReferenceNo = new System.Windows.Forms.Label();
            this.txtOther = new POS.Control.BaseTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlWarehouse = new System.Windows.Forms.ComboBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.ddlSupplier = new System.Windows.Forms.ComboBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.txtDocNo = new POS.Control.BaseTextBox();
            this.txtReferenceNo = new POS.Control.BaseTextBox();
            this.rdoSupplier = new System.Windows.Forms.RadioButton();
            this.rdoWarehouse = new System.Windows.Forms.RadioButton();
            this.rdoOther = new System.Windows.Forms.RadioButton();
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
            this.panelWrapGrid.Location = new System.Drawing.Point(6, 160);
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
            this.gbSearchPanel.Controls.Add(this.dpDateFrom);
            this.gbSearchPanel.Controls.Add(this.dpDateTo);
            this.gbSearchPanel.Controls.Add(this.label2);
            this.gbSearchPanel.Controls.Add(this.lblReferenceNo);
            this.gbSearchPanel.Controls.Add(this.txtOther);
            this.gbSearchPanel.Controls.Add(this.label1);
            this.gbSearchPanel.Controls.Add(this.ddlWarehouse);
            this.gbSearchPanel.Controls.Add(this.lblReason);
            this.gbSearchPanel.Controls.Add(this.ddlSupplier);
            this.gbSearchPanel.Controls.Add(this.lblSource);
            this.gbSearchPanel.Controls.Add(this.txtDocNo);
            this.gbSearchPanel.Controls.Add(this.txtReferenceNo);
            this.gbSearchPanel.Controls.Add(this.rdoSupplier);
            this.gbSearchPanel.Controls.Add(this.rdoWarehouse);
            this.gbSearchPanel.Controls.Add(this.rdoOther);
            this.gbSearchPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gbSearchPanel.Location = new System.Drawing.Point(6, 6);
            this.gbSearchPanel.Name = "gbSearchPanel";
            this.gbSearchPanel.Size = new System.Drawing.Size(956, 148);
            this.gbSearchPanel.TabIndex = 31;
            this.gbSearchPanel.TabStop = false;
            this.gbSearchPanel.Text = "Search Criteria";
            // 
            // dpDateFrom
            // 
            this.dpDateFrom.Location = new System.Drawing.Point(444, 21);
            this.dpDateFrom.Name = "dpDateFrom";
            this.dpDateFrom.Size = new System.Drawing.Size(222, 20);
            this.dpDateFrom.TabIndex = 30;
            // 
            // dpDateTo
            // 
            this.dpDateTo.Location = new System.Drawing.Point(444, 49);
            this.dpDateTo.Name = "dpDateTo";
            this.dpDateTo.Size = new System.Drawing.Size(222, 20);
            this.dpDateTo.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(304, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Document Date From :";
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblReferenceNo.Location = new System.Drawing.Point(12, 21);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(98, 13);
            this.lblReferenceNo.TabIndex = 1;
            this.lblReferenceNo.Text = "Reference No. :";
            // 
            // txtOther
            // 
            this.txtOther.Description = "";
            this.txtOther.Enabled = false;
            this.txtOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOther.Location = new System.Drawing.Point(224, 123);
            this.txtOther.MaxLength = 1000;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(305, 20);
            this.txtOther.TabIndex = 27;
            this.txtOther.Tag = "rdoOther";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(316, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Document Date To :";
            // 
            // ddlWarehouse
            // 
            this.ddlWarehouse.Enabled = false;
            this.ddlWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddlWarehouse.FormattingEnabled = true;
            this.ddlWarehouse.Location = new System.Drawing.Point(224, 99);
            this.ddlWarehouse.Name = "ddlWarehouse";
            this.ddlWarehouse.Size = new System.Drawing.Size(305, 21);
            this.ddlWarehouse.TabIndex = 26;
            this.ddlWarehouse.Tag = "rdoWarehouse";
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
            // ddlSupplier
            // 
            this.ddlSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddlSupplier.FormattingEnabled = true;
            this.ddlSupplier.Location = new System.Drawing.Point(224, 74);
            this.ddlSupplier.Name = "ddlSupplier";
            this.ddlSupplier.Size = new System.Drawing.Size(305, 21);
            this.ddlSupplier.TabIndex = 25;
            this.ddlSupplier.Tag = "rdoSupplier";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSource.Location = new System.Drawing.Point(55, 77);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(55, 13);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "Source :";
            // 
            // txtDocNo
            // 
            this.txtDocNo.Description = "";
            this.txtDocNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDocNo.Location = new System.Drawing.Point(121, 49);
            this.txtDocNo.MaxLength = 100;
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(163, 20);
            this.txtDocNo.TabIndex = 0;
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Description = "";
            this.txtReferenceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtReferenceNo.Location = new System.Drawing.Point(121, 21);
            this.txtReferenceNo.MaxLength = 100;
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(163, 20);
            this.txtReferenceNo.TabIndex = 0;
            // 
            // rdoSupplier
            // 
            this.rdoSupplier.AutoSize = true;
            this.rdoSupplier.Checked = true;
            this.rdoSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoSupplier.Location = new System.Drawing.Point(121, 77);
            this.rdoSupplier.Name = "rdoSupplier";
            this.rdoSupplier.Size = new System.Drawing.Size(63, 17);
            this.rdoSupplier.TabIndex = 2;
            this.rdoSupplier.TabStop = true;
            this.rdoSupplier.Text = "Supplier";
            this.rdoSupplier.UseVisualStyleBackColor = true;
            this.rdoSupplier.CheckedChanged += new System.EventHandler(this.rdoItolerate_CheckedChanged);
            // 
            // rdoWarehouse
            // 
            this.rdoWarehouse.AutoSize = true;
            this.rdoWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoWarehouse.Location = new System.Drawing.Point(121, 100);
            this.rdoWarehouse.Name = "rdoWarehouse";
            this.rdoWarehouse.Size = new System.Drawing.Size(80, 17);
            this.rdoWarehouse.TabIndex = 4;
            this.rdoWarehouse.Text = "Warehouse";
            this.rdoWarehouse.UseVisualStyleBackColor = true;
            this.rdoWarehouse.CheckedChanged += new System.EventHandler(this.rdoItolerate_CheckedChanged);
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdoOther.Location = new System.Drawing.Point(121, 123);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(51, 17);
            this.rdoOther.TabIndex = 6;
            this.rdoOther.Text = "Other";
            this.rdoOther.UseVisualStyleBackColor = true;
            this.rdoOther.CheckedChanged += new System.EventHandler(this.rdoItolerate_CheckedChanged);
            // 
            // ucReceiveMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucReceiveMaterial";
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
        private Control.BaseTextBox txtOther;
        private System.Windows.Forms.ComboBox ddlWarehouse;
        private System.Windows.Forms.ComboBox ddlSupplier;
        private System.Windows.Forms.Label lblSource;
        private Control.BaseTextBox txtReferenceNo;
        private System.Windows.Forms.RadioButton rdoSupplier;
        private System.Windows.Forms.RadioButton rdoWarehouse;
        private System.Windows.Forms.RadioButton rdoOther;
        private Control.GridView.BaseGrid grdBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReferenceNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.DateTimePicker dpDateFrom;
        private System.Windows.Forms.DateTimePicker dpDateTo;
        private Control.BaseTextBox txtDocNo;
    }
}
