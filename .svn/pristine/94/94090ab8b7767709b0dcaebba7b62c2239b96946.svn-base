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
    public partial class CustomerClosingForm : Form
    {
        private string _boID = "";
        string _custCode = "";
        
        public CustomerClosingForm()
        {
            InitializeComponent();
        }

        private bool Validation()
        {
            bool result = true;
            double doubleTryParse;
            if (double.TryParse(txtMatureBalance.Text, out doubleTryParse))
            {
                if (doubleTryParse <= 0 && ddlPaymentMedia.SelectedItem == "Transfer")
                {
                    MessageBox.Show("Matured Money Balance is Negetive Not Allowed for Transfer");
                    result=false;
                    return result;
                }
            }
            //if (txtBOStatus != BusinessAccessLayer.Constants.Indication_AccBOStatus.Active)
            //{
            //    result = false;
            //    return result;
            //}
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchCustomerInformation()
        {
            if (txtSearchCustomer.Text.Trim()!="")
                ShowSearchCustInfo();
        }

        private void ShowSearchCustInfo()
        {
            DataTable custDateTable = new DataTable();
            CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();


            //---------------------- Search By BO ID -------------------///
            if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
            {
                _boID = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);

                if(custDateTable.Rows.Count>0)
                {
                    if (custDateTable.Rows[0]["Status"].ToString().Equals("Closed"))
                    {
                        MessageBox.Show("Client Alredy has closed Account.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        DisplayClientInformation(custDateTable);
                    }
                }

                else
                {
                    MessageBox.Show("No customer found.");
                    txtSearchCustomer.Focus();
                }

              
            }
           //---------------------- END OF Search By BO ID -------------------///

            //---------------------- Start Search By Cust ID -------------------///

            else
            {
                _custCode = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);

                if (custDateTable.Rows.Count > 0)
                {
                    if (custDateTable.Rows[0]["Status"].ToString().Equals("Closed"))
                    {
                        MessageBox.Show("Client Alredy has closed Account.", "", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }

                    else
                    {
                        DisplayClientInformation(custDateTable);
                    }

                }

                else
                {
                    MessageBox.Show("No customer found.");
                    txtSearchCustomer.Focus();
                }

            }

            //---------------------- END OF Search By Cust ID -------------------///


       
        }

        private void DisplayClientInformation(DataTable custDateTable)
        {
            try
            {
                
                    txtCustCode.Text = custDateTable.Rows[0]["Cust_Code"].ToString();
                    txtAccountHolderName.Text = custDateTable.Rows[0]["Cust_Name"].ToString();
                    txtAccountHolderBOId.Text = custDateTable.Rows[0]["BO_Id"].ToString();
                    txtCustSatus.Text = custDateTable.Rows[0]["Status"].ToString();
                    txtBOStatus.Text = custDateTable.Rows[0]["BO_Status"].ToString();

                    if (txtBOStatus.Text.Trim().Equals("Active"))
                    {
                        txtBOStatus.ForeColor = Color.Blue;
                    }

                    else
                    {
                        txtBOStatus.ForeColor = Color.Red;
                    }
                    if (txtCustSatus.Text.Trim().Equals("Active"))
                    {
                        txtCustSatus.ForeColor = Color.Blue;
                    }

                    else
                    {
                        txtCustSatus.ForeColor = Color.Red;
                    }

                    if (Int32.Parse(custDateTable.Rows[0]["Share_Balance"].ToString()) > 0)
                    {
                        txtShareBalance.Text = "Existing Share : " + custDateTable.Rows[0]["Share_Balance"].ToString();
                        txtShareBalance.BackColor = Color.Brown;
                    }

                    else
                    {
                        txtShareBalance.Text = "Existing Share : 0.00";
                        txtShareBalance.BackColor = Color.OliveDrab;
                    }

                    CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
                    PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                    txtBalance.Text = customerInfoBAL.GetCurrentBalane(txtCustCode.Text).ToString("N");
                    txtMatureBalance.Text = customerInfoBAL.GetMaturedBalane(txtCustCode.Text).ToString("N");
                    txtTotalAccruedCharge.Text = paymentInfoBal.GetCurrentBalaneforAccrued(txtCustCode.Text).ToString("N");
                    txtVoucherNo.Focus();
                    

                    if (Convert.ToDouble(txtBalance.Text) <= 0)
                    {
                        txtBalance.BackColor = System.Drawing.Color.Brown;
                    }
                    else
                    {
                        txtBalance.BackColor = Color.OliveDrab;
                    }

                    if (Convert.ToDouble(txtMatureBalance.Text) <= 0)
                    {
                        txtMatureBalance.BackColor = System.Drawing.Color.Brown;
                    }
                    else
                    {
                        txtMatureBalance.BackColor = Color.OliveDrab;
                    }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Validation())
                //{
                    CloseCustomer();

                    DataTable custDateTable = new DataTable();
                    CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
                    _custCode = txtSearchCustomer.Text;
                    custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                    DisplayClientInformation(custDateTable);
                //}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CloseCustomer()
        {

            if (txtSearchCustomer.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill the Customer Code/BO ID.");
                return;
            }
            else if(txtBOStatus.BackColor==Color.Brown)
            {
                MessageBox.Show("To Close Client Account, BO Account must be Closed.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            else if(txtShareBalance.BackColor==Color.Brown)
            {
                MessageBox.Show("To Close Client Account,Share Balance must be zero.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                SaveCloseInfo();
            }
           
        }

        private void SaveCloseInfo()
        {
             if (MessageBox.Show("Do you want to continue to close the Customer: " + txtAccountHolderName.Text + "?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 try
                 {
                     CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
                     //PaymentOOC objpaymentOcc = new PaymentOOC();
                     if (customerInfoBAL.CheckClosingStatus(txtCustCode.Text))
                     {
                         double doubleTryParse;
                         CustomerCloseInfoBO closeInfoBo = new CustomerCloseInfoBO();
                         closeInfoBo.CustCode = txtCustCode.Text;
                         
                         if (double.TryParse(txtCharges.Text.Trim(), out doubleTryParse))
                         {
                             closeInfoBo.ClosingCharge = doubleTryParse;
                            
                         }
                         closeInfoBo.VoucherNo = txtVoucherNo.Text;
                         closeInfoBo.ClosingDate = dtCloseDate.Value;
                         
                         if (ddlPaymentMedia.Text == "Cash")
                         {
                            closeInfoBo.PaymentMedia = BusinessAccessLayer.Constants.Indication_PaymentTransaction.Cash;
                         }
                         if (ddlPaymentMedia.Text == "Transfer")
                         {
                            closeInfoBo.PaymentMedia = BusinessAccessLayer.Constants.Indication_PaymentTransaction.TR;
                         }
                         customerInfoBAL.CloseCustomer(closeInfoBo);
                         MessageBox.Show(txtAccountHolderName.Text + " customer has closed successfully.");
                     }
                     else
                     {
                         MessageBox.Show("Customer has allready Closed.");
                     }                }
                 catch (Exception exc)
                 {
                     MessageBox.Show("Fail to close the customer. Error: " + exc.Message);
                 }
             }
        }

        private void CustomerClosingForm_Load(object sender, EventArgs e)
        {
            ddlPaymentMedia.SelectedIndex = 0;
            ddlSearchCustomer.SelectedIndex = 0;
            txtSearchCustomer.Focus();
            LoadDefaultRedeemedAmnt();
        }

        private void LoadDefaultRedeemedAmnt()
        {
            DataTable dataTable=new DataTable();
            CustomerInfoBAL customerInfoBal=new CustomerInfoBAL();
            dataTable=customerInfoBal.GetDefaultRedeemedAmnt();
            if (dataTable.Rows.Count > 0)
                txtCharges.Text = String.Format("{0:f}", float.Parse(dataTable.Rows[0][0].ToString()));
                   
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            SearchCustomerInformation();
            LoadDefaultRedeemedAmnt();
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                CloseCustomer();
            }
       
        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchCustomerInformation();
            }

        }

        private void txtCharges_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMatureBalance.Text.Trim() != "" && txtCharges.Text.Trim() != "")
                {
                    float floatTryParse_Money;
                    float floatTryParse_Charge;
                    decimal accruedcharge = 0;
                    decimal availablebalance = 0;
                    PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
                    if(!string.IsNullOrEmpty(txtCustCode.Text))
                             accruedcharge = Convert.ToDecimal(paymentInfoBal.GetCurrentBalaneforAccrued(txtCustCode.Text).ToString("N"));
                    if (Convert.ToString(ddlPaymentMedia.SelectedItem) == "Transfer")
                    {
                        if (float.TryParse(txtMatureBalance.Text, out floatTryParse_Money) && float.TryParse(txtCharges.Text, out floatTryParse_Charge))
                        {
                            availablebalance = Convert.ToDecimal(floatTryParse_Money - floatTryParse_Charge);
                            txtRestAmount.Text = Convert.ToString(availablebalance - accruedcharge);
                        }
                        //txtRestAmount.Text = Convert.ToString(float.Parse(txtMatureBalance.Text) - float.Parse(txtCharges.Text));
                    }
                    else if (Convert.ToString(ddlPaymentMedia.SelectedItem) == "Cash")
                    {
                        if (float.TryParse(txtMatureBalance.Text, out floatTryParse_Money))
                        {
                            availablebalance = Convert.ToDecimal(floatTryParse_Money);
                            txtRestAmount.Text = Convert.ToString(availablebalance - accruedcharge);
                        }
                            
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ddlPaymentMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            float floatTryParse_Money;
            float floatTryParse_Charge;
            decimal accruedcharge = 0;
            decimal availablebalance = 0;
            PaymentInfoBAL paymentInfoBal = new PaymentInfoBAL();
            if (!string.IsNullOrEmpty(txtTotalAccruedCharge.Text))
                accruedcharge = Convert.ToDecimal(paymentInfoBal.GetCurrentBalaneforAccrued(txtCustCode.Text).ToString("N"));
            if (Convert.ToString(ddlPaymentMedia.SelectedItem) == "Transfer")
            {
                if (float.TryParse(txtMatureBalance.Text, out floatTryParse_Money) && float.TryParse(txtCharges.Text, out floatTryParse_Charge))
                {
                    availablebalance = Convert.ToDecimal(floatTryParse_Money - floatTryParse_Charge);
                    txtRestAmount.Text = Convert.ToString(availablebalance-accruedcharge);
                }
                    
            }   //txtRestAmount.Text = Convert.ToString(float.Parse(txtMatureBalance.Text) - float.Parse(txtCharges.Text));
            else if (Convert.ToString(ddlPaymentMedia.SelectedItem) == "Cash")
            {
                if (float.TryParse(txtMatureBalance.Text, out floatTryParse_Money))
                {
                    availablebalance = Convert.ToDecimal(floatTryParse_Money);
                    txtRestAmount.Text = Convert.ToString(availablebalance - accruedcharge);
                }
                   
            }
        }

        

        
    }
}
