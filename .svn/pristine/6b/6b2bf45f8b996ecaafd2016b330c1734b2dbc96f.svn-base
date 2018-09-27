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
using System.Collections;
using System.Collections.Generic;

namespace StockbrokerProNewArch
{
    public partial class FrmPopUpWithBankInformation : Form
    {
        ExpenseTransactionBAL BAL = new ExpenseTransactionBAL();
        
        string myString = string.Empty;

      
        public FrmPopUpWithBankInformation()
        {
            InitializeComponent();
        }

        private void FrmPopUpWithBankInformation_Load(object sender, EventArgs e)
        {
            LoadBankName();
            clCmbBankNameForWithdraw.Select();
            clCmbBankNameForWithdraw.Focus();
        }  

        private void LoadBankName()
        {
            DataTable dt;
            dt = BAL.GetBankNameForWithdrawalHistory();
            clCmbBankNameForWithdraw.ViewColumn = 0;
            clCmbBankNameForWithdraw.Data = dt;
        }

        private void clCmbBankNameForWithdraw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtChequeNo.Focus();
            }
        }
        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                dtpPayDate.Focus();
            }
        }

        private void dtpPayDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSave.Focus();
                btnSave.FlatAppearance.BorderColor = Color.Red;
                btnSave.FlatAppearance.BorderSize = 1;
            }
        }

        private string BName()
        {
            string NewBName = string.Empty;
            DataTable dt;
            dt = BAL.GetBankNameForWithdrawalHistory();

            //Add to arraylsit from DataTable's BankName column
            List<string> SavedbankNameList = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                SavedbankNameList.Add(dr["BankName"].ToString());
            }
            foreach (string value in SavedbankNameList)
            {
                if (value.Trim().Contains(clCmbBankNameForWithdraw.Text.Trim()))
                {
                    NewBName = value;
                }
            }
            return NewBName;
        }
        private bool ChequeValidation()
        {
            if (clCmbBankNameForWithdraw.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Write Bank Name...", "Information.");
                clCmbBankNameForWithdraw.Focus();
                return true;
            }
            else if (string.IsNullOrEmpty(BName()))
            {
                MessageBox.Show("'" + clCmbBankNameForWithdraw.Text.Trim() + "' not registered bank..", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clCmbBankNameForWithdraw.Focus();
                return true;
            }
            else if (txtChequeNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Write Cheque No...", "Information.");
                txtChequeNo.Focus();
                return true;
            }
            else if (dtpPayDate.Value < GlobalVariableBO._currentServerDate)
            {
                MessageBox.Show("Select Correct Date..." + "\r\n" + "Transaction Not Possible On Previous Date.", "Information!");
                dtpPayDate.Focus();
                return true;
            }
            else return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ChequeValidation())
                return;

            PopUpBO._BankName = clCmbBankNameForWithdraw.Text.Trim();
            PopUpBO._ChequeNo = txtChequeNo.Text.Trim();
            var sPaydate = dtpPayDate.Value;
            PopUpBO._Paydate = dtpPayDate.Value.Date;

            MessageBox.Show("Check Information Saved...");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Want To Close Without Saving Cheque Information?", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
    }
}
