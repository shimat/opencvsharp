using System.IO;
using OpenCvSharp.Face;
using Xunit;

namespace OpenCvSharp.Tests.Face;

public class FacemarkKazemiTest
{
    [Fact]
    public void CreateWithDefaultAndCustomParameters()
    {
        var parameters = new FacemarkKazemi.Params();
        Assert.True(parameters.CascadeDepth > 0);
        Assert.True(parameters.TreeDepth > 0);
        Assert.True(parameters.NumTreesPerCascadeLevel > 0);

        using var defaultModel = FacemarkKazemi.Create();
        using var customModel = FacemarkKazemi.Create(parameters);
    }

    [Fact]
    public void ReadWrite()
    {
        // cv::face::Facemark inherits Algorithm virtually; this exercises the P/Invoke plumbing
        // that keeps the native pointer at its concrete type across the write/read call, rather
        // than reinterpreting it as cv::Algorithm* (which would corrupt memory).
        using var model = FacemarkKazemi.Create();

        var fileName = Path.Combine(Path.GetTempPath(), $"facemark_kazemi_test_{Guid.NewGuid():N}.yml");
        try
        {
            using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
            {
                fs.Write("marker", 1);
                model.Write(fs);
            }

            using var fs2 = new FileStorage(fileName, FileStorage.Modes.Read);
            var root = fs2.Root();
            Assert.NotNull(root);
            model.Read(root);
        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
    }

    [Fact]
    public void CustomFaceDetectorIsInvoked()
    {
        using var model = FacemarkKazemi.Create();
        using var image = new Mat(32, 32, MatType.CV_8UC1, Scalar.Black);
        Rect expected = new(4, 5, 20, 18);
        model.SetFaceDetector(_ => [expected]);

        var result = model.GetFaces(image, out var faces);

        Assert.True(result);
        Assert.Equal([expected], faces);
    }
}
