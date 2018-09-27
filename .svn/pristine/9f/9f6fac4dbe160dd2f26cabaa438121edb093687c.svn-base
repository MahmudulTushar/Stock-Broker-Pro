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
using BusinessAccessLayer.Constants;

namespace StockbrokerProNewArch
{
    public partial class frmPaymentOOC : Form
    {
        
        private int ID ;
        private string MediaType=string.Empty ;

        public frmPaymentOOC()
        {
            InitializeComponent();
        }

        private void frmPaymentOOC_Load(object sender, EventArgs e)
        {
            lblBranchName.Text = "Branch : " + GlobalVariableBO._branchName;
            ddlPaymentMedia.SelectedIndex = 0;
            GetPurposeList();
            GetOCCPurpose();
            GetPaymentOccInfo(dtpSearchDate.Value);
        }
        private double GetTotalAmount()
        {
            double totalAmount = 0;
            double doubleTryParse;
            foreach (DataGridViewRow dgvr in dgvPaymentOOcInfo.Rows)
            {
                if (double.TryParse(dgvr.Cells["Amount"].Value.ToString(), out doubleTryParse))
                {
                    totalAmount = totalAmount + doubleTryParse;
                }
            }
            return totalAmount;
        }

        private void GetPaymentOccInfo(DateTime date)
        {
            int FilterId = 0;
            string TitleName = string.Empty;
            try
            {
                PaymentOOC ObjPaymentOOCBAL = new PaymentOOC();
                DataTable data = new DataTable();

                data = ObjPaymentOOCBAL.GetPaymentOccInfo(date, TitleName, FilterId);

                dgvPaymentOOcInfo.DataSource = data;
                dgvPaymentOOcInfo.Columns[0].Visible = false;
                dgvPaymentOOcInfo.Columns["Period"].DefaultCellStyle.Format = "yyyy";
                dgvPaymentOOcInfo.Columns["Period"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                dgvPaymentOOcInfo.Columns["Amount"].DefaultCellStyle.Format = "N";
                dgvPaymentOOcInfo.Columns["Amount"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;

                lblTotalRecord.Text = "Total Record : " + dgvPaymentOOcInfo.Rows.Count.ToString();
                lblTotalAmount.Text = "Total Amount Tk.: " + String.Format("{0:n}", GetTotalAmount());
                // ObjPaymentOOCBAL.GetAmount(date));

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetOCCPurpose()
        {
            try
            {
                paymentOCCPaurpose objPaymentOCC = new paymentOCCPaurpose();

                if (ddlPaymentPurpose.Text.Trim() != String.Empty)
                {
                    txtAmount.Text = objPaymentOCC.GetOOCPurpose(Int32.Parse(ddlPaymentPurpose.SelectedValue.ToString())).ToString();
                }

                else
                {
                    txtAmount.Text = "0.00";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPurpose_Click(object sender, EventArgs e)
        {
            frmAddPaymentOOCPurpose objpayment = new frmAddPaymentOOCPurpose();
            objpayment.ShowDialog();
            GetPurposeList();
            GetOCCPurpose();
        }

        private void GetCustomerInfo()
        {
            try
            {
                PaymentOOC objPaymentOOC = new PaymentOOC();
                DataTable data = new DataTable();
                string custStatus = string.Empty;
                ClerCustInfo();
                data = objPaymentOOC.CustomerInfo(txtCustomerCode.Text);
                if (data.Rows.Count > 0)
                {
                    txtFinalCustomerCode.Text = txtCustomerCode.Text;
                    txtName.Text = data.Rows[0]["Cust_Name"].ToString();
                    txtBOID.Text = data.Rows[0]["BO_ID"].ToString();
                    txtCurrentBalence.Text = data.Rows[0]["CurrentBalence"].ToString();
                    txtMaturedBalence.Text = data.Rows[0]["Matured Balence"].ToString();
                    txtAccountStatus.Text = data.Rows[0]["Cust_Status"].ToString();


                    if (float.Parse(data.Rows[0]["CurrentBalence"].ToString()) > 0)
                    {
                        txtCurrentBalence.BackColor = Color.GreenYellow;

                    }

                    else
                    {
                        txtCurrentBalence.BackColor = Color.IndianRed;

                    }

                    if (float.Parse(data.Rows[0]["Matured Balence"].ToString()) > 0)
                    {
                        txtMaturedBalence.BackColor = Color.GreenYellow;

                    }

                    else
                    {
                        txtMaturedBalence.BackColor = Color.IndianRed;

                    }

                    if (data.Rows[0]["Cust_Status"].ToString() == "Active")
                    {
                        txtAccountStatus.BackColor = Color.GreenYellow;

                    }

                    else if (data.Rows[0]["Cust_Status"].ToString() == "Closed")
                    {
                        txtAccountStatus.BackColor = Color.IndianRed;

                    }
                }
                else
                {
                    MessageBox.Show("No Customer found", "Customer Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetPurposeList()
        {
            try
            {
                paymentOCCPaurpose objOccpurpose = new paymentOCCPaurpose();
                DataTable data = new DataTable();
                data = objOccpurpose.GetOCCPurposeList(string.Empty);
                ddlPaymentPurpose.DisplayMember = "OCC_Purpose";
                ddlPaymentPurpose.ValueMember = "OCC_ID";
                ddlPaymentPurpose.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClerCustInfo()
        {
            txtFinalCustomerCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtBOID.Text = string.Empty;
            txtCurrentBalence.Text = string.Empty;
            txtMaturedBalence.Text = string.Empty;
            txtAccountStatus.Text = string.Empty;
        }
        private void SearchCustomerInfo()
        {
            if (txtCustomerCode.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Customer Code Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
            }

            else
            {
                GetCustomerInfo();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCustomerInfo();
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchCustomerInfo();
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ddlPaymentPurpose.SelectedValue) != Indication_PaymentOccPurpose.AccountClosing)
                {
                    SaveToDatabase();
                    dtpPaymentDate.Focus();
                }
                else
                {
                    MessageBox.Show("Account Closing Is Blocked From Here");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save fail because of : " + ex.Message);
            }
        }

        //private bool IsValidCharge()
        //{
        //    bool isValid = true;
        //    PaymentOOC objpaymentOcc = new PaymentOOC();
        //    double BO_OpenCharge = 0;
        //  //  BO_OpenCharge = objpaymentOcc.GetBO_OpenCharge(Convert.ToInt32(ddlPaymentPurpose.SelectedValue.ToString()));
        //    //if (Convert.ToDouble(txtAmount.Text.ToString()) < BO_OpenCharge + Indication_TransWithFixedAmount.BO_Renewal_Charge) 

        //    if (Convert.ToDouble(txtAmount.Text.ToString()) < Indication_TransWithFixedAmount.BO_Renewal_Charge) 
        //    {
        //        MessageBox.Show("Insufficient Balance");
        //        isValid = false;
        //    }
        //    return isValid;
        //}

        private bool IsValidInput()
        {
            if (txtAmount.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Amount Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }

            else if (txtVoucherNo.Text.Trim() == String.Empty && ddlPaymentMedia.SelectedIndex !=2)
            {
                MessageBox.Show("Voucher Number Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVoucherNo.Focus();
                return false;
            }

            if (txtFinalCustomerCode.Text.Trim() == String.Empty)
            {
                MessageBox.Show("No Customer found", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                return false;
            }

            return true;
        }
        private PaymentOOCBO InitializePaymentOOCBO()
        {
            PaymentOOCBO objPaymentOOC = new PaymentOOCBO();
            objPaymentOOC.Cust_Code = txtCustomerCode.Text;
            objPaymentOOC.PaymentMedia = ddlPaymentMedia.Text;
            objPaymentOOC.OCCPurpose = Int32.Parse(ddlPaymentPurpose.SelectedValue.ToString());
            objPaymentOOC.OCC_PaymentDate = dtpPaymentDate.Value;
            objPaymentOOC.OCC_Amount = float.Parse(txtAmount.Text);
            objPaymentOOC.OCC_VoucherNo = txtVoucherNo.Text;
            objPaymentOOC.PaymentPeriod = dtpPeriod.Value;
            objPaymentOOC.Remarks = txtRemarks.Text.Trim();
            objPaymentOOC.PaymentOCCPurpose = ddlPaymentPurpose.Text;
            return objPaymentOOC;
        }
        private void SaveToDatabase()
        {
            if (IsValidInput())
            {
                PaymentOOCBO objPaymentOOC = new PaymentOOCBO();
                objPaymentOOC = InitializePaymentOOCBO();
                PaymentOOC objpaymentOcc = new PaymentOOC();

                objPaymentOOC.TAX_ID = ID;
                objPaymentOOC.MediaType = MediaType;

                if (ddlPaymentMedia.SelectedIndex == 2)
                {                    
                    objpaymentOcc.InsertToTRInfo(objPaymentOOC);
                    EmailSyncBAL objEmailSyncBAL = new EmailSyncBAL();
                    objEmailSyncBAL.UPDATE_TAXCertification(objPaymentOOC.TAX_ID, "1");
                }

                else
                {
                    objpaymentOcc.InsertToDatabse(objPaymentOOC);
                }
                MessageBox.Show("Data Secessfully Saved.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetPaymentOccInfo(dtpSearchDate.Value);
            }

            txtAmount.Text = "";
            txtVoucherNo.Text = "";
            txtRemarks.Text = "";
            ClerCustInfo();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
            txtVoucherNo.Text = "";
        }

        private void ddlPaymentPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //if (Convert.ToInt32(ddlPaymentPurpose.SelectedValue) == Indication_PaymentOccPurpose.AnnualCharge)
                //{
                //    txtVoucherNo.Text = Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(dtpPeriod.Value);
                //    txtVoucherNo.Enabled = false;
                //    if (ddlPaymentPurpose.SelectedIndex > 0)
                //        GetOCCPurpose();
                //    GetPaymentOccInfo(dtpSearchDate.Value);
                //}
                if (ddlPaymentMedia.SelectedIndex==2)
                {
                    if (ddlPaymentPurpose.SelectedIndex > 0)
                        GetOCCPurpose();
                    GetPaymentOccInfo(dtpSearchDate.Value);
                }
                else
                {
                    txtVoucherNo.Text = string.Empty;
                    if (ddlPaymentPurpose.SelectedIndex > 0)
                        GetOCCPurpose();
                    txtVoucherNo.Enabled = true;
                    GetPaymentOccInfo(dtpSearchDate.Value);
                }
            }
            catch
            {

            }
        }

        private void dtpSearchDate_ValueChanged(object sender, EventArgs e)
        {
            GetPaymentOccInfo(dtpSearchDate.Value);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPaymentOOcInfo.Rows.Count > 0)
                {
                    int index = dgvPaymentOOcInfo.SelectedRows[0].Index;
                    string paymentOCCId = "";
                    string voucherNo = string.Empty;
                    string paymentMedia = string.Empty;
                    string MediaType = string.Empty;
                    string OnlineID = string.Empty;

                    paymentOCCId = dgvPaymentOOcInfo.Rows[index].Cells["Payment_OOC_ID"].Value.ToString();
                    voucherNo = dgvPaymentOOcInfo.Rows[index].Cells["Voucher"].Value.ToString();
                    paymentMedia = dgvPaymentOOcInfo.Rows[index].Cells["Media"].Value.ToString();
                    MediaType = dgvPaymentOOcInfo.Rows[index].Cells["Media_Type"].Value.ToString();
                    OnlineID = dgvPaymentOOcInfo.Rows[index].Cells["OnlineOrderNo"].Value.ToString();


                    if (dgvPaymentOOcInfo.Rows[index].Cells["Status"].Value.ToString().Equals("Pending"))
                    {
                        if (MessageBox.Show(@"Do you want to Delete this Other Charges & Credit Information ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (MediaType.ToUpper() == ("Email").ToUpper())
                            {
                                EmailSyncBAL objEmailSyncBAL = new EmailSyncBAL();
                                objEmailSyncBAL.UPDATE_TAXCertification(Convert.ToInt32(OnlineID), "0");
                            }
                            if (voucherNo == Indication_Fixed_VoucherNo_TransReason.OCC_VoucherNo && paymentMedia== Indication_PaymentTransaction.Cash)
                            {
                                CeancelPaymentOOC(paymentOCCId,voucherNo);
                            }
                            else
                            {
                                voucherNo = string.Empty;
                                CeancelPaymentOOC(paymentOCCId,voucherNo);
                            }
                        }

                    }

                    else
                    {
                        MessageBox.Show(dgvPaymentOOcInfo.Rows[index].Cells["Status"].Value.ToString() + " status is not enable to Cancel.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                else
                {
                    MessageBox.Show("No Information is Exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CeancelPaymentOOC(string OCCID,string voucherNo)
        {
            try
            {
                PaymentOOC objPaymentOCCBal = new PaymentOOC();
                if (OCCID != "0")
                {
                    if (voucherNo == Indication_Fixed_VoucherNo_TransReason.OCC_VoucherNo)
                    {
                        objPaymentOCCBal.DeletePaymentOCCInfoFromPaymentPostingRequest(OCCID);
                    }
                    else
                    {
                        objPaymentOCCBal.DeletePaymentOCCInfo(OCCID);
                    }
                }
                MessageBox.Show("Secessfully Cancel this Other Charges & Credits Information.", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                GetPaymentOccInfo(dtpSearchDate.Value);

            }
            catch (Exception)
            {

                throw;
            }
        } 

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBAL = new CommonBAL();
            commonBAL.NumberValidate(txtAmount.Text.Trim(), e);
        }

        private void ddlPaymentMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentMedia.SelectedIndex == 2)
            {
                txtVoucherNo.Enabled = false;
                txtVoucherNo.Text = Indication_Fixed_VoucherNo_TransReason.OCC_VoucherNo;
            }
            else
            {
                txtVoucherNo.Enabled = true;
                txtVoucherNo.Text = string.Empty;
            }
        }

        public void WebDataCasting(EmailSyncBAL bo)
        {
            PaymentOOCBO objPaymentOOCBO = new PaymentOOCBO();
            txtCustomerCode.Text = bo.CustCode;
            dtpPeriod.Value = (bo.Year);
            ddlPaymentMedia.SelectedIndex = 2;
            ddlPaymentPurpose.SelectedIndex = 3;
            SearchCustomerInfo();
            ID = bo.ID;
            MediaType = "Email";

        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            FrmWebTaxCertificate from = new FrmWebTaxCertificate();
            from.pp_deligate = new FrmWebTaxCertificate.DataToWebTaxCertificate(WebDataCasting);
            from.Show();
        }
    }
}
