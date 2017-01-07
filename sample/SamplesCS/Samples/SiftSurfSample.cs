using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using SampleBase;

namespace SamplesCS
{
    /// <summary>
    /// SIFT and SURF sample
    /// http://www.prism.gatech.edu/~ahuaman3/docs/OpenCV_Docs/tutorials/nonfree_1/nonfree_1.html
    /// </summary>
    class SiftSurfSample : ISample
    {
        public void Run()
        {
            var src1 = new Mat(FilePath.Image.Match1, ImreadModes.Color);
            var src2 = new Mat(FilePath.Image.Match2, ImreadModes.Color);

            MatchBySift(src1, src2);
            MatchBySurf(src1, src2);
        }

        private void MatchBySift(Mat src1, Mat src2)
        {
            var gray1 = new Mat();
            var gray2 = new Mat();

            Cv2.CvtColor(src1, gray1, ColorConversionCodes.BGR2GRAY);
            Cv2.CvtColor(src2, gray2, ColorConversionCodes.BGR2GRAY);

            var sift = SIFT.Create();

            // Detect the keypoints and generate their descriptors using SIFT
            KeyPoint[] keypoints1, keypoints2;
            var descriptors1 = new MatOfFloat();
            var descriptors2 = new MatOfFloat();
            sift.DetectAndCompute(gray1, null, out keypoints1, descriptors1);
            sift.DetectAndCompute(gray2, null, out keypoints2, descriptors2);

            // Match descriptor vectors
            var bfMatcher = new BFMatcher(NormTypes.L2, false);
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

            Cv2.CvtColor(src1, gray1, ColorConversionCodes.BGR2GRAY);
            Cv2.CvtColor(src2, gray2, ColorConversionCodes.BGR2GRAY);

            var surf = SURF.Create(200, 4, 2, true);

            // Detect the keypoints and generate their descriptors using SURF
            KeyPoint[] keypoints1, keypoints2;
            var descriptors1 = new MatOfFloat();
            var descriptors2 = new MatOfFloat();
            surf.DetectAndCompute(gray1, null, out keypoints1, descriptors1);
            surf.DetectAndCompute(gray2, null, out keypoints2, descriptors2);

            // Match descriptor vectors 
            var bfMatcher = new BFMatcher(NormTypes.L2, false);
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