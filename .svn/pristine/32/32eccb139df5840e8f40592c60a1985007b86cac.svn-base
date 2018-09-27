using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class RightShareProcess : Form
    {
        public RightShareProcess()
        {
            InitializeComponent();
        }
        private void RightShareProcess_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            RightBAL bonusRightBal = new RightBAL();
            DataTable datatable = bonusRightBal.GetGridData();
            dtg17DP70UX.DataSource = datatable;
            dtg17DP70UX.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                RightBAL rightBal = new RightBAL();
                rightBal.SaveIntoShareDW();
                MessageBox.Show("Right Share Data imported successfully.");
                this.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Fail to import data.Error: " + exc.Message);
            }
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
                Height = 472;
            }

        }
        private void ValidateISINNo()
        {
            try
            {
                RightBAL bonusRightBal = new RightBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = bonusRightBal.ValidateISINNo();
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
                RightBAL bonusRightBal = new RightBAL();
                DataTable boDataTable = new DataTable();
                boDataTable = bonusRightBal.ValidateBOID();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
