using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using DSE_Reports.Reports;
using CrystalDecisions.CrystalReports.Engine;
 
using System.IO;

namespace DseReports 
{
    public partial class frmBOClosing_Report_DSE_21_6 : Form
    {
        public frmBOClosing_Report_DSE_21_6()
        {
            InitializeComponent();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            BO_Closing_Report_DSE_21_6BAL objBAL = new BO_Closing_Report_DSE_21_6BAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crBO_Closing_Report_DSE_21_6 objrpt = new crBO_Closing_Report_DSE_21_6();
            data = objBAL.GetBO_Closing_ReportData(dtpFromDate.Value, dtpToDate.Value);
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtFromDate"]).Text = dtpFromDate.Value.ToShortDateString();
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtToDate"]).Text = dtpToDate.Value.ToShortDateString();
            objrpt.SetDataSource(data);
            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Show();

        }
    }
}
