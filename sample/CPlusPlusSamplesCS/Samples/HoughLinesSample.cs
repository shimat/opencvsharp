using System;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CPlusPlusSamplesCS
{
    /// <summary>
    /// ハフ変換による直線検出
    /// </summary>
    /// <remarks>http://opencv.jp/sample/special_transforms.html#hough_line</remarks>
    class HoughLinesSample : ISample
    {
        public void Run()
        {
            SampleCpp();      
        }

        /// <summary>
        /// sample of new C++ style wrapper
        /// </summary>
        private void SampleCpp()
        {
            // (1) Load the image
            using (Mat imgGray = new Mat(ImagePath.Goryokaku, LoadMode.GrayScale))
            using (Mat imgStd = new Mat(ImagePath.Goryokaku, LoadMode.Color))
            using (Mat imgProb = imgStd.Clone())
            {
                // Preprocess
                Cv2.Canny(imgGray, imgGray, 50, 200, 3, false);

                // (3) Run Standard Hough Transform 
                CvLineSegmentPolar[] segStd = Cv2.HoughLines(imgGray, 1, Math.PI / 180, 50, 0, 0);
                int limit = Math.Min(segStd.Length, 10);
                for (int i = 0; i < limit; i++ )
                {
                    // Draws result lines
                    float rho = segStd[i].Rho;
                    float theta = segStd[i].Theta;
                    double a = Math.Cos(theta);
                    double b = Math.Sin(theta);
                    double x0 = a * rho;
                    double y0 = b * rho;
                    CvPoint pt1 = new CvPoint { X = Cv.Round(x0 + 1000 * (-b)), Y = Cv.Round(y0 + 1000 * (a)) };
                    CvPoint pt2 = new CvPoint { X = Cv.Round(x0 - 1000 * (-b)), Y = Cv.Round(y0 - 1000 * (a)) };
                    imgStd.Line(pt1, pt2, CvColor.Red, 3, LineType.AntiAlias, 0);
                }

                // (4) Run Probabilistic Hough Transform
                CvLineSegmentPoint[] segProb = Cv2.HoughLinesP(imgGray, 1, Math.PI / 180, 50, 50, 10);
                foreach (CvLineSegmentPoint s in segProb)
                {
                    imgProb.Line(s.P1, s.P2, CvColor.Red, 3, LineType.AntiAlias, 0);
                }

                // (5) Show results
                using (new CvWindow("Hough_line_standard", WindowMode.AutoSize, imgStd.ToIplImage()))
                using (new CvWindow("Hough_line_probabilistic", WindowMode.AutoSize, imgProb.ToIplImage()))
                {
                    CvWindow.WaitKey(0);
                }
            }
        }

    }
}
