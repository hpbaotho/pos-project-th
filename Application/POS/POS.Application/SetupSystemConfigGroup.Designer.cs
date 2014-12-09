namespace POS
{
    partial class SetupSystemConfigGroup
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
            this.grdBase = new POS.Control.GridView.BaseGrid();
            this.SuspendLayout();
            // 
            // grdBase
            // 
            this.grdBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdBase.DataSourceTable = null;
            this.grdBase.Location = new System.Drawing.Point(13, 13);
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(690, 293);
            this.grdBase.TabIndex = 0;
            this.grdBase.onAddNewRow += new System.EventHandler(this.grdBase_onAddNewRow);
            this.grdBase.onLoadDataGrid += new System.EventHandler<POS.Control.GridView.DataBindArgs>(this.grdBase_onLoadDataGrid);
            this.grdBase.onCellFormatting += new System.EventHandler<System.Windows.Forms.DataGridViewCellFormattingEventArgs>(this.grdBase_onCellFormatting);
            // 
            // TestGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 357);
            this.Controls.Add(this.grdBase);
            this.Name = "TestGridControl";
            this.Text = "TestGridControl";
            this.Load += new System.EventHandler(this.TestGridControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private POS.Control.GridView.BaseGrid grdBase;

    }
}