using Xunit;

namespace OpenCvSharp.Tests;

public class CoreNewApiTest : TestBase
{
    [Fact]
    public void DivSpectrumsRecoversNumerator()
    {
        using var numerator = Mat.FromPixelData(1, 2, MatType.CV_32FC2,
            new float[] { 2, 0, 4, 0 });
        using var denominator = Mat.FromPixelData(1, 2, MatType.CV_32FC2,
            new float[] { 2, 0, 2, 0 });
        using var quotient = new Mat();
        Cv2.DivSpectrums(numerator, denominator, quotient, DftFlags.None);
        using var scalarChannels = quotient.Reshape(1);
        scalarChannels.GetArray(out float[] actual);
        Assert.Equal(new float[] { 1, 0, 2, 0 }, actual);
    }
}
