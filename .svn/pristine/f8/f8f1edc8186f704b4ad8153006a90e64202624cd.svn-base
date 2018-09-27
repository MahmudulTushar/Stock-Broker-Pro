using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;
using NewArch.Classes;
using System.Drawing.Imaging;

namespace NewArch
{
    public partial class frmSingleAccountHolder : Form
    {

        private string _custCode = "";
        private string _boID = "";
        public frmSingleAccountHolder()
        {
            InitializeComponent();
        }

        private void btnImgBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImageBrowse.ShowDialog() != DialogResult.Cancel)
            {
                txtImgLocation.Text = ofdImageBrowse.FileName;
                picPhoto.Image = Image.FromFile(txtImgLocation.Text);
                btnStartUpload.Enabled = true;

            }
        }



        private void btnStartUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("To Upload Image Customer Code Required.", "Image Upload", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtSearchCustomer.Focus();
                    return;
                }

                if (ddlSelctionMode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("To Upload Image Image Selection Mode Required.", "Image Upload", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ddlSelctionMode.Focus();
                    return;
                }

                if (txtImgLocation.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Imasge File Path Required to upload Image.", "Image Upload", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    btnImgBrowse.Focus();
                    return;
                }

                SingleImageBO singleImageBo = new SingleImageBO();
                singleImageBo.CustCode = txtCustCode.Text;
                singleImageBo.ImageSelectionMode = ddlSelctionMode.Text;

                var byteImage = new ImageResizeBAL().GetImageByte(ofdImageBrowse.FileName);
                //----------if image file convert error then show---------
                if (byteImage == null)
                {
                    MessageBox.Show("Wrong Image File.");
                    btnImgBrowse.Focus();
                    return;
                }
                singleImageBo.ImgByte = byteImage;


                if (singleImageBo.ImgByte != null)
                {
                    SingleImageBAL singleImageBal = new SingleImageBAL();

                    if (singleImageBal.IsExistPhoto(singleImageBo) == true)
                    {
                        if (MessageBox.Show("Photo Exist. Do you want to replace the photo ?", "Photo Uploader", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            singleImageBal.SaveToDatabase(singleImageBo);
                            MessageBox.Show("Photo Successfully Uploaded.", "Photo Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }

                    else
                    {
                        singleImageBal.SaveToDatabase(singleImageBo);
                        MessageBox.Show(" New Photo Successfully Uploaded.", "Photo Upload", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Image uplaod failed. Error:" + ex.Message);
            }

        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            SearchCustomerInformation();
        }

        private void SearchCustomerInformation()
        {
            if (txtSearchCustomer.Text.Trim() != "")
                ShowSearchCustInfo();
        }
        private void ShowSearchCustInfo()
        {
            DataTable custDateTable = new DataTable();
            CustomerInfoBAL customerInfoBAL = new CustomerInfoBAL();
            if (ddlSearchCustomer.SelectedItem.Equals("BO Id"))
            {
                _boID = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByBOID(_boID);
                if (custDateTable.Rows.Count > 0)
                {
                    txtCustCode.Text = custDateTable.Rows[0][0].ToString();
                    txtAccountHolderName.Text = custDateTable.Rows[0][1].ToString();
                    txtAccountHolderBOId.Text = custDateTable.Rows[0][2].ToString();
                    SetImageUploadType(custDateTable.Rows[0]["BO Type"].ToString());

                }
                else
                {
                    MessageBox.Show("No customer found.", "Image Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                _custCode = txtSearchCustomer.Text;
                custDateTable = customerInfoBAL.GetCustInfoByCustCode(_custCode);
                if (custDateTable.Rows.Count > 0)
                {
                    txtCustCode.Text = custDateTable.Rows[0][0].ToString();
                    txtAccountHolderName.Text = custDateTable.Rows[0][1].ToString();
                    txtAccountHolderBOId.Text = custDateTable.Rows[0][2].ToString();
                    SetImageUploadType(custDateTable.Rows[0]["BO Type"].ToString());

                }
                else
                {
                    MessageBox.Show("No customer found.");
                }
            }
        }

        private void ResetInput()
        {
            picPhoto.Image = null;
            txtImgLocation.Text = "";
        }

        private void SetImageUploadType(string BoType)
        {
            try
            {
                if (BoType.Equals("JOINT HOLDERS"))
                {
                    ddlSelctionMode.Items.Clear();
                    ddlSelctionMode.Items.Add("1st Account Holder");
                    ddlSelctionMode.Items.Add("2nd Account Holder");
                    ddlSelctionMode.Items.Add("Nominee1");
                    ddlSelctionMode.Items.Add("Nominee2");
                    ddlSelctionMode.Items.Add("Guardian1");
                    ddlSelctionMode.Items.Add("Guardian2");
                    ddlSelctionMode.Items.Add("POA");
                    ddlSelctionMode.Items.Add("Author");
                    ddlSelctionMode.SelectedIndex = 0;
                }

                else
                {
                    ddlSelctionMode.Items.Clear();
                    ddlSelctionMode.Items.Add("1st Account Holder");
                    ddlSelctionMode.Items.Add("Nominee1");
                    ddlSelctionMode.Items.Add("Nominee2");
                    ddlSelctionMode.Items.Add("Guardian1");
                    ddlSelctionMode.Items.Add("Guardian2");
                    ddlSelctionMode.Items.Add("POA");
                    ddlSelctionMode.Items.Add("Author");
                    ddlSelctionMode.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmSingleAccountHolder_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;

        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchCustomerInformation();
            }
        }
    }
}
