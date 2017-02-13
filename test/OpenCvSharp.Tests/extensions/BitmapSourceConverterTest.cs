#if net46
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Core
{
    [TestFixture]
    public class BitmapSourceConverterTest : TestBase
    {
        [Test]
        public void BitmapSource8Bit()
        {
            Scalar blueColor8 = new Scalar(200, 0, 0);
            Scalar greenColor8 = new Scalar(0, 200, 0);
            Scalar redColor8 = new Scalar(0, 0, 200);

            using (var mat = new Mat(1, 1, MatType.CV_8UC3, blueColor8))
            {
                var bs = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(mat); // PixelFormats.Bgr24
                AssertPixelValue<byte>(blueColor8, bs);
            }
            using (var mat = new Mat(1, 1, MatType.CV_8UC3, greenColor8))
            {
                var bs = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(mat);
                AssertPixelValue<byte>(greenColor8, bs);
            }
            using (var mat = new Mat(1, 1, MatType.CV_8UC3, redColor8))
            {
                var bs = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(mat);
                AssertPixelValue<byte>(redColor8, bs);
            }
        }

        [Test]
        public void BitmapSource16Bit()
        {
            Scalar blueColor16 = new Scalar(32767, 0, 0);
            Scalar greenColor16 = new Scalar(0, 32767, 0);
            Scalar redColor16 = new Scalar(0, 0, 32767);

            using (var mat = new Mat(1, 1, MatType.CV_16UC3, blueColor16))
            {
                var bs = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(mat); // PixelFormats.Rgb48
                AssertPixelValue<ushort>(redColor16, bs); // B is swapped for R
            }
            using (var mat = new Mat(1, 1, MatType.CV_16UC3, greenColor16))
            {
                var bs = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(mat);
                AssertPixelValue<ushort>(greenColor16, bs);
            }
            using (var mat = new Mat(1, 1, MatType.CV_16UC3, redColor16))
            {
                var bs = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(mat);
                AssertPixelValue<ushort>(blueColor16, bs); // R is swapped for B
            }
        }

        /// <summary>
        /// https://github.com/shimat/opencvsharp/issues/304
        /// </summary>
        [Test]
        [Explicit]
        [Apartment(ApartmentState.STA)]
        public void BitmapSource8BitSample()
        {
            const int size = 250;
            Scalar blueColor8 = new Scalar(128, 0, 0);
            Scalar greenColor8 = new Scalar(0, 128, 0);
            Scalar redColor8 = new Scalar(0, 0, 128);
            Scalar whiteColor8 = new Scalar(255, 255, 255);

            using (var mat = new Mat(size, size, MatType.CV_8UC3, new Scalar(128, 128, 128)))
            {
                mat.Rectangle(new OpenCvSharp.Rect(15, 10, 100, 100), blueColor8, -1);
                mat.PutText("B", new OpenCvSharp.Point(50, 70), HersheyFonts.HersheyComplex, 1, whiteColor8);

                mat.Rectangle(new OpenCvSharp.Rect(130, 10, 100, 100), greenColor8, -1);
                mat.PutText("G", new OpenCvSharp.Point(165, 70), HersheyFonts.HersheyComplex, 1, whiteColor8);

                mat.Rectangle(new OpenCvSharp.Rect(75, 130, 100, 100), redColor8, -1);
                mat.PutText("R", new OpenCvSharp.Point(110, 190), HersheyFonts.HersheyComplex, 1, whiteColor8);

                var bs = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(mat);
                Show(bs, nameof(BitmapSource8BitSample));
            }
        }

        /// <summary>
        /// https://github.com/shimat/opencvsharp/issues/304
        /// </summary>
        [Test]
        [Explicit]
        [Apartment(ApartmentState.STA)]
        public void BitmapSource16BitSample()
        {
            const int size = 250;
            Scalar blueColor16 = new Scalar(32767, 0, 0);
            Scalar greenColor16 = new Scalar(0, 32767, 0);
            Scalar redColor16 = new Scalar(0, 0, 32767);
            Scalar whiteColor16 = new Scalar(65535, 65535, 65535);

            using (var mat = new Mat(size, size, MatType.CV_16UC3, new Scalar(32767, 32767, 32767)))
            {
                mat.Rectangle(new OpenCvSharp.Rect(15, 10, 100, 100), blueColor16, -1);
                mat.PutText("B", new OpenCvSharp.Point(50, 70), HersheyFonts.HersheyComplex, 1, whiteColor16);

                mat.Rectangle(new OpenCvSharp.Rect(130, 10, 100, 100), greenColor16, -1);
                mat.PutText("G", new OpenCvSharp.Point(165, 70), HersheyFonts.HersheyComplex, 1, whiteColor16);

                mat.Rectangle(new OpenCvSharp.Rect(75, 130, 100, 100), redColor16, -1);
                mat.PutText("R", new OpenCvSharp.Point(110, 190), HersheyFonts.HersheyComplex, 1, whiteColor16);

                var bs = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(mat);
                Show(bs, nameof(BitmapSource16BitSample));
            }
        }

        private static void Show(BitmapSource bs, string title = "Window")
        {
            // WPFのWindowに表示してみる
            var image = new System.Windows.Controls.Image { Source = bs };
            var window = new System.Windows.Window
            {
                Title = "from Mat to BitmapSource",
                Width = bs.PixelWidth,
                Height = bs.PixelHeight,
                Content = image
            };

            var app = new System.Windows.Application();
            app.Run(window);
        }

        private void AssertPixelValue<T>(Scalar expectedValue, BitmapSource bs)
            where T : struct 
        {
            if (bs.PixelWidth != 1 || bs.PixelHeight != 1)
                Assert.Inconclusive();

            var pixels = new T[3];
            int stride = 4 * Marshal.SizeOf<T>();
            bs.CopyPixels(Int32Rect.Empty, pixels, stride, 0);

            Console.WriteLine("Expected: ({0},{1},{2})", expectedValue.Val0, expectedValue.Val1, expectedValue.Val2);
            Console.WriteLine("Actual: ({0},{1},{2})", pixels[0], pixels[1], pixels[2]);
            Assert.That(pixels[0], Is.EqualTo(expectedValue.Val0).Within(1e-9));
            Assert.That(pixels[1], Is.EqualTo(expectedValue.Val1).Within(1e-9));
            Assert.That(pixels[2], Is.EqualTo(expectedValue.Val2).Within(1e-9));
        }
    }
}
#endif