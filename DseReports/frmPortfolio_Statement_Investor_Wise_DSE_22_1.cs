using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using DSE_Reports.Reports;
using CrystalDecisions.CrystalReports.Engine;
using BusinessAccessLayer.BAL;


namespace DseReports
{
    public partial class frmPortfolio_Statement_Investor_Wise_DSE_22_1 : Form
    {
        Portfolio_Statement_Investor_Wise_DSE_22_1BAL objBAL = new Portfolio_Statement_Investor_Wise_DSE_22_1BAL();
        string Exchange_Name = "";
        string InvestorId = "";
        DateTime Report_Date;
        public frmPortfolio_Statement_Investor_Wise_DSE_22_1()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btnshow_Click(object sender, EventArgs e)
        {
            crPortfolio_Statement_Investor_Wise_DSE_22_1 objRPT = new crPortfolio_Statement_Investor_Wise_DSE_22_1();
            frmReportViewer viewer = new frmReportViewer();
            DataTable dt = new DataTable();
            Exchange_Name=cmbExchangeName.Text;
            InvestorId=cmbInvestorId.Text;
            Report_Date=dtpReportDate.Value;
            if (Exchange_Name == "CSE")
            {
                InvestorId = "";
                Exchange_Name = "";
                dt = objBAL.Portfolio_Statement_Investor(Exchange_Name, Report_Date, InvestorId);
            }
            else
            {
                dt = objBAL.Portfolio_Statement_Investor(Exchange_Name, Report_Date, InvestorId);
            }
            objRPT.SetDataSource(dt);
            viewer.crvReportViewer.ReportSource = objRPT;
            viewer.Show();
        }

        private void frmPortfolio_Statement_Investor_Wise_DSE_22_1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            cmbExchangeName.SelectedIndex = 0;
        }
        private void LoadComboBox()
        {
            DataTable dtInvestor = new DataTable();
            dtInvestor = objBAL.GetInvestorId();
            cmbInvestorId.DataSource = dtInvestor;
            cmbInvestorId.DisplayMember = dtInvestor.Columns[0].ToString();
            cmbInvestorId.ValueMember = dtInvestor.Columns[0].ToString();
        }
    }
}
