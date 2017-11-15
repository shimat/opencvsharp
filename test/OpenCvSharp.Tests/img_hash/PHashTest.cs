using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.ImgHash;
using Xunit;

namespace OpenCvSharp.Tests
{
    public class PHashTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            using (var phash = PHash.Create())
            {
                GC.KeepAlive(phash);
            }
        }

        [Fact]
        public void Compute()
        {
            using (var phash = PHash.Create())
            using (var img = Image("lenna.png"))
            using (var hash = new MatOfByte())
            {
                phash.Compute(img, hash);
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
            using (var phash = PHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.GrayScale))
            {
                double hash = phash.Compare(img1, img1);
                Assert.Equal(0, hash, 6);
            }
        }

        [Fact]
        public void CompareDifferentImage()
        {
            using (var phash = PHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.GrayScale))
            using (var img2 = Image("building.jpg", ImreadModes.GrayScale))
            {
                var size = new Size(256, 256);
                using (var scaledImg1 = img1.Resize(size))
                using (var scaledImg2 = img2.Resize(size))
                {
                    double hash = phash.Compare(scaledImg1, scaledImg2);
                    Assert.Equal(264411, hash, 6);
                }
            }
        }
    }
}
