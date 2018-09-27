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
    public partial class frmIPOUnblockAndTransferLetter : Form
    {
        IPOProcessBAL bal = new IPOProcessBAL();
        IPOReportBAL R_Bal = new IPOReportBAL();

        public frmIPOUnblockAndTransferLetter()
        {
            InitializeComponent();
        }

        private void LoadSessionInf()
        {
            DataTable dt = new DataTable();
            dt = bal.GetCompanyShortCodeAndSessionID();
            cmbsessionName.DataSource = dt;
            cmbsessionName.DisplayMember = "code";
            cmbsessionName.ValueMember = "ID";
            cmbsessionName.SelectedIndex = 0;
        }

        private void frmIPOUnblockAndTransferLetter_Load(object sender, EventArgs e)
        {
            LoadSessionInf();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUnblock_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            crIPOUnblockAndTransferLetter crUnblock = new crIPOUnblockAndTransferLetter();
            frmReportViewer view = new frmReportViewer();
            dt = R_Bal.GetIPOUnblockAndTransferLetter(Convert.ToInt32(cmbsessionName.SelectedValue));
            crUnblock.SetDataSource(dt);
            view.crvReportViewer.ReportSource = crUnblock;
            view.Show();
        }
    }
}
