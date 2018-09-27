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
using Reports;
using System.Globalization;
using BusinessAccessLayer.Constants;
 

namespace Reports
{
    public partial class frmIPOCustomerMoneyLedger : Form
    {
        public frmIPOCustomerMoneyLedger()
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
            IPOReportBAL customerInfoBAL = new IPOReportBAL();
            string newCust = string.Empty;
             
                if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
                {
                    _boID = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetIPOCustInfoByBOID(_boID);
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
                    custDateTable = customerInfoBAL.GetIPOCustInfoByCustCode(_custCode);
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

            IPOReportBAL moneyLedgerReportBal = new IPOReportBAL();
            DataTable dtCustmoneyLedger = new DataTable();
            DataTable dtCustBasicInfo = new DataTable();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            crIPOCustMoneyLedger crCustMoneyledger = new crIPOCustMoneyLedger();
            frmIPOReportViewer viewer = new frmIPOReportViewer();            
            dtCustmoneyLedger = moneyLedgerReportBal.GetIPOCustMoneyLedger(_custCode, _fromDate, _toDate);
            dtCustBasicInfo = moneyLedgerReportBal.GetIpoCustBasicInfo(_custCode);            
            crCustMoneyledger.SetDataSource(dtCustmoneyLedger);
            if (dtCustBasicInfo.Rows.Count > 0)
            {
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCustName"]).Text =
                    dtCustBasicInfo.Rows[0]["Cust_Name"].ToString();
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtCustCode"]).Text =
                    dtCustBasicInfo.Rows[0]["Cust_Code"].ToString();
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["Text6"]).Text =
                    "Balance Before " + dtFromDate.Value.ToString("dd-MMM-yy") + " :";
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtduration"]).Text =
                    "Duration : " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " +
                    dtToDate.Value.ToString("dd-MMM-yyyy");
                ((TextObject)crCustMoneyledger.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                    "IPO Customer Money Ledger";

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

        private void frm_IPO_CustomerMoneyLedger_Load(object sender, EventArgs e)
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
    }
}
