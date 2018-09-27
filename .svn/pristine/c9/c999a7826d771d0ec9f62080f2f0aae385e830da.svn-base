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
    public partial class DematShareProcess : Form
    {
        public DematShareProcess()
        {
            InitializeComponent();
        }

        private void DematShareProcess_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            DematBAL dematBal = new DematBAL();
            DataTable datatable = dematBal.GetGridData();
            dtg16DP61UX.DataSource = datatable;
            dtg16DP61UX.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
                DematBAL dematBal = new DematBAL();
                DataTable companyDataTable = new DataTable();
                companyDataTable = dematBal.ValidateISINNo();
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
                DematBAL dematBal = new DematBAL();
                DataTable boDataTable = new DataTable();
                boDataTable = dematBal.ValidateBOID();
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
                DematBAL dematBal = new DematBAL();
                dematBal.SaveIntoShareDW();
                MessageBox.Show("Demat Share Data imported successfully.");
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
