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
            using (var gray = Image("lenna.png", ImreadModes.Grayscale))
            using (var surf = SURF.Create(500))
            using (Mat descriptor = new Mat())
            {
                KeyPoint[] keyPoints;
                surf.DetectAndCompute(gray, null, out keyPoints, descriptor);

                Console.WriteLine($"keyPoints has {keyPoints.Length} items.");
                Console.WriteLine($"descriptor has {descriptor.Rows} items.");
            }
        }

        [Fact]
        public void DescriptorSize()
        {
            using (var alg = OpenCvSharp.XFeatures2D.SURF.Create(300))
            {
                var ext = alg.Extended;
                var sz = alg.DescriptorSize;
                Assert.Equal(ext ? 128 : 64, sz);
                alg.Extended = !ext;

                var ext2 = alg.Extended;
                Assert.NotEqual(ext, ext2);

                var sz2 = alg.DescriptorSize;
                Assert.Equal(ext2 ? 128 : 64, sz2);
            }
        }

        [Fact]
        public void DescriptorType()
        {
            using (var alg = OpenCvSharp.XFeatures2D.SURF.Create(300))
            {
                var dtype = alg.DescriptorType;
                Assert.Equal(MatType.CV_32F, dtype);
            }
        }

        [Fact]
        public void DefaultNorm()
        {
            using (var alg = OpenCvSharp.XFeatures2D.SURF.Create(300))
            {
                var defnorm = alg.DefaultNorm;
                Assert.Equal(4, defnorm);
            }
        }

        [Fact]
        public void Empty()
        {
            using (var alg = OpenCvSharp.XFeatures2D.SURF.Create(300))
            {
                var empty = alg.Empty();
                Assert.True(empty);
            }
        }
    }
}
