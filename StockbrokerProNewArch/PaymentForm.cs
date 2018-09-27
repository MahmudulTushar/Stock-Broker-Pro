﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using Reports;
using CrystalDecisions.CrystalReports.Engine;
using BusinessAccessLayer.Constants;
using System.Reflection;
using System.Drawing;
using System.Linq;



namespace StockbrokerProNewArch 
{
    public partial class PaymentForm : Form
    {
        #region Global Variable

        private string CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return = "CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return";
        private string EFT_Voucher_Autogen = "(Auto Gen)";
        private string _bank_branch_Entry_For_Deposit = "Bank_Branch_Entry_For_EFT/Check_Deposit";

        private int OnlineOrderNo;
        private DateTime? OnlineEntry_Date;

        Form form;
        private TextBox ControlToFocus = new TextBox();
        private PaymentInfoBO paymentInfoBo = new PaymentInfoBO();
        private string _boID = "";
        private string _custCode = "";
        private float chkTRBalance = 0;
        private float chkAmount = 0;
        private string MenuName;

        private string Transfer_Not_Allowed;
        private string EFT_Not_Allowed;
        private string _status;
        private long _paymentID;
        private string _transReason;
        private bool _formLoad = false;
        private string routingNoText = "";
        private List<KeyValuePair<string, string>> Mapping_PaymentTransaction;
        private Dictionary<string, object> PaymentForm_Cache = new Dictionary<string, object>();
        private List<EnterIndexType> EnterIndex = new List<EnterIndexType>();

        private List<string> PrevilizePaymentMedia = new List<string>();

        private string[] Deposit;
        private string[] Withdraw;
        bool isSearchedBankBranchIdByRoutingNo = false;

        string Channel = string.Empty;

        #endregion Global Variable

        #region Collection

        private struct PaymentMethods
        {
            public string Cash;
            public string Cash_Return;
            public string Ecash;
            public string Cheque;
            public string Cheque_Return;
            public string EFT;
            public string EFT_Return;
            public string PayOrder;
            public string PayOrder_Return;
            public string PayPal;
            public string PayPal_Return;
            public string TR;
           // public string TR_Return;
        };
        private struct EnterIndexType
        {
            public string DipsitWithdraw;
            public string PaymentMedia;
            public string ControlName;
            public Type T;
            public int Index;
        };
        private struct TransactionType
        {
            public string Deposit;
            public string Withdraw;
        };

        private readonly TransactionType depositWithdraw = new TransactionType { Deposit = "Deposit", Withdraw = "Withdraw" };
        private readonly PaymentMethods payMethodsObj = new PaymentMethods { Cash = "Cash", Cash_Return = "Cash Return", Ecash = "Ecash", Cheque = "Cheque", Cheque_Return = "Cheque Return", EFT = "EFT", EFT_Return = "EFT Return", PayOrder = "Pay Order", PayOrder_Return = "Pay Order Return", PayPal = "Paypal", PayPal_Return = "Paypal Return", TR = "Transfer" };
        private enum PaymentMedia { Cash, Cash_Return, Ecash, Cheque, Cheque_Return, EFT, EFT_Return, Pay_Order, Pay_Order_Return, Paypal, Paypal_Return, Transfer };

        //---------------------------Previllize List stored same in Database------------------------//
        private List<string> PrevillizedPaymentMedia = new List<string> 
        {
            Indication_PaymentForm_Previllize.Cash_Deposit,
            Indication_PaymentForm_Previllize.Cash_Deposit_Return,
            Indication_PaymentForm_Previllize.Cash_Withdraw,
            Indication_PaymentForm_Previllize.Cash_Withdraw_Return,
            Indication_PaymentForm_Previllize.Ecash_Deposit,
            Indication_PaymentForm_Previllize.Cheque_Deposit,
            Indication_PaymentForm_Previllize.Cheque_Deposit_Return,
            Indication_PaymentForm_Previllize.EFT_Deposit,
            Indication_PaymentForm_Previllize.EFT_Deposit_Return,
            Indication_PaymentForm_Previllize.EFT_Withdraw,
            Indication_PaymentForm_Previllize.EFT_Withdraw_Return,
            Indication_PaymentForm_Previllize.Payorder_Deposi,
            Indication_PaymentForm_Previllize.Payorder_Deposit_Return,
            Indication_PaymentForm_Previllize.Payorder_Withdraw,
            Indication_PaymentForm_Previllize.Payorder_Withdraw_Return,
            Indication_PaymentForm_Previllize.Paypal_Deposit,
            Indication_PaymentForm_Previllize.Paypal_Deposit_Return,
            Indication_PaymentForm_Previllize.Paypal_Withdraw,
            Indication_PaymentForm_Previllize.Paypal_Withdraw_Return,
            Indication_PaymentForm_Previllize.Deposit_Transfer,
            Indication_PaymentForm_Previllize.Withdraw_Transfer
        };
        #endregion Collection

        #region Constructor
        public PaymentForm(string menuName)
        {
            InitializeComponent();
            SetPermission();
            Initialize_DepositWithdrawComboDatasource();
            Initialize_Mapping_PaymentTransaction();
            Populate_EnterIdex();
            MenuName = menuName;
            LoadBank_Branch_Routing_Info();
           // _menuPurpose = menuName;
            //EnterIndex_Execution(depositWithdraw.Withdraw, payMethodsObj.EFT, txtAmount.Name);
            //Initialize_PaymentMethodsDatasource(ddlDepositWithdraw.Text);
            //LoadPrevillize();
        }
        public PaymentForm()
        {
            InitializeComponent();
            Initialize_DepositWithdrawComboDatasource();
            Initialize_Mapping_PaymentTransaction();
            SetPermission();
            Populate_EnterIdex();
            LoadBank_Branch_Routing_Info();
            //EnterIndex_Execution(depositWithdraw.Withdraw,payMethodsObj.EFT,txtAmount.Name);
            //Initialize_PaymentMethodsDatasource(ddlDepositWithdraw.Text);
            //LoadPrevillize();
        }

        #endregion Constructor
        private void SetPermission()
        {
            DataTable data = new DataTable();
            SecerityInfoBAL sec = new SecerityInfoBAL();
            Transfer_Not_Allowed = "";
            EFT_Not_Allowed = "";
            data = sec.GetPermission();
            if (data.Rows.Count > 0)
            {
                if (data.Rows.Count > 1)
                {
                    Transfer_Not_Allowed = data.Rows[0][0].ToString();
                    EFT_Not_Allowed = data.Rows[1][0].ToString();
                }
                else
                {
                    if (data.Rows[0][0].ToString() == "Transfer Not Allowed")
                    {
                        Transfer_Not_Allowed = data.Rows[0][0].ToString();
                    }
                    else
                    {
                        EFT_Not_Allowed = data.Rows[0][0].ToString();
                    }
                }

                if (Transfer_Not_Allowed == "Transfer Not Allowed" && EFT_Not_Allowed == "EFT Not Allowed")
                {
                    Initialize_DepositWithdrawArray(Transfer_Not_Allowed, EFT_Not_Allowed);
                }
                else if (Transfer_Not_Allowed == "Transfer Not Allowed" && EFT_Not_Allowed == "")
                {
                    Initialize_DepositWithdrawArray(Transfer_Not_Allowed);
                }
                else if (Transfer_Not_Allowed == "" && EFT_Not_Allowed == "EFT Not Allowed")
                {
                    Initialize_DepositWithdrawArray(EFT_Not_Allowed);
                }
            }
            else
            {
                Initialize_DepositWithdrawArray();
            }
        }

        private void Resize()
        {
            this.Size = new Size(683, 668);
            this.gbPaymentInfo.Controls.Add(this.panelPaymentInfo);
            this.gbPaymentInfo.Controls.Add(this.pnlEFT_Deposit);
            this.gbPaymentInfo.Controls.Add(this.pnlDepositWithBankBranchCombo);
            this.gbPaymentInfo.Controls.Add(this.panelEFT);
            this.gbPaymentInfo.Controls.Add(this.panelPaymentTransfer);
            
            this.panelPaymentInfo.Location = new Point(8, 19);
            this.pnlEFT_Deposit.Location = new Point(8, 19);
            this.pnlDepositWithBankBranchCombo.Location = new Point(8, 19);
            this.panelEFT.Location = new Point(8, 19);
            this.panelPaymentTransfer.Location = new Point(8, 19);
        }
        private void Initialize_PaymentMethodsDatasource(string state)
        {
            if (state == depositWithdraw.Deposit)
            {
                LoadDepositCombo();
                //ddlPaymentMedia.DataSource = Deposit;
                if (ddlPaymentMedia.Items.Count > 0)
                    ddlPaymentMedia.SelectedIndex = 0;
            }
            else if (state == depositWithdraw.Withdraw)
            {
                //ddlPaymentMedia.DataSource = Withdraw;
                LoadWithdrawCombo();
                if (ddlPaymentMedia.Items.Count > 0)
                    ddlPaymentMedia.SelectedIndex = 0;
            }
        }
        private void Populate_EnterIdex()
        {
            //EFT MODE
            EnterIndex.Add(new EnterIndexType() { DipsitWithdraw = depositWithdraw.Withdraw, PaymentMedia = payMethodsObj.EFT, ControlName = txtSearchCustomer.Name, T = txtSearchCustomer.GetType(), Index = 0 });
            EnterIndex.Add(new EnterIndexType() { DipsitWithdraw = depositWithdraw.Withdraw, PaymentMedia = payMethodsObj.EFT, ControlName = txtAmount.Name, T = txtAmount.GetType(), Index = 1 });
            EnterIndex.Add(new EnterIndexType() { DipsitWithdraw = depositWithdraw.Withdraw, PaymentMedia = payMethodsObj.EFT, ControlName = txtVoucherNo.Name, T = txtVoucherNo.GetType(), Index = 2 });
            EnterIndex.Add(new EnterIndexType() { DipsitWithdraw = depositWithdraw.Withdraw, PaymentMedia = payMethodsObj.EFT, ControlName = btnSave.Name, T = btnSave.GetType(), Index = 3 });
        }
        private void EnterIndex_Execution(string depwith, string paymentMedia, string controlName)
        {
            int currentIndex = 0;
            string controlName_Temp = string.Empty;

            var tempObj_Index = EnterIndex.Find(t => t.DipsitWithdraw == depwith && t.PaymentMedia == paymentMedia && t.ControlName == controlName);
            currentIndex = tempObj_Index.Index;
            currentIndex = currentIndex + 1;

            var tempObj_ControlName = EnterIndex.Find(t => t.DipsitWithdraw == depwith && t.PaymentMedia == paymentMedia && t.Index == currentIndex);
            controlName_Temp = tempObj_ControlName.ControlName;

            var controlType_Temp = EnterIndex.Find(t => t.DipsitWithdraw == depwith && t.PaymentMedia == paymentMedia && t.Index == currentIndex).T;

            FieldInfo fldControl = this.GetType().GetField(controlName_Temp, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            object control = fldControl.GetValue(this);
            MethodInfo methInfo = control.GetType().GetMethod("Focus");
            object result = methInfo.Invoke(control, null);
            PropertyInfo propInfo = control.GetType().GetProperty("Focused");
            //var  fldInfo.GetValue(this);

        }
        private void Initialize_DepositWithdrawComboDatasource()
        {
            ddlDepositWithdraw.Items.Clear();
            string[] depwith_Temp = new string[] { depositWithdraw.Deposit, depositWithdraw.Withdraw };
            foreach (var obj in depwith_Temp)
                ddlDepositWithdraw.Items.Add(obj);
        }
        private void Initialize_DepositWithdrawArray()
        {
            Deposit = new string[] { payMethodsObj.Cash, payMethodsObj.Cash_Return,payMethodsObj.Ecash, payMethodsObj.Cheque, payMethodsObj.Cheque_Return, payMethodsObj.EFT, payMethodsObj.EFT_Return, payMethodsObj.PayOrder, payMethodsObj.PayOrder_Return, payMethodsObj.PayPal, payMethodsObj.PayPal_Return, payMethodsObj.TR };
            Withdraw = new string[] { payMethodsObj.Cash, payMethodsObj.Cash_Return, payMethodsObj.EFT, payMethodsObj.EFT_Return, payMethodsObj.PayOrder, payMethodsObj.PayOrder_Return, payMethodsObj.PayPal, payMethodsObj.PayPal_Return, payMethodsObj.TR };
        }

        private void Initialize_DepositWithdrawArray(string Permission)
        {
            if (Permission == "Transfer Not Allowed")
            {
                Deposit = new string[] { payMethodsObj.Cash, payMethodsObj.Cash_Return, payMethodsObj.Ecash, payMethodsObj.Cheque, payMethodsObj.Cheque_Return, payMethodsObj.EFT, payMethodsObj.EFT_Return, payMethodsObj.PayOrder, payMethodsObj.PayOrder_Return, payMethodsObj.PayPal, payMethodsObj.PayPal_Return };
                Withdraw = new string[] { payMethodsObj.Cash, payMethodsObj.Cash_Return, payMethodsObj.EFT, payMethodsObj.EFT_Return, payMethodsObj.PayOrder, payMethodsObj.PayOrder_Return, payMethodsObj.PayPal, payMethodsObj.PayPal_Return };
            }
            else
            {
                Deposit = new string[] { payMethodsObj.Cash, payMethodsObj.Ecash, payMethodsObj.Cheque, payMethodsObj.PayOrder, payMethodsObj.PayPal, payMethodsObj.TR };
                Withdraw = new string[] { payMethodsObj.Cash, payMethodsObj.PayOrder, payMethodsObj.PayPal, payMethodsObj.TR };
            }
        }

        private void Initialize_DepositWithdrawArray(string TransferNotAllowed, string EFTNotAllowed)
        {
            Deposit = new string[] { payMethodsObj.Cash, payMethodsObj.Ecash, payMethodsObj.Cheque, payMethodsObj.PayOrder, payMethodsObj.PayPal };
            Withdraw = new string[] { payMethodsObj.Cash, payMethodsObj.PayOrder, payMethodsObj.PayPal };
        }

        private void Initialize_Mapping_PaymentTransaction()
        {
            Mapping_PaymentTransaction = new List<KeyValuePair<string, string>>();

            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.Cash, Indication_PaymentTransaction.Cash));
            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.Cash_Return, Indication_PaymentTransaction.Cash_Return));
            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.Ecash, Indication_PaymentTransaction.Ecash));

            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.Cheque, Indication_PaymentTransaction.Cheque));
            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.Cheque_Return, Indication_PaymentTransaction.Cheque_Return));

            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.EFT, Indication_PaymentTransaction.EFT));
            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.EFT_Return, Indication_PaymentTransaction.EFT_Return));

            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.PayOrder, Indication_PaymentTransaction.Pay_Order));
            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.PayOrder_Return, Indication_PaymentTransaction.Pay_Order_Return));

            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.PayPal, Indication_PaymentTransaction.Pay_Pal));
            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.PayPal_Return, Indication_PaymentTransaction.Pay_Pal_Return));

            Mapping_PaymentTransaction.Add(new KeyValuePair<string, string>(payMethodsObj.TR, Indication_PaymentTransaction.TR));
        }
        public void SetNon_ReturnMode()
        {
//            txtSearchCustomer.ReadOnly = false;
            //if (!_formLoad)
            //{
            //    SearchCustomerInformation();
            //}
 //           txtCustCode.ReadOnly = false;
 //           btnGo.Enabled = true;
            txtAmount.ReadOnly = false;
            dtRecievedDate.Enabled = false;
            // ddlDepositWithdraw.Text = Deposit_Withdraw_ReturnBO.DW;
            btnDWReturnInfo.Enabled = false;
            if ((ddlPaymentMedia.Text == payMethodsObj.Cash||ddlPaymentMedia.Text == payMethodsObj.Ecash ) && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                txtPaymentMedia.Enabled = false;
                dtPaymentMediaDate.Enabled = false;
                txtBankName.Enabled = false;
                txtBranchName.Enabled = false;
                txtSerialNo.ReadOnly = false;
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.Cheque && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                txtDepositPaymentMedia.ReadOnly = false;
                dtPaymentMediaDate.Enabled = true;
                ddlDepositBankName.Enabled = true;
                ddlDepositBranchName.Enabled = true;
                ddlDepositRoutingNo.Enabled = true;
                txtDepositVoucherNo.ReadOnly = false;

            }
            else if (ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Withdraw )
            {
                if (txtSearchCustomer.Text != "")
                {
                    SearchRoutingInformation();
                }
                txteftBankName.ReadOnly = true;
                txteftBankBranchName.ReadOnly = true;
                txteftRoutingNo.ReadOnly = true;
                txtBankAccNo.ReadOnly = true;
                txteftVoucherNo.ReadOnly = true;
                btneftAutoVoucher.Enabled = true;
            }

            else if (ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
            {
                //Search_BankBranchComboDataForDeposit();
                ddlEftDepositBankName.Enabled = false;
                ddlEftDepositBranchName.Enabled = false;
                ddlEftDepositRoutingNo.Enabled = false;
                txtEftDepositBankAccNo.Enabled = false;
                txtEftDepositVoucherNo.ReadOnly = false;
                //btnEftCheckDepositAutogen.Enabled = true;

            }

            else if (ddlPaymentMedia.Text == payMethodsObj.PayOrder && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                txtDepositPaymentMedia.ReadOnly = false;
                dtPaymentMediaDate.Enabled = true;
                ddlDepositBankName.Enabled = true;
                ddlDepositBranchName.Enabled = true;
                ddlDepositRoutingNo.Enabled = true;
                txtDepositVoucherNo.ReadOnly = false;
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.PayPal && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                txtDepositPaymentMedia.ReadOnly = false;
                dtPaymentMediaDate.Enabled = true;
                ddlDepositBankName.Enabled = true;
                ddlDepositBranchName.Enabled = true;
                ddlDepositRoutingNo.Enabled = true;
                txtDepositVoucherNo.ReadOnly = false;
            }
        }

        public void SetDW_ReturnMode()
        {
//            txtSearchCustomer.ReadOnly = true;
 //           SearchCustomerInformation();
//            btnGo.Enabled = false;
            txtCustCode.ReadOnly = true;
            txtAmount.ReadOnly = true;
            dtRecievedDate.Enabled = true;
            // ddlDepositWithdraw.Text = Deposit_Withdraw_ReturnBO.DW;
            btnDWReturnInfo.Enabled = true;
            if (ddlPaymentMedia.Text == payMethodsObj.Cash_Return && (ddlDepositWithdraw.Text==depositWithdraw.Withdraw || ddlDepositWithdraw.Text==depositWithdraw.Deposit))
            {
                txtPaymentMedia.Enabled = false;
                dtPaymentMediaDate.Enabled = false;
                txtBankName.Enabled = false;
                txtBranchName.Enabled = false;
                txtSerialNo.ReadOnly = false;
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.Cheque_Return && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                txtDepositPaymentMedia.ReadOnly = true;
                dtPaymentMediaDate.Enabled = false;
                ddlDepositBankName.Enabled = false;
                ddlDepositBranchName.Enabled = false;
                ddlDepositRoutingNo.Enabled = false;
                txtDepositVoucherNo.ReadOnly = false;
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.EFT_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
            {
  //            SearchRoutingInformation();
                ClearEFTInformation();
                txteftBankName.ReadOnly = true;
                txteftBankBranchName.ReadOnly = true;
                txteftRoutingNo.ReadOnly = true;
                txtBankAccNo.ReadOnly = true;
                txteftVoucherNo.ReadOnly = false;
                btneftAutoVoucher.Enabled = false;

            }

            else if (ddlPaymentMedia.Text == payMethodsObj.EFT_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
            {
                
               // ClearEFTInformation();
                ClearEFTDepositInformation();
                ddlEftDepositBankName.Enabled = false;
                ddlEftDepositBranchName.Enabled = false;
                ddlEftDepositRoutingNo.Enabled = false;
                txtEftDepositBankAccNo.ReadOnly = true;
                txtEftDepositVoucherNo.ReadOnly = false;
              //  btnEftCheckDepositAutogen.Enabled = false;

            }
            else if (ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                txtDepositPaymentMedia.ReadOnly = true;
                dtPaymentMediaDate.Enabled = false;
                ddlDepositBankName.Enabled = false;
                ddlDepositBranchName.Enabled = false;
                ddlDepositRoutingNo.Enabled = false;
                txtDepositVoucherNo.ReadOnly = false;
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.PayPal_Return && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                txtDepositPaymentMedia.ReadOnly = true;
                dtPaymentMediaDate.Enabled = false;
                ddlDepositBankName.Enabled = false;
                ddlDepositBranchName.Enabled = false;
                ddlDepositRoutingNo.Enabled = false;
                txtDepositVoucherNo.ReadOnly = false;
            }
        }
        private void ClearEFTInformation()
        {
            txteftBankName.Text = "";
            txteftBankBranchName.Text = "";
            txteftRoutingNo.Text = "";
            txtBankAccNo.Text = "";
            txteftVoucherNo.Text = "";
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
        }

        private void ClearEFTDepositInformation()
        {
            ddlEftDepositBankName.SelectedIndex = -1;
            ddlEftDepositBranchName.SelectedIndex = -1;
            ddlEftDepositRoutingNo.Text = "";
            txtEftDepositBankAccNo.Text = "";
            txtEftDepositVoucherNo.Text = "";
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
        }

        public void SetDW_ReturnInformation()
        {
          //  txtSearchCustomer.Text = Deposit_Withdraw_ReturnBO.Code;
          //  SearchCustomerInformation();
            //txtCustCode.Text = Deposit_Withdraw_ReturnBO.Code;
            txtAmount.Text = Deposit_Withdraw_ReturnBO.Amount.ToString();
           // dtRecievedDate.Value = Deposit_Withdraw_ReturnBO.Recdate;
            // ddlDepositWithdraw.Text = Deposit_Withdraw_ReturnBO.DW;

            if (ddlPaymentMedia.Text == payMethodsObj.Cash_Return)
            {
                string[] temp = ddlPaymentMedia.Text.Split(' ');
                txtSerialNo.Text = Deposit_Withdraw_ReturnBO.Voucher;
                // _transReason = temp[0] + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();// +Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value;
                _transReason = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();
                txtSerialNo.Focus();
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.Cheque_Return && ddlDepositWithdraw.Text== depositWithdraw.Withdraw)
            {
                txtDepositPaymentMedia.Text = Deposit_Withdraw_ReturnBO.P_MediaNo;
                dtPaymentMediaDate.Value = Deposit_Withdraw_ReturnBO.P_Mediadate;
                ddlDepositBankName.SelectedValue = Deposit_Withdraw_ReturnBO.Bank_ID;
                ddlDepositBranchName.SelectedValue = Deposit_Withdraw_ReturnBO.Branch_ID;
                ddlDepositRoutingNo.SelectedValue = Deposit_Withdraw_ReturnBO.RoutingNo;
                txtDepositVoucherNo.Text = Deposit_Withdraw_ReturnBO.Voucher;
                _transReason = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();
            }

            else if (ddlPaymentMedia.Text == payMethodsObj.Cheque_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
            {
                txtDepositPaymentMedia.Text = Deposit_Withdraw_ReturnBO.P_MediaNo;
                dtPaymentMediaDate.Value = Deposit_Withdraw_ReturnBO.P_Mediadate;
                ddlDepositBankName.SelectedValue = Deposit_Withdraw_ReturnBO.Bank_ID;
                ddlDepositBranchName.SelectedValue = Deposit_Withdraw_ReturnBO.Branch_ID;
                ddlDepositRoutingNo.SelectedValue = Deposit_Withdraw_ReturnBO.RoutingNo;
                txtDepositVoucherNo.Text = Deposit_Withdraw_ReturnBO.Voucher;
                _transReason = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.EFT_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
            {
              //  SearchRoutingInformation();
                txteftBankName.Text = Deposit_Withdraw_ReturnBO.Bank_Name;
                txteftBankBranchName.Text = Deposit_Withdraw_ReturnBO.Bank_Branch;
                txteftRoutingNo.Text = Deposit_Withdraw_ReturnBO.RoutingNo;
                txtBankAccNo.Text = Deposit_Withdraw_ReturnBO.BankAccNo;
                txteftVoucherNo.Text = Deposit_Withdraw_ReturnBO.Voucher;
                txtEFTBankID.Text = Deposit_Withdraw_ReturnBO.Bank_ID.ToString();
                txtEFTBranchID.Text = Deposit_Withdraw_ReturnBO.Branch_ID.ToString();
                _transReason = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.EFT_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
            {
                //  SearchRoutingInformation();
                ddlEftDepositBankName.Text = Deposit_Withdraw_ReturnBO.Bank_Name;
                ddlEftDepositBranchName.Text = Deposit_Withdraw_ReturnBO.Bank_Branch;
                ddlEftDepositRoutingNo.Text = Deposit_Withdraw_ReturnBO.RoutingNo;
                txtEftDepositBankAccNo.Text = Deposit_Withdraw_ReturnBO.BankAccNo;
                txtEftDepositVoucherNo.Text = Deposit_Withdraw_ReturnBO.Voucher;
                ddlDepositBankName.SelectedValue = Deposit_Withdraw_ReturnBO.Bank_ID;
                ddlDepositBranchName.SelectedValue = Deposit_Withdraw_ReturnBO.Branch_ID;

                _transReason = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
            {
                txtDepositPaymentMedia.Text = Deposit_Withdraw_ReturnBO.P_MediaNo;
                dtPaymentMediaDate.Value = Deposit_Withdraw_ReturnBO.P_Mediadate;
                ddlDepositBankName.SelectedValue = Deposit_Withdraw_ReturnBO.Bank_ID;
                ddlDepositBranchName.SelectedValue = Deposit_Withdraw_ReturnBO.Branch_ID;
                ddlDepositRoutingNo.SelectedValue = Deposit_Withdraw_ReturnBO.RoutingNo;
                txtDepositVoucherNo.Text = Deposit_Withdraw_ReturnBO.Voucher;
                _transReason = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();
            }

            else if (ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
            {
                txtDepositPaymentMedia.Text = Deposit_Withdraw_ReturnBO.P_MediaNo;
                dtPaymentMediaDate.Value = Deposit_Withdraw_ReturnBO.P_Mediadate;
                ddlDepositBankName.SelectedValue = Deposit_Withdraw_ReturnBO.Bank_ID;
                ddlDepositBranchName.SelectedValue = Deposit_Withdraw_ReturnBO.Branch_ID;
                ddlDepositRoutingNo.SelectedValue = Deposit_Withdraw_ReturnBO.RoutingNo;
                txtDepositVoucherNo.Text = Deposit_Withdraw_ReturnBO.Voucher;
                _transReason = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();
            }
            else if (ddlPaymentMedia.Text == payMethodsObj.PayPal_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
            {
                txtDepositPaymentMedia.Text = Deposit_Withdraw_ReturnBO.P_MediaNo;
                dtPaymentMediaDate.Value = Deposit_Withdraw_ReturnBO.P_Mediadate;
                ddlDepositBankName.SelectedValue = Deposit_Withdraw_ReturnBO.Bank_ID;
                ddlDepositBranchName.SelectedValue = Deposit_Withdraw_ReturnBO.Branch_ID;
                ddlDepositRoutingNo.SelectedValue = Deposit_Withdraw_ReturnBO.RoutingNo;
                txtDepositVoucherNo.Text = Deposit_Withdraw_ReturnBO.Voucher;
                _transReason = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();
            }

            else if (ddlPaymentMedia.Text == payMethodsObj.PayPal_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
            {
                txtDepositPaymentMedia.Text = Deposit_Withdraw_ReturnBO.P_MediaNo;
                dtPaymentMediaDate.Value = Deposit_Withdraw_ReturnBO.P_Mediadate;
                ddlDepositBankName.SelectedValue = Deposit_Withdraw_ReturnBO.Bank_ID;
                ddlDepositBranchName.SelectedValue = Deposit_Withdraw_ReturnBO.Branch_ID;
                ddlDepositRoutingNo.SelectedValue = Deposit_Withdraw_ReturnBO.RoutingNo;
                txtDepositVoucherNo.Text = Deposit_Withdraw_ReturnBO.Voucher;
                _transReason = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value + "_" + Deposit_Withdraw_ReturnBO.Pid.ToString();
            }

           // SetDW_ReturnMode();
        }
        private void PaymentForm_Load(object sender, EventArgs e)
        {
            CommonBAL cBAL = new CommonBAL();
            _formLoad = true;
            Resize();
            LoadDefaultPrevillize();
            Init();
            txtRecievedBy.Text = GlobalVariableBO._userName;
            txtSearchCustomer.Focus();
            GetPaymentEntryInfo();
            dtRecievedDate.Value = cBAL.GetCurrentServerDate();
            dtRecievedDate.Enabled = false;
            _formLoad = false;
            LoadPrevillize();
        }
        private void LoadDefaultPrevillize()
        {
            FieldInfo[] paymentMediaFields = payMethodsObj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo field in paymentMediaFields)
            {
                PrevilizePaymentMedia.Add(field.GetValue(payMethodsObj).ToString());
            }
            LoadWithdrawCombo();
        }
        private void LoadPrevillize()
        {
            bool Userassigned = false;
            bool Roleassigned = false;

            string tempPrevilize = "";
            DataTable RoleWithUserprevillizeDataTable = new DataTable();
            DataTable RolewisePrevillizeDataTable = new DataTable();
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            FieldInfo[] paymentMediaFields = payMethodsObj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            if (MenuName == "EFT Requisition")
            {
                return;
            }
            PrevilizePaymentMedia.Clear();
            /////////////////// Get Assigned Users for a Role  //////////////////////////
            RoleWithUserprevillizeDataTable = previllizeManagementBal.GetAssignedPrevillizeByUserName(GlobalVariableBO._userName);
            if (RoleWithUserprevillizeDataTable.Rows.Count > 0)
            {
                    for (int i = 0; i < RoleWithUserprevillizeDataTable.Rows.Count; i++)
                    {
                        if (RoleWithUserprevillizeDataTable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                        {
                            if (PrevillizedPaymentMedia.Contains(RoleWithUserprevillizeDataTable.Rows[i]["Previllize"].ToString().Trim()))
                            {
                                tempPrevilize = RoleWithUserprevillizeDataTable.Rows[i]["Previllize"].ToString();
                                InitializePrevillizePaymentMedia(tempPrevilize);
                                Userassigned = true;
                            }
                        }
                    }

            }
            ////////////////////////// Get Previllize for Role ////////////////////////////
             if (!Userassigned)
            {
                RolewisePrevillizeDataTable = previllizeManagementBal.GetOnlyRoleWisePrevillize();
                DataTable dtTable = previllizeManagementBal.GetAllUserAssignedForCurrentRole();
                if (CheckAnyUserAssignedForCurrentRole(dtTable))
                {
                    PrevilizePaymentMedia.Clear();
                    Initialize_PaymentMethodsDatasource(ddlDepositWithdraw.Text);
                    return;
                }
                else
                {
                    for (int i = 0; i < RolewisePrevillizeDataTable.Rows.Count; i++)
                    {
                        if (PrevillizedPaymentMedia.Contains(RolewisePrevillizeDataTable.Rows[i]["Previllize"].ToString().Trim()))
                        {

                            tempPrevilize = RolewisePrevillizeDataTable.Rows[i]["Previllize"].ToString();
                            InitializePrevillizePaymentMedia(tempPrevilize);
                            Roleassigned = true;
                        }
                    }
                }
                
            }

            /////////////////// If No User and Role was Assigned Load Default ////////////////////////
             //if (!Userassigned && !Roleassigned)
             //{
             //    foreach (FieldInfo field in paymentMediaFields)
             //    {
             //        PrevilizePaymentMedia.Add(field.GetValue(payMethodsObj).ToString());
             //    }
             //}
             Initialize_PaymentMethodsDatasource(ddlDepositWithdraw.Text);
        }

        private bool CheckAnyUserAssignedForCurrentRole(DataTable dataTable)
        {
            bool _isFound = false;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (PrevillizedPaymentMedia.Contains(dataTable.Rows[i]["Previllize"].ToString().Trim()))
                {
                    _isFound = true;
                    break;
                }
            }
            return _isFound;
        }

        private void AddPrevillizePaymentMedia(string Deposit_Withdraw, string PaymentMedia)
        {
            if (ddlDepositWithdraw.Text == Deposit_Withdraw)
            {
                PrevilizePaymentMedia.Add(PaymentMedia);
            }
            //else if (ddlDepositWithdraw.Text == Deposit_Withdraw)
            //{
            //    PrevilizePaymentMedia.Add(PaymentMedia);
            //}
        }

        private void InitializePrevillizePaymentMedia(string previlize)
        {
            switch (previlize)
            {
                case Indication_PaymentForm_Previllize.Cash_Deposit:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.Cash);
                    break;
                case Indication_PaymentForm_Previllize.Ecash_Deposit:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.Ecash);
                    break;
                case Indication_PaymentForm_Previllize.Cash_Deposit_Return:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.Cash_Return);
                    break;
                case Indication_PaymentForm_Previllize.Cash_Withdraw:
                    AddPrevillizePaymentMedia(depositWithdraw.Withdraw, payMethodsObj.Cash);
                    break;
                case Indication_PaymentForm_Previllize.Cash_Withdraw_Return:
                    AddPrevillizePaymentMedia(depositWithdraw.Withdraw, payMethodsObj.Cash_Return);
                    break;
                case Indication_PaymentForm_Previllize.Cheque_Deposit:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.Cheque);
                    break;
                case Indication_PaymentForm_Previllize.Cheque_Deposit_Return:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.Cheque_Return);
                    break;
                case Indication_PaymentForm_Previllize.EFT_Deposit:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.EFT);
                    break;
                case Indication_PaymentForm_Previllize.EFT_Deposit_Return:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.EFT_Return);
                    break;
                case Indication_PaymentForm_Previllize.EFT_Withdraw:
                    AddPrevillizePaymentMedia(depositWithdraw.Withdraw, payMethodsObj.EFT);
                    break;
                case Indication_PaymentForm_Previllize.EFT_Withdraw_Return:
                    AddPrevillizePaymentMedia(depositWithdraw.Withdraw, payMethodsObj.EFT_Return);
                    break;
                case Indication_PaymentForm_Previllize.Paypal_Deposit:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.PayPal);
                    break;
                case Indication_PaymentForm_Previllize.Paypal_Deposit_Return:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.PayPal_Return);
                    break;
                case Indication_PaymentForm_Previllize.Paypal_Withdraw:
                    AddPrevillizePaymentMedia(depositWithdraw.Withdraw, payMethodsObj.PayPal);
                    break;
                case Indication_PaymentForm_Previllize.Paypal_Withdraw_Return:
                    AddPrevillizePaymentMedia(depositWithdraw.Withdraw, payMethodsObj.PayPal_Return);
                    break;
                case Indication_PaymentForm_Previllize.Payorder_Deposi:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.PayOrder);
                    break;
                case Indication_PaymentForm_Previllize.Payorder_Deposit_Return:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.PayOrder_Return);
                    break;
                case Indication_PaymentForm_Previllize.Payorder_Withdraw:
                    AddPrevillizePaymentMedia(depositWithdraw.Withdraw, payMethodsObj.PayOrder);
                    break;
                case Indication_PaymentForm_Previllize.Payorder_Withdraw_Return:
                    AddPrevillizePaymentMedia(depositWithdraw.Withdraw, payMethodsObj.PayOrder_Return);
                    break;
                case Indication_PaymentForm_Previllize.Deposit_Transfer:
                    AddPrevillizePaymentMedia(depositWithdraw.Deposit, payMethodsObj.TR);
                    break;
                case Indication_PaymentForm_Previllize.Withdraw_Transfer:
                    AddPrevillizePaymentMedia(depositWithdraw.Withdraw, payMethodsObj.TR);
                    break;               
            }
        }


        private void LoadBank_Branch_Routing_Info()
        {
            DataTable dtBankNameForEFT = new DataTable();
            DataTable dtBankNameForPayOrderPaypalCheck = new DataTable();

            DataTable dtBranchNameForEFT = new DataTable();
            DataTable dtBranchNameForPayOrderPaypalCheck = new DataTable();

            DataTable dtRoutingForEFT = new DataTable();
            DataTable dtRoutingForPayOrderPaypalCheck = new DataTable();
            Bank_Branch_ComboBAL paymentBAL = new Bank_Branch_ComboBAL();

            dtRoutingForEFT = paymentBAL.GetRoutingInfo();
            
            PaymentForm_Cache.Add(CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return, dtRoutingForEFT);
           
            //----------------------For EFT Info--------------------//
            var EftBankDs = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                .Select(t => new { Key_Dtl = t["Bank_ID"], Value_Dtl = t["Bank_Name"] }).GroupBy(t => t.Key_Dtl)
                .Select(g => new { Key = g.Key, Value = Convert.ToString(g.Max(t => t.Value_Dtl)) }).ToList();

            var MaxLenBank = EftBankDs.Select(t => t.Value.Length).Max();


            ddlEftDepositBankName.ValueMember = "Key";
            ddlEftDepositBankName.DisplayMember = "Value"; 
            ddlEftDepositBankName.DataSource = EftBankDs;
            ddlEftDepositBankName.DropDownWidth = MaxLenBank * 7;

            var EftRoutingDs = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
               .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
               .Select(t => new { Key = Convert.ToString(t["Routing_No"]), Value = Convert.ToString(t["Routing_No"]) }).ToList();

            ddlEftDepositRoutingNo.ValueMember = "Key";
            ddlEftDepositRoutingNo.DisplayMember = "Value";
            ddlEftDepositRoutingNo.DataSource = EftRoutingDs;
            ddlEftDepositRoutingNo.SelectedIndex = -1;

            //----------------------For Check Info--------------------//

            var NonEftBankDs = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
               .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
               .Select(t => new { Key_Dtl = t["Bank_ID"], Value_Dtl = t["Bank_Name"] }).GroupBy(t => t.Key_Dtl)
               .Select(g => new { Key = g.Key, Value = g.Max(t => t.Value_Dtl) }).ToList();


            ddlDepositBankName.ValueMember = "Key";
            ddlDepositBankName.DisplayMember = "Value";
            ddlDepositBankName.DataSource = NonEftBankDs;
           
            var NonEftRoutingDs = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                .Select(t => new { Key = t["Routing_No"], Value = t["Routing_No"] }).ToList();

            ddlDepositRoutingNo.ValueMember = "Key";
            ddlDepositRoutingNo.DisplayMember = "Value";
            ddlDepositRoutingNo.DataSource = NonEftRoutingDs;
            
        }
        
        private void GetPaymentEntryInfo()
        {
            string paymentMedia = string.Empty;
            string depositWithdraw = string.Empty;
            try
            {
                PaymentInfoBAL objPaymentBAL = new PaymentInfoBAL();
                DataTable data = new DataTable();
                depositWithdraw = ddlDepositWithdraw.Text;
                // data = objPaymentBAL.GetPaymentEntryInfo(dtpSearchPaymentEntry.Value);
                if (ddlPaymentMedia.Text == payMethodsObj.TR)
                {
                    //paymentMedia = Indication_PaymentTransaction.TR;
                    depositWithdraw = "";
                }
                else
                {
                    depositWithdraw = ddlDepositWithdraw.Text;
                }
                data = objPaymentBAL.PaymentGridLoad(txtSearchCustomer.Text, depositWithdraw, Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value, dtpSearchPaymentEntry.Value);//data;
                dgvPaymentInfo.DataSource = data;
                if (ddlPaymentMedia.Text == payMethodsObj.TR)
                {
                    this.dgvPaymentInfo.Columns[0].Visible = true;
                }
                else
                {
                    this.dgvPaymentInfo.Columns[0].Visible = false;
                }
                tssTotalRecord.Text = @"Total Records " + dgvPaymentInfo.Rows.Count.ToString();
                dgvPaymentInfo.Columns["Amount"].DefaultCellStyle.Format = "N";
                dgvPaymentInfo.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        
        public void LoadDepositCombo()
        {
            ddlPaymentMedia.Items.Clear();
            if (PrevilizePaymentMedia.Count > 0)
            {
                foreach (string pMedia in PrevilizePaymentMedia)
                {
                    ddlPaymentMedia.Items.Add(pMedia);
                }
            }
        }
        public void LoadWithdrawCombo()
        {
            ddlPaymentMedia.Items.Clear();
            if (PrevilizePaymentMedia.Count > 0)
            {
                foreach (string pMedia in PrevilizePaymentMedia)
                {
                    ddlPaymentMedia.Items.Add(pMedia);
                }
            }
        }
        private void Init()
        {

            ddlSearchCustomer.SelectedIndex = 0;
            if (MenuName == "EFT Requisition")
            {
                ddlDepositWithdraw.SelectedIndex = 1;
                ddlPaymentMedia.SelectedIndex = 5;// 2;
                ddlDepositWithdraw.Enabled = false;
                ddlPaymentMedia.Enabled = false;
                btnWebData.Enabled = true;
            }
            else if (MenuName == "Payment Withdraw")
            {
                ddlDepositWithdraw.SelectedIndex = 1;
                label2.Text = @"Withdraw :";
                ddlDepositWithdraw.Enabled = false;
                btnWebData.Enabled = true;
            }
            else
            {
                ddlDepositWithdraw.SelectedIndex = 0;
                ddlDepositWithdraw.Enabled = false;
                label2.Text = @"Deposit :";
                btnWebData.Enabled = true;
            }
            LoadPanel();
            //LoadWithdrawCombo();
            //ddlPaymentMedia.DataSource = Deposit;

            //try
            //{
            //    if (ddlPaymentMedia.SelectedIndex != -1)
            //    ddlPaymentMedia.SelectedIndex = 0;
            //}
            //catch
            //{
            //   // ddlPaymentMedia.SelectedIndex = 0;
            //}
            chkMatureToday.Visible = false;
            txtSearchCustomer.Focus();
        }
        
        private void CheckCommonValidation()
        {
            if (txtSearchCustomer.Text.Trim() == "")
            {
                ControlToFocus = txtSearchCustomer;
                throw new Exception("Please Fill the Search Customer Code.");
            }
            if (txtCustCode.Text.Trim() == "")
            {
                ControlToFocus = txtCustCode;
                throw new Exception("Please Fill the Customer Code.");
            }
            if (txtAmount.Text.Trim() == "")
            {
                ControlToFocus = txtAmount;
                throw new Exception("Please Fill the Amount.");
            }
        }
        
        private void CheckAllValidation(PaymentMedia pmedia)
        {
            switch (pmedia)
            {
                case PaymentMedia.EFT:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Non Return Withdraw 
                        {
                            if (txteftBankName.Text == "")
                            {
                                ControlToFocus = txteftBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (txteftBankBranchName.Text == "")
                            {
                                ControlToFocus = txteftBankBranchName;
                                throw new Exception("Branch Name Required");
                            } 
                            if (txteftRoutingNo.Text == "")
                            {
                                ControlToFocus = txteftRoutingNo;
                                throw new Exception("Routing Number Required");
                            }
                            if (txtBankAccNo.Text == "")
                            {
                                ControlToFocus = txtBankAccNo;
                                throw new Exception("Bank Account Number Required");
                            }
                            if (txteftVoucherNo.Text == "")
                            {
                                ControlToFocus = txteftVoucherNo;
                                throw new Exception("Voucher Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            CheckWithdrawBalance();
                            //else if (Convert.ToInt32(txtAmount.Text) > 400000 || Convert.ToInt32(txtAmount.Text) < 100)
                            //{
                            //    ControlToFocus = txtAmount;
                            //    throw new Exception("Amount must be between 100 and 400000 Taka");
                            //}
                           
                        }
                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Non Return Deposit 
                        {
                            if (ddlEftDepositBankName.SelectedIndex < 0)
                            {
                               // ControlToFocus = txteftBankName;
                                //throw new Exception("Bank Name Required");
                            }
                            if (ddlEftDepositBranchName.SelectedIndex < 0)
                            {
                                //ControlToFocus = txteftBankBranchName;
                                //throw new Exception("Branch Name Required");
                            }
                            if (ddlEftDepositRoutingNo.SelectedIndex < 0)
                            {
                                //ControlToFocus = ddlEftDepositRoutingNo;
                                //throw new Exception("Routing Number Required");
                            }
                            if (txtEftDepositBankAccNo.Text == "")
                            {
                                //ControlToFocus = txtEftDepositBankAccNo;
                                //throw new Exception("Bank Account Number Required");
                            }
                            if (txtEftDepositVoucherNo.Text == "")
                            {
                                ControlToFocus = txtEftDepositVoucherNo;
                                throw new Exception("Voucher Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            //else if (Convert.ToInt32(txtAmount.Text) > 400000 || Convert.ToInt32(txtAmount.Text) < 100)
                            //{
                            //    ControlToFocus = txtAmount;
                            //    throw new Exception("Amount must be between 100 and 400000 Taka");
                            //}
                           
                        }
                        break;
                    }

                case PaymentMedia.EFT_Return:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Return Withdraw
                        {
                            if (txteftBankName.Text == "")
                            {
                                ControlToFocus = txteftBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (txteftBankBranchName.Text == "")
                            {
                                ControlToFocus = txteftBankBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txteftRoutingNo.Text == "")
                            {
                                ControlToFocus = txteftRoutingNo;
                                throw new Exception("Routing Number Required");
                            }
                            if (txtBankAccNo.Text == "")
                            {
                                ControlToFocus = txtBankAccNo;
                                throw new Exception("Bank Account Number Required");
                            }
                            if (txteftVoucherNo.Text == "")
                            {
                                ControlToFocus = txteftVoucherNo;
                                throw new Exception("Voucher Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            //else if (Convert.ToInt32(txtAmount.Text) > 400000 || Convert.ToInt32(txtAmount.Text) < 100)
                            //{
                            //    ControlToFocus = txtAmount;
                            //    throw new Exception("Amount must be between 100 and 400000 Taka");
                            //}

                        }
                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Return Deposit
                        {
                            if (ddlEftDepositBankName.SelectedIndex < 0)
                            {
                                // ControlToFocus = txteftBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlEftDepositBranchName.SelectedIndex < 0)
                            {
                                //ControlToFocus = txteftBankBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (ddlEftDepositRoutingNo.SelectedIndex < 0)
                            {
                               // ControlToFocus = txtEftDepositRoutingNo;
                                throw new Exception("Routing Number Required");
                            }
                            if (txtEftDepositBankAccNo.Text == "")
                            {
                                ControlToFocus = txtEftDepositBankAccNo;
                                throw new Exception("Bank Account Number Required");
                            }
                            if (txtEftDepositVoucherNo.Text == "")
                            {
                                ControlToFocus = txtEftDepositVoucherNo;
                                throw new Exception("Voucher Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            CheckWithdrawBalance();
                            //else if (Convert.ToInt32(txtAmount.Text) > 400000 || Convert.ToInt32(txtAmount.Text) < 100)
                            //{
                            //    ControlToFocus = txtAmount;
                            //    throw new Exception("Amount must be between 100 and 400000 Taka");
                            //}

                        }
                        break;
                    }

                case PaymentMedia.Cash:  
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Non Return Withdraw
                        {
                            if (txtSerialNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtSerialNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            CheckWithdrawBalance();
                        }

                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Non Return Deposit
                        {
                            if (txtSerialNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtSerialNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                        }
                        break;
                    }
                case PaymentMedia.Ecash:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Ecash Deposit
                        {
                            if (txtSerialNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtSerialNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                        }
                        break;
                    }

                case PaymentMedia.Cash_Return:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Return Withdraw
                        {
                            if (txtSerialNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtSerialNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                        }

                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Return Deposit
                        {
                            if (txtSerialNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtSerialNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            CheckWithdrawBalance();
                        }
                        break;

                    }


                case PaymentMedia.Cheque:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Non Return Withdraw
                        {
                            if (txtDepositPaymentMedia.Text == "")// txtPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Payment Media  Required");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                // ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text == "")// txtSerialNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            CheckWithdrawBalance();
                        }

                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Non Return Deposit
                        {
                            if (txtDepositPaymentMedia.Text == "")// txtPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Payment Media  Required");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                // ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text == "")// txtSerialNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                        }
                        break;

                    }

                case PaymentMedia.Cheque_Return:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Return Withdraw
                        {
                            if (txtDepositPaymentMedia.Text == "")// txtPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Payment Media  Required");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                // ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text == "")// txtSerialNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                        }

                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Return Deposit
                        {
                            if (txtDepositPaymentMedia.Text == "")// txtPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Payment Media  Required");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                // ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text == "")// txtSerialNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            //CheckWithdrawBalance();
                        }
                        break;

                    }

                case PaymentMedia.Pay_Order:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Non Return Withdraw
                        {
                            if (txtDepositPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Please Fill the Payment Media No.");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            CheckWithdrawBalance();
                        }

                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Non Return Deposit
                        {
                            if (txtDepositPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Please Fill the Payment Media No.");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                        }
                        break;
                    }

                case PaymentMedia.Pay_Order_Return:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Return Withdraw
                        {
                            if (txtDepositPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Please Fill the Payment Media No.");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                        }

                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Return Deposit
                        {
                            if (txtDepositPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtPaymentMedia;
                                throw new Exception("Please Fill the Payment Media No.");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            CheckWithdrawBalance();
                        }
                        break;
                    }

                case PaymentMedia.Paypal:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Non Return Withdraw
                        {
                            if (txtDepositPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Please Fill the Payment Media No.");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            CheckWithdrawBalance();

                        }

                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Non Return Deposit
                        {
                            if (txtDepositPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Please Fill the Payment Media No.");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                        }
                        break;

                    }

                case PaymentMedia.Paypal_Return:
                    {
                        if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw) //Return Withdraw
                        {
                            if (txtDepositPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Please Fill the Payment Media No.");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                        }

                        else if (ddlDepositWithdraw.Text == depositWithdraw.Deposit) //Return Deposit
                        {
                            if (txtDepositPaymentMedia.Text == "")
                            {
                                ControlToFocus = txtDepositPaymentMedia;
                                throw new Exception("Please Fill the Payment Media No.");
                            }
                            if (ddlDepositBankName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBankName;
                                throw new Exception("Bank Name Required");
                            }
                            if (ddlDepositBranchName.Text.Trim() == "")
                            {
                                ControlToFocus = txtBranchName;
                                throw new Exception("Branch Name Required");
                            }
                            if (txtDepositVoucherNo.Text.Trim() == "")
                            {
                                ControlToFocus = txtDepositVoucherNo;
                                throw new Exception("Serial Number Required");
                            }
                            if (txtAmount.Text == "")
                            {
                                ControlToFocus = txtAmount;
                                throw new Exception("Amount Required");
                            }
                            CheckWithdrawBalance();
                        }
                        break;
                        
                    }
                case PaymentMedia.Transfer:
                    {
                        if (txtTransCustomer.Text.Trim() == "")
                        {
                            ControlToFocus = txtTransCustomer;
                            throw new Exception("Please Fill the Customer Code/BO ID.");
                        }
                        if (txtVoucherNo.Text.Trim() == "")
                        {
                            ControlToFocus = txtVoucherNo;
                            throw new Exception("Please Fill the Voucher No.");
                        }
                        if (txtTransCustomer.Text == txtCustCode.Text)
                        {
                            ControlToFocus = txtTransCustomer;
                            throw new Exception("TR is not possible Between Same Customer.");
                        }
                        if (txtTransBalance.Text.Trim() != "")
                            chkTRBalance = float.Parse(txtTransBalance.Text);
                        if (txtAmount.Text.Trim() != "")
                        {
                            chkAmount = float.Parse(txtAmount.Text);
                        }
                        if (chkTRBalance < chkAmount)
                        {
                            throw new Exception("Insufficient Balance to TR! Please check.");
                        }
                        if (ddlDepositWithdraw.SelectedIndex == 1 && float.Parse(txtTransBalance.Text) < float.Parse(txtAmount.Text))
                        {
                            throw new Exception("Insufficient Balance! Please check.");
                        }

                        CheckTRWithdrawBalance();
                        break;
                    }
            }
        }
        private void ValidationCheck()
        {
            if (ddlPaymentMedia.Text == payMethodsObj.Cash)
                CheckAllValidation(PaymentMedia.Cash);

            else if (ddlPaymentMedia.Text == payMethodsObj.Ecash)
                CheckAllValidation(PaymentMedia.Ecash);

            else if (ddlPaymentMedia.Text == payMethodsObj.Cash_Return)
                CheckAllValidation(PaymentMedia.Cash_Return);

            else if (ddlPaymentMedia.Text == payMethodsObj.Cheque)
                CheckAllValidation(PaymentMedia.Cheque);

            else if (ddlPaymentMedia.Text == payMethodsObj.Cheque_Return)
                CheckAllValidation(PaymentMedia.Cheque_Return);

            else if (ddlPaymentMedia.Text == payMethodsObj.EFT)
                CheckAllValidation(PaymentMedia.EFT);

            else if (ddlPaymentMedia.Text == payMethodsObj.EFT_Return)
                CheckAllValidation(PaymentMedia.EFT_Return);

            

            else if (ddlPaymentMedia.Text == payMethodsObj.PayOrder)
                CheckAllValidation(PaymentMedia.Pay_Order);

            else if (ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return)
                CheckAllValidation(PaymentMedia.Pay_Order_Return);

            else if (ddlPaymentMedia.Text == payMethodsObj.PayPal)
                CheckAllValidation(PaymentMedia.Paypal);

            else if (ddlPaymentMedia.Text == payMethodsObj.PayPal_Return)
                CheckAllValidation(PaymentMedia.Paypal_Return);

            else if (ddlPaymentMedia.Text == payMethodsObj.TR)
                CheckAllValidation(PaymentMedia.Transfer);
            else if (ddlPaymentMedia.Text==payMethodsObj.EFT_Return)
                CheckAllValidation(PaymentMedia.EFT);

        }

        private void FormClear()
        {
            txtSearchCustomer.Text = "";
            ClearByCustCode();
        }
        private void ClearByCustCode()
        {
            txtCustCode.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtAccountHolderName.Text = string.Empty;
            txtAccountHolderBOId.Text = string.Empty;
            txtlastTradeDate.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtCurrentBalance.Text = string.Empty;
            txtMaturedBalance.Text = string.Empty;
            txtBOStatus.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtRecievedBy.Text = string.Empty;
            ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);
            txtRecievedBy.Text = GlobalVariableBO._userName;
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
            txtAvailableWithdrawBalance.Text = string.Empty;
            txtAccruedBalance.Text = string.Empty;
            txtAccruedBalance.Text = string.Empty;
        }
        private void ClearByMode(string transType, string payMeth)
        {

            if (transType == depositWithdraw.Deposit && (payMeth == payMethodsObj.Cash||payMeth == payMethodsObj.Ecash))
            {
                txtAmount.Text = string.Empty;
                txtPaymentMedia.Text = string.Empty;
                txtBankName.Text = string.Empty;
                txtBranchName.Text = string.Empty;
                txtSerialNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.Cash_Return)
            {
                txtAmount.Text = string.Empty;
                txtPaymentMedia.Text = string.Empty;
                txtBankName.Text = string.Empty;
                txtBranchName.Text = string.Empty;
                txtSerialNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.Cheque)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;// txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex= -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.Cheque_Return)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.EFT)
            {
                txtAmount.Text = string.Empty;
                ddlEftDepositBankName.SelectedIndex = -1;// txteftBankBranchName.Text = "";
                ddlEftDepositBranchName.SelectedIndex = -1;// txteftBankName.Text = "";
                ddlEftDepositRoutingNo.SelectedIndex=-1;// txteftRoutingNo.Text = "";
                txtEftDepositVoucherNo.Text = string.Empty;// txteftVoucherNo.Text = "";
                txtEftDepositBankAccNo.Text = string.Empty;// txtBankAccNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.EFT_Return)
            {
                txtAmount.Text = string.Empty;
                ddlEftDepositBankName.SelectedIndex = -1;// txteftBankBranchName.Text = "";
                ddlEftDepositBranchName.SelectedIndex = -1;// txteftBankName.Text = "";
                ddlEftDepositRoutingNo.SelectedIndex = -1;// txteftRoutingNo.Text = "";
                txtEftDepositVoucherNo.Text = string.Empty;// txteftVoucherNo.Text = "";
                txtEftDepositBankAccNo.Text = string.Empty;// txtBankAccNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.PayOrder)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.PayOrder_Return)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }

            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.PayPal)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
           
            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.PayPal_Return)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Deposit && payMeth == payMethodsObj.TR)
            {
                txtAmount.Text = string.Empty;
                txtTransCustomer.Text = string.Empty;
                txtTransCustName.Text = string.Empty;
                txtTransBalance.Text = string.Empty;
                txtVoucherNo.Text = string.Empty;OnlineOrderNo = 0;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }

            else if (transType == depositWithdraw.Withdraw && payMeth == payMethodsObj.Cash)
            {
                txtAmount.Text = string.Empty;
                txtPaymentMedia.Text = string.Empty;
                txtBankName.Text = string.Empty;
                txtBranchName.Text = string.Empty;
                txtSerialNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }

            else if (transType == depositWithdraw.Withdraw && payMeth == payMethodsObj.Cash_Return)
            {
                txtAmount.Text = string.Empty;
                txtPaymentMedia.Text = string.Empty;
                txtBankName.Text = string.Empty;
                txtBranchName.Text = string.Empty;
                txtSerialNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Withdraw && payMeth == payMethodsObj.EFT)
            {
                txtAmount.Text = string.Empty;
                txtEFTBankID.Text = string.Empty;
                txteftBankBranchName.Text = string.Empty;
                txtEFTBranchID.Text = string.Empty;
                txteftBankName.Text = string.Empty;
                txteftRoutingNo.Text = string.Empty;
                txteftVoucherNo.Text = string.Empty;
                txtBankAccNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Withdraw && payMeth == payMethodsObj.EFT_Return)
            {
                txtAmount.Text = string.Empty;
                txteftBankBranchName.Text = string.Empty;
                txteftBankName.Text = string.Empty;
                txteftRoutingNo.Text = string.Empty;
                txteftVoucherNo.Text = string.Empty;
                txtBankAccNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Withdraw && payMeth == payMethodsObj.PayOrder)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Withdraw && payMeth == payMethodsObj.PayOrder_Return)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Withdraw && payMeth == payMethodsObj.PayPal)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }

            else if (transType == depositWithdraw.Withdraw && payMeth == payMethodsObj.PayPal_Return)
            {
                txtAmount.Text = string.Empty;
                txtDepositPaymentMedia.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddlDepositBankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddlDepositBranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddlDepositRoutingNo.SelectedIndex = -1;
                txtDepositVoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == depositWithdraw.Withdraw && payMeth == payMethodsObj.TR)
            {
                txtAmount.Text = string.Empty;
                txtTransCustomer.Text = string.Empty;
                txtTransCustName.Text = string.Empty;
                txtTransBalance.Text = string.Empty;
                txtVoucherNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
        }
        private void SetNextFocus(string payMeth, string currentFocusControlName)
        {
            if ((payMeth == payMethodsObj.Cash||payMeth == payMethodsObj.Cash) && (ddlDepositWithdraw.Text==depositWithdraw.Withdraw ||ddlDepositWithdraw.Text==depositWithdraw.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();// txtAmount.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtAmount.Focus();
                }
                else if (currentFocusControlName == txtAmount.Name)
                {
                    txtSerialNo.Focus();
                }
                else if (currentFocusControlName == txtSerialNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }
            else if (payMeth == payMethodsObj.Cash_Return && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();// txtAmount.Focus();
                }
                if (currentFocusControlName == btnDWReturnInfo.Name)
                {
                    txtSerialNo.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtSerialNo.Focus();
                }
                else if (currentFocusControlName == txtSerialNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }

            else if (payMeth == payMethodsObj.Cheque && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtAmount.Focus();
                }
                else if (currentFocusControlName == txtAmount.Name)
                {
                    txtDepositPaymentMedia.Focus();
                }
                //else if (currentFocusControlName == txtDepositPaymentMedia.Name)
                //{
                //    dtRecievedDate.Focus();
                //}
                else if (currentFocusControlName == txtDepositPaymentMedia.Name)
                {
                    ddlDepositBankName.Focus();
                }
                else if (currentFocusControlName == ddlDepositBankName.Name)
                {
                    ddlDepositBranchName.Focus();
                }
                else if (currentFocusControlName == ddlDepositBranchName.Name)
                {
                    ddlDepositRoutingNo.Focus();
                }
                else if (currentFocusControlName == ddlDepositRoutingNo.Name)
                {
                    txtDepositVoucherNo.Focus();
                }
                else if (currentFocusControlName == txtDepositVoucherNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }

            else if (payMeth == payMethodsObj.Cheque_Return && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == btnDWReturnInfo.Name)
                {
                    txtDepositVoucherNo.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtDepositVoucherNo.Focus();
                }
                else if (currentFocusControlName == txtDepositVoucherNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }

            else if (payMeth == payMethodsObj.PayOrder && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtAmount.Focus();
                }
                else if (currentFocusControlName == txtAmount.Name)
                {
                    txtDepositPaymentMedia.Focus();
                }
                //else if (currentFocusControlName == txtDepositPaymentMedia.Name)
                //{
                //    dtRecievedDate.Focus();
                //}
                else if (currentFocusControlName == txtDepositPaymentMedia.Name)
                {
                    ddlDepositBankName.Focus();
                }
                else if (currentFocusControlName == ddlDepositBankName.Name)
                {
                    ddlDepositBranchName.Focus();
                }
                else if (currentFocusControlName == ddlDepositBranchName.Name)
                {
                    ddlDepositRoutingNo.Focus();
                }
                else if (currentFocusControlName == ddlDepositRoutingNo.Name)
                {
                    txtDepositVoucherNo.Focus();
                }
                else if (currentFocusControlName == txtDepositVoucherNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }
            else if (payMeth == payMethodsObj.PayOrder_Return && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == btnDWReturnInfo.Name)
                {
                    txtDepositVoucherNo.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtDepositVoucherNo.Focus();
                }
                else if (currentFocusControlName == txtDepositVoucherNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }


            else if (payMeth == payMethodsObj.PayPal && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtAmount.Focus();
                }
                else if (currentFocusControlName == txtAmount.Name)
                {
                    txtDepositPaymentMedia.Focus();
                }
                //else if (currentFocusControlName == txtDepositPaymentMedia.Name)
                //{
                //    dtRecievedDate.Focus();
                //}
                else if (currentFocusControlName == txtDepositPaymentMedia.Name)
                {
                    ddlDepositBankName.Focus();
                }
                else if (currentFocusControlName == ddlDepositBankName.Name)
                {
                    ddlDepositBranchName.Focus();
                }
                else if (currentFocusControlName == ddlDepositBranchName.Name)
                {
                    ddlDepositRoutingNo.Focus();
                }

                else if (currentFocusControlName == ddlDepositRoutingNo.Name)
                {
                    txtDepositVoucherNo.Focus();
                }
                else if (currentFocusControlName == txtDepositVoucherNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }

            else if (payMeth == payMethodsObj.PayPal_Return && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw || ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == btnDWReturnInfo.Name)
                {
                    txtDepositVoucherNo.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtDepositVoucherNo.Focus();
                }
                else if (currentFocusControlName == txtDepositVoucherNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }


            else if (payMeth == payMethodsObj.EFT && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtAmount.Focus();
                }
                else if (currentFocusControlName == txtAmount.Name)
                {
                    btneftAutoVoucher.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
                //else if (currentFocusControlName == txtRemarks.Name)
                //{
                //    btnSave.Focus();
                //}
            }
            else if (payMeth == payMethodsObj.EFT_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw )
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == btnDWReturnInfo.Name)
                {
                    txteftVoucherNo.Focus();
                }

                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txteftVoucherNo.Focus();
                }
                else if (currentFocusControlName == txteftVoucherNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }

            else if (payMeth == payMethodsObj.EFT && (ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                //else if (currentFocusControlName == txtAmount.Name)
                //{
                //    dtRecievedDate.Focus();
                //}
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtAmount.Focus();
                }
                else if (currentFocusControlName == txtAmount.Name)
                {
                    ddlEftDepositBankName.Focus();
                }
                else if (currentFocusControlName == ddlEftDepositBankName.Name)
                {
                    ddlEftDepositBranchName.Focus();
                }
                else if (currentFocusControlName == ddlEftDepositBranchName.Name)
                {
                    ddlEftDepositRoutingNo.Focus();
                }
                else if (currentFocusControlName == ddlEftDepositRoutingNo.Name)
                {
                    txtEftDepositBankAccNo.Focus();
                }
                //else if (currentFocusControlName == txtEftDepositBankAccNo.Name)
                //{
                //    btnEftCheckDepositAutogen.Focus();
                //}
                else if (currentFocusControlName == txtEftDepositBankAccNo.Name)
                {
                    txtEftDepositVoucherNo.Focus();
                }
                //else if (currentFocusControlName == btnEftCheckDepositAutogen.Name)
                //{
                //    txtEftDepositVoucherNo.Focus();
                //}

                else if (currentFocusControlName == txtEftDepositVoucherNo.Name)
                {
                    txtRecievedBy.Focus();
                }

                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }


                //else if (currentFocusControlName == txtRemarks.Name)
                //{
                //    btnSave.Focus();
                //}
            }

            else if (payMeth == payMethodsObj.EFT_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtEftDepositVoucherNo.Focus();
                }
                if (currentFocusControlName == btnDWReturnInfo.Name)
                {
                    txtEftDepositVoucherNo.Focus();
                }

                else if (currentFocusControlName == txtEftDepositVoucherNo.Name)
                {
                    txtRecievedBy.Focus();
                }
                else if (currentFocusControlName == txtRecievedBy.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }

            else if (payMeth == payMethodsObj.TR)
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txtAmount.Focus();
                }
                else if (currentFocusControlName == txtAmount.Name)
                {
                    txtTransCustomer.Focus();
                }
                else if (currentFocusControlName == txtTransCustomer.Name)
                {
                    txtVoucherNo.Focus();
                }
                else if (currentFocusControlName == txtVoucherNo.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }
        }

        private void CheckWithdrawBalance()
        {
            CommonBAL comBal = new CommonBAL();
            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
            var availableBalance = comBal.GetCurrentAvailAbleBalanceForWithdraw(txtCustCode.Text);            
            if (Convert.ToDouble(txtAmount.Text) > (availableBalance))
            {
                ControlToFocus = txtAmount;
                throw new Exception("You have no sufficient balance to withdraw");
            }
        }

        private void CheckTRWithdrawBalance()
        {
            CommonBAL comBal=new CommonBAL();
            var availableBalance = comBal.GetCurrentAvailAbleBalanceForWithdraw(txtTransCustomer.Text);
            if (Convert.ToDouble(txtAmount.Text) > availableBalance)
            {
                ControlToFocus = txtAmount;
                throw new Exception("You have no sufficient balance to withdraw");
            }
        }

        private void UpdateVoucherNo()
        {
            PaymentInfoBAL paymentBal = new PaymentInfoBAL();
            paymentBal.UpdateSerialNo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PaymentInfoBAL paymentBal = new PaymentInfoBAL();

            try
            {
                if (txtStatus.Text != @"Active")
                {
                    if (
                        MessageBox.Show(@"This customer is closed. Do you want to save?", @"Cust status check",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SaveData();
                    }
                    else
                    {
                        MessageBox.Show(@"Save canceled", @"Save cancel", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                }
                else
                {
                    SaveData();
                }
            }
            catch (Exception ex)
            {

                ControlToFocus.Focus();
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private bool IsLockedVoucherNo()
        {
            PaymentInfoBAL paymentBal = new PaymentInfoBAL();
            bool result = false;
            if (paymentBal.IsLockedVoucherLockState())
            {
                result = true;
            }
            return result;
        }

        private void SaveData()
        {
            //if (ddlPaymentMedia.Text == payMethodsObj.Cash || ddlPaymentMedia.Text == payMethodsObj.Cheque || ddlPaymentMedia.Text == payMethodsObj.EFT || ddlPaymentMedia.Text == payMethodsObj.PayOrder || ddlPaymentMedia.Text == payMethodsObj.PayPal)
            //{
            PaymentInfoBAL paymentBal = new PaymentInfoBAL();
            CheckCommonValidation();
            ValidationCheck();
            //if (ddlPaymentMedia.Text == payMethodsObj.TR)
            //{
            //    CheckTRWithdrawBalance();
            //}
            //if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw && ddlPaymentMedia.Text != payMethodsObj.TR)
            //{
            //    CheckWithdrawBalance();
            //}
            try
            {
                LoadSupportingInformation();
                if (ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    if (!IsLockedVoucherNo())
                    {
                        paymentBal.LockVoucherNo();
                        SetVoucherNo();
                    }
                    else
                    {
                        throw new Exception("Some one processing,please wait ");
                    }
                }
                SavePaymentInfo();
                if (ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    UpdateVoucherNo();
                    paymentBal.UnLockVoucherNo();
                }
                Point ParentPt = this.Location;
                Point MsgBoxPt = new Point(ParentPt.X / 2 + 250, (ParentPt.Y / 2) + 200);
                frmCustomizedMessageBox cstmessage = new frmCustomizedMessageBox(@"Payment Information Saved Successfully.", @"Save Confirmation", MsgBoxPt);
                //cstmessage.Show();
                cstmessage.ShowDialog();
                // MessageBox.Show(@"Payment Information Saved Successfully.", @"Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                GetPaymentEntryInfo();
                FormClear();
                txtSearchCustomer.Focus();
            }
            catch (Exception ex)
            {
                paymentBal.UnLockVoucherNo();
                throw new Exception(ex.Message);
            }
        }
        //    else
        //    {
        //        PaymentInfoBAL paymentBal = new PaymentInfoBAL();
        //        CheckCommonValidation();
        //        ValidationCheck();
        //        try
        //        {
        //            //  LoadSupportingInformation();
        //            SavePaymentInfo();
        //            GetPaymentEntryInfo();
        //            Point ParentPt = this.Location;
        //            Point MsgBoxPt = new Point(ParentPt.X / 2 + 250, (ParentPt.Y / 2) + 200);
        //            frmCustomizedMessageBox cstmessage = new frmCustomizedMessageBox(@"Payment Information Saved Successfully.", @"Save Confirmation", MsgBoxPt);
        //            //cstmessage.Show();
        //            cstmessage.ShowDialog();

        //            FormClear();
        //            txtSearchCustomer.Focus();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }

        //    }

        //}
        //private void ShowMessage()
        //{
        //    Button btn = new Button();
        //    Label messagetext = new Label();
        //    messagetext.Text = "Data Saved Successfull";
        //    messagetext.AutoSize = true;
        //    btn.Text = "Ok";
        //    btn.Location = new Point(100, 55);
        //    messagetext.Location = new Point(60, 25);
        //    form = new Form
        //    {
        //        StartPosition = FormStartPosition.Manual,
        //        ShowInTaskbar = false,
        //        Size=new Size(300,120),
        //        Location = new Point(350, 250)
        //    };
        //    form.Controls.Add(btn);
        //    form.Controls.Add(messagetext);
        //    form.MaximizeBox = false;
        //    form.MinimizeBox = false;
        //    form.ShowIcon = false;
        //    btn.Click+=new EventHandler(btn_Click);
        //    form.ShowDialog();
        //}
        //private void btn_Click(object sender, EventArgs e)
        //{
        //    form.Close();
        //}
        private void LoadSupportingInformation()
        {
            if (ddlSearchCustomer.SelectedIndex == 0)
            {
                if (txtCustCode.Text != txtSearchCustomer.Text)
                {
                    SearchCustomerInformation();
                    return;
                }
            }
            else
            {
                if (txtAccountHolderBOId.Text != txtSearchCustomer.Text)
                {
                    SearchCustomerInformation();
                    return;
                }
            }
            if (ddlPaymentMedia.Text == payMethodsObj.TR)
            {
                if (txtTransCustomer.Text.Trim() == "")
                {
                    SearchTransCustomerInformation();
                    return;
                }
            }
            //if (txtStatus.Text.Equals("Closed"))
            //{
            //    if (DialogResult.No == MessageBox.Show("This is a Closed Account. Sure you want to continue?", "Closed Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            //    {
            //        // ClearAll();
            //        ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);
            //        txtSearchCustomer.Focus();
            //        return;
            //    }
            //}

        }

        private void SearchTransCustomerInformation()
        {
            if (txtTransCustomer.Text.Trim() != "")
            {
                decimal AccruedBalance = 0; 
                DataTable custDateTable = new DataTable();
                CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
                PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                CommonBAL commbal = new CommonBAL();
                _custCode = txtTransCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                if (custDateTable.Rows.Count > 0)
                {
                    txtTransCustName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                    txtTransBalance.Text = customerInfoBAL.GetCurrentBalane(_custCode).ToString("N");
                    AccruedBalance = Convert.ToDecimal(paymentInfoBal.GetCurrentBalaneforAccrued(_custCode));
                    txtTrAccruedBalance.Text = AccruedBalance.ToString("N");
                    txtTrAvailAbleBalance.Text = commbal.GetCurrentAvailAbleBalanceForWithdraw(_custCode).ToString("N"); 

                }
                else
                {
                    MessageBox.Show(@"No customer found For Payment Transfer.");
                    return;
                }
                if (Convert.ToDouble(txtTransBalance.Text) <= 0)
                {
                    txtTransBalance.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtTransBalance.BackColor = System.Drawing.Color.GreenYellow;
                }
            }
        }

        private void SavePaymentInfo()
        {
            if (!ddlPaymentMedia.Text.Contains(Indication_PaymentTransaction.Return_Indicator))
            {
                PaymentInfoBO paymentInfoBo = new PaymentInfoBO();
                Payment_PostingBO postBo=new Payment_PostingBO();
                float floatTryParse;
                paymentInfoBo.RecievedDate = dtRecievedDate.Value;
                paymentInfoBo.RecievedBy = txtRecievedBy.Text;
                paymentInfoBo.DepositWithdraw = ddlDepositWithdraw.SelectedItem.ToString();
                paymentInfoBo.PaymentApprovedBy = null;
                paymentInfoBo.PaymentApprovedDate = null;
                paymentInfoBo.Remarks = txtRemarks.Text.Trim();
                paymentInfoBo.CustCode = txtCustCode.Text;

                if (float.TryParse(txtAmount.Text.Trim(), out floatTryParse))
                    paymentInfoBo.Amount = floatTryParse;
                paymentInfoBo.PaymentMedia = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value;
                if (ddlPaymentMedia.Text == payMethodsObj.TR)
                {

                    paymentInfoBo.TransCustCode = txtTransCustomer.Text;
                    paymentInfoBo.VoucherSlNo = txtVoucherNo.Text.Trim();

                }
                else if (ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text==depositWithdraw.Withdraw)
                {
                    paymentInfoBo.Bank_ID =Convert.ToInt32(txtEFTBankID.Text.Trim());
                    paymentInfoBo.BankName = txteftBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(txtEFTBranchID.Text.Trim());
                    paymentInfoBo.BranchName = txteftBankBranchName.Text;
                    paymentInfoBo.RoutingNo = txteftRoutingNo.Text;
                    paymentInfoBo.BankAccNo = txtBankAccNo.Text;
                    paymentInfoBo.VoucherSlNo = txteftVoucherNo.Text;
                    //paymentInfoBo.BankAccName = txtBankAccName.Text;
                }
                else if (ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                {
                    //paymentInfoBo.Bank_ID = Convert.ToInt32(ddlEftDepositBankName.SelectedValue.ToString());
                    //paymentInfoBo.BankName = ddlEftDepositBankName.Text;// txteftBankName.Text;
                    //paymentInfoBo.Branch_ID =Convert.ToInt32(ddlEftDepositBranchName.SelectedValue.ToString());
                    //paymentInfoBo.BranchName = ddlEftDepositBranchName.Text;// txteftBankBranchName.Text;
                    //paymentInfoBo.RoutingNo = ddlEftDepositRoutingNo.SelectedValue.ToString();
                    //paymentInfoBo.BankAccNo = txtEftDepositBankAccNo.Text;
                    paymentInfoBo.VoucherSlNo = txtEftDepositVoucherNo.Text;
                }
                else if ((ddlPaymentMedia.Text == payMethodsObj.Cash||ddlPaymentMedia.Text == payMethodsObj.Ecash))
                {

                    paymentInfoBo.VoucherSlNo = txtSerialNo.Text;
                }

                else if (ddlPaymentMedia.Text == payMethodsObj.Cheque && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    paymentInfoBo.IsMatureToday = Convert.ToInt32(chkMatureToday.Checked);
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;//dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;// txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;// txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim();// txtSerialNo.Text;
                }
                else if (ddlPaymentMedia.Text == payMethodsObj.Cheque && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                {
                    paymentInfoBo.IsMatureToday = Convert.ToInt32(chkMatureToday.Checked);
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();// txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;// dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;//txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;//txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo =txtDepositVoucherNo.Text.Trim();
                }
                else if (ddlPaymentMedia.Text == payMethodsObj.PayPal && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;//dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;//txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;//txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim(); //txtSerialNo.Text;
                }
                else if (ddlPaymentMedia.Text == payMethodsObj.PayPal && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                {
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;//dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;//txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;//txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim(); //txtSerialNo.Text;
                }
                else if (ddlPaymentMedia.Text == payMethodsObj.PayOrder && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;//dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;//txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;//txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim(); //txtSerialNo.Text;
                }

                else if (ddlPaymentMedia.Text == payMethodsObj.PayOrder && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                {
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;//dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;//txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;//txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim(); //txtSerialNo.Text;
                }
                //else
                //{
                //    paymentInfoBo.VoucherSlNo = txtSerialNo.Text.Trim();
                //}
                if (OnlineOrderNo != 0 && OnlineOrderNo != null)
                {
                    postBo.OnlineOrderNo = OnlineOrderNo;
                    if (OnlineEntry_Date.Value != null)
                        postBo.OnlineEntry_Date = OnlineEntry_Date.Value;
                        postBo.Channel = Channel;
                }

                try
                {
                    PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();

                    if (ddlPaymentMedia.Text == payMethodsObj.TR)
                    {
                        //paymentInfoBal.InsertIntoPayment(paymentInfoBo);
                        paymentInfoBal.InsertintoPaymentPostingRequestForTR(paymentInfoBo);
                        if (paymentInfoBo.Amount >= 1000)
                        {
                            paymentInfoBo.DepositWithdraw = "Withdraw";
                            paymentInfoBo.Amount = 50;
                            paymentInfoBo.CustCode = txtTransCustomer.Text;
                            paymentInfoBo.PaymentMedia = "Cash";
                            paymentInfoBo.VoucherSlNo = "TR|CHG|" + txtTransCustomer.Text;
                            //InsertintoPaymentPosting
                            CashDividedMarginLoanBAL c = new CashDividedMarginLoanBAL();
                            c.InsertintoPaymentPosting(paymentInfoBo, postBo);
                        }
                    }
                    else
                    {
                        paymentInfoBal.InsertintoPaymentPosting(paymentInfoBo, postBo);
                    }
                    GetPaymentEntryInfo();
                }
                catch
                {
                    throw new Exception("Fail to save Payment Information because of the Error : ");
                }
            }
            else
            {
                PaymentInfoBO paymentInfoBo = new PaymentInfoBO();
                float floatTryParse;
                paymentInfoBo.RecievedDate = dtRecievedDate.Value;
                paymentInfoBo.RecievedBy = txtRecievedBy.Text;
                //if previously deposited now withdraw and vice versa
                if (ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                {
                    paymentInfoBo.DepositWithdraw = depositWithdraw.Withdraw;
                }
                if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    paymentInfoBo.DepositWithdraw = depositWithdraw.Deposit;
                }
                paymentInfoBo.PaymentApprovedBy = null;
                paymentInfoBo.PaymentApprovedDate = null;
                paymentInfoBo.Remarks = txtRemarks.Text.Trim();
                paymentInfoBo.CustCode = txtCustCode.Text;

                if (float.TryParse(txtAmount.Text.Trim(), out floatTryParse))
                    paymentInfoBo.Amount = floatTryParse;
                paymentInfoBo.PaymentMedia = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value;

                if (ddlPaymentMedia.Text == payMethodsObj.Cash_Return)
                {
                    paymentInfoBo.VoucherSlNo = txtSerialNo.Text;
                }
                if (ddlPaymentMedia.Text == payMethodsObj.EFT_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    paymentInfoBo.Bank_ID = Convert.ToInt32(txtEFTBankID.Text.Trim());
                    paymentInfoBo.BankName = txteftBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(txtEFTBranchID.Text.Trim());
                    paymentInfoBo.BranchName = txteftBankBranchName.Text;
                    paymentInfoBo.RoutingNo = txteftRoutingNo.Text;
                    paymentInfoBo.BankAccNo = txtBankAccNo.Text;
                    paymentInfoBo.VoucherSlNo = txteftVoucherNo.Text;
                }

                else if (ddlPaymentMedia.Text == payMethodsObj.EFT_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                {
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlEftDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlEftDepositBankName.Text;// txteftBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlEftDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlEftDepositBranchName.Text;// txteftBankBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlEftDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.BankAccNo = txtEftDepositBankAccNo.Text;
                    paymentInfoBo.VoucherSlNo = txtEftDepositVoucherNo.Text;
                }
                else if (ddlPaymentMedia.Text == payMethodsObj.Cheque_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    paymentInfoBo.IsMatureToday = Convert.ToInt32(chkMatureToday.Checked);
                    paymentInfoBo.PaymentMediaNo = txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;// txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;// txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim();// txtSerialNo.Text;
                }
                else if (ddlPaymentMedia.Text == payMethodsObj.Cheque_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                {
                    paymentInfoBo.IsMatureToday = Convert.ToInt32(chkMatureToday.Checked);
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;// dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;// txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;// txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim();// txtSerialNo.Text;
                }
                paymentInfoBo.TransReason = _transReason;

                if (ddlPaymentMedia.Text == payMethodsObj.PayPal_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;//dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;//txtBankName.Text;
                    paymentInfoBo.Branch_ID =Convert.ToInt32( ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;//txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim(); //txtSerialNo.Text;
                }
                if (ddlPaymentMedia.Text == payMethodsObj.PayPal_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                {
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;//dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;//txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;//txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim(); //txtSerialNo.Text;
                }
                if (ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                {
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;//dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;//txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;//txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim(); //txtSerialNo.Text;
                }
                if (ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                {
                    paymentInfoBo.PaymentMediaNo = txtDepositPaymentMedia.Text.Trim();//txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtDepositPaymentMediaDate.Value;//dtPaymentMediaDate.Value;
                    paymentInfoBo.Bank_ID = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                    paymentInfoBo.BankName = ddlDepositBankName.Text;//txtBankName.Text;
                    paymentInfoBo.Branch_ID = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                    paymentInfoBo.BranchName = ddlDepositBranchName.Text;//txtBranchName.Text;
                    paymentInfoBo.RoutingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                    paymentInfoBo.VoucherSlNo = txtDepositVoucherNo.Text.Trim(); //txtSerialNo.Text;
                }

                try
                {
                    DW_Return_InfoBAL _dwReturn_InfoBAL = new DW_Return_InfoBAL();

                    //if (ddlPaymentMedia.Text == payMethodsObj.TR)
                    //{
                    //    paymentInfoBal.InsertIntoPayment(paymentInfoBo);
                    //}
                    //else
                    //{
                    _dwReturn_InfoBAL.InsertDW_ReturnInfo_IntoPaymentPosting(paymentInfoBo);
                    SetNon_ReturnMode();
                    //}
                    GetPaymentEntryInfo();
                }
                catch
                {
                    throw new Exception("Fail to save Payment Information because of the Error : ");
                }

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //ShowPaymentReviewReport();
            frmReportFormPeriod nReviRep = new frmReportFormPeriod();
            nReviRep.Text = @"New Payment Review Report";
            nReviRep.Title = "New Payment Review Report";
            nReviRep.Show();
        }

        public void ShowPaymentReviewReport()
        {
            CompanyBAL objCompanyBal = new CompanyBAL();
            PaymentReviewBAL paymentBAL = new PaymentReviewBAL();
            DataTable dtPaymentReview = new DataTable();
            crPaymentReview1 crPayment = new crPaymentReview1();
            frmPaymenrReportViewer paymentViewer = new frmPaymenrReportViewer();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            dtPaymentReview = paymentBAL.GneratePaymentReview(DateTime.Today, DateTime.Today);
            crPayment.SetDataSource(dtPaymentReview);

            ///// Load Company Name
            ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

            ///// Load Branch Name
            ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = objCompanyBal.GetHeadofficeInfo();
            ////Load Date
            ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Date: " + DateTime.Today.ToString("dd MMM, yyyy");
            paymentViewer.crvPaymentReview.ReportSource = crPayment;
            paymentViewer.Show();
        }

        private void ClearAll()
        {
            txtStatus.Text = "";
            txtSerialNo.Text = "";
            txtPaymentMedia.Text = "";
            txtBranchName.Text = "";
            txtBankName.Text = "";
            txtVoucherNo.Text = "";
            txtTransCustName.Text = "";
            txtTransBalance.Text = "";
            txtTransCustomer.Text = "";
            txtSearchCustomer.Text = "";
            txtRemarks.Text = "";
            txtCustCode.Text = "";
            txtAmount.Text = "";
            txtStatus.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            txtCurrentBalance.Text = "";
            txtMaturedBalance.Text = "";
            ddlSearchCustomer.SelectedIndex = 0;
            ddlPaymentMedia.SelectedIndex = 0;
            ddlDepositWithdraw.SelectedIndex = 0;
            chkMatureToday.Checked = false;
            chkMatureToday.Visible = false;
            dtRecievedDate.Value = DateTime.Now;
            txtlastTradeDate.Text = "";
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
            txtCurrentBalance.BackColor = System.Drawing.Color.LightGray;
            txtMaturedBalance.BackColor = System.Drawing.Color.LightGray;
            txtSearchCustomer.Focus();

        }
        private void ClearAfterSave()
        {
            txtSerialNo.Text = "";
            txtPaymentMedia.Text = "";
            txtBranchName.Text = "";
            txtBankName.Text = "";
            txtVoucherNo.Text = "";
            txtTransCustName.Text = "";
            txtTransBalance.Text = "";
            txtTransCustomer.Text = "";
            txtSearchCustomer.Text = "";
            txtRemarks.Text = "";
            txtCustCode.Text = "";
            txtAmount.Text = "";
            txtStatus.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            txtCurrentBalance.Text = "";
            txtMaturedBalance.Text = "";
            txtTrAvailAbleBalance.Text = "";
            txtTrAccruedBalance.Text = "";

            txteftBankName.Text = string.Empty;
            txteftBankBranchName.Text = string.Empty;
            txteftRoutingNo.Text = string.Empty;
            txteftVoucherNo.Text = string.Empty;
            txtBankAccNo.Text = "";

            ddlSearchCustomer.SelectedIndex = 0;
            chkMatureToday.Checked = false;
            chkMatureToday.Visible = false;
            txtlastTradeDate.Text = "";
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
            txtCurrentBalance.BackColor = System.Drawing.Color.LightGray;
            txtMaturedBalance.BackColor = System.Drawing.Color.LightGray;
            txtSearchCustomer.Focus();

        }
        private void ClearNoCustomerFound()
        {
            txtSerialNo.Text = "";
            txtPaymentMedia.Text = "";
            txtBranchName.Text = "";
            txtBankName.Text = "";
            txtVoucherNo.Text = "";
            txtTransCustName.Text = "";
            txtTransBalance.Text = "";
            txtTransCustomer.Text = "";
            // txtSearchCustomer.Text = "";
            txtRemarks.Text = "";
            txtCustCode.Text = "";
            txtAmount.Text = "";
            txtStatus.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            txtCurrentBalance.Text = "";
            txtMaturedBalance.Text = "";

            txteftBankName.Text = string.Empty;
            txteftBankBranchName.Text = string.Empty;
            txteftRoutingNo.Text = string.Empty;
            txteftVoucherNo.Text = string.Empty;
            txtBankAccNo.Text = "";

            ddlSearchCustomer.SelectedIndex = 0;
            chkMatureToday.Checked = false;
            chkMatureToday.Visible = false;
            txtlastTradeDate.Text = "";
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
            txtCurrentBalance.BackColor = System.Drawing.Color.LightGray;
            txtMaturedBalance.BackColor = System.Drawing.Color.LightGray;
            txtSearchCustomer.Focus();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchCustomerInformation()        {
           

            if (txtSearchCustomer.Text.Trim() != "")
            {
                decimal MaturedBalance = 0;
                decimal AccruedBalance = 0;
                decimal AvailableWithdrawBalance = 0;

                txtlastTradeDate.Text = "";
                DataTable custDateTable = new DataTable();
                CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
                if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
                {
                    _boID = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);
                    if (custDateTable.Rows.Count > 0)
                    {
                        PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        CommonBAL commbal = new CommonBAL();
                        string _custCode = custDateTable.Rows[0][0].ToString();

                        txtCurrentBalance.Text = paymentInfoBal.GetCurrentBalane(_custCode).ToString("N");
                        MaturedBalance = Convert.ToDecimal(paymentInfoBal.GetMaturedBalane(_custCode));
                        txtMaturedBalance.Text = MaturedBalance.ToString("N");
                        AccruedBalance = Convert.ToDecimal(paymentInfoBal.GetCurrentBalaneforAccrued(_custCode));
                        txtAccruedBalance.Text = AccruedBalance.ToString("N");
                        txtAvailableWithdrawBalance.Text = commbal.GetCurrentAvailAbleBalanceForWithdraw(_custCode).ToString("N");                       
                        txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_ID"].ToString();
                        txtBOStatus.Text = custDateTable.Rows[0]["BO_Status"].ToString();
                        txtlastTradeDate.Text = custDateTable.Rows[0]["LTD"].ToString();
                        txtStatus.Text = custDateTable.Rows[0]["Status"].ToString();
                        txtStatus.ForeColor = txtStatus.Text == @"Closed" ? Color.Red : Color.Blue;
                        txtBOStatus.ForeColor = txtBOStatus.Text == @"Closed" ? Color.Red : Color.Blue;
                    }
                    else
                    {
                        ClearNoCustomerFound();
                        MessageBox.Show(@"No customer found.");
                        return;
                    }
                }
                else
                {
                    _custCode = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);

                    if (custDateTable.Rows.Count > 0)
                    {

                        PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        CommonBAL commbal = new CommonBAL();
                        txtCurrentBalance.Text = paymentInfoBal.GetCurrentBalane(_custCode).ToString("N");
                        txtMaturedBalance.Text = paymentInfoBal.GetMaturedBalane(_custCode).ToString("N");
                        txtAccruedBalance.Text = paymentInfoBal.GetCurrentBalaneforAccrued(_custCode).ToString("N");
                        txtAvailableWithdrawBalance.Text = commbal.GetCurrentAvailAbleBalanceForWithdraw(_custCode).ToString("N");                       
                        txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_ID"].ToString();
                        txtBOStatus.Text = custDateTable.Rows[0]["BO_Status"].ToString();
                        txtlastTradeDate.Text = custDateTable.Rows[0]["LTD"].ToString();
                        txtStatus.Text = custDateTable.Rows[0]["Status"].ToString();
                        txtStatus.ForeColor = txtStatus.Text == @"Closed" ? Color.Red : Color.Blue;
                        txtBOStatus.ForeColor = txtBOStatus.Text == @"Closed" ? Color.Red : Color.Blue;
                    }
                    else
                    {
                        //ClearNoCustomerFound();
                        ClearByCustCode();
                        // MessageBox.Show("No customer found.");
                        throw new Exception("No customer found.");
                        // return;
                    }
                }

                if (Convert.ToDouble(txtCurrentBalance.Text) <= 0)
                {
                    txtCurrentBalance.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtCurrentBalance.BackColor = System.Drawing.Color.GreenYellow;
                }

                if (Convert.ToDouble(txtMaturedBalance.Text) <= 0)
                {
                    txtMaturedBalance.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtMaturedBalance.BackColor = System.Drawing.Color.GreenYellow;
                }
                txtAmount.Focus();
            }
            else
            {
                ControlToFocus = txtSearchCustomer;
                throw new Exception("Search Code Required");
            }

        }


        private void LoadPanel()
        {
            if (ddlPaymentMedia.Text == payMethodsObj.TR)
            {
                panelPaymentInfo.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = false;
                panelPaymentTransfer.Visible = true;
                ddlDepositWithdraw.Enabled = !(ddlPaymentMedia.Text == payMethodsObj.TR);
                groupBox1.Text = "TR To";
                gbPaymentInfo.Text = "TR From";
                return;
            }

            else if ((ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = false;
                pnlEFT_Deposit.Visible = true;

                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "EFT Info";
                groupBox1.Text = "Account Information";
                //Search_BankBranchComboDataForDeposit();
                
                return;
            }
            else if ((ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = false;
                panelEFT.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "EFT Info";
                groupBox1.Text = "Account Information";
                SearchRoutingInformation();
                return;
            }

            else if (ddlPaymentMedia.Text == payMethodsObj.EFT_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = false;
                pnlEFT_Deposit.Visible = true;

                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "EFT Info";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }
            else if ((ddlPaymentMedia.Text == payMethodsObj.EFT_Return) && (ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);
                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = false;
                panelEFT.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "EFT Info";
                groupBox1.Text = "Account Information";
                return;
            }

            else if ((ddlPaymentMedia.Text == payMethodsObj.Cheque && ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }

            else if ((ddlPaymentMedia.Text == payMethodsObj.Cheque_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }
            else if ((ddlPaymentMedia.Text == payMethodsObj.PayOrder && ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }

            else if ((ddlPaymentMedia.Text == payMethodsObj.PayOrder && ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }

            else if ((ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }
            else if ((ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }

            else if ((ddlPaymentMedia.Text == payMethodsObj.PayPal && ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }

            else if ((ddlPaymentMedia.Text == payMethodsObj.PayPal && ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }

            else if ((ddlPaymentMedia.Text == payMethodsObj.PayPal_Return && ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }

            else if ((ddlPaymentMedia.Text == payMethodsObj.PayPal_Return && ddlDepositWithdraw.Text == depositWithdraw.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = true;
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }
            else
            {
                gbPaymentInfo.Text = ddlPaymentMedia.Text + " Info";
                groupBox1.Text = "Account Information";
                ddlDepositWithdraw.Enabled = !(ddlPaymentMedia.Text == payMethodsObj.TR);
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                pnlDepositWithBankBranchCombo.Visible = false;
                panelPaymentInfo.Visible = true;
                ddlDepositWithdraw.Enabled = false;
                txtBranchName.Enabled = (ddlPaymentMedia.Text != payMethodsObj.TR && ddlPaymentMedia.Text != payMethodsObj.Cash && ddlPaymentMedia.Text != payMethodsObj.Ecash);
                txtBankName.Enabled = (ddlPaymentMedia.Text != payMethodsObj.TR && ddlPaymentMedia.Text != payMethodsObj.Cash && ddlPaymentMedia.Text != payMethodsObj.Ecash);
                txtPaymentMedia.Enabled = (ddlPaymentMedia.Text != payMethodsObj.TR && ddlPaymentMedia.Text != payMethodsObj.Cash && ddlPaymentMedia.Text != payMethodsObj.Ecash);
                dtPaymentMediaDate.Enabled = (ddlPaymentMedia.Text != payMethodsObj.TR && ddlPaymentMedia.Text != payMethodsObj.Cash && ddlPaymentMedia.Text != payMethodsObj.Ecash);

            }
            if (ddlPaymentMedia.Text == payMethodsObj.Cheque)
            {
                chkMatureToday.Visible = true;
            }
        }

        private void ClearPanel()
        {
            txtSerialNo.Text = "";
            txtPaymentMedia.Text = "";
            txtBranchName.Text = "";
            txtBankName.Text = "";
            txtVoucherNo.Text = "";
            txtTransCustName.Text = "";
            txtTransBalance.Text = "";
            chkMatureToday.Checked = false;
            chkMatureToday.Visible = false;
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                LoadInfoByCustCode();
                //SearchCustomerInformation();
                ////if (MenuName == "EFT Requisition")
                //if (ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                //{
                //    SearchRoutingInformation();
                //}
                //else if (ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                //{
                //    Search_BankBranchComboDataForDeposit();
                //}
                //GetPaymentEntryInfo();
            }
            catch (Exception ex)
            {
                //ControlToFocus.Focus();
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadInfoByCustCode()
        {
            ClearByCustCode();
            SearchCustomerInformation();
            if (ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
            {
                // ClearEFT_Information();
                SearchRoutingInformation();
            }
            else if (//(ddlPaymentMedia.Text == payMethodsObj.EFT && ddlDepositWithdraw.Text == depositWithdraw.Deposit)||
                (ddlPaymentMedia.Text == payMethodsObj.Cheque && (ddlDepositWithdraw.Text == depositWithdraw.Deposit ||ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
                || (ddlPaymentMedia.Text == payMethodsObj.PayOrder && (ddlDepositWithdraw.Text == depositWithdraw.Deposit || ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
                || (ddlPaymentMedia.Text == payMethodsObj.PayPal && (ddlDepositWithdraw.Text == depositWithdraw.Deposit || ddlDepositWithdraw.Text == depositWithdraw.Withdraw))
                )
            {
                Search_BankBranchComboDataForDeposit();
            }
            GetPaymentEntryInfo();
            if (ddlPaymentMedia.Text.Contains(Indication_PaymentTransaction.Return_Indicator))
            {
                btnDWReturnInfo.Enabled = true;
            }
            else
            {
                btnDWReturnInfo.Enabled = false;
            }
            SetNextFocus(ddlPaymentMedia.Text, txtSearchCustomer.Name);

        }
        private void ddlSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode.ToString() == "Return")
                {
                    //ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);  
                    LoadInfoByCustCode();
                }
            }
            catch (Exception ex)
            {
                ControlToFocus.Focus();
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_BankBranchComboDataForDeposit()
        {
            try
            {
                string _bankName = "";
                string _branchName = "";
                string _routingNo = "";
                DataTable dtRoutingInfo = new DataTable();
                DataTable dtBankName = new DataTable();
                DataTable dtBranchName = new DataTable();
                PaymentInfoBAL paymentBAL = new PaymentInfoBAL();
                EFT_IssueBAL eftBAL = new EFT_IssueBAL();

                dtRoutingInfo = paymentBAL.GetRoutingInfo(txtSearchCustomer.Text);
                //if (dtRoutingInfo.Rows.Count > 0)
                //{
                //}

                if (dtRoutingInfo.Rows.Count > 0)
                {
                    _bankName = dtRoutingInfo.Rows[0][0].ToString();
                    _branchName = dtRoutingInfo.Rows[0][1].ToString();
                    _routingNo = dtRoutingInfo.Rows[0][2].ToString();

                    if (ddlPaymentMedia.Text == payMethodsObj.EFT)
                    {
                        try
                        {
                            ddlEftDepositBankName.Text = _bankName;
                            ddlEftDepositBranchName.Text = _branchName;
                            ddlEftDepositRoutingNo.Text = _routingNo;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }
                    else if (ddlPaymentMedia.Text == payMethodsObj.Cheque || ddlPaymentMedia.Text == payMethodsObj.PayPal || ddlPaymentMedia.Text == payMethodsObj.PayOrder)
                    {
                        ddlDepositBankName.SelectedItem = _bankName;
                        ddlDepositBranchName.SelectedItem = _branchName;
                        ddlDepositRoutingNo.Text = _routingNo;
                    }
                }
                else
                {
                    if ((ddlPaymentMedia.Text == payMethodsObj.EFT ||ddlPaymentMedia.Text == payMethodsObj.EFT_Return) && ddlDepositWithdraw.Text==depositWithdraw.Deposit)
                    {
                        ddlEftDepositBankName.SelectedIndex=-1;
                        ddlEftDepositBranchName.SelectedIndex = -1;
                        ddlEftDepositRoutingNo.SelectedIndex = -1;
                    }
                    else if ((ddlPaymentMedia.Text == payMethodsObj.Cheque || ddlPaymentMedia.Text == payMethodsObj.Cheque_Return) && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                    {
                        ddlDepositBankName.SelectedIndex = -1;
                        ddlDepositBranchName.SelectedIndex = -1;
                    }
                    else if ((ddlPaymentMedia.Text == payMethodsObj.PayOrder || ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return) && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                    {
                        ddlDepositBankName.SelectedIndex = -1;
                        ddlDepositBranchName.SelectedIndex = -1;
                    }
                    else if ((ddlPaymentMedia.Text == payMethodsObj.PayPal || ddlPaymentMedia.Text == payMethodsObj.PayPal_Return) && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                    {
                        ddlDepositBankName.SelectedIndex = -1;
                        ddlDepositBranchName.SelectedIndex = -1;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        private void SearchRoutingInformation()
        {
            try
            {
                string BankAccNo_Temp;
                DataTable dt = new DataTable();
                PaymentInfoBAL paymentBAL = new PaymentInfoBAL();
                EFT_IssueBAL eftBAL = new EFT_IssueBAL();
                dt = paymentBAL.GetRoutingInfo(txtSearchCustomer.Text);
                txteftBankName.Text = dt.Rows[0][0].ToString();
                txteftBankBranchName.Text = dt.Rows[0][1].ToString();
                txteftRoutingNo.Text = dt.Rows[0][2].ToString();
                txtEFTBankID.Text = dt.Rows[0][4].ToString();
                txtEFTBranchID.Text = dt.Rows[0][5].ToString();
                BankAccNo_Temp = dt.Rows[0][3].ToString();
                eftBAL.BankAccountNo_BusinessRule_FormattingCharacters(ref BankAccNo_Temp);
                eftBAL.BankAccountNo_BusinessRule_MakingUp17Digit(ref BankAccNo_Temp);
                txtBankAccNo.Text = BankAccNo_Temp;
            }
            catch
            {
            }
        }
        //private void SetDWandPaymentMediaEnable()
        //{
        //    if (MenuName == "EFT Requisition")
        //    {
        //        ddlDepositWithdraw.Enabled = false;
        //        ddlPaymentMedia.Enabled = false;
        //    }
        //    else 
        //        ddlDepositWithdraw.Enabled = false;
        //}
        private void ddlPaymentMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearPanel();
                LoadPanel();

                if (ddlPaymentMedia.Text.Contains(Indication_PaymentTransaction.Return_Indicator))
                    btnDWReturnInfo.Enabled = true;
                else
                    btnDWReturnInfo.Enabled = false;
                //}
                //if(ddlDepositWithdraw.Text==depositWithdraw.Deposit)
                //{
                //    _tempDW="Withdraw";
                //}

                //if (ddlPaymentMedia.Text == payMethodsObj.EFT)
                //{
                //    //      CheckCommonValidation();
                //    SearchRoutingInformation();
                //}
                if (!ddlPaymentMedia.Text.Contains(Indication_PaymentTransaction.Return_Indicator))
                //if (ddlPaymentMedia.Text == payMethodsObj.Cash || ddlPaymentMedia.Text == payMethodsObj.Cheque || ddlPaymentMedia.Text == payMethodsObj.EFT || ddlPaymentMedia.Text == payMethodsObj.PayOrder || ddlPaymentMedia.Text == payMethodsObj.PayPal)
                {

                    SetNon_ReturnMode();
                }
                else
                {
                    SetDW_ReturnMode();
                }
                // SetDWandPaymentMediaEnable();
                GetPaymentEntryInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearEFT_Information()
        {
            txteftBankBranchName.Text = "";
            txteftBankName.Text = "";
            txteftRoutingNo.Text = "";
            txteftVoucherNo.Text = "";
            txtBankAccNo.Text = "";
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
        }

        private void ddlPaymentMedia_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.ToString() == "Return")
            //{
            //    btnSave_Click(sender, e);
            //}
            SetNextFocus(ddlPaymentMedia.Text, ddlPaymentMedia.Name);
        }

        private void btnSearchTrans_Click(object sender, EventArgs e)
        {
            if (txtTransCustomer.Text.Trim() != "")
                SearchTransCustomerInformation();
        }

        private void txtTransCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchTransCustomerInformation();
                SetNextFocus(ddlPaymentMedia.Text, txtTransCustomer.Name);
            }
        }

        private void ddlDepositWithdraw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, ddlPaymentMedia.Name);
            }
        }

        private void btnGenerateSerial_Click(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtAmount.Text, e);
        }


        private void ddlDepositWithdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initialize_PaymentMethodsDatasource(ddlDepositWithdraw.Text);
            GetPaymentEntryInfo();

            //if (ddlDepositWithdraw.Text == "Withdraw")
            //{
            //    chkMatureToday.Visible = false;
            //    LoadWithdrawCombo();
            //}            
            //else
            //{
            //    chkMatureToday.Visible = true;
            //    LoadDepositCombo();
            //}
        }

        private void dtpSearchPaymentEntry_ValueChanged(object sender, EventArgs e)
        {
            GetPaymentEntryInfo();
        }
        private void SetVoucherNo()
        {
            PaymentInfoBAL obj = new PaymentInfoBAL();
            string serial = obj.GenerateSerial();
            if (ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
            {
                txteftVoucherNo.Text = serial;
            }
            if (ddlDepositWithdraw.Text == depositWithdraw.Deposit)
            {
                txtEftDepositVoucherNo.Text = serial;
            }
        }
        private void btneftAutoVoucher_Click(object sender, EventArgs e)
        {
            //PaymentInfoBAL obj = new PaymentInfoBAL();
            //string serial = obj.GenerateSerial();
            txteftVoucherNo.Text = EFT_Voucher_Autogen;
            //txtRemarks.Focus();
            txtRecievedBy.Focus();
        }

        private void txteftVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, txteftVoucherNo.Name);
            }
        }

        private void txtPaymentMedia_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txtBankName.Name);
        }

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txtBranchName.Name);

        }

        private void btnGenerateSerial_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    ControlNextFocus(ddlPaymentMedia.Text, btnGenerateSerial.Name);

        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txtRemarks.Name);

        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txtAmount.Name);
        }

        private void txtSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txtSerialNo.Name);
        }
        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txtVoucherNo.Name);
        }

        private void LoadDataFromGrid()
        {
            foreach (DataGridViewRow row in this.dgvPaymentInfo.SelectedRows)
            {
                if (dgvPaymentInfo[0, row.Index].Value != DBNull.Value)
                    _paymentID = Convert.ToInt64(dgvPaymentInfo[0, row.Index].Value);
                _status = dgvPaymentInfo[8, row.Index].Value.ToString();
            }

        }
        private void btnDepositCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPaymentInfo.Rows.Count > 0)
                {
                    //if (dgvPaymentInfo.SelectedRows[0].Cells["Status"].Value.ToString().Equals("Pending"))
                    //{
                    if (MessageBox.Show("Do you want to continue to cancel the Deposit?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (ddlPaymentMedia.Text == payMethodsObj.TR)
                        {
                            MessageBox.Show("Transfer Not be Canceled, Please Contact System Administrator", "Cancel Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        LoadDataFromGrid();
                        PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        paymentInfoBal.CancelDeposit(_paymentID);
                        MessageBox.Show("Deposit Request successfully Canceled.");
                        GetPaymentEntryInfo();

                    }
                    // }

                    else
                    {
                        MessageBox.Show("The Selected Deposit has allready " + dgvPaymentInfo.SelectedRows[0].Cells["Status"].Value.ToString() + ". It Can not be Cancel.", "Invalid Selection.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                else
                {
                    MessageBox.Show("No customer exists for Cancel Deposit", "Invalid Selection.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetPaymentEntryInfo();
        }

        private void btnDWReturnInfo_Click(object sender, EventArgs e)
        {
            string _tempDW = "";
            _tempDW = Mapping_PaymentTransaction.Find(p => p.Key == ddlPaymentMedia.Text).Value;
            if (txtSearchCustomer.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Customer Code");
                return;
            }
            if (!(ddlPaymentMedia.Text.Contains(Indication_PaymentTransaction.Return_Indicator)))// == payMethodsObj.Cash_Return || ddlPaymentMedia.Text == payMethodsObj.Cheque_Return || ddlPaymentMedia.Text == payMethodsObj.EFT_Return || ddlPaymentMedia.Text == payMethodsObj.PayOrder_Return || ddlPaymentMedia.Text == payMethodsObj.PayPal_Return))
            {
                MessageBox.Show("Please select payment media as a return mode");
                return;
            }
            frmdeposit_withdraw_Return eftReturn = new frmdeposit_withdraw_Return(txtSearchCustomer.Text, ddlDepositWithdraw.Text, _tempDW);
            eftReturn.StartPosition = FormStartPosition.CenterScreen;
            eftReturn.ShowDialog(this);
            SetNextFocus(ddlPaymentMedia.Text, btnDWReturnInfo.Name);

        }

        private void btnEftCheckDepositAutogen_Click(object sender, EventArgs e)
        {
            txtEftDepositVoucherNo.Text = EFT_Voucher_Autogen;
            txtRecievedBy.Focus();
        }

        private void txtDepositPaymentMedia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, txtDepositPaymentMedia.Name);
            }
        }

        private void dtDepositPaymentMediaDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, dtDepositPaymentMediaDate.Name);
            }
        }

        private void ddlDepositBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlDepositBankName.DroppedDown)
                {
                    ddlDepositBankName.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddlDepositBankName.Name);
            }
        }

        private void ddlDepositBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlDepositBranchName.DroppedDown)
                {
                    ddlDepositBranchName.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddlDepositBranchName.Name);
            }
        }

        private void txtDepositVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, txtDepositVoucherNo.Name);
            }
        }
        #region EFT Deposit Section
        private void ddlEftDepositBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlEftDepositBankName.DroppedDown)
                {
                    ddlEftDepositBankName.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddlEftDepositBankName.Name);
            }
        }
        private void ddlEftDepositBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlEftDepositBranchName.DroppedDown)
                {
                    ddlEftDepositBranchName.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddlEftDepositBranchName.Name);
            }
        }
        private void txtEftDepositBankAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, txtEftDepositBankAccNo.Name);
            }
        }
        private void LoadEftBranchInfoByBankId(int bankId)
        {
            var dtbranch = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                           .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable().Where(t => Convert.ToInt32(t["Bank_ID"]) == bankId)
                           .Select(t => new { Value = t["Branch_Name"] + "(" + t["Routing_No"] + ")", Key = Convert.ToInt32(t["Branch_ID"]) }).ToList();



            var MaxLen = dtbranch.Select(t => t.Value.Length).Max();

            ddlEftDepositBranchName.DataSource = dtbranch;
            ddlEftDepositBranchName.ValueMember = "Key";
            ddlEftDepositBranchName.DisplayMember = "Value";
            ddlEftDepositBranchName.DropDownWidth = MaxLen * 7;
            ddlEftDepositBranchName.SelectedIndex = 0;
        }
        private void ddlEftDepositBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int bankId = Convert.ToInt32(ddlEftDepositBankName.SelectedValue.ToString());
                LoadEftBranchInfoByBankId(bankId);
            }
            catch 
            {

            }
        }
        private void ddlEftDepositBankName_DropDown(object sender, EventArgs e)
        {
            ddlEftDepositBankName.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlEftDepositBankName_DropDownClosed(object sender, EventArgs e)
        {
            ddlEftDepositBankName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void ddlEftDepositBankName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int bankId = Convert.ToInt32(ddlEftDepositBankName.SelectedValue.ToString());
                LoadEftBranchInfoByBankId(bankId);
            }
            catch
            {

            }

        }
        private void LoadEftRoutingInfoByBranchId(int branchId)
        {
            var routingNo = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                            .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                            .Where(t => Convert.ToInt32(t["Branch_ID"]) == branchId)
                            .Select(t => t["Routing_No"]).FirstOrDefault();

            ddlEftDepositRoutingNo.SelectedValue = routingNo;

        }
        private void ddlEftDepositBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int branchId = 0;
            try
            {
                branchId = Convert.ToInt32(ddlEftDepositBranchName.SelectedValue.ToString());
                LoadEftRoutingInfoByBranchId(branchId);
            }
            catch
            {

            }
        }
        private void ddlEftDepositBranchName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int branchId = 0;
            try
            {
                branchId = Convert.ToInt32(ddlEftDepositBranchName.SelectedValue.ToString());
                LoadEftRoutingInfoByBranchId(branchId);
            }
            catch
            {

            }
        }
        private void ddlEftDepositBranchName_DropDown(object sender, EventArgs e)
        {
            ddlEftDepositBranchName.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlEftDepositBranchName_DropDownClosed(object sender, EventArgs e)
        {
            ddlEftDepositBranchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void LoadEFTBankBranchByRoutingNo(string routingNo)
        {
            var BankID = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                        .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                        .Where(t => t["Routing_No"].ToString() == routingNo)
                        .Select(t => t["Bank_ID"]).FirstOrDefault();
            var BranchID = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                        .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                        .Where(t => t["Routing_No"].ToString() == routingNo)
                        .Select(t => t["Branch_ID"]).FirstOrDefault();


            if (BankID != null || BranchID != null)
            {
                ddlEftDepositBankName.SelectedValue = BankID;
                ddlEftDepositBranchName.SelectedValue = BranchID;
            }
        }
        private void ddlEftDepositRoutingNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string routingNo = string.Empty;
            try
            {
                routingNo = ddlEftDepositRoutingNo.SelectedValue.ToString();
                LoadEFTBankBranchByRoutingNo(routingNo);
            }

            catch
            {

            }
        }
        private void ddlEftDepositRoutingNo_DropDown(object sender, EventArgs e)
        {
            ddlEftDepositRoutingNo.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlEftDepositRoutingNo_DropDownClosed(object sender, EventArgs e)
        {
            ddlEftDepositRoutingNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void ddlEftDepositRoutingNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string routingNo = string.Empty;
            try
            {
                routingNo = ddlEftDepositRoutingNo.SelectedValue.ToString();
                LoadEFTBankBranchByRoutingNo(routingNo);
            }

            catch
            {

            }
        }
        private void ddlEftDepositRoutingNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlEftDepositRoutingNo.DroppedDown)
                {
                    ddlEftDepositRoutingNo.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddlEftDepositRoutingNo.Name);
            }
        }
        #endregion EFT Deposit Section

        #region Non EFT Deposit Section
        private void LoadNonEFTBranchInfoByBankId(int bankId)
        {
            var dtbranch = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                           .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable().Where(t => Convert.ToInt32(t["Bank_ID"]) == bankId)
                           .Select(t => new { Value = t["Branch_Name"] + "(" + t["Routing_No"] + ")", Key = Convert.ToInt32(t["Branch_ID"]) }).ToList();



            var MaxLen = dtbranch.Select(t => t.Value.Length).Max();

            ddlDepositBranchName.DataSource = dtbranch;
            ddlDepositBranchName.ValueMember = "Key";
            ddlDepositBranchName.DisplayMember = "Value";
            ddlDepositBranchName.DropDownWidth = MaxLen * 7;

        }
        private void ddlDepositBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int bankId = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                LoadNonEFTBranchInfoByBankId(bankId);
            }
            catch
            {

            }
        }
        private void ddlDepositBankName_DropDown(object sender, EventArgs e)
        {
            ddlDepositBankName.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlDepositBankName_DropDownClosed(object sender, EventArgs e)
        {
            ddlDepositBankName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void ddlDepositBankName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int bankId = Convert.ToInt32(ddlDepositBankName.SelectedValue.ToString());
                LoadNonEFTBranchInfoByBankId(bankId);
            }
            catch
            {

            }
        }
        private void txtEftDepositVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, txtEftDepositVoucherNo.Name);
            }
        }
        private void txtRecievedBy_KeyDown(object sender, KeyEventArgs e)
        {
            SetNextFocus(ddlPaymentMedia.Text, txtRecievedBy.Name);
        }
        private void LoadBranchNameByBranchID(int branchId)
        {
            var routingNo = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                .Where(t => Convert.ToInt32(t["Branch_ID"]) == branchId)
                .Select(t => t["Routing_No"]).SingleOrDefault();
            ddlDepositRoutingNo.SelectedValue = routingNo;   
        }
        private void ddlDepositBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int branchId = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                LoadBranchNameByBranchID(branchId);
            }
            catch
            {
            }
        }
        private void ddlDepositBranchName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int branchId = Convert.ToInt32(ddlDepositBranchName.SelectedValue.ToString());
                LoadBranchNameByBranchID(branchId);
            }
            catch
            {
            }
        }
        private void ddlDepositBranchName_DropDown(object sender, EventArgs e)
        {
            ddlDepositBranchName.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlDepositBranchName_DropDownClosed(object sender, EventArgs e)
        {
            ddlDepositBranchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void LoadBankBranchByRoutingNo(string routingNo)
        {
            try
            {
                var BankID = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                .Where(t => t["Routing_No"].ToString() == routingNo)
                .Select(t => t["Bank_ID"]).SingleOrDefault();

                var BranchID = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                            .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                            .Where(t => t["Routing_No"].ToString() == routingNo)
                            .Select(t => t["Branch_ID"]).SingleOrDefault();

                ddlDepositBankName.SelectedValue = BankID;
                ddlDepositBranchName.SelectedValue = BranchID;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void ddlDepositRoutingNo_DropDown(object sender, EventArgs e)
        {
            ddlDepositRoutingNo.AutoCompleteMode = AutoCompleteMode.None;
           
        }
        private void ddlDepositRoutingNo_DropDownClosed(object sender, EventArgs e)
        {
            ddlDepositRoutingNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            
        }
        private void ddlDepositRoutingNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string routingNo = string.Empty;
            try
            {
                routingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                LoadBankBranchByRoutingNo(routingNo);
            }
            catch
            {

            }

        }
        private void ddlDepositRoutingNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddlDepositRoutingNo.DroppedDown)
                {
                    ddlDepositRoutingNo.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddlDepositRoutingNo.Name);
            }
        }
        private void ddlDepositRoutingNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string routingNo = string.Empty;
            try
            {
                routingNo = ddlDepositRoutingNo.SelectedValue.ToString();
                LoadBankBranchByRoutingNo(routingNo);
            }
            catch
            {

            }
        }
        #endregion Non EFT Deposit Section

        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void WebDataCasting(Payment_PostingBO bo)
        {
            //txtSearchCustomer.Text = bo.Cust_Code;
            //LoadInfoByCustCode();
            ////ddlSearchCustomer_KeyDown(txtCustCode, new KeyEventArgs(Keys.Enter));
            //CommonBAL bal = new CommonBAL();
            //OnlineOrderNo = bo.OnlineOrderNo;
            //OnlineEntry_Date = bo.OnlineEntry_Date;
            //ddlDepositWithdraw.SelectedIndex = 1;
            //ddlPaymentMedia.SelectedIndex = 4;
            ////ddlPaymentMedia_KeyDown(this.ddlPaymentMedia, new KeyEventArgs(Keys.Enter));
            //ddlDepositWithdraw.Enabled = false;
            //ddlPaymentMedia.Enabled = false;

            //dtRecievedDate.Value = bal.GetCurrentServerDate();
            //txtRecievedBy.Text = bo.Received_By;
            //txtRemarks.Text = "Web Request: "+bo.Remarks;
            //txtAmount.Text = bo.Amount.ToString().Trim();  

            if (bo.Channel.ToUpper() == ("SMS").ToString().ToUpper() || bo.Channel.ToUpper() == ("Email").ToString().ToUpper() || bo.Channel.ToUpper() == ("Web").ToString().ToUpper())
            {
                if (bo.Deposit_Withdraw.ToUpper() == ("Deposit").ToUpper())
                {
                    if (bo.Payment_Media.ToUpper() == ("Cheque").ToUpper())
                    {
                        txtSearchCustomer.Text = bo.Cust_Code;
                        LoadInfoByCustCode();
                        ddlDepositWithdraw.SelectedIndex = 0;
                        ddlPaymentMedia.SelectedIndex = 2;
                        ddlDepositWithdraw.Enabled = false;
                        ddlPaymentMedia.Enabled = false;
                        txtAmount.Text = bo.Amount.ToString().Trim();
                        CommonBAL bal = new CommonBAL();
                        dtRecievedDate.Value = bal.GetCurrentServerDate();
                        txtDepositPaymentMedia.Text = bo.Cheque_Number;

                        OnlineOrderNo = bo.OnlineOrderNo;
                        Channel = bo.Channel;
                        OnlineEntry_Date = bo.OnlineEntry_Date;
                    }
                    else if (bo.Payment_Media.ToUpper() == ("EFT").ToUpper())
                    {
                        if (bo.Deposit_Withdraw.ToUpper() == ("Deposit").ToUpper())
                        {
                            txtSearchCustomer.Text = bo.Cust_Code;
                            LoadInfoByCustCode();
                            ddlDepositWithdraw.SelectedIndex = 0;
                            ddlPaymentMedia.SelectedIndex = 4;
                            ddlDepositWithdraw.Enabled = false;
                            ddlPaymentMedia.Enabled = false;
                            txtAmount.Text = bo.Amount.ToString().Trim();
                            CommonBAL bal = new CommonBAL();
                            dtRecievedDate.Value = bal.GetCurrentServerDate();

                            OnlineOrderNo = bo.OnlineOrderNo;
                            Channel = bo.Channel;
                            OnlineEntry_Date = bo.OnlineEntry_Date;
                        }
                        else
                        {
                            txtSearchCustomer.Text = bo.Cust_Code;
                            LoadInfoByCustCode();
                            ddlDepositWithdraw.SelectedIndex = 1;
                            ddlPaymentMedia.SelectedIndex = 4;
                            ddlDepositWithdraw.Enabled = false;
                            ddlPaymentMedia.Enabled = false;
                            txtAmount.Text = bo.Amount.ToString().Trim();
                            CommonBAL bal = new CommonBAL();
                            dtRecievedDate.Value = bal.GetCurrentServerDate();

                            OnlineOrderNo = bo.OnlineOrderNo;
                            Channel = bo.Channel;
                            OnlineEntry_Date = bo.OnlineEntry_Date;
                        }
                    }
                    else
                    {
                        txtSearchCustomer.Text = bo.Cust_Code;
                        LoadInfoByCustCode();
                        ddlDepositWithdraw.SelectedIndex = 0;
                        ddlPaymentMedia.SelectedIndex = 0;
                        ddlDepositWithdraw.Enabled = false;
                        ddlPaymentMedia.Enabled = false;
                        txtAmount.Text = bo.Amount.ToString().Trim();
                        CommonBAL bal = new CommonBAL();
                        dtRecievedDate.Value = bal.GetCurrentServerDate();

                        OnlineOrderNo = bo.OnlineOrderNo;
                        Channel = bo.Channel;
                        OnlineEntry_Date = bo.OnlineEntry_Date;
                    }
                }
                else if (bo.Deposit_Withdraw.ToUpper() == ("Withdraw").ToUpper())
                {
                    if (bo.Payment_Media.ToUpper() == ("EFT").ToUpper())
                    {
                        txtSearchCustomer.Text = bo.Cust_Code;
                        LoadInfoByCustCode();
                        ddlDepositWithdraw.SelectedIndex = 1;
                        ddlPaymentMedia.SelectedItem = "EFT";
                        ddlDepositWithdraw.Enabled = false;
                        ddlPaymentMedia.Enabled = false;
                        txtAmount.Text = bo.Amount.ToString().Trim();
                        CommonBAL bal = new CommonBAL();
                        dtRecievedDate.Value = bal.GetCurrentServerDate();

                        OnlineOrderNo = bo.OnlineOrderNo;
                        Channel = bo.Channel;
                        OnlineEntry_Date = bo.OnlineEntry_Date;
                    }
                    else
                    {
                        txtSearchCustomer.Text = bo.Cust_Code;
                        LoadInfoByCustCode();
                        ddlDepositWithdraw.SelectedIndex = 1;
                        ddlPaymentMedia.SelectedIndex = 0;
                        ddlDepositWithdraw.Enabled = false;
                        ddlPaymentMedia.Enabled = false;
                        txtAmount.Text = bo.Amount.ToString().Trim();
                        CommonBAL bal = new CommonBAL();
                        dtRecievedDate.Value = bal.GetCurrentServerDate();

                        OnlineOrderNo = bo.OnlineOrderNo;
                        Channel = bo.Channel;
                        OnlineEntry_Date = bo.OnlineEntry_Date;
                    }
                }
            }
            else
            {
                txtSearchCustomer.Text = bo.Cust_Code;
                LoadInfoByCustCode();
                //ddlSearchCustomer_KeyDown(txtCustCode, new KeyEventArgs(Keys.Enter));
                CommonBAL bal = new CommonBAL();
                OnlineOrderNo = bo.OnlineOrderNo;
                OnlineEntry_Date = bo.OnlineEntry_Date;
                ddlDepositWithdraw.SelectedIndex = 1;
                ddlPaymentMedia.SelectedIndex = 2;
                //ddlPaymentMedia_KeyDown(this.ddlPaymentMedia, new KeyEventArgs(Keys.Enter));
                ddlDepositWithdraw.Enabled = false;
                ddlPaymentMedia.Enabled = false;

                dtRecievedDate.Value = bal.GetCurrentServerDate();
                txtRecievedBy.Text = bo.Received_By;
                txtRemarks.Text = "Web Request: " + bo.Remarks;
                txtAmount.Text = bo.Amount.ToString().Trim();
                Channel = bo.Channel;
            }
        }

        private void btnWebData_Click_1(object sender, EventArgs e)
        {
            //frmWeb2014DataForward frm = new frmWeb2014DataForward("Money Withdraw Forward Payment Posting");
            //frm.pp_Delegate = new frmWeb2014DataForward.DataToPaymentPosting(WebDataCasting);
            //frm.Show();

            if (MenuName == "Payment Withdraw")
            {
                frmWeb2014DataForward frm = new frmWeb2014DataForward("Payment Withdraw Forward Payment Posting");
                frm.pp_Delegate = new frmWeb2014DataForward.DataToPaymentPosting(WebDataCasting);
                frm.Show();
            }
            else if (MenuName == "EFT Requisition")
            {
                frmWeb2014DataForward frm = new frmWeb2014DataForward("EFT Forward Payment Posting");
                frm.pp_Delegate = new frmWeb2014DataForward.DataToPaymentPosting(WebDataCasting);
                frm.Show();
            }
            else
            {
                frmWeb2014DataForward frm = new frmWeb2014DataForward("Money Withdraw Forward Payment Posting");
                frm.pp_Delegate = new frmWeb2014DataForward.DataToPaymentPosting(WebDataCasting);
                frm.Show();
            }
            
        }


        
        

        
    }
}



