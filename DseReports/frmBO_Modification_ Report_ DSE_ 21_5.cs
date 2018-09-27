using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using DSE_Reports.Reports;
using CrystalDecisions.CrystalReports.Engine;
using BusinessAccessLayer.BAL;


namespace DseReports
{
    public partial class frmBO_Modification_Report_DSE_21_5 : Form
    {
        public frmBO_Modification_Report_DSE_21_5()
        {
            InitializeComponent();
        }
        string _Bo_Id = "";
        string _Cust_Id = "";
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            BO_Modification_Report_DSE_21_5BAL objBAL = new BO_Modification_Report_DSE_21_5BAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crBO_Modification__Report__DSE__21_5 objrpt = new crBO_Modification__Report__DSE__21_5();
            if (ddlCust_BOID.SelectedIndex == 0)
            {
                _Bo_Id = objBAL.GetBoIdByCustCode(txtCustCode_BOID.Text);
                data = objBAL.GetBO_Modification_ReportData(txtCustCode_BOID.Text,_Bo_Id, dtpFromDate.Value, dtpToDate.Value);
            }
            else
            {
                _Cust_Id = objBAL.GetCustCodeByBoId(txtCustCode_BOID.Text);
                data = objBAL.GetBO_Modification_ReportData(_Cust_Id,txtCustCode_BOID.Text, dtpFromDate.Value, dtpToDate.Value);
            }
            objrpt.SetDataSource(data);
            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBO_Modification_Report_DSE_21_5_Load(object sender, EventArgs e)
        {
            ddlCust_BOID.SelectedIndex = 0;
        }
    }
}
