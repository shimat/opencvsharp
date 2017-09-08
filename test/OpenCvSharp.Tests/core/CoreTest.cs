using System;
using Xunit;

namespace OpenCvSharp.Tests.Core
{
    public class CoreTest : TestBase
    {
        [Fact]
        public void Subtract()
        {
            using (Mat image = Image("lenna.png"))
            using (Mat dst1 = new Mat())
            using (Mat dst2 = new Scalar(255) - image)
            {
                Cv2.Subtract(new Scalar(255), image, dst1);

                ShowImagesWhenDebugMode(image, dst1, dst2);

                ImageEquals(dst1, dst2);
            }
        }

        [Fact]
        public void Sum()
        {
            using (Mat ones = Mat.Ones(10, 10, MatType.CV_8UC1))
            {
                Scalar sum = Cv2.Sum(ones);
                Assert.Equal(100, (int)sum.Val0);
            }
        }

        [Fact]
        public void MinMaxLoc()
        {
            using (Mat ones = Mat.Ones(10, 10, MatType.CV_8UC1))
            {
                ones.Set(1, 2, 0);
                ones.Set(3, 4, 2);

                Cv2.MinMaxLoc(ones, out var minVal, out var maxVal, out var minLoc, out var maxLoc);

                Assert.Equal(0, minVal);
                Assert.Equal(2, maxVal);
                Assert.Equal(new Point(2, 1), minLoc);
                Assert.Equal(new Point(4, 3), maxLoc);
            }
        }

        [Fact]
        public void MinMaxIdx()
        {
            using (Mat ones = Mat.Ones(10, 10, MatType.CV_8UC1))
            {
                ones.Set(1, 2, 0);
                ones.Set(3, 4, 2);

                double minVal, maxVal;
                int[] minIdx = new int[2];
                int[] maxIdx = new int[2];
                Cv2.MinMaxIdx(ones, out minVal, out maxVal, minIdx, maxIdx);

                Assert.Equal(0, minVal);
                Assert.Equal(2, maxVal);
                Assert.Equal(new [] {1, 2}, minIdx);
                Assert.Equal(new [] {3, 4}, maxIdx);
            }
        }
    }
}

