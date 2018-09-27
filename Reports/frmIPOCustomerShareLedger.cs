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
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class frmIPOCustomerShareLedger : Form
    {
        public frmIPOCustomerShareLedger()
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

        private void FrmIPOCustomerShareLedger_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
            RdoParentChildGroupingInfo.Checked = true;
        }
        private void ShowPortFolioReportInvestorWise()
        {
            crIPOCustomerShareLedger objcr_DSE_22_1Report = new crIPOCustomerShareLedger();
            DataTable dtProtofolioReportInvestorwise = new DataTable();
            DESReportBal objPortfolioBal = new DESReportBal();
            IPOShareLedgerPortfolioBAL objBAL = new IPOShareLedgerPortfolioBAL();
            CustShareSummeryViewer objfrm_DSE_22_1_Report = new CustShareSummeryViewer();
            string deposit = "0.00";
            string withdraw = "0.00";
            string balance = "0.00";



            try
            {
                ShareLedgerBAL shareLedgerBal = new ShareLedgerBAL();
                DataTable dtCustSummerybasic = new DataTable();

                //RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Customer_Share_Ledger_Share_Portfolio_Summery);
                //string T_Custcode = obj.FilterCustCode(_custCode, ResourceName.Customer_Share_Ledger_Share_Portfolio_Summery);
                //if (T_Custcode == "")
                //{
                //    MessageBox.Show("You are restricted");
                //    return;
                //}
                dtCustSummerybasic = shareLedgerBal.GetCustomerSummerBasicInfo(_custCode, dtToDate.Value);

                if (dtCustSummerybasic.Rows.Count != 0)
                {
                    deposit = Convert.ToDouble(dtCustSummerybasic.Rows[0]["Dep_Amount"]).ToString("N");
                    withdraw = Convert.ToDouble(dtCustSummerybasic.Rows[0]["Withdraw_Amount"]).ToString("N");
                    balance = Convert.ToDouble(dtCustSummerybasic.Rows[0]["Head_Balance"]).ToString("N");
                }

                //string temp_custCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Share_Ledger_Share_Portfolio_Summery);
                //dtProtofolioReportInvestorwise = objPortfolioBal.Get_DSE_22_1_Report(_custCode, dtToDate.Value);
                dtProtofolioReportInvestorwise = objBAL.GetShareLedegerPortfolio(_custCode, dtToDate.Value);
                objcr_DSE_22_1Report.SetDataSource(dtProtofolioReportInvestorwise);

                GetCommonInfo();
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtBranchInfo"]).Text =
                    _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtCustCode"]).Text =
                    txtCustCode.Text;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtBOID"]).Text =
                    txtAccountHolderBOId.Text;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtCustName"]).Text =
                    txtAccountHolderName.Text;

                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtDeposit"]).Text =
                    deposit;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtWithdraw"]).Text =
                    withdraw;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtBalance"]).Text =
                    balance;

                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["asOnDate"]).Text =
                    dtToDate.Value.ToString("dd/MMM/yyyy");

                objfrm_DSE_22_1_Report.crvShareSummeryReportViewer.ReportSource = objcr_DSE_22_1Report;
                objfrm_DSE_22_1_Report.crvShareSummeryReportViewer.DisplayGroupTree = false;
                objfrm_DSE_22_1_Report.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Portfolio Report Investor Wise", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void ParentChildGroupReport()
        {
            try
            {
                ParentAndChildBAL bal = new ParentAndChildBAL();
                DataTable dt = new DataTable();
                CrParentChildInfo rpt = new CrParentChildInfo();
                frmReportViewer view = new frmReportViewer();
                dt = bal.GetAllChild_ShareAndMoney_Information(_custCode);
                rpt.SetDataSource(dt);
                GetCommonInfo();
                ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = _branchAddress;
                ((TextObject)rpt.ReportDefinition.Sections[2].ReportObjects["txtReportName"]).Text = "All Account Information";
                view.crvReportViewer.ReportSource = rpt;
                view.Show();
            }
            catch (Exception ex)
            {
                throw ex;
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (txtCustCode.Text.Trim() != "")
            {
                if (rdoShareSummery.Checked)
                {
                    ShowPortFolioReportInvestorWise();
                }
                    //if(RdoParentChildGroupingInfo.Checked)
                else 
                {
                    ParentChildGroupReport();
                }
            }
            else
            {
                MessageBox.Show("Select a customer first.", "Warning!");
            }
        }
    }
}
