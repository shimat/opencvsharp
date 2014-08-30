using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// SIFT and SURF sample
    /// http://www.prism.gatech.edu/~ahuaman3/docs/OpenCV_Docs/tutorials/nonfree_1/nonfree_1.html
    /// </summary>
    class SiftSurfSample : ISample
    {
        public void Run()
        {
            var src1 = new Mat(FilePath.Image.Match1, LoadMode.Color);
            var src2 = new Mat(FilePath.Image.Match2, LoadMode.Color);

            MatchBySift(src1, src2);
            MatchBySurf(src1, src2);
        }

        private void MatchBySift(Mat src1, Mat src2)
        {
            var gray1 = new Mat();
            var gray2 = new Mat();

            Cv2.CvtColor(src1, gray1, ColorConversion.BgrToGray);
            Cv2.CvtColor(src2, gray2, ColorConversion.BgrToGray);

            var sift = new SIFT();

            // Detect the keypoints and generate their descriptors using SIFT
            KeyPoint[] keypoints1, keypoints2;
            var descriptors1 = new MatOfFloat();
            var descriptors2 = new MatOfFloat();
            sift.Run(gray1, null, out keypoints1, descriptors1);
            sift.Run(gray2, null, out keypoints2, descriptors2);

            // Match descriptor vectors
            var bfMatcher = new BFMatcher(NormType.L2, false);
            var flannMatcher = new FlannBasedMatcher();
            DMatch[] bfMatches = bfMatcher.Match(descriptors1, descriptors2);
            DMatch[] flannMatches = flannMatcher.Match(descriptors1, descriptors2);

            // Draw matches
            var bfView = new Mat();
            Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, bfMatches, bfView);
            var flannView = new Mat();
            Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, flannMatches, flannView);

            using (new Window("SIFT matching (by BFMather)", WindowMode.AutoSize, bfView))
            using (new Window("SIFT matching (by FlannBasedMatcher)", WindowMode.AutoSize, flannView))
            {
                Cv2.WaitKey();
            }
        }

        private void MatchBySurf(Mat src1, Mat src2)
        {
            var gray1 = new Mat();
            var gray2 = new Mat();

            Cv2.CvtColor(src1, gray1, ColorConversion.BgrToGray);
            Cv2.CvtColor(src2, gray2, ColorConversion.BgrToGray);

            var surf = new SURF(500, 4, 2, true);

            // Detect the keypoints and generate their descriptors using SURF
            KeyPoint[] keypoints1, keypoints2;
            var descriptors1 = new MatOfFloat();
            var descriptors2 = new MatOfFloat();
            surf.Run(gray1, null, out keypoints1, descriptors1);
            surf.Run(gray2, null, out keypoints2, descriptors2);

            // Match descriptor vectors 
            var bfMatcher = new BFMatcher(NormType.L2, false);
            var flannMatcher = new FlannBasedMatcher();
            DMatch[] bfMatches = bfMatcher.Match(descriptors1, descriptors2);
            DMatch[] flannMatches = flannMatcher.Match(descriptors1, descriptors2);

            // Draw matches
            var bfView = new Mat();
            Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, bfMatches, bfView);
            var flannView = new Mat();
            Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, flannMatches, flannView);

            using (new Window("SURF matching (by BFMather)", WindowMode.AutoSize, bfView))
            using (new Window("SURF matching (by FlannBasedMatcher)", WindowMode.AutoSize, flannView))
            {
                Cv2.WaitKey();
            }
        }

    }
}