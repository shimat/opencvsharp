using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using SampleBase;

namespace SamplesCS
{
    /// <summary>
    /// Retrieves keypoints using the StarDetector algorithm.
    /// </summary>
    class StarDetectorSample : ISample
    {
        public void Run()
        {
            var dst = new Mat(FilePath.Image.Lenna, ImreadModes.Color);
            var gray = new Mat(FilePath.Image.Lenna, ImreadModes.GrayScale);

            StarDetector detector = StarDetector.Create(45);
            KeyPoint[] keypoints = detector.Detect(gray);

            if (keypoints != null)
            {
                var color = new Scalar(0, 255, 0);
                foreach (KeyPoint kpt in keypoints)
                {
                    float r = kpt.Size / 2;
                    Cv2.Circle(dst, kpt.Pt, (int)r, color);
                    Cv2.Line(dst, 
                        new Point2f(kpt.Pt.X + r, kpt.Pt.Y + r), 
                        new Point2f(kpt.Pt.X - r, kpt.Pt.Y - r), 
                        color);
                    Cv2.Line(dst, 
                        new Point2f(kpt.Pt.X - r, kpt.Pt.Y + r), 
                        new Point2f(kpt.Pt.X + r, kpt.Pt.Y - r), 
                        color);
                }
            }

            using (new Window("StarDetector features", dst))
            {
                Cv2.WaitKey();
            }
        }
    }
}