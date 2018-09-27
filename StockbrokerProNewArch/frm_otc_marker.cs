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
    public partial class frm_otc_marker : Form
    {
        private OTCMarketBo oTCMarketBo = new OTCMarketBo();
        private ShareDWBAL shareDWBAL = new ShareDWBAL();
        private ShareDWBO shareDWBO = new ShareDWBO();
        private PaymentInfoBO payInfoBo = new PaymentInfoBO();
        private PaymentInfoBAL paymentinfobal = new PaymentInfoBAL();
        private PaymentInfoBO paymentInfoBo = new PaymentInfoBO();

        public frm_otc_marker()
        {
            InitializeComponent();
        }

        private void frm_otc_marker_Load(object sender, EventArgs e)
        {
            LoadCompanyShortCode();
        }


        public void ValueCalculation()
        {
            double Tradeqty = 0;
            double TradePrice = 0;
            double Value = 0;
            if(!string.IsNullOrEmpty(txtTradeQty.Text.Trim()))
                Tradeqty = Convert.ToDouble(txtTradeQty.Text.Trim());
            if(!string.IsNullOrEmpty(txtTradePrice.Text.Trim()))
                TradePrice = Convert.ToDouble(txtTradePrice.Text.Trim());
            Value = Tradeqty * TradePrice;
            txtValue.Text = Value.ToString();
            CommissionCalculate();
        }

        public void CommissionCalculate()
        {
            decimal commission = 0;
            decimal Value = 0;
            decimal TotalCommission = 0;
            commission = shareDWBAL.GetCommissionSearch(txtCustomerCode.Text.Trim(), cmdshareType.Text.Trim()); 
            Value = Convert.ToDecimal(txtValue.Text.Trim());
            TotalCommission = Value * commission;
            txtCommission.Text = (Math.Round(commission,3) * 100).ToString();
            txtTotalCommission.Text = (Math.Round(TotalCommission, 5)).ToString();
           

        }

        private void LoadCompanyShortCode()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Company");
            ddlCompanyShortCode.DataSource = dtData;
            ddlCompanyShortCode.DisplayMember = "Comp_Short_Code";
            ddlCompanyShortCode.ValueMember = "Comp_Short_Code";
            if (ddlCompanyShortCode.HasChildren)
                ddlCompanyShortCode.SelectedIndex = -1;
        }


        private void LoadCustInfo()
        {
            DataTable custDateTable = new DataTable();
            CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                custDateTable = customerInfoBAL.GetCustInfoByCustCode(txtCustomerCode.Text);
                if (custDateTable.Rows.Count > 0)
                {
                    txtCode.Text = custDateTable.Rows[0][0].ToString();
                    txtName.Text = custDateTable.Rows[0][1].ToString();
                    txtBoID.Text = custDateTable.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("No customer found.");
                }
            }           
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                if (txtCustomerCode.Text.Trim() == "")
                {
                    MessageBox.Show("Atfirst Enter the Customer Code/BO Id.");
                }
                else
                {
                    LoadCustInfo();
                }
            }
        }

        private void ddlCompanyShortCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataFromDataTable();
        }

        private void LoadDataFromDataTable()
        {
            DataTable companyDataTable = new DataTable();
            CompanyBAL companyBal = new CompanyBAL();
            if (ddlCompanyShortCode.SelectedIndex != -1)
                companyDataTable = companyBal.GetAllData(ddlCompanyShortCode.Text);
            if (companyDataTable.Rows.Count > 0)
            {
                txtInstrumentName.ReadOnly = true;
                txtInstrumentName.Text = companyDataTable.Rows[0]["Comp_Name"].ToString();                         

            }
        }

        private void txtTradeQty_TextChanged(object sender, EventArgs e)
        {
            ValueCalculation();
        }

        private void txtTradePrice_TextChanged(object sender, EventArgs e)
        {
            ValueCalculation();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
                return;

            if (cmdbuysell.Text.Trim() == BusinessAccessLayer.Constants.Indication_ShareTransactionMode.Withdraw.Trim())
            {
                if (CheckShareBalance())
                {
                    Save();
                    SavePaymentInfo();
                }
                else
                {
                    return;
                }
            }
            else
            {
                Save();
                SavePaymentInfo();
            }
            MessageBox.Show("Data Save Successfully");
            ClearText();

        }

        public void SavePaymentInfo()
        {
            PaymentInfoBO paymentInfoBo = new PaymentInfoBO();
            Payment_PostingBO postBo = new Payment_PostingBO();
            float floatTryParse;
            paymentInfoBo.RecievedDate = dtDate.Value;
            paymentInfoBo.RecievedBy = GlobalVariableBO._userName;
            paymentInfoBo.DepositWithdraw = "TR";
            paymentInfoBo.PaymentApprovedBy = null;
            paymentInfoBo.PaymentApprovedDate = null;
            paymentInfoBo.PaymentMedia = "TR";
            paymentInfoBo.Remarks = txtRemark.Text.Trim();
            paymentInfoBo.CustCode = txtTransferCode.Text;

            if (float.TryParse(txtTotalCommission.Text.Trim(), out floatTryParse))
                paymentInfoBo.Amount = floatTryParse;           

                paymentInfoBo.TransCustCode = txtCustomerCode.Text;
                paymentInfoBo.VoucherSlNo = txtVoucherNo.Text.Trim();          

            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
            paymentInfoBal.InsertintoPaymentPostingRequestForTR(paymentInfoBo);
        }

        public void Save()
        {
            oTCMarketBo.Cust_Code = txtCode.Text.Trim();
            oTCMarketBo.Deposit_type = "OTC";
            if (cmdbuysell.Text.Trim().ToUpper() == ("Buy").Trim().ToUpper())
                oTCMarketBo.Deposit_Withdraw = "Deposit";
            else if (cmdbuysell.Text.Trim().ToUpper() == ("Sell").Trim().ToUpper())
                oTCMarketBo.Deposit_Withdraw = "Withdraw";
            oTCMarketBo.Share_Type = cmdshareType.Text;
            oTCMarketBo.Comp_Short_Code = ddlCompanyShortCode.Text;
            oTCMarketBo.TradeQty = Convert.ToInt32(txtTradeQty.Text);
            oTCMarketBo.TradePrice = Convert.ToDecimal(txtTradePrice.Text);
            oTCMarketBo.Value = Convert.ToDecimal(txtValue.Text);
            if (!string.IsNullOrEmpty(txtHowlaCharge.Text))
                oTCMarketBo.HowlaCharge = Convert.ToDecimal(txtHowlaCharge.Text);
            oTCMarketBo.LagaCharge = Convert.ToDecimal(txtLagaCharge.Text);
            oTCMarketBo.Tax = Convert.ToDecimal(txtTax.Text);
            oTCMarketBo.VoucherNo = txtVoucherNo.Text.Trim();
            oTCMarketBo.Remark = txtRemark.Text.Trim();
            oTCMarketBo.TransferCode = txtTransferCode.Text.Trim();
            // Insert OTC 
            shareDWBAL.Insert_OTC_Share(oTCMarketBo);

            shareDWBO.CustCode = oTCMarketBo.Cust_Code;
            shareDWBO.CompanyShortCode = oTCMarketBo.Comp_Short_Code;
            shareDWBO.Quantity = Convert.ToInt32(oTCMarketBo.TradeQty);
            shareDWBO.LockedInQuantity = 0;
            shareDWBO.AvailableQuantity = 0;
            shareDWBO.DepositWithdraw = oTCMarketBo.Deposit_Withdraw;
            shareDWBO.RecordDate = dtDate.Value;
            shareDWBO.Received_Date = dtDate.Value;
            shareDWBO.VoucherNo = oTCMarketBo.VoucherNo;
            shareDWBO.NoScript = 0;
            shareDWBO.DepositType = oTCMarketBo.Deposit_type;
            shareDWBO.ShareType = oTCMarketBo.Share_Type;
            shareDWBO.IssuePrice = float.Parse(txtTradePrice.Text);
            shareDWBO.IssueAmount = float.Parse(txtValue.Text);
            shareDWBO.CDBLCharge = 0;
            // Share Deposit / Withdraw
            shareDWBAL.Insert(shareDWBO);
        }


        private bool CheckShareBalance()
        {
            if (!CompanyShareDoesExist())
            {
                MessageBox.Show(@"This company's share does not exist to withdraw for this client.");
                return false;
            }
            if (!ShareQtyDoesAvail())
            {
                MessageBox.Show(@"Share quantity exceeds the share Balance to withdraw for this client.");
                return false;
            }
            return true;

        }

        private bool ShareQtyDoesAvail()
        {
            ShareDWBAL shareDwbal = new ShareDWBAL();
            if (!shareDwbal.CheckShareQtyDoesAvail(Convert.ToInt32(txtTradeQty.Text), txtCustomerCode.Text, ddlCompanyShortCode.Text))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private bool CompanyShareDoesExist()
        {
            ShareDWBAL shareDwbal = new ShareDWBAL();
            if (!shareDwbal.CheckShareDoesExist(ddlCompanyShortCode.Text, txtCustomerCode.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                MessageBox.Show("Please Enter Customer Code", "InforMation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerCode.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(cmdbuysell.Text))
            {
                MessageBox.Show("Please Select Buy/Sell", "InforMation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdbuysell.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(cmdshareType.Text))
            {
                MessageBox.Show("Please Select Share Type.", "InforMation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdshareType.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(txtTradeQty.Text))
            {
                MessageBox.Show("Please Enter Trade Qty.", "InforMation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTradeQty.Focus();
                return true;
            }

            return false;
        }


        public void ClearText()
        {
            txtCode.Text = string.Empty;
            cmdbuysell.Text = string.Empty;
            cmdshareType.Text = string.Empty;
            txtTradeQty.Text = string.Empty;
            txtTradePrice.Text = string.Empty;
            txtValue.Text = string.Empty;
            txtTransferCode.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtBoID.Text = string.Empty;
            txtHowlaCharge.Text = string.Empty;
            txtLagaCharge.Text = string.Empty;
            txtTax.Text = string.Empty;
            txtVoucherNo.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtCommission.Text = string.Empty;
        }

        private void txtTradeQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits.");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTradePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only digits.");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btneftAutoVoucher_Click(object sender, EventArgs e)
        {
            txtVoucherNo.Text = "OTC|Comm.";
        }
    }
}
