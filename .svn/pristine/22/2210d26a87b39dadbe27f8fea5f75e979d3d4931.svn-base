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
    public partial class BonusShareProcess : Form
    {
        public BonusShareProcess()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            lbISINNoError.Items.Clear();
            lbBOError.Items.Clear();
            ValidateBOID();
            ValidateISINNo();
            if (lbBOError.Items.Count == 0 && lbISINNoError.Items.Count == 0)
            {
                btnProcess.Enabled = true;
            }
            else
            {
                Height = 473;
            }
        }
        private void ValidateISINNo()
        {
            try
            {
                BonusBAL bonusBal = new BonusBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = bonusBal.ValidateISINNo();
                if (companyDataTable.Rows.Count > 0)
                {
                    lbISINNoError.Items.Clear();
                    for (int i = 0; i < companyDataTable.Rows.Count; i++)
                    {
                        lbISINNoError.Items.Add(companyDataTable.Rows[i]["ISIN_Short_Name"]);

                    }
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private void ValidateBOID()
        {
            try
            {
                BonusBAL bonusBal = new BonusBAL();
                DataTable boDataTable = new DataTable();
                boDataTable = bonusBal.ValidateBOID();
                if (boDataTable.Rows.Count > 0)
                {
                    lbBOError.Items.Clear();
                    for (int i = 0; i < boDataTable.Rows.Count; i++)
                    {
                        lbBOError.Items.Add(boDataTable.Rows[i]["BO_ID"]);

                    }
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                BonusBAL bonusBal = new BonusBAL();
                bonusBal.SaveIntoShareDW();
                MessageBox.Show("Bonus Share Data imported successfully.");
                this.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Fail to import data.Error: " + exc.Message);
            }

        }

        private void BonusShareProcess_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            BonusBAL bonusRightBal = new BonusBAL();
            DataTable datatable = bonusRightBal.GetGridData();
            dtg17DP70UX.DataSource = datatable;
            dtg17DP70UX.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

      
}
