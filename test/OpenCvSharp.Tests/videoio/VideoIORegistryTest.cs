using Xunit;

namespace OpenCvSharp.Tests.VideoIO;

public class VideoIORegistryTest : TestBase
{
    [Fact]
    public void GetBackends()
    {
        var backends = Cv2.VideoIORegistry.GetBackends();
        Assert.NotEmpty(backends);
        Assert.Contains(VideoCaptureAPIs.IMAGES, backends);
    }

    [Fact]
    public void GetCameraBackends()
    {
        var backends = Cv2.VideoIORegistry.GetCameraBackends();
        Assert.NotNull(backends);
    }

    [Fact]
    public void GetStreamBackends()
    {
        var backends = Cv2.VideoIORegistry.GetStreamBackends();
        Assert.Contains(VideoCaptureAPIs.IMAGES, backends);
    }

    [Fact]
    public void GetStreamBufferedBackends()
    {
        var backends = Cv2.VideoIORegistry.GetStreamBufferedBackends();
        Assert.NotNull(backends);
    }

    [Fact]
    public void GetWriterBackends()
    {
        var backends = Cv2.VideoIORegistry.GetWriterBackends();
        Assert.NotEmpty(backends);
    }

    [Fact]
    public void HasBackendAndIsBuiltInForImages()
    {
        Assert.True(Cv2.VideoIORegistry.HasBackend(VideoCaptureAPIs.IMAGES));
        Assert.True(Cv2.VideoIORegistry.IsBackendBuiltIn(VideoCaptureAPIs.IMAGES));
    }

    [Fact]
    public void HasBackendReturnsFalseForUnknownApi()
    {
        Assert.False(Cv2.VideoIORegistry.HasBackend((VideoCaptureAPIs)999_999));
    }

    [Fact]
    public void GetBackendNameForImages()
    {
        Assert.Equal("CV_IMAGES", Cv2.VideoIORegistry.GetBackendName(VideoCaptureAPIs.IMAGES));
    }
}
