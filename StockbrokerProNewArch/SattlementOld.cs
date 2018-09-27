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
using StockbrokerProNewArch;

namespace StockbrokerProNewArch
{
    public partial class sattlementOld : Form
    {
        public sattlementOld()
        {
            InitializeComponent();
        }
        private void UploadProcess()
        {
            DataTable tradeDataTable;
            tradeDataTable = ProcessTradeFile(txtFileLocation.Text);
            PayInTradeBAL tradeBal = new PayInTradeBAL();
            tradeBal.TruncateTradeInfoOld();
            tradeBal.SaveProcessedTradeInfoOld(tradeDataTable, "SBP_Trade_Temp_Old");
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
                    UploadProcess();
                    PayInProcessOld payInProcessOld = new PayInProcessOld();
                    payInProcessOld.Show();
                    this.Hide();
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
                MessageBox.Show("Trade File location is a required field.");
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
