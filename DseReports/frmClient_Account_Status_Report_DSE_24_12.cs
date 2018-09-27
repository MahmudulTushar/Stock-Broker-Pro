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
 

namespace DseReports
{
    public partial class frmClient_Account_Status_Report_DSE_24_12 : Form
    {
        Client_Account_Status_Report_DSE_24_12BAL objBAL = new Client_Account_Status_Report_DSE_24_12BAL();
        public frmClient_Account_Status_Report_DSE_24_12()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            crClient_Account_Status_Report_DSE_24_12 objRPT = new crClient_Account_Status_Report_DSE_24_12();
            frmReportViewer viewer = new frmReportViewer();
            DataTable dt = new DataTable();
            dt = objBAL.Client_Account_Status(dtpTradeDate.Value, txtClientCode.Text, txtRowNumber.Text, cmbBranchName.Text);
            objRPT.SetDataSource(dt);
            viewer.crvReportViewer.ReportSource = objRPT;
            viewer.Show();
        }

        public void LoadComboBox()
        {
            DataTable dt = new DataTable();
            dt = objBAL.GetbranchName();
            cmbBranchName.DataSource = dt;
            cmbBranchName.DisplayMember = dt.Columns[0].ToString();
            cmbBranchName.ValueMember = dt.Columns[0].ToString();
        }
    }
}
