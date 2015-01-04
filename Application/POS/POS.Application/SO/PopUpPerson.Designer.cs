namespace POS.SO
{
    partial class PopUpPerson
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
            this.btnDelPeson = new POS.Control.BaseButton();
            this.btnClose = new POS.Control.BaseButton();
            this.btnPerson = new POS.Control.BaseButton();
            this.SuspendLayout();
            // 
            // btnDelPeson
            // 
            this.btnDelPeson.CommandArg = null;
            this.btnDelPeson.DataObject = null;
            this.btnDelPeson.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDelPeson.Location = new System.Drawing.Point(392, 12);
            this.btnDelPeson.Name = "btnDelPeson";
            this.btnDelPeson.Size = new System.Drawing.Size(146, 113);
            this.btnDelPeson.TabIndex = 3;
            this.btnDelPeson.Text = "-";
            this.btnDelPeson.Theme = POS.Control.Theme.MSOffice2010_RED;
            this.btnDelPeson.UseVisualStyleBackColor = true;
            this.btnDelPeson.Click += new System.EventHandler(this.btnDelPeson_Click);
            // 
            // btnClose
            // 
            this.btnClose.CommandArg = null;
            this.btnClose.DataObject = null;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.Location = new System.Drawing.Point(150, 254);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(236, 76);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "ตกลง";
            this.btnClose.Theme = POS.Control.Theme.MSOffice2010_Publisher;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPerson
            // 
            this.btnPerson.CommandArg = null;
            this.btnPerson.DataObject = null;
            this.btnPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPerson.Location = new System.Drawing.Point(26, 12);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(360, 113);
            this.btnPerson.TabIndex = 0;
            this.btnPerson.Text = "ลูกค้า";
            this.btnPerson.Theme = POS.Control.Theme.MSOffice2010_Yellow;
            this.btnPerson.UseVisualStyleBackColor = true;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // PopUpPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(574, 342);
            this.Controls.Add(this.btnDelPeson);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopUpPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopUpPerson";
            this.ResumeLayout(false);

        }

        #endregion

        private Control.BaseButton btnPerson;
        private Control.BaseButton btnClose;
        private Control.BaseButton btnDelPeson;
    }
}