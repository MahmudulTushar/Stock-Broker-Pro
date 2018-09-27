using System;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
             try
             {
                 if (IsValidInput())
                 {
                     UserManagementBAL usrMngBAL = new UserManagementBAL();
                     usrMngBAL.ChangePassword(GlobalVariableBO._userName, txtNewPassword.Text);
                     MessageBox.Show(GlobalVariableBO._userName + "'s password has successfully changed.");
                     ClearField();
                 }

             }
             catch (Exception exc)
             {
                 MessageBox.Show("Password Change Operation unsuccessful because of the error :" + exc.Message);

             }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidInput()
        {
            if (CheckCurrentPassword())
            {
                MessageBox.Show("User Name : " + GlobalVariableBO._userName + " you have enter wrong password.Please enter the correct password.");
                ClearField();
                return false;
            }
            else if (!string.Equals(txtNewPassword.Text, txtConfirmPassword.Text))
            {
                MessageBox.Show("New Password invalid.Re-enter valid password.");
                ClearField();
                return false;
            }
            return true;
        }

        private void ClearField()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private bool CheckCurrentPassword()
        {
            UserManagementBAL userBAL = new UserManagementBAL();
            if (userBAL.CheckCurrentPassword(GlobalVariableBO._userName, txtCurrentPassword.Text))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
        }
    }
}
