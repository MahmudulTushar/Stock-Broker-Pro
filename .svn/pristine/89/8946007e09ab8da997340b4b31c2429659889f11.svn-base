using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class PayInProcess : Form
    {
        public PayInProcess()
        {
            InitializeComponent();
        }

        private void btnGeneratePayInFile_Click(object sender, EventArgs e)
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                DataTable datatable = tradeFileBal.GetPayInData();
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
                DataTable datatable = tradeFileBal.GetPayOutData();
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
                MessageBox.Show("Cannot export to excel...", "Can't export", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PayInProcess_Load(object sender, EventArgs e)
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
        private void btnCheck_Click(object sender, EventArgs e)
        {

            ValidateBOID();
            ValidateCustCode();
            ValidateCustCodeBOID();
            ValidateCompany();
            ValdateISIN();
            ValidateCompanyCategory();
            ValidateGroupMisMatch();
            if (lbCustCodeError.Items.Count == 0 && lbBOError.Items.Count == 0 && lbCodeBOError.Items.Count == 0 && lbCompShortCodeError.Items.Count == 0 && lbISINError.Items.Count == 0 && lbCompanyCatError.Items.Count == 0)
            {
                btnGeneratePayOutFile.Enabled = true;
                btnGeneratePayInFile.Enabled = true;
            }
            else
            {

                Height = 482;
            }
        }
        private void ValidateCustCodeBOID()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
                DataTable codeBODataTable = new DataTable();
                codeBODataTable = tradeBal.ValidateCustCodeBOID();
                lbCodeBOError.Items.Clear();
                if (codeBODataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < codeBODataTable.Rows.Count; i++)
                    {
                        lbCodeBOError.Items.Add(codeBODataTable.Rows[i]["Cust_Code_BO"]);
                    }
                }
                else
                {
                    lbCodeBOError.Items.Clear();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Client Code & BO Id Mismatch Error." + exc.Message);
            }
        }
        private void ValidateGroupMisMatch()
        {
            try
            {
                PayInTradeBAL tradeBal = new PayInTradeBAL();
                DataTable groupDataTable = new DataTable();
                groupDataTable = tradeBal.ValidateGroupMisMatch();
                if (groupDataTable.Rows.Count > 0)
                {
                    dtgGroupMismatch.DataSource = groupDataTable;
                    dtgGroupMismatch.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
                else
                {

                    dtgGroupMismatch.Columns.Clear();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Group Mismatch Error." + exc.Message);
            }
        }

        private void ValidateCompanyCategory()
        {
            try
            {
                PayInTradeBAL tradeBal = new PayInTradeBAL();
                DataTable ctegoryDataTable = new DataTable();
                ctegoryDataTable = tradeBal.ValidateCompanyCategory();
                if (ctegoryDataTable.Rows.Count > 0)
                {
                    lbCompanyCatError.Items.Clear();
                    for (int i = 0; i < ctegoryDataTable.Rows.Count; i++)
                    {
                        lbCompanyCatError.Items.Add(ctegoryDataTable.Rows[i]["InstrumentCategory"]);

                    }
                }
                else
                {
                    lbCompanyCatError.Items.Clear();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Company Validation Error. " + exc.Message);
            }
        }

        private void ValdateISIN()
        {
            try
            {
                PayInTradeBAL tradeBal = new PayInTradeBAL();
                DataTable isinDataTable = new DataTable();
                isinDataTable = tradeBal.ValidateISIN();
                if (isinDataTable.Rows.Count > 0)
                {
                    lbISINError.Items.Clear();
                    for (int i = 0; i < isinDataTable.Rows.Count; i++)
                    {
                        lbISINError.Items.Add(isinDataTable.Rows[i]["ISIN"]);

                    }
                }
                else
                {
                    lbISINError.Items.Clear();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("ISIN Validation Error. " + exc.Message);
            }


        }

        private void ValidateCustCode()
        {
            try
            {
                PayInTradeBAL tradeBal = new PayInTradeBAL();
                DataTable custCodeDataTable = new DataTable();
                custCodeDataTable = tradeBal.ValidateCustCode();
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
                companyDataTable = tradeBal.ValidateCompany();
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

        private void ValidateBOID()
        {
            try
            {
                PayInTradeBAL tradeBal = new PayInTradeBAL();
                DataTable boDataTable = new DataTable();
                boDataTable = tradeBal.ValidateBOID();
                if (boDataTable.Rows.Count > 0)
                {
                    lbBOError.Items.Clear();
                    for (int i = 0; i < boDataTable.Rows.Count; i++)
                    {
                        lbBOError.Items.Add(boDataTable.Rows[i]["BOID"]);

                    }
                }
                else
                {
                    lbBOError.Items.Clear();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("BO ID Validation Error. " + exc.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
