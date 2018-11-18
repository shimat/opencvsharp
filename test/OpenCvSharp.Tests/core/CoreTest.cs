using System;
using System.Diagnostics;
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
        public void MatSubtractWithScalar()
        {
            using (Mat src = new Mat(3, 1, MatType.CV_16SC1, new short[]{1, 2, 3}))
            using (Mat dst = new Mat())
            {
                Cv2.Subtract(src, 1, dst);
                Assert.Equal(0, dst.Get<short>(0));
                Assert.Equal(1, dst.Get<short>(1));
                Assert.Equal(2, dst.Get<short>(2));

                Cv2.Subtract(1, src, dst);
                Assert.Equal(0, dst.Get<short>(0));
                Assert.Equal(-1, dst.Get<short>(1));
                Assert.Equal(-2, dst.Get<short>(2));
            }
        }

        [Fact]
        public void MatExprSubtractWithScalar()
        {
            // MatExpr - Scalar
            using (Mat src = new Mat(3, 1, MatType.CV_16SC1, new short[] { 1, 2, 3 }))
            using (MatExpr srcExpr = src)
            using (MatExpr dstExpr = srcExpr - 1)
            using (Mat dst = dstExpr)
            {
                Assert.Equal(0, dst.Get<short>(0));
                Assert.Equal(1, dst.Get<short>(1));
                Assert.Equal(2, dst.Get<short>(2));
            }

            // Scalar - MatExpr
            using (Mat src = new Mat(3, 1, MatType.CV_16SC1, new short[] { 1, 2, 3 }))
            using (MatExpr srcExpr = src)
            using (MatExpr dstExpr = 1 - srcExpr)
            using (Mat dst = dstExpr)
            {
                Assert.Equal(0, dst.Get<short>(0));
                Assert.Equal(-1, dst.Get<short>(1));
                Assert.Equal(-2, dst.Get<short>(2));
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
        public void Divide()
        {
            using (var mat1 = new Mat(3, 1, MatType.CV_8UC1, new byte[] { 64, 128, 192 }))
            using (var mat2 = new Mat(3, 1, MatType.CV_8UC1, new byte[] { 2, 4, 8 }))
            using (var dst = new Mat())
            {
                // default
                Cv2.Divide(mat1, mat2, dst, 1, -1);
                Assert.Equal(MatType.CV_8UC1, dst.Type());
                Assert.Equal(3, dst.Total());
                Assert.Equal(32, dst.Get<byte>(0));
                Assert.Equal(32, dst.Get<byte>(1));
                Assert.Equal(24, dst.Get<byte>(2));

                // scale
                Cv2.Divide(mat1, mat2, dst, 2, -1);
                Assert.Equal(MatType.CV_8UC1, dst.Type());
                Assert.Equal(3, dst.Total());
                Assert.Equal(64, dst.Get<byte>(0));
                Assert.Equal(64, dst.Get<byte>(1));
                Assert.Equal(48, dst.Get<byte>(2));

                // scale & dtype
                Cv2.Divide(mat1, mat2, dst, 2, MatType.CV_32SC1);
                Assert.Equal(MatType.CV_32SC1, dst.Type());
                Assert.Equal(3, dst.Total());
                Assert.Equal(64, dst.Get<int>(0));
                Assert.Equal(64, dst.Get<int>(1));
                Assert.Equal(48, dst.Get<int>(2));
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
        public void CopyMakeBorder()
        {
            using (var src = new Mat(10, 10, MatType.CV_8UC1, 0))
            using (var dst = new Mat())
            {
                const int top = 1, bottom = 2, left = 3, right = 4;
                Cv2.CopyMakeBorder(src, dst, top, bottom, left, right, BorderTypes.Constant, 255);

                using (var expected = new Mat(src.Rows + top + bottom, src.Cols + left + right, src.Type(), 0))
                {
                    Cv2.Rectangle(expected, new Point(0, 0), new Point(expected.Cols, top - 1), 255, -1);
                    Cv2.Rectangle(expected, new Point(0, expected.Rows - bottom), new Point(expected.Cols, expected.Rows), 255, -1);
                    Cv2.Rectangle(expected, new Point(0, 0), new Point(left - 1, expected.Rows), 255, -1);
                    Cv2.Rectangle(expected, new Point(expected.Cols - right, 0), new Point(expected.Cols, expected.Rows), 255, -1);

                    if (Debugger.IsAttached)
                    {
                        Window.ShowImages(dst, expected);
                    }

                    ImageEquals(dst, expected);
                }
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

        [Fact]
        public void Partition()
        {
            var array = new[] {1, 3, 8, 8, 1, 3, 3, };

            int nClasses = Cv2.Partition(array, out var labels, (a, b) => a == b);

            Assert.Equal(3, nClasses);
            Assert.Equal(new[] {0, 1, 2, 2, 0, 1, 1}, labels);
        }
    }
}

