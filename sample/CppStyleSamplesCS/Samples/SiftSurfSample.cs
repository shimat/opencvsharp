using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

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
            Mat src1 = new Mat(FilePath.Match1, LoadMode.Color);
            Mat src2 = new Mat(FilePath.Match2, LoadMode.Color);

            //MatchBySift(src1, src2);
            MatchBySurf(src1, src2);
        }

        private void MatchBySift(Mat src1, Mat src2)
        {
            Mat gray1 = new Mat();
            Mat gray2 = new Mat();

            Cv2.CvtColor(src1, gray1, ColorConversion.BgrToGray);
            Cv2.CvtColor(src2, gray2, ColorConversion.BgrToGray);

            SIFT sift = new SIFT();

            // Detect the keypoints and generate their descriptors using SIFT
            KeyPoint[] keypoints1, keypoints2;
            MatOfFloat descriptors1 = new MatOfFloat();
            MatOfFloat descriptors2 = new MatOfFloat();
            sift.Run(gray1, null, out keypoints1, descriptors1);
            sift.Run(gray2, null, out keypoints2, descriptors2);

            // Matching descriptor vectors with a brute force matcher
            BFMatcher matcher = new BFMatcher(NormType.L2, false);
            DMatch[] matches = matcher.Match(descriptors1, descriptors2);

            // Draw matches
            Mat view = new Mat();
            Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, matches, view);

            using (new Window("SIFT matching", WindowMode.AutoSize, view))
            {
                Cv2.WaitKey();
            }
        }

        private void MatchBySurf(Mat src1, Mat src2)
        {
            Mat gray1 = new Mat();
            Mat gray2 = new Mat();

            Cv2.CvtColor(src1, gray1, ColorConversion.BgrToGray);
            Cv2.CvtColor(src2, gray2, ColorConversion.BgrToGray);

            SURF surf = new SURF(500, 4, 2, true);

            // Detect the keypoints and generate their descriptors using SURF
            KeyPoint[] keypoints1, keypoints2;
            var descriptors1 = new MatOfDouble();
            var descriptors2 = new MatOfDouble();
            surf.Run(gray1, null, out keypoints1, descriptors1);
            surf.Run(gray2, null, out keypoints2, descriptors2);

            var array = descriptors1.ToArray();
            array.ToString();

            // Matching descriptor vectors with a brute force matcher
            BFMatcher matcher = new BFMatcher(NormType.L2, false);
            DMatch[] matches = matcher.Match(descriptors1, descriptors2);

            // Draw matches
            Mat view = new Mat();
            Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, matches, view);

            using (new Window("SURF matching", WindowMode.AutoSize, view))
            {
                Cv2.WaitKey();
            }
        }

    }
}