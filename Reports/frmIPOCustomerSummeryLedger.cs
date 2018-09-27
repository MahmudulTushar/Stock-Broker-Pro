using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;

namespace Reports
{
    public partial class frmIPOCustomerSummeryLedger : Form
    {
        public frmIPOCustomerSummeryLedger()
        {
            InitializeComponent();
        }
        public static string _boID = "";
        public static string _custCode = "";
        public static int _branchId;
        public static DateTime _fromDate;
        public static DateTime _toDate;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;


        private void btnReport_Click(object sender, EventArgs e)
        {
            ShowCustMoneyLedgerReport();
        }
        private void LoadCustInfo()
        {
            DataTable custDateTable = new DataTable();
            IPOCustomerSummeryLedgerBAL customerInfoBAL = new IPOCustomerSummeryLedgerBAL();
            if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
            {
                _boID = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.IPOGetCustInfoByBOID(_boID);
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
                custDateTable = customerInfoBAL.IPOGetCustomerCode(_custCode);
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
        public void ShowCustMoneyLedgerReport()
        {
            _branchId = GlobalVariableBO._branchId;

            _fromDate = Convert.ToDateTime(dtFromDate.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(dtToDate.Value.ToShortDateString());
            _custCode = txtCustCode.Text;

            IPOCustomerSummeryLedgerBAL moneyLedgerReportBal = new IPOCustomerSummeryLedgerBAL();
            DataTable dtCustmoneyLedger = new DataTable();
            DataTable dtCustBasicInfo = new DataTable();
            DataTable dtopenClose = new DataTable();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            crIPOCustomerSummery crCustMoneyledger = new crIPOCustomerSummery();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            dtCustmoneyLedger = moneyLedgerReportBal.GetIPOCustSummeryLedger(_custCode, _fromDate, _toDate);
            dtCustBasicInfo = moneyLedgerReportBal.GetIpoCustSummaryBasicInfo(_custCode);
            dtopenClose = moneyLedgerReportBal.IpoOpenCloseWithdrawDepost(_custCode,_fromDate,_toDate);
            crCustMoneyledger.SetDataSource(dtCustmoneyLedger);
            if (dtopenClose.Rows.Count > 0)
            {
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtopeningBalance"]).Text = String.Format("{0:0.##}", dtopenClose.Rows[0]["Open_Balance"]);
                //((TextObject)crCustMoneyledger.ReportDefinition.Sections[4].ReportObjects["txtCloseBalance"]).Text = String.Format("{0:0.##}", dtopenClose.Rows[0]["Close_Balance"]);
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[4].ReportObjects["txtDepost"]).Text = String.Format("{0:0.##}", dtopenClose.Rows[0]["total_Deposit"]);
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[4].ReportObjects["txtWithdraw"]).Text = String.Format("{0:0.##}", dtopenClose.Rows[0]["Toatal_Withdraw"]);

            }
            if (dtCustBasicInfo.Rows.Count > 0)
            {
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCustName"]).Text =
                    dtCustBasicInfo.Rows[0]["Cust_Name"].ToString();
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCustCode"]).Text =
                    dtCustBasicInfo.Rows[0]["Cust_Code"].ToString();
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtboid"]).Text =
                    dtCustBasicInfo.Rows[0]["BO_ID"].ToString();                
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtduration"]).Text =
                    "Duration : " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " +
                    dtToDate.Value.ToString("dd-MMM-yyyy");
                //((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                //    "IPO Customer Money Ledger";

            }
            GetCommonInfo();
            ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                _CommpanyName;
            ///// Load Branch Name
            ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            viewer.crystalReportViewer1.ReportSource = crCustMoneyledger;

            viewer.Show();
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

        private void IpoCustomerSummeryLedger_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
        }
    }
}
