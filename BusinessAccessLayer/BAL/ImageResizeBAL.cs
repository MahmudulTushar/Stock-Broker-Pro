using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;

namespace BusinessAccessLayer.BAL
{
   public class ImageResizeBAL
    {
        //-----------Image resize and convert to byte-------------
        public  ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }



        public byte[] GetImageByte(string fileName)
        {
            MemoryStream stream = new MemoryStream();
            try
            {   //-----------Image size compression -------------
                Bitmap bmp1 = new Bitmap(fileName);
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                ///convert to byte formate 
                bmp1.Save(stream, jgpEncoder, myEncoderParameters);
                bmp1.Dispose();

                ////////////Previous Work without compression
                //Bitmap image = new Bitmap(fileName);
                //image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                //image.Dispose();
                return stream.ToArray();
            }
            catch (Exception ex)
            {
              
                Console.WriteLine(ex);
                return null;
                //MessageBox.Show("Wrong Image File." + ex.Message);
            }
            return null;
        }


        //--------End to image convert to byte-----------


    }
}
