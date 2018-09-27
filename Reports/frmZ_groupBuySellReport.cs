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


namespace Reports 
{
    public partial class frmZ_groupBuySellReport : Form
    {
        public frmZ_groupBuySellReport()
        {
            InitializeComponent();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            ZgroupBuySellReportBAL objBAL = new ZgroupBuySellReportBAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crZ_groupBuySellReport objrpt = new crZ_groupBuySellReport();
            int zgroupId;
            zgroupId = objBAL.GetZgroupCompanyId();
            data = objBAL.GetZgroupShareBuySellReport(zgroupId, dtpStartDate.Value, dtpEndDate.Value);
            objrpt.SetDataSource(data);
            ((TextObject)objrpt.Section2.ReportObjects["txtFromDate"]).Text = dtpStartDate.Value.ToString("dd/MM/yyyy");
            ((TextObject)objrpt.Section2.ReportObjects["txtToDate"]).Text = dtpEndDate.Value.ToString("dd/MM/yyyy");
            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Text = "Z-group share Buy/Sell Report";
            rptviewer.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                ShowReport();
            }
        }

        private void dtpEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowReport();
            }
        }

        
    }
}
