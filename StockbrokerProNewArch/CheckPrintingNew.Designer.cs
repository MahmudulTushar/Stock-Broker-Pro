namespace StockbrokerProNewArch
{
    partial class CheckPrintingNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.chkACPayee = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ddlAuthor = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlBankName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbBranchEntry = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblwordsMoney = new System.Windows.Forms.Label();
            this.btnAutoSerial = new System.Windows.Forms.Button();
            this.btnGenerateCheckNo = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.printCheck = new System.Drawing.Printing.PrintDocument();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgCheckReceiver = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvExtension = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.lblRecord = new System.Windows.Forms.Label();
            this.pdCheque = new System.Windows.Forms.PrintDialog();
            this.btnprintSetup = new System.Windows.Forms.Button();
            this.pageSetup = new System.Windows.Forms.PageSetupDialog();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbBranchEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCheckReceiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            this.SuspendLayout();
            // 
            // chkACPayee
            // 
            this.chkACPayee.AutoSize = true;
            this.chkACPayee.Checked = true;
            this.chkACPayee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkACPayee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkACPayee.Location = new System.Drawing.Point(185, 22);
            this.chkACPayee.Name = "chkACPayee";
            this.chkACPayee.Size = new System.Drawing.Size(110, 17);
            this.chkACPayee.TabIndex = 1;
            this.chkACPayee.Text = "AC Payee Only";
            this.chkACPayee.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ddlAuthor);
            this.groupBox3.Location = new System.Drawing.Point(323, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 52);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Author";
            // 
            // ddlAuthor
            // 
            this.ddlAuthor.FormattingEnabled = true;
            this.ddlAuthor.Items.AddRange(new object[] {
            "Blank Author",
            "Managing Director",
            "Director"});
            this.ddlAuthor.Location = new System.Drawing.Point(27, 19);
            this.ddlAuthor.Name = "ddlAuthor";
            this.ddlAuthor.Size = new System.Drawing.Size(151, 21);
            this.ddlAuthor.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlBankName);
            this.groupBox1.Controls.Add(this.chkACPayee);
            this.groupBox1.Location = new System.Drawing.Point(11, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Bank";
            // 
            // ddlBankName
            // 
            this.ddlBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBankName.FormattingEnabled = true;
            this.ddlBankName.Items.AddRange(new object[] {
            "The City Bank Ltd.",
            "Rupali Bank Ltd."});
            this.ddlBankName.Location = new System.Drawing.Point(10, 19);
            this.ddlBankName.Name = "ddlBankName";
            this.ddlBankName.Size = new System.Drawing.Size(162, 21);
            this.ddlBankName.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Gray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(25, 143);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label11.Size = new System.Drawing.Size(124, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCheckNo.Location = new System.Drawing.Point(175, 94);
            this.txtCheckNo.MaxLength = 50;
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(178, 20);
            this.txtCheckNo.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(25, 94);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(124, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Cheque No.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(158, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = ":";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtAmount.Location = new System.Drawing.Point(175, 70);
            this.txtAmount.MaxLength = 50;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(178, 20);
            this.txtAmount.TabIndex = 43;
            this.txtAmount.TabStop = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(25, 46);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(124, 20);
            this.label10.TabIndex = 40;
            this.label10.Text = "Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(158, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = ":";
            // 
            // gbBranchEntry
            // 
            this.gbBranchEntry.Controls.Add(this.dtpDate);
            this.gbBranchEntry.Controls.Add(this.lblwordsMoney);
            this.gbBranchEntry.Controls.Add(this.btnAutoSerial);
            this.gbBranchEntry.Controls.Add(this.btnGenerateCheckNo);
            this.gbBranchEntry.Controls.Add(this.label12);
            this.gbBranchEntry.Controls.Add(this.txtVoucherNo);
            this.gbBranchEntry.Controls.Add(this.label13);
            this.gbBranchEntry.Controls.Add(this.label8);
            this.gbBranchEntry.Controls.Add(this.txtCheckNo);
            this.gbBranchEntry.Controls.Add(this.label9);
            this.gbBranchEntry.Controls.Add(this.label6);
            this.gbBranchEntry.Controls.Add(this.txtAmount);
            this.gbBranchEntry.Controls.Add(this.label7);
            this.gbBranchEntry.Controls.Add(this.label3);
            this.gbBranchEntry.Controls.Add(this.label2);
            this.gbBranchEntry.Controls.Add(this.label1);
            this.gbBranchEntry.Controls.Add(this.txtClientCode);
            this.gbBranchEntry.Controls.Add(this.label4);
            this.gbBranchEntry.Controls.Add(this.txtName);
            this.gbBranchEntry.Controls.Add(this.label10);
            this.gbBranchEntry.Controls.Add(this.label11);
            this.gbBranchEntry.Location = new System.Drawing.Point(12, 322);
            this.gbBranchEntry.Name = "gbBranchEntry";
            this.gbBranchEntry.Size = new System.Drawing.Size(508, 175);
            this.gbBranchEntry.TabIndex = 2;
            this.gbBranchEntry.TabStop = false;
            this.gbBranchEntry.Text = "Cheque Info";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(174, 143);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(103, 21);
            this.dtpDate.TabIndex = 54;
            // 
            // lblwordsMoney
            // 
            this.lblwordsMoney.Location = new System.Drawing.Point(283, 143);
            this.lblwordsMoney.Name = "lblwordsMoney";
            this.lblwordsMoney.Size = new System.Drawing.Size(219, 21);
            this.lblwordsMoney.TabIndex = 53;
            this.lblwordsMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblwordsMoney.Click += new System.EventHandler(this.lblwordsMoney_Click);
            // 
            // btnAutoSerial
            // 
            this.btnAutoSerial.Location = new System.Drawing.Point(359, 117);
            this.btnAutoSerial.Name = "btnAutoSerial";
            this.btnAutoSerial.Size = new System.Drawing.Size(70, 23);
            this.btnAutoSerial.TabIndex = 6;
            this.btnAutoSerial.Text = "Generate";
            this.btnAutoSerial.UseVisualStyleBackColor = true;
            this.btnAutoSerial.Click += new System.EventHandler(this.btnAutoSerial_Click);
            // 
            // btnGenerateCheckNo
            // 
            this.btnGenerateCheckNo.Location = new System.Drawing.Point(358, 93);
            this.btnGenerateCheckNo.Name = "btnGenerateCheckNo";
            this.btnGenerateCheckNo.Size = new System.Drawing.Size(71, 23);
            this.btnGenerateCheckNo.TabIndex = 4;
            this.btnGenerateCheckNo.Text = "Increament";
            this.btnGenerateCheckNo.UseVisualStyleBackColor = true;
            this.btnGenerateCheckNo.Click += new System.EventHandler(this.btnGenerateSerial_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(158, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = ":";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtVoucherNo.Location = new System.Drawing.Point(175, 118);
            this.txtVoucherNo.MaxLength = 50;
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(178, 20);
            this.txtVoucherNo.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Gray;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(25, 118);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label13.Size = new System.Drawing.Size(124, 20);
            this.label13.TabIndex = 51;
            this.label13.Text = "Voucher No.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 70);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 45;
            this.label7.Text = "Amount";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(158, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = ":";
            // 
            // txtClientCode
            // 
            this.txtClientCode.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtClientCode.Location = new System.Drawing.Point(175, 22);
            this.txtClientCode.MaxLength = 50;
            this.txtClientCode.Name = "txtClientCode";
            this.txtClientCode.ReadOnly = true;
            this.txtClientCode.Size = new System.Drawing.Size(178, 20);
            this.txtClientCode.TabIndex = 0;
            this.txtClientCode.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 22);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Client Code";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtName.Location = new System.Drawing.Point(175, 46);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(178, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TabStop = false;
            // 
            // printCheck
            // 
            this.printCheck.OriginAtMargins = true;
            this.printCheck.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printCheck_PrintPage);
            this.printCheck.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.printCheck_QueryPageSettings);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chartreuse;
            this.label5.Location = new System.Drawing.Point(9, 3);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(511, 23);
            this.label5.TabIndex = 70;
            this.label5.Text = "All Cheque Receiver List";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgCheckReceiver
            // 
            this.dtgCheckReceiver.AllowUserToAddRows = false;
            this.dtgCheckReceiver.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCheckReceiver.BackgroundColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCheckReceiver.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCheckReceiver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCheckReceiver.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCheckReceiver.Location = new System.Drawing.Point(9, 47);
            this.dtgCheckReceiver.MultiSelect = false;
            this.dtgCheckReceiver.Name = "dtgCheckReceiver";
            this.dtgCheckReceiver.ReadOnly = true;
            this.dtgCheckReceiver.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCheckReceiver.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCheckReceiver.RowHeadersVisible = false;
            this.dtgCheckReceiver.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgCheckReceiver.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCheckReceiver.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCheckReceiver.Size = new System.Drawing.Size(511, 208);
            this.dtgCheckReceiver.TabIndex = 69;
            this.dtgCheckReceiver.SelectionChanged += new System.EventHandler(this.dtgCheckReceiver_SelectionChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(366, 505);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 27);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.Leave += new System.EventHandler(this.btnPrint_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(445, 506);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvExtension
            // 
            this.dgvExtension.DataGridView = this.dtgCheckReceiver;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dgvExtension.FilterFactory = defaultGridFilterFactory1;
            // 
            // lblRecord
            // 
            this.lblRecord.BackColor = System.Drawing.Color.DimGray;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblRecord.Location = new System.Drawing.Point(376, 5);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(144, 20);
            this.lblRecord.TabIndex = 72;
            this.lblRecord.Text = "Total Record : 0";
            this.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pdCheque
            // 
            this.pdCheque.AllowCurrentPage = true;
            this.pdCheque.AllowSomePages = true;
            this.pdCheque.Document = this.printCheck;
            this.pdCheque.UseEXDialog = true;
            // 
            // btnprintSetup
            // 
            this.btnprintSetup.Location = new System.Drawing.Point(12, 503);
            this.btnprintSetup.Name = "btnprintSetup";
            this.btnprintSetup.Size = new System.Drawing.Size(75, 27);
            this.btnprintSetup.TabIndex = 74;
            this.btnprintSetup.Text = "Print Setup";
            this.btnprintSetup.UseVisualStyleBackColor = true;
            this.btnprintSetup.Click += new System.EventHandler(this.btnprintSetup_Click);
            // 
            // pageSetup
            // 
            this.pageSetup.Document = this.printCheck;
            // 
            // CheckPrintingNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 538);
            this.Controls.Add(this.btnprintSetup);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtgCheckReceiver);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbBranchEntry);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CheckPrintingNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printing on Cheque";
            this.Load += new System.EventHandler(this.CheckPrintingNew_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbBranchEntry.ResumeLayout(false);
            this.gbBranchEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCheckReceiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkACPayee;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbBranchEntry;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Drawing.Printing.PrintDocument printCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgCheckReceiver;
        private System.Windows.Forms.ComboBox ddlBankName;
        private System.Windows.Forms.ComboBox ddlAuthor;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerateCheckNo;
        private System.Windows.Forms.Button btnAutoSerial;
        private GridViewExtensions.DataGridFilterExtender dgvExtension;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.PrintDialog pdCheque;
        private System.Windows.Forms.Button btnprintSetup;
        private System.Windows.Forms.PageSetupDialog pageSetup;
        private System.Windows.Forms.Label lblwordsMoney;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}