using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace Reports
{
    public partial class frmIPORequestToBlockIPOAmount : Form
    {
        IPOReportBAL bal = new IPOReportBAL();
        IPOProcessBAL p_Bal = new IPOProcessBAL();
        int tryparse = 0;
        int sessionID = 0;
        DataTable dt = new DataTable();
        public frmIPORequestToBlockIPOAmount()
        {
            InitializeComponent();
        }

        private void LoadComboData()
        {
            dt = p_Bal.GetCompanyShortCodeAndSessionID();
            if (dt.Rows.Count > 0)
            {
                cmbSession.DataSource = dt;
                cmbSession.DisplayMember = "Code";
                cmbSession.ValueMember = "ID";
            }
            else
            {
                MessageBox.Show("Session Invalid");
            }
        }

        private void frmIPORequestToBlockIPOAmount_Load(object sender, EventArgs e)
        {
            LoadComboData();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            
            if(int.TryParse(Convert.ToString(cmbSession.SelectedValue) ,out tryparse))
            {
                sessionID=tryparse;
            }
            dt = bal.GetIPORequestToBlockIPOAmount(sessionID);
            crIPORequestToBlockIPOAmount cr = new crIPORequestToBlockIPOAmount();
            frmReportViewer view=new frmReportViewer();
            cr.SetDataSource(dt);
            view.crvReportViewer.ReportSource = cr;
            view.Show();
        }
    }
}
