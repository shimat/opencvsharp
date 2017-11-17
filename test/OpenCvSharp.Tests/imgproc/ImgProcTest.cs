using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace OpenCvSharp.Tests.ImgProc
{
    public class ImgProcTest : TestBase
    {
        [Fact]
        public void MorphorogyExErode()
        {
            using (Mat src = Mat.Zeros(100, 100, MatType.CV_8UC1))
            using (Mat dst = new Mat())
            {
                Cv2.Rectangle(src, new Rect(30, 30, 40, 40), Scalar.White, 1);
                Cv2.MorphologyEx(src, dst, MorphTypes.Erode, null);

                ShowImagesWhenDebugMode(src, dst);

                Assert.Equal(0, Cv2.CountNonZero(dst));
            }
        }

        [Fact]
        public void MorphorogyExDilate()
        {
            using (Mat src = new Mat(100, 100, MatType.CV_8UC1, 255))
            using (Mat dst = new Mat())
            {
                Cv2.Rectangle(src, new Rect(30, 30, 40, 40), Scalar.Black, 1);
                Cv2.MorphologyEx(src, dst, MorphTypes.Dilate, null);

                ShowImagesWhenDebugMode(src, dst);

                Assert.Equal(src.Rows * src.Cols, Cv2.CountNonZero(dst));
            }
        }

        [Fact]
        public void RotatedRectangleIntersectionOutputArray()
        {
            var rr1 = new RotatedRect(new Point2f(10, 10), new Size2f(10, 10), 45);
            var rr2 = new RotatedRect(new Point2f(15, 10), new Size2f(10, 10), 0);
            using (var intersectingRegion = new Mat())
            {
                Cv2.RotatedRectangleIntersection(rr1, rr2, intersectingRegion);
                Assert.Equal(5, intersectingRegion.Rows);
                Assert.Equal(1, intersectingRegion.Cols);
                Assert.Equal(MatType.CV_32FC2, intersectingRegion.Type());
            }
        }

        [Fact]
        public void RotatedRectangleIntersectionVector()
        {
            var rr1 = new RotatedRect(new Point2f(100, 100), new Size2f(100, 100), 45);
            var rr2 = new RotatedRect(new Point2f(130, 100), new Size2f(100, 100), 0);

            Cv2.RotatedRectangleIntersection(rr1, rr2, out var intersectingRegion);

            if (Debugger.IsAttached)
            {
                Point[] ToPoints(IEnumerable<Point2f> enumerable)
                {
                    return enumerable.Select(p => new Point(p.X, p.Y)).ToArray();
                }

                using (var img = new Mat(200, 200, MatType.CV_8UC3, 0))
                {
                    img.Polylines(new[] { ToPoints(rr1.Points()) }, true, Scalar.Red);
                    img.Polylines(new[] { ToPoints(rr2.Points()) }, true, Scalar.Green);
                    img.Polylines(new[] { ToPoints(intersectingRegion) }, true, Scalar.White);

                    Window.ShowImages(img);
                }
            }

            intersectingRegion.ToString();
        }

        [Fact]
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

        [Fact]
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
                    Assert.True(
                        expectedValue == actualValue,
                        String.Format("difference at (x:{0}, y:{1})\nexpected:\t{2}\nactual:\t{3}\n",
                            x,
                            y,
                            $"(B:{expectedValue.Item0} G:{expectedValue.Item1} R:{expectedValue.Item2})",
                            $"(B:{actualValue.Item0} G:{actualValue.Item1} R:{actualValue.Item2})"));
                }
            }
        }
    }
}

