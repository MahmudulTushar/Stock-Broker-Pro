using System;
using System.Data;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class ChargeDefForm : Form
    {
        public ChargeDefForm()
        {
            InitializeComponent();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRate.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Charge Rate.");
                return;
            }
            if (txtMinCharge.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Minimum fee.");
                return;
            }
            ChargeDefBO chargeDefBo = new ChargeDefBO();
            chargeDefBo.ChItem = ddlChargeItem.SelectedItem.ToString();
            chargeDefBo.ChItemDescription = txtChargeDescription.Text;
            chargeDefBo.Category = ddlCategory.SelectedItem.ToString();
             if (!String.IsNullOrEmpty(txtMinCharge.Text.Trim()))
                 chargeDefBo.MinCh = float.Parse(txtMinCharge.Text);
            if (!String.IsNullOrEmpty(txtRate.Text.Trim()))
                chargeDefBo.ChRate = float.Parse(txtRate.Text);
            chargeDefBo.EffectiveDate = dtEffectiveDate.Value;
            try
            {
                ChargeDefBAL chargeDefBal = new ChargeDefBAL();
                chargeDefBal.Insert(chargeDefBo);
                MessageBox.Show("Charge Information Saved Successfully.");
                LoadGridData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to save Charge Information because of the Error : " + ex.Message);
            }
        }

      

        private void ChargeDefForm_Load(object sender, EventArgs e)
        {
            LoadGridData();
            ddlChargeItem.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;

        }

        private void LoadGridData()
        {
            ChargeDefBAL chargeDefBal = new ChargeDefBAL();
            DataTable datatable = chargeDefBal.GetGridInfo();
            dtgChargeInfo.DataSource = datatable;
            dtgChargeInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMinCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtMinCharge.Text, e);
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtRate.Text, e);
        }
    }
}
