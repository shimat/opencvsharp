using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Retrieves keypoints using the StarDetector algorithm.
    /// </summary>
    class StarDetectorSample
    {
        public StarDetectorSample()
        {
            using (IplImage img = new IplImage(Const.ImageLenna, LoadMode.GrayScale))
            using (IplImage cimg = new IplImage(img.Size, BitDepth.U8, 3))
            {
                Cv.CvtColor(img, cimg, ColorConversion.GrayToBgr);

                //CStyleStarDetector(img, cimg);      // C-style
                CppStyleStarDetector(img, cimg);    // C++-style

                using (new CvWindow("img", img))
                using (new CvWindow("features", cimg))
                {
                    Cv.WaitKey();
                }
            } 
        }

        /// <summary>
        /// Extracts keypoints by C-style code (cvGetStarKeypoints)
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cimg"></param>
        private void CStyleStarDetector(IplImage img, IplImage cimg)
        {
            using (CvMemStorage storage = new CvMemStorage(0))
            {
                CvStarDetectorParams param = new CvStarDetectorParams(45);
                CvSeq<CvStarKeypoint> keypoints = Cv.GetStarKeypoints(img, storage, param);

                if (keypoints != null)
                {
                    for (int i = 0; i < keypoints.Total; i++)
                    {
                        CvStarKeypoint kpt = keypoints[i].Value;
                        int r = kpt.Size / 2;
                        //Cv.Circle(cimg, kpt.Pt, r, new CvColor(0, 255, 0));
                        //Cv.Line(cimg, new CvPoint(kpt.Pt.X + r, kpt.Pt.Y + r), new CvPoint(kpt.Pt.X - r, kpt.Pt.Y - r), new CvColor(0, 255, 0));
                        //Cv.Line(cimg, new CvPoint(kpt.Pt.X - r, kpt.Pt.Y + r), new CvPoint(kpt.Pt.X + r, kpt.Pt.Y - r), new CvColor(0, 255, 0));
                        cimg.DrawMarker(kpt.Pt.X, kpt.Pt.Y, CvColor.Green, MarkerStyle.CircleAndTiltedCross, kpt.Size);
                    }
                }
            }
        }

        /// <summary>
        /// Extracts keypoints by C++-style code (cv::StarDetector)
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cimg"></param>
        private void CppStyleStarDetector(IplImage img, IplImage cimg)
        {
            Mat src = new Mat(img, false);
            Mat dst = new Mat(cimg, false);
            StarDetector detector = new StarDetector(45);
            KeyPoint[] keypoints = detector.GetKeyPoints(src);

            if (keypoints != null)
            {
                foreach (KeyPoint kpt in keypoints)
                {
                    float r = kpt.Size / 2;
                    CvCpp.Circle(dst, kpt.Pt, (int)r, new CvColor(0, 255, 0), 1, LineType.Link8, 0);
                    CvCpp.Line(dst, new CvPoint2D32f(kpt.Pt.X + r, kpt.Pt.Y + r), new CvPoint2D32f(kpt.Pt.X - r, kpt.Pt.Y - r), new CvColor(0, 255, 0), 1, LineType.Link8, 0);
                    CvCpp.Line(dst, new CvPoint2D32f(kpt.Pt.X - r, kpt.Pt.Y + r), new CvPoint2D32f(kpt.Pt.X + r, kpt.Pt.Y - r), new CvColor(0, 255, 0), 1, LineType.Link8, 0);
                }
            }

        }
    }
}