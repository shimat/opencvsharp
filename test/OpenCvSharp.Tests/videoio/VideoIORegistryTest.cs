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
        // Not asserting NotEmpty here: which camera backends (V4L2, AVFoundation, MSMF, ...) are
        // built varies by CI platform/container, so an empty list is a legitimate result on some runners.
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
        // FFMPEG is the only stream-buffered backend guaranteed to be built across all CI platforms
        // (see videoio_registry-backed VideoCapture(Stream, ...) support), so this should never be empty.
        var backends = Cv2.VideoIORegistry.GetStreamBufferedBackends();
        Assert.NotEmpty(backends);
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
