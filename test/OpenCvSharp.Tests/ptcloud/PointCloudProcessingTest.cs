using System.Buffers.Binary;
using Xunit;

namespace OpenCvSharp.Tests.PtCloud;

public class PointCloudProcessingTest
{
    [Fact]
    public void OutlierFiltersKeepCluster()
    {
        using var cloud = Mat.FromArray(new Point3f[]
        {
            new(0, 0, 0), new(1, 0, 0), new(0, 1, 0), new(1, 1, 0), new(100, 100, 100),
        });
        using var filtered = new Mat();
        using var kept = new Mat();

        Cv2.RemoveRadiusOutliers(cloud, filtered, 1.1, minNeighbors: 2, keptIndices: kept);
        Assert.Equal(4, filtered.Total());
        Assert.True(kept.GetArray(out int[] indices));
        Assert.Equal(new[] { 0, 1, 2, 3 }, indices);

        Cv2.RemoveStatisticalOutliers(cloud, filtered, meanK: 2, stddevMulThresh: 1);
        Assert.True(filtered.GetArray(out Point3f[] points));
        Assert.Equal(4, points.Length);
        Assert.Equal(new Point3f(1, 1, 0), points[3]);
    }

    [Fact]
    public void NormalOrientationAndMeshingUsePointCloud()
    {
        var points = new List<Point3f>();
        var normalVectors = new List<Point3f>();
        for (var y = 0; y < 5; y++)
        for (var x = 0; x < 5; x++)
        {
            points.Add(new Point3f(x, y, 0));
            normalVectors.Add(new Point3f(0, 0, (x + y) % 2 == 0 ? 1 : -1));
        }

        using var cloud = Mat.FromArray(points);
        using var normals = Mat.FromArray(normalVectors);
        Cv2.OrientNormalsConsistent(cloud, normals, k: 4);
        var consistentZ = normals.At<Point3f>(0).Z;
        for (var i = 0; i < normals.Rows; i++)
            Assert.Equal(consistentZ, normals.At<Point3f>(i).Z);

        Cv2.OrientNormals(cloud, normals, new Point3f(0, 0, 10));
        Assert.Equal(1, normals.At<Point3f>(0).Z);
        Assert.Equal(1, Cv2.EstimateMedianSpacing(cloud), 5);

        using var vertices = new Mat();
        using var triangles = new Mat();
        Cv2.CreateMeshBPA(cloud, normals, vertices, triangles);
        Assert.Equal(points.Count, vertices.Total());
        Assert.False(triangles.Empty());
        Assert.Equal(3, triangles.Cols);
    }

    [Fact]
    public void BoundingVolumesEnclosePoints()
    {
        using var cloud = Mat.FromArray(new Point3f[] { new(-2, 4, 6), new(2, 4, 6) });
        using var minimum = new Mat();
        using var maximum = new Mat();
        Cv2.BoundingBox3D(cloud, minimum, maximum);
        Assert.Equal(-2, minimum.At<float>(0));
        Assert.Equal(2, maximum.At<float>(0));
        Assert.Equal(6, maximum.At<float>(2));

        using var center = new Mat();
        using var axes = new Mat();
        using var halfExtents = new Mat();
        Cv2.OrientedBoundingBox3D(cloud, center, axes, halfExtents);
        Assert.Equal(4, center.At<float>(1));
        Assert.Equal(1, axes.At<float>(0, 0));
        Assert.Equal(2, halfExtents.At<float>(0));
        Assert.Equal(0, halfExtents.At<float>(1));

        Assert.Equal(2, Cv2.ApproxEnclosingSphere3D(cloud, center), 5);
        Assert.Equal(0, center.At<float>(0));
        Assert.Equal(4, center.At<float>(1));
    }

    [Fact]
    public void DecodeGaussianSplatsFromAttributes()
    {
        var names = Cv2.GetGaussianSplatPlyPropNames();
        Assert.Equal(new[] { "x", "y", "z", "f_dc_0", "f_dc_1", "f_dc_2", "opacity",
            "scale_0", "scale_1", "scale_2", "rot_0", "rot_1", "rot_2", "rot_3" }, names);

        using var attributes = new Mat(1, names.Length, MatType.CV_32F, Scalar.All(0));
        attributes.Set(0, 0, 2f);
        attributes.Set(0, 10, 1f);
        using var splats = new Mat();
        Cv2.DecodeGaussianSplats(attributes, splats);
        Assert.Equal(1, splats.Rows);
        Assert.Equal((int)GaussianSplatLayout.Stride, splats.Cols);
        Assert.Equal(2, splats.At<float>(0, (int)GaussianSplatLayout.Position));
        Assert.Equal(1, splats.At<float>(0, (int)GaussianSplatLayout.Covariance));
        Assert.Equal(0.5f, splats.At<float>(0, (int)GaussianSplatLayout.Color));
        Assert.Equal(0.5f, splats.At<float>(0, (int)GaussianSplatLayout.Alpha));
    }

    [Fact]
    public void DecodeGaussianSplatsFromPackedBytesAndFile()
    {
        var bytes = new byte[32];
        BinaryPrimitives.WriteSingleLittleEndian(bytes, 2);
        for (var axis = 0; axis < 3; axis++)
            BinaryPrimitives.WriteSingleLittleEndian(bytes.AsSpan(12 + axis * 4), 1);
        bytes[24] = 255;
        bytes[27] = 255;
        bytes[28] = 255;
        bytes[29] = bytes[30] = bytes[31] = 128;

        using var buffer = Mat.FromArray(bytes);
        using var decoded = new Mat();
        Cv2.DecodeGaussianSplatsPacked(buffer, decoded);
        Assert.Equal(1, decoded.Rows);
        Assert.Equal((int)GaussianSplatLayout.Stride, decoded.Cols);
        Assert.Equal(2, decoded.At<float>(0, (int)GaussianSplatLayout.Position));
        Assert.Equal(1, decoded.At<float>(0, (int)GaussianSplatLayout.Covariance));
        Assert.Equal(1, decoded.At<float>(0, (int)GaussianSplatLayout.Color));
        Assert.Equal(1, decoded.At<float>(0, (int)GaussianSplatLayout.Alpha));

        var path = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.splat");
        try
        {
            File.WriteAllBytes(path, bytes);
            using var loaded = new Mat();
            Cv2.LoadGaussianSplats(path, loaded);
            Assert.Equal(0, Cv2.Norm(decoded, loaded, NormTypes.L1));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
