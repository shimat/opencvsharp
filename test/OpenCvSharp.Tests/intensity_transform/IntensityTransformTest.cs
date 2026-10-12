using Xunit;

namespace OpenCvSharp.Tests.IntensityTransform;

public class IntensityTransformTest : TestBase
{
    [Fact]
    public void GammaCorrectionWithUnitGammaPreservesPixels()
    {
        using var input = CreateGradient();
        using var output = new Mat();

        Cv2.IntensityTransform.GammaCorrection(input, output, 1.0f);

        Assert.Equal(input.Size(), output.Size());
        Assert.Equal(input.Type(), output.Type());
        ImageEquals(input, output);
    }

    [Fact]
    public void ContrastTransformationsProduceImages()
    {
        using var input = CreateGradient();
        using var output = new Mat();

        Cv2.IntensityTransform.LogTransform(input, output);
        Assert.Equal(input.Size(), output.Size());
        Cv2.IntensityTransform.Autoscaling(input, output);
        Assert.Equal(input.Size(), output.Size());
        Cv2.IntensityTransform.ContrastStretching(input, output, 64, 32, 192, 224);
        Assert.Equal(input.Size(), output.Size());
    }

    [Fact]
    public void BimefOverloadsProduceColorImages()
    {
        // OpenCV only implements BIMEF when it was built with Eigen.
        if (!System.Text.RegularExpressions.Regex.IsMatch(
                Cv2.GetBuildInformation(), @"^\s+Eigen:\s+YES", System.Text.RegularExpressions.RegexOptions.Multiline))
            return;

        using var input = new Mat(new Size(32, 32), MatType.CV_8UC3, new Scalar(30, 40, 50));
        using var output = new Mat();

        Cv2.IntensityTransform.Bimef(input, output);
        Assert.Equal(input.Size(), output.Size());
        Assert.Equal(input.Type(), output.Type());

        Cv2.IntensityTransform.Bimef(input, output, 1.5f, 0.5f, -0.3293f, 1.1258f);
        Assert.Equal(input.Size(), output.Size());
        Assert.Equal(input.Type(), output.Type());
    }

    private static Mat CreateGradient()
    {
        var result = new Mat(16, 16, MatType.CV_8UC1);
        for (var row = 0; row < result.Rows; row++)
        for (var col = 0; col < result.Cols; col++)
            result.Set(row, col, (byte)(row * 16 + col));
        return result;
    }
}
