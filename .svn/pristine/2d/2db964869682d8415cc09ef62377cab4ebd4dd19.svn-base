using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.Constants;
using System.Threading;
using System.Data.SqlClient;
namespace StockbrokerProNewArch
{
    public partial class frmWeb2014DataForward : Form
    {
        public delegate void DataToPaymentPosting(Payment_PostingBO bo);
        public delegate void DataToCheckRequisition(CheckRequisitionBO bo);
        public delegate void DataToCashRequsition(Payment_PostingBO bo);

        public DataToPaymentPosting pp_Delegate;
        public DataToCheckRequisition cr_Delegate;
        public DataToCashRequsition Cash_Delegate;
        public static bool isProgressed;

        public string MenuName;

        private int grid_RowIndex;
        private int grid_ColumnIndex;

        private const string UserQuery_Forward = "User Query Forward";
        private const string MoneryWithdrawal_Forward_PaymentPosting  = "Money Withdraw Forward Payment Posting";
        private const string MoneryWithdrawal_Forward_PaymentPosting_Table = "Payment Withdraw Forward Payment Posting";
        private const string EFT_PaymentPosting_Table = "EFT Forward Payment Posting";
        private const string MoneryWithdrawal_Forward_CheckRequisition = "Money Withdraw Forward Check Requisition";
        private const string ServiceRegistration_Forward = "Service Registration Forward";
        //private const string EFT_PaymentPosting_Table = "EFT Forward Payment Posting";
        //private const string MoneryWithdrawal_Forward_CheckRequisition = "Money Withdraw Forward Check Requisition";
        
        //User Query

        private int? selected_UQuery_Contact_Us_Id;
        private string selected_UQuery_From_Email_Address;
        private string selected_UQuery_Contact_To;
        private string selected_UQuery_Contact_Subject;
        private string selected_UQuery_Contact_Message;
        private DateTime? selected_UQuery_Contact_Date;
        private string selected_UQuery_Contact_Status;
        private DateTime? selected_UQuery_Entry_Date;
        public static string ChanelID = string.Empty;
        public static string ChannelType = string.Empty;
        
        // Money Withdrawal
       
       private int? selected_MWithdrawal_Request_Id;
       private string selected_MWithdrawal_Customer_Id;
       private DateTime? selected_MWithdrawal_Request_Date;
       private string selected_MWithdrawal_Request_Type;
       private string selected_MWithdrawal_Cheque_Collection_Branch;
       private string selected_MWithdrawal_Delivery_Date;

       private double? selected_MWithdrawal_Amount;
       private string selected_MWithdrawal_Status;
       private string selected_MWithdrawal_Remarks;
       private DateTime? selected_MWithdrawal_Entry_Date;

       //Service Registration

       private string selected_SReg_Cust_Code;
       private int? selected_SReg_Web_Registration;  
       private int? selected_SReg_SMS_Confirmation;
       private int? selected_SReg_SMS_Trade;
       private int? selected_SReg_SMS_MoneyDeposit_Confirmation;
       private int? selected_SReg_SMS_MoneyWithdraw_Confirmation;
       private int? selected_SReg_SMS_EFTWithdraw_Confirmation;
       

       public List<KeyValuePair<string, string>> Form_TransactionIDs;
        
        //-------------------------

       private enum FormState { UserQuery, MoneryWithdrawal, ServiceRegistration };
        
        public frmWeb2014DataForward()
        {
            InitializeComponent();
        }

        public frmWeb2014DataForward(string menuName)
        {
            InitializeComponent();
            MenuName = menuName;

        }
        private void frmWeb2014DataForward_Load(object sender, EventArgs e)
        {
            LoadGridData(MenuName);

            if (MenuName == UserQuery_Forward)
                FormStateExecution(FormState.UserQuery);
            else if (MenuName == MoneryWithdrawal_Forward_PaymentPosting)
                FormStateExecution(FormState.MoneryWithdrawal);
            else if (MenuName == EFT_PaymentPosting_Table)
                FormStateExecution(FormState.MoneryWithdrawal);
            else if (MenuName == MoneryWithdrawal_Forward_PaymentPosting_Table)
                FormStateExecution(FormState.MoneryWithdrawal);
            else if (MenuName == MoneryWithdrawal_Forward_CheckRequisition)
                FormStateExecution(FormState.MoneryWithdrawal);
            else if (MenuName == ServiceRegistration_Forward)
                FormStateExecution(FormState.ServiceRegistration);
            
        }

        private void LoadGridData(string menuName)
        {
            DataTable datatable=new DataTable();
            Web2014DataForwardBAL bal = new Web2014DataForwardBAL();
            Form_TransactionIDs = new List<KeyValuePair<string, string>>();

            if (menuName == UserQuery_Forward)
            {
                datatable = bal.GetData_Web2014_GetNewUserQuery_Temp();
                dtgDepositInfo.MultiSelect = false;
            }
            else if (menuName == MoneryWithdrawal_Forward_PaymentPosting)
            {
                datatable = bal.GetData_Web2014_GetNewWithdrawalRequest_Temp_PaymentPosting();
                dtgDepositInfo.MultiSelect = false;
            }
            else if (menuName == MoneryWithdrawal_Forward_PaymentPosting_Table)
            {
                datatable = bal.GetData_Withdraw_PaymentPosting();
                dtgDepositInfo.MultiSelect = false;
            }
            else if (menuName == EFT_PaymentPosting_Table)
            {
                datatable = bal.GetData_EFT_PaymentPosting();
                dtgDepositInfo.MultiSelect = false;
            }
            else if (menuName == MoneryWithdrawal_Forward_CheckRequisition)
            {
                datatable = bal.GetData_Web2014_GetNewWithdrawalRequest_Temp_CheckRequisition();
                dtgDepositInfo.MultiSelect = false;
            }
            else if (menuName == ServiceRegistration_Forward)
            {
                datatable = bal.GetData_Web2014_GetAllServiceRegistration_Temp();
                dtgDepositInfo.MultiSelect = true;
            }            
            dtgDepositInfo.DataSource = datatable; 
            //SetColumnWidth();
            //SetRowColor();
            FormattingTable(menuName);
            lblTotalDep.Text = "Total Deposit : " + dtgDepositInfo.Rows.Count.ToString();
        }

        //private void SetColumnWidth()
        //{
        //    dtgDepositInfo.Columns["Cust"].Width = 60;
        //    dtgDepositInfo.Columns["Amount"].Width = 70;
        //    dtgDepositInfo.Columns["P.Media"].Width =90;
        //    dtgDepositInfo.Columns["T.Type"].Width = 60;
        //    dtgDepositInfo.Columns["Voucher"].Width = 60;
        //    dtgDepositInfo.Columns["Recv.Date"].Width = 75;
        //    dtgDepositInfo.Columns["Cheq.No"].Width = 60;
        //    dtgDepositInfo.Columns["Cheq.Date"].Width = 75;
        //    dtgDepositInfo.Columns["Bank"].Width = 150;
        //    dtgDepositInfo.Columns["Branch"].Width = 150;
        //    dtgDepositInfo.Columns["Rout.No"].Width = 65;
        //    dtgDepositInfo.Columns["AccNo"].Width = 100;
        //    dtgDepositInfo.Columns["Recv.By"].Width = 70;
        //    dtgDepositInfo.Columns["Remarks"].Width = 60;                   
        //    dtgDepositInfo.Columns["Status"].Width = 60;
        //    dtgDepositInfo.Columns["Dep.Branch"].Width = 70;
        //}

        private void FormattingTable(string menuName)
        {
            
            if (menuName == ServiceRegistration_Forward)
            {
                dtgDepositInfo.Columns["Web_Service_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["SMS_Confirmation_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["SMS_Trade_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["SMS_MoneyDeposit_Confirmation_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["SMS_MoneyWithdraw_Confirmation_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["SMS_EFTWithdraw_Confirmation_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["Email_MoneyDeposit_Confirmation_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["Email_MoneyWithdraw_Confirmation_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["Email_EftWithdraw_Confirmation_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["Email_Trade_Confirmation_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["Email_ChangeIndicator"].Visible = false;
                dtgDepositInfo.Columns["Mobile No_ChangeIndicator"].Visible = false;
                //dtgDepositInfo.Columns["Comment"].Visible = false;
                
                dtgDepositInfo.Columns["Cust_Code"].HeaderText = "Cust Code";
                dtgDepositInfo.Columns["Cust_Code"].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft San Serif", 8.25F, FontStyle.Bold);
                dtgDepositInfo.Columns["Web_Service"].HeaderText = "Web";
                dtgDepositInfo.Columns["Web_Service"].Width = 80;
                dtgDepositInfo.Columns["SMS_Confirmation"].HeaderText = "SMS Confirmation";
                dtgDepositInfo.Columns["SMS_Confirmation"].Width = 100;
                dtgDepositInfo.Columns["SMS_Trade"].HeaderText = "SMS Trade";
                dtgDepositInfo.Columns["SMS_Trade"].Width = 100;
                dtgDepositInfo.Columns["SMS_MoneyDeposit_Confirmation"].HeaderText = "SMS Deposit";
                dtgDepositInfo.Columns["SMS_MoneyDeposit_Confirmation"].Width = 100;
                dtgDepositInfo.Columns["SMS_MoneyWithdraw_Confirmation"].HeaderText = "SMS Withdraw";
                dtgDepositInfo.Columns["SMS_MoneyWithdraw_Confirmation"].Width = 100;
                dtgDepositInfo.Columns["SMS_EFTWithdraw_Confirmation"].HeaderText = "SMS Eft Withdraw";
                dtgDepositInfo.Columns["SMS_EFTWithdraw_Confirmation"].Width = 120;
                dtgDepositInfo.Columns["Email_MoneyDeposit_Confirmation"].HeaderText = "Email Deposit";
                dtgDepositInfo.Columns["Email_MoneyDeposit_Confirmation"].Width = 100;
                dtgDepositInfo.Columns["Email_MoneyWithdraw_Confirmation"].HeaderText = "Email Withdraw";
                dtgDepositInfo.Columns["Email_MoneyWithdraw_Confirmation"].Width = 100;
                dtgDepositInfo.Columns["Email_EftWithdraw_Confirmation"].HeaderText = "Email Eft Withdraw";
                dtgDepositInfo.Columns["Email_EftWithdraw_Confirmation"].Width = 120;
                dtgDepositInfo.Columns["Email_Trade_Confirmation"].HeaderText = "Email Confirmation";
                dtgDepositInfo.Columns["Email_Trade_Confirmation"].Width = 100;
                dtgDepositInfo.Columns["Email"].HeaderText = "Email";
                dtgDepositInfo.Columns["Email"].Width = 180;
                dtgDepositInfo.Columns["Mobile No"].HeaderText = "Mobile";
                dtgDepositInfo.Columns["Mobile No"].Width = 80;
                dtgDepositInfo.Columns["Comment"].HeaderText = "Comment";
                dtgDepositInfo.Columns["Comment"].Width = 120;
                
                foreach (DataGridViewRow dgvRow in dtgDepositInfo.Rows)
                {
                    if (double.Parse(dgvRow.Cells["Web_Service_ChangeIndicator"].Value.ToString())==1)
                    {
                        dgvRow.Cells["Web_Service"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["Web_Service"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["Web_Service"].Style.ForeColor = Color.White;                       
                    }
                    else if (double.Parse(dgvRow.Cells["SMS_Confirmation_ChangeIndicator"].Value.ToString()) == 1)
                    {
                        dgvRow.Cells["SMS_Confirmation"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_Confirmation"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_Confirmation"].Style.ForeColor = Color.White;
                       
                    }
                    else if (double.Parse(dgvRow.Cells["SMS_Trade_ChangeIndicator"].Value.ToString())== 1)
                    {
                        dgvRow.Cells["SMS_Trade"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_Trade"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_Trade"].Style.ForeColor = Color.White;
                        
                    }
                    else if (double.Parse(dgvRow.Cells["SMS_MoneyDeposit_Confirmation_ChangeIndicator"].Value.ToString()) == 1)
                    {
                        dgvRow.Cells["SMS_MoneyDeposit_Confirmation"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_MoneyDeposit_Confirmation"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_MoneyDeposit_Confirmation"].Style.ForeColor = Color.White;
                        
                    }
                    else if (double.Parse(dgvRow.Cells["SMS_MoneyWithdraw_Confirmation_ChangeIndicator"].Value.ToString()) == 1)
                    {
                        dgvRow.Cells["SMS_MoneyWithdraw_Confirmation"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_MoneyWithdraw_Confirmation"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_MoneyWithdraw_Confirmation"].Style.ForeColor = Color.White;
                        
                    }
                    else if (double.Parse(dgvRow.Cells["SMS_EFTWithdraw_Confirmation_ChangeIndicator"].Value.ToString()) == 1)
                    {
                        dgvRow.Cells["SMS_EFTWithdraw_Confirmation"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_EFTWithdraw_Confirmation"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["SMS_EFTWithdraw_Confirmation"].Style.ForeColor = Color.White;

                        
                    }
                    else if (double.Parse(dgvRow.Cells["Email_MoneyDeposit_Confirmation_ChangeIndicator"].Value.ToString()) == 1)
                    {
                        dgvRow.Cells["Email_MoneyDeposit_Confirmation"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["Email_MoneyDeposit_Confirmation"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["Email_MoneyDeposit_Confirmation"].Style.ForeColor = Color.White;
                        
                    }
                    else if (double.Parse(dgvRow.Cells["Email_MoneyWithdraw_Confirmation_ChangeIndicator"].Value.ToString()) == 1)
                    {
                        dgvRow.Cells["Email_MoneyWithdraw_Confirmation"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["Email_MoneyWithdraw_Confirmation"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["Email_MoneyWithdraw_Confirmation"].Style.ForeColor = Color.White;
                        
                    }
                    else if (double.Parse(dgvRow.Cells["Email_EftWithdraw_Confirmation_ChangeIndicator"].Value.ToString()) == 1)
                    {
                        dgvRow.Cells["Email_EftWithdraw_Confirmation"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["Email_EftWithdraw_Confirmation"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["Email_EftWithdraw_Confirmation"].Style.ForeColor = Color.White;
                        
                    }
                    else if (double.Parse(dgvRow.Cells["Email_Trade_Confirmation_ChangeIndicator"].Value.ToString()) == 1)
                    {
                        dgvRow.Cells["Email_Trade_Confirmation"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["Email_Trade_Confirmation"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["Email_Trade_Confirmation"].Style.ForeColor = Color.White;
                        
                    }
                    else if (double.Parse(dgvRow.Cells["Email_ChangeIndicator"].Value.ToString())== 1)
                    {
                        dgvRow.Cells["Email"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["Email"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["Email"].Style.ForeColor = Color.White;
                        
                    }
                    else if (double.Parse(dgvRow.Cells["Mobile No_ChangeIndicator"].Value.ToString()) == 1)
                    {
                        dgvRow.Cells["Mobile No"].Style.BackColor = Color.LightYellow;
                        dgvRow.Cells["Mobile No"].Style.SelectionBackColor = Color.LightYellow;
                        dgvRow.Cells["Mobile No"].Style.ForeColor = Color.White;
                        
                    }
                }
            }
            
        }

        private void FormStateExecution(FormState fs)
        {
            switch (fs)
            {
                case FormState.UserQuery:
                    btnFetch.Enabled = false;
                    btnForward.Enabled = true;
                    btnForwardAll.Enabled = false;
                    btnForward.Text = "Done";
                    btn_Reject.Enabled = true;
                    btn_Reject.Text = "Delete";
                    break;
                case FormState.MoneryWithdrawal:
                    btnFetch.Enabled = true;
                    btnForward.Enabled = true;
                    btnForwardAll.Enabled = false;
                    btnForward.Text = "Forward";
                    btn_Reject.Enabled = true;
                    break;
                case FormState.ServiceRegistration:
                    btnFetch.Enabled = false;
                    btnForward.Enabled = true;
                    btnForwardAll.Enabled = false;
                    btnForward.Text = "Update";
                    btn_Reject.Enabled = false;
                    break;
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            try
            {
                int intTryParse;
                double doubleTryParse;
                DateTime dateTimeTryParse;
                Web2014DataForwardBAL bal = new Web2014DataForwardBAL();

                switch (MenuName)
                {
                    case UserQuery_Forward:
                            bal.ForwardTo_Web2014_UserQuery(Convert.ToInt32(selected_UQuery_Contact_Us_Id));
                            MessageBox.Show("Data Recorded Successfully");
                            LoadGridData(MenuName);    
                        break;

					case MoneryWithdrawal_Forward_PaymentPosting:

                        if (dtgDepositInfo.SelectedRows[0].Cells["Media_Type"].Value.ToString().ToLower() == ("SMS").ToLower() || dtgDepositInfo.SelectedRows[0].Cells["Media_Type"].Value.ToString().ToLower() == ("Email").ToLower())
                            {
                                for (int i = 0; i <= dtgDepositInfo.Rows.Count; i++)
                                {
                                    if (dtgDepositInfo.Rows[i].Selected == true)
                                    {
                                        Payment_PostingBO bo = new Payment_PostingBO();
                                        bo.Cust_Code = dtgDepositInfo.Rows[i].Cells["Customer_Id"].Value.ToString();
                                        if (double.TryParse(dtgDepositInfo.Rows[i].Cells["Amount"].Value.ToString(), out doubleTryParse))
                                            bo.Amount = doubleTryParse;
                                        if (DateTime.TryParse(dtgDepositInfo.Rows[i].Cells["Request_Date"].Value.ToString(), out dateTimeTryParse))
                                            bo.Received_Date = dateTimeTryParse;
                                        if (DateTime.TryParse(dtgDepositInfo.Rows[i].Cells["Request_Date"].Value.ToString(), out dateTimeTryParse))
                                            bo.OnlineEntry_Date = dateTimeTryParse;
                                        bo.Payment_Media = dtgDepositInfo.Rows[i].Cells["Money_TransactionType_Name"].Value.ToString();
                                        ChanelID = (dtgDepositInfo.Rows[i].Cells["Request_Id"].Value.ToString());
                                        ChannelType = dtgDepositInfo.Rows[i].Cells["Media_Type"].Value.ToString();
                                        bo.Deposit_Withdraw = dtgDepositInfo.Rows[i].Cells["Deposit_Withdraw"].Value.ToString();
                                        bo.Cheque_Number = dtgDepositInfo.Rows[i].Cells["Cheque_Number"].Value.ToString();
                                        bo.Channel = ChannelType;
                                        bo.OnlineOrderNo = Convert.ToInt32(ChanelID);
                                        pp_Delegate(bo);
                                        LoadGridData(MenuName);
                                        this.Close();
                                    }
                                }                              
                            }                       

                            
                            else
                            {

                                DataTable dt = bal.GetData_AsSBPCompitable(Convert.ToInt32(selected_MWithdrawal_Request_Id));
                                Payment_PostingBO bo = new Payment_PostingBO();
                                if (dt.Rows.Count > 0)
                                {
                                    bo.Payment_ID =dt.Rows[0]["Payment_ID"].ToString();
                                    bo.Cust_Code = dt.Rows[0]["Customer_Id"].ToString();
                                    if (double.TryParse(dt.Rows[0]["Amount"].ToString(), out doubleTryParse))
                                        bo.Amount = doubleTryParse;
                                    if (DateTime.TryParse(dt.Rows[0]["Received_Date"].ToString(), out dateTimeTryParse))
                                        bo.Received_Date = dateTimeTryParse;
                                    bo.Payment_Media = dt.Rows[0]["Payment_Media"].ToString();
                                    bo.Deposit_Withdraw = dt.Rows[0]["Deposit_Withdraw"].ToString();
                                    bo.Vouchar_SN = dt.Rows[0]["Vouchar_SN"].ToString();
                                    if (int.TryParse(dt.Rows[0]["Approval_Status"].ToString(), out intTryParse))
                                        bo.Approval_Status = intTryParse;
                                    bo.Remarks = dt.Rows[0]["Remarks"].ToString();
                                    if (DateTime.TryParse(dt.Rows[0]["Entry_Date"].ToString(), out dateTimeTryParse))
                                        bo.OnlineEntry_Date = dateTimeTryParse;

                                    bo.Entry_By = GlobalVariableBO._userName;
                                    bo.Entry_Branch_ID = GlobalVariableBO._branchId;
                                    if (int.TryParse(dt.Rows[0]["OnlineOrderNo"].ToString(), out intTryParse))
                                        bo.OnlineOrderNo = intTryParse;
                                    pp_Delegate(bo);
                                    MessageBox.Show("Data Forwarded Successfully");
                                    LoadGridData(MenuName);
                                    this.Close();
                                }
                            }
                        break;
                    case MoneryWithdrawal_Forward_PaymentPosting_Table:
                        for (int i = 0; i <= dtgDepositInfo.Rows.Count; i++)
                        {
                            if (dtgDepositInfo.Rows[i].Selected == true)
                            {
                                Payment_PostingBO bo = new Payment_PostingBO();
                                bo.Cust_Code = dtgDepositInfo.Rows[i].Cells["Customer_Id"].Value.ToString();
                                if (double.TryParse(dtgDepositInfo.Rows[i].Cells["Amount"].Value.ToString(), out doubleTryParse))
                                    bo.Amount = doubleTryParse;
                                if (DateTime.TryParse(dtgDepositInfo.Rows[i].Cells["Request_Date"].Value.ToString(), out dateTimeTryParse))
                                    bo.Received_Date = dateTimeTryParse;
                                if (DateTime.TryParse(dtgDepositInfo.Rows[i].Cells["Request_Date"].Value.ToString(), out dateTimeTryParse))
                                    bo.OnlineEntry_Date = dateTimeTryParse;
                                bo.Payment_Media = dtgDepositInfo.Rows[i].Cells["Money_TransactionType_Name"].Value.ToString();
                                ChanelID = (dtgDepositInfo.Rows[i].Cells["Request_Id"].Value.ToString());
                                ChannelType = dtgDepositInfo.Rows[i].Cells["Media_Type"].Value.ToString();
                                bo.Deposit_Withdraw = dtgDepositInfo.Rows[i].Cells["Deposit_Withdraw"].Value.ToString();
                                bo.Cheque_Number = dtgDepositInfo.Rows[i].Cells["Cheque_Number"].Value.ToString();
                                bo.Channel = ChannelType;
                                bo.Received_By = GlobalVariableBO._userName;
                                bo.OnlineOrderNo = Convert.ToInt32(ChanelID);
                                pp_Delegate(bo);
                                LoadGridData(MenuName);
                                this.Close();
                            }
                        }
                        break;


                    case EFT_PaymentPosting_Table:
                        for (int i = 0; i <= dtgDepositInfo.Rows.Count; i++)
                                {
                                    if (dtgDepositInfo.Rows[i].Selected == true)
                                    {
                                        Payment_PostingBO bo_eft = new Payment_PostingBO();
                                        bo_eft.Cust_Code = dtgDepositInfo.Rows[i].Cells["Customer_Id"].Value.ToString();
                                        if (double.TryParse(dtgDepositInfo.Rows[i].Cells["Amount"].Value.ToString(), out doubleTryParse))
                                            bo_eft.Amount = doubleTryParse;
                                        if (DateTime.TryParse(dtgDepositInfo.Rows[i].Cells["Request_Date"].Value.ToString(), out dateTimeTryParse))
                                            bo_eft.Received_Date = dateTimeTryParse;
                                        if (DateTime.TryParse(dtgDepositInfo.Rows[i].Cells["Request_Date"].Value.ToString(), out dateTimeTryParse))
                                            bo_eft.OnlineEntry_Date = dateTimeTryParse;
                                        bo_eft.Payment_Media = dtgDepositInfo.Rows[i].Cells["Money_TransactionType_Name"].Value.ToString();
                                        ChanelID = (dtgDepositInfo.Rows[i].Cells["Request_Id"].Value.ToString());
                                        ChannelType = dtgDepositInfo.Rows[i].Cells["Media_Type"].Value.ToString();
                                        bo_eft.Deposit_Withdraw = dtgDepositInfo.Rows[i].Cells["Deposit_Withdraw"].Value.ToString();
                                        bo_eft.Channel = ChannelType;
                                        bo_eft.OnlineOrderNo = Convert.ToInt32(ChanelID);
                                        pp_Delegate(bo_eft);
                                        LoadGridData(MenuName);
                                        this.Close();
                                    }
                                }             
                        break;
                    
                    case MoneryWithdrawal_Forward_CheckRequisition:

                        if (dtgDepositInfo.SelectedRows[0].Cells["Media_Type"].Value.ToString().ToLower() == ("SMS").ToLower() || dtgDepositInfo.SelectedRows[0].Cells["Media_Type"].Value.ToString().ToLower() == ("Email").ToLower())
                        {
                            for (int i = 0; i <= dtgDepositInfo.Rows.Count; i++)
                            {
                                if (dtgDepositInfo.Rows[i].Selected == true)
                                {
                                    CheckRequisitionBO bo_check = new CheckRequisitionBO();
                                    bo_check.CustCode = dtgDepositInfo.Rows[i].Cells["Customer_Id"].Value.ToString();
                                    if (double.TryParse(dtgDepositInfo.Rows[i].Cells["Amount"].Value.ToString(), out doubleTryParse))
                                        bo_check.Amount = doubleTryParse;
                                    if (DateTime.TryParse(dtgDepositInfo.Rows[i].Cells["Request_Date"].Value.ToString(), out dateTimeTryParse))
                                        bo_check.RequisitionDate = dateTimeTryParse;
                                    if (DateTime.TryParse(dtgDepositInfo.Rows[i].Cells["Request_Date"].Value.ToString(), out dateTimeTryParse))
                                        bo_check.OnlineEntry_Date = dateTimeTryParse;
                                    bo_check.Payment_Media = dtgDepositInfo.Rows[i].Cells["Money_TransactionType_Name"].Value.ToString();
                                    ChanelID = (dtgDepositInfo.Rows[i].Cells["Request_Id"].Value.ToString());
                                    ChannelType = dtgDepositInfo.Rows[i].Cells["Media_Type"].Value.ToString();
                                    bo_check.Deposit_Withdraw = dtgDepositInfo.Rows[i].Cells["Deposit_Withdraw"].Value.ToString();
                                    bo_check.Channel = ChannelType;
                                    bo_check.OnlineOrderNo = Convert.ToInt32(ChanelID);
                                    cr_Delegate(bo_check);
                                    LoadGridData(MenuName);
                                    this.Close();
                                }
                            }
                        }

                        else
                        {

                            DataTable dt_check = bal.GetData_AsSBPCompitable(Convert.ToInt32(selected_MWithdrawal_Request_Id));
                            CheckRequisitionBO bo_check = new CheckRequisitionBO();

                            if (dt_check.Rows.Count > 0)
                            {
                                bo_check.CustCode = Convert.ToString(dt_check.Rows[0]["Cust_Code"]);
                                if (double.TryParse(dt_check.Rows[0]["Amount"].ToString(), out doubleTryParse))
                                    bo_check.Amount = (float)doubleTryParse;
                                if (DateTime.TryParse(dt_check.Rows[0]["Requisition_Date"].ToString(), out dateTimeTryParse))
                                    bo_check.RequisitionDate = dateTimeTryParse;
                                if (int.TryParse(dt_check.Rows[0]["Collection_Branch_ID"].ToString(), out intTryParse))
                                    bo_check.BranchId = intTryParse;
                                bo_check.Remarks = dt_check.Rows[0]["Remarks"].ToString();
                                if (DateTime.TryParse(dt_check.Rows[0]["Entry_Date"].ToString(), out dateTimeTryParse))
                                    bo_check.OnlineEntry_Date = dateTimeTryParse;
                                if (int.TryParse(dt_check.Rows[0]["OnlineOrderNo"].ToString(), out intTryParse))
                                    bo_check.OnlineOrderNo = intTryParse;
                                cr_Delegate(bo_check);
                                MessageBox.Show("Data Forwarded Successfully");
                                LoadGridData(MenuName);
                                this.Close();
                            }
                        }
                        break;
                    case ServiceRegistration_Forward:
                            bal.FrowardTo_ServiceRegistration(Convert.ToString(selected_SReg_Cust_Code));
                            Form_TransactionIDs.Add(new KeyValuePair<string, string>(MenuName,selected_SReg_Cust_Code));
                            RealTimeExportSMSServer_MoneyTransaction();
                            MessageBox.Show("Data Registered Successfully");
                            LoadGridData(MenuName);

                            
                            
                        break;
                }  
            }
            catch (Exception ex)
            {
               MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);
            }
        }
           
        private void btnAcceptAll_Click(object sender, EventArgs e)
        {
           
        }      

        private void dtgSelectionIndexChange(int ColumnIndex, int RowIndex)
        {
            double doubleTryParse;
            DateTime dateTimeTryParse;
            int intTryParse;
            
            var obj = dtgDepositInfo.Rows[RowIndex];

            switch (MenuName)
            {
                case UserQuery_Forward:
                        
                        //Refresh
                        selected_UQuery_Contact_Us_Id=null;
                        selected_UQuery_From_Email_Address=string.Empty;
                        selected_UQuery_Contact_To=string.Empty;
                        selected_UQuery_Contact_Subject=string.Empty;
                        selected_UQuery_Contact_Message=string.Empty;
                        selected_UQuery_Contact_Date=null;
                        selected_UQuery_Contact_Status=string.Empty;
                        selected_UQuery_Entry_Date=null;
        

                        //Data Casting
                        if (int.TryParse(Convert.ToString(obj.Cells["Contact_Us_Id"].Value), out intTryParse))
                            selected_UQuery_Contact_Us_Id = intTryParse;
                        selected_UQuery_From_Email_Address = Convert.ToString(obj.Cells["From_Email_Address"].Value);
                        selected_UQuery_Contact_To = Convert.ToString(obj.Cells["Contact_To"].Value);
                        selected_UQuery_Contact_Subject = Convert.ToString(obj.Cells["Contact_Subject"].Value);
                        selected_UQuery_Contact_Message = Convert.ToString(obj.Cells["Contact_Message"].Value);
                        if (DateTime.TryParse(Convert.ToString(obj.Cells["Contact_Date"].Value), out dateTimeTryParse))
                            selected_UQuery_Contact_Date = dateTimeTryParse;
                        if (DateTime.TryParse(Convert.ToString(obj.Cells["Entry_Date"].Value), out dateTimeTryParse))
                            selected_UQuery_Entry_Date = dateTimeTryParse; 
                        selected_UQuery_Contact_Status=Convert.ToString(obj.Cells["Contact_Status"].Value);

                        frmUserQueryDetailsViewer frm = new frmUserQueryDetailsViewer();
                        frm.QueryText = selected_UQuery_Contact_Message;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.ShowDialog(this);
                        
                    break;

                case MoneryWithdrawal_Forward_PaymentPosting:

                       //Refresh 
                       selected_MWithdrawal_Request_Id=null;
                       selected_MWithdrawal_Customer_Id=string.Empty;
                       selected_MWithdrawal_Request_Date=null;
                       selected_MWithdrawal_Request_Type=string.Empty;
                       selected_MWithdrawal_Cheque_Collection_Branch = string.Empty;
                       selected_MWithdrawal_Delivery_Date=null;
                      
                       selected_MWithdrawal_Amount=0;
                       selected_MWithdrawal_Status=string.Empty;
                       selected_MWithdrawal_Remarks=string.Empty;
                       selected_MWithdrawal_Entry_Date=null;

                       //Data Casting
                       if (int.TryParse(Convert.ToString(obj.Cells["Request_Id"].Value), out intTryParse))
                           selected_MWithdrawal_Request_Id = intTryParse;
                       selected_MWithdrawal_Customer_Id = Convert.ToString(obj.Cells["Customer_Id"].Value);
                       if (DateTime.TryParse(Convert.ToString(obj.Cells["Request_Date"].Value), out dateTimeTryParse))
                           selected_MWithdrawal_Request_Date = dateTimeTryParse;
                       selected_MWithdrawal_Request_Type = Convert.ToString(obj.Cells["Request_Type"].Value);
                       selected_MWithdrawal_Cheque_Collection_Branch = Convert.ToString(obj.Cells["Cheque_Collection_Branch"].Value);
                       selected_MWithdrawal_Delivery_Date = Convert.ToString(obj.Cells["Delivery_Date"].Value);
                       if (double.TryParse(Convert.ToString(obj.Cells["Amount"].Value), out doubleTryParse))
                           selected_MWithdrawal_Amount = doubleTryParse;
                       selected_MWithdrawal_Status = Convert.ToString(obj.Cells["Status"].Value);
                       selected_MWithdrawal_Remarks = Convert.ToString(obj.Cells["Remarks"].Value);
                       if (DateTime.TryParse(Convert.ToString(obj.Cells["Entry_Date"].Value), out dateTimeTryParse))
                           selected_MWithdrawal_Entry_Date = dateTimeTryParse;    
                                 
                    break;

                case MoneryWithdrawal_Forward_CheckRequisition:

                    //Refresh 
                    selected_MWithdrawal_Request_Id = null;
                    selected_MWithdrawal_Customer_Id = string.Empty;
                    selected_MWithdrawal_Request_Date = null;
                    selected_MWithdrawal_Request_Type = string.Empty;
                    selected_MWithdrawal_Cheque_Collection_Branch = string.Empty;
                    selected_MWithdrawal_Delivery_Date = null;

                    selected_MWithdrawal_Amount = 0;
                    selected_MWithdrawal_Status = string.Empty;
                    selected_MWithdrawal_Remarks = string.Empty;
                    selected_MWithdrawal_Entry_Date = null;

                    //Data Casting
                    if (int.TryParse(Convert.ToString(obj.Cells["Request_Id"].Value), out intTryParse))
                        selected_MWithdrawal_Request_Id = intTryParse;
                    selected_MWithdrawal_Customer_Id = Convert.ToString(obj.Cells["Customer_Id"].Value);
                    if (DateTime.TryParse(Convert.ToString(obj.Cells["Request_Date"].Value), out dateTimeTryParse))
                        selected_MWithdrawal_Request_Date = dateTimeTryParse;
                    selected_MWithdrawal_Request_Type = Convert.ToString(obj.Cells["Request_Type"].Value);
                    selected_MWithdrawal_Cheque_Collection_Branch = Convert.ToString(obj.Cells["Cheque_Collection_Branch"].Value);
                    selected_MWithdrawal_Delivery_Date = Convert.ToString(obj.Cells["Delivery_Date"].Value);
                    if (double.TryParse(Convert.ToString(obj.Cells["Amount"].Value), out doubleTryParse))
                        selected_MWithdrawal_Amount = doubleTryParse;
                    selected_MWithdrawal_Status = Convert.ToString(obj.Cells["Status"].Value);
                    selected_MWithdrawal_Remarks = Convert.ToString(obj.Cells["Remarks"].Value);
                    if (DateTime.TryParse(Convert.ToString(obj.Cells["Entry_Date"].Value), out dateTimeTryParse))
                        selected_MWithdrawal_Entry_Date = dateTimeTryParse;

                    break;

                case ServiceRegistration_Forward:

                       //Refresh
                   
                       selected_SReg_Cust_Code=string.Empty;
                       selected_SReg_SMS_Confirmation=null;
                       selected_SReg_SMS_Trade = null;
                       selected_SReg_SMS_MoneyDeposit_Confirmation=null;
                       selected_SReg_SMS_MoneyWithdraw_Confirmation=null;
                       selected_SReg_SMS_EFTWithdraw_Confirmation=null;
                       selected_SReg_Web_Registration = null;
                   
                        //Data Casting
                   
                       selected_SReg_Cust_Code = obj.Cells["Cust_Code"].Value.ToString();
                       if (int.TryParse(Convert.ToString(obj.Cells["Web_Service"].Value), out intTryParse))
                           selected_SReg_Web_Registration = intTryParse;
                       if (int.TryParse(Convert.ToString(obj.Cells["SMS_Confirmation"].Value), out intTryParse))
                           selected_SReg_SMS_Confirmation = intTryParse;
                       if (int.TryParse(Convert.ToString(obj.Cells["SMS_Trade"].Value), out intTryParse))
                           selected_SReg_SMS_Trade = intTryParse;
                       if (int.TryParse(Convert.ToString(obj.Cells["SMS_MoneyDeposit_Confirmation"].Value), out intTryParse))
                           selected_SReg_SMS_MoneyDeposit_Confirmation = intTryParse;
                       if (int.TryParse(Convert.ToString(obj.Cells["SMS_MoneyWithdraw_Confirmation"].Value), out intTryParse))
                           selected_SReg_SMS_MoneyWithdraw_Confirmation = intTryParse;
                       if (int.TryParse(Convert.ToString(obj.Cells["SMS_EFTWithdraw_Confirmation"].Value), out intTryParse))
                           selected_SReg_SMS_EFTWithdraw_Confirmation = intTryParse;                   
                            
                    break;
            }
        }

        private void dtgDepositInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtgSelectionIndexChange( e.ColumnIndex,e.RowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Reject_Click(object sender, EventArgs e)
        {
            try
            {
                int intTryParse;
                double doubleTryParse;
                DateTime dateTimeTryParse;
                Web2014DataForwardBAL bal = new Web2014DataForwardBAL();
                string media = string.Empty;
                DataGridViewRow Value = dtgDepositInfo.SelectedRows[0];
                if (dtgDepositInfo.SelectedRows.Count > 0)
                {
                    media = Value.Cells["Media_Type"].Value.ToString();
                }
                if (MenuName.ToUpper().Trim() == ("Payment Withdraw Forward Payment Posting").ToUpper().Trim())
                {
                    if (media == "")
                        MenuName = "Money Withdraw Forward Payment Posting";
                }
                switch (MenuName)
                {
                    case UserQuery_Forward:
                        bal.RejectedFrom_Web2014_GetNewUserQuery_Temp(Convert.ToInt32(selected_UQuery_Contact_Us_Id));
                        LoadGridData(MenuName);
                        break;
                    case MoneryWithdrawal_Forward_PaymentPosting:
                        bal.RejectedFrom_Web2014_WithdrawalRequest_Temp(Convert.ToInt32(selected_MWithdrawal_Request_Id));
                        LoadGridData(MenuName);
                        break;
                    case MoneryWithdrawal_Forward_CheckRequisition:
                        bal.RejectedFrom_Web2014_WithdrawalRequest_Temp(Convert.ToInt32(selected_MWithdrawal_Request_Id));
                        LoadGridData(MenuName);
                        break;
                    case ServiceRegistration_Forward:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);
            }
        }



        private void RealTimeExportSMSServer_MoneyTransaction()
        {
            SMSSyncBAL bal = new SMSSyncBAL();
            string[] cust_CodeArray = Form_TransactionIDs.Where(t => t.Key == MenuName).Select(t => t.Value).ToArray();

            try
            {

                bal.Connect_SMS();
                bal.Connect_SBP();

                SqlDataReader dr = bal.GetIPO_ServiceRegistration_UITransApplied(cust_CodeArray);
                bal.DeleteData_SMSSyncExport_Confirmation_SMS_Reg_UITransApplied(cust_CodeArray);
                bal.InsertTable_SMSSyncExport_Confirmation_SMS_Reg_UITransApplied(dr);

                bal.Commit_SBP();
                bal.Commit_SMS();
            }
            catch (Exception ex)
            {
                bal.Rollback_SBP();
                bal.Rollback_SMS();
                throw new Exception(ex.Message);
            }
            finally
            {
                bal.CloseConnection_SBP();
                bal.CloseConnection_SMS();
            }

        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            Thread thrd = new Thread(WaitWindow_Thread);
            isProgressed = true;
            thrd.Start();
            SMSSyncBAL syncBal = new SMSSyncBAL();
            try
            {
                DataTable dt_GotAlreadyRequested = new DataTable();
                DataTable dt_GotAlreadyRequested_SingleApplication = new DataTable();
                DataTable dt_GotNewRequest = new DataTable();
                DataTable dt_GotAlreadyRequested_Email = new DataTable();
                DataTable dt_GotAlreadyRequest_Web = new DataTable();
                DataTable dt_GotNewRequest_Web = new DataTable();
                DataTable dt_GotDeposit_Withdraw_SMS = new DataTable();
                DataTable dt_GotDeposit_Withdraw_Email = new DataTable();
               
                

                syncBal.Connect_SBP();
                syncBal.Connect_SMS();

                syncBal.TruncateTable_SMSSyncImportIPORequest_UITransApplied();

                dt_GotAlreadyRequested = syncBal.GetProcessedIPORequest_UITransApplied();
                //dt_GotNewRequest = syncBal.GetNewIPORequest_UITransApplied(dt_GotAlreadyRequested);
                dt_GotAlreadyRequested_Email = syncBal.GetProcessedIPORequest_UITransApplied_Email();
                dt_GotDeposit_Withdraw_SMS = syncBal.GetProcessedDeposit_Withdraw_Request_SMS();
                dt_GotDeposit_Withdraw_Email = syncBal.GetProcessedDeposit_Withdraw_Request_Email();
                //dt_GotAlreadyRequest_Web = syncBal.GetProcessedIPORequest_ForWeb_UITransApplied();
               

                dt_GotNewRequest = syncBal.GetNewIPORequest_UITransApplied(dt_GotAlreadyRequested, dt_GotAlreadyRequested_Email, dt_GotDeposit_Withdraw_SMS, dt_GotDeposit_Withdraw_Email);
                //dt_GotNewRequest_Web = syncBal.GetNewIPORequest_FroWeb_UITransApplied(dt_GotAlreadyRequest_Web);

                syncBal.InsertTable_SMSSyncImportIPORequest_UITransApplied(dt_GotNewRequest);
                //syncBal.InsertTable_SMSSyncImportIPORequest_UITransApplied(dt_GotNewRequest_Web);

                syncBal.Commit_SBP();
                syncBal.Connect_SMS();
                isProgressed = false;
                frmWeb2014DataForward_Load(sender, e);
                MessageBox.Show("Data Imported Successfully!!");
               
            }
            catch (Exception ex)
            {
                syncBal.Rollback_SBP();
                syncBal.Rollback_SMS();
                isProgressed = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                syncBal.CloseConnection_SBP();
                syncBal.CloseConnection_SMS();
            }


            
        }


        private void WaitWindow_Thread()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (isProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }

      

    }
}
