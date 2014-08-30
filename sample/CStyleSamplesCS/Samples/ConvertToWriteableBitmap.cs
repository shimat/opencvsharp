using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Image Conversion to System.Windows.Media.Imaging.WriteableBitmap 
    /// </summary>
    class ConvertToWriteableBitmap
    {
        public ConvertToWriteableBitmap()
        {
            WriteableBitmap wb = null;

            // OpenCV processing
            using (var src = new IplImage(FilePath.Image.Lenna, LoadMode.GrayScale))
            using (var dst = new IplImage(src.Size, BitDepth.U8, 1))
            {
                src.Smooth(src, SmoothType.Gaussian, 5);
                src.Threshold(dst, 0, 255, ThresholdType.Otsu);
                // IplImage -> WriteableBitmap
                wb = dst.ToWriteableBitmap(PixelFormats.BlackWhite);
                //wb = WriteableBitmapConverter.ToWriteableBitmap(dst, PixelFormats.BlackWhite);
            }

            // Shows WriteableBitmap to WPF window
            var image = new Image { Source = wb };
            var window = new Window
            {
                Title = "from IplImage to WriteableBitmap",
                Width = wb.PixelWidth,
                Height = wb.PixelHeight,
                Content = image
            };

            var app = new Application();
            app.Run(window);
        }
    }
}
