using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace Reports
{
    public partial class frmIPOSummaryOfTheApplications : Form
    {
        public frmIPOSummaryOfTheApplications()
        {
            InitializeComponent();
        }

        private void frmIPOSummaryOfTheApplications_Load(object sender, EventArgs e)
        {
            IPOReportBAL bal = new IPOReportBAL();
            DataTable dt = new DataTable();
            dt = bal.GetSessionName();
            cmbsessionName.DataSource = dt;
            cmbsessionName.DisplayMember = dt.Columns["IpoSession_Name"].ToString();
            cmbsessionName.ValueMember = dt.Columns["ID"].ToString();
            if (cmbsessionName.SelectedIndex >= 0)
            {
                cmbsessionName.SelectedIndex = 0;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            IPOReportBAL bal = new IPOReportBAL();
            DataTable dt = new DataTable();

            int Session_Id = (int)cmbsessionName.SelectedValue;
            dt = bal.GetIpoSummaryOfApplicationBySessionId(Session_Id);

            crIPOSummaryOfTheApplications crRpt = new crIPOSummaryOfTheApplications();
            frmReportViewer viewer = new frmReportViewer();
            crRpt.SetDataSource(dt);
            viewer.crvReportViewer.ReportSource = crRpt;
            viewer.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
