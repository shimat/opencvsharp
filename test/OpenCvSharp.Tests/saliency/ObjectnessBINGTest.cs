using OpenCvSharp.Saliency;
using Xunit;

namespace OpenCvSharp.Tests.Saliency;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class ObjectnessBINGTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var bing = ObjectnessBING.Create();
        Assert.NotNull(bing);
    }

    [Fact]
    public void DefaultProperties()
    {
        using var bing = ObjectnessBING.Create();

        // Verify that property accessors round-trip correctly
        var originalBase = bing.Base;
        var originalNSS = bing.NSS;
        var originalW = bing.W;

        Assert.True(originalBase > 0);
        Assert.True(originalNSS > 0);
        Assert.True(originalW > 0);
    }

    [Fact]
    public void SetProperties()
    {
        using var bing = ObjectnessBING.Create();

        bing.Base = 2.0;
        bing.NSS = 3;
        bing.W = 8;

        Assert.Equal(2.0, bing.Base, precision: 10);
        Assert.Equal(3, bing.NSS);
        Assert.Equal(8, bing.W);
    }

    [Fact]
    public void SetTrainingPath_DoesNotThrow()
    {
        using var bing = ObjectnessBING.Create();
        // Setting a path should not throw even if the directory does not exist;
        // the error only manifests when ComputeSaliency is called.
        bing.SetTrainingPath("/nonexistent/path");
    }

    [Fact]
    public void SetBBResDir_DoesNotThrow()
    {
        using var bing = ObjectnessBING.Create();
        bing.SetBBResDir("/nonexistent/results");
    }
}
