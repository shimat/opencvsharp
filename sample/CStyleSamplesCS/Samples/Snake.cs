using System;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// 輪郭検出
    /// </summary>
    /// <remarks>http://opencv.jp/sample/object_tracking.html#snake</remarks>
    class Snake
    {        
        public Snake()
        {
            using (var src = new IplImage(FilePath.Image.Cake, LoadMode.GrayScale))
            using (var dst = new IplImage(src.Size, BitDepth.U8, 3))
            {
                CvPoint[] contour = new CvPoint[100];
                CvPoint center = new CvPoint(src.Width / 2, src.Height / 2);
                for (int i = 0; i < contour.Length; i++)
                {
                    contour[i].X = (int)(center.X * Math.Cos(2 * Math.PI * i / contour.Length) + center.X);
                    contour[i].Y = (int)(center.Y * Math.Sin(2 * Math.PI * i / contour.Length) + center.Y);
                }
                Console.WriteLine("Press any key to snake\nEsc - quit");
                using (var window = new CvWindow())
                {
                    while (true)
                    {
                        src.SnakeImage(contour, 0.45f, 0.35f, 0.2f, new CvSize(15, 15), new CvTermCriteria(1), true);
                        src.CvtColor(dst, ColorConversion.GrayToRgb);
                        for (int i = 0; i < contour.Length - 1; i++)
                        {
                            dst.Line(contour[i], contour[i + 1], new CvColor(255, 0, 0), 2);
                        }
                        dst.Line(contour[contour.Length - 1], contour[0], new CvColor(255, 0, 0), 2);
                        window.Image = dst;
                        int key = CvWindow.WaitKey();
                        if (key == 27)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
