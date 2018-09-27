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
    public partial class TaxInput : Form
    {
        public static string _boID = "";
        public static string _custCode ="";
        public static int _branchId;
        public static DateTime _fromDate;
        public static DateTime _toDate;
        public static string custCode;


        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        public TaxInput()
        {
            InitializeComponent();
        }

        private string _reportNo;
        public String ReportNo
        {
            get { return _reportNo; }
            set { _reportNo = value; }
        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                if(txtSearchCustomer.Text.Trim()=="")
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

        private void CustomerMoneyLedger_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
            string df = DateTime.Today.AddYears(-1).Year.ToString();
            string dt = DateTime.Today.Year.ToString();
            dtFromDate.Value = Convert.ToDateTime(df + "-07-" + "01");
            dtToDate.Value = Convert.ToDateTime(dt + "-06-" + "30");

            if (_reportNo == "1")
            {
                btnReport.Text = "Generate Tax Statement";
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (txtCustCode.Text.Trim() != "")
            {
                if (_reportNo == "1")
                {
                    ShowCustTaxStatement();
                }
                else
                {
                    ShowCustMoneyLedgerReport();
                }
                
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

            TaxBAL taxBal = new TaxBAL();
            DataTable data = new DataTable();
            data = taxBal.GetCustSummery(_custCode, _fromDate, _toDate);

            TaxStatementBAL TaxStatementBAL = new TaxStatementBAL();
            DataSet TaxDataSet = new DataSet();
            TaxDataSet = TaxStatementBAL.GetData(_custCode, _fromDate, _toDate);

            TaxCerfificateForm taxCerfificateForm = new TaxCerfificateForm();
            TaxCertificate taxCertificate = new TaxCertificate();

            if (TaxDataSet.Tables.Count>2 )
            {
                ((TextObject)taxCertificate.ReportDefinition.Sections[2].ReportObjects["txtCurrent_Brought_Cost_Total"]).Text = String.Format("{0:#,###0.00}", Convert.ToDouble(TaxDataSet.Tables[2].Rows[0][0]));// DepositWithdraw.Rows[0][0].ToString();
                ((TextObject)taxCertificate.ReportDefinition.Sections[2].ReportObjects["txtRealised_Gain_Total"]).Text = String.Format("{0:#,###0.00}", Convert.ToDouble(TaxDataSet.Tables[2].Rows[0][3]));// DepositWithdraw.Rows[0][1].ToString();
                ((TextObject)taxCertificate.ReportDefinition.Sections[2].ReportObjects["txtUnrealised_Gain_Total"]).Text = String.Format("{0:#,###0.00}", Convert.ToDouble(TaxDataSet.Tables[2].Rows[0][4]));//DepositWithdraw.Rows[0][1].ToString();
                ((TextObject)taxCertificate.ReportDefinition.Sections[2].ReportObjects["Market_Value_Total"]).Text = String.Format("{0:#,###0.00}", Convert.ToDouble(TaxDataSet.Tables[2].Rows[0][2]));//DepositWithdraw.Rows[0][1].ToString();
            }

            taxCertificate.SetDataSource(data);

            //if (TaxDataSet.Tables.Count == 3)
            //{

            //    ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtSold_Cost_Total"]).Text = TaxDataSet.Tables[2].Rows[0][1].ToString();// DepositWithdraw.Rows[0][0].ToString();
            //    ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtRealised_Gain_Total"]).Text = TaxDataSet.Tables[2].Rows[0][3].ToString();// DepositWithdraw.Rows[0][1].ToString();
            //    ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtUnrealised_Gain_Total"]).Text = TaxDataSet.Tables[2].Rows[0][4].ToString();//DepositWithdraw.Rows[0][1].ToString();
            //}

            taxCerfificateForm.crTaxCer.ReportSource = taxCertificate;
            taxCerfificateForm.Show();
        }

        public void ShowCustTaxStatement()
        {
            _branchId = GlobalVariableBO._branchId;
            _fromDate = Convert.ToDateTime(dtFromDate.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(dtToDate.Value.ToShortDateString());
            _custCode = txtCustCode.Text;

            TaxBAL taxBal = new TaxBAL();
            DataTable data = new DataTable();
            DataTable DepositWithdraw = new DataTable();
            TaxStatementBAL TaxStatementBAL = new TaxStatementBAL();
            DataSet TaxDataSet = new DataSet();
            TaxDataSet = TaxStatementBAL.GetData(_custCode, _fromDate, _toDate);

            data = taxBal.GetTaxStatement(_custCode, _fromDate, _toDate);
            DepositWithdraw = taxBal.GetDepositWithdrawBalence(_custCode, _fromDate, _toDate);

            //////// Code for Additional Share ****************//////
            cr_additionalShare cradditionalShare = new cr_additionalShare();
            DataTable dtAdditionalShare = new DataTable();
            dtAdditionalShare = taxBal.GetAdditiobnalShare(_custCode, _fromDate, _toDate);
           // cradditionalShare.SetDataSource(dtAdditionalShare);
            //////// End ****************///////////////////////


            TaxCerfificateForm taxCerfificateForm = new TaxCerfificateForm();
            cr_TaxStatement taxStatement = new cr_TaxStatement();
            taxStatement.SetDataSource(data);
            taxStatement.Subreports[0].SetDataSource(dtAdditionalShare);
            taxCerfificateForm.crTaxCer.ReportSource = taxStatement;

            GetCommonInfo();
            ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
            ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;

            ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text =  dtFromDate.Value.ToString("dd-MM-yyyy") + " To " + dtToDate.Value.ToString("dd-MM-yyyy");
            ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtClientCode"]).Text =txtCustCode.Text;
            ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtBoid"]).Text = txtAccountHolderBOId.Text;
            ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtClientName"]).Text = txtAccountHolderName.Text;
            ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtSummary"]).Text = "Summary(" + dtFromDate.Value.ToString("dd-MM-yyyy") + " To " + dtToDate.Value.ToString("dd-MM-yyyy")+")";

            ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtDeposit"]).Text = DepositWithdraw.Rows[0][0].ToString();
            ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtWithdraw"]).Text = DepositWithdraw.Rows[0][1].ToString();

            if (TaxDataSet.Tables.Count> 2)
            {

                ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtSold_Cost_Total"]).Text = TaxDataSet.Tables[2].Rows[0][1].ToString();// DepositWithdraw.Rows[0][0].ToString();
                ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtRealised_Gain_Total"]).Text = TaxDataSet.Tables[2].Rows[0][3].ToString();// DepositWithdraw.Rows[0][1].ToString();
                ((TextObject)taxStatement.ReportDefinition.Sections[2].ReportObjects["txtUnrealised_Gain_Total"]).Text = TaxDataSet.Tables[2].Rows[0][4].ToString();//DepositWithdraw.Rows[0][1].ToString();
            }

            taxCerfificateForm.Text = "Tax Statement";
            taxCerfificateForm.Show();
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
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

        private void btnGrnerateReport_Click(object sender, EventArgs e)
        {
            if (rdbTaxCertificate.Checked == true)
            {
                if (txtCustCode.Text.Trim() != "")
                {
                    if (_reportNo == "1")
                    {
                        ShowCustTaxStatement();
                    }
                    else
                    {
                        ShowCustMoneyLedgerReport();
                    }

                }
                else
                {
                    MessageBox.Show("Select a customer first.", "Warning!");
                }

            }
            if(rdbTaxStatement.Checked==true)
            {
                custCode = txtCustCode.Text;
                _fromDate = Convert.ToDateTime(dtFromDate.Value.ToShortDateString());
                _toDate = Convert.ToDateTime(dtToDate.Value.ToShortDateString());
                DataSet TaxDataSet = new DataSet();
                DataTable TaxStatement = new DataTable();
                DataTable BonusRightIPOSatement = new DataTable();
                DataTable TaxStatementSummary = new DataTable();
                TaxStatementBAL TaxStatementBAL = new TaxStatementBAL();
                crTaxStatement crTaxStatement = new crTaxStatement();
                crTaxStatementBonusIPO crTaxStatementBonusRightIPO_Rpt = new crTaxStatementBonusIPO();
                crTaxStatementSummarySubReport crTaxStatementSummarySubReport = new crTaxStatementSummarySubReport();
                frmPaymentReceiptSummaryViewer ReportViewer = new frmPaymentReceiptSummaryViewer();

                RecordLevelFilteringBAL obj = new RecordLevelFilteringBAL(ResourceName.Tax_TaxStatement);
                string T_Custcode = obj.FilterCustCode(_custCode, ResourceName.Tax_TaxStatement);
                if (T_Custcode == "")
                {
                    MessageBox.Show("You are restricted");
                    return;
                }

                TaxDataSet = TaxStatementBAL.GetData(custCode, _fromDate, _toDate);

                if (TaxDataSet.Tables.Count>3)
                {
                    TaxStatement = TaxDataSet.Tables[0];
                    BonusRightIPOSatement = TaxDataSet.Tables[1];
                    TaxStatementSummary = TaxDataSet.Tables[3];
                }

                crTaxStatement.DataSourceConnections.Clear();
                crTaxStatement.SetDataSource(TaxStatement);
                crTaxStatement.Subreports["crTaxStatementBonusIPO.rpt"].DataSourceConnections.Clear();
                crTaxStatement.Subreports["crTaxStatementBonusIPO.rpt"].SetDataSource(BonusRightIPOSatement);
                crTaxStatement.Subreports["crTaxStatementSummarySubReport.rpt"].DataSourceConnections.Clear();
                crTaxStatement.Subreports["crTaxStatementSummarySubReport.rpt"].SetDataSource(TaxStatementSummary);



                GetCommonInfo();
                ((TextObject)crTaxStatement.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)crTaxStatement.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                ((TextObject)crTaxStatement.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text = dtFromDate.Value.ToString("dd/MM/yyyy");
                ((TextObject)crTaxStatement.ReportDefinition.Sections[2].ReportObjects["txtToDate"]).Text = dtToDate.Value.ToString("dd/MM/yyyy");
                ((TextObject)crTaxStatement.Subreports["crTaxStatementSummarySubReport.rpt"].ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text = _fromDate.ToString("dd-MM-yyyy");
                ((TextObject)crTaxStatement.Subreports["crTaxStatementSummarySubReport.rpt"].ReportDefinition.Sections[2].ReportObjects["txtToDate"]).Text = _toDate.ToString("dd-MM-yyyy");

                ReportViewer.crystalReportViewer1.DisplayGroupTree = false;
                ReportViewer.crystalReportViewer1.ReportSource = crTaxStatement;

                ReportViewer.Show();

            }
        }

        private void rdbTaxCertificate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTaxCertificate.Checked)
            {
                this.Text = "Tax Certificate Information";
            }
        }

        private void rdbTaxStatement_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTaxStatement.Checked)
            {
                this.Text = " Tax Statement Information";
            }
        }


    }
}
