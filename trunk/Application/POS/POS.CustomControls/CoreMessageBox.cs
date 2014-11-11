using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace POS.CustomControls
{
    /// <summary>
    /// The form internally used by <see cref="CustomMessageBox"/> class.
    /// </summary>
    internal partial class CoreMessageBox : Form
    {
        private Button btnSeeMore;
        private Label lblDescription;
        private Panel pnlErroeDetail;
        private Panel panel1;
        private Label lblError;
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
            this.lblError = new System.Windows.Forms.Label();
            this.btnSeeMore = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlErroeDetail = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlErroeDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Name = "lblError";
            this.lblError.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblError.Size = new System.Drawing.Size(553, 81);
            this.lblError.TabIndex = 0;
            this.lblError.Text = "ErroeMessage";
            // 
            // btnSeeMore
            // 
            this.btnSeeMore.Location = new System.Drawing.Point(466, 10);
            this.btnSeeMore.Name = "btnSeeMore";
            this.btnSeeMore.Size = new System.Drawing.Size(75, 23);
            this.btnSeeMore.TabIndex = 1;
            this.btnSeeMore.Text = "View Detail";
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
            this.pnlErroeDetail.Location = new System.Drawing.Point(0, -11);
            this.pnlErroeDetail.Name = "pnlErroeDetail";
            this.pnlErroeDetail.Size = new System.Drawing.Size(553, 139);
            this.pnlErroeDetail.TabIndex = 3;
            this.pnlErroeDetail.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSeeMore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 45);
            this.panel1.TabIndex = 4;
            // 
            // CoreMessageBox
            // 
            this.ClientSize = new System.Drawing.Size(553, 128);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pnlErroeDetail);
            this.Name = "CoreMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlErroeDetail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
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
