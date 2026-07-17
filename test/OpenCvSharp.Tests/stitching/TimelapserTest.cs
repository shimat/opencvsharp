using OpenCvSharp.Detail;
using Xunit;

namespace OpenCvSharp.Tests.Stitching;

public class TimelapserTest : TestBase
{
    [Theory]
    [InlineData(TimelapserType.AsIs)]
    [InlineData(TimelapserType.Crop)]
    public void InitializeProcessGetDst(TimelapserType type)
    {
        using var timelapser = Timelapser.CreateDefault(type);
        using var image = new Mat(new Size(50, 50), MatType.CV_16SC3, Scalar.All(255));
        using var mask = new Mat(new Size(50, 50), MatType.CV_8UC1, Scalar.All(255));

        timelapser.Initialize([new Point(0, 0)], [new Size(50, 50)]);
        timelapser.Process(image, mask, new Point(0, 0));

        using var dst = timelapser.GetDst();
        Assert.False(dst.Empty());
    }
}
