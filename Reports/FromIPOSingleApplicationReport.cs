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
    public partial class FromIPOSingleApplicationReport : Form
    {
        public FromIPOSingleApplicationReport()
        {
            InitializeComponent();
        }
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        IPOApplicationSuccessfulUnSuccessful objBAL = new IPOApplicationSuccessfulUnSuccessful();
        BrokerInfoBAL brBal = new BrokerInfoBAL();
        private void loadStatusNmae()
        {
            IPOProcessBAL process = new IPOProcessBAL();
            DataTable dt = new DataTable();
            dt = objBAL.GetIpoStatusNmae();
            cmbStatusName.DataSource = dt;
            cmbStatusName.DisplayMember = dt.Columns[0].ToString();
            cmbStatusName.ValueMember = dt.Columns[0].ToString();

            DataTable dtallSession = new DataTable();
            dtallSession = process.GetIPOSessionALL();
            CmbCompanyName.DataSource = dtallSession;
            CmbCompanyName.DisplayMember = dtallSession.Columns["Company_Name"].ToString();
            CmbCompanyName.ValueMember = dtallSession.Columns["ID"].ToString();

            DataTable dtbranch = new DataTable();
            dtbranch = brBal.GetBrokerBranchName();
            cmbBranchName.DataSource = dtbranch;
            cmbBranchName.DisplayMember = dtbranch.Columns["Branch_Name"].ToString();
            cmbBranchName.ValueMember = dtbranch.Columns["Branch_ID"].ToString();


        }

        private void FromIPOSingleApplicationReport_Load(object sender, EventArgs e)
        {
            loadStatusNmae();
            if (cmbStatusName.Items.Count > 0)
            {
                cmbStatusName.SelectedIndex = 0;
            }
            if (CmbCompanyName.Items.Count > 0)
            {
                CmbCompanyName.SelectedIndex = 0;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsingleReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string StatusName =Convert.ToString(cmbStatusName.Text);
            string CompanyName = Convert.ToString(CmbCompanyName.SelectedValue);
            int branchId = (int)cmbBranchName.SelectedValue;
            dt = objBAL.IPOSingleApplicationReport(dtpstartdate.Value, dtpenddate.Value, StatusName, CompanyName, branchId);
            crIPOSingleApplicationReport objrpt = new crIPOSingleApplicationReport();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            if (dt.Rows.Count > 0)
            {
                objrpt.SetDataSource(dt);
                GetCommonInfo();
                ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text =
                                   "IPO Single Application Status";
                ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ///// Load Branch Name
                ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                viewer.crystalReportViewer1.ReportSource = objrpt;
                viewer.Show();
            }
            else
            {
                MessageBox.Show("Data not found",""+MessageBoxIcon.Error);
            }
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


    }
}
