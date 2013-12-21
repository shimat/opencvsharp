using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Building convex hull for a sequence or array of points
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/opencv-1.1.0/document/opencvref_cv_geometry.html#decl_cvConvexHull2
    /// </remarks>
    class ConvexHull
    {
        public ConvexHull()
        {
            using (IplImage img = Cv.CreateImage(new CvSize(500, 500), BitDepth.U8, 3))
            using (CvWindow window = new CvWindow("hull"))
            {
                Random rand = new Random();

                for (; ; )
                {
                    int count = rand.Next() % 100 + 1;

                    // create sequence of random points
                    CvPoint[] ptseq = new CvPoint[count];
                    for (int i = 0; i < ptseq.Length; i++)
                    {
                        ptseq[i] = new CvPoint
                        {
                            X = rand.Next() % (img.Width / 2) + img.Width / 4,
                            Y = rand.Next() % (img.Height / 2) + img.Height / 4
                        };
                    }

                    // draw points
                    Cv.Zero(img);
                    foreach(CvPoint pt in ptseq)
                    {
                        Cv.Circle(img, pt, 2, new CvColor(255, 0, 0), -1);
                    }

                    // find hull
                    CvPoint[] hull;
                    Cv.ConvexHull2(ptseq, out hull, ConvexHullOrientation.Clockwise);

                    // draw hull
                    CvPoint pt0 = hull.Last();
                    foreach(CvPoint pt in hull)
                    {
                        Cv.Line(img, pt0, pt, CvColor.Green);
                        pt0 = pt;
                    }


                    window.ShowImage(img);

                    if (Cv.WaitKey(0) == 27) // 'ESC'
                        break;
                }

            }
        }
    }
}
