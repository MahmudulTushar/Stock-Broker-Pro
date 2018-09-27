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

namespace StockbrokerProNewArch
{
    public partial class VoucherViewer : Form
    {
        public VoucherViewer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadViewerImage();
        }

        private void LoadViewerImage()
        {
            try
            {
                ShowForm(txtVoucherNo.Text);
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


        private void ShowForm(string VoucherNo)
        {

            byte[] ImgByteArray = new byte[0];
            OpexBAL opexBal = new OpexBAL();
            DataTable dataTable = new DataTable();

            dataTable = opexBal.ViewVoucher(VoucherNo);

            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    picImgView.Visible = true;
                    ImgByteArray = (byte[])(dataTable.Rows[0][0]);
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
    }
}
