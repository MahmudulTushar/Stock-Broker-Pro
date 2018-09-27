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
    public partial class frmClient_Ledger_Detail_Report_DSE_24_10 : Form
    {
        #region Constructor
        public frmClient_Ledger_Detail_Report_DSE_24_10()
        {
            InitializeComponent();
            //LoadComboBox();
        }
        #endregion

        #region Load ComboBox
        public void LoadComboBox()
        {
            Client_Ledger_Detail_Report_DSE_24_10BAL objBAL = new Client_Ledger_Detail_Report_DSE_24_10BAL();
            DataTable dtclient = new DataTable();
            dtclient = objBAL.GetClient();
            //cmdClientcode.DataSource = dtclient;
            //cmdClientcode.DisplayMember = dtclient.Columns[0].ToString();
            //cmdClientcode.ValueMember = dtclient.Columns[0].ToString();
        }
        #endregion

        #region View Report
        private void btnOpen_Click(object sender, EventArgs e)
        {
            Client_Ledger_Detail_Report_DSE_24_10BAL objBAL = new Client_Ledger_Detail_Report_DSE_24_10BAL();
            crClient_Ledger_Detail_Report_DSE_24_10 objRPT = new crClient_Ledger_Detail_Report_DSE_24_10();
            frmReportViewer viewer = new frmReportViewer();
            DataTable dt = new DataTable();            
            dt = objBAL.Client_Ledger_Detail_Report(txtClientCode.Text, dtpStartDate.Value, dtpEndDate.Value);
            objRPT.SetDataSource(dt);
            ((TextObject)objRPT.Section2.ReportObjects["txtClientCode"]).Text = txtClientCode.Text;
            ((TextObject)objRPT.Section2.ReportObjects["txtEndDate"]).Text = dtpEndDate.Value.ToString("dd-MMMM-yyyy");
            ((TextObject)objRPT.Section2.ReportObjects["txtStartDate"]).Text = dtpStartDate.Value.ToString("dd-MMMM-yyyy");          
            viewer.crvReportViewer.ReportSource = objRPT;
            viewer.Show();
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
