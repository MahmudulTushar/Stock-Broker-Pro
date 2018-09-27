using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class BOCloseProcess : Form
    {
        public BOCloseProcess()
        {
            InitializeComponent();
        }

        private void BOCloseProcess_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }
        private void LoadDataIntoGrid()
        {
            BOCloseBAL boCloseBal = new BOCloseBAL();
            DataTable datatable = boCloseBal.GetGridData();
            dtg08DP04UX.DataSource = datatable;
            dtg08DP04UX.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            lbBOError.Items.Clear();
            ValidateBOID();
            if (lbBOError.Items.Count == 0)
            {
                btnProcess.Enabled = true;
            }
            else
            {
                Height = 470;
            }
        }
        private void ValidateBOID()
        {
            try
            {
                BOCloseBAL boCloseBal = new BOCloseBAL();
                DataTable boDataTable = new DataTable();
                boDataTable = boCloseBal.ValidateBOID();
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
                BOCloseBAL boCloseBal = new BOCloseBAL();
                boCloseBal.UpdateBOCloseInfo();
                MessageBox.Show("BO Close Data imported successfully.");
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
