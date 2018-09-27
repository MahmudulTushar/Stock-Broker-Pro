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
using System.Drawing.Imaging;

namespace NewArch
{
    public partial class frmSingleSignatureUpload : Form
    {

        private string _custCode = "";
        private string _boID = "";

        public frmSingleSignatureUpload()
        {
            InitializeComponent();
        }

        private void btnImgBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImageBrowse.ShowDialog() != DialogResult.Cancel)
            {
                txtImgLocation.Text = ofdImageBrowse.FileName;
                btnStartUpload.Enabled = true;
                picImage.Image = Image.FromFile(txtImgLocation.Text);
            }
        }



        private void btnStartUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("To Upload Signature Customer Code Required.", "Upload Signature",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearchCustomer.Focus();
                    return;
                }

                if (ddlSelctionMode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("To Upload Signature,Signature Selection Mode Required.", "Upload Signature",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ddlSelctionMode.Focus();
                    return;
                }

                if (txtImgLocation.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Signature Image File Loation Required.", "Upload Signature",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnImgBrowse.Focus();
                    return;
                }


              
                SingleImageBO singleImageBo = new SingleImageBO();
                singleImageBo.CustCode = txtCustCode.Text;
                singleImageBo.ImageSelectionMode = ddlSelctionMode.Text;

                var byteImage=new ImageResizeBAL().GetImageByte(ofdImageBrowse.FileName);
                //----------if image file convert error then show---------
                if (byteImage== null)
                {
                    MessageBox.Show("Wrong Image File.");
                    btnImgBrowse.Focus();
                    return;
                }              
                singleImageBo.ImgByte = byteImage;
                if (singleImageBo.ImgByte != null)
                {
                    SingleImageBAL singleImageBal = new SingleImageBAL();

                    if (singleImageBal.IsExistSignature(singleImageBo) == true)
                    {
                        if (MessageBox.Show("Signature Exists. Do you wamt to Update the Signature?", "Signature Updated !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            singleImageBal.SaveSignatureToDatabase(singleImageBo);
                            MessageBox.Show("Signature Secesfully Uploaded.");
                        }
                    }

                    else
                    {
                        singleImageBal.SaveSignatureToDatabase(singleImageBo);
                        MessageBox.Show(" New Signature Successfully Uploaded.", "Photo Upload", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Image uplaod failed. Error:" + ex.Message);
            }

        }

        private void ResetInput()
        {
            picImage.Image = null;
            txtImgLocation.Text = "";
        }

        ////-----------Image resize and convert to byte-------------
        //private static ImageCodecInfo GetEncoder(ImageFormat format)
        //{
        //    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        //    foreach (ImageCodecInfo codec in codecs)
        //    {
        //        if (codec.FormatID == format.Guid)
        //        {
        //            return codec;
        //        }
        //    }
        //    return null;
        //}



        //private byte[] GetImageByte(string fileName)
        //{
        //    MemoryStream stream = new MemoryStream();
        //    try
        //    {   //-----------Image size compression -------------
        //        Bitmap bmp1 = new Bitmap(fileName);
        //        ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
        //        System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
        //        EncoderParameters myEncoderParameters = new EncoderParameters(1);
        //        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
        //        myEncoderParameters.Param[0] = myEncoderParameter;

        //        ///convert to byte formate 
        //        bmp1.Save(stream, jgpEncoder, myEncoderParameters);
        //        bmp1.Dispose();

        //        ////////////Previous Work without compression
        //        //Bitmap image = new Bitmap(fileName);
        //        //image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
        //        //image.Dispose();
        //        return stream.ToArray();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Wrong Image File." + ex.Message);
        //    }
        //    return null;
        //}


        ////--------End to image convert to byte-----------

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
                    MessageBox.Show("No customer found.");
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

        private void frmSingleSignatureUpload_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchCustomerInformation();
            }
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
    }
}
