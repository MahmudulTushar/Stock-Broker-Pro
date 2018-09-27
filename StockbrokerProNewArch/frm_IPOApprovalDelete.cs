using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.Constants;

namespace StockbrokerProNewArch
{
    public partial class frm_IPOApprovalDelete : Form
    {
        IPOProcessBAL ipoBal = new IPOProcessBAL();
        string _custcode = "";
        string _recidency = "";
        string SessionId = "";
        DateTime? Star_Date;

        string remarks = "";
        string voucher = "";
        string transName = "";
        string Dep_With = "";

        public frm_IPOApprovalDelete()
        {
            InitializeComponent();
        }

        private void Load_Info()
        {
            ckhCustCode.Checked = true;
            cmbAppliedCompany.Enabled = false;
            chkAppliedCompany.Checked = false;
            ChkVoucher.Checked = false;
            chkremarks.Checked = false;
            chkMoneyTransaction.Checked = false;
            chkDepositWithdraw.Checked = false;
            cmbDepositWithdraw.Enabled = false;
            cmbMoneytransaction.Enabled = false;
            txtremarks.Enabled = false;
            txtvoucher.Enabled = false;
        }

        private void LoadDeleteData()
        {
            _recidency = "";
            DataTable dt = new DataTable();
            DataTable dt_Custinfo = new DataTable();
            CustomerInfoBAL C_Bal = new CustomerInfoBAL();
            if (ckhCustCode.Checked == true)
            {
                _custcode = txtcustcode.Text;
                dt_Custinfo = C_Bal.GetCustInfoByCustCode(_custcode);
                _recidency = Convert.ToString(dt_Custinfo.Rows[0]["Recidency"]);
            }
            if (chkAppliedCompany.Checked == true)
            {
                SessionId = Convert.ToString(cmbAppliedCompany.SelectedValue);
            }
            else
            {
                SessionId = "";
            }
            if (ChkDateSelection.Checked == true)
            {
                Star_Date = dtpFromDate.Value.Date;

            }
            else
            {
                Star_Date = null;
            }
            if (ChkVoucher.Checked == true)
            {
                voucher = txtvoucher.Text;
            }
            else
            {
                voucher = "";
            }
            if (chkremarks.Checked == true)
            {
                remarks = txtremarks.Text;
            }
            else
            {
                remarks = "";
            }
            if (chkDepositWithdraw.Checked == true)
            {
                //cmbDepositWithdraw.SelectedIndex = 0;
                Dep_With = cmbDepositWithdraw.Text;
            }
            else
            {
                cmbDepositWithdraw.SelectedIndex = -1;
            }
            if (chkMoneyTransaction.Checked == true)
            {
                transName = cmbMoneytransaction.Text;
            }
            else
            {
                transName = "";
            }
            //if (chkDepositWithdraw.Checked == true)
            //{
            //    Dep_With = cmbDepositWithdraw.Text;
            //}
            //else
            //{
            //    Dep_With = "";
            //}
            if (_recidency == "Resident")
            {
                dt = ipoBal.GetIPOAppliedCompany_ForDelete(_custcode, SessionId, Star_Date, voucher, remarks, transName, Dep_With);
            }
            if (_recidency == "Non Resident")
            {
                dt = ipoBal.GetIPO_NRB_DraftInformation(string.Empty, Convert.ToString(SessionId));
                var NRB_Data = dt.Rows.Cast<DataRow>().Where(c => Convert.ToString(c["Approval_Status"]) == "1"
                    && Convert.ToString(c["Cust_Code"]) == _custcode
                    && Convert.ToString(c["Intended_IPOSession_ID"]) == Convert.ToString(SessionId)).ToList();
                if (NRB_Data.Count > 0)
                {
                    dt = NRB_Data.CopyToDataTable();
                }
                else
                {
                    dt = null;
                }
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dgLoadDeleteData.DataSource = dt;
                    dgLoadDeleteData.Columns["ID"].Visible = false;
                }
            }
            else
            {
                dgLoadDeleteData.DataSource = null;
                MessageBox.Show("Data Not Found");
            }
        }

        private void LoadDataAfterDelete()
        {
            DataTable dt = new DataTable();
            dt = ipoBal.GetIPOAppliedCompany_ForDelete(_custcode, SessionId, Star_Date, voucher, remarks, transName, Dep_With);
            dgLoadDeleteData.DataSource = dt;
        }

        private void ckhCustCode_CheckedChanged(object sender, EventArgs e)
        {
            if ((ckhCustCode.Checked))
            {
                txtcustcode.Enabled = true;
                _custcode = txtcustcode.Text;
            }
            else
            {
                txtcustcode.Enabled = false;
            }
        }

        private void chkAppliedCompany_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtCompany = new DataTable();
            dtCompany = ipoBal.GetCompanyShortCodeAndSessionID();
            if (chkAppliedCompany.Checked)
            {
                cmbAppliedCompany.Enabled = true;
                cmbAppliedCompany.DisplayMember = "Code";
                cmbAppliedCompany.ValueMember = "ID";
                cmbAppliedCompany.DataSource = dtCompany;
                SessionId = Convert.ToString(cmbAppliedCompany.SelectedValue);
            }
            else
            {
                cmbAppliedCompany.Enabled = false;
                cmbAppliedCompany.Text = "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkDateSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDateSelection.Checked == true)
            {

            }
            else
            {

            }
        }

        private void frm_IPOApprovalDelete_Load(object sender, EventArgs e)
        {
            Load_Info();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                LoadDeleteData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgLoadDeleteData_SelectionChanged(object sender, EventArgs e)
        {
            /*
            var SelectRows = dgLoadDeleteData.SelectedRows;
            if (SelectRows.Count > 0)
            {
                string Customer_Code = SelectRows[0].Cells["Cust_Code"].Value.ToString();
                SelectSameCustCode(Customer_Code);
            }
            */
        }
        /*
        private void SelectSameCustCode(string Code)
        {
            for (int i = 0; i < dgLoadDeleteData.Rows.Count; i++)
            {
                if (Convert.ToString(dgLoadDeleteData.Rows[i].Cells["Cust_Code"].Value) == Code)
                {
                    dgLoadDeleteData.Rows[i].Selected = true;
                }
            }
        }
        */
        private void chkMoneyTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoneyTransaction.Checked)
            {
                DataTable dt = new DataTable();
                dt = ipoBal.GetIPOMoneyTransType();
                cmbMoneytransaction.DataSource = dt;
                cmbMoneytransaction.DisplayMember = dt.Columns["Name"].ToString();
                cmbMoneytransaction.ValueMember = dt.Columns["ID"].ToString();
                cmbMoneytransaction.Enabled = true;
            }
            else
            {
                cmbMoneytransaction.Text = "";
                cmbMoneytransaction.Enabled = false;
            }
        }

        private void chkDepositWithdraw_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDepositWithdraw.Checked)
            {
                cmbDepositWithdraw.SelectedIndex = 0;
                cmbDepositWithdraw.Enabled = true;
            }
            else
            {
                cmbDepositWithdraw.SelectedIndex = -1;
                cmbDepositWithdraw.Enabled = false;
            }
        }

        private void ChkVoucher_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkVoucher.Checked)
            {
                txtvoucher.Enabled = true;
                voucher = txtvoucher.Text;
            }
            else
            {
                txtvoucher.Enabled = false;
                txtvoucher.Text = "";
                voucher = "";
            }
        }

        private void chkremarks_CheckedChanged(object sender, EventArgs e)
        {
            if (chkremarks.Checked)
            {
                txtremarks.Enabled = true;
                remarks = txtremarks.Text;
            }
            else
            {
                txtremarks.Enabled = false;
                txtremarks.Text = "";
                remarks = "";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataTable dt_Custinfo = new DataTable();
            CustomerInfoBAL C_Bal = new CustomerInfoBAL();
            string cust_code = "";
            string DepositId = "";
            string[] Session_ID = null;
            string[] TransReason = null;
            string Join_SessionId = "";
            string Join_TransReason = "";
            int paymentPostingId = 0;
            string Status = "";
            try
            {
                if (dgLoadDeleteData.SelectedRows.Count > 0)
                {
                    cust_code = dgLoadDeleteData.SelectedRows.Cast<DataGridViewRow>()
                      .Select(c => Convert.ToString(c.Cells["Cust_Code"].Value)).FirstOrDefault();
                    dt_Custinfo = C_Bal.GetCustInfoByCustCode(cust_code);
                    _recidency = Convert.ToString(dt_Custinfo.Rows[0]["Recidency"]);
                    if (_recidency == "Resident")
                    {
                        _recidency = Convert.ToString(dt_Custinfo.Rows[0]["Recidency"]);
                        DepositId = dgLoadDeleteData.SelectedRows.Cast<DataGridViewRow>()
                            .Select(c => Convert.ToString(c.Cells["ID"].Value)).FirstOrDefault();
                        Session_ID = dgLoadDeleteData.SelectedRows.Cast<DataGridViewRow>()
                          .Select(c => Convert.ToString(c.Cells["Session_ID"].Value)).ToArray();
                        TransReason = dgLoadDeleteData.SelectedRows.Cast<DataGridViewRow>()
                           .Select(c => Convert.ToString(c.Cells["Trans_Reason"].Value)).ToArray();
                        Status = dgLoadDeleteData.SelectedRows.Cast<DataGridViewRow>()
                            .Select(c => Convert.ToString(c.Cells["Status"].Value)).FirstOrDefault();
                        Join_SessionId = string.Join(",", Session_ID);
                        Join_TransReason = string.Join(",", TransReason);
                        if (Join_TransReason != "")
                        {
                            paymentPostingId = Convert.ToInt32(Join_TransReason.Split('_').Last());
                        }
                        ipoBal.DeleteDepositInfo(Convert.ToInt32(DepositId), Convert.ToInt32(paymentPostingId), Status);
                        MessageBox.Show("Approval Data Delete Succussfully");
                        Load_Info();
                        LoadDataAfterDelete();
                    }
                    else if (_recidency == "Non Resident")
                    {
                        int id = dgLoadDeleteData.SelectedRows.Cast<DataGridViewRow>()
                            .Select(c => Convert.ToInt32(c.Cells["ID"].Value)).First();
                        ipoBal.GetNRB_DeleteData(id);
                        MessageBox.Show("Approval Data Delete Succussfully");
                        LoadDeleteData();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
