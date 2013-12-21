using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// cv::FAST
    /// </summary>
    class FAST
    {
        public FAST()
        {
            IplImage img = new IplImage(Const.ImageLenna, LoadMode.Color);
            using (Mat imgSrc = new Mat(img))
            //using (Mat imgSrc = new Mat(Const.ImageLenna, LoadMode.Color))
            using (Mat imgGray = new Mat(imgSrc.Size, MatrixType.U8C1))
            using (Mat imgDst = imgSrc.Clone())
            {
                CvCpp.CvtColor(imgSrc, imgGray, ColorConversion.BgrToGray, 0);

                KeyPoint[] keypoints;
                CvCpp.FAST(imgGray, out keypoints, 50, true);

                foreach (KeyPoint kp in keypoints)
                {
                    imgDst.Circle(kp.Pt, 3, CvColor.Red, -1, LineType.AntiAlias, 0);
                }

                CvCpp.ImShow("FAST", imgDst);
                CvCpp.WaitKey(0);
                Cv.DestroyAllWindows();
            }
        }
    }
}