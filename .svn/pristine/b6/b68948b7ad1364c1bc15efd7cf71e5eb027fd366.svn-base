using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace StockbrokerProNewArch
{
    public partial class FrmIncomeSummary : Form
    {
        
        public FrmIncomeSummary()
        {
            InitializeComponent();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            IncomeEntryBAL incBal = new IncomeEntryBAL();
            Cr_IncomeSummaryReport CrReport = new Cr_IncomeSummaryReport();
            CustomerSummeryViewer Viewer = new CustomerSummeryViewer();
            DataTable reportData = new DataTable();

            DateTime FromDate = Convert.ToDateTime(dtpFromDate.Value.ToShortDateString());
            DateTime ToDate = Convert.ToDateTime(dtpToDate.Value.ToShortDateString());
            reportData = incBal.IncomeSummeryReportData(FromDate, ToDate);
            CrReport.SetDataSource(reportData);

            ((TextObject)CrReport.ReportDefinition.Sections[3].ReportObjects["txtDuration"]).Text
                = dtpFromDate.Value.ToString("dd MMM yyyy") + "  To  " + dtpToDate.Value.ToString("dd MMM yyyy");
            Viewer.crvCustSummeryReportViewer.ReportSource = CrReport;
            Viewer.Show();            
        }
    }
}
