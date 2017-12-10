using QRCoder;
using System;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using static QRCoder.QRCodeGenerator;

namespace Srx.Util
{
    /// <summary>
    /// 二维码帮助类
    /// </summary>
    public class QRCodeHelper
    {
        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="QRString">二维码字符串</param>
        /// <param name="QRCodeEncodeMode">二维码编码(Byte、AlphaNumeric、Numeric)</param>
        /// <param name="QRCodeScale">二维码尺寸(Version为0时，1：26x26，每加1宽和高各加25</param>
        /// <param name="QRCodeVersion">二维码密集度0-40</param>
        /// <param name="QRCodeErrorCorrect">二维码纠错能力(L：7% M：15% Q：25% H：30%)</param>
        /// <param name="filePath">保存路径</param>
        /// <param name="hasLogo">是否有logo(logo尺寸50x50，QRCodeScale>=5，QRCodeErrorCorrect为H级)</param>
        /// <param name="logoFilePath">logo路径</param>
        /// <returns></returns>
        public static bool CreateQRCode(string QRString, string QRCodeEncodeMode, short QRCodeScale, int QRCodeVersion, string QRCodeErrorCorrect, string filePath, bool hasLogo, string logoFilePath)
        {
            bool result = true;

            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            ECCLevel level = ECCLevel.H;
            
            switch (QRCodeErrorCorrect)
            {
                case "L":
                    level = ECCLevel.L;
                    break;
                case "M":
                    level = ECCLevel.M;
                    break;
                case "Q":
                    level = ECCLevel.Q;
                    break;
                case "H":
                    level = ECCLevel.H;
                    break;
                default:
                    level = ECCLevel.H;
                    break;
            }

            try
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRString, level))
                    {
                        using (QRCode qrCode = new QRCode(qrCodeData))
                        {
                            if (hasLogo)
                            {
                                Bitmap curBitmap = new Bitmap(logoFilePath);
                                Bitmap curBitmap1 = new Bitmap(curBitmap, 50, 50);

                                Bitmap image = qrCode.GetGraphic(20, System.DrawingCore.Color.Black, System.DrawingCore.Color.White, curBitmap1);
                                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                                image.Save(fs, ImageFormat.Jpeg);
                                fs.Close();

                                curBitmap.Dispose();
                                curBitmap1.Dispose();
                                image.Dispose();
                            }
                            else
                            {
                                Bitmap image = qrCode.GetGraphic(20, System.DrawingCore.Color.Black, System.DrawingCore.Color.White, true);
                                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                                image.Save(fs, ImageFormat.Jpeg);
                                fs.Close();

                                image.Dispose();
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
