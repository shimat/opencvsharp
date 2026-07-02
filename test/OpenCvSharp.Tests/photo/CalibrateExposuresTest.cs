using Xunit;

namespace OpenCvSharp.Tests.Photo;

// ArrayProxy migration coverage (issue #1976): CalibrateCRF.Process (base class for
// CalibrateDebevec/CalibrateRobertson) had no test before.
public class CalibrateExposuresTest : TestBase
{
#pragma warning disable CA2000
    private static Mat[] CreateExposureImages() =>
    [
        new Mat(50, 50, MatType.CV_8UC3, new Scalar(64, 64, 64)),
        new Mat(50, 50, MatType.CV_8UC3, new Scalar(128, 128, 128)),
        new Mat(50, 50, MatType.CV_8UC3, new Scalar(192, 192, 192)),
    ];
#pragma warning restore CA2000

    private static readonly float[] Times = [0.25f, 0.5f, 1.0f];

    [Fact]
    public void CalibrateDebevecProcess()
    {
        var images = CreateExposureImages();
        try
        {
            using var response = new Mat();
            using var calibrator = CalibrateDebevec.Create();
            calibrator.Process(images, response, Times);

            Assert.False(response.Empty());
            Assert.Equal(256, response.Rows);
            Assert.Equal(3, response.Channels());
        }
        finally
        {
            foreach (var img in images) img.Dispose();
        }
    }

    [Fact]
    public void CalibrateRobertsonProcess()
    {
        var images = CreateExposureImages();
        try
        {
            using var response = new Mat();
            using var calibrator = CalibrateRobertson.Create();
            calibrator.Process(images, response, Times);

            Assert.False(response.Empty());
            Assert.Equal(256, response.Rows);
            Assert.Equal(3, response.Channels());
        }
        finally
        {
            foreach (var img in images) img.Dispose();
        }
    }
}
