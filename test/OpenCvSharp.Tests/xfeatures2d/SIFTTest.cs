using System;
using NUnit.Framework;
using OpenCvSharp.XFeatures2D;

namespace OpenCvSharp.Tests.XFeatures2D
{
    // ReSharper disable once InconsistentNaming

    [TestFixture]
    public class SIFTTest : TestBase
    {
        [Test]
        public void CreateAndDispose()
        {
            var surf = SIFT.Create(400);
            surf.Dispose();
        }

        [Test]
        public void Detect()
        {
            KeyPoint[] keyPoints = null;
            using (var gray = Image("lenna.png", 0))
            using (var surf = SIFT.Create(500))
                keyPoints = surf.Detect(gray);

            Console.WriteLine($"KeyPoint has {keyPoints.Length} items.");
        }
    }
}
