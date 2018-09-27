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
    public partial class FinNetting : Form
    {
        public FinNetting()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            
            GetMaturedFund(dtp.Value);
            LoadTernOver(dtp.Value.Month,dtp.Value.Year);
            
        }
        private void GetMaturedFund(DateTime dateTime)
        {
            try
            {
                ReportBAL reportBal = new ReportBAL();
                DataTable data = reportBal.GetNettingSumery(dateTime);
                if (data.Rows.Count > 0)
                {
                    txtMFund.Text = Convert.ToDecimal(data.Rows[0]["MaturedFund"].ToString()).ToString("N");
                    txtImmaturedFund.Text = Convert.ToDecimal(data.Rows[0]["ImmaturedFund"].ToString()).ToString("N");
                    txtTotalBuy.Text = Convert.ToDecimal(data.Rows[0]["TotalBuy"].ToString()).ToString("N");
                }
                else
                {
                    txtMFund.Text = "0";
                    txtImmaturedFund.Text = "0";
                    txtTotalBuy.Text = "0";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void LoadTernOver(int month, int year)
        {
            ReportBAL reportBal = new ReportBAL();
            dgvData.DataSource = reportBal.GetTurnOver(month, year);
            dgvData.Columns[1].DefaultCellStyle.Format = "N";
            dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void FinNetting_Load(object sender, EventArgs e)
        {

        }
    }
}
