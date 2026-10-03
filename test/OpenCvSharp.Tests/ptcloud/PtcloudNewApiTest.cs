using Xunit;

namespace OpenCvSharp.Tests;

public class PtcloudNewApiTest : TestBase
{
    [Fact]
    public void OctreeStoresAndSearchesPoints()
    {
        using var seed = Mat.FromArray(new[]
        {
            new Point3f(1, 1, 1), new Point3f(2, 2, 2)
        });
        using var tree = Octree.CreateWithResolution(0.25, seed);
        Assert.True(tree.InsertPoint(new Point3f(1.5f, 1.5f, 1.5f)));
        Assert.False(tree.Empty());
        using var found = new Mat();
        Assert.True(tree.RadiusNNSearch(new Point3f(1.5f, 1.5f, 1.5f), 0.5f, found) > 0);
        Assert.False(found.Empty());
    }

    [Fact]
    public void TriangleRasterizeFillsColorAndDepth()
    {
        Assert.Equal(TriangleRasterizeSettings.Default, new TriangleRasterizeSettings());
        using var vertices = Mat.FromPixelData(1, 3, MatType.CV_32FC3,
            new float[] { -0.5f, -0.5f, -2, 0.5f, -0.5f, -2, 0, 0.5f, -2 });
        using var indices = Mat.FromPixelData(1, 1, MatType.CV_32SC3, new[] { 0, 1, 2 });
        using var colors = Mat.FromPixelData(1, 3, MatType.CV_32FC3,
            new float[] { 1, 0, 0, 1, 0, 0, 1, 0, 0 });
        using var color = new Mat(new Size(32, 32), MatType.CV_32FC3, Scalar.Black);
        using var depth = new Mat(new Size(32, 32), MatType.CV_32FC1, Scalar.All(10));
        using var camera = Mat.EyeMat(4, 4, MatType.CV_32FC1);
        var settings = TriangleRasterizeSettings.Default with { CullingMode = TriangleCullingMode.None };

        Cv2.TriangleRasterize(vertices, indices, colors, color, depth, camera,
            Math.PI / 2, 0.1, 10, settings);

        Cv2.MinMaxLoc(depth, out double minimum, out double _);
        Assert.True(minimum < 10);
        Assert.True(Cv2.Sum(color).Val0 > 0);
    }
}
