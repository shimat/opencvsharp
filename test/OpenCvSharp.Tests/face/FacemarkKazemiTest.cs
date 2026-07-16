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
