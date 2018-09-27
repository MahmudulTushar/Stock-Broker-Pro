using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class CustomerShareLedger : Form
    {
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


        private string _filterdColumnName;

        public CustomerShareLedger()
        {
            InitializeComponent();
        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode.ToString() == "Return")
            {
                if(txtSearchCustomer.Text.Trim()=="")
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

        private void CustomerShareLedger_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
            rdoShareSummery.Checked = true;
        }

        private void rdoSpecificPeriodShareLedger_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSpecificPeriodShareLedger.Checked)
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }
            else
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }  
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (txtCustCode.Text.Trim() != "")
            {
                ShowCustShareLedgerReport();
            }
            else
            {
                MessageBox.Show("Select a customer first.", "Warning!");
            }
        }
        public void ShowCustShareLedgerReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _shareSummery = rdoShareSummery.Checked;
            _Details = rdoDetailShareLedger.Checked;
            _SpecificPeriod = rdoSpecificPeriodShareLedger.Checked;
            _fromDate = Convert.ToDateTime(dtFromDate.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(dtToDate.Value.ToShortDateString());
            _custCode = txtCustCode.Text;
            ShareLedgerBAL shareLedgerBal = new ShareLedgerBAL();
            _maxPriceDate=shareLedgerBal.GetMaxPriceDate();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            if (_shareSummery)
            {
                ShowPortFolioReportInvestorWise();
            }
            else if (_Details)
            {
                crShareDetails crShareDetail = new crShareDetails();
                ShareDetailsViewer shareDetailViewer = new ShareDetailsViewer();
                DataTable dtShareDetails = new DataTable();
                string Temp_Custcode = "";

                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Customer_Share_Ledger_Share_Portfolio_Details_Specific_Period);
                Temp_Custcode = obj.FilterCustCode(_custCode, ResourceName.Customer_Share_Ledger_Share_Portfolio_Details_Specific_Period);

                dtShareDetails = shareLedgerBal.GetShareDetails(Temp_Custcode);


                crShareDetail.SetDataSource(dtShareDetails);
                ///// Load Company Name
               ((TextObject)crShareDetail.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

                ///// Load Branch Name
                ((TextObject)crShareDetail.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = CmmInfo.BranchDetails(_branchId);
                shareDetailViewer.crvShareDetailsReportViewer.ReportSource = crShareDetail;
                shareDetailViewer.Show();
            }
           
            else if(_SpecificPeriod)
            {
                //crSpecificShareLedger crSpecificShare = new crSpecificShareLedger();
                crShareDetails crSpecificShare = new crShareDetails();
                SpecificShareLedgerViewer specificShareLedgerViewer = new SpecificShareLedgerViewer();
                DataTable dtSpecificShareLedger = new DataTable();
                string Temp_Custcode = "";
                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Customer_Share_Ledger_Share_Portfolio_Details_Specific_Period);
                Temp_Custcode = obj.FilterCustCode(_custCode, ResourceName.Customer_Share_Ledger_Share_Portfolio_Details_Specific_Period);
                dtSpecificShareLedger = shareLedgerBal.GetSpecificShareLedger(Temp_Custcode, _fromDate, _toDate);

                crSpecificShare.SetDataSource(dtSpecificShareLedger);
                ///// Load Company Name
                ((TextObject)crSpecificShare.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();

                ///// Load Branch Name
                ((TextObject)crSpecificShare.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = CmmInfo.BranchDetails(_branchId);
                ((TextObject)crSpecificShare.ReportDefinition.Sections[2].ReportObjects["txtduration"]).Text ="Duration : " + dtFromDate.Value.ToString("dd-MMM-yyyy") + " To " + dtToDate.Value.ToString("dd-MMM-yyyy");
                specificShareLedgerViewer.crvSpecificShareLedgerReportViewer.ReportSource = crSpecificShare;
                specificShareLedgerViewer.Show();
               
            }
            else
            {
                MessageBox.Show("Please Select the report category first.");
            }

        }

        private void ShowPortFolioReportInvestorWise()
        {
            cr_DSE_22_1 objcr_DSE_22_1Report = new cr_DSE_22_1();
            DataTable dtProtofolioReportInvestorwise = new DataTable();
            DESReportBal objPortfolioBal = new DESReportBal();
            CustShareSummeryViewer objfrm_DSE_22_1_Report = new CustShareSummeryViewer();            
            string deposit = "0.00";
            string withdraw = "0.00";
            string balance = "0.00";
            string accruedbalance = "0.00";
            string IPObalance = "0.00";
            string availablebalance = "0.00";
            string netbalance = "0.00";



            try
            {
                ShareLedgerBAL shareLedgerBal = new ShareLedgerBAL();
                DataTable dtCustSummerybasic = new DataTable();

                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Customer_Share_Ledger_Share_Portfolio_Summery);
                string T_Custcode = obj.FilterCustCode(_custCode, ResourceName.Customer_Share_Ledger_Share_Portfolio_Summery);
                if (T_Custcode == "")
                {
                    MessageBox.Show("You are restricted");
                    return;
                }
                dtCustSummerybasic = shareLedgerBal.GetCustomerSummerBasicInfo(T_Custcode, dtToDate.Value);

                if (dtCustSummerybasic.Rows.Count != 0)
                {
                    deposit = Convert.ToDouble(dtCustSummerybasic.Rows[0]["Dep_Amount"]).ToString("N");
                    withdraw = Convert.ToDouble(dtCustSummerybasic.Rows[0]["Withdraw_Amount"]).ToString("N");
                    balance = Convert.ToDouble(dtCustSummerybasic.Rows[0]["Head_Balance"]).ToString("N");
                    accruedbalance = Convert.ToDouble(dtCustSummerybasic.Rows[0]["Accrued_Balance"]).ToString("N");
                    IPObalance = Convert.ToDouble(dtCustSummerybasic.Rows[0]["IPO_Balance"]).ToString("N");
                    availablebalance = (Convert.ToDecimal(balance) - (Convert.ToDecimal(accruedbalance))).ToString("N");
                    netbalance = (Convert.ToDecimal(availablebalance) + Convert.ToDecimal(IPObalance)).ToString("N");
                }

                string temp_custCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Share_Ledger_Share_Portfolio_Summery);
                dtProtofolioReportInvestorwise = objPortfolioBal.Get_DSE_22_1_Report(temp_custCode, dtToDate.Value);

                objcr_DSE_22_1Report.SetDataSource(dtProtofolioReportInvestorwise);

                GetCommonInfo();
                ((TextObject) objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ((TextObject) objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtBranchInfo"]).Text =
                    _branchAddress + ". Phone:" + _branchContactNumber;

                ((TextObject) objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtCustCode"]).Text =
                    txtCustCode.Text;
                ((TextObject) objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtBOID"]).Text =
                    txtAccountHolderBOId.Text;
                ((TextObject) objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtCustName"]).Text =
                    txtAccountHolderName.Text;

                ((TextObject) objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtDeposit"]).Text =
                    deposit;
                ((TextObject) objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtWithdraw"]).Text =
                    withdraw;
                //((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtBalance"]).Text =
                //   balance;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtCurrentTradeBalance"]).Text =
                    balance;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtTotalAcrudeCharge"]).Text =
                    accruedbalance;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtAvailableBalance"]).Text =
                    availablebalance;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtIPOBalance"]).Text =
                   IPObalance;
                ((TextObject)objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["txtNetBalance"]).Text =
                  netbalance;

               

                ((TextObject) objcr_DSE_22_1Report.ReportDefinition.Sections[2].ReportObjects["asOnDate"]).Text =
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

        private void rdoShareSummery_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoShareSummery.Checked)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = true;
            }
            else
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }  
           
        }
        BrokerInfoBAL bal = new BrokerInfoBAL();
        private void Btt_rpt_withPE_Click(object sender, EventArgs e)
        {
            Frm_CryRpt_Display CryRpt_Display = new Frm_CryRpt_Display();

            DateTime _date;
            string _FormDate = "";
            string _ToDate = "";
            _date = DateTime.Parse(dtFromDate.Text);
            _FormDate = _date.ToString();

            _date = DateTime.Parse(dtToDate.Text);
            _ToDate = _date.ToString();


            rpt_Portfolio_PE Portfolio_PE = new rpt_Portfolio_PE();

            DataTable dt = bal.Portfolio_PE_dt(txtSearchCustomer.Text, _ToDate);
            Portfolio_PE.SetDataSource(dt);


           // string RptFormula = "{V_RPT_Portfolio_PE.Cust_Code}='" + txtSearchCustomer.Text + "' AND {V_RPT_Portfolio_PE.Trade_Date}<=#" + _ToDate + "# ";

            string RptFormula = "";
            CryRpt_Display.ShowDialog(Portfolio_PE, RptFormula);

        }
          private bool ValidationCheck()
        {
              if(GlobalVariableBO._userName != "rakimul")
              {
                  MessageBox.Show("Sorry, Admin Only...");
                  return true;
              }

            else if (txtCustCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Select Customer First...", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchCustomer.Focus();
                return true;
            }
            else if (rdoShareSummery.Checked == false)
            {
                MessageBox.Show("No report to show. Select only Share Summary.", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else return false;
        } 
        private void btnNewPortfolioReport_Click(object sender, EventArgs e)
        {
            //if (ValidationCheck())
            //    return;

            ShareDWBAL shareDwbal = new ShareDWBAL();
            ShareLedgerBAL bal = new ShareLedgerBAL();
            MoneyLadgerReportBAL moneyLedgerReportBal = new MoneyLadgerReportBAL();
            DataTable dtPort = new DataTable();
            frmReportViewer viewer = new frmReportViewer();
            cr_NewPortfolioWithGL rpt = new cr_NewPortfolioWithGL();

            DataTable dtCommission = shareDwbal.GetCommissionRate(txtCustCode.Text.Trim());
            double CommissionRate = Convert.ToDouble(dtCommission.Rows[0][0].ToString());
            //string AsOnDateeeeee=Convert.ToString
            dtPort = bal.PortfolioWithActualBEPRealizeGL(txtCustCode.Text.Trim(), CommissionRate, dtToDate.Value);

            DataTable dtCustBasicInfo = moneyLedgerReportBal.GetCustBasicInfo(txtCustCode.Text.Trim());
            ((TextObject)rpt.ReportDefinition.Sections[1].ReportObjects["txtCustCode"]).Text =
                "Cust. Code: " + dtCustBasicInfo.Rows[0]["Cust_Code"].ToString();
            ((TextObject)rpt.ReportDefinition.Sections[1].ReportObjects["txtBOID"]).Text =
                "Cust. BO ID: " + dtCustBasicInfo.Rows[0]["BO_ID"].ToString();
            ((TextObject)rpt.ReportDefinition.Sections[1].ReportObjects["txtCustName"]).Text =
                "Cust. Name: " + dtCustBasicInfo.Rows[0]["Cust_Name"].ToString();
            ((TextObject)rpt.ReportDefinition.Sections[1].ReportObjects["AsOnDate"]).Text =
                "As On: " + dtToDate.Value.ToString("dd MMMM yyyy") + "";
            GetCommonInfo();
            ((TextObject)rpt.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
            ((TextObject)rpt.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text =
                _branchName + ", " + _branchAddress + ", " + "Phone: " + _branchContactNumber;
            ((TextObject)rpt.ReportDefinition.Sections[1].ReportObjects["txtReportName"]).Text = "Portfolio Statement";
            rpt.SetDataSource(dtPort);
            viewer.crvReportViewer.ReportSource = rpt;
            viewer.Show();
        }
    }
}
