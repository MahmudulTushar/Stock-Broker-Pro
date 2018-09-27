using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using System.Data.SqlClient;
using StockbrokerProNewArch;

namespace NewArch
{
    public partial class frmImgShow : Form
    {
        public frmImgShow()
        {
            InitializeComponent();
        }

        private void frmImgShow_Load(object sender, EventArgs e)
        {
            ShowInitial();

        }

        private void ShowInitial()
        {
            ddlSearchPattern.Text = @"1st Account Holder";
            ddlSearchBy.Text = @"Customer Code";

            if (ddlSearchBy.Text == @"Customer Code")
            {
                lblSearchCode.Text = @"Customer Code :";
                txtSearchCode.MaxLength = 9;
                txtSearchCode.Focus();
            }

            if (ddlSearchBy.Text == @"BO ID")
            {
                lblSearchCode.Text = @"Customer BO ID :";
                txtSearchCode.MaxLength = 16;
                txtSearchCode.Focus();
            }

            lblCustomerCod.Text = @"Code: ..............";
            lblBOID.Text = @"BO ID: ..............";
            lblSearchCategory.Text = @"Search: .............";
            lblSearchPersonName.Text = @"Name : ..............";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadViewerImage();
        }

        private void LoadViewerImage()
        {
            try
            {
                ShowImg(ddlSearchPattern.Text, ddlSearchBy.Text, txtSearchCode.Text);
            }
            catch
            {
                NonImgDisplay();
            }
        }

        private void ShowImg(string SearchPattern, string SearchBy, string SearchCode)
        {

            if (SearchCode != String.Empty)
            {
                string SearchTable = "";
                string SearchInfoTable = "";

                if (SearchPattern == "1st Account Holder")
                {
                    SearchTable = "SBP_Cust_Image";
                    SearchInfoTable = "SBP_Cust_Personal_Info";
                }
                else if (SearchPattern == "2nd Account Holder")
                {
                    SearchTable = "SBP_Joint_holder_Image";
                    SearchInfoTable = "SBP_Joint_holder";
                }
                else if (SearchPattern == "1st Nominee")
                {
                    SearchTable = "SBP_Nominee1_Image";
                    SearchInfoTable = "SBP_Nominee1";
                }

                else if (SearchPattern == "2nd Nominee")
                {
                    SearchTable = "SBP_Nominee2_Image";
                    SearchInfoTable = "SBP_Nominee2";
                }

                else if (SearchPattern == "1st Gurdian")
                {
                    SearchTable = "SBP_Guardian1_Image";
                    SearchInfoTable = "SBP_Guardian1";
                }

                else if (SearchPattern == "2nd Gurdian")
                {
                    SearchTable = "SBP_Guardian2_Image";
                    SearchInfoTable = "SBP_Guardian2";
                }

                else if (SearchPattern == "Power OF Attorney")
                {
                    SearchTable = "SBP_POA_Image";
                    SearchInfoTable = "SBP_POA";
                }

                else if (SearchPattern == "Authorzied Person")
                {

                    SearchTable = "SBP_Author_Image";
                    SearchInfoTable = "SBP_Intro_Author";

                }

                SearchImg(SearchTable, SearchBy, SearchCode, SearchInfoTable);
            }

            else
            {
                MessageBox.Show(@"Please Insert Required Code???");
                txtSearchCode.Focus();
            }


        }

        private void SearchImg(string SearchTable, string searchBy, string SearchCode, string SearchInfoTable)
        {
            byte[] ImgByteArray = new byte[0];
            LoadSearchInfo searchinfo = new LoadSearchInfo();
            DataTable dtCustImg = new DataTable();

            dtCustImg = searchinfo.LoadCustomerImg(SearchTable, searchBy, SearchCode, SearchInfoTable, this.Text);

            try
            {
                if (dtCustImg.Rows.Count > 0)
                {
                    picImgView.Visible = true;
                    ImgByteArray = (byte[])(dtCustImg.Rows[0][0]);
                    MemoryStream stream1 = new MemoryStream(ImgByteArray);
                    picImgView.Image = Image.FromStream(stream1);
                    lblImgViewer.Visible = false;

                    lblCustomerCod.Text = @"Customer Code: " + dtCustImg.Rows[0][1].ToString();
                    lblBOID.Text = @"BO ID: " + dtCustImg.Rows[0][2].ToString();
                    lblSearchCategory.Text = @"Search By : " + ddlSearchPattern.Text;

                    lblSearchPersonName.Text = @"Name: " + dtCustImg.Rows[0][3].ToString();
                }

                else
                {
                    NonImgDisplay();
                }
            }

            catch (Exception ex)
            {
                NonImgDisplay();

            }

        }

        private void NonImgDisplay()
        {

            lblImgViewer.Visible = true;
            lblImgViewer.Text = @"No Image Found.";
            picImgView.Visible = false;

            lblCustomerCod.Text = @"Code: ..............";
            lblBOID.Text = @"BO ID: ..............";
            lblSearchCategory.Text = @"Search: .............";
            lblSearchPersonName.Text = @"Name : ..............";

        }

        private void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchBy.Text == @"Customer Code")
            {
                lblSearchCode.Text = @"Customer Code :";
                txtSearchCode.MaxLength = 9;
                txtSearchCode.Focus();
            }

            if (ddlSearchBy.Text == @"Customer BO ID")
            {
                lblSearchCode.Text = @"Customer BO ID :";
                txtSearchCode.MaxLength = 16;
                txtSearchCode.Focus();
            }
        }

        private void ddlSearchPattern_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                LoadViewerImage();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (picImgView.Image != null)
            {
                ImageViewer imageViewer = new ImageViewer(picImgView.Image);
                imageViewer.ShowDialog();
            }
        }
    }
}
