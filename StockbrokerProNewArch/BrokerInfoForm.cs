using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BusinessAccessLayer.BAL;
using BusinessAccessLayer.BO;

namespace StockbrokerProNewArch
{
    public partial class BrokerInfoForm : Form
    {
        public BrokerInfoForm()
        {
            InitializeComponent();
        }
        private string oldName = "";
        private void BrokerInfoForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            BrokerInfoBAL brokerInfoBAL = new BrokerInfoBAL();
            byte[] LogoImgByte= new byte[0];
            byte[] DirSignImgByte = new byte[0];
            byte[] DefaultSignImgByte = new byte[0];
            DataTable dataTable = new DataTable();
            dataTable = brokerInfoBAL.GetBrokerInfo();
            oldName = dataTable.Rows[0]["Name"].ToString();
            txtName.Text = dataTable.Rows[0]["Name"].ToString();
            txtBrokerBOId.Text = dataTable.Rows[0]["BO_ID"].ToString();
            txtTradeID.Text = dataTable.Rows[0]["Trade_ID"].ToString();
            ddlExchangeName.SelectedItem = dataTable.Rows[0]["Exchange_Name"].ToString();
            txtCDBLParticipantID.Text = dataTable.Rows[0]["CDBL_Participant_ID"].ToString();
            dtOpenDate.Value = Convert.ToDateTime(dataTable.Rows[0]["Open_Date"]);
            LogoImgByte = (byte[])(dataTable.Rows[0]["Logo_Image"]);
            if (LogoImgByte.Length> 0)
            {
                MemoryStream LogoStream = new MemoryStream(LogoImgByte);
                picLogoImage.Image = Image.FromStream(LogoStream);
            }
            else
            {
                picLogoImage.Image = null;
            }
            DirSignImgByte = (byte[])(dataTable.Rows[0]["Directors_Signature"]);
            if (DirSignImgByte.Length > 0)
            {
                
                MemoryStream DirSignStream = new MemoryStream(DirSignImgByte);
                picDirectorSign.Image = Image.FromStream(DirSignStream);
            }
            else
            {
                picDirectorSign.Image = null;
            }
            DefaultSignImgByte = (byte[])(dataTable.Rows[0]["Default_Signature"]);
            if (DefaultSignImgByte.Length > 0)
            {
                MemoryStream DefaultSignStream = new MemoryStream(DefaultSignImgByte);
                picDefaultSign.Image = Image.FromStream(DefaultSignStream);
            }
            else
            {
                picDefaultSign.Image = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                BrokerInfoBO brokerInfoBO = new BrokerInfoBO();
                BrokerInfoBAL brokerInfoBAL = new BrokerInfoBAL();
                brokerInfoBO.Name = txtName.Text;
                brokerInfoBO.BOId = txtBrokerBOId.Text;
                brokerInfoBO.TradeId = txtTradeID.Text;
                brokerInfoBO.ExchangeName= ddlExchangeName.SelectedItem.ToString();
                brokerInfoBO.CdblParticipantId = txtCDBLParticipantID.Text;
                brokerInfoBO.OpenDate = dtOpenDate.Value;
                brokerInfoBAL.UpdateBrokerInfo(brokerInfoBO, oldName);
                MessageBox.Show(oldName + " Broker Information has successfully updated.");
                LoadData();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Broker Information update unsuccessful.Because of the error:" + exc.Message);
            }
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

        private void btnLogoUpload_Click(object sender, EventArgs e)
        {
            LogoUpload logoUpload = new LogoUpload();
            logoUpload.ShowDialog();
            LoadData();
        }

        private void btnUploadDirSign_Click(object sender, EventArgs e)
        {
            DirectorSignupload directorSignupload = new DirectorSignupload();
            directorSignupload.ShowDialog();
            LoadData();
        }

        private void btnDefaultSign_Click(object sender, EventArgs e)
        {
            DefaultSignUpload uploadDefaultSign = new DefaultSignUpload();
            uploadDefaultSign.ShowDialog();
            LoadData();
        }

      
    }
}
