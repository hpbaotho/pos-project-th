namespace POS.SO
{
    partial class WorkPeriodSetup
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
            POS.Control.Office2010White office2010White3 = new POS.Control.Office2010White();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            POS.Control.Office2010Green office2010Green1 = new POS.Control.Office2010Green();
            POS.Control.Office2010Red office2010Red1 = new POS.Control.Office2010Red();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Search = new System.Windows.Forms.GroupBox();
            this.btnSearch = new POS.Control.BaseButton();
            this.txtClosePeriodBy = new POS.Control.BaseTextBox();
            this.txtPeriodName = new POS.Control.BaseTextBox();
            this.txtOpenPeriodBy = new POS.Control.BaseTextBox();
            this.txtPeriodDesc = new POS.Control.BaseTextBox();
            this.txtPeriodCode = new POS.Control.BaseTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPeriodCode = new System.Windows.Forms.Label();
            this.grdWorkPeriod = new System.Windows.Forms.DataGridView();
            this.period_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.open_period_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.open_period_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.close_period_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.close_period_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStartPeriod = new POS.Control.BaseButton();
            this.btnEndPeriod = new POS.Control.BaseButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.baseTextBox4 = new POS.Control.BaseTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.baseTextBox3 = new POS.Control.BaseTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.baseTextBox2 = new POS.Control.BaseTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.baseTextBox1 = new POS.Control.BaseTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.baseTextBox5 = new POS.Control.BaseTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.baseTextBox6 = new POS.Control.BaseTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkPeriod)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.Search, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdWorkPeriod, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 730);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Search
            // 
            this.Search.Controls.Add(this.btnSearch);
            this.Search.Controls.Add(this.txtClosePeriodBy);
            this.Search.Controls.Add(this.txtPeriodName);
            this.Search.Controls.Add(this.txtOpenPeriodBy);
            this.Search.Controls.Add(this.txtPeriodDesc);
            this.Search.Controls.Add(this.txtPeriodCode);
            this.Search.Controls.Add(this.label4);
            this.Search.Controls.Add(this.label3);
            this.Search.Controls.Add(this.label2);
            this.Search.Controls.Add(this.label1);
            this.Search.Controls.Add(this.lblPeriodCode);
            this.Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Search.Location = new System.Drawing.Point(3, 3);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(750, 188);
            this.Search.TabIndex = 0;
            this.Search.TabStop = false;
            this.Search.Text = "Search";
            // 
            // btnSearch
            // 
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
            this.btnSearch.ColorTable = office2010White3;
            this.btnSearch.CommandArg = null;
            this.btnSearch.Location = new System.Drawing.Point(331, 141);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.Theme = POS.Control.Theme.MSOffice2010_WHITE;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtClosePeriodBy
            // 
            this.txtClosePeriodBy.Location = new System.Drawing.Point(511, 98);
            this.txtClosePeriodBy.Name = "txtClosePeriodBy";
            this.txtClosePeriodBy.Size = new System.Drawing.Size(188, 20);
            this.txtClosePeriodBy.TabIndex = 9;
            // 
            // txtPeriodName
            // 
            this.txtPeriodName.Location = new System.Drawing.Point(511, 33);
            this.txtPeriodName.Name = "txtPeriodName";
            this.txtPeriodName.Size = new System.Drawing.Size(188, 20);
            this.txtPeriodName.TabIndex = 8;
            // 
            // txtOpenPeriodBy
            // 
            this.txtOpenPeriodBy.Location = new System.Drawing.Point(141, 102);
            this.txtOpenPeriodBy.Name = "txtOpenPeriodBy";
            this.txtOpenPeriodBy.Size = new System.Drawing.Size(188, 20);
            this.txtOpenPeriodBy.TabIndex = 7;
            // 
            // txtPeriodDesc
            // 
            this.txtPeriodDesc.Location = new System.Drawing.Point(141, 68);
            this.txtPeriodDesc.Name = "txtPeriodDesc";
            this.txtPeriodDesc.Size = new System.Drawing.Size(188, 20);
            this.txtPeriodDesc.TabIndex = 6;
            // 
            // txtPeriodCode
            // 
            this.txtPeriodCode.Location = new System.Drawing.Point(141, 36);
            this.txtPeriodCode.Name = "txtPeriodCode";
            this.txtPeriodCode.Size = new System.Drawing.Size(188, 20);
            this.txtPeriodCode.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Close Period By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Open Period By";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Period Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Period Desc";
            // 
            // lblPeriodCode
            // 
            this.lblPeriodCode.AutoSize = true;
            this.lblPeriodCode.Location = new System.Drawing.Point(41, 36);
            this.lblPeriodCode.Name = "lblPeriodCode";
            this.lblPeriodCode.Size = new System.Drawing.Size(65, 13);
            this.lblPeriodCode.TabIndex = 0;
            this.lblPeriodCode.Text = "Period Code";
            // 
            // grdWorkPeriod
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkPeriod.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdWorkPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWorkPeriod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.period_code,
            this.period_name,
            this.period_description,
            this.open_period_by,
            this.open_period_date,
            this.close_period_by,
            this.close_period_date});
            this.grdWorkPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkPeriod.Location = new System.Drawing.Point(3, 197);
            this.grdWorkPeriod.Name = "grdWorkPeriod";
            this.grdWorkPeriod.Size = new System.Drawing.Size(750, 530);
            this.grdWorkPeriod.TabIndex = 1;
            // 
            // period_code
            // 
            this.period_code.DataPropertyName = "period_code";
            this.period_code.Frozen = true;
            this.period_code.HeaderText = "Period Code";
            this.period_code.Name = "period_code";
            this.period_code.ReadOnly = true;
            // 
            // period_name
            // 
            this.period_name.DataPropertyName = "period_name";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.period_name.DefaultCellStyle = dataGridViewCellStyle6;
            this.period_name.Frozen = true;
            this.period_name.HeaderText = "Period Name";
            this.period_name.Name = "period_name";
            this.period_name.ReadOnly = true;
            // 
            // period_description
            // 
            this.period_description.DataPropertyName = "period_description";
            this.period_description.HeaderText = "Description";
            this.period_description.Name = "period_description";
            this.period_description.ReadOnly = true;
            // 
            // open_period_by
            // 
            this.open_period_by.DataPropertyName = "open_period_by";
            this.open_period_by.HeaderText = "Open By";
            this.open_period_by.Name = "open_period_by";
            this.open_period_by.ReadOnly = true;
            // 
            // open_period_date
            // 
            this.open_period_date.DataPropertyName = "open_period_date";
            this.open_period_date.HeaderText = "Open Date";
            this.open_period_date.Name = "open_period_date";
            this.open_period_date.ReadOnly = true;
            // 
            // close_period_by
            // 
            this.close_period_by.DataPropertyName = "close_period_by";
            this.close_period_by.HeaderText = "Close By";
            this.close_period_by.Name = "close_period_by";
            this.close_period_by.ReadOnly = true;
            // 
            // close_period_date
            // 
            this.close_period_date.DataPropertyName = "close_period_date";
            this.close_period_date.HeaderText = "Close Date";
            this.close_period_date.Name = "close_period_date";
            this.close_period_date.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnStartPeriod);
            this.flowLayoutPanel1.Controls.Add(this.btnEndPeriod);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(759, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(246, 188);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnStartPeriod
            // 
            office2010Green1.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(72)))), ((int)(((byte)(161)))));
            office2010Green1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(135)))), ((int)(((byte)(228)))));
            office2010Green1.ButtonMouseOverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010Green1.ButtonMouseOverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010Green1.ButtonMouseOverColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(225)))), ((int)(((byte)(137)))));
            office2010Green1.ButtonMouseOverColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(224)))));
            office2010Green1.ButtonNormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(126)))), ((int)(((byte)(43)))));
            office2010Green1.ButtonNormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(184)))), ((int)(((byte)(67)))));
            office2010Green1.ButtonNormalColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(126)))), ((int)(((byte)(43)))));
            office2010Green1.ButtonNormalColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(184)))), ((int)(((byte)(67)))));
            office2010Green1.ButtonSelectedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010Green1.ButtonSelectedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010Green1.ButtonSelectedColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(117)))));
            office2010Green1.ButtonSelectedColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            office2010Green1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010Green1.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010Green1.TextColor = System.Drawing.Color.White;
            this.btnStartPeriod.ColorTable = office2010Green1;
            this.btnStartPeriod.CommandArg = null;
            this.btnStartPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStartPeriod.Location = new System.Drawing.Point(3, 5);
            this.btnStartPeriod.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.btnStartPeriod.Name = "btnStartPeriod";
            this.btnStartPeriod.Size = new System.Drawing.Size(243, 82);
            this.btnStartPeriod.TabIndex = 2;
            this.btnStartPeriod.Text = "Start Work Period";
            this.btnStartPeriod.Theme = POS.Control.Theme.MSOffice2010_Green;
            this.btnStartPeriod.UseVisualStyleBackColor = true;
            // 
            // btnEndPeriod
            // 
            office2010Red1.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(72)))), ((int)(((byte)(161)))));
            office2010Red1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(135)))), ((int)(((byte)(228)))));
            office2010Red1.ButtonMouseOverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010Red1.ButtonMouseOverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010Red1.ButtonMouseOverColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(225)))), ((int)(((byte)(137)))));
            office2010Red1.ButtonMouseOverColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(224)))));
            office2010Red1.ButtonNormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            office2010Red1.ButtonNormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(148)))), ((int)(((byte)(64)))));
            office2010Red1.ButtonNormalColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(77)))), ((int)(((byte)(45)))));
            office2010Red1.ButtonNormalColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(148)))), ((int)(((byte)(64)))));
            office2010Red1.ButtonSelectedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010Red1.ButtonSelectedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010Red1.ButtonSelectedColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(117)))));
            office2010Red1.ButtonSelectedColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            office2010Red1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010Red1.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010Red1.TextColor = System.Drawing.Color.White;
            this.btnEndPeriod.ColorTable = office2010Red1;
            this.btnEndPeriod.CommandArg = null;
            this.btnEndPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEndPeriod.Location = new System.Drawing.Point(3, 105);
            this.btnEndPeriod.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.btnEndPeriod.Name = "btnEndPeriod";
            this.btnEndPeriod.Size = new System.Drawing.Size(243, 82);
            this.btnEndPeriod.TabIndex = 3;
            this.btnEndPeriod.Text = "End Work Period";
            this.btnEndPeriod.Theme = POS.Control.Theme.MSOffice2010_RED;
            this.btnEndPeriod.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.baseTextBox6);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.baseTextBox5);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.baseTextBox4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.baseTextBox3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.baseTextBox2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.baseTextBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(759, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 530);
            this.panel1.TabIndex = 4;
            // 
            // baseTextBox4
            // 
            this.baseTextBox4.Location = new System.Drawing.Point(99, 162);
            this.baseTextBox4.Name = "baseTextBox4";
            this.baseTextBox4.Size = new System.Drawing.Size(141, 20);
            this.baseTextBox4.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Period Name";
            // 
            // baseTextBox3
            // 
            this.baseTextBox3.Location = new System.Drawing.Point(99, 130);
            this.baseTextBox3.Name = "baseTextBox3";
            this.baseTextBox3.Size = new System.Drawing.Size(141, 20);
            this.baseTextBox3.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Period Code";
            // 
            // baseTextBox2
            // 
            this.baseTextBox2.Location = new System.Drawing.Point(3, 83);
            this.baseTextBox2.Name = "baseTextBox2";
            this.baseTextBox2.Size = new System.Drawing.Size(130, 20);
            this.baseTextBox2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Time of Work Period";
            // 
            // baseTextBox1
            // 
            this.baseTextBox1.Location = new System.Drawing.Point(3, 27);
            this.baseTextBox1.Name = "baseTextBox1";
            this.baseTextBox1.Size = new System.Drawing.Size(130, 20);
            this.baseTextBox1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date of Work Period";
            // 
            // baseTextBox5
            // 
            this.baseTextBox5.Location = new System.Drawing.Point(99, 195);
            this.baseTextBox5.Name = "baseTextBox5";
            this.baseTextBox5.Size = new System.Drawing.Size(141, 20);
            this.baseTextBox5.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Open Period By";
            // 
            // baseTextBox6
            // 
            this.baseTextBox6.Location = new System.Drawing.Point(99, 226);
            this.baseTextBox6.Name = "baseTextBox6";
            this.baseTextBox6.Size = new System.Drawing.Size(141, 20);
            this.baseTextBox6.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Open Period Date";
            // 
            // WorkPeriodSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WorkPeriodSetup";
            this.Text = "WorkPeriod";
            this.Shown += new System.EventHandler(this.btnSearch_Click);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Search.ResumeLayout(false);
            this.Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkPeriod)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox Search;
        private System.Windows.Forms.Label lblPeriodCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Control.BaseButton btnSearch;
        private Control.BaseTextBox txtClosePeriodBy;
        private Control.BaseTextBox txtPeriodName;
        private Control.BaseTextBox txtOpenPeriodBy;
        private Control.BaseTextBox txtPeriodDesc;
        private Control.BaseTextBox txtPeriodCode;
        private System.Windows.Forms.DataGridView grdWorkPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn period_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn period_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn period_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn open_period_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn open_period_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn close_period_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn close_period_date;
        private Control.BaseButton btnStartPeriod;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Control.BaseButton btnEndPeriod;
        private System.Windows.Forms.Panel panel1;
        private Control.BaseTextBox baseTextBox4;
        private System.Windows.Forms.Label label8;
        private Control.BaseTextBox baseTextBox3;
        private System.Windows.Forms.Label label7;
        private Control.BaseTextBox baseTextBox2;
        private System.Windows.Forms.Label label6;
        private Control.BaseTextBox baseTextBox1;
        private System.Windows.Forms.Label label5;
        private Control.BaseTextBox baseTextBox6;
        private System.Windows.Forms.Label label10;
        private Control.BaseTextBox baseTextBox5;
        private System.Windows.Forms.Label label9;
    }
}