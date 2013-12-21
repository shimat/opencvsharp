using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Draws from IplImage to HDC
    /// </summary>
    class DrawToHdc
    {
        public DrawToHdc()
        {
            CvRect roi = new CvRect(320, 260, 100, 100);        // region of roosevelt's face

            using (IplImage src = new IplImage(Const.ImageYalta, LoadMode.Color))
            using (IplImage dst = new IplImage(roi.Size, BitDepth.U8, 3))
            {
                src.ROI = roi;

                using (Bitmap bitmap = new Bitmap(roi.Width, roi.Height, PixelFormat.Format32bppArgb))
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    //BitmapConverter.DrawToGraphics(src, g, new CvRect(new CvPoint(0, 0), roi.Size));
                    IntPtr hdc = g.GetHdc();
                    BitmapConverter.DrawToHdc(src, hdc, new CvRect(new CvPoint(0,0), roi.Size));
                    g.ReleaseHdc(hdc);

                    g.DrawString("Roosevelt", new Font(FontFamily.GenericSerif, 12), Brushes.Red, 20, 0);
                    g.DrawEllipse(new Pen(Color.Red, 4), new Rectangle(20, 20, roi.Width/2, roi.Height/2));

                    dst.CopyFrom(bitmap);
                }

                src.ResetROI();                

                using (new CvWindow("src", src))
                using (new CvWindow("dst", dst))
                {
                    Cv.WaitKey();
                }
            }
        }
    }
}
