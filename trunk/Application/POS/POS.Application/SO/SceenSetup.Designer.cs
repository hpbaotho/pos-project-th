namespace POS.SO
{
    partial class SceenSetup
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
            POS.BL.DTO.SO.CustromControlPropertyDTO custromControlPropertyDTO1 = new POS.BL.DTO.SO.CustromControlPropertyDTO();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.spComtrolCommand = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlScreen = new System.Windows.Forms.ComboBox();
            this.txtTableName = new POS.Control.BaseTextBox();
            this.ddlControlType = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.cmdForm = new System.Windows.Forms.ComboBox();
            this.dragContainer2 = new POS.Control.DragContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewScreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spComtrolCommand)).BeginInit();
            this.spComtrolCommand.Panel1.SuspendLayout();
            this.spComtrolCommand.Panel2.SuspendLayout();
            this.spComtrolCommand.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("Arial", 14F);
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Arial", 14F);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Arial", 14F);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 536);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 14F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(251, 534);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.spComtrolCommand);
            this.tabPage1.Font = new System.Drawing.Font("Arial", 14F);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(243, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Events";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // spComtrolCommand
            // 
            this.spComtrolCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spComtrolCommand.Font = new System.Drawing.Font("Arial", 14F);
            this.spComtrolCommand.Location = new System.Drawing.Point(3, 3);
            this.spComtrolCommand.Name = "spComtrolCommand";
            // 
            // spComtrolCommand.Panel1
            // 
            this.spComtrolCommand.Panel1.Controls.Add(this.label6);
            this.spComtrolCommand.Panel1.Controls.Add(this.label5);
            this.spComtrolCommand.Panel1.Controls.Add(this.label1);
            this.spComtrolCommand.Panel1.Font = new System.Drawing.Font("Arial", 14F);
            // 
            // spComtrolCommand.Panel2
            // 
            this.spComtrolCommand.Panel2.Controls.Add(this.ddlScreen);
            this.spComtrolCommand.Panel2.Controls.Add(this.txtTableName);
            this.spComtrolCommand.Panel2.Controls.Add(this.ddlControlType);
            this.spComtrolCommand.Panel2.Font = new System.Drawing.Font("Arial", 14F);
            this.spComtrolCommand.Size = new System.Drawing.Size(237, 493);
            this.spComtrolCommand.SplitterDistance = 82;
            this.spComtrolCommand.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Arial", 14F);
            this.label6.Location = new System.Drawing.Point(0, 58);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label6.Size = new System.Drawing.Size(114, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Next Screen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Arial", 14F);
            this.label5.Location = new System.Drawing.Point(0, 29);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label5.Size = new System.Drawing.Size(106, 29);
            this.label5.TabIndex = 1;
            this.label5.Text = "TableName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(118, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control Type";
            // 
            // ddlScreen
            // 
            this.ddlScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.ddlScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlScreen.Font = new System.Drawing.Font("Arial", 14F);
            this.ddlScreen.FormattingEnabled = true;
            this.ddlScreen.Items.AddRange(new object[] {
            "Button",
            "Table",
            "Object"});
            this.ddlScreen.Location = new System.Drawing.Point(0, 59);
            this.ddlScreen.Name = "ddlScreen";
            this.ddlScreen.Size = new System.Drawing.Size(151, 30);
            this.ddlScreen.TabIndex = 2;
            this.ddlScreen.SelectedIndexChanged += new System.EventHandler(this.ddlScreen_SelectedIndexChanged);
            // 
            // txtTableName
            // 
            this.txtTableName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTableName.Enabled = false;
            this.txtTableName.Location = new System.Drawing.Point(0, 30);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(151, 29);
            this.txtTableName.TabIndex = 1;
            this.txtTableName.TextChanged += new System.EventHandler(this.txtTableName_TextChanged);
            // 
            // ddlControlType
            // 
            this.ddlControlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.ddlControlType.Font = new System.Drawing.Font("Arial", 14F);
            this.ddlControlType.FormattingEnabled = true;
            this.ddlControlType.Items.AddRange(new object[] {
            "Button",
            "Table",
            "Object"});
            this.ddlControlType.Location = new System.Drawing.Point(0, 0);
            this.ddlControlType.Name = "ddlControlType";
            this.ddlControlType.Size = new System.Drawing.Size(151, 30);
            this.ddlControlType.TabIndex = 0;
            this.ddlControlType.SelectedIndexChanged += new System.EventHandler(this.ddlControlType_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.propertyGrid1);
            this.tabPage2.Font = new System.Drawing.Font("Arial", 14F);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(243, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Properties";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Font = new System.Drawing.Font("Arial", 14F);
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(237, 493);
            this.propertyGrid1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Font = new System.Drawing.Font("Arial", 14F);
            this.splitContainer2.Location = new System.Drawing.Point(0, 25);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.txtHeight);
            this.splitContainer2.Panel1.Controls.Add(this.txtWidth);
            this.splitContainer2.Panel1.Controls.Add(this.cmdForm);
            this.splitContainer2.Panel1.Font = new System.Drawing.Font("Arial", 14F);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.dragContainer2);
            this.splitContainer2.Panel2.Font = new System.Drawing.Font("Arial", 14F);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer2.Size = new System.Drawing.Size(745, 511);
            this.splitContainer2.SplitterDistance = 73;
            this.splitContainer2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F);
            this.label4.Location = new System.Drawing.Point(8, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Select From";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F);
            this.label3.Location = new System.Drawing.Point(564, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Height";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F);
            this.label2.Location = new System.Drawing.Point(567, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Width";
            // 
            // txtHeight
            // 
            this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeight.Font = new System.Drawing.Font("Arial", 14F);
            this.txtHeight.Location = new System.Drawing.Point(629, 35);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 29);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWidth.Font = new System.Drawing.Font("Arial", 14F);
            this.txtWidth.Location = new System.Drawing.Point(629, 9);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 29);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // cmdForm
            // 
            this.cmdForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdForm.Font = new System.Drawing.Font("Arial", 14F);
            this.cmdForm.FormattingEnabled = true;
            this.cmdForm.Location = new System.Drawing.Point(128, 9);
            this.cmdForm.Name = "cmdForm";
            this.cmdForm.Size = new System.Drawing.Size(250, 30);
            this.cmdForm.TabIndex = 0;
            this.cmdForm.SelectedIndexChanged += new System.EventHandler(this.cmdForm_SelectedIndexChanged);
            // 
            // dragContainer2
            // 
            custromControlPropertyDTO1.control_code = null;
            custromControlPropertyDTO1.control_id = null;
            custromControlPropertyDTO1.control_parent_id = null;
            custromControlPropertyDTO1.control_type = null;
            custromControlPropertyDTO1.ControlState = null;
            custromControlPropertyDTO1.NextScreen = null;
            custromControlPropertyDTO1.TableName = null;
            this.dragContainer2.ControlCommand = custromControlPropertyDTO1;
            this.dragContainer2.Font = new System.Drawing.Font("Arial", 14F);
            this.dragContainer2.Location = new System.Drawing.Point(3, 3);
            this.dragContainer2.Name = "dragContainer2";
            this.dragContainer2.Size = new System.Drawing.Size(410, 359);
            this.dragContainer2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 14F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewScreen,
            this.toolStripSeparator2,
            this.btnAdd,
            this.btnDelete,
            this.btnCopy,
            this.btnSave,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewScreen
            // 
            this.btnNewScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewScreen.Image = global::POS.Properties.Resources.New_document;
            this.btnNewScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewScreen.Name = "btnNewScreen";
            this.btnNewScreen.Size = new System.Drawing.Size(23, 22);
            this.btnNewScreen.Text = "toolStripButton1";
            this.btnNewScreen.ToolTipText = "Ctrl + N";
            this.btnNewScreen.Click += new System.EventHandler(this.btnNewScreen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::POS.Properties.Resources.Add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "toolStripButton1";
            this.btnAdd.ToolTipText = "Ctrl + A";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::POS.Properties.Resources.Delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "toolStripButton1";
            this.btnDelete.ToolTipText = "Press Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_ButtonClick);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = global::POS.Properties.Resources.Copy;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 22);
            this.btnCopy.Text = "toolStripButton1";
            this.btnCopy.ToolTipText = "Ctrl + D";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::POS.Properties.Resources.Save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton2";
            this.btnSave.ToolTipText = "Ctrl + S";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // SceenSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1000, 536);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SceenSetup";
            this.Text = "SceenSetup";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.spComtrolCommand.Panel1.ResumeLayout(false);
            this.spComtrolCommand.Panel1.PerformLayout();
            this.spComtrolCommand.Panel2.ResumeLayout(false);
            this.spComtrolCommand.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spComtrolCommand)).EndInit();
            this.spComtrolCommand.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.DragContainer dragContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.SplitContainer spComtrolCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlControlType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.ComboBox cmdForm;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnNewScreen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label5;
        private Control.BaseTextBox txtTableName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlScreen;
    }
}