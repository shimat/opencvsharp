using System;
using OpenCvSharp.ImgHash;
using Xunit;

namespace OpenCvSharp.Tests.ImgHash
{
    public class ColorMomentHashTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            using (var model = ColorMomentHash.Create())
            {
                GC.KeepAlive(model);
            }
        }

        [Fact]
        public void Compute()
        {
            using (var model = ColorMomentHash.Create())
            using (var img = Image("lenna.png"))
            using (var hash = new MatOfDouble())
            {
                model.Compute(img, hash);
                Assert.Equal(1, hash.Rows);
                Assert.Equal(42, hash.Cols);
                Assert.Equal(MatType.CV_64FC1, hash.Type());

                var hashArray = hash.ToArray();
                Assert.Equal(
                    new double[]
                    {
                        0.00168799895166844, 9.73548985026306E-09, 7.12008515499876E-12, 1.58206172228354E-10,
                        5.28813826840171E-21, 1.29337857065483E-14, 4.79075399951684E-22, 0.00128609224067447,
                        9.52599959124291E-10, 3.93698021400622E-12, 7.14400696815386E-12, 3.78255159833954E-23,
                        1.97733914733847E-16, 2.16399836659832E-24, 0.000922260536104536, 3.65830493343832E-09,
                        7.661707706699E-13, 1.19445875901408E-12, -1.12767845932483E-24, -5.93217692337658E-17,
                        -1.84467412783745E-25, 0.00132500752122349, 9.11756797244743E-09, 3.34535518270916E-12,
                        9.874171040899E-12, 1.58987320234562E-25, -9.15629498603106E-16, 5.67505900918754E-23,
                        0.000996616840904085, 1.90986702741479E-10, 1.81929041195046E-13, 1.60689960736751E-13,
                        -2.7254690880086E-26, 1.04487497633728E-18, -3.47059704207128E-27, 0.00139981947147226,
                        2.27201044977745E-09, 4.41887540236722E-13, 7.28673251542401E-13, -4.09431968883588E-25,
                        3.10909057900972E-17, -5.77204894690052E-26
                    },
                    hashArray, new DoubleEqualityComparer(1E-12));
            }
        }

        [Fact]
        public void CompareSameImage()
        {
            using (var model = ColorMomentHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.Grayscale))
            {
                double hash = model.Compare(img1, img1);
                Assert.Equal(0, hash, 6);
            }
        }

        [Fact]
        public void CompareDifferentImage()
        {
            using (var model = ColorMomentHash.Create())
            using (var img1 = Image("lenna.png", ImreadModes.Grayscale))
            using (var img2 = Image("building.jpg", ImreadModes.Grayscale))
            {
                var size = new Size(256, 256);
                using (var scaledImg1 = img1.Resize(size))
                using (var scaledImg2 = img2.Resize(size))
                {
                    double hash = model.Compare(scaledImg1, scaledImg2);
                    Assert.Equal(236458999.828723, hash, 6);
                }
            }
        }
    }
}
