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
    public partial class WebConfirmationProcess : Form
    {
        public WebConfirmationProcess()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSMSConfirmationProcess_Load(object sender, EventArgs e)
        {
            try
            {
                GetWorkStationList();
                LoadDataIntoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void LoadDataIntoGrid()
        {
            try
            {
                PayInTradeBAL tradeFileBal = new PayInTradeBAL();
                DataTable datatable = tradeFileBal.GetTradedataByWorkstation();
                dtgTradeFile.DataSource = datatable;
                dtgTradeFile.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch (Exception)
            {
                throw;
            }
           
        }

        private void GetWorkStationList()
        {
            try
            {
                WorkStationBAL objWorkstationBal = new WorkStationBAL();
                DataTable data = new DataTable();
                data = objWorkstationBal.GetWorkStationList();
                ddlWorkStation.DataSource = data;
                ddlWorkStation.DisplayMember = "WorkStation_Name";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ddlWorkStation_TextChanged(object sender, EventArgs e)
        {

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
                this.Height=367;
                btnSmsConfirmation.Enabled = true;
            }
            else
            {

                Height = 482;
            }
        }

        private void ValidateGroupMisMatch()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
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
                TradeBAL tradeBal = new TradeBAL();
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

        private void ValdateISIN()
        {
            try
            {
                TradeBAL tradeBal = new TradeBAL();
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
                TradeBAL tradeBal = new TradeBAL();
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
                TradeBAL tradeBal = new TradeBAL();
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
                TradeBAL tradeBal = new TradeBAL();
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

        private void btnSmsConfirmation_Click(object sender, EventArgs e)
        {

        }
    }
}
