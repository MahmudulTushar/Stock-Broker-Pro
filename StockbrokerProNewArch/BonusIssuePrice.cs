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
    public partial class BonusIssuePrice : Form
    {
        public BonusIssuePrice()
        {
            InitializeComponent();
        }

        private void BonusIssuePrice_Load(object sender, EventArgs e)
        {

            LoadGridData();
        }
        private void LoadGridData()
        {
            BonusBAL bonusBal = new BonusBAL();
            DataTable datatable = bonusBal.GetGridIssueAmount();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = datatable;
            dtgIssuePrice.DataSource = bSource;
            dtgIssuePrice.Columns[0].ReadOnly = true;
            dtgIssuePrice.Columns[1].ReadOnly = true;
            dtgIssuePrice.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                BonusBAL bonusBal = new BonusBAL();
                if (ValidIssuePrice())
                {
                    for (int i = 0; i < dtgIssuePrice.Rows.Count; i++)
                    {
                        string companyName = "";
                        float issuePrice = 0;
                        companyName = dtgIssuePrice[0, i].Value.ToString();
                        issuePrice = float.Parse(dtgIssuePrice[2, i].Value.ToString());
                        bonusBal.UpdateIssueAmount(companyName, issuePrice);
                    }
                    BonusShareProcess bonusShareProcess = new BonusShareProcess();
                    bonusShareProcess.Show();
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
                if (dtgIssuePrice[2, i].Value == DBNull.Value)
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
