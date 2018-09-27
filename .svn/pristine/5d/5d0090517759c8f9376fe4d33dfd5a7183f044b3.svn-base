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
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class DefaultSignUpload : Form
    {
        public DefaultSignUpload()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if(txtDefaultSignPath.Text.Trim()=="")
            {
                MessageBox.Show("Choose the image file.");
                return;
            }
            try
            {
                UpdateDefaultSign();
                this.Hide();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Default Sign upload unsuccessful.Because of the error:" + exc.Message);
            }
        }

        private void UpdateDefaultSign()
        {
            BrokerInfoBO brokerInfoBO = new BrokerInfoBO();
            if (txtDefaultSignPath.Text.Trim() != "")
                brokerInfoBO.DefaultSignImage = GetImageBytes(txtDefaultSignPath.Text);
            BrokerInfoBAL brokerInfoBAL = new BrokerInfoBAL();
            brokerInfoBAL.UpdateDefaultSignature(brokerInfoBO);
            MessageBox.Show(" Default signature has successfully updated.");
           ;
        }
        private byte[] GetImageBytes(string fileName)
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                Bitmap image = new Bitmap(fileName);
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                image.Dispose();
                return stream.ToArray();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong Image File." + ex.Message);
            }
            return null;
        }
      

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            if (ofdDefaultSign.ShowDialog() != DialogResult.Cancel)
            {
                txtDefaultSignPath.Text = ofdDefaultSign.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
