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
    public partial class frmIPODailyReport : Form
    {
        public frmIPODailyReport()
        {
            InitializeComponent();
        }
        IPOProcessBAL Bal = new IPOProcessBAL();
        IPOReportBAL bal = new IPOReportBAL();
        string MoneyTransactionTypeName = "";
        string StatusName = "";
        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
         
        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            CrIpoDailyReport crRpt = new CrIpoDailyReport();
            crIPODepositSummaryInfo crSummary = new crIPODepositSummaryInfo();
            frmIPOReportViewer viewer = new frmIPOReportViewer();
            if (cmbMoneyTransacitonType.Text=="ALL")
            {
                MoneyTransactionTypeName = "";
            }
            else
            {
                MoneyTransactionTypeName = cmbMoneyTransacitonType.Text;
            }
            if (CmbtransactionStatus.Text=="ALL")
            {
                StatusName = "";
            }
            else
            {
                StatusName =Convert.ToString(CmbtransactionStatus.SelectedValue);
            }
            if (rdbDailyIPOFullReport.Checked)
            {
                if (ChkCompanySelection.Checked)
                {
                    dt = bal.GetDailyTransactionReport(null, null, MoneyTransactionTypeName, StatusName, Convert.ToString(CmbsessionName.SelectedValue));
                }
                else
                {
                    dt = bal.GetDailyTransactionReport(dtpFormdate.Value.Date, dtpTodate.Value.Date, MoneyTransactionTypeName, StatusName, "");
                }
                crRpt.SetDataSource(dt);
                GetCommonInfo();

                ((TextObject)crRpt.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text =
                    _CommpanyName;
                ///// Load Branch Name
                ((TextObject)crRpt.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text =
                    "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                viewer.crystalReportViewer1.ReportSource = crRpt;
            }
            else
            {
                dt = bal.GetIPODepositSummaryInfo(Convert.ToString(CmbsessionName.SelectedValue));
                crSummary.SetDataSource(dt);
                viewer.crystalReportViewer1.ReportSource = crSummary;
            }
            
            viewer.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombo()
        {
            DataTable dtTransacitonType = new DataTable();
            DataTable dtStatusName = new DataTable();
            //Transaction Type Name
            dtTransacitonType = bal.GetMoneyTransactionTypeName();
            cmbMoneyTransacitonType.DataSource = dtTransacitonType;
            cmbMoneyTransacitonType.DisplayMember = dtTransacitonType.Columns["MoneyTransType_Name"].ToString();
            cmbMoneyTransacitonType.ValueMember = dtTransacitonType.Columns["ID"].ToString();


            dtStatusName = bal.GetTransactionStatus();
            CmbtransactionStatus.DataSource = dtStatusName;
            CmbtransactionStatus.DisplayMember = dtStatusName.Columns["Status_Name"].ToString();
            CmbtransactionStatus.ValueMember = dtStatusName.Columns["ID"].ToString();

            

        }

        private void frmIPODailyReport_Load(object sender, EventArgs e)
        {
            LoadCombo();
            cmbMoneyTransacitonType.SelectedIndex = 0;
            CmbtransactionStatus.SelectedIndex = 0;
            CmbsessionName.Enabled = false;
            rdbIPODepositSummary.Checked = true;
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

        private void ChkCompanySelection_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCompanySelection.Checked)
            {
                CmbsessionName.Enabled = true;
                DataTable dt = new DataTable();
                dt = Bal.GetCompanyShortCodeAndSessionID();
                CmbsessionName.DataSource = dt;
                CmbsessionName.DisplayMember = dt.Columns["Code"].ToString();
                CmbsessionName.ValueMember = dt.Columns["ID"].ToString();

                //this.dtpFormdate.MinDate = DateTime.MaxValue;
                this.dtpTodate.CustomFormat = "";
                dtpFormdate.Enabled = false;
                dtpTodate.Enabled = false;
                
                
            }
            else
            {
                CmbsessionName.Enabled = false;
                CmbsessionName.Text = "";
                dtpFormdate.Enabled = true;
                dtpTodate.Enabled = true;
                
            }
        }
        
    }
}
