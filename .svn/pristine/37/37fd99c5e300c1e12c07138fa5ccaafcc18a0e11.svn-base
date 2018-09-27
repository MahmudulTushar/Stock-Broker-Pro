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
    public partial class LockWindow2 : Form
    {
        public LockWindow2()
        {
            InitializeComponent();
        }
        private void RefreshFields()
        {
            txtPassword.Text = "";
        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (IsValidEntry())
            {
                try
                {
                    LoginManagementBAL loginBAL = new LoginManagementBAL();
                    int branchId = loginBAL.UserPassCheck(GlobalVariableBO._userName, txtPassword.Text);

                    if (branchId != 0)
                    {
                        GlobalVariableBO._branchId = branchId;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Password is not Correct.Please try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshFields();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Log in failed because of the error :" + ex.Message);
                }
            }
        }

        private void LockWindow2_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnectionCheck();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Connection Failed. Error : " + exception.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtPassword.Focus();
        }
        private void DatabaseConnectionCheck()
        {
            DatabaseConnectionCheck _databaseConnectionCheck = new DatabaseConnectionCheck();
            _databaseConnectionCheck.CheckDatabaseConnections();
        }
        private bool IsValidEntry()
        {
            if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Password is required.", "Login Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
