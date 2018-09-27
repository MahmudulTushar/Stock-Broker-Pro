using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class TradePriceProcess : Form
    {
        public TradePriceProcess()
        {
            InitializeComponent();
        }

       
        private void ValidateCompany()
        {
            try
            {
                TradePriceBAL tradePriceBal = new TradePriceBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = tradePriceBal.ValidateCompany();
                if (companyDataTable.Rows.Count > 0)
                {
                    lbComapnyName.Items.Clear();
                    for (int i = 0; i < companyDataTable.Rows.Count; i++)
                    {
                        lbComapnyName.Items.Add(companyDataTable.Rows[i]["Instrument_Code"]);

                    }
                }
                else
                {
                    lbComapnyName.Items.Clear();
                }

            }

            catch (Exception exc)
            {

                MessageBox.Show("Company Validation Error." + exc.Message);
            }

        }

       
      

        private void LoadDataIntoGrid()
        {
            TradePriceBAL tradePriceBal = new TradePriceBAL();
            DataTable datatable = tradePriceBal.GetGridData();
            dtgTradeFile.DataSource = datatable;
            dtgTradeFile.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void TradePriceImport_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void btnProcess_Click_1(object sender, EventArgs e)
        {
            try
            {
                TradePriceBAL tradePriceBal = new TradePriceBAL();
                tradePriceBal.SaveIntoTradePrice(TradePriceUpload.tradeDate);
                MessageBox.Show("Trade Price Data imported successfully.");
                this.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Transaction Data import operation failed. " + exc.Message);
            }

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ValidateCompany();
            if (lbComapnyName.Items.Count == 0)
            {
                btnProcess.Enabled = true;
            }
            else
            {

                Height = 482;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
