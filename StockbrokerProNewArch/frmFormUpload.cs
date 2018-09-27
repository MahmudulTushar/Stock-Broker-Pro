using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;

namespace NewArch
{
    public partial class frmFormUpload : Form
    {
        private string _custCode ="";
        private string _boID = "";

        public frmFormUpload()
        {
            InitializeComponent();
        }

        private void frmFormUpload_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
        }

        private void btnFormBrowse_Click(object sender, EventArgs e)
        {
             if(ofdImgLocation.ShowDialog()!=DialogResult.Cancel)
             {
               txtImgLocation.Text=ofdImgLocation.FileName;
               btnFormUpload.Enabled = true;
             }
        }
        private void btnFormUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCustCode.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("To Upload Form,Customer Code Required.", "Form Upload", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtSearchCustomer.Focus();
                    return;
                }

                if(txtImgPurpose.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("To Upload Form,Form Purpose Required.", "Form Upload", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    txtImgPurpose.Focus();
                    return;
                }

                if(txtImgLocation.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("To Upload Form,Form File Required.", "Form Upload", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                    btnFormBrowse.Focus();
                    return;
                }

                SaveForm(txtCustCode.Text, txtImgPurpose.Text, txtImgLocation.Text);
                MessageBox.Show("Form Image Secessfully Uploaded.", "Form Upload",MessageBoxButtons.OK,MessageBoxIcon.Information);

               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Form Image can not Upload." + ex.Message, "Upload Faild!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveForm(string Cust_Code, string ImgPurpose, string ImgPath)
        {
            var byteImage = new ImageResizeBAL().GetImageByte(ImgPath);
            //----------if image file convert error then show---------
            if (byteImage == null)
            {
                MessageBox.Show("Wrong Image File.");
                btnFormBrowse.Focus();
                return;
            }

            byte[] _bArrayImgByte = byteImage;
            if (_bArrayImgByte != null)
            {
                SingleImageBAL singleImageBal=new SingleImageBAL();
                singleImageBal.SaveOtherImageToDatabase(_bArrayImgByte, Cust_Code, ImgPurpose);
            }

        }

        //private byte[] GetImageBytes(string fileName)
        //{
        //    MemoryStream stream = new MemoryStream();
        //    try
        //    {
        //        Bitmap image = new Bitmap(fileName);
        //        image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
        //        image.Dispose();
        //        return stream.ToArray();
        //    }
        //    catch (Exception ex)
        //    {
        //         MessageBox.Show("Upload Result: Image Corruputed. Error: "+ex.Message);
        //    }
        //    return null;
        //}

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchCustomerInformation();
            }
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
                }
                else
                {
                    MessageBox.Show("No customer found.");
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            SearchCustomerInformation();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
