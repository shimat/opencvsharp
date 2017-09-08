using System;
using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D
{
    // ReSharper disable once InconsistentNaming
    
    public class SURFTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            var surf = SURF.Create(400);
            surf.Dispose();
        }

        [Fact]
        public void Detect()
        {
            // This parameter should introduce same result of http://opencv.jp/wordpress/wp-content/uploads/lenna_SURF-150x150.png
            KeyPoint[] keyPoints = null;
            using (var gray = Image("lenna.png", 0))
            using (var surf = SURF.Create(500, 4, 2, true))
                keyPoints = surf.Detect(gray);

            Console.WriteLine($"KeyPoint has {keyPoints.Length} items.");
        }

        [Fact]
        public void DetectAndCompute()
        {
            using (var gray = Image("lenna.png", ImreadModes.GrayScale))
            using (var surf = SURF.Create(500))
            using (Mat descriptor = new Mat())
            {
                KeyPoint[] keyPoints;
                surf.DetectAndCompute(gray, null, out keyPoints, descriptor);

                Console.WriteLine($"keyPoints has {keyPoints.Length} items.");
                Console.WriteLine($"descriptor has {descriptor.Rows} items.");
            }
        }
    }
}
