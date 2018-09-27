using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class ClosingChargeEntry : Form
    {
        public ClosingChargeEntry()
        {
            InitializeComponent();
        }

        private void ClosingChargeEntry_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            ClosingChargeDefBAL closingChargeDefBal = new ClosingChargeDefBAL();
            DataTable datatable = closingChargeDefBal.GetGridInfo();
            dtgChargeInfo.DataSource = datatable;
            dtgChargeInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRate.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Charge Rate.");
                return;
            }
            ClosingChargeBO closingChargeBo = new ClosingChargeBO();
            if (!String.IsNullOrEmpty(txtRate.Text.Trim()))
                closingChargeBo.ClosingCharge = float.Parse(txtRate.Text);
            closingChargeBo.EffectiveDate = dtEffectiveDate.Value;
            try
            {
                ClosingChargeDefBAL closingChargeDefBal = new ClosingChargeDefBAL();
                closingChargeDefBal.Insert(closingChargeBo);
                MessageBox.Show("Closing Charge Information Saved Successfully.");
                LoadGridData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to save Closing Charge Information because of the Error : " + ex.Message);
            }
        }
    }
}
