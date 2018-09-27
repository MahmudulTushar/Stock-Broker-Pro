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
using BusinessAccessLayer.Constants;
using CrystalDecisions.CrystalReports.Engine;

namespace Reports
{
    public partial class FrmAccruedBalance : Form
    {
        public FrmAccruedBalance()
        {
            InitializeComponent();
        }

        private void FrmAccruedBalance_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
            rbIndividual.Checked = true;
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

        string Interest_Service_Charge = "Interest Service Charge";
        string tempMenuPurpose = string.Empty;
        private string newCustomerMoneyBalance = "New Customer Money Ledger";

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
        private bool ValidationCheck()
        {
            if (rbIndividual.Checked == true && txtCustCode.Text == string.Empty)
            {
                MessageBox.Show("Please Select Customer First...", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchCustomer.Focus();
                return true;
            }
            else return false;
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (ValidationCheck())
                return;

            ShowCustMoneyLedgerReport();
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

        public void ShowCustMoneyLedgerReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _fromDate = Convert.ToDateTime(dtFromDate.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(dtToDate.Value.ToShortDateString());
            _custCode = txtCustCode.Text;

            MoneyLadgerReportBAL moneyLedgerReportBal = new MoneyLadgerReportBAL();
            DataTable dtAccruedBalance = new DataTable();
            DataTable dtCustBasicInfo = new DataTable();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();

            crAccruedBalance rpt = new crAccruedBalance();
            frmReportViewer viewer = new frmReportViewer();

            RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Customer_Money_Ledger);

                string T_custCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Money_Ledger);
                dtCustBasicInfo = moneyLedgerReportBal.GetCustBasicInfo(T_custCode);
           
                if (dtCustBasicInfo.Rows.Count > 0)
                {
                    ((TextObject)rpt .ReportDefinition.Sections[2].ReportObjects["txtCustName"]).Text =
                       "Cust. Name: "+ dtCustBasicInfo.Rows[0]["Cust_Name"].ToString();
                    ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtCustCode"]).Text =
                        "Cust. Code:  " + dtCustBasicInfo.Rows[0]["Cust_Code"].ToString();
                    ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtBalanceBefore"]).Text =
                        "Balance Before :  " + dtFromDate.Value.ToString("dd-MMM-yy");
                    ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtduration"]).Text =
                        "Duration :  " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " +
                        dtToDate.Value.ToString("dd-MMM-yyyy");
                    ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                        "Accrued Balance Report";
                }
                else
                {
                    ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtduration"]).Text =
                          "Duration :  " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " +
                          dtToDate.Value.ToString("dd-MMM-yyyy");
                    ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                        "Accrued Balance Report";
                }
                    dtAccruedBalance = moneyLedgerReportBal.GetAccruedBalanceData(T_custCode, _fromDate, _toDate);             
                    rpt.SetDataSource(dtAccruedBalance);

            GetCommonInfo();
                ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name: " + _branchName + "," + _branchAddress + ". Phone: " + _branchContactNumber;
                viewer.crvReportViewer.ReportSource = rpt;
                viewer.Show();
        }

        private void rbIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIndividual.Checked == true)
            {

            }
            else 
            {
                txtSearchCustomer.Text = string.Empty;
                txtCustCode.Text = string.Empty;
                txtAccountHolderName.Text = string.Empty;
                txtAccountHolderBOId.Text = string.Empty;
            }
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchCustomer.Text.Trim()))
            {
                rbIndividual.Checked = true;
            }
        }
    }
}
