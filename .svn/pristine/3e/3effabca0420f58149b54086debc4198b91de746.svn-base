using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class TodaySummeryReport : Form
    {
        public static int _branchId;
        public TodaySummeryReport()
        {
            InitializeComponent();
        }

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private string _filterdColumnName;

        private void TodaySummeryReport_Load(object sender, EventArgs e)
        {
            CommonBAL comBal=new CommonBAL();
            lblTransDate.Text = comBal.GetCurrentServerDate().ToString("dd-MMM-yyyy");
        }

        private void btnCustShareBalance_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ShowCustShareBalanceReport();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
         }
      
        public  void ShowCustShareBalanceReport()
        {
            _branchId = GlobalVariableBO._branchId;
            SummeryReportBAL summeryReportBal = new SummeryReportBAL();
            DataTable dtCustsharebalance= new DataTable();
            crCustTodayShareBalance crCustShareBalance = new crCustTodayShareBalance();
            CustShareBalanceViewer custShareBalance = new CustShareBalanceViewer();
            dtCustsharebalance = summeryReportBal.GetCustShareBalance();

            _filterdColumnName = dtCustsharebalance.Columns[0].ToString();
            RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtCustsharebalance, _filterdColumnName, ResourceName.Todays_Summery_Report_Share_Balance);
            dtCustsharebalance = obj.GetRecordLevelFilteredData();

            crCustShareBalance.SetDataSource(dtCustsharebalance);

            GetCommonInfo();
                ///// Load Company Name
             ((TextObject)crCustShareBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
             ((TextObject)crCustShareBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
             ((TextObject)crCustShareBalance.ReportDefinition.Sections[2].ReportObjects["txtPrintDate"]).Text = GlobalVariableBO._currentServerDate.ToString("dd-MMM-yyyy");

              custShareBalance.crvCustShareBalanceReportViewer.ReportSource = crCustShareBalance;
              custShareBalance.Show();
        }

        private void btnCustMoneybalance_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ShowCustMoneyBalanceReport();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        public void ShowCustMoneyBalanceReport()
        {
            _branchId = GlobalVariableBO._branchId;
            SummeryReportBAL summeryReportBal = new SummeryReportBAL();
            DataTable dtCustMoneybalance = new DataTable();
            crCustTodayMoneyBalance crCustMoneyBalance = new crCustTodayMoneyBalance();
            CustMoneyBalanceViewer custMoneyBalance = new CustMoneyBalanceViewer();
            //dtCustMoneybalance = summeryReportBal.GetCustMoneyBalance(GlobalVariableBO._currentServerDate);
            dtCustMoneybalance = summeryReportBal.GetCustMoneyBalance();

            _filterdColumnName = dtCustMoneybalance.Columns[0].ToString();
            RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtCustMoneybalance, _filterdColumnName, ResourceName.Todays_Summery_Report_Money_Balance);
            dtCustMoneybalance = obj.GetRecordLevelFilteredData();

            crCustMoneyBalance.SetDataSource(dtCustMoneybalance);


            ///// Load Company Name
            GetCommonInfo();
            ((TextObject)crCustMoneyBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

            ///// Load Branch Name
            ((TextObject)crCustMoneyBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            ((TextObject)crCustMoneyBalance.ReportDefinition.Sections[2].ReportObjects["txtPrintDate"]).Text = GlobalVariableBO._currentServerDate.ToString("dd-MMM-yyyy");
            custMoneyBalance.crvCustMoneyBalanceReportViewer.ReportSource = crCustMoneyBalance;
            custMoneyBalance.Show();
        }

        private void btnTodaysTotalbalance_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ShowToadysCustBalanceReport();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void ShowToadysCustBalanceReport()
        {
            _branchId = GlobalVariableBO._branchId;
            SummeryReportBAL summeryReportBal = new SummeryReportBAL();
            DataTable dtCustToadysCustBal = new DataTable();
            crTodayCustBalance crTodayCustBal = new crTodayCustBalance();
            TodayCustBalanceViewer todayCustBalanceViewer = new TodayCustBalanceViewer();
            dtCustToadysCustBal = summeryReportBal.GetTodaysCustBalance();

            _filterdColumnName = dtCustToadysCustBal.Columns[0].ToString();
            RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(dtCustToadysCustBal, _filterdColumnName, ResourceName.Todays_Summery_Report_Cust_Balance);
            dtCustToadysCustBal = obj.GetRecordLevelFilteredData();

            crTodayCustBal.SetDataSource(dtCustToadysCustBal);

            GetCommonInfo();
            ///// Load Company Name
            ((TextObject)crTodayCustBal.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

            ///// Load Branch Name
            ((TextObject)crTodayCustBal.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            ((TextObject)crTodayCustBal.ReportDefinition.Sections[2].ReportObjects["txtPrintDate"]).Text = GlobalVariableBO._currentServerDate.ToString("dd-MMM-yyyy");
            todayCustBalanceViewer.crvTodayCustBalanceReportViewer.ReportSource = crTodayCustBal;
            todayCustBalanceViewer.crvTodayCustBalanceReportViewer.DisplayGroupTree = false;
            todayCustBalanceViewer.Show();
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
    }
}
