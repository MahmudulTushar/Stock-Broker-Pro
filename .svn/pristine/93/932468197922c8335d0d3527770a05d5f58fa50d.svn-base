using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;
using CrystalDecisions.CrystalReports.Engine;

namespace Reports
{
    public partial class frmAdminAlternativeReport : Form
    {

        private string _CommpanyName;
        private string _branchName;
        private int _branchId;
        private string _branchAddress;
        private string _branchContactNumber;
        private string _filterdColumnName;

        private string ReportName = string.Empty;
       
        
        public frmAdminAlternativeReport()
        {
            InitializeComponent();
        }

        private void frmAdminAlternativeReport_Load(object sender, EventArgs e)
        {
            dtp_PaymentReview_FromDate.Value = GlobalVariableBO._currentServerDate;
            dtp_PaymentReveiw_ToDate.Value = GlobalVariableBO._currentServerDate;
            dtp_TodayBalanceDate.Value = GlobalVariableBO._currentServerDate;
            chk_AccountView.Checked = true;
        }

        private void btn_TodayCustBalance_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation
                if (txt_Reason.Text == string.Empty)
                {
                    MessageBox.Show("You Should Writed Down The Reason");
                    return;
                }

                _branchId = GlobalVariableBO._branchId;
                Admin_Alternative_Report_Bal summeryReportBal = new Admin_Alternative_Report_Bal();
                DataTable dtCustToadysCustBal = new DataTable();
                crTodayCustBalance crTodayCustBal = new crTodayCustBalance();
                TodayCustBalanceViewer todayCustBalanceViewer = new TodayCustBalanceViewer();
                dtCustToadysCustBal = summeryReportBal.GetTodaysCustBalance(dtp_TodayBalanceDate.Value);

                _filterdColumnName = dtCustToadysCustBal.Columns[0].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtCustToadysCustBal, _filterdColumnName, ResourceName.Todays_Summery_Report_Cust_Balance);
                dtCustToadysCustBal = obj.GetRecordLevelFilteredData();

                crTodayCustBal.SetDataSource(dtCustToadysCustBal);

                GetCommonInfo();
                ReportName = "TodayCustomerTotalBalance";
                ///// Load Company Name
                ((TextObject)crTodayCustBal.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crTodayCustBal.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                ((TextObject)crTodayCustBal.ReportDefinition.Sections[2].ReportObjects["txtPrintDate"]).Text = dtp_TodayBalanceDate.Value.ToString("dd-MMM-yyyy");
                todayCustBalanceViewer.crvTodayCustBalanceReportViewer.ReportSource = crTodayCustBal;
                todayCustBalanceViewer.crvTodayCustBalanceReportViewer.DisplayGroupTree = false;
                todayCustBalanceViewer.Show();
                InsertLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_TodayCustMoneyBalance_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Reason.Text == string.Empty)
                {
                    MessageBox.Show("You Should Writed Down The Reason");
                    return;
                }
                
                _branchId = GlobalVariableBO._branchId;
                Admin_Alternative_Report_Bal summeryReportBal = new Admin_Alternative_Report_Bal();
                DataTable dtCustMoneybalance = new DataTable();
                crCustTodayMoneyBalance crCustMoneyBalance = new crCustTodayMoneyBalance();
                CustMoneyBalanceViewer custMoneyBalance = new CustMoneyBalanceViewer();
                //dtCustMoneybalance = summeryReportBal.GetCustMoneyBalance(GlobalVariableBO._currentServerDate);
                dtCustMoneybalance = summeryReportBal.GetCustMoneyBalance(dtp_TodayBalanceDate.Value);

                _filterdColumnName = dtCustMoneybalance.Columns[0].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtCustMoneybalance, _filterdColumnName, ResourceName.Todays_Summery_Report_Money_Balance);
                dtCustMoneybalance = obj.GetRecordLevelFilteredData();

                crCustMoneyBalance.SetDataSource(dtCustMoneybalance);


                ///// Load Company Name
                GetCommonInfo();
                ReportName = "TodayCustomerMoneyBalance";
                ((TextObject)crCustMoneyBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crCustMoneyBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                ((TextObject)crCustMoneyBalance.ReportDefinition.Sections[2].ReportObjects["txtPrintDate"]).Text = dtp_TodayBalanceDate.Value.ToString("dd-MMM-yyyy"); ;
                custMoneyBalance.crvCustMoneyBalanceReportViewer.ReportSource = crCustMoneyBalance;
                custMoneyBalance.Show();
                InsertLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_TodayCustShareBalance_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_Reason.Text == string.Empty)
                {
                    MessageBox.Show("You Should Writed Down The Reason");
                    return;
                }
                
                _branchId = GlobalVariableBO._branchId;
                Admin_Alternative_Report_Bal summeryReportBal = new Admin_Alternative_Report_Bal();
                DataTable dtCustsharebalance = new DataTable();
                crCustTodayShareBalance crCustShareBalance = new crCustTodayShareBalance();
                CustShareBalanceViewer custShareBalance = new CustShareBalanceViewer();
                dtCustsharebalance = summeryReportBal.GetCustShareBalance(dtp_TodayBalanceDate.Value);

                _filterdColumnName = dtCustsharebalance.Columns[0].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtCustsharebalance, _filterdColumnName, ResourceName.Todays_Summery_Report_Share_Balance);
                dtCustsharebalance = obj.GetRecordLevelFilteredData();

                crCustShareBalance.SetDataSource(dtCustsharebalance);

                GetCommonInfo();
                ReportName = "TodayCustomerShareBalance";
                ///// Load Company Name
                ((TextObject)crCustShareBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crCustShareBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                ((TextObject)crCustShareBalance.ReportDefinition.Sections[2].ReportObjects["txtPrintDate"]).Text = dtp_TodayBalanceDate.Value.ToString("dd-MMM-yyyy"); ;

                custShareBalance.crvCustShareBalanceReportViewer.ReportSource = crCustShareBalance;
                custShareBalance.Show();
                InsertLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_PaymentReveiw_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Reason.Text == string.Empty)
                {
                    MessageBox.Show("You Should Writed Down The Reason");
                    return;
                }
                
                Admin_Alternative_Report_Bal paymentBAL = new Admin_Alternative_Report_Bal();
                DataTable dtPaymentReview = new DataTable();
                cr_NewPaymentReview crPayment = new cr_NewPaymentReview();
                frmPaymenrReportViewer paymentViewer = new frmPaymenrReportViewer();
                LoadCommonInfo CmmInfo = new LoadCommonInfo();

                int issorted = 0;
                int isAccountsView = 0;

                if (chk_SortedByCustCode.Checked)
                    issorted = 1;
                else
                {
                    issorted = 0;
                }

                if (chk_AccountView.Checked)
                    isAccountsView = 1;
                else
                    isAccountsView = 0;


                dtPaymentReview = paymentBAL.GnerateNewPaymentReview(dtp_PaymentReview_FromDate.Value, dtp_PaymentReveiw_ToDate.Value, issorted, isAccountsView);

                _filterdColumnName = dtPaymentReview.Columns[1].ToString();
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtPaymentReview, _filterdColumnName, ResourceName.New_Payment_Review);
                dtPaymentReview = obj.GetRecordLevelFilteredData();

                crPayment.SetDataSource(dtPaymentReview);

                GetCommonInfo();
                ReportName = "PaymentReviewSorted";
                ///// Load Company Name
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = _branchName + "," + _branchAddress + ",Phone: " + _branchContactNumber;

                ////Load Date
                ((TextObject)crPayment.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text = dtp_PaymentReview_FromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtp_PaymentReveiw_ToDate.Value.ToString("dd-MMM-yyyy");

                paymentViewer.crvPaymentReview.DisplayGroupTree = false;
                paymentViewer.crvPaymentReview.ReportSource = crPayment;
                paymentViewer.Show();
                InsertLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void InsertLog()
        {
            try
            {
                Admin_Alternative_Report_Bal bal=new Admin_Alternative_Report_Bal();
                CommonBAL comBal=new CommonBAL();
                DateTime Today=comBal.GetCurrentServerDate();
                bal.InsertAdminLog(ReportName, txt_Reason.Text.Trim(),Today);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }

    }
}
