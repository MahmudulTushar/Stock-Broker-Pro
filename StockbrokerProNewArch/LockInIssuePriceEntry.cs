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
    public partial class LockInIssuePriceEntry : Form
    {
        public LockInIssuePriceEntry()
        {
            InitializeComponent();
        }

        private void LockInIssuePriceEntry_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }

        private void LoadGridData()
        {
            LockInShareBAL lockInShareBal = new LockInShareBAL();
            DataTable datatable = lockInShareBal.GetGridIssueAmount();
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
                LockInShareBAL lockInShareBal = new LockInShareBAL();
                if (ValidIssuePrice())
                {
                    for (int i = 0; i < dtgIssuePrice.Rows.Count; i++)
                    {
                        string companyName = "";
                        float issuePrice = 0;
                        companyName = dtgIssuePrice[0, i].Value.ToString();
                        issuePrice = float.Parse(dtgIssuePrice[1, i].Value.ToString());
                        lockInShareBal.UpdateIssueAmount(companyName, issuePrice);
                    }
                    LockInShareProcess lockInShareProcess = new LockInShareProcess();
                    lockInShareProcess.Show();
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
