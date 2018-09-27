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
    public partial class CustomerCommisionInfo : Form
    {
        public CustomerCommisionInfo()
        {
            InitializeComponent();
        }

        private void txtMinCommission_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtMinCommission.Text, e);

        }

        private void txtCommissionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBal = new CommonBAL();
            commonBal.NumberValidate(txtCommissionRate.Text, e);
        }

        private void CustomerCommisionInfo_Load(object sender, EventArgs e)
        {
            LoadGridData();
            LoadDDLCustGroup();
            ddlCustomerGroup.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
        }

        private void LoadGridData()
        {
            CustomerCommisionInfoBAL customerCommisionBal = new CustomerCommisionInfoBAL();
            DataTable datatable = customerCommisionBal.GetGridInfo();
            dtgCustCommision.DataSource = datatable;
            dtgCustCommision.Columns["Min. Commission"].DefaultCellStyle.Format = "N";
            //dtgCustCommision.Columns["Rate"].DefaultCellStyle.Format = "N";
            dtgCustCommision.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void LoadDDLCustGroup()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Cust_Group");

            ddlCustomerGroup.DataSource = dtData;

            ddlCustomerGroup.DisplayMember = "Cust_Group";
            ddlCustomerGroup.ValueMember = "Cust_Group_ID";

            if (ddlCustomerGroup.HasChildren)
                ddlCustomerGroup.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCommissionRate.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Commissoin Rate.");
                return;
            }
            if (txtMinCommission.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Minimum fee.");
                return;
            }
            try
            {
                CustomerCommisionBO commisionBo = new CustomerCommisionBO();
                commisionBo.GroupId = Convert.ToInt32(ddlCustomerGroup.SelectedValue);
                if (!String.IsNullOrEmpty(txtMinCommission.Text.Trim()))
                    commisionBo.MinComm = float.Parse(txtMinCommission.Text);
                if (!String.IsNullOrEmpty(txtCommissionRate.Text.Trim()))
                    commisionBo.GroupCommRate = float.Parse(txtCommissionRate.Text);
                commisionBo.Category = ddlCategory.SelectedItem.ToString();
                commisionBo.EffectiveFrom = dtEffectiveDate.Value;
                CustomerCommisionInfoBAL customerCommisionBal = new CustomerCommisionInfoBAL();
                customerCommisionBal.Insert(commisionBo);
                MessageBox.Show("Customerwise commission has been changed.");
                LoadGridData();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Customerwise commission can not changed.Error: " + exc.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
