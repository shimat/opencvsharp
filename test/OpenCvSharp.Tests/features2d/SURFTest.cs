using System;
using NUnit.Framework;
using OpenCvSharp.XFeatures2D;

namespace OpenCvSharp.Tests.features2d
{
    // ReSharper disable once InconsistentNaming

    [TestFixture]
    public class SURFTest : TestBase
    {
        [Test]
        public void CreateAndDispose()
        {
            var surf = SURF.Create(400);
            surf.Dispose();
        }

        [Test]
        public void Detect()
        {
            // This parameter should introduce same result of http://opencv.jp/wordpress/wp-content/uploads/lenna_SURF-150x150.png
            KeyPoint[] keyPoints = null;
            using (var gray = Image("lenna.png", 0))
            using (var surf = SURF.Create(500, 4, 2, true))
                keyPoints = surf.Detect(gray);

            Console.WriteLine($"KeyPoint has {keyPoints.Length} items.");
        }
    }
}
