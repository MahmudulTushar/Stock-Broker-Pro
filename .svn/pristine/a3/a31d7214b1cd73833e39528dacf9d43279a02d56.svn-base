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
    public partial class CustomerSummeryLedger : Form
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


        public CustomerSummeryLedger()
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

        private void CustomerSummeryLedger_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustCode.Text.Trim() != "")
                {
                    this.Cursor = Cursors.WaitCursor;
                    ShowCustSummeryReport();
                    this.Cursor = Cursors.Arrow;
                }
                else
                {
                    MessageBox.Show("Select a customer first.", "Warning!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
       
        public void ShowCustSummeryReport()
        {
            _branchId = GlobalVariableBO._branchId;
            _fromDate = Convert.ToDateTime(dtFromDate.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(dtToDate.Value.ToShortDateString());
            _custCode = txtCustCode.Text;

            CustomerSummeryBAL customerSummeryBal = new CustomerSummeryBAL();
            crCustomerSummery crCustomerSumm = new crCustomerSummery();
            CustomerSummeryViewer custSumViewer = new CustomerSummeryViewer();
            DataTable dtCustSummery = new DataTable();

            RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Customer_Summery_Ledger);
            string T_custCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Summery_Ledger);
            dtCustSummery = customerSummeryBal.GetCustSummery(T_custCode, _fromDate, _toDate);
            crCustomerSumm.SetDataSource(dtCustSummery);

            ////Load Summery Data
            DataTable dtSummeryTrans = new DataTable();
            DataTable dtPaymentSummery=new DataTable();

            string summerycustCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Summery_Ledger);
            dtSummeryTrans = customerSummeryBal.GetSummeryDataTransaction(summerycustCode, _fromDate, _toDate);
            
            string paymentcustCode = obj.FilterCustCode(_custCode, ResourceName.Customer_Summery_Ledger);
            dtPaymentSummery = customerSummeryBal.GetSummeryDataPayment(paymentcustCode, _fromDate, _toDate);

            if (dtSummeryTrans.Rows.Count > 0)
            {
                ((TextObject) crCustomerSumm.ReportDefinition.Sections[4].ReportObjects["txtBuyAmount"]).Text =String.Format("{0:0.##}",dtSummeryTrans.Rows[0]["TotalBuyAmount"]);
                ((TextObject)crCustomerSumm.ReportDefinition.Sections[4].ReportObjects["txtSellAmount"]).Text = String.Format("{0:0.##}",dtSummeryTrans.Rows[0]["TotalSellAmount"]);
                ((TextObject)crCustomerSumm.ReportDefinition.Sections[4].ReportObjects["txtCommission"]).Text = String.Format("{0:0.##}",dtSummeryTrans.Rows[0]["TotalCommission"]);
            }
            if(dtPaymentSummery.Rows.Count>0)
            {
                ((TextObject)crCustomerSumm.ReportDefinition.Sections[4].ReportObjects["txtReceived"]).Text =String.Format("{0:0.##}",dtPaymentSummery.Rows[0]["TotalDeposit"]);
                ((TextObject)crCustomerSumm.ReportDefinition.Sections[4].ReportObjects["txtWithdraw"]).Text = String.Format("{0:0.##}",dtPaymentSummery.Rows[0]["TotalWithdraw"]);
            }

            GetCommonInfo();
            ///// Load Company Name
            ((TextObject) crCustomerSumm.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =_CommpanyName;
            ///// Load Branch Name
            ((TextObject)crCustomerSumm.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            ////Load Date
            if (_fromDate != null && _toDate != null)
            {
                ((TextObject)crCustomerSumm.ReportDefinition.Sections[2].ReportObjects["txtReportDuration"]).Text = "Duration : " + _fromDate.ToString("dd-MMM-yyyy") + " To " + _toDate.ToString("dd-MMM-yyyy");

            }
            custSumViewer.crvCustSummeryReportViewer.ReportSource = crCustomerSumm;
            custSumViewer.crvCustSummeryReportViewer.DisplayGroupTree = false;
            custSumViewer.Show();
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
