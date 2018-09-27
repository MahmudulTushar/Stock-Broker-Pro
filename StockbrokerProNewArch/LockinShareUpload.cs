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
    public partial class LockInShareUpload : Form
    {
        public LockInShareUpload()
        {
            InitializeComponent();
        }
        
        private void UploadProcess()
        {
            DataTable ipoShareDataTable = null;
            ipoShareDataTable = ProcessIPOFile(txtFileLocation.Text);
            LockInShareBAL lockInShareBal = new LockInShareBAL();
            lockInShareBal.TruncateIPOTemp();
            lockInShareBal.SaveProcessedLockInShareInfo(ipoShareDataTable, "SBP_16DPB7UX");
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
                //if (i == 4)
                //{
                //    dataTable.Columns.Add(new DataColumn("Lockin_Quantity", typeof(double)));
                //}
                //else
                //{
                    dataTable.Columns.Add(new DataColumn());
                //}
            }
            do
            {
                string[] values = lineText.Split(proChar);
                dataRow = dataTable.NewRow();
                values[0]=values[0].Substring(8, 8);
                //values[4] =values[4];
                //values[8] = DateTime.ParseExact(values[8], "dd-MM-yyyy", null).ToShortDateString();  
                //values[5] = Convert.ToDateTime(values[5]).ToString("MM-dd-yyyy");
                //values[6] = Convert.ToDateTime(values[6]).ToString("MM-dd-yyyy");
                //values[7] = Convert.ToDateTime(values[7]).ToString("MM-dd-yyyy");
                //dataRow[0] = values[0];
                //dataRow[1] = values[1];
                //dataRow[2] = values[2];
                //dataRow[3] = values[3];
                //dataRow[4] = Convert.ToDouble(values[4]);
                //dataRow[5] = Convert.ToDateTime(values[5]);
                //dataRow[6] = Convert.ToDateTime(values[6]);
                //dataRow[7] = Convert.ToDateTime(values[7]);
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
                    if (commonBal.IsUpload(tradeDate, "SBP_16DPB7UX"))
                    {
                        MessageBox.Show("This IPO File has allready imported.");
                        return;
                    }
                    else
                    {
                        UploadProcess();
                        LockInIssuePriceEntry issueAmountEntry = new LockInIssuePriceEntry();
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
            DateTime tradeDate = Convert.ToDateTime(values[5]);
            return tradeDate;
        }

        private bool ValidateFeild()
        {
            if (txtFileLocation.Text.Length.Equals(0))
            {
                MessageBox.Show("LockIn Share File location is a required field.");
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
