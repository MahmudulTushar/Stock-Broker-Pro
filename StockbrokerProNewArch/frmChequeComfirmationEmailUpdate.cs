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
using System.Text.RegularExpressions;

namespace StockbrokerProNewArch
{
    public partial class frmChequeComfirmationEmailUpdate : Form
    {
        public frmChequeComfirmationEmailUpdate()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChequeComfirmationEmailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                GetEmailConfirmationData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

         private void GetEmailConfirmationData()
        {
            try
            {
                EmailConfirmationBAL objEmailConfirmation = new EmailConfirmationBAL();
                DataTable data = new DataTable();
                data = objEmailConfirmation.GetEmailConfirmation();

                txtEmailBody.Text = data.Rows[0]["Body"].ToString();
                txtEmailFrom.Text = data.Rows[0]["From"].ToString();
                txtEmailSubject.Text = data.Rows[0]["Subject"].ToString();
                txtEmailTo.Text = data.Rows[0]["To"].ToString();

            }
            catch (Exception)
            {
                throw;
            }
        }

       

        private void btnUpdateTo_Click(object sender, EventArgs e)
        {
            try
            {
                SaveEmailConfirmation();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveEmailConfirmation()
        {
            if (txtEmailTo.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Email To Required.","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtEmailTo.Focus();
                return;
            }

            else if (txtEmailFrom.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Email From Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailFrom.Focus();
                return;
            }

            else if (txtEmailBody.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Email Body Required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailBody.Focus();
                return;
            }

            else
            {
                if (isEmailAddress(txtEmailFrom.Text) == false)
                {
                    MessageBox.Show("Email From Address Should be Correct Format.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailFrom.Focus();
                    return;
                }

                else if (isEmailAddress(txtEmailTo.Text) == false)
                {
                    MessageBox.Show("Email To Address Should be Correct Format.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailTo.Focus();
                    return;
                }

                else
                {
                    EmailConfirmationBO objEmailConfirmationBO = new EmailConfirmationBO();
                    objEmailConfirmationBO.To = txtEmailTo.Text;
                    objEmailConfirmationBO.Form = txtEmailFrom.Text;
                    objEmailConfirmationBO.Body = txtEmailBody.Text;
                    objEmailConfirmationBO.Subject = txtEmailSubject.Text;

                    EmailConfirmationBAL objEmailConfirmationBAl = new EmailConfirmationBAL();
                    objEmailConfirmationBAl.UpdateEmailConfirmation(objEmailConfirmationBO);

                    MessageBox.Show("Email Confirmation is Secessfully Update.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private bool isEmailAddress(string inputEmail)
        {
            
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

    }
}
