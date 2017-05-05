using System;
using NUnit.Framework;
using OpenCvSharp.Flann;
using OpenCvSharp.XFeatures2D;

namespace OpenCvSharp.Tests.Features2D
{
    // ReSharper disable once InconsistentNaming

    [TestFixture]
    public class FlannBasedMatcherTest : TestBase
    {
        [Test]
        public void Mathing()
        {
            using (var img1 = Image("tsukuba_left.png", ImreadModes.GrayScale))
            using (var img2 = Image("tsukuba_right.png", ImreadModes.GrayScale))
            using (var orb = ORB.Create(500))
            using (var descriptor1 = new Mat())
            using (var descriptor2 = new Mat())
            {
                KeyPoint[] keyPoints1, keyPoints2;
                orb.DetectAndCompute(img1, null, out keyPoints1, descriptor1);
                orb.DetectAndCompute(img2, null, out keyPoints2, descriptor2);

                // Flann needs the descriptors to be of type CV_32F
                Assert.AreEqual(MatType.CV_8UC1, descriptor1.Type());
                Assert.AreEqual(MatType.CV_8UC1, descriptor2.Type());
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

        [Test]
        public void MathingWithKDTreeIndexParams()
        {
            using (var img1 = Image("tsukuba_left.png", ImreadModes.GrayScale))
            using (var img2 = Image("tsukuba_right.png", ImreadModes.GrayScale))
            using (var orb = ORB.Create(500))
            using (var descriptor1 = new Mat())
            using (var descriptor2 = new Mat())
            {
                KeyPoint[] keyPoints1, keyPoints2;
                orb.DetectAndCompute(img1, null, out keyPoints1, descriptor1);
                orb.DetectAndCompute(img2, null, out keyPoints2, descriptor2);

                var indexParams = new KDTreeIndexParams();

                // Flann needs the descriptors to be of type CV_32F
                Assert.AreEqual(MatType.CV_8UC1, descriptor1.Type());
                Assert.AreEqual(MatType.CV_8UC1, descriptor2.Type());
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

        [Test]
        public void MathingWithLshIndexParams()
        {
            using (var img1 = Image("tsukuba_left.png", ImreadModes.GrayScale))
            using (var img2 = Image("tsukuba_right.png", ImreadModes.GrayScale))
            using (var orb = ORB.Create(500))
            using (var descriptor1 = new Mat())
            using (var descriptor2 = new Mat())
            {
                KeyPoint[] keyPoints1, keyPoints2;
                orb.DetectAndCompute(img1, null, out keyPoints1, descriptor1);
                orb.DetectAndCompute(img2, null, out keyPoints2, descriptor2);

                var indexParams = new LshIndexParams(12, 20, 2);

                Assert.AreEqual(MatType.CV_8UC1, descriptor1.Type());
                Assert.AreEqual(MatType.CV_8UC1, descriptor2.Type());

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
