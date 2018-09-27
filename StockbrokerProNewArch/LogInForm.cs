using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using DataAccessLayer;

namespace StockbrokerProNewArch
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        private void BtnLogInClick(object sender, EventArgs e)
        {
            if (IsValidEntry())
            {
                try
                {
                    LoginManagementBAL loginBAL = new LoginManagementBAL();
                    CommonBAL comBal = new CommonBAL();
                    int branchId = loginBAL.UserPassCheck(txtUserName.Text, txtPassword.Text);
                    string branchName = loginBAL.GetBranchName(branchId);

                    if (branchId != 0)
                    {

                        if(loginBAL.IsActive)
                        {
                            if (loginBAL.CheckLoggedinStatus(txtUserName.Text) == 1)
                            {
                                MessageBox.Show("This user is already loggedin. Please check.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshFields();
                                txtUserName.Focus();
                                return;
                            }
                            loginBAL.UpdateLoggedinStatus(txtUserName.Text, 1);
                            loginBAL.InsertLogRecord();

                            GlobalVariableBO._userName = txtUserName.Text;
                            GlobalVariableBO._branchId = branchId;
                            GlobalVariableBO._branchName = branchName;
                            GlobalVariableBO._employeeCode = loginBAL.EmployeeCode;
                            GlobalVariableBO._currentServerDate = comBal.GetCurrentServerDate_FromDB();

                            LoginInfo._userName = txtUserName.Text;
                            LoginInfo._branchId = branchId;
                            LoginInfo._branchName = branchName;
                            LoginInfo._employeeCode = loginBAL.EmployeeCode;
                            LoginInfo._currentServerDate = comBal.GetCurrentServerDate_FromDB();
                                
                            DialogResult = DialogResult.OK;
                        }

                        else
                        {
                            MessageBox.Show("User has been Deactived to Login Stock Broker Pro.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshFields();
                            txtUserName.Focus();
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("User Name Or Password is not Correct.Please try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshFields();
                        txtUserName.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Log in failed because of the error :" + ex.Message);
                }
            }
        }
        private bool IsValidEntry()
        {
            if (String.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                MessageBox.Show("User name is required.", "Login Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUserName.Text = "";
                txtUserName.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
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

        private void RefreshFields()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }


        private void BtnExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogInFormLoad(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void LogInFormPaint(object sender, PaintEventArgs e)
        {
            /*var pen = new Pen(Color.SteelBlue, 2);
            var rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height);
            var brBackground = new LinearGradientBrush(rect, Color.FromArgb(170, 208, 255), Color.FromArgb(236, 233, 216), LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brBackground, rect);
            e.Graphics.DrawRectangle(pen, rect);*/
        }
    }
}
