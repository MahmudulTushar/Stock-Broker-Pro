﻿using System;
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
    public partial class DepositApproval : Form
    {
        private string _paymentId;
        private string _custCode;
        private double _requistionWithdrawAmount;
        private string _rejectionID;
        public static string _rejectionCustCode;
        public string MenuName;
        public static bool IsProgressed;

        private const string Requisition_Withdraw_Return = "EFT/Cash (Requisition)/Withdraw Return";
        private const string Deposit_Deposit_Return = "Deposit/Deposit Return";
        private const string Transfer = "Transfer";

        //Changed By Shahrior
        private string selected_PaymentMedia;
        private string selected_DepositWithdraw;
        private double selected_Requisition_Amount;
        private string selected_CustCode;     
        private string selected_TransReason;
        private string selected_VoucherNo;
        private DateTime selected_ReceivedDate;
        private string selected_ReceivedBy;
        private string selected_BankName;
        private string selected_BranchName;
        private string selected_PaymentMediaNo;

        private string selected_paymentId;
        private int selected_parentPaymentId_ForReturnTrans;
        //-------------------------

        private enum FormState { SingleApproved_Processing, SingleApproved_ProcessDone, SingleApproved_ProcessStart, SingleApproved_ProcessionErrorOccured };
        private enum ValidationState { NonReturn_Deposit, NonReturn_Withdraw, Return_Deposit, Return_Withdraw, Default_NoAction };

        private bool IsRowAlreadySelected = false;

        private const string BO_Annual_Charge = "BO Annual Charge";

        public DepositApproval()
        {
            InitializeComponent();
            IsProgressed = false;
        }   
        
        public DepositApproval(string menuName)
        {
            InitializeComponent();
            MenuName = menuName;
            IsProgressed = false;
        }
        private void DepositApproval_Load(object sender, EventArgs e)
        {
            LoadGridData(MenuName);

        }
        private void LoadGridData(string menuName)
        {
            DataTable datatable=new DataTable();
            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
            if (menuName == Requisition_Withdraw_Return)
            {
                datatable = paymentInfoBal.GetAllWithdrawForApproval();
                dtgDepositInfo.MultiSelect = false;
            }
            else if (menuName == Deposit_Deposit_Return)
            {
                datatable = paymentInfoBal.GetAllDepositForApproval();
                dtgDepositInfo.MultiSelect = false;
            }
            else if (menuName == Transfer)
            {
                datatable = paymentInfoBal.GetAllTransferForApproval();
                dtgDepositInfo.MultiSelect = true;
            }
            else if (menuName == BO_Annual_Charge)
            {
                datatable = paymentInfoBal.GetAllBOAnnualChargeForApproval();
                
            }
            //Deposit/Deposit Return
            dtgDepositInfo.DataSource = datatable;
            this.dtgDepositInfo.Columns[0].Visible = false;
            this.dtgDepositInfo.Columns["Entry_Branch_ID"].Visible = false;
            this.dtgDepositInfo.Columns["Trans_Reason"].Visible = false;
            dtgDepositInfo.Columns[2].DefaultCellStyle.Format = "N";
            dtgDepositInfo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDepositInfo.Columns[4].DefaultCellStyle.Format = "dd-MMM-yyyy";
            dtgDepositInfo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDepositInfo.Columns[6].DefaultCellStyle.Format = "dd-MMM-yyyy";
            dtgDepositInfo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDepositInfo.Columns["Bank_ID"].Visible = false;
            dtgDepositInfo.Columns["Branch_ID"].Visible = false;

            if (menuName == BO_Annual_Charge)
            {
                dtgDepositInfo.Columns["srt_ID"].Visible = false;
            }
            SetColumnWidth();
           // SetRowColor();
            lblTotalDep.Text = "Total Deposit : " + dtgDepositInfo.Rows.Count.ToString();
        }
        private void SetColumnWidth()
        {
            dtgDepositInfo.Columns["Cust"].Width = 60;
            dtgDepositInfo.Columns["Amount"].Width = 70;
            dtgDepositInfo.Columns["P.Media"].Width =90;
            dtgDepositInfo.Columns["T.Type"].Width = 60;
            dtgDepositInfo.Columns["Voucher"].Width = 60;
            dtgDepositInfo.Columns["Recv.Date"].Width = 75;
            dtgDepositInfo.Columns["Cheq.No"].Width = 60;
            dtgDepositInfo.Columns["Cheq.Date"].Width = 75;
            dtgDepositInfo.Columns["Bank"].Width = 150;
            dtgDepositInfo.Columns["Branch"].Width = 150;
            dtgDepositInfo.Columns["Rout.No"].Width = 65;
            dtgDepositInfo.Columns["AccNo"].Width = 100;
            dtgDepositInfo.Columns["Recv.By"].Width = 70;
            dtgDepositInfo.Columns["Remarks"].Width = 60;                   
            dtgDepositInfo.Columns["Status"].Width = 60;
            dtgDepositInfo.Columns["Dep.Branch"].Width = 70;
        }
        //private void SetRowColor()
        //{
        //    foreach (DataGridViewRow dgvRow in dtgDepositInfo.Rows)
        //    {
        //        if (double.Parse(dgvRow.Cells["Amount"].Value.ToString()) > 100000 && double.Parse(dgvRow.Cells["Amount"].Value.ToString()) <= 500000)
        //        {
        //            dgvRow.DefaultCellStyle.BackColor = Color.Red;
        //        }
        //        else if (double.Parse(dgvRow.Cells["Amount"].Value.ToString()) > 500000 && double.Parse(dgvRow.Cells["Amount"].Value.ToString()) <= 1500000)
        //        {
        //            dgvRow.DefaultCellStyle.BackColor = Color.Pink;
        //        }
        //        else if (double.Parse(dgvRow.Cells["Amount"].Value.ToString()) > 1500000 )
        //        {
        //            dgvRow.DefaultCellStyle.BackColor = Color.Plum;
        //        }
        //    }
        //}

        private void FormStateExecution(FormState fs)
        {
            switch (fs)
            {
                case FormState.SingleApproved_ProcessDone:
                    btnDeposit.Enabled = true;
                    btnAccept.Enabled = true;
                    btnReject.Enabled = true;
                    break;
                case FormState.SingleApproved_Processing:
                    btnDeposit.Enabled = false;
                    btnAccept.Enabled = false;
                    btnReject.Enabled = false;
                    break;
                case FormState.SingleApproved_ProcessStart:
                    btnDeposit.Enabled = false;
                    btnAccept.Enabled = false;
                    btnReject.Enabled = false;
                    break;
                case FormState.SingleApproved_ProcessionErrorOccured:
                    btnDeposit.Enabled = true;
                    btnAccept.Enabled = true;
                    btnReject.Enabled = true;
                    break;
            }
        }

        private void ValidationStateExcucation(ValidationState ls)
        {
            switch (ls)
            {
                case ValidationState.NonReturn_Deposit:
                    IsValidAmount(ValidationState.NonReturn_Deposit);    
                    break;
                case ValidationState.NonReturn_Withdraw:
                    IsValidAmount(ValidationState.NonReturn_Withdraw);    
                    break;
                case ValidationState.Return_Deposit:
                    //IsValidAmount(ValidationState.Return_Deposit);    
                    break;
                case ValidationState.Return_Withdraw:
                    IsValidAmount(ValidationState.Return_Withdraw);    
                    break;               
            }
        }
        
        private void IsValidAmount(ValidationState vs)
        {
            double amount = 0.00;
            double chargeAmount = 0.00;

            CommonBAL comBal = new CommonBAL();
            PaymentInfoBAL bal = new PaymentInfoBAL();

            switch (vs)
            {
                case ValidationState.NonReturn_Deposit:                  
                    break;
                case ValidationState.Return_Deposit:

                    amount = comBal.GetCurrentAvailAbleBalanceForWithdraw(selected_CustCode);

                    //Get Addition Transaction Based Charge
                    if (selected_PaymentMedia.Contains(Indication_PaymentTransaction.Cheque) && selected_PaymentMedia.Contains(Indication_PaymentTransaction.Return_Indicator))
                    {
                        chargeAmount = Indication_TransactioBasedCharge.ChargeTypeList.Where(t => t.Key == Indication_TransactioBasedCharge.CheckBounce)
                        .Select(t => t.Value).SingleOrDefault() == Indication_TransactioBasedCharge.Charge_Amount ? bal.GetTransactionBasedCharges_ChargeAmount(Indication_TransactioBasedCharge.CheckBounce, selected_Requisition_Amount)
                                                                    : Indication_TransactioBasedCharge.ChargeTypeList.Where(t => t.Key == Indication_TransactioBasedCharge.CheckBounce)
                                                                    .Select(t => t.Value).SingleOrDefault() == Indication_TransactioBasedCharge.Charge_Rate ? bal.GetTransactionBasedCharges_ChageRate(Indication_TransactioBasedCharge.CheckBounce, selected_Requisition_Amount) : 0.00;
                    }

                    //Check Amount
                    if (!(amount + chargeAmount >= selected_Requisition_Amount))
                    {
                        throw new Exception("Insuffiecient Balance!");
                    }

                    break;
                case ValidationState.NonReturn_Withdraw:

                    amount = comBal.GetCurrentAvailAbleBalanceForWithdraw(selected_CustCode);

                    if (!(amount >= selected_Requisition_Amount))
                    {
                        throw new Exception("Insuffiecient Balance!");
                    }
                    break;
               
                case ValidationState.Return_Withdraw:
                    break;            
            }            
        }

        private ValidationState ValidationSwitching(string PaymentMethod, string DepositWithdraw)
        {
            if (PaymentMethod.Contains(Indication_PaymentTransaction.Return_Indicator) && DepositWithdraw == Indication_PaymentMode.Withdraw)
                return ValidationState.Return_Deposit;
            else if (PaymentMethod.Contains(Indication_PaymentTransaction.Return_Indicator) && DepositWithdraw == Indication_PaymentMode.Deposit)
                return ValidationState.Return_Withdraw;
            else if ((!PaymentMethod.Contains(Indication_PaymentTransaction.Return_Indicator)) && DepositWithdraw == Indication_PaymentMode.Deposit)
                return ValidationState.NonReturn_Deposit;
            else if ((!PaymentMethod.Contains(Indication_PaymentTransaction.Return_Indicator)) && DepositWithdraw == Indication_PaymentMode.Withdraw)
                return ValidationState.NonReturn_Withdraw;
            else if ((PaymentMethod.Contains(Indication_PaymentTransaction.TR)) && DepositWithdraw == Indication_PaymentMode.Withdraw)
                return ValidationState.NonReturn_Withdraw;
            else
                return ValidationState.Default_NoAction;
        }       
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            int _payment_Posting_PaymentId = -1;
            int _totalvoucherNo;
            int _totalSortId;
            string[] paymentID = new string[2];
            if (dtgDepositInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Approved", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Approved selected Deposit?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                PaymentInfoBO payInfoBo = new PaymentInfoBO();
                payInfoBo.CustCode = selected_CustCode;
                payInfoBo.BankName = selected_BankName;
                payInfoBo.BranchName = selected_BranchName;
                payInfoBo.RecievedDate = selected_ReceivedDate;
                payInfoBo.RecievedBy = selected_ReceivedBy;
                payInfoBo.PaymentMediaNo = selected_PaymentMediaNo;

                CommonBAL comBal = new CommonBAL();
                try
                {
                    switch (MenuName)
                    {
                        case Requisition_Withdraw_Return: // All Withdraw And Withdraw Return

                            FormStateExecution(FormState.SingleApproved_ProcessStart);
                            
                            //Changed By Shahrior
                            //_payment_Posting_PaymentId = LoadDataFromGrid();
                            //double amount = comBal.GetCurrentAvailAbleBalanceForWithdraw(_custCode);
                            //if (
                            //    ((!selectedPaymentMedia.Contains(Indication_PaymentTransaction.Return_Indicator)) && selectedDepositWithdraw == Indication_PaymentMode.Withdraw)//Non Return Withdraw
                            //    ||
                            //    (selectedPaymentMedia.Contains(Indication_PaymentTransaction.Return_Indicator) && selectedDepositWithdraw == Indication_PaymentMode.Withdraw)//Return Withdraw
                            //)
                            //{
                            //    if (amount >= _requistionWithdrawAmount)
                            //    {
                            //        MessageBox.Show("Insuffiecient Balance!");
                            //        break;
                            //    }
                            //}

                            var vState_Withdraw = ValidationSwitching(selected_PaymentMedia, selected_DepositWithdraw);
                            ValidationStateExcucation(vState_Withdraw);

                            paymentInfoBal.ApprovedSingleWithdraw(selected_paymentId, selected_parentPaymentId_ForReturnTrans);

                            MessageBox.Show("Payment Withdraw successfully Approved.");
                            FormStateExecution(FormState.SingleApproved_ProcessDone);

                            break;
            
                        case Deposit_Deposit_Return: //All Deposit And Deposit Return

                            FormStateExecution(FormState.SingleApproved_ProcessStart);
                            //_payment_Posting_PaymentId = LoadDataFromGrid();
                            var vState_Deposit = ValidationSwitching(selected_PaymentMedia, selected_DepositWithdraw);
                            ValidationStateExcucation(vState_Deposit);

                            if (selected_PaymentMedia == Indication_PaymentTransaction.Cheque && selected_DepositWithdraw == Indication_PaymentMode.Deposit)
                            {
                                paymentInfoBal.ApprovedSingleDeposit(selected_paymentId, selected_parentPaymentId_ForReturnTrans, payInfoBo, 0, Indication_TransactioBasedCharge.BankClearing, selected_Requisition_Amount);
                            }
                            else if (selected_PaymentMedia.Contains(Indication_PaymentTransaction.Cheque) && selected_PaymentMedia.Contains(Indication_PaymentTransaction.Return_Indicator) && selected_DepositWithdraw == Indication_PaymentMode.Withdraw)
                            {
                                paymentInfoBal.ApprovedSingleDeposit(selected_paymentId, selected_parentPaymentId_ForReturnTrans, payInfoBo, 0, Indication_TransactioBasedCharge.CheckBounce, selected_Requisition_Amount);
                            }
                            else
                            {
                                paymentInfoBal.ApprovedSingleDeposit(selected_paymentId, selected_parentPaymentId_ForReturnTrans);
                            }

                            MessageBox.Show("Payment Deposit successfully Approved.");
                            FormStateExecution(FormState.SingleApproved_ProcessDone);

                            break;
                        
                        case Transfer: // All Transfer
                        
                            DataTable data = (DataTable)dtgDepositInfo.DataSource;
                            DataGridViewSelectedRowCollection rows = dtgDepositInfo.SelectedRows;
                            DataRow myRow1 = (rows[0].DataBoundItem as DataRowView).Row;
                            DataRow myRow2 = (rows[1].DataBoundItem as DataRowView).Row;
                            string Cust_CodeTemp = string.Empty;

                            _totalvoucherNo = CalculateTotalVoucherNo(myRow1[5].ToString(), data);
                            if (_totalvoucherNo == 2)
                            {

                                if (myRow1[4].ToString() == "Withdraw")
                                {
                                    paymentID[0] = myRow1[0].ToString();
                                    Cust_CodeTemp = Convert.ToString(myRow1["Cust"]);
                                }
                                else if (myRow2[4].ToString() == "Withdraw")
                                {
                                    paymentID[0] = myRow2[0].ToString();
                                    Cust_CodeTemp = Convert.ToString(myRow2["Cust"]);
                                }

                                if (myRow1[4].ToString() == "Deposit")
                                {
                                    paymentID[1] = myRow1[0].ToString();
                                }
                                else if (myRow2[4].ToString() == "Deposit")
                                {
                                    paymentID[1] = myRow2[0].ToString();
                                }
                                
                                selected_CustCode=Cust_CodeTemp;
                                
                                var vState_TR= ValidationSwitching(Indication_PaymentTransaction.TR, Indication_PaymentMode.Withdraw);
                                ValidationStateExcucation(vState_TR);

                                ApproveSingleTransfer(paymentID);
                                if (myRow1[4].ToString().Trim().ToUpper() == ("Withdraw").ToUpper())
                                {
                                    CashDividedMarginLoanBAL cashDividedMarginLoanBAL = new CashDividedMarginLoanBAL();
                                    cashDividedMarginLoanBAL.GetQueryString_InsertPayment_Charge("TR|CHG|" + myRow1[1].ToString(), 1, Convert.ToDateTime(myRow1[6].ToString()), myRow1[1].ToString());
                                    cashDividedMarginLoanBAL.GetQueryString_Deposit_InsertMoneyBalance("TR|CHG|" + myRow1[1].ToString(), Convert.ToDateTime(myRow1[6].ToString()));
                                    //cashDividedMarginLoanBAL.AccTransaction("TR|CHG|" + myRow1[1].ToString(), Convert.ToDateTime(myRow1[6].ToString()), "I008", "I008i", 0, 10, 0, "Cr", "", "");

                                }
                                else   if (myRow2[4].ToString().Trim().ToUpper() == ("Withdraw").ToUpper())
                                {
                                    CashDividedMarginLoanBAL cashDividedMarginLoanBAL = new CashDividedMarginLoanBAL();
                                    cashDividedMarginLoanBAL.GetQueryString_InsertPayment_Charge("TR|CHG|" + myRow2[1].ToString(), 1, Convert.ToDateTime(myRow2[6].ToString()), myRow2[1].ToString());
                                    cashDividedMarginLoanBAL.GetQueryString_Deposit_InsertMoneyBalance("TR|CHG|" + myRow2[1].ToString(), Convert.ToDateTime(myRow2[6].ToString()));
                                    //cashDividedMarginLoanBAL.AccTransaction("TR|CHG|" + myRow2[1].ToString(), Convert.ToDateTime(myRow2[6].ToString()), "I008", "I008i", 0, 10, 0, "Cr", "", "");

                                }
                                MessageBox.Show("Transfer successfully Approved.");

                            }
                            break;

                        case BO_Annual_Charge: // All BO Annual Charge

                            string transreason = string.Empty;
                            string custCode = string.Empty;
                            
                            DataTable dataBOAnnual = (DataTable)dtgDepositInfo.DataSource;
                            DataGridViewSelectedRowCollection rowsBOAnnual = dtgDepositInfo.SelectedRows;
                            DataRow myRowBOAnnual1 = (rowsBOAnnual[0].DataBoundItem as DataRowView).Row;
                            //DataRow myRowBOAnnual2 = (rowsBOAnnual[1].DataBoundItem as DataRowView).Row;

                            _totalSortId = CalculateTotalSortNo(myRowBOAnnual1[21].ToString(), dataBOAnnual);
                            //if (_totalSortId == 1)
                            //{
                                //paymentID[0] Contains Withdraw Information
                                transreason = myRowBOAnnual1["Trans_Reason"].ToString();
                                custCode = myRowBOAnnual1["Cust"].ToString();
                                //if (myRowBOAnnual1[4].ToString() == "Withdraw")
                                //{
                                //    paymentID[0] = Convert.ToInt32(myRowBOAnnual1[0].ToString());
                                //}
                                //else if (myRowBOAnnual2[4].ToString() == "Withdraw")
                                //{
                                //    paymentID[0] = Convert.ToInt32(myRowBOAnnual2[0].ToString());
                                //}
                                
                                //paymentID[1] Contains Deposit Information
                                if (myRowBOAnnual1[4].ToString() == "Deposit")
                                {
                                    paymentID[0] =myRowBOAnnual1[0].ToString();
                                }
                               
                                //if (paymentInfoBal.IsReceivedBoRenewal(custCode, transreason))
                                //{
                                //    MessageBox.Show("Already Payment Received");
                                //    return;
                                //}
                                    ApproveSingleBOAnnual(paymentID);
                                    MessageBox.Show("BO Annual Successfully Approved.");
                            //}
                            
                            break;
                    }

                    LoadGridData(MenuName);
                    //RealTimeExportSMSServer_MoneyTransaction();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);

                }
            }
        }
        
        private DataTable RemoveMatchedVoucherNoRow(string voucherNo, DataTable dataTable)
        {
            int rowcount = dataTable.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                if (dataTable.Rows.Count > 0)
                {
                    for (int x = 0; x < rowcount; x++)
                    {
                        if (dataTable.Rows.Count > x)
                        {
                            if (dataTable.Rows[x][5].ToString() == voucherNo)
                            {
                                dataTable.Rows.RemoveAt(x);
                                break;
                            }
                        }
                    }
                }
            }
            return dataTable;
        }

        private DataTable RemoveMatchedSortIdRow(string sortId, DataTable dataTable)
        {
            int rowcount = dataTable.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                if (dataTable.Rows.Count > 0)
                {
                    for (int x = 0; x < rowcount; x++)
                    {
                        if (dataTable.Rows.Count > x)
                        {
                            if (dataTable.Rows[x][21].ToString() == sortId)
                            {
                                dataTable.Rows.RemoveAt(x);
                                break;
                            }
                        }
                    }
                }
            }
            return dataTable;
        }
        private void ApproveSingleTransfer(string[] paymentID)
        {
            PaymentInfoBAL objBAL = new PaymentInfoBAL();
            objBAL.InsertIntoPayment_MoneyBalance_ForTRApproval(paymentID);
        }

        private void ApproveSingleBOAnnual(string[] paymentID)
        {
            PaymentInfoBAL objBAL = new PaymentInfoBAL();
            objBAL.InsertIntoPayment_ForBOAnnualApproval(paymentID);
        }

        private void ApproveTransfer(DataTable dataTable)
        {
            DataTable tempDataTable;
            string voucher = "";
            int _totalvoucherNo;
            string[] paymentID;
            int[] temp;
            paymentID =new string[2];
            tempDataTable = dataTable.Copy();
            foreach (DataRow dr in dataTable.Rows)
            {
                if (tempDataTable.Rows.Count >= 2)
                {
                    voucher = dr[5].ToString();
                    _totalvoucherNo = CalculateTotalVoucherNo(voucher, tempDataTable);
                    if (_totalvoucherNo == 2)
                    {
                        temp = GetpaymentID(voucher, tempDataTable);                       
                        paymentID[0] = temp[0].ToString();//Withdraw
                        paymentID[1] = temp[1].ToString();//Deposit
                        tempDataTable = RemoveMatchedVoucherNoRow(voucher, tempDataTable);
                        ApproveSingleTransfer(paymentID);
                    }
                }
            }
           // ApproveSingleTransfer(paymentID);
        }

        private void ApproveBOAnnul(DataTable dataTable)
        {
            DataTable tempDataTable;
            string sortId = "";
            int _totalSortNo;
            string[] paymentID;
            string[] temp;
            paymentID = new string[2];
            tempDataTable = dataTable.Copy();
            foreach (DataRow dr in dataTable.Rows)
            {
                if (tempDataTable.Rows.Count >= 2)
                {
                    sortId = dr[21].ToString();
                    _totalSortNo = CalculateTotalSortNo(sortId, tempDataTable);
                    if (_totalSortNo == 2)
                    {
                        temp = GetpaymentIDForBOAnnual(sortId, tempDataTable);
                        paymentID[0] = temp[0].ToString();
                        paymentID[1] = temp[1].ToString();
                        tempDataTable = RemoveMatchedSortIdRow(sortId, tempDataTable);
                        ApproveSingleBOAnnual(paymentID);
                    }
                }
            }
            // ApproveSingleTransfer(paymentID);
        }
        private int[] GetpaymentID(string voucherNo,DataTable data)
        {
            int[] paymentID=new int[2];
            int counter = 0;
            for(int i=0;i<data.Rows.Count;i++)
            {
                if(data.Rows[i][5].ToString()==voucherNo)
                {
                    if (data.Rows[i][4].ToString() == "Withdraw")
                    {
                        paymentID[0] = Convert.ToInt32(data.Rows[i][0].ToString());
                    }
                    if (data.Rows[i][4].ToString() == "Deposit")
                    {
                        paymentID[1] = Convert.ToInt32(data.Rows[i][0].ToString());
                    }
                    counter++;
                }
            }
            return paymentID;
        }

        private string[] GetpaymentIDForBOAnnual(string sortId, DataTable data)
        {
            string[] paymentID = new string[2];
            int counter = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][21].ToString() == sortId)
                {
                    paymentID[counter] =data.Rows[i][0].ToString();
                    counter++;
                }
            }
            return paymentID;
        }
        //private void ApproveSingleTransfer(DataRow dtrow,DataTable dataTable)
        //{           
        //    string vouchsrNo = "";
        //    int totalVoucherNoCount = 0;
        //    PaymentInfoBO objBO = new PaymentInfoBO();
        //    PaymentInfoBAL objBAL = new PaymentInfoBAL();
        //    foreach (DataGridViewRow row in this.dtgDepositInfo.SelectedRows)
        //    {
        //        if (dtgDepositInfo[5, row.Index].Value != DBNull.Value)
        //        {
        //            vouchsrNo = dtgDepositInfo[5, row.Index].Value.ToString();
        //            totalVoucherNoCount = CalculateTotalVoucherNo(vouchsrNo);
        //            if (totalVoucherNoCount == 2)
        //            {
        //                objBO.VoucherSlNo = vouchsrNo;
        //                objBAL.InsertIntoPayment_MoneyBalance_ForTRApproval(objBO);
        //            }
        //            else if (totalVoucherNoCount < 2)
        //            {
        //                throw new Exception("You need Two same voucher No But Only one Voucher No found");
        //            }
        //            else if (totalVoucherNoCount > 2)
        //            {
        //                throw new Exception("You need Two same voucher No But more than Two Voucher No found");
        //            }
        //        }
        //    }
        //}
        private int CalculateTotalVoucherNo(string voucherNo, DataTable dtTemp)
        {
            int count = 0;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (dtTemp.Rows[i][5].ToString() != "")
                {
                    if (voucherNo == dtTemp.Rows[i][5].ToString())
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int CalculateTotalSortNo(string sortId, DataTable dtTemp)
        {
            int count = 0;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (dtTemp.Rows[i][21].ToString() != "")
                {
                    if (sortId == dtTemp.Rows[i][21].ToString())
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private int GetpaymentIDFromPaymentPositngRequestByTransReason(string transReason)
        {
            int _payment_Posting_PaymentId = -1;

            string tempTransReason = "";
            tempTransReason = transReason;
            string[] temp;
            temp = tempTransReason.Split('_');
            _payment_Posting_PaymentId = Convert.ToInt32(temp[1]);
            return _payment_Posting_PaymentId;
        }
        private int LoadDataFromGrid()
        {
            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
            int parentPaymentID_ForReturnTrans = -1;
            string tempTransReason="";
            _custCode = string.Empty;
            foreach (DataGridViewRow row in this.dtgDepositInfo.SelectedRows)
            {
                if (dtgDepositInfo[0, row.Index].Value != DBNull.Value)
                {
                    _paymentId =dtgDepositInfo[0, row.Index].Value.ToString();
                    _custCode = Convert.ToString(dtgDepositInfo[1, row.Index].Value);
                    _requistionWithdrawAmount = Convert.ToDouble(dtgDepositInfo[2, row.Index].Value);                    
                    tempTransReason=dtgDepositInfo["Trans_Reason", row.Index].Value.ToString();
                    if (tempTransReason.Contains(Indication_PaymentTransaction.Return_Indicator))// != "")
                    {
                        parentPaymentID_ForReturnTrans = GetpaymentIDFromPaymentPositngRequestByTransReason(tempTransReason);
                    }
                }
            }
            //if (_payment_Posting_PaymentId != -1)
            //{
            //    _payment_PaymentId = paymentInfoBal.GetPaymentIdFromPaymentByPaymentPostingPaymentId(_payment_Posting_PaymentId);
            //    _payment_Trans_Reason = Indication_PaymentTransaction.Return_Indicator + "_" + _payment_PaymentId.ToString();
            //}
            return parentPaymentID_ForReturnTrans;
        }

        private void RealTimeExportSMSServer_MoneyTransaction()
        {
            //Export Customer Trade Acc
            List<string> UpdatedCustList = new List<string>();
            if (MenuName == Indication_Forms_Title.IPOParentAccountTransferBackApproval || MenuName == Indication_Forms_Title.IPONRBMoneyDepositAndApplication)
                UpdatedCustList = dtgDepositInfo.SelectedRows.Cast<DataGridViewRow>().Select(t => Convert.ToString(t.Cells["Cust_Code"].Value)).ToList();
            

            SMSSyncBAL syncBal = new SMSSyncBAL();
            DashboardBAL dashBal = new DashboardBAL();
            foreach (string obj in UpdatedCustList)
                dashBal.Execute_GenereateMoneyBalanceTemp(obj);

            try
            {

                syncBal.Connect_SBP();
                syncBal.Connect_SMS();

                SqlDataReader dt_GotExported_CustTradeAccBalance = syncBal.GetIPO_Customer_Trade_Account_UITransApplied(UpdatedCustList.ToArray());
                syncBal.DeleteData_SMSSyncExport_Customer_Trade_Account_UITransApplied(UpdatedCustList.ToArray());
                syncBal.InsertTable_SMSSyncExport_Customer_Trade_Account_UITransApplied(dt_GotExported_CustTradeAccBalance);

                //////Export Customer IPO Acc
                //SqlDataReader dt_GotExported_CustIpoAccBalance = syncBal.GetIPO_Customer_IPO_Account_UITransApplied(UpdatedCustList.ToArray());
                //syncBal.DeleteData_SMSSyncExport_Customer_IPO_Account_UITransApplied(UpdatedCustList.ToArray());
                //syncBal.InsertTable_SMSSyncExport_Customer_IPO_Account_UITransApplied(dt_GotExported_CustIpoAccBalance);

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

        private void btnReject_Click(object sender, EventArgs e)
        {
            string voucherNo = "";
            string sortId = "";
            string [] paymentID = new string[2];
            string PaymentMedia = "";
            if (dtgDepositInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Reject", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Reject selected Deposit?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    LoadDataFromGridForReject();
                    PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                    DepRejectionReason rejectionReason = new DepRejectionReason();
                    rejectionReason.ShowDialog();
                    if (MenuName == Requisition_Withdraw_Return)
                    {
                        paymentInfoBal.RejectSingleWithdraw(_rejectionID, DepRejectionReason._rejectionReason);
                        MessageBox.Show("Payment Withdraw has Rejected.");
                    }
                    else if (MenuName == Deposit_Deposit_Return)
                    {
                        paymentInfoBal.RejectSingleDeposit(_rejectionID, DepRejectionReason._rejectionReason);
                        MessageBox.Show("Payment Deposit has Rejected.");
                    }
                    else if (MenuName == Transfer)
                    {
                        DataGridViewRow r = dtgDepositInfo.SelectedRows[0];
                        voucherNo = dtgDepositInfo[5, r.Index].Value.ToString();
                        // PaymentMedia = dtgDepositInfo[3, r.Index].Value.ToString();
                        paymentInfoBal.RejectTransfer(voucherNo, DepRejectionReason._rejectionReason);
                        MessageBox.Show("Payment Deposit has Rejected.");
                    }

                    else if (MenuName == BO_Annual_Charge)
                    {
                        DataTable dataTable = (DataTable)dtgDepositInfo.DataSource;
                        DataGridViewRow r = dtgDepositInfo.SelectedRows[0];
                        sortId = dtgDepositInfo[21, r.Index].Value.ToString();
                        // PaymentMedia = dtgDepositInfo[3, r.Index].Value.ToString();
                        paymentID = GetpaymentIDForBOAnnual(sortId, dataTable);
                        paymentInfoBal.RejectBOAnnual(paymentID, DepRejectionReason._rejectionReason);
                        MessageBox.Show("BO Annual has Rejected.");
                    }

                    LoadGridData(MenuName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rejection unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void LoadDataFromGridForReject()
        {
            foreach (DataGridViewRow row in this.dtgDepositInfo.SelectedRows)
            {
                if (dtgDepositInfo[0, row.Index].Value != DBNull.Value)
                    _rejectionID = dtgDepositInfo[0, row.Index].Value.ToString();
                _rejectionCustCode = dtgDepositInfo[1, row.Index].Value.ToString();
            }
        }

        private void btnRejectAll_Click(object sender, EventArgs e)
        {
            string voucherNo = "";
            string sortId = "";
            string []paymentID=new string[2];
            string PaymentMedia = "";
            if (dtgDepositInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Reject", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Reject All selected Deposit?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _rejectionCustCode = "All Selected";
                    DepRejectionReason rejectionReason = new DepRejectionReason();
                    rejectionReason.ShowDialog();
                    foreach (DataGridViewRow row in dtgDepositInfo.Rows)
                    {
                        if (dtgDepositInfo[0, row.Index].Value != DBNull.Value)
                            _rejectionID = dtgDepositInfo[0, row.Index].Value.ToString();
                        PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        if (MenuName == Requisition_Withdraw_Return)
                        {
                            paymentInfoBal.RejectSingleWithdraw(_rejectionID, DepRejectionReason._rejectionReason);
                        }
                        else if (MenuName == Deposit_Deposit_Return)
                        {
                            paymentInfoBal.RejectSingleDeposit(_rejectionID, DepRejectionReason._rejectionReason);
                        }
                        else if (MenuName == Transfer)
                        {
                            voucherNo = dtgDepositInfo[5, row.Index].Value.ToString();
                            paymentInfoBal.RejectTransfer(voucherNo, DepRejectionReason._rejectionReason);
                        }

                        else if (MenuName == BO_Annual_Charge)
                        {
                            sortId = dtgDepositInfo[21, row.Index].Value.ToString();
                            DataTable dataTable = (DataTable) dtgDepositInfo.DataSource;
                            paymentID = GetpaymentIDForBOAnnual(sortId, dataTable);
                            paymentInfoBal.RejectBOAnnual(paymentID, DepRejectionReason._rejectionReason);
                        }
                    }
                    if (MenuName == Requisition_Withdraw_Return)
                    {
                       MessageBox.Show("All Selected Withdraw has Rejected.");
                    }
                    else if (MenuName == Deposit_Deposit_Return)
                    {
                       MessageBox.Show("All Selected Deposit has Rejected.");
                    }
                    else if (MenuName == Transfer)
                    {
                        MessageBox.Show("All Selected Transfer has Rejected.");
                    }
                    else if (MenuName == BO_Annual_Charge)
                    {
                        MessageBox.Show("All Selected BO Annual has Rejected.");
                    }
                    LoadGridData(MenuName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rejection unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnAcceptAll_Click(object sender, EventArgs e)
        {
            string tempTransReason = "";
            int _payment_Posting_PaymentId = -1;
            if (dtgDepositInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Approved", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Approved All selected Deposit?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (MenuName != Transfer && MenuName != BO_Annual_Charge)
                    {
                        foreach (DataGridViewRow row in dtgDepositInfo.Rows)
                        {
                            if (dtgDepositInfo[0, row.Index].Value != DBNull.Value)
                            {
                                _paymentId =dtgDepositInfo[0, row.Index].Value.ToString();
                                tempTransReason = dtgDepositInfo["Trans_Reason", row.Index].Value.ToString();
                                if (tempTransReason != "")
                                {
                                    _payment_Posting_PaymentId =
                                        GetpaymentIDFromPaymentPositngRequestByTransReason(tempTransReason);
                                }
                            }
                            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                            if (MenuName == Requisition_Withdraw_Return)
                            {
                                paymentInfoBal.ApprovedSingleWithdraw(_paymentId, _payment_Posting_PaymentId);
                                MessageBox.Show("All Withdraw has Approved.");
                            }
                            else if (MenuName == Deposit_Deposit_Return)
                            {
                                paymentInfoBal.ApprovedSingleDeposit(_paymentId, _payment_Posting_PaymentId);
                                MessageBox.Show("All Deposit has Approved.");
                            }

                        }
                    }
                    else if (MenuName == Transfer)
                    {
                        DataTable data = (DataTable)dtgDepositInfo.DataSource;
                        ApproveTransfer(data);

                    }
                    else if (MenuName == BO_Annual_Charge)
                    {
                        DataTable data = (DataTable)dtgDepositInfo.DataSource;
                        ApproveBOAnnul(data);

                    }
                    if (MenuName == Requisition_Withdraw_Return)
                    {
                       MessageBox.Show("All Withdraw has Approved.");
                    }
                    else if (MenuName == Deposit_Deposit_Return)
                    {
                       MessageBox.Show("All Deposit has Approved.");
                    }
                    else if (MenuName == Transfer)
                    {
                        MessageBox.Show("All Transfer has Approved.");
                    }
                    else if (MenuName == BO_Annual_Charge)
                    {
                        MessageBox.Show("All BO Annual has Approved.");
                    }
                    LoadGridData(MenuName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGridData(MenuName);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SelectDatagridviewRow(string voucherNo)
        {
            foreach (DataGridViewRow row in this.dtgDepositInfo.Rows)
            {
                if (dtgDepositInfo[5, row.Index].Value != DBNull.Value)
                {
                    if (voucherNo == dtgDepositInfo[5, row.Index].Value.ToString())
                    {
                        dtgDepositInfo.Rows[row.Index].Selected = true;
                    }
                }
            }
        }

        private void dtgSelectionIndexChange(int ColumnIndex, int RowIndex)
        {
            double doubleTryParse;
            DateTime dateTimeTryParse;
            int intTryParse;

            IsRowAlreadySelected = true;
            selected_Requisition_Amount = 0.00;
            selected_PaymentMedia = string.Empty;
            selected_DepositWithdraw = string.Empty;
            selected_paymentId = "0";
            selected_CustCode = string.Empty;
            selected_TransReason = string.Empty;
            selected_parentPaymentId_ForReturnTrans = 0;
            selected_VoucherNo = string.Empty;
            selected_ReceivedBy = string.Empty;
            selected_BranchName = string.Empty;
            selected_BankName = string.Empty;
            selected_PaymentMediaNo = string.Empty;

            selected_PaymentMedia = dtgDepositInfo.Rows[RowIndex].Cells["P.Media"].Value.ToString();
            selected_PaymentMediaNo = dtgDepositInfo.Rows[RowIndex].Cells["Cheq.No"].Value.ToString();
            selected_DepositWithdraw = dtgDepositInfo.Rows[RowIndex].Cells["T.Type"].Value.ToString();
            if (double.TryParse(dtgDepositInfo.Rows[RowIndex].Cells["Amount"].Value.ToString(), out doubleTryParse))
                selected_Requisition_Amount = doubleTryParse;
            else
                throw new Exception("Internal Error! Please Contact System Admin");
            //if (int.TryParse(dtgDepositInfo.Rows[RowIndex].Cells["Payment_ID"].Value.ToString(), out intTryParse))
            //    selected_paymentId = intTryParse;
            //else
            //    throw new Exception("Internal Error! Please Contact System Admin");

            
                selected_paymentId =dtgDepositInfo.Rows[RowIndex].Cells["Payment_ID"].Value.ToString();
          




            selected_CustCode = dtgDepositInfo.Rows[RowIndex].Cells["Cust"].Value.ToString();
            selected_TransReason = dtgDepositInfo.Rows[RowIndex].Cells["Trans_Reason"].Value.ToString();
            if (selected_TransReason.Contains(Indication_PaymentTransaction.Return_Indicator))
                selected_parentPaymentId_ForReturnTrans = GetpaymentIDFromPaymentPositngRequestByTransReason(selected_TransReason);
            selected_VoucherNo = dtgDepositInfo.Rows[RowIndex].Cells["Voucher"].Value.ToString();
            selected_ReceivedBy = dtgDepositInfo.Rows[RowIndex].Cells["Recv.By"].Value.ToString();
            if (DateTime.TryParse(dtgDepositInfo.Rows[RowIndex].Cells["Recv.Date"].Value.ToString(), out dateTimeTryParse))
                selected_ReceivedDate = dateTimeTryParse;
            selected_BranchName = dtgDepositInfo.Rows[RowIndex].Cells["Branch"].Value.ToString();
            selected_BankName = dtgDepositInfo.Rows[RowIndex].Cells["Bank"].Value.ToString();
        }

        private void SelectDatagridviewRowBOAnnual(string sortId)
        {
            foreach (DataGridViewRow row in this.dtgDepositInfo.Rows)
            {
                if (dtgDepositInfo[21, row.Index].Value != DBNull.Value)
                {
                    if (sortId == dtgDepositInfo[21, row.Index].Value.ToString())
                    {
                        dtgDepositInfo.Rows[row.Index].Selected = true;
                    }
                }
            }

        }

        //private void dtgDepositInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (MenuName == Transfer)
        //    {
        //        dtgDepositInfo.MultiSelect = true;
        //        if (dtgDepositInfo[5, e.RowIndex].Value.ToString() != "")
        //        {
        //            SelectDatagridviewRow(dtgDepositInfo[5, e.RowIndex].Value.ToString());
        //        }
        //    }
        //    if (MenuName == BO_Annual_Charge)
        //    {
        //        dtgDepositInfo.MultiSelect = true;
        //        if (dtgDepositInfo[21, e.RowIndex].Value.ToString() != "")
        //        {
        //            SelectDatagridviewRowBOAnnual(dtgDepositInfo[21, e.RowIndex].Value.ToString());
        //        }

        //    }
        //    dtgDepositInfo.MultiSelect = true;
        //}

        private void dtgDepositInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (MenuName == Transfer)
            {
                dtgDepositInfo.ClearSelection();
            }
            if (MenuName == BO_Annual_Charge)
            {
                dtgDepositInfo.ClearSelection();
            }
        }

        private void dtgDepositInfo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var dg = sender as DataGridView;
                if (dg.RowCount > 0)
                {
                    var rowIndex = dg.CurrentCell.RowIndex;
                    var columnIndex = dg.CurrentCell.ColumnIndex;
                    dtgSelectionIndexChange(columnIndex, rowIndex);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dtgDepositInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            try
            {
                //if (MenuName == Transfer)
                //{
                    
                //    if (dtgDepositInfo[5, e.RowIndex].Value.ToString() != string.Empty)
                //    {
                //        SelectDatagridviewRow(dtgDepositInfo[5, e.RowIndex].Value.ToString());
                //    }
                //}
            if (MenuName == Transfer)
            {
                dtgDepositInfo.MultiSelect = true;
                if (dtgDepositInfo[5, e.RowIndex].Value.ToString() != "")
                {
                    SelectDatagridviewRow(dtgDepositInfo[5, e.RowIndex].Value.ToString());
                }
            }
            else if (MenuName == BO_Annual_Charge)
            {
                dtgDepositInfo.MultiSelect = true;
                if (dtgDepositInfo[21, e.RowIndex].Value.ToString() != "")
                {
                    SelectDatagridviewRowBOAnnual(dtgDepositInfo[21, e.RowIndex].Value.ToString());
                }

            }
            else
                dtgDepositInfo.MultiSelect = false;

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        
        }

        private void dtgDepositInfo_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                var dg = sender as DataGridView;
                if (dg.RowCount > 0)
                {
                    var rowIndex = dg.CurrentCell.RowIndex;
                    var columnIndex = dg.CurrentCell.ColumnIndex;
                    dtgSelectionIndexChange(columnIndex, rowIndex);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DashboardBAL bal = new DashboardBAL();
                Thread thrd = new Thread(WaitWindow_Thread);
                IsProgressed = true;
                thrd.Start();
                bal.DashBoard_Details_UpdateByCurrentData();
                IsProgressed = false;
                MessageBox.Show("Dash Board Updated Successfully");
            }
            catch (Exception ex)
            {
                IsProgressed = false;
                MessageBox.Show(ex.Message);
            }
        }
        private void WaitWindow_Thread()
        {
            WaitWindow waitWindow = new WaitWindow();
            waitWindow.Show();
            while (IsProgressed)
            {
                waitWindow.Refresh();
            }
            waitWindow.Close();
        }
        
    }
}