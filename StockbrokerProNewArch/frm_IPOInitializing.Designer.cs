﻿namespace StockbrokerProNewArch
{
    partial class frm_IPOInitializing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_IPOInitializing));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.IPOCompany = new System.Windows.Forms.TabPage();
            this.txtDesignationName = new System.Windows.Forms.TextBox();
            this.txtCompanyChairmentName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmb_RoutingNo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_ShortCode = new System.Windows.Forms.TextBox();
            this.txt_Company_ID = new System.Windows.Forms.TextBox();
            this.cmb_BranchName = new System.Windows.Forms.ComboBox();
            this.cmb_BankName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pb_Company_Logo = new System.Windows.Forms.PictureBox();
            this.txt_Bank_Acc_No = new System.Windows.Forms.TextBox();
            this.txt_Company_Address = new System.Windows.Forms.TextBox();
            this.txt_Company_Name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Branch_Name = new System.Windows.Forms.Label();
            this.lbl_Bank_Name = new System.Windows.Forms.Label();
            this.lbl_Company_Address = new System.Windows.Forms.Label();
            this.lbl_Company_Name = new System.Windows.Forms.Label();
            this.IPOSession = new System.Windows.Forms.TabPage();
            this.btnCurrencyAdd = new System.Windows.Forms.Button();
            this.CmbCurrencyName = new System.Windows.Forms.ComboBox();
            this.Dg_Currency = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cur_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurrencyAmount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbSessionName = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_TotalAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Premium = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_ApplicaitonType = new System.Windows.Forms.ComboBox();
            this.txt_Session_ID = new System.Windows.Forms.TextBox();
            this.dtp_Session_Date = new System.Windows.Forms.DateTimePicker();
            this.cmb_IPO_Company = new System.Windows.Forms.ComboBox();
            this.txt_ShareTotalAmount = new System.Windows.Forms.TextBox();
            this.txt_ShareAmount = new System.Windows.Forms.TextBox();
            this.txt_NoOfShare = new System.Windows.Forms.TextBox();
            this.txt_Session_Description = new System.Windows.Forms.TextBox();
            this.txt_Session_Name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveBranch = new System.Windows.Forms.Button();
            this.dgv_CommonGrid = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.dtp_Session_End_Date = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.IPOCompany.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Company_Logo)).BeginInit();
            this.IPOSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg_Currency)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CommonGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.IPOCompany);
            this.tabControl1.Controls.Add(this.IPOSession);
            this.tabControl1.Location = new System.Drawing.Point(4, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(558, 334);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // IPOCompany
            // 
            this.IPOCompany.Controls.Add(this.txtDesignationName);
            this.IPOCompany.Controls.Add(this.txtCompanyChairmentName);
            this.IPOCompany.Controls.Add(this.label15);
            this.IPOCompany.Controls.Add(this.label14);
            this.IPOCompany.Controls.Add(this.cmb_RoutingNo);
            this.IPOCompany.Controls.Add(this.label10);
            this.IPOCompany.Controls.Add(this.txt_ShortCode);
            this.IPOCompany.Controls.Add(this.txt_Company_ID);
            this.IPOCompany.Controls.Add(this.cmb_BranchName);
            this.IPOCompany.Controls.Add(this.cmb_BankName);
            this.IPOCompany.Controls.Add(this.groupBox1);
            this.IPOCompany.Controls.Add(this.txt_Bank_Acc_No);
            this.IPOCompany.Controls.Add(this.txt_Company_Address);
            this.IPOCompany.Controls.Add(this.txt_Company_Name);
            this.IPOCompany.Controls.Add(this.label6);
            this.IPOCompany.Controls.Add(this.label5);
            this.IPOCompany.Controls.Add(this.lbl_Branch_Name);
            this.IPOCompany.Controls.Add(this.lbl_Bank_Name);
            this.IPOCompany.Controls.Add(this.lbl_Company_Address);
            this.IPOCompany.Controls.Add(this.lbl_Company_Name);
            this.IPOCompany.Location = new System.Drawing.Point(4, 22);
            this.IPOCompany.Name = "IPOCompany";
            this.IPOCompany.Padding = new System.Windows.Forms.Padding(3);
            this.IPOCompany.Size = new System.Drawing.Size(550, 308);
            this.IPOCompany.TabIndex = 0;
            this.IPOCompany.Text = "IPO Company";
            this.IPOCompany.UseVisualStyleBackColor = true;
            // 
            // txtDesignationName
            // 
            this.txtDesignationName.Location = new System.Drawing.Point(111, 47);
            this.txtDesignationName.Name = "txtDesignationName";
            this.txtDesignationName.Size = new System.Drawing.Size(257, 20);
            this.txtDesignationName.TabIndex = 25;
            // 
            // txtCompanyChairmentName
            // 
            this.txtCompanyChairmentName.Location = new System.Drawing.Point(111, 17);
            this.txtCompanyChairmentName.Name = "txtCompanyChairmentName";
            this.txtCompanyChairmentName.Size = new System.Drawing.Size(257, 20);
            this.txtCompanyChairmentName.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(41, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Designation";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Director Name";
            // 
            // cmb_RoutingNo
            // 
            this.cmb_RoutingNo.FormattingEnabled = true;
            this.cmb_RoutingNo.Location = new System.Drawing.Point(110, 221);
            this.cmb_RoutingNo.Name = "cmb_RoutingNo";
            this.cmb_RoutingNo.Size = new System.Drawing.Size(100, 21);
            this.cmb_RoutingNo.TabIndex = 21;
            this.cmb_RoutingNo.SelectedIndexChanged += new System.EventHandler(this.cmb_RoutingNo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Short Code";
            // 
            // txt_ShortCode
            // 
            this.txt_ShortCode.Location = new System.Drawing.Point(110, 276);
            this.txt_ShortCode.Name = "txt_ShortCode";
            this.txt_ShortCode.Size = new System.Drawing.Size(100, 20);
            this.txt_ShortCode.TabIndex = 19;
            // 
            // txt_Company_ID
            // 
            this.txt_Company_ID.Location = new System.Drawing.Point(3, 3);
            this.txt_Company_ID.Name = "txt_Company_ID";
            this.txt_Company_ID.Size = new System.Drawing.Size(22, 20);
            this.txt_Company_ID.TabIndex = 17;
            this.txt_Company_ID.Visible = false;
            // 
            // cmb_BranchName
            // 
            this.cmb_BranchName.Enabled = false;
            this.cmb_BranchName.FormattingEnabled = true;
            this.cmb_BranchName.Location = new System.Drawing.Point(111, 192);
            this.cmb_BranchName.Name = "cmb_BranchName";
            this.cmb_BranchName.Size = new System.Drawing.Size(257, 21);
            this.cmb_BranchName.TabIndex = 16;
            // 
            // cmb_BankName
            // 
            this.cmb_BankName.Enabled = false;
            this.cmb_BankName.FormattingEnabled = true;
            this.cmb_BankName.Location = new System.Drawing.Point(111, 164);
            this.cmb_BankName.Name = "cmb_BankName";
            this.cmb_BankName.Size = new System.Drawing.Size(257, 21);
            this.cmb_BankName.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pb_Company_Logo);
            this.groupBox1.Location = new System.Drawing.Point(374, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 266);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company Logo";
            // 
            // pb_Company_Logo
            // 
            this.pb_Company_Logo.Location = new System.Drawing.Point(6, 19);
            this.pb_Company_Logo.Name = "pb_Company_Logo";
            this.pb_Company_Logo.Size = new System.Drawing.Size(158, 126);
            this.pb_Company_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Company_Logo.TabIndex = 13;
            this.pb_Company_Logo.TabStop = false;
            // 
            // txt_Bank_Acc_No
            // 
            this.txt_Bank_Acc_No.Location = new System.Drawing.Point(110, 249);
            this.txt_Bank_Acc_No.Name = "txt_Bank_Acc_No";
            this.txt_Bank_Acc_No.Size = new System.Drawing.Size(100, 20);
            this.txt_Bank_Acc_No.TabIndex = 12;
            // 
            // txt_Company_Address
            // 
            this.txt_Company_Address.Location = new System.Drawing.Point(110, 107);
            this.txt_Company_Address.Multiline = true;
            this.txt_Company_Address.Name = "txt_Company_Address";
            this.txt_Company_Address.Size = new System.Drawing.Size(258, 49);
            this.txt_Company_Address.TabIndex = 8;
            // 
            // txt_Company_Name
            // 
            this.txt_Company_Name.Location = new System.Drawing.Point(110, 78);
            this.txt_Company_Name.Name = "txt_Company_Name";
            this.txt_Company_Name.Size = new System.Drawing.Size(173, 20);
            this.txt_Company_Name.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Routing No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bank Account No";
            // 
            // lbl_Branch_Name
            // 
            this.lbl_Branch_Name.AutoSize = true;
            this.lbl_Branch_Name.Location = new System.Drawing.Point(32, 195);
            this.lbl_Branch_Name.Name = "lbl_Branch_Name";
            this.lbl_Branch_Name.Size = new System.Drawing.Size(72, 13);
            this.lbl_Branch_Name.TabIndex = 3;
            this.lbl_Branch_Name.Text = "Branch Name";
            // 
            // lbl_Bank_Name
            // 
            this.lbl_Bank_Name.AutoSize = true;
            this.lbl_Bank_Name.Location = new System.Drawing.Point(41, 167);
            this.lbl_Bank_Name.Name = "lbl_Bank_Name";
            this.lbl_Bank_Name.Size = new System.Drawing.Size(63, 13);
            this.lbl_Bank_Name.TabIndex = 2;
            this.lbl_Bank_Name.Text = "Bank Name";
            // 
            // lbl_Company_Address
            // 
            this.lbl_Company_Address.AutoSize = true;
            this.lbl_Company_Address.Location = new System.Drawing.Point(12, 110);
            this.lbl_Company_Address.Name = "lbl_Company_Address";
            this.lbl_Company_Address.Size = new System.Drawing.Size(92, 13);
            this.lbl_Company_Address.TabIndex = 1;
            this.lbl_Company_Address.Text = "Company Address";
            // 
            // lbl_Company_Name
            // 
            this.lbl_Company_Name.AutoSize = true;
            this.lbl_Company_Name.Location = new System.Drawing.Point(22, 81);
            this.lbl_Company_Name.Name = "lbl_Company_Name";
            this.lbl_Company_Name.Size = new System.Drawing.Size(82, 13);
            this.lbl_Company_Name.TabIndex = 0;
            this.lbl_Company_Name.Text = "Company Name";
            // 
            // IPOSession
            // 
            this.IPOSession.Controls.Add(this.btnCurrencyAdd);
            this.IPOSession.Controls.Add(this.CmbCurrencyName);
            this.IPOSession.Controls.Add(this.Dg_Currency);
            this.IPOSession.Controls.Add(this.txtCurrencyAmount);
            this.IPOSession.Controls.Add(this.label16);
            this.IPOSession.Controls.Add(this.cmbSessionName);
            this.IPOSession.Controls.Add(this.label13);
            this.IPOSession.Controls.Add(this.txt_TotalAmount);
            this.IPOSession.Controls.Add(this.label12);
            this.IPOSession.Controls.Add(this.txt_Premium);
            this.IPOSession.Controls.Add(this.label11);
            this.IPOSession.Controls.Add(this.cmb_ApplicaitonType);
            this.IPOSession.Controls.Add(this.txt_Session_ID);
            this.IPOSession.Controls.Add(this.dtp_Session_End_Date);
            this.IPOSession.Controls.Add(this.dtp_Session_Date);
            this.IPOSession.Controls.Add(this.cmb_IPO_Company);
            this.IPOSession.Controls.Add(this.txt_ShareTotalAmount);
            this.IPOSession.Controls.Add(this.txt_ShareAmount);
            this.IPOSession.Controls.Add(this.txt_NoOfShare);
            this.IPOSession.Controls.Add(this.txt_Session_Description);
            this.IPOSession.Controls.Add(this.txt_Session_Name);
            this.IPOSession.Controls.Add(this.label9);
            this.IPOSession.Controls.Add(this.label8);
            this.IPOSession.Controls.Add(this.label17);
            this.IPOSession.Controls.Add(this.label7);
            this.IPOSession.Controls.Add(this.label4);
            this.IPOSession.Controls.Add(this.label3);
            this.IPOSession.Controls.Add(this.label2);
            this.IPOSession.Controls.Add(this.label1);
            this.IPOSession.Location = new System.Drawing.Point(4, 22);
            this.IPOSession.Name = "IPOSession";
            this.IPOSession.Padding = new System.Windows.Forms.Padding(3);
            this.IPOSession.Size = new System.Drawing.Size(550, 308);
            this.IPOSession.TabIndex = 1;
            this.IPOSession.Text = "IPO Session";
            this.IPOSession.UseVisualStyleBackColor = true;
            // 
            // btnCurrencyAdd
            // 
            this.btnCurrencyAdd.Location = new System.Drawing.Point(493, 156);
            this.btnCurrencyAdd.Name = "btnCurrencyAdd";
            this.btnCurrencyAdd.Size = new System.Drawing.Size(37, 23);
            this.btnCurrencyAdd.TabIndex = 27;
            this.btnCurrencyAdd.Text = "Add";
            this.btnCurrencyAdd.UseVisualStyleBackColor = true;
            this.btnCurrencyAdd.Click += new System.EventHandler(this.btnCurrencyAdd_Click);
            // 
            // CmbCurrencyName
            // 
            this.CmbCurrencyName.FormattingEnabled = true;
            this.CmbCurrencyName.Location = new System.Drawing.Point(338, 133);
            this.CmbCurrencyName.Name = "CmbCurrencyName";
            this.CmbCurrencyName.Size = new System.Drawing.Size(69, 21);
            this.CmbCurrencyName.TabIndex = 26;
            // 
            // Dg_Currency
            // 
            this.Dg_Currency.AllowUserToAddRows = false;
            this.Dg_Currency.AllowUserToDeleteRows = false;
            this.Dg_Currency.AllowUserToOrderColumns = true;
            this.Dg_Currency.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Dg_Currency.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Dg_Currency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dg_Currency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Cur_Name,
            this.Amount});
            this.Dg_Currency.Location = new System.Drawing.Point(338, 156);
            this.Dg_Currency.Name = "Dg_Currency";
            this.Dg_Currency.RowHeadersVisible = false;
            this.Dg_Currency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dg_Currency.Size = new System.Drawing.Size(149, 88);
            this.Dg_Currency.TabIndex = 25;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 20;
            // 
            // Cur_Name
            // 
            this.Cur_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cur_Name.HeaderText = "Cur_Name";
            this.Cur_Name.Name = "Cur_Name";
            this.Cur_Name.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 68;
            // 
            // txtCurrencyAmount
            // 
            this.txtCurrencyAmount.Location = new System.Drawing.Point(413, 133);
            this.txtCurrencyAmount.Name = "txtCurrencyAmount";
            this.txtCurrencyAmount.Size = new System.Drawing.Size(74, 20);
            this.txtCurrencyAmount.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(282, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Currency";
            // 
            // cmbSessionName
            // 
            this.cmbSessionName.FormattingEnabled = true;
            this.cmbSessionName.Location = new System.Drawing.Point(143, 9);
            this.cmbSessionName.Name = "cmbSessionName";
            this.cmbSessionName.Size = new System.Drawing.Size(121, 21);
            this.cmbSessionName.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(312, 281);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Total Amount";
            // 
            // txt_TotalAmount
            // 
            this.txt_TotalAmount.Location = new System.Drawing.Point(387, 278);
            this.txt_TotalAmount.Name = "txt_TotalAmount";
            this.txt_TotalAmount.ReadOnly = true;
            this.txt_TotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txt_TotalAmount.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(335, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Premium";
            // 
            // txt_Premium
            // 
            this.txt_Premium.Location = new System.Drawing.Point(387, 250);
            this.txt_Premium.Name = "txt_Premium";
            this.txt_Premium.Size = new System.Drawing.Size(100, 20);
            this.txt_Premium.TabIndex = 18;
            this.txt_Premium.TextChanged += new System.EventHandler(this.txt_Premium_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Application Type";
            // 
            // cmb_ApplicaitonType
            // 
            this.cmb_ApplicaitonType.FormattingEnabled = true;
            this.cmb_ApplicaitonType.Location = new System.Drawing.Point(143, 194);
            this.cmb_ApplicaitonType.Name = "cmb_ApplicaitonType";
            this.cmb_ApplicaitonType.Size = new System.Drawing.Size(121, 21);
            this.cmb_ApplicaitonType.TabIndex = 15;
            // 
            // txt_Session_ID
            // 
            this.txt_Session_ID.Location = new System.Drawing.Point(7, 13);
            this.txt_Session_ID.Name = "txt_Session_ID";
            this.txt_Session_ID.Size = new System.Drawing.Size(26, 20);
            this.txt_Session_ID.TabIndex = 14;
            this.txt_Session_ID.Visible = false;
            // 
            // dtp_Session_Date
            // 
            this.dtp_Session_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Session_Date.Location = new System.Drawing.Point(143, 135);
            this.dtp_Session_Date.Name = "dtp_Session_Date";
            this.dtp_Session_Date.Size = new System.Drawing.Size(121, 20);
            this.dtp_Session_Date.TabIndex = 13;
            // 
            // cmb_IPO_Company
            // 
            this.cmb_IPO_Company.FormattingEnabled = true;
            this.cmb_IPO_Company.Location = new System.Drawing.Point(143, 105);
            this.cmb_IPO_Company.Name = "cmb_IPO_Company";
            this.cmb_IPO_Company.Size = new System.Drawing.Size(294, 21);
            this.cmb_IPO_Company.TabIndex = 12;
            // 
            // txt_ShareTotalAmount
            // 
            this.txt_ShareTotalAmount.Location = new System.Drawing.Point(143, 278);
            this.txt_ShareTotalAmount.Name = "txt_ShareTotalAmount";
            this.txt_ShareTotalAmount.ReadOnly = true;
            this.txt_ShareTotalAmount.Size = new System.Drawing.Size(121, 20);
            this.txt_ShareTotalAmount.TabIndex = 11;
            // 
            // txt_ShareAmount
            // 
            this.txt_ShareAmount.Location = new System.Drawing.Point(143, 250);
            this.txt_ShareAmount.Name = "txt_ShareAmount";
            this.txt_ShareAmount.Size = new System.Drawing.Size(121, 20);
            this.txt_ShareAmount.TabIndex = 10;
            this.txt_ShareAmount.TextChanged += new System.EventHandler(this.txt_ShareAmount_TextChanged);
            // 
            // txt_NoOfShare
            // 
            this.txt_NoOfShare.Location = new System.Drawing.Point(143, 223);
            this.txt_NoOfShare.Name = "txt_NoOfShare";
            this.txt_NoOfShare.Size = new System.Drawing.Size(121, 20);
            this.txt_NoOfShare.TabIndex = 9;
            this.txt_NoOfShare.TextChanged += new System.EventHandler(this.txt_NoOfShare_TextChanged);
            // 
            // txt_Session_Description
            // 
            this.txt_Session_Description.Location = new System.Drawing.Point(143, 63);
            this.txt_Session_Description.Multiline = true;
            this.txt_Session_Description.Name = "txt_Session_Description";
            this.txt_Session_Description.Size = new System.Drawing.Size(294, 34);
            this.txt_Session_Description.TabIndex = 8;
            // 
            // txt_Session_Name
            // 
            this.txt_Session_Name.Location = new System.Drawing.Point(143, 35);
            this.txt_Session_Name.Name = "txt_Session_Name";
            this.txt_Session_Name.Size = new System.Drawing.Size(294, 20);
            this.txt_Session_Name.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Total Share Value (Tk.)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Each Sare Value(Tk.)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "No Of Share";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Session Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "IPO Company ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Session Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSaveBranch);
            this.panel1.Location = new System.Drawing.Point(4, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(186, 9);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnUpdate.Size = new System.Drawing.Size(90, 25);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Enabled = false;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(90, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnNew.Size = new System.Drawing.Size(90, 25);
            this.btnNew.TabIndex = 6;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(378, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveBranch
            // 
            this.btnSaveBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBranch.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSaveBranch.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveBranch.Image")));
            this.btnSaveBranch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveBranch.Location = new System.Drawing.Point(282, 9);
            this.btnSaveBranch.Name = "btnSaveBranch";
            this.btnSaveBranch.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSaveBranch.Size = new System.Drawing.Size(90, 25);
            this.btnSaveBranch.TabIndex = 4;
            this.btnSaveBranch.TabStop = false;
            this.btnSaveBranch.Text = "Save";
            this.btnSaveBranch.UseVisualStyleBackColor = true;
            this.btnSaveBranch.Click += new System.EventHandler(this.btnSaveBranch_Click);
            // 
            // dgv_CommonGrid
            // 
            this.dgv_CommonGrid.AllowUserToAddRows = false;
            this.dgv_CommonGrid.AllowUserToDeleteRows = false;
            this.dgv_CommonGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CommonGrid.Location = new System.Drawing.Point(4, 415);
            this.dgv_CommonGrid.Name = "dgv_CommonGrid";
            this.dgv_CommonGrid.ReadOnly = true;
            this.dgv_CommonGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CommonGrid.Size = new System.Drawing.Size(558, 192);
            this.dgv_CommonGrid.TabIndex = 2;
            this.dgv_CommonGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CommonGrid_CellClick);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDelete.Image = global::StockbrokerProNewArch.Properties.Resources.Close_2_icon;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(421, 613);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(141, 25);
            this.btnDelete.TabIndex = 83;
            this.btnDelete.Text = "Delete IPO Session";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 169);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Session End Date";
            // 
            // dtp_Session_End_Date
            // 
            this.dtp_Session_End_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Session_End_Date.Location = new System.Drawing.Point(143, 166);
            this.dtp_Session_End_Date.Name = "dtp_Session_End_Date";
            this.dtp_Session_End_Date.Size = new System.Drawing.Size(121, 20);
            this.dtp_Session_End_Date.TabIndex = 13;
            // 
            // frm_IPOInitializing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 641);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgv_CommonGrid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frm_IPOInitializing";
            this.Text = "IPO Initialization";
            this.Load += new System.EventHandler(this.frmIPOInitializing_Load);
            this.tabControl1.ResumeLayout(false);
            this.IPOCompany.ResumeLayout(false);
            this.IPOCompany.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Company_Logo)).EndInit();
            this.IPOSession.ResumeLayout(false);
            this.IPOSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg_Currency)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CommonGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage IPOCompany;
        private System.Windows.Forms.TabPage IPOSession;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveBranch;
        private System.Windows.Forms.DataGridView dgv_CommonGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Branch_Name;
        private System.Windows.Forms.Label lbl_Bank_Name;
        private System.Windows.Forms.Label lbl_Company_Address;
        private System.Windows.Forms.Label lbl_Company_Name;
        private System.Windows.Forms.TextBox txt_Bank_Acc_No;
        private System.Windows.Forms.TextBox txt_Company_Address;
        private System.Windows.Forms.TextBox txt_Company_Name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pb_Company_Logo;
        private System.Windows.Forms.ComboBox cmb_BranchName;
        private System.Windows.Forms.ComboBox cmb_BankName;
        private System.Windows.Forms.DateTimePicker dtp_Session_Date;
        private System.Windows.Forms.ComboBox cmb_IPO_Company;
        private System.Windows.Forms.TextBox txt_ShareTotalAmount;
        private System.Windows.Forms.TextBox txt_ShareAmount;
        private System.Windows.Forms.TextBox txt_NoOfShare;
        private System.Windows.Forms.TextBox txt_Session_Description;
        private System.Windows.Forms.TextBox txt_Session_Name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Session_ID;
        private System.Windows.Forms.TextBox txt_Company_ID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_ShortCode;
        private System.Windows.Forms.ComboBox cmb_ApplicaitonType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_RoutingNo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Premium;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_TotalAmount;
        private System.Windows.Forms.ComboBox cmbSessionName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDesignationName;
        private System.Windows.Forms.TextBox txtCompanyChairmentName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView Dg_Currency;
        private System.Windows.Forms.TextBox txtCurrencyAmount;
        private System.Windows.Forms.Button btnCurrencyAdd;
        private System.Windows.Forms.ComboBox CmbCurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cur_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DateTimePicker dtp_Session_End_Date;
        private System.Windows.Forms.Label label17;
    }
}