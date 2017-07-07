using System;
using System.Diagnostics;
using NUnit.Framework;

namespace OpenCvSharp.Tests.ImgProc
{
    [TestFixture]
    public class ImgProcTest : TestBase
    {
        [Test]
        public void MorphorogyExErode()
        {
            using (Mat src = Mat.Zeros(100, 100, MatType.CV_8UC1))
            using (Mat dst = new Mat())
            {
                Cv2.Rectangle(src, new Rect(30, 30, 40, 40), Scalar.White, 1);
                Cv2.MorphologyEx(src, dst, MorphTypes.Erode, null);

                ShowImagesWhenDebugMode(src, dst);

                Assert.Zero(Cv2.CountNonZero(dst));
            }
        }

        [Test]
        public void MorphorogyExDilate()
        {
            using (Mat src = new Mat(100, 100, MatType.CV_8UC1, 255))
            using (Mat dst = new Mat())
            {
                Cv2.Rectangle(src, new Rect(30, 30, 40, 40), Scalar.Black, 1);
                Cv2.MorphologyEx(src, dst, MorphTypes.Dilate, null);

                ShowImagesWhenDebugMode(src, dst);

                Assert.AreEqual(src.Rows * src.Cols, Cv2.CountNonZero(dst));
            }
        }

        [Test]
        public void Rectangle()
        {
            var color = Scalar.Red;

            using (Mat img = Mat.Zeros(100, 100, MatType.CV_8UC3))
            {
                img.Rectangle(new Rect(10, 10, 80, 80), color, 1);

                ShowImagesWhenDebugMode(img);

                var colorVec = color.ToVec3b();
                var expected = new Vec3b[100, 100];
                for (int x = 10; x < 90; x++)
                {
                    expected[10, x] = colorVec;
                    expected[89, x] = colorVec;
                }
                for (int y = 10; y < 90; y++)
                {
                    expected[y, 10] = colorVec;
                    expected[y, 89] = colorVec;
                }

                TestImage(img, expected);
            }
        }

        [Test]
        public void RectangleFilled()
        {
            var color = Scalar.Red;

            using (Mat img = Mat.Zeros(100, 100, MatType.CV_8UC3))
            {
                img.Rectangle(new Rect(10, 10, 80, 80), color, Cv2.FILLED/*-1*/);

                if (Debugger.IsAttached)
                {
                    Window.ShowImages(img);
                }

                var colorVec = color.ToVec3b();
                var expected = new Vec3b[100, 100];
                for (int y = 10; y < 90; y++)
                {
                    for (int x = 10; x < 90; x++)
                    {
                        expected[y, x] = colorVec;
                    }
                }

                TestImage(img, expected);
            }
        }

        private static void TestImage(Mat img, Vec3b[,] expected)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (expected == null)
                throw new ArgumentNullException(nameof(expected));
            
            int height = img.Rows;
            int width = img.Cols;
            if (height != expected.GetLength(0) || width != expected.GetLength(1))
                throw new ArgumentException("size mismatch");

            var indexer = img.GetGenericIndexer<Vec3b>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var expectedValue = expected[y, x];
                    var actualValue = indexer[y, x];
                    Assert.AreEqual(
                        expectedValue,
                        actualValue,
                        "difference at (x:{0}, y:{1})\nexpected:\t{2}\nactual:\t{3}\n",
                        x,
                        y,
                        $"(B:{expectedValue.Item0} G:{expectedValue.Item1} R:{expectedValue.Item2})",
                        $"(B:{actualValue.Item0} G:{actualValue.Item1} R:{actualValue.Item2})");
                }
            }
        }
    }
}

