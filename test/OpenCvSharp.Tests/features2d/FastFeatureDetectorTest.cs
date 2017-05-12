using System;
using NUnit.Framework;

namespace OpenCvSharp.Tests.Features2D
{
    // ReSharper disable once InconsistentNaming

    [TestFixture]
    public class FastFeatureDetectorTest : TestBase
    {
        [Test]
        public void CreateAndDispose()
        {
            var surf = FastFeatureDetector.Create();
            surf.Dispose();
        }

        [Test]
        public void Detect()
        {
            KeyPoint[] keyPoints;
            using (var gray = Image("lenna.png", 0))
            using (var orb = FastFeatureDetector.Create())
                keyPoints = orb.Detect(gray);

            Console.WriteLine($"KeyPoint has {keyPoints.Length} items.");
        }
    }
}
