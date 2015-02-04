namespace POS.LOV
{
    partial class InPortfolio
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelWrapGrid = new System.Windows.Forms.Panel();
            this.grdBaseHead = new POS.Control.GridView.BaseGrid();
            this.gbSearchPanel = new System.Windows.Forms.GroupBox();
            this.txtName = new POS.Control.BaseTextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDesc = new POS.Control.BaseTextBox();
            this.txtCode = new POS.Control.BaseTextBox();
            this.panelWrapGrid.SuspendLayout();
            this.gbSearchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWrapGrid
            // 
            this.panelWrapGrid.Controls.Add(this.grdBaseHead);
            this.panelWrapGrid.Location = new System.Drawing.Point(12, 90);
            this.panelWrapGrid.Name = "panelWrapGrid";
            this.panelWrapGrid.Size = new System.Drawing.Size(739, 311);
            this.panelWrapGrid.TabIndex = 1;
            // 
            // grdBaseHead
            // 
            this.grdBaseHead.btnAddEnable = true;
            this.grdBaseHead.btnAddVisible = true;
            this.grdBaseHead.btnDeleteEnable = true;
            this.grdBaseHead.btnDeleteVisible = true;
            this.grdBaseHead.btnSearchEnable = true;
            this.grdBaseHead.btnSearchVisible = true;
            this.grdBaseHead.DataKeyName = null;
            this.grdBaseHead.DataKeyValue = null;
            this.grdBaseHead.DataSourceDataSet = null;
            this.grdBaseHead.DataSourceTable = null;
            this.grdBaseHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBaseHead.FormMode = ObjectState.Nothing;
            this.grdBaseHead.HiddenColumnName = null;
            this.grdBaseHead.Location = new System.Drawing.Point(0, 0);
            this.grdBaseHead.Name = "grdBaseHead";
            this.grdBaseHead.Size = new System.Drawing.Size(739, 311);
            this.grdBaseHead.TabIndex = 3;
            this.grdBaseHead.onSelectedDataRow += new System.EventHandler<POS.Control.GridView.RowEventArgs>(this.grdBase_onSelectedDataRow);
            this.grdBaseHead.onLoadDataGrid += new System.EventHandler<POS.Control.GridView.DataBindArgs>(this.grdBase_onLoadDataGrid);
            // 
            // gbSearchPanel
            // 
            this.gbSearchPanel.Controls.Add(this.txtName);
            this.gbSearchPanel.Controls.Add(this.lblDesc);
            this.gbSearchPanel.Controls.Add(this.lblCode);
            this.gbSearchPanel.Controls.Add(this.lblName);
            this.gbSearchPanel.Controls.Add(this.txtDesc);
            this.gbSearchPanel.Controls.Add(this.txtCode);
            this.gbSearchPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gbSearchPanel.Location = new System.Drawing.Point(12, 5);
            this.gbSearchPanel.Name = "gbSearchPanel";
            this.gbSearchPanel.Size = new System.Drawing.Size(739, 79);
            this.gbSearchPanel.TabIndex = 32;
            this.gbSearchPanel.TabStop = false;
            this.gbSearchPanel.Text = "Search Criteria";
            // 
            // txtName
            // 
            this.txtName.Description = "";
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtName.Location = new System.Drawing.Point(377, 21);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 44;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblDesc.Location = new System.Drawing.Point(6, 48);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(79, 13);
            this.lblDesc.TabIndex = 38;
            this.lblDesc.Text = "Description :";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCode.Location = new System.Drawing.Point(41, 21);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(44, 13);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Code :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblName.Location = new System.Drawing.Point(324, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name :";
            // 
            // txtDesc
            // 
            this.txtDesc.Description = "";
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDesc.Location = new System.Drawing.Point(91, 45);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(486, 20);
            this.txtDesc.TabIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.Description = "";
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCode.Location = new System.Drawing.Point(91, 21);
            this.txtCode.MaxLength = 100;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(200, 20);
            this.txtCode.TabIndex = 0;
            // 
            // InPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(763, 413);
            this.Controls.Add(this.gbSearchPanel);
            this.Controls.Add(this.panelWrapGrid);
            this.Name = "InPortfolio";
            this.Text = "Portfolio";
            this.Load += new System.EventHandler(this.InMaterial_Load);
            this.panelWrapGrid.ResumeLayout(false);
            this.gbSearchPanel.ResumeLayout(false);
            this.gbSearchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelWrapGrid;
        private Control.GridView.BaseGrid grdBaseHead;
        private System.Windows.Forms.GroupBox gbSearchPanel;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private Control.BaseTextBox txtDesc;
        private Control.BaseTextBox txtCode;
        private Control.BaseTextBox txtName;

    }
}