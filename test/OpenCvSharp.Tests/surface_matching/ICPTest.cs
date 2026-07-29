using OpenCvSharp.PpfMatch3D;
using Xunit;

namespace OpenCvSharp.Tests.SurfaceMatching;

public class ICPTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var icp = new ICP();
    }

    [Fact]
    public void ComputeNormalsPC3dProducesPointCloudWithNormals()
    {
        using var pointCloud = CreateCurvedPointCloud();
        using var pointCloudWithNormals = new Mat();

        var result = Cv2.PpfMatch3D.ComputeNormalsPC3d(
            pointCloud,
            pointCloudWithNormals,
            numberOfNeighbors: 12);

        Assert.Equal(1, result);
        Assert.Equal(pointCloud.Rows, pointCloudWithNormals.Rows);
        Assert.Equal(6, pointCloudWithNormals.Cols);
        Assert.Equal(MatType.CV_32FC1, pointCloudWithNormals.Type());

        var normalLength = Math.Sqrt(
            Math.Pow(pointCloudWithNormals.Get<float>(pointCloudWithNormals.Rows / 2, 3), 2) +
            Math.Pow(pointCloudWithNormals.Get<float>(pointCloudWithNormals.Rows / 2, 4), 2) +
            Math.Pow(pointCloudWithNormals.Get<float>(pointCloudWithNormals.Rows / 2, 5), 2));
        Assert.InRange(normalLength, 0.9, 1.1);
    }

    [Fact]
    public void RegisterModelToSceneReturnsPose()
    {
        using var destinationPoints = CreateCurvedPointCloud();
        using var destination = new Mat();
        Assert.Equal(1, Cv2.PpfMatch3D.ComputeNormalsPC3d(
            destinationPoints,
            destination,
            numberOfNeighbors: 12));

        using var source = destination.Clone();
        using var icp = new ICP(
            iterations: 100,
            tolerance: 0.005f,
            rejectionScale: 2.5f,
            numberOfLevels: 6);

        var result = icp.RegisterModelToScene(
            source,
            destination,
            out var residual,
            out var pose);
        using (pose)
        {
            Assert.Equal(0, result);
            Assert.True(double.IsFinite(residual));
            Assert.Equal(4, pose.Rows);
            Assert.Equal(4, pose.Cols);
            Assert.Equal(MatType.CV_64FC1, pose.Type());

            for (var row = 0; row < 4; row++)
            {
                for (var column = 0; column < 4; column++)
                {
                    var expected = row == column ? 1.0 : 0.0;
                    Assert.Equal(expected, pose.Get<double>(row, column), 5);
                }
            }
        }
    }

    private static Mat<float> CreateCurvedPointCloud()
    {
        const int width = 20;
        const int height = 15;
        var points = new float[width * height, 3];
        var index = 0;

        for (var y = 0; y < height; y++)
        {
            var yf = (y - (height - 1) / 2f) / 5f;
            for (var x = 0; x < width; x++)
            {
                var xf = (x - (width - 1) / 2f) / 5f;
                points[index, 0] = xf;
                points[index, 1] = yf;
                points[index, 2] = 0.15f * xf * xf + 0.08f * yf * yf + 0.03f * xf * yf;
                index++;
            }
        }

        return Mat.FromArray(points);
    }
}
