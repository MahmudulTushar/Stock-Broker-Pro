using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.IO;
using System.Text;

namespace StockbrokerProNewArch
{
    public partial class SattleProcess : Form
    {
        //Updated By Shahrior On 31 May 2012
        private bool _isLoadOldTradeFile;

        public bool IsLoadOldTradeFile
        {
            get { return _isLoadOldTradeFile; }
            set { _isLoadOldTradeFile = value; }
        }
        //End Updated

        
        public SattleProcess()
        {
            InitializeComponent();            
            //Default Value Assign
            _isLoadOldTradeFile = true; //Updated By Shahrior on 31 May 2012
        }
            
        
        private void btnGeneratePayInFile_Click(object sender, EventArgs e)
        {
            try
            {
                 
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                if (!IsLoadOldTradeFile)
                    tradeFileBal.GeneratePayInDataByTradeFileTemp();
                else
                    tradeFileBal.GeneratePayInDataByOldTradeFileTemp();
                    //tradeFileBal.MH_GeneratePayInData();
                PayinOutEditor payinOutEditor = new PayinOutEditor();
                payinOutEditor.Paylog = "I";
                DialogResult dialogResult = payinOutEditor.ShowDialog();
                if(dialogResult == DialogResult.OK)
                {
                    GeneratePayinFile();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fail to process payin files. Because: " + exception.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        } 

        private void PayInProcessOld_Load(object sender, EventArgs e)
        {
            if (!IsLoadOldTradeFile)
                LoadTradeDataIntoGrid();
            else
                LoadOldTradeDataIntoGrid();
        }

        private void LoadOldTradeDataIntoGrid()
        {
            PayInTradeBAL tradeFileBal = new PayInTradeBAL();
            DataTable datatable = tradeFileBal.GetGridDataOld();
            dtgTradeFile.DataSource = datatable;
            dtgTradeFile.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        
        private void LoadTradeDataIntoGrid()
        {
            //payintradebal tradefilebal = new payintradebal();
            //datatable datatable = tradefilebal.getgriddata();
            //dtgtradefile.datasource = datatable;
            //dtgtradefile.columns[0].defaultcellstyle.alignment = datagridviewcontentalignment.middleright;
            
            TradeBAL tradeFileBal = new TradeBAL();
            DataTable datatable = tradeFileBal.GetGridData_FlexTrade();
            dtgTradeFile.DataSource = datatable;
            dtgTradeFile.Columns[0].Visible = false;
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
                btnGeneratePayInFile.Enabled = true;
            }
            else
            {

                Height = 482;
            }

        }
        /*********************************************************************************
         **************   Payin v-2 Code  ************************************************
         *********************************************************************************/
        private void GeneratePayinFile()
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                DataTable datatable = tradeFileBal.GetSattlePayInData();
                if (datatable.Rows.Count > 0)
                {
                    Write(datatable, GeneratePayinFileName());
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

        public void Write(DataTable dt, string sFileName)
        {
            StreamWriter sw = null;
            try
            {
                SaveFileDialog oDialog = new SaveFileDialog();
                oDialog.Filter = "Payin-out files | *.01";
                oDialog.FileName = sFileName;

                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    sFileName = oDialog.FileName;
                }
                else
                {
                    return;
                }

                if (sFileName != null)
                {
                    sw = new StreamWriter(sFileName, false);
                    foreach (DataRow row in dt.Rows)
                    {
                        sw.WriteLine(row[0].ToString());
                    }
                    sw.Close();

                    MessageBox.Show("Report saved with file: " + sFileName, "To Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    //oEXLApp.ActiveWorkbook.Close(false, Missing.Value, Missing.Value);
                    MessageBox.Show("Cannot export to Text...", "Can't export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalid Operation : \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GeneratePayinFileName()
        {
            return "01023500" + DateTime.Today.ToString("ddMMyyyy") + ".01";
        }
    }
}
