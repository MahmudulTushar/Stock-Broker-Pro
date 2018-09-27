using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class LogoUpload : Form
    {
        public LogoUpload()
        {
            InitializeComponent();
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            if (ofdLogo.ShowDialog() != DialogResult.Cancel)
            {
                txtLogoPath.Text = ofdLogo.FileName;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtLogoPath.Text.Trim() == "")
            {
                MessageBox.Show("Choose the image file.");
                return;
            }
            try
            {
                UpdateLogoImage();
                this.Hide();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Logo image upload unsuccessful.Because of the error:" + exc.Message);
            }
       }

        private void UpdateLogoImage()
        {
            BrokerInfoBO brokerInfoBO = new BrokerInfoBO();
            if (txtLogoPath.Text.Trim() != "")
                brokerInfoBO.LogoImage = GetImageBytes(txtLogoPath.Text);
            BrokerInfoBAL brokerInfoBAL = new BrokerInfoBAL();
            brokerInfoBAL.UpdateLogoImage(brokerInfoBO);
            MessageBox.Show(" Logo Image has successfully updated.");
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
      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
