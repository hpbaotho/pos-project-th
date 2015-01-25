namespace POS.IN.SetupMaterialGroup
{
    partial class ucMaterialGroup
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
            this.txtMaterialGroupName = new POS.Control.BaseTextBox();
            this.txtMaterialGroupCode = new POS.Control.BaseTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdBase = new POS.Control.GridView.BaseGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaterialGroupName
            // 
            this.txtMaterialGroupName.Description = "";
            this.txtMaterialGroupName.Location = new System.Drawing.Point(400, 24);
            this.txtMaterialGroupName.Name = "txtMaterialGroupName";
            this.txtMaterialGroupName.Size = new System.Drawing.Size(183, 20);
            this.txtMaterialGroupName.TabIndex = 5;
            // 
            // txtMaterialGroupCode
            // 
            this.txtMaterialGroupCode.Description = "";
            this.txtMaterialGroupCode.Location = new System.Drawing.Point(118, 24);
            this.txtMaterialGroupCode.Name = "txtMaterialGroupCode";
            this.txtMaterialGroupCode.Size = new System.Drawing.Size(121, 20);
            this.txtMaterialGroupCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material Group Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaterialGroupName);
            this.groupBox1.Controls.Add(this.txtMaterialGroupCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material Group Code";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdBase, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.75576F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.24425F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 449);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.grdBase.FormMode = ObjectState.Nothing;
            this.grdBase.HiddenColumnName = null;
            this.grdBase.Location = new System.Drawing.Point(3, 69);
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(970, 377);
            this.grdBase.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(976, 477);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(968, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucMaterialGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucMaterialGroup";
            this.Size = new System.Drawing.Size(976, 477);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.BaseTextBox txtMaterialGroupName;
        private Control.BaseTextBox txtMaterialGroupCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Control.GridView.BaseGrid grdBase;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
    }
}
