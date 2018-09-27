using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.IO;
using StockbrokerProNewArch;


namespace NewArch
{
    public partial class frmFormViewer : Form
    {
        private string _custCode = "";
        private string _boID = "";
        public frmFormViewer()
        {
            InitializeComponent();
        }

        private void LoadViewerImage()
        {
            try
            {
                ShowForm(txtCustCode.Text, ddlImgpurpose.Text);
            }
            catch
            {
                NonImgDisplay();
            }
        }
        private void NonImgDisplay()
        {
            lblImgViewer.Visible = true;
            lblImgViewer.Text = "No Image Found.";
            picImgView.Visible = false;
        }


        private void ShowForm(string Cust_code, string imgPurpose)
        {

            byte[] ImgByteArray = new byte[0];
            SearchForm searchinfo = new SearchForm();
            DataTable dtCustImg = new DataTable();

            dtCustImg = searchinfo.dtLoadForm(Cust_code, imgPurpose);

            try
            {
                if (dtCustImg.Rows.Count > 0)
                {
                    picImgView.Visible = true;
                    ImgByteArray = (byte[])(dtCustImg.Rows[0][0]);
                    MemoryStream stream1 = new MemoryStream(ImgByteArray);
                    picImgView.Image = Image.FromStream(stream1);
                    lblImgViewer.Visible = false;
                }
                else
                {
                    NonImgDisplay();
                }
            }

            catch
            {
                NonImgDisplay();

            }
        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            SearchCustomerInformation();
        }

        private void SearchCustomerInformation()
        {
            if (txtSearchCustomer.Text.Trim() != "")
            {
                ShowSearchCustInfo();
                if (txtCustCode.Text.Trim() != "")
                {
                    LoadPurpose();
                }
                else
                {
                    ddlImgpurpose.DataSource = null;
                }
            }

        }

        private void LoadPurpose()
        {
            CommonBAL commBal = new CommonBAL();
            DataTable dtLoadImgPur = commBal.LoadImagePurpose_ImgExt(_custCode);
            if (dtLoadImgPur.Rows.Count > 0)
            {
                ddlImgpurpose.DataSource = dtLoadImgPur;
                ddlImgpurpose.DisplayMember = "Purpose";
            }

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
                    ClearAll();
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
                    ClearAll();
                }
            }
        }

        private void ClearAll()
        {
            txtCustCode.Text = "";
            txtAccountHolderName.Text = "";
            txtAccountHolderBOId.Text = "";
        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                SearchCustomerInformation();
            }
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            LoadViewerImage();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFormViewer_Load(object sender, EventArgs e)
        {
            ddlSearchCustomer.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (picImgView.Image != null)
            {
                ImageViewer imageViewer = new ImageViewer(picImgView.Image);
                imageViewer.ShowDialog();
            }
        }

    }
}
