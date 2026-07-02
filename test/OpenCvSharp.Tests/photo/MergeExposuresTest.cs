using Xunit;

namespace OpenCvSharp.Tests.Photo;

public class MergeExposuresTest : TestBase
{
#pragma warning disable CA2000
    private static Mat[] CreateExposureImages() =>
    [
        new Mat(100, 100, MatType.CV_8UC3, new Scalar(64, 64, 64)),
        new Mat(100, 100, MatType.CV_8UC3, new Scalar(128, 128, 128)),
        new Mat(100, 100, MatType.CV_8UC3, new Scalar(192, 192, 192)),
    ];
#pragma warning restore CA2000

    #region MergeDebevec

    [Fact]
    public void MergeDebevecCreate()
    {
        using var merger = MergeDebevec.Create();
        Assert.NotEqual(IntPtr.Zero, merger.RawPtr);
    }

    [Fact]
    public void MergeDebevecProcess()
    {
        var images = CreateExposureImages();
        try
        {
            float[] times = [0.25f, 0.5f, 1.0f];

            // Linear inverse CRF: response[i] = i/255 for each channel
            var responseData = new Vec3f[256];
            for (int i = 0; i < 256; i++)
            {
                float v = i / 255.0f;
                responseData[i] = new Vec3f(v, v, v);
            }
            using var response = new Mat(256, 1, MatType.CV_32FC3);
            response.SetArray(responseData);

            using var dst = new Mat();
            using var merger = MergeDebevec.Create();
            merger.Process(images, dst, times, response);

            Assert.False(dst.Empty());
            Assert.Equal(MatType.CV_32FC3, dst.Type());
            Assert.Equal(100, dst.Rows);
            Assert.Equal(100, dst.Cols);
        }
        finally
        {
            foreach (var img in images) img.Dispose();
        }
    }

    #endregion

    #region MergeMertens

    [Fact]
    public void MergeMertensCreate()
    {
        using var merger = MergeMertens.Create();
        Assert.NotEqual(IntPtr.Zero, merger.RawPtr);
    }

    [Fact]
    public void MergeMertensProcess()
    {
        var images = CreateExposureImages();
        try
        {
            using var dst = new Mat();
            using var merger = MergeMertens.Create();
            merger.Process(images, dst);

            Assert.False(dst.Empty());
            Assert.Equal(MatType.CV_32FC3, dst.Type());
            Assert.Equal(100, dst.Rows);
            Assert.Equal(100, dst.Cols);
        }
        finally
        {
            foreach (var img in images) img.Dispose();
        }
    }

    #endregion
}
