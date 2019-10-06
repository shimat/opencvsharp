using System;
using Xunit;

namespace OpenCvSharp.Tests.Features2D
{
    // ReSharper disable once InconsistentNaming

    public class ORBTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            var surf = ORB.Create(400);
            surf.Dispose();
        }

        [Fact]
        public void Detect()
        {
            // This parameter should introduce same result of http://opencv.jp/wordpress/wp-content/uploads/lenna_SURF-150x150.png
            using var gray = Image("lenna.png", 0);
            using var orb = ORB.Create(500);
            var keyPoints = orb.Detect(gray);

            Console.WriteLine($"KeyPoint has {keyPoints.Length} items.");
        }

        [Fact]
        public void DetectAndCompute()
        {
            using (var gray = Image("lenna.png", ImreadModes.Grayscale))
            using (var orb = ORB.Create(500))
            using (Mat descriptor = new Mat())
            {
                orb.DetectAndCompute(gray, null, out var keyPoints, descriptor);

                Console.WriteLine($"keyPoints has {keyPoints.Length} items.");
                Console.WriteLine($"descriptor has {descriptor.Rows} items.");
            }
        }
    }
}
