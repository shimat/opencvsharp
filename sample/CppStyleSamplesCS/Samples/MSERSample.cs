using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// Maximally Stable Extremal Regions
    /// </summary>
    class MSERSample : ISample
    {
        public void Run()
        {
            using (Mat src = new Mat(FilePath.Image.Distortion, LoadMode.Color))
            using (Mat gray = new Mat())
            using (Mat dst = src.Clone())
            {
                Cv2.CvtColor(src, gray, ColorConversion.BgrToGray);

                CppStyleMSER(gray, dst);  // C++ style

                using (new Window("MSER src", src))
                using (new Window("MSER gray", gray))
                using (new Window("MSER dst", dst))
                {
                    Cv.WaitKey();
                }
            }
        }
        
        /// <summary>
        /// Extracts MSER by C++-style code (cv::MSER)
        /// </summary>
        /// <param name="gray"></param>
        /// <param name="dst"></param>
        private void CppStyleMSER(Mat gray, Mat dst)
        {
            MSER mser = new MSER();
            Point[][] contours = mser.Run(gray, null);     // operator()
            foreach (Point[] pts in contours)
            {
                CvColor color = CvColor.Random();
                foreach (Point p in pts)
                {
                    dst.Circle(p, 1, color);
                }
            }
        }
    }
}