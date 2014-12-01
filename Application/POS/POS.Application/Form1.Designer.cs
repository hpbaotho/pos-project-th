namespace POS
{
    partial class Form1
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
            this.coreButton1 = new POS.CustomControls.CoreButton();
            this.coreTextBox1 = new POS.CustomControls.CoreTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // coreButton1
            // 
            this.coreButton1.Location = new System.Drawing.Point(286, 407);
            this.coreButton1.Name = "coreButton1";
            this.coreButton1.Size = new System.Drawing.Size(75, 23);
            this.coreButton1.TabIndex = 0;
            this.coreButton1.Text = "coreButton1";
            this.coreButton1.UseVisualStyleBackColor = true;
            this.coreButton1.Click += new System.EventHandler(this.coreButton1_Click);
            // 
            // coreTextBox1
            // 
            this.coreTextBox1.Location = new System.Drawing.Point(180, 407);
            this.coreTextBox1.Name = "coreTextBox1";
            this.coreTextBox1.Size = new System.Drawing.Size(100, 20);
            this.coreTextBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 442);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.coreTextBox1);
            this.Controls.Add(this.coreButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.CoreButton coreButton1;
        private CustomControls.CoreTextBox coreTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

