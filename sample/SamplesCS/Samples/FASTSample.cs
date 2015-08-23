using OpenCvSharp;
using SampleBase;

namespace SamplesCS
{
    /// <summary>
    /// cv::FAST
    /// </summary>
    class FASTSample : ISample
    {
        public void Run()
        {
            using (Mat imgSrc = new Mat(FilePath.Image.Lenna, ImreadModes.Color))
            using (Mat imgGray = new Mat())
            using (Mat imgDst = imgSrc.Clone())
            {
                Cv2.CvtColor(imgSrc, imgGray, ColorConversionCodes.BGR2GRAY, 0);

                KeyPoint[] keypoints = Cv2.FAST(imgGray, 50, true);

                foreach (KeyPoint kp in keypoints)
                {
                    imgDst.Circle(kp.Pt, 3, Scalar.Red, -1, LineTypes.AntiAlias, 0);
                }

                Cv2.ImShow("FAST", imgDst);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
            }
        }
    }
}