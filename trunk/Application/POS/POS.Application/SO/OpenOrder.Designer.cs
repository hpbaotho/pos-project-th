using POS.Control;
namespace POS.SO
{
    partial class OpenOrder
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
            this.components = new System.ComponentModel.Container();
            this.fPnlMenuItem = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new POS.Control.BaseButton();
            this.baseButton1 = new POS.Control.BaseButton();
            this.pnlNumScreen = new System.Windows.Forms.Panel();
            this.txtCommand = new POS.Control.BaseTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnStartTime = new POS.Control.BaseButton();
            this.btnPerson = new POS.Control.BaseButton();
            this.baseButton6 = new POS.Control.BaseButton();
            this.btnDelete = new POS.Control.BaseButton();
            this.btnAdd = new POS.Control.BaseButton();
            this.btnPrint = new POS.Control.BaseButton();
            this.baseButton4 = new POS.Control.BaseButton();
            this.baseButton3 = new POS.Control.BaseButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labEatingTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labPersonCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbltablrdesc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labTotalPrice = new System.Windows.Forms.Label();
            this.fPnlMainMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.lisMenuOrder = new System.Windows.Forms.ListView();
            this.fPnlDiningType = new System.Windows.Forms.FlowLayoutPanel();
            this.timeEating = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // fPnlMenuItem
            // 
            this.fPnlMenuItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fPnlMenuItem.AutoScroll = true;
            this.fPnlMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fPnlMenuItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fPnlMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fPnlMenuItem.Location = new System.Drawing.Point(556, 80);
            this.fPnlMenuItem.Name = "fPnlMenuItem";
            this.fPnlMenuItem.Size = new System.Drawing.Size(199, 467);
            this.fPnlMenuItem.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.CommandArg = null;
            this.btnClose.DataObject = null;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.Location = new System.Drawing.Point(120, 694);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 62);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Theme = POS.Control.Theme.MSOffice2010_RED;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // baseButton1
            // 
            this.baseButton1.CommandArg = null;
            this.baseButton1.DataObject = null;
            this.baseButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.baseButton1.Location = new System.Drawing.Point(408, 694);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(139, 62);
            this.baseButton1.TabIndex = 5;
            this.baseButton1.Text = "PAY";
            this.baseButton1.Theme = POS.Control.Theme.MSOffice2010_Green;
            this.baseButton1.UseVisualStyleBackColor = true;
            // 
            // pnlNumScreen
            // 
            this.pnlNumScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNumScreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlNumScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNumScreen.Location = new System.Drawing.Point(553, 603);
            this.pnlNumScreen.Name = "pnlNumScreen";
            this.pnlNumScreen.Size = new System.Drawing.Size(202, 162);
            this.pnlNumScreen.TabIndex = 6;
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCommand.Location = new System.Drawing.Point(556, 553);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(202, 44);
            this.txtCommand.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnStartTime);
            this.panel3.Controls.Add(this.btnPerson);
            this.panel3.Controls.Add(this.baseButton6);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnPrint);
            this.panel3.Controls.Add(this.baseButton4);
            this.panel3.Controls.Add(this.baseButton3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(116, 768);
            this.panel3.TabIndex = 8;
            // 
            // btnStartTime
            // 
            this.btnStartTime.CommandArg = null;
            this.btnStartTime.DataObject = null;
            this.btnStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnStartTime.Location = new System.Drawing.Point(3, 157);
            this.btnStartTime.Name = "btnStartTime";
            this.btnStartTime.Size = new System.Drawing.Size(110, 71);
            this.btnStartTime.TabIndex = 7;
            this.btnStartTime.Text = "Start Time";
            this.btnStartTime.Theme = POS.Control.Theme.MSOffice2010_RED;
            this.btnStartTime.UseVisualStyleBackColor = true;
            this.btnStartTime.Click += new System.EventHandler(this.btnStartTime_Click);
            // 
            // btnPerson
            // 
            this.btnPerson.CommandArg = null;
            this.btnPerson.DataObject = null;
            this.btnPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPerson.Location = new System.Drawing.Point(3, 80);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(110, 71);
            this.btnPerson.TabIndex = 6;
            this.btnPerson.Text = "Update Person";
            this.btnPerson.Theme = POS.Control.Theme.MSOffice2010_Yellow;
            this.btnPerson.UseVisualStyleBackColor = true;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // baseButton6
            // 
            this.baseButton6.CommandArg = null;
            this.baseButton6.DataObject = null;
            this.baseButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.baseButton6.Location = new System.Drawing.Point(3, 543);
            this.baseButton6.Name = "baseButton6";
            this.baseButton6.Size = new System.Drawing.Size(110, 71);
            this.baseButton6.TabIndex = 5;
            this.baseButton6.Text = "Cancel Bill";
            this.baseButton6.Theme = POS.Control.Theme.MSOffice2010_RED;
            this.baseButton6.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.CommandArg = null;
            this.btnDelete.DataObject = null;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDelete.Location = new System.Drawing.Point(3, 466);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 71);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "-";
            this.btnDelete.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.CommandArg = null;
            this.btnAdd.DataObject = null;
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAdd.Location = new System.Drawing.Point(3, 389);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 71);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.CommandArg = null;
            this.btnPrint.DataObject = null;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPrint.Location = new System.Drawing.Point(3, 312);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 71);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print Bill";
            this.btnPrint.Theme = POS.Control.Theme.MSOffice2010_Green;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // baseButton4
            // 
            this.baseButton4.CommandArg = null;
            this.baseButton4.DataObject = null;
            this.baseButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.baseButton4.Location = new System.Drawing.Point(3, 235);
            this.baseButton4.Name = "baseButton4";
            this.baseButton4.Size = new System.Drawing.Size(110, 71);
            this.baseButton4.TabIndex = 1;
            this.baseButton4.Text = "Ticket Note";
            this.baseButton4.Theme = POS.Control.Theme.MSOffice2010_Pink;
            this.baseButton4.UseVisualStyleBackColor = true;
            // 
            // baseButton3
            // 
            this.baseButton3.CommandArg = null;
            this.baseButton3.DataObject = null;
            this.baseButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.baseButton3.Location = new System.Drawing.Point(3, 3);
            this.baseButton3.Name = "baseButton3";
            this.baseButton3.Size = new System.Drawing.Size(110, 71);
            this.baseButton3.TabIndex = 0;
            this.baseButton3.Text = "Change Table";
            this.baseButton3.Theme = POS.Control.Theme.MSOffice2010_BLUE;
            this.baseButton3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Controls.Add(this.labEatingTime);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.labPersonCount);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lbltablrdesc);
            this.panel4.Location = new System.Drawing.Point(121, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(429, 71);
            this.panel4.TabIndex = 9;
            // 
            // labEatingTime
            // 
            this.labEatingTime.AutoSize = true;
            this.labEatingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labEatingTime.ForeColor = System.Drawing.Color.Lime;
            this.labEatingTime.Location = new System.Drawing.Point(343, 6);
            this.labEatingTime.Name = "labEatingTime";
            this.labEatingTime.Size = new System.Drawing.Size(79, 20);
            this.labEatingTime.TabIndex = 7;
            this.labEatingTime.Text = "00:00:00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(252, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Eating time:";
            // 
            // labPersonCount
            // 
            this.labPersonCount.AutoSize = true;
            this.labPersonCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labPersonCount.Location = new System.Drawing.Point(345, 39);
            this.labPersonCount.Name = "labPersonCount";
            this.labPersonCount.Size = new System.Drawing.Size(18, 20);
            this.labPersonCount.TabIndex = 5;
            this.labPersonCount.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(284, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Person:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(69, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "New";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(69, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "10";
            // 
            // lbltablrdesc
            // 
            this.lbltablrdesc.AutoSize = true;
            this.lbltablrdesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbltablrdesc.Location = new System.Drawing.Point(3, 6);
            this.lbltablrdesc.Name = "lbltablrdesc";
            this.lbltablrdesc.Size = new System.Drawing.Size(52, 20);
            this.lbltablrdesc.TabIndex = 0;
            this.lbltablrdesc.Text = "Table:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(128, 660);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Balance:";
            // 
            // labTotalPrice
            // 
            this.labTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.labTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.labTotalPrice.Location = new System.Drawing.Point(215, 660);
            this.labTotalPrice.Name = "labTotalPrice";
            this.labTotalPrice.Size = new System.Drawing.Size(335, 25);
            this.labTotalPrice.TabIndex = 11;
            this.labTotalPrice.Text = "0.00";
            this.labTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fPnlMainMenu
            // 
            this.fPnlMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fPnlMainMenu.AutoScroll = true;
            this.fPnlMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.fPnlMainMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fPnlMainMenu.Location = new System.Drawing.Point(761, 2);
            this.fPnlMainMenu.Name = "fPnlMainMenu";
            this.fPnlMainMenu.Size = new System.Drawing.Size(261, 763);
            this.fPnlMainMenu.TabIndex = 12;
            // 
            // lisMenuOrder
            // 
            this.lisMenuOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lisMenuOrder.FullRowSelect = true;
            this.lisMenuOrder.HideSelection = false;
            this.lisMenuOrder.Location = new System.Drawing.Point(120, 80);
            this.lisMenuOrder.MultiSelect = false;
            this.lisMenuOrder.Name = "lisMenuOrder";
            this.lisMenuOrder.Size = new System.Drawing.Size(430, 577);
            this.lisMenuOrder.TabIndex = 13;
            this.lisMenuOrder.UseCompatibleStateImageBehavior = false;
            this.lisMenuOrder.SelectedIndexChanged += new System.EventHandler(this.lisMenuOrder_SelectedIndexChanged);
            // 
            // fPnlDiningType
            // 
            this.fPnlDiningType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fPnlDiningType.Location = new System.Drawing.Point(556, 3);
            this.fPnlDiningType.Name = "fPnlDiningType";
            this.fPnlDiningType.Size = new System.Drawing.Size(199, 71);
            this.fPnlDiningType.TabIndex = 14;
            // 
            // timeEating
            // 
            this.timeEating.Interval = 1000;
            this.timeEating.Tick += new System.EventHandler(this.timeEating_Tick);
            // 
            // OpenOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.fPnlDiningType);
            this.Controls.Add(this.lisMenuOrder);
            this.Controls.Add(this.fPnlMainMenu);
            this.Controls.Add(this.labTotalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.pnlNumScreen);
            this.Controls.Add(this.baseButton1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.fPnlMenuItem);
            this.Name = "OpenOrder";
            this.Text = "OpenOrder";
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fPnlMenuItem;
        private Control.BaseButton btnClose;
        private Control.BaseButton baseButton1;
        private System.Windows.Forms.Panel pnlNumScreen;
        private Control.BaseTextBox txtCommand;
        private System.Windows.Forms.Panel panel3;
        private Control.BaseButton btnDelete;
        private Control.BaseButton btnAdd;
        private Control.BaseButton btnPrint;
        private Control.BaseButton baseButton3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbltablrdesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labTotalPrice;
        private Control.BaseButton baseButton4;
        private System.Windows.Forms.FlowLayoutPanel fPnlMainMenu;
        private System.Windows.Forms.ListView lisMenuOrder;
        private System.Windows.Forms.FlowLayoutPanel fPnlDiningType;
        private BaseButton baseButton6;
        private BaseButton btnPerson;
        private System.Windows.Forms.Label labPersonCount;
        private System.Windows.Forms.Label label5;
        private BaseButton btnStartTime;
        private System.Windows.Forms.Label labEatingTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timeEating;
    }
}