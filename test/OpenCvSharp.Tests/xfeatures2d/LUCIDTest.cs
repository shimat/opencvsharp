using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class LUCIDTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var surf = LUCID.Create();
        surf.Dispose();
    }

    [Fact]
    public void Compute()
    {
        using (var color = Image("lenna.png", ImreadModes.Color))
        using (var gray = Image("lenna.png", ImreadModes.Grayscale))
        using (var descriptors = new Mat())
        using (var lucid = LUCID.Create())
        using (var surf = SURF.Create(500))
        {
            var keypoints = surf.Detect(gray);
            lucid.Compute(color, ref keypoints, descriptors);
        }
    }

    [Fact]
    public void DescriptorSize()
    {
        using (var alg = LUCID.Create())
        {
            var sz = alg.DescriptorSize;
            Assert.Equal(27, sz);
        }
    }

    [Fact]
    public void DefaultNorm()
    {
        using (var alg = LUCID.Create())
        {
            var defnorm = alg.DefaultNorm;
            Assert.Equal(6, defnorm);
        }
    }
}
