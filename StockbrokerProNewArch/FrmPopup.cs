using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using BusinessAccessLayer.BAL;
using DataAccessLayer;

using iTextSharp.text;

namespace StockbrokerProNewArch
{
    public partial class FrmPopup : Form
    {
        public FrmPopup()
        {
            InitializeComponent();
        }

        private void FrmPopup_Load(object sender, EventArgs e)
        {
            LoadBankName();
            cmbBankName.Text = "Select Bank Name";
            cmbBankName.Focus();

        }

        string x = "";
        private void LoadBankName()
        {
            string query111 = @"SELECT  BankName +'   '+ BankAcc +'   '+ AccountPurpose AS Bankinformation, BankAcc
                                    FROM   [BankBook].[dbo].[BankInfo]
                                    GROUP BY BankName +'   '+ BankAcc +'   '+ AccountPurpose, BankAcc";

            ExpenseTransactionBAL Ex_Trans_BankBook = new ExpenseTransactionBAL();
            cmbBankName.DataSource = Ex_Trans_BankBook.getBankInforFromBankBook(query111);
            cmbBankName.DisplayMember = "Bankinformation";
            cmbBankName.ValueMember = "BankAcc";

            x = cmbBankName.SelectedValue.ToString();
            lblAccountNo.Text = x;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCheckNo.Text == "")
            {
                MessageBox.Show("Please Enter Check Number.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCheckNo.Focus();
            }

            else
            {
                frmExpenseTransaction frm = new frmExpenseTransaction();
                frm.Bank_Name = cmbBankName.Text;
                frm.Check_No = txtCheckNo.Text;
                frm.Check_Date = Convert.ToString(dtpPayDate.Value);
                frm.Bank_AccNo = lblAccountNo.Text;
                BankName();
                frm.Bank_Name = account_name;
                BankID();
                frm.Bank_ID_No = Bank_ID;
                AccPurpose();
                frm.Account_Purpose = purpose;
                this.Close();
                frm.Show();
            }

        }

        private ExpenseTransactionBAL expbal = new ExpenseTransactionBAL();
        private string account_name;
        private string Bank_ID;
        private string purpose;

        private void BankName()
        {
            DataTable dt = new DataTable();
            string queryString = @"select BankName FROM [BankBook].[dbo].[BankInfo]  where BankAcc='" + lblAccountNo.Text + "'";

            dt = expbal.Get_Data(queryString);
            account_name = dt.Rows[0][0].ToString();
        }
        private void BankID()
        {
            DataTable dt = new DataTable();
            string queryString = @"select BankId FROM [BankBook].[dbo].[BankInfo]  where BankAcc='" + lblAccountNo.Text + "'";

            dt = expbal.Get_Data(queryString);
            Bank_ID = dt.Rows[0][0].ToString();
        }
        private void AccPurpose()
        {
            DataTable dt = new DataTable();
            string queryString = @"select AccountPurpose FROM [BankBook].[dbo].[BankInfo]  where BankAcc='" + lblAccountNo.Text + "'";

            dt = expbal.Get_Data(queryString);
            purpose = dt.Rows[0][0].ToString();
        }


        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                x = cmbBankName.SelectedValue.ToString();
                lblAccountNo.Text = x;
                lblAccountNo.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbBankName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                txtCheckNo.Focus();
            }
        }

        private void txtCheckNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSave.Focus();
            }
        }

       
        //private void FrmPopup_FormClosing(object sender, FormClosingEventArgs e)
        //{

        //    e.Cancel = true;
        //    FrmPopup frm = new FrmPopup();
        //    frm.Show();
        //}

        private void FrmPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            frmExpenseTransaction frm = new frmExpenseTransaction();
            frm.Show();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
         
            frmExpenseTransaction frm = new frmExpenseTransaction();
            frm.Show();
        }
    }
}

