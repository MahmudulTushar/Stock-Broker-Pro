using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using DataAccessLayer;
using Reports;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class Frm_Office_Expense : Form
    {
      //  private DbConnection dbcon= new DbConnection();

        public AccTransactionBAL AccTrans = new AccTransactionBAL();
        string MD_DMD = null;
        string Cash_Cheque = null;


        public Frm_Office_Expense()
        {
            InitializeComponent();
        }
        private void Starting()
        {
            radMD.Focus();
            txtAmt.Text = "";
            txtRemarks.Text = "";
            txtBranceh.Text = "";
            txtAccountNo.Text = "";
            txtRoutingNo.Text = "";
            txtChequeNo.Text = "";
            radMD.Checked = true;
            radCash.Checked = true;           

            GridLoad();
            VouchrNO();
            CashOrCheqe();
            //comboBrance_Lode();
            perspectiveOfCash();

            lblCount.Text = Convert.ToString(DataGrid.Rows.Count);
        }
        private void Frm_Office_Expense_Load(object sender, EventArgs e)
        {
            Starting();
        }
        

        
        string BAcc = "";
        string bID = "";
        private void cmbBankNameLoad()
        {
            string queryString = @"SELECT  BankName +'   '+ BankAcc AS BankName, BankAcc
                                    FROM   [BankBook].[dbo].[BankInfo]
                                    GROUP BY BankName +'   '+ BankAcc, BankAcc";
//            string queryString = @"SELECT [BankName]
//                                          ,[BankAcc]                                         
//                                      FROM [BankBook].[dbo].[BankInfo]";
            ExpenseTransactionBAL Ex_Trans_BankBook = new ExpenseTransactionBAL();
                                
           cmbBankName.DataSource = Ex_Trans_BankBook.getBankInforFromBankBook(queryString);            
           cmbBankName.DisplayMember = "BankName";
           cmbBankName.ValueMember = "BankAcc";
           cmbBankName.Text = "---Select Bank Name---";
           BAcc = cmbBankName.SelectedValue.ToString();

           DataTable dt = new DataTable();
           string queryString11 = @"SELECT  [BankId]
                                          ,[BankAcc]
                                          ,[RoutingNumber]
                                          ,[BankBranch]
                                      FROM [BankBook].[dbo].[BankInfo]
                                      where BankAcc='" + BAcc + "'";
           dt = Ex_Trans_BankBook.getBankInforFromBankBook(queryString11);
           bID = dt.Rows[0]["BankId"].ToString();
           txtAccountNo.Text = dt.Rows[0]["BankAcc"].ToString();
           txtRoutingNo.Text = dt.Rows[0]["RoutingNumber"].ToString();
           txtBranceh.Text = dt.Rows[0]["BankBranch"].ToString();
        }

        private void cmbBankName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BAcc = cmbBankName.SelectedValue.ToString();
            ExpenseTransactionBAL Ex_Trans_BankBook = new ExpenseTransactionBAL();
            DataTable dt = new DataTable();
            string queryString11 = @"SELECT  [BankId]
                                          ,[BankAcc]
                                          ,[RoutingNumber]
                                          ,[BankBranch]
                                      FROM [BankBook].[dbo].[BankInfo]
                                      where BankAcc='" + BAcc + "'";
            dt = Ex_Trans_BankBook.getBankInforFromBankBook(queryString11);
            bID = dt.Rows[0]["BankId"].ToString();
            txtAccountNo.Text = dt.Rows[0]["BankAcc"].ToString();
            txtRoutingNo.Text = dt.Rows[0]["RoutingNumber"].ToString();
            txtBranceh.Text = dt.Rows[0]["BankBranch"].ToString();
        }
        //private void comboBrance_Lode()
        //{
        //    string queryString = "SELECT Branch_ID, Branch_Name FROM  SBP_Broker_Branch ";
        //    DataTable dt_combo= AccTrans.ExQuery(queryString);           
        //    //Cmb_Location.DataSource = dt_combo;            
        //    //Cmb_Location.DisplayMember = "Branch_Name";
        //    //Cmb_Location.ValueMember = "Branch_ID";                      
        //}
        BO_Opening_InformationBAL BoDeleteBal = new BO_Opening_InformationBAL();

        private void GridLoad()
        {
            DateTime presentDate = txtDate.Value;
            string queryString = @"SELECT PDate as 'Date' 
	                                    ,VoucherNo as 'Voucher_No'
	                                    ,case when AccSub_Sub_Hade=2012003 then 'Md_Sir'
		                                     when AccSub_Sub_Hade=2012004 then 'DMD_Sir' else ''
		                                     end as 'Rcv_From'
	                                    ,DrAmt as 'Amount' 
	                                    ,Cash_Cheque as 'Trn_Type'
	                                    ,ChequeNO as 'Chq_No'
	                                    ,BankRoutingNo as 'Routing_No'
	                                    ,BankName as 'Bank'
	                                    ,Bank_Branch as 'Branch'
	                                    ,Remarks  
	                                    FROM  AccTransaction 
		                                    where CONVERT(Varchar(10),PDate,120)= '" + GlobalVariableBO._currentServerDate.ToString("yyyy-MM-dd") + @"' 
		                                    and AccSub_Hade= 2012000 
		                                    and TransactionType='Receive'
		                                    and Branch_ID=" +GlobalVariableBO._branchId+@"
                                    order by SL desc";

            DataGrid.DataSource = BoDeleteBal.Get_Data(queryString);
        }

        private void VouchrNO()
        {
            string queryString = " SELECT COUNT_BIG('VoucherNo +1') AS MaxV FROM  AccTransaction where  AccSub_Hade= 2012000";
            DataTable dt = BoDeleteBal.Get_Data(queryString);

            txtvoucher.Text = "RV_" + dt.Rows[0]["MaxV"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Starting();
        }

        private void radCash_CheckedChanged(object sender, EventArgs e)
        {
            CashOrCheqe();
        }
        private void perspectiveOfCash()
        { 
                cmbBankName.DataSource = null;
                cmbBankName.Enabled = false;
                txtBranceh.Enabled = false;
                txtRoutingNo.Enabled = false;
                txtAccountNo.Enabled = false;
                txtChequeNo.Enabled = false;   
                txtBranceh.Text = "";
                txtAccountNo.Text = "";
                txtRoutingNo.Text = "";
                txtChequeNo.Text = "";
                Cash_Cheque = "Cash";

        }

        private void CashOrCheqe()
        {
            if (radCash.Checked == true)
            {
                perspectiveOfCash();
            }
            else if (radCheque.Checked == true)
            {
                cmbBankNameLoad();
                txtBranceh.Text = "";
                txtAccountNo.Text = "";
                txtRoutingNo.Text = "";
                txtChequeNo.Text = "";

                cmbBankName.Enabled = true;
                txtBranceh.Enabled = false;
                txtRoutingNo.Enabled = false;
                txtAccountNo.Enabled = false;
                txtChequeNo.Enabled = true;
                Cash_Cheque = "Cheque";
            }
            else
            {

            }
        }

        private void radDMD_CheckedChanged(object sender, EventArgs e)
        {
            if (radDMD.Checked == true)
                MD_DMD = "DMD Sir";
        }

        private void radMD_CheckedChanged(object sender, EventArgs e)
        {
            if (radMD.Checked == true)
                MD_DMD = "MD Sir";
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

        private void bttSave_Click(object sender, EventArgs e)
        {
            if (radMD.Checked == true || radDMD.Checked == true)
            {
                if (radMD.Checked == true)
                {
                    MD_DMD = "2012003";
                }
                else if (radDMD.Checked == true)
                {
                    MD_DMD = "2012004";
                }
            }

            if(radCash.Checked==true)
            {
                Insert_CashExpense();               
            }
            else if(radCheque.Checked==true)
            {
                Insert_ChequeData();                             
            }
           
            //Starting();
        }
        private bool CashValidation()
        {
            double doubleTryparse;
            double amount = 0;
            if (double.TryParse(txtAmt.Text, out doubleTryparse))
                amount = doubleTryparse;

            if (amount == 0)
            {
                MessageBox.Show("Please write amount...");
                txtAmt.Focus();
               return true; 
            }

            else return false;
        }
        private bool chequeValidation()
        {
            double doubleTryparse;
            double amount = 0;
            if (double.TryParse(txtAmt.Text, out doubleTryparse))
                amount = doubleTryparse;

            if (amount == 0)
            {
                MessageBox.Show("Please write amount...");
                txtAmt.Focus();
                return true;
            }
            else if (radCheque.Checked == true && cmbBankName.Text == "---Select Bank Name---")
            {
                MessageBox.Show("Please Select Bank Name...");
                cmbBankName.Focus();
                return true;
            }
             else if (radCheque.Checked == true && txtChequeNo.Text == string.Empty)
            {
                MessageBox.Show("Please Write Cheque No...");
                txtChequeNo.Focus();
                return true;
            }
           
            else return false;
        }
        private void Insert_ChequeData()
        {
            if (chequeValidation())
                return;
           
            string AccSub_Hade = "2012000";
            string DrAmt = txtAmt.Text;
            string CrAmt = "0.00";
            string query = @" INSERT INTO [SBP_Database].[dbo].[AccTransaction]
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
                                           ,[EntyDate]
                                           ,[BankAccNo])
                                     VALUES
                                           ('" + txtvoucher.Text + @"'
                                           ,'" + txtDate.Text + @"'
                                           ,'" + AccSub_Hade + @"'
                                           ,'" + MD_DMD + @"'
                                           ,'" + DrAmt + @"'
                                           ,'" + CrAmt + @"'
                                           ,0.00
                                           ,'Receive'
                                           ,'" + Cash_Cheque + @"'
                                           ,'" + txtChequeNo.Text + @"'
                                           ,'" + txtRoutingNo.Text + @"'
                                           ,'" + cmbBankName.Text + @"'
                                           ,'" + txtBranceh.Text + @"'
                                           ,"+GlobalVariableBO._branchId+ @"
                                           ,'Dr'
                                           ,'1011001'
                                           ,'" + txtRemarks.Text + @"'
                                           ,'"+GlobalVariableBO._userName+@"'
                                           ,'"+GlobalVariableBO._currentServerDate+@"'
                                           ,'"+txtAccountNo.Text+"')";
            _dbConnection.ConnectDatabase();
            _dbConnection.ExecuteNonQuery(query);           
            _dbConnection.CloseDatabase();

            /////////////////////////Send Data To Bank Book///////////////////////////////////////

            ExpenseTransactionBAL expTranBal = new ExpenseTransactionBAL();
            DataTable Biddt = new DataTable();
            string Bid = @"select BankId from [BankBook].[dbo].[BankInfo] where BankAcc='" + txtAccountNo.Text + "'";
            Biddt = expTranBal.Get_Data(Bid);

            DataTable APdt = new DataTable();
            string AP = @"select AccountPurpose from [BankBook].[dbo].[BankInfo]  where BankAcc='" + txtAccountNo.Text + "'";
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
                                       ,[DebitAmount]
                                       ,[CrediteAmount]
                                       ,[TotalAmount]
                                       ,[Status]
                                       ,[Cheque_Status]
                                       ,[StatusforDelation]
                                       ,[CreateBy]
                                       ,[CreateDate]                                       
                                       ,[TransferMedia]
                                      )
                                 VALUES
                                       (
                                        '" + cID + @"'
                                       ,'" + gID + @"'
                                       ,'" + Biddt.Rows[0][0].ToString() + @"'
                                       ,0
                                       ,'" + txtAccountNo.Text + @"'
                                       ,'" + APdt.Rows[0][0].ToString() + @"'
                                       ,'" + txtDate.Value + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,'Deposit for Petty Cash'
                                       ,'Debit'
                                       ,'" + txtChequeNo.Text + @"'
                                        ,'" + txtvoucher.Text + @"'
                                       ,'" + Cash_Cheque + @"'
                                       ,'" + DrAmt + @"'
                                       ,'" + CrAmt + @"'
                                       ,'"+DrAmt+@"'
                                       ,'Approved'
                                       ,'ChequeUnclear'
                                       ,'A'
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'                                       
                                       ,'Deposit'
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
                                       ,[DebitAmount]
                                       ,[CrediteAmount]
                                       ,[TotalAmount]
                                       ,[Status]
                                       ,[Cheque_Status]
                                       ,[StatusforDelation]
                                       ,[CreateBy]
                                       ,[CreateDate]                                       
                                       ,[TransferMedia]
                                      )
                                 VALUES
                                       (
                                        '" + tID + @"'
                                       ,'" + cID + @"'
                                       ,'" + gID + @"'
                                       ,'" + Biddt.Rows[0][0].ToString() + @"'
                                       ,0
                                       ,'" + txtAccountNo.Text + @"'
                                       ,'" + APdt.Rows[0][0].ToString() + @"'
                                       ,'" + txtDate.Value + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'
                                       ,'Deposit for Petty Cash'
                                       ,'Debit'
                                       ,'" + txtChequeNo.Text + @"'
                                        ,'" + txtvoucher.Text + @"'
                                       ,'" + Cash_Cheque + @"'
                                       ,'" + DrAmt + @"'
                                       ,'" + CrAmt + @"'
                                       ,'" + DrAmt + @"'
                                       ,'Approved'
                                       ,'ChequeUnclear'
                                       ,'A'
                                       ,'" + GlobalVariableBO._userName + @"'
                                       ,'" + Convert.ToDateTime(System.DateTime.Now) + @"'                                       
                                       ,'Deposit'
                                        )";
            ExpenseTransactionBAL Ex_Trans_BankBook = new ExpenseTransactionBAL();
            Ex_Trans_BankBook.SaveDt_CityBankBook(saveCityBankBook);
            Ex_Trans_BankBook.SaveDt_CityBankBook(saveApprovedDataTable);

            MessageBox.Show("Deposit Information Saved Successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Starting();
        }
        private DbConnection _dbConnection =new DbConnection ();
     
        private void Insert_CashExpense()
        {
            if(CashValidation())
                return;
            try
            {
                string AccSub_Hade = "2012000"; 
                string DrAmt =txtAmt.Text;
                string CrAmt =  "0.00";
                string InsertQ = @"INSERT INTO AccTransaction
                                                    (
                                                    VoucherNo,
                                                    PDate, 
                                                    AccSub_Sub_Hade, 
                                                    AccSub_Hade, 
                                                    DrAmt,
                                                    CrAmt,
                                                    Balance,
                                                    TransactionType,
                                                    Cash_Cheque,
                                                    ChequeNO,
                                                    BankRoutingNo,
                                                    BankName,
                                                    Bank_Branch,
                                                    Remarks,
                                                    Branch_ID,
                                                    Dr_Cr_Acc,
                                                    DrCr_SubHad_code,
                                                    EntyBy,
                                                    EntyDate
                                                   ,BankAccNo
                                                    ) 
                                             VALUES (
                                                    '" + txtvoucher.Text + @"',
                                                    '" + txtDate.Text + @"',
                                                    '" + MD_DMD + @"',
                                                    '" + AccSub_Hade + @"', 
                                                    '" + DrAmt + @"',
                                                    '" + CrAmt + @"',
                                                    '0.00',
                                                    'Receive',
                                                    '" + Cash_Cheque + @"',
                                                    '" + txtChequeNo.Text + @"',
                                                    '" + txtRoutingNo.Text + @"',
                                                    '" + cmbBankName.Text + @"',
                                                    '" + txtBranceh.Text + @"',
                                                    '" + txtRemarks.Text + @"',
                                                    '" + GlobalVariableBO._branchId + @"',
                                                    'Dr',
                                                    '1011001',
                                                    '" +GlobalVariableBO._userName+@"',
                                                    '"+GlobalVariableBO._currentServerDate+@"',
                                                    '"+txtAccountNo.Text+@"'
                                                     )";

                _dbConnection.ConnectDatabase();
                _dbConnection.ExecuteNonQuery(InsertQ);               
                _dbConnection.CloseDatabase();
                MessageBox.Show("Deposit Information Saved Successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Starting();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Insert Error :" + ex);
            }
        }

        private void radCheque_CheckedChanged(object sender, EventArgs e)
        {
            CashOrCheqe();
        }

        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RetrapData();
        }

        private void RetrapData()
        {
            if (DataGrid.Rows.Count > 0)
            {
                txtvoucher.Text = DataGrid.CurrentRow.Cells["VoucherNo"].Value.ToString();
              
                if(  DataGrid.CurrentRow.Cells["PDate"].Value.ToString()!="" )
                txtDate.Value = Convert.ToDateTime(DataGrid.CurrentRow.Cells["PDate"].Value.ToString());

                MD_DMD = DataGrid.CurrentRow.Cells["AccSub_Sub_Hade"].Value.ToString();

                if (MD_DMD == "DMD Sir")
                    radDMD.Checked = true;

                if (MD_DMD == "MD Sir")
                    radMD.Checked = true;

                Cash_Cheque = DataGrid.CurrentRow.Cells["TransType"].Value.ToString();

                if (Cash_Cheque == "Cash")
                    radCash.Checked = true;

                if (Cash_Cheque == "Cheque")
                    radCheque.Checked = true;

                txtAmt.Text = DataGrid.CurrentRow.Cells["Amount"].Value.ToString();
                txtBranceh.Text = DataGrid.CurrentRow.Cells["Bank_Branch"].Value.ToString();
                txtRoutingNo.Text = DataGrid.CurrentRow.Cells["BankRoutingNo"].Value.ToString();
                txtChequeNo.Text = DataGrid.CurrentRow.Cells["ChequeNO"].Value.ToString();
                txtRemarks.Text = DataGrid.CurrentRow.Cells["Remarks"].Value.ToString();
            }
        }

        private void bttReport_Click(object sender, EventArgs e)
        {
            ////System.IO.Path.GetDirectory(MD_DMD_Expense.rpt);
            //string CryRptFormula=null;
            //Frm_CryRpt_Display CryRpt = new Frm_CryRpt_Display();
            //CryRpt.ShowDialog("MD_DMD_Expense.rpt", CryRptFormula);
        }

        private void radCheque_CheckedChanged_1(object sender, EventArgs e)
        {

            CashOrCheqe();
        }

        private void dtpSearchDateWise_ValueChanged(object sender, EventArgs e)
        {
            //BO_Opening_InformationBAL BoOpInfoBAL = new BO_Opening_InformationBAL();
            ExpenseTransactionBAL etb = new ExpenseTransactionBAL();
            string searchDate = Convert.ToString(dtpSearchDateWise.Value.ToString("yyyy-MM-dd"));
            DataGrid.DataSource = etb.SearchDataDateWise(searchDate);
            lblCount.Text = Convert.ToString(DataGrid.Rows.Count);
        }

        private void txtAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                if (radCash.Checked = true)
                {
                    bttSave.Focus();
                }
                else
                {
                    cmbBankName.Focus();
                }                
            }
        }
    }
}

