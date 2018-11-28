using System;
using OpenCvSharp.Flann;
using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.Features2D
{
    // ReSharper disable once InconsistentNaming

    public class FlannBasedMatcherTest : TestBase
    {
        [Fact]
        public void Mathing()
        {
            using (var img1 = Image("tsukuba_left.png", ImreadModes.Grayscale))
            using (var img2 = Image("tsukuba_right.png", ImreadModes.Grayscale))
            using (var orb = ORB.Create(500))
            using (var descriptor1 = new Mat())
            using (var descriptor2 = new Mat())
            {
                KeyPoint[] keyPoints1, keyPoints2;
                orb.DetectAndCompute(img1, null, out keyPoints1, descriptor1);
                orb.DetectAndCompute(img2, null, out keyPoints2, descriptor2);

                // Flann needs the descriptors to be of type CV_32F
                Assert.Equal(MatType.CV_8UC1, descriptor1.Type());
                Assert.Equal(MatType.CV_8UC1, descriptor2.Type());
                descriptor1.ConvertTo(descriptor1, MatType.CV_32F);
                descriptor2.ConvertTo(descriptor2, MatType.CV_32F);

                var matcher = new FlannBasedMatcher();
                DMatch[] matches = matcher.Match(descriptor1, descriptor2);

                /*
                using (var view = new Mat())
                using (var window = new Window())
                {
                    Cv2.DrawMatches(img1, keyPoints1, img2, keyPoints2, matches, view);
                    window.ShowImage(view);
                    Cv2.WaitKey();
                }*/
            }
        }

        [Fact]
        public void MathingWithKDTreeIndexParams()
        {
            using (var img1 = Image("tsukuba_left.png", ImreadModes.Grayscale))
            using (var img2 = Image("tsukuba_right.png", ImreadModes.Grayscale))
            using (var orb = ORB.Create(500))
            using (var descriptor1 = new Mat())
            using (var descriptor2 = new Mat())
            {
                KeyPoint[] keyPoints1, keyPoints2;
                orb.DetectAndCompute(img1, null, out keyPoints1, descriptor1);
                orb.DetectAndCompute(img2, null, out keyPoints2, descriptor2);

                var indexParams = new KDTreeIndexParams();

                // Flann needs the descriptors to be of type CV_32F
                Assert.Equal(MatType.CV_8UC1, descriptor1.Type());
                Assert.Equal(MatType.CV_8UC1, descriptor2.Type());
                descriptor1.ConvertTo(descriptor1, MatType.CV_32F);
                descriptor2.ConvertTo(descriptor2, MatType.CV_32F);

                var matcher = new FlannBasedMatcher(indexParams);
                DMatch[] matches = matcher.Match(descriptor1, descriptor2);

                /*
                using (var view = new Mat())
                using (var window = new Window())
                {
                    Cv2.DrawMatches(img1, keyPoints1, img2, keyPoints2, matches, view);
                    window.ShowImage(view);
                    Cv2.WaitKey();
                }*/
            }
        }

        [Fact]
        public void MathingWithLshIndexParams()
        {
            using (var img1 = Image("tsukuba_left.png", ImreadModes.Grayscale))
            using (var img2 = Image("tsukuba_right.png", ImreadModes.Grayscale))
            using (var orb = ORB.Create(500))
            using (var descriptor1 = new Mat())
            using (var descriptor2 = new Mat())
            {
                KeyPoint[] keyPoints1, keyPoints2;
                orb.DetectAndCompute(img1, null, out keyPoints1, descriptor1);
                orb.DetectAndCompute(img2, null, out keyPoints2, descriptor2);

                var indexParams = new LshIndexParams(12, 20, 2);

                Assert.Equal(MatType.CV_8UC1, descriptor1.Type());
                Assert.Equal(MatType.CV_8UC1, descriptor2.Type());

                // LshIndexParams requires Binary descriptor, so it must NOT convert to CV_32F.
                //descriptor1.ConvertTo(descriptor1, MatType.CV_32F);
                //descriptor2.ConvertTo(descriptor2, MatType.CV_32F);

                var matcher = new FlannBasedMatcher(indexParams);
                DMatch[] matches = matcher.Match(descriptor1, descriptor2);

                /*
                using (var view = new Mat())
                using (var window = new Window())
                {
                    Cv2.DrawMatches(img1, keyPoints1, img2, keyPoints2, matches, view);
                    window.ShowImage(view);
                    Cv2.WaitKey();
                }*/
            }
        }
    }
}
