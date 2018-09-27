using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.IO;

namespace StockbrokerProNewArch
{
    public partial class frmBoCloseProcess : Form
    {
        private BOCloseBAL BOCloseBAL = new BOCloseBAL();
        private int progessvalue = 0;

        public frmBoCloseProcess()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
      

        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }


        private void UploadProcess()
        {
            DataTable bonusRightDataTable = null;
            bonusRightDataTable = ProcessRightFile(txtFileLocation.Text);
            List<string> List_Bo_ID = bonusRightDataTable.Rows.Cast<DataRow>().Select(t => t["Column1"].ToString()).ToList();            
            BOCloseBAL.All_CDBLClose_To_SBP_CustCode_Close(List_Bo_ID.ToArray());
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
             DialogResult dialogResult = MessageBox.Show("Are You Sure.Close All Account.", "Information!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
             if (dialogResult == DialogResult.Yes)
             {
                 UploadProcess();
                 MessageBox.Show("Cust Code Close successfully.", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
        }

        private DataTable ProcessRightFile(string filePath)
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
                //if (values[7].Trim().Length == 0)
                //    values[7] = null;
                values[0] = values[0].Substring(8, 8);
                dataRow.ItemArray = values;
                dataTable.Rows.Add(dataRow);
                lineText = streamReader.ReadLine();
            } while (lineText != null);

            return dataTable;
        }
    }
}
