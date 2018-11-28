using System;
using OpenCvSharp.ImgHash;
using Xunit;

namespace OpenCvSharp.Tests.ImgHash
{
    public class MarrHildrethHashTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            using (var model = MarrHildrethHash.Create())
            {
                GC.KeepAlive(model);
            }
        }

        [Fact]
        public void Compute()
        {
            using (var model = MarrHildrethHash.Create())
            using (var img = Image("lenna.png"))
            using (var hash = new MatOfByte())
            {
                model.Compute(img, hash);
                Assert.Equal(1, hash.Rows);
                Assert.Equal(72, hash.Cols);
                Assert.Equal(MatType.CV_8UC1, hash.Type());

                var hashArray = hash.ToArray();
                Assert.Equal(
                    new byte[]{ 208, 54, 63, 31, 143, 199, 227, 241, 192, 124, 126, 39, 3, 205, 192, 124, 126, 63, 228, 150, 199, 194,
                        242, 254, 208, 143, 201, 105, 118, 57, 5, 191, 3, 99, 177, 224, 15, 137, 153, 58, 5, 129, 63, 193, 216, 228,
                        112, 100, 129, 176, 248, 255, 110, 7, 230, 16, 193, 231, 207, 135, 0, 150, 120, 5, 191, 60, 18, 114, 119, 131, 150, 31 },
                    hashArray);
            }
        }

        [Fact]
        public void CompareSameImage()
        {
            using (var model = MarrHildrethHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.Grayscale))
            {
                double hash = model.Compare(img1, img1);
                Assert.Equal(0, hash, 6);
            }
        }

        [Fact]
        public void CompareDifferentImage()
        {
            using (var model = MarrHildrethHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.Grayscale))
            using (var img2 = Image("building.jpg", ImreadModes.Grayscale))
            {
                var size = new Size(256, 256);
                using (var scaledImg1 = img1.Resize(size))
                using (var scaledImg2 = img2.Resize(size))
                {
                    double hash = model.Compare(scaledImg1, scaledImg2);
                    Assert.Equal(264411, hash, 6);
                }
            }
        }
    }
}
