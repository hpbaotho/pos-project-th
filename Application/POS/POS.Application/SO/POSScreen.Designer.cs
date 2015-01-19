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
            this.btnClose = new POS.Control.BaseButton();
            this.timerTable = new System.Windows.Forms.Timer(this.components);
            this.btnTakeaway = new POS.Control.BaseButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTableView = new System.Windows.Forms.Panel();
            this.pnlTakeAway = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerTakeAway = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.CommandArg = null;
            this.btnClose.DataObject = null;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.Location = new System.Drawing.Point(538, 467);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(294, 66);
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
            // btnTakeaway
            // 
            this.btnTakeaway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTakeaway.CommandArg = null;
            this.btnTakeaway.DataObject = null;
            this.btnTakeaway.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnTakeaway.Location = new System.Drawing.Point(4, 467);
            this.btnTakeaway.Name = "btnTakeaway";
            this.btnTakeaway.Size = new System.Drawing.Size(262, 66);
            this.btnTakeaway.TabIndex = 6;
            this.btnTakeaway.Text = "Take away";
            this.btnTakeaway.Theme = POS.Control.Theme.MSOffice2010_Green;
            this.btnTakeaway.UseVisualStyleBackColor = true;
            this.btnTakeaway.Click += new System.EventHandler(this.btnTakeaway_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 301F));
            this.tableLayoutPanel1.Controls.Add(this.btnTakeaway, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlTableView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlTakeAway, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.9162F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0838F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(836, 537);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // pnlTableView
            // 
            this.pnlTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableView.Location = new System.Drawing.Point(4, 62);
            this.pnlTableView.Name = "pnlTableView";
            this.pnlTableView.Size = new System.Drawing.Size(526, 398);
            this.pnlTableView.TabIndex = 7;
            // 
            // pnlTakeAway
            // 
            this.pnlTakeAway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTakeAway.Location = new System.Drawing.Point(537, 62);
            this.pnlTakeAway.Name = "pnlTakeAway";
            this.pnlTakeAway.Size = new System.Drawing.Size(295, 398);
            this.pnlTakeAway.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(526, 57);
            this.label1.TabIndex = 9;
            this.label1.Text = "Shop Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(537, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 57);
            this.label2.TabIndex = 10;
            this.label2.Text = "Take Away Order";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerTakeAway
            // 
            this.timerTakeAway.Interval = 1000;
            this.timerTakeAway.Tick += new System.EventHandler(this.timerTakeAway_Tick);
            // 
            // POSScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 537);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "POSScreen";
            this.Text = "POSScreen";
            this.Shown += new System.EventHandler(this.POSScreen_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.BaseButton btnClose;
        private System.Windows.Forms.Timer timerTable;
        private Control.BaseButton btnTakeaway;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlTableView;
        private System.Windows.Forms.FlowLayoutPanel pnlTakeAway;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerTakeAway;
    }
}