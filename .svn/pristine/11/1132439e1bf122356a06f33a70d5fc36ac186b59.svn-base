using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using CrystalDecisions.CrystalReports.Engine;
namespace Reports
{
    public partial class InstruwiseShareTradeList : Form
    {
        public InstruwiseShareTradeList()
        {
            InitializeComponent();
        }

        private void InstruwiseShareTradeListReportViewer_Load(object sender, EventArgs e)
        {
            LoadCompanyShortCode();
        }
        private void LoadCompanyShortCode()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Company");
            ddlCompanyShortCode.DataSource = dtData;
            ddlCompanyShortCode.DisplayMember = "Comp_Short_Code";
            ddlCompanyShortCode.ValueMember = "Comp_Short_Code";
            if (ddlCompanyShortCode.HasChildren)
                ddlCompanyShortCode.SelectedIndex = -1;
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                ReportView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: "+ex.Message);
            }

        }

        private void ReportView()
        {
            if(ddlCompanyShortCode.Text==string.Empty)
            {
                MessageBox.Show("Please Select Instrument Short Code");
                return;
            }            
            DataTable dt = new DataTable();
            ShareBalanceBAL reportBAL=new ShareBalanceBAL();
            LoadCommonInfo CmmInfo = new LoadCommonInfo();
            CompanyBAL objCompanyBal = new CompanyBAL();
            
            string compShortCode=ddlCompanyShortCode.Text;
            DateTime fromDate=dtStartDate.Value;
            DateTime toDate=dtEndDate.Value;
            dt = reportBAL.GetCompanyWiseShareTradeList(compShortCode, fromDate, toDate);
            
            crInstruwiseShareTradeList reportFile = new crInstruwiseShareTradeList();
            reportFile.SetDataSource(dt);

            ((TextObject)reportFile.ReportDefinition.Sections[1].ReportObjects["txtCompanyName"]).Text = CmmInfo.ShowCompanyName();
            ((TextObject)reportFile.ReportDefinition.Sections[1].ReportObjects["txtBranchName"]).Text = objCompanyBal.GetHeadofficeInfo();
            ((TextObject)reportFile.ReportDefinition.Sections[1].ReportObjects["txtReportDate"]).Text = "From " + fromDate.ToShortDateString() + " To " + toDate.ToShortDateString();           
            

            ((TextObject)reportFile.ReportDefinition.Sections[1].ReportObjects["txtInstruName"]).Text=Convert.ToString(dt.Rows[0][2]);
            ((TextObject)reportFile.ReportDefinition.Sections[1].ReportObjects["txtInstruCode"]).Text=Convert.ToString(dt.Rows[0][1]);
            ((TextObject)reportFile.ReportDefinition.Sections[1].ReportObjects["txtInstruGroup"]).Text = Convert.ToString(dt.Rows[0][3]);

            frmInstruwiseShareTradeListViewer reportViewer = new frmInstruwiseShareTradeListViewer();
            reportViewer.crvInstruWiseShareTradeList.ReportSource = reportFile;
            reportViewer.Show();            

        }
    }
}
