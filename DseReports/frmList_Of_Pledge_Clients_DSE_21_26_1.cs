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
    public partial class frmList_Of_Pledge_Clients_DSE_21_26_1 : Form
    {
        public frmList_Of_Pledge_Clients_DSE_21_26_1()
        {
            InitializeComponent();
        }
        private void LoadComboData()
        {
            List_Of_Pledge_Clients_DSE_21_26_1BAL objBAL = new List_Of_Pledge_Clients_DSE_21_26_1BAL();
            DataTable pledgeclients;
            pledgeclients = objBAL.GetExchangeName();

            ddlExchange.DataSource = pledgeclients;
            ddlExchange.ValueMember = pledgeclients.Columns[0].ToString();
            ddlExchange.DisplayMember = pledgeclients.Columns[0].ToString();
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            List_Of_Pledge_Clients_DSE_21_26_1BAL objBAL = new List_Of_Pledge_Clients_DSE_21_26_1BAL();
            DataTable data = new DataTable();
            frmReportViewer rptviewer = new frmReportViewer();
            crList_Of_Pledge_Clients_DSE_21_26_1 objrpt = new crList_Of_Pledge_Clients_DSE_21_26_1();
            data = objBAL.GetList_Of_Pledge_Clients_ReportData(dtpFromDate.Value, dtpToDate.Value,ddlExchange.Text);
            objrpt.SetDataSource(data);
            ((TextObject)objrpt.Section2.ReportObjects["txtDate"]).Text = dtpToDate.Value.ToString("dd-MMMM-yyyy");
            ((TextObject)objrpt.Section2.ReportObjects["ToDate"]).Text = dtpToDate.Value.ToString("dd-MMMM-yyyy");
            ((TextObject)objrpt.Section2.ReportObjects["txtExchangeName"]).Text = ddlExchange.Text;

            rptviewer.crvReportViewer.ReportSource = objrpt;
            rptviewer.Show();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmList_Of_Pledge_Clients_DSE_21_26_1_Load(object sender, EventArgs e)
        {
            LoadComboData();
        }
    }
}
