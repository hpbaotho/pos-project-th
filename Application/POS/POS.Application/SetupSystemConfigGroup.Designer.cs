﻿namespace POS
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdBase
            // 
            this.grdBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdBase.DataKeyName = null;
            this.grdBase.DataSourceTable = null;
            this.grdBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBase.Location = new System.Drawing.Point(3, 3);
            this.grdBase.Name = "grdBase";
            this.grdBase.Size = new System.Drawing.Size(806, 387);
            this.grdBase.TabIndex = 0;
            this.grdBase.onAddNewRow += new System.EventHandler(this.grdBase_onAddNewRow);
            this.grdBase.onLoadDataGrid += new System.EventHandler<POS.Control.GridView.DataBindArgs>(this.grdBase_onLoadDataGrid);
            this.grdBase.onCellFormatting += new System.EventHandler<System.Windows.Forms.DataGridViewCellFormattingEventArgs>(this.grdBase_onCellFormatting);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(820, 419);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdBase);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(812, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DataSource";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SetupSystemConfigGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 419);
            this.Controls.Add(this.tabControl1);
            this.Name = "SetupSystemConfigGroup";
            this.Text = "TestGridControl";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private POS.Control.GridView.BaseGrid grdBase;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;

    }
}