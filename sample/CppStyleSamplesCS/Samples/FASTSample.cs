using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// cv::FAST
    /// </summary>
    class FASTSample : ISample
    {
        public void Run()
        {
            using (Mat imgSrc = new Mat(FilePath.Image.Lenna, LoadMode.Color))
            using (Mat imgGray = new Mat())
            using (Mat imgDst = imgSrc.Clone())
            {
                Cv2.CvtColor(imgSrc, imgGray, ColorConversion.BgrToGray, 0);

                KeyPoint[] keypoints;
                Cv2.FAST(imgGray, out keypoints, 50, true);

                foreach (KeyPoint kp in keypoints)
                {
                    imgDst.Circle(kp.Pt, 3, CvColor.Red, -1, LineType.AntiAlias, 0);
                }

                Cv2.ImShow("FAST", imgDst);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }
        }
    }
}