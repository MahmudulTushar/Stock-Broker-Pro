﻿namespace StockbrokerProNewArch
{
    partial class frm_IPOPaymentForm
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
            PaymentForm_Cache = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_IPOPaymentForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.gbPaymentInfo = new System.Windows.Forms.GroupBox();
            this.pnlEFT_Deposit = new System.Windows.Forms.Panel();
            this.ddl_DepositEft_RoutingNo = new System.Windows.Forms.ComboBox();
            this.ddl_DepositEft_Branch_Name = new System.Windows.Forms.ComboBox();
            this.ddl_DepositEft_Bank_Name = new System.Windows.Forms.ComboBox();
            this.btnEftCheckDepositAutogen = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txt_DepositEft_BankAccountNo = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txt_DepositEft_VoucherNo = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.panelChequeDeposit = new System.Windows.Forms.Panel();
            this.ddl_DepositCheque_RoutingNo = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.ddl_DepositCheque_BranchName = new System.Windows.Forms.ComboBox();
            this.ddl_DepositCheque_BankName = new System.Windows.Forms.ComboBox();
            this.txt_DepositCheque_VoucherNo = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.dtp_DepositChequeDate = new System.Windows.Forms.DateTimePicker();
            this.txtDepositChequeNo = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.panelEFT = new System.Windows.Forms.Panel();
            this.txtEFTBranchID = new System.Windows.Forms.TextBox();
            this.txtEFTBankID = new System.Windows.Forms.TextBox();
            this.btneftAutoVoucher = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txt_EftWithdraw_BankAccNo = new System.Windows.Forms.TextBox();
            this.txt_EftWithdraw_RoutingNo = new System.Windows.Forms.TextBox();
            this.txt_EftWithdraw_BankName = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txt_EftWithdraw_VoucherNo = new System.Windows.Forms.TextBox();
            this.txt_EftWithdraw_BranchName = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.panelPaymentTransfer = new System.Windows.Forms.Panel();
            this.txtAvailableWithdrawBalance = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.txtAccruedBalance = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.btnAutoGen = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSearchTrans = new System.Windows.Forms.Button();
            this.txt_Transfer_CustCode = new System.Windows.Forms.TextBox();
            this.txt_Transfer_CustName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_Transfer_VoucherNo = new System.Windows.Forms.TextBox();
            this.txt_Transfer_Balance = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panelPaymentInfo = new System.Windows.Forms.Panel();
            this.txt_Paypal_VoucherNo = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_Paypal_BranchName = new System.Windows.Forms.TextBox();
            this.txt_Paypal_BankName = new System.Windows.Forms.TextBox();
            this.dtp_Paypal_OrderDate = new System.Windows.Forms.DateTimePicker();
            this.txt_Paypal_OrderNo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ChannelType = new System.Windows.Forms.TextBox();
            this.txt_ChannelID = new System.Windows.Forms.TextBox();
            this.btnSms = new System.Windows.Forms.Button();
            this.btnWebData = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.ddlSearchCustomer = new System.Windows.Forms.ComboBox();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRecievedBy = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtRecievedDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnEftReturn = new System.Windows.Forms.Button();
            this.btn_Cancel_TransChrgTaken = new System.Windows.Forms.Button();
            this.txt_RequiredTranCharge = new System.Windows.Forms.TextBox();
            this.LabelCount = new System.Windows.Forms.Label();
            this.txt_CustCodeHidden = new System.Windows.Forms.TextBox();
            this.txt_MinBalance = new System.Windows.Forms.TextBox();
            this.txt_Distributed_Amount = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDWReturnInfo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ddlDepositWithdraw = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkMatureToday = new System.Windows.Forms.CheckBox();
            this.ddlPaymentMedia = new System.Windows.Forms.ComboBox();
            this.dgvPaymentInfo = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpSearchPaymentEntry = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssTotalRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDepositCancel = new System.Windows.Forms.Button();
            this.dgvExtension = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.dg_Customers = new System.Windows.Forms.DataGridView();
            this.IsChargable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cust_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPO_Mone_Bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distributed_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteFlag = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BankAccNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoutingNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk_AppliedTogather = new System.Windows.Forms.CheckBox();
            this.gp_AvailableSession = new System.Windows.Forms.GroupBox();
            this.dg_AvailableSession = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Company_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_Of_Share = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Premium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gp_RefundMothod = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Cust_Code_ForTransferParent = new System.Windows.Forms.TextBox();
            this.dg_RefundBankInfo = new System.Windows.Forms.DataGridView();
            this.cmb_RefundMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_ApplicationStatus = new System.Windows.Forms.DataGridView();
            this.P_Cust_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Applied_Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefundType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.App_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridFilterExtender1 = new GridViewExtensions.DataGridFilterExtender(this.components);
            this.BtnVerification = new System.Windows.Forms.Button();
            this.btnpublicReport = new System.Windows.Forms.Button();
            this.ChkAffected = new System.Windows.Forms.CheckBox();
            this.txtLotNO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelTransactionCharge = new System.Windows.Forms.Panel();
            this.txt_TransChrg_TransFromCode = new System.Windows.Forms.TextBox();
            this.txt_TransChrg_PaymentMediaName = new System.Windows.Forms.TextBox();
            this.txt_TransChrg_PaymentMediaID = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txt_TransChrg_TransReason = new System.Windows.Forms.TextBox();
            this.txt_TransChrg_Remarks = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txt_TransChrg_RefNo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_TransChrg_ChargedCustCode = new System.Windows.Forms.TextBox();
            this.txt_TransChrg_VoucherNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_TranChrg_ChagedAmount = new System.Windows.Forms.TextBox();
            this.dtp_TransChrg_ReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.chk_TransChrg_IsApplied = new System.Windows.Forms.CheckBox();
            this.lbl_dgvPaymentInfo = new System.Windows.Forms.Label();
            this.lbl_dgvApp = new System.Windows.Forms.Label();
            this.dgvEFTbankInfo = new System.Windows.Forms.DataGridView();
            this.dgPanerlEft = new System.Windows.Forms.Panel();
            this.label49 = new System.Windows.Forms.Label();
            this.btnAutoGenForEFT = new System.Windows.Forms.Button();
            this.txtAutoGen = new System.Windows.Forms.TextBox();
            this.pnlwithdraw = new System.Windows.Forms.Panel();
            this.label50 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgWithdrawGrid = new System.Windows.Forms.DataGridView();
            this.panelIPOApplicationCharge = new System.Windows.Forms.Panel();
            this.chk_AppCharge_IsApplied = new System.Windows.Forms.CheckBox();
            this.txt_AppCharge_PaymentMediaName = new System.Windows.Forms.TextBox();
            this.txt_AppCharge_PaymentMediaID = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txt_AppCharge_TransReason = new System.Windows.Forms.TextBox();
            this.txt_AppCharge_Remarks = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.txt_AppCharge_ReferenceNo = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.txt_AppCharge_TransFrom = new System.Windows.Forms.TextBox();
            this.txt_AppCharge_VoucherNo = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.txt_AppCharge_Amount = new System.Windows.Forms.TextBox();
            this.dtp_AppCharge_ReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.ChkNegativeBalanceNotCalculate = new System.Windows.Forms.CheckBox();
            this.pnlEFT_Deposit.SuspendLayout();
            this.panelChequeDeposit.SuspendLayout();
            this.panelEFT.SuspendLayout();
            this.panelPaymentTransfer.SuspendLayout();
            this.panelPaymentInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Customers)).BeginInit();
            this.gp_AvailableSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_AvailableSession)).BeginInit();
            this.gp_RefundMothod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_RefundBankInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ApplicationStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).BeginInit();
            this.panelTransactionCharge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEFTbankInfo)).BeginInit();
            this.dgPanerlEft.SuspendLayout();
            this.pnlwithdraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWithdrawGrid)).BeginInit();
            this.panelIPOApplicationCharge.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPaymentInfo
            // 
            this.gbPaymentInfo.Location = new System.Drawing.Point(12, 286);
            this.gbPaymentInfo.Name = "gbPaymentInfo";
            this.gbPaymentInfo.Size = new System.Drawing.Size(337, 175);
            this.gbPaymentInfo.TabIndex = 2;
            this.gbPaymentInfo.TabStop = false;
            this.gbPaymentInfo.Text = "Payment Info";
            // 
            // pnlEFT_Deposit
            // 
            this.pnlEFT_Deposit.Controls.Add(this.ddl_DepositEft_RoutingNo);
            this.pnlEFT_Deposit.Controls.Add(this.ddl_DepositEft_Branch_Name);
            this.pnlEFT_Deposit.Controls.Add(this.ddl_DepositEft_Bank_Name);
            this.pnlEFT_Deposit.Controls.Add(this.btnEftCheckDepositAutogen);
            this.pnlEFT_Deposit.Controls.Add(this.label37);
            this.pnlEFT_Deposit.Controls.Add(this.label38);
            this.pnlEFT_Deposit.Controls.Add(this.txt_DepositEft_BankAccountNo);
            this.pnlEFT_Deposit.Controls.Add(this.label39);
            this.pnlEFT_Deposit.Controls.Add(this.txt_DepositEft_VoucherNo);
            this.pnlEFT_Deposit.Controls.Add(this.label40);
            this.pnlEFT_Deposit.Controls.Add(this.label41);
            this.pnlEFT_Deposit.Location = new System.Drawing.Point(703, 17);
            this.pnlEFT_Deposit.Name = "pnlEFT_Deposit";
            this.pnlEFT_Deposit.Size = new System.Drawing.Size(296, 150);
            this.pnlEFT_Deposit.TabIndex = 200;
            this.pnlEFT_Deposit.Visible = false;
            // 
            // ddl_DepositEft_RoutingNo
            // 
            this.ddl_DepositEft_RoutingNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddl_DepositEft_RoutingNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddl_DepositEft_RoutingNo.DropDownWidth = 180;
            this.ddl_DepositEft_RoutingNo.Enabled = false;
            this.ddl_DepositEft_RoutingNo.FormattingEnabled = true;
            this.ddl_DepositEft_RoutingNo.Location = new System.Drawing.Point(112, 56);
            this.ddl_DepositEft_RoutingNo.Name = "ddl_DepositEft_RoutingNo";
            this.ddl_DepositEft_RoutingNo.Size = new System.Drawing.Size(161, 21);
            this.ddl_DepositEft_RoutingNo.TabIndex = 104;
            this.ddl_DepositEft_RoutingNo.SelectionChangeCommitted += new System.EventHandler(this.ddlEftDepositRoutingNo_SelectionChangeCommitted);
            this.ddl_DepositEft_RoutingNo.SelectedIndexChanged += new System.EventHandler(this.ddlEftDepositRoutingNo_SelectedIndexChanged);
            this.ddl_DepositEft_RoutingNo.DropDownClosed += new System.EventHandler(this.ddlEftDepositRoutingNo_DropDownClosed);
            this.ddl_DepositEft_RoutingNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlEftDepositRoutingNo_KeyDown);
            this.ddl_DepositEft_RoutingNo.DropDown += new System.EventHandler(this.ddlEftDepositRoutingNo_DropDown);
            // 
            // ddl_DepositEft_Branch_Name
            // 
            this.ddl_DepositEft_Branch_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddl_DepositEft_Branch_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddl_DepositEft_Branch_Name.DropDownWidth = 180;
            this.ddl_DepositEft_Branch_Name.Enabled = false;
            this.ddl_DepositEft_Branch_Name.FormattingEnabled = true;
            this.ddl_DepositEft_Branch_Name.Location = new System.Drawing.Point(112, 32);
            this.ddl_DepositEft_Branch_Name.Name = "ddl_DepositEft_Branch_Name";
            this.ddl_DepositEft_Branch_Name.Size = new System.Drawing.Size(161, 21);
            this.ddl_DepositEft_Branch_Name.TabIndex = 104;
            this.ddl_DepositEft_Branch_Name.SelectionChangeCommitted += new System.EventHandler(this.ddlEftDepositBranchName_SelectionChangeCommitted);
            this.ddl_DepositEft_Branch_Name.SelectedIndexChanged += new System.EventHandler(this.ddlEftDepositBranchName_SelectedIndexChanged);
            this.ddl_DepositEft_Branch_Name.DropDownClosed += new System.EventHandler(this.ddlEftDepositBranchName_DropDownClosed);
            this.ddl_DepositEft_Branch_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlEftDepositBranchName_KeyDown);
            this.ddl_DepositEft_Branch_Name.DropDown += new System.EventHandler(this.ddlEftDepositBranchName_DropDown);
            // 
            // ddl_DepositEft_Bank_Name
            // 
            this.ddl_DepositEft_Bank_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddl_DepositEft_Bank_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddl_DepositEft_Bank_Name.DropDownWidth = 180;
            this.ddl_DepositEft_Bank_Name.Enabled = false;
            this.ddl_DepositEft_Bank_Name.FormattingEnabled = true;
            this.ddl_DepositEft_Bank_Name.Location = new System.Drawing.Point(112, 7);
            this.ddl_DepositEft_Bank_Name.Name = "ddl_DepositEft_Bank_Name";
            this.ddl_DepositEft_Bank_Name.Size = new System.Drawing.Size(161, 21);
            this.ddl_DepositEft_Bank_Name.TabIndex = 103;
            this.ddl_DepositEft_Bank_Name.SelectionChangeCommitted += new System.EventHandler(this.ddlEftDepositBankName_SelectionChangeCommitted);
            this.ddl_DepositEft_Bank_Name.SelectedIndexChanged += new System.EventHandler(this.ddlEftDepositBankName_SelectedIndexChanged);
            this.ddl_DepositEft_Bank_Name.DropDownClosed += new System.EventHandler(this.ddlEftDepositBankName_DropDownClosed);
            this.ddl_DepositEft_Bank_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlEftDepositBankName_KeyDown);
            this.ddl_DepositEft_Bank_Name.DropDown += new System.EventHandler(this.ddlEftDepositBankName_DropDown);
            // 
            // btnEftCheckDepositAutogen
            // 
            this.btnEftCheckDepositAutogen.Location = new System.Drawing.Point(248, 137);
            this.btnEftCheckDepositAutogen.Name = "btnEftCheckDepositAutogen";
            this.btnEftCheckDepositAutogen.Size = new System.Drawing.Size(45, 10);
            this.btnEftCheckDepositAutogen.TabIndex = 102;
            this.btnEftCheckDepositAutogen.TabStop = false;
            this.btnEftCheckDepositAutogen.Text = "Auto";
            this.btnEftCheckDepositAutogen.UseVisualStyleBackColor = true;
            this.btnEftCheckDepositAutogen.Visible = false;
            this.btnEftCheckDepositAutogen.Click += new System.EventHandler(this.btnEftCheckDepositAutogen_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(5, 82);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(71, 13);
            this.label37.TabIndex = 101;
            this.label37.Text = "Bank Acc No";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(5, 59);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(61, 13);
            this.label38.TabIndex = 101;
            this.label38.Text = "Routing No";
            // 
            // txt_DepositEft_BankAccountNo
            // 
            this.txt_DepositEft_BankAccountNo.Enabled = false;
            this.txt_DepositEft_BankAccountNo.Location = new System.Drawing.Point(112, 81);
            this.txt_DepositEft_BankAccountNo.Name = "txt_DepositEft_BankAccountNo";
            this.txt_DepositEft_BankAccountNo.Size = new System.Drawing.Size(161, 20);
            this.txt_DepositEft_BankAccountNo.TabIndex = 100;
            this.txt_DepositEft_BankAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEftDepositBankAccNo_KeyDown);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(4, 7);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(63, 13);
            this.label39.TabIndex = 91;
            this.label39.Text = "Bank Name";
            // 
            // txt_DepositEft_VoucherNo
            // 
            this.txt_DepositEft_VoucherNo.Location = new System.Drawing.Point(112, 105);
            this.txt_DepositEft_VoucherNo.Name = "txt_DepositEft_VoucherNo";
            this.txt_DepositEft_VoucherNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_DepositEft_VoucherNo.Size = new System.Drawing.Size(161, 20);
            this.txt_DepositEft_VoucherNo.TabIndex = 3;
            this.txt_DepositEft_VoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEftDepositVoucherNo_KeyDown);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 34);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(72, 13);
            this.label40.TabIndex = 87;
            this.label40.Text = "Branch Name";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(5, 104);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(67, 13);
            this.label41.TabIndex = 90;
            this.label41.Text = "Voucher No.";
            // 
            // panelChequeDeposit
            // 
            this.panelChequeDeposit.Controls.Add(this.ddl_DepositCheque_RoutingNo);
            this.panelChequeDeposit.Controls.Add(this.label47);
            this.panelChequeDeposit.Controls.Add(this.ddl_DepositCheque_BranchName);
            this.panelChequeDeposit.Controls.Add(this.ddl_DepositCheque_BankName);
            this.panelChequeDeposit.Controls.Add(this.txt_DepositCheque_VoucherNo);
            this.panelChequeDeposit.Controls.Add(this.label42);
            this.panelChequeDeposit.Controls.Add(this.dtp_DepositChequeDate);
            this.panelChequeDeposit.Controls.Add(this.txtDepositChequeNo);
            this.panelChequeDeposit.Controls.Add(this.label43);
            this.panelChequeDeposit.Controls.Add(this.label44);
            this.panelChequeDeposit.Controls.Add(this.label45);
            this.panelChequeDeposit.Controls.Add(this.label46);
            this.panelChequeDeposit.Location = new System.Drawing.Point(704, 173);
            this.panelChequeDeposit.Name = "panelChequeDeposit";
            this.panelChequeDeposit.Size = new System.Drawing.Size(296, 150);
            this.panelChequeDeposit.TabIndex = 200;
            // 
            // ddl_DepositCheque_RoutingNo
            // 
            this.ddl_DepositCheque_RoutingNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddl_DepositCheque_RoutingNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddl_DepositCheque_RoutingNo.DropDownWidth = 148;
            this.ddl_DepositCheque_RoutingNo.FormattingEnabled = true;
            this.ddl_DepositCheque_RoutingNo.Location = new System.Drawing.Point(133, 97);
            this.ddl_DepositCheque_RoutingNo.Name = "ddl_DepositCheque_RoutingNo";
            this.ddl_DepositCheque_RoutingNo.Size = new System.Drawing.Size(148, 21);
            this.ddl_DepositCheque_RoutingNo.TabIndex = 181;
            this.ddl_DepositCheque_RoutingNo.SelectionChangeCommitted += new System.EventHandler(this.ddlDepositRoutingNo_SelectionChangeCommitted);
            this.ddl_DepositCheque_RoutingNo.SelectedIndexChanged += new System.EventHandler(this.ddlDepositRoutingNo_SelectedIndexChanged);
            this.ddl_DepositCheque_RoutingNo.DropDownClosed += new System.EventHandler(this.ddlDepositRoutingNo_DropDownClosed);
            this.ddl_DepositCheque_RoutingNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositRoutingNo_KeyDown);
            this.ddl_DepositCheque_RoutingNo.DropDown += new System.EventHandler(this.ddlDepositRoutingNo_DropDown);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(4, 100);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(61, 13);
            this.label47.TabIndex = 180;
            this.label47.Text = "Routing No";
            // 
            // ddl_DepositCheque_BranchName
            // 
            this.ddl_DepositCheque_BranchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddl_DepositCheque_BranchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddl_DepositCheque_BranchName.DropDownHeight = 180;
            this.ddl_DepositCheque_BranchName.DropDownWidth = 250;
            this.ddl_DepositCheque_BranchName.FormattingEnabled = true;
            this.ddl_DepositCheque_BranchName.IntegralHeight = false;
            this.ddl_DepositCheque_BranchName.Location = new System.Drawing.Point(133, 73);
            this.ddl_DepositCheque_BranchName.Name = "ddl_DepositCheque_BranchName";
            this.ddl_DepositCheque_BranchName.Size = new System.Drawing.Size(148, 21);
            this.ddl_DepositCheque_BranchName.TabIndex = 179;
            this.ddl_DepositCheque_BranchName.SelectionChangeCommitted += new System.EventHandler(this.ddlDepositBranchName_SelectionChangeCommitted);
            this.ddl_DepositCheque_BranchName.SelectedIndexChanged += new System.EventHandler(this.ddlDepositBranchName_SelectedIndexChanged);
            this.ddl_DepositCheque_BranchName.DropDownClosed += new System.EventHandler(this.ddlDepositBranchName_DropDownClosed);
            this.ddl_DepositCheque_BranchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositBranchName_KeyDown);
            this.ddl_DepositCheque_BranchName.DropDown += new System.EventHandler(this.ddlDepositBranchName_DropDown);
            // 
            // ddl_DepositCheque_BankName
            // 
            this.ddl_DepositCheque_BankName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddl_DepositCheque_BankName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddl_DepositCheque_BankName.DropDownHeight = 180;
            this.ddl_DepositCheque_BankName.DropDownWidth = 250;
            this.ddl_DepositCheque_BankName.FormattingEnabled = true;
            this.ddl_DepositCheque_BankName.IntegralHeight = false;
            this.ddl_DepositCheque_BankName.Location = new System.Drawing.Point(133, 49);
            this.ddl_DepositCheque_BankName.Name = "ddl_DepositCheque_BankName";
            this.ddl_DepositCheque_BankName.Size = new System.Drawing.Size(148, 21);
            this.ddl_DepositCheque_BankName.TabIndex = 178;
            this.ddl_DepositCheque_BankName.SelectionChangeCommitted += new System.EventHandler(this.ddlDepositBankName_SelectionChangeCommitted);
            this.ddl_DepositCheque_BankName.SelectedIndexChanged += new System.EventHandler(this.ddlDepositBankName_SelectedIndexChanged);
            this.ddl_DepositCheque_BankName.DropDownClosed += new System.EventHandler(this.ddlDepositBankName_DropDownClosed);
            this.ddl_DepositCheque_BankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositBankName_KeyDown);
            this.ddl_DepositCheque_BankName.DropDown += new System.EventHandler(this.ddlDepositBankName_DropDown);
            // 
            // txt_DepositCheque_VoucherNo
            // 
            this.txt_DepositCheque_VoucherNo.Location = new System.Drawing.Point(133, 120);
            this.txt_DepositCheque_VoucherNo.Name = "txt_DepositCheque_VoucherNo";
            this.txt_DepositCheque_VoucherNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_DepositCheque_VoucherNo.Size = new System.Drawing.Size(148, 20);
            this.txt_DepositCheque_VoucherNo.TabIndex = 4;
            this.txt_DepositCheque_VoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepositVoucherNo_KeyDown);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(4, 122);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(64, 13);
            this.label42.TabIndex = 177;
            this.label42.Text = "Voucher No";
            // 
            // dtp_DepositChequeDate
            // 
            this.dtp_DepositChequeDate.CustomFormat = "dd-MMM-yyyy";
            this.dtp_DepositChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DepositChequeDate.Location = new System.Drawing.Point(133, 27);
            this.dtp_DepositChequeDate.Name = "dtp_DepositChequeDate";
            this.dtp_DepositChequeDate.Size = new System.Drawing.Size(126, 20);
            this.dtp_DepositChequeDate.TabIndex = 1;
            this.dtp_DepositChequeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cdtDepositPaymentMediaDate_KeyDown);
            // 
            // txtDepositChequeNo
            // 
            this.txtDepositChequeNo.Location = new System.Drawing.Point(133, 4);
            this.txtDepositChequeNo.Name = "txtDepositChequeNo";
            this.txtDepositChequeNo.Size = new System.Drawing.Size(148, 20);
            this.txtDepositChequeNo.TabIndex = 0;
            this.txtDepositChequeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepositPaymentMedia_KeyDown);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(4, 29);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(122, 13);
            this.label43.TabIndex = 176;
            this.label43.Text = "Pay Order/Cheque Date";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(4, 76);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(72, 13);
            this.label44.TabIndex = 175;
            this.label44.Text = "Branch Name";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(4, 7);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(122, 13);
            this.label45.TabIndex = 174;
            this.label45.Text = "Pay Oreder/Cheque No.";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(4, 51);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(63, 13);
            this.label46.TabIndex = 173;
            this.label46.Text = "Bank Name";
            // 
            // panelEFT
            // 
            this.panelEFT.Controls.Add(this.txtEFTBranchID);
            this.panelEFT.Controls.Add(this.txtEFTBankID);
            this.panelEFT.Controls.Add(this.btneftAutoVoucher);
            this.panelEFT.Controls.Add(this.label35);
            this.panelEFT.Controls.Add(this.label28);
            this.panelEFT.Controls.Add(this.txt_EftWithdraw_BankAccNo);
            this.panelEFT.Controls.Add(this.txt_EftWithdraw_RoutingNo);
            this.panelEFT.Controls.Add(this.txt_EftWithdraw_BankName);
            this.panelEFT.Controls.Add(this.label32);
            this.panelEFT.Controls.Add(this.txt_EftWithdraw_VoucherNo);
            this.panelEFT.Controls.Add(this.txt_EftWithdraw_BranchName);
            this.panelEFT.Controls.Add(this.label33);
            this.panelEFT.Controls.Add(this.label34);
            this.panelEFT.Location = new System.Drawing.Point(703, 336);
            this.panelEFT.Name = "panelEFT";
            this.panelEFT.Size = new System.Drawing.Size(296, 150);
            this.panelEFT.TabIndex = 163;
            this.panelEFT.Visible = false;
            // 
            // txtEFTBranchID
            // 
            this.txtEFTBranchID.Location = new System.Drawing.Point(274, 35);
            this.txtEFTBranchID.Name = "txtEFTBranchID";
            this.txtEFTBranchID.Size = new System.Drawing.Size(5, 20);
            this.txtEFTBranchID.TabIndex = 104;
            this.txtEFTBranchID.Visible = false;
            // 
            // txtEFTBankID
            // 
            this.txtEFTBankID.Location = new System.Drawing.Point(274, 8);
            this.txtEFTBankID.Name = "txtEFTBankID";
            this.txtEFTBankID.Size = new System.Drawing.Size(5, 20);
            this.txtEFTBankID.TabIndex = 103;
            this.txtEFTBankID.Visible = false;
            // 
            // btneftAutoVoucher
            // 
            this.btneftAutoVoucher.Location = new System.Drawing.Point(228, 107);
            this.btneftAutoVoucher.Name = "btneftAutoVoucher";
            this.btneftAutoVoucher.Size = new System.Drawing.Size(45, 23);
            this.btneftAutoVoucher.TabIndex = 102;
            this.btneftAutoVoucher.TabStop = false;
            this.btneftAutoVoucher.Text = "Auto";
            this.btneftAutoVoucher.UseVisualStyleBackColor = true;
            this.btneftAutoVoucher.Click += new System.EventHandler(this.btneftAutoVoucher_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(4, 82);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(71, 13);
            this.label35.TabIndex = 101;
            this.label35.Text = "Bank Acc No";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(4, 59);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(61, 13);
            this.label28.TabIndex = 101;
            this.label28.Text = "Routing No";
            // 
            // txt_EftWithdraw_BankAccNo
            // 
            this.txt_EftWithdraw_BankAccNo.Location = new System.Drawing.Point(113, 81);
            this.txt_EftWithdraw_BankAccNo.Name = "txt_EftWithdraw_BankAccNo";
            this.txt_EftWithdraw_BankAccNo.ReadOnly = true;
            this.txt_EftWithdraw_BankAccNo.Size = new System.Drawing.Size(159, 20);
            this.txt_EftWithdraw_BankAccNo.TabIndex = 100;
            // 
            // txt_EftWithdraw_RoutingNo
            // 
            this.txt_EftWithdraw_RoutingNo.Location = new System.Drawing.Point(113, 58);
            this.txt_EftWithdraw_RoutingNo.Name = "txt_EftWithdraw_RoutingNo";
            this.txt_EftWithdraw_RoutingNo.ReadOnly = true;
            this.txt_EftWithdraw_RoutingNo.Size = new System.Drawing.Size(159, 20);
            this.txt_EftWithdraw_RoutingNo.TabIndex = 100;
            // 
            // txt_EftWithdraw_BankName
            // 
            this.txt_EftWithdraw_BankName.Location = new System.Drawing.Point(112, 9);
            this.txt_EftWithdraw_BankName.Name = "txt_EftWithdraw_BankName";
            this.txt_EftWithdraw_BankName.ReadOnly = true;
            this.txt_EftWithdraw_BankName.Size = new System.Drawing.Size(160, 20);
            this.txt_EftWithdraw_BankName.TabIndex = 1;
            this.txt_EftWithdraw_BankName.TabStop = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(3, 9);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(63, 13);
            this.label32.TabIndex = 91;
            this.label32.Text = "Bank Name";
            // 
            // txt_EftWithdraw_VoucherNo
            // 
            this.txt_EftWithdraw_VoucherNo.Location = new System.Drawing.Point(113, 109);
            this.txt_EftWithdraw_VoucherNo.Name = "txt_EftWithdraw_VoucherNo";
            this.txt_EftWithdraw_VoucherNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_EftWithdraw_VoucherNo.Size = new System.Drawing.Size(113, 20);
            this.txt_EftWithdraw_VoucherNo.TabIndex = 3;
            this.txt_EftWithdraw_VoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txteftVoucherNo_KeyDown);
            // 
            // txt_EftWithdraw_BranchName
            // 
            this.txt_EftWithdraw_BranchName.Location = new System.Drawing.Point(113, 34);
            this.txt_EftWithdraw_BranchName.Name = "txt_EftWithdraw_BranchName";
            this.txt_EftWithdraw_BranchName.ReadOnly = true;
            this.txt_EftWithdraw_BranchName.Size = new System.Drawing.Size(160, 20);
            this.txt_EftWithdraw_BranchName.TabIndex = 2;
            this.txt_EftWithdraw_BranchName.TabStop = false;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(4, 34);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(72, 13);
            this.label33.TabIndex = 87;
            this.label33.Text = "Branch Name";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(4, 108);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(67, 13);
            this.label34.TabIndex = 90;
            this.label34.Text = "Voucher No.";
            // 
            // panelPaymentTransfer
            // 
            this.panelPaymentTransfer.Controls.Add(this.txtAvailableWithdrawBalance);
            this.panelPaymentTransfer.Controls.Add(this.label59);
            this.panelPaymentTransfer.Controls.Add(this.txtAccruedBalance);
            this.panelPaymentTransfer.Controls.Add(this.label58);
            this.panelPaymentTransfer.Controls.Add(this.btnAutoGen);
            this.panelPaymentTransfer.Controls.Add(this.label19);
            this.panelPaymentTransfer.Controls.Add(this.btnSearchTrans);
            this.panelPaymentTransfer.Controls.Add(this.txt_Transfer_CustCode);
            this.panelPaymentTransfer.Controls.Add(this.txt_Transfer_CustName);
            this.panelPaymentTransfer.Controls.Add(this.label29);
            this.panelPaymentTransfer.Controls.Add(this.txt_Transfer_VoucherNo);
            this.panelPaymentTransfer.Controls.Add(this.txt_Transfer_Balance);
            this.panelPaymentTransfer.Controls.Add(this.label30);
            this.panelPaymentTransfer.Controls.Add(this.label31);
            this.panelPaymentTransfer.Location = new System.Drawing.Point(704, 496);
            this.panelPaymentTransfer.Name = "panelPaymentTransfer";
            this.panelPaymentTransfer.Size = new System.Drawing.Size(296, 150);
            this.panelPaymentTransfer.TabIndex = 3;
            // 
            // txtAvailableWithdrawBalance
            // 
            this.txtAvailableWithdrawBalance.Location = new System.Drawing.Point(113, 77);
            this.txtAvailableWithdrawBalance.Name = "txtAvailableWithdrawBalance";
            this.txtAvailableWithdrawBalance.ReadOnly = true;
            this.txtAvailableWithdrawBalance.Size = new System.Drawing.Size(160, 20);
            this.txtAvailableWithdrawBalance.TabIndex = 108;
            this.txtAvailableWithdrawBalance.TabStop = false;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.SystemColors.Control;
            this.label59.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label59.Location = new System.Drawing.Point(4, 77);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(88, 13);
            this.label59.TabIndex = 109;
            this.label59.Text = "Available W. Bal.";
            // 
            // txtAccruedBalance
            // 
            this.txtAccruedBalance.Location = new System.Drawing.Point(112, 56);
            this.txtAccruedBalance.Name = "txtAccruedBalance";
            this.txtAccruedBalance.ReadOnly = true;
            this.txtAccruedBalance.Size = new System.Drawing.Size(160, 20);
            this.txtAccruedBalance.TabIndex = 106;
            this.txtAccruedBalance.TabStop = false;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.SystemColors.Control;
            this.label58.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label58.Location = new System.Drawing.Point(3, 56);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(89, 13);
            this.label58.TabIndex = 107;
            this.label58.Text = "Accrued Balance";
            // 
            // btnAutoGen
            // 
            this.btnAutoGen.Location = new System.Drawing.Point(226, 121);
            this.btnAutoGen.Name = "btnAutoGen";
            this.btnAutoGen.Size = new System.Drawing.Size(45, 23);
            this.btnAutoGen.TabIndex = 105;
            this.btnAutoGen.TabStop = false;
            this.btnAutoGen.Text = "Auto";
            this.btnAutoGen.UseVisualStyleBackColor = true;
            this.btnAutoGen.Click += new System.EventHandler(this.btnAutoGen_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(3, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(97, 13);
            this.label19.TabIndex = 99;
            this.label19.Text = "TR Customer Code";
            // 
            // btnSearchTrans
            // 
            this.btnSearchTrans.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchTrans.Image")));
            this.btnSearchTrans.Location = new System.Drawing.Point(230, 6);
            this.btnSearchTrans.Name = "btnSearchTrans";
            this.btnSearchTrans.Size = new System.Drawing.Size(42, 23);
            this.btnSearchTrans.TabIndex = 1;
            this.btnSearchTrans.TabStop = false;
            this.btnSearchTrans.UseVisualStyleBackColor = true;
            this.btnSearchTrans.Click += new System.EventHandler(this.btnSearchTrans_Click);
            // 
            // txt_Transfer_CustCode
            // 
            this.txt_Transfer_CustCode.Location = new System.Drawing.Point(112, 7);
            this.txt_Transfer_CustCode.Name = "txt_Transfer_CustCode";
            this.txt_Transfer_CustCode.Size = new System.Drawing.Size(113, 20);
            this.txt_Transfer_CustCode.TabIndex = 0;
            this.txt_Transfer_CustCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransCustomer_KeyDown);
            // 
            // txt_Transfer_CustName
            // 
            this.txt_Transfer_CustName.Location = new System.Drawing.Point(112, 33);
            this.txt_Transfer_CustName.Name = "txt_Transfer_CustName";
            this.txt_Transfer_CustName.ReadOnly = true;
            this.txt_Transfer_CustName.Size = new System.Drawing.Size(160, 20);
            this.txt_Transfer_CustName.TabIndex = 1;
            this.txt_Transfer_CustName.TabStop = false;
            this.txt_Transfer_CustName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositWithdraw_KeyDown);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.SystemColors.Control;
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(3, 33);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(82, 13);
            this.label29.TabIndex = 91;
            this.label29.Text = "Customer Name";
            // 
            // txt_Transfer_VoucherNo
            // 
            this.txt_Transfer_VoucherNo.Location = new System.Drawing.Point(113, 123);
            this.txt_Transfer_VoucherNo.Name = "txt_Transfer_VoucherNo";
            this.txt_Transfer_VoucherNo.ReadOnly = true;
            this.txt_Transfer_VoucherNo.Size = new System.Drawing.Size(112, 20);
            this.txt_Transfer_VoucherNo.TabIndex = 3;
            this.txt_Transfer_VoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherNo_KeyDown);
            // 
            // txt_Transfer_Balance
            // 
            this.txt_Transfer_Balance.Location = new System.Drawing.Point(113, 99);
            this.txt_Transfer_Balance.Name = "txt_Transfer_Balance";
            this.txt_Transfer_Balance.ReadOnly = true;
            this.txt_Transfer_Balance.Size = new System.Drawing.Size(160, 20);
            this.txt_Transfer_Balance.TabIndex = 2;
            this.txt_Transfer_Balance.TabStop = false;
            this.txt_Transfer_Balance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositWithdraw_KeyDown);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.SystemColors.Control;
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(4, 99);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(46, 13);
            this.label30.TabIndex = 87;
            this.label30.Text = "Balance";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.SystemColors.Control;
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(4, 122);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 13);
            this.label31.TabIndex = 90;
            this.label31.Text = "Voucher No.";
            // 
            // panelPaymentInfo
            // 
            this.panelPaymentInfo.Controls.Add(this.txt_Paypal_VoucherNo);
            this.panelPaymentInfo.Controls.Add(this.label21);
            this.panelPaymentInfo.Controls.Add(this.txt_Paypal_BranchName);
            this.panelPaymentInfo.Controls.Add(this.txt_Paypal_BankName);
            this.panelPaymentInfo.Controls.Add(this.dtp_Paypal_OrderDate);
            this.panelPaymentInfo.Controls.Add(this.txt_Paypal_OrderNo);
            this.panelPaymentInfo.Controls.Add(this.label22);
            this.panelPaymentInfo.Controls.Add(this.label23);
            this.panelPaymentInfo.Controls.Add(this.label24);
            this.panelPaymentInfo.Controls.Add(this.label25);
            this.panelPaymentInfo.Location = new System.Drawing.Point(703, 652);
            this.panelPaymentInfo.Name = "panelPaymentInfo";
            this.panelPaymentInfo.Size = new System.Drawing.Size(296, 150);
            this.panelPaymentInfo.TabIndex = 0;
            // 
            // txt_Paypal_VoucherNo
            // 
            this.txt_Paypal_VoucherNo.Location = new System.Drawing.Point(133, 106);
            this.txt_Paypal_VoucherNo.Name = "txt_Paypal_VoucherNo";
            this.txt_Paypal_VoucherNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Paypal_VoucherNo.Size = new System.Drawing.Size(148, 20);
            this.txt_Paypal_VoucherNo.TabIndex = 4;
            this.txt_Paypal_VoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerialNo_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(4, 108);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 13);
            this.label21.TabIndex = 177;
            this.label21.Text = "Voucher No";
            // 
            // txt_Paypal_BranchName
            // 
            this.txt_Paypal_BranchName.Location = new System.Drawing.Point(133, 81);
            this.txt_Paypal_BranchName.Name = "txt_Paypal_BranchName";
            this.txt_Paypal_BranchName.Size = new System.Drawing.Size(148, 20);
            this.txt_Paypal_BranchName.TabIndex = 3;
            this.txt_Paypal_BranchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranchName_KeyDown);
            // 
            // txt_Paypal_BankName
            // 
            this.txt_Paypal_BankName.Location = new System.Drawing.Point(133, 57);
            this.txt_Paypal_BankName.Name = "txt_Paypal_BankName";
            this.txt_Paypal_BankName.Size = new System.Drawing.Size(148, 20);
            this.txt_Paypal_BankName.TabIndex = 2;
            this.txt_Paypal_BankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBankName_KeyDown);
            // 
            // dtp_Paypal_OrderDate
            // 
            this.dtp_Paypal_OrderDate.CustomFormat = "dd-MMM-yyyy";
            this.dtp_Paypal_OrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Paypal_OrderDate.Location = new System.Drawing.Point(133, 33);
            this.dtp_Paypal_OrderDate.Name = "dtp_Paypal_OrderDate";
            this.dtp_Paypal_OrderDate.Size = new System.Drawing.Size(126, 20);
            this.dtp_Paypal_OrderDate.TabIndex = 1;
            this.dtp_Paypal_OrderDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositWithdraw_KeyDown);
            // 
            // txt_Paypal_OrderNo
            // 
            this.txt_Paypal_OrderNo.Location = new System.Drawing.Point(133, 9);
            this.txt_Paypal_OrderNo.Name = "txt_Paypal_OrderNo";
            this.txt_Paypal_OrderNo.Size = new System.Drawing.Size(148, 20);
            this.txt_Paypal_OrderNo.TabIndex = 0;
            this.txt_Paypal_OrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaymentMedia_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 35);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 13);
            this.label22.TabIndex = 176;
            this.label22.Text = "Pay Order/Cheque Date";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 13);
            this.label23.TabIndex = 175;
            this.label23.Text = "Branch Name";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(4, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(122, 13);
            this.label24.TabIndex = 174;
            this.label24.Text = "Pay Oreder/Cheque No.";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 57);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 13);
            this.label25.TabIndex = 173;
            this.label25.Text = "Bank Name";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(524, 447);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(74, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(322, 574);
            this.btnReset.Name = "btnReset";
            this.btnReset.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReset.Size = new System.Drawing.Size(79, 25);
            this.btnReset.TabIndex = 6;
            this.btnReset.TabStop = false;
            this.btnReset.Text = "Review";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(606, 447);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(74, 25);
            this.btnClose.TabIndex = 7;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ChannelType);
            this.groupBox1.Controls.Add(this.txt_ChannelID);
            this.groupBox1.Controls.Add(this.btnSms);
            this.groupBox1.Controls.Add(this.btnWebData);
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.ddlSearchCustomer);
            this.groupBox1.Controls.Add(this.txtSearchCustomer);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Selection";
            // 
            // txt_ChannelType
            // 
            this.txt_ChannelType.Location = new System.Drawing.Point(300, -1);
            this.txt_ChannelType.Name = "txt_ChannelType";
            this.txt_ChannelType.Size = new System.Drawing.Size(10, 20);
            this.txt_ChannelType.TabIndex = 5;
            this.txt_ChannelType.Visible = false;
            // 
            // txt_ChannelID
            // 
            this.txt_ChannelID.Location = new System.Drawing.Point(316, -1);
            this.txt_ChannelID.Name = "txt_ChannelID";
            this.txt_ChannelID.Size = new System.Drawing.Size(10, 20);
            this.txt_ChannelID.TabIndex = 4;
            this.txt_ChannelID.Visible = false;
            // 
            // btnSms
            // 
            this.btnSms.Location = new System.Drawing.Point(247, 17);
            this.btnSms.Name = "btnSms";
            this.btnSms.Size = new System.Drawing.Size(42, 23);
            this.btnSms.TabIndex = 3;
            this.btnSms.Text = "Sms";
            this.btnSms.UseVisualStyleBackColor = true;
            this.btnSms.Click += new System.EventHandler(this.btnSms_Click);
            // 
            // btnWebData
            // 
            this.btnWebData.Enabled = false;
            this.btnWebData.Location = new System.Drawing.Point(291, 17);
            this.btnWebData.Name = "btnWebData";
            this.btnWebData.Size = new System.Drawing.Size(38, 23);
            this.btnWebData.TabIndex = 2;
            this.btnWebData.Text = "Web";
            this.btnWebData.UseVisualStyleBackColor = true;
            this.btnWebData.Click += new System.EventHandler(this.btnWebData_Click_1);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(203, 17);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(42, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.TabStop = false;
            this.btnGo.Text = "Add";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // ddlSearchCustomer
            // 
            this.ddlSearchCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchCustomer.FormattingEnabled = true;
            this.ddlSearchCustomer.Items.AddRange(new object[] {
            "Customer Code",
            "BO Id"});
            this.ddlSearchCustomer.Location = new System.Drawing.Point(6, 17);
            this.ddlSearchCustomer.Name = "ddlSearchCustomer";
            this.ddlSearchCustomer.Size = new System.Drawing.Size(75, 21);
            this.ddlSearchCustomer.TabIndex = 0;
            this.ddlSearchCustomer.TabStop = false;
            this.ddlSearchCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlSearchCustomer_KeyDown);
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtSearchCustomer.Location = new System.Drawing.Point(85, 18);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(115, 20);
            this.txtSearchCustomer.TabIndex = 0;
            this.txtSearchCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlSearchCustomer_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(101, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 13);
            this.label15.TabIndex = 169;
            this.label15.Text = ":";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(101, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(10, 13);
            this.label18.TabIndex = 172;
            this.label18.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 171;
            this.label11.Text = "Recieved By";
            // 
            // txtRecievedBy
            // 
            this.txtRecievedBy.Location = new System.Drawing.Point(117, 40);
            this.txtRecievedBy.Name = "txtRecievedBy";
            this.txtRecievedBy.Size = new System.Drawing.Size(186, 20);
            this.txtRecievedBy.TabIndex = 0;
            this.txtRecievedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecievedBy_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 168;
            this.label9.Text = "Recieved Date";
            // 
            // dtRecievedDate
            // 
            this.dtRecievedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtRecievedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRecievedDate.Location = new System.Drawing.Point(117, 16);
            this.dtRecievedDate.Name = "dtRecievedDate";
            this.dtRecievedDate.Size = new System.Drawing.Size(88, 20);
            this.dtRecievedDate.TabIndex = 1;
            this.dtRecievedDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositWithdraw_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 174;
            this.label6.Text = "Remarks";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(101, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 13);
            this.label14.TabIndex = 175;
            this.label14.Text = ":";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(117, 64);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(186, 30);
            this.txtRemarks.TabIndex = 2;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkNegativeBalanceNotCalculate);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtRecievedDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtRecievedBy);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(13, 461);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 109);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnEftReturn);
            this.groupBox4.Controls.Add(this.btn_Cancel_TransChrgTaken);
            this.groupBox4.Controls.Add(this.txt_RequiredTranCharge);
            this.groupBox4.Controls.Add(this.LabelCount);
            this.groupBox4.Controls.Add(this.txt_CustCodeHidden);
            this.groupBox4.Controls.Add(this.txt_MinBalance);
            this.groupBox4.Controls.Add(this.txt_Distributed_Amount);
            this.groupBox4.Controls.Add(this.txtAmount);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btnDWReturnInfo);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.ddlDepositWithdraw);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.chkMatureToday);
            this.groupBox4.Controls.Add(this.ddlPaymentMedia);
            this.groupBox4.Location = new System.Drawing.Point(13, 179);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(336, 107);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // btnEftReturn
            // 
            this.btnEftReturn.Enabled = false;
            this.btnEftReturn.Location = new System.Drawing.Point(286, 57);
            this.btnEftReturn.Name = "btnEftReturn";
            this.btnEftReturn.Size = new System.Drawing.Size(32, 23);
            this.btnEftReturn.TabIndex = 239;
            this.btnEftReturn.Text = "...";
            this.btnEftReturn.UseVisualStyleBackColor = true;
            this.btnEftReturn.Visible = false;
            this.btnEftReturn.Click += new System.EventHandler(this.btnEftReturn_Click);
            // 
            // btn_Cancel_TransChrgTaken
            // 
            this.btn_Cancel_TransChrgTaken.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel_TransChrgTaken.Location = new System.Drawing.Point(318, 57);
            this.btn_Cancel_TransChrgTaken.Name = "btn_Cancel_TransChrgTaken";
            this.btn_Cancel_TransChrgTaken.Size = new System.Drawing.Size(16, 23);
            this.btn_Cancel_TransChrgTaken.TabIndex = 172;
            this.btn_Cancel_TransChrgTaken.Text = "X";
            this.btn_Cancel_TransChrgTaken.UseVisualStyleBackColor = true;
            this.btn_Cancel_TransChrgTaken.Click += new System.EventHandler(this.btn_Cancel_TransChrgTaken_Click);
            // 
            // txt_RequiredTranCharge
            // 
            this.txt_RequiredTranCharge.Location = new System.Drawing.Point(265, 30);
            this.txt_RequiredTranCharge.Name = "txt_RequiredTranCharge";
            this.txt_RequiredTranCharge.Size = new System.Drawing.Size(24, 20);
            this.txt_RequiredTranCharge.TabIndex = 171;
            this.txt_RequiredTranCharge.Visible = false;
            // 
            // LabelCount
            // 
            this.LabelCount.AutoSize = true;
            this.LabelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCount.ForeColor = System.Drawing.Color.Black;
            this.LabelCount.Location = new System.Drawing.Point(245, 8);
            this.LabelCount.Name = "LabelCount";
            this.LabelCount.Size = new System.Drawing.Size(10, 13);
            this.LabelCount.TabIndex = 170;
            this.LabelCount.Text = " ";
            // 
            // txt_CustCodeHidden
            // 
            this.txt_CustCodeHidden.Location = new System.Drawing.Point(293, 30);
            this.txt_CustCodeHidden.Name = "txt_CustCodeHidden";
            this.txt_CustCodeHidden.Size = new System.Drawing.Size(24, 20);
            this.txt_CustCodeHidden.TabIndex = 169;
            this.txt_CustCodeHidden.Visible = false;
            // 
            // txt_MinBalance
            // 
            this.txt_MinBalance.Location = new System.Drawing.Point(293, 83);
            this.txt_MinBalance.Name = "txt_MinBalance";
            this.txt_MinBalance.Size = new System.Drawing.Size(24, 20);
            this.txt_MinBalance.TabIndex = 168;
            this.txt_MinBalance.Visible = false;
            // 
            // txt_Distributed_Amount
            // 
            this.txt_Distributed_Amount.Location = new System.Drawing.Point(265, 83);
            this.txt_Distributed_Amount.Name = "txt_Distributed_Amount";
            this.txt_Distributed_Amount.Size = new System.Drawing.Size(24, 20);
            this.txt_Distributed_Amount.TabIndex = 167;
            this.txt_Distributed_Amount.Visible = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(121, 83);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.Size = new System.Drawing.Size(135, 20);
            this.txtAmount.TabIndex = 164;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 166;
            this.label17.Text = "Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(101, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 165;
            this.label8.Text = ":";
            // 
            // btnDWReturnInfo
            // 
            this.btnDWReturnInfo.Location = new System.Drawing.Point(257, 57);
            this.btnDWReturnInfo.Name = "btnDWReturnInfo";
            this.btnDWReturnInfo.Size = new System.Drawing.Size(32, 23);
            this.btnDWReturnInfo.TabIndex = 163;
            this.btnDWReturnInfo.Text = "...";
            this.btnDWReturnInfo.UseVisualStyleBackColor = true;
            this.btnDWReturnInfo.Click += new System.EventHandler(this.btnDWReturnInfo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 162;
            this.label4.Text = "Payment Media";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(101, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 161;
            this.label10.Text = ":";
            // 
            // ddlDepositWithdraw
            // 
            this.ddlDepositWithdraw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDepositWithdraw.FormattingEnabled = true;
            this.ddlDepositWithdraw.Location = new System.Drawing.Point(121, 34);
            this.ddlDepositWithdraw.Name = "ddlDepositWithdraw";
            this.ddlDepositWithdraw.Size = new System.Drawing.Size(135, 21);
            this.ddlDepositWithdraw.TabIndex = 0;
            this.ddlDepositWithdraw.SelectedIndexChanged += new System.EventHandler(this.ddlDepositWithdraw_SelectedIndexChanged);
            this.ddlDepositWithdraw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositWithdraw_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 157;
            this.label2.Text = "Deposit/Withdraw";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 156;
            this.label7.Text = ":";
            // 
            // chkMatureToday
            // 
            this.chkMatureToday.AutoSize = true;
            this.chkMatureToday.Location = new System.Drawing.Point(265, 85);
            this.chkMatureToday.Name = "chkMatureToday";
            this.chkMatureToday.Size = new System.Drawing.Size(65, 17);
            this.chkMatureToday.TabIndex = 3;
            this.chkMatureToday.TabStop = false;
            this.chkMatureToday.Text = "Matured";
            this.chkMatureToday.UseVisualStyleBackColor = true;
            this.chkMatureToday.Visible = false;
            this.chkMatureToday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlPaymentMedia_KeyDown);
            // 
            // ddlPaymentMedia
            // 
            this.ddlPaymentMedia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPaymentMedia.FormattingEnabled = true;
            this.ddlPaymentMedia.Location = new System.Drawing.Point(121, 58);
            this.ddlPaymentMedia.Name = "ddlPaymentMedia";
            this.ddlPaymentMedia.Size = new System.Drawing.Size(135, 21);
            this.ddlPaymentMedia.TabIndex = 2;
            this.ddlPaymentMedia.SelectedIndexChanged += new System.EventHandler(this.ddlPaymentMedia_SelectedIndexChanged);
            this.ddlPaymentMedia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositWithdraw_KeyDown);
            // 
            // dgvPaymentInfo
            // 
            this.dgvPaymentInfo.AllowUserToAddRows = false;
            this.dgvPaymentInfo.AllowUserToDeleteRows = false;
            this.dgvPaymentInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvPaymentInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaymentInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentInfo.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaymentInfo.ColumnHeadersHeight = 26;
            this.dgvPaymentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaymentInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaymentInfo.GridColor = System.Drawing.Color.LightGray;
            this.dgvPaymentInfo.Location = new System.Drawing.Point(12, 629);
            this.dgvPaymentInfo.MultiSelect = false;
            this.dgvPaymentInfo.Name = "dgvPaymentInfo";
            this.dgvPaymentInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaymentInfo.RowHeadersVisible = false;
            this.dgvPaymentInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentInfo.Size = new System.Drawing.Size(429, 161);
            this.dgvPaymentInfo.TabIndex = 10;
            this.dgvPaymentInfo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvPaymentInfo_RowsAdded);
            this.dgvPaymentInfo.DataSourceChanged += new System.EventHandler(this.dgvPaymentInfo_DataSourceChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.dtpSearchPaymentEntry);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Location = new System.Drawing.Point(12, 572);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 29);
            this.panel1.TabIndex = 11;
            // 
            // dtpSearchPaymentEntry
            // 
            this.dtpSearchPaymentEntry.CustomFormat = "dd-MMM-yyyy";
            this.dtpSearchPaymentEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearchPaymentEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearchPaymentEntry.Location = new System.Drawing.Point(114, 4);
            this.dtpSearchPaymentEntry.Name = "dtpSearchPaymentEntry";
            this.dtpSearchPaymentEntry.Size = new System.Drawing.Size(139, 20);
            this.dtpSearchPaymentEntry.TabIndex = 1;
            this.dtpSearchPaymentEntry.ValueChanged += new System.EventHandler(this.dtpSearchPaymentEntry_ValueChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.GreenYellow;
            this.label27.Location = new System.Drawing.Point(18, 8);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(94, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Payment Date :";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssTotalRecord});
            this.statusStrip1.Location = new System.Drawing.Point(0, 821);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1339, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssTotalRecord
            // 
            this.tssTotalRecord.Name = "tssTotalRecord";
            this.tssTotalRecord.Size = new System.Drawing.Size(0, 17);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnRefresh.Location = new System.Drawing.Point(513, 796);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnRefresh.Size = new System.Drawing.Size(87, 25);
            this.btnRefresh.TabIndex = 198;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "Fetch Data";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDepositCancel
            // 
            this.btnDepositCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepositCancel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDepositCancel.Location = new System.Drawing.Point(609, 796);
            this.btnDepositCancel.Name = "btnDepositCancel";
            this.btnDepositCancel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDepositCancel.Size = new System.Drawing.Size(74, 25);
            this.btnDepositCancel.TabIndex = 197;
            this.btnDepositCancel.TabStop = false;
            this.btnDepositCancel.Text = "Cancel";
            this.btnDepositCancel.UseVisualStyleBackColor = true;
            this.btnDepositCancel.Click += new System.EventHandler(this.btnDepositCancel_Click);
            // 
            // dgvExtension
            // 
            this.dgvExtension.DataGridView = this.dgvPaymentInfo;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.dgvExtension.FilterFactory = defaultGridFilterFactory1;
            // 
            // dg_Customers
            // 
            this.dg_Customers.AllowUserToAddRows = false;
            this.dg_Customers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Customers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dg_Customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Customers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsChargable,
            this.Cust_Code,
            this.BOID,
            this.Status,
            this.IPO_Mone_Bal,
            this.Distributed_Amount,
            this.DeleteFlag,
            this.BankAccNo,
            this.RoutingNo,
            this.BankID,
            this.BankName,
            this.BranchID,
            this.BranchName,
            this.ChannelID,
            this.ChannelType});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Customers.DefaultCellStyle = dataGridViewCellStyle7;
            this.dg_Customers.Location = new System.Drawing.Point(12, 64);
            this.dg_Customers.MultiSelect = false;
            this.dg_Customers.Name = "dg_Customers";
            this.dg_Customers.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Customers.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dg_Customers.RowHeadersVisible = false;
            this.dg_Customers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Customers.Size = new System.Drawing.Size(336, 118);
            this.dg_Customers.TabIndex = 202;
            this.dg_Customers.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dg_Customers_RowsAdded);
            this.dg_Customers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Customers_CellEndEdit);
            this.dg_Customers.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dg_Customers_RowsRemoved);
            this.dg_Customers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Customers_CellContentClick);
            // 
            // IsChargable
            // 
            this.IsChargable.DataPropertyName = "IsChargable";
            this.IsChargable.HeaderText = "";
            this.IsChargable.Name = "IsChargable";
            this.IsChargable.ReadOnly = true;
            this.IsChargable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsChargable.Width = 20;
            // 
            // Cust_Code
            // 
            this.Cust_Code.DataPropertyName = "Cust_Code";
            this.Cust_Code.HeaderText = "Code";
            this.Cust_Code.Name = "Cust_Code";
            this.Cust_Code.ReadOnly = true;
            this.Cust_Code.Width = 70;
            // 
            // BOID
            // 
            this.BOID.DataPropertyName = "BOID";
            this.BOID.HeaderText = "BOID";
            this.BOID.Name = "BOID";
            this.BOID.ReadOnly = true;
            this.BOID.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 60;
            // 
            // IPO_Mone_Bal
            // 
            this.IPO_Mone_Bal.DataPropertyName = "IPO_Mone_Bal";
            this.IPO_Mone_Bal.HeaderText = "Balance (IPO)";
            this.IPO_Mone_Bal.Name = "IPO_Mone_Bal";
            this.IPO_Mone_Bal.ReadOnly = true;
            this.IPO_Mone_Bal.Width = 115;
            // 
            // Distributed_Amount
            // 
            this.Distributed_Amount.DataPropertyName = "Distributed_Amount";
            this.Distributed_Amount.HeaderText = "Amount";
            this.Distributed_Amount.Name = "Distributed_Amount";
            this.Distributed_Amount.ReadOnly = true;
            this.Distributed_Amount.Width = 73;
            // 
            // DeleteFlag
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(1);
            this.DeleteFlag.DefaultCellStyle = dataGridViewCellStyle6;
            this.DeleteFlag.HeaderText = "Remove";
            this.DeleteFlag.Name = "DeleteFlag";
            this.DeleteFlag.ReadOnly = true;
            this.DeleteFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteFlag.Width = 50;
            // 
            // BankAccNo
            // 
            this.BankAccNo.DataPropertyName = "BankAccNo";
            this.BankAccNo.HeaderText = "Acc. No";
            this.BankAccNo.Name = "BankAccNo";
            this.BankAccNo.ReadOnly = true;
            this.BankAccNo.Visible = false;
            // 
            // RoutingNo
            // 
            this.RoutingNo.DataPropertyName = "RoutingNo";
            this.RoutingNo.HeaderText = "Routing No";
            this.RoutingNo.Name = "RoutingNo";
            this.RoutingNo.ReadOnly = true;
            this.RoutingNo.Visible = false;
            // 
            // BankID
            // 
            this.BankID.DataPropertyName = "BankID";
            this.BankID.HeaderText = "Bank ID";
            this.BankID.Name = "BankID";
            this.BankID.ReadOnly = true;
            this.BankID.Visible = false;
            // 
            // BankName
            // 
            this.BankName.DataPropertyName = "BankName";
            this.BankName.HeaderText = "Bank Name";
            this.BankName.Name = "BankName";
            this.BankName.ReadOnly = true;
            this.BankName.Visible = false;
            // 
            // BranchID
            // 
            this.BranchID.DataPropertyName = "BranchID";
            this.BranchID.HeaderText = "Branch ID";
            this.BranchID.Name = "BranchID";
            this.BranchID.ReadOnly = true;
            this.BranchID.Visible = false;
            // 
            // BranchName
            // 
            this.BranchName.DataPropertyName = "BranchName";
            this.BranchName.HeaderText = "Branch Name";
            this.BranchName.Name = "BranchName";
            this.BranchName.ReadOnly = true;
            this.BranchName.Visible = false;
            // 
            // ChannelID
            // 
            this.ChannelID.DataPropertyName = "ChannelID";
            this.ChannelID.HeaderText = "ChannelID";
            this.ChannelID.Name = "ChannelID";
            this.ChannelID.ReadOnly = true;
            this.ChannelID.Visible = false;
            // 
            // ChannelType
            // 
            this.ChannelType.DataPropertyName = "ChannelType";
            this.ChannelType.HeaderText = "ChannelType";
            this.ChannelType.Name = "ChannelType";
            this.ChannelType.ReadOnly = true;
            this.ChannelType.Visible = false;
            // 
            // chk_AppliedTogather
            // 
            this.chk_AppliedTogather.AutoSize = true;
            this.chk_AppliedTogather.Location = new System.Drawing.Point(356, 15);
            this.chk_AppliedTogather.Name = "chk_AppliedTogather";
            this.chk_AppliedTogather.Size = new System.Drawing.Size(107, 17);
            this.chk_AppliedTogather.TabIndex = 211;
            this.chk_AppliedTogather.Text = "Applied Togather";
            this.chk_AppliedTogather.UseVisualStyleBackColor = true;
            this.chk_AppliedTogather.CheckedChanged += new System.EventHandler(this.chk_AppliedTogather_CheckedChanged);
            // 
            // gp_AvailableSession
            // 
            this.gp_AvailableSession.Controls.Add(this.dg_AvailableSession);
            this.gp_AvailableSession.Location = new System.Drawing.Point(353, 249);
            this.gp_AvailableSession.Name = "gp_AvailableSession";
            this.gp_AvailableSession.Size = new System.Drawing.Size(336, 183);
            this.gp_AvailableSession.TabIndex = 210;
            this.gp_AvailableSession.TabStop = false;
            this.gp_AvailableSession.Text = "Available Session";
            // 
            // dg_AvailableSession
            // 
            this.dg_AvailableSession.AllowUserToAddRows = false;
            this.dg_AvailableSession.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_AvailableSession.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dg_AvailableSession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_AvailableSession.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IsSelect,
            this.Company_Name,
            this.No_Of_Share,
            this.Amount,
            this.TotalAmount,
            this.Premium});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_AvailableSession.DefaultCellStyle = dataGridViewCellStyle10;
            this.dg_AvailableSession.Location = new System.Drawing.Point(7, 18);
            this.dg_AvailableSession.Name = "dg_AvailableSession";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_AvailableSession.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dg_AvailableSession.RowHeadersVisible = false;
            this.dg_AvailableSession.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_AvailableSession.Size = new System.Drawing.Size(323, 151);
            this.dg_AvailableSession.TabIndex = 1;
            this.dg_AvailableSession.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_AvailableSession_CellClick);
            this.dg_AvailableSession.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_AvailableSession_CellContentClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // IsSelect
            // 
            this.IsSelect.HeaderText = "";
            this.IsSelect.Name = "IsSelect";
            this.IsSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsSelect.Width = 20;
            // 
            // Company_Name
            // 
            this.Company_Name.DataPropertyName = "Company_Name";
            this.Company_Name.HeaderText = "Company Name";
            this.Company_Name.Name = "Company_Name";
            this.Company_Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Company_Name.Width = 160;
            // 
            // No_Of_Share
            // 
            this.No_Of_Share.DataPropertyName = "No_Of_Share";
            this.No_Of_Share.HeaderText = "Qty";
            this.No_Of_Share.Name = "No_Of_Share";
            this.No_Of_Share.Width = 40;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Visible = false;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.Name = "TotalAmount";
            // 
            // Premium
            // 
            this.Premium.DataPropertyName = "Premium";
            this.Premium.HeaderText = "Premium";
            this.Premium.Name = "Premium";
            // 
            // gp_RefundMothod
            // 
            this.gp_RefundMothod.Controls.Add(this.label3);
            this.gp_RefundMothod.Controls.Add(this.txt_Cust_Code_ForTransferParent);
            this.gp_RefundMothod.Controls.Add(this.dg_RefundBankInfo);
            this.gp_RefundMothod.Controls.Add(this.cmb_RefundMethod);
            this.gp_RefundMothod.Controls.Add(this.label1);
            this.gp_RefundMothod.ForeColor = System.Drawing.Color.Black;
            this.gp_RefundMothod.Location = new System.Drawing.Point(354, 51);
            this.gp_RefundMothod.Name = "gp_RefundMothod";
            this.gp_RefundMothod.Size = new System.Drawing.Size(335, 196);
            this.gp_RefundMothod.TabIndex = 209;
            this.gp_RefundMothod.TabStop = false;
            this.gp_RefundMothod.Text = "Refund Method";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Code :";
            // 
            // txt_Cust_Code_ForTransferParent
            // 
            this.txt_Cust_Code_ForTransferParent.Enabled = false;
            this.txt_Cust_Code_ForTransferParent.Location = new System.Drawing.Point(111, 45);
            this.txt_Cust_Code_ForTransferParent.Name = "txt_Cust_Code_ForTransferParent";
            this.txt_Cust_Code_ForTransferParent.Size = new System.Drawing.Size(135, 20);
            this.txt_Cust_Code_ForTransferParent.TabIndex = 7;
            // 
            // dg_RefundBankInfo
            // 
            this.dg_RefundBankInfo.AllowUserToAddRows = false;
            this.dg_RefundBankInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_RefundBankInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dg_RefundBankInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_RefundBankInfo.DefaultCellStyle = dataGridViewCellStyle13;
            this.dg_RefundBankInfo.Location = new System.Drawing.Point(6, 70);
            this.dg_RefundBankInfo.Name = "dg_RefundBankInfo";
            this.dg_RefundBankInfo.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_RefundBankInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dg_RefundBankInfo.RowHeadersVisible = false;
            this.dg_RefundBankInfo.Size = new System.Drawing.Size(323, 119);
            this.dg_RefundBankInfo.TabIndex = 6;
            // 
            // cmb_RefundMethod
            // 
            this.cmb_RefundMethod.FormattingEnabled = true;
            this.cmb_RefundMethod.Location = new System.Drawing.Point(111, 18);
            this.cmb_RefundMethod.Name = "cmb_RefundMethod";
            this.cmb_RefundMethod.Size = new System.Drawing.Size(205, 21);
            this.cmb_RefundMethod.TabIndex = 5;
            this.cmb_RefundMethod.SelectedIndexChanged += new System.EventHandler(this.cmb_RefundMethod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Refund Method :";
            // 
            // dgv_ApplicationStatus
            // 
            this.dgv_ApplicationStatus.AllowUserToAddRows = false;
            this.dgv_ApplicationStatus.AllowUserToDeleteRows = false;
            this.dgv_ApplicationStatus.AllowUserToResizeRows = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_ApplicationStatus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_ApplicationStatus.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ApplicationStatus.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ApplicationStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_ApplicationStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ApplicationStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P_Cust_Code,
            this.Applied_Company,
            this.RefundType,
            this.App_Status});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ApplicationStatus.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgv_ApplicationStatus.Location = new System.Drawing.Point(447, 629);
            this.dgv_ApplicationStatus.Name = "dgv_ApplicationStatus";
            this.dgv_ApplicationStatus.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ApplicationStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgv_ApplicationStatus.RowHeadersVisible = false;
            this.dgv_ApplicationStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ApplicationStatus.Size = new System.Drawing.Size(242, 161);
            this.dgv_ApplicationStatus.TabIndex = 213;
            this.dgv_ApplicationStatus.DataSourceChanged += new System.EventHandler(this.dgv_ApplicationStatus_DataSourceChanged);
            // 
            // P_Cust_Code
            // 
            this.P_Cust_Code.DataPropertyName = "Cust_Code";
            this.P_Cust_Code.HeaderText = "Code";
            this.P_Cust_Code.Name = "P_Cust_Code";
            this.P_Cust_Code.ReadOnly = true;
            this.P_Cust_Code.Width = 50;
            // 
            // Applied_Company
            // 
            this.Applied_Company.DataPropertyName = "Applied_Company";
            this.Applied_Company.FillWeight = 145.1613F;
            this.Applied_Company.HeaderText = "Applied Company";
            this.Applied_Company.Name = "Applied_Company";
            this.Applied_Company.ReadOnly = true;
            this.Applied_Company.Width = 75;
            // 
            // RefundType
            // 
            this.RefundType.DataPropertyName = "RefundType";
            this.RefundType.HeaderText = "Refund";
            this.RefundType.Name = "RefundType";
            this.RefundType.ReadOnly = true;
            this.RefundType.Width = 60;
            // 
            // App_Status
            // 
            this.App_Status.DataPropertyName = "Status";
            this.App_Status.FillWeight = 54.83871F;
            this.App_Status.HeaderText = "Status";
            this.App_Status.Name = "App_Status";
            this.App_Status.ReadOnly = true;
            this.App_Status.Width = 52;
            // 
            // dataGridFilterExtender1
            // 
            this.dataGridFilterExtender1.DataGridView = this.dgv_ApplicationStatus;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this.dataGridFilterExtender1.FilterFactory = defaultGridFilterFactory2;
            this.dataGridFilterExtender1.FilterTextVisible = false;
            // 
            // BtnVerification
            // 
            this.BtnVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVerification.ForeColor = System.Drawing.Color.SaddleBrown;
            this.BtnVerification.Image = ((System.Drawing.Image)(resources.GetObject("BtnVerification.Image")));
            this.BtnVerification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnVerification.Location = new System.Drawing.Point(360, 447);
            this.BtnVerification.Name = "BtnVerification";
            this.BtnVerification.Size = new System.Drawing.Size(74, 25);
            this.BtnVerification.TabIndex = 216;
            this.BtnVerification.Text = "Verify";
            this.BtnVerification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnVerification.UseVisualStyleBackColor = true;
            this.BtnVerification.Click += new System.EventHandler(this.BtnVerification_Click);
            // 
            // btnpublicReport
            // 
            this.btnpublicReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpublicReport.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnpublicReport.Location = new System.Drawing.Point(442, 447);
            this.btnpublicReport.Name = "btnpublicReport";
            this.btnpublicReport.Size = new System.Drawing.Size(74, 25);
            this.btnpublicReport.TabIndex = 218;
            this.btnpublicReport.Text = "Report";
            this.btnpublicReport.UseVisualStyleBackColor = true;
            this.btnpublicReport.Click += new System.EventHandler(this.btnpublicReport_Click);
            // 
            // ChkAffected
            // 
            this.ChkAffected.AutoSize = true;
            this.ChkAffected.Enabled = false;
            this.ChkAffected.Location = new System.Drawing.Point(463, 15);
            this.ChkAffected.Name = "ChkAffected";
            this.ChkAffected.Size = new System.Drawing.Size(146, 17);
            this.ChkAffected.TabIndex = 220;
            this.ChkAffected.Text = "Is Affected Account (ASI)";
            this.ChkAffected.UseVisualStyleBackColor = true;
            // 
            // txtLotNO
            // 
            this.txtLotNO.Location = new System.Drawing.Point(655, 16);
            this.txtLotNO.Multiline = true;
            this.txtLotNO.Name = "txtLotNO";
            this.txtLotNO.Size = new System.Drawing.Size(34, 20);
            this.txtLotNO.TabIndex = 223;
            this.txtLotNO.Text = "1";
            this.txtLotNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(615, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 224;
            this.label5.Text = "Lot No";
            // 
            // panelTransactionCharge
            // 
            this.panelTransactionCharge.Controls.Add(this.txt_TransChrg_TransFromCode);
            this.panelTransactionCharge.Controls.Add(this.txt_TransChrg_PaymentMediaName);
            this.panelTransactionCharge.Controls.Add(this.txt_TransChrg_PaymentMediaID);
            this.panelTransactionCharge.Controls.Add(this.label48);
            this.panelTransactionCharge.Controls.Add(this.txt_TransChrg_TransReason);
            this.panelTransactionCharge.Controls.Add(this.txt_TransChrg_Remarks);
            this.panelTransactionCharge.Controls.Add(this.label36);
            this.panelTransactionCharge.Controls.Add(this.txt_TransChrg_RefNo);
            this.panelTransactionCharge.Controls.Add(this.label20);
            this.panelTransactionCharge.Controls.Add(this.label16);
            this.panelTransactionCharge.Controls.Add(this.txt_TransChrg_ChargedCustCode);
            this.panelTransactionCharge.Controls.Add(this.txt_TransChrg_VoucherNo);
            this.panelTransactionCharge.Controls.Add(this.label12);
            this.panelTransactionCharge.Controls.Add(this.txt_TranChrg_ChagedAmount);
            this.panelTransactionCharge.Controls.Add(this.dtp_TransChrg_ReceivedDate);
            this.panelTransactionCharge.Controls.Add(this.label13);
            this.panelTransactionCharge.Controls.Add(this.label26);
            this.panelTransactionCharge.Location = new System.Drawing.Point(1002, 17);
            this.panelTransactionCharge.Name = "panelTransactionCharge";
            this.panelTransactionCharge.Size = new System.Drawing.Size(296, 203);
            this.panelTransactionCharge.TabIndex = 178;
            // 
            // txt_TransChrg_TransFromCode
            // 
            this.txt_TransChrg_TransFromCode.Location = new System.Drawing.Point(85, 74);
            this.txt_TransChrg_TransFromCode.Name = "txt_TransChrg_TransFromCode";
            this.txt_TransChrg_TransFromCode.Size = new System.Drawing.Size(18, 20);
            this.txt_TransChrg_TransFromCode.TabIndex = 188;
            // 
            // txt_TransChrg_PaymentMediaName
            // 
            this.txt_TransChrg_PaymentMediaName.Location = new System.Drawing.Point(85, 133);
            this.txt_TransChrg_PaymentMediaName.Name = "txt_TransChrg_PaymentMediaName";
            this.txt_TransChrg_PaymentMediaName.Size = new System.Drawing.Size(18, 20);
            this.txt_TransChrg_PaymentMediaName.TabIndex = 187;
            this.txt_TransChrg_PaymentMediaName.Visible = false;
            // 
            // txt_TransChrg_PaymentMediaID
            // 
            this.txt_TransChrg_PaymentMediaID.Location = new System.Drawing.Point(85, 104);
            this.txt_TransChrg_PaymentMediaID.Name = "txt_TransChrg_PaymentMediaID";
            this.txt_TransChrg_PaymentMediaID.Size = new System.Drawing.Size(18, 20);
            this.txt_TransChrg_PaymentMediaID.TabIndex = 186;
            this.txt_TransChrg_PaymentMediaID.Visible = false;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(4, 159);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(71, 13);
            this.label48.TabIndex = 185;
            this.label48.Text = "TransReason";
            // 
            // txt_TransChrg_TransReason
            // 
            this.txt_TransChrg_TransReason.Location = new System.Drawing.Point(133, 156);
            this.txt_TransChrg_TransReason.Name = "txt_TransChrg_TransReason";
            this.txt_TransChrg_TransReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_TransChrg_TransReason.Size = new System.Drawing.Size(148, 20);
            this.txt_TransChrg_TransReason.TabIndex = 184;
            // 
            // txt_TransChrg_Remarks
            // 
            this.txt_TransChrg_Remarks.Location = new System.Drawing.Point(133, 131);
            this.txt_TransChrg_Remarks.Name = "txt_TransChrg_Remarks";
            this.txt_TransChrg_Remarks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_TransChrg_Remarks.Size = new System.Drawing.Size(148, 20);
            this.txt_TransChrg_Remarks.TabIndex = 182;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(4, 134);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(49, 13);
            this.label36.TabIndex = 183;
            this.label36.Text = "Remarks";
            // 
            // txt_TransChrg_RefNo
            // 
            this.txt_TransChrg_RefNo.Location = new System.Drawing.Point(133, 105);
            this.txt_TransChrg_RefNo.Name = "txt_TransChrg_RefNo";
            this.txt_TransChrg_RefNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_TransChrg_RefNo.Size = new System.Drawing.Size(148, 20);
            this.txt_TransChrg_RefNo.TabIndex = 180;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 108);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 13);
            this.label20.TabIndex = 181;
            this.label20.Text = "Reference No";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 13);
            this.label16.TabIndex = 179;
            this.label16.Text = "Charged Cust Code";
            // 
            // txt_TransChrg_ChargedCustCode
            // 
            this.txt_TransChrg_ChargedCustCode.Location = new System.Drawing.Point(133, 5);
            this.txt_TransChrg_ChargedCustCode.Name = "txt_TransChrg_ChargedCustCode";
            this.txt_TransChrg_ChargedCustCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_TransChrg_ChargedCustCode.Size = new System.Drawing.Size(148, 20);
            this.txt_TransChrg_ChargedCustCode.TabIndex = 178;
            // 
            // txt_TransChrg_VoucherNo
            // 
            this.txt_TransChrg_VoucherNo.Location = new System.Drawing.Point(133, 81);
            this.txt_TransChrg_VoucherNo.Name = "txt_TransChrg_VoucherNo";
            this.txt_TransChrg_VoucherNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_TransChrg_VoucherNo.Size = new System.Drawing.Size(148, 20);
            this.txt_TransChrg_VoucherNo.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 177;
            this.label12.Text = "Voucher No";
            // 
            // txt_TranChrg_ChagedAmount
            // 
            this.txt_TranChrg_ChagedAmount.Location = new System.Drawing.Point(133, 55);
            this.txt_TranChrg_ChagedAmount.Name = "txt_TranChrg_ChagedAmount";
            this.txt_TranChrg_ChagedAmount.Size = new System.Drawing.Size(148, 20);
            this.txt_TranChrg_ChagedAmount.TabIndex = 2;
            // 
            // dtp_TransChrg_ReceivedDate
            // 
            this.dtp_TransChrg_ReceivedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtp_TransChrg_ReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TransChrg_ReceivedDate.Location = new System.Drawing.Point(133, 31);
            this.dtp_TransChrg_ReceivedDate.Name = "dtp_TransChrg_ReceivedDate";
            this.dtp_TransChrg_ReceivedDate.Size = new System.Drawing.Size(126, 20);
            this.dtp_TransChrg_ReceivedDate.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 176;
            this.label13.Text = "Received_Date";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(4, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 13);
            this.label26.TabIndex = 173;
            this.label26.Text = "Amount";
            // 
            // chk_TransChrg_IsApplied
            // 
            this.chk_TransChrg_IsApplied.AutoSize = true;
            this.chk_TransChrg_IsApplied.Location = new System.Drawing.Point(500, 32);
            this.chk_TransChrg_IsApplied.Name = "chk_TransChrg_IsApplied";
            this.chk_TransChrg_IsApplied.Size = new System.Drawing.Size(130, 17);
            this.chk_TransChrg_IsApplied.TabIndex = 189;
            this.chk_TransChrg_IsApplied.Text = "IsTransChargeApplied";
            this.chk_TransChrg_IsApplied.UseVisualStyleBackColor = true;
            this.chk_TransChrg_IsApplied.Visible = false;
            // 
            // lbl_dgvPaymentInfo
            // 
            this.lbl_dgvPaymentInfo.AutoSize = true;
            this.lbl_dgvPaymentInfo.Location = new System.Drawing.Point(15, 796);
            this.lbl_dgvPaymentInfo.Name = "lbl_dgvPaymentInfo";
            this.lbl_dgvPaymentInfo.Size = new System.Drawing.Size(47, 13);
            this.lbl_dgvPaymentInfo.TabIndex = 226;
            this.lbl_dgvPaymentInfo.Text = "Count: 0";
            // 
            // lbl_dgvApp
            // 
            this.lbl_dgvApp.AutoSize = true;
            this.lbl_dgvApp.Location = new System.Drawing.Point(448, 796);
            this.lbl_dgvApp.Name = "lbl_dgvApp";
            this.lbl_dgvApp.Size = new System.Drawing.Size(47, 13);
            this.lbl_dgvApp.TabIndex = 227;
            this.lbl_dgvApp.Text = "Count: 0";
            // 
            // dgvEFTbankInfo
            // 
            this.dgvEFTbankInfo.AllowUserToAddRows = false;
            this.dgvEFTbankInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEFTbankInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEFTbankInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEFTbankInfo.Location = new System.Drawing.Point(4, 3);
            this.dgvEFTbankInfo.Name = "dgvEFTbankInfo";
            this.dgvEFTbankInfo.ReadOnly = true;
            this.dgvEFTbankInfo.RowHeadersVisible = false;
            this.dgvEFTbankInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEFTbankInfo.Size = new System.Drawing.Size(337, 118);
            this.dgvEFTbankInfo.TabIndex = 230;
            // 
            // dgPanerlEft
            // 
            this.dgPanerlEft.Controls.Add(this.label49);
            this.dgPanerlEft.Controls.Add(this.btnAutoGenForEFT);
            this.dgPanerlEft.Controls.Add(this.txtAutoGen);
            this.dgPanerlEft.Controls.Add(this.dgvEFTbankInfo);
            this.dgPanerlEft.Location = new System.Drawing.Point(1002, 235);
            this.dgPanerlEft.Name = "dgPanerlEft";
            this.dgPanerlEft.Size = new System.Drawing.Size(337, 175);
            this.dgPanerlEft.TabIndex = 230;
            this.dgPanerlEft.Visible = false;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(7, 133);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(61, 13);
            this.label49.TabIndex = 233;
            this.label49.Text = "VoucherNo";
            // 
            // btnAutoGenForEFT
            // 
            this.btnAutoGenForEFT.Location = new System.Drawing.Point(188, 127);
            this.btnAutoGenForEFT.Name = "btnAutoGenForEFT";
            this.btnAutoGenForEFT.Size = new System.Drawing.Size(45, 23);
            this.btnAutoGenForEFT.TabIndex = 232;
            this.btnAutoGenForEFT.TabStop = false;
            this.btnAutoGenForEFT.Text = "Auto";
            this.btnAutoGenForEFT.UseVisualStyleBackColor = true;
            this.btnAutoGenForEFT.Click += new System.EventHandler(this.btnAutoGenForEFT_Click);
            // 
            // txtAutoGen
            // 
            this.txtAutoGen.Location = new System.Drawing.Point(73, 129);
            this.txtAutoGen.Name = "txtAutoGen";
            this.txtAutoGen.ReadOnly = true;
            this.txtAutoGen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAutoGen.Size = new System.Drawing.Size(113, 20);
            this.txtAutoGen.TabIndex = 231;
            // 
            // pnlwithdraw
            // 
            this.pnlwithdraw.Controls.Add(this.label50);
            this.pnlwithdraw.Controls.Add(this.button1);
            this.pnlwithdraw.Controls.Add(this.textBox1);
            this.pnlwithdraw.Controls.Add(this.dgWithdrawGrid);
            this.pnlwithdraw.Location = new System.Drawing.Point(1002, 415);
            this.pnlwithdraw.Name = "pnlwithdraw";
            this.pnlwithdraw.Size = new System.Drawing.Size(337, 175);
            this.pnlwithdraw.TabIndex = 233;
            this.pnlwithdraw.Visible = false;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(7, 133);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(61, 13);
            this.label50.TabIndex = 233;
            this.label50.Text = "VoucherNo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 232;
            this.button1.TabStop = false;
            this.button1.Text = "Auto";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 231;
            // 
            // dgWithdrawGrid
            // 
            this.dgWithdrawGrid.AllowUserToAddRows = false;
            this.dgWithdrawGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgWithdrawGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgWithdrawGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWithdrawGrid.Location = new System.Drawing.Point(4, 3);
            this.dgWithdrawGrid.Name = "dgWithdrawGrid";
            this.dgWithdrawGrid.ReadOnly = true;
            this.dgWithdrawGrid.RowHeadersVisible = false;
            this.dgWithdrawGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWithdrawGrid.Size = new System.Drawing.Size(337, 118);
            this.dgWithdrawGrid.TabIndex = 230;
            // 
            // panelIPOApplicationCharge
            // 
            this.panelIPOApplicationCharge.Controls.Add(this.chk_AppCharge_IsApplied);
            this.panelIPOApplicationCharge.Controls.Add(this.txt_AppCharge_PaymentMediaName);
            this.panelIPOApplicationCharge.Controls.Add(this.txt_AppCharge_PaymentMediaID);
            this.panelIPOApplicationCharge.Controls.Add(this.label51);
            this.panelIPOApplicationCharge.Controls.Add(this.txt_AppCharge_TransReason);
            this.panelIPOApplicationCharge.Controls.Add(this.txt_AppCharge_Remarks);
            this.panelIPOApplicationCharge.Controls.Add(this.label52);
            this.panelIPOApplicationCharge.Controls.Add(this.txt_AppCharge_ReferenceNo);
            this.panelIPOApplicationCharge.Controls.Add(this.label53);
            this.panelIPOApplicationCharge.Controls.Add(this.label54);
            this.panelIPOApplicationCharge.Controls.Add(this.txt_AppCharge_TransFrom);
            this.panelIPOApplicationCharge.Controls.Add(this.txt_AppCharge_VoucherNo);
            this.panelIPOApplicationCharge.Controls.Add(this.label55);
            this.panelIPOApplicationCharge.Controls.Add(this.txt_AppCharge_Amount);
            this.panelIPOApplicationCharge.Controls.Add(this.dtp_AppCharge_ReceiveDate);
            this.panelIPOApplicationCharge.Controls.Add(this.label56);
            this.panelIPOApplicationCharge.Controls.Add(this.label57);
            this.panelIPOApplicationCharge.Location = new System.Drawing.Point(1002, 593);
            this.panelIPOApplicationCharge.Name = "panelIPOApplicationCharge";
            this.panelIPOApplicationCharge.Size = new System.Drawing.Size(296, 206);
            this.panelIPOApplicationCharge.TabIndex = 236;
            this.panelIPOApplicationCharge.Visible = false;
            // 
            // chk_AppCharge_IsApplied
            // 
            this.chk_AppCharge_IsApplied.AutoSize = true;
            this.chk_AppCharge_IsApplied.Location = new System.Drawing.Point(7, 184);
            this.chk_AppCharge_IsApplied.Name = "chk_AppCharge_IsApplied";
            this.chk_AppCharge_IsApplied.Size = new System.Drawing.Size(140, 17);
            this.chk_AppCharge_IsApplied.TabIndex = 188;
            this.chk_AppCharge_IsApplied.Text = "IsIPOAppChargeApplied";
            this.chk_AppCharge_IsApplied.UseVisualStyleBackColor = true;
            // 
            // txt_AppCharge_PaymentMediaName
            // 
            this.txt_AppCharge_PaymentMediaName.Location = new System.Drawing.Point(85, 133);
            this.txt_AppCharge_PaymentMediaName.Name = "txt_AppCharge_PaymentMediaName";
            this.txt_AppCharge_PaymentMediaName.Size = new System.Drawing.Size(18, 20);
            this.txt_AppCharge_PaymentMediaName.TabIndex = 187;
            this.txt_AppCharge_PaymentMediaName.Visible = false;
            // 
            // txt_AppCharge_PaymentMediaID
            // 
            this.txt_AppCharge_PaymentMediaID.Location = new System.Drawing.Point(85, 104);
            this.txt_AppCharge_PaymentMediaID.Name = "txt_AppCharge_PaymentMediaID";
            this.txt_AppCharge_PaymentMediaID.Size = new System.Drawing.Size(18, 20);
            this.txt_AppCharge_PaymentMediaID.TabIndex = 186;
            this.txt_AppCharge_PaymentMediaID.Visible = false;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(4, 159);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(71, 13);
            this.label51.TabIndex = 185;
            this.label51.Text = "TransReason";
            // 
            // txt_AppCharge_TransReason
            // 
            this.txt_AppCharge_TransReason.Location = new System.Drawing.Point(133, 156);
            this.txt_AppCharge_TransReason.Name = "txt_AppCharge_TransReason";
            this.txt_AppCharge_TransReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_AppCharge_TransReason.Size = new System.Drawing.Size(148, 20);
            this.txt_AppCharge_TransReason.TabIndex = 184;
            this.txt_AppCharge_TransReason.Visible = false;
            // 
            // txt_AppCharge_Remarks
            // 
            this.txt_AppCharge_Remarks.Location = new System.Drawing.Point(133, 131);
            this.txt_AppCharge_Remarks.Name = "txt_AppCharge_Remarks";
            this.txt_AppCharge_Remarks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_AppCharge_Remarks.Size = new System.Drawing.Size(148, 20);
            this.txt_AppCharge_Remarks.TabIndex = 182;
            this.txt_AppCharge_Remarks.Visible = false;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(4, 134);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(49, 13);
            this.label52.TabIndex = 183;
            this.label52.Text = "Remarks";
            // 
            // txt_AppCharge_ReferenceNo
            // 
            this.txt_AppCharge_ReferenceNo.Location = new System.Drawing.Point(133, 105);
            this.txt_AppCharge_ReferenceNo.Name = "txt_AppCharge_ReferenceNo";
            this.txt_AppCharge_ReferenceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_AppCharge_ReferenceNo.Size = new System.Drawing.Size(148, 20);
            this.txt_AppCharge_ReferenceNo.TabIndex = 180;
            this.txt_AppCharge_ReferenceNo.Visible = false;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(4, 108);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(74, 13);
            this.label53.TabIndex = 181;
            this.label53.Text = "Reference No";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(4, 8);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(88, 13);
            this.label54.TabIndex = 179;
            this.label54.Text = "TransFrom_Code";
            // 
            // txt_AppCharge_TransFrom
            // 
            this.txt_AppCharge_TransFrom.Location = new System.Drawing.Point(133, 5);
            this.txt_AppCharge_TransFrom.Name = "txt_AppCharge_TransFrom";
            this.txt_AppCharge_TransFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_AppCharge_TransFrom.Size = new System.Drawing.Size(148, 20);
            this.txt_AppCharge_TransFrom.TabIndex = 178;
            this.txt_AppCharge_TransFrom.Visible = false;
            // 
            // txt_AppCharge_VoucherNo
            // 
            this.txt_AppCharge_VoucherNo.Location = new System.Drawing.Point(133, 81);
            this.txt_AppCharge_VoucherNo.Name = "txt_AppCharge_VoucherNo";
            this.txt_AppCharge_VoucherNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_AppCharge_VoucherNo.Size = new System.Drawing.Size(148, 20);
            this.txt_AppCharge_VoucherNo.TabIndex = 4;
            this.txt_AppCharge_VoucherNo.Visible = false;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(4, 84);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(64, 13);
            this.label55.TabIndex = 177;
            this.label55.Text = "Voucher No";
            // 
            // txt_AppCharge_Amount
            // 
            this.txt_AppCharge_Amount.Location = new System.Drawing.Point(133, 55);
            this.txt_AppCharge_Amount.Name = "txt_AppCharge_Amount";
            this.txt_AppCharge_Amount.Size = new System.Drawing.Size(148, 20);
            this.txt_AppCharge_Amount.TabIndex = 2;
            this.txt_AppCharge_Amount.Visible = false;
            // 
            // dtp_AppCharge_ReceiveDate
            // 
            this.dtp_AppCharge_ReceiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dtp_AppCharge_ReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_AppCharge_ReceiveDate.Location = new System.Drawing.Point(133, 31);
            this.dtp_AppCharge_ReceiveDate.Name = "dtp_AppCharge_ReceiveDate";
            this.dtp_AppCharge_ReceiveDate.Size = new System.Drawing.Size(126, 20);
            this.dtp_AppCharge_ReceiveDate.TabIndex = 1;
            this.dtp_AppCharge_ReceiveDate.Visible = false;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(4, 33);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(82, 13);
            this.label56.TabIndex = 176;
            this.label56.Text = "Received_Date";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(4, 58);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(43, 13);
            this.label57.TabIndex = 173;
            this.label57.Text = "Amount";
            // 
            // ChkNegativeBalanceNotCalculate
            // 
            this.ChkNegativeBalanceNotCalculate.AutoSize = true;
            this.ChkNegativeBalanceNotCalculate.Location = new System.Drawing.Point(211, 18);
            this.ChkNegativeBalanceNotCalculate.Name = "ChkNegativeBalanceNotCalculate";
            this.ChkNegativeBalanceNotCalculate.Size = new System.Drawing.Size(111, 17);
            this.ChkNegativeBalanceNotCalculate.TabIndex = 239;
            this.ChkNegativeBalanceNotCalculate.Text = "Negative Balance";
            this.ChkNegativeBalanceNotCalculate.UseVisualStyleBackColor = true;
            // 
            // frm_IPOPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1038, 751);
            this.Controls.Add(this.panelIPOApplicationCharge);
            this.Controls.Add(this.pnlwithdraw);
            this.Controls.Add(this.chk_TransChrg_IsApplied);
            this.Controls.Add(this.dgPanerlEft);
            this.Controls.Add(this.lbl_dgvApp);
            this.Controls.Add(this.chk_AppliedTogather);
            this.Controls.Add(this.panelTransactionCharge);
            this.Controls.Add(this.lbl_dgvPaymentInfo);
            this.Controls.Add(this.ChkAffected);
            this.Controls.Add(this.dgv_ApplicationStatus);
            this.Controls.Add(this.btnpublicReport);
            this.Controls.Add(this.gp_AvailableSession);
            this.Controls.Add(this.gp_RefundMothod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnVerification);
            this.Controls.Add(this.pnlEFT_Deposit);
            this.Controls.Add(this.txtLotNO);
            this.Controls.Add(this.panelPaymentTransfer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panelPaymentInfo);
            this.Controls.Add(this.panelEFT);
            this.Controls.Add(this.panelChequeDeposit);
            this.Controls.Add(this.dg_Customers);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPaymentInfo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbPaymentInfo);
            this.Controls.Add(this.btnDepositCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_IPOPaymentForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaymentForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDepositWithdraw_KeyDown);
            this.pnlEFT_Deposit.ResumeLayout(false);
            this.pnlEFT_Deposit.PerformLayout();
            this.panelChequeDeposit.ResumeLayout(false);
            this.panelChequeDeposit.PerformLayout();
            this.panelEFT.ResumeLayout(false);
            this.panelEFT.PerformLayout();
            this.panelPaymentTransfer.ResumeLayout(false);
            this.panelPaymentTransfer.PerformLayout();
            this.panelPaymentInfo.ResumeLayout(false);
            this.panelPaymentInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Customers)).EndInit();
            this.gp_AvailableSession.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_AvailableSession)).EndInit();
            this.gp_RefundMothod.ResumeLayout(false);
            this.gp_RefundMothod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_RefundBankInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ApplicationStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilterExtender1)).EndInit();
            this.panelTransactionCharge.ResumeLayout(false);
            this.panelTransactionCharge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEFTbankInfo)).EndInit();
            this.dgPanerlEft.ResumeLayout(false);
            this.dgPanerlEft.PerformLayout();
            this.pnlwithdraw.ResumeLayout(false);
            this.pnlwithdraw.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWithdrawGrid)).EndInit();
            this.panelIPOApplicationCharge.ResumeLayout(false);
            this.panelIPOApplicationCharge.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbPaymentInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGo;
        public System.Windows.Forms.ComboBox ddlSearchCustomer;
        public System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Panel panelPaymentInfo;
        public System.Windows.Forms.TextBox txt_Paypal_VoucherNo;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox txt_Paypal_BranchName;
        public System.Windows.Forms.TextBox txt_Paypal_BankName;
        public System.Windows.Forms.DateTimePicker dtp_Paypal_OrderDate;
        public System.Windows.Forms.TextBox txt_Paypal_OrderNo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panelPaymentTransfer;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSearchTrans;
        private System.Windows.Forms.TextBox txt_Transfer_CustCode;
        public System.Windows.Forms.TextBox txt_Transfer_CustName;
        private System.Windows.Forms.Label label29;
        public System.Windows.Forms.TextBox txt_Transfer_VoucherNo;
        public System.Windows.Forms.TextBox txt_Transfer_Balance;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRecievedBy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtRecievedDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddlDepositWithdraw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkMatureToday;
        private System.Windows.Forms.ComboBox ddlPaymentMedia;
        private System.Windows.Forms.DataGridView dgvPaymentInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpSearchPaymentEntry;
        private System.Windows.Forms.Label label27;
        private GridViewExtensions.DataGridFilterExtender dgvExtension;
        private System.Windows.Forms.Panel panelEFT;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txt_EftWithdraw_RoutingNo;
        public System.Windows.Forms.TextBox txt_EftWithdraw_BankName;
        private System.Windows.Forms.Label label32;
        public System.Windows.Forms.TextBox txt_EftWithdraw_VoucherNo;
        public System.Windows.Forms.TextBox txt_EftWithdraw_BranchName;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btneftAutoVoucher;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txt_EftWithdraw_BankAccNo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssTotalRecord;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDepositCancel;
        private System.Windows.Forms.Button btnDWReturnInfo;
        private System.Windows.Forms.Panel pnlEFT_Deposit;
        private System.Windows.Forms.Button btnEftCheckDepositAutogen;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txt_DepositEft_BankAccountNo;
        private System.Windows.Forms.Label label39;
        public System.Windows.Forms.TextBox txt_DepositEft_VoucherNo;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox ddl_DepositEft_Branch_Name;
        private System.Windows.Forms.ComboBox ddl_DepositEft_Bank_Name;
        private System.Windows.Forms.Panel panelChequeDeposit;
        public System.Windows.Forms.TextBox txt_DepositCheque_VoucherNo;
        private System.Windows.Forms.Label label42;
        public System.Windows.Forms.DateTimePicker dtp_DepositChequeDate;
        public System.Windows.Forms.TextBox txtDepositChequeNo;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox ddl_DepositCheque_BranchName;
        private System.Windows.Forms.ComboBox ddl_DepositCheque_BankName;
        private System.Windows.Forms.TextBox txtEFTBranchID;
        private System.Windows.Forms.TextBox txtEFTBankID;
        private System.Windows.Forms.ComboBox ddl_DepositEft_RoutingNo;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddl_DepositCheque_RoutingNo;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button btnWebData;
        private System.Windows.Forms.Button btnAutoGen;
        private System.Windows.Forms.DataGridView dg_Customers;

        private System.Windows.Forms.TextBox txt_Distributed_Amount;
        private System.Windows.Forms.CheckBox chk_AppliedTogather;
        private System.Windows.Forms.GroupBox gp_AvailableSession;
        private System.Windows.Forms.DataGridView dg_AvailableSession;
        private System.Windows.Forms.GroupBox gp_RefundMothod;
        private System.Windows.Forms.ComboBox cmb_RefundMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MinBalance;
        private System.Windows.Forms.TextBox txt_CustCodeHidden;
        private System.Windows.Forms.DataGridView dg_RefundBankInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_Of_Share;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Premium;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Cust_Code_ForTransferParent;
        private System.Windows.Forms.DataGridView dgv_ApplicationStatus;
        private GridViewExtensions.DataGridFilterExtender dataGridFilterExtender1;
        private System.Windows.Forms.Button BtnVerification;
        private System.Windows.Forms.Button btnpublicReport;
        private System.Windows.Forms.CheckBox ChkAffected;
        private System.Windows.Forms.Label LabelCount;
        private System.Windows.Forms.TextBox txtLotNO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelTransactionCharge;
        public System.Windows.Forms.TextBox txt_TransChrg_VoucherNo;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txt_TranChrg_ChagedAmount;
        public System.Windows.Forms.DateTimePicker dtp_TransChrg_ReceivedDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txt_TransChrg_ChargedCustCode;
        public System.Windows.Forms.TextBox txt_TransChrg_RefNo;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txt_TransChrg_Remarks;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label48;
        public System.Windows.Forms.TextBox txt_TransChrg_TransReason;
        private System.Windows.Forms.TextBox txt_RequiredTranCharge;
        private System.Windows.Forms.Button btn_Cancel_TransChrgTaken;
        private System.Windows.Forms.Label lbl_dgvPaymentInfo;
        private System.Windows.Forms.Label lbl_dgvApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Cust_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Applied_Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefundType;
        private System.Windows.Forms.DataGridViewTextBoxColumn App_Status;
        private System.Windows.Forms.DataGridView dgvEFTbankInfo;
        private System.Windows.Forms.Panel dgPanerlEft;
        private System.Windows.Forms.Button btnAutoGenForEFT;
        public System.Windows.Forms.TextBox txtAutoGen;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Panel pnlwithdraw;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgWithdrawGrid;
        private System.Windows.Forms.Button btnSms;
        private System.Windows.Forms.TextBox txt_ChannelType;
        private System.Windows.Forms.TextBox txt_ChannelID;
        private System.Windows.Forms.TextBox txt_TransChrg_PaymentMediaID;
        private System.Windows.Forms.TextBox txt_TransChrg_PaymentMediaName;
        private System.Windows.Forms.Panel panelIPOApplicationCharge;
        private System.Windows.Forms.TextBox txt_AppCharge_PaymentMediaName;
        private System.Windows.Forms.TextBox txt_AppCharge_PaymentMediaID;
        private System.Windows.Forms.Label label51;
        public System.Windows.Forms.TextBox txt_AppCharge_TransReason;
        public System.Windows.Forms.TextBox txt_AppCharge_Remarks;
        private System.Windows.Forms.Label label52;
        public System.Windows.Forms.TextBox txt_AppCharge_ReferenceNo;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        public System.Windows.Forms.TextBox txt_AppCharge_TransFrom;
        public System.Windows.Forms.TextBox txt_AppCharge_VoucherNo;
        private System.Windows.Forms.Label label55;
        public System.Windows.Forms.TextBox txt_AppCharge_Amount;
        public System.Windows.Forms.DateTimePicker dtp_AppCharge_ReceiveDate;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txt_TransChrg_TransFromCode;
        private System.Windows.Forms.CheckBox chk_AppCharge_IsApplied;
        private System.Windows.Forms.CheckBox chk_TransChrg_IsApplied;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChargable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cust_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPO_Mone_Bal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distributed_Amount;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAccNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoutingNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelType;
        private System.Windows.Forms.Button btnEftReturn;
        public System.Windows.Forms.TextBox txtAccruedBalance;
        private System.Windows.Forms.Label label58;
        public System.Windows.Forms.TextBox txtAvailableWithdrawBalance;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.CheckBox ChkNegativeBalanceNotCalculate;
    }
}
