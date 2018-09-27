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

namespace StockbrokerProNewArch
{
    public partial class TotalSubscriptionStatus : Form
    {
        public TotalSubscriptionStatus()
        {
            InitializeComponent();
        }

        private void TotalSubscriptionStatus_Load(object sender, EventArgs e)
        {
            LoadComboData();
            if (CmbsessionIdByName.Items.Count>0)
            CmbsessionIdByName.SelectedIndex = 0;
        }
        IPOProcessBAL bal = new IPOProcessBAL();
        private void LoadComboData()
        {
            DataTable dt = new DataTable();
            dt = bal.GetCompanyShortCodeAndSessionID();
            CmbsessionIdByName.DataSource = dt;
            CmbsessionIdByName.DisplayMember = dt.Columns["Code"].ToString();
            CmbsessionIdByName.ValueMember = dt.Columns["ID"].ToString();

        }

        private void btnSubscriptionstatus_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            crTotalSubscriptionStatus crlist = new crTotalSubscriptionStatus();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            int sessionid =Convert.ToInt32(CmbsessionIdByName.SelectedValue);
            dt = bal.GetTotalSubscriptionStatus(sessionid);
            crlist.SetDataSource(dt);
            viewer.crystalReportViewer1.ReportSource = crlist;
            viewer.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
