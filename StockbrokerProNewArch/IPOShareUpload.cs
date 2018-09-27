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
    public partial class IPOShareUpload : Form
    {
        public IPOShareUpload()
        {
            InitializeComponent();
        }
        
        private void UploadProcess()
        {
            DataTable ipoShareDataTable = null;
            ipoShareDataTable = ProcessIPOFile(txtFileLocation.Text);
            IPOShareBAL ipoShareBal = new IPOShareBAL();
            ipoShareBal.TruncateIPOTemp();
            ipoShareBal.SaveProcessedIPOShareInfo(ipoShareDataTable, "SBP_16DP95UX");
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
                values[4]=values[4].Substring(8, 8);
                //values[8] = DateTime.ParseExact(values[8], "dd-MM-yyyy", null).ToShortDateString();  
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
                    if (commonBal.IsUpload(tradeDate, "16DP95UX"))
                    {
                        MessageBox.Show("This IPO File has allready imported.");
                        return;
                    }
                    else
                    {
                        UploadProcess();
                        IPOIssuePriceEntry issueAmountEntry = new IPOIssuePriceEntry();
                        issueAmountEntry.Show();
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
            DateTime tradeDate = Convert.ToDateTime(values[3]);
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

        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }
    }
}
