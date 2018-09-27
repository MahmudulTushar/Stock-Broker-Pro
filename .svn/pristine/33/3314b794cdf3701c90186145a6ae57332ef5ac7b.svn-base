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
using Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;

namespace StockbrokerProNewArch
{
    public partial class frm_IPO_Single_ApplicationProcess : Form
    {

        private DataTable dt_EligableCustomer;
        private DataTable dt_AppliedCustomer;

        private int _dGEligibleCustomer_RowIndex;
        private int _dGAppliedCustomer_RowIndex;

        public frm_IPO_Single_ApplicationProcess()
        {
            InitializeComponent();
            
        }
     

        #region Global Variable
        
        int RowCount;
        int Cust_code;
        string SmsApplied_Client_ID = "";
        string SmsApplication_Type = "";
        DataTable dt_EligibleClient;
        DataTable dt_AppliedClient;


        double Deposit_Pending_Balance =0.00;
        double Withdraw_Pending_Balance = 0.00;
        double Total_Balance = 0.00;
        double IPO_Cur_Balance = 0.00;
        double Total_Approved_Pending_Balance = 0.00;
        double GoingBalance = 0.00;
        string Deposit_Transaction_Name = "";
        string Withdraw_Transaction_Name = "";
        string Customer = "";
        
        #endregion

        #region Load Combo Box
        private void LoadCombo()
            {
                IPOProcessBAL ipoBal = new IPOProcessBAL();
                
                DataTable dt_Company = ipoBal.GetIPOSessionALL();
                cmb_CompanyName.DataSource = dt_Company;
                cmb_CompanyName.DisplayMember = "Company_Name";
                cmb_CompanyName.ValueMember = "ID";

                cmb_CompanyName.SelectedIndex =- 1;

                DataTable dt_RefundType = ipoBal.GetRefundMethod();
                cmb_RefundType.DataSource = dt_RefundType;
                cmb_RefundType.DisplayMember = "Desc";
                cmb_RefundType.ValueMember = "ID";

                cmb_RefundType.SelectedValue=Indication_IPORefundType.Refund_TRIPO_ID;
            }
        private void LoadSchemaForDataTable()
        {

            IPOProcessBAL ipoBal=new IPOProcessBAL();
            DataTable dt = ipoBal.GetEligibleCustomer(-1);
            dt_EligableCustomer = dt.Clone();
            dt_AppliedCustomer = dt.Clone();
            ClearALL();
            
        }
        #endregion

       

        #region From Load

            private void IpoApplicationProcess_Load(object sender, EventArgs e)
            {
                LoadCombo();
                LoadSchemaForDataTable();
            }
          
        #endregion

        #region        
       
        private void SetDataTableToDataGridView()
        {
            dgv_FinalCheck.DataSource = dt_AppliedCustomer;
        }

       

       
        private void Check_Validation()
        {
            if (Convert.ToInt32(cmb_CompanyName.SelectedValue) < 0 || cmb_CompanyName.SelectedValue==null)
            {
                throw new Exception("Please Selecte A Company!!");
            }
            if (Convert.ToInt32(cmb_RefundType.SelectedValue) < 0 || cmb_RefundType.SelectedValue== null)
            {
                throw new Exception("Please Selecte A RefundValue!!");
            }
            if (cmb_RefundType.SelectedText==Indication_IPORefundType.Refund_TRPR_Desc)
            {
                throw new Exception("Trasfer Parent Not Allowed");
            }
        }

        #endregion

        private void cmb_CompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_CompanyName.ValueMember !=string.Empty)
            {
                IPOProcessBAL ipoBal=new IPOProcessBAL();
                
                int id = Convert.ToInt32(cmb_CompanyName.SelectedValue);
                DataTable dt = ipoBal.GetIPOSessionInfo_BySessionId(id);               

            }
        }
        private void CheckBankInformation_AddToGrid(DataRow dr)
        {
            //string rountingID = "";
            if (cmb_RefundType.Text == Indication_IPORefundType.Refund_EFT_Desc || cmb_RefundType.Text == Indication_IPORefundType.Refund_MMT_Desc)
            {
                if (Convert.ToString(dr["Routing_No"]).Trim() == string.Empty || Convert.ToString(dr["Bank_Name"]).Trim() == string.Empty || Convert.ToString(dr["Bank id"]).Trim() == string.Empty || Convert.ToString(dr["Branch_Name"]).Trim() == string.Empty || Convert.ToString(dr["Branch Id"]).Trim() == string.Empty)
                //int BankNameCount = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BankName"]).Trim() == string.Empty).Count();
                //int BankIdCount = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BankID"]).Trim() == string.Empty).Count();
                //int BranchNameCount = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BranchName"]).Trim() == string.Empty).Count();
                //int BranchIdcount = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BranchID"]).Trim() == string.Empty).Count();

                //if (BalnkRoutingCount != 0 || BankNameCount != 0 || BankIdCount != 0 || BranchNameCount != 0 || BranchIdcount != 0)
                {
                    MessageBox.Show("Unable to Applied Due to bank Information is not Valid");
                }
            }

        }

        private void CheckBankInformation_BeforeSave()
        {
            //string rountingID = "";
            if (cmb_RefundType.Text == Indication_IPORefundType.Refund_EFT_Desc || cmb_RefundType.Text == Indication_IPORefundType.Refund_MMT_Desc)
            {
                int BalnkRoutingCount = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["Routing_NO"]).Trim() == string.Empty).Count();
                int BankNameCount = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BankName"]).Trim() == string.Empty).Count();
                int BankIdCount = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BankID"]).Trim() == string.Empty).Count();
                int BranchNameCount = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BranchName"]).Trim() == string.Empty).Count();
                int BranchIdcount = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t => Convert.ToString(t["BranchID"]).Trim() == string.Empty).Count();

                if (BalnkRoutingCount != 0 || BankNameCount != 0 || BankIdCount != 0 || BranchNameCount != 0 || BranchIdcount != 0)
                {
                    throw new Exception("Unable to Applied Due to bank Information is not Valid");
                }
            }

        }        

        private void ClearDetais()
        {
            txtCustCode.Text=string.Empty;
            if (!chkVoucher.Checked)
                txtsingleSerailno.Text = string.Empty;
            if (!chkremarks.Checked)
                txtsingelApplicationRemarks.Text = string.Empty;
            txt_ChannelID.Text = "0";
            txt_ChannelType.Text = string.Empty;
        }

        private void ClearByIPOSession()
        {
            if (dt_AppliedCustomer != null)
                dt_AppliedCustomer.Clear();
            SetDataTableToDataGridView();
            chkVoucher.Checked = false;
            chkremarks.Checked = false;
            ChkAffectedAccount.Checked = false;
            txtsingelApplicationRemarks.Text = "";
            txtsingleSerailno.Text = "";
            txtCustCode.Text = "";          
            cmb_RefundType.Text = "";
            txt_Cust_Code_ForReturnTransferParent.Text = "";
        }

        private void ClearALL()
        {

            if (dt_AppliedCustomer != null)
                dt_AppliedCustomer.Clear();
            SetDataTableToDataGridView();
            chkVoucher.Checked = false;
            chkremarks.Checked = false;
            ChkAffectedAccount.Checked = false;
            txtsingelApplicationRemarks.Text = "";
            txtsingleSerailno.Text = "";
            txtCustCode.Text = "";
            cmb_CompanyName.Text = "";
            cmb_RefundType.Text = "";
            txt_Cust_Code_ForReturnTransferParent.Text = "";
            txt_ChannelID.Text = "0";

        }

        private void NextIndex(string controlName)
        {
            if (txtCustCode.Name == controlName)
                txtsingleSerailno.Focus();

            if (txtsingleSerailno.Name == controlName)
                btnSaveDetails.Focus();
            if (cmb_CompanyName.Name == controlName)
                cmb_RefundType.Focus();
            if (cmb_RefundType.Name == controlName)
                txtCustCode.Focus();
            if (btnSaveDetails.Name == controlName)
                txtCustCode.Focus();
        }

        private void btnEligibleClient_Click(object sender, EventArgs e)
        {
            try
            {
                string serial = txtsingleSerailno.Text;
                string remarks = txtsingelApplicationRemarks.Text;
                if (cmb_CompanyName.ValueMember != string.Empty)
                {
                    DataTable dt = new DataTable();
                    IPOProcessBAL ipoBal = new IPOProcessBAL();
                    
                    //ClearByEligibleCustomer();
                    int id = Convert.ToInt32(cmb_CompanyName.SelectedValue);                     
                    //dt = ipoBal.GetEligibleCustomer(id, txtCustCode.Text);
                    //if (dt.Rows[0]["Serial_No"] == "")
                    //{
                    //    dt.Rows[0]["Serial_No"] = serial;
                    //}
                    foreach (DataRow dr in ipoBal.GetEligibleCustomer(id, txtCustCode.Text).Rows)
                    {
                        if (dt_AppliedCustomer.Rows.Cast<DataRow>().Where(T => Convert.ToString(T["Cust_Code"]) == txtCustCode.Text).Count() == 0)
                        {
                            //Charge
                            double AppCharge = ipoBal.GetIPO_ChargeDef().Rows.Count > 0 ? Convert.ToDouble(ipoBal.GetIPO_ChargeDef().Rows[0]["AppCharge"]) : 0.00;
                            double RefundCharge = 0.00;
                            double TotalCharge = AppCharge + RefundCharge;
                            
                            //Added By Md.Rashedul Hasan 20-Jan-2015
                            string cust_code = dr["Cust_Code"].ToString();
                            double amount = Convert.ToDouble(dr["ApplyMoney"]);
                            EntryBlanceChecking(cust_code, (amount + AppCharge));
                            /*********************************************************************************/

                            dr["Serial_No"] = txtsingleSerailno.Text;
                            dr["Remarks"] = txtsingelApplicationRemarks.Text;
                            dr["ChannelID"] = Convert.ToInt32(txt_ChannelID.Text==string.Empty?"0":txt_ChannelID.Text);
                            dr["ChannelType"] = txt_ChannelType.Text;
                            CheckBankInformation_AddToGrid(dr);
                            dt_AppliedCustomer.Rows.Add(dr.ItemArray);
                        }
                        else
                        {
                            MessageBox.Show("Already in grid");
                        }
                    }
                    SetDataTableToDataGridView();
                    NextIndex(btnSaveDetails.Name);
                    ClearDetais();
                    dgv_FinalCheck.FirstDisplayedScrollingRowIndex = dgv_FinalCheck.Rows.Cast<DataGridViewRow>().ToList().Last().Index;
                    //btnDoubleForward_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                NextIndex(btnSaveDetails.Name);
            }
        }
        
        private void dgvEligibleCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _dGEligibleCustomer_RowIndex = e.RowIndex;
        }

        private void dgvFinalCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _dGAppliedCustomer_RowIndex = e.RowIndex;
           
        }

        private void btnSingleForward_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = dt_EligableCustomer.Rows[_dGEligibleCustomer_RowIndex];
                dt_AppliedCustomer.Rows.Add(dr.ItemArray);
                dt_EligableCustomer.Rows.RemoveAt(_dGEligibleCustomer_RowIndex);
                SetDataTableToDataGridView();
                btnVerify.Visible = true;
                btnVerify.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnsingleBackword_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = dt_AppliedCustomer.Rows[_dGAppliedCustomer_RowIndex];
                dt_EligableCustomer.Rows.Add(dr.ItemArray);
                dt_AppliedCustomer.Rows.RemoveAt(_dGAppliedCustomer_RowIndex);
                SetDataTableToDataGridView();
                btnVerify.Visible = false;
                btnVerify.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDoubleForward_Click(object sender, EventArgs e)
        {
            try
            {
                
                for (int i = 0; i <dt_EligableCustomer.Rows.Count; i++)
                {
                    dt_AppliedCustomer.Rows.Add(dt_EligableCustomer.Rows[i].ItemArray);
                }
                dt_EligableCustomer.Clear();
                SetDataTableToDataGridView();
                btnVerify.Visible = true;
                btnVerify.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDoubleBackWard_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dt_AppliedCustomer.Rows.Count; i++)
                {
                    dt_EligableCustomer.Rows.Add(dt_AppliedCustomer.Rows[i].ItemArray);
                }
                dt_AppliedCustomer.Clear();
                SetDataTableToDataGridView();
                btnVerify.Visible = false;
                btnVerify.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            try
            {
                Check_Validation();
                //CheckBankInformation_BeforeSave();
                IPOProcessBAL ipoBal = new IPOProcessBAL();

                string[] Cust_Codes = dt_AppliedCustomer.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                int[] SessionID = (new int[] {Convert.ToInt32(cmb_CompanyName.SelectedValue)});
                int RefundID=Convert.ToInt32(cmb_RefundType.SelectedValue);
                string[] SerailNo = dt_AppliedCustomer.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Serial_No"])).ToArray();
                string[] Remarks = dt_AppliedCustomer.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Remarks"])).ToArray();
                int[] ChannelID = dt_AppliedCustomer.Rows.Cast<DataRow>().Select(t => Convert.ToInt32(t["ChannelID"])).ToArray();
                string[] ChannelType = dt_AppliedCustomer.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["ChannelType"])).ToArray(); 
                
                DataTable MoneyRefDt = new DataTable();

                if (Cust_Codes.Length ==0)
                    throw new Exception("No Customer Found");
                //if (SessionID < 0)
                //    throw new Exception("No Company Name Selected");
                if (RefundID < 0)
                    throw new Exception("No Refund Type Selected");

                string Refund_Reference=string.Empty;

                if (cmb_RefundType.Text == Indication_IPORefundType.Refund_TRPRIPO_Desc)
                {
                   Refund_Reference= txt_Cust_Code_ForReturnTransferParent.Text;
                }

                //Added By Md.Rashedul Hasan 20-Jan-2015
                foreach (DataRow dr in dt_AppliedCustomer.Rows)
                {
                    string cust_code = dr["Cust_Code"].ToString();
                    double amount = Convert.ToDouble(dr["ApplyMoney"]);
                    EntryBlanceChecking(cust_code, amount);

                }
                /*********************************************************************************/
                //ipoBal.Insert_ApplyApplication_MoneyTransaction(new int[] { SessionID }, Cust_Codes, RefundID, Refund_Reference,0);

                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Insert_ApplyApplication_MoneyTransaction_UITransApplied(SessionID, Cust_Codes, RefundID, Refund_Reference, MoneyRefDt, Convert.ToInt32(txtlotNo.Text), SerailNo,Remarks,ChannelID,ChannelType);
                    ipoBal.Updated_IPO_Affected_Account_UITransApplied(Cust_Codes, ChkAffectedAccount.Checked);
                    ipoBal.Commit();
                    MessageBox.Show("Application Process Successfully Done");
                    LoadGridDataAfterSave(Cust_Codes, SessionID.FirstOrDefault(), RefundID);
                }
                catch(Exception ex)
                {
                    ipoBal.RollBack();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ipoBal.CloseDatabase();    
                }
            }               
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Added BY Md.Rashedul Hasan 20-Jan-2015
        /// <summary>
        /// Withdraw Balance Checking For withdraw Transaction
        /// </summary>
        /// <param name="cust_code"></param>
        /// <param name="Distributed_Amount"></param>
        private void EntryBlanceChecking(string cust_code, double Distributed_Amount)
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
                Total_Balance = 0.00;
                Total_Approved_Pending_Balance = 0.00;
                Withdraw_Pending_Balance = 0.00;
                Deposit_Pending_Balance = 0.00;

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
                    double Hold = 0.00;
                    if (Previous_Balance[i] != "")
                    {
                        Hold = Convert.ToDouble(Previous_Balance[i]);
                        Total_Balance = Hold;
                    }
                }
                for (int i = 0; i < Present_Approve_Pending_Balance.Length; i++)
                {
                    double P_Hold = 0.00;
                    if (Present_Approve_Pending_Balance[i] != "")
                    {
                        P_Hold = Convert.ToDouble(Present_Approve_Pending_Balance[i]);
                        Total_Approved_Pending_Balance = P_Hold;
                    }
                }
                for (int i = 0; i < Total_Withdraw_Pending.Length; i++)
                {
                    double W_con = 0.00;
                    string W_Pending = Total_Withdraw_Pending[i];
                    if (W_Pending == "")
                    {
                        W_Pending = "0";
                        W_con = W_con + Convert.ToDouble(W_Pending);
                    }
                    else
                    {
                        W_con = W_con + Convert.ToDouble(W_Pending);
                    }
                    Withdraw_Pending_Balance = Withdraw_Pending_Balance + W_con;
                }
                for (int i = 0; i < Total_Deposit_Pending.Length; i++)
                {
                    double D_con = 0.00;
                    //Convert.ToDecimal(D_Pending);

                    string D_Pending = Total_Deposit_Pending[i];
                    if (D_Pending == "")
                    {
                        D_Pending = "0";
                        D_con = D_con + Convert.ToDouble(D_Pending);
                    }
                    else
                    {
                        D_con = D_con + Convert.ToDouble(D_Pending);
                    }
                    Deposit_Pending_Balance = Deposit_Pending_Balance + D_con;
                }
                //Convert.ToDecimal(dt.Rows[0]["Withdraw_Pending"]);
                if ((Total_Balance - Withdraw_Pending_Balance) < Distributed_Amount)
                {
                    throw new Exception("Your previous Balance =" + Total_Balance + "\n available withdrawal Balance = " + Total_Approved_Pending_Balance + "\n Total Pendding deposit Amount = " + Deposit_Pending_Balance + " Deposit Transaction Pending By: " + Deposit_Transaction_Name + "\n Total Withdraw Balance = " + Withdraw_Pending_Balance + " Withdraw Transaction Pending By: " + Withdraw_Transaction_Name + "\n For This Cust Code= " + cust_code);
                }
            }

        }

        private void SetSMSData()
        {
            ClearDetais();
            cmb_CompanyName.SelectedValue = frm_IPOSMSMoneyTransactionApproval.IPOSessionID;
            txtCustCode.Text=frm_IPOSMSMoneyTransactionApproval.Cust_Code.Distinct().FirstOrDefault();
            txtsingleSerailno.Text = Convert.ToString(frm_IPOSMSMoneyTransactionApproval.SMSReqID.Where(t => Convert.ToString(t.Key) == txtCustCode.Text).Select(t => t.Value).SingleOrDefault());
            txtsingelApplicationRemarks.Text=string.Empty;
            txtlotNo.Text = Convert.ToString(frm_IPOSMSMoneyTransactionApproval.LotNo == 0 ? 1 : frm_IPOSMSMoneyTransactionApproval.LotNo);
            txt_ChannelID.Text =Convert.ToString( frm_IPOSMSMoneyTransactionApproval.SMSReqID.Where(t=> Convert.ToString(t.Key)==txtCustCode.Text).Select(t=> t.Value).SingleOrDefault());
            txt_ChannelType.Text = frm_IPOSMSMoneyTransactionApproval.MediaType.Distinct().SingleOrDefault();                     
            //cmb_RefundType.SelectedValue = frm_IPOSMSMoneyTransactionApproval.RefundType_ID;
            cmb_RefundType.SelectedText = Indication_IPORefundType.Refund_TRIPO_Desc;
            cmb_RefundType.SelectedValue = Indication_IPORefundType.Refund_TRIPO_ID;

            txt_Cust_Code_ForReturnTransferParent.Enabled = false;
            txt_Cust_Code_ForReturnTransferParent.Text = string.Empty;
            txt_Cust_Code_ForReturnTransferParent.ReadOnly = true;
        }

        private void cmb_RefundType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_RefundType.Text == Indication_IPORefundType.Refund_TRPR_Desc)
            {
                txt_Cust_Code_ForReturnTransferParent.Enabled = true;
                txt_Cust_Code_ForReturnTransferParent.Text = string.Empty;
            }
            else if (cmb_RefundType.Text == Indication_IPORefundType.Refund_TRIPO_Desc)
            {
                txt_Cust_Code_ForReturnTransferParent.Enabled = false;
                txt_Cust_Code_ForReturnTransferParent.Text = string.Empty;
                txt_Cust_Code_ForReturnTransferParent.ReadOnly = true;
            }
            else if (cmb_RefundType.Text == Indication_IPORefundType.Refund_TRPRIPO_Desc)
            {
                IPOProcessBAL bal = new IPOProcessBAL();
                DataTable dt = new DataTable();
                if (SmsApplication_Type != Indication_IPOPaymentTransaction.SmsRequestType_Single_Application)
                {
                    SmsApplied_Client_ID = txtCustCode.Text;
                }

                string[] Cust_Code = new string[] { SmsApplied_Client_ID };
                dt = bal.GetParentCodeFromChildCode(Cust_Code);
                string Parent_Code = "";
                if (dt.Rows.Count > 1)
                {
                    throw new Exception("Invalid Parent Child Group Found");
                }
                else if (dt.Rows.Count == 0)
                {
                    throw new Exception("Invalid Parent Child Group Found");

                }
                else
                {
                    Parent_Code = dt.Rows[0][0].ToString();
                }
                txt_Cust_Code_ForReturnTransferParent.Text = Parent_Code;
            }
            else
            {
                txt_Cust_Code_ForReturnTransferParent.Enabled = false;
                txt_Cust_Code_ForReturnTransferParent.Text = string.Empty;
            }
        }

        private string[] ref_cust_code;
        private int ref_cust_code_index = 0;

        #region Signature Info
        private void btnVerify_Click(object sender, EventArgs e)
        {
            DataTable dtcode = new DataTable();
            //dtcode = dgv_FinalCheck;

            string[] orderId = dt_AppliedCustomer.Rows.Cast<DataRow>().Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
            //ref_cust_code = orderId;
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
            string[] sessionId = new string[] {Convert.ToString(cmb_CompanyName.SelectedValue) };
            IPOProcessBAL objBAL = new IPOProcessBAL();
            DataTable dt = new DataTable();
            crIpoApplicationForPublicIssueSignature objrpt = new crIpoApplicationForPublicIssueSignature();
            frmIPOReportViewer viewer = new frmIPOReportViewer();

            dt = objBAL.GetPublicIssueFromBeforeApplication(orderId, sessionId);
            

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
            viewer.StartPosition = FormStartPosition.CenterScreen;
            viewer.ShowDialog(this);
        

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
        #endregion

        private void btnImageVerify_Click(object sender, EventArgs e)
        {
            try
            {
                string SelectedCode=Convert.ToString(dt_AppliedCustomer.Rows[dgv_FinalCheck.CurrentRow.Index]["Cust_Code"]);
                string[] orderId_Except = dt_AppliedCustomer.Rows.Cast<DataRow>().Where(t=> t["Cust_Code"]!=SelectedCode)
                    .Select(t => Convert.ToString(t["Cust_Code"])).ToArray();
                List<string> orderIdList = new List<string>();
                orderIdList.Add(SelectedCode);
                orderIdList.AddRange(orderId_Except);
                ref_cust_code = orderIdList.ToArray();
                if (ref_cust_code.Length - 1 > ref_cust_code_index)
                {
                    ref_cust_code_index++;
                }

                else
                {
                    ref_cust_code_index = 0;
                }
                string ref_cust_code_list = ref_cust_code[ref_cust_code_index];

                frmCustomerVerificationInfo info = new frmCustomerVerificationInfo(orderIdList.ToArray());
                info.StartPosition = FormStartPosition.CenterScreen;
                info.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = dt_AppliedCustomer.Rows[_dGAppliedCustomer_RowIndex];
                dt_EligableCustomer.Rows.Add(dr.ItemArray);
                dt_AppliedCustomer.Rows.RemoveAt(_dGAppliedCustomer_RowIndex);
                SetDataTableToDataGridView();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                NextIndex(txtCustCode.Name);
            }
        }

        private void LoadGridDataAfterSave(string[] code, int id,int refund)
        {
            IPOProcessBAL bal = new IPOProcessBAL();
            DataTable dt = new DataTable();
            try
            {
                dt = bal.GetSingleApplicationDataAfterSave(code, id, refund);
                dgv_FinalCheck.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearALL();
        }

        private void cmb_CompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                NextIndex(cmb_CompanyName.Name);
            }
        }

        private void cmb_RefundType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                NextIndex(cmb_RefundType.Name);
            }
        }

        private void txtsingleSerailno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                NextIndex(txtsingleSerailno.Name);
            }

        }

        private void cmb_CompanyName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ClearByIPOSession();
        }

        private void BtnSmsApplication_Click(object sender, EventArgs e)
        {
            try
            {
                frm_IPOSMSMoneyTransactionApproval frm = new frm_IPOSMSMoneyTransactionApproval(Indication_IPOPaymentTransaction.IPOForwardingData_MenuList_SingleApplication);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog(this);
                if (frm_IPOSMSMoneyTransactionApproval.isForwarded)
                    SetSMSData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
