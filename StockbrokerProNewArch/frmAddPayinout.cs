using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class frmAddPayinout : Form
    {
        public frmAddPayinout()
        {
            InitializeComponent();
        }

        private string _payLog;
        public String PayLog
        {
            get { return _payLog; }
            set { _payLog = value; }
        }

        private DialogResult _dialogOK;
        public DialogResult DialogOK
        {
            get { return _dialogOK; }
            set { _dialogOK = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddPayinout_Load(object sender, EventArgs e)
        {
            GetCompanyShortCodeList();
        }

        private void GetCompanyShortCodeList()
        {
            try
            {
                CompanyBAL objCompanyBAl = new CompanyBAL();
                DataTable dtCompanyShortCodeList = new DataTable();
                dtCompanyShortCodeList = objCompanyBAl.GetCompanyShortCodeList();
                ddlCompanyShortCode.DataSource = dtCompanyShortCodeList;
                ddlCompanyShortCode.DisplayMember = "Comp_Short_Code";
                ddlCompanyShortCode.ValueMember = "ISIN_No";
                GetCompanyISINNo();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetCustomerBOId()
        {
            try
            {
                CustomerBAL objCustomerBal = new CustomerBAL();

                if (txtCustomerCode.Text.Trim() != String.Empty)
                {
                    DataTable dtRecord = new DataTable();
                    dtRecord = objCustomerBal.GetCustomerInfo(txtCustomerCode.Text);

                    if (dtRecord.Rows.Count>0)
                    {
                        btnSave.Enabled =true;
                        txtBOId.Text = dtRecord.Rows[0]["BO_ID"].ToString();
                        txtFinalCustomerCode.Text = dtRecord.Rows[0]["Cust_Code"].ToString();
                    }

                    else
                    {
                        MessageBox.Show("Customer Code does not exist.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txtCustomerCode.Focus();
                        btnSave.Enabled =false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetCompanyISINNo()
        {
            try
            {
                if (ddlCompanyShortCode.Text.Trim() != String.Empty)
                {
                    txtISIN.Text = ddlCompanyShortCode.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSattlementInfo();
        }

        private void SaveSattlementInfo()
        {
            try
            {
                if (txtCustomerCode.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Customer Code Required ?","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtCustomerCode.Focus();
                }

                else if (txtTradeqty.Text.Trim() == String.Empty)
                {

                    MessageBox.Show("Trade Qunity Required ?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTradeqty.Focus();
                }

                else if (txtBOId.Text.Trim() == String.Empty)
                {

                    MessageBox.Show("Customer BOID Required ?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerCode.Focus();
                }

                else
                {
                    PayinBO objPayinBO = new PayinBO();
                   
                  
                    objPayinBO.SattlementDate = dtpSattlementDate.Value;
                    objPayinBO.CompanyISIN = txtISIN.Text;
                    objPayinBO.CustomerCode = txtFinalCustomerCode.Text;
                    objPayinBO.Paylog = _payLog;
                    objPayinBO.TradeQty = txtTradeqty.Text;
                    PayinBAL objpayinBAl = new PayinBAL();

                    if (_payLog == "O")
                    {
                        objPayinBO.BOId = "1202350000281086";
                        objPayinBO.CounterBOID = txtBOId.Text;
                        objpayinBAl.InsertPayoutSattlement(objPayinBO);
                        MessageBox.Show("successful Saved Payout sattlement.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (_payLog == "I")
                    {
                        objPayinBO.BOId = txtBOId.Text;
                        objPayinBO.CounterBOID = "1202350000281086";
                        objpayinBAl.InsertPayinSattlement(objPayinBO);
                        MessageBox.Show("successful Saved Payin sattlement.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }





                    _dialogOK = DialogResult.Yes;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ddlCompanyShortCode_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetCustomerBOId();
            }
        }

       

        private void ddlCompanyShortCode_ValueMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void ddlCompanyShortCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCompanyISINNo();
        }
    }
}
