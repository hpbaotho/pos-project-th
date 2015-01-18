namespace POS.SO
{
    partial class POSScreen
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
            this.components = new System.ComponentModel.Container();
            this.pnlTableView = new System.Windows.Forms.Panel();
            this.btnClose = new POS.Control.BaseButton();
            this.timerTable = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pnlTableView
            // 
            this.pnlTableView.Location = new System.Drawing.Point(12, 12);
            this.pnlTableView.Name = "pnlTableView";
            this.pnlTableView.Size = new System.Drawing.Size(800, 398);
            this.pnlTableView.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.CommandArg = null;
            this.btnClose.DataObject = null;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.Location = new System.Drawing.Point(550, 438);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(262, 75);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Main Screen";
            this.btnClose.Theme = POS.Control.Theme.MSOffice2010_RED;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timerTable
            // 
            this.timerTable.Interval = 300;
            this.timerTable.Tick += new System.EventHandler(this.timerTable_Tick);
            // 
            // POSScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 537);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlTableView);
            this.Name = "POSScreen";
            this.Text = "POSScreen";
            this.Shown += new System.EventHandler(this.POSScreen_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTableView;
        private Control.BaseButton btnClose;
        private System.Windows.Forms.Timer timerTable;
    }
}