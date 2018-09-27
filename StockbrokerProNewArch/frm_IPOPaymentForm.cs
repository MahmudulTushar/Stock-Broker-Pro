using System;
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
using System.Data.Linq;
using System.Data.Common;
using System.Data.SqlClient;

namespace StockbrokerProNewArch 
{
    public partial class frm_IPOPaymentForm : Form
    {

#region Global Variable   

        private enum FormDeposit_Withdraw {Deposit,Withdraw};
        public enum RefundPanelMode { TRTA, TRIPO, EFT, MMT, TRPR, TRPRIPO, Default, };
        private string CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return = "CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return";
        private DataTable dt_CustList_IPOPayment;
       
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
           
        private string _status;
        private int _paymentID;
        private string _transReason;
        private bool _formLoad = false;
        private string routingNoText = "";
        private Dictionary<string, object> PaymentForm_Cache = new Dictionary<string, object>();

        private string[] DepositWithdrawType;
        private string[] Deposit;
        private string[] Withdraw;

        private bool isclosed=false;
        
        bool isSearchedBankBranchIdByRoutingNo = false;

        decimal Deposit_Pending_Balance = 0.0M;
        decimal Withdraw_Pending_Balance = 0.0M;
        decimal Total_Balance = 0.0M;
        decimal IPO_Cur_Balance = 0.0M;
        decimal Total_Approved_Pending_Balance = 0.0M;
        decimal GoingBalance = 0.0M;
        string Deposit_Transaction_Name = "";
        string Withdraw_Transaction_Name = "";
        string Customer = "";
        decimal Tr_CurrentBalance = 0.0M;
        decimal Tr_Pending_Deposit = 0.0M;
        decimal Tr_Pending_Withdraw = 0.0M;
        decimal Tr_AvailableWithdraw_Balance = 0.0M;
      
        private List<string> ExceptionCollectionList;
        bool IsCollectiveExceptionOn = false;

        public string TransID="";

        


       
#endregion Global Variable

#region Collection
              

        //---------------------------Previllize List stored same in Database------------------------//
       
#endregion Collection

#region Constructor

        public frm_IPOPaymentForm()
        {
            InitializeComponent();
            Init_Datatable_CustList_IPOPayment();

            Initialize_PaymentMethod_For_DepositWithdrawArray();
            LoadBank_Branch_Routing_Info();
            LoadRefundMethod();
            Initialize_DepositWithdrawComboDatasource();
            
            FormResize();
                       
            //EnterIndex_Execution(depositWithdraw.Withdraw,Indication_IPOPaymentTransaction.EFT,txtAmount.Name);
            //Initialize_PaymentMethodsDatasource(ddlDepositWithdraw.Text);
            //LoadPrevillize();
        }

        public frm_IPOPaymentForm(string Pr_MenuName)
        {
            MenuName = Pr_MenuName;
            InitializeComponent();
            Init_Datatable_CustList_IPOPayment();

            Initialize_PaymentMethod_For_DepositWithdrawArray();
            LoadBank_Branch_Routing_Info();
            LoadRefundMethod();
            Initialize_DepositWithdrawComboDatasource();

            FormResize();
            if (Indication_Forms_Title.IPOPaymentDeposit.ToLower().Trim() == MenuName.ToLower().Trim())
            {
                ChkNegativeBalanceNotCalculate.Visible = false;
            }
            else
            {
                ChkNegativeBalanceNotCalculate.Visible = true;
            }
        }

#endregion Constructor

#region Initialization&Relevent

        private void Init()
        {
            ExceptionCollectionList = new List<string>();
            ddlSearchCustomer.SelectedIndex = 0;
            if (MenuName == Indication_Forms_Title.IPOPaymentDeposit)
            {
                ddlDepositWithdraw.SelectedIndex = 0;
                //Initialize_PaymentMethodsDatasource(FormDeposit_Withdraw.Deposit);
                label2.Text = @"Withdraw :";
                ddlDepositWithdraw.Enabled = false;
                btnWebData.Enabled = false;
            }
            else if (MenuName == Indication_Forms_Title.IPOPaymentWithdraw)
            {
                ddlDepositWithdraw.SelectedIndex = 1;
                //Initialize_PaymentMethodsDatasource(FormDeposit_Withdraw.Withdraw);
                label2.Text = @"Deposit :";
                ddlDepositWithdraw.Enabled = false;
                btnWebData.Enabled = false;
            }
            LoadPanel();
            LoadRefundPanel();
            chkMatureToday.Visible = false;
            txtSearchCustomer.Focus();
        }

        private void Init_Datatable_CustList_IPOPayment()
        {
            dt_CustList_IPOPayment = new DataTable();
            dt_CustList_IPOPayment.Columns.Add("IsChargable", typeof(bool));
            dt_CustList_IPOPayment.Columns.Add("Cust_Code", typeof(string));
            dt_CustList_IPOPayment.Columns.Add("BOID", typeof(string));
            dt_CustList_IPOPayment.Columns.Add("Status", typeof(string));
            dt_CustList_IPOPayment.Columns.Add("IPO_Mone_Bal", typeof(double));
            dt_CustList_IPOPayment.Columns.Add("Distributed_Amount", typeof(double));
            dt_CustList_IPOPayment.Columns.Add("BankAccNo", typeof(string));
            dt_CustList_IPOPayment.Columns.Add("RoutingNo", typeof(string));
            dt_CustList_IPOPayment.Columns.Add("BankID", typeof(int));
            dt_CustList_IPOPayment.Columns.Add("BankName", typeof(string));
            dt_CustList_IPOPayment.Columns.Add("BranchID", typeof(int));
            dt_CustList_IPOPayment.Columns.Add("BranchName", typeof(string));
            dt_CustList_IPOPayment.Columns.Add("ChannelID", typeof(string));
            dt_CustList_IPOPayment.Columns.Add("ChannelType", typeof(string));
        }

        public void FormResize()
        {
            this.Size = new Size(709, 872);
            gbPaymentInfo.Controls.Add(pnlEFT_Deposit);
            gbPaymentInfo.Controls.Add(panelChequeDeposit);
            gbPaymentInfo.Controls.Add(panelEFT);
            gbPaymentInfo.Controls.Add(panelPaymentTransfer);
            gbPaymentInfo.Controls.Add(panelPaymentInfo);
            gbPaymentInfo.Controls.Add(dgPanerlEft);

            pnlEFT_Deposit.Location = new Point(7, 17);
            panelChequeDeposit.Location = new Point(7, 17);
            panelEFT.Location = new Point(7, 17);
            panelPaymentTransfer.Location = new Point(7, 17);
            panelPaymentInfo.Location = new Point(7, 17);
            dgPanerlEft.Location = new Point(7, 17);
        }

        private void Initialize_PaymentMethodsDatasource(FormDeposit_Withdraw fw)
        {
            if (fw==FormDeposit_Withdraw.Deposit)
            {
                LoadDepositCombo();
                //ddlPaymentMedia.DataSource = Deposit;
                if (ddlPaymentMedia.Items.Count > 0)
                    ddlPaymentMedia.SelectedIndex = 0;
            }
            else if (fw==FormDeposit_Withdraw.Withdraw)
            {
               
                LoadWithdrawCombo();
                //ddlPaymentMedia.DataSource = Withdraw;
                if (ddlPaymentMedia.Items.Count > 0)
                    ddlPaymentMedia.SelectedIndex = 0;
            }
        }       
              
        private void Initialize_DepositWithdrawComboDatasource()
        {
            ddlDepositWithdraw.Items.Clear();
            string[] depwith_Temp = new string[] {Indication_PaymentMode.Deposit,Indication_PaymentMode.Withdraw};
            foreach (var obj in depwith_Temp)
                ddlDepositWithdraw.Items.Add(obj);
        }
       
        private void Initialize_PaymentMethod_For_DepositWithdrawArray()
        {
            Deposit = new string[] { Indication_IPOPaymentTransaction.Cash,Indication_IPOPaymentTransaction.Ecash, Indication_IPOPaymentTransaction.Cheque, Indication_IPOPaymentTransaction.Cheque_Return, Indication_IPOPaymentTransaction.EFT,Indication_IPOPaymentTransaction.EFT_Return, Indication_IPOPaymentTransaction.TRTA, Indication_IPOPaymentTransaction.TRIPO };
            Withdraw = new string[] { Indication_IPOPaymentTransaction.Cash, Indication_IPOPaymentTransaction.Cheque, Indication_IPOPaymentTransaction.EFT, Indication_IPOPaymentTransaction.TRTA, Indication_IPOPaymentTransaction.TRIPO };
        }

#endregion Initialization&Relevent

#region Previledge

        private void SetPermission()
        {
            //DataTable data = new DataTable();
            //SecerityInfoBAL sec = new SecerityInfoBAL();
            //Transfer_Not_Allowed = "";
            //EFT_Not_Allowed = "";
            //data = sec.GetPermission();
            //if (data.Rows.Count > 0)
            //{
            //    if (data.Rows.Count > 1)
            //    {
            //        Transfer_Not_Allowed = data.Rows[0][0].ToString();
            //        EFT_Not_Allowed = data.Rows[1][0].ToString();
            //    }
            //    else
            //    {
            //        if (data.Rows[0][0].ToString() == "Transfer Not Allowed")
            //        {
            //            Transfer_Not_Allowed = data.Rows[0][0].ToString();
            //        }
            //        else
            //        {
            //            EFT_Not_Allowed = data.Rows[0][0].ToString();
            //        }
            //    }

            //    if (Transfer_Not_Allowed == "Transfer Not Allowed" && EFT_Not_Allowed == "EFT Not Allowed")
            //    {
            //        Initialize_DepositWithdrawArray(Transfer_Not_Allowed, EFT_Not_Allowed);
            //    }
            //    else if (Transfer_Not_Allowed == "Transfer Not Allowed" && EFT_Not_Allowed == "")
            //    {
            //        Initialize_DepositWithdrawArray(Transfer_Not_Allowed);
            //    }
            //    else if (Transfer_Not_Allowed == "" && EFT_Not_Allowed == "EFT Not Allowed")
            //    {
            //        Initialize_DepositWithdrawArray(EFT_Not_Allowed);
            //    }
            //}
            //else
            //{
            //    Initialize_DepositWithdrawArray();
            //}
        }

        private void LoadPrevillize()
        {
            //bool Userassigned = false;
            //bool Roleassigned = false;

            //string tempPrevilize = "";
            //DataTable RoleWithUserprevillizeDataTable = new DataTable();
            //DataTable RolewisePrevillizeDataTable = new DataTable();
            //PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();
            //FieldInfo[] paymentMediaFields = Indication_IPOPaymentTransaction.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            //if (MenuName == "EFT Requisition")
            //{
            //    return;
            //}
            //PrevilizePaymentMedia.Clear();
            ///////////////////// Get Assigned Users for a Role  //////////////////////////
            //RoleWithUserprevillizeDataTable = previllizeManagementBal.GetAssignedPrevillizeByUserName(GlobalVariableBO._userName);
            //if (RoleWithUserprevillizeDataTable.Rows.Count > 0)
            //{
            //        for (int i = 0; i < RoleWithUserprevillizeDataTable.Rows.Count; i++)
            //        {
            //            if (RoleWithUserprevillizeDataTable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
            //            {
            //                if (PrevillizedPaymentMedia.Contains(RoleWithUserprevillizeDataTable.Rows[i]["Previllize"].ToString().Trim()))
            //                {
            //                    tempPrevilize = RoleWithUserprevillizeDataTable.Rows[i]["Previllize"].ToString();
            //                    InitializePrevillizePaymentMedia(tempPrevilize);
            //                    Userassigned = true;
            //                }
            //            }
            //        }

            //}
            //////////////////////////// Get Previllize for Role ////////////////////////////
            // if (!Userassigned)
            //{
            //    RolewisePrevillizeDataTable = previllizeManagementBal.GetOnlyRoleWisePrevillize();
            //    DataTable dtTable = previllizeManagementBal.GetAllUserAssignedForCurrentRole();
            //    if (CheckAnyUserAssignedForCurrentRole(dtTable))
            //    {
            //        PrevilizePaymentMedia.Clear();
            //        Initialize_PaymentMethodsDatasource(ddlDepositWithdraw.Text);
            //        return;
            //    }
            //    else
            //    {
            //        for (int i = 0; i < RolewisePrevillizeDataTable.Rows.Count; i++)
            //        {
            //            if (PrevillizedPaymentMedia.Contains(RolewisePrevillizeDataTable.Rows[i]["Previllize"].ToString().Trim()))
            //            {

            //                tempPrevilize = RolewisePrevillizeDataTable.Rows[i]["Previllize"].ToString();
            //                InitializePrevillizePaymentMedia(tempPrevilize);
            //                Roleassigned = true;
            //            }
            //        }
            //    }

            //}

            ///////////////////// If No User and Role was Assigned Load Default ////////////////////////
            // //if (!Userassigned && !Roleassigned)
            // //{
            // //    foreach (FieldInfo field in paymentMediaFields)
            // //    {
            // //        PrevilizePaymentMedia.Add(field.GetValue(Indication_IPOPaymentTransaction).ToString());
            // //    }
            // //}
            // Initialize_PaymentMethodsDatasource(ddlDepositWithdraw.Text);
        }

        private bool CheckAnyUserAssignedForCurrentRole(DataTable dataTable)
        {
            bool _isFound = false;
            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    if (PrevillizedPaymentMedia.Contains(dataTable.Rows[i]["Previllize"].ToString().Trim()))
            //    {
            //        _isFound = true;
            //        break;
            //    }
            //}
            return _isFound;
        }

        private void AddPrevillizePaymentMedia(string Deposit_Withdraw, string PaymentMedia)
        {
            //if (ddlDepositWithdraw.Text == Deposit_Withdraw)
            //{
            //    PrevilizePaymentMedia.Add(PaymentMedia);
            //}
            ////else if (ddlDepositWithdraw.Text == Deposit_Withdraw)
            ////{
            ////    PrevilizePaymentMedia.Add(PaymentMedia);
            ////}
        }

        private void InitializePrevillizePaymentMedia(string previlize)
        {
            //switch (previlize)
            //{
            //    case Indication_PaymentForm_Previllize.Cash_Deposit:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.Cash);
            //        break;
            //    case Indication_PaymentForm_Previllize.Cash_Deposit_Return:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.Cash_Return);
            //        break;
            //    case Indication_PaymentForm_Previllize.Cash_Withdraw:
            //        AddPrevillizePaymentMedia(depositWithdraw.Withdraw, Indication_IPOPaymentTransaction.Cash);
            //        break;
            //    case Indication_PaymentForm_Previllize.Cash_Withdraw_Return:
            //        AddPrevillizePaymentMedia(depositWithdraw.Withdraw, Indication_IPOPaymentTransaction.Cash_Return);
            //        break;
            //    case Indication_PaymentForm_Previllize.Cheque_Deposit:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.Cheque);
            //        break;
            //    case Indication_PaymentForm_Previllize.Cheque_Deposit_Return:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.Cheque_Return);
            //        break;
            //    case Indication_PaymentForm_Previllize.EFT_Deposit:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.EFT);
            //        break;
            //    case Indication_PaymentForm_Previllize.EFT_Deposit_Return:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.EFT_Return);
            //        break;
            //    case Indication_PaymentForm_Previllize.EFT_Withdraw:
            //        AddPrevillizePaymentMedia(depositWithdraw.Withdraw, Indication_IPOPaymentTransaction.EFT);
            //        break;
            //    case Indication_PaymentForm_Previllize.EFT_Withdraw_Return:
            //        AddPrevillizePaymentMedia(depositWithdraw.Withdraw, Indication_IPOPaymentTransaction.EFT_Return);
            //        break;
            //    case Indication_PaymentForm_Previllize.Paypal_Deposit:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.PayPal);
            //        break;
            //    case Indication_PaymentForm_Previllize.Paypal_Deposit_Return:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.PayPal_Return);
            //        break;
            //    case Indication_PaymentForm_Previllize.Paypal_Withdraw:
            //        AddPrevillizePaymentMedia(depositWithdraw.Withdraw, Indication_IPOPaymentTransaction.PayPal);
            //        break;
            //    case Indication_PaymentForm_Previllize.Paypal_Withdraw_Return:
            //        AddPrevillizePaymentMedia(depositWithdraw.Withdraw, Indication_IPOPaymentTransaction.PayPal_Return);
            //        break;
            //    case Indication_PaymentForm_Previllize.Payorder_Deposi:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.PayOrder);
            //        break;
            //    case Indication_PaymentForm_Previllize.Payorder_Deposit_Return:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.PayOrder_Return);
            //        break;
            //    case Indication_PaymentForm_Previllize.Payorder_Withdraw:
            //        AddPrevillizePaymentMedia(depositWithdraw.Withdraw, Indication_IPOPaymentTransaction.PayOrder);
            //        break;
            //    case Indication_PaymentForm_Previllize.Payorder_Withdraw_Return:
            //        AddPrevillizePaymentMedia(depositWithdraw.Withdraw, Indication_IPOPaymentTransaction.PayOrder_Return);
            //        break;
            //    case Indication_PaymentForm_Previllize.Deposit_Transfer:
            //        AddPrevillizePaymentMedia(depositWithdraw.Deposit, Indication_IPOPaymentTransaction.TR);
            //        break;
            //    case Indication_PaymentForm_Previllize.Withdraw_Transfer:
            //        AddPrevillizePaymentMedia(depositWithdraw.Withdraw, Indication_IPOPaymentTransaction.TR);
            //        break;               
            //}
        }

#endregion Previledge

#region LoadingMethod

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            CommonBAL cBAL = new CommonBAL();
            _formLoad = true;
            Init();
            txtRecievedBy.Text = GlobalVariableBO._userName;
            txtSearchCustomer.Focus();
            GetPaymentEntryInfo();
            dtRecievedDate.Value = cBAL.GetCurrentServerDate();
            dtRecievedDate.Enabled = false;
            _formLoad = false;
            Set_AppliedTogatherMode(chk_AppliedTogather.Checked);

            ResetPrevillize();
            LoadPrevilize();
        }

        public void ResetPrevillize()
        {
            ChkNegativeBalanceNotCalculate.Visible = false;
           
        }
        private void LoadPrevilize()
        {
            bool result = false;
            DataTable RoleWiseUserPrevillizeDatatable = new DataTable();
            DataTable RoleWisePrevillizeDataTable = new DataTable();
            PrevillizeManagementBAL previllizeManagementBal = new PrevillizeManagementBAL();

            RoleWisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();


            RoleWiseUserPrevillizeDatatable = previllizeManagementBal.GetAssignedPrevillize();
            if (RoleWiseUserPrevillizeDatatable.Rows.Count > 0)
            {
                for (int i = 0; i < RoleWiseUserPrevillizeDatatable.Rows.Count; i++)
                {
                    if (RoleWiseUserPrevillizeDatatable.Rows[i][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                    {
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    for (int j = 0; j < RoleWiseUserPrevillizeDatatable.Rows.Count; j++)
                    {
                        if (RoleWiseUserPrevillizeDatatable.Rows[j][0].ToString().ToLower() == GlobalVariableBO._userName.ToLower())
                        {
                            SetPrevillize(RoleWiseUserPrevillizeDatatable.Rows[j]["Previllize"].ToString());
                        }
                    }
                }
               
            }
            else if (RoleWiseUserPrevillizeDatatable.Rows.Count == 0)
            {
                RoleWisePrevillizeDataTable = previllizeManagementBal.GetRoleWisePrevillize();

                for (int k = 0; k < RoleWisePrevillizeDataTable.Rows.Count; k++)
                {
                    SetPrevillize(RoleWisePrevillizeDataTable.Rows[k]["Previllize"].ToString());
                }
              
            }
        }

        private void SetPrevillize(string Previllize)
        {
            switch (Previllize)
            {
                case "Negative Balance Transfer":
                    ChkNegativeBalanceNotCalculate.Visible = true;
                    break;


                default:
                    break;
            }
        }

        public void LoadRefundMethod()
        {
            DataTable dt = new DataTable();
            IPOProcessBAL ipoBal=new IPOProcessBAL();

            dt = ipoBal.GetRefundMethod();
            cmb_RefundMethod.DataSource = dt;
            cmb_RefundMethod.DisplayMember = "Desc";
            cmb_RefundMethod.ValueMember = "ID";
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


            ddl_DepositEft_Bank_Name.ValueMember = "Key";
            ddl_DepositEft_Bank_Name.DisplayMember = "Value";
            ddl_DepositEft_Bank_Name.DataSource = EftBankDs;
            ddl_DepositEft_Bank_Name.DropDownWidth = MaxLenBank * 7;

            var EftRoutingDs = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
               .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
               .Select(t => new { Key = Convert.ToString(t["Routing_No"]), Value = Convert.ToString(t["Routing_No"]) }).ToList();

            ddl_DepositEft_RoutingNo.ValueMember = "Key";
            ddl_DepositEft_RoutingNo.DisplayMember = "Value";
            ddl_DepositEft_RoutingNo.DataSource = EftRoutingDs;
            ddl_DepositEft_RoutingNo.SelectedIndex = -1;

            //----------------------For Check Info--------------------//

            var NonEftBankDs = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
               .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
               .Select(t => new { Key_Dtl = t["Bank_ID"], Value_Dtl = t["Bank_Name"] }).GroupBy(t => t.Key_Dtl)
               .Select(g => new { Key = g.Key, Value = g.Max(t => t.Value_Dtl) }).ToList();


            ddl_DepositCheque_BankName.ValueMember = "Key";
            ddl_DepositCheque_BankName.DisplayMember = "Value";
            ddl_DepositCheque_BankName.DataSource = NonEftBankDs;

            var NonEftRoutingDs = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable()
                .Select(t => new { Key = t["Routing_No"], Value = t["Routing_No"] }).ToList();

            ddl_DepositCheque_RoutingNo.ValueMember = "Key";
            ddl_DepositCheque_RoutingNo.DisplayMember = "Value";
            ddl_DepositCheque_RoutingNo.DataSource = NonEftRoutingDs;

        }
      
        public void LoadDepositCombo()
        {
            //ddlPaymentMedia.Items.Clear();

            DataTable dt = new DataTable();
            DataTable MappedDt=new DataTable() ;
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            dt = ipoBal.GetIPOMoneyTransType();
            MappedDt = dt.Clone();
            foreach (DataRow dr in dt.Rows)
                if (Deposit.Contains(dr["Name"].ToString()))
                    MappedDt.Rows.Add(dr.ItemArray);


            ddlPaymentMedia.DataSource = MappedDt.Rows.Cast<DataRow>()
                .Select(t=> new{Key=Convert.ToInt32(t["ID"]),Value=Convert.ToString(t["Name"])})
                .OrderBy(t=> t.Value).ToList();
            ddlPaymentMedia.ValueMember = "Key";
            ddlPaymentMedia.DisplayMember = "Value";
           
        }

        public void LoadWithdrawCombo()
        {
            ddlPaymentMedia.Items.Clear();

            IPOProcessBAL ipoBal = new IPOProcessBAL();
            DataTable dt = new DataTable();
            DataTable MappedDt = new DataTable();
            dt = ipoBal.GetIPOMoneyTransType();
            MappedDt = dt.Clone();
            foreach (DataRow dr in dt.Rows)
                if (Withdraw.Contains(dr["Name"].ToString()))
                    MappedDt.Rows.Add(dr.ItemArray);

            ddlPaymentMedia.DisplayMember = "Name";
            ddlPaymentMedia.ValueMember = "ID";
            ddlPaymentMedia.DataSource = MappedDt;
        }

        private void LoadSupportingInformation()
        {
            //if (ddlSearchCustomer.SelectedIndex == 0)
            //{
            //    if (txtCustCode.Text != txtSearchCustomer.Text)
            //    {
            //        SearchCustomerInformation();
            //        return;
            //    }
            //}
            //else
            //{
            //    if (txtAccountHolderBOId.Text != txtSearchCustomer.Text)
            //    {
            //        SearchCustomerInformation();
            //        return;
            //    }
            //}
            //if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA)
            //{
            //    if (txtTransCustomer.Text.Trim() == "")
            //    {
            //        SearchTransCustomerInformation(Indication_IPOPaymentTransaction.TRTA); 
            //        return;
            //    }
            //}
            //else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO)
            //{
            //    if (txtTransCustomer.Text.Trim() == "")
            //    {
            //        SearchTransCustomerInformation(Indication_IPOPaymentTransaction.TRIPO);
            //        return;
            //    }
            //}
            //else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPOApp)
            //{
            //    if (txtTransCustomer.Text.Trim() == "")
            //    {
            //        SearchTransCustomerInformation(Indication_IPOPaymentTransaction.TRIPOApp);
            //        return;
            //    }
            //}
            ////if (txtStatus.Text.Equals("Closed"))
            ////{
            ////    if (DialogResult.No == MessageBox.Show("This is a Closed Account. Sure you want to continue?", "Closed Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            ////    {
            ////        // ClearAll();
            ////        ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);
            ////        txtSearchCustomer.Focus();
            ////        return;
            ////    }
            ////}

        }

        private void LoadPanel()
        {
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO)
            {
                if (MenuName == Indication_Forms_Title.IPOPaymentDeposit)
                {
                    panelPaymentInfo.Visible = false;
                    panelEFT.Visible = false;
                    pnlEFT_Deposit.Visible = false;
                    panelChequeDeposit.Visible = false;
                    panelPaymentTransfer.Visible = true;
                    ddlDepositWithdraw.Enabled = !(ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO);
                    txtAmount.Enabled = (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO);
                    groupBox1.Enabled = true;
                    txt_Transfer_VoucherNo.Enabled = true;
                    groupBox1.Text = "TR To";
                    gbPaymentInfo.Text = "TR From";
                }
                else if (MenuName == Indication_Forms_Title.IPOPaymentWithdraw)
                {
                    panelPaymentInfo.Visible = false;
                    panelEFT.Visible = false;
                    pnlEFT_Deposit.Visible = false;
                    panelChequeDeposit.Visible = false;
                    panelPaymentTransfer.Visible = true;
                    ddlDepositWithdraw.Enabled = !(ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO);
                    txtAmount.Enabled = (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO);
                    groupBox1.Enabled = true;
                    txt_Transfer_VoucherNo.Enabled = true;
                    groupBox1.Text = "TR From";
                    gbPaymentInfo.Text = "TR To";
                }
                return;
            }         
            else if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                panelChequeDeposit.Visible = false;
                pnlEFT_Deposit.Visible = true;
                //dgPanerlEft.Visible = true;
                txtAmount.Enabled = (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT);
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "EFT Info";
                groupBox1.Enabled = true;
                groupBox1.Text = "Account Information";
                //Search_BankBranchComboDataForDeposit();

                return;
            }
            else if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                panelChequeDeposit.Visible = false;
                pnlEFT_Deposit.Visible = true;
                //dgPanerlEft.Visible = true;
                txtAmount.Enabled = (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return);
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "EFT Return Info";
                groupBox1.Enabled = true;
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                btnEftReturn.Enabled = true;
                btnEftReturn.Visible = true;
           
                return;
            }

            else if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                pnlEFT_Deposit.Visible = false;
                panelChequeDeposit.Visible = false;
                //panelEFT.Visible = true;
				dgPanerlEft.Visible = true;	
                txtAmount.Enabled = (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT);
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "EFT Info";
                groupBox1.Enabled = true;
                groupBox1.Text = "Account Information";
                SearchRoutingInformation();
                return;
            }

            //else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
            //{
            //    ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

            //    panelPaymentInfo.Visible = false;
            //    panelPaymentTransfer.Visible = false;
            //    panelEFT.Visible = false;
            //    panelChequeDeposit.Visible = false;
            //    pnlEFT_Deposit.Visible = true;
            //    txtAmount.Enabled = (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return);
            //    //ddlDepositWithdraw.Enabled = false;
            //    //ddlPaymentMedia.Enabled = false;
            //    gbPaymentInfo.Text = "EFT Info";
            //    groupBox1.Enabled = true;
            //    groupBox1.Text = "Account Information";
            //    Search_BankBranchComboDataForDeposit();
            //    return;
            //}

            else if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return) && (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);
                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                pnlEFT_Deposit.Visible = false;
                panelChequeDeposit.Visible = false;
                panelEFT.Visible = true;
                dgPanerlEft.Visible = false;
                txtAmount.Enabled = (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return);
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "EFT Info";
                groupBox1.Enabled = true;
                groupBox1.Text = "Account Information";
                return;
            }

            else if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                panelChequeDeposit.Visible = true;
                txtAmount.Enabled = (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque);
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Enabled = true;
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }

            else if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
            {
                ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

                panelPaymentInfo.Visible = false;
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                panelChequeDeposit.Visible = true;
                txtAmount.Enabled = (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque_Return);
                //ddlDepositWithdraw.Enabled = false;
                //ddlPaymentMedia.Enabled = false;
                gbPaymentInfo.Text = "Account Information";
                groupBox1.Enabled = true;
                groupBox1.Text = "Account Information";
                Search_BankBranchComboDataForDeposit();
                return;
            }         
          
            else
            {
                gbPaymentInfo.Text = ddlPaymentMedia.Text + " Info";
                groupBox1.Enabled = true;
                groupBox1.Text = "Account Information";
                ddlDepositWithdraw.Enabled = !(ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA);
                panelPaymentTransfer.Visible = false;
                panelEFT.Visible = false;
                pnlEFT_Deposit.Visible = false;
                panelChequeDeposit.Visible = false;
                panelPaymentInfo.Visible = true;
                ddlDepositWithdraw.Enabled = false;
                txtAmount.Enabled = true;
                txt_Paypal_BranchName.Enabled = (!(ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA) && ddlPaymentMedia.Text != Indication_IPOPaymentTransaction.Cash && ddlPaymentMedia.Text != Indication_IPOPaymentTransaction.Ecash);
                txt_Paypal_BankName.Enabled = (!(ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA) && ddlPaymentMedia.Text != Indication_IPOPaymentTransaction.Cash && ddlPaymentMedia.Text != Indication_IPOPaymentTransaction.Ecash);
                txt_Paypal_OrderNo.Enabled = (!(ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA) && ddlPaymentMedia.Text != Indication_IPOPaymentTransaction.Cash && ddlPaymentMedia.Text != Indication_IPOPaymentTransaction.Ecash);
                dtp_Paypal_OrderDate.Enabled = (!(ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA) && ddlPaymentMedia.Text != Indication_IPOPaymentTransaction.Cash && ddlPaymentMedia.Text != Indication_IPOPaymentTransaction.Ecash);

            }
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
            {
                chkMatureToday.Visible = true;
            }
        }
        private void Dg_RefundBankInfo_Format()
        {
                dg_RefundBankInfo.Columns["BOID"].Visible = false;
                dg_RefundBankInfo.Columns["Status"].Visible = false;
                dg_RefundBankInfo.Columns["IPO_Mone_Bal"].Visible = false;
                dg_RefundBankInfo.Columns["Distributed_Amount"].Visible = false;

                dg_RefundBankInfo.Columns["Cust_Code"].Width = 80;
                dg_RefundBankInfo.Columns["BankAccNo"].Width = 100;
                dg_RefundBankInfo.Columns["RoutingNo"].Width = 70;
                dg_RefundBankInfo.Columns["BankID"].Width = 50;
                dg_RefundBankInfo.Columns["BankName"].Width = 150;
                dg_RefundBankInfo.Columns["BranchID"].Width = 70;
                dg_RefundBankInfo.Columns["BranchName"].Width = 200;
        }

        private void CheckBankInformation()
        {
            //string rountingID = "";
            if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_EFT_Desc || cmb_RefundMethod.Text == Indication_IPORefundType.Refund_MMT_Desc)
            {
                int BalnkRoutingCount = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["RoutingNo"]).Trim() == string.Empty).Count();
                int BankNameCount = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BankName"]).Trim() == string.Empty).Count();
                int BankIdCount = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BankID"]).Trim() == string.Empty).Count();
                int BranchNameCount = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BranchName"]).Trim() == string.Empty).Count();
                int BranchIdcount = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BranchID"]).Trim() == string.Empty).Count();

                if (BalnkRoutingCount != 0 || BankNameCount != 0 || BankIdCount != 0 || BranchNameCount != 0 || BranchIdcount != 0)
                {
                    throw new Exception("Unable to Applied Due to bank Information is not Valid");
                }
            }
            
        }

        private void LoadRefundPanel()
        {

            if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_EFT_Desc)
            {
                Set_RefundPanelMode(RefundPanelMode.EFT);
               
                dg_RefundBankInfo.DataSource = dt_CustList_IPOPayment;
                Dg_RefundBankInfo_Format();
            }
            else if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_MMT_Desc)
            {
                Set_RefundPanelMode(RefundPanelMode.MMT);
                
                dg_RefundBankInfo.DataSource = dt_CustList_IPOPayment;
                Dg_RefundBankInfo_Format();
            }
            else if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRTA_Desc)
            {
                Set_RefundPanelMode(RefundPanelMode.TRTA);
                dg_RefundBankInfo.DataSource = null;
            }
            else if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRIPO_Desc)
            {
                Set_RefundPanelMode(RefundPanelMode.TRIPO);
                dg_RefundBankInfo.DataSource = null;
            }
            else if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRPR_Desc)
            {
                Set_RefundPanelMode(RefundPanelMode.TRPR);
                dg_RefundBankInfo.DataSource = null;
                dg_AvailableSession.DataSource = null;
            }
            //else if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRPRIPO_Desc)
            //{
                //Set_RefundPanelMode(RefundPanelMode.TRPRIPO);
                //dg_RefundBankInfo.DataSource = null;
            else if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRPRIPO_Desc)
                {
                IPOProcessBAL bal = new IPOProcessBAL();
                DataTable dt = new DataTable();
                string[] Cust_Code = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                dt = bal.GetParentCodeFromChildCode(Cust_Code);
                string Parent_Code = "";
                if (dt.Rows.Count > 1)
                {
                    ClearRefundPanel();
                    dg_AvailableSession.DataSource = null;
                    string msg = "Invalid Parent Child Group Found";
                    ExceptionCollectionList.Add(msg);
                    if (IsCollectiveExceptionOn)
                        return;
                    Form_CustomException(msg, IsCollectiveExceptionOn);
                }
                else if (dt.Rows.Count == 0)
                {
                    ClearRefundPanel();
                    dg_AvailableSession.DataSource = null;

                    string msg = "Invalid Parent Child Group Found";
                    ExceptionCollectionList.Add(msg);
                    if (IsCollectiveExceptionOn)
                        return;
                    Form_CustomException(msg, IsCollectiveExceptionOn);
                }
                else
                {
                    Parent_Code = dt.Rows[0][0].ToString();
                }
                if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cash)
                {
                    txt_Cust_Code_ForTransferParent.Text = Parent_Code;

                }
                if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Ecash)
                {
                    txt_Cust_Code_ForTransferParent.Text = Parent_Code;

                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
                {
                    txt_Cust_Code_ForTransferParent.Text = Parent_Code;
                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque_Return)
                {
                    txt_Cust_Code_ForTransferParent.Text = Parent_Code;
                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT)
                {
                    txt_Cust_Code_ForTransferParent.Text = Parent_Code;
                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO)
                {
                    txt_Cust_Code_ForTransferParent.Text = Parent_Code;
                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA)
                {
                    txt_Cust_Code_ForTransferParent.Text = Parent_Code;
                }

            }
            else
            {
                Set_RefundPanelMode(RefundPanelMode.Default);
                dg_RefundBankInfo.DataSource = null;
            }
           
        }      

        private void LoadInfoByCustCode()
        {
            ClearByCustCode();
            if (dt_CustList_IPOPayment.Rows.Count == 1)
            {
                if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw)
                {
                    //ClearEFTInformation();
                    SearchRoutingInformation();
                }
                //else if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)||
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit || ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw))
                {
                    Search_BankBranchComboDataForDeposit();
                }
            }
            GetPaymentEntryInfo();
            if (ddlPaymentMedia.Text.Contains(Indication_PaymentTransaction.Return_Indicator))
            {
                btnDWReturnInfo.Enabled = true;
            }
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA)
            {
                btnDWReturnInfo.Enabled = true;
            }
            SetNextFocus(ddlPaymentMedia.Text, txtSearchCustomer.Name);

        }
        
        private void LoadDataFromGrid()
        {
            foreach (DataGridViewRow row in this.dgvPaymentInfo.SelectedRows)
            {
                if (dgvPaymentInfo[0, row.Index].Value != DBNull.Value)
                    _paymentID = Convert.ToInt32(dgvPaymentInfo[0, row.Index].Value);
                _status = dgvPaymentInfo[8, row.Index].Value.ToString();
            }
        }

        private void LoadAvailAbleIPOSession()
        {
            double doubleTryParse;
            double distAmount=0.00;
            double minBalanceAmount = 0.00;
            double chargedAmount=0.00;
            double requiredCharge = 0.00;
            DataTable dt = new DataTable();
            IPOProcessBAL ipoBal=new IPOProcessBAL();
            
            if (double.TryParse(txt_Distributed_Amount.Text, out doubleTryParse))
                distAmount = doubleTryParse;
            if (double.TryParse(txt_MinBalance.Text, out doubleTryParse))
                minBalanceAmount = doubleTryParse;
            if(double.TryParse(txt_AppCharge_Amount.Text,out doubleTryParse))
                chargedAmount = doubleTryParse;
            if (double.TryParse(txt_RequiredTranCharge.Text, out doubleTryParse))
                requiredCharge = doubleTryParse;

            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
                dt = ipoBal.GetAvailableSession(minBalanceAmount + distAmount + chargedAmount);
            else
                dt = ipoBal.GetAvailableSession(minBalanceAmount + distAmount + chargedAmount);

            dg_AvailableSession.DataSource = dt;
            dg_AvailableSession.Columns["ID"].Visible = false;
        }

#endregion LoadingMethod


#region Miscellaneous
         
        private void AddChildCodeTo_dg_Customers_Grid(string Name)
        {
            IPOProcessBAL bal = new IPOProcessBAL();            

            //bal.GetParentChildInfo(txt_Transfer_CustCode.Text);
            //if (dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(T => Convert.ToString(T["Cust_Code"]) == txtSearchCustomer.Text).Count() == 0)
            //{
            //ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);

            if (dg_Customers.Rows.Count > 0)
            {
                while (dg_Customers.Rows.Count > 0)
                {
                    dg_Customers.Rows.RemoveAt(0);
                }
                txt_CustCodeHidden.Text = txtSearchCustomer.Text;
                DataTable dtc = bal.GetParentChildInfo(txt_Transfer_CustCode.Text, Name);
                // if (dt.Rows.Count > 0)
                foreach (DataRow dt in dtc.Rows)
                {
                    string code = dt["Cust_Code"].ToString();
                    if (dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(T => Convert.ToString(T["Cust_Code"]) == code).Count() == 0)
                    {
                        dt_CustList_IPOPayment.Rows.Add(false,dt["Cust_Code"], dt["BOID"].ToString(), dt["Status"].ToString(), Convert.ToDouble(dt["IPO_Mone_Bal"].ToString()), 0.00, dt["BankAccNo"].ToString(), dt["RoutingNo"].ToString(), Convert.ToInt32(dt["BankID"]), dt["BankName"].ToString(), Convert.ToInt32(dt["BranchID"]), dt["BranchName"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Already in grid ");
                    }
                }
                Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                Set_MinimumBalance_Amount();
                dg_Customers.DataSource = dt_CustList_IPOPayment;
                LoadInfoByCustCode();
                chk_AppliedTogather.Checked = false;
                Set_AppliedTogatherMode(false);
                //txtSearchCustomer.Text = "";
                //txtSearchCustomer.Focus();
                txt_Transfer_CustCode.Focus();
                //dg_Customers.Rows.Clear();
            }
            else
            {
                // dg_Customers.Rows.Clear();
                txt_CustCodeHidden.Text = txtSearchCustomer.Text;
                DataTable dtc = bal.GetParentChildInfo(txt_Transfer_CustCode.Text, Name);
                // if (dt.Rows.Count > 0)
                foreach (DataRow dt in dtc.Rows)
                {
                    string code = dt["Cust_Code"].ToString();
                    if (dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(T => Convert.ToString(T["Cust_Code"]) == code).Count() == 0)
                    {
                        dt_CustList_IPOPayment.Rows.Add(false,dt["Cust_Code"], dt["BOID"].ToString(), dt["Status"].ToString(), Convert.ToDouble(dt["IPO_Mone_Bal"].ToString()), 0.00, dt["BankAccNo"].ToString(), dt["RoutingNo"].ToString(), Convert.ToInt32(dt["BankID"]), dt["BankName"].ToString(), Convert.ToInt32(dt["BranchID"]), dt["BranchName"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Already in grid ");
                    }
                }
                Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                Set_MinimumBalance_Amount();
                dg_Customers.DataSource = dt_CustList_IPOPayment;
                LoadInfoByCustCode();
                chk_AppliedTogather.Checked = false;
                Set_AppliedTogatherMode(false);
                //txtSearchCustomer.Text = "";
                //txtSearchCustomer.Focus();
                txt_Transfer_CustCode.Focus();
                //}
            }

        }
        
        //Added BY MD.Rasheul hasan 19-Jan-2015
        /// <summary>
        /// TRTA And TRIPO Transaction Checking
        /// </summary>
        
        private void SearchTransCustomerInformation()
        {
            _custCode = txt_Transfer_CustCode.Text;
            if (string.IsNullOrEmpty(_custCode))
                return;
            IPOProcessBAL ipoBal = new IPOProcessBAL();
            PaymentInfoBAL P_Bal = new PaymentInfoBAL();
            DataTable dtBalance = new DataTable();
            DataTable TradeBalance = new DataTable();
            dtBalance = ipoBal.GetIPOAccountInformation(_custCode);
            TradeBalance=P_Bal.GetCurrentBalanceInfo(_custCode);
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA)
            {
                //if(ddlDepositWithdraw.Text==Indication_PaymentMode.Deposit)
                //{
                if (txt_Transfer_CustCode.Text.Trim() != "")
                {
                    double doubleTryParse = 0;
                    DataTable custDateTable = new DataTable();
                    CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
                    //IPOProcessBAL ipoBal = new IPOProcessBAL();
                     
                    custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                    double CurrentBalance = 0.00;
                    double GoingBalance = 0.00;
                    decimal IPO_Current_Balance = 0.0M;
                    decimal AccruedBalance = 0.0M;
                    
                    if (double.TryParse(txtAmount.Text, out doubleTryParse))
                        GoingBalance = doubleTryParse;
                    if (custDateTable.Rows.Count > 0)
                    {
                        //Added BY MD.rashedul Hasan on 26-01-2015
                        if (TradeBalance.Rows.Count > 0)
                        {
                              Tr_CurrentBalance = 0.0M;
                             Tr_Pending_Deposit = 0.0M;
                             Tr_Pending_Withdraw = 0.0M;
                              Tr_AvailableWithdraw_Balance=0.0M;
                            string[] Tr_CurrentBalance_Array = null;
                            string[] Tr_Pending_Deposit_Array = null;
                            string[] Tr_Pending_Withdraw_Array = null;
                            Tr_CurrentBalance_Array = TradeBalance.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["Current_Balance"])).ToArray();
                            Tr_Pending_Deposit_Array = TradeBalance.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["Pending_Deposit"])).ToArray();
                            Tr_Pending_Withdraw_Array = TradeBalance.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["Pending_Withdraw"])).ToArray();
                            
                            for (int i = 0; i < Tr_CurrentBalance_Array.Length; i++)
                            {
                                decimal hold = 0.0M;
                                if (Tr_CurrentBalance_Array[i] != "")
                                {
                                    hold =Convert.ToDecimal(Tr_CurrentBalance_Array[i]) + hold;
                                    Tr_CurrentBalance = Tr_CurrentBalance + hold;
                                    break;
                                }
                            }
                            for (int i = 0; i < Tr_Pending_Deposit_Array.Length; i++)
                            {
                                decimal hold = 0.0M;
                                if (Tr_Pending_Deposit_Array[i] != "")
                                {
                                    hold = Convert.ToDecimal(Tr_Pending_Deposit_Array[i]) + hold;
                                    Tr_Pending_Deposit = Tr_Pending_Deposit + hold;
                                }
                            }
                            for (int i = 0; i < Tr_Pending_Withdraw_Array.Length; i++)
                            {
                                decimal hold = 0.0M;
                                if (Tr_Pending_Withdraw_Array[i] != "")
                                {
                                     hold= Convert.ToDecimal(Tr_Pending_Withdraw_Array[i]) + hold;
                                     Tr_Pending_Withdraw = Tr_Pending_Withdraw + hold;
                                }
                            }
                            txt_Transfer_CustName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                            txt_Transfer_Balance.Text = customerInfoBAL.GetCurrentBalane(_custCode).ToString("N");
                            CurrentBalance = Convert.ToDouble(txt_Transfer_Balance.Text);
                            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                            CommonBAL commbal = new CommonBAL(); 
                            txtAccruedBalance.Text = paymentInfoBal.GetCurrentBalaneforAccrued(_custCode).ToString("N");
                            AccruedBalance = Convert.ToDecimal(txtAccruedBalance.Text);
                            txtAvailableWithdrawBalance.Text = commbal.GetCurrentAvailAbleBalanceForWithdraw(_custCode).ToString("N");
                            Tr_AvailableWithdraw_Balance =((Convert.ToDecimal(CurrentBalance-Validation.Payment_MinimumBalanceHave_InWithdraw_ForActive) - Tr_Pending_Withdraw)-AccruedBalance);
                            if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
                            {
                                if (Tr_AvailableWithdraw_Balance < Convert.ToDecimal(GoingBalance))
                                {
                                    txt_Transfer_Balance.Focus();
                                    txt_Transfer_Balance.BackColor = System.Drawing.Color.Red;
                                    string msg = "Insufficient Balance For : " + _custCode + "\nAvailable Withdraw Balance is :" + Tr_AvailableWithdraw_Balance + "\nYour Current Balance is :" + Tr_CurrentBalance + "\nPending Withdraw Transaction :" + Tr_Pending_Withdraw;
                                    ExceptionCollectionList.Add(msg);
                                    if (IsCollectiveExceptionOn)
                                        return;
                                    Form_CustomException(msg, IsCollectiveExceptionOn);
                                   
                                }
                                else
                                {
                                    txt_Transfer_Balance.BackColor = System.Drawing.Color.GreenYellow;
                                }
                            }
                            else
                            {
                                if (dt_CustList_IPOPayment.Rows.Count > 0)
                                {

                                    foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                                    {
                                        string cust_code = amount["Cust_Code"].ToString();
                                        decimal Distributed_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                                        EntryBlanceChecking(cust_code, Distributed_Amount);

                                    }
                                }
                            }
                            //}
                            ////////////////////////////////////26-01-2015/////////////////////
                            
                        }
                    }
                    else
                    {
                        string msg = "No Customer Found For Payment Transfer.";
                        ExceptionCollectionList.Add(msg);
                        if (IsCollectiveExceptionOn)
                            return;
                        Form_CustomException(msg, IsCollectiveExceptionOn);
                        //MessageBox.Show(msg);
                       
                        return;
                    }
                     
                }
            }
            else
            {
               // _custCode = txt_Transfer_CustCode.Text;
                
                
                decimal doubleTryparse = 0.0M;
                
                Deposit_Pending_Balance = 0.0M;
                Withdraw_Pending_Balance = 0.0M;
                Total_Balance = 0.0M;
                IPO_Cur_Balance = 0.0M;
                Total_Approved_Pending_Balance = 0.0M;
                GoingBalance = 0.0M;
                Deposit_Transaction_Name = "";
                Withdraw_Transaction_Name = "";
                string Customer = "";
                if (decimal.TryParse(txtAmount.Text, out doubleTryparse))
                {
                    GoingBalance = doubleTryparse;
                }
                if (dtBalance.Rows.Count > 0)
                {
                    string[] Total_withdraw_transaction_Name = null;
                    string[] Total_Deposit_transaction_Name = null;
                    string[] Total_Withdraw_Pending = null;
                    string[] Total_Deposit_Pending = null;
                    string[] Previus_Balance = null;
                    string[] Ap_Pn_Balance = null;
                    string[] Name = dtBalance.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Cust_Name"])).ToArray();
                    Previus_Balance = dtBalance.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Presenct_Balance"])).ToArray();
                    Ap_Pn_Balance = dtBalance.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["ApprovePendingBalance"])).ToArray();
                    for (int i = 0; i < Name.Length; i++)
                    {
                        if (Name[i] != "")
                        {
                            Customer = Name[i];
                            break;
                        }
                    }
                    for (int i = 0; i < Previus_Balance.Length; i++)
                    {
                        decimal Pr_Bl = 0.0M;
                        string S_Bl = Previus_Balance[i];
                        if (S_Bl != "")
                        {
                            Pr_Bl = Pr_Bl + Convert.ToDecimal(S_Bl);
                        }
                        Total_Balance = Pr_Bl;
                        IPO_Cur_Balance = Total_Balance;
                    }
                    for (int i = 0; i < Ap_Pn_Balance.Length; i++)
                    {
                        decimal Ap_Pn_Bl = 0.0M;
                        string P_Bl = Ap_Pn_Balance[i];
                        if (P_Bl != "")
                        {
                            Ap_Pn_Bl = Ap_Pn_Bl + Convert.ToDecimal(P_Bl);
                        }
                        Total_Approved_Pending_Balance = Ap_Pn_Bl;
                    }

                    //if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
                    //{

                        Total_withdraw_transaction_Name = dtBalance.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Withdraw_Pending_Transaction_Name"])).ToArray();
                        Total_Deposit_transaction_Name = dtBalance.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["Deposit_Pending_Transaction_Name"])).ToArray();
                        //Deposit_Transaction_Name = dt.Rows[0]["Deposit_Pending_Transaction_Name"].ToString();
                        //Withdraw_Transaction_Name = dt.Rows[0]["Withdraw_Pending_Transaction_Name"].ToString();
                        Withdraw_Transaction_Name = string.Join(",", Total_withdraw_transaction_Name);
                        Deposit_Transaction_Name = string.Join(",", Total_Deposit_transaction_Name);
                        //Total_Approved_Pending_Balance = Convert.ToDecimal(dtBalance.Rows[0]["ApprovePendingBalance"]);
                        Total_Withdraw_Pending = dtBalance.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Withdraw_Pending"])).ToArray();
                        Total_Deposit_Pending = dtBalance.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Deposit_Pending"])).ToArray();
                        for (int i = 0; i < Total_Withdraw_Pending.Length; i++)
                        {
                            decimal W_con = 0.0M;
                            string W_Pending = Total_Withdraw_Pending[i];
                            if (W_Pending == "")
                            {
                                W_Pending = "0";
                                W_con = W_con + Convert.ToDecimal(W_Pending);
                            }
                            else
                            {
                                W_con = W_con + Convert.ToDecimal(W_Pending);
                            }
                            Withdraw_Pending_Balance = Withdraw_Pending_Balance + W_con;
                        }
                        for (int i = 0; i < Total_Deposit_Pending.Length; i++)
                        {
                            decimal D_con = 0.0M;
                            //Convert.ToDecimal(D_Pending);

                            string D_Pending = Total_Deposit_Pending[i];
                            if (D_Pending == "")
                            {
                                D_Pending = "0";
                                D_con = D_con + Convert.ToDecimal(D_Pending);
                            }
                            else
                            {
                                D_con = D_con + Convert.ToDecimal(D_Pending);
                            }
                            Deposit_Pending_Balance = Deposit_Pending_Balance + D_con;
                        }

                        //GoingBalance = Convert.ToDecimal(txtAmount.Text); 
                        if (dt_CustList_IPOPayment.Rows.Count > 0)
                        {

                            foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                            {
                                string cust_code = amount["Cust_Code"].ToString();
                                decimal Dis_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                                if (cust_code == txt_Transfer_CustCode.Text)
                                {
                                    string msg = "Same Account Is not Possible";
                                    ExceptionCollectionList.Add(msg);
                                    if (IsCollectiveExceptionOn)
                                        return;
                                    Form_CustomException(msg, IsCollectiveExceptionOn);
                                }
                                else
                                {
                                    if (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw)
                                    {
                                        EntryBlanceChecking(cust_code, Dis_Amount);
                                        txt_Transfer_CustName.Text = Customer;
                                        //IPO_Cur_Balance 
                                        txt_Transfer_Balance.Text = IPO_Cur_Balance.ToString("N");
                                        txt_Transfer_Balance.BackColor = System.Drawing.Color.GreenYellow;
                                    }
                                    else
                                    {
                                        if ((Total_Balance - Withdraw_Pending_Balance) < GoingBalance)
                                        {
                                            txt_Transfer_CustName.Text = Customer;
                                            IPO_Cur_Balance = Total_Balance;
                                            txt_Transfer_Balance.Text = Total_Balance.ToString("G29");
                                            txt_Transfer_Balance.BackColor = System.Drawing.Color.Red;
                                            string msg = "Your previous Balance =" + Total_Balance + "\n available withdrawal Balance = " + Total_Approved_Pending_Balance + "\n Total Pendding deposit Amount = " + Deposit_Pending_Balance + " Deposit Transaction Pending By: " + Deposit_Transaction_Name + "\n Total Withdraw Balance = " + Withdraw_Pending_Balance + " Withdraw Transaction Pending By: " + Withdraw_Transaction_Name + "\n For This Cust Code= " + _custCode;
                                            ExceptionCollectionList.Add(msg);
                                            Form_CustomException(msg, IsCollectiveExceptionOn);
                                        }
                                        else
                                        {
                                            txt_Transfer_CustName.Text = Customer;
                                            IPO_Cur_Balance = Total_Balance;
                                            txt_Transfer_Balance.Text = IPO_Cur_Balance.ToString("N");
                                            txt_Transfer_Balance.BackColor = System.Drawing.Color.GreenYellow;
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            string msg = "Provide valid Customer Code For deposit";
                            ExceptionCollectionList.Add(msg);
                            if (IsCollectiveExceptionOn)
                                return;
                            Form_CustomException(msg, IsCollectiveExceptionOn);
                        }
                        
                    //}
                    //else
                    //{
                    //    if (Total_Balance < GoingBalance)
                    //    {
                    //        txt_Transfer_CustName.Text = Customer;
                    //        IPO_Cur_Balance = Total_Balance;
                    //        txt_Transfer_Balance.Text = IPO_Cur_Balance.ToString("G29");
                    //        txt_Transfer_Balance.BackColor = System.Drawing.Color.Red;
                    //    }
                    //    else
                    //    {
                    //        txt_Transfer_CustName.Text = Customer;
                    //        IPO_Cur_Balance = Total_Balance;
                    //        txt_Transfer_Balance.Text = IPO_Cur_Balance.ToString("G29");
                    //        txt_Transfer_Balance.BackColor = System.Drawing.Color.GreenYellow;
                    //    }
                    //}
                }
            }
        }
		
        private void SearchCustomerInformation()
        {

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

                    if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT)
                    {
                        try
                        {
                            ddl_DepositEft_Bank_Name.Text = _bankName;
                            ddl_DepositEft_Branch_Name.Text = _branchName;
                            ddl_DepositEft_RoutingNo.Text = _routingNo;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }
                    else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
                    {
                        ddl_DepositCheque_BankName.SelectedItem = _bankName;
                        ddl_DepositCheque_BranchName.SelectedItem = _branchName;
                        ddl_DepositCheque_RoutingNo.Text = _routingNo;
                    }
                }
                else
                {
                    if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return) && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
                    {
                        ddl_DepositEft_Bank_Name.SelectedIndex = -1;
                        ddl_DepositEft_Branch_Name.SelectedIndex = -1;
                        ddl_DepositEft_RoutingNo.SelectedIndex = -1;
                    }
                    else if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque_Return) && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
                    {
                        ddl_DepositCheque_BankName.SelectedIndex = -1;
                        ddl_DepositCheque_BranchName.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SearchRoutingInformation()
        {
            try
            {
                //string BankAccNo_Temp;
                DataTable dt = new DataTable();
                PaymentInfoBAL paymentBAL = new PaymentInfoBAL();
                EFT_IssueBAL eftBAL = new EFT_IssueBAL();
                if (dt_CustList_IPOPayment.Rows.Count > 0)
                {
                    dgvEFTbankInfo.DataSource = dt_CustList_IPOPayment;

                    dgvEFTbankInfo.Columns["BOID"].Visible = false;
                    dgvEFTbankInfo.Columns["Status"].Visible = false;
                    dgvEFTbankInfo.Columns["IPO_Mone_Bal"].Visible = true;
                    dgvEFTbankInfo.Columns["BankID"].Visible = false;
                    dgvEFTbankInfo.Columns["BranchID"].Visible = false;
                    dgvEFTbankInfo.Columns["Distributed_Amount"].Visible = false;
                }
                //dt = paymentBAL.GetRoutingInfo(txtSearchCustomer.Text);
                //txt_EftWithdraw_BankName.Text = dt.Rows[0][0].ToString();
                //txt_EftWithdraw_BranchName.Text = dt.Rows[0][1].ToString();
                //txt_EftWithdraw_RoutingNo.Text = dt.Rows[0][2].ToString();
                //txtEFTBankID.Text = dt.Rows[0][4].ToString();
                //txtEFTBranchID.Text = dt.Rows[0][5].ToString();
                //BankAccNo_Temp = dt.Rows[0][3].ToString();
                //eftBAL.BankAccountNo_BusinessRule_FormattingCharacters(ref BankAccNo_Temp);
                //eftBAL.BankAccountNo_BusinessRule_MakingUp17Digit(ref BankAccNo_Temp);
                //txt_EftWithdraw_BankAccNo.Text = BankAccNo_Temp;
            }
            catch
            {
            }
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
            //txtRemarks.Text = "Web Request: " + bo.Remarks;
            //txtAmount.Text = bo.Amount.ToString().Trim();
        }

        private void Form_CustomException(string P_msg,bool P_IsCollectiveExceptionOn)
        {
            if (!P_IsCollectiveExceptionOn)
                throw new Exception(P_msg);
        }

        private void Form_CollectiveException()
        {
            string errorString = string.Empty;

            int i = 1;
            foreach (var text in ExceptionCollectionList)
            {
                errorString = errorString + @"
                " + i + ")" + text;
                i++;
            }
            ExceptionCollectionList.Clear();
            if (i != 1)
                throw new Exception(errorString);
        }

        private void SetVoucherNo()
        {
            PaymentInfoBAL obj = new PaymentInfoBAL();
            string serial = obj.GenerateSerial();
            if (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw)
            {
                txt_EftWithdraw_VoucherNo.Text = serial;
            }
            if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
            {
                txt_DepositEft_VoucherNo.Text = serial;
            }
        }

        public void ShowPaymentReviewReport()
        {
            //CompanyBAL objCompanyBal = new CompanyBAL();
            //PaymentReviewBAL paymentBAL = new PaymentReviewBAL();
            //DataTable dtPaymentReview = new DataTable();
            //crPaymentReview1 crPayment = new crPaymentReview1();
            //frmPaymenrReportViewer paymentViewer = new frmPaymenrReportViewer();
            //LoadCommonInfo CmmInfo = new LoadCommonInfo();
            //dtPaymentReview = paymentBAL.GneratePaymentReview(DateTime.Today, DateTime.Today);
            //crPayment.SetDataSource(dtPaymentReview);

            /////// Load Company Name
            //((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

            /////// Load Branch Name
            //((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = objCompanyBal.GetHeadofficeInfo();
            //////Load Date
            //((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Date: " + DateTime.Today.ToString("dd MMM, yyyy");
            //paymentViewer.crvPaymentReview.ReportSource = crPayment;
            //paymentViewer.Show();
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

            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cash && (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw || ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
            {
                txt_Paypal_OrderNo.Enabled = false;
                dtp_Paypal_OrderDate.Enabled = false;
                txt_Paypal_BankName.Enabled = false;
                txt_Paypal_BranchName.Enabled = false;
                txt_Paypal_VoucherNo.ReadOnly = false;
            }
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Ecash && (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw || ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
            {
                txt_Paypal_OrderNo.Enabled = false;
                dtp_Paypal_OrderDate.Enabled = false;
                txt_Paypal_BankName.Enabled = false;
                txt_Paypal_BranchName.Enabled = false;
                txt_Paypal_VoucherNo.ReadOnly = false;
            }
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw || ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
            {
                txtDepositChequeNo.ReadOnly = false;
                dtp_Paypal_OrderDate.Enabled = true;
                ddl_DepositCheque_BankName.Enabled = true;
                ddl_DepositCheque_BranchName.Enabled = true;
                ddl_DepositCheque_RoutingNo.Enabled = true;
                txt_DepositCheque_VoucherNo.ReadOnly = false;

            }

            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw)
            {
                if (txtSearchCustomer.Text != "")
                {
                    SearchRoutingInformation();
                }
                txt_EftWithdraw_BankName.ReadOnly = true;
                txt_EftWithdraw_BranchName.ReadOnly = true;
                txt_EftWithdraw_RoutingNo.ReadOnly = true;
                txt_EftWithdraw_BankAccNo.ReadOnly = true;
                txt_EftWithdraw_VoucherNo.ReadOnly = true;
                btneftAutoVoucher.Enabled = true;
            }

            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
            {
                //Search_BankBranchComboDataForDeposit();
                ddl_DepositEft_Bank_Name.Enabled = false;
                ddl_DepositEft_Branch_Name.Enabled = false;
                ddl_DepositEft_RoutingNo.Enabled = false;
                txt_DepositEft_BankAccountNo.ReadOnly = true;
                txt_DepositEft_VoucherNo.ReadOnly = false;
                //btnEftCheckDepositAutogen.Enabled = true;

            }
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
            {
                Search_BankBranchComboDataForDeposit();
                ddl_DepositEft_Bank_Name.Enabled = true;
                ddl_DepositEft_Branch_Name.Enabled = true;
                ddl_DepositEft_RoutingNo.Enabled = true;
                txt_DepositEft_BankAccountNo.ReadOnly = false;
                txt_DepositEft_VoucherNo.ReadOnly = false;
                //btnEftCheckDepositAutogen.Enabled = true;

            }
        }

        public void SetDW_ReturnMode()
        {
            //            txtSearchCustomer.ReadOnly = true;
            //           SearchCustomerInformation();
            //            btnGo.Enabled = false;
            
            txtAmount.ReadOnly = true;
            dtRecievedDate.Enabled = true;
            // ddlDepositWithdraw.Text = Deposit_Withdraw_ReturnBO.DW;
            btnDWReturnInfo.Enabled = true;

            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque_Return && (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw || ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
            {
                txtDepositChequeNo.ReadOnly = true;
                dtp_Paypal_OrderDate.Enabled = false;
                ddl_DepositCheque_BankName.Enabled = false;
                ddl_DepositCheque_BranchName.Enabled = false;
                ddl_DepositCheque_RoutingNo.Enabled = false;
                txt_DepositCheque_VoucherNo.ReadOnly = false;
            }
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw)
            {
                //            SearchRoutingInformation();
                ClearEFTInformation();
                txt_EftWithdraw_BankName.ReadOnly = true;
                txt_EftWithdraw_BranchName.ReadOnly = true;
                txt_EftWithdraw_RoutingNo.ReadOnly = true;
                txt_EftWithdraw_BankAccNo.ReadOnly = true;
                txt_EftWithdraw_VoucherNo.ReadOnly = false;
                btneftAutoVoucher.Enabled = false;

            }

            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
            {

                // ClearEFTInformation();
                ClearEFTDepositInformation();
                ddl_DepositEft_Bank_Name.Enabled = false;
                ddl_DepositEft_Branch_Name.Enabled = false;
                ddl_DepositEft_RoutingNo.Enabled = false;
                txt_DepositEft_BankAccountNo.ReadOnly = true;
                txt_DepositEft_VoucherNo.ReadOnly = false;
                //  btnEftCheckDepositAutogen.Enabled = false;
                txtAmount.ReadOnly = false;
                btnDWReturnInfo.Enabled = false;
            }           
        }

        public void SetDW_ReturnInformation()
        {
           if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
            {
                
                IPOProcessBAL bal=new IPOProcessBAL();
                txtDepositChequeNo.Text = IPO_Deposit_Withdraw_Return_BO.P_Media;
              
                ddl_DepositCheque_RoutingNo.SelectedValue = IPO_Deposit_Withdraw_Return_BO.RoutingNo;
                txt_DepositCheque_VoucherNo.Text = IPO_Deposit_Withdraw_Return_BO.Voucher;
                
                ClearCustomerGrid();
                txtAmount.Text = Convert.ToString(IPO_Deposit_Withdraw_Return_BO.CustAmountList.Sum(t => t.Amount)); 
                foreach(BusinessAccessLayer.BO.IPO_Deposit_Withdraw_Return_BO.IPO_Customer_Amount_Obj obj in IPO_Deposit_Withdraw_Return_BO.CustAmountList.ToList())
                {
                    txtSearchCustomer.Text = obj.Cust_Code;
                    //txtAmount.Text = Convert.ToString(obj.Amount);
                    txt_CustCodeHidden.Text = txtSearchCustomer.Text;
                    Add_Dt_CustList_IPOPayment();
                }
                
                txtSearchCustomer.Text = string.Empty;
                
            }
        }

        public void Add_Dt_CustList_IPOPayment()
        {
            string custCode=string.Empty;
            IPOProcessBAL ipoBal=new IPOProcessBAL();
            custCode = txt_CustCodeHidden.Text;
            DataTable dt=ipoBal.GetCustoemrDetailsForPaymentEntry(custCode);
            string ChannelID = (txt_ChannelID.Text!=string.Empty?txt_ChannelID.Text:"0");
            string ChannelType=(txt_ChannelType.Text!=string.Empty?txt_ChannelType.Text:string.Empty);
            if (dt.Rows.Count > 0)
                dt_CustList_IPOPayment.Rows.Add(false,dt.Rows[0]["Cust_Code"], dt.Rows[0]["BOID"].ToString(), dt.Rows[0]["Status"].ToString(), Convert.ToDouble(dt.Rows[0]["IPO_Mone_Bal"].ToString()), 0.00, dt.Rows[0]["BankAccNo"].ToString(), dt.Rows[0]["RoutingNo"].ToString(), Convert.ToInt32(dt.Rows[0]["BankID"]), dt.Rows[0]["BankName"].ToString(), Convert.ToInt32(dt.Rows[0]["BranchID"]), dt.Rows[0]["BranchName"].ToString(), ChannelID, ChannelType);

            Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
            Set_MinimumBalance_Amount();
        }

        public void Remove_Dt_CustList_IPOPayment(int index)
        {
           dt_CustList_IPOPayment.Rows.RemoveAt(index);
           Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
           Set_MinimumBalance_Amount();
        }
        
        public void Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount()
        {
            double distributedAmount = 0.00;
            double doubleTryParse=0.00;          
            
            //Set_Distributed_Amount();
            
            distributedAmount = Get_Distributed_Amount();
            
            var dgTemp = dg_Customers.Rows.Cast<DataGridViewRow>().ToList();

            //dg_Customers.BeginEdit(true);
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
            {

                double transChargeAmount = 0.00;
                string transCust_Code = string.Empty;
                
                if (double.TryParse(txt_TranChrg_ChagedAmount.Text, out doubleTryParse))
                    transChargeAmount = doubleTryParse;
                transCust_Code = txt_TransChrg_ChargedCustCode.Text;
                int i = 0;
                foreach (DataRow dr in dt_CustList_IPOPayment.Rows)
                {
                    bool isChargableCode = Convert.ToBoolean(dr["IsChargable"].ToString());
                    string grid_Cust_Code=dr["Cust_Code"].ToString();
                    //dgTemp
                        //.Where(t => Convert.ToString(t.Cells["Cust_Code"].Value) == Convert.ToString(dr["Cust_Code"]))
                        //.Select(t => Convert.ToBoolean(t.Cells["IsChargable"].Value)).FirstOrDefault();

                    if (isChargableCode && chk_TransChrg_IsApplied.Checked && transCust_Code == grid_Cust_Code)
                    {
                        dr["Distributed_Amount"] = Convert.ToDouble(distributedAmount + transChargeAmount);
                    }
                    else
                    {
                        dr["Distributed_Amount"] = distributedAmount;
                    }                    
                    i++;
                }
            }
            else
            {
                int i = 0;
                foreach (DataRow dr in dt_CustList_IPOPayment.Rows)
                {
                    dr["Distributed_Amount"] = distributedAmount;
                    i++;
                }
            }
          
            foreach (DataGridViewRow dr in dg_Customers.Rows)
                foreach (DataGridViewCell dc in dr.Cells)
                    dg_Customers.UpdateCellValue(dc.ColumnIndex,dr.Index);
        }        

        public void Set_Distributed_Amount()
        {
            int count = 0;
            double doubleTryParse = 0.00;
            double transactionAmount = 0.00;
            double chargeAmount = 0.00;
            double ipoChargeAmount = 0.00;
            double result = 0.00;
            double finalTransaction = 0.00;
            
            count = dt_CustList_IPOPayment.Rows.Count;
            if (double.TryParse(txtAmount.Text, out doubleTryParse))
                transactionAmount = doubleTryParse;
            if (double.TryParse(txt_TranChrg_ChagedAmount.Text, out doubleTryParse))
                chargeAmount = doubleTryParse;
            if (double.TryParse(txt_AppCharge_Amount.Text, out doubleTryParse))
                ipoChargeAmount = doubleTryParse;

            finalTransaction = transactionAmount + ipoChargeAmount;

            if (ddlPaymentMedia.Text==Indication_IPOPaymentTransaction.Cheque && txt_TransChrg_PaymentMediaName.Text==string.Empty)
            {
                if (count > 0)
                    result = (finalTransaction - chargeAmount) / count;
            }
            else 
            {
                if (count > 0)
                    result = (finalTransaction) / count;
            }            

            txt_Distributed_Amount.Text = Convert.ToString(result);
        }

        public void Set_TransactionCharge_FromAmount()
        {
            double doubleTryParse;
            double amount_ToDeposit=0.00;
            string cust_Code_SelectedInDG=string.Empty;
            string payment_Media=string.Empty;
            PaymentInfoBAL bal = new PaymentInfoBAL();

            var temp = dg_Customers.Rows.Cast<DataGridViewRow>().Where(t => Convert.ToBoolean(t.Cells["IsChargable"].EditedFormattedValue) == true)
                                .Select(t => new { Cust_Code = Convert.ToString(t.Cells["Cust_Code"].Value), Amount = Convert.ToDouble(t.Cells["Distributed_Amount"].Value) + Convert.ToDouble(t.Cells["IPO_Mone_Bal"].Value) }).ToList();
            if (temp.Count > 0)
                cust_Code_SelectedInDG = temp.FirstOrDefault().Cust_Code;
            payment_Media=ddlPaymentMedia.Text;

            if (double.TryParse(txtAmount.Text, out doubleTryParse))
                amount_ToDeposit = doubleTryParse;

            if (cust_Code_SelectedInDG != string.Empty && payment_Media==Indication_IPOPaymentTransaction.Cheque && !(chk_TransChrg_IsApplied.Checked && txt_TransChrg_PaymentMediaName.Text!=string.Empty))
            {
                ClearTransactionBasedChargeTaken();
                txt_TransChrg_ChargedCustCode.Text = cust_Code_SelectedInDG;
                txt_TranChrg_ChagedAmount.Text = Convert.ToString(bal.GetTransactionBasedCharges_ChargeAmount(Indication_TransactioBasedCharge.BankClearing, amount_ToDeposit));
                chk_TransChrg_IsApplied.Checked = true;
            }
        }

        public double Get_Distributed_Amount()
        {
            double doubleTryParse;
            double result=0.00;
            
            if(double.TryParse(txt_Distributed_Amount.Text,out doubleTryParse))
                result=doubleTryParse;

            return result; 
        }
        
        public void Set_MinimumBalance_Amount()
        {
            double minBalance = 0.00;
            double minBalance_Temp=0.00;

            foreach (DataRow dr in dt_CustList_IPOPayment.Rows)
            {
                minBalance_Temp=Convert.ToDouble(dr["IPO_Mone_Bal"]);

                if (minBalance == 0.00)
                    minBalance = minBalance_Temp;
                else if (minBalance > minBalance_Temp)
                    minBalance = minBalance_Temp;
            }

            txt_MinBalance.Text =Convert.ToString( minBalance);
        }

        public void ReSet_ChequeChargeAmount_ToChargedAccount()
        {
            double chargeAmount = 0.00;
            double doubleTryParseTemp = 0.00;

            double amount = 0.00;
            if (double.TryParse(txtAmount.Text, out doubleTryParseTemp))
                amount = doubleTryParseTemp;

            if (double.TryParse(txt_TranChrg_ChagedAmount.Text, out doubleTryParseTemp))
            {
                chargeAmount = doubleTryParseTemp;
            }
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
            {
                DataRow drTemp = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                    .Where(t => Convert.ToString(t["Cust_Code"]) == txt_TransChrg_ChargedCustCode.Text).FirstOrDefault();

                if (drTemp != null)
                    drTemp["Distributed_Amount"] = Convert.ToDouble(drTemp["Distributed_Amount"]) - chargeAmount;
            }
            
            //Added By Md.Rashedul Hasan
            else
            {
                int Coustomer_Count = dt_CustList_IPOPayment.Rows.Count;
                double Single_Charge_Amount = chargeAmount / Coustomer_Count;
                double distAmount = 0.00;
                //distAmount=(amount-chargeAmount)/Coustomer_Count;
                foreach (DataRow row in dt_CustList_IPOPayment.Rows)
                {
                    row["Distributed_Amount"] = Convert.ToDouble(row["Distributed_Amount"]) - Single_Charge_Amount;
                    distAmount = Convert.ToDouble(row["Distributed_Amount"]);
                }
                txt_Distributed_Amount.Text = Convert.ToString(distAmount);
            }
            ////////////////////
        }

        public void Set_IPOApplicaiton_Charge_ToChargedAccount()
        {
            double chargeAmount = 0.00;
            double doubleTryParseTemp = 0.00;
            string CustCode = txt_TransChrg_ChargedCustCode.Text;
            double D_Amount = 0.00;
            double amount = 0.00;
            if (double.TryParse(txt_Distributed_Amount.Text, out doubleTryParseTemp))
                amount = doubleTryParseTemp;
            if (double.TryParse(txt_AppCharge_Amount.Text, out doubleTryParseTemp))
            {
                chargeAmount = doubleTryParseTemp;
            }
           
            int i = dt_CustList_IPOPayment.Rows.Count;
            D_Amount = (amount + chargeAmount);
            foreach (DataRow row in dt_CustList_IPOPayment.Rows)
            {
                //double am = Convert.ToDouble(row["Distributed_Amount"]);
                row["Distributed_Amount"] = D_Amount;
                //Amount =Amount+Convert.ToDouble(row["Distributed_Amount"]);
            }
            txt_Distributed_Amount.Text = Convert.ToString(D_Amount);
            
            //Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
            
            ////////////////////
        }
        
        public void ReSet_IPOApplicaiton_Charge_ToChargedAccount()
        {
            double chargeAmount = 0.00;
            double doubleTryParseTemp = 0.00;
            string CustCode = txt_TransChrg_ChargedCustCode.Text;
            double D_Amount = 0.00;
            double amount = 0.00;
            if (double.TryParse(txt_Distributed_Amount.Text, out doubleTryParseTemp))
                amount = doubleTryParseTemp;
            if (double.TryParse(txt_AppCharge_Amount.Text, out doubleTryParseTemp))
            {
                chargeAmount = doubleTryParseTemp;
            }

            int i = dt_CustList_IPOPayment.Rows.Count;
            D_Amount = (amount - chargeAmount);
            foreach (DataRow row in dt_CustList_IPOPayment.Rows)
            {
                //double am = Convert.ToDouble(row["Distributed_Amount"]);
                row["Distributed_Amount"] = D_Amount;
                //Amount =Amount+Convert.ToDouble(row["Distributed_Amount"]);
            }
            txt_Distributed_Amount.Text = Convert.ToString(D_Amount);

            //Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();

            ////////////////////
        }
       
        public void Set_RequiredTransCharge()
        {
            double doubleTryParse = 0.00;
            double amount_ToDeposit = 0.00;
            if (double.TryParse(txtAmount.Text, out doubleTryParse))
                amount_ToDeposit = doubleTryParse;
            PaymentInfoBAL bal = new PaymentInfoBAL();
            txt_RequiredTranCharge.Text = Convert.ToString(bal.GetTransactionBasedCharges_ChargeAmount(Indication_TransactioBasedCharge.BankClearing, amount_ToDeposit)); 
        }
      
        public double Get_MinimumBalance_Amount()
        {
            double doubleTryParse;
            double result=0.00;

            if (double.TryParse(txt_MinBalance.Text, out doubleTryParse))
                result = doubleTryParse;

            return result;
        }

        public void Set_AppliedTogatherMode(bool IsAppliedTogather)
        {
            if (!IsAppliedTogather)
            {
                gp_RefundMothod.Enabled = false;
                gp_AvailableSession.Enabled = false;
                txt_Cust_Code_ForTransferParent.Enabled = false;
                ClearRefundPanel();
                ClearAvailableSession();
            }
            else 
            {
                gp_AvailableSession.Enabled = true;
                gp_RefundMothod.Enabled = true;
                txt_Cust_Code_ForTransferParent.Enabled = true;
            }
        }

        public void Set_RefundPanelMode(RefundPanelMode rf)
        {
            switch(rf)
            {
                case RefundPanelMode.TRTA:
                    dg_RefundBankInfo.Enabled = false;
                    txt_Cust_Code_ForTransferParent.Enabled = false;
                    txt_Cust_Code_ForTransferParent.Text = "";
                    break;
                case RefundPanelMode.TRIPO:
                    dg_RefundBankInfo.Enabled = false;
                    txt_Cust_Code_ForTransferParent.Enabled = false;
                    txt_Cust_Code_ForTransferParent.Text = "";
                    break;
                case RefundPanelMode.EFT:
                    dg_RefundBankInfo.Enabled = true;
                    txt_Cust_Code_ForTransferParent.Enabled = false;
                    txt_Cust_Code_ForTransferParent.Text = "";
                    break;
                case RefundPanelMode.MMT:
                    dg_RefundBankInfo.Enabled = true;
                    txt_Cust_Code_ForTransferParent.Enabled = false;
                    txt_Cust_Code_ForTransferParent.Text = "";
                    break;
                case RefundPanelMode.TRPR:
                    dg_RefundBankInfo.Enabled = true;
                    txt_Cust_Code_ForTransferParent.Enabled = false;
                    if (panelPaymentTransfer.Visible == true)
                    {
                        txt_Cust_Code_ForTransferParent.Text = txt_Transfer_CustCode.Text;
                    }
                    else
                    {
                        throw new Exception("Transfer Parent Not Allowed");
                    }
                    break;
                case RefundPanelMode.TRPRIPO:
                    dg_RefundBankInfo.Enabled = true;
                    txt_Cust_Code_ForTransferParent.Enabled = false;
                    if (panelPaymentTransfer.Visible == true)
                    {
                        txt_Cust_Code_ForTransferParent.Text = txt_Transfer_CustCode.Text;
                    }
                    else
                    {
                        throw new Exception("Transfer Parent Not Allowed");
                    }
                    break;
                case RefundPanelMode.Default:
                    dg_RefundBankInfo.Enabled = false;
                    txt_Cust_Code_ForTransferParent.Enabled = false;
                    txt_Cust_Code_ForTransferParent.Text = "";
                    break;
            }   
        }

#endregion Miscellaneous

#region FormClearMethod

        private void FormClear()
        {
            txtSearchCustomer.Text = "";
            ClearByCustCode();
        }

        private void ClearByCustCode()
        {
            if (dt_CustList_IPOPayment.Rows.Count == 0)
            {
                txtAmount.Text = string.Empty;
                txt_MinBalance.Text = string.Empty;
                txt_Distributed_Amount.Text = string.Empty;
                Set_RequiredTransCharge();
            }
            txtRemarks.Text = string.Empty;
            txtRecievedBy.Text = string.Empty;
            ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);
            txtRecievedBy.Text = GlobalVariableBO._userName;
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
        }

        private void ClearSearchCustomer()
        {
            txtSearchCustomer.Text = string.Empty;
        }

        private void ClearByMode(string transType, string payMeth)
        {

            if (transType == Indication_PaymentMode.Deposit && payMeth == Indication_IPOPaymentTransaction.Cash)
            {
                //txtAmount.Text = string.Empty;
                txt_Paypal_OrderNo.Text = string.Empty;
                txt_Paypal_BankName.Text = string.Empty;
                txt_Paypal_BranchName.Text = string.Empty;
                txt_Paypal_VoucherNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == Indication_PaymentMode.Deposit && payMeth == Indication_IPOPaymentTransaction.Ecash)
            {
                //txtAmount.Text = string.Empty;
                txt_Paypal_OrderNo.Text = string.Empty;
                txt_Paypal_BankName.Text = string.Empty;
                txt_Paypal_BranchName.Text = string.Empty;
                txt_Paypal_VoucherNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }   
            else if (transType == Indication_PaymentMode.Deposit && payMeth == Indication_IPOPaymentTransaction.Cheque)
            {
                //txtAmount.Text = string.Empty;
                txtDepositChequeNo.Text = string.Empty;// txtPaymentMedia.Text = "";
                ddl_DepositCheque_BankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddl_DepositCheque_BranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddl_DepositCheque_RoutingNo.SelectedIndex = -1;
                txt_DepositCheque_VoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == Indication_PaymentMode.Deposit && payMeth == Indication_IPOPaymentTransaction.Cheque_Return)
            {
                //txtAmount.Text = string.Empty;
                txtDepositChequeNo.Text = string.Empty;//txtPaymentMedia.Text = "";
                ddl_DepositCheque_BankName.SelectedIndex = -1;// txtBankName.Text = "";
                ddl_DepositCheque_BranchName.SelectedIndex = -1;// txtBranchName.Text = "";
                ddl_DepositCheque_RoutingNo.SelectedIndex = -1;
                txt_DepositCheque_VoucherNo.Text = string.Empty;// txtSerialNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == Indication_PaymentMode.Deposit && payMeth == Indication_IPOPaymentTransaction.EFT)
            {
                //txtAmount.Text = string.Empty;
                ddl_DepositEft_Bank_Name.Enabled = false;// txteftBankBranchName.Text = "";
                ddl_DepositEft_Branch_Name.Enabled = false;// txteftBankName.Text = "";
                ddl_DepositEft_RoutingNo.Enabled = false;// txteftRoutingNo.Text = "";
                txt_DepositEft_VoucherNo.Enabled = true;// txteftVoucherNo.Text = "";
                txt_DepositEft_BankAccountNo.Enabled = false;// txtBankAccNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == Indication_PaymentMode.Deposit && payMeth == Indication_IPOPaymentTransaction.EFT_Return)
            {
                //txtAmount.Text = string.Empty;
                ddl_DepositEft_Bank_Name.SelectedIndex = -1;// txteftBankBranchName.Text = "";
                ddl_DepositEft_Branch_Name.SelectedIndex = -1;// txteftBankName.Text = "";
                ddl_DepositEft_RoutingNo.SelectedIndex = -1;// txteftRoutingNo.Text = "";
                txt_DepositEft_VoucherNo.Text = string.Empty;// txteftVoucherNo.Text = "";
                txt_DepositEft_BankAccountNo.Text = string.Empty;// txtBankAccNo.Text = "";
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
                txtAmount.ReadOnly = false;
            }
            else if (transType == Indication_PaymentMode.Withdraw && payMeth == Indication_IPOPaymentTransaction.Cash)
            {
                //txtAmount.Text = string.Empty;
                txt_Paypal_OrderNo.Text = string.Empty;
                txt_Paypal_BankName.Text = string.Empty;
                txt_Paypal_BranchName.Text = string.Empty;
                txt_Paypal_VoucherNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == Indication_PaymentMode.Withdraw && payMeth == Indication_IPOPaymentTransaction.Ecash)
            {
                //txtAmount.Text = string.Empty;
                txt_Paypal_OrderNo.Text = string.Empty;
                txt_Paypal_BankName.Text = string.Empty;
                txt_Paypal_BranchName.Text = string.Empty;
                txt_Paypal_VoucherNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }          
            else if (transType == Indication_PaymentMode.Withdraw && payMeth == Indication_IPOPaymentTransaction.EFT)
            {
                //txtAmount.Text = string.Empty;
                txtEFTBankID.Text = string.Empty;
                txt_EftWithdraw_BranchName.Text = string.Empty;
                txtEFTBranchID.Text = string.Empty;
                txt_EftWithdraw_BankName.Text = string.Empty;
                txt_EftWithdraw_RoutingNo.Text = string.Empty;
                txt_EftWithdraw_VoucherNo.Text = string.Empty;
                txt_EftWithdraw_BankAccNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
            else if (transType == Indication_PaymentMode.Withdraw && payMeth == Indication_IPOPaymentTransaction.EFT_Return)
            {
                //txtAmount.Text = string.Empty;
                txt_EftWithdraw_BranchName.Text = string.Empty;
                txt_EftWithdraw_BankName.Text = string.Empty;
                txt_EftWithdraw_RoutingNo.Text = string.Empty;
                txt_EftWithdraw_VoucherNo.Text = string.Empty;
                txt_EftWithdraw_BankAccNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }
          
            else if (transType == Indication_PaymentMode.Withdraw && payMeth == Indication_IPOPaymentTransaction.TRTA)
            {
                //txtAmount.Text = string.Empty;
                txt_Transfer_CustCode.Text = string.Empty;
                txt_Transfer_CustName.Text = string.Empty;
                txt_Transfer_Balance.Text = string.Empty;
                txt_Transfer_VoucherNo.Text = string.Empty;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }         
            else if ((transType == Indication_PaymentMode.Deposit || transType==Indication_PaymentMode.Withdraw)  && payMeth == Indication_IPOPaymentTransaction.TRIPOApp)
            {
                //txtAmount.Text = string.Empty;
                txt_Transfer_CustCode.Text = string.Empty;
                txt_Transfer_CustName.Text = string.Empty;
                txt_Transfer_Balance.Text = string.Empty;
                txt_Transfer_VoucherNo.Text = string.Empty; OnlineOrderNo = 0;
                OnlineOrderNo = 0;
                OnlineEntry_Date = null;
            }

        }

        private void ClearRefundPanel()
        {
            cmb_RefundMethod.SelectedIndex = -1;
            if (dg_RefundBankInfo != null)
            {
                dg_RefundBankInfo.DataSource = null;
            }                

        }

        private void ClearRefundPanel_ByRefundMethod()
        {
            if (dg_RefundBankInfo != null)
            {
                dg_RefundBankInfo.DataSource = null;
            }
                 
        }

        private void ClearAvailableSession()
        {
            if (dg_AvailableSession != null)
                dg_AvailableSession.DataSource = null;
             
        }

        private void ClearCustomerGrid()
        {
            if (dg_Customers != null)
            {
                dt_CustList_IPOPayment.Rows.Clear();
                //dg_Customers.DataSource = dt_CustList_IPOPayment;
            }
        }

        private void ClearAll()
        {
            txt_Paypal_VoucherNo.Text = "";
            txt_Paypal_OrderNo.Text = "";
            txt_Paypal_BranchName.Text = "";
            txt_Paypal_BankName.Text = "";
            txt_Transfer_VoucherNo.Text = "";
            txt_Transfer_CustName.Text = "";
            txt_Transfer_Balance.Text = "";
            txt_Transfer_CustCode.Text = "";
            txtSearchCustomer.Text = "";
            txtRemarks.Text = "";
            txtAmount.Text = "";
            txtLotNO.Text = "1";
            txt_ChannelID.Text = "0";
            txt_ChannelType.Text = string.Empty;
            ddlSearchCustomer.SelectedIndex = 0;
            //ddlPaymentMedia.SelectedIndex = 0;
            if (MenuName == Indication_Forms_Title.IPOPaymentWithdraw)
                ddlDepositWithdraw.SelectedIndex = 1;
            if (MenuName == Indication_Forms_Title.IPOPaymentDeposit)
                ddlDepositWithdraw.SelectedIndex = 0;
            chkMatureToday.Checked = false;
            chkMatureToday.Visible = false;
            dtRecievedDate.Value = DateTime.Now;
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
            Charge_For_IPO_Application = "";
            txtSearchCustomer.Focus();
            chk_AppliedTogather.Checked = false;
            txtAvailableWithdrawBalance.Text = string.Empty;
            txtAccruedBalance.Text = string.Empty;

            ExceptionCollectionList.Clear();
            ClearRefundPanel();
            ClearAvailableSession();
            ClearCustomerGrid();
            txt_Cust_Code_ForTransferParent.Text = "";
            ClearChequeDeposit();
            ClearTransfer();
            ClearPayOrder();
            ClearPanel();
            ClearEFTInformation();
            ClearEFTDepositInformation();
            dtpSearchPaymentEntry.Value = DateTime.Today.Date;
            ClearRequiredTransCharge();
            ClearChagableCustCode();
            ClearTransactionBasedChargeTaken();
            Clear_IPO_Application_ChargeTaken();
        }

        private void ClearAfterSave()
        {
            txt_Paypal_VoucherNo.Text = "";
            txt_Paypal_OrderNo.Text = "";
            txt_Paypal_BranchName.Text = "";
            txt_Paypal_BankName.Text = "";
            txt_Transfer_VoucherNo.Text = "";
            txt_Transfer_CustName.Text = "";
            txt_Transfer_Balance.Text = "";
            txt_Transfer_CustCode.Text = "";
            txtSearchCustomer.Text = "";
            txtRemarks.Text = "";           
            txtAmount.Text = "";
            txt_ChannelID.Text = "0";
            txt_ChannelType.Text = string.Empty;
            txt_EftWithdraw_BankName.Text = string.Empty;
            txt_EftWithdraw_BranchName.Text = string.Empty;
            txt_EftWithdraw_RoutingNo.Text = string.Empty;
            txt_EftWithdraw_VoucherNo.Text = string.Empty;
            txt_EftWithdraw_BankAccNo.Text = "";
            ddlSearchCustomer.SelectedIndex = 0;
            chkMatureToday.Checked = false;
            chkMatureToday.Visible = false;
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
            txtSearchCustomer.Focus();
            ExceptionCollectionList.Clear();
            ClearRefundPanel();
            ClearPayOrder();
            ClearRequiredTransCharge();
            ClearTransactionBasedChargeTaken();
            txt_TranChrg_ChagedAmount.Text = string.Empty;
            ClearTransactionBasedChargeTaken();
            Clear_IPO_Application_ChargeTaken();
        }

        private void ClearNoCustomerFound()
        {
            txt_Paypal_VoucherNo.Text = "";
            txt_Paypal_OrderNo.Text = "";
            txt_Paypal_BranchName.Text = "";
            txt_Paypal_BankName.Text = "";
            txt_Transfer_VoucherNo.Text = "";
            txt_Transfer_CustName.Text = "";
            txt_Transfer_Balance.Text = "";
            txt_Transfer_CustCode.Text = "";
            // txtSearchCustomer.Text = "";
            txtRemarks.Text = "";
            txtAmount.Text = "";
            txt_EftWithdraw_BankName.Text = string.Empty;
            txt_EftWithdraw_BranchName.Text = string.Empty;
            txt_EftWithdraw_RoutingNo.Text = string.Empty;
            txt_EftWithdraw_VoucherNo.Text = string.Empty;
            txt_EftWithdraw_BankAccNo.Text = "";
            ddlSearchCustomer.SelectedIndex = 0;
            chkMatureToday.Checked = false;
            chkMatureToday.Visible = false;
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
            txtSearchCustomer.Focus();
        }

        private void ClearChequeDeposit()
        {
            txtDepositChequeNo.Text = "";
            ddl_DepositCheque_BankName.SelectedIndex = -1;
            ddl_DepositCheque_BranchName.SelectedIndex = -1;
            ddl_DepositCheque_RoutingNo.SelectedIndex = -1;
            txt_DepositCheque_VoucherNo.Text = "";
            dtp_DepositChequeDate.Value = DateTime.Today.Date;
        }

        private void ClearTransactionBasedChargeTaken()
        {
            txt_TransChrg_ChargedCustCode.Text=string.Empty;
            dtp_TransChrg_ReceivedDate.Value=dtRecievedDate.Value;
            txt_TranChrg_ChagedAmount.Text=string.Empty;
            txt_TransChrg_VoucherNo.Text=string.Empty;
            txt_TransChrg_RefNo.Text=string.Empty;
            txt_TransChrg_Remarks.Text = string.Empty;
            txt_TransChrg_TransReason.Text=string.Empty;
            txt_TransChrg_TransFromCode.Text=string.Empty;
            txt_TransChrg_PaymentMediaID.Text=string.Empty;
            txt_TransChrg_PaymentMediaName.Text=string.Empty;
            chk_TransChrg_IsApplied.Checked=false;
            
            //Set_Distributed_Amount();
            //Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
            //Set_MinimumBalance_Amount();
        }

        private void ClearTransactionBasedChargeTaken_OnlyTakenFromAmount()
        {
            if(chk_TransChrg_IsApplied.Checked && txt_TransChrg_PaymentMediaName.Text==string.Empty)
            ClearTransactionBasedChargeTaken();
        }
        
        private void ClearChargeCust_Code_Checking()
        {
            foreach (DataRow dr in dt_CustList_IPOPayment.Rows)
                dr["IsChargable"] = false;
        }

        private void Clear_IPO_Application_ChargeTaken()
        {
            txt_AppCharge_TransFrom.Text=string.Empty;
            dtp_AppCharge_ReceiveDate.Value=dtRecievedDate.Value;
            txt_AppCharge_Amount.Text=string.Empty;
            txt_AppCharge_VoucherNo.Text=string.Empty;
            txt_AppCharge_ReferenceNo.Text=string.Empty;
            txt_AppCharge_Remarks.Text=string.Empty;
            txt_AppCharge_TransReason.Text=string.Empty;
            txt_AppCharge_PaymentMediaID.Text=string.Empty;
            txt_AppCharge_PaymentMediaName.Text=string.Empty;
            chk_AppCharge_IsApplied.Checked=false;
            
            Set_Distributed_Amount();
            Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
            Set_MinimumBalance_Amount();
        }
        
        private void ClearChagableCustCode()
        {
            foreach (var value in dg_AvailableSession.Rows.Cast<DataGridViewRow>().ToList())
            {
                value.Cells["IsChargable"].Value = false;
            }   
        }

        private void ClearRequiredTransCharge()
        {
            txt_RequiredTranCharge.Text = "0";
            txt_TranChrg_ChagedAmount.Text = "0";
             
        }
        
        private void ClearTransfer()
        {
            txt_Transfer_CustCode.Text = "";
            txt_Transfer_CustName.Text = "";
            txt_Transfer_Balance.Text = "";
            txt_Transfer_VoucherNo.Text = "";
        }

        private void ClearPayOrder()
        {
            txt_Paypal_OrderNo.Text = "";
            dtp_Paypal_OrderDate.Value = DateTime.Today.Date;
            txt_Paypal_BankName.Text = "";
            txt_Paypal_BranchName.Text = "";
            txt_Paypal_VoucherNo.Text = "";
        }

        private void ClearPanel()
        {
            txt_Paypal_VoucherNo.Text = "";
            txt_Paypal_OrderNo.Text = "";
            txt_Paypal_BranchName.Text = "";
            txt_Paypal_BankName.Text = "";
            txt_Transfer_VoucherNo.Text = "";
            txt_Transfer_CustName.Text = "";
            txt_Transfer_Balance.Text = "";
            chkMatureToday.Checked = false;
            chkMatureToday.Visible = false;
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
            ClearRefundPanel();
        }

        //private void ClearEFT_Information()
        //{
        //    txteftBankBranchName.Text = "";
        //    txteftBankName.Text = "";
        //    txteftRoutingNo.Text = "";
        //    txteftVoucherNo.Text = "";
        //    txtBankAccNo.Text = "";
        //    OnlineOrderNo = 0;
        //    OnlineEntry_Date = null;
        //}

        private void ClearEFTInformation()
        {
            txt_EftWithdraw_BankName.Text = "";
            txt_EftWithdraw_BranchName.Text = "";
            txt_EftWithdraw_RoutingNo.Text = "";
            txt_EftWithdraw_BankAccNo.Text = "";
            txt_EftWithdraw_VoucherNo.Text = "";
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
        }

        private void ClearEFTDepositInformation()
        {
            ddl_DepositEft_Bank_Name.SelectedIndex = -1;
            ddl_DepositEft_Branch_Name.SelectedIndex = -1;
            ddl_DepositEft_RoutingNo.Text = "";
            txt_DepositEft_BankAccountNo.Text = "";
            txt_DepositEft_VoucherNo.Text = "";
            OnlineOrderNo = 0;
            OnlineEntry_Date = null;
        }

#endregion FormClearMethod

#region Check&ValidationMethod

        private void CheckCommonValidation()
        {
            if (txtSearchCustomer.Text.Trim() == "")
            {
                ControlToFocus = txtSearchCustomer;
                throw new Exception("Please Fill the Search Customer Code.");
            }
            if (txtAmount.Text.Trim() == "")
            {
                ControlToFocus = txtAmount;
                throw new Exception("Please Fill the Amount.");
            }
        }

        private void CheckLotMoney()
        {
            double LowestAmount = double.Parse(txt_Distributed_Amount.Text) + double.Parse(txt_MinBalance.Text);
            double gridAmount = dg_AvailableSession.Rows.Cast<DataGridViewRow>()
                .Where(T => Convert.ToBoolean(T.Cells[0].Value) == true)
                .Sum(t => Convert.ToDouble(t.Cells["TotalAmount"].Value))*Convert.ToDouble(txtLotNO.Text);
            if (gridAmount > LowestAmount)
            {
                throw new Exception("Insufficient Balance");
            }
        }

        private void CloseRefundMethodForParent()
        {
            if (cmb_RefundMethod.SelectedText == Indication_IPORefundType.Refund_TRPR_Desc)
            {
                throw new Exception("Refund method Transfer not allowed to ");
            }
        }
        //added By Md.Rashedul Hasan 19-Jan-2015
        /// <summary>
        /// Check Duplicate Deposit By same Voucher or remarks or same amount
        /// </summary>
        /// <param name="cust_code"></param>
        /// <param name="Trans_Type"></param>
        /// <param name="remarks"></param>
        /// <param name="voucher"></param>
        private void CheckSameRemarksORVoucherdDeposit(string cust_code, string Trans_Type, string remarks, string voucher)
        {
            IPOProcessBAL bal = new IPOProcessBAL();
            DataTable dt = new DataTable();
            dt = bal.GetIPOSameVoucherORRemarks(Trans_Type, cust_code, voucher, remarks);
            if (dt.Rows.Count > 0)
            {

                //var AccountStatus = dt.Rows.Cast<DataRow>().ToList(); 

                decimal Amount = Convert.ToDecimal(txtAmount.Text);
                foreach (var test in dt.Rows.Cast<DataRow>().ToList())
                {
                    string Trnas = test["Money_TransactionType_Name"].ToString();
                    decimal DepositAmount = Convert.ToDecimal(test["Amount"]);
                    string receiveDate = test["Received_Date"].ToString();
                    string voucher_no = test["Voucher_No"].ToString();
                    string remarks_no = test["Remarks"].ToString();
                    string user = test["Entry_By"].ToString();
                    string deposit = test["Deposit_Withdraw"].ToString();
                    string Status = test["ApproveORPending"].ToString();
                    string text = @"Your Transaction Already been done Against This Code =" + cust_code + "\n Transaction Name: " + Trnas + "\n Deposit Amount: " + DepositAmount + "\n Voucher No: " + voucher_no + "\nRemarks: " + remarks + "\nEntry By: " + user + "\n Wish To continue Again ??";
                    if (Status == "Pending")
                    {
                        if ((voucher_no == voucher && DepositAmount == Amount) || voucher_no == voucher || DepositAmount == Amount || (remarks == remarks_no && DepositAmount == Amount) || remarks == remarks_no)
                        {

                            throw new Exception(text);

                        }
                    }
                    else
                    {
                        if ((voucher_no == voucher && DepositAmount == Amount) || DepositAmount == Amount || (remarks == remarks_no && DepositAmount == Amount))
                        {
                            if (DialogResult.No == MessageBox.Show(text, "Error", MessageBoxButtons.YesNo))
                            {
                                throw new Exception("Go to another one!!");
                            }
                        }
                    }
                }

            }


        }

        private void CheckAllValidation(string pmedia)
        {

            if (pmedia == Indication_IPOPaymentTransaction.EFT)
            {
                
                if (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw) //Non Return Withdraw 
                {
                    
                    string[] Cust_Code_For_Bank_Name = dgvEFTbankInfo.Rows.Cast<DataGridViewRow>().Where(B => Convert.ToString(B.Cells["BankName"].Value) == string.Empty)
                        .Select(t => Convert.ToString(t.Cells["Cust_Code"].Value)).ToArray();
                    string[] Cust_Code_For_Rounting = dgvEFTbankInfo.Rows.Cast<DataGridViewRow>().Where(B => Convert.ToString(B.Cells["RoutingNo"].Value) == string.Empty)
                       .Select(t => Convert.ToString(t.Cells["Cust_Code"].Value)).ToArray();
                    string[] Cust_Code_For_Branch_Name = dgvEFTbankInfo.Rows.Cast<DataGridViewRow>().Where(B => Convert.ToString(B.Cells["BranchName"].Value) == string.Empty)
                       .Select(t => Convert.ToString(t.Cells["Cust_Code"].Value)).ToArray();
                    if (Cust_Code_For_Bank_Name.Length > 0)
                    {
                        throw new Exception("Problem Bank name for this code" + String.Join(",", Cust_Code_For_Bank_Name));                        
                    }
                    else if (Cust_Code_For_Rounting.Length > 0)
                    {
                        throw new Exception("Problem Rountng No for this code" + String.Join(",", Cust_Code_For_Rounting)); 
                    }
                    else if (Cust_Code_For_Branch_Name.Length > 0)
                    {
                        throw new Exception("Problem Branch name for this code" + String.Join(",", Cust_Code_For_Branch_Name));
                    }
                        
                   
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    if (chk_AppliedTogather.Checked)
                    {
                        CloseRefundMethodForParent();
                    }
                    //else if (Convert.ToInt32(txtAmount.Text) > 400000 || Convert.ToInt32(txtAmount.Text) < 100)
                    //{
                    //    ControlToFocus = txtAmount;
                    //    throw new Exception("Amount must be between 100 and 400000 Taka");
                    //}

                    /*-----------------------Added By Rashedul Hasan---------------------------*/
                    if (dt_CustList_IPOPayment.Rows.Count > 0)
                    {

                        foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                        {
                            string cust_code = amount["Cust_Code"].ToString();
                            decimal Distributed_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                            EntryBlanceChecking(cust_code, Distributed_Amount);

                        }
                    }
                    /*--------------------------------------------------*/

                }
                else if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit) //Non Return Deposit 
                {
                    //if (ddl_DepositEft_Bank_Name.SelectedIndex < 0)
                    //{
                    //    // ControlToFocus = txteftBankName;
                    //    throw new Exception("Bank Name Required");
                    //}
                    //if (ddl_DepositEft_Branch_Name.SelectedIndex < 0)
                    //{
                    //    //ControlToFocus = txteftBankBranchName;
                    //    throw new Exception("Branch Name Required");
                    //}
                    //if (ddl_DepositEft_RoutingNo.SelectedIndex < 0)
                    //{
                    //    //ControlToFocus = ddlEftDepositRoutingNo;
                    //    //throw new Exception("Routing Number Required");
                    //}
                    //if (txt_DepositEft_BankAccountNo.Text == "")
                    //{
                    //    ControlToFocus = txt_DepositEft_BankAccountNo;
                    //    throw new Exception("Bank Account Number Required");
                    //}
                    if (txt_DepositEft_VoucherNo.Text == "")
                    {
                        ControlToFocus = txt_DepositEft_VoucherNo;
                        throw new Exception("Voucher Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    if (cmb_RefundMethod.SelectedText == Indication_IPORefundType.Refund_TRPR_Desc)
                    {
                        throw new Exception("Refund method Transfer not allowed to " + pmedia);
                    }
                    CheckLotMoney();
                    //CheckWithdrawBalance();
                    if (chk_AppliedTogather.Checked)
                    {
                        CheckLotMoney();
                        CloseRefundMethodForParent();

                        //Added By Md.Rashedul Hasan 20-Jan-2015
                        if (dg_AvailableSession.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dg_AvailableSession.Rows[0].Cells["IsSelect"].Value) != true)
                            {
                                throw new Exception("Please Select Company Name");
                            }

                        }
                        /*******************************************************************************/
                    }
                    if(isclosed)
                    throw new Exception("This is temporarily haulted!!");
                
                    //else if (Convert.ToInt32(txtAmount.Text) > 400000 || Convert.ToInt32(txtAmount.Text) < 100)
                    //{
                    //    ControlToFocus = txtAmount;
                    //    throw new Exception("Amount must be between 100 and 400000 Taka");
                    //}
                }

            }

            else if (pmedia == Indication_IPOPaymentTransaction.EFT_Return)
            {
                if (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw) //Return Withdraw
                {
                    if (txt_EftWithdraw_BankName.Text == "")
                    {
                        ControlToFocus = txt_EftWithdraw_BankName;
                        throw new Exception("Bank Name Required");
                    }
                    if (txt_EftWithdraw_BranchName.Text == "")
                    {
                        ControlToFocus = txt_EftWithdraw_BranchName;
                        throw new Exception("Branch Name Required");
                    }
                    if (txt_EftWithdraw_RoutingNo.Text == "")
                    {
                        ControlToFocus = txt_EftWithdraw_RoutingNo;
                        throw new Exception("Routing Number Required");
                    }
                    if (txt_EftWithdraw_BankAccNo.Text == "")
                    {
                        ControlToFocus = txt_EftWithdraw_BankAccNo;
                        throw new Exception("Bank Account Number Required");
                    }
                    if (txt_EftWithdraw_VoucherNo.Text == "")
                    {
                        ControlToFocus = txt_EftWithdraw_VoucherNo;
                        throw new Exception("Voucher Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    //else if (Convert.ToInt32(txtAmount.Text) > 400000 || Convert.ToInt32(txtAmount.Text) < 100)
                    //{
                    //    ControlToFocus = txtAmount;
                    //    throw new Exception("Amount must be between 100 and 400000 Taka");
                    //}
                    if (chk_AppliedTogather.Checked)
                    {
                        CloseRefundMethodForParent();
                    }
                    /*-----------------------Added By Rashedul Hasan---------------------------*/
                    if (dt_CustList_IPOPayment.Rows.Count > 0)
                    {

                        foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                        {
                            string cust_code = amount["Cust_Code"].ToString();
                            decimal Distributed_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                            EntryBlanceChecking(cust_code, Distributed_Amount);

                        }
                    }
                    /*--------------------------------------------------*/

                }
                else if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit) //Return Deposit
                {
                    //if (string.IsNullOrEmpty(txt_DepositEft_VoucherNo.Text))
                    //{
                        // ControlToFocus = txteftBankName;
                    //    ControlToFocus = txt_DepositEft_VoucherNo;
                    //    throw new Exception("Vocher no is required");
                    //}
                    if (dg_Customers.Rows.Count>1)
                    {
                        //ControlToFocus = txteftBankBranchName;
                        throw new Exception("Two customers eft return is not possible at the same time");
                    }
                    if (dg_Customers.Rows.Count == 0)
                    {
                        //ControlToFocus = txteftBankBranchName;
                        throw new Exception("provide a eftreturn cust code");
                    }
                    if (ddl_DepositEft_RoutingNo.SelectedIndex < 0)
                    {
                        // ControlToFocus = txtEftDepositRoutingNo;
                        //throw new Exception("Routing Number Required");
                    }
                    if (txt_DepositEft_BankAccountNo.Text == "")
                    {
                        //ControlToFocus = txt_DepositEft_BankAccountNo;
                        //throw new Exception("Bank Account Number Required");
                    }
                    if (txt_DepositEft_VoucherNo.Text == "")
                    {
                        //ControlToFocus = txt_DepositEft_VoucherNo;
                        //throw new Exception("Voucher Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    

                }

            }

            else if (pmedia == Indication_IPOPaymentTransaction.Cash)
            {
                if (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw) //Non Return Withdraw
                {
                    if (txt_Paypal_VoucherNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Paypal_VoucherNo;
                        throw new Exception("Serial Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    /*-----------------------Added By Rashedul Hasan---------------------------*/
                    if (dt_CustList_IPOPayment.Rows.Count > 0)
                    {

                        foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                        {
                            string cust_code = amount["Cust_Code"].ToString();
                            decimal Distributed_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                            EntryBlanceChecking(cust_code, Distributed_Amount);

                        }
                    }
                    /*--------------------------------------------------*/
                    CheckWithdrawBalance();
                    CheckLotMoney();
                    if (chk_AppliedTogather.Checked)
                    {
                        CloseRefundMethodForParent();
                    }
                }

                else if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit) //Non Return Deposit
                {
                    if (txt_Paypal_VoucherNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Paypal_VoucherNo;
                        throw new Exception("Serial Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    if (cmb_RefundMethod.SelectedText == Indication_IPORefundType.Refund_TRPR_Desc)
                    {
                        throw new Exception("Refund method Transfer not allowed to " + pmedia);
                    }
                    if (chk_AppliedTogather.Checked)
                    {
                        CheckLotMoney();
                        CloseRefundMethodForParent();

                        //Added By Md.Rashedul Hasan 20-Jan-2015
                        if (dg_AvailableSession.Rows.Count > 0)
                        {
                            
                            if (Convert.ToBoolean(dg_AvailableSession.Rows[0].Cells["IsSelect"].Value)!= true)
                            {
                                throw new Exception("Please Select Company Name");
                            }

                        }
                        /*******************************************************************************/
                    }
                }

            }
            else if (pmedia == Indication_IPOPaymentTransaction.Ecash)
            {
                if (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw) //Non Return Withdraw
                {
                    if (txt_Paypal_VoucherNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Paypal_VoucherNo;
                        throw new Exception("Serial Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    /*-----------------------Added By Rashedul Hasan---------------------------*/
                    if (dt_CustList_IPOPayment.Rows.Count > 0)
                    {

                        foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                        {
                            string cust_code = amount["Cust_Code"].ToString();
                            decimal Distributed_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                            EntryBlanceChecking(cust_code, Distributed_Amount);

                        }
                    }
                    /*--------------------------------------------------*/
                    CheckWithdrawBalance();
                    CheckLotMoney();
                    if (chk_AppliedTogather.Checked)
                    {
                        CloseRefundMethodForParent();
                    }
                }

                else if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit) //Non Return Deposit
                {
                    if (txt_Paypal_VoucherNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Paypal_VoucherNo;
                        throw new Exception("Serial Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    if (cmb_RefundMethod.SelectedText == Indication_IPORefundType.Refund_TRPR_Desc)
                    {
                        throw new Exception("Refund method Transfer not allowed to " + pmedia);
                    }
                    if (chk_AppliedTogather.Checked)
                    {
                        CheckLotMoney();
                        CloseRefundMethodForParent();

                        //Added By Md.Rashedul Hasan 20-Jan-2015
                        if (dg_AvailableSession.Rows.Count > 0)
                        {

                            if (Convert.ToBoolean(dg_AvailableSession.Rows[0].Cells["IsSelect"].Value) != true)
                            {
                                throw new Exception("Please Select Company Name");
                            }

                        }
                        /*******************************************************************************/
                    }
                }

            }
            else if (pmedia == Indication_IPOPaymentTransaction.Cheque)
            {
                if (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw) //Non Return Withdraw
                {
                    if (txtDepositChequeNo.Text == "")// txtPaymentMedia.Text == "")
                    {
                        ControlToFocus = txtDepositChequeNo;
                        throw new Exception("Payment Media  Required");
                    }
                    if (ddl_DepositCheque_BankName.Text.Trim() == "")
                    {
                        // ControlToFocus = txtBankName;
                        throw new Exception("Bank Name Required");
                    }
                    if (ddl_DepositCheque_BranchName.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Paypal_BranchName;
                        throw new Exception("Branch Name Required");
                    }
                    if (txt_DepositCheque_VoucherNo.Text == "")// txtSerialNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_DepositCheque_VoucherNo;
                        throw new Exception("Serial Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    /*-----------------------Added By Rashedul Hasan---------------------------*/
                    if (dt_CustList_IPOPayment.Rows.Count > 0)
                    {

                        foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                        {
                            string cust_code = amount["Cust_Code"].ToString();
                            decimal Distributed_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                            EntryBlanceChecking(cust_code, Distributed_Amount);

                        }
                    }
                    /*--------------------------------------------------*/
                    CheckWithdrawBalance();
                    CheckLotMoney();
                    if (chk_AppliedTogather.Checked)
                    {
                        CloseRefundMethodForParent();
                    }
                }

                else if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit) //Non Return Deposit
                {
                    if (txtDepositChequeNo.Text == "")// txtPaymentMedia.Text == "")
                    {
                        ControlToFocus = txtDepositChequeNo;
                        throw new Exception("Payment Media  Required");
                    }
                    if (ddl_DepositCheque_BankName.Text.Trim() == "")
                    {
                        // ControlToFocus = txtBankName;
                        throw new Exception("Bank Name Required");
                    }
                    if (ddl_DepositCheque_BranchName.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Paypal_BranchName;
                        throw new Exception("Branch Name Required");
                    }
                    if (txt_DepositCheque_VoucherNo.Text == "")// txtSerialNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_DepositCheque_VoucherNo;
                        throw new Exception("Serial Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    if (cmb_RefundMethod.SelectedText == Indication_IPORefundType.Refund_TRPR_Desc)
                    {
                        throw new Exception("Refund method Transfer not allowed to " + pmedia);
                    }
                    if (chk_AppliedTogather.Checked)
                    {
                        CheckLotMoney();
                        CloseRefundMethodForParent();

                        //Added By Md.Rashedul Hasan 20-Jan-2015
                        if (dg_AvailableSession.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dg_AvailableSession.Rows[0].Cells["IsSelect"].Value) != true)
                            {
                                throw new Exception("Please Select Company Name");
                            }

                        }
                        /*******************************************************************************/
                    }
                    if (isclosed)
                    throw new Exception("This is temporarily haulted!!");
                }


            }

            else if (pmedia == Indication_IPOPaymentTransaction.Cheque_Return)
            {
                if (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw) //Return Withdraw
                {
                    if (txtDepositChequeNo.Text == "")// txtPaymentMedia.Text == "")
                    {
                        ControlToFocus = txtDepositChequeNo;
                        throw new Exception("Payment Media  Required");
                    }
                    if (ddl_DepositCheque_BankName.Text.Trim() == "")
                    {
                        // ControlToFocus = txtBankName;
                        throw new Exception("Bank Name Required");
                    }
                    if (ddl_DepositCheque_BranchName.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Paypal_BranchName;
                        throw new Exception("Branch Name Required");
                    }
                    if (txt_DepositCheque_VoucherNo.Text == "")// txtSerialNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_DepositCheque_VoucherNo;
                        throw new Exception("Serial Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    if (chk_AppliedTogather.Checked)
                    {
                        CheckLotMoney();
                        CloseRefundMethodForParent();
                    }
                    /*-----------------------Added By Rashedul Hasan---------------------------*/
                    if (dt_CustList_IPOPayment.Rows.Count > 0)
                    {

                        foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                        {
                            string cust_code = amount["Cust_Code"].ToString();
                            decimal Distributed_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                            EntryBlanceChecking(cust_code, Distributed_Amount);

                        }
                    }
                    /*--------------------------------------------------*/
                    if (isclosed)
                    throw new Exception("This is temporarily haulted!!");
                }

                else if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit) //Return Deposit
                {
                    if (txtDepositChequeNo.Text == "")// txtPaymentMedia.Text == "")
                    {
                        ControlToFocus = txtDepositChequeNo;
                        throw new Exception("Payment Media  Required");
                    }
                    if (ddl_DepositCheque_BankName.Text.Trim() == "")
                    {
                        // ControlToFocus = txtBankName;
                        throw new Exception("Bank Name Required");
                    }
                    if (ddl_DepositCheque_BranchName.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Paypal_BranchName;
                        throw new Exception("Branch Name Required");
                    }
                    if (txt_DepositCheque_VoucherNo.Text == "")// txtSerialNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_DepositCheque_VoucherNo;
                        throw new Exception("Serial Number Required");
                    }
                    if (txtAmount.Text == "")
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Required");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    if (cmb_RefundMethod.SelectedText == Indication_IPORefundType.Refund_TRPR_Desc)
                    {
                        throw new Exception("Refund method Transfer not allowed to " + pmedia);
                    }
                    //CheckWithdrawBalance();
                    if (chk_AppliedTogather.Checked)
                    {
                        CheckLotMoney();
                        CloseRefundMethodForParent();

                        //Added By Md.Rashedul Hasan 20-Jan-2015
                        if (dg_AvailableSession.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dg_AvailableSession.Rows[0].Cells["IsSelect"].Value) != true)
                            {
                                throw new Exception("Please Select Company Name");
                            }

                        }
                        /*******************************************************************************/
                    }
                    if (isclosed)
                    throw new Exception("This is temporarily haulted!!");
                }


            }
            else if (pmedia == Indication_IPOPaymentTransaction.TRTA || pmedia == Indication_IPOPaymentTransaction.TRIPO)
            {
                if (MenuName == Indication_Forms_Title.IPOPaymentDeposit)
                {
                    if (txt_Transfer_CustCode.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Transfer_CustCode;
                        throw new Exception("Please Fill the Customer Code/BO ID.");
                    }
                    if (txt_Transfer_VoucherNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Transfer_VoucherNo;
                        throw new Exception("Please Fill the Voucher No.");
                    }

                    if (txt_Transfer_Balance.Text.Trim() != "")
                        chkTRBalance = float.Parse(txt_Transfer_Balance.Text);
                    if (txtAmount.Text.Trim() != "")
                    {
                        chkAmount = float.Parse(txtAmount.Text);
                    }

                    //if (chkTRBalance < chkAmount)
                    //{
                    //    throw new Exception("Insufficient Balance to TR! Please check.");
                    //}
                    //Added BY MD.Rashedul hasan
                    if (ddlPaymentMedia.Text == Indication_PaymentTransaction.TRIPO)
                    {
                        foreach (DataRow code in dt_CustList_IPOPayment.Rows)
                        {
                            string cust_code = code["Cust_Code"].ToString();
                            if (cust_code == txt_Transfer_CustCode.Text)
                            {
                                throw new Exception("Same Account TRIPO Not possible");
                            }
                            else
                            {
                                if (Convert.ToDecimal(chkAmount) > (Total_Balance - Withdraw_Pending_Balance))
                                {
                                    throw new Exception("Your previous Balance =" + Total_Balance + "\n available withdrawal Balance = " + Total_Approved_Pending_Balance + "\n Total Pendding deposit Amount = " + Deposit_Pending_Balance + " Deposit Transaction Pending By: " + Deposit_Transaction_Name + "\n Total Withdraw Balance = " + Withdraw_Pending_Balance + " Withdraw Transaction Pending By: " + Withdraw_Transaction_Name);

                                }
                            }
                        }
                    }
                        /*********************************************************************/
                    else
                    {
                        //Edit By MD.Rashedul hasan ON 26-01-2015
                        //double currentBalance = Convert.ToDouble(txt_Transfer_Balance.Text);
                        double GoingBalance = Convert.ToDouble(txtAmount.Text);
                        //if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit
                        //    && Validation.Payment_MinimumBalanceHave_InWithdraw_ForActive > (currentBalance - GoingBalance))
                        //{
                        //    throw new Exception("Insufficient Balance! Please check.");
                        //}
                        if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit && Tr_AvailableWithdraw_Balance < Convert.ToDecimal(GoingBalance))
                        {
                            txt_Transfer_Balance.Focus();
                            txt_Transfer_Balance.BackColor = System.Drawing.Color.Red;
                            throw new Exception("Cust Code : " + txt_Transfer_CustCode.Text + "\nAvailable Withdraw Balance is :" + Tr_AvailableWithdraw_Balance + "\nYour Current Balance is :" + Tr_CurrentBalance + "\nPending Withdraw Transaction :" + Tr_Pending_Withdraw);
                        }
                        else
                        {
                            txt_Transfer_Balance.BackColor = System.Drawing.Color.GreenYellow;
                        }
                        /////////////////////////////26-01-2015///////////////
                        //double currentBalance = Convert.ToDouble(txt_Transfer_Balance.Text);
                        //double GoingBalance = Convert.ToDouble(txtAmount.Text);
                        //if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit
                        //    && Validation.Payment_MinimumBalanceHave_InWithdraw_ForActive > (currentBalance - GoingBalance))
                        //{
                        //    throw new Exception("Insufficient Balance! Please check.");
                        //}
                    }
                    /*********************************************************************/
                    if (ddlDepositWithdraw.SelectedIndex == 1 && float.Parse(txt_Transfer_Balance.Text) < float.Parse(txtAmount.Text))
                    {
                        throw new Exception("Insufficient Balance! Please check.");
                    }
                    if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                    {
                        ControlToFocus = txtAmount;
                        throw new Exception("Amount Not Shown Grid Data");
                    }
                    if (chk_AppliedTogather.Checked)
                    {
                        CloseRefundMethodForParent();

                        //Added By Md.Rashedul Hasan 20-Jan-2015
                        if (dg_AvailableSession.Rows.Count > 0)
                        {
                            if (Convert.ToBoolean(dg_AvailableSession.Rows[0].Cells["IsSelect"].Value) != true)
                            {
                                throw new Exception("Please Select Company Name");
                            }

                        }
                        /*******************************************************************************/
                    }
                    //Suggestion
                    IPOProcessBAL trtaBal = new IPOProcessBAL();
                    DataTable dtparentChildCheck = new DataTable();
                    dtparentChildCheck = trtaBal.GetAllChildCode(txt_Transfer_CustCode.Text);
                    bool isIncludedParentChild = true;
                    //foreach (var data in Cust_Code_IPOAcc)
                    //{
                    //    if (!dt.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(data))
                    //    {
                    //        isIncludedParentChild = false;
                    //        break;
                    //    }
                    //}
                    //End Suggestion

                    if (dt_CustList_IPOPayment.Rows.Count == 1)
                    {
                        ControlToFocus = txtSearchCustomer;
                        string FromCustCode = txt_Transfer_CustCode.Text;
                        string ToCustCode = dt_CustList_IPOPayment.Rows[0]["Cust_Code"].ToString();

                        if (FromCustCode != ToCustCode)
                        {
                            //if (!dtparentChildCheck.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(ToCustCode))
                            //{
                            //    MessageBox.Show("Invalid Parent Child");
                            //} 
                            if (!dtparentChildCheck.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(ToCustCode))
                            {
                                isIncludedParentChild = false;
                                throw new Exception("Invalid Child Or parent code found, Check Your parent and child code" + MessageBoxIcon.Error);
                            } 
                        }  
                           

                    }                    
                    else
                    {
                        ControlToFocus = txtSearchCustomer;
                        string[] Cust_Code_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                        foreach (var data in Cust_Code_IPOAcc)
                        {
                            if (!dtparentChildCheck.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(data))
                            {
                                isIncludedParentChild = false;
                                throw new Exception("Invalid Child Or parent code found, Check Your parent and child code" + MessageBoxIcon.Error);
                            }
                            //throw new Exception("Multi Transfer Not Allowed!!");
                        }
                        //throw new Exception("Multi Transfer Not Allowed!!");
                    }
                    //if (dt_CustList_IPOPayment.Rows.Count == 1)
                    //{
                    //    if (Convert.ToString(dt_CustList_IPOPayment.Rows[0]["Cust_Code"]) != Convert.ToString(txt_Transfer_CustCode.Text))
                    //    {
                    //        ControlToFocus = txtSearchCustomer;
                    //        throw new Exception("Transfer Should Possible Only Same Account!!");
                    //    }
                    //}
                }
                #region Withdraw Block
            //    else if (MenuName == Indication_Forms_Title.IPOPaymentWithdraw)
            //    {
            //        if (txt_Transfer_CustCode.Text.Trim() == "")
            //        {
            //            ControlToFocus = txt_Transfer_CustCode;
            //            throw new Exception("Please Fill the Customer Code/BO ID.");
            //        }
            //        if (txt_Transfer_VoucherNo.Text.Trim() == "")
            //        {
            //            ControlToFocus = txt_Transfer_VoucherNo;
            //            throw new Exception("Please Fill the Voucher No.");
            //        }

            //        if (txt_Transfer_Balance.Text.Trim() != "")
            //            chkTRBalance = float.Parse(txt_Transfer_Balance.Text);
            //        if (txtAmount.Text.Trim() != "")
            //        {
            //            chkAmount = float.Parse(txtAmount.Text);
            //        }

            //        if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
            //        {
            //            ControlToFocus = txtAmount;
            //            throw new Exception("Amount Not Shown Grid Data");
            //        }
            //        if (dt_CustList_IPOPayment.Rows.Count > 1)
            //        {
            //            ControlToFocus = txtSearchCustomer;
            //            throw new Exception("Multi Transfer Not Allowed!!");
            //        }
            //        IPOProcessBAL trtaBal = new IPOProcessBAL();
            //        DataTable dtparentChildCheck = new DataTable();
            //        dtparentChildCheck = trtaBal.GetAllChildCode(txt_Transfer_CustCode.Text);
            //        bool isIncludedParentChild = true;
            //        //foreach (var data in Cust_Code_IPOAcc)
            //        //{
            //        //    if (!dt.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(data))
            //        //    {
            //        //        isIncludedParentChild = false;
            //        //        break;
            //        //    }
            //        //}
            //        //End Suggestion

            //        if (dt_CustList_IPOPayment.Rows.Count == 1)
            //        {
            //            ControlToFocus = txtSearchCustomer;
            //            string FromCustCode = txt_Transfer_CustCode.Text;
            //            string ToCustCode = dt_CustList_IPOPayment.Rows[0]["Cust_Code"].ToString();

            //            if (FromCustCode != ToCustCode)
            //            {
            //                //if (!dtparentChildCheck.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(ToCustCode))
            //                //{
            //                //    MessageBox.Show("Invalid Parent Child");
            //                //} 
            //                if (!dtparentChildCheck.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(ToCustCode))
            //                {
            //                    isIncludedParentChild = false;
            //                    throw new Exception("Invalid Child Or parent code found, Check Your parent and child code" + MessageBoxIcon.Error);
            //                }
            //            }


            //        }
            //        else
            //        {
            //            //ControlToFocus = txtSearchCustomer;
            //            //string[] Cust_Code_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
            //            //foreach (var data in Cust_Code_IPOAcc)
            //            //{
            //            //    if (!dtparentChildCheck.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(data))
            //            //    {
            //            //        isIncludedParentChild = false;
            //            //        throw new Exception("Invalid Child Or parent code found, Check Your parent and child code" + MessageBoxIcon.Error);
            //            //    }
            //            //    //throw new Exception("Multi Transfer Not Allowed!!");
            //            //}
            //            throw new Exception("Multi Transfer Not Allowed!!");
            //        }

            //        CheckTRWithdrawBalance();
                //    }
#endregion 

                else if (MenuName == Indication_Forms_Title.IPOPaymentWithdraw)
                {
                    if (txt_Transfer_CustCode.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Transfer_CustCode;
                        throw new Exception("Please Fill the Customer Code/BO ID.");
                    }
                    if (txt_Transfer_VoucherNo.Text.Trim() == "")
                    {
                        ControlToFocus = txt_Transfer_VoucherNo;
                        throw new Exception("Please Fill the Voucher No.");
                    }
                    IPOProcessBAL trtaBal = new IPOProcessBAL();
                    DataTable dtparentChildCheck = new DataTable();
                    bool isIncludedParentChild=false ;
                   
                    if (ddlPaymentMedia.Text == Indication_PaymentTransaction.TRIPO)
                    {
                        string[] Cust_Code_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                        dtparentChildCheck = trtaBal.GetParentCodeFromChildCode(Cust_Code_IPOAcc);
                        isIncludedParentChild = true;
                        if (dt_CustList_IPOPayment.Rows.Count > 0)
                        {
                            ControlToFocus = txtSearchCustomer;
                            string FromCustCode = "";
                            if (dtparentChildCheck.Rows.Count > 0)
                                FromCustCode = dtparentChildCheck.Rows[0][0].ToString();

                            string ToCustCode = "";
                            DataTable dtTransferCheckParent = trtaBal.GetParentCodeFromChildCode(new string[] { txt_Transfer_CustCode.Text });
                            if (dtTransferCheckParent.Rows.Count > 0)
                                ToCustCode = dtTransferCheckParent.Rows[0][0].ToString();

                            if (FromCustCode != ToCustCode)
                            {
                                isIncludedParentChild = false;
                                throw new Exception("Invalid Child Or parent code found, Check Your parent and child code" + MessageBoxIcon.Error);
                            }
                            else
                            {
                                //Added By Md.Rashedul hasan

                                if (dt_CustList_IPOPayment.Rows.Count > 0)
                                {

                                    foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                                    {
                                        //string cust_code = code["Cust_Code"].ToString();
                                        string cust_code = amount["Cust_Code"].ToString();
                                        decimal Distributed_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                                        if (cust_code == txt_Transfer_CustCode.Text)
                                        {
                                            throw new Exception("Same Account TRIPO Not possible");
                                        }
                                        else
                                        {
                                            EntryBlanceChecking(cust_code, Distributed_Amount);
                                        }

                                    }
                                }
                                //////////////
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(txt_Distributed_Amount.Text) == 0)
                        {
                            ControlToFocus = txtAmount;
                            throw new Exception("Amount Not Shown Grid Data");
                        }
                        if (txt_Transfer_Balance.Text.Trim() != "")
                            chkTRBalance = float.Parse(txt_Transfer_Balance.Text);
                        if (txtAmount.Text.Trim() != "")
                        {
                            chkAmount = float.Parse(txtAmount.Text);
                        }
                        if (dt_CustList_IPOPayment.Rows.Count > 1)
                        {
                            ControlToFocus = txtSearchCustomer;
                            throw new Exception("Multi Transfer Not Allowed!!");
                        }
                        if (dt_CustList_IPOPayment.Rows.Count > 1)
                        {
                            ControlToFocus = txtSearchCustomer;
                            throw new Exception("Multi Transfer Not Allowed!!");
                        }
                        //Added By Md.Rashedul hasan
                        
                        if (dt_CustList_IPOPayment.Rows.Count > 0)
                        {

                            foreach (DataRow amount in dt_CustList_IPOPayment.Rows)
                            {
                                string cust_code = amount["Cust_Code"].ToString();
                                decimal Distributed_Amount = Convert.ToDecimal(amount["Distributed_Amount"]);
                                EntryBlanceChecking(cust_code, Distributed_Amount);

                            }
                        }
                        //////////////
                        dtparentChildCheck = trtaBal.GetAllChildCode(txt_Transfer_CustCode.Text);
                        isIncludedParentChild = true;
                        if (dt_CustList_IPOPayment.Rows.Count == 1)
                        {
                            ControlToFocus = txtSearchCustomer;
                            string FromCustCode = txt_Transfer_CustCode.Text;
                            string ToCustCode = dt_CustList_IPOPayment.Rows[0]["Cust_Code"].ToString();

                            if (FromCustCode != ToCustCode)
                            {
                                //if (!dtparentChildCheck.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(ToCustCode))
                                //{
                                //    MessageBox.Show("Invalid Parent Child");
                                //} 
                                if (!dtparentChildCheck.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Child_Code"])).Contains(ToCustCode))
                                {
                                    isIncludedParentChild = false;
                                    throw new Exception("Invalid Child Or parent code found, Check Your parent and child code" + MessageBoxIcon.Error);
                                }
                            }


                        }
                        else
                        {

                            throw new Exception("Multi Transfer Not Allowed!!");
                        }

                    }
                    CheckTRWithdrawBalance();
                }

            }

        }
        //Added By Md.Rashedul Hasan
        /// <summary>
        /// Withdraw Balance Checking For withdraw Transaction
        /// </summary>
        /// <param name="cust_code"></param>
        /// <param name="Distributed_Amount"></param>
        private void EntryBlanceChecking(string cust_code, decimal Distributed_Amount)
        {
            IPOProcessBAL ACBal = new IPOProcessBAL();
            string[] Total_withdraw_transaction_Name = null;
            string[] Total_Deposit_transaction_Name = null;
            string[] Total_Withdraw_Pending = null;
            string[] Total_Deposit_Pending = null;
            string[] Previous_Balance = null;
            string[] Present_Approve_Pending_Balance = null;
            DataTable dt = new DataTable();
            dt = ACBal.GetIPOAccountInformation(cust_code);
            if (dt.Rows.Count > 0)
            {
                Total_Balance = 0.0M;
                Total_Approved_Pending_Balance = 0.0M;
                Withdraw_Pending_Balance = 0.0M;
                Deposit_Pending_Balance = 0.0M;

                Previous_Balance = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Presenct_Balance"])).ToArray(); ;
                Total_withdraw_transaction_Name = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Withdraw_Pending_Transaction_Name"])).ToArray();
                Total_Deposit_transaction_Name = dt.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["Deposit_Pending_Transaction_Name"])).ToArray();
                //Deposit_Transaction_Name = dt.Rows[0]["Deposit_Pending_Transaction_Name"].ToString();
                //Withdraw_Transaction_Name = dt.Rows[0]["Withdraw_Pending_Transaction_Name"].ToString();
                Withdraw_Transaction_Name = string.Join(",", Total_withdraw_transaction_Name);
                Deposit_Transaction_Name = string.Join(",", Total_Deposit_transaction_Name);

                Present_Approve_Pending_Balance = dt.Rows.Cast<DataRow>().Select(c => Convert.ToString(c["ApprovePendingBalance"])).ToArray();
                Total_Withdraw_Pending = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Withdraw_Pending"])).ToArray();
                Total_Deposit_Pending = dt.Rows.OfType<DataRow>().Select(c => Convert.ToString(c["Deposit_Pending"])).ToArray();

                for (int i = 0; i < Previous_Balance.Length; i++)
                {
                    decimal Hold = 0.0M;
                    if (Previous_Balance[i] != "")
                    {
                        Hold = Convert.ToDecimal(Previous_Balance[i]);
                        Total_Balance = Hold;
                    }
                }
                for (int i = 0; i < Present_Approve_Pending_Balance.Length; i++)
                {
                    decimal P_Hold = 0.0M;
                    if (Present_Approve_Pending_Balance[i] != "")
                    {
                        P_Hold = Convert.ToDecimal(Present_Approve_Pending_Balance[i]);
                        Total_Approved_Pending_Balance = P_Hold;
                    }
                }
                for (int i = 0; i < Total_Withdraw_Pending.Length; i++)
                {
                    decimal W_con = 0.0M;
                    string W_Pending = Total_Withdraw_Pending[i];
                    if (W_Pending == "")
                    {
                        W_Pending = "0";
                        W_con = W_con + Convert.ToDecimal(W_Pending);
                    }
                    else
                    {
                        W_con = W_con + Convert.ToDecimal(W_Pending);
                    }
                    Withdraw_Pending_Balance = Withdraw_Pending_Balance + W_con;
                }
                for (int i = 0; i < Total_Deposit_Pending.Length; i++)
                {
                    decimal D_con = 0.0M;
                    //Convert.ToDecimal(D_Pending);

                    string D_Pending = Total_Deposit_Pending[i];
                    if (D_Pending == "")
                    {
                        D_Pending = "0";
                        D_con = D_con + Convert.ToDecimal(D_Pending);
                    }
                    else
                    {
                        D_con = D_con + Convert.ToDecimal(D_Pending);
                    }
                    Deposit_Pending_Balance = Deposit_Pending_Balance + D_con;
                }
               //reza
                if (ChkNegativeBalanceNotCalculate.Checked == false)
                {
                    if ((Total_Balance - Withdraw_Pending_Balance) < Distributed_Amount)
                    {
                        throw new Exception("Your previous Balance =" + Total_Balance + "\n available withdrawal Balance = " + Total_Approved_Pending_Balance + "\n Total Pendding deposit Amount = " + Deposit_Pending_Balance + " Deposit Transaction Pending By: " + Deposit_Transaction_Name + "\n Total Withdraw Balance = " + Withdraw_Pending_Balance + " Withdraw Transaction Pending By: " + Withdraw_Transaction_Name + "\n For This Cust Code= " + cust_code);
                    }
                }
                
               
            }

        }

        private void ValidationCheck()
        {
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cash)
                CheckAllValidation(Indication_IPOPaymentTransaction.Cash);
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Ecash)
                CheckAllValidation(Indication_IPOPaymentTransaction.Ecash);
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
                CheckAllValidation(Indication_IPOPaymentTransaction.Cheque);
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque_Return)
                CheckAllValidation(Indication_IPOPaymentTransaction.Cheque_Return);
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT)
                CheckAllValidation(Indication_IPOPaymentTransaction.EFT);
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return)
                CheckAllValidation(Indication_IPOPaymentTransaction.EFT_Return);          
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPOApp)
                CheckAllValidation(Indication_IPOPaymentTransaction.TRIPOApp);
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA)
                CheckAllValidation(Indication_IPOPaymentTransaction.TRTA);
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return)
                CheckAllValidation(Indication_IPOPaymentTransaction.EFT);

        }

        private void CheckWithdrawBalance()
        {
            CommonBAL comBal = new CommonBAL();
            IPOApprovalBAL ipoBal = new IPOApprovalBAL();
            foreach (DataRow dr in dt_CustList_IPOPayment.Rows)
            {
                var BalanceForIPOAccount = ipoBal.GetIPOCustomerBalance(Convert.ToString(dr["Cust_Code"]));//CheckIn
                if (Convert.ToDouble(txtAmount.Text) > BalanceForIPOAccount)
                {
                    ControlToFocus = txtAmount;
                    throw new Exception("You have no sufficient balance to withdraw");
                }
            }
        }

        private void CheckTRWithdrawBalance()
        {
            PaymentInfoBAL payInfo = new PaymentInfoBAL();
            IPOApprovalBAL ipoBal = new IPOApprovalBAL();
            foreach (DataRow dr in dt_CustList_IPOPayment.Rows)
            {
                var BalanceForIPOAccount = ipoBal.GetIPOCustomerBalance(Convert.ToString(dr["Cust_Code"]));
                var BalanceForTradeAccount = payInfo.GetCurrentBalane(Convert.ToString(dr["Cust_Code"]));
                if (Convert.ToDouble(txtAmount.Text) > BalanceForIPOAccount)
                {
                    ControlToFocus = txtAmount;
                    throw new Exception("You have no sufficient balance to withdraw");
                }
            }
        }

        private bool Check_IsAllActive()
        {
            bool result = true;

            foreach (DataRow dr in dt_CustList_IPOPayment.Rows)
            {
                if (dr["Status"] != "Active")
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        //private bool CheckDeposit_Balance_GreaterThan_AppliedIPO()
        //{
        //    bool result=false;
        //    double doubleTryParse=0;
        //    double minBalance=0;
        //    double appliedBalance=0;
        //    if (double.TryParse(txt_MinBalance.Text, out doubleTryParse))
        //        minBalance = doubleTryParse;
            

        //    return result;
        //}


#endregion Check&ValidationMethod

#region EnterIndex

        private void SetNextFocus(string payMeth, string currentFocusControlName)
        {
            if ((payMeth == Indication_IPOPaymentTransaction.Cash || payMeth == Indication_IPOPaymentTransaction.Ecash) && (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw || ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
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
                    txt_Paypal_VoucherNo.Focus();
                }
                else if (currentFocusControlName == txt_Paypal_VoucherNo.Name)
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

            else if (payMeth == Indication_IPOPaymentTransaction.Cheque && (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw || ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
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
                    txtDepositChequeNo.Focus();
                }
                //else if (currentFocusControlName == txtDepositPaymentMedia.Name)
                //{
                //    dtRecievedDate.Focus();
                //}
                else if (currentFocusControlName == txtDepositChequeNo.Name)
                {
                    ddl_DepositCheque_BankName.Focus();
                }
                else if (currentFocusControlName == ddl_DepositCheque_BankName.Name)
                {
                    ddl_DepositCheque_BranchName.Focus();
                }
                else if (currentFocusControlName == ddl_DepositCheque_BranchName.Name)
                {
                    ddl_DepositCheque_RoutingNo.Focus();
                }
                else if (currentFocusControlName == ddl_DepositCheque_RoutingNo.Name)
                {
                    txt_DepositCheque_VoucherNo.Focus();
                }
                else if (currentFocusControlName == txt_DepositCheque_VoucherNo.Name)
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

            else if (payMeth == Indication_IPOPaymentTransaction.Cheque_Return && (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw || ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == btnDWReturnInfo.Name)
                {
                    txt_DepositCheque_VoucherNo.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txt_DepositCheque_VoucherNo.Focus();
                }
                else if (currentFocusControlName == txt_DepositCheque_VoucherNo.Name)
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

            else if (payMeth == Indication_IPOPaymentTransaction.EFT && (ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw))
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
            else if (payMeth == Indication_IPOPaymentTransaction.EFT_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw)
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == btnDWReturnInfo.Name)
                {
                    txt_EftWithdraw_VoucherNo.Focus();
                }

                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txt_EftWithdraw_VoucherNo.Focus();
                }
                else if (currentFocusControlName == txt_EftWithdraw_VoucherNo.Name)
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

            else if (payMeth == Indication_IPOPaymentTransaction.EFT && (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit))
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
                    ddl_DepositEft_Bank_Name.Focus();
                }
                else if (currentFocusControlName == ddl_DepositEft_Bank_Name.Name)
                {
                    ddl_DepositEft_Branch_Name.Focus();
                }
                else if (currentFocusControlName == ddl_DepositEft_Branch_Name.Name)
                {
                    ddl_DepositEft_RoutingNo.Focus();
                }
                else if (currentFocusControlName == ddl_DepositEft_RoutingNo.Name)
                {
                    txt_DepositEft_BankAccountNo.Focus();
                }
                //else if (currentFocusControlName == txtEftDepositBankAccNo.Name)
                //{
                //    btnEftCheckDepositAutogen.Focus();
                //}
                else if (currentFocusControlName == txt_DepositEft_BankAccountNo.Name)
                {
                    txt_DepositEft_VoucherNo.Focus();
                }
                //else if (currentFocusControlName == btnEftCheckDepositAutogen.Name)
                //{
                //    txtEftDepositVoucherNo.Focus();
                //}

                else if (currentFocusControlName == txt_DepositEft_VoucherNo.Name)
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

            else if (payMeth == Indication_IPOPaymentTransaction.EFT_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
            {
                if (currentFocusControlName == txtSearchCustomer.Name)
                {
                    ddlPaymentMedia.Focus();
                }
                if (currentFocusControlName == ddlPaymentMedia.Name)
                {
                    txt_DepositEft_VoucherNo.Focus();
                }
                if (currentFocusControlName == btnDWReturnInfo.Name)
                {
                    txt_DepositEft_VoucherNo.Focus();
                }

                else if (currentFocusControlName == txt_DepositEft_VoucherNo.Name)
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
           
            else if (payMeth == Indication_IPOPaymentTransaction.TRTA)
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
                    txt_Transfer_CustCode.Focus();
                }
                else if (currentFocusControlName == txt_Transfer_CustCode.Name)
                {
                    txt_Transfer_VoucherNo.Focus();
                }
                else if (currentFocusControlName == txt_Transfer_VoucherNo.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }

            else if (payMeth == Indication_IPOPaymentTransaction.TRIPOApp)
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
                    txt_Transfer_CustCode.Focus();
                }
                else if (currentFocusControlName == txt_Transfer_CustCode.Name)
                {
                    txt_Transfer_VoucherNo.Focus();
                }
                else if (currentFocusControlName == txt_Transfer_VoucherNo.Name)
                {
                    txtRemarks.Focus();
                }
                else if (currentFocusControlName == txtRemarks.Name)
                {
                    btnSave.Focus();
                }
            }
        }

#endregion EnterIndex

#region FormDataAccessMethod

        private void UpdateVoucherNo()
        {
            PaymentInfoBAL paymentBal = new PaymentInfoBAL();
            paymentBal.UpdateSerialNo();
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

        public void SetData()
        {

            try
            {
                ClearAll();

                //Switched On Collective Exception                
                IsCollectiveExceptionOn = true;

                IPOProcessBAL ipoBal = new IPOProcessBAL();

                //ddlDepositWithdraw.Text = frm_IPOSMSMoneyTransactionApproval.Deposit_Withdraw;

                string[] Cust_Code_Tmp = frm_IPOSMSMoneyTransactionApproval.Cust_Code;

                foreach (string tmp_Code in Cust_Code_Tmp)
                {
                    txt_ChannelID.Text = string.Empty;
                    txt_ChannelType.Text = string.Empty;

                    txtSearchCustomer.Text = tmp_Code;
                    txt_ChannelID.Text = frm_IPOSMSMoneyTransactionApproval.SMSReqID.Where(t => t.Key == tmp_Code).Select(t => t.Value).FirstOrDefault();
                    txt_ChannelType.Text = frm_IPOSMSMoneyTransactionApproval.MediaType.FirstOrDefault();

                    btnGo_Event();
                }

                Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                Set_MinimumBalance_Amount();

                string MethodName_Tmp = frm_IPOSMSMoneyTransactionApproval.Money_TransactionType_Name;
                int MethodID_Tmp = frm_IPOSMSMoneyTransactionApproval.Money_TransactionType_Name_ID;

                ddlPaymentMedia.SelectedValue = MethodID_Tmp;

                double Amount_Tmp = frm_IPOSMSMoneyTransactionApproval.Amount.Sum();

                txtAmount.Text = Convert.ToString(Amount_Tmp);

                txtAmount_Event();

                ddl_DepositCheque_RoutingNo.Text = frm_IPOSMSMoneyTransactionApproval.Routing_Number.Distinct().SingleOrDefault();
                txtDepositChequeNo.Text = frm_IPOSMSMoneyTransactionApproval.Cheque_Number.Distinct().SingleOrDefault();

                txt_Paypal_OrderNo.Text = frm_IPOSMSMoneyTransactionApproval.Cheque_Number.Distinct().SingleOrDefault();
                
                string ApplicationType = frm_IPOSMSMoneyTransactionApproval.ApplicationType.Distinct().SingleOrDefault();

                if (MethodName_Tmp == Indication_IPOPaymentTransaction.TRTA || MethodName_Tmp == Indication_IPOPaymentTransaction.TRIPO)
                {
                    string Transfer_From = frm_IPOSMSMoneyTransactionApproval.TransferCode.Distinct().First();
                    txt_Transfer_CustCode.Text = Transfer_From;
                    btnSearchTrans_Event();
                }

                if (ApplicationType.Trim() == Indication_IPOPaymentTransaction.SmsRequestType_Apply_Together.Trim())
                {
                    chk_AppliedTogather.Checked = true;
                    txtLotNO.Text = Convert.ToString(frm_IPOSMSMoneyTransactionApproval.LotNo);
                    cmb_RefundMethod.SelectedValue = frm_IPOSMSMoneyTransactionApproval.RefundType_ID;

                    if (dg_AvailableSession.Rows.Count > 0)
                    {
                        int RequestedIPOSessionID = frm_IPOSMSMoneyTransactionApproval.IPOSessionID;
                        dg_AvailableSession.Rows.Cast<DataGridViewRow>().Where(t => Convert.ToInt32(t.Cells["ID"].Value) == RequestedIPOSessionID)
                            .First().Cells["IsSelect"].Value = true;
                    }
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                IsCollectiveExceptionOn = false;
            }

        }    

        private void SaveData()
        {
            try
            {
                
                
                if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA)
                {
                    //CheckAllValidation(ddlPaymentMedia.Text);
                    CheckBankInformation();
                    
                    double doubleTryParse;

                    double chargeTest = 0.00;
                    if (double.TryParse(txt_AppCharge_Amount.Text, out doubleTryParse))
                        chargeTest = doubleTryParse;

                    string[] Cust_Code_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                    double[] Amount_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"]) - (chk_AppCharge_IsApplied.Checked?chargeTest:0.00)).ToArray();
                    string Deposit_Withdraw_IPOAcc = ddlDepositWithdraw.Text;

                    //IPO Charge Added By Md.Rashedul Hasan
                    double Doubletrypare = 0.00;
                    int intTryParse;

                    double chargeamount = 0.00;
                    string[] Deposit_Charge_Cust_Code = null;
                    string Charge_TransferCode = string.Empty;
                    string Charge_PaymentMedia = string.Empty;
                    string Charge_TransReason = string.Empty;
                    string Charge_Voucher = string.Empty;
                    int Charge_intended_Session_ID=0;
                    string Charge_Reamarks=string.Empty;

                    if (chk_AppCharge_IsApplied.Checked)
                    {
                        if (double.TryParse(txt_AppCharge_Amount.Text, out Doubletrypare))
                            chargeamount = Doubletrypare;

                        Charge_PaymentMedia = txt_AppCharge_PaymentMediaName.Text;
                        Deposit_Charge_Cust_Code = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t=> Convert.ToString(t["Cust_Code"])).ToArray();
                        Charge_TransferCode =txt_AppCharge_TransFrom.Text ;
                        Charge_TransReason = txt_AppCharge_TransReason.Text;
                        Charge_Voucher = txt_AppCharge_VoucherNo.Text;
                        Charge_intended_Session_ID=0;
                        Charge_Reamarks = txtRemarks.Text;
                    }

                    DateTime ReceivedDate=new DateTime();                    
                    ReceivedDate=dtRecievedDate.Value;
                    string VoucherNo = "";
                     
                    var temp = dg_AvailableSession.Rows.Cast<DataGridViewRow>().ToList();
                    int[] AppliedSessionID = temp
                        .Where(t=> Convert.ToBoolean(t.Cells["IsSelect"].Value))
                        .Select(c=> Convert.ToInt32(c.Cells["ID"].Value)).ToArray();
                    int AppliedSessionIDSingle = 0;
                    if(AppliedSessionID.Count()==1)
                        AppliedSessionIDSingle=AppliedSessionID[0];

                    string Cust_Code_PaymentPost=txt_Transfer_CustCode.Text;
                    double Amount_PaymentPost=0.00;
                    if(double.TryParse(txtAmount.Text,out doubleTryParse))
                        Amount_PaymentPost=doubleTryParse;
                    string Deposit_Withdraw_PaymentPost=string.Empty;
                    if(Deposit_Withdraw_IPOAcc==Indication_PaymentMode.Deposit)
                        Deposit_Withdraw_PaymentPost=Indication_PaymentMode.Withdraw;
                    else
                        Deposit_Withdraw_PaymentPost=Indication_PaymentMode.Deposit;

                   
                    int[] ChannelID = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                        .Select(t => Convert.ToInt32(t["ChannelID"])).ToArray();

                    string[] ChannelType = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                        .Select(t => Convert.ToString(t["ChannelType"])).ToArray();
                    
                    //Added By Md.Rashedul Hasan 09-01-2015
                    for (int i = 0; i < Cust_Code_IPOAcc.Length; i++)
                    {
                        CheckSameRemarksORVoucherdDeposit(Cust_Code_IPOAcc[i], Indication_IPOPaymentTransaction.TRTA, txtRemarks.Text, VoucherNo);
                    }

                    IPOProcessBAL ipoBal = new IPOProcessBAL();

                    if (Cust_Code_IPOAcc.Length > 0)
                    {
                        try
                        {
                            ipoBal.ConnectDatabase();
                            if (ipoBal.CheckLock_UITrasnApplied() == false)
                            {
                                ipoBal.Lock_UITransApplied();
                                string prefix = ipoBal.GetPrefix_UITransApplied();
                                int serial = ipoBal.GetSerial_UITransApplied();
                                VoucherNo = prefix + "" + serial;
                                // Change /Add Rezaul Islam
                                DataTable  dt = new DataTable();
                                
                                if(ChkNegativeBalanceNotCalculate.Checked == true)
                                    dt = ipoBal.Insert_Transfer_DepositMoneyTransaction_UITransApplied_Negative(Cust_Code_PaymentPost, Cust_Code_IPOAcc, Amount_PaymentPost, Amount_IPOAcc, Deposit_Withdraw_IPOAcc, Deposit_Withdraw_PaymentPost, ReceivedDate, VoucherNo, txtRemarks.Text, AppliedSessionIDSingle, ChannelID, ChannelType);
                                else
                                   dt = ipoBal.Insert_Transfer_DepositMoneyTransaction_UITransApplied(Cust_Code_PaymentPost, Cust_Code_IPOAcc, Amount_PaymentPost, Amount_IPOAcc, Deposit_Withdraw_PaymentPost, Deposit_Withdraw_IPOAcc, ReceivedDate, VoucherNo, txtRemarks.Text, AppliedSessionIDSingle, ChannelID, ChannelType);
                                //Added By Md.Rashedul Hasan
                                if (chk_AppCharge_IsApplied.Checked)
                                    ipoBal.Insert_IPO_Application_Charge(Deposit_Charge_Cust_Code, chargeamount, Charge_PaymentMedia, Charge_TransferCode, VoucherNo, Charge_TransReason, Charge_intended_Session_ID, Charge_Reamarks);
                                
                                /////////////////////////
                                if (chk_AppliedTogather.Checked)
                                {
                                    string Refund_Referencial = string.Empty;
                                    if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRPRIPO_Desc)
                                        Refund_Referencial = txt_Cust_Code_ForTransferParent.Text;
                                    int RefundID = Convert.ToInt32(cmb_RefundMethod.SelectedValue);

                                    ipoBal.Updated_IPO_Affected_Account_UITransApplied(Cust_Code_IPOAcc, ChkAffected.Checked);
                                    ipoBal.Insert_ApplyApplication_MoneyTransaction_UITransApplied(AppliedSessionID, Cust_Code_IPOAcc, RefundID, Refund_Referencial, dt, Convert.ToInt32(txtLotNO.Text), new string[] { }, new string[] { },ChannelID,ChannelType);

                                }
                                ipoBal.UpdateVoucherNo_UITransApplied(serial + 1);
                                ipoBal.UnLock_UITransApplied();
                            }
                            else
                            {
                                throw new Exception("Auto Voucher System Busy Please Try Later!!");
                            }

                            ipoBal.Commit();
                        }
                        catch (Exception ex)
                        {
                            ipoBal.UnLock_UITransApplied();
                            ipoBal.RollBack();
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            ipoBal.CloseDatabase();
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid Child Or parent code found, Check Your parent and child code" + MessageBoxIcon.Error);
                    } 
                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO)
                {
                    CheckAllValidation(ddlPaymentMedia.Text);
                    IPOProcessBAL bal = new IPOProcessBAL();

                    double doubleTryParse;
                    double chargeTest = 0.00;
                    if (double.TryParse(txt_AppCharge_Amount.Text, out doubleTryParse))
                        chargeTest = doubleTryParse;
                    //Above DtCustList IPO Account Casting
                    string[] Cust_Code_IPoAcc_dtCustList = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t=>Convert.ToString(t["Cust_Code"])).ToArray();
                    //double[] Amount_IPOAcc_dtCustList = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"])).ToArray();
                    double[] Amount_IPOAcc_dtCustList = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"]) - (chk_AppCharge_IsApplied.Checked ? chargeTest : 0.00)).ToArray();
                    string Deposit_Withdraw_IPOAcc_dtCustList = ddlDepositWithdraw.Text;

                    //IPO Charge Added By Md.Rashedul Hasan
                    double Doubletrypare = 0.00;
                    int intTryParse;

                    double chargeamount = 0.00;
                    string[] Deposit_Charge_Cust_Code = null;
                    string Charge_TransferCode = string.Empty;
                    string Charge_PaymentMedia = string.Empty;
                    string Charge_TransReason = string.Empty;
                    string Charge_Voucher = string.Empty;
                    int Charge_intended_Session_ID = 0;
                    string Charge_Reamarks = string.Empty;

                    if (chk_AppCharge_IsApplied.Checked)
                    {
                        if (double.TryParse(txt_AppCharge_Amount.Text, out Doubletrypare))
                            chargeamount = Doubletrypare;

                        Charge_PaymentMedia = txt_AppCharge_PaymentMediaName.Text;
                        Deposit_Charge_Cust_Code = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                        Charge_TransferCode = txt_AppCharge_TransFrom.Text;
                        Charge_TransReason = txt_AppCharge_TransReason.Text;
                        Charge_Voucher = txt_AppCharge_VoucherNo.Text;
                        Charge_intended_Session_ID = 0;
                        Charge_Reamarks = txtRemarks.Text;
                    }
                    
                    //TransCode IPO Account Casting
                    string Cust_Code_IPoAcc_TransCode = txt_Transfer_CustCode.Text;
                    double Amount_TransCode = 0.00;
                   
                    if (double.TryParse(txtAmount.Text, out doubleTryParse))
                        Amount_TransCode = doubleTryParse;
                    string Deposit_Withdraw_TransCode = string.Empty;
                    if (Deposit_Withdraw_IPOAcc_dtCustList == Indication_PaymentMode.Deposit)
                        Deposit_Withdraw_TransCode = Indication_PaymentMode.Withdraw;
                    else
                        Deposit_Withdraw_TransCode = Indication_PaymentMode.Deposit;

                    
                    DateTime ReceivedDate = new DateTime();
                    ReceivedDate = dtRecievedDate.Value;
                    string VoucherNo = "";

                    var temp = dg_AvailableSession.Rows.Cast<DataGridViewRow>().ToList();
                    int[] AppliedSessionID = temp
                        .Where(t => Convert.ToBoolean(t.Cells["IsSelect"].Value))
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).ToArray();
                    int AppliedSessionIDSingle = 0;
                    if (AppliedSessionID.Count() == 1)
                        AppliedSessionIDSingle = AppliedSessionID[0];

                    string Cust_Code_PaymentPost = txt_Transfer_CustCode.Text;
                    double Amount_PaymentPost = 0.00;
                     
                    if (double.TryParse(txtAmount.Text, out doubleTryParse))
                        Amount_PaymentPost = doubleTryParse;
                    string Deposit_Withdraw_PaymentPost = string.Empty;
                    if (Deposit_Withdraw_IPOAcc_dtCustList == Indication_PaymentMode.Deposit)
                        Deposit_Withdraw_PaymentPost = Indication_PaymentMode.Withdraw;
                    else
                        Deposit_Withdraw_PaymentPost = Indication_PaymentMode.Deposit;

                    int[] ChannelID = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                       .Select(t => Convert.ToInt32(t["ChannelID"])).ToArray();

                    string[] ChannelType = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                        .Select(t => Convert.ToString(t["ChannelType"])).ToArray();

                    //Added By Md.Rashedul Hasan 09-01-2015
                    for (int i = 0; i < Cust_Code_IPoAcc_dtCustList.Length; i++)
                    {
                        CheckSameRemarksORVoucherdDeposit(Cust_Code_IPoAcc_dtCustList[i], Indication_IPOPaymentTransaction.TRIPO, txtRemarks.Text, VoucherNo);
                    }

                    IPOProcessBAL ipoBal = new IPOProcessBAL();

                    if (Cust_Code_IPoAcc_dtCustList.Length > 0)
                    {
                        try
                        {
                            ipoBal.ConnectDatabase();
                            if (ipoBal.CheckLock_UITrasnApplied() == false)
                            {
                                ipoBal.Lock_UITransApplied();
                                string prefix = ipoBal.GetPrefix_UITransApplied();
                                int serial = ipoBal.GetSerial_UITransApplied();
                                VoucherNo = prefix + "" + serial;                                
                                DataTable dt = ipoBal.Insert_Transfer_IPO_To_IPO_DepositMoneyTransaction_UITransApplied(Cust_Code_IPoAcc_TransCode, Cust_Code_IPoAcc_dtCustList, Amount_TransCode, Amount_IPOAcc_dtCustList, Deposit_Withdraw_TransCode, Deposit_Withdraw_IPOAcc_dtCustList, ReceivedDate, VoucherNo, txtRemarks.Text, AppliedSessionIDSingle, Charge_For_IPO_Application,ChannelID,ChannelType);
                                
                                if (chk_AppCharge_IsApplied.Checked)
                                    ipoBal.Insert_IPO_Application_Charge(Deposit_Charge_Cust_Code, chargeamount, Charge_PaymentMedia, Charge_TransferCode, VoucherNo, Charge_TransReason, Charge_intended_Session_ID, Charge_Reamarks);
                                if (chk_AppliedTogather.Checked)
                                {
                                    string Refund_Referencial = string.Empty;
                                    if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRPRIPO_Desc)
                                        Refund_Referencial = txt_Cust_Code_ForTransferParent.Text;
                                    int RefundID = Convert.ToInt32(cmb_RefundMethod.SelectedValue);

                                    ipoBal.Updated_IPO_Affected_Account_UITransApplied(Cust_Code_IPoAcc_dtCustList, ChkAffected.Checked);
                                    ipoBal.Insert_ApplyApplication_MoneyTransaction_UITransApplied(AppliedSessionID, Cust_Code_IPoAcc_dtCustList, RefundID, Refund_Referencial, dt, Convert.ToInt32(txtLotNO.Text), new string[] { }, new string[] { },ChannelID,ChannelType);

                                }
                                ipoBal.UpdateVoucherNo_UITransApplied(serial + 1);
                                ipoBal.UnLock_UITransApplied();
                            }
                            

                            ipoBal.Commit();
                        }
                        catch (Exception ex)
                        {
                            ipoBal.UnLock_UITransApplied();
                            ipoBal.RollBack();
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            ipoBal.CloseDatabase();
                        }
                    
                    }
                    else
                    {
                        throw new Exception("Invalid Child Or parent code found, Check Your parent and child code" + MessageBoxIcon.Error);

                    } 


                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cash || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Ecash)
                {
                    CheckAllValidation(ddlPaymentMedia.Text);
                    CheckBankInformation();

                    IPOProcessBAL ipoBal = new IPOProcessBAL();
                    ipoBal.SBPModuleName = this.Text;
                    string[] Cust_Code_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                    double[] Amount_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"])).ToArray();
                    string Deposit_Withdraw_IPOAcc = ddlDepositWithdraw.Text;
                    DateTime ReceivedDate = new DateTime();
                    ReceivedDate = dtRecievedDate.Value;
                    int PaymentMethodID = Convert.ToInt32(ddlPaymentMedia.SelectedValue);
                    string PaymentMethod = ddlPaymentMedia.Text;
                    int BankID = Convert.ToInt32(ddl_DepositCheque_BankName.SelectedValue);
                    int BranchID = Convert.ToInt32(ddl_DepositCheque_BranchName.SelectedValue);
                    string BankName = ddl_DepositCheque_BankName.SelectedText;
                    string BranchName = ddl_DepositCheque_BranchName.SelectedText;
                    string RoutingNo = Convert.ToString(ddl_DepositCheque_RoutingNo.SelectedValue);
                    string BankAccNo = txt_EftWithdraw_BankAccNo.Text;
                    string VoucherNo = txt_Paypal_VoucherNo.Text;
                    string ChequeNo = txtDepositChequeNo.Text;
                    
                    DateTime ChequeDate = dtp_DepositChequeDate.Value;
                    var temp = dg_AvailableSession.Rows.Cast<DataGridViewRow>().ToList();
                    int[] AppliedSessionID = temp
                        .Where(t => Convert.ToBoolean(t.Cells["IsSelect"].Value))
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).ToArray();
                    int AppliedSessionIDSingle = 0;
                    if (AppliedSessionID.Count() == 1)
                        AppliedSessionIDSingle = AppliedSessionID[0];

                    int[] ChannelID = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                       .Select(t => Convert.ToInt32(t["ChannelID"])).ToArray();

                    string[] ChannelType = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                        .Select(t => Convert.ToString(t["ChannelType"])).ToArray();

                    //Added By Md.Rashedul Hasan 09-01-2015
                    for (int i = 0; i < Cust_Code_IPOAcc.Length; i++)
                    {
                        if (PaymentMethod == Indication_IPOPaymentTransaction.Cash)
                        {
                            CheckSameRemarksORVoucherdDeposit(Cust_Code_IPOAcc[i], Indication_IPOPaymentTransaction.Cash, txtRemarks.Text, VoucherNo);
                        }
                        else if (PaymentMethod == Indication_IPOPaymentTransaction.Ecash)
                        {
                            CheckSameRemarksORVoucherdDeposit(Cust_Code_IPOAcc[i], Indication_IPOPaymentTransaction.Ecash, txtRemarks.Text, VoucherNo);
                        }
                    }

                    try
                    {
                        ipoBal.ConnectDatabase();
                        DataTable dt = ipoBal.Insert_NonTransfer_MoneyTransaction_UITransApplied(Cust_Code_IPOAcc, Amount_IPOAcc, Deposit_Withdraw_IPOAcc, ReceivedDate, PaymentMethodID, PaymentMethod, VoucherNo, string.Empty, txtRemarks.Text, AppliedSessionIDSingle, ChannelID, ChannelType);
                        //DataTable dt = ipoBal.Insert_NonTransfer_WithTransDetails_MoneyTransaction_UITransApplied(Cust_Code_IPOAcc, Amount_IPOAcc, Deposit_Withdraw_IPOAcc, ReceivedDate, PaymentMethodID, PaymentMethod, txtDepositPaymentMedia.Text, dtDepositPaymentMediaDate.Value, BankID, BankName, BranchID, BranchName, RoutingNo, BankAccNo, VoucherNo, AppliedSessionIDSingle);
                       
                        if (chk_AppliedTogather.Checked)
                        {
                            string Refund_Referencial = string.Empty;
                            if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRPRIPO_Desc)
                                Refund_Referencial = txt_Cust_Code_ForTransferParent.Text;
                            int RefundID = Convert.ToInt32(cmb_RefundMethod.SelectedValue);
                            ipoBal.Updated_IPO_Affected_Account_UITransApplied(Cust_Code_IPOAcc, ChkAffected.Checked);
                            ipoBal.Insert_ApplyApplication_MoneyTransaction_UITransApplied(AppliedSessionID, Cust_Code_IPOAcc, RefundID, Refund_Referencial, dt, Convert.ToInt32(txtLotNO.Text), new string[] { }, new string[] { },new int[]{},new string[]{});
                        }
                        ipoBal.Commit();
                    }
                    catch (Exception ex)
                    {
                        ipoBal.RollBack();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        ipoBal.CloseDatabase();
                    }
                }
                
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && ddlDepositWithdraw.Text==Indication_PaymentMode.Deposit)
                {
                    CheckAllValidation(ddlPaymentMedia.Text);
                    CheckBankInformation();
                    string[] Cust_Code_IPOAcc=null;
                    double[] Amount_IPOAcc=null;
                    string Cust_Code_TrnCharged=string.Empty;
                    double Amount_Trn_Charged=0;

                    var Checekd_Cust_Code=dg_Customers.Rows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToBoolean(t.Cells["IsChargable"].Value) == true)
                           .Select(t=> Convert.ToString(t.Cells["Cust_Code"].Value)).FirstOrDefault();
                    
                    IPOProcessBAL ipoBal = new IPOProcessBAL();
                    //if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && txt_TransChrg_ChargedCustCode.Text == string.Empty && Checekd_Cust_Code != null )
                    //{
                    //    List<string> CodeIPOAcc_Temp_List = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToList();
                    //    List<double> AmountIPOAcc_Temp_List = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"])).ToList();
                        
                    //    string[] Cust_CodeTemp=CodeIPOAcc_Temp_List.ToArray();
                    //    for (int i = 0; i < Cust_CodeTemp.Length; i++)
                    //    {
                    //        if (Cust_CodeTemp[i] == Checekd_Cust_Code)
                    //        {
                    //            Amount_Trn_Charged = AmountIPOAcc_Temp_List[i];
                    //            Cust_Code_TrnCharged = Checekd_Cust_Code;

                    //            CodeIPOAcc_Temp_List.RemoveAt(i);
                    //            AmountIPOAcc_Temp_List.RemoveAt(i);
                    //        }
                    //    }
                        
                    //    Cust_Code_IPOAcc = CodeIPOAcc_Temp_List.ToArray();
                    //    Amount_IPOAcc = AmountIPOAcc_Temp_List.ToArray();
                    //}
                    //else 
                    if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && txt_TransChrg_ChargedCustCode.Text != string.Empty && Checekd_Cust_Code != null && (txt_TransChrg_RefNo.Text == Indication_IPOPaymentTransaction.Cash || txt_TransChrg_RefNo.Text == Indication_IPOPaymentTransaction.Cheque)) 
                    {
                        List<string> CodeIPOAcc_Temp_List = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToList();
                        List<double> AmountIPOAcc_Temp_List = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"])).ToList();
                        
                        string[] Cust_CodeTemp=CodeIPOAcc_Temp_List.ToArray();
                        for (int i = 0; i < Cust_CodeTemp.Length; i++)
                        {
                            if (Cust_CodeTemp[i] == txt_TransChrg_ChargedCustCode.Text)
                            {
                                Amount_Trn_Charged = AmountIPOAcc_Temp_List[i] - Convert.ToDouble(txt_TranChrg_ChagedAmount.Text);
                                Cust_Code_TrnCharged=txt_TransChrg_ChargedCustCode.Text;
                                
                                CodeIPOAcc_Temp_List.RemoveAt(i);
                                AmountIPOAcc_Temp_List.RemoveAt(i);
                            }
                        }
                        
                        Cust_Code_IPOAcc = CodeIPOAcc_Temp_List.ToArray();
                        Amount_IPOAcc = AmountIPOAcc_Temp_List.ToArray();                            
                    }
                    
                    string Deposit_Withdraw_IPOAcc = ddlDepositWithdraw.Text;
                    DateTime ReceivedDate = new DateTime();
                    ReceivedDate = dtRecievedDate.Value;
                    int PaymentMethodID = Convert.ToInt32(ddlPaymentMedia.SelectedValue);
                    string PaymentMethod = ddlPaymentMedia.Text;
                    int BankID = Convert.ToInt32(ddl_DepositCheque_BankName.SelectedValue);
                    int BranchID = Convert.ToInt32(ddl_DepositCheque_BranchName.SelectedValue);
                    string BankName = ddl_DepositCheque_BankName.Text;
                    string BranchName = ddl_DepositCheque_BranchName.Text;
                    string RoutingNo = Convert.ToString(ddl_DepositCheque_RoutingNo.SelectedValue);
                    string BankAccNo=string.Empty;
                    string VoucherNo = txt_DepositCheque_VoucherNo.Text;
                    string ChequeNo=txtDepositChequeNo.Text;  
                    DateTime ChequeDate=dtp_DepositChequeDate.Value;
                    
                    var temp = dg_AvailableSession.Rows.Cast<DataGridViewRow>().ToList();
                    int[] AppliedSessionID = temp
                        .Where(t => Convert.ToBoolean(t.Cells["IsSelect"].Value))
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).ToArray();
                    int AppliedSessionIDSingle = 0;
                    if (AppliedSessionID.Count() == 1)
                        AppliedSessionIDSingle = AppliedSessionID[0];

                    int[] ChannelID = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                      .Select(t => Convert.ToInt32(t["ChannelID"])).ToArray();

                    string[] ChannelType = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                        .Select(t => Convert.ToString(t["ChannelType"])).ToArray();

                   

                    //Added By Md.Rashedul Hasan 09-01-2015
                    for (int i = 0; i < Cust_Code_IPOAcc.Length; i++)
                    {
                        CheckSameRemarksORVoucherdDeposit(Cust_Code_IPOAcc[i], Indication_IPOPaymentTransaction.Cheque, txtRemarks.Text, VoucherNo);
                    }

                    try
                    {
                        ipoBal.ConnectDatabase();
                                               
                        DataTable dt= ipoBal.Insert_NonTransfer_WithTransDetails_MoneyTransaction_UITransApplied(Cust_Code_IPOAcc, Amount_IPOAcc, Deposit_Withdraw_IPOAcc, ReceivedDate, PaymentMethodID, PaymentMethod, txtDepositChequeNo.Text, dtp_DepositChequeDate.Value, BankID, BankName, BranchID, BranchName, RoutingNo, BankAccNo, VoucherNo,string.Empty,txtRemarks.Text, AppliedSessionIDSingle,ChannelID,ChannelType);
                        string TransReason=Indication_TransactioBasedCharge.GroupEntry_ChargedAccount_TransReason;
                        DataTable dt_ChargeAccount = ipoBal.Insert_NonTransfer_WithTransDetails_MoneyTransaction_UITransApplied(new string[] { Cust_Code_TrnCharged }, new double[] { Amount_Trn_Charged }, Deposit_Withdraw_IPOAcc, ReceivedDate, PaymentMethodID, PaymentMethod, txtDepositChequeNo.Text, dtp_DepositChequeDate.Value, BankID, BankName, BranchID, BranchName, RoutingNo, BankAccNo, VoucherNo, TransReason, txtRemarks.Text, AppliedSessionIDSingle,new int[]{},new string[]{} );

                        if (chk_AppliedTogather.Checked)
                        {
                            string Refund_Referencial = string.Empty;
                            if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRPRIPO_Desc)
                                Refund_Referencial = txt_Cust_Code_ForTransferParent.Text;
                            int RefundID = Convert.ToInt32(cmb_RefundMethod.SelectedValue);

                            ipoBal.Updated_IPO_Affected_Account_UITransApplied(Cust_Code_IPOAcc, ChkAffected.Checked);
                            ipoBal.Updated_IPO_Affected_Account_UITransApplied(new string[] { Cust_Code_TrnCharged }, ChkAffected.Checked);

                            ipoBal.Insert_ApplyApplication_MoneyTransaction_UITransApplied(AppliedSessionID, Cust_Code_IPOAcc, RefundID, Refund_Referencial, dt, Convert.ToInt32(txtLotNO.Text), new string[] { }, new string[] { },new int[]{},new string[]{});
                            ipoBal.Insert_ApplyApplication_MoneyTransaction_UITransApplied(AppliedSessionID, new string[] { Cust_Code_TrnCharged }, RefundID, Refund_Referencial, dt_ChargeAccount, Convert.ToInt32(txtLotNO.Text), new string[] { }, new string[] { }, new int[] { }, new string[] { });
                            
                        }

                        if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && txt_TransChrg_ChargedCustCode.Text != string.Empty && Convert.ToDouble(txt_TranChrg_ChagedAmount.Text) > 0 && txt_TransChrg_RefNo.Text == Indication_IPOPaymentTransaction.Cash)
                        {
                            string voucherTemp = txt_TransChrg_VoucherNo.Text;
                            string[] chargedCodeTemp = new string[]{txt_TransChrg_ChargedCustCode.Text};
                            string remarksTemp = txt_TransChrg_Remarks.Text;
                            DateTime receivedDateTemp = dtp_TransChrg_ReceivedDate.Value;
                            double[] amountTemp = new double[]{Convert.ToDouble(txt_TranChrg_ChagedAmount.Text)};
                            string transReason = txt_TransChrg_TransReason.Text;
                            var ParentTransID = dt_ChargeAccount.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Cust_Code"]) == chargedCodeTemp[0]).Select(t => Convert.ToInt32(t["Last_Scope_Id"])).FirstOrDefault();
                            if (ParentTransID!=null)
                                ipoBal.Insert_NonTransfer_MoneyTransaction_UITransApplied(chargedCodeTemp, amountTemp, Indication_PaymentMode.Deposit, receivedDateTemp, Indication_IPOPaymentTransaction.Cash_ID , Indication_IPOPaymentTransaction.Cash, VoucherNo, transReason + "_" + Convert.ToString(ParentTransID),txtRemarks.Text, AppliedSessionIDSingle,ChannelID,ChannelType);
                        }
                        ipoBal.Commit();

                    }
                    catch (Exception ex)
                    {
                        ipoBal.RollBack();
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        ipoBal.CloseDatabase();
                    }
                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
                {
                        CheckAllValidation(ddlPaymentMedia.Text);
                        CheckBankInformation();
                        IPOProcessBAL ipoBal = new IPOProcessBAL();
                        double doubleTryParse;
                        
                        double chargeTest = 0.00;
                        if (double.TryParse(txt_AppCharge_Amount.Text, out doubleTryParse))
                            chargeTest = doubleTryParse;
                        
                        string[] Cust_Code_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                        //double[] Amount_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"])).ToArray();
                        double[] Amount_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"]) - (chk_AppCharge_IsApplied.Checked ? chargeTest : 0.00)).ToArray();
                        string Deposit_Withdraw_IPOAcc = ddlDepositWithdraw.Text;
                        DateTime ReceivedDate = new DateTime();
                        ReceivedDate = dtRecievedDate.Value;
                        int PaymentMethodID = Convert.ToInt32(ddlPaymentMedia.SelectedValue);
                        string PaymentMethod = ddlPaymentMedia.Text;
                       

                        //IPO Charge Added By Md.Rashedul Hasan
                        double Doubletrypare = 0.00;
                        int intTryParse;

                        double chargeamount = 0.00;
                        string[] Deposit_Charge_Cust_Code = null;
                        string Charge_TransferCode = string.Empty;
                        string Charge_PaymentMedia = string.Empty;
                        string Charge_TransReason = string.Empty;
                        string Charge_Voucher = string.Empty;
                        int Charge_intended_Session_ID = 0;
                        string Charge_Reamarks = string.Empty;

                        int[] ChannelID = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                            //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                      .Select(t => Convert.ToInt32(t["ChannelID"])).ToArray();

                        string[] ChannelType = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                            //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                            .Select(t => Convert.ToString(t["ChannelType"])).ToArray();

                        if (chk_AppCharge_IsApplied.Checked)
                        {
                            if (double.TryParse(txt_AppCharge_Amount.Text, out Doubletrypare))
                                chargeamount = Doubletrypare;

                            Charge_PaymentMedia = txt_AppCharge_PaymentMediaName.Text;
                            Deposit_Charge_Cust_Code = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                            Charge_TransferCode = txt_AppCharge_TransFrom.Text;
                            Charge_TransReason = txt_AppCharge_TransReason.Text;
                            Charge_Voucher = txt_AppCharge_VoucherNo.Text;
                            Charge_intended_Session_ID = 0;
                            Charge_Reamarks = txtRemarks.Text;
                        }

                        //////////////////////////////////////

                        string VoucherNo = txt_DepositEft_VoucherNo.Text;
                        var temp = dg_AvailableSession.Rows.Cast<DataGridViewRow>().ToList();
                        int[] AppliedSessionID = temp
                            .Where(t => Convert.ToBoolean(t.Cells["IsSelect"].Value))
                            .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).ToArray();
                        int AppliedSessionIDSingle = 0;
                        if (AppliedSessionID.Count() == 1)
                            AppliedSessionIDSingle = AppliedSessionID[0];
                       
                        //Added By Md.Rashedul Hasan 09-01-2015
                        for (int i = 0; i < Cust_Code_IPOAcc.Length; i++)
                        {
                            CheckSameRemarksORVoucherdDeposit(Cust_Code_IPOAcc[i], Indication_IPOPaymentTransaction.EFT, txtRemarks.Text, VoucherNo);
                        }

                        try
                        {
                            ipoBal.ConnectDatabase();

                            DataTable dt = ipoBal.Insert_NonTransfer_MoneyTransaction_UITransApplied(Cust_Code_IPOAcc, Amount_IPOAcc, Deposit_Withdraw_IPOAcc, ReceivedDate, PaymentMethodID, PaymentMethod, VoucherNo, string.Empty, txtRemarks.Text, AppliedSessionIDSingle,ChannelID,ChannelType);
                            //DataTable dt = ipoBal.Insert_NonTransfer_WithTransDetails_MoneyTransaction_UITransApplied(Cust_Code_IPOAcc, Amount_IPOAcc, Deposit_Withdraw_IPOAcc, ReceivedDate, PaymentMethodID, PaymentMethod, txtDepositChequeNo.Text, dtp_DepositChequeDate.Value, BankID, BankName, BranchID, BranchName, RoutingNo, BankAccNo, VoucherNo,string.Empty,txtRemarks.Text, AppliedSessionIDSingle);
                            
                            //Added By Md.Rashedul Hasan
                            if (chk_AppCharge_IsApplied.Checked)
                                ipoBal.Insert_IPO_Application_Charge(Deposit_Charge_Cust_Code, chargeamount, Charge_PaymentMedia, Charge_TransferCode, Charge_Voucher, Charge_TransReason, Charge_intended_Session_ID, Charge_Reamarks);


                            /////////////////////////

                            if (chk_AppliedTogather.Checked)
                            {
                                string Refund_Referencial = string.Empty;
                                if (cmb_RefundMethod.Text == Indication_IPORefundType.Refund_TRPRIPO_Desc)
                                    Refund_Referencial = txt_Cust_Code_ForTransferParent.Text;
                                int RefundID = Convert.ToInt32(cmb_RefundMethod.SelectedValue);
                                
                                ipoBal.Updated_IPO_Affected_Account_UITransApplied(Cust_Code_IPOAcc, ChkAffected.Checked);
                                ipoBal.Insert_ApplyApplication_MoneyTransaction_UITransApplied(AppliedSessionID, Cust_Code_IPOAcc, RefundID, Refund_Referencial, dt, Convert.ToInt32(txtLotNO.Text), new string[] { }, new string[] { },new int[]{},new string[]{});
                            }
                            ipoBal.Commit();
                        }
                        catch (Exception ex)
                        {
                            ipoBal.RollBack();
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            ipoBal.CloseDatabase();
                        }
                    

                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
                {
                    CheckAllValidation(ddlPaymentMedia.Text);
                    //CheckBankInformation();

                    IPOProcessBAL ipoBal = new IPOProcessBAL();
                    ipoBal.SBPModuleName = this.Text;
                    string[] Cust_Code_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                    double Amount_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"])).FirstOrDefault();
                    string Deposit_Withdraw_IPOAcc = ddlDepositWithdraw.Text;
                    DateTime ReceivedDate = new DateTime();
                    ReceivedDate = dtpSearchPaymentEntry.Value;
                    int PaymentMethodID = Convert.ToInt32(ddlPaymentMedia.SelectedValue);
                    string PaymentMethod = ddlPaymentMedia.Text;
                    //string VoucherNo = "";
                    string VoucherNo = txt_DepositEft_VoucherNo.Text;
                    //TransID = frm_IPOEFTReturn.ID;
                    //Added By Md.Rashedul Hasan 09-01-2015
                    for (int i = 0; i < Cust_Code_IPOAcc.Length; i++)
                    {
                        CheckSameRemarksORVoucherdDeposit(Cust_Code_IPOAcc[i], Indication_IPOPaymentTransaction.EFT_Return, txtRemarks.Text, VoucherNo);
                    }

                    try
                    {
                        string cust_code=string.Join(",", Cust_Code_IPOAcc);
                        ipoBal.ConnectDatabase();
                        
                            ipoBal.InsertIPO_EFT_Return(TransID, cust_code, Amount_IPOAcc, ReceivedDate, txtRemarks.Text, VoucherNo);
                            
                        ipoBal.Commit();
                    }
                    catch (Exception ex)
                    {
                        ipoBal.RollBack();
                        throw new Exception(ex.Message);
                        
                    }
                    
                    finally
                    {
                        ipoBal.CloseDatabase();
                    }
                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == Indication_PaymentMode.Withdraw)
                {
                    CheckAllValidation(ddlPaymentMedia.Text);
                    CheckBankInformation();
                    IPOProcessBAL ipoBal = new IPOProcessBAL();
                    string[] Cust_Code_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                    double[] Amount_IPOAcc = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToDouble(t["Distributed_Amount"])).ToArray();
                    string Deposit_Withdraw_IPOAcc = ddlDepositWithdraw.Text;
                    DateTime ReceivedDate = new DateTime();
                    ReceivedDate = dtRecievedDate.Value;
                    int PaymentMethodID = Convert.ToInt32(ddlPaymentMedia.SelectedValue);
                    string PaymentMethod = ddlPaymentMedia.Text;
                    //int BankID = Convert.ToInt32(txtEFTBankID.Text);
                    //int BranchID = Convert.ToInt32(txtEFTBranchID.Text);
                    //string BankName = txt_EftWithdraw_BankName.Text;
                    //string BranchName = txt_EftWithdraw_BranchName.Text;
                    //string RoutingNo = Convert.ToString(txt_EftWithdraw_RoutingNo.Text);
                    //string BankAccNo = txt_EftWithdraw_BankAccNo.Text;
                    int BankID = Convert.ToInt32(dgvEFTbankInfo.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToInt32(c.Cells["BankID"].Value)).FirstOrDefault());
                    int BranchID = Convert.ToInt32(dgvEFTbankInfo.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToInt32(c.Cells["BranchID"].Value)).FirstOrDefault());
                    string BankName = dgvEFTbankInfo.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["BankName"].Value)).FirstOrDefault();
                    string BranchName = dgvEFTbankInfo.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["BranchName"].Value)).FirstOrDefault();
                    string RoutingNo = dgvEFTbankInfo.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["RoutingNo"].Value)).FirstOrDefault();
                    string BankAccNo = dgvEFTbankInfo.SelectedRows.Cast<DataGridViewRow>().Select(c => Convert.ToString(c.Cells["BankAccNo"].Value)).FirstOrDefault();
                    //string VoucherNo = txt_EftWithdraw_VoucherNo.Text;
                    string VoucherNo = "";
                    var temp = dg_AvailableSession.Rows.Cast<DataGridViewRow>().ToList();
                    int[] AppliedSessionID = temp
                        .Where(t => Convert.ToBoolean(t.Cells["IsSelect"].Value))
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).ToArray();
                    int AppliedSessionIDSingle = 0;
                    if (AppliedSessionID.Count() == 1)
                        AppliedSessionIDSingle = AppliedSessionID[0];

                    int[] ChannelID = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                      .Select(t => Convert.ToInt32(t["ChannelID"])).ToArray();

                    string[] ChannelType = dt_CustList_IPOPayment.Rows.Cast<DataRow>()
                        //.Where(t=> Convert.ToString(t["ChannelType"])==Indication_IPOPaymentTransaction.ChannelType_SMS)
                        .Select(t => Convert.ToString(t["ChannelType"])).ToArray();


                    //Added By Md.Rashedul Hasan 09-01-2015
                    for (int i = 0; i < Cust_Code_IPOAcc.Length; i++)
                    {
                        CheckSameRemarksORVoucherdDeposit(Cust_Code_IPOAcc[i], Indication_IPOPaymentTransaction.EFT, txtRemarks.Text, VoucherNo);
                    }

                    try
                    {
                        ipoBal.ConnectDatabase();
                        if (ipoBal.CheckLock_UiTransAppliedFor_EFT() == false)
                        {
                            ipoBal.Lock_UITransApplied_EFT();
                            string prefix = ipoBal.GetPrefix_UITransApplied_EFT();
                            int serial = ipoBal.GetSerial_UITransApplied_EFT();
                            VoucherNo = prefix + "" + serial;
                            //DataTable dt = ipoBal.Insert_NonTransfer_WithTransDetails_MoneyTransaction(Cust_Code_IPOAcc, Amount_IPOAcc, Deposit_Withdraw_IPOAcc, ReceivedDate, PaymentMethodID, PaymentMethod, txtDepositChequeNo.Text, dtp_DepositChequeDate.Value, BankID, BankName, BranchID, BranchName, RoutingNo, BankAccNo, VoucherNo, string.Empty, txtRemarks.Text, AppliedSessionIDSingle);
                            ipoBal.Insert_NonTransfer_WithTransDetails_MoneyTransaction_UITransApplied(Cust_Code_IPOAcc, Amount_IPOAcc, Deposit_Withdraw_IPOAcc, ReceivedDate, PaymentMethodID, PaymentMethod, txtDepositChequeNo.Text, dtp_DepositChequeDate.Value, BankID, BankName, BranchID, BranchName, RoutingNo, BankAccNo, VoucherNo, string.Empty, txtRemarks.Text, AppliedSessionIDSingle,ChannelID,ChannelType);
                            ipoBal.UpdateVoucherNo_UITransApplied_EFT(serial + 1);
                            ipoBal.UnLock_UITransApplied_EFT();
                        }
                        else
                        {
                            throw new Exception("System Busy Please waint some time");
                        }
                        ipoBal.Commit();
                        //if (chk_AppliedTogather.Checked)
                        //{
                        //    int RefundID = Convert.ToInt32(cmb_RefundMethod.SelectedValue);
                        //    ipoBal.Insert_ApplyApplication_MoneyTransaction(AppliedSessionID, Cust_Code_IPOAcc, RefundID);
                        //}
                    }
                    catch (Exception ex)
                    {
                        ipoBal.UnLock_UITransApplied_EFT();
                        ipoBal.RollBack();
                        throw new Exception(ex.Message);

                    }

                    //if (chk_AppliedTogather.Checked)
                    //{
                    //    int RefundID = Convert.ToInt32(cmb_RefundMethod.SelectedValue);
                    //    ipoBal.Insert_ApplyApplication_MoneyTransaction(AppliedSessionID, Cust_Code_IPOAcc, RefundID);
                    //}

                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque_Return && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
                {
                    IPOProcessBAL bal = new IPOProcessBAL();
                    //bal.Insert_Return_NonTransfer_MoneyTransaction();
                    string Deposit_Withdraw = Indication_PaymentMode.Withdraw;
                    List<double> amountList=new List<double>();
                    List<string> transReasonList = new List<string>();
                    string payment_Method = Indication_IPOPaymentTransaction.Cheque_Return;

                    
                    string[] Cust_Code = dg_Customers.Rows.Cast<DataGridViewRow>().Select(T => Convert.ToString(T.Cells["Cust_Code"].Value)).ToArray();
                    foreach (string code in Cust_Code)
                    {
                        double amount_Temp = dg_Customers.Rows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["Cust_Code"].Value) == code)
                            .Select(t => Convert.ToDouble(t.Cells["Distributed_Amount"].Value)).FirstOrDefault();
                        amountList.Add(amount_Temp);

                        string trans_Reason_Temp = IPO_Deposit_Withdraw_Return_BO.CustAmountList
                            .Where(t => t.Cust_Code == code)
                            .Select(t => Indication_IPOPaymentTransaction.Cheque_Return + "_" + Convert.ToString(t.Id)).FirstOrDefault();
                        transReasonList.Add(trans_Reason_Temp);                    
                    }

                    
                    string voucherNo = txt_DepositCheque_VoucherNo.Text;
                    DateTime date = dtp_DepositChequeDate.Value;
                    bal.Insert_Return_NonTransfer_MoneyTransaction(Cust_Code, amountList.ToArray(), Deposit_Withdraw, date, payment_Method, voucherNo,txtRemarks.Text, transReasonList.ToArray());
                    //string routing=
                }
                else
                {
                    throw new Exception("Under Construction!!");
                }

                MessageBox.Show("Data Save Successfully!!");
                GetPaymentEntryInfo();
                ClearAll();
               
                //GetPaymentEntryInfo();
            }
            catch (Exception ex)
            {
                GetPaymentEntryInfo();
                throw new Exception(ex.Message);
            }

        }
        
        private void DgCustomer_Formatting()
        {
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
            {
                dg_Customers.Columns["IsChargable"].Visible = true;
                CheckParentAndChildCode();
            }
            else
            {
                dg_Customers.Columns["IsChargable"].Visible = false;
                DgCustomersSetDefaultColor();
            }
        }
        private void CheckParentAndChildCode()
        {           
            IPOProcessBAL bal = new IPOProcessBAL();
            DataTable dt = new DataTable();
          
            //dg_Customers.Rows[r].Selected = true;
            string[] code = dg_Customers.Rows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Cust_Code"].Value)).ToArray();
            string[] cust_code ;
            if (code.Length > 0)
            {
                dt = bal.GetParentInfo(code);
                cust_code = dt.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Parent_Code"])).ToArray();
                foreach (DataGridViewRow row in dg_Customers.Rows)
                {
                    string instantrowCodee = row.Cells["Cust_Code"].Value.ToString();
                    if (cust_code.Contains(instantrowCodee))
                    {
                        dg_Customers.Rows[row.Index].Cells["Cust_code"].Style.SelectionBackColor = Color.Pink;
                        dg_Customers.Rows[row.Index].Cells["Cust_code"].Style.BackColor = Color.Pink;
                    }
                }
            }
        }
        private void DgCustomersSetDefaultColor()
        {

             
            foreach (DataGridViewRow row in dg_Customers.Rows)
            {
                //string instantrowCodee = row.Cells["Cust_Code"].Value.ToString();                 
                    dg_Customers.Rows[row.Index].Cells["Cust_code"].Style.SelectionBackColor = Color.Empty;
                    dg_Customers.Rows[row.Index].Cells["Cust_code"].Style.BackColor = Color.Empty;
                
            }
        }
        private void btnDWReturnInfo_ModeChange()
        {
            int noOfCustomerSelected=dg_Customers.Rows.Cast<DataGridViewRow>().ToList().Where(t=> Convert.ToBoolean(t.Cells["IsChargable"].EditedFormattedValue)==true).Count();
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit && noOfCustomerSelected == 0)
            {
                btnDWReturnInfo.Size = new Size(60, 23);
                btnDWReturnInfo.Text = "Charge";
                btnDWReturnInfo.Enabled = false;
                btn_Cancel_TransChrgTaken.Visible = true;
                btn_Cancel_TransChrgTaken.Enabled = false;
            }
            else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit && noOfCustomerSelected>0)
            {
                btnDWReturnInfo.Size = new Size(60, 23);
                btnDWReturnInfo.Text = "Charge";
                btnDWReturnInfo.Enabled = true;
                btn_Cancel_TransChrgTaken.Visible = true;
                btn_Cancel_TransChrgTaken.Enabled = true;
            }
            else if ((ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA) 
                && ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
            {
                btnDWReturnInfo.Size = new Size(60, 23);
                btnDWReturnInfo.Text = "Charge";
                btnDWReturnInfo.Enabled = true;
                btn_Cancel_TransChrgTaken.Visible = true;
                btn_Cancel_TransChrgTaken.Enabled = true;
            } 
            else
            {
                btnDWReturnInfo.Size = new Size(30, 23);
                btnDWReturnInfo.Text = "...";
                btn_Cancel_TransChrgTaken.Visible = false;
                btn_Cancel_TransChrgTaken.Enabled = false;
            }
        }

        private void GetPaymentEntryInfo()
        {
            string paymentMedia = string.Empty;
            string depositWithdraw = string.Empty;
            try
            {
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                DataTable data_ForTransaction = new DataTable();
                DataTable data_ForApplication = new DataTable();
                depositWithdraw = ddlDepositWithdraw.Text;
                
                //string[] Codes=dt_CustList_IPOPayment.AsEnumerable().Select(t=> "'"+Convert.ToString(t["Cust_Code"])+"'").ToArray();

                //if (Codes.Length > 0)
                //{
                    //Transaction Data Load
                    data_ForTransaction = ipoBal.GetIPOPaymentEntryFormTransactionData(depositWithdraw, ddlPaymentMedia.Text, dtpSearchPaymentEntry.Value);
                    dgvPaymentInfo.DataSource = data_ForTransaction;

                    //Change
                    //if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TR)
                    //{
                    //    this.dgvPaymentInfo.Columns[0].Visible = true;
                    //}
                    //else
                    //{
                    //    this.dgvPaymentInfo.Columns[0].Visible = false;
                    //}
                    tssTotalRecord.Text = @"Total Records " + dgvPaymentInfo.Rows.Count.ToString();
                    dgvPaymentInfo.Columns["Amount"].DefaultCellStyle.Format = "N";
                    dgvPaymentInfo.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPaymentInfo.Columns["ID"].Visible =false ;
                    dgvPaymentInfo.Columns["Trans_Reason"].Visible = false;

                    //Application Data Load
                    data_ForApplication = ipoBal.GetIPOPaymentEntryFromApplicationData(dtpSearchPaymentEntry.Value);
                    dgv_ApplicationStatus.DataSource = data_ForApplication;
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



#endregion FormDataAccessMethod

#region EventMethod

        private void btnSave_Click(object sender, EventArgs e)
        {
            PaymentInfoBAL paymentBal = new PaymentInfoBAL();
            

            try
            {
                //CheckIn if (txtStatus.Text != @"Active")
                if (Check_IsAllActive())
                {
                    if (!
                        ( MessageBox.Show(@"Customer Found Closed. Do You Want To Save?", @"Cust status check",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) )
                    {
                        return;
                    }
                }
                SaveData();
            }
            catch (Exception ex)
            {

                ControlToFocus.Focus();
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //ShowPaymentReviewReport();
            //frmReportFormPeriod nReviRep = new frmReportFormPeriod();
            frmIPONewPaymentReview review = new frmIPONewPaymentReview();
            review.Show();
            //nReviRep.Text = @"New Payment Review Report";
            //nReviRep.Title = "New Payment Review Report";
            //nReviRep.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                btnGo_Event();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        

        private void btnGo_Event()
        {
            try
            {
                IPOProcessBAL bal = new IPOProcessBAL();
                string code = txtSearchCustomer.Text;
                if (code != bal.GetCheckCustCode(txtSearchCustomer.Text))
                {
                    string msg = "Invalid Customer Code or close account or nonrecident";
                    ExceptionCollectionList.Add("Cust Code: " + txtSearchCustomer.Text + " " + msg);
                    Form_CustomException(msg, IsCollectiveExceptionOn);
                }
                else
                {
                    if (dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(T => Convert.ToString(T["Cust_Code"]) == txtSearchCustomer.Text).Count() == 0)
                    {
                        //ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);  
                        txt_CustCodeHidden.Text = txtSearchCustomer.Text;
                        Add_Dt_CustList_IPOPayment();
                        dg_Customers.DataSource = dt_CustList_IPOPayment;
                        LoadInfoByCustCode();
                        chk_AppliedTogather.Checked = false;
                        Set_AppliedTogatherMode(false);
                        txtSearchCustomer.Text = "";
                        txtSearchCustomer.Focus();
                    }
                    else
                    {
                        string msg = "Already in grid ";
                        ExceptionCollectionList.Add("Cust Code: " + txtSearchCustomer.Text + " " + msg);
                        Form_CustomException(msg, IsCollectiveExceptionOn);
                    }

                    //txt_CustCodeHidden.Text = txtSearchCustomer.Text;
                    //Add_Dt_CustList_IPOPayment();
                    //dg_Customers.DataSource = dt_CustList_IPOPayment;
                    //LoadInfoByCustCode();
                    //chk_AppliedTogather.Checked = false;
                    //Set_AppliedTogatherMode(false);
                    //txtSearchCustomer.Focus();
                    ////SearchCustomerInformation();
                    //////if (MenuName == "EFT Requisition")
                    ////if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == depositWithdraw.Withdraw)
                    ////{
                    ////    SearchRoutingInformation();
                    ////}
                    ////else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.EFT && ddlDepositWithdraw.Text == depositWithdraw.Deposit)
                    ////{
                    ////    Search_BankBranchComboDataForDeposit();
                    ////}
                    ////GetPaymentEntryInfo();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void ddlSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            IPOProcessBAL bal=new IPOProcessBAL();
            string code=txtSearchCustomer.Text;
            try
            {
                if (e.KeyCode.ToString() == "Return")
                {
                    if (code != bal.GetCheckCustCode(txtSearchCustomer.Text))
                    {
                        MessageBox.Show("Invalid Customer Code or close account or nonrecident");
                    }
                     
                        
                        else
                        {
                            if (dt_CustList_IPOPayment.Rows.Cast<DataRow>().Where(T => Convert.ToString(T["Cust_Code"]) == txtSearchCustomer.Text).Count() == 0)
                            {
                                //ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);  
                                txt_CustCodeHidden.Text = txtSearchCustomer.Text;
                                Add_Dt_CustList_IPOPayment();
                                dg_Customers.DataSource = dt_CustList_IPOPayment;
                                LoadInfoByCustCode();
                                chk_AppliedTogather.Checked = false;
                                Set_AppliedTogatherMode(false);
                                txtSearchCustomer.Text = "";
                                txtSearchCustomer.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Already in grid ");
                            }
                            
                        }
                     
                }
            }
            catch (Exception ex)
            {
                ControlToFocus.Focus();
                MessageBox.Show(ex.Message);
            }
        }


        private void ddlPaymentMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Clearing
                if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA)
                {
                    ClearByCustCode();
                    ClearSearchCustomer();
                    ClearTransactionBasedChargeTaken();
                    ClearChargeCust_Code_Checking();
                    ClearRequiredTransCharge();
                    Set_Distributed_Amount();
                    Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                    Set_MinimumBalance_Amount();
                }
                else
                {
                    ClearPanel();
                    ClearByMode(ddlDepositWithdraw.Text, ddlPaymentMedia.Text);
                    ClearChagableCustCode();
                    ClearTransactionBasedChargeTaken();
                    ClearChargeCust_Code_Checking();
                    ClearRequiredTransCharge();
                    Set_Distributed_Amount();
                    Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                    Set_MinimumBalance_Amount();
                }
                
                //Loading
                LoadPanel();
               
                if (!ddlPaymentMedia.Text.Contains(Indication_PaymentTransaction.Return_Indicator))
                {

                    SetNon_ReturnMode();
                }
                else
                {
                    SetDW_ReturnMode();
                }

                if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
                {
                    
                    Set_RequiredTransCharge();
                }
                DgCustomer_Formatting();
                btnDWReturnInfo_ModeChange();
                GetPaymentEntryInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            try
            {
                btnSearchTrans_Event();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchTrans_Event()
        {
            if (txt_Transfer_CustCode.Text.Trim() != "")
            {
                string PaymentMethod = ddlPaymentMedia.Text;
                SearchTransCustomerInformation();
                SetNextFocus(ddlPaymentMedia.Text, txt_Transfer_CustCode.Name);
            }
        }

        private void txtTransCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                try
                {
                    SearchTransCustomerInformation();
                    SetNextFocus(ddlPaymentMedia.Text, txt_Transfer_CustCode.Name);                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                 
                
                
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
            if (ddlDepositWithdraw.Text==Indication_PaymentMode.Deposit)
                Initialize_PaymentMethodsDatasource(FormDeposit_Withdraw.Deposit);
            else
                Initialize_PaymentMethodsDatasource(FormDeposit_Withdraw.Withdraw);
            
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

        private void btneftAutoVoucher_Click(object sender, EventArgs e)
        {
            //PaymentInfoBAL obj = new PaymentInfoBAL();
            //string serial = obj.GenerateSerial();
            txt_EftWithdraw_VoucherNo.Text = EFT_Voucher_Autogen;
            //txtRemarks.Focus();
            txtRecievedBy.Focus();
        }

        private void txteftVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, txt_EftWithdraw_VoucherNo.Name);
            }
        }

        private void txtPaymentMedia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txt_Paypal_OrderNo.Name);
        }

        private void txtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txt_Paypal_BankName.Name);
        }

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txt_Paypal_BranchName.Name);

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
            {
                txtAmount_Event();
            }
        }

        private void txtAmount_Event()
        {
            SetNextFocus(ddlPaymentMedia.Text, txtAmount.Name);
            Set_TransactionCharge_FromAmount();
            //cust DataTable Repopulation 
            Set_Distributed_Amount();
            Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
            Set_MinimumBalance_Amount();
            chk_AppliedTogather.Checked = false;
            Set_AppliedTogatherMode(false);
            Set_RequiredTransCharge();
            
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO)
                SearchTransCustomerInformation();
        }

        private void txtSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetNextFocus(ddlPaymentMedia.Text, txt_Paypal_VoucherNo.Name);
        }

        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAutoGen_Click(sender, e);
                SetNextFocus(ddlPaymentMedia.Text, txt_Transfer_VoucherNo.Name);
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
                        //Change
                        //if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TR)
                        //{
                        //    MessageBox.Show("Transfer Not be Canceled, Please Contact System Administrator", "Cancel Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        //LoadDataFromGrid();
                        //PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        //paymentInfoBal.CancelDeposit(_paymentID);
                        IPOProcessBAL bal = new IPOProcessBAL();
                        int Payemt_Posting_ID = 0;
                        string transreason=dgvPaymentInfo.SelectedRows[0].Cells["Trans_Reason"].Value.ToString();
                        int IpoTrans_ID=Convert.ToInt32(dgvPaymentInfo.SelectedRows[0].Cells["ID"].Value);
                        string stattus = dgvPaymentInfo.SelectedRows[0].Cells["Status"].Value.ToString();
                        string Media = dgvPaymentInfo.SelectedRows[0].Cells["Media"].Value.ToString();
                        if (stattus == "Pending")
                        {
                            if (Media == Indication_IPOPaymentTransaction.TRTA)
                            {
                                if (transreason != string.Empty)
                                {
                                    Payemt_Posting_ID = Convert.ToInt32(transreason.Split('_').Last());
                                }
                            }
                            bal.DeleteDepositInfo(IpoTrans_ID, Payemt_Posting_ID, stattus);
                            MessageBox.Show("Deposit Request successfully Canceled.");
                            GetPaymentEntryInfo();
                        }
                        else
                        {
                            throw new Exception("Approved transaction Can't be deleted");
                        }


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
        string Charge_Media = "";
        string Charge_For_IPO_Application = "";
        private void btnDWReturnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque_Return)
                //{
                //    IPOProcessBAL bal = new IPOProcessBAL();
                //    string _tempDW = "";
                //    string[] Cust_Code;
                //    _tempDW = ddlPaymentMedia.Text;
                   
                //    Cust_Code = dg_Customers.Rows.Cast<DataGridViewRow>()
                //        //.Where(t=>Convert.ToString(t.Cells["Deposit_Withdraw"].Value)=="Deposit")
                //        .Select(T => Convert.ToString(T.Cells["Cust_Code"].Value)).ToArray();
                //    frm_Ipo_CheckReturn frm = new frm_Ipo_CheckReturn(Cust_Code, "", Indication_IPOPaymentTransaction.Cheque);
                //    frm.StartPosition = FormStartPosition.CenterScreen;
                //    frm.ShowDialog(this);
                //    SetNextFocus(ddlPaymentMedia.Text, btnDWReturnInfo.Name);
                //}
                //else 
                if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
                {
                    if (txt_DepositCheque_VoucherNo.Text == string.Empty)
                        throw new Exception("Defined Voucher No First!!");
                    double doubleTryParse;
                    double amount_ToDeposit=0.00;
                    
                    var temp = dg_Customers.Rows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToBoolean(t.Cells["IsChargable"].Value) == true)
                        .Select(t => new 
                        { Cust_Code = Convert.ToString(t.Cells["Cust_Code"].Value)
                            , Amount = Convert.ToDouble(t.Cells["Distributed_Amount"].Value) + Convert.ToDouble(t.Cells["IPO_Mone_Bal"].Value) }).FirstOrDefault();
                    double amount = temp.Amount;
                    string cust_Code = temp.Cust_Code;
                    if (double.TryParse(txtAmount.Text, out doubleTryParse))
                        amount_ToDeposit = doubleTryParse;
                    
                    PaymentInfoBAL bal = new PaymentInfoBAL();

                    //Popup form casting
                    frm_IPOTransactionChargeTaken frm = new frm_IPOTransactionChargeTaken();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ChargeName = Indication_TransactioBasedCharge.BankClearing;
                    frm.ChargedCustCode = cust_Code;
                    frm.Amount = bal.GetTransactionBasedCharges_ChargeAmount(Indication_TransactioBasedCharge.BankClearing, amount_ToDeposit);
                    frm.VoucherNo = txt_DepositCheque_VoucherNo.Text;
                    frm.TransReason = Indication_TransactioBasedCharge.TransReasonList
                        .Where(t => t.Key == Indication_TransactioBasedCharge.BankClearing)
                        .Select(t => t.Value).FirstOrDefault();
                    frm.ReceivedDate = dtRecievedDate.Value.Date;
                    frm.Remarks = string.Empty;
                    frm.AmountToDeposit = amount_ToDeposit;
                    //frm.ReferenceNo =Indication_IPOPaymentTransaction.Cash;
                    frm.ChargeType = ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque ? Indication_TransactioBasedCharge.BankClearing : Indication_TransactioBasedCharge.IPOApp;
                    frm.ShowDialog(this);

                    //Popup form cast. back
                    if (frm.IsChargeTaken)
                    {

                        if (frm.ChargeType == Indication_TransactioBasedCharge.BankClearing)
                        {
                            ClearTransactionBasedChargeTaken();
                            txt_TransChrg_ChargedCustCode.Text = frm.ChargedCustCode;
                            txt_TransChrg_TransFromCode.Text = frm.TransferCode;
                            txt_TranChrg_ChagedAmount.Text = Convert.ToString(frm.Amount);
                            txt_TransChrg_VoucherNo.Text = frm.VoucherNo;
                            txt_TransChrg_RefNo.Text = frm.ReferenceNo;
                            dtp_TransChrg_ReceivedDate.Value = frm.ReceivedDate.Date;
                            txt_TransChrg_Remarks.Text = frm.Remarks;
                            txt_TransChrg_TransReason.Text = frm.TransReason;
                            txt_TransChrg_PaymentMediaID.Text = Convert.ToString(frm.Payment_MediaID);
                            txt_TransChrg_PaymentMediaName.Text = frm.Payment_Media;
                            chk_TransChrg_IsApplied.Checked = true;
                        }
                        else if (frm.ChargeType == Indication_TransactioBasedCharge.IPOApp)
                        {
                            chk_AppCharge_IsApplied.Checked = true;
                            txt_AppCharge_TransFrom.Text = frm.TransferCode;
                            dtp_AppCharge_ReceiveDate.Value = frm.ReceivedDate.Date;
                            txt_AppCharge_Amount.Text = Convert.ToString(frm.Amount);
                            txt_AppCharge_VoucherNo.Text = frm.VoucherNo;
                            txt_AppCharge_ReferenceNo.Text = frm.ReferenceNo;
                            txt_AppCharge_Remarks.Text = frm.Remarks;
                            txt_AppCharge_TransReason.Text = frm.TransReason;
                            txt_AppCharge_PaymentMediaID.Text = Convert.ToString(frm.Payment_MediaID);
                            txt_AppCharge_PaymentMediaName.Text = frm.Payment_Media;
                        }

                        Set_Distributed_Amount();
                        Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                        Set_MinimumBalance_Amount();

                        ////cust DataTable Repopulation                   
                        //Set_ChequeChargeAmount_ToChargedAccount();
                        //Set_MinimumBalance_Amount();
                    }
                }
                else if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRTA || ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.TRIPO)
                {
                   
                    double amount = 0.00;
                    List<string> Code=new List<string>();
                    //foreach (DataGridViewRow row in dg_Customers.Rows)
                    //{
                    //    amount =Convert.ToDouble(row.Cells["Distributed_Amount"].Value) + amount;
                    //    string c = row.Cells["Cust_Code"].Value.ToString();
                    //     //cust_Code=(new string[] { c });
                    //    //Code.Add(c);
                    //}
                   
                    //string[] cust_code = Code.ToArray(); 
                    
                    string From_Cust_Code=txt_Transfer_CustCode.Text;
                    double doubleTryParse;
                    double amount_ToDeposit = 0.00;
                    if (double.TryParse(txtAmount.Text, out doubleTryParse))
                        amount_ToDeposit = doubleTryParse;
                    
                    //Clear_IPO_Application_ChargeTaken();

                    IPOProcessBAL bal = new IPOProcessBAL();
                    
                    //Popup form casting
                    frm_IPOTransactionChargeTaken frm = new frm_IPOTransactionChargeTaken();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ChargeName = Indication_TransactioBasedCharge.IPOApp;
                    //frm.ChargedCustCode =string.Empty;
                    frm.TransferCode = string.Empty;
                    frm.ChargedCustCode = string.Join(",",dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray());

                    frm.Amount = bal.GetIPO_ChargeDef().Rows.Count > 0 ? Convert.ToDouble(bal.GetIPO_ChargeDef().Rows[0]["TotalCharge"]) : 0.00;
                    frm.VoucherNo = txt_DepositCheque_VoucherNo.Text;
                    frm.TransReason = Indication_TransactioBasedCharge.TransReasonList
                        .Where(t => t.Key == Indication_TransactioBasedCharge.IPOApp)
                        .Select(t => t.Value).FirstOrDefault();
                    frm.ReceivedDate = dtRecievedDate.Value.Date;
                    frm.ChargeType = ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque ? Indication_TransactioBasedCharge.BankClearing : Indication_TransactioBasedCharge.IPOApp;
                    //frm.Remarks = Indication_IPOPaymentTransaction.Cash||Indication_IPOPaymentTransaction.TRIPO||Indication_IPOPaymentTransaction.TRTA;
                    frm.ReferenceNo = frm.Payment_Media;
                    frm.ShowDialog(this);
                    
                    //Popup form cast back
                    if (frm.IsChargeTaken)
                    {
                        chk_AppCharge_IsApplied.Checked = true;
                        txt_AppCharge_TransFrom.Text=frm.TransferCode;
                        dtp_AppCharge_ReceiveDate.Value=frm.ReceivedDate.Date;
                        txt_AppCharge_Amount.Text=Convert.ToString(frm.Amount);
                        txt_AppCharge_VoucherNo.Text=frm.VoucherNo;
                        txt_AppCharge_ReferenceNo.Text=frm.ReferenceNo;
                        txt_AppCharge_Remarks.Text=frm.Remarks;
                        txt_AppCharge_TransReason.Text=frm.TransReason;
                        txt_AppCharge_PaymentMediaID.Text=Convert.ToString(frm.Payment_MediaID);
                        txt_AppCharge_PaymentMediaName.Text = frm.Payment_Media;
                        //Set_IPOApplicaiton_Charge_ToChargedAccount();
                        Set_Distributed_Amount();
                        Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                        Set_MinimumBalance_Amount();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEftCheckDepositAutogen_Click(object sender, EventArgs e)
        {
            txt_DepositEft_VoucherNo.Text = EFT_Voucher_Autogen;
            txtRecievedBy.Focus();
        }

        private void txtDepositPaymentMedia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, txtDepositChequeNo.Name);
            }
        }

        private void cdtDepositPaymentMediaDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, dtp_DepositChequeDate.Name);
            }
        }

        private void ddlDepositBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddl_DepositCheque_BankName.DroppedDown)
                {
                    ddl_DepositCheque_BankName.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddl_DepositCheque_BankName.Name);
            }
        }

        private void ddlDepositBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddl_DepositCheque_BranchName.DroppedDown)
                {
                    ddl_DepositCheque_BranchName.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddl_DepositCheque_BranchName.Name);
            }
        }

        private void txtDepositVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, txt_DepositCheque_VoucherNo.Name);
            }
        }

        private void btnWebData_Click_1(object sender, EventArgs e)
        {
            frmWeb2014DataForward frm = new frmWeb2014DataForward("Money Withdraw Forward Payment Posting");
            frm.pp_Delegate = new frmWeb2014DataForward.DataToPaymentPosting(WebDataCasting);
            frm.Show();

        }

        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void chk_AppliedTogather_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ClearRefundPanel();
                ClearAvailableSession();
                ChkAffected.Checked = false;

                if (ddlDepositWithdraw.Text == Indication_PaymentMode.Deposit)
                {
                    Set_AppliedTogatherMode(chk_AppliedTogather.Checked);
                    LoadDefault();
                    if (chk_AppliedTogather.Checked)
                    {
                        LoadRefundPanel();
                        LoadAvailAbleIPOSession();
                    }
                }
                TOtalAmountOfTotalAppliedCompany = 0;                
            }
            catch (Exception ex)
            {   
                    MessageBox.Show(ex.Message);
            }

        }
        private void LoadDefault()
        {
            cmb_RefundMethod.SelectedValue = 2;
        }

        private void cmb_RefundMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearRefundPanel_ByRefundMethod();
                LoadRefundPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dg_Customers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dg_Customers.CommitEdit(DataGridViewDataErrorContexts.Commit);

                if (dg_Customers.Columns[e.ColumnIndex].Name == "DeleteFlag")
                {
                    Remove_Dt_CustList_IPOPayment(e.RowIndex);
                    dg_Customers.DataSource = dt_CustList_IPOPayment;
                    chk_AppliedTogather.Checked = false;
                    Set_AppliedTogatherMode(false);
                }
                else if (dg_Customers.Columns[e.ColumnIndex].Name == "IsChargable")
                {
                    btnDWReturnInfo_ModeChange();


                    //var temp = dg_Customers.Rows.Cast<DataGridViewRow>().Where(t => Convert.ToBoolean(t.Cells["IsChargable"].EditedFormattedValue) == true)
                    //    .Select(t => new { Cust_Code = Convert.ToString(t.Cells["Cust_Code"].Value), Amount = Convert.ToDouble(t.Cells["Distributed_Amount"].Value) + Convert.ToDouble(t.Cells["IPO_Mone_Bal"].Value) }).ToList();
                    //int count = temp.Count();
                    if (dg_Customers.Rows.Cast<DataGridViewRow>().Where(t => Convert.ToBoolean(t.Cells["IsChargable"].EditedFormattedValue) == true).Count() > 1)
                    {
                        dg_Customers.CancelEdit();
                        throw new Exception("Charge Don't Apply More Than One Code");
                    }
                    if (!Convert.ToBoolean(dg_Customers.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue))
                    {
                        ClearTransactionBasedChargeTaken_OnlyTakenFromAmount();
                        
                        Set_Distributed_Amount();
                        Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                        Set_MinimumBalance_Amount();
                    
                        dg_Customers.EndEdit();
                        dg_Customers.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
                    }
                    else
                    {
                        txt_TransChrg_ChargedCustCode.Text = Convert.ToString(dg_Customers.Rows[e.RowIndex].Cells["Cust_Code"].Value);
                        Set_TransactionCharge_FromAmount();

                        Set_Distributed_Amount();
                        Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                        Set_MinimumBalance_Amount();
                        dg_Customers.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            //SetNextFocus(ddlPaymentMedia.Text, txtAmount.Name);
            //Set_TransactionChargeFromAmount();
            ////cust DataTable Repopulation 
            //Set_Distributed_Amount();
            //Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
            //Set_ChequeChargeAmount_ToChargedAccount();
            //Set_MinimumBalance_Amount();
            //chk_AppliedTogather.Checked = false;
            //Set_AppliedTogatherMode(false);
            //Set_RequiredTransCharge();
            txtAmount_Event();
        }



    #endregion EventMethod

#region EFT Deposit Section
        private void ddlEftDepositBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddl_DepositEft_Bank_Name.DroppedDown)
                {
                    ddl_DepositEft_Bank_Name.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddl_DepositEft_Bank_Name.Name);
            }
        }
        private void ddlEftDepositBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ddl_DepositEft_Branch_Name.DroppedDown)
                {
                    ddl_DepositEft_Branch_Name.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddl_DepositEft_Branch_Name.Name);
            }
        }
        private void txtEftDepositBankAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(ddlPaymentMedia.Text, txt_DepositEft_BankAccountNo.Name);
            }
        }
        private void LoadEftBranchInfoByBankId(int bankId)
        {
            var dtbranch = (PaymentForm_Cache.Where(t => t.Key == CacheKey_Bank_Branch_Routing_Info_For_EFTCheckPayorderPaypal_Return)
                           .Select(t => t.Value).SingleOrDefault() as DataTable).AsEnumerable().Where(t => Convert.ToInt32(t["Bank_ID"]) == bankId)
                           .Select(t => new { Value = t["Branch_Name"] + "(" + t["Routing_No"] + ")", Key = Convert.ToInt32(t["Branch_ID"]) }).ToList();



            var MaxLen = dtbranch.Select(t => t.Value.Length).Max();

            ddl_DepositEft_Branch_Name.DataSource = dtbranch;
            ddl_DepositEft_Branch_Name.ValueMember = "Key";
            ddl_DepositEft_Branch_Name.DisplayMember = "Value";
            ddl_DepositEft_Branch_Name.DropDownWidth = MaxLen * 7;
            ddl_DepositEft_Branch_Name.SelectedIndex = 0;
        }
        private void ddlEftDepositBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int bankId = Convert.ToInt32(ddl_DepositEft_Bank_Name.SelectedValue.ToString());
                LoadEftBranchInfoByBankId(bankId);
            }
            catch
            {

            }
        }
        private void ddlEftDepositBankName_DropDown(object sender, EventArgs e)
        {
            ddl_DepositEft_Bank_Name.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlEftDepositBankName_DropDownClosed(object sender, EventArgs e)
        {
            ddl_DepositEft_Bank_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void ddlEftDepositBankName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int bankId = Convert.ToInt32(ddl_DepositEft_Bank_Name.SelectedValue.ToString());
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

            ddl_DepositEft_RoutingNo.SelectedValue = routingNo;

        }
        private void ddlEftDepositBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int branchId = 0;
            try
            {
                branchId = Convert.ToInt32(ddl_DepositEft_Branch_Name.SelectedValue.ToString());
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
                branchId = Convert.ToInt32(ddl_DepositEft_Branch_Name.SelectedValue.ToString());
                LoadEftRoutingInfoByBranchId(branchId);
            }
            catch
            {

            }
        }
        private void ddlEftDepositBranchName_DropDown(object sender, EventArgs e)
        {
            ddl_DepositEft_Branch_Name.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlEftDepositBranchName_DropDownClosed(object sender, EventArgs e)
        {
            ddl_DepositEft_Branch_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
                ddl_DepositEft_Bank_Name.SelectedValue = BankID;
                ddl_DepositEft_Branch_Name.SelectedValue = BranchID;
            }
        }
        private void ddlEftDepositRoutingNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string routingNo = string.Empty;
            try
            {
                routingNo = ddl_DepositEft_RoutingNo.SelectedValue.ToString();
                LoadEFTBankBranchByRoutingNo(routingNo);
            }

            catch
            {

            }
        }
        private void ddlEftDepositRoutingNo_DropDown(object sender, EventArgs e)
        {
            ddl_DepositEft_RoutingNo.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlEftDepositRoutingNo_DropDownClosed(object sender, EventArgs e)
        {
            ddl_DepositEft_RoutingNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void ddlEftDepositRoutingNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string routingNo = string.Empty;
            try
            {
                routingNo = ddl_DepositEft_RoutingNo.SelectedValue.ToString();
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
                if (ddl_DepositEft_RoutingNo.DroppedDown)
                {
                    ddl_DepositEft_RoutingNo.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddl_DepositEft_RoutingNo.Name);
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

            ddl_DepositCheque_BranchName.DataSource = dtbranch;
            ddl_DepositCheque_BranchName.ValueMember = "Key";
            ddl_DepositCheque_BranchName.DisplayMember = "Value";
            ddl_DepositCheque_BranchName.DropDownWidth = MaxLen * 7;

        }
       
        private void ddlDepositBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int bankId = Convert.ToInt32(ddl_DepositCheque_BankName.SelectedValue.ToString());
                LoadNonEFTBranchInfoByBankId(bankId);
            }
            catch
            {

            }
        }
        private void ddlDepositBankName_DropDown(object sender, EventArgs e)
        {
            ddl_DepositCheque_BankName.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlDepositBankName_DropDownClosed(object sender, EventArgs e)
        {
            ddl_DepositCheque_BankName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void ddlDepositBankName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int bankId = Convert.ToInt32(ddl_DepositCheque_BankName.SelectedValue.ToString());
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
                SetNextFocus(ddlPaymentMedia.Text, txt_DepositEft_VoucherNo.Name);
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
            ddl_DepositCheque_RoutingNo.SelectedValue = routingNo;
        }
        private void ddlDepositBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int branchId = Convert.ToInt32(ddl_DepositCheque_BranchName.SelectedValue.ToString());
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
                int branchId = Convert.ToInt32(ddl_DepositCheque_BranchName.SelectedValue.ToString());
                LoadBranchNameByBranchID(branchId);
            }
            catch
            {
            }
        }
        private void ddlDepositBranchName_DropDown(object sender, EventArgs e)
        {
            ddl_DepositCheque_BranchName.AutoCompleteMode = AutoCompleteMode.None;
        }
        private void ddlDepositBranchName_DropDownClosed(object sender, EventArgs e)
        {
            ddl_DepositCheque_BranchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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

                ddl_DepositCheque_BankName.SelectedValue = BankID;
                ddl_DepositCheque_BranchName.SelectedValue = BranchID;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
      

        private void ddlDepositRoutingNo_DropDown(object sender, EventArgs e)
        {
            ddl_DepositCheque_RoutingNo.AutoCompleteMode = AutoCompleteMode.None;

        }      
        private void ddlDepositRoutingNo_DropDownClosed(object sender, EventArgs e)
        {
            ddl_DepositCheque_RoutingNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

        }
        private void ddlDepositRoutingNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string routingNo = string.Empty;
            try
            {
                routingNo = ddl_DepositCheque_RoutingNo.SelectedValue.ToString();
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
                if (ddl_DepositCheque_RoutingNo.DroppedDown)
                {
                    ddl_DepositCheque_RoutingNo.DroppedDown = false;
                }
                SetNextFocus(ddlPaymentMedia.Text, ddl_DepositCheque_RoutingNo.Name);
            }
        }        
        private void ddlDepositRoutingNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string routingNo = string.Empty;
            try
            {
                routingNo = ddl_DepositCheque_RoutingNo.SelectedValue.ToString();
                LoadBankBranchByRoutingNo(routingNo);
            }
            catch
            {

            }
        }

#endregion Non EFT Deposit Section     

        private void dg_AvailableSession_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            double doubleTryParse = 0.00;
            double chargedAmount = 0.00;
            double LowestAmount=0.00;
            double chargeChargeRequired = 0.00;
            double depositAmount = 0.00;
            double requiredChargedAmount = 0.00;

            PaymentInfoBAL bal=new PaymentInfoBAL();

            //Cheque Deposit & Charge Taken
            if(double.TryParse(txt_TranChrg_ChagedAmount.Text,out doubleTryParse))
            {
                chargedAmount = doubleTryParse;
            }
            if (double.TryParse(txtAmount.Text, out doubleTryParse))
            {
                depositAmount = doubleTryParse;
            }
            if (double.TryParse(txt_RequiredTranCharge.Text, out doubleTryParse))
            {
                requiredChargedAmount = doubleTryParse;
            }

            //Calculate Lowest Deposit Amount
            if (ddlPaymentMedia.Text == Indication_IPOPaymentTransaction.Cheque)
            {
                LowestAmount = double.Parse(txt_Distributed_Amount.Text) + double.Parse(txt_MinBalance.Text) + chargedAmount;
            }
            else
            {
                LowestAmount = double.Parse(txt_Distributed_Amount.Text) + double.Parse(txt_MinBalance.Text);
            }
 
            
            double TotalAppliedCompanyAmount=0;
            if (e.ColumnIndex == 0)
            {
                bool value = Convert.ToBoolean(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].EditedFormattedValue);
                double Amount = GetTotalAppliedCompanysAmount(e.RowIndex);
                if (value == true)
                {
                    //TOtalAmountOfTotalAppliedCompany = TOtalAmountOfTotalAppliedCompany+double.Parse(dg_AvailableSession.Rows[e.RowIndex].Cells["TotalAmount"].Value.ToString());

                    //GetTotalAppliedCompanysAmount(e.RowIndex);
                    Amount = double.Parse(dg_AvailableSession.Rows[e.RowIndex].Cells["TotalAmount"].Value.ToString()) + Amount;
                }

                TotalAppliedCompanyAmount = Amount+requiredChargedAmount;

            }

            if ((TotalAppliedCompanyAmount) > LowestAmount)
            {
                MessageBox.Show("Your balance is less then application amount");
                dg_AvailableSession.CancelEdit();
            }             

           
        }
        public double GetTotalAppliedCompanysAmount(int rowIndex)
        {
            double Result = 0;

            for (int i = 0; i < dg_AvailableSession.Rows.Count; i++)
            {
                if (i != rowIndex)
                {
                    bool value = Convert.ToBoolean(dg_AvailableSession.Rows[i].Cells[0].Value);
                    if (value == true)
                    {
                       Result=Result+ double.Parse(dg_AvailableSession.Rows[i].Cells["TotalAmount"].Value.ToString());
                    }
                }
            }
            return Result;
        }
        public string[] quantity;
        private void BtnVerification_Click(object sender, EventArgs e)
        {
            quantity = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
            frmCustomerVerificationInfo info = new frmCustomerVerificationInfo(quantity);
            info.StartPosition = FormStartPosition.CenterScreen;
            info.ShowDialog(this);
        }


        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        private void GetCommonInfo()
        {

            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyInfo();

                if (drCommonInfo != null)
                {
                    _CommpanyName = drCommonInfo.Table.Rows[0][0].ToString();
                    _branchName = drCommonInfo.Table.Rows[0][1].ToString();
                    _branchAddress = drCommonInfo.Table.Rows[0][2].ToString();
                    _branchContactNumber = drCommonInfo.Table.Rows[0][3].ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        double TOtalAmountOfTotalAppliedCompany = 0D;
        private void dg_AvailableSession_CellClick(object sender, DataGridViewCellEventArgs e)
        {

             
        }
        //private string[] ref_cust_code;
        //private int ref_cust_code_index = 0;
        private void btnpublicReport_Click(object sender, EventArgs e)
        {
            string[] orderId = dt_CustList_IPOPayment.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
            string refund_Desc = cmb_RefundMethod.Text;
            //ref_cust_code = orderId;
            ////do
            ////{
            //if (ref_cust_code.Length - 1 > ref_cust_code_index)
            //{
            //    ref_cust_code_index++;
            //}
            //else
            //{
            //    ref_cust_code_index = 0;
            //}
            //string ref_cust_code_list = ref_cust_code[ref_cust_code_index];
            //string id = (string)dgv_FinalCheck.SelectedCells[0].Value; 
            IPOProcessBAL objBAL = new IPOProcessBAL();
            DataTable dt = new DataTable();
            crIpoApplicationForPublicIssueSignature objrpt = new crIpoApplicationForPublicIssueSignature();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            string[] sessionID =  dg_AvailableSession.Rows.Cast<DataGridViewRow>()
                .Where(t => Convert.ToBoolean(t.Cells["IsSelect"].Value)==true)
                .Select(t => Convert.ToString(t.Cells["ID"].Value)).ToArray();
            dt = objBAL.GetPublicIssueFromBeforeApplication(orderId,sessionID);

            foreach (DataRow dr in dt.Rows)
            {
                dr["Refund_Method"] = refund_Desc;
            }


            objrpt.SetDataSource(dt);
            GetCommonInfo();
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                               "IPO Application for public issue";
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                _CommpanyName;
            ///// Load Branch Name
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            viewer.crystalReportViewer1.ReportSource = objrpt;
            //}while(ref_cust_code.Length=orderId.Length)
            viewer.StartPosition = FormStartPosition.CenterScreen;
            viewer.ShowDialog(this);
        }



        private void dg_Customers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dg_Customers != null)
            {                
                DataGridViewRow dr = dg_Customers.Rows[e.RowIndex];
                
                dg_Customers.Rows[e.RowIndex].Selected = true;

                if (Convert.ToDouble(dr.Cells["IPO_Mone_Bal"].Value) <= 0)
                {
                    dg_Customers.Rows[e.RowIndex].Cells["IPO_Mone_Bal"].Style.SelectionForeColor = Color.Red;
                    dg_Customers.Rows[e.RowIndex].Cells["IPO_Mone_Bal"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dg_Customers.Rows[e.RowIndex].Cells["IPO_Mone_Bal"].Style.SelectionForeColor = Color.Blue;
                    dg_Customers.Rows[e.RowIndex].Cells["IPO_Mone_Bal"].Style.ForeColor = Color.Blue;
                }

                dg_Customers.FirstDisplayedScrollingRowIndex = e.RowIndex;
                //}
                LabelCount.Text = "(Count - " + dg_Customers.Rows.Count.ToString() + ")";
                
            }
        }

        private void dg_Customers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dg_Customers != null)
            {
                LabelCount.Text = "(Count - "+dg_Customers.Rows.Count.ToString()+")";
            }
        }

        private void btnAutoGen_Click(object sender, EventArgs e)
        {
            txt_Transfer_VoucherNo.Text = "(Auto Gen)";
        }

        private void dgvPaymentInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //dgvPaymentInfo.Rows[e.RowIndex].Selected = true;
            //dgvPaymentInfo.FirstDisplayedScrollingRowIndex = e.RowIndex;
        }

        private void btn_Cancel_TransChrgTaken_Click(object sender, EventArgs e)
        {
            //ReSet_ChequeChargeAmount_ToChargedAccount();
            Clear_IPO_Application_ChargeTaken();
            ClearTransactionBasedChargeTaken();
            Set_TransactionCharge_FromAmount();
            Set_Distributed_Amount();
            Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
            Set_MinimumBalance_Amount();            
        }

        private void dgvPaymentInfo_DataSourceChanged(object sender, EventArgs e)
        {
            lbl_dgvPaymentInfo.Text ="Count: "+dgvPaymentInfo.Rows.Count;
        }

        private void dgv_ApplicationStatus_DataSourceChanged(object sender, EventArgs e)
        {
            lbl_dgvApp.Text = "Count: " + dgv_ApplicationStatus.Rows.Count;
        }

        private void dg_Customers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (chk_AppliedTogather.Checked)
            {
                chk_AppliedTogather.Checked = false;
                Set_AppliedTogatherMode(false);
            }
        }

        private void btnAutoGenForEFT_Click(object sender, EventArgs e)
        {
            txtAutoGen.Text = "Auto Gen";
        }

        private void btnSms_Click(object sender, EventArgs e)
        {
            try
            {
                if (MenuName == Indication_Forms_Title.IPOPaymentDeposit)
                {
                    frm_IPOSMSMoneyTransactionApproval sms = new frm_IPOSMSMoneyTransactionApproval(Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_Deposit);
                    sms.StartPosition = FormStartPosition.CenterScreen;
                    sms.ShowDialog(this);
                }
                if (MenuName == Indication_Forms_Title.IPOPaymentWithdraw)
                {
                    frm_IPOSMSMoneyTransactionApproval sms = new frm_IPOSMSMoneyTransactionApproval(Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_Withdraw);
                    sms.StartPosition = FormStartPosition.CenterScreen;
                    sms.ShowDialog(this);
                }
                //this.Close();
                if (frm_IPOSMSMoneyTransactionApproval.isForwarded)
                {
                    SetData();
                    Form_CollectiveException();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
             
        }

        private void btnEftReturn_Click(object sender, EventArgs e)
        {
            string EFTReturnCustCode = "";
            decimal Amount = 0M;
            string date="" ;
            if (MenuName == Indication_Forms_Title.IPOPaymentDeposit)
            {
                if (dg_Customers.Rows.Count == 0)
                {
                    MessageBox.Show("you have not provide any cutomer for EFT return");
                    return;
                }
                else if (dg_Customers.Rows.Count >= 2)
                {
                    MessageBox.Show("Two customers EFT Return is not possible at the same time");
                    return;
                }
                else
                {
                    EFTReturnCustCode = dg_Customers.Rows.Cast<DataGridViewRow>().Select(x => Convert.ToString(x.Cells["Cust_Code"].Value)).FirstOrDefault();
                    date = dtpSearchPaymentEntry.Value.ToShortDateString();
                    if (string.IsNullOrEmpty(txtAmount.Text))
                    {
                        MessageBox.Show("You have not provide EFT Amount");
                        return;
                    }
                    else
                    {

                        Amount = Convert.ToDecimal(txtAmount.Text);
                    }
                    frm_IPOEFTReturn eft = new frm_IPOEFTReturn(EFTReturnCustCode,Amount,date);
                    eft.StartPosition = FormStartPosition.CenterParent;
                    eft.ShowDialog(this);
                    SetEFTReturnData();
                }
            }
        }

        public void SetEFTReturnData()
        {

            try
            {
                ClearAll();

                //Switched On Collective Exception                
                IsCollectiveExceptionOn = true;
                TransID = frm_IPOEFTReturn.ID;
                IPOProcessBAL ipoBal = new IPOProcessBAL();

                //ddlDepositWithdraw.Text = frm_IPOSMSMoneyTransactionApproval.Deposit_Withdraw;

                string Cust_Code_Tmp = frm_IPOEFTReturn.cust_code;

                txt_ChannelID.Text = string.Empty;
                txt_ChannelType.Text = string.Empty;

                txtSearchCustomer.Text = Cust_Code_Tmp;
                btnGo_Event();

                Refresh_dt_CustList_IPOPayment_WithCurrentDistAmount();
                Set_MinimumBalance_Amount();




                decimal Amount_Tmp_EFT_Return = frm_IPOEFTReturn.Amount;

                txtAmount.Text = Convert.ToString(Amount_Tmp_EFT_Return);

                txtAmount_Event();
               

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                IsCollectiveExceptionOn = false;
            }

        }    

        
    }
}



