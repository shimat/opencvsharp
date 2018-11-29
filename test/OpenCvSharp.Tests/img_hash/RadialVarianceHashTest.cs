using System;
using OpenCvSharp.ImgHash;
using Xunit;

namespace OpenCvSharp.Tests.ImgHash
{
    public class RadialVarianceHashTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            using (var model = RadialVarianceHash.Create())
            {
                GC.KeepAlive(model);
            }
        }

        [Fact]
        public void Compute()
        {
            using (var model = RadialVarianceHash.Create())
            using (var img = Image("lenna.png"))
            using (var hash = new MatOfByte())
            {
                model.Compute(img, hash);
                Assert.Equal(1, hash.Rows);
                Assert.Equal(40, hash.Cols);
                Assert.Equal(MatType.CV_8UC1, hash.Type());

                var hashArray = hash.ToArray();
                Assert.Equal(
                    new byte[]{ 142, 0, 209, 255, 100, 131, 131, 190, 107, 68, 192, 159, 136, 135, 131, 159, 129, 184, 140, 134,
                        145, 120, 162, 157, 136, 142, 139, 134, 149, 146, 134, 151, 137, 139, 148, 144, 140, 135, 144, 144 },
                    hashArray);
            }
        }

        [Fact]
        public void CompareSameImage()
        {
            using (var model = RadialVarianceHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.Grayscale))
            {
                var size = new Size(40, 40);
                using (var scaledImg1 = img1.Resize(size))
                using (var scaledImg2 = img1.Resize(size))
                {
                    double hash = model.Compare(scaledImg1, scaledImg2);
                    Assert.Equal(1, hash, 6);
                }
            }
        }

        [Fact]
        public void CompareDifferentImage()
        {
            using (var model = RadialVarianceHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.Grayscale))
            using (var img2 = Image("building.jpg", ImreadModes.Grayscale))
            {
                var size = new Size(40, 40);
                using (var scaledImg1 = img1.Resize(size))
                using (var scaledImg2 = img2.Resize(size))
                {
                    double hash = model.Compare(scaledImg1, scaledImg2);
                    Assert.Equal(0.085777, hash, 6);
                }
            }
        }
    }
}
