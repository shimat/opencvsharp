using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantArgumentDefaultValue

namespace OpenCvSharp.Tests.Core
{
    public class CoreTest : TestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        public CoreTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void GetAndSetNumThreads()
        {
            int threads = Cv2.GetNumThreads();
            
            Cv2.SetNumThreads(threads + 1);
            Assert.Equal(threads + 1, Cv2.GetNumThreads());

            Cv2.SetNumThreads(threads);
            Assert.Equal(threads, Cv2.GetNumThreads());
        }
        
        [Fact]
        public void GetThreadNum()
        {
            testOutputHelper.WriteLine("GetThreadNum: {0}", Cv2.GetThreadNum());
        }

        [Fact]
        public void GetBuildInformation()
        {
            Assert.NotEmpty(Cv2.GetBuildInformation());
            testOutputHelper.WriteLine("GetBuildInformation: {0}", Cv2.GetBuildInformation());
        }

        [Fact]
        public void GetVersionString()
        {
            Assert.NotEmpty(Cv2.GetVersionString());
            testOutputHelper.WriteLine("GetVersionString: {0}", Cv2.GetVersionString());
        }

        [Fact]
        public void GetVersionMajor()
        {
            testOutputHelper.WriteLine("GetVersionMajor: {0}", Cv2.GetVersionMajor());
        }

        [Fact]
        public void GetVersionMinor()
        {
            testOutputHelper.WriteLine("GetVersionMinor: {0}", Cv2.GetVersionMinor());
        }

        [Fact]
        public void GetVersionRevision()
        {
            testOutputHelper.WriteLine("GetVersionRevision: {0}", Cv2.GetVersionRevision());
        }

        [Fact]
        public void GetTickCount()
        {
            testOutputHelper.WriteLine("GetTickCount: {0}", Cv2.GetTickCount());
        }

        [Fact]
        public void GetTickFrequency()
        {
            testOutputHelper.WriteLine("GetTickFrequency: {0}", Cv2.GetTickFrequency());
        }

        [Fact]
        public void GetCpuTickCount()
        {
            testOutputHelper.WriteLine("GetCpuTickCount: {0}", Cv2.GetCpuTickCount());
        }

        [Fact]
        public void CheckHardwareSupport()
        {
            var features = (CpuFeatures[])Enum.GetValues(typeof(CpuFeatures));

            foreach (var feature in features)
            {
                testOutputHelper.WriteLine("CPU Feature '{0}': {1}", feature, Cv2.CheckHardwareSupport(feature));
            }
        }

        [Fact]
        public void GetHardwareFeatureName()
        {
            testOutputHelper.WriteLine(Cv2.GetHardwareFeatureName(0));
        }

        [Fact]
        public void GetCpuFeaturesLine()
        {
            Assert.NotEmpty(Cv2.GetCpuFeaturesLine());
            testOutputHelper.WriteLine("GetCpuFeaturesLine: {0}", Cv2.GetCpuFeaturesLine());
        }

        [Fact]
        // ReSharper disable once IdentifierTypo
        public void GetNumberOfCpus()
        {
            Assert.True(1 <= Cv2.GetNumberOfCpus());
        }

        [Theory]
        [InlineData(FormatType.Default)]
        [InlineData(FormatType.MATLAB)]
        [InlineData(FormatType.CSV)]
        [InlineData(FormatType.Python)]
        [InlineData(FormatType.NumPy)]
        [InlineData(FormatType.C)]
        public void Format(FormatType format)
        {
            using (var mat = new Mat(3, 3, MatType.CV_8UC1, new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9}))
            {
                var result = Cv2.Format(mat, format);
                Assert.NotEmpty(result);
                testOutputHelper.WriteLine("Format: {0}", format);
                testOutputHelper.WriteLine(result);
            }
        }

        [Theory]
        [InlineData(FormatType.Default)]
        [InlineData(FormatType.MATLAB)]
        [InlineData(FormatType.CSV)]
        [InlineData(FormatType.Python)]
        [InlineData(FormatType.NumPy)]
        [InlineData(FormatType.C)]
        public void Dump(FormatType format)
        {
            using (var mat = new Mat(3, 3, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }))
            {
                var result = mat.Dump(format);
                Assert.NotEmpty(result);
                Assert.Equal(Cv2.Format(mat, format), result);
                testOutputHelper.WriteLine("Dump: {0}", format);
                testOutputHelper.WriteLine(result);
            }
        }

        [Fact]
        public void Add()
        {
            using (Mat src1 = new Mat(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 }))
            using (Mat src2 = new Mat(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 }))
            using (Mat dst = new Mat())
            {
                Cv2.Add(src1, src2, dst);

                Assert.Equal(MatType.CV_8UC1, dst.Type());
                Assert.Equal(2, dst.Rows);
                Assert.Equal(2, dst.Cols);

                Assert.Equal(2, dst.At<byte>(0, 0));
                Assert.Equal(4, dst.At<byte>(0, 1));
                Assert.Equal(6, dst.At<byte>(1, 0));
                Assert.Equal(8, dst.At<byte>(1, 1));
            }
        }

        [Fact]
        public void AddScalar()
        {
            using (Mat src = new Mat(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 }))
            using (Mat dst = new Mat())
            {
                Cv2.Add(new Scalar(10), src, dst);

                Assert.Equal(MatType.CV_8UC1, dst.Type());
                Assert.Equal(2, dst.Rows);
                Assert.Equal(2, dst.Cols);

                Assert.Equal(11, dst.At<byte>(0, 0));
                Assert.Equal(12, dst.At<byte>(0, 1));
                Assert.Equal(13, dst.At<byte>(1, 0));
                Assert.Equal(14, dst.At<byte>(1, 1));

                Cv2.Add(src, new Scalar(10), dst);
                Assert.Equal(11, dst.At<byte>(0, 0));
                Assert.Equal(12, dst.At<byte>(0, 1));
                Assert.Equal(13, dst.At<byte>(1, 0));
                Assert.Equal(14, dst.At<byte>(1, 1));

                Cv2.Add(src, InputArray.Create(10.0), dst);
                Assert.Equal(11, dst.At<byte>(0, 0));
                Assert.Equal(12, dst.At<byte>(0, 1));
                Assert.Equal(13, dst.At<byte>(1, 0));
                Assert.Equal(14, dst.At<byte>(1, 1));
            }
        }

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
        public void SubtractScalar()
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
        public void ScalarOperations()
        {
            var values = new[] { -1f };
            using (var mat = new Mat(1, 1, MatType.CV_32FC1, values))
            {
                Assert.Equal(values[0], mat.Get<float>(0, 0));

                Cv2.Subtract(mat, 1, mat);
                Assert.Equal(-2, mat.Get<float>(0, 0));

                Cv2.Multiply(mat, 2.0, mat);
                Assert.Equal(-4, mat.Get<float>(0, 0));

                Cv2.Divide(mat, 2.0, mat);
                Assert.Equal(-2, mat.Get<float>(0, 0));

                Cv2.Add(mat, 1, mat);
                Assert.Equal(-1, mat.Get<float>(0, 0));
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

                int[] minIdx = new int[2];
                int[] maxIdx = new int[2];
                Cv2.MinMaxIdx(ones, out var minVal, out var maxVal, minIdx, maxIdx);

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

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void PSNR()
        {
            using var img1 = Image("lenna.png");
            using var img2 = new Mat();
            Cv2.GaussianBlur(img1, img2, new Size(5, 5), 10);

            var psnr = Cv2.PSNR(img1, img2);

            Assert.Equal(29, psnr, 0);
        }
    }
}

