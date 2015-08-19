using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using SampleBase;

namespace SamplesCS
{
    /// <summary>
    /// Retrieves keypoints using the FREAK algorithm.
    /// </summary>
    class FREAKSample : ISample
    {
        public void Run()
        {
            var gray = new Mat(FilePath.Image.Lenna, LoadMode.GrayScale);
            var dst = new Mat(FilePath.Image.Lenna, LoadMode.Color);

            // ORB
            var orb = ORB.Create(1000);
            KeyPoint[] keypoints = orb.Detect(gray);

            // FREAK
            FREAK freak = FREAK.Create();
            Mat freakDescriptors = new Mat();
            freak.Compute(gray, ref keypoints, freakDescriptors);

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

            using (new Window("FREAK", dst))
            {
                Cv2.WaitKey();
            }
        }
    }
}