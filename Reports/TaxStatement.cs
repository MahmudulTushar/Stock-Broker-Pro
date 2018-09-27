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
using Reports;

namespace Reports
{
    public partial class TaxStatement : Form
    {
        public static DateTime _fromDate;
        public static DateTime _toDate;
        public static string custCode;

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        
        public TaxStatement()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            custCode = txtCustCode.Text;
            _fromDate = Convert.ToDateTime(dtFromDate.Value.ToShortDateString());
            _toDate = Convert.ToDateTime(dtToDate.Value.ToShortDateString());
            DataSet TaxDataSet = new DataSet();
            DataTable TaxStatement =new DataTable();
            DataTable BonusRightIPOSatement=new DataTable();
            TaxStatementBAL TaxStatementBAL = new TaxStatementBAL();
            crTaxStatement crTaxStatement = new crTaxStatement();
            crTaxStatementBonusIPO crTaxStatementBonusRightIPO_Rpt = new crTaxStatementBonusIPO();
            frmPaymentReceiptSummaryViewer ReportViewer = new frmPaymentReceiptSummaryViewer();
            TaxDataSet = TaxStatementBAL.GetData(custCode, _fromDate, _toDate);
            if (TaxDataSet.Tables.Count ==3)
            {
                TaxStatement = TaxDataSet.Tables[0];
                BonusRightIPOSatement = TaxDataSet.Tables[1];
            }
            crTaxStatement.DataSourceConnections.Clear();
            crTaxStatement.SetDataSource(TaxStatement);
            crTaxStatement.Subreports["crTaxStatementBonusIPO.rpt"].DataSourceConnections.Clear();
            crTaxStatement.Subreports["crTaxStatementBonusIPO.rpt"].SetDataSource(BonusRightIPOSatement);
            GetCommonInfo();
            ((TextObject)crTaxStatement.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
            ((TextObject)crTaxStatement.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            ((TextObject)crTaxStatement.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text = dtFromDate.Value.ToString("dd/MM/yyyy");
            ((TextObject)crTaxStatement.ReportDefinition.Sections[2].ReportObjects["txtToDate"]).Text = dtToDate.Value.ToString("dd/MM/yyyy");

            ReportViewer.crystalReportViewer1.DisplayGroupTree = false;
            ReportViewer.crystalReportViewer1.ReportSource = crTaxStatement;
            
            ReportViewer.Show();

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

        private void TaxStatement_Load(object sender, EventArgs e)
        {
            int year;
            string currentYear;
            string previousYear;
            year = DateTime.Now.Year;
            currentYear = "28/Jun/"+year+"";
            previousYear = "1/Jul/" + Convert.ToString(year - 1) + "";
            dtFromDate.Value = Convert.ToDateTime(previousYear);
            dtToDate.Value = Convert.ToDateTime(currentYear);
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReport_Click(sender, (KeyEventArgs)e);
            }
        }
    }
}
