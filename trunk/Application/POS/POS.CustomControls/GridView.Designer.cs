namespace POS.CustomControls
{
    partial class GridView
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
            this.components = new System.ComponentModel.Container();
            this.tsManageData = new System.Windows.Forms.ToolStrip();
            this.tslblAdd = new System.Windows.Forms.ToolStripLabel();
            this.tslblDel = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsManageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tsManageData
            // 
            this.tsManageData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblAdd,
            this.tslblDel});
            this.tsManageData.Location = new System.Drawing.Point(0, 0);
            this.tsManageData.Name = "tsManageData";
            this.tsManageData.Size = new System.Drawing.Size(465, 25);
            this.tsManageData.TabIndex = 0;
            this.tsManageData.Text = "toolStrip1";
            // 
            // tslblAdd
            // 
            this.tslblAdd.Name = "tslblAdd";
            this.tslblAdd.Size = new System.Drawing.Size(29, 22);
            this.tslblAdd.Text = "Add";
            // 
            // tslblDel
            // 
            this.tslblDel.Name = "tslblDel";
            this.tslblDel.Size = new System.Drawing.Size(40, 22);
            this.tslblDel.Text = "Delete";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.dataTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(462, 264);
            this.dataGridView1.TabIndex = 1;
            // 
            // GridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tsManageData);
            this.Name = "GridView";
            this.Size = new System.Drawing.Size(465, 295);
            this.tsManageData.ResumeLayout(false);
            this.tsManageData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsManageData;
        private System.Windows.Forms.ToolStripLabel tslblAdd;
        private System.Windows.Forms.ToolStripLabel tslblDel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dataTableBindingSource;
    }
}
