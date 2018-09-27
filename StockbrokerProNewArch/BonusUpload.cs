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
    public partial class BonusUpload : Form
    {
        public BonusUpload()
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
            DataTable bonusRightDataTable = null;
            bonusRightDataTable = ProcessBonusFile(txtFileLocation.Text);
            BonusBAL bonusBal = new BonusBAL();
            bonusBal.TruncateBonusTemp();
            bonusBal.SaveProcessedBonusRightShare(bonusRightDataTable, "SBP_17DP70UX");
          
            DataTable LockInShareTable = null;           
            LockInShareTable = ProcessLockInFile(txtFileLocation.Text);        
          
            LockInShareBAL lockInShareBal = new LockInShareBAL();
            lockInShareBal.TruncateIPOTemp();
            lockInShareBal.SaveProcessedLockInShareInfo(LockInShareTable, "SBP_16DPB7UX");
            lockInShareBal.SaveIntoShareDW();

        }
        private DataTable ProcessBonusFile(string filePath)
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
                if (Convert.ToDecimal(values[15]) == 0)
                {

                    dataRow = dataTable.NewRow();
                    if (values[7].Trim().Length == 0)
                        values[7] = null;
                    values[10] = values[10].Substring(8, 8);
                    dataRow.ItemArray = values;
                    dataTable.Rows.Add(dataRow);

                }
                lineText = streamReader.ReadLine();
            } while (lineText != null);

            return dataTable;
        }


        private DataTable ProcessLockInFile(string filePath)
        {
            string lineText;
            string[] tempValue;
            char proChar = '~';
            StreamReader streamReader = new StreamReader(filePath);
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            lineText = streamReader.ReadLine();
            tempValue = lineText.Split(proChar);

            for (int i = 0; i < 9; ++i)
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
                string[] result = null;
                string[] values = lineText.Split(proChar);
                dataRow = dataTable.NewRow();
                values[10] = values[10].Substring(8, 8);

                if (Convert.ToDecimal(values[15]) > 0)
                {
                    dataRow[0] = values[10];
                    dataRow[1] = values[11];
                    dataRow[2] = values[0];
                    dataRow[3] = values[1];
                    dataRow[4] = values[15];
                    dataRow[5] = values[5];
                    dataRow[6] = values[17];
                    dataRow[7] = values[5];
                    dataRow[8] = values[6];
                    //dataRow.ItemArray = values;
                    dataTable.Rows.Add(dataRow);
                    break;
                }
                lineText = streamReader.ReadLine();
            } while (lineText != null);

            return dataTable;
        }

        //private DataTable ProcessBonusFile(string filePath)
        //{
        //    string lineText;
        //    string[] tempValue;
        //    char proChar = '~';
        //    StreamReader streamReader = new StreamReader(filePath);
        //    DataTable dataTable = new DataTable();
        //    DataRow dataRow;

        //    lineText = streamReader.ReadLine();
        //    tempValue = lineText.Split(proChar);

        //    for (int i = 0; i < tempValue.Length; ++i)
        //    {
        //        dataTable.Columns.Add(new DataColumn());
        //    }

        //    do
        //    {
        //        string[] values = lineText.Split(proChar);
        //        dataRow = dataTable.NewRow();
        //        if (values[7].Trim().Length == 0)
        //            values[7] = null;
        //        values[10] = values[10].Substring(8, 8);
        //        dataRow.ItemArray = values;
        //        dataTable.Rows.Add(dataRow);
        //        lineText = streamReader.ReadLine();
        //    } while (lineText != null);

        //    return dataTable;
        //}
        private void btnStartImport_Click(object sender, EventArgs e)
        {
            if (ValidateFeild())
            {
                try
                {
                    DateTime tradeDate = GetTradeDateFromFile();
                    CommonBAL commonBal = new CommonBAL();
                    //if (commonBal.IsUpload(tradeDate, "17DP70UX_Bonus"))
                    //{
                    //    MessageBox.Show("This Bonus Share File has allready imported.");
                    //    return;
                    //}
                    //else
                    {
                        UploadProcess();
                        BonusIssuePrice issueAmountEntry = new BonusIssuePrice();
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
                MessageBox.Show("Bonus Share File location is a required field.");
                return false;
            }
            return true;
        }

    }
}
