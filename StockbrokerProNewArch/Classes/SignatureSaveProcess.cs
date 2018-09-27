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
    public class SignatureSaveProcess
    {
        private bool _isCorrcetCustCode;
        private string _AccountHolderCode;
        private string _imgLocation;
        private string _imgSavePattern;

        public string _ImgUploadResult;
        public string _CustomerCode;
        public bool _IsImgSave;
        public Int64 _length;

        public void CommonImgFunction(string ImagePathName, string ImgSavePattern)
        {
            _imgSavePattern = ImgSavePattern;

            CheeckCorrctCustCode(ImagePathName);

            if (_isCorrcetCustCode == true)
            {
                SaveImage(ImagePathName);
            }

            if (_isCorrcetCustCode == false)
            {

                _CustomerCode = Path.GetFileNameWithoutExtension(ImagePathName);
                _ImgUploadResult = "Invaild Customer Code.";
                _IsImgSave = false;



            }

        }


        private bool CheeckCorrctCustCode(string ImgPath)
        {

            string CustomerCode = Path.GetFileNameWithoutExtension(ImgPath);
            int AccCode;

            if (Int32.TryParse(CustomerCode, out AccCode) == true)
            {
                _AccountHolderCode = CustomerCode;

                _CustomerCode = CustomerCode;

                _isCorrcetCustCode = true;
                return _isCorrcetCustCode;
            }

            else
            {
                _isCorrcetCustCode = false;
                return _isCorrcetCustCode;

            }

        }

        private void SaveImage(string ImgPath)
        {
            byte[] _bArrayImgByte = GetImageBytes(ImgPath);


            if (_bArrayImgByte != null)
            {
                _imgLocation = ImgPath;
                SaveToDatabase(_bArrayImgByte, _AccountHolderCode);
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
                _length = stream.Length;
                return stream.ToArray();

            }
            catch (Exception)
            {

                _ImgUploadResult = "Image Corruputed.";
                _IsImgSave = false;


            }
            return null;
        }




        private void SaveToDatabase(byte[] _bArrayImgByte, string CustCode)
        {

            SaveImgBO saveImgBO = new SaveImgBO();
            SaveImgBAL saveImgBl = new SaveImgBAL();


            SingleImageBO SimgBo = new SingleImageBO();
            SingleImageBAL SimgBal = new SingleImageBAL();

            saveImgBO.CustomerCode = CustCode;
            saveImgBO.ImageArrayByte = _bArrayImgByte;
            _length = _bArrayImgByte.Length;

            SimgBo.CustCode = CustCode;
            SimgBo.ImgByte = _bArrayImgByte;
            SimgBo.ImageSelectionMode = _imgSavePattern;

            try
            {
                // saveImgBl.InsertSignature(saveImgBO, _imgSavePattern);
                SimgBal.SaveToDatabase(SimgBo);
                _ImgUploadResult = "Secessfully Saved";
                _IsImgSave = true;


            }
            catch (Exception ex)
            {
                _IsImgSave = false;
                _ImgUploadResult = "Unsaved";
                string ErrorMessage = ex.Message;


            }

        }



    }
}
