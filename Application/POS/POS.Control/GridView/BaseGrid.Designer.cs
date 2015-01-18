namespace POS.Control.GridView
{
    partial class BaseGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseGrid));
            this.Grid = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblTotalRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblSelectedRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProcessComplete = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnProcessCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.AllowUserToOrderColumns = true;
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.EnableHeadersVisualStyles = false;
            this.Grid.Location = new System.Drawing.Point(0, 53);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.ShowCellErrors = false;
            this.Grid.ShowRowErrors = false;
            this.Grid.Size = new System.Drawing.Size(431, 228);
            this.Grid.TabIndex = 2;
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            this.Grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_CellFormatting);
            this.Grid.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.Grid_ColumnAdded);
            this.Grid.SelectionChanged += new System.EventHandler(this.Grid_SelectionChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblTotalRows,
            this.tsslblSelectedRows});
            this.statusStrip1.Location = new System.Drawing.Point(0, 280);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(431, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblTotalRows
            // 
            this.tsslblTotalRows.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslblTotalRows.Name = "tsslblTotalRows";
            this.tsslblTotalRows.Size = new System.Drawing.Size(78, 19);
            this.tsslblTotalRows.Text = "Total 0 Rows";
            // 
            // tsslblSelectedRows
            // 
            this.tsslblSelectedRows.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslblSelectedRows.Name = "tsslblSelectedRows";
            this.tsslblSelectedRows.Size = new System.Drawing.Size(101, 19);
            this.tsslblSelectedRows.Text = "No selected rows";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnProcessComplete);
            this.panel1.Controls.Add(this.btnProcess);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnProcessCancel);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 53);
            this.panel1.TabIndex = 5;
            // 
            // btnProcessComplete
            // 
            this.btnProcessComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessComplete.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessComplete.Image")));
            this.btnProcessComplete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcessComplete.Location = new System.Drawing.Point(217, 1);
            this.btnProcessComplete.Name = "btnProcessComplete";
            this.btnProcessComplete.Size = new System.Drawing.Size(54, 50);
            this.btnProcessComplete.TabIndex = 3;
            this.btnProcessComplete.Tag = "kitchenOP";
            this.btnProcessComplete.Text = "Comp";
            this.btnProcessComplete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcessComplete.UseVisualStyleBackColor = true;
            this.btnProcessComplete.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcess.Location = new System.Drawing.Point(164, 1);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(54, 50);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Tag = "kitchenOP";
            this.btnProcess.Text = "Proc";
            this.btnProcess.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(104, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 50);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Tag = "normalOP";
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnProcessCancel
            // 
            this.btnProcessCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessCancel.Image")));
            this.btnProcessCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProcessCancel.Location = new System.Drawing.Point(270, 1);
            this.btnProcessCancel.Name = "btnProcessCancel";
            this.btnProcessCancel.Size = new System.Drawing.Size(54, 50);
            this.btnProcessCancel.TabIndex = 1;
            this.btnProcessCancel.Tag = "kitchenOP";
            this.btnProcessCancel.Text = "Cancel";
            this.btnProcessCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcessCancel.UseVisualStyleBackColor = true;
            this.btnProcessCancel.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(53, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(54, 50);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Tag = "normalOP";
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdd.Location = new System.Drawing.Point(0, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 50);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Tag = "normalOP";
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.tsbtnAddRow_Click);
            // 
            // BaseGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Grid);
            this.Name = "BaseGrid";
            this.Size = new System.Drawing.Size(431, 304);
            this.Load += new System.EventHandler(this.BaseGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblTotalRows;
        private System.Windows.Forms.ToolStripStatusLabel tsslblSelectedRows;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnProcessComplete;
        private System.Windows.Forms.Button btnProcessCancel;
    }
}
