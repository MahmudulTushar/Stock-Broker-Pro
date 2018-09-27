using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;

namespace Reports
{
    public partial class CustInfoReport : Form
    {
        public CustInfoReport()
        {
            InitializeComponent();
        }
        private static int _branchId;
        private static string _groupName;
        private static DateTime _startDate;
        private static DateTime _endDate;
        //private bool _isstarted;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

       
        private void CustInfoReport_Load(object sender, EventArgs e)
        {
            ShowReportCategory();
            ddlReportCatagory.SelectedIndex = 0;
        }

        private void ShowReportCategory()
        {
            ddlReportCatagory.Text = "All";
            ddlReportCatagory.Items.Add("All");
            ddlReportCatagory.Items.Add("Active");
            ddlReportCatagory.Items.Add("Inactive");
            ddlReportCatagory.Items.Add("Group");
            ShowEnable();
        }

        private void ShowEnable()
        {
            if (ddlReportCatagory.Text == "Group")
            {
                ddlCustGroupName.Enabled = true;
                ShowGroupName();
            }

            if (ddlReportCatagory.Text == "All" || ddlReportCatagory.Text == "Active" || ddlReportCatagory.Text == "Inactive")
            {

                ddlCustGroupName.Enabled = false;

            }
        }

        private void ShowGroupName()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Cust_Group");

            ddlCustGroupName.DataSource = dtData;
            ddlCustGroupName.DisplayMember = "Cust_Group";
            if (ddlCustGroupName.HasChildren)
                ddlCustGroupName.SelectedIndex = 0;
        }

        private void ddlReportCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowEnable();
        }
        private void ShowReport(object data)
        {
            _branchId = GlobalVariableBO._branchId;
            string ReportPattern = data.ToString();
            LoadRPTCustomerInfo loadcustInfo = new LoadRPTCustomerInfo();
            DataTable dtloaddata = loadcustInfo.LoadCustomerInfo(ReportPattern, _startDate, _endDate);

            crCustomerInfo crCustInfo = new crCustomerInfo();
            crCustInfo.SetDataSource(dtloaddata);
            

            GetCommonInfo();
            ///// Load Company Name
            ((TextObject)crCustInfo.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =_CommpanyName;

            ///// Load Branch Name
            ((TextObject)crCustInfo.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;


            ///// Name of Report Category
           if (_groupName == null)
           {
               ((TextObject)crCustInfo.ReportDefinition.Sections[2].ReportObjects["txtReportCategory"]).Text = "Report Category: " + ReportPattern + " Customer";
           }

           if (_groupName != null)
           {
               ((TextObject)crCustInfo.ReportDefinition.Sections[2].ReportObjects["txtReportCategory"]).Text = "Report Category: " + ReportPattern + " " + _groupName;
               _groupName = null;
           }

            ////// Show Customer Duration
           if (_startDate != null && _endDate != null)
           {
               ((TextObject)crCustInfo.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Duration : " + _startDate.ToString("dd-MMM-yyyy") + " To " + _endDate.ToString("dd-MMM-yyyy");

           }
            frmViewCustomerInfo frmviewcustinfo = new frmViewCustomerInfo();
            frmviewcustinfo.crvCustomerInfo.ReportSource = crCustInfo;
            frmviewcustinfo.Show();
        }

        private void btnReportView_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GenerateReport();
            this.Cursor = Cursors.Arrow;
        }
        private void GenerateReport()
        {
            SetCustomerDuration();
            if (!ddlCustGroupName.Enabled)
            {
                ShowReport(ddlReportCatagory.Text);
            }

            if (ddlCustGroupName.Enabled)
            {
                _groupName = "Group";
                ShowReport(ddlCustGroupName.Text);
            }
        }

        private void SetCustomerDuration()
        {
            _startDate = dtpFromDate.Value;
            _endDate = dtpToDate.Value;
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
