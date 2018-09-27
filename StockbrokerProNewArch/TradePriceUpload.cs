using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class TradePriceUpload : Form
    {
        public static DateTime tradeDate;
        public TradePriceUpload()
        {
            InitializeComponent();
        }
        private void UploadProcess()
        {
            DataTable tradepriceDataTable;
            tradepriceDataTable = ProcessTradeFile(txtFileLocation.Text);
            TradePriceBAL tradePriceBal = new TradePriceBAL();
            tradePriceBal.TruncateTradePriceInfo();
            tradePriceBal.SaveProcessedTradeInfo(tradepriceDataTable, "SBP_Trade_Price_Temp");
        }
        private DataTable ProcessTradeFile(string filePath)
        {
            string lineText;
            string[] tempValue;
            char proChar = ',';
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
                dataRow.ItemArray = values;
                dataTable.Rows.Add(dataRow);
                lineText = streamReader.ReadLine();
            } while (lineText != null);
            return dataTable;
        }


        private void btnStartImport_Click(object sender, EventArgs e)
        {
            if (ValidateFeild())
            {
                try
                {
                    tradeDate = dtTradeDate.Value;
                    CommonBAL commonBal = new CommonBAL();
                    if (commonBal.IsUpload(tradeDate, "tradePrice"))
                    {
                        MessageBox.Show("These Data File has allready imported.");
                        return;
                    }
                    else
                    {

                        UploadProcess();
                        TradePriceProcess tradePriceProcess = new TradePriceProcess();
                        //tradeFileProcess.MdiParent = this.Parent;
                        tradePriceProcess.Show();
                        this.Hide();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error Occured." + exc.Message);
                }
                  
            }
        }
     private bool ValidateFeild()
        {
            if (txtFileLocation.Text.Length.Equals(0))
            {
                MessageBox.Show("Trading Price File location is a required field.");
                return false;
            }
            return true;
        }

     private void btnFileLocationBrowser_Click(object sender, EventArgs e)
     {
         if (ofdFileOpen.ShowDialog() == DialogResult.OK)
             txtFileLocation.Text = ofdFileOpen.FileName;
     }
    }
}
