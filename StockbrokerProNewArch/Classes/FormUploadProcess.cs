using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BusinessAccessLayer.BO;
using BusinessAccessLayer.BAL;
using System.Drawing;

namespace NewArch.Properties.Classes
{
   public  class FormUploadProcess
    {
        public string _ImgUploadResult;
        public bool _IsImgSave;
        public Int64 _length;
        public bool _IsUpdateImg;

        public void CommonImgFunction(string CustCode, string ImgPurpos,string ImgPath)
        {
        }
        private void SaveImage(string ImgPath)
        {
        }
   }
}
