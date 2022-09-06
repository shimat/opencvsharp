using Xunit;
using Xunit.Abstractions;

namespace OpenCvSharp.Tests.Features2D;

// ReSharper disable once InconsistentNaming
public class FastFeatureDetectorTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public FastFeatureDetectorTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CreateAndDispose()
    {
        var surf = FastFeatureDetector.Create();
        surf.Dispose();
    }

    [Fact]
    public void Detect()
    {
        KeyPoint[] keyPoints;
        using (var gray = Image("lenna.png", 0))
        using (var orb = FastFeatureDetector.Create())
            keyPoints = orb.Detect(gray);

        testOutputHelper.WriteLine($"KeyPoint has {keyPoints.Length} items.");
    }
}
