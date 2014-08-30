using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// Retrieves keypoints using the BRISK algorithm.
    /// </summary>
    class BRISKSample : ISample
    {
        public void Run()
        {
            var gray = new Mat(FilePath.Image.Lenna, LoadMode.GrayScale);
            var dst = new Mat(FilePath.Image.Lenna, LoadMode.Color);

            BRISK brisk = new BRISK();
            KeyPoint[] keypoints = brisk.Detect(gray);

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

            using (new Window("BRISK features", dst))
            {
                Cv.WaitKey();
            }
        }
    }
}