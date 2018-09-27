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
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class TradeFileImportOld : Form
    {
        public TradeFileImportOld()
        {
            InitializeComponent();
        }
        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }
        private void UploadProcess()
        {
            DataTable tradeDataTable;
            tradeDataTable = ProcessTradeFile(txtFileLocation.Text);
            TradeOldBAL tradeOldBal = new TradeOldBAL();
            tradeOldBal.TruncateTradeInfo();
            tradeOldBal.SaveProcessedTradeInfoOld(tradeDataTable, "SBP_Transactions_Temp_Old");
            tradeOldBal.TruncateNewTradeInfo();
            tradeOldBal.InsertIntoNewTradeInfo();
        }

        private DataTable ProcessTradeFile(string filePath)
        {
            string lineText;
            string[] tempValue;
            char proChar = '|';
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
                values[8] = CommonMethodBO.GetDateFormat(values[8]).ToShortDateString();
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
                    DateTime tradeDate = GetTradeDateFromFile();
                    CommonBAL commonBal = new CommonBAL();
                    if (commonBal.IsUpload(tradeDate, "tradeFileOld"))
                    {
                        MessageBox.Show("These Data File has allready imported.");
                        return;
                    }
                    else
                    {

                        UploadProcess();
                        TradeFileProcessOld tradeFileProcessOld = new TradeFileProcessOld();
                        //tradeFileProcess.MdiParent = this.Parent;
                        tradeFileProcessOld.Show();
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
            char proChar = '|';
            StreamReader streamReader = new StreamReader(txtFileLocation.Text);
            string[] values = streamReader.ReadLine().Split(proChar);
            DateTime tradeDate = CommonMethodBO.GetDateFormat(values[8]);
            return tradeDate;
        }
        private bool ValidateFeild()
        {
            if (txtFileLocation.Text.Length.Equals(0))
            {
                MessageBox.Show("Trade File location is a required field.");
                return false;
            }
            return true;
        }
    }
}
