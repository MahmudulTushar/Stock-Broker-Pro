using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class ManagementView : Form
    {
        private int _month;
        private int _year;
        public ManagementView()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                LoadManagementInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured." + ex.Message);
            }
            
        }

        private void LoadManagementInfo()
        {
            CommonBAL objBal = new CommonBAL();
            _month = dtmonthYear.Value.Month;
            _year = dtYear.Value.Year;
            ManagementViewBAL managementViewBal = new ManagementViewBAL();
            DataTable dtManagementInfo = new DataTable();
            dtManagementInfo = managementViewBal.GetmanagementBOInfo(_month, _year);
            if (dtManagementInfo.Rows.Count > 0)
            {
                txtTradeAmount.Text = dtManagementInfo.Rows[0]["TotalTradeAmount"].ToString();
                txtCommission.Text = dtManagementInfo.Rows[0]["TotalCommission"].ToString();
                txtHowlaCharge.Text = dtManagementInfo.Rows[0]["TotalHowlaCharge"].ToString();
                txtLagaCharge.Text = dtManagementInfo.Rows[0]["TotalLagaCharge"].ToString();
                txtTax.Text = dtManagementInfo.Rows[0]["TotalTax"].ToString();
                txtNetCommission.Text = dtManagementInfo.Rows[0]["NetCommission"].ToString();
                lblLastTradeDate.Text = dtManagementInfo.Rows[0]["LastTradeDate"].ToString();
                lblCurrentDate.Text = Convert.ToString(objBal.GetCurrentServerDate());
                lblComapnyAccount.Text = dtManagementInfo.Rows[0]["CompanyAccount"].ToString();
                lblInterestAccount.Text = dtManagementInfo.Rows[0]["InterestAccount"].ToString();
                lblResult.Text = dtManagementInfo.Rows[0]["Result"].ToString();
                lblPossitiveBalance.Text = dtManagementInfo.Rows[0]["PossitiveBalance"].ToString();
                lblNegetiveBalance.Text = dtManagementInfo.Rows[0]["NegetiveBalance"].ToString();
                lblCustomerBalance.Text = dtManagementInfo.Rows[0]["CustomerBalance"].ToString();
                lblBankBalance.Text = dtManagementInfo.Rows[0]["BankBalance"].ToString();

            }
        }

        private void ManagementView_Load(object sender, EventArgs e)
        {

        }
    }
}
