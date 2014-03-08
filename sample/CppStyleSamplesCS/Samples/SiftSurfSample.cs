using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// SIFT and SURF sample
    /// </summary>
    class SiftSurfSample : ISample
    {
        public void Run()
        {
            Mat src = new Mat(ImagePath.Lenna, LoadMode.Color);
            Mat gray = new Mat();
            Mat siftView = src.Clone();
            Mat surfView = src.Clone();

            Cv2.CvtColor(src, gray, ColorConversion.BgrToGray);

            // initializes SIFT & SURF class
            SIFT sift = new SIFT();
            SURF surf = new SURF(500, 4, 2, true);

            // extracts SIFT
            {
                KeyPoint[] keypoints;
                Mat descriptors = new Mat();
                sift.Run(gray, null, out keypoints, descriptors);
                // draw keypoints
                Scalar color = new Scalar(255, 255, 0);
                foreach (KeyPoint kp in keypoints)
                {
                    siftView.Circle(kp.Pt, (int)(kp.Size * 0.25), color);
                }
            }

            // extracts SURF
            {
                KeyPoint[] keypoints;
                float[] descriptors;
                surf.Run(gray, null, out keypoints, out descriptors);
                // draw keypoints
                Scalar color = new Scalar(255, 255, 0);
                foreach (KeyPoint kp in keypoints)
                {
                    surfView.Circle(kp.Pt, (int)(kp.Size * 0.25), color);
                }
            }

            using (new Window("SIFT", WindowMode.AutoSize, siftView))
            using (new Window("SURF", WindowMode.AutoSize, surfView))
            {
                Cv2.WaitKey();
            }
        }

    }
}