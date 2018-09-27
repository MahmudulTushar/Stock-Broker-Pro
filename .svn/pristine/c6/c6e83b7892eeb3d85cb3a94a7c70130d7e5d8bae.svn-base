using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using CrystalDecisions.CrystalReports.Engine;

namespace Reports
{
    public partial class frmIPOCustomerSummaryBalanceLedger : Form
    {
        public frmIPOCustomerSummaryBalanceLedger()
        {
            InitializeComponent();
        }

        public static string _boID = "";
        public static string _custCode = "";
        public static int _branchId;
        public static DateTime _fromDate;
        public static DateTime _toDate;
        public static bool _shareSummery;
        public static bool _Details;
        public static bool _Last30Day;
        public static bool _SpecificPeriod;
        public static DateTime _maxPriceDate;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        private void btnReport_Click(object sender, EventArgs e)
        {
                loadShareBalanceReport();
        }

        private void loadShareBalanceReport()
        {

            IPOReportBAL bal = new IPOReportBAL();
            crIPOCustomerSummaryBalanceLedger objrpt = new crIPOCustomerSummaryBalanceLedger();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            DataTable dt = new DataTable();
            _fromDate = dtFromDate.Value.Date;
            _toDate = dtToDate.Value.Date;
            dt = bal.GetAllCustomerIPOBalance(_fromDate.Date, _toDate.Date);
            objrpt.SetDataSource(dt);
            GetCommonInfo();
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = _branchAddress;
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtReportName"]).Text = "All Account Balance Summary Information";
            //((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["Todate"]).Text = _toDate.Date.ToString();
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["FromDate"]).Text=_fromDate.Date.ToString();
            viewer.crystalReportViewer1.ReportSource = objrpt;
            viewer.Show();
        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                if (txtSearchCustomer.Text.Trim() == "")
                {
                    MessageBox.Show("Atfirst Enter the Customer Code/BO Id.");
                }
                else
                {
                    LoadCustInfo();
                }
            }
        }
        
        private void LoadCustInfo()
        {
            DataTable custDateTable = new DataTable();
            CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
            if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
            {
                _boID = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);
                if (custDateTable.Rows.Count > 0)
                {
                    int _custCode = Convert.ToInt32(custDateTable.Rows[0][0].ToString());
                    txtCustCode.Text = custDateTable.Rows[0][0].ToString();
                    txtAccountHolderName.Text = custDateTable.Rows[0][1].ToString();
                    txtAccountHolderBOId.Text = custDateTable.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("No customer found.");
                }
            }
            else
            {
                _custCode = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                if (custDateTable.Rows.Count > 0)
                {
                    txtCustCode.Text = custDateTable.Rows[0][0].ToString();
                    txtAccountHolderName.Text = custDateTable.Rows[0][1].ToString();
                    txtAccountHolderBOId.Text = custDateTable.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("No customer found.");
                }
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
            catch (Exception)
            {

                throw;
            }
        }

        private void frmIPOCustomerSummaryBalanceLedger_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
        }
    }
}
