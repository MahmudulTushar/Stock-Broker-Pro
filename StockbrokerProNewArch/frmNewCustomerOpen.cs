
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
    public partial class frmNewCustomerOpen : Form
    {
        private string TitleName;
        private PaymentOOC PaymentOOC = new PaymentOOC();

        public frmNewCustomerOpen(string frmName)
        {
            InitializeComponent();
            TitleName = frmName;
        }
        private void Initialize_Resizing(string FormStr)
        {
            var profile =
                Indication_FormControlResize.NewCustomerOpen.AsEnumerable().Where(
                    t => t.StateName == FormStr).ToList();
            this.Text = FormStr;
            ///////////btnSearch Info
            var profile_btnSearch = profile.Where(t => t.ControlName == btnSearch.Name).ToList();
            btnSearch.Visible = profile_btnSearch.Select(t => t.Visible).SingleOrDefault();

            ///////////pnlPaymentOCCInfo
            var profile_paymentInfo = profile.Where(t => t.ControlName == pnlPaymentInfo.Name).ToList();
            pnlPaymentInfo.Location = new Point(profile_paymentInfo.Select(t => t.LocationX).SingleOrDefault(), profile_paymentInfo.Select(t => t.LocationY).SingleOrDefault());
            pnlPaymentInfo.Size = new Size(profile_paymentInfo.Select(t => t.ControlWidth).SingleOrDefault(),
                                           profile_paymentInfo.Select(t => t.ControlHeight).SingleOrDefault());
            ///////////Voucher Info
            var profile_voucherInfo = profile.Where(t => t.ControlName == pnlVoucherInfo.Name).ToList();
            pnlVoucherInfo.Location = new Point(profile_voucherInfo.Select(t => t.LocationX).SingleOrDefault(), profile_voucherInfo.Select(t => t.LocationY).SingleOrDefault());
            pnlVoucherInfo.Size = new Size(profile_voucherInfo.Select(t => t.ControlWidth).SingleOrDefault(),
                                           profile_voucherInfo.Select(t => t.ControlHeight).SingleOrDefault());

            ///////////ckbBOOpenwithRenewal
            var profile_ckbBOOpenwithRenewal = profile.Where(t => t.ControlName == ckbAnnualCharge.Name).ToList();
            ckbAnnualCharge.Visible = profile_ckbBOOpenwithRenewal.Select(t => t.Visible).SingleOrDefault();

            ///////////pnlPaymentOCCInfo
            var profile_pnlPaymentOCCInfo = profile.Where(t => t.ControlName == pnlPaymentOCCInfo.Name).ToList();
            pnlPaymentOCCInfo.Visible = profile_pnlPaymentOCCInfo.Select(t => t.Visible).SingleOrDefault();

            //////////pnlAnnualChargeInfo
            var profile_pnlAnnualChargeInfo = profile.Where(t => t.ControlName == pnlAnnualChargeInfo.Name).ToList();
            pnlAnnualChargeInfo.Location = new Point(profile_pnlAnnualChargeInfo.Select(t => t.LocationX).SingleOrDefault(), profile_pnlAnnualChargeInfo.Select(t => t.LocationY).SingleOrDefault());
            pnlAnnualChargeInfo.Size = new Size(profile_pnlAnnualChargeInfo.Select(t => t.ControlWidth).SingleOrDefault(),
                                           profile_pnlAnnualChargeInfo.Select(t => t.ControlHeight).SingleOrDefault());
            pnlAnnualChargeInfo.Visible = profile_pnlAnnualChargeInfo.Select(t => t.Visible).SingleOrDefault();

            ///////////CustInfo
            var profile_CustInfo = profile.Where(t => t.ControlName == pnlCustInfo.Name).ToList();
            pnlCustInfo.Location = new Point(profile_CustInfo.Select(t => t.LocationX).SingleOrDefault(), profile_CustInfo.Select(t => t.LocationY).SingleOrDefault());
            pnlCustInfo.Size = new Size(profile_CustInfo.Select(t => t.ControlWidth).SingleOrDefault(),
                                           profile_CustInfo.Select(t => t.ControlHeight).SingleOrDefault());
            pnlCustInfo.Visible = profile_CustInfo.Select(t => t.Visible).SingleOrDefault();

            ///////////Panel1
            var profile_Panel1 = profile.Where(t => t.ControlName == panel1.Name).ToList();
            panel1.Location = new Point(profile_Panel1.Select(t => t.LocationX).SingleOrDefault(), profile_Panel1.Select(t => t.LocationY).SingleOrDefault());
            panel1.Size = new Size(profile_Panel1.Select(t => t.ControlWidth).SingleOrDefault(),
                                           profile_Panel1.Select(t => t.ControlHeight).SingleOrDefault());
            panel1.Visible = profile_Panel1.Select(t => t.Visible).SingleOrDefault();


            ///////////labelTotalAmount Info
            var profile_labelTotalAmount = profile.Where(t => t.ControlName == lblTotalAmount.Name).ToList();
            lblTotalAmount.Location = new Point(profile_labelTotalAmount.Select(t => t.LocationX).SingleOrDefault(), profile_labelTotalAmount.Select(t => t.LocationY).SingleOrDefault());
            lblTotalAmount.Size = new Size(profile_labelTotalAmount.Select(t => t.ControlWidth).SingleOrDefault(),
                                           profile_labelTotalAmount.Select(t => t.ControlHeight).SingleOrDefault());

            //////////btnCancel
            var profile_btnCancel = profile.Where(t => t.ControlName == btnCancel.Name).ToList();
            btnCancel.Location = new Point(profile_btnCancel.Select(t => t.LocationX).SingleOrDefault(), profile_btnCancel.Select(t => t.LocationY).SingleOrDefault());

            //////////GroupBox3
            var profile_GroupBox3 = profile.Where(t => t.ControlName == groupBox3.Name).ToList();
            var siz_grp = new Size(profile_GroupBox3.Select(t => t.ControlWidth).SingleOrDefault(),
                                           profile_GroupBox3.Select(t => t.ControlHeight).SingleOrDefault());
            //groupBox3.Size = new Size(profile_GroupBox3.Select(t => t.ControlWidth).SingleOrDefault(),
            //                               profile_GroupBox3.Select(t => t.ControlHeight).SingleOrDefault());
            groupBox3.Size = siz_grp;

            //////////dgvPaymentOOcInfo
            var profile_dgv = profile.Where(t => t.ControlName == dgvPaymentOOcInfo.Name).ToList();
            dgvPaymentOOcInfo.Size = new Size(profile_dgv.Select(t => t.ControlWidth).SingleOrDefault(),
                                           profile_dgv.Select(t => t.ControlHeight).SingleOrDefault());

            //////////Form
            var profile_Form = profile.Where(t => t.ControlName == this.Name).ToList();
            this.Size = new Size(profile_Form.Select(t => t.ControlWidth).SingleOrDefault(),
                                           profile_Form.Select(t => t.ControlHeight).SingleOrDefault());

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
            int FilterId = -1;

            try
            {
                PaymentOOC ObjPaymentOOCBAL = new PaymentOOC();
                DataTable data = new DataTable();
                if (TitleName == Indication_Forms_Title.NewCustomerOpen)
                {
                    FilterId = 1;
                }
                if (TitleName == Indication_Forms_Title.BORenewal)
                {
                    FilterId = 2;
                }
                data = ObjPaymentOOCBAL.GetPaymentOccInfo(date, TitleName, FilterId);
                try
                {
                dgvPaymentOOcInfo.DataSource = data;
                dgvPaymentOOcInfo.Columns["Payment_ID"].Visible = false;
                dgvPaymentOOcInfo.Columns["Payment_OOC_ID"].Visible = false;
                // dgvPaymentOOcInfo.Columns["Media Date"].DefaultCellStyle.Format = "MM-dd-yyyy";
                dgvPaymentOOcInfo.Columns["Rec. Date"].DefaultCellStyle.Format = "MM-dd-yyyy";
                }
                catch
                { }
                // dgvPaymentOOcInfo.Columns["Entry Date"].DefaultCellStyle.Format = "MM-dd-yyyy";
                lblTotalRecord.Text = "Total Record : " + dgvPaymentOOcInfo.Rows.Count.ToString();
                lblTotalAmount.Text = "Total Amount Tk.: " + String.Format("{0:n}", GetTotalAmount());
                //ObjPaymentOOCBAL.GetAmount(date));

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
                    txtOCCAmount.Text = objPaymentOCC.GetOOCPurpose(Int32.Parse(ddlPaymentPurpose.SelectedValue.ToString())).ToString();
                }

                else
                {
                    txtOCCAmount.Text = "0.00";
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

        //private void GetCustomerInfo()
        //{
        //    try
        //    {
        //        PaymentOOC objPaymentOOC = new PaymentOOC();
        //        DataTable data = new DataTable();
        //        string custStatus = string.Empty;

        //            custStatus = objPaymentOOC.GetCustomerStatus(txtCustomerCode.Text.Trim());

        //            if (custStatus == "Pending")
        //            {
        //                if (MessageBox.Show(@"The Customer is Pending  Do you Want to Proceed?.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
        //                {
        //                    txtCustomerCode.Text = string.Empty;
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show(@"No Customer Found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
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
        private void ClerCustInfo()
        {
            txtFinalCustomerCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtBOID.Text = string.Empty;
            txtCurrentBalence.Text = string.Empty;
            txtMaturedBalence.Text = string.Empty;
            txtAccountStatus.Text = string.Empty;
        }

        private void GetPurposeList()
        {
            try
            {
                paymentOCCPaurpose objOccpurpose = new paymentOCCPaurpose();
                DataTable data = new DataTable();
                data = objOccpurpose.GetOCCPurposeList(TitleName);
                ddlPaymentPurpose.DisplayMember = "OCC_Purpose";
                ddlPaymentPurpose.ValueMember = "OCC_ID";
                ddlPaymentPurpose.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                if (TitleName == Indication_Forms_Title.BORenewal)
                {
                    SearchCustomerInfo();
                }
                SetNextFocus(TitleName, txtCustomerCode.Name);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                SaveToDatabase();
                txtCustomerCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Save fail because of : " + ex.Message);
            }
        }

        private bool IsValidCharge()
        {
            bool isValid = true;
            PaymentOOC objpaymentOcc = new PaymentOOC();
            double BO_OpenCharge = 0;

            if (Convert.ToDouble(txtOCCAmount.Text.ToString()) < Indication_TransWithFixedAmount.BO_Renewal_Charge)
            {
                MessageBox.Show(@"Insufficient Balance");
                isValid = false;
            }
            return isValid;
        }

        private bool IsValidInput()
        {
            //bool isValid = true;
            DataTable dt = PaymentOOC.duplicateCustCodeCheck(txtCustomerCode.Text.Trim());

            if (txtCustomerCode.Text.Trim() == String.Empty)
            {
                MessageBox.Show(@"Customer Code Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerCode.Focus();
                return false;
            }
            if (txtOCCAmount.Text.Trim() == String.Empty)
            {
                MessageBox.Show(@"OCC Amount Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOCCAmount.Focus();
                return false;
            }
            //if (TitleName == Indication_Forms_Title.NewCustomerOpen)
            //{
            //    if (ckbAnnualCharge.Checked)
            //    {
            //        if (Convert.ToDouble(txtOCCAmount.Text) > 1000.0 || Convert.ToDouble(txtOCCAmount.Text) < 500.0)
            //        {
            //            MessageBox.Show(@"Amount must be between  (500 and 1000)  TK.", "", MessageBoxButtons.OK,
            //                            MessageBoxIcon.Warning);
            //            txtOCCAmount.Focus();
            //            return false;
            //        }

            //        if (!IsValidCharge())
            //        {
            //            return false;
            //        }
            //    }
            //}
            if (TitleName == Indication_Forms_Title.BORenewal)
            {
                if (Convert.ToDouble(txtOCCAmount.Text) + Convert.ToDouble(txtCurrentBalence.Text) < 500)
                {
                    MessageBox.Show(@"Insufficient Balance.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOCCAmount.Focus();
                    return false;
                }
            }
            if (TitleName == Indication_Forms_Title.NewCustomerOpen)
            {
                if (txtOCCVoucherNo.Text.Trim() == String.Empty)
                {
                    MessageBox.Show(@"OCC Voucher Number Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOCCVoucherNo.Focus();
                    return false;
                }
            }
            if (TitleName == Indication_Forms_Title.NewCustomerOpen && ckbAnnualCharge.Checked)
            {
                if (txtAnnualChargeVoucherNo.Text.Trim() == String.Empty)
                {
                    MessageBox.Show(@"Annual Voucher Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnnualChargeVoucherNo.Focus();
                    return false;
                }
            }

            if (TitleName == Indication_Forms_Title.BORenewal)
            {
                if (txtAnnualChargeVoucherNo.Text.Trim() == String.Empty)
                {
                    MessageBox.Show(@"Annual Voucher Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnnualChargeVoucherNo.Focus();
                    return false;
                }
            }

            //if (dt.Rows[0][0].ToString() != "")
            //{
            //    MessageBox.Show(@"CustCode Already Exit.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}  

            //return true;


            //////////////////////////Change by nobin.. for probelm new client cannt seveing/////////////////////////////////////////
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(@"CustCode Already Exit.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private PaymentOOCBO InitializePaymentOOCBO()
        {
            PaymentOOCBO objBOOpenRenewal = new PaymentOOCBO();
            objBOOpenRenewal.Cust_Code = txtCustomerCode.Text;
            objBOOpenRenewal.PaymentMedia = ddlPaymentMedia.Text;
            objBOOpenRenewal.OCCPurpose = Int32.Parse(ddlPaymentPurpose.SelectedValue.ToString());
            if (TitleName == Indication_Forms_Title.NewCustomerOpen)
            {
                objBOOpenRenewal.OCC_PaymentDate = dtpPaymentOCCDate.Value;
                objBOOpenRenewal.OCC_Amount = float.Parse(txtOCCAmount.Text);
                objBOOpenRenewal.OCC_VoucherNo = txtOCCVoucherNo.Text;
            }
            if ((ddlPaymentPurpose.Text.Contains(Indication_Fixed_VoucherNo_TransReason.BO_Open)) && TitleName == Indication_Forms_Title.NewCustomerOpen && ckbAnnualCharge.Checked)
            {
                objBOOpenRenewal.Annual_PaymentDate = dtpAnnualChargePaymentDate.Value;
                objBOOpenRenewal.Annual_Amount = float.Parse(txtAnnualChargeAmount.Text);
                objBOOpenRenewal.Annual_VoucherNo = txtAnnualChargeVoucherNo.Text;
            }
            if ((ddlPaymentPurpose.Text.Contains(Indication_Fixed_VoucherNo_TransReason.BO_Open)) && TitleName == Indication_Forms_Title.BORenewal)
            {
                objBOOpenRenewal.Annual_PaymentDate = dtpAnnualChargePaymentDate.Value;
                objBOOpenRenewal.Annual_Amount = float.Parse(txtAnnualChargeAmount.Text);
                objBOOpenRenewal.Annual_VoucherNo = txtAnnualChargeVoucherNo.Text;
            }
            objBOOpenRenewal.PaymentPeriod = dtpPeriod.Value;
            objBOOpenRenewal.Remarks = txtRemarks.Text.Trim();

            objBOOpenRenewal.PaymentOCCPurpose = ddlPaymentPurpose.Text;
            if (ddlPaymentPurpose.Text.Contains(Indication_Fixed_VoucherNo_TransReason.BO_Open))
            {
                objBOOpenRenewal.Trans_Reason = Indication_Fixed_VoucherNo_TransReason.GetBORenewal_TransReason(dtpPeriod.Value);
            }
            return objBOOpenRenewal;
        }
        private void SaveToDatabase()
        {
            
            if (IsValidInput())
            {
                PaymentOOCBO objPaymentOOC = new PaymentOOCBO();
                string custStatus = string.Empty;
                objPaymentOOC = InitializePaymentOOCBO();
                PaymentOOC objpaymentOcc = new PaymentOOC();
                if (TitleName == Indication_Forms_Title.NewCustomerOpen)
                {
                    if (ddlPaymentPurpose.Text.Trim() == Indication_Fixed_VoucherNo_TransReason.BO_Open &&
                        ckbAnnualCharge.Checked)
                    {
                        custStatus = objpaymentOcc.GetCustomerStatus(txtCustomerCode.Text.Trim());

                        if (custStatus != "Pending")// && custStatus!="Active"
                        {
                            if (
                                MessageBox.Show(@"New Customer Create with default group, Do you want to proceed ?",
                                                @"New Customer Create Check", MessageBoxButtons.YesNo) ==
                                DialogResult.Yes)
                            {

                                try
                                {
                                    objpaymentOcc.ConnectDatabase();
                                    objpaymentOcc.InsertNewCustomer_UITransApplied(txtCustomerCode.Text.Trim());
                                    objpaymentOcc.InsertPaymentPostingRequestByTitle_UITransApplied(objPaymentOOC, TitleName);
                                    objpaymentOcc.Commit();
                                    MessageBox.Show(@"Data Secessfully Saved.", "", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    objpaymentOcc.RollBack();
                                    throw ex;
                                }
                                finally
                                {
                                    objpaymentOcc.CloseDatabase();
                                }

                            }
                            else
                            {
                                MessageBox.Show(@"No Customer Found.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (custStatus == "Pending")
                        {
                            if (
                                MessageBox.Show(@"The Customer is Pending, Do you want to proceed ?",
                                                @"Pending Customer Create Check", MessageBoxButtons.YesNo) ==
                                DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                try
                                {
                                    //objpaymentOcc.ConnectDatabase();
                                    objpaymentOcc.InsertPaymentPostingRequestByTitle(objPaymentOOC, TitleName);
                                    //objpaymentOcc.Commit();
                                    MessageBox.Show(@"Data Secessfully Saved.", "", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    //objpaymentOcc.RollBack();
                                    throw ex;
                                }
                                finally
                                {
                                    //objpaymentOcc.CloseDatabase();
                                }

                            }
                        }
                        //if (custStatus == "Active")
                        //{
                        //    if (
                        //        MessageBox.Show(@"The Customer is Active, Do you want to proceed ?",
                        //                        @"Active Customer Check", MessageBoxButtons.YesNo) ==
                        //        DialogResult.No)
                        //    {
                        //        return;
                        //    }
                        //    else
                        //    {
                        //        objpaymentOcc.InsertPaymentPostingRequestByTitle(objPaymentOOC, TitleName);
                        //        MessageBox.Show(@"Data Secessfully Saved.", "", MessageBoxButtons.OK,
                        //                        MessageBoxIcon.Information);

                        //    }
                        //}


                    }
                    else
                    {
                        custStatus = objpaymentOcc.GetCustomerStatus(txtCustomerCode.Text.Trim());
                        if (custStatus == "Pending")
                        {
                            if (
                                MessageBox.Show(@"The Customer is Pending and want to only OCC, Do you want to proceed ?",
                                                @"Pending Customer Check", MessageBoxButtons.YesNo) ==
                                DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                try
                                {
                                    //objpaymentOcc.ConnectDatabase();
                                    objpaymentOcc.InsertToDatabse(objPaymentOOC);
                                    MessageBox.Show(@"Data Secessfully Saved.", "", MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                    //objpaymentOcc.Commit();
                                }
                                catch (Exception ex)
                                {
                                    //objpaymentOcc.RollBack();
                                    throw ex;
                                }
                                finally
                                {
                                    //objpaymentOcc.CloseDatabase();
                                }
                            }
                        }
                    }
                }
                else
                {
                    objpaymentOcc.InsertPaymentPostingRequestByTitle(objPaymentOOC, TitleName);
                    MessageBox.Show(@"Data Secessfully Saved.", "", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                GetPaymentOccInfo(dtpSearchDate.Value);
                ClearText();
            }
        }
        private void ClearText()
        {
            if (TitleName == Indication_Forms_Title.NewCustomerOpen)
            {
                txtCustomerCode.Text = string.Empty;
                txtOCCVoucherNo.Text = string.Empty;
                txtAnnualChargeAmount.Text = "500";
                txtAnnualChargeVoucherNo.Text = string.Empty;
                txtRemarks.Text = string.Empty;
            }
            else if (TitleName == Indication_Forms_Title.BORenewal)
            {
                txtCustomerCode.Text = string.Empty;
                txtAnnualChargeVoucherNo.Text = string.Empty;
                txtAnnualChargeAmount.Text = "500";
                txtRemarks.Text = string.Empty;
                txtFinalCustomerCode.Text = string.Empty;
                txtBOID.Text = string.Empty;
                txtName.Text = string.Empty;
                txtCurrentBalence.Text = string.Empty;
                txtMaturedBalence.Text = string.Empty;
                txtAccountStatus.Text = string.Empty;

                txtCurrentBalence.BackColor = Color.Gainsboro;
                txtMaturedBalence.BackColor = Color.Gainsboro;
                txtAccountStatus.BackColor = Color.Gainsboro;
            }
        }

        private void SaveNewCustomer()
        {
            try
            {
                PaymentOOC objpaymentOcc = new PaymentOOC();
                objpaymentOcc.InsertNewCustomer(txtCustomerCode.Text.Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtOCCAmount.Text = "";
            txtOCCVoucherNo.Text = "";
        }

        private void ddlPaymentPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    if (Convert.ToInt32(ddlPaymentPurpose.SelectedValue)==Indication_PaymentOccPurpose.AnnualCharge)
            //    {
            //        txtVoucherNo.Text = Indication_Fixed_VoucherNo_TransReason.GetBORenewal_VoucherNo(dtpPeriod.Value);
            //        txtVoucherNo.Enabled = false;
            //        if (ddlPaymentPurpose.SelectedIndex > 0)
            //            GetOCCPurpose();
            //        GetPaymentOccInfo(dtpSearchDate.Value);
            //    }
            //    else
            //    {
            //        txtVoucherNo.Text = string.Empty;
            //        if (ddlPaymentPurpose.SelectedIndex > 0)
            //            GetOCCPurpose();
            //        txtVoucherNo.Enabled = true;
            //        GetPaymentOccInfo(dtpSearchDate.Value);
            //    }
            //    if (ddlPaymentPurpose.Text.Contains(Indication_Fixed_VoucherNo_TransReason.BO_Open))
            //    {
            //        pnlBoAnnualChargeInfo.Visible = true;
            //    }
            //    else
            //    {
            //        pnlBoAnnualChargeInfo.Visible = false;
            //    }
            //}
            //catch
            //{

            //}
        }

        private void dtpSearchDate_ValueChanged(object sender, EventArgs e)
        {
            GetPaymentOccInfo(dtpSearchDate.Value);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvPaymentOOcInfo.Rows.Count > 0)
            //    {
            //        int index = dgvPaymentOOcInfo.SelectedRows[0].Index;
            //        int paymentOCCId = 0;
            //        int paymentId = 0;
            //        string Withdraw_VoucherNo = string.Empty;
            //        string Deposit_Withdraw = dgvPaymentOOcInfo.Rows[index].Cells["D/W"].Value.ToString();
            //        //paymentOCCId = Int32.Parse(dgvPaymentOOcInfo.Rows[index].Cells["Payment_OOC_ID"].Value.ToString());
            //        paymentOCCId = Int32.Parse(dgvPaymentOOcInfo.Rows[index].Cells["Payment_OOC_ID"].Value.ToString());
            //        paymentId = Int32.Parse(dgvPaymentOOcInfo.Rows[index].Cells["Payment_ID"].Value.ToString());
            //        Withdraw_VoucherNo = dgvPaymentOOcInfo.Rows[index].Cells["Vouchar"].Value.ToString();


            //        if (dgvPaymentOOcInfo.Rows[index].Cells["Status"].Value.ToString().Equals("Pending"))
            //        {
            //            if (MessageBox.Show("Do you want to Delete this Other Charges & Credit Information ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //                CeancelPaymentOOC(paymentId, Withdraw_VoucherNo, Deposit_Withdraw, paymentOCCId);
            //            }

            //        }

            //        else
            //        {
            //            MessageBox.Show(dgvPaymentOOcInfo.Rows[index].Cells["Status"].Value.ToString() + " status is not enable to Cancel.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }

            //    }

            //    else
            //    {
            //        MessageBox.Show("No Information is Exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                if (dgvPaymentOOcInfo.Rows.Count > 0)
                {
                    int index = dgvPaymentOOcInfo.SelectedRows[0].Index;
                    //int paymentOCCId = 0;
                    //int paymentId = 0;
                    //string Withdraw_VoucherNo = string.Empty;
                    //string Deposit_Withdraw = dgvPaymentOOcInfo.Rows[index].Cells["D/W"].Value.ToString();
                    ////paymentOCCId = Int32.Parse(dgvPaymentOOcInfo.Rows[index].Cells["Payment_OOC_ID"].Value.ToString());
                    //paymentOCCId = Int32.Parse(dgvPaymentOOcInfo.Rows[index].Cells["Payment_OOC_ID"].Value.ToString());
                    //paymentId = Int32.Parse(dgvPaymentOOcInfo.Rows[index].Cells["Payment_ID"].Value.ToString());
                    //Withdraw_VoucherNo = dgvPaymentOOcInfo.Rows[index].Cells["Vouchar"].Value.ToString();
                    PaymentOOC objPaymentOCCBal = new PaymentOOC();
                    string[] PaymentID = null;
                    string PaymentOccID = "";
                    string Status = "";
                    string CustCode = "";
                    PaymentID = dgvPaymentOOcInfo.SelectedRows.Cast<DataGridViewRow>().Where(p => Convert.ToInt32(p.Cells["Payment_ID"].Value) != 0)
                        .Select(c => c.Cells["Payment_ID"].Value.ToString()).ToArray();
                    PaymentOccID = dgvPaymentOOcInfo.SelectedRows.Cast<DataGridViewRow>().Where(p => Convert.ToInt32(p.Cells["Payment_OOC_ID"].Value) != 0)
                        .Select(c => c.Cells["Payment_OOC_ID"].Value.ToString()).FirstOrDefault();
                    Status = dgvPaymentOOcInfo.SelectedRows.Cast<DataGridViewRow>()
                        .Select(c => Convert.ToString(c.Cells["Status"].Value)).Distinct().FirstOrDefault();
                    CustCode = dgvPaymentOOcInfo.SelectedRows.Cast<DataGridViewRow>()
                        .Select(c => Convert.ToString(c.Cells["Cust Code"].Value)).Distinct().FirstOrDefault();

                    if (Status == "Pending")
                    {

                        if (MessageBox.Show("Do you want to Delete this Other Charges & Credit Information ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            objPaymentOCCBal.DeltePostingAndOccid(PaymentID, PaymentOccID);
                            GetPaymentOccInfo(dtpSearchDate.Value);
                            objPaymentOCCBal.DeleteCustCode(CustCode);
                        }
                    }


                    //if (dgvPaymentOOcInfo.Rows[index].Cells["Status"].Value.ToString().Equals("Pending"))
                    //{
                    //    if (MessageBox.Show("Do you want to Delete this Other Charges & Credit Information ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //    {
                    //        CeancelPaymentOOC(paymentId, Withdraw_VoucherNo, Deposit_Withdraw, paymentOCCId);
                    //    }

                    //}

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

        private void CeancelPaymentOOC(int paymentId, string withdraw_voucherNo, string deposit_withdraw, string paymentOCCId)
        {
            try
            {
                PaymentOOC objPaymentOCCBal = new PaymentOOC();
                if (paymentId != 0)
                {
                    objPaymentOCCBal.DeleteFromPaymentPostingRequest(paymentId, withdraw_voucherNo, deposit_withdraw);
                }
                if (paymentOCCId != "")
                {
                    objPaymentOCCBal.DeletePaymentOCCInfo(paymentOCCId);
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

        private void ckbBOOpenwithRenewal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckbAnnualCharge.Checked)
                {
                    SetBO_OpenCharge();
                    GetPaymentOccInfo(dtpSearchDate.Value);
                    txtAnnualChargeVoucherNo.Enabled = true;
                }
                else
                {
                    txtAnnualChargeVoucherNo.Enabled = false;
                    txtAnnualChargeVoucherNo.Text = string.Empty;
                    lblAnnualCharge.Text = string.Empty;
                }
            }
            catch
            {
                throw;
            }
        }

        private void SetBO_OpenCharge()
        {
            if (ckbAnnualCharge.Checked)
            {
                double Total_Amount = 0, BO_Renewal_Charge = 0;
                double doubleTryParse;
                BO_Renewal_Charge = Convert.ToDouble(Indication_TransWithFixedAmount.BO_Renewal_Charge);

                if (txtAnnualChargeAmount.Text.Trim() != string.Empty &&
                    double.TryParse(txtAnnualChargeAmount.Text.Trim(), out doubleTryParse))
                {
                    Total_Amount = doubleTryParse;
                }
                if (ckbAnnualCharge.Checked)
                {
                    if (Total_Amount >= BO_Renewal_Charge)
                    {
                        lblAnnualCharge.Text = @"(Annual-" + BO_Renewal_Charge.ToString() + @", Deposit-" +
                                               ((Total_Amount) == 0
                                                    ? "0"
                                                    : (Total_Amount.ToString())) + @")";
                        //lblBOOpen.Text = @", Bo Open-" + ((Total_Amount - BO_Renewal_Charge) == 0 ? "0" : (Total_Amount - BO_Renewal_Charge).ToString()) +")";
                    }
                    else
                    {
                        lblAnnualCharge.Text = @"(Annual-0" + @", Deposit-" + txtAnnualChargeAmount.Text + @")";
                        // lblBOOpen.Text = @", Bo Open-" + txtAmount.Text + ")";
                    }
                }
                else
                {
                    lblAnnualCharge.Text = @"(Annual-0" + @", Deposit-" + txtAnnualChargeAmount.Text + @")";
                    // lblBOOpen.Text = string.Empty;
                }
                //if (Convert.ToDouble(txtOCCAmount.Text) > 1000)
                //{
                //    MessageBox.Show("Amount must be between 500 and 1000 Tk.");
                //    txtOCCAmount.Text = string.Empty;
                //    return;
                //}

            }
            else
            {
                lblAnnualCharge.Text = "";
            }
        }

        private void Set_AnnualCharge()
        {
            //lblBOOpen.Text = txtAmount.Text;
        }

        private void txtAnnualChargeAmount_TextChanged(object sender, EventArgs e)
        {
            double inputAmount = 0;
            double doubleTryParse;
            try
            {
                if (ckbAnnualCharge.Checked && TitleName == Indication_Forms_Title.NewCustomerOpen)
                {
                    lblAnnualCharge.Visible = true;
                    if (double.TryParse(txtAnnualChargeAmount.Text.Trim(), out doubleTryParse))
                    {
                        inputAmount = doubleTryParse;
                        if (inputAmount > 0 && inputAmount != 0)
                        {
                            SetBO_OpenCharge();
                            // Set_AnnualCharge();
                        }
                        else if (inputAmount == 0)
                        {
                            lblAnnualCharge.Text = "(Annual-0" + @", BO Open-0)";
                        }
                        //else
                        //{
                        //    MessageBox.Show("Amount must be between (500 and 1000)TK.");
                        //    txtAnnualChargeAmount.Text = txtOCCAmount.Text.Substring(0, 3);
                        //}
                    }
                    else
                    {
                        if (txtAnnualChargeAmount.Text == "")
                        {
                            lblAnnualCharge.Text = "(Annual-0" + @", BO Open-0)";
                        }
                    }
                }
                else
                {
                    lblAnnualCharge.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void txtOCCAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBAL = new CommonBAL();
            commonBAL.NumberValidate(txtOCCAmount.Text.Trim(), e);
        }
        private void txtAnnualChargeAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonBAL commonBAL = new CommonBAL();
            commonBAL.NumberValidate(txtOCCAmount.Text.Trim(), e);
        }
        private void frmNewCustomerOpen_Load(object sender, EventArgs e)
        {
            Initialize_Resizing(TitleName);
            lblBranchName.Text = "Branch : " + GlobalVariableBO._branchName;
            ddlPaymentMedia.SelectedIndex = 0;
            GetPurposeList();
            GetOCCPurpose();
            GetPaymentOccInfo(dtpSearchDate.Value);
            SetPeriod();
            txtCustomerCode.Focus();
        }

        private void SetPeriod()
        {
            int month = 0;
            month = dtpPeriod.Value.Month;
            if (month > 6)
            {
                dtpPeriod.Value = dtpPeriod.Value.AddYears(1);
            }
        }
        private void SetNextFocus(string TitleName, string currentFocusControlName)
        {
            if (TitleName == Indication_Forms_Title.NewCustomerOpen)
            {
                if (currentFocusControlName == txtCustomerCode.Name)
                {
                    txtOCCVoucherNo.Focus();
                }
                if (currentFocusControlName == txtOCCVoucherNo.Name)
                {
                    txtAnnualChargeAmount.Focus();
                }
                else if (currentFocusControlName == txtAnnualChargeAmount.Name)
                {
                    txtAnnualChargeVoucherNo.Focus();
                }
                else if (currentFocusControlName == txtAnnualChargeVoucherNo.Name)
                {
                    btnPayment.Focus();
                }
                else if (currentFocusControlName == btnPayment.Name)
                {
                    txtCustomerCode.Focus();
                }
            }
            if (TitleName == Indication_Forms_Title.BORenewal)
            {
                if (currentFocusControlName == txtCustomerCode.Name)
                {
                    txtAnnualChargeAmount.Focus();
                }
                if (currentFocusControlName == txtAnnualChargeAmount.Name)
                {
                    txtAnnualChargeVoucherNo.Focus();
                }
                else if (currentFocusControlName == txtAnnualChargeVoucherNo.Name)
                {
                    btnPayment.Focus();
                }

                else if (currentFocusControlName == btnPayment.Name)
                {
                    txtCustomerCode.Focus();
                }
            }
        }


        private void txtOCCVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(TitleName, txtOCCVoucherNo.Name);
            }
        }

        private void txtAnnualChargeAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(TitleName, txtAnnualChargeAmount.Name);
            }
        }

        private void txtAnnualChargeVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(TitleName, txtAnnualChargeVoucherNo.Name);
            }
        }

        private void btnPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetNextFocus(TitleName, btnPayment.Name);
            }
        }

        private void ckbAnnualCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAnnualCharge.Checked)
            {
                pnlAccountDepositInfo.Enabled = true;
                txtAnnualChargeAmount.Text = "500";
            }
            else
            {
                pnlAccountDepositInfo.Enabled = false;
                txtAnnualChargeAmount.Text = string.Empty;
                txtAnnualChargeVoucherNo.Text = string.Empty;
            }
        }
        private void SetPaymentOCCDepositRowColor()
        {
            foreach (DataGridViewRow row in dgvPaymentOOcInfo.Rows)
            {
                if (row.Cells[0].Value.ToString() == "0")
                {
                    row.DefaultCellStyle.ForeColor = Color.DeepSkyBlue;
                    //row.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                }
            }
        }
        private void dgvPaymentOOcInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetPaymentOCCDepositRowColor();
        }
    }
}
