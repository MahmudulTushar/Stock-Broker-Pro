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
    public partial class DepositPayment : Form
    {
        private string _boID = "";
        private string _custCode = "";
        private string _depositBank = "";
        private string _depositBranch = "";
        private DateTime _searchDate;
        private string _status;
        private int _paymentID;
        public DepositPayment()
        {
            InitializeComponent();
        }

        private void CheckDeposite_Load(object sender, EventArgs e)
        {
            Init();
            ddlDepositBank.SelectedIndex = 0;
            txtRecievedBy.Text = GlobalVariableBO._userName;
            txtSearchCustomer.Focus();
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
            _searchDate = dtDepositReceivedDate.Value;
            DataTable datatable = paymentInfoBal.GetGridData(_searchDate);
            dtgDepositListInfo.DataSource = datatable;
            this.dtgDepositListInfo.Columns[0].Visible = false;
            dtgDepositListInfo.Columns["Amount"].DefaultCellStyle.Format = "N";
            dtgDepositListInfo.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDepositListInfo.Columns["Received Date"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            dtgDepositListInfo.Columns["Received Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblTotalDep.Text = "Total Deposit: " + dtgDepositListInfo.Rows.Count.ToString();

        }

        private void Init()
        {
            ddlSearchCustomer.SelectedIndex = 0;
            ddlPaymentMedia.SelectedIndex = 0;
            chkMatureToday.Visible = false;
            txtSearchCustomer.Focus();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            SearchCustomerInformation();
        }
        private void SearchCustomerInformation()
        {
            if (txtSearchCustomer.Text.Trim() != "")
            {
                txtlastTradeDate.Text = "";
                DataTable custDateTable = new DataTable();
                CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
                if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
                {
                    _boID = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);
                    if (custDateTable.Rows.Count > 0)
                    {
                        PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        string _custCode = custDateTable.Rows[0][0].ToString();

                        txtCurrentBalance.Text = paymentInfoBal.GetCurrentBalane(_custCode).ToString("N");
                        txtMaturedBalance.Text = paymentInfoBal.GetMaturedBalane(_custCode).ToString("N");
                        txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_ID"].ToString();
                        txtlastTradeDate.Text = custDateTable.Rows[0]["LTD"].ToString();
                        txtStatus.Text = custDateTable.Rows[0]["Status"].ToString();
                        txtBOStatus.Text = custDateTable.Rows[0]["BO_Status"].ToString();
                        txtStatus.ForeColor = txtStatus.Text == "Closed" ? Color.Red : Color.Blue;
                        txtBOStatus.ForeColor = txtBOStatus.Text == "Closed" ? Color.Red : Color.Blue;
                    }
                    else
                    {
                        MessageBox.Show("No customer found.");
                        return;
                    }
                }
                else
                {
                    _custCode = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);

                    if (custDateTable.Rows.Count > 0)
                    {

                        PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                        txtCurrentBalance.Text = paymentInfoBal.GetCurrentBalane(_custCode).ToString("N");
                        txtMaturedBalance.Text = paymentInfoBal.GetMaturedBalane(_custCode).ToString("N");
                        txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                        txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                        txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_ID"].ToString();
                        txtlastTradeDate.Text = custDateTable.Rows[0]["LTD"].ToString();
                        txtStatus.Text = custDateTable.Rows[0]["Status"].ToString();
                        txtBOStatus.Text = custDateTable.Rows[0]["BO_Status"].ToString();
                        txtStatus.ForeColor = txtStatus.Text == "Closed" ? Color.Red : Color.Blue;
                        txtBOStatus.ForeColor = txtBOStatus.Text == "Closed" ? Color.Red : Color.Blue;

                    }
                    else
                    {
                        MessageBox.Show("No customer found.");
                        return;
                    }
                }

                if (Convert.ToDouble(txtCurrentBalance.Text) <= 0)
                {
                    txtCurrentBalance.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtCurrentBalance.BackColor = System.Drawing.Color.GreenYellow;
                }

                if (Convert.ToDouble(txtMaturedBalance.Text) <= 0)
                {
                    txtMaturedBalance.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtMaturedBalance.BackColor = System.Drawing.Color.GreenYellow;
                }
                txtAmount.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchCustomerInformation();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadSaveInformation();
        }
        private void LoadSaveInformation()
        {
            if (ddlSearchCustomer.SelectedIndex == 0)
            {
                if (txtCustCode.Text != txtSearchCustomer.Text)
                {
                    SearchCustomerInformation();
                    return;
                }
            }
            else
            {
                if (txtAccountHolderBOId.Text != txtSearchCustomer.Text)
                {
                    SearchCustomerInformation();
                    return;
                }
            }
            if (txtStatus.Text.Equals("Closed"))
            {
                if (DialogResult.No == MessageBox.Show("This is a Closed Account. Sure you want to continue?", "Closed Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    ClearAll();
                    txtSearchCustomer.Focus();
                    return;
                }
            }
            SavePaymentInfo();
        }
        private void SavePaymentInfo()
        {
            if (txtSearchCustomer.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Customer Code.");
                return;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Amount.");
                return;
            }
            if (txtAmount.Text.Trim() == "0")
            {
                MessageBox.Show("Please Enter Valid Amount.");
                return;
            }
            if (ddlPaymentMedia.Text == "Cash")
            {
                if (txtSerialNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please Generate the Serial Number.");
                    return;
                }
            }
            else
            {
                if (txtPaymentMedia.Text.Trim() == "")
                {
                    MessageBox.Show("Please Fill the Cheque No.");
                    return;
                }
                if (txtSerialNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please Generate the Serial Number.");
                    return;
                }

            }

            try
            {
                PaymentInfoBO paymentInfoBo=new PaymentInfoBO();
                paymentInfoBo.CustCode = txtCustCode.Text;
                if (!String.IsNullOrEmpty(txtAmount.Text.Trim()))
                    paymentInfoBo.Amount = float.Parse(txtAmount.Text);
               
                if (ddlPaymentMedia.Text == "Cash")
                {

                    paymentInfoBo.PaymentMedia = "Cash";
                    paymentInfoBo.VoucherSlNo = txtSerialNo.Text;
                }

                else //Non Cash
                {
                    paymentInfoBo.IsMatureToday = Convert.ToInt32(chkMatureToday.Checked);
                    if(ddlPaymentMedia.Text.Equals("Cheque"))
                    {
                        paymentInfoBo.PaymentMedia = "Check";
                    }

                    else //Non Cheque
                    {
                        paymentInfoBo.PaymentMedia = ddlPaymentMedia.Text;
                    }
                    
                    paymentInfoBo.PaymentMediaNo = txtPaymentMedia.Text;
                    paymentInfoBo.PaymentMediaDate = dtPaymentMediaDate.Value;
                    paymentInfoBo.BankName = txtBankName.Text;
                    paymentInfoBo.BranchName = txtBranchName.Text;
                    paymentInfoBo.VoucherSlNo = txtSerialNo.Text;

                }

                paymentInfoBo.RecievedDate = dtRecievedDate.Value;
                paymentInfoBo.RecievedBy = txtRecievedBy.Text;
                paymentInfoBo.DepositWithdraw = "Deposit";
                paymentInfoBo.PaymentApprovedBy = null;
                paymentInfoBo.PaymentApprovedDate = null;
                paymentInfoBo.Remarks = txtRemarks.Text;
                _depositBank = ddlDepositBank.Text;
                _depositBranch = txtDepositBranch.Text;
                try
                {
                    PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                    paymentInfoBal.InsertintoPaymentPosting(paymentInfoBo);//,_depositBank,_depositBranch);
                    MessageBox.Show("Payment Depsoit Information Saved Successfully.");
                    LoadDataIntoGrid();
                    ClearAll();
                    txtSearchCustomer.Focus();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail to save Payment Depsoit Information because of the Error : " + ex.Message);
                }


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);

            }

        }
        private void ClearAll()
        {
            txtStatus.Text = "";
            txtSerialNo.Text = "";
            txtPaymentMedia.Text = "";
            txtBranchName.Text = "";
            txtBankName.Text = "";
            txtSearchCustomer.Text = "";
            txtRemarks.Text = "";
            txtCustCode.Text = "";
            txtAmount.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
            txtCurrentBalance.Text = "";
            txtMaturedBalance.Text = "";
            ddlSearchCustomer.SelectedIndex = 0;
            ddlPaymentMedia.SelectedIndex = 0;
            chkMatureToday.Checked = false;
            chkMatureToday.Visible = false;
            dtRecievedDate.Value = DateTime.Now;
            txtlastTradeDate.Text = "";
            txtCurrentBalance.BackColor = System.Drawing.Color.LightGray;
            txtMaturedBalance.BackColor = System.Drawing.Color.LightGray;
            txtSearchCustomer.Focus();

        }

        private void ddlPaymentMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPanelData();
        }
        private void LoadPanelData()
        {
            txtBranchName.Enabled = (ddlPaymentMedia.Text != "Cash");
            txtBankName.Enabled = (ddlPaymentMedia.Text != "Cash");
            txtPaymentMedia.Enabled = (ddlPaymentMedia.Text != "Cash");
            dtPaymentMediaDate.Enabled = (ddlPaymentMedia.Text != "Cash");
            chkMatureToday.Visible = (ddlPaymentMedia.Text == "Check");
        }

        private void btnGenerateSerial_Click(object sender, EventArgs e)
        {
            PaymentInfoBAL paymentBal = new PaymentInfoBAL();
            txtSerialNo.Text = paymentBal.GenerateSerial();
        }

        private void btnDepositCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgDepositListInfo.Rows.Count > 0)
                {
                    if (dtgDepositListInfo.SelectedRows[0].Cells["Status"].Value.ToString().Equals("Pending"))
                    {
                        if (MessageBox.Show("Do you want to continue to cancel the Deposit?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            LoadDataFromGrid();
                            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                            paymentInfoBal.CancelDeposit(_paymentID);
                            MessageBox.Show("Deposit Request successfully Canceled.");
                            LoadDataIntoGrid();

                        }
                    }

                    else
                    {
                        MessageBox.Show("The Selected Deposit has allready " + dtgDepositListInfo.SelectedRows[0].Cells["Status"].Value.ToString() + ". It Can not be Cancel.", "Invalid Selection.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                else
                {
                    MessageBox.Show("No customer exists for Cancel Deposit", "Invalid Selection.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
        }

        private void LoadDataFromGrid()
        {
            foreach (DataGridViewRow row in this.dtgDepositListInfo.SelectedRows)
            {
                if (dtgDepositListInfo[0, row.Index].Value != DBNull.Value)
                    _paymentID = Convert.ToInt32(dtgDepositListInfo[0, row.Index].Value);
                _status = dtgDepositListInfo[7, row.Index].Value.ToString();
            }
           
        }

        private void dtgDepositListInfo_SelectionChanged(object sender, EventArgs e)
        {
            LoadDataFromGrid();
        }

        private void dtDepositReceivedDate_ValueChanged(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                LoadSaveInformation();
            }
        }

        private void dtDepositReceivedDate_ValueChanged_1(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }
    }
}
