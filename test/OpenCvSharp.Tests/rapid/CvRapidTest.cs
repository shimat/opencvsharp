using OpenCvSharp.Rapid;
using Xunit;

namespace OpenCvSharp.Tests.Rapid;

public class CvRapidTest : TestBase
{
    [Fact]
    public void DrawWireframeRendersProjectedTriangles()
    {
        using var image = new Mat(160, 160, MatType.CV_8UC1, Scalar.Black);
        using var points = Mat.FromPixelData(4, 1, MatType.CV_32FC2,
            new[] { new Point2f(60, 60), new Point2f(100, 60),
                new Point2f(100, 100), new Point2f(60, 100) });
        using var triangles = CreateTriangles();

        CvRapid.DrawWireframe(image, points, triangles, Scalar.White);

        Assert.True(Cv2.CountNonZero(image) > 0);
    }

    [Fact]
    public void TrackRefinesPoseOnSyntheticSquare()
    {
        using var image = new Mat(160, 160, MatType.CV_8UC1, Scalar.Black);
        Cv2.Rectangle(image, new Point(60, 60), new Point(100, 100), Scalar.White, 2);
        using var vertices = Mat.FromPixelData(4, 1, MatType.CV_32FC3,
            new[] { new Point3f(-0.5f, 0.5f, 0), new Point3f(0.5f, 0.5f, 0),
                new Point3f(0.5f, -0.5f, 0), new Point3f(-0.5f, -0.5f, 0) });
        using var triangles = CreateTriangles();
        using var camera = Mat.FromPixelData(3, 3, MatType.CV_64FC1,
            new double[] { 80, 0, 80, 0, 80, 80, 0, 0, 1 });
        using var rotation = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new double[3]);
        using var translation = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new double[] { 0, 0, 2 });

        var ratio = CvRapid.Track(image, 20, 5, vertices, triangles,
            camera, rotation, translation, out var rmsd);

        Assert.InRange(ratio, float.Epsilon, 1f);
        Assert.True(double.IsFinite(rmsd));
        Assert.Equal(MatType.CV_64FC1, rotation.Type());
        Assert.Equal(MatType.CV_64FC1, translation.Type());
    }

    [Fact]
    public void RejectsInvalidSearchParameters()
    {
        using var image = new Mat(160, 160, MatType.CV_8UC1);
        using var vertices = Mat.FromPixelData(3, 1, MatType.CV_32FC3,
            new[] { new Point3f(0, 0, 0), new Point3f(1, 0, 0), new Point3f(0, 1, 0) });
        using var triangles = Mat.FromPixelData(1, 1, MatType.CV_32SC3, new[] { new Vec3i(0, 1, 2) });
        using var camera = Mat.Eye(3, 3, MatType.CV_64FC1).ToMat();
        using var rotation = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new double[3]);
        using var translation = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new double[] { 0, 0, 2 });

        Assert.Throws<ArgumentOutOfRangeException>(() => CvRapid.Track(
            image, 2, 5, vertices, triangles, camera, rotation, translation, out _));
        Assert.Throws<ArgumentOutOfRangeException>(() => CvRapid.Track(
            image, 3, 0, vertices, triangles, camera, rotation, translation, out _));
    }

    private static Mat CreateTriangles() => Mat.FromPixelData(2, 1, MatType.CV_32SC3,
        new[] { new Vec3i(0, 2, 1), new Vec3i(0, 3, 2) });
}
