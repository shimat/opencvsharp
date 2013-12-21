using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// cvFitLine sample
    /// </summary>
    class FitLine
    {
        public FitLine()
        {
            CvSize imageSize = new CvSize(500, 500);

            // cvFitLine
            CvPoint2D32f[] points = GetRandomPoints(20, imageSize);
            CvLine2D line = Cv.FitLine2D(points, DistanceType.L2, 0, 0.01, 0.01);

            using (IplImage img = new IplImage(imageSize, BitDepth.U8, 3))
            {
                img.Zero();

                // draw line
                {
                    CvPoint pt1, pt2;
                    line.FitSize(img.Width, img.Height, out pt1, out pt2);
                    img.Line(pt1, pt2, CvColor.Green, 1, LineType.Link8);
                }

                // draw points and distances
                using (CvFont font = new CvFont(FontFace.HersheySimplex, 0.33, 0.33))
                {
                    foreach (CvPoint2D32f p in points)
                    {
                        double d = line.Distance(p);

                        img.Circle(p, 2, CvColor.White, -1, LineType.AntiAlias);
                        img.PutText(string.Format("{0:F1}", d), new CvPoint((int) (p.X + 3), (int) (p.Y + 3)), font, CvColor.Green);
                    }
                }

                CvWindow.ShowImages(img);
            }
        }


        private CvPoint2D32f[] GetRandomPoints(int count, CvSize imageSize)
        {
            Random rand = new Random();
            CvPoint2D32f[] points = new CvPoint2D32f[count];
            double a = rand.NextDouble() + 0.5;
            for (int i = 0; i < points.Length; i++)
            {
                double x = rand.Next(imageSize.Width);
                double y = (x * a) + (rand.Next(100) - 50);
                points[i] = new CvPoint2D32f(x, y);
            }
            return points;
        }
    }
}