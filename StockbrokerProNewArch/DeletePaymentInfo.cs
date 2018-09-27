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
    public partial class DeletePaymentInfo : Form
    {
        private int _paymentID;
        string voucherNo = string.Empty;
        private string modificationType = string.Empty;
        private DateTime receivedDate = DateTime.Today;
        private int _requisitionId;

        private bool searchButtonClick = false;

        private bool _isPaymentDelete = false;
        private bool _isPaymentOCCDelete = false;

        public DeletePaymentInfo()
        {
            InitializeComponent();
        }
        public string GetCriteriaString()
        {
            string criteriaStringPayment = "";
            if (chbCustCode.Checked && txtCustCode.Text.Trim() != "")
            {
                criteriaStringPayment = criteriaStringPayment + " AND Cust_Code = '" + txtCustCode.Text + "'";
            }
            if (chbVoucher.Checked && txtVoucherNo.Text.Trim() != "")
            {
                criteriaStringPayment = criteriaStringPayment + " AND Voucher_Sl_No = '" + txtVoucherNo.Text + "'";
            }
            if (chbDW.Checked && ddlDepositWithdraw.Text.Trim() != "")
            {
                criteriaStringPayment = criteriaStringPayment + " AND Deposit_Withdraw = '" + ddlDepositWithdraw.Text +
                                        "'";
            }
            if (ChbRecievedDate.Checked)
            {
                criteriaStringPayment = criteriaStringPayment + " AND Received_Date = '" + dtRecievedDate.Value + "'";
            }
            return criteriaStringPayment;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                searchButtonClick = true;
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            modificationType = "Delete";
            DataTable dtRequisitionId=new DataTable();
            DataTable dtPaymentId = new DataTable();
            foreach (DataGridViewRow row in this.dtgPaymentSearchData.SelectedRows)
            {
                _paymentID = Convert.ToInt32(dtgPaymentSearchData[0, row.Index].Value);
                string CustCode = Convert.ToString(dtgPaymentSearchData[1, row.Index].Value);
                string paymentMethod = Convert.ToString(dtgPaymentSearchData[3, row.Index].Value);
                string paymentMode = Convert.ToString(dtgPaymentSearchData[6, row.Index].Value);
                string voucher = Convert.ToString(dtgPaymentSearchData[5, row.Index].Value);

                if (MessageBox.Show("Do you want to continue to delete the Payment Data?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        if (!paymentInfoBal.IsRenewal_Transaction(_paymentID, paymentMethod))
                        {
                            if (
                                paymentInfoBal.GetApprovedReturnTransaction(_paymentID, paymentMethod, paymentMode).Rows
                                    .Count > 0)
                            {
                                if (
                                    MessageBox.Show(
                                        "You Have A Return Transaction As Approved Status!! Do you Want to Delete Also?",
                                        "Question", MessageBoxButtons.YesNo) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            if (
                                paymentInfoBal.GetPendingReturnTransaction(_paymentID, paymentMethod, paymentMode).Rows.
                                    Count > 0)
                            {
                                MessageBox.Show("Error!! You Have A Return Transaction As Pending Status!!");
                                return;
                            }
                            paymentInfoBal.DeletePaymentInfo(_paymentID, paymentMethod, paymentMode,modificationType);
                            MessageBox.Show("Deletion Successfull, Please Click on the Process Button.", "Success.");
                            btnProcessPayment.Enabled = true;
                        }
                        else
                        {
                            if(paymentMode==Indication_PaymentMode.Deposit)
                            {
                                dtRequisitionId = paymentInfoBal.GetRequisitionIDByDepositTransaction(_paymentID, paymentMethod,
                                                                      paymentMode);
                            }
                            else if(paymentMode==Indication_PaymentMode.Withdraw && (!(voucher.ToUpper().Trim()).Contains("BAC")))
                            {
                                dtRequisitionId = paymentInfoBal.GetRequisitionIDByWithdrawTransaction(_paymentID,
                                                                      paymentMethod,
                                                                      paymentMode);
                            }
                            else if (paymentMode == Indication_PaymentMode.Withdraw && ((voucher.ToUpper().Trim()).Contains("BAC")))
                            {
                                dtPaymentId =  paymentInfoBal.GetRequisitionIDByWithdrawTransaction_For_BAC_Voucher(_paymentID,
                                                                      paymentMethod,
                                                                      paymentMode, CustCode , voucher);
                            }
                            paymentInfoBal.DeleteRenewal_Transaction(dtRequisitionId);
                            if (dtPaymentId.Rows.Count > 0)
                            {
                                paymentInfoBal.DeleteRenewal_PaymentId(dtPaymentId);
                            }
                            MessageBox.Show("Deletion Successfull, Please Click on the Process Button.", "Success.");
                            btnProcessPayment.Enabled = true;
                        }
                        LoadGrid();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fail to delete the Payment Data" + exc.Message);
                    }
                }
            }
            LoadGrid();
        }

        private void chbCustCode_CheckedChanged(object sender, EventArgs e)
        {
            if (_isPaymentDelete)
            {
                txtCustCode.Enabled = chbCustCode.Checked;
                txtCustCode.Text = "";
            }
            else if (_isPaymentOCCDelete)
            {
                txtOCCCustCode.Enabled = ckbOCCCustCode.Checked;
                txtOCCCustCode.Text = "";
            }
        }

        private void chbDW_CheckedChanged(object sender, EventArgs e)
        {
            if (_isPaymentDelete)
            {
                ddlDepositWithdraw.Enabled = chbDW.Checked;
                ddlDepositWithdraw.SelectedIndex = 0;
            }
            else if (_isPaymentOCCDelete)
            {
                ddlOCCDepositWithdraw.Enabled = ckbOCCDW.Checked;
                ddlOCCDepositWithdraw.SelectedIndex = 0;
            }
        }

        private void chbVoucher_CheckedChanged(object sender, EventArgs e)
        {
            if (_isPaymentDelete)
            {
                txtVoucherNo.Enabled = chbVoucher.Checked;
                txtVoucherNo.Text = "";
            }
            else if (_isPaymentOCCDelete)
            {
                txtOCCVoucherNo.Enabled = ckbOCCVoucher.Checked;
                txtOCCVoucherNo.Text = "";
            }
        }

        private void ChbRecievedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (_isPaymentDelete)
            {
                dtRecievedDate.Enabled = ChbRecievedDate.Checked;
                dtRecievedDate.Value = DateTime.Today;
            }
            else if (_isPaymentOCCDelete)
            {
                dtOCCRecievedDate.Enabled = ckbOCCRecievedDate.Checked;
                dtOCCRecievedDate.Value = DateTime.Today;
            }
        }

        private void DeletePaymentInfo_Load(object sender, EventArgs e)
        {
            dtRecievedDate.Text = System.DateTime.Now.ToString();
            Init();
            _isPaymentDelete = true;
        }

        private void Init()
        {
            if (_isPaymentDelete)
            {
                txtVoucherNo.Enabled = false;
                txtCustCode.Enabled = false;
                dtRecievedDate.Enabled = false;
                ddlDepositWithdraw.Enabled = false;
                btnProcessPayment.Enabled = false;
            }
            else if (_isPaymentOCCDelete)
            {
                txtOCCVoucherNo.Enabled = false;
                txtOCCCustCode.Enabled = false;
                dtOCCRecievedDate.Enabled = false;
                ddlOCCDepositWithdraw.Enabled = false;
                btnOCCProcessPayment.Enabled = false;
            }
        }

        private void LoadGrid()
        {
            dtgPaymentSearchData.DataSource = null;
            string criteriaString = GetCriteriaString();
            if ((chbCustCode.Checked || chbVoucher.Checked || chbDW.Checked || ChbRecievedDate.Checked) &&
                criteriaString.Trim() != string.Empty)
            {
                PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                DataTable datatable = paymentInfoBal.SearchForDelete(criteriaString, _isPaymentDelete,
                                                                     _isPaymentOCCDelete);
                if (datatable.Rows.Count > 0)
                {
                    dtgPaymentSearchData.DataSource = datatable;
                    this.dtgPaymentSearchData.Columns[0].Visible = false;
                    dtgPaymentSearchData.Columns[0].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                    dtgPaymentSearchData.Columns["Requisition_ID"].Visible = false;
                    lblRecord.Text = "Total Record : " + dtgPaymentSearchData.Rows.Count.ToString();
                }
                if (datatable.Rows.Count == 0 && searchButtonClick == true)
                {
                    throw new Exception(" No Data found. Please search with valid criteria.");
                }
            }
            else
            {
                MessageBox.Show("Please Select and Enter any search criteria of the customer.","Information.",MessageBoxButtons.OK,MessageBoxIcon.Information);               
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                paymentInfoBal.PaymentInitialProcessing();
                MessageBox.Show("Data Processed Successfully", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchButtonClick = false;
                LoadGrid();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Can not process initial data. Because : " + exception.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        //-----------------Delete Payment OCC Section-------------------------//
        private void ckbOCCCustCode_CheckedChanged(object sender, EventArgs e)
        {
            chbCustCode_CheckedChanged(sender,e);
        }

        private void ckbOCCVoucher_CheckedChanged(object sender, EventArgs e)
        {
            chbVoucher_CheckedChanged(sender,e);
        }

        private void ckbOCCDW_CheckedChanged(object sender, EventArgs e)
        {
            chbDW_CheckedChanged(sender,e);
        }

        private void ckbOCCRecievedDate_CheckedChanged(object sender, EventArgs e)
        {
            ChbRecievedDate_CheckedChanged(sender,e);
        }

        private void btnOCCGo_Click(object sender, EventArgs e)
        {
            btnGo_Click(sender,e);
        }

        private void btnOCCProcessPayment_Click(object sender, EventArgs e)
        {
            btnProcessPayment_Click(sender,e);
        }

        private void btnOCCDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }

        private void btnOCCClose_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender,e);
        }

        private void tabDelete_Payment_PaymentOCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabDelete_Payment_PaymentOCC.SelectedIndex==0)
            {
                _isPaymentDelete = true;
                _isPaymentOCCDelete = false;
            }
            if(tabDelete_Payment_PaymentOCC.SelectedIndex==1)
            {
                _isPaymentDelete = false;
                _isPaymentOCCDelete = true;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PaymentInfoBAL paymentInfoBal=new PaymentInfoBAL();
            modificationType = "Edit";
            int tryParse = 0;
            if (btnEdit.Text == @"Edit")
            {
                foreach (DataGridViewRow row in this.dtgPaymentSearchData.SelectedRows)
                {
                    _paymentID = Convert.ToInt32(dtgPaymentSearchData[0, row.Index].Value);
                    if (int.TryParse(dtgPaymentSearchData[8, row.Index].Value.ToString(), out tryParse))
                    {
                        _requisitionId = tryParse;
                    }
                    voucherNo = dtgPaymentSearchData[5, row.Index].Value.ToString();
                    receivedDate = Convert.ToDateTime(dtgPaymentSearchData[7, row.Index].Value);
                    SetForEdit(voucherNo, receivedDate);
                    btnEdit.Text = @"Save";
                }
            }
            else if(btnEdit.Text==@"Save")
            {
                paymentInfoBal.EditPaymentInfoData(_paymentID,_requisitionId,voucherNo,dtRecievedDate.Value,modificationType);
                btnEdit.Text = @"Edit";
                txtVoucherNo.Enabled = true; 
                ddlDepositWithdraw.Enabled = true;
                MessageBox.Show(@"Information Edited Successfully");
                LoadGrid();
            }
            LoadGrid();
        }
        private void SetForEdit(string _voucherNo,DateTime _receivedDate)
        {
            txtVoucherNo.Text = _voucherNo;
            txtVoucherNo.Enabled = false;
            ddlDepositWithdraw.Enabled = false;
            dtRecievedDate.Value = _receivedDate;
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                LoadGrid();
            }
        }

        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadGrid();
            }
        }

        private void ddlDepositWithdraw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadGrid();
            }
        }

        private void dtRecievedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadGrid();
            }
        }

        private void tabDelete_Payment_PaymentOCC_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpDeletePaymentOCC)
                e.Cancel = true;
        }
    }
}
