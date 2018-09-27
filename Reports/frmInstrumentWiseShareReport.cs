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

namespace Reports
{
    public partial class frmInstrumentWiseShareReport : Form
    {
        public frmInstrumentWiseShareReport()
        {
            InitializeComponent();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            InstrumentWiseShareBAL objBAL = new InstrumentWiseShareBAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crInstrumentWiseShareReport objrpt = new crInstrumentWiseShareReport();
            data = objBAL.GetInstrumentWiseShareReportData();
            objrpt.SetDataSource(data);
            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Text = "Instrument Wise Share Report";
            rptviewer.Show();
        }
    }
}
