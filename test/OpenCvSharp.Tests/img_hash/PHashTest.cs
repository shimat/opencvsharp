using System;
using OpenCvSharp.ImgHash;
using Xunit;

namespace OpenCvSharp.Tests.ImgHash
{
    public class PHashTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            using (var model = PHash.Create())
            {
                GC.KeepAlive(model);
            }
        }

        [Fact]
        public void Compute()
        {
            using (var model = PHash.Create())
            using (var img = Image("lenna.png"))
            using (var hash = new MatOfByte())
            {
                model.Compute(img, hash);
                Assert.Equal(1, hash.Rows);
                Assert.Equal(8, hash.Cols);
                Assert.Equal(MatType.CV_8UC1, hash.Type());

                var hashArray = hash.ToArray();
                Assert.Equal(152, hashArray[0]);
                Assert.Equal(99, hashArray[1]);
                Assert.Equal(42, hashArray[2]);
                Assert.Equal(180, hashArray[3]);
                Assert.Equal(206, hashArray[4]);
                Assert.Equal(197, hashArray[5]);
                Assert.Equal(97, hashArray[6]);
                Assert.Equal(25, hashArray[7]);
            }
        }

        [Fact]
        public void CompareSameImage()
        {
            using (var model = PHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.Grayscale))
            {
                double hash = model.Compare(img1, img1);
                Assert.Equal(0, hash, 6);
            }
        }

        [Fact]
        public void CompareDifferentImage()
        {
            using (var model = PHash.Create())
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
