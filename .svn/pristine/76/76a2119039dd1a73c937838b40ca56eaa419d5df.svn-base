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
    public partial class DeleteShareDW : Form
    {
        private int _shareDWID;

        public DeleteShareDW()
        {
            InitializeComponent();
        }

        private void DeleteShareDW_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            txtVoucherNo.Enabled = false;
            txtCustCode.Enabled = false;
            dtRecievedDate.Enabled = false;
            ddlDepositWithdraw.Enabled = false;
            btnProcessShareDW.Enabled = false;
        }

        private void chbVoucher_CheckedChanged(object sender, EventArgs e)
        {
            txtVoucherNo.Enabled = chbVoucher.Checked;
            txtVoucherNo.Text = "";
        }

        private void chbCustCode_CheckedChanged(object sender, EventArgs e)
        {
            txtCustCode.Enabled = chbCustCode.Checked;
            txtCustCode.Text = "";
        }

        private void chbDW_CheckedChanged(object sender, EventArgs e)
        {
            ddlDepositWithdraw.Enabled = chbDW.Checked;
            ddlDepositWithdraw.SelectedIndex = 0;
        }

        private void ChbRecievedDate_CheckedChanged(object sender, EventArgs e)
        {
            dtRecievedDate.Enabled = ChbRecievedDate.Checked;
            dtRecievedDate.Value = DateTime.Today;
        }
        public string GetCriteriaString()
        {
            string criteriaString = "";
            if (chbCustCode.Checked && txtCustCode.Text.Trim() != "")
            {
                criteriaString = criteriaString + " AND Cust_Code = '" + txtCustCode.Text + "'";
            }
            if (chbVoucher.Checked && txtVoucherNo.Text.Trim() != "")
            {
                criteriaString = criteriaString + " AND Vouchar_No = '" + txtVoucherNo.Text + "'";
            }
            if (chbDW.Checked && ddlDepositWithdraw.Text.Trim() != "")
            {
                criteriaString = criteriaString + " AND Deposit_Withdraw = '" + ddlDepositWithdraw.Text + "'";
            }
            if (ChbRecievedDate.Checked)
            {
                criteriaString = criteriaString + " AND Received_Date = '" + dtRecievedDate.Value + "'";
            }
            return criteriaString;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            SearchInfo();
        }

        private void SearchInfo()
        {
            dtgShareDWSearchData.DataSource = null;
            string criteriaString = GetCriteriaString();
            if ((chbCustCode.Checked || chbVoucher.Checked || chbDW.Checked || ChbRecievedDate.Checked) && criteriaString.Trim() != "")
            {
                ShareDWBAL shareDwbal = new ShareDWBAL();
                DataTable datatable = shareDwbal.SearchForDelete(criteriaString);
                if (datatable.Rows.Count > 0)
                {
                    dtgShareDWSearchData.DataSource = datatable;
                    this.dtgShareDWSearchData.Columns[0].Visible = false;
                    dtgShareDWSearchData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    lblRecord.Text = "Total Record : " + dtgShareDWSearchData.Rows.Count;
                }
                else
                {
                    MessageBox.Show("No Data found. Please search with valid criteria.", "Invalid Search");
                }
            }
            else
            {
                MessageBox.Show("Please Select and Enter any search criteria of the customer.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dtgShareDWSearchData.SelectedRows)
            {
                _shareDWID = Convert.ToInt32(dtgShareDWSearchData[0, row.Index].Value);
               if (MessageBox.Show("Do you want to continue to delete the ShareDW Data?", "Question",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        ShareDWBAL shareDwbal = new ShareDWBAL();
                        shareDwbal.DeleteShareDW(_shareDWID);
                        MessageBox.Show("Deletion Successfull, Please Click on Process Button.", "Success.");
                        SearchInfoAgain();
                        btnProcessShareDW.Enabled = true;
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fail to delete the Share DW Data" + exc.Message);
                    }
                }
            }
        }

        private void SearchInfoAgain()
        {
            dtgShareDWSearchData.DataSource = null;
            string criteriaString = GetCriteriaString();
            if ((chbCustCode.Checked || chbVoucher.Checked || chbDW.Checked || ChbRecievedDate.Checked) && criteriaString.Trim() != "")
            {
                ShareDWBAL shareDwbal = new ShareDWBAL();
                DataTable datatable = shareDwbal.SearchForDelete(criteriaString);
                if (datatable.Rows.Count > 0)
                {
                    dtgShareDWSearchData.DataSource = datatable;
                    this.dtgShareDWSearchData.Columns[0].Visible = false;
                    dtgShareDWSearchData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            else
            {
                MessageBox.Show("Please Select and Enter any search criteria of the customer.");
            }
        }

        private void btnProcessShareDW_Click(object sender, EventArgs e)
        {
            try
            {
                ShareDWBAL shareDwbal = new ShareDWBAL();
                shareDwbal.ShareDWInitialProcessing();
                MessageBox.Show("Data Processed Successfully", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Can not process initial data. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchInfo();
            }

        }
    }
}
