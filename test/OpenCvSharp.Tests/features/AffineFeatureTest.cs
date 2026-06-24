using Xunit;

namespace OpenCvSharp.Tests.Features;

// ReSharper disable once InconsistentNaming
public class AffineFeatureTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var backend = SIFT.Create();
        using var affine = AffineFeature.Create(backend);
        Assert.NotEqual(IntPtr.Zero, affine.RawPtr);
    }

    [Fact]
    public void Detect()
    {
        using var gray = LoadImage("lenna.png", 0);
        using var backend = SIFT.Create();
        using var affine = AffineFeature.Create(backend, maxTilt: 2);
        var keyPoints = affine.Detect(gray);
        Assert.NotEmpty(keyPoints);
    }

    [Fact]
    public void SetAndGetViewParams()
    {
        using var backend = SIFT.Create();
        using var affine = AffineFeature.Create(backend);

        var tilts = new[] { 1.0f, 2.0f, 3.0f };
        var rolls = new[] { 0.0f, 45.0f, 90.0f };
        affine.SetViewParams(tilts, rolls);

        affine.GetViewParams(out var outTilts, out var outRolls);
        Assert.Equal(tilts, outTilts);
        Assert.Equal(rolls, outRolls);
    }
}
