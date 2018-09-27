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
    public partial class FrmTaxCertificate : Form
    {
        private All_ReportBAL objAll_ReportBAL = new All_ReportBAL();
        private PaymentOOC PaymentOOC = new PaymentOOC();
        public FrmTaxCertificate()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTaxCertificate_Load(object sender, EventArgs e)
        {
            
        }
        public void Cust_Wise_Information()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = objAll_ReportBAL.Cust_Information(txtCustCode.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtCustCode.Text = dr[0].ToString();
                        txtCustomerName.Text = dr[1].ToString();
                        txtAmount.Text = dr[2].ToString();
                        txtAmount.ForeColor = Color.Red;
                    }
                }
                else
                {
                    MessageBox.Show("No Coustomer Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Claertext();
                    txtCustCode.Focus();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void Email_Address_Searching()
        {
            string Email_ID_Parent_Child = string.Empty;
            string Email_ID_Register = string.Empty;
            string Email_ID_Bo = string.Empty;
            string Parent_Child = string.Empty;
            string Cust_Code = string.Empty;
            try
            {
                Parent_Child = objAll_ReportBAL.Parent_Child_Cheaking(txtCustCode.Text.Trim());
                if (Parent_Child != "")
                {
                    Cust_Code = Parent_Child;
                }
                else
                {
                    Cust_Code = txtCustCode.Text.Trim();
                }


                Email_ID_Parent_Child = objAll_ReportBAL.All_Email_Address("1", Cust_Code);
                Email_ID_Register = objAll_ReportBAL.All_Email_Address("2", Cust_Code);
                Email_ID_Bo = objAll_ReportBAL.All_Email_Address("3", Cust_Code);

               
                if (Email_ID_Parent_Child.Trim() != "")
                {
                    txtEmailID.Text = Email_ID_Parent_Child.Trim();
                    rdbParentChild.Checked = true;
                    rdbRegister.Checked = false;
                    rdbboopen.Checked = false;
                    rdbOther.Checked = false;
                }
                else if (Email_ID_Register.Trim() != "")
                {
                    txtEmailID.Text = Email_ID_Register.Trim();
                    rdbParentChild.Checked = false;
                    rdbRegister.Checked = true;
                    rdbboopen.Checked = false;
                    rdbOther.Checked = false;
                }
                else if (Email_ID_Bo.Trim() != "")
                {
                    txtEmailID.Text = Email_ID_Bo.Trim();
                    rdbParentChild.Checked = false;
                    rdbRegister.Checked = false;
                    rdbboopen.Checked = true;
                    rdbOther.Checked = false;
                }
                else
                {
                    rdbParentChild.Checked = false;
                    rdbRegister.Checked = false;
                    rdbboopen.Checked = false;
                    rdbOther.Checked = true;
                }

                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Email_Address_Searching();
                Cust_Wise_Information();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Claertext();
        }
        public void Claertext()
        {
            txtCustCode.Text = "";
            txtAmount.Text = "";
            txtCustomerName.Text = "";
            txtEmailID.Text = "";
            rdbPortolio.Checked = false;
            rdbSummaryLedger.Checked = false;
            rdbTradeIPOConfirmation.Checked = false;
            rdbTaxCertificate.Checked = false;
            rdbParentChild.Checked = false;
            rdbRegister.Checked = false;
            rdbboopen.Checked = false;
            rdbOther.Checked = false;
            dtFromDate.Value = System.DateTime.Now;
            dtToDate.Value = System.DateTime.Now;
            
        }

        private void rdbParentChild_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbParentChild.Checked == true)
            {
                txtEmailID.Text = objAll_ReportBAL.All_Email_Address("1", txtCustCode.Text.Trim());
                txtEmailID.ReadOnly = true;
            }
        }

        private void rdbRegister_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRegister.Checked == true)
            {
                txtEmailID.Text = objAll_ReportBAL.All_Email_Address("2", txtCustCode.Text.Trim());
                txtEmailID.ReadOnly = true;
            }
        }

        private void rdbboopen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbboopen.Checked == true)
            {
                txtEmailID.Text = objAll_ReportBAL.All_Email_Address("3", txtCustCode.Text.Trim());
                txtEmailID.ReadOnly = true;
            }
        }

        private void rdbOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbOther.Checked == true)
            {
                txtEmailID.ReadOnly = false;
                txtEmailID.Text = "";
            }
        }

        private void rdbTaxCertificate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTaxCertificate.Checked == true)
            {
                string df = DateTime.Today.AddYears(-1).Year.ToString();
                string dt = DateTime.Today.Year.ToString();
                dtFromDate.Value = Convert.ToDateTime(df + "-07-" + "01");
                dtToDate.Value = Convert.ToDateTime(dt + "-06-" + "30");
            }
        }

        private void rdbTradeIPOConfirmation_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Value = System.DateTime.Now;
            dtToDate.Value = System.DateTime.Now;
        }

        private void rdbPortolio_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Value = System.DateTime.Now;
            dtToDate.Value = System.DateTime.Now;
        }

        private void rdbSummaryLedger_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Value = System.DateTime.Now;
            dtToDate.Value = System.DateTime.Now;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (isValidation())
                return;
            Sending_Report();
            MessageBox.Show("Sending Successfully.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            btnRefresh_Click(sender, e);
        }
        public bool isValidation()
        {
            if (txtCustCode.Text == "")
            {
                MessageBox.Show("Please Enter Cust Code.", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtCustCode.Focus();
                return true;
            }
            else if (txtEmailID.Text == "")
            {
                MessageBox.Show("Your Email ID is not Found.", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private PaymentOOCBO InitializePaymentOOCBO()
        {
            PaymentOOCBO objPaymentOOC = new PaymentOOCBO();
            objPaymentOOC.Cust_Code = txtCustCode.Text;
            objPaymentOOC.PaymentMedia = "TR";
            objPaymentOOC.OCCPurpose = 1;
            objPaymentOOC.OCC_PaymentDate = System.DateTime.Now;
            objPaymentOOC.OCC_Amount = 100;
            objPaymentOOC.OCC_VoucherNo = "OCC-C";
            objPaymentOOC.PaymentPeriod = System.DateTime.Now;
            objPaymentOOC.Remarks = "";
            objPaymentOOC.PaymentOCCPurpose = "Tex Certificate";
            return objPaymentOOC;

        }
            public void Sending_Report()
        {
            try
            {
                if (rdbTaxCertificate.Checked == true)
                {
                    PaymentOOCBO objPaymentOOC = new PaymentOOCBO();
                    objPaymentOOC = InitializePaymentOOCBO();
                    PaymentOOC objpaymentOcc = new PaymentOOC();

                    string Year = dtToDate.Value.ToString("yyyy");
                    objAll_ReportBAL.InsertToTRInfo(objPaymentOOC);
                    objAll_ReportBAL.Tax_Certificate("", txtCustCode.Text.Trim(), txtCustomerName.Text.Trim(), txtEmailID.Text.Trim(), Year, "", "");
                }
                else if (rdbSummaryLedger.Checked == true)
                {
                    if (dtFromDate.Value == dtToDate.Value)
                    {
                        objAll_ReportBAL.Insert_All_Report_Sender("", txtCustomerName.Text.Trim(), txtCustCode.Text.Trim(), txtEmailID.Text.Trim(), txtEmailID.Text.Trim()
                            , dtFromDate.Value.ToString(), "", "", "", "summary", "", "", "", "User Module");
                    }
                    else
                    {
                        objAll_ReportBAL.Insert_All_Report_Sender("", txtCustomerName.Text.Trim(), txtCustCode.Text.Trim(), txtEmailID.Text.Trim(), txtEmailID.Text.Trim()
                            , "", dtFromDate.Value.ToString(), dtToDate.Value.ToString(), "", "summary", "", "", "", "User Module");
                    }
                }
                else if (rdbTradeIPOConfirmation.Checked == true)
                {
                    if (dtFromDate.Value == dtToDate.Value)
                    {
                        objAll_ReportBAL.Insert_All_Report_Sender("", txtCustomerName.Text.Trim(), txtCustCode.Text.Trim(), txtEmailID.Text.Trim(), txtEmailID.Text.Trim()
                            , dtFromDate.Value.ToString(), "", "", "", "confirmation", "", "", "", "User Module");
                    }
                    else
                    {
                        objAll_ReportBAL.Insert_All_Report_Sender("", txtCustomerName.Text.Trim(), txtCustCode.Text.Trim(), txtEmailID.Text.Trim(), txtEmailID.Text.Trim()
                            , "", dtFromDate.Value.ToString(), dtToDate.Value.ToString(), "", "confirmation", "", "", "", "User Module");
                    }
                }
                else if (rdbPortolio.Checked == true)
                {
                    if (dtFromDate.Value == dtToDate.Value)
                    {
                        objAll_ReportBAL.Insert_All_Report_Sender("", txtCustomerName.Text.Trim(), txtCustCode.Text.Trim(), txtEmailID.Text.Trim(), txtEmailID.Text.Trim()
                            , dtFromDate.Value.ToString(), "", "", "", "portfolio", "", "", "", "User Module");
                    }
                    else
                    {
                        objAll_ReportBAL.Insert_All_Report_Sender("", txtCustomerName.Text.Trim(), txtCustCode.Text.Trim(), txtEmailID.Text.Trim(), txtEmailID.Text.Trim()
                            , "", dtFromDate.Value.ToString(), dtToDate.Value.ToString(), "", "portfolio", "", "", "", "User Module");
                    }
                }

            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
