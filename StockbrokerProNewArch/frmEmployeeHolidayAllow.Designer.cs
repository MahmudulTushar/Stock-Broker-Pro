namespace StockbrokerProNewArch
{
    partial class frmEmployeeHolidayAllow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeHolidayAllow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblEmployeeCode = new System.Windows.Forms.Label();
            this.ddlHolidayType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudLeave = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRestHoliday = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalHoilDay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvEmployeeHoliday = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTakenHoliday = new System.Windows.Forms.TextBox();
            this.btnApprovedLeave = new System.Windows.Forms.Button();
            this.btndetails = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeave)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeHoliday)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblEmployeeName);
            this.panel1.Controls.Add(this.lblEmployeeCode);
            this.panel1.Controls.Add(this.ddlHolidayType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 41);
            this.panel1.TabIndex = 1;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEmployeeName.Location = new System.Drawing.Point(117, 13);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(41, 13);
            this.lblEmployeeName.TabIndex = 5;
            this.lblEmployeeName.Text = "label10";
            // 
            // lblEmployeeCode
            // 
            this.lblEmployeeCode.AutoSize = true;
            this.lblEmployeeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeCode.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEmployeeCode.Location = new System.Drawing.Point(3, 13);
            this.lblEmployeeCode.Name = "lblEmployeeCode";
            this.lblEmployeeCode.Size = new System.Drawing.Size(41, 13);
            this.lblEmployeeCode.TabIndex = 4;
            this.lblEmployeeCode.Text = "label10";
            // 
            // ddlHolidayType
            // 
            this.ddlHolidayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlHolidayType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlHolidayType.FormattingEnabled = true;
            this.ddlHolidayType.Items.AddRange(new object[] {
            "Annual Leave",
            "Sick Leave",
            "Maternity Policy",
            "Paternity Policy"});
            this.ddlHolidayType.Location = new System.Drawing.Point(395, 10);
            this.ddlHolidayType.Name = "ddlHolidayType";
            this.ddlHolidayType.Size = new System.Drawing.Size(110, 21);
            this.ddlHolidayType.TabIndex = 2;
            this.ddlHolidayType.SelectedIndexChanged += new System.EventHandler(this.ddlHolidayType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(305, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Leave Catagory :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MM-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(121, 61);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(114, 20);
            this.dtpStartDate.TabIndex = 2;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(22, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Leave From  :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.txtReason);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nudLeave);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 197);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Holiday Information";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRefresh.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnRefresh.Location = new System.Drawing.Point(194, 168);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(62, 23);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Reset";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(117, 87);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(152, 35);
            this.txtReason.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(22, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 36);
            this.label4.TabIndex = 16;
            this.label4.Text = "Reason       :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudLeave
            // 
            this.nudLeave.Location = new System.Drawing.Point(117, 35);
            this.nudLeave.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLeave.Name = "nudLeave";
            this.nudLeave.Size = new System.Drawing.Size(56, 20);
            this.nudLeave.TabIndex = 15;
            this.nudLeave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLeave.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(188, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "[ Day ]";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(117, 127);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(152, 35);
            this.txtRemarks.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(22, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 36);
            this.label2.TabIndex = 10;
            this.label2.Text = "Remarks     :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Days           :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.ForeColor = System.Drawing.Color.ForestGreen;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(128, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRestHoliday
            // 
            this.txtRestHoliday.BackColor = System.Drawing.Color.AliceBlue;
            this.txtRestHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestHoliday.ForeColor = System.Drawing.Color.DarkRed;
            this.txtRestHoliday.Location = new System.Drawing.Point(36, 138);
            this.txtRestHoliday.Name = "txtRestHoliday";
            this.txtRestHoliday.ReadOnly = true;
            this.txtRestHoliday.Size = new System.Drawing.Size(132, 20);
            this.txtRestHoliday.TabIndex = 6;
            this.txtRestHoliday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(36, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "+ Remaining  Leave";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(36, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "= Total Leave";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalHoilDay
            // 
            this.txtTotalHoilDay.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTotalHoilDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHoilDay.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTotalHoilDay.Location = new System.Drawing.Point(36, 43);
            this.txtTotalHoilDay.Name = "txtTotalHoilDay";
            this.txtTotalHoilDay.ReadOnly = true;
            this.txtTotalHoilDay.Size = new System.Drawing.Size(132, 20);
            this.txtTotalHoilDay.TabIndex = 2;
            this.txtTotalHoilDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(36, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "+ Taken Leave";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvEmployeeHoliday);
            this.groupBox3.Location = new System.Drawing.Point(12, 269);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 140);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Highlight Information";
            // 
            // dgvEmployeeHoliday
            // 
            this.dgvEmployeeHoliday.AllowUserToAddRows = false;
            this.dgvEmployeeHoliday.AllowUserToDeleteRows = false;
            this.dgvEmployeeHoliday.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.dgvEmployeeHoliday.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployeeHoliday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployeeHoliday.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployeeHoliday.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmployeeHoliday.ColumnHeadersHeight = 32;
            this.dgvEmployeeHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployeeHoliday.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEmployeeHoliday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployeeHoliday.EnableHeadersVisualStyles = false;
            this.dgvEmployeeHoliday.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvEmployeeHoliday.Location = new System.Drawing.Point(3, 16);
            this.dgvEmployeeHoliday.MultiSelect = false;
            this.dgvEmployeeHoliday.Name = "dgvEmployeeHoliday";
            this.dgvEmployeeHoliday.ReadOnly = true;
            this.dgvEmployeeHoliday.RowHeadersVisible = false;
            this.dgvEmployeeHoliday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeHoliday.Size = new System.Drawing.Size(509, 121);
            this.dgvEmployeeHoliday.TabIndex = 0;
            this.dgvEmployeeHoliday.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployeeHoliday_CellMouseDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.Location = new System.Drawing.Point(392, 412);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Location = new System.Drawing.Point(468, 412);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTakenHoliday);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtRestHoliday);
            this.groupBox1.Controls.Add(this.txtTotalHoilDay);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(325, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 167);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary Information";
            // 
            // txtTakenHoliday
            // 
            this.txtTakenHoliday.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTakenHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTakenHoliday.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTakenHoliday.Location = new System.Drawing.Point(36, 91);
            this.txtTakenHoliday.Name = "txtTakenHoliday";
            this.txtTakenHoliday.Size = new System.Drawing.Size(132, 20);
            this.txtTakenHoliday.TabIndex = 7;
            this.txtTakenHoliday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnApprovedLeave
            // 
            this.btnApprovedLeave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnApprovedLeave.Location = new System.Drawing.Point(290, 412);
            this.btnApprovedLeave.Name = "btnApprovedLeave";
            this.btnApprovedLeave.Size = new System.Drawing.Size(99, 23);
            this.btnApprovedLeave.TabIndex = 7;
            this.btnApprovedLeave.Text = "Previous Leaves";
            this.btnApprovedLeave.UseVisualStyleBackColor = false;
            this.btnApprovedLeave.Click += new System.EventHandler(this.btnApprovedLeave_Click);
            // 
            // btndetails
            // 
            this.btndetails.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btndetails.ForeColor = System.Drawing.Color.DarkCyan;
            this.btndetails.Location = new System.Drawing.Point(211, 412);
            this.btndetails.Name = "btndetails";
            this.btndetails.Size = new System.Drawing.Size(75, 23);
            this.btndetails.TabIndex = 8;
            this.btndetails.Text = "Details";
            this.btndetails.UseVisualStyleBackColor = false;
            this.btndetails.Click += new System.EventHandler(this.btndetails_Click);
            // 
            // frmEmployeeHolidayAllow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 439);
            this.Controls.Add(this.btndetails);
            this.Controls.Add(this.btnApprovedLeave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEmployeeHolidayAllow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeeHolidayAllow";
            this.Load += new System.EventHandler(this.frmEmployeeHolidayAllow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeave)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeHoliday)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlHolidayType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRestHoliday;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalHoilDay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvEmployeeHoliday;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtTakenHoliday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudLeave;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnApprovedLeave;
        private System.Windows.Forms.Button btndetails;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblEmployeeCode;
    }
}