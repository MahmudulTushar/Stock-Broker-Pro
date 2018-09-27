using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class IPOIssuePriceEntry : Form
    {
        public IPOIssuePriceEntry()
        {
            InitializeComponent();
        }

        private void IPOIssuePriceEntry_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void LoadGridData()
        {
            IPOShareBAL ipoShareBal = new IPOShareBAL();
            DataTable datatable = ipoShareBal.GetGridIssueAmount();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = datatable;
            dtgIssuePrice.DataSource = bSource;
            dtgIssuePrice.Columns[0].ReadOnly = true;
            dtgIssuePrice.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                IPOShareBAL ipoShareBal = new IPOShareBAL();
                if (ValidIssuePrice())
                {
                    for (int i = 0; i < dtgIssuePrice.Rows.Count; i++)
                    {
                        string issnNo = string.Empty;
                        string companyName = string.Empty;
                        float issuePrice = 0;
                        issnNo = dtgIssuePrice["ISIN No", i].Value.ToString();
                        companyName = dtgIssuePrice["Company Name", i].Value.ToString();
                        issuePrice = float.Parse(dtgIssuePrice["Issue Price", i].Value.ToString());
                        ipoShareBal.UpdateIssueAmount(issnNo, issuePrice);
                    }
                    IPOShareProcess ipoShareProcess = new IPOShareProcess();
                    ipoShareProcess.Show();
                    this.Hide();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Issue Price has not inserted. Error: " + exc.Message);
            }
        }
        private bool ValidIssuePrice()
        {
            for (int i = 0; i < dtgIssuePrice.Rows.Count; i++)
            {
                string companyName = "";
                companyName = dtgIssuePrice[0, i].Value.ToString();
                if (dtgIssuePrice[1, i].Value == DBNull.Value)
                {
                    MessageBox.Show("Please Insert the Issue Price of " + companyName);
                    return false;
                }
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
