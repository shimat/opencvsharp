using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

public class BOWKMeansTrainerTest : TestBase
{
    [Fact]
    public void New()
    {
        var bow = new BOWKMeansTrainer(100);
        bow.Dispose();
    }
}
