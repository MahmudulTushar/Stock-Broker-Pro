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
    public partial class frmPay_Out_Confirmation_Report_DSE_21_11 : Form
    {
        public frmPay_Out_Confirmation_Report_DSE_21_11()
        {
            InitializeComponent();
        }

        private void frmPay_Out_Confirmation_Report_DSE_21_11_Load(object sender, EventArgs e)
        {
            Pay_Out_Confirmation_Report_DSE_21_11BAL objBAL = new Pay_Out_Confirmation_Report_DSE_21_11BAL();
            DataTable instrumentGroup;
            DataTable branchName;
            instrumentGroup = objBAL.GetInstrumentGroup();
            branchName = objBAL.GetBranchName();

            ddlInstrumentGroup.DataSource = instrumentGroup;
            ddlInstrumentGroup.ValueMember = instrumentGroup.Columns[0].ToString();
            ddlInstrumentGroup.DisplayMember = instrumentGroup.Columns[1].ToString();

            ddlBranchName.DataSource = branchName;
            ddlBranchName.ValueMember = branchName.Columns[0].ToString();
            ddlBranchName.DisplayMember = branchName.Columns[1].ToString();

        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            Pay_Out_Confirmation_Report_DSE_21_11BAL objBAL = new Pay_Out_Confirmation_Report_DSE_21_11BAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crPay_Out_Confirmation_Report_DSE_21_11 objrpt = new crPay_Out_Confirmation_Report_DSE_21_11();
            data = objBAL.GetPay_In_Confirmation_ReportData(ddlInstrumentGroup.Text, ddlBranchName.Text, dtpDate.Value);
            objrpt.SetDataSource(data);
            ((TextObject)objrpt.Section2.ReportObjects["txtBranch"]).Text = ddlBranchName.Text;
            ((TextObject)objrpt.Section2.ReportObjects["txtInstrumentGroup"]).Text = ddlInstrumentGroup.Text;
            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
