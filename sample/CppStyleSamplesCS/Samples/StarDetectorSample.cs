using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// Retrieves keypoints using the StarDetector algorithm.
    /// </summary>
    class StarDetectorSample : ISample
    {
        public void Run()
        {
            using (IplImage img = new IplImage(FilePath.Lenna, LoadMode.GrayScale))
            using (IplImage cimg = new IplImage(img.Size, BitDepth.U8, 3))
            {
                Cv.CvtColor(img, cimg, ColorConversion.GrayToBgr);

                CppStyleStarDetector(img, cimg);    // C++-style

                using (new CvWindow("img", img))
                using (new CvWindow("StarDetector features", cimg))
                {
                    Cv.WaitKey();
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
            KeyPoint[] keypoints = detector.Run(src);

            if (keypoints != null)
            {
                foreach (KeyPoint kpt in keypoints)
                {
                    float r = kpt.Size / 2;
                    Cv2.Circle(dst, kpt.Pt, (int)r, new CvColor(0, 255, 0), 1, LineType.Link8, 0);
                    Cv2.Line(dst, new Point2f(kpt.Pt.X + r, kpt.Pt.Y + r), new Point2f(kpt.Pt.X - r, kpt.Pt.Y - r), new CvColor(0, 255, 0), 1, LineType.Link8, 0);
                    Cv2.Line(dst, new Point2f(kpt.Pt.X - r, kpt.Pt.Y + r), new Point2f(kpt.Pt.X + r, kpt.Pt.Y - r), new CvColor(0, 255, 0), 1, LineType.Link8, 0);
                }
            }

        }
    }
}