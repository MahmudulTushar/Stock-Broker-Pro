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
    public partial class MarginChargeDef : Form
    {
        public MarginChargeDef()
        {
            InitializeComponent();
        }

        private void MarginChargeDef_Load(object sender, EventArgs e)
        {
            LoadGridData();
            ddlPlanName.SelectedIndex = 0;
        }

        private void LoadGridData()
        {
            MarginChargeDefBAL marginChargeDefBal = new MarginChargeDefBAL();
            DataTable datatable = marginChargeDefBal.GetGridInfo();
            dtgChargeInfo.DataSource = datatable;
            dtgChargeInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMarginPlan();
        }

        private void SaveMarginPlan()
        {
            if (txtChargeRate.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Charge Rate.");
                return;
            }
            if (txtEffectiveCount.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Effective Count.");
                return;
            }
            MarginChargeDefBO marginChargeDefBo = new MarginChargeDefBO();
            marginChargeDefBo.PlanName = ddlPlanName.SelectedItem.ToString();
            if (!String.IsNullOrEmpty(txtChargeRate.Text.Trim()))
                marginChargeDefBo.ChargeRate = float.Parse(txtChargeRate.Text);
            if (!String.IsNullOrEmpty(txtEffectiveCount.Text.Trim()))
                marginChargeDefBo.EffectiveCount = Convert.ToInt32(txtEffectiveCount.Text);
            marginChargeDefBo.EffectiveDate = dtEffectiveDate.Value;
            marginChargeDefBo.Remarks = txtRemarks.Text;
            try
            {
                MarginChargeDefBAL marginChargeDefBal = new MarginChargeDefBAL();
                marginChargeDefBal.Insert(marginChargeDefBo);
                MessageBox.Show("Margin Charge Information Saved Successfully.");
                LoadGridData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to save Margin Charge Information because of the Error : " + ex.Message);
            }
        }

        private void txtChargeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtChargeRate.Text, e);
        }

        private void txtEffectiveCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtEffectiveCount.Text, e);
        }
    }
}
