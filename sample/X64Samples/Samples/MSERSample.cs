using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace X64Samples
{
    /// <summary>
    /// Maximally Stable Extremal Regions
    /// </summary>
    class MSERSample : ISample
    {
        public void Run()
        {
            using (IplImage imgSrc = new IplImage(ImagePath.Distortion, LoadMode.Color))
            using (IplImage imgGray = new IplImage(imgSrc.Size, BitDepth.U8, 1))
            using (IplImage imgDst = imgSrc.Clone())
            {
                Cv.CvtColor(imgSrc, imgGray, ColorConversion.BgrToGray);

                CppStyleMSER(imgGray, imgDst);  // C++ style

                using (new CvWindow("MSER src", imgSrc))
                using (new CvWindow("MSER gray", imgGray))
                using (new CvWindow("MSER dst", imgDst))
                {
                    Cv.WaitKey();
                }
            }
        }
        
        /// <summary>
        /// Extracts MSER by C++-style code (cv::MSER)
        /// </summary>
        /// <param name="imgGray"></param>
        /// <param name="imgRender"></param>
        private void CppStyleMSER(IplImage imgGray, IplImage imgDst)
        {
            MSER mser = new MSER();
            CvPoint[][] contours = mser.Extract(new Mat(imgGray, false), null);     // operator()
            foreach (CvPoint[] p in contours)
            {
                CvColor color = CvColor.Random();
                for (int i = 0; i < p.Length; i++)
                {
                    imgDst.Circle(p[i], 1, color);
                }
            }
        }
    }
}