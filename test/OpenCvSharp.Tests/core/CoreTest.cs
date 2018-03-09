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
        public void BorderInterpolate()
        {
            Assert.Equal(3, Cv2.BorderInterpolate(3, 10, BorderTypes.Reflect));
            Assert.Equal(3, Cv2.BorderInterpolate(3, 10, BorderTypes.Replicate));
            Assert.Equal(3, Cv2.BorderInterpolate(3, 10, BorderTypes.Constant));

            Assert.Equal(2, Cv2.BorderInterpolate(-3, 10, BorderTypes.Reflect));
            Assert.Equal(0, Cv2.BorderInterpolate(-3, 10, BorderTypes.Replicate));
            Assert.Equal(-1, Cv2.BorderInterpolate(-3, 10, BorderTypes.Constant));

            Assert.Equal(6, Cv2.BorderInterpolate(13, 10, BorderTypes.Reflect));
            Assert.Equal(9, Cv2.BorderInterpolate(13, 10, BorderTypes.Replicate));
            Assert.Equal(-1, Cv2.BorderInterpolate(13, 10, BorderTypes.Constant));
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

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void SolveLP()
        {
            // https://qiita.com/peisuke/items/4cbc0d0bf388492ad2a5

            using (var a = new Mat(3, 1, MatType.CV_64FC1, new double[] { 3, 1, 2 }))
            using (var b = new Mat(3, 4, MatType.CV_64FC1, new double[] { 1, 1, 3, 30, 2, 2, 5, 24, 4, 1, 2, 36 }))
            using (var z = new Mat())
            {
                Cv2.SolveLP(a, b, z);

                Assert.Equal(MatType.CV_64FC1, z.Type());
                Assert.Equal(3, z.Total());
                Assert.Equal(8, z.Get<double>(0));
                Assert.Equal(4, z.Get<double>(1));
                Assert.Equal(0, z.Get<double>(2));
            }
        }
    }
}

