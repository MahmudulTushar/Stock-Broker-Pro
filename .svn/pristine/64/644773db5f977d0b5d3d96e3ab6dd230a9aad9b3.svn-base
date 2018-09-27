using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class frmExpenseApproval : Form
    {
        private DbConnection _dbConnection = new DbConnection();
        public frmExpenseApproval()
        {
            InitializeComponent();
        }

        private void ExpenseApproval_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void LoadGridData()
        {
            ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
            DataTable datatable = expenseApprovalBAL.GetExpenseApproveList();
            dgvExpenseInfo.DataSource = datatable;
            dgvExpenseInfo.Columns[0].Visible = false;
            dgvExpenseInfo.Columns["Purchaser"].Visible = false;
            dgvExpenseInfo.Columns["Voucher_ID"].Visible = false;
            dgvExpenseInfo.Columns["Voucher_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExpenseInfo.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExpenseInfo.Columns["Amount"].DefaultCellStyle.Format = "N2";
            lblTotalDep.Text = "Total Requests : " + dgvExpenseInfo.Rows.Count;
        }

        private void btnViewVoucharImage_Click(object sender, EventArgs e)
        {
            int index = dgvExpenseInfo.SelectedRows[0].Index;
            if (index < 0)
                return;
            if (dgvExpenseInfo.Rows[index].Cells["Voucher_ID"].Value == DBNull.Value)
            {
                MessageBox.Show("Empty Image", "Vouchar Image Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvExpenseInfo.Rows.Count > 0)
            {
                int voucherID = Int32.Parse(dgvExpenseInfo.Rows[index].Cells["Voucher_ID"].Value.ToString());
                ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                byte[] ImageBytes = expenseApprovalBAL.GetVoucherByte(voucherID);


                if (ImageBytes != null && ImageBytes.Length != 0)
                {
                    MemoryStream ms = new MemoryStream(ImageBytes);
                    Close_All_Opened_ImageViewer();
                    ImageViewer imageViewer = new ImageViewer(Image.FromStream(ms));
                    imageViewer.Show();
                }
                else
                {
                    MessageBox.Show("Voucher Image-Not Found.", "Vouchar Image Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Close_All_Opened_ImageViewer()
        {
            FormCollection fc = Application.OpenForms;

            int openedformCount = fc.Count;
            if (openedformCount > 0)
            {
                Form[] fcTemp = new Form[openedformCount];

                for (int i = 0; i < openedformCount; i++)
                {
                    try
                    {
                        Form frm = fc[i];
                        if (frm.Name == "ImageViewer")
                        {
                            fcTemp[i] = frm;
                        }
                    }
                    catch
                    {
                    }
                }
                var openedImageViewerCollection = fcTemp.Where(t => t != null);
                foreach (var imageViewer in openedImageViewerCollection)
                {
                    imageViewer.Close();
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)        
        {
            if (dgvExpenseInfo.Rows.Count <= 0)
            {
                MessageBox.Show("Approve list is Empty!", "Approve Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Want to approve??", "Approval Alert!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    decimal rate = 0;
                    int qty = 0;
                    int index = dgvExpenseInfo.SelectedRows[0].Index;
                    if (index < 0)
                        return;
                    // int expenseId = Convert.ToInt32(dgvExpenseInfo.Rows[index].Cells["Transaction_ID"].Value.ToString());  Expense_ID 
                    int trnId = Convert.ToInt32(dgvExpenseInfo.Rows[index].Cells["Transaction_ID"].Value.ToString());
                    int expenseId = Convert.ToInt32(dgvExpenseInfo.Rows[index].Cells["Expense_ID"].Value.ToString());
                    int catID = Convert.ToInt32(dgvExpenseInfo.Rows[index].Cells["Category_ID"].Value.ToString());
                    string pMedia = (dgvExpenseInfo.Rows[index].Cells["Payment_Media"].Value.ToString());
                    string bAccNo = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Account_No"].Value.ToString());
                    string bName = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Bank_Name"].Value.ToString());
                    string cqNo = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Cheque_No"].Value.ToString());
                    DateTime exDate = Convert.ToDateTime(dgvExpenseInfo.Rows[index].Cells["Expense_Date"].Value.ToString());
                    string exps = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Expense"].Value.ToString());
                    Double tk = Convert.ToDouble(dgvExpenseInfo.Rows[index].Cells["Amount"].Value.ToString());
                    string vNo = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Voucher_No"].Value.ToString());
                    string rem = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Remarks"].Value.ToString());
                    string assetName = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["AssetName"].Value.ToString());
                    string CategoryName = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Category"].Value.ToString());
                    string strQty = dgvExpenseInfo.Rows[index].Cells["Qty"].Value.ToString();
                    if (!string.IsNullOrEmpty(strQty))
                        qty = Convert.ToInt32(strQty);
                    string strRate = dgvExpenseInfo.Rows[index].Cells["Rate"].Value.ToString();
                    if (!string.IsNullOrEmpty(strRate))
                        rate = Convert.ToDecimal(strRate);

                    if (pMedia == "Cheque")
                    {
                        ExpenseTransactionBAL expTranBal = new ExpenseTransactionBAL();
                        DataTable Biddt = new DataTable();
                        string Bid = @"select BankId from [BankBook].[dbo].[BankInfo] where BankAcc='" + bAccNo + "'";
                        Biddt = expTranBal.Get_Data(Bid);

                        DataTable APdt = new DataTable();
                        string AP = @"select AccountPurpose from [BankBook].[dbo].[BankInfo]  where BankAcc='" + bAccNo + "'";
                        APdt = expTranBal.Get_Data(AP);

                        string tID = NextTranID();
                        string cID = NextCityID();
                        string gID = GroupNextID();
                        string saveCityBankBook = @"INSERT INTO [BankBook].[dbo].[CityBankBook]           
                                       (
                                        [City_ID]
                                       ,[GroupID]
                                       ,[BankId]
                                       ,[TransactionID]
                                       ,[AccountNumber]
                                       ,[AccountPurpose]
                                       ,[Date]
                                       ,[SBP_ReceiveDate]
                                       ,[Particular]
                                       ,[PaymentType]
                                       ,[ChequeNo]
                                       ,[VoucherNo]
                                       ,[PaymentMedia]
                                       ,[CrediteAmount]
                                       ,[TotalAmount]
                                       ,[Status]
                                       ,[Cheque_Status]
                                       ,[StatusforDelation]
                                       ,[CreateBy]
                                       ,[CreateDate]
                                       ,[DebitAmount]
                                       ,[TransferMedia]
                                      )
                                 VALUES
                                       (
                                        '" + cID + @"'
                                       ,'" + gID + @"'
                                       ,'" + Biddt.Rows[0][0].ToString() + @"'
                                       ,0
                                       ,'" + bAccNo + @"'
                                       ,'" + APdt.Rows[0][0].ToString() + @"'
                                       ,'" + exDate + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,'" + exps + @"'
                                       ,'Credit'
                                       ,'" + cqNo + @"'
                                        ,'" + vNo + @"'
                                       ,'" + pMedia + @"'
                                       ,'" + tk + @"'
                                       ,'" + tk + @"'
                                       ,'Approved'
                                       ,'ChequeUnclear'
                                       ,'A'
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,0
                                       ,'Expense'
                                        )";
                        string saveApprovedDataTable = @"INSERT INTO [BankBook].[dbo].[TranactionApprovedata]           
                                       (
                                        [TrnID]
                                       ,[City_ID]
                                       ,[GroupID]
                                       ,[BankId]
                                       ,[TransactionID]
                                       ,[AccountNumber]
                                       ,[AccountPurpose]
                                       ,[Date]
                                       ,[SBP_ReceiveDate]
                                       ,[Particular]
                                       ,[PaymentType]
                                       ,[ChequeNo]
                                       ,[VoucherNo]
                                       ,[PaymentMedia]
                                       ,[CrediteAmount]
                                       ,[TotalAmount]
                                       ,[Status]
                                       ,[Cheque_Status]
                                       ,[StatusforDelation]
                                       ,[CreateBy]
                                       ,[CreateDate]
                                       ,[DebitAmount]
                                       ,[TransferMedia]
                                      )
                                 VALUES
                                       (
                                        '" + tID + @"'
                                       ,'" + cID + @"'
                                       ,'" + gID + @"'
                                       ,'" + Biddt.Rows[0][0].ToString() + @"'
                                       ,0
                                       ,'" + bAccNo + @"'
                                       ,'" + APdt.Rows[0][0].ToString() + @"'
                                       ,'" + exDate + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,'" + exps + @"'
                                       ,'Credit'
                                       ,'" + cqNo + @"'
                                        ,'" + vNo + @"'
                                       ,'" + pMedia + @"'
                                       ,'" + tk + @"'
                                       ,'" + tk + @"'
                                       ,'Approved'
                                       ,'ChequeUnclear'
                                       ,'A'
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,0
                                       ,'Expense'
                                        )";
                        ExpenseTransactionBAL Ex_Trans_BankBook = new ExpenseTransactionBAL();
                        Ex_Trans_BankBook.SaveDt_CityBankBook(saveCityBankBook);
                        Ex_Trans_BankBook.SaveDt_CityBankBook(saveApprovedDataTable);

                        ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                        expenseApprovalBAL.ApproveSelectedExpense(trnId);

                        if (catID == 9)
                        {
                            //To send SBP_Asset table
                            string sendAsset = @"INSERT INTO [SBP_Database].[dbo].[SBP_Asset]
                                                   ([Name]
                                                   ,[Model]
                                                   ,[PurchaseDate]
                                                   ,[Type]
                                                   ,[Catagori]
                                                   ,[Quantity]
                                                   ,[Rate]
                                                   ,[Cost]
                                                   ,[LifeTime]
                                                   ,[SalvageValue]
                                                   ,[DepreciationRate]
                                                   ,[DepreciationAmount]
                                                   ,[NetBalance]
                                                   ,[Status]
                                                   ,[Remarks]
                                                   ,[EntryDate]
                                                   ,[EntryBy]
                                                   ,[UpdateDate]
                                                   ,[UpdateBy]
                                                   ,[TransactiionID]
                                                   ,[Expense_ID]
                                                   ,[Category_ID]
                                                   ,[Branch_ID])
                                             VALUES
                                                   (
                                                   '" + assetName + @"'
                                                   ,''
                                                   ,'" + exDate + @"'
                                                   ,'" + exps + @"'
                                                   ,'" + CategoryName + @"'
                                                   ," + rate + @"
                                                   ," + tk + @"
                                                   ," + tk + @"
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,'Approved'
                                                   ,'" + rem + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ," + trnId + @"
                                                   ," + expenseId + @"
                                                   ," + catID + @"
                                                   ," + GlobalVariableBO._branchId + @"
                                                   )";
                            _dbConnection.ConnectDatabase();
                            _dbConnection.ExecuteNonQuery(sendAsset);
                            _dbConnection.CloseDatabase();
                        }
                    }
                    else if (pMedia == "Cash")
                    {
                        //Start sending to [dbo].[AccTransaction]
                        string sendAccTransaction = @"INSERT INTO [SBP_Database].[dbo].[AccTransaction]
                                                   ([VoucherNo]
                                                   ,[PDate]
                                                   ,[AccSub_Hade]
                                                   ,[AccSub_Sub_Hade]
                                                   ,[DrAmt]
                                                   ,[CrAmt]
                                                   ,[Balance]
                                                   ,[TransactionType]
                                                   ,[Cash_Cheque]
                                                   ,[ChequeNO]
                                                   ,[BankRoutingNo]
                                                   ,[BankName]
                                                   ,[Bank_Branch]
                                                   ,[Branch_ID]
                                                   ,[Dr_Cr_Acc]
                                                   ,[DrCr_SubHad_code]
                                                   ,[Remarks]
                                                   ,[EntyBy]
                                                   ,[EntyDate])
                                             VALUES
                                                   ('" + vNo + @"'
                                                   ,'" + exDate + @"'
                                                   ,'2012000'
                                                   ,''
                                                   ,0.00
                                                   ," + tk + @"
                                                   ,0.00
                                                   ,'Payment'
                                                   ,'Cash'
                                                   ,''
                                                   ,''
                                                   ,''
                                                   ,''
                                                   ," + GlobalVariableBO._branchId + @"
                                                   ,'Cr'
                                                   ,'4011001'
                                                   ,'" + rem + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                    )";
                        _dbConnection.ConnectDatabase();
                        _dbConnection.ExecuteNonQuery(sendAccTransaction);
                        _dbConnection.CloseDatabase();
                        //Stop sending to [dbo].[AccTransaction]



                        // To approve in Transaction table
                        ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                        expenseApprovalBAL.ApproveSelectedExpense(trnId);


                        if (catID == 9)
                        {
                            //To send SBP_Asset table
                            string sendAsset = @"INSERT INTO [SBP_Database].[dbo].[SBP_Asset]
                                                   ([Name]
                                                   ,[Model]
                                                   ,[PurchaseDate]
                                                   ,[Type]
                                                   ,[Catagori]
                                                   ,[Quantity]
                                                   ,[Rate]
                                                   ,[Cost]
                                                   ,[LifeTime]
                                                   ,[SalvageValue]
                                                   ,[DepreciationRate]
                                                   ,[DepreciationAmount]
                                                   ,[NetBalance]
                                                   ,[Status]
                                                   ,[Remarks]
                                                   ,[EntryDate]
                                                   ,[EntryBy]
                                                   ,[UpdateDate]
                                                   ,[UpdateBy]
                                                   ,[TransactiionID]
                                                   ,[Expense_ID]
                                                   ,[Category_ID]
                                                   ,[Branch_ID])
                                             VALUES
                                                   (
                                                   '" + assetName + @"'
                                                   ,''
                                                   ,'" + exDate + @"'
                                                   ,'" + exps + @"'
                                                   ,'" + CategoryName + @"'
                                                   ," + qty + @"
                                                   ," + rate + @"
                                                   ," + tk + @"
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,'Approved'
                                                   ,'" + rem + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ," + trnId + @"
                                                   ," + expenseId + @"
                                                   ," + catID + @"
                                                   ," + GlobalVariableBO._branchId + @"
                                                   )";
                            _dbConnection.ConnectDatabase();
                            _dbConnection.ExecuteNonQuery(sendAsset);
                            _dbConnection.CloseDatabase();
                        }
                    }
                    LoadGridData();
                    MessageBox.Show("Successfully Approved.", "Approve Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private ExpenseTransactionBAL expTranBal = new ExpenseTransactionBAL();

        public string NextTranID()
        {
            DataTable dt = new DataTable();
            string queryString = "select isnull(max(cast(TrnID as numeric)),0)+1 from [BankBook].[dbo].[TranactionApprovedata]";
            dt = expTranBal.Get_Data(queryString);
            return (dt.Rows[0][0].ToString());
        }
        public string NextCityID()
        {
            DataTable dt = new DataTable();
            string queryString = @"select isnull(max(cast(City_ID as numeric)),0)+1 from [BankBook].[dbo].[CityBankBook]";

            dt = expTranBal.Get_Data(queryString);
            return (dt.Rows[0][0].ToString());
        }
        public string GroupNextID()
        {
            DataTable dt = new DataTable();
            string queryString = "select isnull(max(cast(GroupID as numeric)),0)+1 from [BankBook].[dbo].[CityBankBook]";

            dt = expTranBal.Get_Data(queryString);
            return (dt.Rows[0][0].ToString());
        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvExpenseInfo.Rows.Count <= 0)
            {
                MessageBox.Show("Approve list is Empty!", "Approve Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Do you want to continue to Reject selected Deposit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //DepRejectionReason rejectionReason = new DepRejectionReason();
                    //rejectionReason.ShowDialog();

                    int index = dgvExpenseInfo.SelectedRows[0].Index;
                    if (index < 0)
                        return;
                    int expenseId = Convert.ToInt32(dgvExpenseInfo.Rows[index].Cells["Transaction_ID"].Value.ToString());
                    //string rejectReason = rejectionReason.txtRejectionReason.Text;
                    ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                    expenseApprovalBAL.RejectSelectedExpense(expenseId);

                    MessageBox.Show("Selected Expense has been Rejected", "Reject Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rejection unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnRejectAll_Click(object sender, EventArgs e)
        {
            if (dgvExpenseInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Reject", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Do you want to continue to Reject All selected Deposit?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    //DepRejectionReason rejectionReason = new DepRejectionReason();
                    //rejectionReason.ShowDialog();
                    foreach (DataGridViewRow row in dgvExpenseInfo.Rows)
                    {
                        int index = row.Index;
                        int expenseId = Convert.ToInt32(dgvExpenseInfo.Rows[index].Cells["Transaction_ID"].Value.ToString());
                        //string rejectReason = rejectionReason.txtRejectionReason.Text;
                        ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                        expenseApprovalBAL.RejectSelectedExpense(expenseId);
                    }
                    MessageBox.Show("All Selected Expense has been Rejected.");
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rejection unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnAcceptAll_Click(object sender, EventArgs e)
        {
            if (dgvExpenseInfo.Rows.Count <= 0)
            {
                MessageBox.Show("No customer has been select for Approved", "Invalid Selection.");
                return;
            }
            if (MessageBox.Show("Want to approve all transactions??", "Approval alert!!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvExpenseInfo.Rows)
                    {
                        int index = row.Index;
                        decimal rate = 0;
                        int qty = 0;
                        int trnId = Convert.ToInt32(dgvExpenseInfo.Rows[index].Cells["Transaction_ID"].Value.ToString());
                        int expenseId = Convert.ToInt32(dgvExpenseInfo.Rows[index].Cells["Expense_ID"].Value.ToString());
                        int catID = Convert.ToInt32(dgvExpenseInfo.Rows[index].Cells["Category_ID"].Value.ToString());
                        string pMedia = (dgvExpenseInfo.Rows[index].Cells["Payment_Media"].Value.ToString());
                        string bAccNo = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Account_No"].Value.ToString());
                        string bName = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Bank_Name"].Value.ToString());
                        string cqNo = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Cheque_No"].Value.ToString());
                        DateTime exDate = Convert.ToDateTime(dgvExpenseInfo.Rows[index].Cells["Expense_Date"].Value.ToString());
                        string exps = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Expense"].Value.ToString());
                        Double tk = Convert.ToDouble(dgvExpenseInfo.Rows[index].Cells["Amount"].Value.ToString());
                        string vNo = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Voucher_No"].Value.ToString());
                        string rem = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Remarks"].Value.ToString());
                        string assetName = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["AssetName"].Value.ToString());
                        string CategoryName = Convert.ToString(dgvExpenseInfo.Rows[index].Cells["Category"].Value.ToString());
                        string strQty = dgvExpenseInfo.Rows[index].Cells["Qty"].Value.ToString();
                        if (!string.IsNullOrEmpty(strQty))
                            qty = Convert.ToInt32(strQty);
                        string strRate = dgvExpenseInfo.Rows[index].Cells["Rate"].Value.ToString();
                        if (!string.IsNullOrEmpty(strRate))
                            rate = Convert.ToDecimal(strRate);

                        if (pMedia == "Cheque")
                        {
                            ExpenseTransactionBAL expTranBal = new ExpenseTransactionBAL();
                            DataTable Biddt = new DataTable();
                            string Bid = @"select BankId from [BankBook].[dbo].[BankInfo] where BankAcc='" + bAccNo + "'";
                            Biddt = expTranBal.Get_Data(Bid);

                            DataTable APdt = new DataTable();
                            string AP = @"select AccountPurpose from [BankBook].[dbo].[BankInfo]  where BankAcc='" + bAccNo + "'";
                            APdt = expTranBal.Get_Data(AP);


                            string tID = NextTranID();
                            string cID = NextCityID();
                            string gID = GroupNextID();
                            string saveCityBankBook = @"INSERT INTO [BankBook].[dbo].[CityBankBook]           
                                       (
                                        [City_ID]
                                       ,[GroupID]
                                       ,[BankId]
                                       ,[TransactionID]
                                       ,[AccountNumber]
                                       ,[AccountPurpose]
                                       ,[Date]
                                       ,[SBP_ReceiveDate]
                                       ,[Particular]
                                       ,[PaymentType]
                                       ,[ChequeNo]
                                       ,[VoucherNo]
                                       ,[PaymentMedia]
                                       ,[CrediteAmount]
                                       ,[TotalAmount]
                                       ,[Status]
                                       ,[Cheque_Status]
                                       ,[StatusforDelation]
                                       ,[CreateBy]
                                       ,[CreateDate]
                                       ,[DebitAmount]
                                       ,[TransferMedia]
                                      )
                                 VALUES
                                       (
                                        '" + cID + @"'
                                       ,'" + gID + @"'
                                       ,'" + Biddt.Rows[0][0].ToString() + @"'
                                       ,0
                                       ,'" + bAccNo + @"'
                                       ,'" + APdt.Rows[0][0].ToString() + @"'
                                       ,'" + exDate + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,'" + exps + @"'
                                       ,'Credit'
                                       ,'" + cqNo + @"'
                                        ,'" + vNo + @"'
                                       ,'" + pMedia + @"'
                                       ,'" + tk + @"'
                                       ,'" + tk + @"'
                                       ,'Approved'
                                       ,'ChequeUnclear'
                                       ,'A'
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,0
                                       ,'Expense'
                                        )";
                            string saveApprovedDataTable = @"INSERT INTO [BankBook].[dbo].[TranactionApprovedata]           
                                       (
                                        [TrnID]
                                       ,[City_ID]
                                       ,[GroupID]
                                       ,[BankId]
                                       ,[TransactionID]
                                       ,[AccountNumber]
                                       ,[AccountPurpose]
                                       ,[Date]
                                       ,[SBP_ReceiveDate]
                                       ,[Particular]
                                       ,[PaymentType]
                                       ,[ChequeNo]
                                       ,[VoucherNo]
                                       ,[PaymentMedia]
                                       ,[CrediteAmount]
                                       ,[TotalAmount]
                                       ,[Status]
                                       ,[Cheque_Status]
                                       ,[StatusforDelation]
                                       ,[CreateBy]
                                       ,[CreateDate]
                                       ,[DebitAmount]
                                       ,[TransferMedia]
                                      )
                                 VALUES
                                       (
                                        '" + tID + @"'
                                       ,'" + cID + @"'
                                       ,'" + gID + @"'
                                       ,'" + Biddt.Rows[0][0].ToString() + @"'
                                       ,0
                                       ,'" + bAccNo + @"'
                                       ,'" + APdt.Rows[0][0].ToString() + @"'
                                       ,'" + exDate + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,'" + exps + @"'
                                       ,'Credit'
                                       ,'" + cqNo + @"'
                                        ,'" + vNo + @"'
                                       ,'" + pMedia + @"'
                                       ,'" + tk + @"'
                                       ,'" + tk + @"'
                                       ,'Approved'
                                       ,'ChequeUnclear'
                                       ,'A'
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,0
                                       ,'Expense'
                                        )";
                            ExpenseTransactionBAL Ex_Trans_BankBook = new ExpenseTransactionBAL();
                            Ex_Trans_BankBook.SaveDt_CityBankBook(saveCityBankBook);
                            Ex_Trans_BankBook.SaveDt_CityBankBook(saveApprovedDataTable);

                            ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                            expenseApprovalBAL.ApproveSelectedExpense(trnId);


                            if (catID == 9)
                            {
                                //To send SBP_Asset table
                                string sendAsset = @"INSERT INTO [SBP_Database].[dbo].[SBP_Asset]
                                                   ([Name]
                                                   ,[Model]
                                                   ,[PurchaseDate]
                                                   ,[Type]
                                                   ,[Catagori]
                                                   ,[Quantity]
                                                   ,[Rate]
                                                   ,[Cost]
                                                   ,[LifeTime]
                                                   ,[SalvageValue]
                                                   ,[DepreciationRate]
                                                   ,[DepreciationAmount]
                                                   ,[NetBalance]
                                                   ,[Status]
                                                   ,[Remarks]
                                                   ,[EntryDate]
                                                   ,[EntryBy]
                                                   ,[UpdateDate]
                                                   ,[UpdateBy]
                                                   ,[TransactiionID]
                                                   ,[Expense_ID]
                                                   ,[Category_ID]
                                                   ,[Branch_ID])
                                             VALUES
                                                   (
                                                   '" + assetName + @"'
                                                   ,''
                                                   ,'" + exDate + @"'
                                                   ,'" + exps + @"'
                                                   ,'" + CategoryName + @"'
                                                   ,1
                                                   ," + tk + @"
                                                   ," + tk + @"
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,'Approved'
                                                   ,'" + rem + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ," + trnId + @"
                                                   ," + expenseId + @"
                                                   ," + catID + @"
                                                   ," + GlobalVariableBO._branchId + @"
                                                   )";
                                _dbConnection.ConnectDatabase();
                                _dbConnection.ExecuteNonQuery(sendAsset);
                                _dbConnection.CloseDatabase();
                            }
                        }
                        else if (pMedia == "Cash")
                        {
                            //Start sending to [dbo].[AccTransaction]
                            string sendAccTransaction = @"INSERT INTO [SBP_Database].[dbo].[AccTransaction]
                                                   ([VoucherNo]
                                                   ,[PDate]
                                                   ,[AccSub_Hade]
                                                   ,[AccSub_Sub_Hade]
                                                   ,[DrAmt]
                                                   ,[CrAmt]
                                                   ,[Balance]
                                                   ,[TransactionType]
                                                   ,[Cash_Cheque]
                                                   ,[ChequeNO]
                                                   ,[BankRoutingNo]
                                                   ,[BankName]
                                                   ,[Bank_Branch]
                                                   ,[Branch_ID]
                                                   ,[Dr_Cr_Acc]
                                                   ,[DrCr_SubHad_code]
                                                   ,[Remarks]
                                                   ,[EntyBy]
                                                   ,[EntyDate])
                                             VALUES
                                                   ('" + vNo + @"'
                                                   ,'" + exDate + @"'
                                                   ,'2012000'
                                                   ,''
                                                   ,0.00
                                                   ," + tk + @"
                                                   ,0.00
                                                   ,'Payment'
                                                   ,'Cash'
                                                   ,''
                                                   ,''
                                                   ,''
                                                   ,''
                                                   ," + GlobalVariableBO._branchId + @"
                                                   ,'Cr'
                                                   ,'4011001'
                                                   ,'" + rem + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                    )";
                            _dbConnection.ConnectDatabase();
                            _dbConnection.ExecuteNonQuery(sendAccTransaction);
                            _dbConnection.CloseDatabase();
                            //Stop sending to [dbo].[AccTransaction]

                            ExpenseApprovalBAL expenseApprovalBAL = new ExpenseApprovalBAL();
                            expenseApprovalBAL.ApproveSelectedExpense(trnId);


                            if (catID == 9)
                            {
                                //To send SBP_Asset table
                                string sendAsset = @"INSERT INTO [SBP_Database].[dbo].[SBP_Asset]
                                                   ([Name]
                                                   ,[Model]
                                                   ,[PurchaseDate]
                                                   ,[Type]
                                                   ,[Catagori]
                                                   ,[Quantity]
                                                   ,[Rate]
                                                   ,[Cost]
                                                   ,[LifeTime]
                                                   ,[SalvageValue]
                                                   ,[DepreciationRate]
                                                   ,[DepreciationAmount]
                                                   ,[NetBalance]
                                                   ,[Status]
                                                   ,[Remarks]
                                                   ,[EntryDate]
                                                   ,[EntryBy]
                                                   ,[UpdateDate]
                                                   ,[UpdateBy]
                                                   ,[TransactiionID]
                                                   ,[Expense_ID]
                                                   ,[Category_ID]
                                                   ,[Branch_ID])
                                             VALUES
                                                   (
                                                   '" + assetName + @"'
                                                   ,''
                                                   ,'" + exDate + @"'
                                                   ,'" + exps + @"'
                                                   ,'" + CategoryName + @"'
                                                   ," + qty + @"
                                                   ," + rate + @"
                                                   ," + tk + @"
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,0
                                                   ,'Approved'
                                                   ,'" + rem + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ,'" + GlobalVariableBO._currentServerDate + @"'
                                                   ,'" + GlobalVariableBO._userName + @"'
                                                   ," + trnId + @"
                                                   ," + expenseId + @"
                                                   ," + catID + @"
                                                   ," + GlobalVariableBO._branchId + @"
                                                   )";
                                _dbConnection.ConnectDatabase();
                                _dbConnection.ExecuteNonQuery(sendAsset);
                                _dbConnection.CloseDatabase();
                            }
                        }
                    }
                    MessageBox.Show("All expense request has been approved successfully.", "Approve Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Approved unsuccessfull. Error Occured: " + ex.Message);
                }
            }
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGridData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

