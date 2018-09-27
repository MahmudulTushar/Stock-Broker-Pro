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
    public partial class frm_IPOSMSMoneyTransactionApproval : Form
    {
        public static string[] Cust_Code;
        public static string[] RegisteredCode;
        public static string Money_TransactionType_Name;
        public static double[] Amount;
        public static string Deposit_Withdraw;
        public static string[] TransferCode;
        public static int IPOSessionID;
        public static int LotNo;
        public static int[] SmsId;
        public static int Money_TransactionType_Name_ID;
        public static string[] Remarks;
        public static int RefundType_ID;
        public static string Refund_Name; 
        public static List<KeyValuePair<string,string>> SMSReqID;
        public static string SMSReceiverID;
        public static string[] ApplicationType;
        public static string[] MediaType;
        public static bool isForwarded=false;

        public List<KeyValuePair<string, string>> Form_TransactionIDs; 


        public static DateTime Received_Date;

        private WaitWindow waitWindow;
        public static bool isProgressed;
         
        string Menu_Name = "";

        public static string[] Routing_Number;
        public static string[] Cheque_Number;

        public frm_IPOSMSMoneyTransactionApproval(string Form)
        {
            
            InitializeComponent();
            Menu_Name = Form;
            this.Text = Menu_Name;
            isForwarded = false;
            SMSReqID = new List<KeyValuePair<string, string>>();
            Form_TransactionIDs = new List<KeyValuePair<string, string>>();

        }
         

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IPOMoneyTransactionApproval_Load(object sender, EventArgs e)
        {
            if (Menu_Name == Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_SingleApplication)
            {
                LoadGridData();
                dtgMoneyTransactionForward.Columns["ID"].Visible = false;
                dtgMoneyTransactionForward.Columns["SMSReqID"].Visible = false;
                dtgMoneyTransactionForward.Columns["IPOSessionID"].Visible = false;
                dtgMoneyTransactionForward.Columns["LotNo"].Visible = false;
                dtgMoneyTransactionForward.Columns["RefundType_ID"].Visible = false;
                dtgMoneyTransactionForward.Columns["Money_TransactionType_Name_ID"].Visible = false;
            }
            else if (Menu_Name == Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_Deposit)
            {
                LoadGridData();
                dtgMoneyTransactionForward.Columns["ID"].Visible = false;
                dtgMoneyTransactionForward.Columns["SMSReqID"].Visible = false;
                dtgMoneyTransactionForward.Columns["IPOSessionID"].Visible = false;
                dtgMoneyTransactionForward.Columns["LotNo"].Visible = false;
                dtgMoneyTransactionForward.Columns["RefundType_ID"].Visible = false;
                dtgMoneyTransactionForward.Columns["Money_TransactionType_Name_ID"].Visible = false;
                dtgMoneyTransactionForward.Columns["SelectionID"].Visible = false;
            }
            else if (Menu_Name == Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_Withdraw)
            {
                LoadGridData();
                dtgMoneyTransactionForward.Columns["ID"].Visible = false;
                dtgMoneyTransactionForward.Columns["SMSReqID"].Visible = false;
                dtgMoneyTransactionForward.Columns["IPOSessionID"].Visible = false;
                dtgMoneyTransactionForward.Columns["LotNo"].Visible = false;
                dtgMoneyTransactionForward.Columns["RefundType_ID"].Visible = false;
                dtgMoneyTransactionForward.Columns["Money_TransactionType_Name_ID"].Visible = false;
                dtgMoneyTransactionForward.Columns["SelectionID"].Visible = false;
            }
        }

        public void LoadGridData()
        {
            if (Menu_Name == Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_SingleApplication)
            {
                IPOSMSMoneyTransactionForwardBAL IPOSMS = new IPOSMSMoneyTransactionForwardBAL();
                DataTable datatable = IPOSMS.GetDataLoad_SingleApplication();
                dtgMoneyTransactionForward.DataSource = datatable;
                dtgMoneyTransactionForward.MultiSelect = false;
            }
            else if (Menu_Name == Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_Deposit)
            {
                IPOSMSMoneyTransactionForwardBAL IPOSMS = new IPOSMSMoneyTransactionForwardBAL();
                DataTable datatable = IPOSMS.GetDataLoad_Deposit();
                dtgMoneyTransactionForward.DataSource = datatable;
                dtgMoneyTransactionForward.MultiSelect = true;
            }
            else if (Menu_Name == Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_Withdraw)
            {
                IPOSMSMoneyTransactionForwardBAL IPOSMS = new IPOSMSMoneyTransactionForwardBAL();
                DataTable datatable = IPOSMS.GetDataLoad_Withdraw();
                dtgMoneyTransactionForward.DataSource = datatable;
                dtgMoneyTransactionForward.MultiSelect = true;
            }
            //FormattingTable();
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


        #region Block Code
        private void FormattingTable()
        {
            dtgMoneyTransactionForward.Columns["ID"].HeaderText = "ID";
            dtgMoneyTransactionForward.Columns["ID"].Width = 0;
            dtgMoneyTransactionForward.Columns["Cust_Code"].HeaderText = "Cust_Code";
            dtgMoneyTransactionForward.Columns["Cust_Code"].Width = 100;
            dtgMoneyTransactionForward.Columns["Payment_Media"].HeaderText = "Payment Media";
            dtgMoneyTransactionForward.Columns["Payment_Media"].Width = 120;
            dtgMoneyTransactionForward.Columns["Payment_Media_No"].HeaderText = "Payment Media No";
            dtgMoneyTransactionForward.Columns["Payment_Media_No"].Width = 120;
            dtgMoneyTransactionForward.Columns["Amount"].HeaderText = "Amount";
            dtgMoneyTransactionForward.Columns["Amount"].Width = 150;
            dtgMoneyTransactionForward.Columns["Deposit_Withdraw"].HeaderText = "Deposit Withdraw";
            dtgMoneyTransactionForward.Columns["Deposit_Withdraw"].Width = 100;
            dtgMoneyTransactionForward.Columns["Money_Balance"].HeaderText = "Money Balance";
            dtgMoneyTransactionForward.Columns["Money_Balance"].Width = 100;
            dtgMoneyTransactionForward.Columns["ReferenceNo"].HeaderText = "Reference No";
            dtgMoneyTransactionForward.Columns["ReferenceNo"].Width = 150;
            dtgMoneyTransactionForward.Columns["Destination_No"].HeaderText = "Destination No";
            dtgMoneyTransactionForward.Columns["Destination_No"].Width = 150;
            dtgMoneyTransactionForward.Columns["VoucherNo"].HeaderText = "Voucher No";
            dtgMoneyTransactionForward.Columns["VoucherNo"].Width = 150;
            dtgMoneyTransactionForward.Columns["ChequekBank"].HeaderText = "Cheque Bank";
            dtgMoneyTransactionForward.Columns["ChequekBank"].Width = 150;
            dtgMoneyTransactionForward.Columns["ChequeBranch"].HeaderText = "Cheque Branch";
            dtgMoneyTransactionForward.Columns["ChequeBranch"].Width = 150;
        }
        #endregion

        private void btnForward_Click(object sender, EventArgs e)
        {
            Verification();
            isForwarded = true;
            this.Close();
        }

        private void Verification()
        {
            if (Menu_Name == Indication_IPOPaymentTransaction.SmsRequestType_Single_Application)
            {
               
                
            }
            else
            {
                IPOProcessBAL bal = new IPOProcessBAL();
                if(Cust_Code.Distinct().Count()>1 && TransferCode.Distinct().Count()==1)
                {
                    DataTable dt = bal.GetParentInfo(Cust_Code);
                    if (!(dt.Rows.Count == 1)) 
                        throw new Exception("Account Grouping Problem");
                }

            }
            
        }
 
       
        private void dtgMoneyTransactionForward_DataSourseChange(object sender, EventArgs e)
        {
            lblTotalDep.Text = "Forward List : " + dtgMoneyTransactionForward.Rows.Count;
        }

        private void btn_Reject_Click(object sender, EventArgs e)
        {
            try
            {
                IPOApprovalBAL bal = new IPOApprovalBAL();
                bal.Delete_SMS_Request(SmsId);
                foreach (int tmp in SmsId)
                    Form_TransactionIDs.Add(new KeyValuePair<string, string>(btn_Reject.Name, Convert.ToString(tmp)));

                RealTimeExportSMSServer_MoneyTransaction();
                MessageBox.Show("Sms Data deleted Succussfully");
                LoadGridData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RealTimeExportSMSServer_MoneyTransaction()
        {
           

            SMSSyncBAL syncBal = new SMSSyncBAL();
            DashboardBAL dashBal = new DashboardBAL();

            try
            {
                syncBal.Connect_SBP();
                syncBal.Connect_SMS();

                string[] id=Form_TransactionIDs.Where(t=> t.Key==btn_Reject.Name).Select(t=> t.Value).ToArray();
                SqlDataReader dt_CancelApplicationWithMoneyTransaction = syncBal.GetApplicationList_AllreadyApplied(id);
                syncBal.DeleteData_tbl_IPO_SessionApplications_UITransApplied(id);
                syncBal.InsertTable_IPO_SessionApplications_UITransApplied(dt_CancelApplicationWithMoneyTransaction);

                SqlDataReader dt_CancelFreeTransaction = syncBal.GetData_FreeMoneyTransactionRequest_Status_UITransApplied(id);
                syncBal.DeleteData_FreeMoneyTransactionRequest_UITransApplied(id);
                syncBal.InsertTable_IPO_SessionApplications_UITransApplied(dt_CancelFreeTransaction);
              
                syncBal.Commit_SBP();
                syncBal.Commit_SMS();
            }
            catch (Exception ex)
            {
                syncBal.Rollback_SBP();
                syncBal.Rollback_SMS();
            }
            finally
            {
                syncBal.CloseConnection_SBP();
                syncBal.CloseConnection_SMS();
            }

        }


        private void dtgMoneyTransactionForward_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string SelectionID;

            if (dtgMoneyTransactionForward.SelectedRows.Count > 0)
            {
                if (Menu_Name == Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_Deposit)
                {
                    SelectionID = Convert.ToString(dtgMoneyTransactionForward.SelectedRows[0].Cells["SelectionID"].Value);
                    Multi_Selection(SelectionID);
                }
               
                //Casting Selected Rows
                Cust_Code = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Cust_Code"].Value)).ToArray();
                RegisteredCode = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["RegisteredCode"].Value)).ToArray();
                Amount = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToDouble(t.Cells["Amount"].Value)).ToArray();
                TransferCode = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["TransferCode"].Value)).ToArray();
                SmsId = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToInt32(t.Cells["ID"].Value)).ToArray();
                Remarks = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Remarks"].Value)).ToArray();
                SMSReqID = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => new KeyValuePair<string,string>(Convert.ToString(t.Cells["Cust_Code"].Value), Convert.ToString(t.Cells["SMSReqID"].Value))).ToList();
                ApplicationType = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["ApplicationType"].Value)).ToArray();
                MediaType = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Media_Type"].Value)).ToArray();

                Money_TransactionType_Name = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Money_TransactionType_Name"].Value)).Distinct().FirstOrDefault();
                Deposit_Withdraw = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Deposit_Withdraw"].Value)).Distinct().FirstOrDefault();
                IPOSessionID = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToInt32(t.Cells["IPOSessionID"].Value)).Distinct().FirstOrDefault();
                LotNo = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => ( Convert.ToInt32(t.Cells["LotNo"].Value) == 0 ? 1 : Convert.ToInt32(t.Cells["LotNo"].Value) )).Distinct().FirstOrDefault();
                Money_TransactionType_Name_ID = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToInt32(t.Cells["Money_TransactionType_Name_ID"].Value)).Distinct().FirstOrDefault();
                RefundType_ID = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToInt32(t.Cells["RefundType_ID"].Value)).Distinct().FirstOrDefault();
                Refund_Name = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Refund_Name"].Value)).Distinct().FirstOrDefault();
                SMSReceiverID = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["SMSReceiveID"].Value)).Distinct().FirstOrDefault();
                Cheque_Number = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Cheque_Number"].Value)).ToArray();
                Routing_Number = dtgMoneyTransactionForward.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Routing_Number"].Value)).ToArray();
            }

        }

        private void Multi_Selection(string SelectionID)
        {
            int i=0;
            dtgMoneyTransactionForward.MultiSelect = true;
            foreach (DataGridViewRow dr in dtgMoneyTransactionForward.Rows)
            {
                if (Convert.ToString(dr.Cells["SelectionID"].Value) == SelectionID)
                    dtgMoneyTransactionForward.Rows[i].Selected = true;
                    i++;
            }
            //dtgMoneyTransactionForward.MultiSelect = false;
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

                dt_GotDeposit_Withdraw_SMS = syncBal.GetProcessedDeposit_Withdraw_Request_SMS();
                dt_GotDeposit_Withdraw_Email = syncBal.GetProcessedDeposit_Withdraw_Request_Email();
                
                dt_GotAlreadyRequested = syncBal.GetProcessedIPORequest_UITransApplied();
                //dt_GotNewRequest = syncBal.GetNewIPORequest_UITransApplied(dt_GotAlreadyRequested);
                dt_GotAlreadyRequested_Email = syncBal.GetProcessedIPORequest_UITransApplied_Email();
                dt_GotAlreadyRequest_Web = syncBal.GetProcessedIPORequest_ForWeb_UITransApplied();

                dt_GotNewRequest = syncBal.GetNewIPORequest_UITransApplied(dt_GotAlreadyRequested, dt_GotAlreadyRequested_Email, dt_GotDeposit_Withdraw_SMS, dt_GotDeposit_Withdraw_Email);
                dt_GotNewRequest_Web = syncBal.GetNewIPORequest_FroWeb_UITransApplied(dt_GotAlreadyRequest_Web);
                
                syncBal.InsertTable_SMSSyncImportIPORequest_UITransApplied(dt_GotNewRequest);
                syncBal.InsertTable_SMSSyncImportIPORequest_UITransApplied(dt_GotNewRequest_Web);
                
                syncBal.Commit_SBP();
                syncBal.Connect_SMS();
                isProgressed = false;
                MessageBox.Show("Data Imported Successfully!!");
                LoadGridData();
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
    }
}
