using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;

namespace Reports
{
    public partial class CustomizedForDSE_ReviewCustbalance : Form
    {
        public static bool _possitive;
        public static bool _negetive;
        public static bool _negetiveToday;
        public static bool _negSpecific;
        public static bool _negTillSpecificDate;
        public static bool _posTillSpecificDate;
        public static bool _posSpecific;
        public static bool _negDateRange;
        public static int _branchId;
        public static DateTime _fromDate;
        public static DateTime _toDate;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public CustomizedForDSE_ReviewCustbalance()
        {
            InitializeComponent();
        }

        private void ReviewCustbalance_Load(object sender, EventArgs e)
        {
            CommonBAL commonbal=new CommonBAL();
            dtpFromDate.Value = commonbal.GetCompanyStartDate();
            dtpToDate.Value = commonbal.GetCurrentServerDate();
            dtpToDate.Enabled = false;
            dtpFromDate.Enabled = false;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ShowReviewReport();
            this.Cursor = Cursors.Arrow;
        }
       
        public void ShowReviewReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _possitive = rdoPossitiveBal.Checked;
            _negetive = rdoNegetive.Checked;
            _negSpecific = rdoNegetiveSpecificer.Checked;
            _negTillSpecificDate = rdoNegetiveSpecificerTillSpecificDate.Checked;
            _posTillSpecificDate = rdoPositiveSpecificerTillSpecificDate.Checked;
            _posSpecific = rdoPositiveSpecific.Checked;
            _negDateRange = rdoNegetiveDateRange.Checked;
            _fromDate = dtpFromDate.Value;
            _toDate = dtpToDate.Value;//dtpToDate.Value;
            
            int isSorted = 0;

            if (chbOrder.Checked)
                isSorted = 1;
            else
            {
                isSorted = 0;
            }

            CustReviewBalanceBAL custReviewBalanceBal = new CustReviewBalanceBAL();
            crCustPossitiveBalance crCustBalance = new crCustPossitiveBalance();
            CustPositiveBalViewer custRptViewer = new CustPositiveBalViewer();
            DataTable dtCustPositiveBalance = new DataTable();

            GetCommonInfo();

            if (_possitive)
            {
                dtCustPositiveBalance = custReviewBalanceBal.GetCustPositiveBalance(isSorted);
                crCustBalance.SetDataSource(dtCustPositiveBalance);
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportTitle"]).Text = "Customer With Postive Balance[Over All]";
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportDate"]).Text = "Printed On " + DateTime.Now.ToString("dd-MMM-yyyy");
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                custRptViewer.crvCustPositiveBalReportViewer.ReportSource = crCustBalance;
                custRptViewer.crvCustPositiveBalReportViewer.DisplayGroupTree = false;
                custRptViewer.Show();
            }
            else if (_negetive)
            {
                DataTable dtCustNegetiveBalance = new DataTable();
                dtCustNegetiveBalance = custReviewBalanceBal.GetCustNegetiveBalance(isSorted);
                crCustBalance.SetDataSource(dtCustNegetiveBalance);

                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportTitle"]).Text = "Customer With Negative Balance[Over All]";
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportDate"]).Text = "Printed On " + DateTime.Now.ToString("dd-MMM-yyyy");
                ((TextObject) crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =_CommpanyName;
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                custRptViewer.crvCustPositiveBalReportViewer.ReportSource = crCustBalance;
                custRptViewer.crvCustPositiveBalReportViewer.DisplayGroupTree = false;
                custRptViewer.Show();
            }

           /* else if (_negetiveToday)
            {
                crCustNegTodayBalance crCustNegTodaybalance = new crCustNegTodayBalance();
                CustNegTodayBalViewer negTodayBalViewer = new CustNegTodayBalViewer();
                DataTable dtCustNegTodayBalance = new DataTable();
                dtCustNegTodayBalance = custReviewBalanceBal.GetCustNegetiveBalanceToday();
                crCustNegTodaybalance.SetDataSource(dtCustNegTodayBalance);
                ///// Load Company Name
                ((TextObject)crCustNegTodaybalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crCustNegTodaybalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                negTodayBalViewer.crvCustNegTodayBalReportViewer.ReportSource = crCustNegTodaybalance;
                negTodayBalViewer.Show();

            }*/

            else if (_negSpecific)
            {
                
                DataTable dtCustNegTodayBalance = new DataTable();
                dtCustNegTodayBalance = custReviewBalanceBal.GetCustNegSpecificBalance(_toDate, isSorted);
                crCustBalance.SetDataSource(dtCustNegTodayBalance);

                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportTitle"]).Text = "Customer With Negative Balance On";
                ((TextObject) crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportDate"]).Text =_fromDate.ToString("dd-MMMM-yyyy");
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =_CommpanyName;
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                custRptViewer.crvCustPositiveBalReportViewer.ReportSource = crCustBalance;
                custRptViewer.crvCustPositiveBalReportViewer.DisplayGroupTree = false;
                custRptViewer.Show();

            }
            else if (_negTillSpecificDate)
            {
                DataTable dtCustNegTodayBalance = new DataTable();
                //dtCustNegTodayBalance = custReviewBalanceBal.CustomisedDSE_NewGetCustNegBalanceTillSpecificDate(_toDate, isSorted);
                dtCustNegTodayBalance = custReviewBalanceBal.GetCustNegBalanceTillSpecificDate(_toDate, isSorted);
                crCustBalance.SetDataSource(dtCustNegTodayBalance);

                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportTitle"]).Text = "Customer With Negative Balance Till Date";
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportDate"]).Text = _toDate.ToString("dd-MMMM-yyyy");
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                custRptViewer.crvCustPositiveBalReportViewer.ReportSource = crCustBalance;
                custRptViewer.crvCustPositiveBalReportViewer.DisplayGroupTree = false;
                custRptViewer.Show();
            }

            else if (_posTillSpecificDate)
            {
                DataTable dtCustNegTodayBalance = new DataTable();
                //dtCustNegTodayBalance = custReviewBalanceBal.CustomisedDSE_NewGetCustPosBalanceTillSpecificDate(_toDate, isSorted);
                dtCustNegTodayBalance = custReviewBalanceBal.GetCustPosBalanceTillSpecificDate(_toDate, isSorted);
                crCustBalance.SetDataSource(dtCustNegTodayBalance);

                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportTitle"]).Text = "Customer With Positive Balance Till Date";
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportDate"]).Text = _toDate.ToString("dd-MMMM-yyyy");
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                custRptViewer.crvCustPositiveBalReportViewer.ReportSource = crCustBalance;
                custRptViewer.crvCustPositiveBalReportViewer.DisplayGroupTree = false;
                custRptViewer.Show();
            }


            else if (_posSpecific)
            {
                
             
                DataTable dtCustPosBalance = new DataTable();

                dtCustPosBalance = custReviewBalanceBal.GetCustPosSpecificBalance(_toDate, isSorted);
                crCustBalance.SetDataSource(dtCustPosBalance);


                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportTitle"]).Text = "Customer With Postive Balance On";
                ((TextObject) crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportDate"]).Text =_fromDate.ToString("dd-MMMM-yyyy");
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                
                custRptViewer.crvCustPositiveBalReportViewer.ReportSource = crCustBalance;
                custRptViewer.crvCustPositiveBalReportViewer.DisplayGroupTree = false;
                custRptViewer.Show();

            }
            else if (_negDateRange)
            {

                cr_CustNegBalDateRange crNegBalDateRange = new cr_CustNegBalDateRange();
                DataTable dt = new DataTable();
                dt = custReviewBalanceBal.GetCustNegBalanceBetweenDateRang(_fromDate,_toDate,isSorted);

                crNegBalDateRange.SetDataSource(dt);

                //((TextObject)crCustBalance.ReportDefinition.Sections[2].ReportObjects["txtReportTitle"]).Text = "Customer With Negetive Balance Between Date Range";
                ((TextObject)crNegBalDateRange.ReportDefinition.Sections[2].ReportObjects["txtdateRange"]).Text = "From " + _fromDate.ToString("dd-MMMM-yyyy") + " To " + _toDate.ToString("dd-MMMM-yyyy");
                ((TextObject)crNegBalDateRange.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crNegBalDateRange.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

                custRptViewer.crvCustPositiveBalReportViewer.ReportSource = crNegBalDateRange;
                custRptViewer.crvCustPositiveBalReportViewer.DisplayGroupTree = false;
                custRptViewer.Show();

            }

            else
            {
                MessageBox.Show("Please Select the report category first.");
            }

        }

        private void rdoPositiveSpecific_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoNegetiveSpecificer_CheckedChanged(object sender, EventArgs e)
        {

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

        private void rdoPossitiveBal_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoNegetiveSpecificer.Checked || rdoPositiveSpecific.Checked)
            {
                chbOrder.Text = "Display Customer Code Oder BY Balence";
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = true;
            }

            else
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
        }

        private void rdoPositiveSpecificerTillSpecificDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNegetiveSpecificer.Checked || rdoPositiveSpecific.Checked)
            {
                chbOrder.Text = "Display Customer Code Oder BY Balence";
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = true;
            }
            else if (rdoNegetiveSpecificerTillSpecificDate.Checked || rdoPositiveSpecificerTillSpecificDate.Checked)
            {
                chbOrder.Text = "Display Customer Code Oder BY Balence";
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = true;
            }
            else
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
        }

        private void rdoNegetiveSpecificerTillSpecificDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNegetiveSpecificer.Checked || rdoPositiveSpecific.Checked)
            {
                chbOrder.Text = "Display Customer Code Oder BY Balence";
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = true;
            }
            else if (rdoNegetiveSpecificerTillSpecificDate.Checked || rdoPositiveSpecificerTillSpecificDate.Checked)
            {
                chbOrder.Text = "Display Customer Code Oder BY Balence";
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = true;
            }
            else
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNegetiveDateRange.Checked || rdoNegetiveDateRange.Checked)
            {
                chbOrder.Text = "Display Customer Code Oder BY Balence";
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }

            else
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }       
        }

        private void chbOrder_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gpPeriod_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
