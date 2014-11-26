namespace POS
{
    partial class DragForm
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
            this.labLocation = new System.Windows.Forms.Label();
            this.pnlDragArea = new POS.CustomControls.DragContainer();
            this.SuspendLayout();
            // 
            // labLocation
            // 
            this.labLocation.AutoSize = true;
            this.labLocation.Location = new System.Drawing.Point(568, 368);
            this.labLocation.Name = "labLocation";
            this.labLocation.Size = new System.Drawing.Size(35, 13);
            this.labLocation.TabIndex = 0;
            this.labLocation.Text = "label1";
            // 
            // pnlDragArea
            // 
            this.pnlDragArea.Location = new System.Drawing.Point(0, 0);
            this.pnlDragArea.Name = "pnlDragArea";
            this.pnlDragArea.Size = new System.Drawing.Size(562, 401);
            this.pnlDragArea.TabIndex = 1;
            // 
            // DragForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 403);
            this.Controls.Add(this.pnlDragArea);
            this.Controls.Add(this.labLocation);
            this.Name = "DragForm";
            this.Text = "DragForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labLocation;
        private CustomControls.DragContainer pnlDragArea;
    }
}