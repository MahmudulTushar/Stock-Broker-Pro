using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using System.Drawing.Imaging;

namespace NewArch
{
    public partial class frmBatchSignatureUpload : Form
    {
        private string[] _sArrayImageFiles = new string[10000];
        private string[] _sArrayCorrectImgFiles = new string[10000];
        private string _sTempImageFileLoc;
        private string _sImageName;
        private int imgCount;
        private bool _IsVaildImage;
        private string[] _sCustomerCode = new string[1000000];
        private int _nDuplicatedID = 0;
        private int _nUnSavedImgNo = 0;
        private int _ndtgShowPositon = 0;
        private int _nImageSaveNumber = 0;
        private string _savePattern;

        public frmBatchSignatureUpload()
        {
            InitializeComponent();
        }

        private void btnBrowseDirectory_Click(object sender, EventArgs e)
        {
            if (fbdImageUpload.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {

                txtImgDirectoryLocation.Text = fbdImageUpload.SelectedPath;
                _sArrayImageFiles = Directory.GetFiles(fbdImageUpload.SelectedPath);
                CountCorrectImgFormat(fbdImageUpload.SelectedPath);
                lblUploadProgress.Text = "";

            }

        }

        private void CountCorrectImgFormat(string imgPath)
        {

            imgCount = 0;

            for (int i = 0; i < _sArrayImageFiles.Length; i++)
            {

                if (Path.GetExtension(_sArrayImageFiles[i].ToLower()) == ".jpg" || Path.GetExtension(_sArrayImageFiles[i].ToLower()) == ".bmp" || Path.GetExtension(_sArrayImageFiles[i].ToLower()) == ".gif" || Path.GetExtension(_sArrayImageFiles[i].ToLower()) == ".jpeg" || Path.GetExtension(_sArrayImageFiles[i].ToLower()) == ".png")
                {
                    _sArrayCorrectImgFiles[imgCount++] = _sArrayImageFiles[i];

                    //CheckCorrectCustomerCode(Path.GetFileNameWithoutExtension(_sArrayImageFiles[i]), imgCount);
                    //if (_IsVaildImage == true)
                    //{
                    //    _sArrayCorrectImgFiles[imgCount++] = _sArrayImageFiles[i];
                    //}


                }
            }


            ShowImageNumber(imgCount);
        }

        private void ShowImageNumber(int imgNumber)
        {
            if (imgNumber > 0)
            {
                lblTotalImage.Text = "Total Images: " + imgNumber.ToString();
                lblUploadimage.Text = "Uploaded Images: 0";
                lblDuplicateImage.Text = "Duplicate Images: 0";
                lblErrorImg.Text = "Unsaved Images: " + _nUnSavedImgNo + "";
                btnStartUpload.Enabled = true;
                pgbUpload.Maximum = imgNumber;

            }

            else
            {
                MessageBox.Show("No 1st Account Holder Signature found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool CheckCorrectCustomerCode(string ImageName, int ImgNo)
        {

            int testCheckCode;

            if (Int32.TryParse(ImageName, out testCheckCode) == true)
            {


                _sCustomerCode[ImgNo] = ImageName;
                _IsVaildImage = true;
                return _IsVaildImage;
            }
            else
            {

                _IsVaildImage = false;
                return _IsVaildImage;
            }


        }

        private void frmBatchSignatureUpload_Load(object sender, EventArgs e)
        {
            SettingInitialValue();
            lblImageDirctoryTitle.Text = "Error Log Information : " + this.Text + " Signature";
        }

        private void SettingInitialValue()
        {
            lblTotalImage.Text = "Total Images:0 ";
            lblUploadimage.Text = "Uploaded Images: 0";
            lblDuplicateImage.Text = "Duplicate Images: 0";
            lblErrorImg.Text = "Unsaved Images: 0";


        }

        private void btnStartUpload_Click(object sender, EventArgs e)
        {
            try
            {
              //  _savePattern = "1st Account Holder";// this.Text;
                SaveImage();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void SaveImage()
        {
            SingleImageBAL BAL = new SingleImageBAL();
            pgbUpload.Value = 0;
            pgbUpload.Visible = true;
            lblUploadProgress.Visible = true;
            string extensionValue = string.Empty;
            string AccountNumber = string.Empty;

            for (int i = 0; i < imgCount; ++i)
            {
                _sTempImageFileLoc = _sArrayCorrectImgFiles[i];
                _sImageName = Path.GetFileNameWithoutExtension(_sTempImageFileLoc);

                if (_sImageName.Length > 15 &&_sImageName.Length <21)
                {
                    string BoID = _sImageName.Substring(8,8);
                    string BoExtention = _sImageName.Substring(16);
                    switch (BoExtention)
                    {
                        case "0101":
                            {
                                extensionValue = "a";
                                break;
                            }
                        case "0201":
                            {
                                extensionValue = "b";
                                break;
                            }
                        case "0401":
                            {
                                extensionValue = "n";
                                break;
                            }
                        case "0601":
                            {
                                extensionValue = "p";
                                break;
                            }
                        default: break;                   
                    }

                    AccountNumber = BAL.BOIdToCustCode(BoID);
                    if (!string.IsNullOrEmpty(AccountNumber))
                    {
                        specificLocationImageSave(i, _sTempImageFileLoc, extensionValue, AccountNumber);
                    }
                    else 
                    {
                        _nUnSavedImgNo = _nUnSavedImgNo + 1;
                        MoveInvalidImage(_sTempImageFileLoc);
                    }
                }
                else
                {
                    extensionValue = _sImageName.Substring(_sImageName.Length - 1);
                    AccountNumber = _sImageName.Substring(0, _sImageName.Length - 1);

                    int testCheckCode;
                    if (Int32.TryParse(_sImageName, out testCheckCode) == true)
                    {
                        _savePattern = "1st Account Holder";

                        byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);

                        if (_bArrayImgByte != null)
                        {
                            SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc, testCheckCode.ToString());
                        }
                    }
                    else
                    {
                        specificLocationImageSave(i, _sTempImageFileLoc, extensionValue, AccountNumber);
                    }
                }

                lblUploadProgress.Text = "Uploading " + Path.GetFileNameWithoutExtension(_sTempImageFileLoc) + "...";
                pgbUpload.Value = pgbUpload.Value + 1;
                
            }

            if (pgbUpload.Value == imgCount)
            {
                lblUploadProgress.Text = "Signature Sucessfully Upload Completed";
                btnStartUpload.Enabled = false;
                _nImageSaveNumber = 0;
                _nDuplicatedID = 0;
                MessageBox.Show("Signature Sucessfully Upload Completed", "Signature Upload",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        public void specificLocationImageSave(int i, string _sTempImageFileLoc, string extensionValue, string AccountNumber)
        {                          
                switch (extensionValue.ToLower())
                {
                    case "a":
                        {
                            _savePattern = "1st Account Holder";
                            byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);
                            if (_bArrayImgByte != null)
                            {
                                SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc, AccountNumber);
                            }
                            break;
                        }
                    case "b":
                        {
                            _savePattern = "2nd Account Holder";
                            byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);
                            if (_bArrayImgByte != null)
                            {
                                SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc, AccountNumber);
                            }

                            break;
                        }
                    case "n":
                        {
                            _savePattern = "Nominee1";
                            byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);
                            if (_bArrayImgByte != null)
                            {
                                SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc, AccountNumber);
                            }
                            break;
                        }
                    case "o":
                        {
                            _savePattern = "Nominee2";
                            byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);
                            if (_bArrayImgByte != null)
                            {
                                SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc, AccountNumber);
                            }

                            break;
                        }
                    case "g":
                        {
                            _savePattern = "Guardian1";
                            byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);
                            if (_bArrayImgByte != null)
                            {
                                SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc, AccountNumber);
                            }

                            break;
                        }
                    case "h":
                        {
                            _savePattern = "Guardian2";
                            byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);
                            if (_bArrayImgByte != null)
                            {
                                SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc, AccountNumber);
                            }

                            break;
                        }
                    case "p":
                        {
                            _savePattern = "POA";
                            byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);
                            if (_bArrayImgByte != null)
                            {
                                SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc, AccountNumber);
                            }

                            break;
                        }
                    case "u":
                        {
                            _savePattern = "Author";
                            byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);
                            if (_bArrayImgByte != null)
                            {
                                SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc, AccountNumber);
                            }

                            break;
                        }
                } 
        }






        private byte[] GetImageBytes(string fileName)
        {
            MemoryStream stream = new MemoryStream();
            try
            {   //-----------Image size compression -------------
                Bitmap bmp1 = new Bitmap(fileName);
                ImageCodecInfo jgpEncoder = new ImageResizeBAL().GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                ///convert to byte formate 
                bmp1.Save(stream, jgpEncoder, myEncoderParameters);
                bmp1.Dispose();
                return stream.ToArray();
            }
            catch (Exception ex)
            {
                _nUnSavedImgNo = _nUnSavedImgNo + 1;
                lblErrorImg.Text = "UnSaved Image: " + _nUnSavedImgNo.ToString();
                MoveInvalidImage(fileName);
                WriteErrorLogFile(fileName, ex.Message);

            }
            return null;
        }

        private void MoveInvalidImage(string imgPath)
        {
            string errDirPath = Directory.GetParent(imgPath) + "ErrorLogDictory\\";

            if (!Directory.Exists(errDirPath))
            {
                Directory.CreateDirectory(errDirPath);

            }


            try
            {
                File.Move(imgPath, errDirPath + "\\" + Path.GetFileName(imgPath));


                if (dtgImUploadDirInfo.Columns.Count == 0)
                {
                    CreateColumnDtg();

                }

                string ImgName = Path.GetFileNameWithoutExtension(imgPath);
                dtgImUploadDirInfo.Rows.Add(1);
                ShowErrorInfo(ImgName, errDirPath + "\\" + Path.GetFileName(imgPath), _ndtgShowPositon);



            }
            catch (Exception)
            {
                throw;
            }
        }

        private void WriteErrorLogFile(string ImgPath, string ErrorMessage)
        {
            string ErrorFilePath = Path.GetDirectoryName(ImgPath);
            TextWriter ErrorLogFileInfo = new StreamWriter(ErrorFilePath + "\\ErrorLog.txt", true);

            ErrorLogFileInfo.WriteLine("         ***************** Error Log Information ********************** ");
            ErrorLogFileInfo.WriteLine("Image Name: " + Path.GetFileNameWithoutExtension(ImgPath));
            ErrorLogFileInfo.WriteLine("Image Location: " + ImgPath);
            ErrorLogFileInfo.WriteLine("Error Description: " + ErrorMessage);

            ErrorLogFileInfo.Close();

        }

        private void SaveToDatabase(byte[] _bArrayImgByte, int imgSavePosition, string ImgPath, string customerCode)
        {
            //SaveImgBO imgBO = new SaveImgBO();
            SaveImgBAL imgBAL = new SaveImgBAL();

            SingleImageBO SimgBo = new SingleImageBO();
            SingleImageBAL SimgBal = new SingleImageBAL();

            //imgBO.CustomerCode = customerCode;
            //imgBO.ImageArrayByte = _bArrayImgByte;


            SimgBo.CustCode = customerCode;
            SimgBo.ImgByte = _bArrayImgByte;
            SimgBo.ImageSelectionMode = _savePattern;
            try
            {
                // imgBAL.InsertSignature(imgBO, _savePattern);
                SimgBal.SaveSignatureToDatabase(SimgBo);

                _nImageSaveNumber = _nImageSaveNumber + 1;
                lblUploadimage.Text = "Uploading Images: " + (_nImageSaveNumber).ToString();
            }
            catch (Exception ex)
            {
                _nDuplicatedID = _nDuplicatedID + 1;
                lblErrorImg.Text = "Unsaved Image: " + _nDuplicatedID.ToString();
                MoveInvalidImage(ImgPath);
                WriteErrorLogFile(ImgPath, ex.Message);

            }

        }

        private void ShowErrImg(string ErrImgPath)
        {
            string ImgPath = Path.GetDirectoryName(ErrImgPath);
            oflErrImgPath.InitialDirectory = ImgPath;
            oflErrImgPath.FileName = Path.GetFileName(ErrImgPath);
            oflErrImgPath.ShowDialog();

        }

        private void ShowErrorInfo(string ImgName, string ImgPath, int dtgPos)
        {
            dtgImUploadDirInfo.Rows[dtgPos].Cells[0].Value = "Error No:" + (dtgPos + 1).ToString();
            dtgImUploadDirInfo.Rows[dtgPos].Cells[1].Value = ImgName;
            dtgImUploadDirInfo.Rows[dtgPos].Cells[2].Value = ImgPath;
            _ndtgShowPositon = _ndtgShowPositon + 1;


        }

        private void CreateColumnDtg()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle_Data = new System.Windows.Forms.DataGridViewCellStyle();

            DataGridViewTextBoxColumn colConcept1 = new DataGridViewTextBoxColumn();
            DataGridViewCell cell5 = new DataGridViewTextBoxCell();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();



            DataGridViewTextBoxColumn colConcept2 = new DataGridViewTextBoxColumn();
            DataGridViewCell cell6 = new DataGridViewTextBoxCell();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            DataGridViewTextBoxColumn colConcept3 = new DataGridViewTextBoxColumn();
            DataGridViewCell cell7 = new DataGridViewTextBoxCell();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();



            /////////////////////////// Coloum CID///////////////////////
            colConcept1.CellTemplate = cell5;
            colConcept1.Name = "Error No";
            colConcept1.HeaderText = "Error No";
            colConcept1.ReadOnly = true;
            this.dtgImUploadDirInfo.Columns.Add(colConcept1);
            ///////////////// End of CID //////////////////////////////


            ///////////////////////////// Ctrate Issuses ImgLocation ///////////////
            colConcept2.CellTemplate = cell6;
            colConcept2.Name = "Image Name";
            colConcept2.HeaderText = "Image Title";
            colConcept2.ReadOnly = true;
            this.dtgImUploadDirInfo.Columns.Add(colConcept2);
            ////////////////////////*********** END*****************////////////////////////////////////


            ///////////////////////////// Ctrate Description ///////////////
            colConcept3.CellTemplate = cell7;
            colConcept3.Name = "Location";
            colConcept3.HeaderText = "Image Location";
            colConcept3.ReadOnly = true;
            this.dtgImUploadDirInfo.Columns.Add(colConcept3);
            ////////////////////////*********** END*****************////////////////////////////////////





        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgImUploadDirInfo.Rows.Count > 0)
                    ShowErrImg(dtgImUploadDirInfo.SelectedRows[0].Cells[2].Value.ToString());

                else
                {
                    MessageBox.Show("No Error Log Information Exists.", "", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }



    }
}
