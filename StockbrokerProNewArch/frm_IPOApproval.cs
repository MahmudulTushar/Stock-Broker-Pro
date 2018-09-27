using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.Constants;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using DataAccessLayer;
using System.Data.SqlClient;


namespace StockbrokerProNewArch
{
    public partial class frm_IPOApproval : Form
    {
        private string MenuName;
        private string Selected_VoucherNo;
        private int Selected_Single_ID_IPOAcc;
        private int[] Selected_Multi_ID_IPOAcc;
        private int Selected_Single_ID_PaymentPosting;
        public enum RealTimeTrackerName { Application, Transaction };

        public List<KeyValuePair<RealTimeTrackerName, string>> Form_Transaction_IDs;

        public frm_IPOApproval(string P_MenuName)
        {
            InitializeComponent();
            MenuName = P_MenuName;
            this.Text = MenuName;
            Form_Transaction_IDs = new List<KeyValuePair<RealTimeTrackerName, string>>();
        }

        private void LoadGrid()
        {
            if (MenuName == Indication_Forms_Title.IPODepositApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt=ipoBal.GetNonTransferDeposit_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;

            }
            else if (MenuName == Indication_Forms_Title.Ipo_single_Deposit_approval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.Get_NonTransfer_money_depositSingle();
                dg_IpoApproval.DataSource = dt;
            }
            else if (MenuName == Indication_Forms_Title.IPOCheck_Clearence)
              {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetChecqueApprovedData();
                dg_IpoApproval.DataSource = dt;
                
                dg_IpoApproval.Columns["Session_Id"].Visible = false;
                dg_IpoApproval.Columns["Transaction_Ref_Id"].Visible = false;
                dg_IpoApproval.Columns["ID"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
                
 
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetNonTransferWithdraw_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval_Refund)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetNonTransferBack_Withdraw_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPOSingleTransferApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetSingleTransfer_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetMultiTransfer_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPOAppApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetIPOApplication_Pending_List();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["IPOSession_ID"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPOSingleTransferBackApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetSingleTransferBack_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;               
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPOParentAccountTransferBackApproval)
            {
                IPOApprovalBAL ipoBal =new IPOApprovalBAL();
                DataTable dt = ipoBal.GetTRPRIPOTransferBack_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                 
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;
                dg_IpoApproval.Columns["SelectionID"].Visible = false;
                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    dg_IpoApproval.Rows[0].Selected = true;
                    
                    btnAcceptAll.Enabled = true;
                }
                else
                {
                    btnAcceptAll.Enabled = false;
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferBackApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetMultiTransferBack_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawalSingleApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetSingleTransferWithdraw_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawalMultiApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetMultiTransferWithdraw_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;

                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;

            }
            else if (MenuName == Indication_Forms_Title.IPOMoneyDeposit_ApplyTogther)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetDeposit_Apply_Together();
                dg_IpoApproval.DataSource = dt;
                //dg_IpoApproval.Columns["Customer"].Visible = false;
                dg_IpoApproval.Columns["Session_Id"].Visible = false;
                dg_IpoApproval.Columns["Transaction_Ref_Id"].Visible = false;
                dg_IpoApproval.Columns["ID"].Visible = false;
                //dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                //dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                //dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;
                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPODepositSingleTransfer_ApplyTogther)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                DataTable dt = ipoBal.GetSingleTransfer_ApplyTogether_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                //dg_IpoApproval.Columns["Customer"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;
                dg_IpoApproval.Columns["Application Id"].Visible = false;
                dg_IpoApproval.Columns["IPO Premium"].Visible = false;
                dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPODepositMultiTransfer_ApplyTogther)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                //DataTable dt = ipoBal.GetDeposit_Apply_Together();
                DataTable dt = ipoBal.GetMultiTransfer_ApplyTogether_MoneyTransaction_Pending_List();
                dg_IpoApproval.DataSource = dt;
                //dg_IpoApproval.Columns["Customer"].Visible = false;
                //dg_IpoApproval.Columns[""].Visible = false;
                dg_IpoApproval.Columns["PaymentPosting_ID"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_ID"].Visible = false;
                dg_IpoApproval.Columns["Money_TransactionType_ID"].Visible = false;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["Voucher_No_Selection"].Visible = false;
                dg_IpoApproval.Columns["IPO Premium"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;
                dg_IpoApproval.Columns["Intended_IPOSession_Name"].Visible = false;
                dg_IpoApproval.Columns["SelectionID"].Visible = false;
                //dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                    dg_IpoApproval.Rows[0].Selected = true;
            }
            else if (MenuName == Indication_Forms_Title.IPONRBMoneyDepositAndApplication)
            {
                IPOApprovalBAL bal = new IPOApprovalBAL();
                DataTable dt = bal.GetNRBApplicationAndMoneyTransfer();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["ID"].Visible = false;
                dg_IpoApproval.Columns["SelectionID"].Visible = false;
                dg_IpoApproval.ClearSelection();
            }
            else if (MenuName == Indication_Forms_Title.IPOMoneyRefund_ForNrb)
            {
                IPOApprovalBAL bal = new IPOApprovalBAL();
                DataTable dt = new DataTable();
                dt = bal.GetRefundInformation_NRBDruft_PendingList();
                dg_IpoApproval.DataSource = dt;
                dg_IpoApproval.Columns["Nrb_ID"].Visible = false;
                //dg_IpoApproval.ClearSelection();
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    dg_IpoApproval.Rows[0].Selected = true;
                }
            }


        }
        private void LoadGridMode()
        {
            if (MenuName == Indication_Forms_Title.IPODepositApproval)
            {
                dg_IpoApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg_IpoApproval.MultiSelect = false;
                btnAccept.Text = "Approved";
                btnReject.Text = "Reject";
                btnAcceptAll.Text = "Approval ALl";
                btnRejectAll.Text = "Reject ALL";
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval)
            {
                dg_IpoApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg_IpoApproval.MultiSelect = false;
                btnAccept.Text = "Approved";
                btnReject.Text = "Reject";
                btnAcceptAll.Text = "Approval ALl";
                btnRejectAll.Text = "Reject ALL";
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval_Refund)
            {
                dg_IpoApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg_IpoApproval.MultiSelect = false;
                btnAccept.Text = "Approved";
                btnReject.Text = "Reject";
                btnAcceptAll.Text = "Approval ALl";
                btnRejectAll.Text = "Reject ALL";
            }
            else if (MenuName == Indication_Forms_Title.IPOMoneyDeposit_ApplyTogther)
            {
                dg_IpoApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg_IpoApproval.MultiSelect = true;
                btnAccept.Text = "Approved";
                btnReject.Text = "Reject";
                btnAcceptAll.Text = "Approval ALl";
                btnRejectAll.Text = "Reject ALL";
            }
            else if (MenuName == Indication_Forms_Title.IPOCheck_Clearence)
            {
                dg_IpoApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg_IpoApproval.MultiSelect = true;
                btnAccept.Text = "Clear";
                btnReject.Text = "UnClear";
                btnAcceptAll.Text = "Clear ALl";
                btnRejectAll.Text = "UnClear ALL";
            }
            else if (MenuName == Indication_Forms_Title.IPODepositSingleTransfer_ApplyTogther)
            {
                dg_IpoApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg_IpoApproval.MultiSelect = true;
            }
            else if (MenuName == Indication_Forms_Title.IPODepositMultiTransfer_ApplyTogther)
            {
                dg_IpoApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg_IpoApproval.MultiSelect = true;
            }
            else
            {
                dg_IpoApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dg_IpoApproval.MultiSelect = true;
                btnAccept.Text = "Approved";
                btnReject.Text = "Reject";
            }
            
        }

        private void frm_IPOApproval_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadGridMode();
        }

        private void Business_Validation_Execution(DataGridViewRow[] P_dr)
        {
            if (MenuName == Indication_Forms_Title.IPODepositApproval)
            {
                
            }
            else if (MenuName == Indication_Forms_Title.IPOCheck_Clearence)
            {
                //PaymentInfoBAL infoBal = new PaymentInfoBAL();
                //IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                //double IpoApplicationAmount = P_dr.Cast<DataGridViewRow>().Where(T => Convert.ToString(T.Cells["AccountName"].Value) == "APPLICATION")
                //    .Select(T => Convert.ToDouble(T.Cells["Total_Amount"].Value)).FirstOrDefault();
                //string custCodeTemp = P_dr.Cast<DataGridViewRow>().Select(T => Convert.ToString(T.Cells["Customer"].Value)).FirstOrDefault();
                //double TransactionAmount = P_dr.Cast<DataGridViewRow>().Where(T => Convert.ToString(T.Cells["AccountName"].Value) == "TRANSACTION").Select(T => Convert.ToDouble(T.Cells["Amount"].Value)).FirstOrDefault();

                //string payment_Media = P_dr.Cast<DataGridViewRow>().Where(T => Convert.ToString(T.Cells["AccountName"].Value) == "TRANSACTION")
                //    .Select(T => Convert.ToString(T.Cells["Transaction_type"].Value)).FirstOrDefault();
                ////double withDrawAmount = Convert.ToDouble(dr.Cells["Amount"].Value);
                ////double balanceTradeAccount = infoBal.GetCurrentBalane(custCodeTemp);

                //if (!(payment_Media == Indication_IPOPaymentTransaction.Cheque))
                //{
                //    double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication(custCodeTemp);
                //    if (!(IpoApplicationAmount <= balanceIPOAccount + TransactionAmount))
                //        throw new Exception("Insufficient Balance");
                //}
            }
            else if (MenuName == Indication_Forms_Title.IPOMoneyDeposit_ApplyTogther)
            {
                //PaymentInfoBAL infoBal = new PaymentInfoBAL();
                //IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                //double IpoApplicationAmount = P_dr.Cast<DataGridViewRow>().Where(T => Convert.ToString(T.Cells["AccountName"].Value) == "APPLICATION")
                //    .Select(T => Convert.ToDouble(T.Cells["Total_Amount"].Value)).FirstOrDefault();
                //string custCodeTemp = P_dr.Cast<DataGridViewRow>().Select(T => Convert.ToString(T.Cells["Customer"].Value)).FirstOrDefault();
                //double TransactionAmount = P_dr.Cast<DataGridViewRow>().Where(T => Convert.ToString(T.Cells["AccountName"].Value) == "TRANSACTION").Select(T => Convert.ToDouble(T.Cells["Amount"].Value)).FirstOrDefault();

                //string payment_Media = P_dr.Cast<DataGridViewRow>().Where(T => Convert.ToString(T.Cells["AccountName"].Value) == "TRANSACTION")
                //    .Select(T => Convert.ToString(T.Cells["Transaction_type"].Value)).FirstOrDefault();
                ////double withDrawAmount = Convert.ToDouble(dr.Cells["Amount"].Value);
                ////double balanceTradeAccount = infoBal.GetCurrentBalane(custCodeTemp);

                //if (!(payment_Media == Indication_IPOPaymentTransaction.Cheque))
                //{
                //    double balanceIPOAccount = ipoBal.GetIPOCustomerBalance(custCodeTemp);
                //    if (!(IpoApplicationAmount <= balanceIPOAccount + TransactionAmount))
                //        throw new Exception("Insufficient Balance");
                //}
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval)
            {
                //Any Payment Method
                string DepositWithdraw = Convert.ToString(P_dr[0].Cells["Deposit/Withdraw"].Value);
                string PaymentMethod = Convert.ToString(P_dr[0].Cells["Payment Method"].Value);

                if (DepositWithdraw == Indication_PaymentMode.Withdraw)
                {
                    foreach (DataGridViewRow dr in P_dr)
                    {
                        PaymentInfoBAL infoBal = new PaymentInfoBAL();
                        IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                        double amountTemp = Convert.ToDouble(dr.Cells["Amount"].Value);
                        string custCodeTemp = Convert.ToString(dr.Cells["Customer"].Value);

                        //double balanceTradeAccount = infoBal.GetCurrentBalane(custCodeTemp);
                        double balanceIPOAccount = ipoBal.GetIPOCustomerBalance(custCodeTemp);

                        if (!(amountTemp <= balanceIPOAccount))
                            throw new Exception("Insufficient Balance");
                    }

                }
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval_Refund)
            {
                //Any Payment Method
                string DepositWithdraw = Convert.ToString(P_dr[0].Cells["Deposit/Withdraw"].Value);
                string PaymentMethod = Convert.ToString(P_dr[0].Cells["Payment Method"].Value);

                if (DepositWithdraw == Indication_PaymentMode.Withdraw)
                {
                    foreach (DataGridViewRow dr in P_dr)
                    {
                        PaymentInfoBAL infoBal = new PaymentInfoBAL();
                        IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                        double amountTemp = Convert.ToDouble(dr.Cells["Amount"].Value);
                        string custCodeTemp = Convert.ToString(dr.Cells["Customer"].Value);

                        //double balanceTradeAccount = infoBal.GetCurrentBalane(custCodeTemp);
                        double balanceIPOAccount = ipoBal.GetIPOCustomerBalance(custCodeTemp);

                        if (!(amountTemp <= balanceIPOAccount))
                            throw new Exception("Insufficient Balance");
                    }

                }
            }
            else if (MenuName == Indication_Forms_Title.IPOSingleTransferApproval)
            {
                //Any Payment Method
                string DepositWithdraw = Convert.ToString(P_dr[0].Cells["Deposit/Withdraw"].Value);
                string PaymentMethod = Convert.ToString(P_dr[0].Cells["Payment Method"].Value);
                if (DepositWithdraw == Indication_PaymentMode.Withdraw)
                {
                    foreach (DataGridViewRow dr in P_dr)
                    {
                        if (Convert.ToString(dr.Cells["AccountName"]) == "TRADEACC")
                        {
                            PaymentInfoBAL infoBal = new PaymentInfoBAL();                            
                            double amountTemp = Convert.ToDouble(dr.Cells["Amount"].Value);
                            string custCodeTemp = Convert.ToString(dr.Cells["Customer"].Value);

                            //double balanceTradeAccount = infoBal.GetCurrentBalane(custCodeTemp);
                            foreach (DataRow B_dr in infoBal.GetCurrentBalanceInfo(custCodeTemp).Rows)
                            {
                                double Deduct500Balance = Convert.ToDouble(B_dr["CurrentMoneyDeduct500"]);
                                //if (!(amountTemp <= balanceTradeAccount))
                                if (!(amountTemp <= Deduct500Balance))
                                    throw new Exception("Insufficient Balance");
                            }
                        }
                    }
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferApproval)
            {
                //Any Payment Method
                string DepositWithdraw = Convert.ToString(P_dr[0].Cells["Deposit/Withdraw"].Value);
                string PaymentMethod = Convert.ToString(P_dr[0].Cells["Payment Method"].Value);
                if (DepositWithdraw == Indication_PaymentMode.Withdraw)
                {
                    foreach (DataGridViewRow dr in P_dr)
                    {
                        if (Convert.ToString(dr.Cells["AccountName"]) == "TRADEACC")
                        {
                            PaymentInfoBAL infoBal = new PaymentInfoBAL();
                            
                            double amountTemp = Convert.ToDouble(dr.Cells["Amount"].Value);
                            string custCodeTemp = Convert.ToString(dr.Cells["Customer"].Value);
                            //double balanceTradeAccount = infoBal.GetCurrentBalane(custCodeTemp);                           
                            //if (!(amountTemp <= balanceTradeAccount))
                            //    throw new Exception("Insufficient Balance");
                            foreach (DataRow B_dr in infoBal.GetCurrentBalanceInfo(custCodeTemp).Rows)
                            {
                                double Deduct500Balance = Convert.ToDouble(B_dr["CurrentMoneyDeduct500"]);
                                //if (!(amountTemp <= balanceTradeAccount))
                                if (!(amountTemp <= Deduct500Balance))
                                    throw new Exception("Insufficient Balance");
                            }
                        }
                    }

                }
            }
            else if (MenuName == Indication_Forms_Title.IPOAppApproval)
            {
                //Any Payment Method

                foreach (DataGridViewRow dr in P_dr)
                {

                    PaymentInfoBAL infoBal = new PaymentInfoBAL();
                    IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                    double amountTemp = Convert.ToDouble(dr.Cells["TotalAmount"].Value);
                    string custCodeTemp = Convert.ToString(dr.Cells["Cust_Code"].Value);

                    //double balanceTradeAccount = infoBal.GetCurrentBalane(custCodeTemp);
                    double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication(custCodeTemp);
                    if (!(amountTemp <= balanceIPOAccount))
                        throw new Exception("Insufficient Balance");
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOSingleTransferBackApproval)
            {
                //Any Payment Method
                string DepositWithdraw = Convert.ToString(P_dr[0].Cells["Deposit/Withdraw"].Value);
                string PaymentMethod = Convert.ToString(P_dr[0].Cells["Payment Method"].Value);
                if (DepositWithdraw == Indication_PaymentMode.Withdraw)
                {
                    foreach (DataGridViewRow dr in P_dr)
                    {
                        if (Convert.ToString(dr.Cells["AccountName"]) == "IPOACC")
                        {
                            PaymentInfoBAL infoBal = new PaymentInfoBAL();
                            IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                            double amountTemp = Convert.ToDouble(dr.Cells["Amount"].Value);
                            string custCodeTemp = Convert.ToString(dr.Cells["Customer"].Value);

                            //double balanceTradeAccount = infoBal.GetCurrentBalane(custCodeTemp);
                            double balanceIPOAccount = ipoBal.GetIPOCustomerBalance(custCodeTemp);
                            if (!(amountTemp <= balanceIPOAccount))
                                throw new Exception("Insufficient Balance");
                        }
                    }

                }
            }
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferBackApproval)
            {
                //Any Payment Method
                string DepositWithdraw = Convert.ToString(P_dr[0].Cells["Deposit/Withdraw"].Value);
                string PaymentMethod = Convert.ToString(P_dr[0].Cells["Payment Method"].Value);
                if (DepositWithdraw == Indication_PaymentMode.Withdraw)
                {
                    foreach (DataGridViewRow dr in P_dr)
                    {
                        if (Convert.ToString(dr.Cells["AccountName"]) == "IPOACC")
                        {
                            PaymentInfoBAL infoBal = new PaymentInfoBAL();
                            IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                            double amountTemp = Convert.ToDouble(dr.Cells["Amount"].Value);
                            string custCodeTemp = Convert.ToString(dr.Cells["Customer"].Value);

                            //double balanceTradeAccount = infoBal.GetCurrentBalane(custCodeTemp);
                            double balanceIPOAccount = ipoBal.GetIPOCustomerBalance(custCodeTemp);
                            if (!(amountTemp <= balanceIPOAccount))
                                throw new Exception("Insufficient Balance");
                        }
                    }
                }
            }
        }

        

        private void SelectedSameVoucher(string VoucherNo)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (MenuName == Indication_Forms_Title.IPOWithdrawalSingleApproval
                    ||MenuName==Indication_Forms_Title.IPOParentAccountTransferBackApproval)
                {
                    if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["SelectionID"].Value) == VoucherNo)
                    {
                        dg_IpoApproval.Rows[i].Selected = true;
                    }
                }
                else
                {
                    if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher No"].Value) == VoucherNo)
                        dg_IpoApproval.Rows[i].Selected = true;
                }

            }
            //dg_IpoApproval.MultiSelect = false;
        }
        private void SelectedSameVoucher(string VoucherNo, string selectionID)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (MenuName == Indication_Forms_Title.IPOWithdrawalMultiApproval 
                    || MenuName == Indication_Forms_Title.IPOParentAccountTransferBackApproval
                    || MenuName == Indication_Forms_Title.IPONRBMoneyDepositAndApplication)
                {
                    if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["SelectionID"].Value) == selectionID
                        && Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher No"].Value) == VoucherNo)
                    {
                        dg_IpoApproval.Rows[i].Selected = true;
                    }
                }
            }
        }
        /// <summary>
        /// Added By Rashed On 29 Jun 2015
        /// </summary>
        /// <param name="Status"></param>
        private void SelectedNRBUnsuccessful(string Status)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["Status_Name"].Value) == Status)
                    dg_IpoApproval.Rows[i].Selected = true;
            }
            //dg_IpoApproval.MultiSelect = false;
        }

        private void SelectedSameSelectionID_SessionID_VoucherNo(string SessionID,string VoucherNo, string selectionID)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (MenuName == Indication_Forms_Title.IPOParentAccountTransferBackApproval)
                {
                    if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["SelectionID"].Value) == selectionID
                        && Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher No"].Value) == VoucherNo
                        && Convert.ToString(dg_IpoApproval.Rows[i].Cells["Intended_IPOSession_ID"].Value) == SessionID)
                    {
                        dg_IpoApproval.Rows[i].Selected = true;
                    }
                }

            }
        }
        private void SelectSameBankRoutingCheque(string bank, string routing, string cheque)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                //Convert.ToString(dg_IpoApproval.Rows[i].Cells["Customer"].Value) == cust_Code && 
                if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["Bank_Name"].Value) == bank
                    && Convert.ToString(dg_IpoApproval.Rows[i].Cells["Cheque_No"].Value) == cheque && Convert.ToString(dg_IpoApproval.Rows[i].Cells["Routing_No"].Value) == routing)
                {
                    dg_IpoApproval.Rows[i].Selected = true;
                }
            }
        }
        
        private void SelectSamepaymentIDAndVoucherNoForMultitransfer(string voucher, string selection_ID)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher_No_Selection"].Value) == voucher
                    && Convert.ToString(dg_IpoApproval.Rows[i].Cells["SelectionID"].Value) == selection_ID)
                {
                    dg_IpoApproval.Rows[i].Selected = true;
                }
            }
        }
        private void SelectVoucherNoForMultitransfer(string voucher)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher_No_Selection"].Value) == voucher)
                {
                    dg_IpoApproval.Rows[i].Selected = true;
                }
            }
        }
        
        //private void SelectedSameVoucher(string VoucherNo)
        //{
        //    for(int i=0; i<dg_IpoApproval.Rows.Count;i++)
        //    {
        //        if(Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher No"].Value)==VoucherNo)
        //          dg_IpoApproval.Rows[i].Selected=true;
        //    }
        //    //dg_IpoApproval.MultiSelect = false;
        //}

        private void SelectSameMoneyTransId(string cust_Code)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["Transaction_Ref_Id"].Value) == cust_Code)
                    dg_IpoApproval.Rows[i].Selected = true;
            }
        }

        private void SelectSameCustCodeandAmount(string Cust_Code, string appid)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (
                    Convert.ToString(dg_IpoApproval.Rows[i].Cells["Customer"].Value) == Cust_Code
                    //&&(Convert.ToString(dg_IpoApproval.Rows[i].Cells["Amount"].Value)==Amount)
                    && Convert.ToString(dg_IpoApproval.Rows[i].Cells["Application Id"].Value) == appid)
                {
                    dg_IpoApproval.Rows[i].Selected = true;
                }
            }
        }
        
        private void SelectSameCustCodeandAmount(string Cust_Code, string appid, string voucher)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if(
                    Convert.ToString(dg_IpoApproval.Rows[i].Cells["Customer"].Value)==Cust_Code
                    //&&(Convert.ToString(dg_IpoApproval.Rows[i].Cells["Amount"].Value)==Amount)
                    &&Convert.ToString(dg_IpoApproval.Rows[i].Cells["Application Id"].Value)==appid
                    &&Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher No"].Value) == voucher)
                {
                    dg_IpoApproval.Rows[i].Selected = true;
                }
            }
        }
        private void SelectSameCustCodeandAmount(string voucher)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher No"].Value) == voucher)                     
                {
                    dg_IpoApproval.Rows[i].Selected = true;
                }
            }
        }

        private void SelectSamepaymentIDAndVoucherNoForMultitransfer(string paymentId, string voucher,string select)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["PaymentPosting_ID"].Value) == paymentId
                    &&Convert.ToString(dg_IpoApproval.Rows[i].Cells["SelectionID"].Value)==select
                    && Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher_No_Selection"].Value) == voucher)
                {
                    dg_IpoApproval.Rows[i].Selected = true;
                }
            }
        }
        
        private void SelectSamepaymentIDAndVoucherNoForMultitransfer(string voucher)
        {
            for (int i = 0; i < dg_IpoApproval.Rows.Count; i++)
            {
                if (Convert.ToString(dg_IpoApproval.Rows[i].Cells["Voucher_No_Selection"].Value) == voucher)
                {
                    dg_IpoApproval.Rows[i].Selected = true;
                }
            }
        }

        private void RealTimeExportSMSServer_MoneyTransaction()
        {
            IPOApprovalBAL ipoBal=new IPOApprovalBAL();
            
            //Export Customer Trade Acc
            List<string> UpdatedCustList = new List<string>();
            if (MenuName == Indication_Forms_Title.IPONRBMoneyDepositAndApplication)
                UpdatedCustList = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Cust_Code"].Value)).ToList();
            else if (MenuName != Indication_Forms_Title.IPOAppApproval)
                UpdatedCustList = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Customer"].Value)).ToList();
            else if (MenuName == Indication_Forms_Title.IPOAppApproval)
                UpdatedCustList = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Cust_Code"].Value)).ToList();

            string[] ApplicationIDs = Form_Transaction_IDs.Where(t => t.Key == RealTimeTrackerName.Application).Select(t => t.Value).Distinct().ToArray();
            string[] TransactionIDs = Form_Transaction_IDs.Where(t => t.Key == RealTimeTrackerName.Transaction).Select(t => t.Value).Distinct().ToArray();

            //string[] IPO_Cust_CodeList = ipoBal.GetCustListFromIPOTransactionIDs(TransactionIDs);
            
            SMSSyncBAL syncBal = new SMSSyncBAL();
            DashboardBAL dashBal = new DashboardBAL();
           
            try
            {
                
                foreach (string obj in UpdatedCustList)
                    dashBal.Execute_GenereateMoneyBalanceTemp(obj);

                syncBal.Connect_SBP();
                syncBal.Connect_SMS();
               
                SqlDataReader dt_GotExported_CustTradeAccBalance = syncBal.GetIPO_Customer_Trade_Account_UITransApplied(UpdatedCustList.ToArray());
                syncBal.DeleteData_SMSSyncExport_Customer_Trade_Account_UITransApplied(UpdatedCustList.ToArray());
                syncBal.InsertTable_SMSSyncExport_Customer_Trade_Account_UITransApplied(dt_GotExported_CustTradeAccBalance);

                ////Export Customer IPO Acc
                SqlDataReader dt_GotExported_CustIpoAccBalance_TradeTrans = syncBal.GetIPO_Customer_IPO_Account_UITransApplied(UpdatedCustList.ToArray());
                syncBal.DeleteData_SMSSyncExport_Customer_IPO_Account_UITransApplied(UpdatedCustList.ToArray());
                syncBal.InsertTable_SMSSyncExport_Customer_IPO_Account_UITransApplied(dt_GotExported_CustIpoAccBalance_TradeTrans);

                //if (MenuName != Indication_Forms_Title.IPOAppApproval)
                //{
                    SqlDataReader dt_AllreadyApplied = syncBal.GetApplicationList_AllreadyApplied(ApplicationIDs);
                    syncBal.DeleteData_tbl_IPO_SessionApplications_UITransApplied(ApplicationIDs);
                    syncBal.InsertTable_IPO_SessionApplications_UITransApplied(dt_AllreadyApplied);
                //}
                
                //Export MoneyTransaction
                SqlDataReader dt_MoneyTransRequest = syncBal.GetData_FreeMoneyTransactionRequest_Status_UITransApplied(TransactionIDs);
                syncBal.DeleteData_FreeMoneyTransactionRequest_UITransApplied(TransactionIDs);
                syncBal.InsertTable_MoneyTransactionRequest_Status_UITransApplied(dt_MoneyTransRequest);

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


        private void ApplyReject()
        {
            if (MenuName == Indication_Forms_Title.IPOSingleTransferApproval)
            {
                int transID_IPOACC = 0;
                int transID_TRADEACC = 0;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();
                }

                ipoBal.Rejected_Single_Transfer_MoneyTransaction(transID_TRADEACC, transID_IPOACC, string.Empty);

            }
            else if (MenuName == Indication_Forms_Title.IPOCheck_Clearence)
            {
                int transID_AppID = 0;
                int transID_TransID = 0;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string[] transRefIdList = null;
                string Payment_Media = string.Empty;

                if (dg_IpoApproval.Rows.Count > 0)
                {
                    transRefIdList = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Select(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value))
                        .Distinct().ToArray();
                }
                foreach (string refIDTemp in transRefIdList)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();

                    transID_AppID = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp && Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                    transID_TransID = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp && Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                       .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                    Payment_Media = dg_IpoApproval.Rows.Cast<DataGridViewRow>().ToList()
                    .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp && Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                    .Select(t => Convert.ToString(t.Cells["Transaction_type"].Value)).FirstOrDefault();
                    try
                    {
                        ipoBal.ConnectDatabase();
                        
                        ipoBal.ChequeUnClear_MoneyTransaction_UITransApplied(transID_TransID, GlobalVariableBO._userName);
                        Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_TransID)));
                        //var cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                        //                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                        //                    .Select(t => Convert.ToString(t.Cells["Customer"].Value)).FirstOrDefault();
                        //var AppAmount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                        //                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                        //                    .Select(t => Convert.ToString(t.Cells["Total_Amount"].Value)).FirstOrDefault();
                        //var IpoBalance = ipoBal.GetIPOCustomerBalance_FroAppApproval_UITransApplied(cust_Code);

                        //if (Convert.ToDouble(AppAmount) > Convert.ToDouble(IpoBalance))
                        //    throw new Exception("Insufficient Balance");
                        //var rows = dg_IpoApproval.Rows.Cast<DataGridViewRow>().ToList()
                        //        .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp).ToArray();

                        //Business_Validation_Execution(rows);
                        ipoBal.Rejected_IPOApplication_UITransApplied(transID_AppID, GlobalVariableBO._userName, "Cheque Uncleared");
                        ipoBal.Commit();
                    }
                    catch (Exception ex)
                    {
                        ipoBal.RollBack();
                        throw ex;
                    }
                    finally
                    {
                        ipoBal.CloseDatabase();
                    }
                }
            }
            //else if (MenuName == Indication_Forms_Title.Ipo_Cheque_Clear_UnClear)
            //{
            //    //string transid = "";
            //    //IPOProcessBAL bal = new IPOProcessBAL();
            //    //if (dg_IpoApproval.SelectedRows.Count > 0)
            //    //{
            //    //    transid = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
            //    //        .Where(T => Convert.ToString(T.Cells["Money_TransactionType_Name"].Value) == "Cheque")
            //    //        .Select(c => Convert.ToString(c.Cells["ID"].Value)).FirstOrDefault();
            //    //    bal.IpoAppliccationAndchequeReject(transid);
            //    //}
            //}
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferApproval)
            {
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                }

                ipoBal.Rejected_Mulit_Transfer_MoneyTransaction(transID_TRADEACC, transID_IPOACC, string.Empty);
            }
            else if (MenuName == Indication_Forms_Title.IPODepositApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                int transID = 0;
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID = Convert.ToInt32(dg_IpoApproval.SelectedRows[0].Cells["ID"].Value);
                }
                string ApprovedBy = GlobalVariableBO._userName;

                ipoBal.Rejected_Single_NonTransfer_MoneyTransaction(transID, ApprovedBy, string.Empty);
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                int appID = 0;
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    appID = Convert.ToInt32(dg_IpoApproval.SelectedRows[0].Cells["ID"].Value);
                }
                string ApprovedBy = GlobalVariableBO._userName;

                ipoBal.Rejected_Single_NonTransfer_MoneyTransaction(appID, ApprovedBy, string.Empty);
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval_Refund)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                int appID = 0;
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    appID = Convert.ToInt32(dg_IpoApproval.SelectedRows[0].Cells["ID"].Value);
                }
                string ApprovedBy = GlobalVariableBO._userName;

                ipoBal.Rejected_Single_NonTransfer_MoneyTransaction(appID, ApprovedBy, string.Empty);
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawalSingleApproval)
            {
                IPOApprovalBAL ipobal = new IPOApprovalBAL();
                int TransId_IPOAcc = 0;
                int TransId_tradeAcc = 0;
                string SelectionId = "";
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    SelectionId = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Select(c => Convert.ToString(c.Cells["SelectionID"].Value)).FirstOrDefault();
                    TransId_IPOAcc = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Selectionid"].Value) == SelectionId &&
                            Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).First();
                    TransId_tradeAcc = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Selectionid"].Value) == SelectionId &&
                            Convert.ToString(c.Cells["AccountName"].Value) == "TRADEACC")
                            .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).First();
                    ipobal.Rejected_Single_Transfer_MoneyTransaction(TransId_tradeAcc, TransId_IPOAcc, "Money Transaction Rejected");
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawalMultiApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string[] TransId_IPOAcc = null;
                string[] TransId_TradeAcc = null;
                string IPO_DepositId = "";
                string IPO_WithdrawId = "";
                string SelectionID = "";
                string[] TrnsId_To_TransId_IPoAcc = null;
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    SelectionID = dg_IpoApproval.SelectedRows[0].Cells["SelectionID"].Value.ToString();
                    TransId_IPOAcc = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == SelectionID
                            && Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                    TransId_TradeAcc = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == SelectionID
                            && Convert.ToString(c.Cells["AccountName"].Value) == "TRADEACC")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                    IPO_DepositId = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == SelectionID
                            && Convert.ToString(c.Cells["AccountName"].Value) == "IPOTOIPODEPOSIT")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).FirstOrDefault();
                    IPO_WithdrawId = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == SelectionID
                            && Convert.ToString(c.Cells["AccountName"].Value) == "IPOTOIPOWITHDRAW")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).FirstOrDefault();
                    if (TransId_IPOAcc != null && TransId_TradeAcc != null)
                    {
                        ipoBal.Rejected_Mulit_Transfer_MoneyTransaction(TransId_TradeAcc, TransId_IPOAcc, "Money Transaction Rejected");
                    }
                    else if (IPO_DepositId != "" && IPO_WithdrawId != "")
                    {
                        TrnsId_To_TransId_IPoAcc = new string[] {IPO_DepositId,IPO_WithdrawId };
                        ipoBal.Rejected_IPO_TO_IPO_Mulit_Transfer_MoneyTransaction(TrnsId_To_TransId_IPoAcc, "Money Transaction Rejected");
                    }
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOAppApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                int appID = 0;
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    appID = Convert.ToInt32(dg_IpoApproval.SelectedRows[0].Cells["ID"].Value);
                }
                string ApprovedBy = GlobalVariableBO._userName;

                ipoBal.Rejected_IPOApplication(appID, ApprovedBy, "Money transaction Rejected");

            }
            else if (MenuName == Indication_Forms_Title.IPOSingleTransferBackApproval)
            {
                int transID_IPOACC = 0;
                int transID_TRADEACC = 0;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();
                }

                ipoBal.Rejected_Single_TransferBack_MoneyTransaction(transID_TRADEACC, transID_IPOACC, string.Empty);

            }
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferBackApproval)
            {
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                }

                ipoBal.Rejected_Multi_TransferBack_MoneyTransaction(transID_TRADEACC, transID_IPOACC, string.Empty);

            }
            else if (MenuName == Indication_Forms_Title.IPOMoneyDeposit_ApplyTogther)
            {
                int transID_APP = 0;
                int transID_TRANS = 0;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string Payment_Media = string.Empty;

                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    Payment_Media = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                    .Where(t => Convert.ToString(t.Cells["Transaction_type"].Value) != "")
                    .Select(t => Convert.ToString(t.Cells["Transaction_type"].Value)).FirstOrDefault();

                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                    transID_APP = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                    transID_TRANS = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                       .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                    
                        //try
                        //{
                            //ipoBal.ConnectDatabase();
                            
                            //ipoBal.Rejected_Single_NonTransfer_MoneyTransaction(transID_TRANS, GlobalVariableBO._userName, string.Empty);
                            //var cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                            //                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                            //                    .Select(t => Convert.ToString(t.Cells["Customer"].Value)).FirstOrDefault();
                            //var AppAmount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                            //                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                            //                    .Select(t => Convert.ToString(t.Cells["Total_Amount"].Value)).FirstOrDefault();
                            //var IpoBalance = ipoBal.GetIPOCustomerBalance_FroAppApproval_UITransApplied(cust_Code);

                    try
                    {
                        ipoBal.ConnectDatabase();

                        ipoBal.Rejected_Single_NonTransfer_MoneyTransaction(transID_TRANS, GlobalVariableBO._userName, "Money Transaction Rejected");
                        //var cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                        //                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                        //                    .Select(t => Convert.ToString(t.Cells["Customer"].Value)).FirstOrDefault();
                        //var AppAmount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                        //                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                        //                    .Select(t => Convert.ToString(t.Cells["Total_Amount"].Value)).FirstOrDefault();
                        //var IpoBalance = ipoBal.GetIPOCustomerBalance_FroAppApproval_UITransApplied(cust_Code);

                        //if (Convert.ToDouble(AppAmount) > Convert.ToDouble(IpoBalance))
                        //    throw new Exception("Insufficient Balance");
                        Business_Validation_Execution(dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToArray());

                        ipoBal.Rejected_IPOApplication(transID_APP, GlobalVariableBO._userName, "Money Transaction Rejected");
                        //ipoBal.Insert_Into_93Account_Deposit_UITrans(transID_TRANS);
                        ipoBal.Commit();
                    }
                    catch (Exception ex)
                    {
                        ipoBal.RollBack();
                        throw ex;
                    }
                    finally
                    {
                        ipoBal.CloseDatabase();
                    }

                }
            }
            else if (MenuName == Indication_Forms_Title.IPODepositSingleTransfer_ApplyTogther)
            {
                var selectRows = dg_IpoApproval.SelectedRows;
                int transID_IPOACC = 0;
                int transID_TRADEACC = 0;
                int App_ID = 0;

                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {

                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();
                    App_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToInt32(c.Cells["Application Id"].Value)).SingleOrDefault();

                }
                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Rejected_Single_Transfer_MoneyTransaction(transID_TRADEACC, transID_IPOACC, "Money Transaction Rejected");
                    ipoBal.Rejected_IPOApplication(App_ID, GlobalVariableBO._userName, "Money Transaction Rejected");
                    ipoBal.Commit();
                }
                catch (Exception ex)
                {
                    ipoBal.RollBack();
                    throw ex;
                }
                finally
                {
                    ipoBal.CloseDatabase();
                }

            }
            else if (MenuName == Indication_Forms_Title.IPODepositMultiTransfer_ApplyTogther)
            {
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                string[] app_Id = null;
                string[] TrnsId_To_TransId_IPoAcc = null;
                string Trade_Cust_Code = "";
                double Trade_Amount = 0.00;
                double amountTemp = 0.00;
                double[] ParentAmount = null;
                string[] custCodeTemp = null;
                string[] ParentWithDrawchek = null;
                string[] childWithdrawCheck = null;
                string IPOACC = dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString();
                string TRADEACC = dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString();
                string Application = dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString();
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                    if ((dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "IPOACC")
                        || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "TRADEACC")
                        || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "APPLICATION"))
                    {
                        transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();

                        transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToString(c.Cells["PaymentPosting_ID"].Value)).Distinct().ToArray();

                        /*Added by Rashedul on 06 jan 2015*/

                        app_Id = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();
                        amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                   .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                               .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();
                        custCodeTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                           .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();

                        Trade_Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();
                        Trade_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();

                    }
                    else if ((dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "IPOtoIPO")
                        || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "IPOtoIPO")
                        || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "TRIPOAPPLICATION"))
                    {
                        TrnsId_To_TransId_IPoAcc = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOtoIPO")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                        app_Id = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                          .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRIPOAPPLICATION")
                          .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                        /*Added by Rashedul on 06 jan 2015*/

                        ParentAmount = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                          .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOtoIPO" && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Withdraw")
                          .OrderBy(t => Convert.ToString(t.Cells["Customer"].Value))
                          .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).ToArray();
                        amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                   .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOtoIPO")
                               .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First(); ;
                        ParentWithDrawchek = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                           .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOtoIPO" && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Withdraw")
                           .OrderBy(t => Convert.ToString(t.Cells["Customer"].Value))
                           .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();
                        childWithdrawCheck = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                          .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOtoIPO" && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Deposit")
                       .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();
                    }
                }
                try
                {
                    ipoBal.ConnectDatabase();
                    if (transID_TRADEACC != null && transID_IPOACC != null)
                    {
                        ipoBal.Rejected_Mulit_Transfer_MoneyTransaction(transID_TRADEACC, transID_IPOACC, "Money Transaction Rejected");
                    }
                    else
                    {
                        ipoBal.Rejected_IPO_TO_IPO_Mulit_Transfer_MoneyTransaction(TrnsId_To_TransId_IPoAcc, "Money Transaction Rejected");
                    }
                    ipoBal.Rejected_IPO_To_IPO_IPOApplication(app_Id, GlobalVariableBO._userName, "Money Transaction Rejected");
                    ipoBal.Commit();
                }
                catch (Exception ex)
                {
                    ipoBal.RollBack();
                    throw ex;
                }
                finally
                {
                    ipoBal.CloseDatabase();
                }
            }
        }

        private void ApplyApprove()
        {
            
            if (MenuName == Indication_Forms_Title.IPOSingleTransferApproval)
            {
                string transID_IPOACC = "";
                string transID_TRADEACC = "";
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => c.Cells["ID"].Value.ToString()).SingleOrDefault();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => c.Cells["ID"].Value.ToString()).SingleOrDefault();
                }
                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Approved_Single_Transfer_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
                    //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(transID_IPOACC) });
                    //Track The Change
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));
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
            else if (MenuName == Indication_Forms_Title.Ipo_single_Deposit_approval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                int transID = 0;
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID = Convert.ToInt32(dg_IpoApproval.SelectedRows[0].Cells["ID"].Value);
                }
                string ApprovedBy = GlobalVariableBO._userName;

                try
                {
                    ipoBal.ConnectDatabase();                    
                    ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(transID, ApprovedBy);
                    //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(transID) });
                    //Track The Change
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID)));
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
            else if (MenuName == Indication_Forms_Title.IPOCheck_Clearence)
            {
                int transID_APP = 0;
                int transID_TRANS = 0;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string Payment_Media = string.Empty;
                var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();

                if (temp.Count > 0)
                {
                    Payment_Media = temp.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                       .Select(c => Convert.ToString(c.Cells["Transaction_type"].Value)).Distinct().SingleOrDefault();                  
                    if (Payment_Media == Indication_IPOPaymentTransaction.Cheque)
                    {
                        try
                        {
                            string[] Cust_Codes = temp.Cast<DataGridViewRow>()
                                .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                                .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();

                            var ChargedAccount_Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                                                .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION"
                                                    && Convert.ToString(t.Cells["Trans_Reason"].Value) == Indication_TransactioBasedCharge.GroupEntry_ChargedAccount_TransReason)
                                                 .Select(t => Convert.ToString(t.Cells["Customer"].Value)).FirstOrDefault();

                            var Deposit_Parent_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                                                .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION"
                                                    && Convert.ToString(t.Cells["Trans_Reason"].Value) == Indication_TransactioBasedCharge.GroupEntry_ChargedAccount_TransReason)
                                                .Select(t => Convert.ToInt32(t.Cells["ID"].Value)).FirstOrDefault();

                            Double DepositAmount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                                                   .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                                                   .Select(t => Convert.ToDouble(t.Cells["Amount"].Value)).Sum();

                            PaymentInfoBAL paybal = new PaymentInfoBAL();
                            double ChargedAmount = paybal.GetTransactionBasedCharges_ChargeAmount(Indication_TransactioBasedCharge.BankClearing, DepositAmount);

                            ipoBal.ConnectDatabase();

                            foreach (var cust_CodeTemp in Cust_Codes)
                            {
                                transID_APP = temp.Cast<DataGridViewRow>()
                                   .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION"
                                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp)
                                   .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                                transID_TRANS = temp.Cast<DataGridViewRow>()
                                   .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION"
                                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp)
                                   .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                                ipoBal.ChequeClear_MoneyTransaction_UITransApplied(transID_TRANS, GlobalVariableBO._userName);
                                Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_TRANS)));
                                //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(transID_TRANS) });

                                var AppAmount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                                                   .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION"
                                                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp)
                                                   .Select(t => Convert.ToString(t.Cells["Total_Amount"].Value)).FirstOrDefault();

                                var IpoBalance = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(cust_CodeTemp);

                                if (Convert.ToDouble(AppAmount) > Convert.ToDouble(IpoBalance))
                                    throw new Exception("Insufficient Balance");
                                //Business_Validation_Execution(dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToArray());

                                ipoBal.Approved_IPOApplication_UITransApplied(transID_APP, GlobalVariableBO._userName);
                                //Track The Change
                                Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Application, Convert.ToString(transID_APP)));
                                
                                //ipoBal.Insert_Into_93Account_Deposit_UITrans(new string[] { Convert.ToString(transID_TRANS) });
                            }
                            var IpoBalance_ChargedAccount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(ChargedAccount_Cust_Code);


                            if (Convert.ToDouble(ChargedAmount) > Convert.ToDouble(IpoBalance_ChargedAccount))
                                throw new Exception("Insufficient Balance For Charge Withdraw");
                            //Business_Validation_Execution(dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToArray());
                            CommonBAL objBal = new CommonBAL();
                            int InsertIdentity = ipoBal.Inesert_TransactionBasedCharge_Withdraw_UITransApplied(
                                    Indication_TransactioBasedCharge.BankClearing
                                    , ChargedAccount_Cust_Code
                                    , ChargedAmount
                                    , objBal.GetCurrentServerDate()
                                    , Deposit_Parent_ID);
                            //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(InsertIdentity) });

                            ipoBal.Commit();
                        }
                        catch (Exception ex)
                        {
                            ipoBal.RollBack();
                            throw ex;
                        }
                        finally
                        {
                            ipoBal.CloseDatabase();
                        }
                    }
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferApproval)
            {
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                }
                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Approved_Multi_Transfer_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
                    //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(transID_IPOACC.Select(t => Convert.ToString(t)).ToArray());
                    
                    //Track The Change
                    foreach (string temp in transID_IPOACC)
                        Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, temp));

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
            else if (MenuName == Indication_Forms_Title.IPODepositApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                int transID = 0;
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID = Convert.ToInt32(dg_IpoApproval.SelectedRows[0].Cells["ID"].Value);
                }
                string ApprovedBy = GlobalVariableBO._userName;
                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(transID, ApprovedBy);
                    //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(transID) });
                    
                    //Track The Change
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID)));

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
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                int transID = 0;
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID = Convert.ToInt32(dg_IpoApproval.SelectedRows[0].Cells["ID"].Value);
                }
                string ApprovedBy = GlobalVariableBO._userName;
                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(transID, ApprovedBy);
                    //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(transID) });
                    //Track The Change
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID)));
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
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval_Refund)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                IPOProcessBAL proBal=new IPOProcessBAL();
                int transID = 0;               
                               
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID = Convert.ToInt32(dg_IpoApproval.SelectedRows[0].Cells["ID"].Value);                    
                }

                string ApprovedBy = GlobalVariableBO._userName;
                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(transID, ApprovedBy);
                    //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(transID) });
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID)));
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

            else if (MenuName == Indication_Forms_Title.IPOAppApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                //Instance 
                IPOProcessBAL Bal = new IPOProcessBAL();
                double AppCharge = Bal.GetIPO_ChargeDef().Rows.Count > 0 ? Convert.ToDouble(Bal.GetIPO_ChargeDef().Rows[0]["AppCharge"]) : 0.00;
                double RefundCharge = 0.00;
                double TotalCharge = AppCharge + RefundCharge;

                double app_amount=0.00;
                string Cust_Code=string.Empty;

                int appID = 0;
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    appID = Convert.ToInt32(dg_IpoApproval.SelectedRows[0].Cells["ID"].Value);
                }
                string ApprovedBy = GlobalVariableBO._userName;

                app_amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Select(c => Convert.ToDouble(c.Cells["TotalAmount"].Value)).FirstOrDefault();
                Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Select(c => Convert.ToString(c.Cells["Cust_Code"].Value)).FirstOrDefault();
                var appdata = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().Select(t => t).FirstOrDefault();

                var IpoBalance = ipoBal.GetIPOCustomerBalance_ForApplication(Cust_Code);

                if (Convert.ToDouble(app_amount + AppCharge) > Convert.ToDouble(IpoBalance))
                    throw new Exception("Insufficient Balance");

                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Approved_IPOApplication_UITransApplied(appID, ApprovedBy);
                    int newIDChargeEntry=ipoBal.Inesert_IPoApplicationCharge_Withdraw_UITransApplied(appdata.Cells["Cust_Code"].Value.ToString(), AppCharge, Convert.ToInt32(appdata.Cells["IPOSession_ID"].Value), appdata.Cells["IPOSession_Name"].Value.ToString());
                    //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                    //ipoBal.Insert_Into_72Account_Deposit_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                    //Track The Change
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Application, Convert.ToString(appID)));
                    ipoBal.Commit();
                }
                catch (Exception ex)
                {
                    ipoBal.RollBack();
                }
                finally
                {
                    ipoBal.CloseDatabase();
                }

            }
                
            else if (MenuName == Indication_Forms_Title.IPOParentAccountTransferBackApproval)
            {
                string[] Dep_IPOAcc_ID = null;
                string[] With_IPOAcc_ID = null;
                string DEP_With_ID = "";
                
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();

                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    Dep_IPOAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "DEP_IPOACC")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                    With_IPOAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "WITH_IPOACC")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                    DEP_With_ID = string.Join(",", Dep_IPOAcc_ID) + "," + string.Join(",", With_IPOAcc_ID);
                }
                try
                {
                    ipoBal.Approved_Multi_Transfer_MoneyTransaction(DEP_With_ID);
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
            else if (MenuName == Indication_Forms_Title.IPOSingleTransferBackApproval)
            {
                string transID_IPOACC = "";
                string transID_TRADEACC = "";
                string Payment_Media = string.Empty;
                string code = "";
                double doubletryparse = 0.00;
                double RefundCharge = 0.00;
                int sessionId = 0;
                string SessionName = "";
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                IPOProcessBAL proBal = new IPOProcessBAL();
                DataTable dt_Charge = new DataTable();

                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c =>c.Cells["ID"].Value.ToString()).SingleOrDefault();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => c.Cells["ID"].Value.ToString()).SingleOrDefault();

                    Payment_Media = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                   .Where(t => Convert.ToString(t.Cells["Payment Method"].Value) != "")
                   .Select(t => Convert.ToString(t.Cells["Payment Method"].Value)).FirstOrDefault();

                    code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToString(c.Cells["Customer"].Value)).SingleOrDefault();
                    sessionId = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t =>Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToInt32(c.Cells["Intended_IPOSession_ID"].Value)).SingleOrDefault();
                    SessionName = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t =>Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["Intended_IPOSession_Name"].Value)).SingleOrDefault();
                    dt_Charge = proBal.GetIPO_ChargeDef();

                    if (double.TryParse(dt_Charge.Rows[0]["RefundCharge"].ToString(), out doubletryparse))
                    {
                        RefundCharge = doubletryparse;
                    }

                }
                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Approved_Single_TransferBack_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
                    //int newIDChargeEntry = ipoBal.Inesert_IPoApplicationCharge_Withdraw_UITransApplied(code, RefundCharge, sessionId, SessionName, Indication_TransactioBasedCharge.IPOAppRefund);
                    //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                    //bal.Insert_Into_72Account_Deposit_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                   // ipoBal.Insert_Into_72Account_Deposit_UITransApplied_NRB_Refund(new string[] { Convert.ToString(newIDChargeEntry) });
                    //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(transID_IPOACC) });
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));

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
            //else if (MenuName == Indication_Forms_Title.IPOSingleTransferBackApproval)
            //{
            //    int transID_IPOACC = 0;
            //    int transID_TRADEACC = 0;
            //    string Payment_Media = string.Empty;
            //    IPOApprovalBAL ipoBal = new IPOApprovalBAL();
            //    IPOProcessBAL proBal = new IPOProcessBAL();               

            //    if (dg_IpoApproval.SelectedRows.Count > 0)
            //    {
            //        transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
            //            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
            //            .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();

            //        transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
            //           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
            //           .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();
                    
            //        Payment_Media = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
            //       .Where(t => Convert.ToString(t.Cells["Payment Method"].Value) != "")
            //       .Select(t => Convert.ToString(t.Cells["Payment Method"].Value)).FirstOrDefault();
                    
            //    }
            //    try
            //    {
            //        ipoBal.ConnectDatabase();
            //        ipoBal.Approved_Single_TransferBack_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
            //        ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(transID_IPOACC) });
            //        ipoBal.Insert_Into_72Account_Deposit_UITransApplied(new string[] { Convert.ToString(transID_IPOACC) });
            //        Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));
                    
            //        ipoBal.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        ipoBal.RollBack();
            //        throw new Exception(ex.Message);
            //    }
            //    finally
            //    {
            //        ipoBal.CloseDatabase();
            //    }

            //}
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferBackApproval)
            {
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();                    
                }
                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Approved_Multi_TransferBack_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
                    //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(transID_IPOACC.Select(t => Convert.ToString(t)).ToArray());
                    foreach(var id in transID_IPOACC)
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName,string>(RealTimeTrackerName.Transaction,Convert.ToString(id)));
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

            else if (MenuName == Indication_Forms_Title.IPOWithdrawalSingleApproval)
            {
                string transID_IPOACC = "";
                string transID_TRADEACC = "";
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c =>c.Cells["ID"].Value.ToString()).SingleOrDefault();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => c.Cells["ID"].Value.ToString()).SingleOrDefault();
                }
                try
                {
                    ipoBal.ConnectDatabase();
                    ipoBal.Approved_Single_TransferWithdraw_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
                    //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(transID_IPOACC) });
                    //Track The Change
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));
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
            else if (MenuName == Indication_Forms_Title.IPOWithdrawalMultiApproval)
            {
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                string[] trnasID_Deposit = null;
                string[] transID_Withdraw = null;
                string WithdrawpaymentMedia = "";
                string DepositPaymentMedia = "";

                IPOApprovalBAL ipoBal = new IPOApprovalBAL();

                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    WithdrawpaymentMedia = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                  .Where(p => Convert.ToString(p.Cells["AccountName"].Value) == "IPOTOIPOWITHDRAW")
                  .Select(c => Convert.ToString(c.Cells["Payment Method"].Value)).First();

                    DepositPaymentMedia = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                      .Where(P => Convert.ToString(P.Cells["AccountName"].Value) == "IPOTOIPODEPOSIT")
                      .Select(c => Convert.ToString(c.Cells["Payment Method"].Value)).First();

                    if (WithdrawpaymentMedia == DepositPaymentMedia)
                    {
                        trnasID_Deposit = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOTOIPODEPOSIT")
                           .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                        transID_Withdraw = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOTOIPOWITHDRAW")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                    }
                    else
                    {
                        var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                        transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                        transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                    }
                }
                try
                {
                    ipoBal.ConnectDatabase();
                    if (DepositPaymentMedia == WithdrawpaymentMedia)
                    {
                        string DepositId_JointText = string.Join(",", trnasID_Deposit);
                        string WithdrawID_JoinText = string.Join(",", transID_Withdraw);
                        string JoinID = DepositId_JointText + "," + WithdrawID_JoinText;
                        ipoBal.Approved_Multi_Transfer_MoneyTransaction(JoinID);
                        //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied( JoinID.Split(',').ToArray());
                        
                        //Track The Change
                        foreach (string temp in trnasID_Deposit)
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(temp)));
                        foreach (string temp in transID_Withdraw)
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(temp)));
                    }
                    else
                    {
                        ipoBal.Approved_Multi_TransferWithdraw_MoneyTransaction(transID_TRADEACC, transID_IPOACC);
                        //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(transID_IPOACC.Select(t => Convert.ToString(t)).ToArray());
                        
                        //Track The Change
                        foreach (var id in transID_IPOACC)
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(id)));
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
            //Apply Together 
            else if (MenuName == Indication_Forms_Title.IPOMoneyDeposit_ApplyTogther)
            {
                int transID_APP;               
                int transID_TRANS ;
                int transID_TRADEACC;
                int transID_CHARGE;

                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string[] Payment_Media ;
                var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();

                if (temp.Count > 0)
                {
                    Payment_Media = temp.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                       .Select(c => Convert.ToString(c.Cells["Transaction_type"].Value)).ToArray();

                    if (Payment_Media.Distinct().Count()==1 && Payment_Media.Distinct().FirstOrDefault() == Indication_IPOPaymentTransaction.Cheque)
                    {
                        try
                        {
                            string[] Cust_Codes = temp.Cast<DataGridViewRow>()
                                .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                                .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();

                            ipoBal.ConnectDatabase();

                            foreach (var cust_CodeTemp in Cust_Codes)
                            {
                                transID_APP = temp.Cast<DataGridViewRow>()
                                   .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION"
                                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp)
                                   .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                                transID_TRANS = temp.Cast<DataGridViewRow>()
                                   .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION"
                                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp)
                                   .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                                transID_CHARGE = temp.Cast<DataGridViewRow>()
                                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "CHARGE"
                                         && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp)
                                    .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                                ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(transID_TRANS, GlobalVariableBO._userName);
                                Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_TRANS)));
                                //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(transID_TRANS) });

                                if (transID_CHARGE != 0)
                                {
                                    ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(transID_CHARGE, GlobalVariableBO._userName);
                                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_CHARGE)));
                                    //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(transID_CHARGE) });
                                }
                                
                                //Track The Change
                                Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Application, Convert.ToString(transID_APP)));
                                
                               

                                
                                //Commented By Shahrior on 07 Jan 2015

                                //var AppAmount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                                //                   .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION"
                                //                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp)
                                //                   .Select(t => Convert.ToString(t.Cells["Total_Amount"].Value)).FirstOrDefault();

                                //var IpoBalance = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(cust_CodeTemp);

                                //if (Convert.ToDouble(AppAmount) > Convert.ToDouble(IpoBalance))
                                //    throw new Exception("Insufficient Balance");                        

                                //ipoBal.Approved_IPOApplication_UITransApplied(transID_APP, GlobalVariableBO._userName);

                                //-------------------------------------

                            }
                            ipoBal.Commit();
                        }
                        catch (Exception ex)
                        {
                            ipoBal.RollBack();
                            throw ex;
                        }
                        finally
                        {
                            ipoBal.CloseDatabase();
                        }
                    }
                    else
                    {
                        try
                        {

                            string[] Cust_Codes = temp.Cast<DataGridViewRow>()
                                .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                                .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();

                            //Instance 
                            IPOProcessBAL Bal = new IPOProcessBAL();
                            double AppCharge = Bal.GetIPO_ChargeDef().Rows.Count > 0 ? Convert.ToDouble(Bal.GetIPO_ChargeDef().Rows[0]["AppCharge"]) : 0.00;
                            double RefundCharge = 0.00;
                            double TotalCharge = AppCharge + RefundCharge;


                            ipoBal.ConnectDatabase();

                            foreach (var cust_CodeTemp in Cust_Codes)
                            {
                                

                                var transID_APP_Cash = temp.Cast<DataGridViewRow>()
                                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION"
                                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp) 
                                    .Select(c => c).FirstOrDefault();

                                transID_APP = temp.Cast<DataGridViewRow>()
                                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION"
                                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp) 
                                    .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                                transID_TRANS = temp.Cast<DataGridViewRow>()
                                   .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION"
                                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp)
                                   .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                                ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(transID_TRANS, GlobalVariableBO._userName);
                                Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_TRANS)));                                
                                //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(transID_TRANS) });

                                var AppAmount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                                                   .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION"
                                                        && Convert.ToString(t.Cells["Customer"].Value) == cust_CodeTemp)
                                                   .Select(t => Convert.ToString(t.Cells["Amount"].Value)).FirstOrDefault();

                                var IpoBalance = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(cust_CodeTemp);

                                if (Convert.ToDouble(AppAmount+ AppCharge) > Convert.ToDouble(IpoBalance))
                                    throw new Exception("Insufficient Balance");
                                //Business_Validation_Execution(dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToArray());                                

                                //IPO Application Approval
                                ipoBal.Approved_IPOApplication_UITransApplied(transID_APP, GlobalVariableBO._userName);
                                Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Application, Convert.ToString(transID_APP)));

                                //IPO Application Charge
                                int newIDChargeEntry=ipoBal.Inesert_IPoApplicationCharge_Withdraw_UITransApplied(transID_APP_Cash.Cells["Customer"].Value.ToString(), AppCharge, Convert.ToInt32(transID_APP_Cash.Cells["Session_Id"].Value), transID_APP_Cash.Cells["Session_Name"].Value.ToString());
                                //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                                ipoBal.Insert_Into_72Account_Deposit_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });

                                
                                
                                
                            }
                            ipoBal.Commit();
                        }
                        catch (Exception ex)
                        {
                            ipoBal.RollBack();
                            throw ex;
                        }
                        finally
                        {
                            ipoBal.CloseDatabase();
                        }
                    }
                    
                }

            }
            else if (MenuName == Indication_Forms_Title.IPODepositSingleTransfer_ApplyTogther)
            {
                

                var selectRows = dg_IpoApproval.SelectedRows;
                string transID_IPOACC = "";
                string transID_TRADEACC = "";
                int charge_Cash_TransID = 0;
                int[] charge_TRIPO_TransID = null;
                string charge_TRTA_TransID_IPOACC = "";
                string charge_TRTA_TransID_TRADEACC = "";
                int App_ID = 0;
                DataGridViewRow App_DataGridView = new DataGridViewRow();

                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    //All 3 Ids Collection                    
                        transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => c.Cells["ID"].Value.ToString()).FirstOrDefault();

                        transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => c.Cells["ID"].Value.ToString()).SingleOrDefault();
                        App_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                           .Select(c => Convert.ToInt32(c.Cells["Application Id"].Value)).FirstOrDefault();
                    
                    App_DataGridView = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION").FirstOrDefault();

                    charge_Cash_TransID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "CHARGE_CASH_IPOACC")
                       .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                    charge_TRIPO_TransID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "CHARGE_TRIPO_IPOACC")
                       .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).ToArray();

                    charge_TRTA_TransID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "CHARGE_TRTA_IPOACC" && Convert.ToString(t.Cells["Deposit/Withdraw"])==Indication_PaymentMode.Deposit)
                       .Select(c => c.Cells["ID"].Value.ToString()).FirstOrDefault();

                    charge_TRTA_TransID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "CHARGE_TRTA_IPOACC" && Convert.ToString(t.Cells["Deposit/Withdraw"]) == Indication_PaymentMode.Withdraw)
                       .Select(c => c.Cells["ID"].Value.ToString()).FirstOrDefault();
                }
                try
                {
                    //Instance 
                    IPOProcessBAL Bal = new IPOProcessBAL();
                    double AppCharge = Bal.GetIPO_ChargeDef().Rows.Count > 0 ? Convert.ToDouble(Bal.GetIPO_ChargeDef().Rows[0]["AppCharge"]) : 0.00;
                    double RefundCharge = 0.00;
                    double TotalCharge = AppCharge + RefundCharge;
                    
                    ipoBal.ConnectDatabase();

                   

                    double Trade_amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                   .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "TRADEACC")
                               .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();
                    string Trade_custCodeTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "TRADEACC")
                     .Select(c => Convert.ToString(c.Cells["Customer"].Value)).First();

                    double IPO_amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                    .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                                .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();
                    
                    double IPO_App_TotalAmount = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                    .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "APPLICATION")
                                .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).FirstOrDefault();
                    
                    string IPO_custCodeTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                     .Select(c => Convert.ToString(c.Cells["Customer"].Value)).First();

                    PaymentInfoBAL P_Bal = new PaymentInfoBAL();
                    /*************Added By Sharior Vai ON 27-Jan-2015*************/
                    P_Bal.SetConnection(ipoBal.GetConnection());
                    /***********************************************/
                    /*************Added By Md.Rashedul Hasan ON 27-Jan-2015*********************/
                    foreach (DataRow dr in P_Bal.GetCurrentBalanceInfo_Uitrans(Trade_custCodeTemp).Rows)
                    {
                        double Current_Balance = Convert.ToDouble(dr["Current_Balance"]);
                        double Deduct500CurrentBalance = Convert.ToDouble(dr["CurrentMoneyDeduct500"]);
                        double Approve_Pending_Balance = Convert.ToDouble(dr["Approve_And_Pending_Balance"]);
                        double Pending_Deposit = Convert.ToDouble(dr["Pending_Deposit"]);
                        double Pending_Withdraw = Convert.ToDouble(dr["Pending_Withdraw"]);
                        if (!(Trade_amountTemp <= Deduct500CurrentBalance))
                        {
                            throw new Exception("Insufficient Balance For this Customer : " + Trade_custCodeTemp + "\nCurrent Balance is : " + Current_Balance + "\n Available Withdraw Balance is : " + Deduct500CurrentBalance + "\n Present Blance is : " + Approve_Pending_Balance + "\n Deposit Pending Balance is : " + Pending_Deposit + "\n Withdraw Pending Blance is : " + Pending_Withdraw);
                        }
                    }

                    ipoBal.Approved_Single_Transfer_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));

                    //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(transID_IPOACC) });

                    if (charge_Cash_TransID != 0)
                    {
                        //Media: Cash -Charge Deposit Extra
                        ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(charge_Cash_TransID, GlobalVariableBO._userName);
                        ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(charge_Cash_TransID) });
                        Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(charge_Cash_TransID)));
                    }
                    if ((!string.IsNullOrEmpty(charge_TRTA_TransID_IPOACC)) && (!string.IsNullOrEmpty(charge_TRTA_TransID_TRADEACC)))
                    {
                        //Media: TRTA -Charge Deposit Extra
                        ipoBal.Approved_Single_Transfer_MoneyTransaction_UITransApplied(charge_TRTA_TransID_TRADEACC,charge_TRTA_TransID_IPOACC);
                        //ipoBal.Insert_Into_71Account_Deposit_UITransApplied(new string[] { Convert.ToString(charge_TRTA_TransID_IPOACC) });
                        Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(charge_TRTA_TransID_IPOACC)));
                    }
                    if (charge_TRIPO_TransID!=null)
                    {
                        if (charge_TRIPO_TransID.Count()>0)
                            //Meida: TRIPO -Charge Deposit Extra
                            ipoBal.Approved_Single_Transfer_MoneyTransaction_UITransApplied(charge_TRIPO_TransID.Select(t=> Convert.ToString(t)).ToArray());
                        foreach (var id in charge_TRIPO_TransID.Select(t => Convert.ToString(t)).ToArray())
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(id)));
                    }

                    double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(IPO_custCodeTemp);
                    if (!((IPO_App_TotalAmount + AppCharge) <= balanceIPOAccount))
                    {
                        throw new Exception("Insufficient Balance");
                    }
                    ipoBal.Approved_IPOApplication_UITransApplied(App_ID, GlobalVariableBO._userName);
                    int newIDChargeEntry=ipoBal.Inesert_IPoApplicationCharge_Withdraw_UITransApplied(App_DataGridView.Cells["Customer"].Value.ToString(), AppCharge, Convert.ToInt32(App_DataGridView.Cells["Intended_IPOSession_ID"].Value), App_DataGridView.Cells["Intended_IPOSession_Name"].Value.ToString());
                    //ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                    ipoBal.Insert_Into_72Account_Deposit_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });

                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Application, Convert.ToString(App_ID)));
                    
                    
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
            else if (MenuName == Indication_Forms_Title.IPONRBMoneyDepositAndApplication)
            {
                IPOApprovalBAL bal = new IPOApprovalBAL();
                IPOProcessBAL P_Bla = new IPOProcessBAL();
                DataTable dt_Charge = new DataTable();
                DataTable dt_AccountBalance = new DataTable();

                string Trans_ID = "";
                string App_ID = "";
                string Chrage_Trans_ID = "";
                string cust_Code = "";
                string Company_Name = "";
                string Currency_Name = "";
                string SessionName = "";
                string Fd_No = "";
                int Session_ID = 0;
                double currency_Amount = 0.00;
                double Charge_Amount = 0.00;
                double Total_Charge_Amount = 0.00;
                double doubletryparse = 0.0;
                double CurrencyAmountByName = 0.00;
                double Min_App_Charge = 0.00;
                double LockAmount = 0.00;
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    Trans_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_Trans_ID")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).FirstOrDefault();
                    App_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_App_ID")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).FirstOrDefault();
                    Chrage_Trans_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_Charge_Trans_ID")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).FirstOrDefault();
                    Charge_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_Charge_Trans_ID")
                        .Select(c => Convert.ToDouble(c.Cells["Charge"].Value)).FirstOrDefault();
                    currency_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_Trans_ID")
                        .Select(c => Convert.ToDouble(c.Cells["Currency_Amount"].Value)).First();
                    cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_Trans_ID")
                        .Select(c => Convert.ToString(c.Cells["Cust_Code"].Value)).FirstOrDefault();
                    Currency_Name = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_Trans_ID")
                        .Select(c => Convert.ToString(c.Cells["Currency_Name"].Value)).FirstOrDefault();
                    Company_Name = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_App_ID")
                        .Select(c => Convert.ToString(c.Cells["Short_Code"].Value)).FirstOrDefault();
                    Fd_No = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_Trans_ID")
                        .Select(c => Convert.ToString(c.Cells["FD_NO"].Value)).FirstOrDefault();
                    Session_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_Trans_ID")
                        .Select(c => Convert.ToInt32(c.Cells["Intended_IPOSession_ID"].Value)).FirstOrDefault();
                    SessionName = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Account_Name"].Value) == "NRB_Trans_ID")
                        .Select(c => Convert.ToString(c.Cells["Intended_IPOSession_Name"].Value)).FirstOrDefault();
                    dt_Charge = P_Bla.GetIPO_ChargeDef();
                    CurrencyAmountByName = P_Bla.Get_NRB_IPO_Amount(Company_Name, Currency_Name);
                    dt_AccountBalance = P_Bla.GetIPOAccountInformation(cust_Code);
                    //IPOAccountTotalBalance = dt_AccountBalance.Rows.Cast<DataRow>().Select(c => Convert.ToDouble(c["Presenct_Balance"])).Sum();
                    LockAmount = dt_AccountBalance.Rows.Cast<DataRow>()
                        .Where(c => Convert.ToDouble(c["LockAmount"]) > 0)
                        .Select(c => Convert.ToDouble(c["LockAmount"])).FirstOrDefault();
                    //IPOAccount_Amount = IPOAccountTotalBalance - LockAmount;
                    if (double.TryParse(dt_Charge.Rows[0]["TotalCharge"].ToString(), out doubletryparse))
                    {
                        Total_Charge_Amount = doubletryparse;
                    }
                    if (double.TryParse(dt_Charge.Rows[0]["AppCharge"].ToString(), out doubletryparse))
                    {
                        Min_App_Charge = doubletryparse;
                    }
                    try
                    {
                        bal.ConnectDatabase();
                        double balanceIPOAccount1 = bal.GetIPOCustomerBalance_ForApplication_UITransApply(cust_Code);

                        
                        if (currency_Amount < CurrencyAmountByName)
                        {
                            throw new Exception("Currency Amount invalid");
                        }
                        //else
                        //{
                        bal.Update_NRBApplication_Money_UITrans(Trans_ID);
                        if (!string.IsNullOrEmpty(Chrage_Trans_ID))
                        {
                            bal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(Convert.ToInt32(Chrage_Trans_ID), GlobalVariableBO._userName);
                            bal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(Chrage_Trans_ID) });
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(Chrage_Trans_ID)));
                        }
                        //bal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(Convert.ToInt32(Chrage_Trans_ID), GlobalVariableBO._userName);
                        //bal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(Chrage_Trans_ID) });
                        //}
                        double Applicant_Amount_Towithdraw = bal.GetNRBReqApplicatinAmount(Trans_ID, cust_Code, Fd_No, Session_ID);
                        double balanceIPOAccount = bal.GetIPOCustomerBalance_ForApplication_UITransApply(cust_Code);
                        if ((balanceIPOAccount - LockAmount) < Total_Charge_Amount)
                        {
                            throw new Exception("Charge Amount invalid");
                        }
                        if (Applicant_Amount_Towithdraw < (CurrencyAmountByName))
                        {
                            throw new Exception("Insufficient Balance to withdraw");
                        }
                        if (Min_App_Charge > (balanceIPOAccount - LockAmount))
                        {
                            throw new Exception("Insufficient Charge Amount");
                        }
                        bal.Approve_NRB_IPO_Application(Trans_ID, App_ID, Chrage_Trans_ID, Min_App_Charge, Currency_Name, currency_Amount);
                        int newIDChargeEntry = bal.Inesert_IPoApplicationCharge_Withdraw_UITransApplied(cust_Code, Min_App_Charge, Session_ID, SessionName, Indication_TransactioBasedCharge.IPONRBApp);
                        //bal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                        bal.Insert_Into_72Account_Deposit_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                        bal.Commit();
                    }
                    catch (Exception ex)
                    {
                        bal.RollBack();
                        throw new Exception(ex.Message);
                    }
                }
            }
                
                
            else if (MenuName == Indication_Forms_Title.IPOMoneyRefund_ForNrb)
            {
                DataTable dt_Charge = new DataTable();
                IPOApprovalBAL bal = new IPOApprovalBAL();
                IPOProcessBAL P_Bla = new IPOProcessBAL();
                dt_Charge = P_Bla.GetIPO_ChargeDef();
                double doubletryparse = 0.00;
                double RefundCharge = 0.00;
                IEnumerable<DataGridViewRow> row = null;
                if (double.TryParse(dt_Charge.Rows[0]["RefundCharge"].ToString(), out doubletryparse))
                {
                    RefundCharge = doubletryparse;
                }
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    row = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().AsEnumerable();
                }
                try
                {

                    bal.ConnectDatabase();
                    if (dg_IpoApproval.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow code in dg_IpoApproval.Rows)
                        {
                            bal.NRB_DraftRefundApprove(code.Cells["Nrb_ID"].Value.ToString());
                            int newIDChargeEntry = bal.Inesert_IPoApplicationCharge_Withdraw_UITransApplied(code.Cells["Cust_Code"].Value.ToString(), RefundCharge, Convert.ToInt32(code.Cells["Intended_IPOSession_ID"].Value), code.Cells["Intended_IPOSession_Name"].Value.ToString(), Indication_TransactioBasedCharge.IPONRBAppRefund);
                            bal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                            //bal.Insert_Into_72Account_Deposit_UITransApplied_NRB_Refund(new string[] { Convert.ToString(newIDChargeEntry) });
                            bal.Insert_Into_72Account_Deposit_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                        }
                    }
                    //bal.NRB_DraftRefundApprove(RefundCharge, Indication_TransactioBasedCharge.IPONRBAppRefund);
                    bal.Commit();
                }
                catch (Exception ex)
                {
                    bal.RollBack();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    bal.CloseDatabase();
                }

            }
            else if (MenuName == Indication_Forms_Title.IPODepositMultiTransfer_ApplyTogther)
            {

                /*Added by Rashedul on 06 jan 2015*/
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                List<DataGridViewRow> app_Id_Cust_Code =new List<DataGridViewRow>();
                string[] TrnsId_To_TransId_IPoAcc = null;
                string[] Deposit_Trans_Id = null;
                string[] Withdraw_Trans_Id = null;
                string Trade_Cust_Code = "";
                double Trade_Amount = 0.00;
                double amountTemp = 0.00;
                double App_Amount=0.00;
                double[] ParentAmount = null;
                string[] custCodeTemp = null;
                string[] ParentWithDrawchek = null;
                string[] childWithdrawCheck = null;
                double With_Charge_Amount = 0.00;
                double Dep_Charge_Amount = 0.00;
                string[] Charge_TradeAcc_ID = null;
                string[] Charge_IPoAcc_ID = null;
                string[] app_Cust_Code=null;
                
                string[] Cash_Charge_ID = null;

                string ChTRTA_MTRTA_Cust_Code = "";
                string ChTRIPO_MTRIPO_Cust_Code = "";
                string ChTRTA_MTRIPO_Cust_Code="";
                string TransferFromCode=string.Empty;
                string ChTRIPO_MTRTA_Cust_Code = "";
                string[] ChTRTA_MTRTA_TradeAcc_ID=null;
                string[] ChTRTA_MTRTA_IPoAcc_ID=null;
                string[] ChTRIPO_MTRTA_TradeAcc_ID = null;
                string[] ChTRIPO_MTRTA_IPoAcc_ID = null;
                string[] ChCash_MTRTA_Charge_ID = null;
                string[] ChTRTA_MTRIPO_TradeAcc_ID = null;
                string[] ChTRTA_MTRIPO_IPoAcc_ID = null;
                string[] ChTRIPO_MTRIPO_TradeAcc_ID = null;
                string[] ChTRIPO_MTRIPO_IPoAcc_ID = null;
                string[] ChCash_MTRIPO_Charge_ID = null;

                string IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                    .Where(c => c.Cells["AccountName"].Value.ToString() == "IPOACC")
                    .Select(c => c.Cells["AccountName"].Value.ToString()).FirstOrDefault();
                string TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                    .Where(c => c.Cells["AccountName"].Value.ToString() == "TRADEACC")
                    .Select(c => c.Cells["AccountName"].Value.ToString()).FirstOrDefault();
                string Application = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                    .Where(c => c.Cells["AccountName"].Value.ToString() == "APPLICATION"
                        || c.Cells["AccountName"].Value.ToString() == "TRIPOAPPLICATION")
                    .Select(c => c.Cells["AccountName"].Value.ToString()).FirstOrDefault();

                string Deposit_IPOAcc = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                    .Where(c => c.Cells["AccountName"].Value.ToString() == "DEP_IPOtoIPO")
                    .Select(c => c.Cells["AccountName"].Value.ToString()).FirstOrDefault();
                string Withdraw_IPOAcc = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                    .Where(c => c.Cells["AccountName"].Value.ToString() == "With_IPOtoIPO")
                    .Select(c => c.Cells["AccountName"].Value.ToString()).FirstOrDefault();


                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                IPOProcessBAL Bal=new IPOProcessBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                    //if ((dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "IPOACC")
                    //    || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "TRADEACC")
                    //    || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "APPLICATION")
                    //    || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "W_TRADEACC_Charge")
                    //    || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "D_IPOAcc_Charge"))
                    
                    if (IPOACC == "IPOACC" && TRADEACC == "TRADEACC" && Application == "APPLICATION")
                    {
                        transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();

                        transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToString(c.Cells["PaymentPosting_ID"].Value)).Distinct().ToArray();

                        /*Added by Rashedul on 06 jan 2015*/
                        app_Id_Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION").ToList();
                            //.Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();

                        App_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                           .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).FirstOrDefault();

                        amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                   .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                               .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).FirstOrDefault();
                        
                        custCodeTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                           .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();

                        Trade_Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();
                        
                        Trade_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).FirstOrDefault();

                        With_Charge_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "W_TRADEACC_Charge")
                           .Select(c => Convert.ToDouble(c.Cells["IPO Charge"].Value)).FirstOrDefault();

                        Dep_Charge_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "D_IPOAcc_Charge")
                           .Select(c => Convert.ToDouble(c.Cells["IPO Charge"].Value)).FirstOrDefault();

                        ChTRTA_MTRTA_Cust_Code = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                          .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "W_TRADEACC_Charge")
                       .Select(c => Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();

                        ChTRIPO_MTRTA_Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "With_IPOtoIPO_Charge")
                        .Select(c => Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();

                        TransferFromCode = Convert.ToString(ChTRTA_MTRTA_Cust_Code == string.Empty ? ChTRIPO_MTRTA_Cust_Code : ChTRTA_MTRTA_Cust_Code);

                        ChTRTA_MTRTA_TradeAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "W_TRADEACC_Charge")
                           .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();
                        ChTRTA_MTRTA_IPoAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "D_IPOAcc_Charge")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();                       

                        ChTRIPO_MTRTA_TradeAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                          .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "With_IPOtoIPO_Charge")
                          .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();
                        ChTRIPO_MTRTA_IPoAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "DEP_IPOtoIPO_Charge")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();

                        ChCash_MTRTA_Charge_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "DEP_Cash_Charge")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();

                    }
                    //else if ((dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "DEP_IPOtoIPO")
                    //    || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "With_IPOtoIPO")
                    //    || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "TRIPOAPPLICATION")
                    //    || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "TRIPOAPPLICATION")
                    //    || (dg_IpoApproval.CurrentRow.Cells["AccountName"].Value.ToString() == "TRIPOAPPLICATION"))
                    else if (Deposit_IPOAcc == "DEP_IPOtoIPO" && Withdraw_IPOAcc == "With_IPOtoIPO" && Application == "TRIPOAPPLICATION")
                    {
                        Deposit_Trans_Id = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "DEP_IPOtoIPO")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                        Withdraw_Trans_Id = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "With_IPOtoIPO")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                        app_Id_Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                          .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRIPOAPPLICATION").ToList();
                        
                        App_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                          .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRIPOAPPLICATION")
                         .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).FirstOrDefault();

                        //app_Cust_Code=dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        //  .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRIPOAPPLICATION")
                        //  .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();

                        /*Added by Rashedul on 06 jan 2015*/

                        ChTRIPO_MTRIPO_Cust_Code = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                           .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "With_IPOtoIPO_Charge")
                        .Select(c => Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();

                        ParentAmount = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                          .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "With_IPOtoIPO"
                              && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Withdraw")
                          .OrderBy(t => Convert.ToString(t.Cells["Customer"].Value))
                          .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).ToArray();
                        amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                   .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "DEP_IPOtoIPO")
                               .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();
                        ParentWithDrawchek = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                           .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "With_IPOtoIPO"
                               && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Withdraw")
                           .OrderBy(t => Convert.ToString(t.Cells["Customer"].Value))
                           .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();
                        childWithdrawCheck = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                          .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "DEP_IPOtoIPO"
                              && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Deposit")
                       .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();

                        With_Charge_Amount = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                          .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "With_IPOtoIPO_Charge"
                              && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Withdraw")
                          .Select(c => Convert.ToDouble(c.Cells["IPO Charge"].Value)).FirstOrDefault();

                        Dep_Charge_Amount = With_Charge_Amount = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                          .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "DEP_IPOtoIPO_Charge"
                              && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Deposit")
                          .Select(c => Convert.ToDouble(c.Cells["IPO Charge"].Value)).FirstOrDefault();

                        ChTRTA_MTRIPO_Cust_Code = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                         .Where(c => Convert.ToString(c.Cells["AccountName"].Value) == "W_TRADEACC_Charge")
                      .Select(c => Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();

                        ChTRIPO_MTRIPO_Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "With_IPOtoIPO_Charge")
                        .Select(c => Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();

                        TransferFromCode = Convert.ToString(ChTRTA_MTRIPO_Cust_Code == string.Empty ? ChTRIPO_MTRIPO_Cust_Code : ChTRTA_MTRIPO_Cust_Code);

                        ChTRTA_MTRIPO_TradeAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "W_TRADEACC_Charge")
                           .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();
                        ChTRTA_MTRIPO_IPoAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "D_IPOAcc_Charge")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();


                        ChTRIPO_MTRIPO_TradeAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                          .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "With_IPOtoIPO_Charge")
                          .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();
                        ChTRIPO_MTRIPO_IPoAcc_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "DEP_IPOtoIPO_Charge")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();

                        ChCash_MTRIPO_Charge_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "DEP_Cash_Charge")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();
                    }
                }
                try
                {

                    //Instance 
                    
                    double AppCharge = Bal.GetIPO_ChargeDef().Rows.Count > 0 ? Convert.ToDouble(Bal.GetIPO_ChargeDef().Rows[0]["AppCharge"]) : 0.00;
                    double RefundCharge = 0.00;
                    double TotalCharge = AppCharge + RefundCharge;
                    
                    ipoBal.ConnectDatabase();
                    if (transID_IPOACC != null && transID_TRADEACC != null)
                    {
                        //Need To Update Check Trade Account Balance
                        PaymentInfoBAL P_Bal = new PaymentInfoBAL();
                        /*************Added By Sharior Vai ON 27-Jan-2015*************/
                        P_Bal.SetConnection(ipoBal.GetConnection());
                        /***********************************************/
                        /*************Added By Md.Rashedul Hasan ON 27-Jan-2015*********************/
                        foreach (DataRow dr in P_Bal.GetCurrentBalanceInfo_Uitrans(Trade_Cust_Code).Rows)
                        {
                            double Current_Balance = Convert.ToDouble(dr["Current_Balance"]);
                            double Deduct500CurrentBalance = Convert.ToDouble(dr["CurrentMoneyDeduct500"]);
                            double Approve_Pending_Balance = Convert.ToDouble(dr["Approve_And_Pending_Balance"]);
                            double Pending_Deposit = Convert.ToDouble(dr["Pending_Deposit"]);
                            double Pending_Withdraw = Convert.ToDouble(dr["Pending_Withdraw"]);
                            if (!(Trade_Amount <= Deduct500CurrentBalance))
                            {
                                throw new Exception("Insufficient Balance For this Customer : " + Trade_Amount + "\nCurrent Balance is : " + Current_Balance + "\n Available Withdraw Balance is : " + Deduct500CurrentBalance + "\n Present Blance is : " + Approve_Pending_Balance + "\n Deposit Pending Balance is : " + Pending_Deposit + "\n Withdraw Pending Blance is : " + Pending_Withdraw);
                            }
                        }
                        
                        //Charge Calcualton
                        if (TransferFromCode != null )
                        {
                            DataTable dt = P_Bal.GetCurrentBalanceInfo_Uitrans(TransferFromCode);
                            double DoubleTryParse = 0.00;
                            double Present_Balance_For_Charge_Code = 0.00;
                            if (dt.Rows.Count > 0)
                            {
                                if (double.TryParse(dt.Rows[0]["CurrentMoneyDeduct500"].ToString(), out DoubleTryParse))
                                {
                                    Present_Balance_For_Charge_Code = DoubleTryParse;
                                }
                            }
                            if (Present_Balance_For_Charge_Code < With_Charge_Amount)
                            {
                                throw new Exception("Insufficient Balance For Charge Code" + TransferFromCode);
                            }
                        }
                        //
                        /*Trade Charge Account concate*/
                       
                        var concate_Trade = ConcatArrays(transID_TRADEACC, ChTRTA_MTRTA_TradeAcc_ID);
                        var Concate_IPO = ConcatArrays(transID_IPOACC, ChTRTA_MTRTA_IPoAcc_ID);
                        ipoBal.Approved_Multi_Transfer_MoneyTransaction_UITransApplied(concate_Trade.ToArray(), Concate_IPO.ToArray());
                        foreach (var id in Concate_IPO)
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(id)));
                       
                        //Charge Taken By TRIPO & Cash
                        var Concate_Trade = ConcatArrays(ChTRIPO_MTRTA_TradeAcc_ID, ChTRIPO_MTRTA_IPoAcc_ID, ChCash_MTRTA_Charge_ID);
                        ipoBal.Approved_Single_Transfer_MoneyTransaction_UITransApplied(Concate_Trade.ToArray());

                        foreach (var id in Concate_Trade)
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(id)));
                        
                        var concate_Charge_EffectIPO = ConcatArrays(ChTRIPO_MTRTA_TradeAcc_ID, ChTRIPO_MTRTA_IPoAcc_ID, ChCash_MTRTA_Charge_ID);
                        ipoBal.Insert_Into_71Account_Deposit_UITransApplied(concate_Charge_EffectIPO.ToArray());
                      
                        foreach (string s in custCodeTemp)
                        {
                            double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(s);
                            if (!((App_Amount+AppCharge) <= balanceIPOAccount))
                            {
                                throw new Exception("Insufficient Balance");
                            }
                        }
                    }
                    //ipoBal.Insert_Into_93Account_Deposit_UITrans(transID_IPOACC);
                    else
                    {

                        for (int i = 0; i < ParentAmount.Length; i++)
                        {
                            double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(ParentWithDrawchek[i]);

                            if (!(ParentAmount[i] <= balanceIPOAccount))
                            {
                                throw new Exception("Insufficient Balance");
                            }
                        }
                        double ChargeWithdraw_Amount = 0.00;
                        if (TransferFromCode != null)
                        {
                            ChargeWithdraw_Amount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(TransferFromCode);
                            if (With_Charge_Amount > ChargeWithdraw_Amount)
                            {
                                throw new Exception("Insufficient Balance For this code " + TransferFromCode);
                            }
                        }

                        //TrnsId_To_TransId_IPoAcc = new string[] { Deposit_Trans_Id, Withdraw_Trans_Id };
                        //TrnsId_To_TransId_IPoAcc.Concat(Charge_TradeAcc_ID);
                        //TrnsId_To_TransId_IPoAcc.Concat(Charge_IPoAcc_ID);
                        
                        var Concate_TrnsId_To_TransId_IPoAcc = ConcatArrays(ChTRIPO_MTRIPO_TradeAcc_ID, ChTRIPO_MTRIPO_IPoAcc_ID, ChCash_MTRIPO_Charge_ID, Deposit_Trans_Id,Withdraw_Trans_Id);

                        ipoBal.Approved_Single_Transfer_MoneyTransaction_UITransApplied(Concate_TrnsId_To_TransId_IPoAcc.ToArray());
                        
                        foreach (var id in Concate_TrnsId_To_TransId_IPoAcc)
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(id)));

                        //Charge Taken By TRTA
                        ipoBal.Approved_Multi_Transfer_MoneyTransaction_UITransApplied(ChTRTA_MTRIPO_TradeAcc_ID, ChTRTA_MTRIPO_IPoAcc_ID);

                        foreach (var id in ChTRTA_MTRIPO_IPoAcc_ID)
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(id)));

                        var concate_Charge_EffectIPO = ConcatArrays(ChTRIPO_MTRIPO_TradeAcc_ID, ChTRIPO_MTRIPO_IPoAcc_ID, ChCash_MTRIPO_Charge_ID);
                        ipoBal.Insert_Into_71Account_Deposit_UITransApplied(concate_Charge_EffectIPO.ToArray());
                        
                        foreach (string s in childWithdrawCheck)
                        {
                            double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(s);
                            if (!((App_Amount + AppCharge) <= balanceIPOAccount))
                            {
                                throw new Exception("Insufficient Balance");
                            }
                        }
                    }

                    
                    foreach (DataGridViewRow value in app_Id_Cust_Code)
                    {
                        ipoBal.Approved_IPOApplication_UITransApplied(Convert.ToInt32(value.Cells["ID"].Value), GlobalVariableBO._userName);
                        int newIDChargeEntry=ipoBal.Inesert_IPoApplicationCharge_Withdraw_UITransApplied(value.Cells["Customer"].Value.ToString(), AppCharge, Convert.ToInt32(value.Cells["Intended_IPOSession_ID"].Value), value.Cells["Intended_IPOSession_Name"].Value.ToString());
                        ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                        ipoBal.Insert_Into_72Account_Deposit_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                        Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Application, Convert.ToString(value.Cells["ID"].Value)));
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
                //-----------------------------------------------------------
            }
           
        }

        //Added BY Md.Rashedul Hasan
        public static T[] ConcatArrays<T>(params T[][] list)
        {
            var result = new T[list.Sum(a => a.Length)];
            int offset = 0;
            for (int x = 0; x < list.Length; x++)
            {
                list[x].CopyTo(result, offset);
                offset += list[x].Length;
            }
            return result;
        }
       
        private double GetTransactionChargeAmount(string ChangeName,double Amount)
        {
            double result=0.00;
            PaymentInfoBAL bal=new PaymentInfoBAL();
            result=bal.GetTransactionBasedCharges_ChargeAmount(ChangeName,Amount);
            return result;
        }

        //private void ChargeApply()
        //{
        //    #region Check Charge Apply
        //    double doubleTryParse = 0;
        //    double Charge_Rate = 0;
        //    double Charge_Amount = 0;
        //    bool isChargeApplied = true; ;

        //    double selected_Requisition_Amount = 0;
        //    PaymentInfoBAL bal = new PaymentInfoBAL();
        //    PaymentInfoBO payInfoBo = new PaymentInfoBO();
        //    DataTable dt = new DataTable();

        //    IPOApprovalBAL ChargeBal = new IPOApprovalBAL();
        //    dt = ChargeBal.GetCharegeList();
        //    if (double.TryParse(dg_IpoApproval.Rows[0].Cells["Amount"].Value.ToString(), out doubleTryParse))
        //    {
        //        selected_Requisition_Amount = doubleTryParse;
        //    }
        //    int ChargeId = dt.Rows.Cast<DataRow>()
        //        .Where(t => Convert.ToInt32(t["Minimum_Effective_Amount"]) >= doubleTryParse)
        //        .Select(c => Convert.ToInt32(c["Charge_ID"])).FirstOrDefault();
        //    string ChargeName = dt.Rows.Cast<DataRow>()
        //        .Where(t => Convert.ToInt32(t["Minimum_Effective_Amount"]) >= doubleTryParse)
        //        .Select(c => Convert.ToString(c["Charge_Name"])).FirstOrDefault();


        //    selected_Requisition_Amount = doubleTryParse;
        //    dt = ChargeBal.GetIPOTransactionBasedCharges(ChargeId, Indication_TransactioBasedCharge.BankClearing, selected_Requisition_Amount);
        //    if (dt.Rows.Count > 0)
        //    {
        //        string ChargeType = Indication_TransactioBasedCharge.ChargeTypeList.Where(t => t.Key == ChargeName).Select(t => t.Value).SingleOrDefault();
        //        string TransReason = Indication_TransactioBasedCharge.TransReasonList.Where(t => t.Key == ChargeName).Select(t => t.Value).SingleOrDefault();

        //        if (ChargeType == Indication_TransactioBasedCharge.Charge_Rate)
        //        {
        //            if (double.TryParse(dt.Rows[0]["Charge_Rate"].ToString(), out doubleTryParse))
        //                Charge_Rate = doubleTryParse;
        //        }
        //        else if (ChargeType == Indication_TransactioBasedCharge.Charge_Amount)
        //        {
        //            if (double.TryParse(dt.Rows[0]["Charge_Amount"].ToString(), out doubleTryParse))
        //                Charge_Amount = doubleTryParse;
        //        }

        //        if ((ChargeType == Indication_TransactioBasedCharge.Charge_Amount && Charge_Amount == 0) || (ChargeType == Indication_TransactioBasedCharge.Charge_Rate && Charge_Rate == 0))
        //            isChargeApplied = false;

        //        if (Indication_TransactioBasedCharge.ExceptionString.GetValues(Indication_TransactioBasedCharge.BankClearing).ToList().Contains(payInfoBo.BankName))
        //            isChargeApplied = false;
        //    }
        //    if (isChargeApplied == true)
        //    {
        //        string code=dg_IpoApproval.Rows.Cast<DataGridViewRow>()
        //            .Where(t=>Convert.ToString(t.Cells["Transaction_type"].Value)=="Cheque")
        //            .Select(c=>Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();
        //        string voucher=dg_IpoApproval.Rows.Cast<DataGridViewRow>()
        //            .Where(t=>Convert.ToString(t.Cells["Voucher"].Value)=="Cheque")
        //            .Select(c=>Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();
        //        ChargeBal.Insert_Cheque_Charge("88", "Deposit", voucher, code);
        //    }
        //    #endregion
        //}

        private void ApplyApproveAll()
        {
            if (MenuName == Indication_Forms_Title.IPOSingleTransferApproval)
            {
                DataTable dt = new DataTable();
                int transID_IPOACC = 0;
                int transID_TRADEACC = 0;
                double Trade_Amount = 0.00;
                string cust_code="";
                PaymentInfoBAL P_Bal = new PaymentInfoBAL();
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string[] voucherList = null;
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    voucherList = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Select(t => Convert.ToString(t.Cells["Customer"].Value))
                        .Distinct().ToArray();
                }
                foreach (string voucherTemp in voucherList)
                {
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp 
                                && Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                         .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp 
                             && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                            .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();
                    cust_code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                         .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp 
                             && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                            .Select(c => Convert.ToString(c.Cells["Customer"].Value)).SingleOrDefault();
                    Trade_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp
                            && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).SingleOrDefault();

                    
                    foreach (DataRow dr in P_Bal.GetCurrentBalanceInfo(cust_code).Rows)
                    {
                        double Current_Balance = Convert.ToDouble(dr["Current_Balance"]);
                        double Deduct500CurrentBalance = Convert.ToDouble(dr["CurrentMoneyDeduct500"]);
                        double Approve_Pending_Balance = Convert.ToDouble(dr["Approve_And_Pending_Balance"]);
                        double Pending_Deposit = Convert.ToDouble(dr["Pending_Deposit"]);
                        double Pending_Withdraw = Convert.ToDouble(dr["Pending_Withdraw"]);
                        if (!(Trade_Amount <= Deduct500CurrentBalance))
                        {
                            throw new Exception("Insufficient Balance For this Customer : " + Trade_Amount + "\nCurrent Balance is : " + Current_Balance + "\n Available Withdraw Balance is : " + Deduct500CurrentBalance + "\n Present Blance is : " + Approve_Pending_Balance + "\n Deposit Pending Balance is : " + Pending_Deposit + "\n Withdraw Pending Blance is : " + Pending_Withdraw);
                        }
                    }
                     
                    ipoBal.Approved_Single_Transfer_MoneyTransaction(transID_TRADEACC, transID_IPOACC);
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));
                }


            }
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferApproval)
            {
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                string cust_code = "";
                double Trade_Amount = 0.00;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                PaymentInfoBAL P_Bal = new PaymentInfoBAL();
                string[] voucherList = null;


                if (dg_IpoApproval.Rows.Count > 0)
                {
                    voucherList = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Select(t => Convert.ToString(t.Cells["SelectionId"].Value))
                        .Distinct().ToArray();
                }
                foreach (string voucherTemp in voucherList)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["SelectionId"].Value) == voucherTemp
                            && Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["SelectionId"].Value) == voucherTemp
                           && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                    cust_code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                         .Where(t => Convert.ToString(t.Cells["SelectionId"].Value) == voucherTemp
                             && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                            .Select(c => Convert.ToString(c.Cells["Customer"].Value)).SingleOrDefault();
                    Trade_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["SelectionId"].Value) == voucherTemp
                            && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).SingleOrDefault();


                    foreach (DataRow dr in P_Bal.GetCurrentBalanceInfo(cust_code).Rows)
                    {
                        double Current_Balance = Convert.ToDouble(dr["Current_Balance"]);
                        double Deduct500CurrentBalance = Convert.ToDouble(dr["CurrentMoneyDeduct500"]);
                        double Approve_Pending_Balance = Convert.ToDouble(dr["Approve_And_Pending_Balance"]);
                        double Pending_Deposit = Convert.ToDouble(dr["Pending_Deposit"]);
                        double Pending_Withdraw = Convert.ToDouble(dr["Pending_Withdraw"]);
                        if (!(Trade_Amount <= Deduct500CurrentBalance))
                        {
                            throw new Exception("Insufficient Balance For this Customer : " + Trade_Amount + "\nCurrent Balance is : " + Current_Balance + "\n Available Withdraw Balance is : " + Deduct500CurrentBalance + "\n Present Blance is : " + Approve_Pending_Balance + "\n Deposit Pending Balance is : " + Pending_Deposit + "\n Withdraw Pending Blance is : " + Pending_Withdraw);
                        }
                    }
                    ipoBal.Approved_Multi_Transfer_MoneyTransaction(transID_TRADEACC, transID_IPOACC);

                }
            }
            else if (MenuName == Indication_Forms_Title.IPOParentAccountTransferBackApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string[] DepId = null;
                string[] WithID = null;
                string Dep_With_ID = "";
                string[] selectionID = null;
                List<string> Con_Cust_Code = new List<string>();
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    selectionID = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Select(c => Convert.ToString(c.Cells["SelectionID"].Value)).Distinct().ToArray();
                }
                foreach (string S_ID in selectionID)
                {
                    DepId = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == S_ID
                            && Convert.ToString(c.Cells["AccountName"].Value) == "DEP_IPOACC")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                    WithID=dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == S_ID
                            && Convert.ToString(c.Cells["AccountName"].Value) == "WITH_IPOACC")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();                   
                    Dep_With_ID = string.Join(",", DepId) + "," + string.Join(",", WithID);
                    Con_Cust_Code.Add(Dep_With_ID);
                    
                }
                Dep_With_ID = string.Join(",", Con_Cust_Code.ToArray());
                ipoBal.Approved_Multi_Transfer_MoneyTransaction(Dep_With_ID);
                
            }
            else if (MenuName == Indication_Forms_Title.IPODepositApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                int transID = 0;
                foreach (DataGridViewRow dr in dg_IpoApproval.Rows)
                {
                    transID = Convert.ToInt32(dr.Cells["ID"].Value);

                    string ApprovedBy = GlobalVariableBO._userName;

                    ipoBal.Approved_Single_NonTransfer_MoneyTransaction(transID, ApprovedBy);
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                IPOProcessBAL P_Bal = new IPOProcessBAL();
                int transID = 0;
                decimal Amount = 0.00M;
                string cust_code = "";
                foreach (DataGridViewRow dr in dg_IpoApproval.Rows)
                {
                    transID = Convert.ToInt32(dr.Cells["ID"].Value);
                    cust_code = Convert.ToString(dr.Cells["customer"].Value);
                    Amount = Convert.ToDecimal(dr.Cells["Amount"].Value);

                    string ApprovedBy = GlobalVariableBO._userName;
                    EntryBlanceChecking(cust_code, Amount);

                    ipoBal.Approved_Single_NonTransfer_MoneyTransaction(transID, ApprovedBy);
                }

            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawApproval_Refund)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                IPOProcessBAL P_Bal = new IPOProcessBAL();
                int transID = 0;
                decimal Amount = 0.00M;
                string cust_code = "";
                foreach (DataGridViewRow dr in dg_IpoApproval.Rows)
                {
                    transID = Convert.ToInt32(dr.Cells["ID"].Value);
                    cust_code = Convert.ToString(dr.Cells["customer"].Value);
                    Amount = Convert.ToDecimal(dr.Cells["Amount"].Value);

                    string ApprovedBy = GlobalVariableBO._userName;
                    EntryBlanceChecking(cust_code, Amount);

                    ipoBal.Approved_Single_NonTransfer_MoneyTransaction(transID, ApprovedBy);
                }

            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawalSingleApproval)
            {
                string transID_IPOACC = "";
                string transID_TRADEACC = "";
                string[] cust_Code = null;
                string IPO_Cust_Code = "";
                double IPO_Amount = 0.0;
                double balanceIPOAccount = 0.0;

                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Select(c => Convert.ToString(c.Cells["Customer"].Value)).Distinct().ToArray();
                }
                foreach (string code in cust_Code)
                {
                    IPO_Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Customer"].Value) == code
                            && Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["Customer"].Value)).First();

                    IPO_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(c => Convert.ToString(c.Cells["Customer"].Value) == code
                            && Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();

                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => c.Cells["ID"].Value.ToString()).SingleOrDefault();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => c.Cells["ID"].Value.ToString()).SingleOrDefault();

                    balanceIPOAccount = ipoBal.GetIPOCustomerBalance(IPO_Cust_Code);
                    //EntryBlanceChecking(IPO_Cust_Code, IPO_Amount);

                    if (!(IPO_Amount <= balanceIPOAccount))
                    {
                        throw new Exception("Insufficient Balance");
                    }
                    else
                    {
                        try
                        {
                            ipoBal.ConnectDatabase();
                            ipoBal.Approved_Single_TransferWithdraw_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
                            ipoBal.Insert_Into_93Account_Deposit_UITrans(new string[] { Convert.ToString(transID_IPOACC) });
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));
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
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOWithdrawalMultiApproval)
            {
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                string[] trnasID_Deposit = null;
                string[] transID_Withdraw = null;
                string WithdrawpaymentMedia = "";
                string DepositPaymentMedia = "";
                string[] SelectionId = null;
                string cust_code = "";
                double Amount = 0.0;
                double balanceIPOAccount = 0.0;


                IPOApprovalBAL ipoBal = new IPOApprovalBAL();

                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    SelectionId = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Select(c => Convert.ToString(c.Cells["SelectionID"].Value)).Distinct().ToArray();
                }
                foreach (string S_id in SelectionId)
                {
                    WithdrawpaymentMedia = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                  .Where(p => Convert.ToString(p.Cells["SelectionID"].Value) == S_id &&
                    Convert.ToString(p.Cells["AccountName"].Value) == "IPOTOIPOWITHDRAW")
                  .Select(c => Convert.ToString(c.Cells["Payment Method"].Value)).First();

                    DepositPaymentMedia = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                      .Where(P => Convert.ToString(P.Cells["SelectionID"].Value) == S_id &&
                          Convert.ToString(P.Cells["AccountName"].Value) == "IPOTOIPODEPOSIT")
                      .Select(c => Convert.ToString(c.Cells["Payment Method"].Value)).First();


                    if (WithdrawpaymentMedia == DepositPaymentMedia)
                    {
                        trnasID_Deposit = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == S_id &&
                               Convert.ToString(t.Cells["AccountName"].Value) == "IPOTOIPODEPOSIT")
                           .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                        transID_Withdraw = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == S_id &&
                                Convert.ToString(t.Cells["AccountName"].Value) == "IPOTOIPOWITHDRAW")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                        cust_code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == S_id &&
                                Convert.ToString(t.Cells["AccountName"].Value) == "IPOTOIPOWITHDRAW")
                            .Select(c => Convert.ToString(c.Cells["Customer"].Value)).First();

                        Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == S_id &&
                                Convert.ToString(t.Cells["AccountName"].Value) == "IPOTOIPOWITHDRAW")
                            .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();
                        balanceIPOAccount = ipoBal.GetIPOCustomerBalance(cust_code);
                    }
                    else
                    {
                        var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                        transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == S_id &&
                                Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                        transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == S_id &&
                               Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                        cust_code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == S_id &&
                                Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).First();

                        Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == S_id &&
                                Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();
                        balanceIPOAccount = ipoBal.GetIPOCustomerBalance(cust_code);
                    }

                    if (!(Amount <= balanceIPOAccount))
                    {
                        throw new Exception("Insufficient Balance");
                    }
                    else
                    {
                        try
                        {

                            ipoBal.ConnectDatabase();
                            if (DepositPaymentMedia == WithdrawpaymentMedia)
                            {
                                string DepositId_JointText = string.Join(",", trnasID_Deposit);
                                string WithdrawID_JoinText = string.Join(",", transID_Withdraw);
                                string JoinID = DepositId_JointText + "," + WithdrawID_JoinText;
                                ipoBal.Approved_Multi_Transfer_MoneyTransaction(JoinID);
                            }
                            else
                            {
                                ipoBal.Approved_Multi_TransferWithdraw_MoneyTransaction(transID_TRADEACC, transID_IPOACC);
                                foreach (var id in transID_IPOACC)
                                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(id)));
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
                }

            }
            else if (MenuName == Indication_Forms_Title.IPOAppApproval)
            {
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                int appID = 0;
                foreach (DataGridViewRow dr in dg_IpoApproval.Rows)
                {
                    appID = Convert.ToInt32(dr.Cells["ID"].Value);

                    string ApprovedBy = GlobalVariableBO._userName;

                    ipoBal.Approved_IPOApplication(appID, ApprovedBy);
                }

            }
            else if (MenuName == Indication_Forms_Title.IPOSingleTransferBackApproval)
            {
                int transID_IPOACC = 0;
                int transID_TRADEACC = 0;
                double doubletryparse = 0.00;
                double RefundCharge = 0.00;
                int sessionId = 0;
                string SessionName = "";
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                IPOProcessBAL P_Bal = new IPOProcessBAL();
                string[] voucherList = null;
                DataTable dt_Charge = new DataTable();
                dt_Charge = P_Bal.GetIPO_ChargeDef();
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    voucherList = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Select(t => Convert.ToString(t.Cells["Customer"].Value))
                        .Distinct().ToArray();
                }
                if (double.TryParse(dt_Charge.Rows[0]["RefundCharge"].ToString(), out doubletryparse))
                {
                    RefundCharge = doubletryparse;
                }
                foreach (string voucherTemp in voucherList)
                {
                    transID_IPOACC = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp
                                && Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();

                    transID_TRADEACC = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                         .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp
                             && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                            .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();
                    sessionId = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp
                                && Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToInt32(c.Cells["Intended_IPOSession_ID"].Value)).SingleOrDefault();
                    SessionName = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp
                                && Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["Intended_IPOSession_Name"].Value)).SingleOrDefault();
                    ipoBal.Approved_Single_TransferBack_MoneyTransaction(transID_TRADEACC, transID_IPOACC);
                    //int newIDChargeEntry = ipoBal.Inesert_IPoApplicationCharge_Withdraw_UITransApplied(voucherTemp, RefundCharge, sessionId, "", Indication_TransactioBasedCharge.IPOAppRefund);
                   // ipoBal.Insert_Into_71Account_Withdraw_UITransApplied(new string[] { Convert.ToString("") });
                    //bal.Insert_Into_72Account_Deposit_UITransApplied(new string[] { Convert.ToString(newIDChargeEntry) });
                    //ipoBal.Insert_Into_72Account_Deposit_UITransApplied_NRB_Refund(new string[] { Convert.ToString("") });
                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));
                }

            }
            //else if (MenuName == Indication_Forms_Title.IPOSingleTransferBackApproval)
            //{
            //    int transID_IPOACC = 0;
            //    int transID_TRADEACC = 0;
            //    IPOApprovalBAL ipoBal = new IPOApprovalBAL();
            //    string[] voucherList = null;
            //    if (dg_IpoApproval.Rows.Count > 0)
            //    {
            //        voucherList = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
            //            .Select(t => Convert.ToString(t.Cells["Customer"].Value))
            //            .Distinct().ToArray();
            //    }
            //    foreach (string voucherTemp in voucherList)
            //    {
            //        transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
            //                .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp
            //                    && Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
            //                .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();

            //        transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
            //             .Where(t => Convert.ToString(t.Cells["Customer"].Value) == voucherTemp
            //                 && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
            //                .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).SingleOrDefault();

            //        ipoBal.Approved_Single_TransferBack_MoneyTransaction(transID_TRADEACC, transID_IPOACC);
            //        Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));
            //    }
                

            //}
            else if (MenuName == Indication_Forms_Title.IPOMultiTransferBackApproval)
            {
                string[] transID_IPOACC = null;
                string[] transID_TRADEACC = null;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string[] voucherList = null;
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    voucherList = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Select(t => Convert.ToString(t.Cells["Voucher No"].Value))
                        .Distinct().ToArray();
                }
                foreach (string voucherTemp in voucherList)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();
                    transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["Voucher No"].Value) == voucherTemp && Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                        .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                    transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["Voucher No"].Value) == voucherTemp && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                       .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();
                    ipoBal.Approved_Multi_TransferBack_MoneyTransaction(transID_TRADEACC, transID_IPOACC);
                    foreach (var id in transID_IPOACC)
                        Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(id)));
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOMoneyDeposit_ApplyTogther)
            {
                int transID_AppID = 0;
                int transID_TransID = 0;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string[] transRefIdList = null;
                string Payment_Media = string.Empty;
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    transRefIdList = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Select(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value))
                        .Distinct().ToArray();
                }
                foreach (string refIDTemp in transRefIdList)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();

                    transID_AppID = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp && Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                    transID_TransID = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp && Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                       .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                    Payment_Media = dg_IpoApproval.Rows.Cast<DataGridViewRow>().ToList()
                    .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp && Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                    .Select(t => Convert.ToString(t.Cells["Transaction_type"].Value)).FirstOrDefault();


                    if (!(Payment_Media == Indication_IPOPaymentTransaction.Cheque))
                    {
                        try
                        {
                            ipoBal.ConnectDatabase();
                            
                            ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(transID_TransID, GlobalVariableBO._userName);
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName,string>(RealTimeTrackerName.Transaction,Convert.ToString(transID_TransID)));
                            var cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                                                .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp
                                                && Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                                                .Select(t => Convert.ToString(t.Cells["Customer"].Value)).FirstOrDefault();
                            var AppAmount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                                                .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp
                                                && Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                                                .Select(t => Convert.ToString(t.Cells["Total_Amount"].Value)).FirstOrDefault();
                            var IpoBalance = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(cust_Code);

                            if (Convert.ToDouble(AppAmount) > Convert.ToDouble(IpoBalance))
                                throw new Exception("Insufficient Balance");
                            //var rows = dg_IpoApproval.Rows.Cast<DataGridViewRow>().ToList()
                            //    .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp).ToArray();

                            //Business_Validation_Execution(rows);

                            ipoBal.Approved_IPOApplication_UITransApplied(transID_AppID, GlobalVariableBO._userName);
                            ipoBal.Commit();
                        }
                        catch (Exception ex)
                        {
                            ipoBal.RollBack();
                            throw ex;
                        }
                        finally
                        {
                            ipoBal.CloseDatabase();
                        }
                    }
                    else if (Payment_Media == Indication_IPOPaymentTransaction.Cheque)
                    {
                        try
                        {
                            ipoBal.ConnectDatabase();
                            
                            ipoBal.Approved_Single_NonTransfer_MoneyTransaction_UITransApplied(transID_TransID, GlobalVariableBO._userName);
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_TransID)));
                            
                            ipoBal.Commit();
                        }
                        catch (Exception ex)
                        {
                            ipoBal.RollBack();
                            throw ex;
                        }
                        finally
                        {
                            ipoBal.CloseDatabase();
                        }
                    }
                }
            }
            else if (MenuName == Indication_Forms_Title.IPOCheck_Clearence)
            {
                int transID_AppID = 0;
                int transID_TransID = 0;
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                string[] transRefIdList = null;
                string Payment_Media = string.Empty;

                if (dg_IpoApproval.Rows.Count > 0)
                {
                    transRefIdList = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Select(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value))
                        .Distinct().ToArray();
                }
                foreach (string refIDTemp in transRefIdList)
                {
                    var temp = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList();

                    transID_AppID = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp && Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                        .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                    transID_TransID = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                       .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp && Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                       .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).FirstOrDefault();

                    Payment_Media = dg_IpoApproval.Rows.Cast<DataGridViewRow>().ToList()
                    .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp && Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                    .Select(t => Convert.ToString(t.Cells["Transaction_type"].Value)).FirstOrDefault();
                    try
                    {
                        ipoBal.ConnectDatabase();
                        
                        ipoBal.ChequeClear_MoneyTransaction_UITransApplied(transID_TransID, GlobalVariableBO._userName);
                        Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_TransID)));
                        //var cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                        //                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "TRANSACTION")
                        //                    .Select(t => Convert.ToString(t.Cells["Customer"].Value)).FirstOrDefault();
                        //var AppAmount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToList()
                        //                    .Where(t => Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                        //                    .Select(t => Convert.ToString(t.Cells["Total_Amount"].Value)).FirstOrDefault();
                        //var IpoBalance = ipoBal.GetIPOCustomerBalance_FroAppApproval_UITransApplied(cust_Code);

                        //if (Convert.ToDouble(AppAmount) > Convert.ToDouble(IpoBalance))
                        //    throw new Exception("Insufficient Balance");
                        var rows = dg_IpoApproval.Rows.Cast<DataGridViewRow>().ToList()
                                .Where(t => Convert.ToString(t.Cells["Transaction_Ref_Id"].Value) == refIDTemp).ToArray();

                        Business_Validation_Execution(rows);
                        ipoBal.Approved_IPOApplication_UITransApplied(transID_AppID, GlobalVariableBO._userName);
                        ipoBal.Commit();
                    }
                    catch (Exception ex)
                    {
                        ipoBal.RollBack();
                        throw ex;
                    }
                    finally
                    {
                        ipoBal.CloseDatabase();
                    }
                }
            }
            else if (MenuName == Indication_Forms_Title.IPODepositSingleTransfer_ApplyTogther)
            {
                var selectRows = dg_IpoApproval.SelectedRows;
                string transID_IPOACC = "";
                string transID_TRADEACC = "";
                int App_ID = 0;
                string[] Application_Id = null;

                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.SelectedRows.Count > 0)
                {
                    Application_Id = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                        .Select(c => Convert.ToString(c.Cells["Application Id"].Value)).Distinct().ToArray();
                }
                if (Application_Id.Length > 0)
                {
                    foreach (string Id in Application_Id)
                    {
                        transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(t => Convert.ToString(t.Cells["Application Id"].Value) == Id
                                && Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => c.Cells["ID"].Value.ToString()).SingleOrDefault();

                        transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["Application Id"].Value) == Id
                               && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => c.Cells["ID"].Value.ToString()).SingleOrDefault();

                        App_ID = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                           .Where(t => Convert.ToString(t.Cells["Application Id"].Value) == Id
                                    && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                           .Select(c => Convert.ToInt32(c.Cells["Application Id"].Value)).SingleOrDefault();


                        try
                        {
                            ipoBal.ConnectDatabase();

                            double Trade_amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                           .Where(c => Convert.ToString(c.Cells["Application Id"].Value) == Id
                                               && Convert.ToString(c.Cells["AccountName"].Value) == "TRADEACC")
                                       .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();

                            string Trade_custCodeTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                .Where(c => Convert.ToString(c.Cells["Application Id"].Value) == Id
                                    && Convert.ToString(c.Cells["AccountName"].Value) == "TRADEACC")
                             .Select(c => Convert.ToString(c.Cells["Customer"].Value)).First();

                            double IPO_amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                            .Where(c => Convert.ToString(c.Cells["Application Id"].Value) == Id
                                                && Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                                        .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First();

                            string IPO_custCodeTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                .Where(c => Convert.ToString(c.Cells["Application Id"].Value) == Id
                                    && Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                             .Select(c => Convert.ToString(c.Cells["Customer"].Value)).First();

                            PaymentInfoBAL P_Bal = new PaymentInfoBAL();
                            /*************Added By Sharior Vai ON 27-Jan-2015*************/
                            P_Bal.SetConnection(ipoBal.GetConnection());
                            /***********************************************/
                            /*************Added By Md.Rashedul Hasan ON 27-Jan-2015*********************/
                            foreach (DataRow dr in P_Bal.GetCurrentBalanceInfo_Uitrans(Trade_custCodeTemp).Rows)
                            {
                                double Current_Balance = Convert.ToDouble(dr["Current_Balance"]);
                                double Deduct500CurrentBalance = Convert.ToDouble(dr["CurrentMoneyDeduct500"]);
                                double Approve_Pending_Balance = Convert.ToDouble(dr["Approve_And_Pending_Balance"]);
                                double Pending_Deposit = Convert.ToDouble(dr["Pending_Deposit"]);
                                double Pending_Withdraw = Convert.ToDouble(dr["Pending_Withdraw"]);
                                if (!(Trade_amountTemp <= Deduct500CurrentBalance))
                                {
                                    throw new Exception("Insufficient Balance For this Customer : " + Trade_custCodeTemp + "\nCurrent Balance is : " + Current_Balance + "\n Available Withdraw Balance is : " + Deduct500CurrentBalance + "\n Present Blance is : " + Approve_Pending_Balance + "\n Deposit Pending Balance is : " + Pending_Deposit + "\n Withdraw Pending Blance is : " + Pending_Withdraw);
                                }
                            }

                            ipoBal.Approved_Single_Transfer_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
                            Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(transID_IPOACC)));

                            double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(IPO_custCodeTemp);
                            if (!(IPO_amountTemp <= balanceIPOAccount))
                            {
                                throw new Exception("Insufficient Balance");
                            }
                            ipoBal.Approved_IPOApplication_UITransApplied(App_ID, GlobalVariableBO._userName);
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
                }
            }
            else if (MenuName == Indication_Forms_Title.IPODepositMultiTransfer_ApplyTogther)
            {
                string[] transID_IPOACC = null;
                string[] Selection_ID = null;
                string[] transID_TRADEACC = null;
                string[] app_Id = null;
                string[] TrnsId_To_TransId_IPoAcc = null;
                string Deposit_Trans_Id = "";
                string Withdraw_Trans_Id = "";
                string Trade_Cust_Code = "";
                double Trade_Amount = 0.00;
                double amountTemp = 0.00;
                double[] ParentAmount = null;
                string[] IPO_Acc_CustCode = null;
                string[] ParentWithDrawchek = null;
                string[] childWithdrawCheck = null;
                string Application_Name = "";
                string IPO_Account = "";
                string Trade_Account = "";
                string TRIPO_Application = "";
                string DEP_IPOToIPO = "";
                string With_IPOtoIPO = "";
                IPOApprovalBAL ipoBal = new IPOApprovalBAL();
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    Selection_ID = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                        .Select(t => Convert.ToString(t.Cells["SelectionID"].Value)).Distinct().ToArray();
                }
                if (Selection_ID.Length > 0)
                {
                    foreach (string AppLication_ID in Selection_ID)
                    {
                        transID_IPOACC = null;
                        transID_TRADEACC = null;
                        app_Id = null;
                        TrnsId_To_TransId_IPoAcc = null;
                        Deposit_Trans_Id = "";
                        Withdraw_Trans_Id = "";
                        Trade_Cust_Code = "";
                        Trade_Amount = 0.00;
                        amountTemp = 0.00;
                        ParentAmount = null;
                        IPO_Acc_CustCode = null;
                        ParentWithDrawchek = null;
                        childWithdrawCheck = null;
                        Application_Name = "";
                        IPO_Account = "";
                        Trade_Account = "";
                        TRIPO_Application = "";
                        DEP_IPOToIPO = "";
                        With_IPOtoIPO = "";

                        Application_Name = dg_IpoApproval.Rows.Cast<DataGridViewRow>()
                            .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                && Convert.ToString(c.Cells["AccountName"].Value) == "APPLICATION")
                            .Select(t => Convert.ToString(t.Cells["AccountName"].Value)).FirstOrDefault();

                        IPO_Account = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                && Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                            .Select(t => Convert.ToString(t.Cells["AccountName"].Value)).FirstOrDefault();

                        Trade_Account = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                && Convert.ToString(c.Cells["AccountName"].Value) == "TRADEACC")
                            .Select(t => Convert.ToString(t.Cells["AccountName"].Value)).FirstOrDefault();

                        TRIPO_Application = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                && Convert.ToString(c.Cells["AccountName"].Value) == "TRIPOAPPLICATION")
                            .Select(t => Convert.ToString(t.Cells["AccountName"].Value)).FirstOrDefault();

                        DEP_IPOToIPO = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                && Convert.ToString(c.Cells["AccountName"].Value) == "DEP_IPOtoIPO")
                            .Select(t => Convert.ToString(t.Cells["AccountName"].Value)).FirstOrDefault();

                        With_IPOtoIPO = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                            .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                && Convert.ToString(c.Cells["AccountName"].Value) == "With_IPOtoIPO")
                            .Select(t => Convert.ToString(t.Cells["AccountName"].Value)).FirstOrDefault();

                        if (Application_Name == "APPLICATION" && IPO_Account == "IPOACC" && Trade_Account == "TRADEACC")
                        {
                            transID_IPOACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                                    .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == AppLication_ID
                                        && Convert.ToString(t.Cells["AccountName"].Value) == "IPOACC")
                                    .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();

                            transID_TRADEACC = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                               .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == AppLication_ID &&
                                        Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                               .Select(c => Convert.ToString(c.Cells["PaymentPosting_ID"].Value)).Distinct().ToArray();

                            /*Added by Rashedul on 06 jan 2015*/

                            app_Id = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                                .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == AppLication_ID
                                    && Convert.ToString(t.Cells["AccountName"].Value) == "APPLICATION")
                                .Select(c => Convert.ToString(c.Cells["ID"].Value)).Distinct().ToArray();

                            amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                       .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                           && Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                                   .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).FirstOrDefault();

                            IPO_Acc_CustCode = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                               .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                   && Convert.ToString(c.Cells["AccountName"].Value) == "IPOACC")
                            .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();

                            Trade_Cust_Code = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                               .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == AppLication_ID
                                    && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                               .Select(c => Convert.ToString(c.Cells["Customer"].Value)).FirstOrDefault();

                            Trade_Amount = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                               .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == AppLication_ID
                                   && Convert.ToString(t.Cells["AccountName"].Value) == "TRADEACC")
                               .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).FirstOrDefault();
                        }
                        else
                        {
                            Deposit_Trans_Id = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                                    .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == AppLication_ID
                                        && Convert.ToString(t.Cells["AccountName"].Value) == "DEP_IPOtoIPO")
                                    .Select(c => Convert.ToString(c.Cells["ID"].Value)).FirstOrDefault();

                            Withdraw_Trans_Id = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                                .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == AppLication_ID
                                    && Convert.ToString(t.Cells["AccountName"].Value) == "With_IPOtoIPO")
                                .Select(c => Convert.ToString(c.Cells["ID"].Value)).FirstOrDefault();
                            TrnsId_To_TransId_IPoAcc = new string[] { Deposit_Trans_Id, Withdraw_Trans_Id };

                            app_Id = dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>()
                              .Where(t => Convert.ToString(t.Cells["SelectionID"].Value) == AppLication_ID
                                  && Convert.ToString(t.Cells["AccountName"].Value) == "TRIPOAPPLICATION")
                              .Select(c => Convert.ToString(c.Cells["ID"].Value)).ToArray();

                            /*Added by Rashedul on 06 jan 2015*/

                            ParentAmount = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                              .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                  && Convert.ToString(c.Cells["AccountName"].Value) == "With_IPOtoIPO"
                                  && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Withdraw")
                              .OrderBy(t => Convert.ToString(t.Cells["Customer"].Value))
                              .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).ToArray();

                            amountTemp = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                                       .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                           && Convert.ToString(c.Cells["AccountName"].Value) == "DEP_IPOtoIPO")
                                   .Select(c => Convert.ToDouble(c.Cells["Amount"].Value)).First(); ;
                            ParentWithDrawchek = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                               .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                   && Convert.ToString(c.Cells["AccountName"].Value) == "With_IPOtoIPO"
                                   && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Withdraw")
                               .OrderBy(t => Convert.ToString(t.Cells["Customer"].Value))
                               .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();

                            childWithdrawCheck = dg_IpoApproval.SelectedRows.OfType<DataGridViewRow>()
                              .Where(c => Convert.ToString(c.Cells["SelectionID"].Value) == AppLication_ID
                                  && Convert.ToString(c.Cells["AccountName"].Value) == "DEP_IPOtoIPO"
                                  && Convert.ToString(c.Cells["Deposit/Withdraw"].Value) == "Deposit")
                           .Select(c => Convert.ToString(c.Cells["Customer"].Value)).ToArray();
                        }
                        try
                        {
                            ipoBal.ConnectDatabase();
                            if (transID_IPOACC != null && transID_TRADEACC != null)
                            {
                                //Need To Update Check Trade Account Balance
                                PaymentInfoBAL P_Bal = new PaymentInfoBAL();
                                /*************Added By Sharior Vai ON 27-Jan-2015*************/
                                P_Bal.SetConnection(ipoBal.GetConnection());
                                /***********************************************/
                                /*************Added By Md.Rashedul Hasan ON 27-Jan-2015*********************/
                                foreach (DataRow dr in P_Bal.GetCurrentBalanceInfo_Uitrans(Trade_Cust_Code).Rows)
                                {
                                    double Current_Balance = Convert.ToDouble(dr["Current_Balance"]);
                                    double Deduct500CurrentBalance = Convert.ToDouble(dr["CurrentMoneyDeduct500"]);
                                    double Approve_Pending_Balance = Convert.ToDouble(dr["Approve_And_Pending_Balance"]);
                                    double Pending_Deposit = Convert.ToDouble(dr["Pending_Deposit"]);
                                    double Pending_Withdraw = Convert.ToDouble(dr["Pending_Withdraw"]);
                                    if (!(Trade_Amount <= Deduct500CurrentBalance))
                                    {
                                        throw new Exception("Insufficient Balance For this Customer : " + Trade_Amount + "\nCurrent Balance is : " + Current_Balance + "\n Available Withdraw Balance is : " + Deduct500CurrentBalance + "\n Present Blance is : " + Approve_Pending_Balance + "\n Deposit Pending Balance is : " + Pending_Deposit + "\n Withdraw Pending Blance is : " + Pending_Withdraw);
                                    }
                                }

                                ipoBal.Approved_Multi_Transfer_MoneyTransaction_UITransApplied(transID_TRADEACC, transID_IPOACC);
                                foreach (string s in IPO_Acc_CustCode)
                                {
                                    double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(s);
                                    if (!(amountTemp <= balanceIPOAccount))
                                    {
                                        throw new Exception("Insufficient Balance");
                                    }
                                }

                            }
                            //ipoBal.Insert_Into_93Account_Deposit_UITrans(transID_IPOACC);
                            else if (TRIPO_Application == "TRIPOAPPLICATION" && DEP_IPOToIPO == "DEP_IPOtoIPO" && With_IPOtoIPO == "With_IPOtoIPO")
                            {

                                for (int i = 0; i < ParentAmount.Length; i++)
                                {
                                    double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(ParentWithDrawchek[i]);

                                    if (!(ParentAmount[i] <= balanceIPOAccount))
                                    {
                                        throw new Exception("Insufficient Balance");
                                    }
                                }

                                ipoBal.Approved_Single_Transfer_MoneyTransaction_UITransApplied(TrnsId_To_TransId_IPoAcc);
                                foreach (var id in TrnsId_To_TransId_IPoAcc)
                                    Form_Transaction_IDs.Add(new KeyValuePair<RealTimeTrackerName, string>(RealTimeTrackerName.Transaction, Convert.ToString(id)));

                                foreach (string s in childWithdrawCheck)
                                {
                                    double balanceIPOAccount = ipoBal.GetIPOCustomerBalance_ForApplication_UITransApply(s);
                                    if (!(amountTemp <= balanceIPOAccount))
                                    {
                                        throw new Exception("Insufficient Balance");
                                    }
                                }
                            }
                            if (TRIPO_Application == "TRIPOAPPLICATION" || Application_Name == "APPLICATION")
                            {
                                foreach (string id in app_Id)
                                {
                                    ipoBal.Approved_IPOApplication_UITransApplied(Convert.ToInt32(id), GlobalVariableBO._userName);
                                }
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
                }
            }
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    Business_Validation_Execution(dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToArray());
                }
                ApplyApprove();
                //RealTimeExportSMSServer_MoneyTransaction();
                MessageBox.Show("Succesfully Approved!!");
                LoadGrid();
                LoadGridMode();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            LoadGrid();
            LoadGridMode();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyReject();
                MessageBox.Show("Succesfully Rejected!!");
                LoadGrid();
                LoadGridMode();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcceptAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_IpoApproval.Rows.Count > 0)
                {
                    //dg_IpoApproval.SelectAll();
                    Business_Validation_Execution(dg_IpoApproval.SelectedRows.Cast<DataGridViewRow>().ToArray());
                }
                
                ApplyApproveAll();
                MessageBox.Show("Succesfully Approved!!");
                LoadGrid();
                LoadGridMode();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dg_IpoApproval_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dg_IpoApproval.SelectedRows;

            if (selectedRows.Count > 0)
            {

                if (MenuName == Indication_Forms_Title.IPOMultiTransferApproval 
                    || MenuName == Indication_Forms_Title.IPOMultiTransferBackApproval 
                    || MenuName == Indication_Forms_Title.IPOWithdrawalMultiApproval)
                {
                    string SelectionID = "";
                    string voucher_Temp = Convert.ToString(selectedRows[0].Cells["Voucher No"].Value);
                    if (MenuName == Indication_Forms_Title.IPOWithdrawalMultiApproval)
                    {
                        SelectionID = Convert.ToString(selectedRows[0].Cells["SelectionID"].Value);
                        SelectedSameVoucher(voucher_Temp, SelectionID);
                    }
                    else
                    {
                        SelectedSameVoucher(voucher_Temp);
                    }
                    //string voucher_Temp = Convert.ToString(selectedRows[0].Cells["Voucher No"].Value);
                    //SelectedSameVoucher(voucher_Temp);
                }
                else if (MenuName == Indication_Forms_Title.IPOSingleTransferApproval 
                    || MenuName == Indication_Forms_Title.IPOSingleTransferBackApproval 
                    || MenuName == Indication_Forms_Title.IPOWithdrawalSingleApproval)
                {
                    if (MenuName == Indication_Forms_Title.IPOWithdrawalSingleApproval)
                    {
                        string PostingId = Convert.ToString(selectedRows[0].Cells["SelectionID"].Value);
                        SelectedSameVoucher(PostingId);
                    }
                    else
                    {
                        string voucher_Temp = Convert.ToString(selectedRows[0].Cells["Voucher No"].Value);
                        SelectedSameVoucher(voucher_Temp);
                    }
                    //string voucher_Temp = Convert.ToString(selectedRows[0].Cells["Voucher No"].Value);
                    //SelectedSameVoucher(voucher_Temp);
                }
                else if (MenuName == Indication_Forms_Title.IPOMoneyDeposit_ApplyTogther 
                    || MenuName == Indication_Forms_Title.IPOCheck_Clearence)
                {
                    string bankName = selectedRows[0].Cells["Bank_Name"].Value.ToString();
                    string RoutingNo = selectedRows[0].Cells["Routing_No"].Value.ToString();
                    string ChequeNo = selectedRows[0].Cells["Cheque_No"].Value.ToString();
                    if (ChequeNo != "" && RoutingNo != "" && bankName != "")
                    {
                        SelectSameBankRoutingCheque(bankName, RoutingNo, ChequeNo);
                    }
                    else
                    {
                        string montransId = Convert.ToString(selectedRows[0].Cells["Transaction_Ref_Id"].Value);
                        SelectSameMoneyTransId(montransId);
                    }
                }
                else if (MenuName == Indication_Forms_Title.IPODepositSingleTransfer_ApplyTogther)
                {
                    string Cust_Code = selectedRows[0].Cells["Customer"].Value.ToString();
                    //string Amount = selectedRows[0].Cells["Amount"].Value.ToString();
                    string AppId = selectedRows[0].Cells["Application Id"].Value.ToString();
                    string voucher = selectedRows[0].Cells["Voucher No"].Value.ToString();
                    
                    //if (String.IsNullOrEmpty(voucher))
                    //{
                        
                    SelectSameCustCodeandAmount(Cust_Code, AppId,voucher);
                    //}
                    //else
                    //{
                    //    SelectSameCustCodeandAmount(voucher);
                    //}
                }
                else if (MenuName == Indication_Forms_Title.IPODepositMultiTransfer_ApplyTogther)
                {
                    string PaymentId = "";
                    string voucher = "";
                    string SelectionID = "";
                    string AccountName = selectedRows[0].Cells["AccountName"].Value.ToString();
                    SelectionID = selectedRows[0].Cells["SelectionID"].Value.ToString();
                    voucher = selectedRows[0].Cells["Voucher_No_Selection"].Value.ToString();
                    SelectVoucherNoForMultitransfer(voucher);
                    //SelectSamepaymentIDAndVoucherNoForMultitransfer(voucher, SelectionID);
                }
               
                else if (MenuName == Indication_Forms_Title.IPOParentAccountTransferBackApproval)
                {
                    string selectionID = selectedRows[0].Cells["SelectionID"].Value.ToString();
                    string sessionId = selectedRows[0].Cells["Intended_IPOSession_ID"].Value.ToString();
                    string voucherNo = selectedRows[0].Cells["Voucher No"].Value.ToString();
                    SelectedSameSelectionID_SessionID_VoucherNo(sessionId, voucherNo, selectionID);
                }
                else if (MenuName == Indication_Forms_Title.IPONRBMoneyDepositAndApplication)
                {
                    string selectionID = selectedRows[0].Cells["SelectionID"].Value.ToString();
                    string voucher = selectedRows[0].Cells["Voucher No"].Value.ToString();
                    SelectedSameVoucher(voucher, selectionID);
                }
                else if (MenuName == Indication_Forms_Title.IPOMoneyRefund_ForNrb)
                {
                    string DraftStatus = selectedRows[0].Cells["Status_Name"].Value.ToString();
                    SelectedNRBUnsuccessful(DraftStatus);
                }
            }
        }

        private void dg_IpoApproval_DataSourceChanged(object sender, EventArgs e)
        {
            lbl_dgIpoApp.Text ="Count: "+dg_IpoApproval.Rows.Count;
        }
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
                        break;
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
                //Convert.ToDecimal(dt.Rows[0]["Withdraw_Pending"]);
                if ((Total_Balance - Withdraw_Pending_Balance) < Distributed_Amount)
                {
                    throw new Exception("Your previous Balance =" + Total_Balance + "\n available withdrawal Balance = " + Total_Approved_Pending_Balance + "\n Total Pendding deposit Amount = " + Deposit_Pending_Balance + " Deposit Transaction Pending By: " + Deposit_Transaction_Name + "\n Total Withdraw Balance = " + Withdraw_Pending_Balance + " Withdraw Transaction Pending By: " + Withdraw_Transaction_Name + "\n For This Cust Code= " + cust_code);
                }
            }

        }
    }
}
