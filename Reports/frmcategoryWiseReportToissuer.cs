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
using CrystalDecisions.CrystalReports.Engine;

namespace StockbrokerProNewArch
{
    public partial class frmcategoryWiseReportToissuer : Form
    {
        public frmcategoryWiseReportToissuer()
        {
            InitializeComponent();
        }

        private void btnreporttoissuer_Click(object sender, EventArgs e)
        {
            string sessionid = "0";
            DataTable dt = new DataTable();
            crCategoryWiseReportToIssuer crReport = new crCategoryWiseReportToIssuer();
           frmIPOReportViewer viewer = new frmIPOReportViewer();
           if (cmsessionIdByName.Items.Count>0)
            {
                 sessionid = cmsessionIdByName.SelectedValue.ToString();
            }
            
            dt = bal.GetCategoryWiseReportToIssuer(sessionid);
            crReport.SetDataSource(dt);
            
            viewer.crystalReportViewer1.ReportSource = crReport;
            viewer.Show();
        }

        private void frmcategoryWiseReportToissuer_Load(object sender, EventArgs e)
        {
            loadCombo();
            if(cmsessionIdByName.Items.Count>0)
            {
            cmsessionIdByName.SelectedIndex = 0;
            }
        }
        IPOProcessBAL bal = new IPOProcessBAL();
        private void loadCombo()
        {
            DataTable dt = new DataTable();
            dt = bal.GetCompanyShortCodeAndSessionID();
            cmsessionIdByName.DataSource = dt;
            cmsessionIdByName.DisplayMember = dt.Columns["Code"].ToString();
            cmsessionIdByName.ValueMember = dt.Columns["ID"].ToString();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
