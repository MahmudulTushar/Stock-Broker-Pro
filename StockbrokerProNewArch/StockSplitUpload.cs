using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class StockSplitUpload : Form
    {
        public StockSplitUpload()
        {
            InitializeComponent();
        }

        private void UploadProcess()
        {
            DataTable stockSplitDataTable = null;
            stockSplitDataTable = ProcessIPOFile(txtFileLocation.Text);
            StockSplitBAL splitBal = new StockSplitBAL();
            splitBal.TruncateBonusTemp();
            splitBal.SaveProcessedStockSplit(stockSplitDataTable, "SBP_17DP70UX");

        }


        private DataTable ProcessIPOFile(string filePath)
        {
            string lineText;
            string[] tempValue;
            char proChar = '~';
            StreamReader streamReader = new StreamReader(filePath);
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            lineText = streamReader.ReadLine();
            tempValue = lineText.Split(proChar);

            for (int i = 0; i < tempValue.Length; ++i)
            {
                dataTable.Columns.Add(new DataColumn());
            }

            do
            {
                string[] values = lineText.Split(proChar);
                dataRow = dataTable.NewRow();
                if (values[7].Trim().Length == 0)
                    values[7] = null;
                values[10] = values[10].Substring(8, 8);
                dataRow.ItemArray = values;
                dataTable.Rows.Add(dataRow);
                lineText = streamReader.ReadLine();
            } while (lineText != null);

            return dataTable;
        }

        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {

            if (ValidateFeild())
            {
                try
                {
                    DateTime tradeDate = GetTradeDateFromFile();
                    CommonBAL commonBal = new CommonBAL();
                    if (commonBal.IsUpload(tradeDate, "17DP70UX_StockSplit"))
                    {
                        MessageBox.Show("This Stock Split File has allready imported.");
                        return;
                    }

                    else
                    {
                        UploadProcess();
                        StockSplitIssueAmount stockSplitIssueAmount = new StockSplitIssueAmount();
                        stockSplitIssueAmount.Show();
                        this.Hide();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error Occured." + exc.Message);
                }
            }
        }

        private DateTime GetTradeDateFromFile()
        {
            char proChar = '~';
            StreamReader streamReader = new StreamReader(txtFileLocation.Text);
            string[] values = streamReader.ReadLine().Split(proChar);
            DateTime tradeDate = Convert.ToDateTime(values[5]);
            return tradeDate;
        }

        private bool ValidateFeild()
        {
            if (txtFileLocation.Text.Length.Equals(0))
            {
                MessageBox.Show("IPO Share File location is a required field.");
                return false;
            }
            return true;
        }
    }
}
