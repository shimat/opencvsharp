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
            var src = new Mat(FilePath.Lenna, LoadMode.Color);
            var gray = new Mat(FilePath.Lenna, LoadMode.GrayScale);
            var dst = new Mat(src.Size(), MatType.CV_8UC3, Scalar.All(0));

            StarDetector detector = new StarDetector(45);
            KeyPoint[] keypoints = detector.Run(gray);

            if (keypoints != null)
            {
                var color = new Scalar(0, 255, 0);
                foreach (KeyPoint kpt in keypoints)
                {
                    float r = kpt.Size / 2;
                    Cv2.Circle(dst, kpt.Pt, (int)r, color, 1, LineType.Link8, 0);
                    Cv2.Line(dst, 
                        new Point2f(kpt.Pt.X + r, kpt.Pt.Y + r), 
                        new Point2f(kpt.Pt.X - r, kpt.Pt.Y - r), 
                        color, 1, LineType.Link8, 0);
                    Cv2.Line(dst, 
                        new Point2f(kpt.Pt.X - r, kpt.Pt.Y + r), 
                        new Point2f(kpt.Pt.X + r, kpt.Pt.Y - r), 
                        color, 1, LineType.Link8, 0);
                }
            }

            using (new Window("img", src))
            using (new Window("StarDetector features", dst))
            {
                Cv.WaitKey();
            }
        }
    }
}