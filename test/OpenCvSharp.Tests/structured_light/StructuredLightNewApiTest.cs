using OpenCvSharp.StructuredLight;
using Xunit;

namespace OpenCvSharp.Tests;

public class StructuredLightNewApiTest : TestBase
{
    [Fact]
    public void SinusoidalPatternGeneratesImages()
    {
        using var pattern = SinusoidalPattern.Create(new SinusoidalPatternParams
        {
            Width = 64, Height = 48, NumberOfPeriods = 4, SetMarkers = false
        });
        var images = pattern.Generate();
        try
        {
            Assert.NotEmpty(images);
            Assert.All(images, image => Assert.Equal(new Size(64, 48), image.Size()));
        }
        finally
        {
            DisposeAll(images);
        }
    }

    private static void DisposeAll(IEnumerable<Mat> mats)
    {
        foreach (var mat in mats)
            mat.Dispose();
    }
}
