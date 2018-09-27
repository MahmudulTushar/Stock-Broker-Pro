using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;
using System.Globalization;
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class CustomerMoneyLedger : Form
    {
        public static string _boID = "";
        public static string _custCode ="";
        public static int _branchId;
        public static DateTime _fromDate;
        public static DateTime _toDate;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        string Interest_Service_Charge = "Interest Service Charge";
        string tempMenuPurpose = string.Empty;
        private string newCustomerMoneyBalance = "New Customer Money Ledger";
        public CustomerMoneyLedger()
        {
            InitializeComponent();
        }

        public CustomerMoneyLedger(string _menupurpose)
        {
            InitializeComponent();
            tempMenuPurpose = _menupurpose;
        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                if (txtSearchCustomer.Text.Trim() == "")
                {
                    MessageBox.Show("Atfirst Enter the customer code/BO ID.");
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
            DataTable NewcustDateTable = new DataTable();
            CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
            string newCust = string.Empty;
            if (tempMenuPurpose != newCustomerMoneyBalance)
            {
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
            else
            {

                NewcustDateTable = customerInfoBAL.IsExistNewCustomerCode(txtSearchCustomer.Text);
                if (NewcustDateTable.Rows.Count > 0)
                {
                    if (NewcustDateTable.Rows[0][1].ToString() != "") //Check BO_ID
                    {
                        MessageBox.Show("The Customer Already exist, The report Can't Shown here",
                                        "Existing Customer Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (NewcustDateTable.Rows[0][0].ToString() != "")
                    {
                        newCust = NewcustDateTable.Rows[0][0].ToString();
                        txtCustCode.Text = newCust;
                    }
                }
                else
                {
                    MessageBox.Show("Customer not exist",
                                "Customer Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void CustomerMoneyLedger_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {                                      
            if (txtCustCode.Text.Trim() != "")
            {
                ShowCustMoneyLedgerReport();
            }
            else
            {
                MessageBox.Show("Select a customer first.", "Warning!");
            }
        }

        public void ShowCustMoneyLedgerReport()
        {
            _branchId = GlobalVariableBO._branchId;

            _fromDate = Convert.ToDateTime(dtFromDate.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(dtToDate.Value.ToShortDateString());
            _custCode = txtCustCode.Text;

            MoneyLadgerReportBAL moneyLedgerReportBal = new MoneyLadgerReportBAL();
            DataTable dtCustmoneyLedger = new DataTable();
            DataTable dtCustBasicInfo = new DataTable();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();

            crNewCustMoneyLedger crNewCustMoneyledger = new crNewCustMoneyLedger();
            crCustMoneyLedger crCustMoneyledger = new crCustMoneyLedger();

            CustMoneyLedgerViewer moneyLedgerViewer = new CustMoneyLedgerViewer();
            frmReportViewer viewer=new frmReportViewer();

            RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Customer_Money_Ledger);

            if (tempMenuPurpose != newCustomerMoneyBalance)
            {
                string T_custCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Money_Ledger);
                dtCustBasicInfo = moneyLedgerReportBal.GetCustBasicInfo(T_custCode);
            }
            //else if (tempMenuPurpose == newCustomerMoneyBalance)
            //{
            //    dtCustBasicInfo = moneyLedgerReportBal.GetCustBasicInfo(_custCode);
            //}
            if (dtCustBasicInfo.Rows.Count > 0)
            {
                ((TextObject) crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCustName"]).Text =
                    dtCustBasicInfo.Rows[0]["Cust_Name"].ToString();
                ((TextObject) crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCustCode"]).Text =
                    dtCustBasicInfo.Rows[0]["Cust_Code"].ToString();
                ((TextObject) crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["Text6"]).Text =
                    "Balance Before " + dtFromDate.Value.ToString("dd-MMM-yy") + " :";
                ((TextObject) crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtduration"]).Text =
                    "Duration : " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " +
                    dtToDate.Value.ToString("dd-MMM-yyyy");
                ((TextObject) crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                    "Customer Money Ledger";

            }
            if (tempMenuPurpose == newCustomerMoneyBalance)
            {
                ((TextObject)crNewCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCustCode"]).Text = txtCustCode.Text;
                    
                ((TextObject)crNewCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                    "Customer Money Ledger";
            }
            if (tempMenuPurpose != newCustomerMoneyBalance)
            {
                string temp_custCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Money_Ledger);

                if (tempMenuPurpose == Interest_Service_Charge)
                {
                    dtCustmoneyLedger = moneyLedgerReportBal.GetInterestServiceCharge(temp_custCode, _fromDate, _toDate);
                }
                else
                {
                    dtCustmoneyLedger = moneyLedgerReportBal.GetCustMoneyLedger(temp_custCode, _fromDate, _toDate);
                }
            }
            else
            {
                dtCustmoneyLedger = moneyLedgerReportBal.GetNewCustMoneyLedger(_custCode, _fromDate, _toDate);
            }
            if (tempMenuPurpose == newCustomerMoneyBalance)
            {
                crNewCustMoneyledger.SetDataSource(dtCustmoneyLedger);

            }
            else
            {
                crCustMoneyledger.SetDataSource(dtCustmoneyLedger);

            }

            GetCommonInfo();
            if (tempMenuPurpose != newCustomerMoneyBalance)
            {
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                _CommpanyName;

                ///// Load Branch Name
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                moneyLedgerViewer.crvCustMoneyLedgerReportViewer.DisplayGroupTree = false;

            }
            else if (tempMenuPurpose == newCustomerMoneyBalance)
            {
                ((TextObject) crNewCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;

                ///// Load Branch Name
                ((TextObject) crNewCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            }
            if (tempMenuPurpose == newCustomerMoneyBalance)
            {
                viewer.crvReportViewer.ReportSource = crNewCustMoneyledger;
                viewer.Show();
            }
            else
            {
                moneyLedgerViewer.crvCustMoneyLedgerReportViewer.ReportSource = crCustMoneyledger;
                moneyLedgerViewer.Show();
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

    }
}
