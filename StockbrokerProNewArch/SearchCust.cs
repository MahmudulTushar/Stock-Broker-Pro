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
    public partial class SearchCust : Form
    {
        public SearchCust()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbName_CheckedChanged(object sender, EventArgs e)
        {
            txtName.Enabled = chbName.Checked;
            txtName.Text = "";
        }

        private void chbFatherName_CheckedChanged(object sender, EventArgs e)
        {
            txtFatherName.Enabled = chbFatherName.Checked;
            txtFatherName.Text = "";
        }

        private void chbAddress_CheckedChanged(object sender, EventArgs e)
        {
            txtAddress.Enabled = chbAddress.Checked;
            txtAddress.Text = "";
        }

        private void chbDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFrom.Enabled = chbDate.Checked;
            dtTo.Enabled = chbDate.Checked;
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
        }

        private void chbMobile_CheckedChanged(object sender, EventArgs e)
        {
            txtMobile.Enabled = chbMobile.Checked;
            txtMobile.Text = "";
        }

        private void chbBankAccNo_CheckedChanged(object sender, EventArgs e)
        {
            txtBankAccNo.Enabled = chbBankAccNo.Checked;
            txtBankAccNo.Text = "";
        }
        private void chbBankName_CheckedChanged(object sender, EventArgs e)
        {
            txtBankName.Enabled = chbBankName.Checked;
            txtBankName.Text = "";
        }

        private void SearchCust_Load(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            txtMobile.Enabled = false;
            txtFatherName.Enabled = false;
            txtBankAccNo.Enabled = false;
            txtBankName.Enabled = false;
            txtAddress.Enabled = false;
            dtFrom.Enabled = false;
            dtTo.Enabled = false;
        }

        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAll.Checked)
            {
                chbName.Checked = true;
                chbMobile.Checked = true;
                chbFatherName.Checked = true;
                chbDate.Checked = true;
                chbBankAccNo.Checked = true;
                chbAddress.Checked = true;
                chbBankName.Checked=true;
            }
            else
            {
                chbName.Checked = false;
                chbMobile.Checked = false;
                chbFatherName.Checked = false;
                chbDate.Checked = false;
                chbBankAccNo.Checked = false;
                chbAddress.Checked = false;
                chbBankName.Checked = false;
            }
        }
        public string GetCriteriaString()
        {
            string criteriaString = "";
            if(chbName.Checked && txtName.Text.Trim()!="")
            {
                criteriaString =criteriaString + " AND Cust_Name like '%" + txtName.Text + "%'";
            }
            if (chbMobile.Checked && txtMobile.Text.Trim() != "")
            {
                criteriaString = criteriaString + " AND Mobile like '%" + txtMobile.Text + "%'";
            }
            if (chbFatherName.Checked && txtFatherName.Text.Trim() != "")
            {
                criteriaString = criteriaString + " AND Father_Name like '%" + txtFatherName.Text + "%'";
            }
            if (chbDate.Checked)
            {
                criteriaString = criteriaString + " AND BO_Open_Date BETWEEN '" + dtFrom.Value + "' AND '" + dtTo.Value + "'";
            }
            if (chbBankName.Checked && txtBankName.Text.Trim() != "")
            {
                criteriaString = criteriaString + " AND Bank_Name like '%" + txtBankName.Text + "%'";
            }
            if (chbBankAccNo.Checked && txtBankAccNo.Text.Trim() != "")
            {
                criteriaString = criteriaString + " AND Account_No like '%" + txtBankAccNo.Text + "%'";
            }
            if (chbAddress.Checked && txtAddress.Text.Trim() != "")
            {
                criteriaString = criteriaString + " AND Address1 like '%" + txtAddress.Text + "%'";
            }
            return criteriaString;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string criteriaString = GetCriteriaString();
            if ((chbName.Checked || chbMobile.Checked || chbFatherName.Checked || chbDate.Checked || chbBankName.Checked || chbBankAccNo.Checked || chbAddress.Checked) && criteriaString.Trim() != "")
            {
                SearchCustBAL searchCustBal = new SearchCustBAL();
                DataTable datatable = searchCustBal.SearchCustomer(criteriaString);
                if (datatable.Rows.Count > 0)
                {
                    dtgCustInfo.DataSource = datatable;
                    dtgCustInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    lblSearchResult.Text = datatable.Rows.Count + " results Found.";
                }
                else
                {
                    MessageBox.Show("No customer found. Please search with valid criteria.","Invalid Search");
                }
            }
            else
            {
                MessageBox.Show("Please Select and Enter any search criteria of the customer.");
            }
        }
    }
}
