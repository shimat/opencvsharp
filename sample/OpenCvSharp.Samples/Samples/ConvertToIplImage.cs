using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenCvSharp.Extensions;


namespace OpenCvSharp.Test
{
    /// <summary>
    /// Conversion from Bitmap/WriteableBitmap to IplImage
    /// </summary>
    class ConvertToIplImage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ConvertToIplImage()
        {
            TestBitmap();
            TestWriteableBitmap();
            TestWriteableBitmapBgr32();
        }

        /// <summary>
        /// Bitmap -> IplImage
        /// </summary>
        private void TestBitmap()
        {
            using (Bitmap bitmap = new Bitmap(Const.ImageFruits))
            {
                IplImage ipl = new IplImage(bitmap.Width, bitmap.Height, BitDepth.U8, 3);

                //ipl = bitmap.ToIplImage();
                ipl.CopyFrom(bitmap);

                using (new CvWindow("from Bitmap to IplImage", ipl))
                {
                    Cv.WaitKey();
                }
            }
        }

        /// <summary>
        /// WriteableBitmap -> IplImage
        /// </summary>
        private void TestWriteableBitmap()
        {
            // Load 16-bit image to WriteableBitmap
            PngBitmapDecoder decoder = new PngBitmapDecoder(
                new Uri(Const.Image16bit, UriKind.Relative),
                BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default
            );
            BitmapSource bs = decoder.Frames[0];
            WriteableBitmap wb = new WriteableBitmap(bs);

            // Convert wb into IplImage
            IplImage ipl = wb.ToIplImage();
            //IplImage ipl32 = new IplImage(wb.PixelWidth, wb.PixelHeight, BitDepth.U16, 1);
            //WriteableBitmapConverter.ToIplImage(wb, ipl32);

            // Print pixel values
            for (int i = 0; i < ipl.Height; i++)
            {
                Console.WriteLine("x:{0} y:{1} v:{2}", i, i, ipl[i, 128]);
            }

            // Show 16-bit IplImage
            using (new CvWindow("from WriteableBitmap to IplImage", ipl))
            {
                Cv.WaitKey();
            }
        }

        /// <summary>
        /// WriteableBitmap (Format = Bgr32) -> IplImage
        /// </summary>
        private void TestWriteableBitmapBgr32()
        {
            // loads color image
            PngBitmapDecoder decoder = new PngBitmapDecoder(
                new Uri(Const.ImageLenna, UriKind.Relative),
                BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default
            );
            BitmapSource bs = decoder.Frames[0];

            // converts pixelformat from Bgr24 to Bgr32 (for this test)
            FormatConvertedBitmap fcb = new FormatConvertedBitmap();
            fcb.BeginInit();
            fcb.Source = bs;
            fcb.DestinationFormat = PixelFormats.Gray8;
            fcb.EndInit();

            // creates WriteableBitmap
            WriteableBitmap wb = new WriteableBitmap(fcb);

            // shows wb 
            /*
            var image = new System.Windows.Controls.Image { Source = wb };
            var window = new System.Windows.Window
            {
                Title = string.Format("wb (Format:{0})", wb.Format),
                Width = wb.PixelWidth,
                Height = wb.PixelHeight,
                Content = image
            };
            var app = new System.Windows.Application();
            app.Run(window);
            //*/

            // convert wb into IplImage
            IplImage ipl = wb.ToIplImage();
            //IplImage ipl32 = new IplImage(wb.PixelWidth, wb.PixelHeight, BitDepth.U16, 1);
            //WriteableBitmapConverter.ToIplImage(wb, ipl32);

            using (new CvWindow("from WriteableBitmap(Bgr32) to IplImage", ipl))
            {
                Cv.WaitKey();
            }
        }
    }
}
