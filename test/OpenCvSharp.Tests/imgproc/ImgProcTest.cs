using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Xunit;

namespace OpenCvSharp.Tests.ImgProc
{
    public class ImgProcTest : TestBase
    {
        [Fact]
        public void MorphologyExDilate()
        {
            using Mat src = new Mat(100, 100, MatType.CV_8UC1, 255);
            using Mat dst = new Mat();
            Cv2.Rectangle(src, new Rect(30, 30, 40, 40), Scalar.Black, 1);
            Cv2.MorphologyEx(src, dst, MorphTypes.Dilate, null);

            ShowImagesWhenDebugMode(src, dst);

            Assert.Equal(src.Rows * src.Cols, Cv2.CountNonZero(dst));
        }

        [Fact]
        public void MorphologyExErode()
        {
            using Mat src = Mat.Zeros(100, 100, MatType.CV_8UC1);
            using Mat dst = new Mat();
            Cv2.Rectangle(src, new Rect(30, 30, 40, 40), Scalar.White, 1);
            Cv2.MorphologyEx(src, dst, MorphTypes.Erode, null);

            ShowImagesWhenDebugMode(src, dst);

            Assert.Equal(0, Cv2.CountNonZero(dst));
        }

        [Fact]
        public void WarpAffine()
        {
            using var src = new Mat(new Size(1024, 768), MatType.CV_8UC4);

            using var matrix = new Mat(new Size(3, 2), MatType.CV_64FC1);
            matrix.Set<double>(0, 0, 1);
            matrix.Set<double>(1, 1, 1);

            using var dst = new Mat();
            Cv2.WarpAffine(src, dst, matrix, src.Size());
        }        
        
        // TODO
        [Fact(Skip = "fails with exception")]
        public void WarpAffineBigImage()
        {
            using var src = new Mat(new Size(8192, 10), MatType.CV_8UC4);

            using var matrix = new Mat(new Size(3, 2), MatType.CV_64FC1);
            matrix.Set<double>(0, 0, 1);
            matrix.Set<double>(1, 1, 1);

            using var dst = new Mat();
            Cv2.WarpAffine(src, dst, matrix, src.Size()); // fails with exception
        }

        [Fact]
        public void BlendLinear()
        {
            using var src1 = Image("tsukuba_left.png");
            using var src2 = Image("tsukuba_right.png");
            using var weights = new Mat(src1.Size(), MatType.CV_32FC1, Scalar.All(0.5));
            using var dst = new Mat();

            Assert.Equal(src1.Size(), src2.Size());

            Cv2.BlendLinear(src1, src2, weights, weights, dst);

            ShowImagesWhenDebugMode(src1, src2, dst);
        }

        [Fact]
        public void Demosaicing()
        {
            using var src = Image("lenna.png", ImreadModes.Grayscale);
            using var dst = new Mat();
            Cv2.Demosaicing(src, dst, ColorConversionCodes.BayerBG2GRAY);

            ShowImagesWhenDebugMode(src, dst);
        }

        [Fact]
        public void ArcLength()
        {
            var arc = new[] { new Point2f(0, 0), new Point2f(10, 0), new Point2f(10, 10), new Point2f(0, 10), };
            var length1 = Cv2.ArcLength(arc, true);
            Assert.Equal(40, length1);

            var length2 = Cv2.ArcLength(arc, false);
            Assert.Equal(30, length2);
        }

        [Fact]
        public void BoundingRect()
        {
            var points = new[] { new Point(0, 0), new Point(10, 10), new Point(5, 5), };
            var rect1 = Cv2.BoundingRect(points);
            Assert.Equal(new Rect(0, 0, 11, 11), rect1);

            var floatPoints = new[] { new Point2f(0, 0), new Point2f(10, 10), new Point2f(5, 5), };
            var rect2 = Cv2.BoundingRect(floatPoints);
            Assert.Equal(new Rect(0, 0, 11, 11), rect2);
        }

        [Fact]
        public void ContourArea()
        {
            var contour = new[] { new Point2f(0, 0), new Point2f(10, 0), new Point2f(10, 10), new Point2f(0, 10), };
            var area = Cv2.ContourArea(contour);
            Assert.Equal(100, area);
        }

        [Fact]
        public void BoxPoints()
        {
            var rotatedRect = new RotatedRect(new Point2f(10, 10), new Size2f(10, 10), (float)(Math.PI / 4));
            var points = Cv2.BoxPoints(rotatedRect);

            Assert.Equal(4, points.Length);
            Assert.Equal(4.932f, points[0].X, 3);
            Assert.Equal(14.931f, points[0].Y, 3);
            Assert.Equal(5.069f, points[1].X, 3);
            Assert.Equal(4.932f, points[1].Y, 3);
            Assert.Equal(15.068f, points[2].X, 3);
            Assert.Equal(5.069f, points[2].Y, 3);
            Assert.Equal(14.931f, points[3].X, 3);
            Assert.Equal(15.068f, points[3].Y, 3);
        }

        [Fact]
        public void MinEnclosingCircle()
        {
            var points = new[] { new Point2f(0, 0), new Point2f(10, 0), new Point2f(10, 10), new Point2f(0, 10), };
            Cv2.MinEnclosingCircle(points, out var center, out var radius);

            Assert.Equal(5f, center.X, 3);
            Assert.Equal(5f, center.Y, 3);
            Assert.Equal(5 * Math.Sqrt(2), radius, 3);
        }

        [Fact]
        public void MinEnclosingTriangle()
        {
            var points = new[] { new Point2f(0, 0), new Point2f(10, 0), new Point2f(10, 10), new Point2f(0, 10), };
            var area = Cv2.MinEnclosingTriangle(points, out var triangle);

            Assert.Equal(3, triangle.Length);
            Assert.Equal(0f, triangle[0].X, 3);
            Assert.Equal(-10f, triangle[0].Y, 3);
            Assert.Equal(0f, triangle[1].X, 3);
            Assert.Equal(10f, triangle[1].Y, 3);
            Assert.Equal(20f, triangle[2].X, 3);
            Assert.Equal(10f, triangle[2].Y, 3);

            Assert.Equal(200f, area, 3);
        }

        [Fact]
        public void ConvexHull()
        {
            var contour = new[]
            {
                // ‰š
                new Point(0, 0),
                new Point(0, 10),
                new Point(3, 10),
                new Point(3, 5),
                new Point(6, 5),
                new Point(6, 10),
                new Point(10, 10),
                new Point(10, 0),
            };
            var hull = Cv2.ConvexHull(contour);

            Assert.Equal(4, hull.Length);
            Assert.Equal(new Point(10, 0), hull[0]);
            Assert.Equal(new Point(10, 10), hull[1]);
            Assert.Equal(new Point(0, 10), hull[2]);
            Assert.Equal(new Point(0, 0), hull[3]);
        }

        [Fact]
        public void ConvexHullIndices()
        {
            var contour = new[]
            {
                // ‰š
                new Point(0, 0),
                new Point(0, 10),
                new Point(3, 10),
                new Point(3, 5),
                new Point(6, 5),
                new Point(6, 10),
                new Point(10, 10),
                new Point(10, 0),
            };
            var hull = Cv2.ConvexHullIndices(contour);

            Assert.Equal(4, hull.Length);
            Assert.Equal(new[] { 7, 6, 1, 0 }, hull);
        }

        [Fact]
        public void ConvexityDefects()
        {
            var contour = new[]
            {
                // ‰š
                new Point(0, 0),
                new Point(0, 10),
                new Point(3, 10),
                new Point(3, 5),
                new Point(6, 5),
                new Point(6, 10),
                new Point(10, 10),
                new Point(10, 0),
            };
            var convexHull = Cv2.ConvexHullIndices(contour);
            Assert.Equal(4, convexHull.Length);

            // Note: ConvexityDefects does not support Point2f contour
            var convexityDefects = Cv2.ConvexityDefects(contour, convexHull);

            Assert.Single(convexityDefects);
            Assert.Equal(new Vec4i(1, 6, 3, 1280), convexityDefects[0]);
        }

        [Fact]
        public void IsContourConvex()
        {
            var contour1 = new[]
            {
                // ‰š
                new Point(0, 0),
                new Point(0, 10),
                new Point(3, 10),
                new Point(3, 5),
                new Point(6, 5),
                new Point(6, 10),
                new Point(10, 10),
                new Point(10, 0),
            };
            Assert.False(Cv2.IsContourConvex(contour1));

            var contour2 = new[]
            {
                new Point2f(0, 0),
                new Point2f(10, 0),
                new Point2f(10, 10),
                new Point2f(0, 10),
            };
            Assert.True(Cv2.IsContourConvex(contour2));
        }

        [Fact]
        public void FitEllipse()
        {
            var contour = new[]
            {
                new Point2f(0, 0),
                new Point2f(10, 0),
                new Point2f(10, 10),
                new Point2f(5, 15),
                new Point2f(0, 10),
            };
            var ellipse = new[]
            {
                Cv2.FitEllipse(contour),
                Cv2.FitEllipseAMS(contour),
                Cv2.FitEllipseDirect(contour)
            };

            foreach (var e in ellipse)
            {
                Assert.Equal(5f, e.Center.X, 3);
                Assert.Equal(5f, e.Center.Y, 3);
                Assert.Equal(11.547f, e.Size.Width, 3);
                Assert.Equal(20f, e.Size.Height, 3);
                Assert.Equal(0f, e.Angle, 3);
            }
        }

        [Fact]
        public void FitLine()
        {
            var contour = new[]
            {
                new Point2f(0, 0),
                new Point2f(10, 10),
                new Point2f(5, 5),
            };
            var line = Cv2.FitLine(contour, DistanceTypes.L2, 0, 0, 0.01);

            Assert.Equal(5.0, line.X1, 3);
            Assert.Equal(5.0, line.Y1, 3);
            Assert.Equal(Math.Sqrt(2) / 2, line.Vx, 3);
            Assert.Equal(Math.Sqrt(2) / 2, line.Vy, 3);
        }

        [Fact]
        public void PointPolygonTest()
        {
            var contour = new[]
            {
                new Point2f(0, 0),
                new Point2f(10, 0),
                new Point2f(10, 10),
                new Point2f(0, 10),
            };
            var dist = Cv2.PointPolygonTest(contour, new Point2f(5, 5), false);
            Assert.Equal(1, dist, 3);

            dist = Cv2.PointPolygonTest(contour, new Point2f(0, 5), false);
            Assert.Equal(0, dist, 3);

            dist = Cv2.PointPolygonTest(contour, new Point2f(100, 100), false);
            Assert.Equal(-1, dist, 3);

            dist = Cv2.PointPolygonTest(contour, new Point2f(5, 5), true);
            Assert.Equal(5, dist, 3);
        }

        [Fact]
        public void RotatedRectangleIntersectionOutputArray()
        {
            var rr1 = new RotatedRect(new Point2f(10, 10), new Size2f(10, 10), 45);
            var rr2 = new RotatedRect(new Point2f(15, 10), new Size2f(10, 10), 0);
            using var intersectingRegion = new Mat();
            Cv2.RotatedRectangleIntersection(rr1, rr2, intersectingRegion);
            Assert.Equal(5, intersectingRegion.Rows);
            Assert.Equal(1, intersectingRegion.Cols);
            Assert.Equal(MatType.CV_32FC2, intersectingRegion.Type());
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

                using var img = new Mat(200, 200, MatType.CV_8UC3, 0);
                img.Polylines(new[] { ToPoints(rr1.Points()) }, true, Scalar.Red);
                img.Polylines(new[] { ToPoints(rr2.Points()) }, true, Scalar.Green);
                img.Polylines(new[] { ToPoints(intersectingRegion) }, true, Scalar.White);

                Window.ShowImages(img);
            }
        }

        [Fact]
        public void Rectangle()
        {
            var color = Scalar.Red;

            using Mat img1 = Mat.Zeros(100, 100, MatType.CV_8UC3);
            using Mat img2 = img1.Clone();
            using Mat img3 = img1.Clone();
            using Mat img4 = img1.Clone();
            using InputOutputArray ioa3 = InputOutputArray.Create(img3);
            using InputOutputArray ioa4 = InputOutputArray.Create(img4);

            Cv2.Rectangle(img1, new Rect(10, 10, 80, 80), color, 1);
            Cv2.Rectangle(img2, new Point(10, 10), new Point(89, 89), color, 1);
            Cv2.Rectangle(ioa3, new Rect(10, 10, 80, 80), color, 1);
            Cv2.Rectangle(ioa4, new Point(10, 10), new Point(89, 89), color, 1);

            ShowImagesWhenDebugMode(img1, img2);

            var colorVec = color.ToVec3b();
            var expected = new Vec3b[100, 100];
            for (int x = 10; x <= 89; x++)
            {
                expected[10, x] = colorVec;
                expected[89, x] = colorVec;
            }
            for (int y = 10; y <= 89; y++)
            {
                expected[y, 10] = colorVec;
                expected[y, 89] = colorVec;
            }

            TestImage(img1, expected);
            TestImage(img2, expected);
            TestImage(img3, expected);
            TestImage(img4, expected);
        }

        [Fact]
        public void RectangleShift()
        {
            using var mat = new Mat(300, 300, MatType.CV_8UC3, Scalar.All(0));
            Cv2.Rectangle(mat, new Rect(10, 20, 100, 200), Scalar.Red, -1, LineTypes.Link8, 0);
            Cv2.Rectangle(mat, new Rect(10, 20, 100, 200), Scalar.Green, -1, LineTypes.Link8, 1);
            Cv2.Rectangle(mat, new Rect(10, 20, 100, 200), Scalar.Blue, -1, LineTypes.Link8, 2);

            ShowImagesWhenDebugMode(mat);
        }

        [Fact]
        public void RectangleFilled()
        {
            var color = Scalar.Red;

            using Mat img = Mat.Zeros(100, 100, MatType.CV_8UC3);
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

        private static void TestImage(Mat img, Vec3b[,] expected)
        {
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (expected == null)
                throw new ArgumentNullException(nameof(expected));
            
            if (img.Type() != MatType.CV_8UC3)
                throw new ArgumentException("Mat.Type() != 8UC3", nameof(img));

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
                        // ReSharper disable once UseStringInterpolation
                        string.Format(CultureInfo.InvariantCulture, "difference at (x:{0}, y:{1})\nexpected:\t{2}\nactual:\t{3}\n",
                            x,
                            y,
                            $"(B:{expectedValue.Item0} G:{expectedValue.Item1} R:{expectedValue.Item2})",
                            $"(B:{actualValue.Item0} G:{actualValue.Item1} R:{actualValue.Item2})"));
                }
            }
        }

        [Fact]
        public void ApplyColorMap()
        {
            using var src = Image("building.jpg", ImreadModes.Color);
            using var dst = new Mat();
            Cv2.ApplyColorMap(src, dst, ColormapTypes.Cool);

            ShowImagesWhenDebugMode(src, dst);

            using var userColor = new Mat(256, 1, MatType.CV_8UC3, Scalar.All(128));
            Cv2.ApplyColorMap(src, dst, userColor);

            ShowImagesWhenDebugMode(src, dst);
        }
        
        [Fact]
        public void CornerHarris()
        {
            using var src = Image("building.jpg", ImreadModes.Grayscale);
            using var corners = new Mat();
            using var dst = new Mat();
            Cv2.CornerHarris(src, corners, 2, 3, 0.04);

            if (Debugger.IsAttached)
            {
                Cv2.Normalize(corners, corners, 0, 255, NormTypes.MinMax);
                Cv2.Threshold(corners, dst, 180, 255, ThresholdTypes.Binary);
                Window.ShowImages(src, corners, dst);
            }
        }

        [Fact]
        public void CornerMinEigenVal()
        {
            using var src = Image("building.jpg", ImreadModes.Grayscale);
            using var corners = new Mat();
            using var dst = new Mat();
            Cv2.CornerMinEigenVal(src, corners, 2, 3, BorderTypes.Reflect);

            if (Debugger.IsAttached)
            {
                Cv2.Normalize(corners, corners, 0, 255, NormTypes.MinMax);
                Cv2.Threshold(corners, dst, 180, 255, ThresholdTypes.Binary);
                Window.ShowImages(src, corners, dst);
            }
        }

        [Fact]
        public void FindContours()
        {
            using var src = Image("markers_6x6_250.png", ImreadModes.Grayscale);
            Cv2.BitwiseNot(src, src);
            Cv2.FindContours(
                src, 
                out var contours,
                out var hierarchy, 
                RetrievalModes.External,
                ContourApproximationModes.ApproxSimple);

            Assert.NotEmpty(contours);
            Assert.NotEmpty(hierarchy);

            Assert.All(contours, contour =>
            {
                Assert.Equal(4, contour.Length);
            });

            if (Debugger.IsAttached)
            {
                using var view = new Mat(src.Size(), MatType.CV_8UC3, Scalar.All(0));
                Cv2.DrawContours(view, contours, -1, Scalar.Red);
                Window.ShowImages(src, view);
            }
        }
    }
}

