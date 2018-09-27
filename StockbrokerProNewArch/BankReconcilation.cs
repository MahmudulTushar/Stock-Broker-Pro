using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;
using StockbrokerProNewArch.Classes;

namespace StockbrokerProNewArch
{
    public partial class BankReconcilation : Form
    {
        public BankReconcilation()
        {
            InitializeComponent();
        }

        private string _CommpanyName;
        private string _branchName;
        private string _branchAddress;
        private string _branchContactNumber;
        private void btnFileLocationBrowser_Click(object sender, EventArgs e)
        {
            if (ofdFileOpen.ShowDialog() == DialogResult.OK)
                txtFileLocation.Text = ofdFileOpen.FileName;
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            UplaodProcess();
        }
        private void ProcessingMessage(string message)
        {
            lbProText.Text = message;
            progress.PerformStep();
        }
        private void Reset()
        {
            lbProText.Text = "Ready for new import process..";
            progress.Maximum = 100;
            progress.Value = 0;
        }
        private void UplaodProcess()
        {
            ProcessingMessage("Processing Bank File...");
            if (txtFileLocation.Text.Length.Equals(0))
            {
                err.SetError(txtFileLocation, "Bank File location is a required field.");
                return;
            }
            else
            {
                err.SetError(txtFileLocation, "");
            }

            CityBankBO.CityBankCollectionBO cityBankCollectionBo = new CityBankBO.CityBankCollectionBO();
            try
            {
                cityBankCollectionBo = ProcessTextFile();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process pdf file. No data saved. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();
                return;
            }
            BlankToTempTable();
            ProcessingMessage("Importing data into database....");
            BankReconcileBAL bankReconcileBal = new BankReconcileBAL();

            progress.Maximum = cityBankCollectionBo.Count + 1;
            foreach (CityBankBO citybankBo in cityBankCollectionBo)
            {
                try
                {
                    if (IsNotExist(citybankBo))
                    {
                        bankReconcileBal.ProcessDatabase(citybankBo);
                    }
                }
                catch (Exception exception)
                {
                    AddErrorInGrid(citybankBo.ChequeNo, exception.Message);
                }
                progress.PerformStep();
            }
            ProcessingMessage("Data imported successfully....");
            MessageBox.Show("Bank Information Imported Successfully.", "Import Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reset();

        }

        private void BlankToTempTable()
        {
            try
            {
                BankReconcileBAL objBankReconcileBAL=new BankReconcileBAL();
                objBankReconcileBAL.TruncateCityBankTable();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsNotExist(CityBankBO cityBankBo)
        {
            BankReconcileBAL bankReconcileBal=new BankReconcileBAL();
            if (bankReconcileBal.IsInsert(cityBankBo))
                return false;
            else
            {
                return true;
            }
        }

        private CityBankBO.CityBankCollectionBO ProcessTextFile()
        {
            DataTable bankDataTable=new DataTable();
            CityBankBO.CityBankCollectionBO cityBankCollectionBo=new CityBankBO.CityBankCollectionBO();
            bankDataTable = GetImportedData();
            dtgBankData.DataSource = bankDataTable;
            dtgBankData.Columns["Date"].DefaultCellStyle.Format = "d";
            dtgBankData.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgBankData.Columns["Debit"].DefaultCellStyle.Format = "N";
            dtgBankData.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgBankData.Columns["Credit"].DefaultCellStyle.Format = "N";
            dtgBankData.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgBankData.Columns["Balance"].DefaultCellStyle.Format = "N";
            dtgBankData.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            


            if (bankDataTable.Rows.Count>0)
            {
                foreach (DataRow dtRow in bankDataTable.Rows)
                {
                    CityBankBO cityBankBo = new CityBankBO();
                    if(dtRow[0]!=DBNull.Value)
                        cityBankBo.ChequeDate = Convert.ToDateTime(dtRow[0].ToString().Trim());
                    cityBankBo.Description = dtRow[1].ToString().Trim();
                    cityBankBo.ChequeNo = dtRow[2].ToString().Trim();
                    cityBankBo.Debit = dtRow[3].ToString().Trim();
                    cityBankBo.Credit = dtRow[4].ToString().Trim();
                    cityBankBo.Balance = dtRow[5].ToString().Trim();
                    cityBankCollectionBo.Add(cityBankBo);
                }
            }
            return cityBankCollectionBo;
            
        }

        private void AddErrorInGrid(string customerCode, string errorMessage)
        {

            string[] rowString = new string[] { (dgvErrors.Rows.Count + 1).ToString(), customerCode, errorMessage };
            dgvErrors.Rows.Add(rowString);
        }

        private DataTable GetImportedData()
        {
            PDFParser pdfParser = new PDFParser();
            string data = pdfParser.ExtractText(txtFileLocation.Text);
            data = data.Replace(";To ;", "");
            data = data.Replace(" ;", ";");
            string[] arrayData = data.Split(';');
            string newData = "";

            CommonBAL objBal = new CommonBAL();
            DateTime dateTime = objBal.GetCurrentServerDate();
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("Description");
            dataTable.Columns.Add("Cheque No");
            dataTable.Columns.Add("Debit");
            dataTable.Columns.Add("Credit");
            dataTable.Columns.Add("Balance");
            dataTable.Columns.Add(" ");

            DataRow dataRow;
            bool indicator = false;
            int count = 6;

            foreach (string word in arrayData)
            {
                if (indicator || DateTime.TryParseExact(word, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    if(!indicator)
                    {
                        newData = newData + dateTime.ToString().Replace(",", "") + ";";
                    }
                    else
                    {
                        newData = newData + word.Replace(",", "") + ";";
                    }
                    indicator = true;
                    --count;
                }
                if (count == 0)
                {
                    indicator = false;
                    count = 6;
                    dataRow = dataTable.NewRow();
                    dataRow.ItemArray = newData.Split(';');
                    newData = "";
                    dataTable.Rows.Add(dataRow);
                }
            }

            /*StreamWriter streamWriter = new StreamWriter("f:\\bank.txt");
            streamWriter.Write(newData);
            streamWriter.Close();*/
            return dataTable;
        }

        private void BankReconcilation_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GenerateChequrematchReport();
            this.Cursor = Cursors.Arrow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GenerateBalanceMissmatchReport();
            this.Cursor = Cursors.Arrow;
        }

        private void GenerateBalanceMissmatchReport()
        {
            try
            {
                cr_CityBankReconceliation objcrBankReport = new cr_CityBankReconceliation();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                BankReconcileBAL objBankReconceliationBAL = new BankReconcileBAL();



                dataTable = objBankReconceliationBAL.BalanceMissmatchList();
                objcrBankReport.SetDataSource(dataTable);

                GetCommonInfo();
                ((TextObject)objcrBankReport.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrBankReport.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                ((TextObject)objcrBankReport.ReportDefinition.Sections[2].ReportObjects["txtReportType"]).Text = "Balance Missmatch";


                objReportviewer.crvReportViewer.ReportSource = objcrBankReport;
                objReportviewer.Text = "Bank Reconceliation : Balance Missmatch";
                objReportviewer.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void GenerateChequrematchReport()
        {
            try
            {
                cr_CityBankReconceliation objcrBankReport = new cr_CityBankReconceliation();
                DataTable dataTable = new DataTable();
                frmReportViewer objReportviewer = new frmReportViewer();
                BankReconcileBAL objBankReconceliationBAL = new BankReconcileBAL();



                dataTable = objBankReconceliationBAL.GetChequeMissmatch();
                objcrBankReport.SetDataSource(dataTable);

                GetCommonInfo();
                ((TextObject)objcrBankReport.ReportDefinition.Sections[2].ReportObjects["txtCompanyName"]).Text = _CommpanyName;
                ((TextObject)objcrBankReport.ReportDefinition.Sections[2].ReportObjects["txtAddress"]).Text = "Branch Name:" + _branchName + "," + _branchAddress + ". Phone:" + _branchContactNumber;
                ((TextObject)objcrBankReport.ReportDefinition.Sections[2].ReportObjects["txtReportType"]).Text = "Cheque Missmatch";


                objReportviewer.crvReportViewer.ReportSource = objcrBankReport;
                objReportviewer.Text = "Bank Reconceliation : Cheque Missmatch";
                objReportviewer.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetCommonInfo()
        {

            try
            {
                CommonInfoBal objCommonInfoBal = new CommonInfoBal();
                DataRow drCommonInfo = null;

                drCommonInfo = objCommonInfoBal.GetCommpanyInfo();

                if (drCommonInfo != null)
                {
                    _CommpanyName = drCommonInfo.Table.Rows[0][0].ToString();
                    _branchName = drCommonInfo.Table.Rows[0][1].ToString();
                    _branchAddress = drCommonInfo.Table.Rows[0][2].ToString();
                    _branchContactNumber = drCommonInfo.Table.Rows[0][3].ToString();


                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
