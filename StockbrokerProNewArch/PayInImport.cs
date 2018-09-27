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
    public partial class PayInImport : Form
    {
        public PayInImport()
        {
            InitializeComponent();
        }
        private void UploadProcess()
        {
            DataTable tradeDataTable;
            tradeDataTable = ProcessTradeFile(txtFileLocation.Text);
            PayInTradeBAL tradeBal = new PayInTradeBAL();
            tradeBal.TruncateTradeInfo();
            tradeBal.SaveProcessedTradeInfo(tradeDataTable, "SBP_Trade_Temp");
        }

        private DataTable ProcessTradeFile(string filePath)
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
                //values[8] = DateTime.ParseExact(values[8], "dd-MM-yyyy", null).ToShortDateString();  
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
                    UploadProcess();
                    PayInProcess payInProcess = new PayInProcess();
                    payInProcess.Show();
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

    }
}
