﻿namespace StockbrokerProNewArch
{
    partial class frm_IPO_Single_ApplicationProcess
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
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.btnImageVerify = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Process = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Cust_Code_ForReturnTransferParent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_RefundType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_CompanyName = new System.Windows.Forms.ComboBox();
            this.dgv_FinalCheck = new System.Windows.Forms.DataGridView();
            this.F_CustCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.App_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_CustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_ApplyMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvExtension = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.ChkAffectedAccount = new System.Windows.Forms.CheckBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtlotNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSaveDetails = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_ChannelType = new System.Windows.Forms.TextBox();
            this.txt_ChannelID = new System.Windows.Forms.TextBox();
            this.BtnSmsApplication = new System.Windows.Forms.Button();
            this.chkVoucher = new System.Windows.Forms.CheckBox();
            this.chkremarks = new System.Windows.Forms.CheckBox();
            this.txtsingelApplicationRemarks = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtsingleSerailno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FinalCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImageVerify
            // 
            this.btnImageVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImageVerify.ForeColor = System.Drawing.Color.Navy;
            this.btnImageVerify.Location = new System.Drawing.Point(59, 8);
            this.btnImageVerify.Name = "btnImageVerify";
            this.btnImageVerify.Size = new System.Drawing.Size(83, 23);
            this.btnImageVerify.TabIndex = 36;
            this.btnImageVerify.Text = "Verify";
            this.btnImageVerify.UseVisualStyleBackColor = true;
            this.btnImageVerify.Click += new System.EventHandler(this.btnImageVerify_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.Navy;
            this.btnVerify.Location = new System.Drawing.Point(156, 8);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(83, 23);
            this.btnVerify.TabIndex = 35;
            this.btnVerify.Text = "Report";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btn_Delete);
            this.panel2.Controls.Add(this.btnVerify);
            this.panel2.Controls.Add(this.btnImageVerify);
            this.panel2.Controls.Add(this.btn_Process);
            this.panel2.Controls.Add(this.btn_Close);
            this.panel2.Location = new System.Drawing.Point(11, 601);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 36);
            this.panel2.TabIndex = 25;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Navy;
            this.btnReset.Location = new System.Drawing.Point(445, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(83, 23);
            this.btnReset.TabIndex = 42;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.Navy;
            this.btn_Delete.Location = new System.Drawing.Point(251, 8);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(83, 23);
            this.btn_Delete.TabIndex = 41;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Process
            // 
            this.btn_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Process.ForeColor = System.Drawing.Color.Navy;
            this.btn_Process.Location = new System.Drawing.Point(348, 8);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(83, 23);
            this.btn_Process.TabIndex = 40;
            this.btn_Process.TabStop = false;
            this.btn_Process.Text = "Process";
            this.btn_Process.UseVisualStyleBackColor = true;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Navy;
            this.btn_Close.Location = new System.Drawing.Point(542, 8);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(83, 23);
            this.btn_Close.TabIndex = 39;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 84);
            this.panel3.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Cust_Code_ForReturnTransferParent);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmb_RefundType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmb_CompanyName);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 74);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initial Information";
            // 
            // txt_Cust_Code_ForReturnTransferParent
            // 
            this.txt_Cust_Code_ForReturnTransferParent.Location = new System.Drawing.Point(506, 40);
            this.txt_Cust_Code_ForReturnTransferParent.Name = "txt_Cust_Code_ForReturnTransferParent";
            this.txt_Cust_Code_ForReturnTransferParent.Size = new System.Drawing.Size(114, 20);
            this.txt_Cust_Code_ForReturnTransferParent.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Code :";
            // 
            // cmb_RefundType
            // 
            this.cmb_RefundType.FormattingEnabled = true;
            this.cmb_RefundType.Location = new System.Drawing.Point(412, 13);
            this.cmb_RefundType.Name = "cmb_RefundType";
            this.cmb_RefundType.Size = new System.Drawing.Size(208, 21);
            this.cmb_RefundType.TabIndex = 34;
            this.cmb_RefundType.SelectedIndexChanged += new System.EventHandler(this.cmb_RefundType_SelectedIndexChanged);
            this.cmb_RefundType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_RefundType_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Refund Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Company Name";
            // 
            // cmb_CompanyName
            // 
            this.cmb_CompanyName.FormattingEnabled = true;
            this.cmb_CompanyName.Location = new System.Drawing.Point(113, 13);
            this.cmb_CompanyName.Name = "cmb_CompanyName";
            this.cmb_CompanyName.Size = new System.Drawing.Size(208, 21);
            this.cmb_CompanyName.TabIndex = 31;
            this.cmb_CompanyName.SelectedIndexChanged += new System.EventHandler(this.cmb_CompanyName_SelectedIndexChanged_1);
            this.cmb_CompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_CompanyName_KeyDown);
            // 
            // dgv_FinalCheck
            // 
            this.dgv_FinalCheck.AllowUserToAddRows = false;
            this.dgv_FinalCheck.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FinalCheck.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_FinalCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_FinalCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F_CustCode,
            this.App_ID,
            this.Serial_NO,
            this.Remarks,
            this.F_CustName,
            this.F_Balance,
            this.F_ApplyMoney,
            this.ChannelID,
            this.ChannelType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_FinalCheck.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_FinalCheck.Location = new System.Drawing.Point(3, 236);
            this.dgv_FinalCheck.Name = "dgv_FinalCheck";
            this.dgv_FinalCheck.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_FinalCheck.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_FinalCheck.RowHeadersVisible = false;
            this.dgv_FinalCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_FinalCheck.Size = new System.Drawing.Size(700, 359);
            this.dgv_FinalCheck.TabIndex = 27;
            this.dgv_FinalCheck.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFinalCheck_CellClick);
            // 
            // F_CustCode
            // 
            this.F_CustCode.DataPropertyName = "Cust_Code";
            this.F_CustCode.HeaderText = "Code";
            this.F_CustCode.Name = "F_CustCode";
            this.F_CustCode.ReadOnly = true;
            this.F_CustCode.Width = 50;
            // 
            // App_ID
            // 
            this.App_ID.DataPropertyName = "ApplicationID";
            this.App_ID.HeaderText = "App ID";
            this.App_ID.Name = "App_ID";
            this.App_ID.ReadOnly = true;
            // 
            // Serial_NO
            // 
            this.Serial_NO.DataPropertyName = "Serial_No";
            this.Serial_NO.HeaderText = "Serial NO";
            this.Serial_NO.Name = "Serial_NO";
            this.Serial_NO.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // F_CustName
            // 
            this.F_CustName.DataPropertyName = "Cust_Name";
            this.F_CustName.HeaderText = "Name";
            this.F_CustName.Name = "F_CustName";
            this.F_CustName.ReadOnly = true;
            this.F_CustName.Width = 150;
            // 
            // F_Balance
            // 
            this.F_Balance.DataPropertyName = "Balance";
            this.F_Balance.HeaderText = "Balance";
            this.F_Balance.Name = "F_Balance";
            this.F_Balance.ReadOnly = true;
            this.F_Balance.Width = 80;
            // 
            // F_ApplyMoney
            // 
            this.F_ApplyMoney.DataPropertyName = "ApplyMoney";
            this.F_ApplyMoney.HeaderText = "Apply Money";
            this.F_ApplyMoney.Name = "F_ApplyMoney";
            this.F_ApplyMoney.ReadOnly = true;
            // 
            // ChannelID
            // 
            this.ChannelID.DataPropertyName = "ChannelID";
            this.ChannelID.HeaderText = "ChannelID";
            this.ChannelID.Name = "ChannelID";
            this.ChannelID.ReadOnly = true;
            // 
            // ChannelType
            // 
            this.ChannelType.DataPropertyName = "ChannelType";
            this.ChannelType.HeaderText = "ChannelType";
            this.ChannelType.Name = "ChannelType";
            this.ChannelType.ReadOnly = true;
            // 
            // dgvExtension
            // 
            this.dgvExtension.DataGridView = null;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dgvExtension.FilterFactory = defaultGridFilterFactory1;
            this.dgvExtension.FilterTextVisible = false;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgv_FinalCheck;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory2;
            this.dataGridFilterExtender1.FilterTextVisible = false;
            // 
            // ChkAffectedAccount
            // 
            this.ChkAffectedAccount.AutoSize = true;
            this.ChkAffectedAccount.Enabled = false;
            this.ChkAffectedAccount.Location = new System.Drawing.Point(398, 7);
            this.ChkAffectedAccount.Name = "ChkAffectedAccount";
            this.ChkAffectedAccount.Size = new System.Drawing.Size(123, 17);
            this.ChkAffectedAccount.TabIndex = 44;
            this.ChkAffectedAccount.Text = "Is Affected Account ";
            this.ChkAffectedAccount.UseVisualStyleBackColor = true;
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(256, 6);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(79, 20);
            this.txtCustCode.TabIndex = 43;
            this.txtCustCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustCode_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(191, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Cust Code";
            // 
            // txtlotNo
            // 
            this.txtlotNo.Location = new System.Drawing.Point(492, 27);
            this.txtlotNo.Name = "txtlotNo";
            this.txtlotNo.Size = new System.Drawing.Size(17, 20);
            this.txtlotNo.TabIndex = 41;
            this.txtlotNo.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(445, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Lot No";
            // 
            // btnSaveDetails
            // 
            this.btnSaveDetails.Location = new System.Drawing.Point(440, 77);
            this.btnSaveDetails.Name = "btnSaveDetails";
            this.btnSaveDetails.Size = new System.Drawing.Size(83, 23);
            this.btnSaveDetails.TabIndex = 39;
            this.btnSaveDetails.Text = "Save";
            this.btnSaveDetails.UseVisualStyleBackColor = true;
            this.btnSaveDetails.Click += new System.EventHandler(this.btnEligibleClient_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Controls.Add(this.txt_ChannelType);
            this.panel4.Controls.Add(this.txt_ChannelID);
            this.panel4.Controls.Add(this.BtnSmsApplication);
            this.panel4.Controls.Add(this.chkVoucher);
            this.panel4.Controls.Add(this.chkremarks);
            this.panel4.Controls.Add(this.txtsingelApplicationRemarks);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txtsingleSerailno);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtCustCode);
            this.panel4.Controls.Add(this.ChkAffectedAccount);
            this.panel4.Controls.Add(this.btnSaveDetails);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtlotNo);
            this.panel4.Location = new System.Drawing.Point(3, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(700, 115);
            this.panel4.TabIndex = 45;
            // 
            // txt_ChannelType
            // 
            this.txt_ChannelType.Location = new System.Drawing.Point(574, 10);
            this.txt_ChannelType.Name = "txt_ChannelType";
            this.txt_ChannelType.Size = new System.Drawing.Size(14, 20);
            this.txt_ChannelType.TabIndex = 53;
            this.txt_ChannelType.Visible = false;
            // 
            // txt_ChannelID
            // 
            this.txt_ChannelID.Location = new System.Drawing.Point(554, 10);
            this.txt_ChannelID.Name = "txt_ChannelID";
            this.txt_ChannelID.Size = new System.Drawing.Size(14, 20);
            this.txt_ChannelID.TabIndex = 52;
            this.txt_ChannelID.Visible = false;
            // 
            // BtnSmsApplication
            // 
            this.BtnSmsApplication.Location = new System.Drawing.Point(8, 7);
            this.BtnSmsApplication.Name = "BtnSmsApplication";
            this.BtnSmsApplication.Size = new System.Drawing.Size(95, 23);
            this.BtnSmsApplication.TabIndex = 51;
            this.BtnSmsApplication.Text = "Sms Application";
            this.BtnSmsApplication.UseVisualStyleBackColor = true;
            this.BtnSmsApplication.Click += new System.EventHandler(this.BtnSmsApplication_Click);
            // 
            // chkVoucher
            // 
            this.chkVoucher.AutoSize = true;
            this.chkVoucher.Location = new System.Drawing.Point(169, 33);
            this.chkVoucher.Name = "chkVoucher";
            this.chkVoucher.Size = new System.Drawing.Size(15, 14);
            this.chkVoucher.TabIndex = 50;
            this.chkVoucher.UseVisualStyleBackColor = true;
            // 
            // chkremarks
            // 
            this.chkremarks.AutoSize = true;
            this.chkremarks.Location = new System.Drawing.Point(186, 59);
            this.chkremarks.Name = "chkremarks";
            this.chkremarks.Size = new System.Drawing.Size(15, 14);
            this.chkremarks.TabIndex = 49;
            this.chkremarks.UseVisualStyleBackColor = true;
            // 
            // txtsingelApplicationRemarks
            // 
            this.txtsingelApplicationRemarks.Location = new System.Drawing.Point(256, 56);
            this.txtsingelApplicationRemarks.Multiline = true;
            this.txtsingelApplicationRemarks.Name = "txtsingelApplicationRemarks";
            this.txtsingelApplicationRemarks.Size = new System.Drawing.Size(164, 44);
            this.txtsingelApplicationRemarks.TabIndex = 48;
            this.txtsingelApplicationRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(198, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Remarks";
            // 
            // txtsingleSerailno
            // 
            this.txtsingleSerailno.Location = new System.Drawing.Point(256, 30);
            this.txtsingleSerailno.Name = "txtsingleSerailno";
            this.txtsingleSerailno.Size = new System.Drawing.Size(164, 20);
            this.txtsingleSerailno.TabIndex = 46;
            this.txtsingleSerailno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsingleSerailno_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(183, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Voucher No";
            // 
            // frm_IPO_Single_ApplicationProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 642);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_FinalCheck);
            this.Name = "frm_IPO_Single_ApplicationProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPO Single Application Process";
            this.Load += new System.EventHandler(this.IpoApplicationProcess_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_FinalCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_FinalCheck;
        private GridViewExtensions.DataGridFilterExtender dgvExtension;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnImageVerify;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Cust_Code_ForReturnTransferParent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_RefundType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_CompanyName;
        private System.Windows.Forms.CheckBox ChkAffectedAccount;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtlotNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSaveDetails;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtsingleSerailno;
        private System.Windows.Forms.TextBox txtsingelApplicationRemarks;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkVoucher;
        private System.Windows.Forms.CheckBox chkremarks;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button BtnSmsApplication;
        private System.Windows.Forms.TextBox txt_ChannelType;
        private System.Windows.Forms.TextBox txt_ChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_CustCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn App_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_CustName;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_ApplyMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelType;
    }
}