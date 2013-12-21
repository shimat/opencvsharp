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

namespace OpenCvSharp.Test
{
    /// <summary>
    /// System.Windows.Media.Imaging.WriteableBitmapへの変換
    /// </summary>
    class ConvertToWriteableBitmap
    {
        public ConvertToWriteableBitmap()
        {
            WriteableBitmap wb = null;

            // OpenCVによる画像処理 (Threshold)
            using (IplImage src = new IplImage(Const.ImageLenna, LoadMode.GrayScale))
            using (IplImage dst = new IplImage(src.Size, BitDepth.U8, 1))
            {
                src.Smooth(src, SmoothType.Gaussian, 5);
                src.Threshold(dst, 0, 255, ThresholdType.Otsu);
                // IplImage -> WriteableBitmap
                wb = dst.ToWriteableBitmap(PixelFormats.BlackWhite);
                //wb = WriteableBitmapConverter.ToWriteableBitmap(dst, PixelFormats.BlackWhite);
            }

            // WPFのWindowに表示してみる
            Image image = new Image { Source = wb };
            Window window = new Window
            {
                Title = "from IplImage to WriteableBitmap",
                Width = wb.PixelWidth,
                Height = wb.PixelHeight,
                Content = image
            };

            Application app = new Application();
            app.Run(window);
        }
    }
}
