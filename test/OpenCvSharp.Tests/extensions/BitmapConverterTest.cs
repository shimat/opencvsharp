using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using OpenCvSharp.Extensions;
using Xunit;

namespace OpenCvSharp.Tests.Extensions
{
    public class BitmapConverterTest : TestBase
    {
        [Fact]
        public void BitmapSource8Bit()
        {
            Scalar blueColor8 = new Scalar(200, 0, 0);
            Scalar greenColor8 = new Scalar(0, 200, 0);
            Scalar redColor8 = new Scalar(0, 0, 200);

            using (var mat = new Mat(1, 1, MatType.CV_8UC3, blueColor8))
            {
                var bitmap = BitmapConverter.ToBitmap(mat);
                AssertPixelValue8bpp(blueColor8, bitmap);
            }
            using (var mat = new Mat(1, 1, MatType.CV_8UC3, greenColor8))
            {
                var bitmap = BitmapConverter.ToBitmap(mat);
                AssertPixelValue8bpp(greenColor8, bitmap);
            }
            using (var mat = new Mat(1, 1, MatType.CV_8UC3, redColor8))
            {
                var bitmap = BitmapConverter.ToBitmap(mat);
                AssertPixelValue8bpp(redColor8, bitmap);
            }
        }

        private void AssertPixelValue8bpp(Scalar expectedValue, Bitmap bitmap)
        {
            if (bitmap.Width != 1 || bitmap.Height != 1)
                throw new Exception("1x1 image only");

            var pixels = new byte[3];
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, 1, 1), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            Marshal.Copy(bitmapData.Scan0, pixels, 0, 3);
            bitmap.UnlockBits(bitmapData);

            Console.WriteLine("Expected: ({0},{1},{2})", expectedValue.Val0, expectedValue.Val1, expectedValue.Val2);
            Console.WriteLine("Actual: ({0},{1},{2})", pixels[0], pixels[1], pixels[2]);
            Assert.Equal(expectedValue.Val0, Convert.ToDouble(pixels[0]), 9);
            Assert.Equal(expectedValue.Val1, Convert.ToDouble(pixels[1]), 9);
            Assert.Equal(expectedValue.Val2, Convert.ToDouble(pixels[2]), 9);
        }
    }
}
