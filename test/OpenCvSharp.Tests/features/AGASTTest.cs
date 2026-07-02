using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.Features;

// ArrayProxy migration coverage (issue #1976): Cv2.AGAST had no test before.
// ReSharper disable once InconsistentNaming
public class AGASTTest : TestBase
{
    [Fact]
    public void Detect()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);

        var keyPoints = Cv2.AGAST(gray, 10, true, AgastFeatureDetector.DetectorType.OAST_9_16);

        Assert.NotEmpty(keyPoints);
    }
}
