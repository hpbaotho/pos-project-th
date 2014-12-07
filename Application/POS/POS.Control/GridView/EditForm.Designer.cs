namespace POS.Control.GridView
{
    partial class EditForm
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
            this.tbLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tbLayout
            // 
            this.tbLayout.AutoSize = true;
            this.tbLayout.ColumnCount = 2;
            this.tbLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbLayout.Location = new System.Drawing.Point(12, 12);
            this.tbLayout.Name = "tbLayout";
            this.tbLayout.RowCount = 1;
            this.tbLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbLayout.Size = new System.Drawing.Size(785, 606);
            this.tbLayout.TabIndex = 0;
            this.tbLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.tbLayout_Paint);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 630);
            this.Controls.Add(this.tbLayout);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbLayout;
    }
}