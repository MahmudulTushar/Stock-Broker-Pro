using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;

namespace NewArch.Classes
{
    public class BatchImgSaveProcess
    {
        private string[] _sArrayImageFiles = new string[10000];
        private string[] _sArrayCorrectImgFiles = new string[10000];
        private string _sTempImageFileLoc;
        private string _sImageName;
        private int imgCount = 0;
        private string[] _sImageReference = new string[1000000];
        private string[] _sCustomerCode = new string[1000000];
        private int _nDuplicatedID = 0;
        private int _nUnSavedImgNo = 0;
        private int _nImageSaveNumber = 0;
        private string _SavePattern;
        public bool _IsImgSave;

        public void CommonImgFunction(string ImgPath, string SavePattern)
        {
            _SavePattern = SavePattern;
            SaveImage();

        }

        private void SaveImage()
        {
            //pgbUpload.Visible = true;
            //lblUploadProgress.Visible = true;
            _IsImgSave = true;
            for (int i = 0; i < imgCount; ++i)
            {
                _sTempImageFileLoc = _sArrayCorrectImgFiles[i];
                byte[] _bArrayImgByte = GetImageBytes(_sTempImageFileLoc);

                if (_bArrayImgByte != null)
                {
                    _sImageName = Path.GetFileNameWithoutExtension(_sTempImageFileLoc);
                    SaveToDatabase(_bArrayImgByte, i, _sTempImageFileLoc);

                }

                //lblUploadProgress.Text = "Uploading " + Path.GetFileNameWithoutExtension(_sTempImageFileLoc) + "...";
                //pgbUpload.Value = pgbUpload.Value + 1;

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
                _nUnSavedImgNo = _nUnSavedImgNo + 1;
                //lblErrorImg.Text = "UnSaved Image: " + _nUnSavedImgNo.ToString();
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


                /* if (dtgImUploadDirInfo.Columns.Count == 0)
                 {
                     CreateColumnDtg();

                 }

                 string ImgName = Path.GetFileNameWithoutExtension(imgPath);
                 dtgImUploadDirInfo.Rows.Add(1);
                 ShowErrorInfo(ImgName, errDirPath + "\\" + Path.GetFileName(imgPath), _ndtgShowPositon);*/



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

        private void SaveToDatabase(byte[] _bArrayImgByte, int imgSavePosition, string ImgPath)
        {
            SaveImgBO imgBO = new SaveImgBO();
            SaveImgBAL imgBAL = new SaveImgBAL();

            SingleImageBO SimgBo = new SingleImageBO();
            SingleImageBAL SimgBal = new SingleImageBAL();

            imgBO.CustomerCode = _sCustomerCode[imgSavePosition];
            imgBO.ImageArrayByte = _bArrayImgByte;


            SimgBo.CustCode = _sCustomerCode[imgSavePosition];
            SimgBo.ImgByte = _bArrayImgByte;
            SimgBo.ImageSelectionMode = _SavePattern;
            try
            {
                //imgBAL.InsertCustImg(imgBO,_SavePattern);
                SimgBal.SaveToDatabase(SimgBo);
                _nImageSaveNumber = _nImageSaveNumber + 1;
                // lblUploadimage.Text = "Uploading Images: " + (_nImageSaveNumber).ToString();
            }
            catch (Exception ex)
            {
                _nDuplicatedID = _nDuplicatedID + 1;
                //lblDuplicateImage.Text = "Duplicated Image: " + _nDuplicatedID.ToString();
                MoveInvalidImage(ImgPath);
                WriteErrorLogFile(ImgPath, ex.Message);

            }




        }

    }
}
