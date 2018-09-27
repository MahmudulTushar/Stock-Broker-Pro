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
    public partial class SMSDataEdit : Form
    {
        private string _id;
        public SMSDataEdit(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUpdatedData();
        }
        private void SaveUpdatedData()
        {
            SMSConfEdit smsConfEdit = new SMSConfEdit();
            try
            {
                smsConfEdit.SmsId = _id;
                smsConfEdit.Customer = txtCustomer.Text;
                smsConfEdit.BuySell = ddlBuySell.Text;
                smsConfEdit.Instrument = ddlInstrument.Text;
                smsConfEdit.TradeQty = Convert.ToInt32(txtTradeQty.Text);
                smsConfEdit.TradePrice = Convert.ToDecimal(txtTradePrice.Text);
                smsConfEdit.MobileNo = txtMobileNo.Text;

                SMSDataEditBAL smsDataEditBal = new SMSDataEditBAL();
                smsDataEditBal.UpdateSmsInfo(smsConfEdit);
                MessageBox.Show("Data Updated Successfully","Successful Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SMSDataEdit_Load(object sender, EventArgs e)
        {
            LoadInstruments();
            LoadData(_id);
        }

        private void LoadInstruments()
        {
            LoadDDLBAL loadDDLBAL = new LoadDDLBAL();
            DataTable dtData = loadDDLBAL.LoadDDL("SBP_Company");
            ddlInstrument.DataSource = dtData;
            ddlInstrument.DisplayMember = "Comp_Short_Code";
            ddlInstrument.ValueMember = "Comp_Short_Code";
            if (ddlInstrument.HasChildren)
                ddlInstrument.SelectedIndex = -1;
        }
        private void LoadData(string id)
        {
            SMSDataEditBAL smsDataEditBal = new SMSDataEditBAL();
            DataTable data = smsDataEditBal.LoadData(id);

            txtCustomer.Text = data.Rows[0]["Customer"].ToString();
            ddlBuySell.Text = data.Rows[0]["BuySellFlag"].ToString();
            ddlInstrument.Text = data.Rows[0]["InstrumentCode"].ToString();
            txtTradeQty.Text = data.Rows[0]["TradeQty"].ToString();
            txtTradePrice.Text = data.Rows[0]["TradePrice"].ToString();
            txtMobileNo.Text = data.Rows[0]["MobileNo"].ToString();
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            if(txtCustomer.Text.Trim().Equals(""))
                return;
            SMSDataEditBAL smsDataEditBal = new SMSDataEditBAL();
            if(!smsDataEditBal.CheckCustomer(txtCustomer.Text))
            {
                MessageBox.Show("Customer Code not found. Please try with correct code.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomer.Text = "";
                txtCustomer.Focus();
            }
        }
    }
}
