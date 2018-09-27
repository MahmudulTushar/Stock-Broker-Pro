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
    public partial class DematUpload : Form
    {
        public DematUpload()
        {
            InitializeComponent();
        }
        private void UploadProcess()
        {
            DataTable dematDataTable = null;
            dematDataTable = ProcessDematFile(txtFileLocation.Text);
            DematBAL dematBal = new DematBAL();
            dematBal.TruncateDematTemp();
            dematBal.SaveProcessedDematInfo(dematDataTable, "SBP_16DP61UX");
        }

        private DataTable ProcessDematFile(string filePath)
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
                values[4] = values[4].Substring(8, 8);
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
                    DateTime dematDate = GetDematDateFromFile();
                    CommonBAL commonBal = new CommonBAL();
                    if (commonBal.IsUpload(dematDate, "16DP61UX"))
                    {
                        MessageBox.Show("This Demat File has allready imported.");
                        return;
                    }
                    else
                    {
                        UploadProcess();
                        DematIssueAmount dematIssueAmount = new DematIssueAmount();
                        dematIssueAmount.Show();
                        this.Hide();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error Occured." + exc.Message);
                }

            }
        }

        private DateTime GetDematDateFromFile()
        {
            char proChar = '~';
            StreamReader streamReader = new StreamReader(txtFileLocation.Text);
            string[] values = streamReader.ReadLine().Split(proChar);
            DateTime dematDate = Convert.ToDateTime(values[20]);
            return dematDate;
        }

        private bool ValidateFeild()
        {
            if (txtFileLocation.Text.Length.Equals(0))
            {
                MessageBox.Show("Demat File location is a required field.");
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
