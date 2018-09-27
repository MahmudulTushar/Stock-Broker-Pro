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
    public partial class Frm_BOOpeningCharge : Form
    {
        BO_Opening_InformationBAL BAL = new BO_Opening_InformationBAL();
        double doubleTryParse = 0;

        public Frm_BOOpeningCharge()
        {
            InitializeComponent();
        }
        private void Frm_BOOpeningCharge_Load(object sender, EventArgs e)
        {
            LoadGridView();
            LoadLastChargeHistory();
            txtTotalCharge.Focus();
        }

        private void LoadLastChargeHistory()
        {
            double doubleTryParse;
            DataTable dt = BAL.GetLastChargeHistory();

            if (dt.Rows.Count > 0)
            {
                var HouseCh = (from DataRow a in dt.Rows where a["Ch_Item"].ToString() == "BO Open Charge_House" select a["Ch_Rate"]).FirstOrDefault();
                double H_CH = 0;
                if (double.TryParse(HouseCh.ToString(), out doubleTryParse))
                    H_CH = doubleTryParse;

                var CDBLch = (from DataRow a in dt.Rows where a["Ch_Item"].ToString() == "BO Open Charge_CDBL" select a["Ch_Rate"]).FirstOrDefault();
                double C_CH = 0;
                if (double.TryParse(CDBLch.ToString(), out doubleTryParse))
                    C_CH = doubleTryParse;

                txtTotalCharge.Text = Convert.ToString(H_CH + C_CH);
                txtHouseCharge.Text = H_CH.ToString();
                txtCDBLCharge.Text = C_CH.ToString();
            }
            //txtTotalCharge.Text = dt.Rows[0]["TotalCharge"].ToString();
            //txtHouseCharge.Text = dt.Rows[0]["Ch_Rate"].ToString();
            //txtCDBLCharge.Text = dt.Rows[1]["Ch_Rate"].ToString();
        }

        private void LoadGridView()
        {
            DataTable dt = BAL.GetChargeHistory();
            if (dt.Rows.Count > 0) dgvChargeHistory.DataSource = dt;
        }

        private void txtTotalCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtHouseCharge.Focus();
            }
        }

        private void txtHouseCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtCDBLCharge.Focus();
            }
        }

        private void txtCDBLCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnUpdate.Focus();
            }
        }

        private void txtTotalCharge_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(txtTotalCharge.Text.Trim(), out doubleTryParse))
            {
                MessageBox.Show("Please Write Correct Formate");
                txtTotalCharge.Focus();
            }
        }

        private void txtHouseCharge_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(txtHouseCharge.Text.Trim(), out doubleTryParse))
            {
                MessageBox.Show("Please Write Correct Formate");
                txtHouseCharge.Focus();
            }
        }

        private void txtCDBLCharge_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(txtCDBLCharge.Text.Trim(), out doubleTryParse))
            {
                MessageBox.Show("Please Write Correct Formate");
                txtCDBLCharge.Focus();
            }
        }

        private bool UpdateValidation()
        {
            double HouseCharge = 0;
            if (!string.IsNullOrEmpty(txtHouseCharge.Text.Trim()))
                HouseCharge = Convert.ToDouble(txtHouseCharge.Text.Trim());

            double CDBLCharge = 0;
            if (!string.IsNullOrEmpty(txtCDBLCharge.Text.Trim()))
                CDBLCharge = Convert.ToDouble(txtCDBLCharge.Text.Trim());

            double totalCharge = 0;
            if (!string.IsNullOrEmpty(txtTotalCharge.Text.Trim()))
                totalCharge = Convert.ToDouble(txtTotalCharge.Text.Trim());


            if ((HouseCharge + CDBLCharge) > totalCharge)
            {
                MessageBox.Show("Pleace check Charges. Total charge is less than distributed charges..", "Alart..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHouseCharge.Focus();
                return true;
            }
            else if ((HouseCharge + CDBLCharge) < totalCharge)
            {
                MessageBox.Show("Pleace check Charges. Total charge is more than distributed charges..", "Alart..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalCharge.Focus();
                return true;
            }
            else return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateValidation())
                return;

            if (MessageBox.Show("Want To Update Charge Information?", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    BAL.UpdateCharges(txtHouseCharge.Text.Trim(), txtCDBLCharge.Text.Trim());
                    MessageBox.Show("BO Opening Charges Saved Successfully...");
                    Frm_BOOpeningCharge_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("BO Opening Charges Save Unsuccessfully...");
                }
            }
        }
    }
}
