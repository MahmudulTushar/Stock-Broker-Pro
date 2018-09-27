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
    public partial class StockSplitIssueAmount : Form
    {
        public StockSplitIssueAmount()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StockSplitIssueAmount_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            StockSplitBAL splitBal = new StockSplitBAL();
            DataTable datatable = splitBal.GetGridIssueAmount();
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
                StockSplitBAL stockSplitBal = new StockSplitBAL();
                if (ValidIssuePrice())
                {
                    for (int i = 0; i < dtgIssuePrice.Rows.Count; i++)
                    {
                        string companyName = "";
                        float issuePrice = 0;
                        companyName = dtgIssuePrice[0, i].Value.ToString();
                        issuePrice = float.Parse(dtgIssuePrice[2, i].Value.ToString());
                        stockSplitBal.UpdateIssueAmount(companyName, issuePrice);
                    }
                    StockSplitProcess splitProcess = new StockSplitProcess();
                    splitProcess.Show();
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
            float qty;
            bool statu = true;

            for (int i = 0; i < dtgIssuePrice.Rows.Count; i++)
            {
                string companyName = "";
                companyName = dtgIssuePrice[0, i].Value.ToString();
                if (dtgIssuePrice[2, i].Value.ToString().Trim().Equals(""))
                {
                    MessageBox.Show("Please Insert Split Value of " + companyName);
                    statu = false;
                }

                else if(float.TryParse(dtgIssuePrice[2, i].Value.ToString(),out qty)==false)
                {
                    MessageBox.Show(CompanyName+" Split Qty Must be Numeric.","Split Qty",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    statu = false;
                }

            }

            return statu;
        }
    }
}
