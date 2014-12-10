using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Control
{
    /// <summary>
    /// The form internally used by <see cref="CustomMessageBox"/> class.
    /// </summary>
    internal partial class CoreMessageBox : System.Windows.Forms.Form
    {
        private POS.Control.BaseButton btnSeeMore;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel pnlErroeDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer spMessage;
        private System.Windows.Forms.Panel panel2;
        private POS.Control.BaseButton btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblError;
        /// <summary>
        /// This constructor is required for designer support.
        /// </summary>
        public CoreMessageBox()
        {
            InitializeComponent();
        }

        public CoreMessageBox(string title, string description)
        {
            InitializeComponent();

            this.lblError.Text = title;
            this.lblDescription.Text = description;
        }

        private void InitializeComponent()
        {
            POS.Control.Office2010White office2010White3 = new POS.Control.Office2010White();
            POS.Control.Office2010White office2010White4 = new POS.Control.Office2010White();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSeeMore = new POS.Control.BaseButton();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlErroeDetail = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.spMessage = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new POS.Control.BaseButton();
            this.pnlErroeDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMessage)).BeginInit();
            this.spMessage.Panel1.SuspendLayout();
            this.spMessage.Panel2.SuspendLayout();
            this.spMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Name = "lblError";
            this.lblError.Padding = new System.Windows.Forms.Padding(10, 20, 10, 0);
            this.lblError.Size = new System.Drawing.Size(455, 93);
            this.lblError.TabIndex = 0;
            this.lblError.Tag = "";
            this.lblError.Text = "Message";
            // 
            // btnSeeMore
            // 
            this.btnSeeMore.Anchor = System.Windows.Forms.AnchorStyles.None;
            office2010White3.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(72)))), ((int)(((byte)(161)))));
            office2010White3.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(135)))), ((int)(((byte)(228)))));
            office2010White3.ButtonMouseOverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010White3.ButtonMouseOverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010White3.ButtonMouseOverColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(225)))), ((int)(((byte)(137)))));
            office2010White3.ButtonMouseOverColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(224)))));
            office2010White3.ButtonNormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
            office2010White3.ButtonNormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            office2010White3.ButtonNormalColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            office2010White3.ButtonNormalColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            office2010White3.ButtonSelectedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010White3.ButtonSelectedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010White3.ButtonSelectedColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(117)))));
            office2010White3.ButtonSelectedColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            office2010White3.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010White3.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010White3.TextColor = System.Drawing.Color.Black;
            this.btnSeeMore.ColorTable = office2010White3;
            this.btnSeeMore.Location = new System.Drawing.Point(394, 3);
            this.btnSeeMore.Name = "btnSeeMore";
            this.btnSeeMore.Size = new System.Drawing.Size(75, 23);
            this.btnSeeMore.TabIndex = 1;
            this.btnSeeMore.Text = "View Detail";
            this.btnSeeMore.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnSeeMore.UseVisualStyleBackColor = true;
            this.btnSeeMore.Click += new System.EventHandler(this.btnSeeMore_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.lblDescription.Size = new System.Drawing.Size(534, 138);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Erroe Message Detail";
            this.lblDescription.Visible = false;
            // 
            // pnlErroeDetail
            // 
            this.pnlErroeDetail.AutoScroll = true;
            this.pnlErroeDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlErroeDetail.Controls.Add(this.lblDescription);
            this.pnlErroeDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlErroeDetail.Location = new System.Drawing.Point(0, -15);
            this.pnlErroeDetail.Name = "pnlErroeDetail";
            this.pnlErroeDetail.Size = new System.Drawing.Size(553, 139);
            this.pnlErroeDetail.TabIndex = 3;
            this.pnlErroeDetail.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.spMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 93);
            this.panel1.TabIndex = 4;
            // 
            // spMessage
            // 
            this.spMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMessage.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spMessage.IsSplitterFixed = true;
            this.spMessage.Location = new System.Drawing.Point(0, 0);
            this.spMessage.Name = "spMessage";
            // 
            // spMessage.Panel1
            // 
            this.spMessage.Panel1.Controls.Add(this.pictureBox1);
            // 
            // spMessage.Panel2
            // 
            this.spMessage.Panel2.Controls.Add(this.lblError);
            this.spMessage.Size = new System.Drawing.Size(553, 93);
            this.spMessage.SplitterDistance = 94;
            this.spMessage.TabIndex = 2;
            this.spMessage.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::POS.Control.Properties.Resources.error;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(94, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSeeMore);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 30);
            this.panel2.TabIndex = 5;
            // 
            // btnClose
            // 
            office2010White4.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(72)))), ((int)(((byte)(161)))));
            office2010White4.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(135)))), ((int)(((byte)(228)))));
            office2010White4.ButtonMouseOverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010White4.ButtonMouseOverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010White4.ButtonMouseOverColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(225)))), ((int)(((byte)(137)))));
            office2010White4.ButtonMouseOverColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(224)))));
            office2010White4.ButtonNormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(154)))), ((int)(((byte)(154)))));
            office2010White4.ButtonNormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            office2010White4.ButtonNormalColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            office2010White4.ButtonNormalColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            office2010White4.ButtonSelectedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010White4.ButtonSelectedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010White4.ButtonSelectedColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(117)))));
            office2010White4.ButtonSelectedColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            office2010White4.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010White4.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010White4.TextColor = System.Drawing.Color.Black;
            this.btnClose.ColorTable = office2010White4;
            this.btnClose.Location = new System.Drawing.Point(475, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CoreMessageBox
            // 
            this.ClientSize = new System.Drawing.Size(553, 124);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlErroeDetail);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoreMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlErroeDetail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.spMessage.Panel1.ResumeLayout(false);
            this.spMessage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMessage)).EndInit();
            this.spMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void btnSeeMore_Click(object sender, EventArgs e)
        {
            bool visible = lblDescription.Visible;
            lblDescription.Visible = !visible;
            pnlErroeDetail.Visible = !visible;
            if (!visible)
            {
                btnSeeMore.Text = "Hide Detail";
                this.Height = 323;

            }
            else
            {
                btnSeeMore.Text = "Vide Detail";

                this.Height = 167;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
    }

    /// <summary>
    /// Your custom message box helper.
    /// </summary>
    public static class ErrorMessageBox
    {
        public static void Show(string title, string description)
        {
            // using construct ensures the resources are freed when form is closed
            using (var form = new CoreMessageBox(title, description))
            {
                form.ShowDialog();
            }
        }
    }
}
