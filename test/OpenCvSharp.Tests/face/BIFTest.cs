using OpenCvSharp.Face;
using Xunit;

namespace OpenCvSharp.Tests.Face;

// ReSharper disable once InconsistentNaming
public class BIFTest
{
    [Fact]
    public void CreateAndCompute()
    {
        using var bif = BIF.Create(4, 6);
        using var image = new Mat(64, 64, MatType.CV_32FC1, Scalar.All(0.5));
        using var features = new Mat();

        bif.Compute(image, features);

        Assert.Equal(4, bif.NumBands);
        Assert.Equal(6, bif.NumRotations);
        Assert.False(features.Empty());
        Assert.Equal(MatType.CV_32FC1, features.Type());
    }
}
