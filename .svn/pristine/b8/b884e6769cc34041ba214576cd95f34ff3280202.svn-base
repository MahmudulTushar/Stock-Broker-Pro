using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;

namespace Reports
{
    public partial class frmIPOFordardingResultAfterResult : Form
    {
        IPOProcessBAL bal = new IPOProcessBAL();
        IPOReportBAL R_Bal = new IPOReportBAL();
        public frmIPOFordardingResultAfterResult()
        {
            InitializeComponent();
        }

        private void frmIPOFordardingResultAfterResult_Load(object sender, EventArgs e)
        {
            LoadSessionInf();
        }
        private void LoadSessionInf()
        {
            DataTable dt = new DataTable();
            dt=bal.GetCompanyShortCodeAndSessionID();
            cmbSessionName.DataSource = dt;
            cmbSessionName.DisplayMember = "code";
            cmbSessionName.ValueMember = "ID";
            cmbSessionName.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string App_ID = txtAppliationNo.Text;
            int Session_Id = Convert.ToInt32(cmbSessionName.SelectedValue);
            crIPOForwardingLetterAfterResult crobj = new crIPOForwardingLetterAfterResult();
            frmReportViewer view = new frmReportViewer();
            dt = R_Bal.GetIPOForwardingLetterDataAfterResult(Session_Id, App_ID);
            string Add = dt.Rows[0]["Company_Addr"].ToString();
            Add.Replace( "\n","Dhaka");
            dt.Rows.Add("Add");
            crobj.SetDataSource(dt);
            view.crvReportViewer.ReportSource = crobj;
            view.Show();
        }
    }
}
