using System.Drawing;
using System.IO;

namespace CodeUtils
{
    public static class Images
    {

        public static byte[] ConvertImageToByteArray(Image imageToConvert,
            System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] ret;

            using (var ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                ret = ms.ToArray();
            }

            return ret;
        }

        public static Image ConvertByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }

    }
}