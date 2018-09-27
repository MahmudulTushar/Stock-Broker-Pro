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
    public partial class LockInShareProcess : Form
    {
        public LockInShareProcess()
        {
            InitializeComponent();
        }

        private void LockInShareProcess_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            LockInShareBAL lockInShareBal = new LockInShareBAL();
            DataTable datatable = lockInShareBal.GetGridData();
            dtg16DP95UX.DataSource = datatable;
            dtg16DP95UX.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtg16DP95UX.Columns[0].Width =80 ;
            dtg16DP95UX.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtg16DP95UX.Columns[1].Width =180 ;
            dtg16DP95UX.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtg16DP95UX.Columns[2].Width = 180;
            dtg16DP95UX.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtg16DP95UX.Columns[3].Width = 80;
            dtg16DP95UX.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtg16DP95UX.Columns[4].Width = 80;
            dtg16DP95UX.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtg16DP95UX.Columns[5].Width = 80;
            dtg16DP95UX.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtg16DP95UX.Columns[6].Width = 80;           
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            lbCompShortCodeError.Items.Clear();
            lbBOError.Items.Clear();
            ValidateBOID();
            ValidateCompany();
            if (lbBOError.Items.Count == 0 && lbCompShortCodeError.Items.Count == 0)
            {
                btnProcess.Enabled = true;
            }
            else
            {
                Height = 436;
            }
        }


        private void ValidateCompany()
        {
            try
            {
                LockInShareBAL lockInShareBal = new LockInShareBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = lockInShareBal.ValidateCompany();
                if (companyDataTable.Rows.Count > 0)
                {
                    lbCompShortCodeError.Items.Clear();
                    for (int i = 0; i < companyDataTable.Rows.Count; i++)
                    {
                        lbCompShortCodeError.Items.Add(companyDataTable.Rows[i]["Comp_Short_Code"]);
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
                LockInShareBAL lockInShareBal = new LockInShareBAL();
                DataTable boDataTable = new DataTable();
                 boDataTable = lockInShareBal.ValidateBOID();
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
                LockInShareBAL lockInShareBal = new LockInShareBAL();
                lockInShareBal.SaveIntoShareDW();
                MessageBox.Show("Lock In Share Data imported successfully.");
                this.Close();
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
