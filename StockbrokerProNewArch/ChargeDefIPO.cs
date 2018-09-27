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
    public partial class ChargeDefIPO : Form
    {
        public ChargeDefIPO()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChDefIPO_Load(object sender, EventArgs e)
        {
            LoadCompanyDDL();
            LoadGridData();
            ddlCompShortCode.SelectedIndex = 0;
        }

        private void LoadGridData()
        {
            IPOChargeBAL ipoChargeBal = new IPOChargeBAL();
            DataTable datatable = ipoChargeBal.GetGridInfo();
            dtgIPOChargeInfo.DataSource = datatable;
            dtgIPOChargeInfo.Columns["Commission"].DefaultCellStyle.Format = "N";
            dtgIPOChargeInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void LoadCompanyDDL()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Company");
            ddlCompShortCode.DataSource = dtData;
            ddlCompShortCode.DisplayMember = "Comp_Short_Code";
            ddlCompShortCode.ValueMember = "Comp_Short_Code";
            if (ddlCompShortCode.HasChildren)
                ddlCompShortCode.SelectedIndex = -1;

        }

        private void ddlCompShortCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCompany();
        }

        private void LoadCompany()
        {
            DataTable companyDataTable = new DataTable();
            IPOChargeBAL ipoChargeBal = new IPOChargeBAL();
            if (ddlCompShortCode.SelectedIndex != -1)
                companyDataTable = ipoChargeBal.GetAllData(ddlCompShortCode.Text);
            if (companyDataTable.Rows.Count > 0)
            {
                txtCompanyName.Text = companyDataTable.Rows[0]["Comp_Name"].ToString();
                txtShareType.Text = companyDataTable.Rows[0]["Share_Type"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCommissionRate.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Commission Rate.");
                return;
            }
            IPOChargeDefBO ipoChargeDefBo = new IPOChargeDefBO();
            ipoChargeDefBo.CompShortCode = ddlCompShortCode.Text;
            ipoChargeDefBo.CompName = txtCompanyName.Text;
            ipoChargeDefBo.ShareType = txtShareType.Text;
            ipoChargeDefBo.Commision = float.Parse(txtCommissionRate.Text);
            ipoChargeDefBo.EffectiveDate = dtEffectiveDate.Value;
            try
            {
                IPOChargeBAL ipoChargeBal = new IPOChargeBAL();
                ipoChargeBal.Insert(ipoChargeDefBo);
                MessageBox.Show("IPO Charge Information Saved Successfully.");
                LoadGridData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to save IPO Charge Information because of the Error : " + ex.Message);
            }
        }
    }
}
