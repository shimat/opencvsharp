using System.Diagnostics;
using System.Globalization;
using OpenCvSharp.Internal.Vectors;
using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

public class ImgProcTest : TestBase
{
    private static readonly int[] SingleChannelIndex = { 0 };
    private static readonly int[] GrayscaleHistSize = { 256 };
    private static readonly int[] SquareContourPoints = { 0, 0, 10, 0, 10, 10, 0, 10 };

    [Fact]
    public void BuildPyramidTest()
    {
        using var src = LoadImage("lenna.png");
        using var dst = new VectorOfMat();
        Cv2.BuildPyramid(src, dst, 2);
        Assert.Equal(3, dst.Size);
    }

    [Fact]
    public void MorphologyExDilate()
    {
        using var src = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(255));
        using var dst = new Mat();
        Cv2.Rectangle(src, new Rect(30, 30, 40, 40), Scalar.Black, 1);
        Cv2.MorphologyEx(src, dst, MorphTypes.Dilate, default);

        ShowImagesWhenDebugMode(src, dst);

        Assert.Equal(src.Rows * src.Cols, Cv2.CountNonZero(dst));
    }

    [Fact]
    public void MorphologyExErode()
    {
        using var src = Mat.ZerosMat(100, 100, MatType.CV_8UC1);
        using var dst = new Mat();
        Cv2.Rectangle(src, new Rect(30, 30, 40, 40), Scalar.White, 1);
        Cv2.MorphologyEx(src, dst, MorphTypes.Erode, default);

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
        using var src1 = LoadImage("tsukuba_left.png");
        using var src2 = LoadImage("tsukuba_right.png");
        using var weights = new Mat(src1.Size(), MatType.CV_32FC1, Scalar.All(0.5));
        using var dst = new Mat();

        Assert.Equal(src1.Size(), src2.Size());

        Cv2.BlendLinear(src1, src2, weights, weights, dst);

        ShowImagesWhenDebugMode(src1, src2, dst);
    }

    [Fact]
    public void Demosaicing()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
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
        Assert.Equal(4.932f, points[0].X, 1e-3);
        Assert.Equal(14.931f, points[0].Y, 1e-3);
        Assert.Equal(5.069f, points[1].X, 1e-3);
        Assert.Equal(4.932f, points[1].Y, 1e-3);
        Assert.Equal(15.068f, points[2].X, 1e-3);
        Assert.Equal(5.069f, points[2].Y, 1e-3);
        Assert.Equal(14.931f, points[3].X, 1e-3);
        Assert.Equal(15.068f, points[3].Y, 1e-3);
    }

    [Fact]
    public void MinEnclosingCircle()
    {
        var points = new[] { new Point2f(0, 0), new Point2f(10, 0), new Point2f(10, 10), new Point2f(0, 10), };
        Cv2.MinEnclosingCircle(points, out var center, out var radius);

        Assert.Equal(5f, center.X, 1e-3);
        Assert.Equal(5f, center.Y, 1e-3);
        Assert.Equal(5 * Math.Sqrt(2), radius, 3);
    }

    [Fact]
    public void MinEnclosingTriangle()
    {
        var points = new[] { new Point2f(0, 0), new Point2f(10, 0), new Point2f(10, 10), new Point2f(0, 10), };
        var area = Cv2.MinEnclosingTriangle(points, out var triangle);

        Assert.Equal(3, triangle.Length);
        Assert.Equal(0f, triangle[0].X, 1e-3);
        Assert.Equal(-10f, triangle[0].Y, 1e-3);
        Assert.Equal(0f, triangle[1].X, 1e-3);
        Assert.Equal(10f, triangle[1].Y, 1e-3);
        Assert.Equal(20f, triangle[2].X, 1e-3);
        Assert.Equal(10f, triangle[2].Y, 1e-3);

        Assert.Equal(200f, area, 3);
    }

    [Fact]
    public void ConvexHull()
    {
        var contour = new[]
        {
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
        Assert.Equal([7, 6, 1, 0], hull);
    }

    [Fact]
    public void ConvexityDefects()
    {
        var contour = new[]
        {
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
        var ellipse = Cv2.FitEllipse(contour);

        Assert.Equal(5f, ellipse.Center.X, 1e-3);
        Assert.Equal(5f, ellipse.Center.Y, 1e-3);
        Assert.Equal(11.547f, ellipse.Size.Width, 1e-3);
        Assert.Equal(20f, ellipse.Size.Height, 1e-3);

        var angleError = Math.Min(Math.Abs(ellipse.Angle), Math.Abs(ellipse.Angle - 180f));
        Assert.True(angleError < 2e-1, $"Angle should be close to 0 or 180 degrees, but was {ellipse.Angle}");
    }

    [Fact]
    public void FitEllipseAMS()
    {
        var contour = new[]
        {
            new Point2f(0, 0),
            new Point2f(10, 0),
            new Point2f(10, 10),
            new Point2f(5, 15),
            new Point2f(0, 10),
        };
        var ellipse = Cv2.FitEllipseAMS(contour);

        Assert.Equal(5f, ellipse.Center.X, 2e-1);
        Assert.Equal(5f, ellipse.Center.Y, 2e-1);
        Assert.Equal(11.547f, ellipse.Size.Width, 2e-1);
        Assert.Equal(20f, ellipse.Size.Height, 4e-1);

        var angleError = Math.Min(Math.Abs(ellipse.Angle), Math.Abs(ellipse.Angle - 180f));
        Assert.True(angleError < 1.0, $"Angle should be close to 0 or 180 degrees, but was {ellipse.Angle}");
    }

    [Fact]
    public void FitEllipseDirect()
    {
        var contour = new[]
        {
            new Point2f(0, 0),
            new Point2f(10, 0),
            new Point2f(10, 10),
            new Point2f(5, 15),
            new Point2f(0, 10),
        };
        var ellipse = Cv2.FitEllipseDirect(contour);

        Assert.Equal(5f, ellipse.Center.X, 1e-3);
        Assert.Equal(5f, ellipse.Center.Y, 1e-3);
        Assert.Equal(11.547f, ellipse.Size.Width, 1e-3);
        Assert.Equal(20f, ellipse.Size.Height, 1e-3);

        var angleError = Math.Min(Math.Abs(ellipse.Angle), Math.Abs(ellipse.Angle - 180f));
        Assert.True(angleError < 2e-1, $"Angle should be close to 0 or 180 degrees, but was {ellipse.Angle}");
    }

    [Fact]
    public void FitLineByPoint2f()
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
    public void FitLineByPoints()
    {
        var contour = new[]
        {
            new Point(0, 0),
            new Point(10, 10),
            new Point(5, 5),
        };
        var line = Cv2.FitLine(contour, DistanceTypes.L2, 0, 0, 0.01);

        Assert.Equal(5.0, line.X1, 3);
        Assert.Equal(5.0, line.Y1, 3);
        Assert.Equal(Math.Sqrt(2) / 2, line.Vx, 3);
        Assert.Equal(Math.Sqrt(2) / 2, line.Vy, 3);
    }

    [Fact]
    public void FitLineByMat()
    {
        var matTypes = new[]
        {
            (MatType.CV_32SC1, 2),
            (MatType.CV_32SC2, 1)
        };
        foreach (var (matType, cols) in matTypes)
        {
            var contour = new[]
            {
                new Point(0, 0),
                new Point(10, 10),
                new Point(5, 5),
            };
            using var src = Mat.FromPixelData(contour.Length, cols, matType, contour);
            using var dst = new Mat();
            Cv2.FitLine(src, dst, DistanceTypes.L2, 0, 0, 0.01);

            Assert.False(dst.Empty());
            Assert.Equal(MatType.CV_32FC1, dst.Type());
            Assert.Equal(new Size(1, 4), dst.Size());

            Assert.Equal(Math.Sqrt(2) / 2, dst.Get<float>(0), 3);
            Assert.Equal(Math.Sqrt(2) / 2, dst.Get<float>(1), 3);
            Assert.Equal(5, dst.Get<float>(2), 1e-3);
            Assert.Equal(5, dst.Get<float>(3), 1e-3);
        }
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
        // OpenCV 5 returns the intersecting region as a 1xN row vector instead of the
        // Nx1 column vector OpenCV 4 produced.
        Assert.Equal(1, intersectingRegion.Rows);
        Assert.Equal(5, intersectingRegion.Cols);
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
            static Point[] ToPoints(IEnumerable<Point2f> enumerable)
            {
                return enumerable.Select(p => new Point(p.X, p.Y)).ToArray();
            }

            using var img = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0));
            Cv2.Polylines(img, [ToPoints(rr1.Points())], true, Scalar.Red);
            Cv2.Polylines(img, [ToPoints(rr2.Points())], true, Scalar.Green);
            Cv2.Polylines(img, [ToPoints(intersectingRegion)], true, Scalar.White);

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

        Cv2.Rectangle(img1, new Rect(10, 10, 80, 80), color, 1);
        Cv2.Rectangle(img2, new Point(10, 10), new Point(89, 89), color, 1);
        Cv2.Rectangle(InputOutputArray.Create(img3), new Rect(10, 10, 80, 80), color, 1);
        Cv2.Rectangle(InputOutputArray.Create(img4), new Point(10, 10), new Point(89, 89), color, 1);

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
        Cv2.Rectangle(img, new Rect(10, 10, 80, 80), color, Cv2.FILLED/*-1*/);

        if (Debugger.IsAttached)
        {
            Window.ShowImages(img);
        }

        var colorVec = color.ToVec3b();
        var expected = new Vec3b[100, 100];
        for (var y = 10; y < 90; y++)
        {
            for (var x = 10; x < 90; x++)
            {
                expected[y, x] = colorVec;
            }
        }

        TestImage(img, expected);
    }

    private static void TestImage(Mat img, Vec3b[,] expected)
    {
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        if (expected is null)
            throw new ArgumentNullException(nameof(expected));

        if (img.Type() != MatType.CV_8UC3)
            throw new ArgumentException("Mat.Type() != 8UC3", nameof(img));

        var height = img.Rows;
        var width = img.Cols;
        if (height != expected.GetLength(0) || width != expected.GetLength(1))
            throw new ArgumentException("size mismatch");

        var rows = img.AsRows<Vec3b>();
        for (var y = 0; y < height; y++)
        {
            var row = rows[y];
            for (var x = 0; x < width; x++)
            {
                var expectedValue = expected[y, x];
                var actualValue = row[x];
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
        using var src = LoadImage("building.jpg", ImreadModes.Color);
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
        using var src = LoadImage("building.jpg", ImreadModes.Grayscale);
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
        using var src = LoadImage("building.jpg", ImreadModes.Grayscale);
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
        using var src = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
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

    [Fact]
    public void CalcHist()
    {
        using var src = new Mat(@"_data/image/mandrill.png", ImreadModes.Grayscale);

        using var hist = new Mat();
        Cv2.CalcHist(
            images: [src],
            channels: [0],
            mask: default,
            hist: hist,
            dims: 1,
            histSize: [256],
            ranges: new[] { new Rangef(0, 256) });

        if (Debugger.IsAttached)
        {
            const int histW = 512;
            const int histH = 400; 
            var binW = Math.Round((double)histW / 256);
            using var histImage = new Mat(histH, histW, MatType.CV_8UC3, Scalar.All(0));
            Cv2.Normalize(hist, hist, 0, histImage.Rows, NormTypes.MinMax, -1);

            for (var i = 0; i < 256; i++)
            {
                var pt1 = new Point2d(binW * (i - 1), histH - Math.Round(hist.At<float>(i - 1)));
                var pt2 = new Point2d(binW * (i), histH - Math.Round(hist.At<float>(i)));
                Cv2.Line(
                    histImage, (Point)pt1, (Point)pt2,
                    Scalar.Red, 1, LineTypes.Link8);
            }

            Window.ShowImages(src, histImage);
        }
    }

    [Fact]
    public void MatchTemplate()
    {
        using var src = new Mat("_data/image/qr_multi.png", ImreadModes.Grayscale);
        using var template = src[new Rect(33, 33, 235, 235)];

        using var result = new Mat();
        Cv2.MatchTemplate(src, template, result, TemplateMatchModes.CCoeffNormed);

        Assert.False(result.Empty());
        Assert.Equal(MatType.CV_32FC1, result.Type());
        Assert.Equal(src.Rows - template.Rows + 1, result.Rows);
        Assert.Equal(src.Cols - template.Cols + 1, result.Cols);

        Cv2.MinMaxLoc(result, out _, out Point maxLoc);
        Assert.Equal(new Point(33, 33), maxLoc);

        if (Debugger.IsAttached)
        {
            using var view = new Mat();
            Cv2.CvtColor(src, view, ColorConversionCodes.GRAY2BGR);
            Cv2.Rectangle(view, new Rect(maxLoc, template.Size()), Scalar.Red, 2);
                
            Window.ShowImages(view, result);
        }
    }

    [Fact]
    public void HoughLinesP()
    {
        using var src = new Mat("_data/image/houghp.png", ImreadModes.Grayscale);

        using var binary = new Mat();
        Cv2.Threshold(src, binary, 0, 255, ThresholdTypes.Otsu);

        var lines = Cv2.HoughLinesP(binary, 1, Cv2.PI / 180f, 50, 50, 10);
        Assert.NotEmpty(lines);

        if (Debugger.IsAttached)
        {
            using var view = new Mat();
            Cv2.CvtColor(src, view, ColorConversionCodes.GRAY2BGR);
            foreach (var line in lines)
            {
                Cv2.Line(view, line.P1, line.P2, Scalar.Red);
            }

            Window.ShowImages([src, binary, view], ["src", "binary", "lines"]);
        }
    }

    [Fact]
    public void HoughLinesPointSet()
    {
        Vec2f[] points =
        [
            new(0.0f, 369.0f),
            new(10.0f, 364.0f), 
            new(20.0f, 358.0f), 
            new(30.0f, 352.0f), 
            new(40.0f, 346.0f),
            new(50.0f, 341.0f), 
            new(60.0f, 335.0f), 
            new(70.0f, 329.0f), 
            new(80.0f, 323.0f),
            new(90.0f, 318.0f),
            new(100.0f, 312.0f), 
            new(110.0f, 306.0f), 
            new(120.0f, 300.0f), 
            new(130.0f, 295.0f),
            new(140.0f, 289.0f),
            new(150.0f, 284.0f),
            new(160.0f, 277.0f), 
            new(170.0f, 271.0f),
            new(180.0f, 266.0f),
            new(190.0f, 260.0f)
        ];

        const int
            linesMax = 20,
            threshold = 1;
        const double 
            rhoMin = 0.0f, 
            rhoMax = 360.0f, 
            rhoStep = 1,
            thetaMin = 0.0f,
            thetaMax = Cv2.PI / 2.0f, 
            thetaStep = Cv2.PI / 180.0f;

        using var pointsMat = new Mat(points.Length, 1, MatType.CV_32FC2);
        pointsMat.SetArray(points);
        using var linesMat = new Mat();
        Cv2.HoughLinesPointSet(pointsMat, linesMat, linesMax, threshold, rhoMin, rhoMax, rhoStep, thetaMin, thetaMax, thetaStep); 
        
        Assert.False(linesMat.Empty());
        Assert.Equal(MatType.CV_64FC3, linesMat.Type());
        
        Assert.True(linesMat.GetArray(out Vec3d[] lines));
        Assert.NotEmpty(lines);

        var (votes, rho, theta) = lines[0];
        Assert.True(votes > 10);
        Assert.Equal(320, rho, 6);
        Assert.Equal(1.0471975803375244, theta, 6);
    }

    [Fact]
    public void Integral()
    {
        using var ones = Mat.OnesMat(3, 3, MatType.CV_8UC1);
        using var sum = new Mat();

        Cv2.Integral(ones, sum);

        Assert.Equal(9, sum.At<byte>(3, 3));
        Assert.Equal(9, (int)Cv2.Sum(ones));
    }

    [Theory]
    [InlineData(InterpolationFlags.Nearest)]
    [InlineData(InterpolationFlags.Linear)]
    [InlineData(InterpolationFlags.Cubic)]
    [InlineData(InterpolationFlags.Lanczos4)]
    public void ResizeByteMat(InterpolationFlags flags) => ResizeCore<byte>(flags);
        
    [Theory]
    [InlineData(InterpolationFlags.Nearest)]
    [InlineData(InterpolationFlags.Linear)]
    [InlineData(InterpolationFlags.Cubic)]
    [InlineData(InterpolationFlags.Lanczos4)]
    public void ResizeFloatMat(InterpolationFlags flags) => ResizeCore<float>(flags);

    [Theory]
    [InlineData(InterpolationFlags.Nearest)]
    //[InlineData(InterpolationFlags.Linear)]
    //[InlineData(InterpolationFlags.Cubic)]
    //[InlineData(InterpolationFlags.Lanczos4)]
    public void ResizeInt32Mat(InterpolationFlags flags) => ResizeCore<int>(flags);

    [Theory]
    [InlineData(InterpolationFlags.Nearest)]
    [InlineData(InterpolationFlags.Linear)]
    [InlineData(InterpolationFlags.Cubic)]
    [InlineData(InterpolationFlags.Lanczos4)]
    public void ResizeUShortMat(InterpolationFlags flags) => ResizeCore<ushort>(flags);

    [Theory]
    [InlineData(InterpolationFlags.Nearest)]
    [InlineData(InterpolationFlags.Linear)]
    [InlineData(InterpolationFlags.Cubic)]
    [InlineData(InterpolationFlags.Lanczos4)]
    public void ResizeDoubleMat(InterpolationFlags flags) => ResizeCore<double>(flags);

    [Theory]
    [InlineData(InterpolationFlags.Nearest)]
    [InlineData(InterpolationFlags.Linear)]
    [InlineData(InterpolationFlags.Cubic)]
    [InlineData(InterpolationFlags.Lanczos4)]
    public void ResizeVec3bMat(InterpolationFlags flags) => ResizeCore<Vec3b>(flags);

    [Theory]
    [InlineData(InterpolationFlags.Nearest)]
    //[InlineData(InterpolationFlags.Linear)]
    //[InlineData(InterpolationFlags.Cubic)]
    //[InlineData(InterpolationFlags.Lanczos4)]
    public void ResizeVec4iMat(InterpolationFlags flags) => ResizeCore<Vec4i>(flags);

    [Theory]
    [InlineData(InterpolationFlags.Nearest)]
    [InlineData(InterpolationFlags.Linear)]
    [InlineData(InterpolationFlags.Cubic)]
    [InlineData(InterpolationFlags.Lanczos4)]
    public void ResizeVec6dMat(InterpolationFlags flags) => ResizeCore<Vec6d>(flags);

    private static void ResizeCore<T>(InterpolationFlags flags)
        where T : unmanaged
    {
        using var src = new Mat<T>(10, 10);
        using var dst = new Mat();
        Cv2.Resize(src, dst, default, 0.5, 0.5, flags);
        Assert.Equal(new Size(5, 5), dst.Size());
    }

    // --- ArrayProxy migration coverage (issue #1976): one test per migrated Cv2 method ---

    [Fact]
    public void Blur()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.Blur(src, dst, new Size(3, 3));

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(src.Type(), dst.Type());
    }

    [Fact]
    public void BoxFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.BoxFilter(src, dst, MatType.CV_8U, new Size(3, 3));

        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void SqrBoxFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.SqrBoxFilter(src, dst, (int)MatType.CV_32F, new Size(3, 3));

        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void BilateralFilter()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.BilateralFilter(src, dst, 9, 75, 75);

        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void Sobel()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.Sobel(src, dst, MatType.CV_16S, 1, 0);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(MatType.CV_16SC1, dst.Type());
    }

    [Fact]
    public void Scharr()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.Scharr(src, dst, MatType.CV_16S, 1, 0);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(MatType.CV_16SC1, dst.Type());
    }

    [Fact]
    public void Laplacian()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.Laplacian(src, dst, MatType.CV_16S);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(MatType.CV_16SC1, dst.Type());
    }

    [Fact]
    public void SepFilter2D()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var kernelX = Mat.FromPixelData(3, 1, MatType.CV_32FC1, new float[] { 1f / 3, 1f / 3, 1f / 3 });
        using var kernelY = Mat.FromPixelData(3, 1, MatType.CV_32FC1, new float[] { 1f / 3, 1f / 3, 1f / 3 });
        using var dst = new Mat();
        Cv2.SepFilter2D(src, dst, MatType.CV_8U, kernelX, kernelY);

        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void GetDerivKernels()
    {
        using var kx = new Mat();
        using var ky = new Mat();
        Cv2.GetDerivKernels(kx, ky, 1, 0, 3);

        Assert.Equal(3, kx.Total());
        Assert.Equal(3, ky.Total());
    }

    [Fact]
    public void SpatialGradient()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dx = new Mat();
        using var dy = new Mat();
        Cv2.SpatialGradient(src, dx, dy);

        Assert.Equal(src.Size(), dx.Size());
        Assert.Equal(MatType.CV_16SC1, dx.Type());
    }

    [Fact]
    public void PreCornerDetect()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.PreCornerDetect(src, dst, 3);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(MatType.CV_32FC1, dst.Type());
    }

    [Fact]
    public void CornerEigenValsAndVecs()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.CornerEigenValsAndVecs(src, dst, 3, 3);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(6, dst.Channels());
    }

    [Fact]
    public void PyrDown()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.PyrDown(src, dst);

        Assert.Equal((src.Cols + 1) / 2, dst.Cols);
        Assert.Equal((src.Rows + 1) / 2, dst.Rows);
    }

    [Fact]
    public void PyrUp()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.PyrUp(src, dst);

        Assert.Equal(src.Cols * 2, dst.Cols);
        Assert.Equal(src.Rows * 2, dst.Rows);
    }

    [Fact]
    public void PyrMeanShiftFiltering()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.PyrMeanShiftFiltering(src, dst, 10, 20);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(src.Type(), dst.Type());
    }

    [Fact]
    public void EqualizeHist()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.EqualizeHist(src, dst);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(MatType.CV_8UC1, dst.Type());
    }

    [Fact]
    public void AdaptiveThreshold()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.AdaptiveThreshold(src, dst, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, 11, 2);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(MatType.CV_8UC1, dst.Type());
    }

    [Fact]
    public void CvtColorTwoPlane()
    {
        using var y = new Mat(4, 4, MatType.CV_8UC1, Scalar.All(128));
        using var uv = new Mat(2, 2, MatType.CV_8UC2, Scalar.All(128));
        using var dst = new Mat();
        Cv2.CvtColorTwoPlane(y, uv, dst, ColorConversionCodes.YUV2BGR_NV12);

        Assert.Equal(y.Size(), dst.Size());
        Assert.Equal(3, dst.Channels());
    }

    [Fact]
    public void CreateHanningWindow()
    {
        using var dst = new Mat();
        Cv2.CreateHanningWindow(dst, new Size(8, 8), MatType.CV_32F);

        Assert.Equal(new Size(8, 8), dst.Size());
        Assert.Equal(MatType.CV_32FC1, dst.Type());
    }

    [Fact]
    public void ConvertMaps()
    {
        using var map1 = new Mat(4, 4, MatType.CV_32FC1, Scalar.All(1));
        using var map2 = new Mat(4, 4, MatType.CV_32FC1, Scalar.All(1));
        using var dstmap1 = new Mat();
        using var dstmap2 = new Mat();
        Cv2.ConvertMaps(map1, map2, dstmap1, dstmap2, MatType.CV_16SC2);

        Assert.Equal(map1.Size(), dstmap1.Size());
    }

    [Fact]
    public void GetRectSubPix()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var patch = new Mat();
        Cv2.GetRectSubPix(src, new Size(5, 5), new Point2f(10, 10), patch);

        Assert.Equal(new Size(5, 5), patch.Size());
    }

    [Fact]
    public void WarpPolar()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        Cv2.WarpPolar(src, dst, new Size(64, 64), new Point2f(src.Cols / 2f, src.Rows / 2f),
            src.Cols / 2.0, InterpolationFlags.Linear, WarpPolarMode.Linear);

        Assert.Equal(new Size(64, 64), dst.Size());
    }

    [Fact]
    public void Accumulate()
    {
        using var src = new Mat(2, 2, MatType.CV_8UC1, Scalar.All(5));
        using var dst = new Mat(2, 2, MatType.CV_32FC1, Scalar.All(0));
        using var mask = new Mat(2, 2, MatType.CV_8UC1, Scalar.All(255));
        Cv2.Accumulate(src, dst, mask);

        Assert.Equal(5.0, dst.At<float>(0, 0), 3);
    }

    [Fact]
    public void AccumulateSquare()
    {
        using var src = new Mat(2, 2, MatType.CV_8UC1, Scalar.All(5));
        using var dst = new Mat(2, 2, MatType.CV_32FC1, Scalar.All(0));
        using var mask = new Mat(2, 2, MatType.CV_8UC1, Scalar.All(255));
        Cv2.AccumulateSquare(src, dst, mask);

        Assert.Equal(25.0, dst.At<float>(0, 0), 3);
    }

    [Fact]
    public void AccumulateProduct()
    {
        using var src1 = new Mat(2, 2, MatType.CV_8UC1, Scalar.All(5));
        using var src2 = new Mat(2, 2, MatType.CV_8UC1, Scalar.All(2));
        using var dst = new Mat(2, 2, MatType.CV_32FC1, Scalar.All(0));
        using var mask = new Mat(2, 2, MatType.CV_8UC1, Scalar.All(255));
        Cv2.AccumulateProduct(src1, src2, dst, mask);

        Assert.Equal(10.0, dst.At<float>(0, 0), 3);
    }

    [Fact]
    public void AccumulateWeighted()
    {
        using var src = new Mat(2, 2, MatType.CV_8UC1, Scalar.All(10));
        using var dst = new Mat(2, 2, MatType.CV_32FC1, Scalar.All(0));
        using var mask = new Mat(2, 2, MatType.CV_8UC1, Scalar.All(255));
        Cv2.AccumulateWeighted(src, dst, 0.5, mask);

        Assert.Equal(5.0, dst.At<float>(0, 0), 3);
    }

    [Fact]
    public void ApproxPolyDP()
    {
        using var curve = Mat.FromPixelData(4, 1, MatType.CV_32FC2, new float[] { 0, 0, 10, 0, 10, 10, 0, 10 });
        using var approx = new Mat();
        Cv2.ApproxPolyDP(curve, approx, 1.0, true);

        Assert.Equal(4, approx.Total());
    }

    [Fact]
    public void ArrowedLine()
    {
        using var img = new Mat(50, 50, MatType.CV_8UC1, Scalar.All(0));
        Cv2.ArrowedLine(img, new Point(5, 5), new Point(40, 40), Scalar.All(255), 2);

        Assert.True(Cv2.CountNonZero(img) > 0);
    }

    [Fact]
    public void Circle()
    {
        using var img = new Mat(50, 50, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Circle(img, 25, 25, 10, Scalar.All(255), 2);

        Assert.True(Cv2.CountNonZero(img) > 0);
    }

    [Fact]
    public void Ellipse()
    {
        using var img = new Mat(50, 50, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Ellipse(img, new Point(25, 25), new Size(15, 10), 0, 0, 360, Scalar.All(255), 2);

        Assert.True(Cv2.CountNonZero(img) > 0);
    }

    [Fact]
    public void DrawMarker()
    {
        using var img = new Mat(50, 50, MatType.CV_8UC1, Scalar.All(0));
        Cv2.DrawMarker(img, new Point(25, 25), Scalar.All(255), MarkerTypes.Cross, 20, 2);

        Assert.True(Cv2.CountNonZero(img) > 0);
    }

    [Fact]
    public void FillConvexPoly()
    {
        using var img = new Mat(50, 50, MatType.CV_8UC1, Scalar.All(0));
        var pts = new[] { new Point(10, 10), new Point(40, 10), new Point(40, 40), new Point(10, 40) };
        Cv2.FillConvexPoly(img, pts, Scalar.All(255));

        Assert.True(Cv2.CountNonZero(img) > 0);
    }

    [Fact]
    public void FillPoly()
    {
        using var img = new Mat(50, 50, MatType.CV_8UC1, Scalar.All(0));
        var pts = new[] { new[] { new Point(10, 10), new Point(40, 10), new Point(40, 40), new Point(10, 40) } };
        Cv2.FillPoly(img, pts, Scalar.All(255));

        Assert.True(Cv2.CountNonZero(img) > 0);
    }

    [Fact]
    public void CalcBackProject()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var hist = new Mat();
        var ranges = new[] { new Rangef(0, 256) };
        Cv2.CalcHist(new[] { src }, SingleChannelIndex, default, hist, 1, GrayscaleHistSize, ranges);

        using var backProject = new Mat();
        Cv2.CalcBackProject(new[] { src }, SingleChannelIndex, hist, backProject, ranges);

        Assert.Equal(src.Size(), backProject.Size());
    }

    [Fact]
    public void CompareHist()
    {
        using var h1 = Mat.FromPixelData(4, 1, MatType.CV_32FC1, new float[] { 1, 2, 3, 4 });
        using var h2 = Mat.FromPixelData(4, 1, MatType.CV_32FC1, new float[] { 1, 2, 3, 4 });
        var d = Cv2.CompareHist(h1, h2, HistCompMethods.Correl);

        Assert.Equal(1.0, d, 3); // identical histograms correlate perfectly
    }

    [Fact]
    public void ConnectedComponents()
    {
        using var img = MakeTwoBlobImage();
        using var labels = new Mat();
        var n = Cv2.ConnectedComponents(img, labels, PixelConnectivity.Connectivity8);

        Assert.Equal(3, n); // background + two blobs
    }

    [Fact]
    public void ConnectedComponentsWithAlgorithm()
    {
        using var img = MakeTwoBlobImage();
        using var labels = new Mat();
        var n = Cv2.ConnectedComponentsWithAlgorithm(img, labels, PixelConnectivity.Connectivity8,
            MatType.CV_32S, ConnectedComponentsAlgorithmsTypes.Default);

        Assert.Equal(3, n);
    }

    [Fact]
    public void ConnectedComponentsWithStats()
    {
        using var img = MakeTwoBlobImage();
        using var labels = new Mat();
        using var stats = new Mat();
        using var centroids = new Mat();
        var n = Cv2.ConnectedComponentsWithStats(img, labels, stats, centroids);

        Assert.Equal(3, n);
        Assert.Equal(3, stats.Rows);
    }

    [Fact]
    public void ConnectedComponentsWithStatsWithAlgorithm()
    {
        using var img = MakeTwoBlobImage();
        using var labels = new Mat();
        using var stats = new Mat();
        using var centroids = new Mat();
        var n = Cv2.ConnectedComponentsWithStatsWithAlgorithm(img, labels, stats, centroids,
            PixelConnectivity.Connectivity8, MatType.CV_32S, ConnectedComponentsAlgorithmsTypes.Default);

        Assert.Equal(3, n);
    }

    [Fact]
    public void CornerSubPix()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        var refined = Cv2.CornerSubPix(src, new[] { new Point2f(50, 50) }, new Size(5, 5), new Size(-1, -1),
            new TermCriteria(CriteriaTypes.MaxIter | CriteriaTypes.Eps, 30, 0.01));

        Assert.Single(refined);
    }

    [Fact]
    public void DistanceTransform()
    {
        using var img = new Mat(10, 10, MatType.CV_8UC1, Scalar.All(255));
        using var dst = new Mat();
        Cv2.DistanceTransform(img, dst, DistanceTypes.L2, DistanceTransformMasks.Mask3);

        Assert.Equal(img.Size(), dst.Size());
        Assert.Equal(MatType.CV_32FC1, dst.Type());
    }

    [Fact]
    public void DistanceTransformWithLabels()
    {
        using var img = new Mat(10, 10, MatType.CV_8UC1, Scalar.All(255));
        using var dst = new Mat();
        using var labels = new Mat();
        Cv2.DistanceTransformWithLabels(img, dst, labels, DistanceTypes.L2, DistanceTransformMasks.Mask3);

        Assert.Equal(img.Size(), dst.Size());
        Assert.Equal(img.Size(), labels.Size());
    }

    [Fact]
    public void EMD()
    {
        using var sig1 = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 0.5f, 0, 0.5f, 1 });
        using var sig2 = Mat.FromPixelData(2, 2, MatType.CV_32FC1, new float[] { 0.5f, 0, 0.5f, 1 });
        var d = Cv2.EMD(sig1, sig2, DistanceTypes.L2);

        Assert.Equal(0.0, d, 3); // identical signatures
    }

    [Fact]
    public void FindContoursAsArray()
    {
        using var img = MakeSingleBlobImage();
        var contours = Cv2.FindContoursAsArray(img, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

        Assert.True(contours.Length >= 1);
    }

    [Fact]
    public void FindContoursAsMat()
    {
        using var img = MakeSingleBlobImage();
        var contours = Cv2.FindContoursAsMat(img, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

        Assert.True(contours.Length >= 1);
        foreach (var c in contours)
            c.Dispose();
    }

    [Fact]
    public void FloodFill()
    {
        using var img = new Mat(10, 10, MatType.CV_8UC1, Scalar.All(0));
        var area = Cv2.FloodFill(img, new Point(5, 5), Scalar.All(255));

        Assert.True(area > 0);
    }

    [Fact]
    public void GetAffineTransform()
    {
        var src = new[] { new Point2f(0, 0), new Point2f(1, 0), new Point2f(0, 1) };
        var dst = new[] { new Point2f(0, 0), new Point2f(2, 0), new Point2f(0, 2) };
        using var m = Cv2.GetAffineTransform(src, dst);

        Assert.Equal(new Size(3, 2), m.Size());
    }

    [Fact]
    public void GetPerspectiveTransform()
    {
        var src = new[] { new Point2f(0, 0), new Point2f(1, 0), new Point2f(1, 1), new Point2f(0, 1) };
        var dst = new[] { new Point2f(0, 0), new Point2f(2, 0), new Point2f(2, 2), new Point2f(0, 2) };
        using var m = Cv2.GetPerspectiveTransform(src, dst);

        Assert.Equal(new Size(3, 3), m.Size());
    }

    [Fact]
    public void GoodFeaturesToTrack()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var mask = new Mat();
        var corners = Cv2.GoodFeaturesToTrack(src, 100, 0.01, 10, mask, 3, false, 0.04);

        Assert.True(corners.Length > 0);
    }

    [Fact]
    public void GrabCut()
    {
        using var color = LoadImage("lenna.png", ImreadModes.Color);
        using var img = new Mat();
        Cv2.Resize(color, img, new Size(64, 64));
        using var mask = new Mat();
        using var bgdModel = new Mat();
        using var fgdModel = new Mat();
        Cv2.GrabCut(img, mask, new Rect(8, 8, 48, 48), bgdModel, fgdModel, 1, GrabCutModes.InitWithRect);

        Assert.Equal(img.Size(), mask.Size());
    }

    [Fact]
    public void HoughLines()
    {
        using var img = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Line(img, new Point(0, 50), new Point(99, 50), Scalar.All(255), 1);
        var lines = Cv2.HoughLines(img, 1, Math.PI / 180, 50);

        Assert.True(lines.Length > 0);
    }

    [Fact]
    public void HoughCircles()
    {
        using var img = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Circle(img, 50, 50, 20, Scalar.All(255), 2);
        var circles = Cv2.HoughCircles(img, HoughModes.Gradient, 1, 20, 100, 30, 10, 40);

        Assert.NotNull(circles); // exercises the proxy path; detection itself can vary
    }

    [Fact]
    public void IntersectConvexConvex()
    {
        using var p1 = Mat.FromPixelData(4, 1, MatType.CV_32FC2, new float[] { 0, 0, 10, 0, 10, 10, 0, 10 });
        using var p2 = Mat.FromPixelData(4, 1, MatType.CV_32FC2, new float[] { 5, 5, 15, 5, 15, 15, 5, 15 });
        using var p12 = new Mat();
        var area = Cv2.IntersectConvexConvex(p1, p2, p12);

        Assert.True(area > 0);
    }

    [Fact]
    public void InvertAffineTransform()
    {
        var src = new[] { new Point2f(0, 0), new Point2f(1, 0), new Point2f(0, 1) };
        var dst = new[] { new Point2f(0, 0), new Point2f(2, 0), new Point2f(0, 2) };
        using var m = Cv2.GetAffineTransform(src, dst);
        using var im = new Mat();
        Cv2.InvertAffineTransform(m, im);

        Assert.Equal(new Size(3, 2), im.Size());
    }

    [Fact]
    public void MatchShapes()
    {
        using var c1 = Mat.FromPixelData(4, 1, MatType.CV_32SC2, SquareContourPoints);
        using var c2 = Mat.FromPixelData(4, 1, MatType.CV_32SC2, SquareContourPoints);
        var d = Cv2.MatchShapes(c1, c2, ShapeMatchModes.I1);

        Assert.Equal(0.0, d, 3); // identical contours
    }

    [Fact]
    public void MinAreaRect()
    {
        using var pts = Mat.FromPixelData(4, 1, MatType.CV_32FC2, new float[] { 0, 0, 10, 0, 10, 10, 0, 10 });
        var rr = Cv2.MinAreaRect(pts);

        Assert.True(rr.Size.Width > 0 && rr.Size.Height > 0);
    }

    [Fact]
    public void PhaseCorrelate()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var small = new Mat();
        Cv2.Resize(gray, small, new Size(64, 64));
        using var src = new Mat();
        small.ConvertTo(src, MatType.CV_32F);
        using var window = new Mat();
        Cv2.CreateHanningWindow(window, new Size(64, 64), MatType.CV_32F);

        var shift = Cv2.PhaseCorrelate(src, src, window, out var response);

        Assert.True(Math.Abs(shift.X) < 1.0 && Math.Abs(shift.Y) < 1.0); // identical inputs -> no shift
    }

    [Fact]
    public void Watershed()
    {
        using var color = LoadImage("lenna.png", ImreadModes.Color);
        using var img = new Mat();
        Cv2.Resize(color, img, new Size(64, 64));
        using var markers = new Mat(img.Size(), MatType.CV_32SC1, Scalar.All(0));
        markers.Set(8, 8, 1);
        markers.Set(56, 56, 2);
        Cv2.Watershed(img, markers);

        Assert.Equal(img.Size(), markers.Size());
    }

    private static Mat MakeTwoBlobImage()
    {
        var img = new Mat(10, 10, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(img, new Rect(1, 1, 2, 2), Scalar.All(255), -1);
        Cv2.Rectangle(img, new Rect(6, 6, 2, 2), Scalar.All(255), -1);
        return img;
    }

    private static Mat MakeSingleBlobImage()
    {
        var img = new Mat(20, 20, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(img, new Rect(5, 5, 10, 10), Scalar.All(255), -1);
        return img;
    }
}
