using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Linq;
using System.Collections.Generic;

namespace StockbrokerProNewArch
{
    public partial class TradePriceProcess_FlexTrade : Form
    {
        private DataTable dtPricefileData = new DataTable();
       
        public TradePriceProcess_FlexTrade()
        {
            InitializeComponent();
            
        }

        private void ProcessInstrumentGroupChange(DataTable dtPriceInfoDt)
        {
            try
            {
                List<DataRow> queryInstrumentInfo = new List<DataRow>();
                List<DataRow> queryInstrumentCompanyInfo = new List<DataRow>();

                TradePriceBAL Bal = new TradePriceBAL();
            
                DataTable dt_Temp_InstrumentGroup = new DataTable();
                DataTable dt_Temp_InstrumentGroupFromCompany = new DataTable();
                
                dt_Temp_InstrumentGroup = Bal.GetInstrumentGroupInfo();
                dt_Temp_InstrumentGroupFromCompany = Bal.GetInstrumentCompanyInfo();
                
                queryInstrumentInfo = dt_Temp_InstrumentGroup.Rows.Cast<DataRow>().ToList();
                queryInstrumentCompanyInfo = dt_Temp_InstrumentGroupFromCompany.Rows.Cast<DataRow>().ToList();


                var data = dtPriceInfoDt.Rows.Cast<DataRow>().GroupBy(t => new { Comp_Short_Code = Convert.ToString(t["Instrument_Code"]), Category = Convert.ToString(t["Category"]) })
                   .Select(t => new { Comp_Short_Code = t.Key.Comp_Short_Code, Category = t.Key.Category });

                
               foreach(var eachData in data)
               {
                    string comp_Short_Code=eachData.Comp_Short_Code;
                    string comp_Group = eachData.Category;
                    if (!string.IsNullOrEmpty(comp_Group))
                    {
                        //var dataTemp = queryInstrumentInfo.Where(t => t["Comp_Category"].ToString() == comp_Group).SingleOrDefault().ItemArray[0];
                        var dataTemp = queryInstrumentInfo.Where(t => Convert.ToString(t["Comp_Category"]) == comp_Group).SingleOrDefault().ItemArray[0];
                        if (dataTemp == null)
                            throw new Exception(comp_Group + " Category Not Found In Master Info");
                        int Comp_CatgID_FoundFrom_CompanyCatgInfo = Convert.ToInt32(dataTemp);


                        var dataTemp_1 = queryInstrumentCompanyInfo.Where(t => t["Comp_Short_Code"].ToString() == comp_Short_Code).SingleOrDefault().ItemArray[1];
                        if (dataTemp_1 == null)
                            throw new Exception(comp_Short_Code + " Company Not Found In Master Info");
                        int Comp_CatgID_FoundFrom_SBPCompanyInfo = Convert.ToInt32(dataTemp_1);

                        if (Comp_CatgID_FoundFrom_CompanyCatgInfo != Comp_CatgID_FoundFrom_SBPCompanyInfo)
                        {
                            UpdateCompanyGroup(comp_Short_Code, Comp_CatgID_FoundFrom_CompanyCatgInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateCompanyGroup(string comp_Short_Code, int groupId)
        {
            TradePriceBAL bal = new TradePriceBAL();
            bal.ChangeCompanyGroup(comp_Short_Code, groupId);
        }

        private void ValidateCompany()
        {
            try
            {
                TradePriceBAL tradePriceBal = new TradePriceBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = tradePriceBal.ValidateCompany();
                if (companyDataTable.Rows.Count > 0)
                {
                    lbComapnyName.Items.Clear();
                    for (int i = 0; i < companyDataTable.Rows.Count; i++)
                    {
                        lbComapnyName.Items.Add(companyDataTable.Rows[i]["Instrument_Code"]);

                    }
                }
                else
                {
                    lbComapnyName.Items.Clear();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Company Validation Error." + exc.Message);
            }
        }
        
        private void ValidateGroupMisMatch()
        {
            try
            {
                TradePriceBAL tradeBal = new TradePriceBAL();
                DataTable groupDataTable = new DataTable();
                groupDataTable = tradeBal.ValidateGroupMisMatch_FlexTrade();
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

        private void LoadDataIntoGrid()
        {
            TradePriceBAL tradePriceBal = new TradePriceBAL();
            DataTable datatable = tradePriceBal.GetGridData_FlexTrade();
            dtgTradeFile.DataSource = datatable;
            dtgTradeFile.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtPricefileData = datatable;
        }

        private void TradePriceImport_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void btnProcess_Click_1(object sender, EventArgs e)
        {
            try
            {
                TradePriceBAL tradePriceBal = new TradePriceBAL();
                tradePriceBal.SaveIntoTradePrice_FlexTrade(TradePriceUpload_FlexTrade.tradeDate);
                MessageBox.Show("Trade Price Data imported successfully.");
                this.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Transaction Data import operation failed. " + exc.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ValidateCompany();
            ValidateGroupMisMatch();
            if (lbComapnyName.Items.Count == 0)
            {
                btnProcess.Enabled = true;
            }
            else
            {
                btnProcess.Enabled = true;
                Height = 482;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeGroup_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessInstrumentGroupChange(dtPricefileData);
                MessageBox.Show(@"Group Changed Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);               
            }
        }
    }
}
