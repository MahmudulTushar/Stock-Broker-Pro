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
    public partial class SettleEditEntry : Form
    {
        private int settleId;
        private string custCode;
        private int quantity;

        public SettleEditEntry(int settleId, string custCode,int Quantity)
        {
            InitializeComponent();

            this.settleId = settleId;
            this.custCode = custCode;
            this.quantity = Quantity;
            txtNewQuantity.Text = Quantity.ToString();
        }

        private string _payLog;
        public string PayLog
        {
            get { return _payLog; }
            set { _payLog = value; }
        }


        private string _iSIN;
        public string ISIN
        {
            get { return _iSIN; }
            set { _iSIN = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUpdates();
        }

        private void SettleEditEntry_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "Editing From : " + custCode;
        }

        private void LoadCustInfo()
        {
            if (txtCustCode.Text.Equals(""))
            {

                MessageBox.Show("Please Enter a valid Customer Code", "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PayInTradeBAL payInTradeBal = new PayInTradeBAL();
            DataTable data = payInTradeBal.GetCustInfo(txtCustCode.Text);

            if(data.Rows.Count>0)
            {
                txtCustCodeFinal.Text = data.Rows[0]["Cust_Code"].ToString();
                txtName.Text = data.Rows[0]["Cust_Name"].ToString();
                txtBoid.Text = data.Rows[0]["BOID"].ToString();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadCustInfo();
        }

        private void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Return))
            {
                LoadCustInfo();
            }
        }

        private void SaveUpdates()
        {
            if(txtCustCodeFinal.Text.Equals(""))
            {

                MessageBox.Show("Please Select a New Account to Edit.", "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewQuantity.Text.Equals(""))
            {

                MessageBox.Show("Trade Quantity Required.", "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            PayInTradeBAL payInTradeBal = new PayInTradeBAL();
            try
            {
                PayinBO objPayinBO = new PayinBO();
                objPayinBO.CustomerCodeFrom = custCode;
                objPayinBO.PreviousQuantity = quantity;
                objPayinBO.Paylog = _payLog;
                objPayinBO.CompanyISIN = _iSIN;

                payInTradeBal.SaveUpdatesToPayin(txtCustCodeFinal.Text, txtBoid.Text, settleId, txtNewQuantity.Text, objPayinBO);
                MessageBox.Show("Data updated successfully.", "Success Message",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception exception)
            {

                MessageBox.Show("Fail to edit data. Because: " + exception.Message, "Error Message",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
