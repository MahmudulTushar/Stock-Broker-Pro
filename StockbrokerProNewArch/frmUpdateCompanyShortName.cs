using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;

namespace StockbrokerProNewArch
{
    public partial class frmUpdateCompanyShortName : Form
    {
        public frmUpdateCompanyShortName()
        {
            InitializeComponent();
        }

        private bool _isLoad = false;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUpdateCompanyShortName_Load(object sender, EventArgs e)
        {
            GetOldCompanyShortCodeList();

            if (ddlOldCompanyShortCode.Text.Trim() != string.Empty && _isLoad == true)
                GetOldCompanyName(ddlOldCompanyShortCode.Text);
        }

        private void GetOldCompanyShortCodeList()
        {
            try
            {
                CompanyBAL objCompanyBAL=new CompanyBAL();
                DataTable data=new DataTable();
                data = objCompanyBAL.GetCompanyShortCodeList();
                ddlOldCompanyShortCode.DataSource = data;
                ddlOldCompanyShortCode.DisplayMember = "Comp_Short_Code";

                if (ddlOldCompanyShortCode.Text.Trim() != string.Empty)
                    _isLoad = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetOldCompanyName(string CompanyShortCode)
        {
            try
            {
                CompanyBAL objCompanyBAL=new CompanyBAL();


                if (CompanyShortCode != string.Empty )
                {
                    string CompanyName = objCompanyBAL.GetCompanyName(CompanyShortCode);
                    txtOldCompanyName.Text = CompanyName;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ddlOldCompanyShortCode_TextChanged(object sender, EventArgs e)
        {
            if(ddlOldCompanyShortCode.Text.Trim()!=string.Empty && _isLoad==true)
            GetOldCompanyName(ddlOldCompanyShortCode.Text);
        }

        private void btnChangeCompanyShortName_Click(object sender, EventArgs e)
        {
            ChangeCompanyShortCode();
        }

        private void ChangeCompanyShortCode()
        {
            try
            {
                if(txtNewCompanyShortName.Text.Trim()==String.Empty)
                {
                    MessageBox.Show("Change Company Short Code Required.", "Change Company Short Code",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                else if(txtNewCompanyName.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Change Company Name Required.", "Change Company Name", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                else
                {
                    if(MessageBox.Show("Do you want to Update Company Short Name ?","Update Company Short Name ||",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        CompanyBAL objCompanyBAL=new CompanyBAL();
                        objCompanyBAL.ChangeCompanyShortCode(txtNewCompanyShortName.Text,txtNewCompanyName.Text,ddlOldCompanyShortCode.Text,txtOldCompanyName.Text);
                        MessageBox.Show("Scessfully Change Company Short Name.", "Company Short Name",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GetOldCompanyShortCodeList();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
