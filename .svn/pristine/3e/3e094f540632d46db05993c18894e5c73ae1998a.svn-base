using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BusinessAccessLayer.BAL;
using Microsoft.Office.Interop;

namespace StockbrokerProNewArch
{
    public partial class ExportDataForIssuer : Form
    {
        public ExportDataForIssuer()
        {
            InitializeComponent();
        }

        private void BtndataforIssuer_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Writexcel(DataTable dt)
        {
            string data = null;
            SaveFileDialog oDialog = new SaveFileDialog();
            oDialog.Filter = "Text files | *.xls";
            if (oDialog.ShowDialog() == DialogResult.OK)
            {
                data = oDialog.FileName;
            }

            if (data != null)
            {
                int i = 0;
                int j = 0;

                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);




                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    for (j = 0; j <= dt.Columns.Count - 1; j++)
                    {
                        data = dt.Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 1, j + 1] = data;
                    }
                }

                xlWorkBook.SaveAs("csharp.net-informations.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");

            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
