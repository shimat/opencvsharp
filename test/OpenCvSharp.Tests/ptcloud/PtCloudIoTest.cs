using Xunit;

namespace OpenCvSharp.Tests.PtCloud;

// Tests for the OpenCV 5 ptcloud mesh / point cloud I/O (loadPointCloud / savePointCloud /
// loadMesh / saveMesh) added to OpenCvSharp.
public class PtCloudIoTest : TestBase
{
    private static readonly float[] Vertices =
    {
        0f, 0f, 0f,
        1f, 0f, 0f,
        0f, 1f, 0f,
        1f, 1f, 1f
    };

    [Theory]
    [InlineData(".ply")]
    [InlineData(".obj")]
    public void PointCloudRoundTrip(string ext)
    {
        var path = Path.Combine(Path.GetTempPath(), $"ocvs_pc_{Guid.NewGuid():N}{ext}");
        try
        {
            using var src = Mat.FromPixelData(4, 1, MatType.CV_32FC3, (float[])Vertices.Clone());
            Cv2.SavePointCloud(path, src);
            Assert.True(File.Exists(path));

            using var loaded = new Mat();
            Cv2.LoadPointCloud(path, loaded);

            Assert.Equal(4, (int)loaded.Total());

            using var flat = loaded.Reshape(1, (int)loaded.Total() * loaded.Channels());
            flat.GetArray(out float[] vals);
            Assert.Equal(Vertices.Length, vals.Length);
            for (var i = 0; i < Vertices.Length; i++)
                Assert.True(Math.Abs(vals[i] - Vertices[i]) < 1e-4, $"vertex component {i}");
        }
        finally
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }

    [Fact]
    public void MeshRoundTrip()
    {
        var path = Path.Combine(Path.GetTempPath(), $"ocvs_mesh_{Guid.NewGuid():N}.ply");
        try
        {
            using var verts = Mat.FromPixelData(4, 1, MatType.CV_32FC3, (float[])Vertices.Clone());

            // Tetrahedron: 4 triangular faces.
            var faces = new[]
            {
                new[] { 0, 1, 2 },
                new[] { 0, 1, 3 },
                new[] { 0, 2, 3 },
                new[] { 1, 2, 3 }
            };
            var indexMats = faces.Select(f => Mat.FromPixelData(1, 3, MatType.CV_32SC1, f)).ToArray();
            try
            {
                Cv2.SaveMesh(path, verts, indexMats);
                Assert.True(File.Exists(path));

                using var loadedVerts = new Mat();
                Cv2.LoadMesh(path, loadedVerts, out var loadedIndices);

                Assert.Equal(4, (int)loadedVerts.Total());
                Assert.Equal(faces.Length, loadedIndices.Length);
                foreach (var idx in loadedIndices)
                    idx.Dispose();
            }
            finally
            {
                foreach (var m in indexMats)
                    m.Dispose();
            }
        }
        finally
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
