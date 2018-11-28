using System;
using OpenCvSharp.ImgHash;
using Xunit;

namespace OpenCvSharp.Tests.ImgHash
{
    public class BlockMeanHashTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            using (var model = BlockMeanHash.Create(BlockMeanHashMode.Mode0))
            {
                GC.KeepAlive(model);
            }
            using (var model = BlockMeanHash.Create(BlockMeanHashMode.Mode1))
            {
                GC.KeepAlive(model);
            }
        }

        [Fact]
        public void ComputeMode0()
        {
            using (var model = BlockMeanHash.Create(BlockMeanHashMode.Mode0))
            using (var img = Image("lenna.png"))
            using (var hash = new MatOfByte())
            {
                model.Compute(img, hash);
                Assert.Equal(1, hash.Rows);
                Assert.Equal(32, hash.Cols);
                Assert.Equal(MatType.CV_8UC1, hash.Type());

                var hashArray = hash.ToArray();
                Assert.Equal(
                    new byte[]{ 243, 61, 243, 61, 195, 63, 226, 151, 226, 159, 250, 223, 50, 206, 18, 231, 130, 226, 130, 227, 130, 243, 130, 243, 2, 243, 2, 87, 2, 127, 2, 47 },
                    hashArray);
            }
        }

        [Fact]
        public void ComputeMode1()
        {
            using (var model = BlockMeanHash.Create(BlockMeanHashMode.Mode1))
            using (var img = Image("lenna.png"))
            using (var hash = new MatOfByte())
            {
                model.Compute(img, hash);
                Assert.Equal(1, hash.Rows);
                Assert.Equal(121, hash.Cols);
                Assert.Equal(MatType.CV_8UC1, hash.Type());

                var hashArray = hash.ToArray();
                Assert.Equal(
                    new byte[]
                    {
                        135, 255, 243, 135, 131, 255, 249, 199, 193, 255, 252, 227, 224, 127, 254, 113, 128, 127, 127,
                        48, 192, 191, 25, 24, 240, 255, 4, 13, 248, 127, 135, 134, 252, 255, 99, 67, 254, 255, 184, 113,
                        255, 127, 220, 240, 195, 31, 111, 120, 224, 135, 55, 12, 248, 192, 27, 6, 126, 240, 13, 128, 63,
                        248, 6, 64, 14, 126, 3, 48, 7, 191, 3, 248, 131, 159, 1, 248, 193, 207, 0, 252, 240, 103, 0,
                        126, 248, 59, 0, 63, 254, 29, 0, 15, 255, 14, 0, 135, 127, 6, 128, 131, 63, 3, 224, 103, 206, 0,
                        240, 247, 99, 0, 248, 255, 49, 0, 252, 255, 24, 0, 254, 49, 0
                    },
                    hashArray);
            }
        }

        [Theory]
        [InlineData(BlockMeanHashMode.Mode0)]
        [InlineData(BlockMeanHashMode.Mode1)]
        public void CompareSameImage(BlockMeanHashMode mode)
        {
            using (var model = BlockMeanHash.Create(mode))
            using (var img1 = Image("lenna.png", ImreadModes.Grayscale))
            {
                double hash = model.Compare(img1, img1);
                Assert.Equal(0, hash, 6);
            }
        }

        [Theory]
        [InlineData(BlockMeanHashMode.Mode0)]
        [InlineData(BlockMeanHashMode.Mode1)]
        public void CompareDifferentImage(BlockMeanHashMode mode)
        {
            using (var model = BlockMeanHash.Create(mode))
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
