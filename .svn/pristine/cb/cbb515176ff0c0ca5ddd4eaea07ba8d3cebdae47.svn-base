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
    public partial class frmIPOApplicationForPublicIssue : Form
    {
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;

        IPOApplicationForPublicIssueBAL objBAL = new IPOApplicationForPublicIssueBAL();

        public frmIPOApplicationForPublicIssue()
        {
            InitializeComponent();
        }
        private void LoadComboInfo()
        {
            CmbCompanyCode.SelectedIndex = 0;
        }

        private void FrmIpoApplicationForPublicIssue_Load(object sender, EventArgs e)
        {
            //LoadComboInfo();
            CmbCompanyCode.SelectedIndex = 0;
            if (CmbCustCode.Items.Count>0)
            {
              CmbCustCode.SelectedIndex = 0;  
            }
            
            cmbSelectSignature.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {             
                if (cmbSelectSignature.SelectedItem.Equals("Signature"))
                {
                    PrintWithSignature();
                }
                else
                {
                    PrinTwithoutSignature();
                }
             
        }
        private void PrinTwithoutSignature()
        {
            DataTable dt = new DataTable();
            crIpoApplicationForPublicIssueSignature objrpt = new crIpoApplicationForPublicIssueSignature();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            if (CmbCompanyCode.SelectedItem.Equals("Company Name"))
            {
                dt = objBAL.GetPublicApplicationIssue("", CmbCustCode.Text);
            }
            else if (CmbCompanyCode.SelectedItem.Equals("Cust Code"))
            {
                dt = objBAL.GetPublicApplicationIssue(CmbCustCode.Text, "");
            }
            else if (CmbCompanyCode.SelectedItem.Equals("Code and Company"))
            {
                dt = objBAL.GetPublicApplicationIssue(CmbCustCode.Text, CmbCompany.Text);
            }

            objrpt.SetDataSource(dt);
            GetCommonInfo();
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                               "IPO Application for public issue";
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                _CommpanyName;
            ///// Load Branch Name
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            viewer.crystalReportViewer1.ReportSource = objrpt;
            viewer.Show();
        }
        private void PrintWithSignature()
        {
            DataTable dt = new DataTable();
            crIpoApplicationForPublicIssue objrpt = new crIpoApplicationForPublicIssue();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            if (CmbCompanyCode.SelectedItem.Equals("Company Name"))
            {
                dt = objBAL.GetPublicApplicationIssue("", CmbCustCode.Text);
            }
            else if (CmbCompanyCode.SelectedItem.Equals("Cust Code"))
            {
                dt = objBAL.GetPublicApplicationIssue(CmbCustCode.Text, "");
            }
            else if (CmbCompanyCode.SelectedItem.Equals("Code and Company"))
            {
                dt = objBAL.GetPublicApplicationIssue(CmbCustCode.Text, CmbCompany.Text);
            }

            objrpt.SetDataSource(dt);
            GetCommonInfo();
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                               "IPO Application for public issue";
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                _CommpanyName;
            ///// Load Branch Name
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            viewer.crystalReportViewer1.ReportSource = objrpt;
            viewer.Show();
        }
        private void GetCommonInfo()
        {

            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyInfo();

                if (drCommonInfo != null)
                {
                    _CommpanyName = drCommonInfo.Table.Rows[0][0].ToString();
                    _branchName = drCommonInfo.Table.Rows[0][1].ToString();
                    _branchAddress = drCommonInfo.Table.Rows[0][2].ToString();
                    _branchContactNumber = drCommonInfo.Table.Rows[0][3].ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CmbCompanyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPOProcessBAL process = new IPOProcessBAL();
            if (CmbCompanyCode.SelectedIndex == 0)
            {                
                DataTable dtCust = new DataTable();
                dtCust = objBAL.GetCustCode();
                CmbCustCode.DataSource = dtCust;
                CmbCustCode.DisplayMember = dtCust.Columns[0].ToString();
                CmbCustCode.ValueMember = dtCust.Columns[0].ToString();
                CmbCompany.Enabled = false;
                CmbCompany.Text = "";
            }
            else if (CmbCompanyCode.SelectedIndex == 1)
            {
                DataTable dtprocess = new DataTable();
                dtprocess = process.GetIPOSessionALL();
                CmbCustCode.DataSource = dtprocess;
                CmbCustCode.DisplayMember = dtprocess.Columns["Company_Name"].ToString();
                CmbCustCode.ValueMember = dtprocess.Columns["ID"].ToString();
                CmbCompany.Enabled = false;
                CmbCompany.Text = "";
            }
            else if(CmbCompanyCode.SelectedIndex==2)
            {
                DataTable dtCust = new DataTable();
                dtCust = objBAL.GetCustCode();
                CmbCustCode.DataSource = dtCust;
                CmbCustCode.DisplayMember = dtCust.Columns[0].ToString();
                CmbCustCode.ValueMember = dtCust.Columns[0].ToString();
                DataTable dtprocess = new DataTable();
                dtprocess = process.GetIPOSessionALL();
                CmbCompany.DataSource = dtprocess;
                CmbCompany.DisplayMember = dtprocess.Columns["Company_Name"].ToString();
                CmbCompany.ValueMember = dtprocess.Columns["ID"].ToString();
                CmbCompany.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbCustCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (cmbSelectSignature.SelectedItem.Equals("Signature"))
                {                    
                        PrintWithSignature();                    
                }
                //else
                //{
                //    //PrinTwithoutSignature();
                //}
            }
        }
    }
}
