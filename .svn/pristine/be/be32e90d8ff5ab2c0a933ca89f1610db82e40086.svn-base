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
using BusinessAccessLayer.Constants;
using CrystalDecisions.CrystalReports.Engine;
using Reports;
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class frmBOClosing_Procedure : Form
    {
        private DbConnection _dbConnection = new DbConnection();

        public frmBOClosing_Procedure()
        {
            InitializeComponent();
        }
        DataTable dtActiveAccountList=new DataTable();
        string []BOID;

        private enum FormExecutionMode
        {
            ShowActiveAccountListMode
           ,AnnualChargeWithdrawMode
           ,BOClosingRefundSimpleMode
           ,BOClosingRefundErrorMode
           ,Deposit98AccountListMode
           , BOClosingRefundBeforeCheckMode
        }
        private void FormsExecutionMode(FormExecutionMode formExecutionMode)
        {
            switch(formExecutionMode)
            {
                case FormExecutionMode.ShowActiveAccountListMode:
                    SetForms_ShowActiveAccountListMode();
                    break;
                case FormExecutionMode.AnnualChargeWithdrawMode:
                    SetForms_AnnualChargeWithdrawMode();
                    break;
                case FormExecutionMode.BOClosingRefundBeforeCheckMode:
                    SetForms_BOClosingRefundBeforeCheckMode();
                    break;
                case FormExecutionMode.BOClosingRefundSimpleMode:
                    SetForms_BOClosingRefundSimpleMode();
                    break;
                case FormExecutionMode.BOClosingRefundErrorMode:
                    SetForms_BOClosingRefundErrorMode();
                    break;
                case FormExecutionMode.Deposit98AccountListMode:
                    SetForms_Deposit98AccountListMode();
                    break;
            }
        }
        private void SetForms_ShowActiveAccountListMode()
        {
            this.Size = new Size(605, 356);
            tabBOClosingProcedure.Size = new Size(573, 299);
        }
        private void SetForms_AnnualChargeWithdrawMode()
        {
            this.Size = new Size(605, 356);
            tabBOClosingProcedure.Size = new Size(573, 299);
        }

        private void SetForms_BOClosingRefundSimpleMode()
        {
            //dtpReceivedDate_Deposit98Account.Enabled = false;
            this.Size = new Size(605, 356);
            tabBOClosingProcedure.Size = new Size(573, 299);
            btnRefundAnnualCharge.Enabled = true;
        }
        private void SetForms_BOClosingRefundErrorMode()
        {
            this.Size = new Size(605, 519);
            tabBOClosingProcedure.Size = new Size(573, 441);

            if (this.Location.Y >= 151)
            {
                this.Location = new Point(this.Location.X, this.Location.Y - 60);
            }
            btnRefundAnnualCharge.Enabled = false;
        }

        private void SetForms_BOClosingRefundBeforeCheckMode()
        {
            this.Size = new Size(605, 356);
            tabBOClosingProcedure.Size = new Size(573, 299);
            btnRefundAnnualCharge.Enabled = false;
        }

        private void SetForms_Deposit98AccountListMode()
        {
            this.Size = new Size(605, 356);
            tabBOClosingProcedure.Size = new Size(573, 299);
        }

        private void btnViewAllActiveAccountList_Click(object sender, EventArgs e)
        {
            
            BOClosing_ProcedureBAL activeAccountListBAL = new BOClosing_ProcedureBAL();
            //DataTable dtActiveAccountList = new DataTable();
            frmReportViewer ReportViewer=new frmReportViewer();
            crActiveAccountList activeAccountList=new crActiveAccountList();
            this.Cursor = Cursors.WaitCursor;
            string voucherSn = string.Empty;
            DateTime receivedDate = new DateTime();
            receivedDate = Convert.ToDateTime(dtpReportDate.Value.ToString("dd-MM-yyyy"));
            //voucherSn = "BAC" + dtp_ClosingYear_AllActiveAccList.Value.Year.ToString();

            dtActiveAccountList = activeAccountListBAL.GetActiveAccountList(dtp_ClosingYear_AllActiveAccList.Value.Year.ToString(),dtpReportDate.Value);
            activeAccountList.SetDataSource(dtActiveAccountList);
            ReportViewer.crvReportViewer.ReportSource = activeAccountList;
            this.Cursor = Cursors.Default;
            ReportViewer.Show();
        }

        
        private void SetWithdrawClosingYear(DateTimePicker dtpclosingYear)
        {
            int month = 0;
            DateTime temp = DateTime.Now;
            month = temp.Month;
            if (month > 6)
            {
                if (dtpclosingYear.Name == "dtpWithdrawAnnualChargeClosingYear")
                {
                    dtpWithdrawAnnualChargeClosingYear.Value = temp.AddYears(1);
                }

                else if (dtpclosingYear.Name == "dtpRefundClosingYear")
                {
                    dtpRefundClosingYear.Value = temp.AddYears(1);
                }
                else if (dtpclosingYear.Name == "dtpClosingYear98Account")
                {
                    dtpClosingYear98Account.Value = temp.AddYears(1);
                }
                else if (dtpclosingYear.Name == "dtpClosingYear99Account")
                {
                    dtpClosingYear99Account.Value = temp.AddYears(1);
                }
            }
        }

        private void tabBOClosingProcedure_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabBOClosingProcedure.SelectedIndex == 0)
            {
                FormsExecutionMode(FormExecutionMode.ShowActiveAccountListMode);
            }
            if (tabBOClosingProcedure.SelectedIndex == 1)
            {
                SetWithdrawClosingYear(dtpWithdrawAnnualChargeClosingYear);
                FormsExecutionMode(FormExecutionMode.AnnualChargeWithdrawMode);
            }
            else if( tabBOClosingProcedure.SelectedIndex == 2)
            {
                FormsExecutionMode(FormExecutionMode.BOClosingRefundBeforeCheckMode);
                SetWithdrawClosingYear(dtpRefundClosingYear);
            }
            else if (tabBOClosingProcedure.SelectedIndex == 3)
            {
                FormsExecutionMode(FormExecutionMode.BOClosingRefundSimpleMode);
                SetWithdrawClosingYear(dtpClosingYear98Account);
            }
            else if (tabBOClosingProcedure.SelectedIndex == 4)
            {
                FormsExecutionMode(FormExecutionMode.BOClosingRefundSimpleMode);
                SetWithdrawClosingYear(dtpClosingYear99Account);
            }
        }
        //----------------------------------Withdraw Section-------------------------------------//
        private bool IsValid_WithdrawAnnual()
        {
            bool valid = true;
            BOClosing_ProcedureBAL bal = new BOClosing_ProcedureBAL();
            if (txtWithdrawAmount.Text == string.Empty)
            {
                MessageBox.Show(@"Withdraw amount required", @"Withdraw amount check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valid = false;
            }               

            return valid;
        }
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
             DataTable dt = new DataTable();
            BOClosing_ProcedureBAL activeAccountListBAL = new BOClosing_ProcedureBAL();
           // DataTable dtActiveAccountList = new DataTable();
            try
            {
                
                if (IsValid_WithdrawAnnual())
                {
                    ExpenseTransactionBAL etb = new ExpenseTransactionBAL();
                    string voucherSn = string.Empty;
                    DateTime receivedDate = new DateTime();
                    receivedDate = Convert.ToDateTime(dtpWithdrawDate.Value.ToString("dd-MM-yyyy"));                   

                    dtActiveAccountList = activeAccountListBAL.GetActiveAccountList(dtpWithdrawAnnualChargeClosingYear.Value.Year.ToString(), dtpWithdrawDate.Value);
                    voucherSn = "BAC" + dtpWithdrawAnnualChargeClosingYear.Value.Year.ToString();
                    //string cCode = dtActiveAccountList.Rows[0][1].ToString();
                    string amt = dtActiveAccountList.Rows[0][4].ToString();
                    string query = @"SELECT COUNT(*) AS count
                                    FROM dbo.SBP_Customers 
                                    INNER JOIN dbo.SBP_Payment 
                                    ON dbo.SBP_Customers.Cust_Code = dbo.SBP_Payment.Cust_Code
                                    GROUP BY dbo.SBP_Customers.BO_Status_ID, dbo.SBP_Payment.Voucher_Sl_No
                                    HAVING (dbo.SBP_Customers.BO_Status_ID = 1) AND (dbo.SBP_Payment.Voucher_Sl_No = '" + voucherSn + "')";
                    dt = etb.Get_Data(query);
                    if(dt.Rows.Count==0)
                    {
                        try
                        {
                            ProcessWithrowAnnualCharge(dtActiveAccountList, receivedDate);
                            MessageBox.Show(@"Annual charge withdraw successfull");
                            progressBar1.Value = 0;

                            SendToSBP_Income();                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Annual Charge Deduction Denied. The Error : '" + ex + "'");
                        }
                    }
                    else if (dt.Rows.Count > 0)
                    {
                        if (MessageBox.Show("Do you want Deduct Annual Charge Again For The Year '" + dtpWithdrawAnnualChargeClosingYear.Value.Year.ToString() + "'", "Alert!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                ProcessWithrowAnnualCharge(dtActiveAccountList, receivedDate);
                                MessageBox.Show(@"Annual charge withdraw successfull");
                                progressBar1.Value = 0;

                                SendToSBP_Income(); 
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Annual Charge Deduction Denied. The Error : '" + ex + "'");
                            }                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendToSBP_Income()
        {
            double doubleTryparse;
            BOClosing_ProcedureBAL activeAccountListBAL = new BOClosing_ProcedureBAL();
            int totalRow = dtActiveAccountList.Rows.Count;

            double HCharge = 0;
            if (double.TryParse(txtHouseCharge.Text, out doubleTryparse))
                HCharge = doubleTryparse;

            double CDBLCharge = 0;
            if (double.TryParse(txtCDBLCharge.Text, out doubleTryparse))
                CDBLCharge = doubleTryparse;

            double totalHouseCharge = totalRow * Convert.ToDouble(HCharge);
            double totalCDBLCharge = totalRow * Convert.ToDouble(CDBLCharge);
            string voucherSn = "BAC" + dtpWithdrawAnnualChargeClosingYear.Value.Year.ToString();
            DateTime rcvDate = Convert.ToDateTime(dtpWithdrawDate.Value.ToString("dd-MM-yyyy"));

            string queryIntoSBP_Income_Entry_TotalHouseCharge_100 = @"INSERT INTO [SBP_Database].[dbo].[SBP_IncomeEntry]
                                                           ([VoucherSLNo]
                                                           ,[RcvDate]
                                                           ,[RcvFrom]
                                                           ,[ClientCode]
                                                           ,[Dr_Cr]
                                                           ,[Dr_Amount]
                                                           ,[Cr_Amount]
                                                           ,[Purpose]
                                                           ,[TrnType]
                                                           ,[AccHead]
                                                           ,[AccSubHead]
                                                           ,[RoutingNo]
                                                           ,[BankName]
                                                           ,[BankBranchName]
                                                           ,[DistrictName]
                                                           ,[ChequeNo]
                                                           ,[PayDate]
                                                           ,[Status]
                                                           ,[BrokerBranchID]
                                                           ,[EntryDate]
                                                           ,[EntryBy]
                                                           ,[UpdateDate]
                                                           ,[UpdateBy])
                                                     VALUES
                                                           ('" + voucherSn + @"'
                                                           ,'" + rcvDate + @"'
                                                           ,'All Active Customer'
                                                           ,0
                                                           ,'Deposit'
                                                           ," + totalHouseCharge + @"
                                                           ,0.00
                                                           ,'BO Annual Charge(CDBL)'
                                                           ,'Cash'
                                                           ,'I003'
                                                           ,'I003iii'
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,'Approved'
                                                           ," + GlobalVariableBO._branchId + @"
                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
                                                           ,'" + GlobalVariableBO._userName + @"'
                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
                                                           ,'" + GlobalVariableBO._userName + @"')";
            string queryIntoSBP_Income_Entry_TotalCDBL_Charge400 = @"INSERT INTO [SBP_Database].[dbo].[SBP_IncomeEntry]
                                                           ([VoucherSLNo]
                                                           ,[RcvDate]
                                                           ,[RcvFrom]
                                                           ,[ClientCode]
                                                           ,[Dr_Cr]
                                                           ,[Dr_Amount]
                                                           ,[Cr_Amount]
                                                           ,[Purpose]
                                                           ,[TrnType]
                                                           ,[AccHead]
                                                           ,[AccSubHead]
                                                           ,[RoutingNo]
                                                           ,[BankName]
                                                           ,[BankBranchName]
                                                           ,[DistrictName]
                                                           ,[ChequeNo]
                                                           ,[PayDate]
                                                           ,[Status]
                                                           ,[BrokerBranchID]
                                                           ,[EntryDate]
                                                           ,[EntryBy]
                                                           ,[UpdateDate]
                                                           ,[UpdateBy])
                                                     VALUES
                                                           ('" + voucherSn + @"'
                                                           ,'" + rcvDate + @"'
                                                           ,'All Active Customer'
                                                           ,0
                                                           ,'Deposit'
                                                           ," + totalCDBLCharge + @"
                                                           ,0.00
                                                           ,'BO Annual Charge'
                                                           ,'" + Indication_PaymentTransaction.Cash + @"'
                                                           ,'I003'
                                                           ,'I003iv'
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,''
                                                           ,'Approved'
                                                           ," + GlobalVariableBO._branchId + @"
                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
                                                           ,'" + GlobalVariableBO._userName + @"'
                                                           ,'" + GlobalVariableBO._currentServerDate + @"'
                                                           ,'" + GlobalVariableBO._userName + @"')";

            //activeAccountListBAL.DeductedChargeSendToSBP_Income(voucherSn
            //                                                    , rcvDate);
            try
            {
                _dbConnection.CloseDatabase();
                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(queryIntoSBP_Income_Entry_TotalHouseCharge_100);
                _dbConnection.ExecuteNonQuery(queryIntoSBP_Income_Entry_TotalCDBL_Charge400);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbConnection.CloseDatabase();
            }
        }

        private void ProcessWithrowAnnualCharge(DataTable dtActiveAccountList,DateTime ReceivedDate)
        {
            BOClosing_ProcedureBAL activeAccountListBAL = new BOClosing_ProcedureBAL();
            BOClosing_ProcedureBO bOClosing_ProcedureBO = new BOClosing_ProcedureBO();
            for (int i = 0; i < dtActiveAccountList.Rows.Count; i++)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = dtActiveAccountList.Rows.Count;
                bOClosing_ProcedureBO = GetBOClosing_ProcedureBO();
                bOClosing_ProcedureBO.Cust_Code = dtActiveAccountList.Rows[i][1].ToString();
                bOClosing_ProcedureBO.Received_Date = ReceivedDate;
                activeAccountListBAL.Withdraw_Active_Account_Annual_Charge(bOClosing_ProcedureBO);
                progressBar1.Value = i;
            }
        }
        private BOClosing_ProcedureBO GetBOClosing_ProcedureBO()
        {
            BOClosing_ProcedureBO bOClosing_ProcedureBO=new BOClosing_ProcedureBO();

            bOClosing_ProcedureBO.Amount = Convert.ToDouble(txtWithdrawAmount.Text);
            bOClosing_ProcedureBO.Received_Date = Convert.ToDateTime(dtpWithdrawDate.Value.ToString("dd-MM-yyyy"));
            bOClosing_ProcedureBO.Payment_Media = Indication_PaymentTransaction.Cash;
            bOClosing_ProcedureBO.Payment_Media_No = DBNull.Value;
            bOClosing_ProcedureBO.Received_By = GlobalVariableBO._userName;
            bOClosing_ProcedureBO.Deposit_Withdraw = Indication_PaymentMode.Withdraw;
            bOClosing_ProcedureBO.VoucherSl_No = "BAC" + dtpWithdrawAnnualChargeClosingYear.Value.Year.ToString();
            bOClosing_ProcedureBO.Trans_Reason = "BAC-" + dtpWithdrawAnnualChargeClosingYear.Value.Year.ToString();
            bOClosing_ProcedureBO.Entry_Date = Convert.ToDateTime(dtpWithdrawDate.Value.ToString("dd-MM-yyyy"));
            bOClosing_ProcedureBO.Entry_By = GlobalVariableBO._userName;
            bOClosing_ProcedureBO.Entry_Branch_ID = GlobalVariableBO._branchId;
            return bOClosing_ProcedureBO;
        }
 //--------------------------Refund Annual charge Section-------------------------//
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                SetFilePath();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void SetFilePath()
        {
            OpenFileDialog ofdFilePath = new OpenFileDialog();

            ofdFilePath.Title = @"Open a text File";
            ofdFilePath.Filter = @"TXT Files|*.txt";
            ofdFilePath.InitialDirectory = @"C:\";

            if (ofdFilePath.ShowDialog() == DialogResult.OK && ofdFilePath.FileName!=string.Empty)
            {
                if (tabBOClosingProcedure.SelectedIndex == 2)
                {
                    txtFilePath.Text = ofdFilePath.FileName.Trim();
                    UploadProcess(txtFilePath.Text);
                }
                if (tabBOClosingProcedure.SelectedIndex == 4)
                {
                    txtFilepathDeposit99Acc.Text = ofdFilePath.FileName.Trim();
                    UploadProcess(txtFilepathDeposit99Acc.Text);
                }
            }
        }        

        private void btnRefundAnnualCharge_Click(object sender, EventArgs e)
        {
            BOClosing_ProcedureBAL boClosingProcedureBal=new BOClosing_ProcedureBAL();
            try
            {
                ProcessBOClosingTextFile();
                string voucherNo = "BAC" + dtpRefundClosingYear.Value.Year.ToString();
                DateTime Received_Date = dtpRefundDate.Value;
                this.Cursor = Cursors.WaitCursor;
                boClosingProcedureBal.RefundBOClosingCharge(voucherNo,Received_Date);
                boClosingProcedureBal.Process_Settlement();
                this.Cursor = Cursors.Default;
                MessageBox.Show("Refund Successfull");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string voucherNo = "BAC" + dtpRefundClosingYear.Value.Year.ToString();
            string Received_Date = dtpRefundDate.Value.ToString("yyyy-MM-dd");
            try
            {

                bool b = new BOClosing_ProcedureBAL().CheckDataAvailability(voucherNo, Received_Date);
                if (b)
                {
                    ProcessBOClosingTextFile();
                    this.Cursor = Cursors.WaitCursor;
                    SetErrorLog();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(@"File checked Completed");
                }
                else
                {
                    MessageBox.Show("There is no data in this date.." + "\r\n" + "Please Check Date First..");
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        
        public void UploadProcess(string filePath)
        {
            DataTable BOCloseDataTable = null;
            BOCloseDataTable = ProcessIPOFile(filePath);
            BOCloseBAL boCloseBal = new BOCloseBAL();
            boCloseBal.TruncatBOCloseTemp();
            boCloseBal.SaveProcessedBOCloseInfo(BOCloseDataTable, "SBP_08DP04UX");
        }
        public DataTable ProcessIPOFile(string filePath)
        {
            string lineText;
            string[] tempValue;
            char proChar = '~';
            StreamReader streamReader = new StreamReader(filePath);
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            lineText = streamReader.ReadLine();
            tempValue = lineText.Split(proChar);

            for (int i = 0; i < tempValue.Length; ++i)
            {
                dataTable.Columns.Add(new DataColumn());
            }
            do
            {
                string[] values = lineText.Split(proChar);
                dataRow = dataTable.NewRow();
                //values[8] = DateTime.ParseExact(values[8], "dd-MM-yyyy", null).ToShortDateString();  
                dataRow.ItemArray = values;
                dataTable.Rows.Add(dataRow);
                lineText = streamReader.ReadLine();
            } while (lineText != null);

            return dataTable;
        }
        private void ProcessBOClosingTextFile()
        {
            string[] lines = null;
           
            if (tabBOClosingProcedure.SelectedIndex == 2)
            {
                if (txtFilePath.Text == string.Empty)
                throw new Exception("There Is No File Path Selected!!");

                UploadProcess(txtFilePath.Text);
                lines = File.ReadAllLines(txtFilePath.Text);
            }
            else if (tabBOClosingProcedure.SelectedIndex == 4)
            {
                if (txtFilepathDeposit99Acc.Text == string.Empty)
                throw new Exception("There Is No File Path Selected!!");
                UploadProcess(txtFilepathDeposit99Acc.Text);
                lines = File.ReadAllLines(txtFilepathDeposit99Acc.Text);
            }            
            
            if (lines != null && lines.Length != 0)
            {
                SetBOID(lines);
            }
        }

        private void SetBOID(string[] lines)
        {
            char splitChar = '~';
            BOID = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                BOID[i] = lines[i].Split(splitChar)[0].Substring(8, 8);
            }
        }
        private void SetErrorLog()
        {
            BOClosing_ProcedureBAL  boClosingProcedureBal=new BOClosing_ProcedureBAL();
            IEnumerable<DataRow> dtAllActiveCDBLAccountList = null;
            DataTable dtErrorLog=new DataTable();
            dtErrorLog.Columns.Add("Cust_Code", typeof (System.String));
            dtErrorLog.Columns.Add("BO_ID", typeof(System.String));
            dtErrorLog.Columns.Add("Cust_Name", typeof(System.String));

            dtAllActiveCDBLAccountList = boClosingProcedureBal.Get_All_Active_CDBL_AccountList().AsEnumerable().ToList(); ;

            foreach(string boid in BOID)
            {
                var activeBOID =dtAllActiveCDBLAccountList.AsEnumerable().Where(b => b["BO_ID"].ToString() == boid).ToList();
                if(activeBOID.Count>0)
                {
                    DataRow dr = dtErrorLog.NewRow();
                    dr["Cust_Code"] = activeBOID[0].ItemArray[0].ToString();
                    dr["BO_ID"] = activeBOID[0].ItemArray[1].ToString();
                    dr["Cust_Name"] = activeBOID[0].ItemArray[2].ToString();
                    dtErrorLog.Rows.Add(dr);
                }
            }
            if (dtErrorLog.Rows.Count > 0)
            {
                dgvErrorLog.DataSource = dtErrorLog;
                FormsExecutionMode(FormExecutionMode.BOClosingRefundErrorMode);
            }
            else
            {
                FormsExecutionMode(FormExecutionMode.BOClosingRefundSimpleMode);
            }
        }

        
        private void btnGenerateErrorReport_Click(object sender, EventArgs e)
        {
            DataTable dtBOClosingErrorLog=new DataTable();
            if (dgvErrorLog.Rows.Count > 0)
            {
                dtBOClosingErrorLog = (DataTable) dgvErrorLog.DataSource;
                frmReportViewer reportViewer = new frmReportViewer();
                crBOClosingErrorLog crboClosingErrorLog = new crBOClosingErrorLog();
                crboClosingErrorLog.SetDataSource(dtBOClosingErrorLog);
                reportViewer.crvReportViewer.ReportSource = crboClosingErrorLog;
                reportViewer.Show();
            }
            else
            {
                MessageBox.Show("No Data found to report");
            }
        }


        //----------------------------98 Deposit Section---------------------------------------//

        private bool IsValid_Deposit98()
        {
            bool valid = true;
            BOClosing_ProcedureBAL bal = new BOClosing_ProcedureBAL();
            if (txtWithdrawAmount.Text == string.Empty)
            {
                MessageBox.Show(@"Withdraw amount required", @"Withdraw amount check", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                valid = false;
            }            
            return valid;
        }
        
        private void btnPreview_Click(object sender, EventArgs e)
        {
            int accNo = 98;
            
            ShowReportPreviewFor98OR99Account(accNo);

        }

        private void btnDeposit98Account_Click(object sender, EventArgs e)
        {
            int accNo = 98;
            try
            {
                ProcessDepositChargeIn98Account(accNo);
                MessageBox.Show("98 Account Deposit successfull");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ShowReportPreviewFor98OR99Account(int accNo)
        {
            CommonBAL objBal = new CommonBAL();
            DataTable AllAccountListNeedToDeposit98OR99Account = new DataTable();
            BOClosing_ProcedureBAL boClosingProcedureBal = new BOClosing_ProcedureBAL();
            DateTime receivedDate = objBal.GetCurrentServerDate();
            string voucherNo = string.Empty;

            if (accNo == 98)
            {
                 receivedDate = dtpReceivedDate_Deposit98Account.Value;
                 voucherNo = "BAC" + dtpClosingYear98Account.Value.Year.ToString();
            }
            else if(accNo==99)
            {
                 receivedDate = dtpReceivedDate_Deposit99Account.Value.Date;
                 voucherNo = "BAC" + dtpClosingYear99Account.Value.Year.ToString() + "/ClosingCharge";
            }

            AllAccountListNeedToDeposit98OR99Account = boClosingProcedureBal.GetAllAccountListNeedToDeposit98Account(accNo, voucherNo, receivedDate);
            frmReportViewer reportViewer = new frmReportViewer();
            crAllAccountListNeedToDeposit98Account crAllAccountListNeedToDeposit98Account = new crAllAccountListNeedToDeposit98Account();
            crAllAccountListNeedToDeposit98Account.SetDataSource(AllAccountListNeedToDeposit98OR99Account);
            reportViewer.crvReportViewer.ReportSource = crAllAccountListNeedToDeposit98Account;
            reportViewer.Show();
        }

        private void ProcessDepositChargeIn98Account(int accNo)
        {
            DataTable dtAllAccountListNeedToDeposit98Account = new DataTable();
            BOClosing_ProcedureBAL boClosingProcedureBal = new BOClosing_ProcedureBAL();
            DateTime receivedDate = DateTime.Now;
            string voucherNo = string.Empty;

            if(accNo==98)//if (tabBOClosingProcedure.SelectedIndex==4)
            {
                receivedDate = dtpReceivedDate_Deposit98Account.Value;
                voucherNo = "BAC" + dtpClosingYear98Account.Value.Year.ToString();
            }
            //else if (tabBOClosingProcedure.SelectedIndex == 4)
            //{
            //    receivedDate = dtpReceivedDate_Deposit99Account.Value;
            //    voucherNo = "BAC" + dtpClosingYear99Account.Value.Year.ToString() + "/ClosingCharge";
            //}

            dtAllAccountListNeedToDeposit98Account =
                boClosingProcedureBal.GetAllAccountListNeedToDeposit98Account(accNo, voucherNo, receivedDate);
            boClosingProcedureBal.DepositBOClosingChargeInto98Account( dtAllAccountListNeedToDeposit98Account,receivedDate);
        }

        //----------------------------99 Deposit Section---------------------------------------//

        private void btnPreview99accDeposit_Click(object sender, EventArgs e)
        {
            int accNo = 99;
            ProcessBOClosingTextFile();
            ShowReportPreviewFor98OR99Account(accNo);
        }

        private void btnDeposit99Account_Click(object sender, EventArgs e)
        {
            string voucherNo = string.Empty;

            try
            {
                ProcessBOClosingTextFile();
                BOClosing_ProcedureBAL boClosingProcedureBal=new BOClosing_ProcedureBAL();
                voucherNo = "BAC" + dtpClosingYear99Account.Value.Year.ToString() + "/ClosingCharge";
                boClosingProcedureBal.TakeBOClosingCharge(voucherNo);
                boClosingProcedureBal.Process_Settlement();
                MessageBox.Show("99 Account Deposit successfull");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnBrowseFileDeposit99Acc_Click(object sender, EventArgs e)
        {
            SetFilePath();
        }
        
        private void txtHouseCharge_TextChanged(object sender, EventArgs e)
        {
            double doubleTryparse;

            if(txtHouseCharge.Text != "")
            {
                double HCharge = 0;
                if (double.TryParse(txtHouseCharge.Text, out doubleTryparse))
                    HCharge = doubleTryparse;

                double CDBLCharge = 0;
                if (double.TryParse(txtCDBLCharge.Text, out doubleTryparse))
                    CDBLCharge = doubleTryparse;

                txtWithdrawAmount.Text = Convert.ToString(HCharge+CDBLCharge);
            }
            else
            {
                double CDBLCharge = 0;
                if (double.TryParse(txtCDBLCharge.Text, out doubleTryparse))
                    CDBLCharge = doubleTryparse;

                txtWithdrawAmount.Text = Convert.ToString(CDBLCharge);
            }            
        }

        private void txtCDBLCharge_TextChanged(object sender, EventArgs e)
        {
            double doubleTryparse;

            if (txtCDBLCharge.Text != "")
            {
                double HCharge = 0;
                if (double.TryParse(txtHouseCharge.Text, out doubleTryparse))
                    HCharge = doubleTryparse;

                double CDBLCharge = 0;
                if (double.TryParse(txtCDBLCharge.Text, out doubleTryparse))
                    CDBLCharge = doubleTryparse;

                txtWithdrawAmount.Text = Convert.ToString(HCharge + CDBLCharge);
            }
            else
            {
                double HCharge = 0;
                if (double.TryParse(txtHouseCharge.Text, out doubleTryparse))
                    HCharge = doubleTryparse;

                txtWithdrawAmount.Text = Convert.ToString(HCharge);
            }         
        }
    }
}
