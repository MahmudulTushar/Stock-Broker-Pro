using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Reports;

using CrystalDecisions.CrystalReports.Engine;
using BusinessAccessLayer.BAL;
using DataAccessLayer;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class Frm_Current_Cash_Rpt : Form
    {
        //Created By : Nurul Huda Nabin
        //Updated By : Nazmul Hossain

        private DbConnection _dbConnection;
        BO_Opening_InformationBAL BoOpInfoBAL = new BO_Opening_InformationBAL();
        cr_CashInHandReport crCashReport = new cr_CashInHandReport();

        public static DateTime _fromDate;
        public static DateTime _toDate;
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public Frm_Current_Cash_Rpt()
        {
            InitializeComponent();
        }

        private void Frm_Current_Cash_Rpt_Load(object sender, EventArgs e)
        {
          
        }

        private void Btt_ViewRpt_Click(object sender, EventArgs e)
        {
            ShowCashInHandReport();

            //Work Of Mr. Nabin.
            //Frm_CryRpt_Display CryRpt_Display = new Frm_CryRpt_Display();
            //Rpt_CurrentCashInHand rptCurrentCash = new Rpt_CurrentCashInHand();

            //insertdata();
            //DateTime _date;
            //string _FormDate = "";
            //string _ToDate = "";
            //_date = DateTime.Parse(FormDate.Text);
            //_FormDate = _date.ToString("yyyy-MM-dd");

            //_date = DateTime.Parse(ToDate.Text);
            //_ToDate = _date.ToString("yyyy-MM-dd");


            //object RptObj = rptCurrentCash;
            //string RptFormula = "";
            //RptFormula = "{AccTransaction.PDate}>='" + _FormDate + "'and{AccTransaction.PDate}<='" + _ToDate + "'";

            //CryRpt_Display.ShowDialog(rptCurrentCash, RptFormula);
        }
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
        private void ShowCashInHandReport()
        {
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            _fromDate = Convert.ToDateTime(FormDate.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(ToDate.Value.ToShortDateString());

            DataTable dtBoInfo = new DataTable();
            dtBoInfo = BoOpInfoBAL.getCashInHandInfo(_fromDate, _toDate);
            crCashReport.SetDataSource(dtBoInfo);
           
            GetCommonInfo();

            ((TextObject)crCashReport.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
               _CommpanyName;
            ((TextObject)crCashReport.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            ((TextObject)crCashReport.ReportDefinition.Sections[2].ReportObjects["txtduration"]).Text =
                    "Duration : " + FormDate.Value.ToString("dd-MMM-yyyy") + " To " +
                    ToDate.Value.ToString("dd-MMM-yyyy");


            viewer.crystalReportViewer1.ReportSource = crCashReport;
            viewer.Show();
        }
//        public void insertdata()
//        {                                                // 1.4012000 (Expense Head Code)  2.4012002 (Expense Ledger Code)
//            try
//            {
//                string sql = @" DELETE FROM AccTransaction
//                               Where  AccSub_Hade= 4012000 and AccSub_Sub_Hade=4012002 
//                                 
//                                 INSERT 
//                                    INTO     AccTransaction
//                                                    (
//                                                      PDate
//                                                     ,VoucherNo
//                                                     ,AccSub_Hade
//                                                     ,AccSub_Sub_Hade
//                                                     ,DrAmt
//                                                     ,CrAmt
//                                                     ,TransactionType
//                                                     ,Dr_Cr_Acc
//                                                     ,DrCr_SubHad_code
//                                                     ,Remarks
//                                                     ,Branch_ID
//                                                     ,EntyBy
//                                                     ,EntyDate
//                                                  )
//
//		                                     SELECT    
//                                                   Payment_Date AS PDate,
//		                                           Voucher_ID AS VoucherNo,
//			                                       4012000 AS AccSub_Hade, 
//		                                           4012002 AS AccSub_Sub_Hade,
//		                                           '0.00' as CrAmt
//		                                           ,Amount as DrAmt 
//		                                           ,'Payment'
//		                                           ,'Cr' AS Dr_Cr_Acc
//		                                           ,1011001 AS DrCr_SubHad_code
//		                                           ,Remarks
//		                                           ,Branch_ID AS Project_Branch
//		                                           ,Entry_By AS EntyBy
//		                                           ,Entry_Date_Time AS EntyDate  
//                                    			        
//                                             FROM  SBP_Expense_Transaction
//
//                                        WHERE 
//		                                    (Approval_Status = 1) 
//		                                    		                                 
//                          ";

//              //  AccTrans.ExNonQuery(sql);

//                _dbConnection.ConnectDatabase();
//                _dbConnection.ExecuteNonQuery(sql);
//                //_dbConnection.ExecuteNonQuery(InsertQ);
//                _dbConnection.CloseDatabase();

//            }
//            catch(DataException ex)
//            {
//                MessageBox.Show("Expence Data Prossing Error..");
//            }
//        }
    }
}
