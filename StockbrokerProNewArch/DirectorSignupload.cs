using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class DirectorSignupload : Form
    {
        public DirectorSignupload()
        {
            InitializeComponent();
        }
        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            if (ofdDirectorSign.ShowDialog() != DialogResult.Cancel)
            {
                txtDirectorSignPath.Text = ofdDirectorSign.FileName;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtDirectorSignPath.Text.Trim() == "")
            {
                MessageBox.Show("Choose the image file.");
                return;
            }
            try
            {
                UpdateDirSign();
                this.Hide();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Director Sign upload unsuccessful.Because of the error:" + exc.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateDirSign()
        {
            BrokerInfoBO brokerInfoBO = new BrokerInfoBO();
            if (txtDirectorSignPath.Text.Trim() != "")
                brokerInfoBO.DirSignImage = GetImageBytes(txtDirectorSignPath.Text);
            BrokerInfoBAL brokerInfoBAL = new BrokerInfoBAL();
            brokerInfoBAL.UpdateDirSignature(brokerInfoBO);
            MessageBox.Show(" Director signature has successfully updated.");
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
    }
}
