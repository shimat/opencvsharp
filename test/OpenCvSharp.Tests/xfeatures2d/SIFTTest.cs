using System;
using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D
{
    // ReSharper disable once InconsistentNaming
    
    public class SIFTTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            var surf = SIFT.Create(400);
            surf.Dispose();
        }

        [Fact]
        public void Detect()
        {
            KeyPoint[] keyPoints;
            using (var gray = Image("lenna.png", 0))
            using (var alg = SIFT.Create(500))
                keyPoints = alg.Detect(gray);

            Console.WriteLine($"KeyPoint has {keyPoints.Length} items.");
        }

        [Fact]
        public void DescriptorSize()
        {
            using (var alg = SIFT.Create())
            {
                var sz = alg.DescriptorSize;
                Assert.Equal(128, sz);
            }
        }

        [Fact]
        public void DescriptorType()
        {
            using (var alg = SIFT.Create())
            {
                var dtype = alg.DescriptorType;
                Assert.Equal(MatType.CV_32F, dtype);
            }
        }

        [Fact]
        public void DefaultNorm()
        {
            using (var alg = SIFT.Create())
            {
                var defnorm = alg.DefaultNorm;
                Assert.Equal(4, defnorm);
            }
        }
    }
}
