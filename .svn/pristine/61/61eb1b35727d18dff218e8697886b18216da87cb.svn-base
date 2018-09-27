using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class PayInProcessOld : Form
    {
        public PayInProcessOld()
        {
            InitializeComponent();
        }

        private void btnGeneratePayInFile_Click(object sender, EventArgs e)
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                DataTable datatable = tradeFileBal.GetPayInDataOld();
                if (datatable.Rows.Count > 0)
                {
                    Export2Excel(datatable);
                }
                else
                {
                    MessageBox.Show("No Data for export.");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occured." + exc.Message);
            }
        }

        private void btnGeneratePayOutFile_Click(object sender, EventArgs e)
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                DataTable datatable = tradeFileBal.GetPayOutDataOld();
                if (datatable.Rows.Count > 0)
                {
                    Export2Excel(datatable);
                }
                else
                {
                    MessageBox.Show("No Data for export.");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occured." + exc.Message);
            }
        }
        private void Export2Excel(DataTable dataTable)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;
            string data = null;
            string sFileName = null;

            for (j = 0; j < dataTable.Columns.Count; j++)
            {
                xlWorkSheet.Cells[1, j + 1] = dataTable.Columns[j].ColumnName;
            }
            for (i = 0; i <= dataTable.Rows.Count - 1; i++)
            {
                for (j = 0; j <= dataTable.Columns.Count - 1; j++)
                {
                    data = dataTable.Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                }
            }
            SaveFileDialog oDialog = new SaveFileDialog();
            oDialog.Filter = "Excel files | *.xls";
            if (oDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = oDialog.FileName;
            }

            if (sFileName != null)
            {
                xlWorkBook.SaveAs(sFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                MessageBox.Show("Report saved with file: " + sFileName, "To Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                //oEXLApp.ActiveWorkbook.Close(false, Missing.Value, Missing.Value);
                MessageBox.Show("Cannot export to excel...", "Cann't export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
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

        private void PayInProcessOld_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            PayInTradeBAL tradeFileBal = new PayInTradeBAL();
            DataTable datatable = tradeFileBal.GetGridData();
            dtgTradeFile.DataSource = datatable;
            dtgTradeFile.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void ValidateCustCode()
        {
            try
            {
                PayInTradeBAL tradeBal = new PayInTradeBAL();
                DataTable custCodeDataTable = new DataTable();
                custCodeDataTable = tradeBal.ValidateCustCodeOld();
                if (custCodeDataTable.Rows.Count > 0)
                {
                    lbCustCodeError.Items.Clear();
                    for (int i = 0; i < custCodeDataTable.Rows.Count; i++)
                    {
                        lbCustCodeError.Items.Add(custCodeDataTable.Rows[i]["Customer"]);

                    }
                }
                else
                {
                    lbCustCodeError.Items.Clear();

                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Customer Code Validation Error. " + exc.Message);
            }
        }

        private void ValidateCompany()
        {
            try
            {
                PayInTradeBAL tradeBal = new PayInTradeBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = tradeBal.ValidateCompanyOld();
                if (companyDataTable.Rows.Count > 0)
                {
                    lbCompShortCodeError.Items.Clear();
                    for (int i = 0; i < companyDataTable.Rows.Count; i++)
                    {
                        lbCompShortCodeError.Items.Add(companyDataTable.Rows[i]["InstrumentCode"]);

                    }
                }
                else
                {
                    lbCompShortCodeError.Items.Clear();
                }

            }

            catch (Exception exc)
            {

                MessageBox.Show("Company Validation Error." + exc.Message);
            }

        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheck_Click_1(object sender, EventArgs e)
        {
            ValidateCustCode();
            ValidateCompany();
            if (lbCustCodeError.Items.Count == 0 && lbCompShortCodeError.Items.Count == 0)
            {
                btnGeneratePayOutFile.Enabled = true;
                btnGeneratePayInFile.Enabled = true;
            }
            else
            {

                Height = 482;
            }

        }

      
    }
}
