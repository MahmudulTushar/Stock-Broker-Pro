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
    public partial class frmIPOTotalMoneyTransactionAfterResults : Form
    {
        IPOReportBAL bal = new IPOReportBAL();
        IPOProcessBAL Pbal = new IPOProcessBAL();
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
       
        public frmIPOTotalMoneyTransactionAfterResults()
        {
            InitializeComponent();
        }

        private void frmIPOTotalMoneyTransactionAfterResults_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            cmbSessionName.SelectedIndex = 0;
            CmbTransactionTypename.SelectedIndex = 0;
        }

        private void LoadComboBox()
        {
            DataTable PaymentName = new DataTable();
            DataTable session = new DataTable();
            PaymentName = bal.LoadMoneyTransactionTypeName();
            CmbTransactionTypename.DataSource = PaymentName;
            CmbTransactionTypename.DisplayMember = PaymentName.Columns["MoneyTransType_Name"].ToString();
            CmbTransactionTypename.ValueMember = PaymentName.Columns["ID"].ToString();

            session = Pbal.GetSessionIdByName();
            cmbSessionName.DataSource = session;
            cmbSessionName.DisplayMember = session.Columns["IPOSession_Name"].ToString();
            cmbSessionName.ValueMember=session.Columns["ID"].ToString();
        }

        private void BtnReportShow_Click(object sender, EventArgs e)
        {
            int SessionId = 0;
            string TransacitonTypeName = "";
            if (cmbSessionName.Items.Count > 0)
            {
                SessionId = (int)cmbSessionName.SelectedValue;
            }
            if (CmbTransactionTypename.Items.Count > 0)
            {
                TransacitonTypeName = CmbTransactionTypename.Text;
            }
            DataTable dt = new DataTable();
            crIPOTotalMoneyTransactionAfterResult objrpt = new crIPOTotalMoneyTransactionAfterResult();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            dt = bal.TotalTransactionstatusAfterResults(TransacitonTypeName, SessionId, dtpFormdae.Value, dtpEndDate.Value);
            objrpt.SetDataSource(dt);
            GetCommonInfo();
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                _CommpanyName;
            ///// Load Branch Name
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtBranchName"]).Text =
                "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
            ((TextObject)objrpt.ReportDefinition.Sections[2].ReportObjects["txtreportName"]).Text = "Total Transaction List With out TRTA after IPO result";
            viewer.crystalReportViewer1.ReportSource = objrpt;
            viewer.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
