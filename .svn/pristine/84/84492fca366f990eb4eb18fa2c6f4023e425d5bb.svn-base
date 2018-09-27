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
    public partial class BOCloseUpload : Form
    {
        public BOCloseUpload()
        {
            InitializeComponent();
        }
        public void UploadProcess(string filePath)
        {
            DataTable BOCloseDataTable = null;
            BOCloseDataTable = ProcessIPOFile(filePath);
            BOCloseBAL boCloseBal = new BOCloseBAL();
            boCloseBal.TruncatBOCloseTemp();
            boCloseBal.SaveProcessedBOCloseInfo(BOCloseDataTable, "SBP_08DP04UX");
        }

        public DataTable ProcessIPOFile(string filePath)
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


        private void btnStartImport_Click(object sender, EventArgs e)
        {

            if (ValidateFeild())
            {
                try
                {
                    DateTime boCloseDate = GetBOCloseDateFromFile();
                    CommonBAL commonBal = new CommonBAL();
                    if (commonBal.IsUpload(boCloseDate, "08DP04UX"))
                    {
                        MessageBox.Show("This BO Close File has allready imported.");
                        return;
                    }
                    else
                    {
                        UploadProcess(txtFileLocation.Text);
                        BOCloseProcess boCloseProcess = new BOCloseProcess();
                        boCloseProcess.Show();
                        this.Hide();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error Occured." + exc.Message);
                }

            }
        }
        private DateTime GetBOCloseDateFromFile()
        {
            char proChar = '~';
            StreamReader streamReader = new StreamReader(txtFileLocation.Text);
            string[] values = streamReader.ReadLine().Split(proChar);
            DateTime boCloseDate = Convert.ToDateTime(values[6]);
            return boCloseDate;
        }

        private bool ValidateFeild()
        {
            if (txtFileLocation.Text.Length.Equals(0))
            {
                MessageBox.Show("BO Close File location is a required field.");
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
