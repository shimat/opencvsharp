using System.Runtime.InteropServices;
using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

// Tests for the priority-B dnn additions: blobFromImageWithParams / blobFromImagesWithParams,
// imagesFromBlob, NMSBoxesBatched, softNMSBoxes and readNetFromTFLite.
public class BlobAndNmsTest : TestBase
{
    public static bool IsWindowsOrLinux =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void BlobFromImageWithParamsMatchesBlobFromImage()
    {
        using var img = LoadImage("lenna.png");

        using var expected = CvDnn.BlobFromImage(
            img, 1.0, new Size(224, 224), new Scalar(0, 0, 0), swapRB: false, crop: false);

        var param = new Image2BlobParams(
            new Scalar(1, 1, 1, 1), new Size(224, 224), new Scalar(0, 0, 0), swapRB: false);
        using var actual = CvDnn.BlobFromImageWithParams(img, param);

        Assert.Equal(expected.Dims, actual.Dims);
        for (var i = 0; i < expected.Dims; i++)
            Assert.Equal(expected.Size(i), actual.Size(i));
        // Same preprocessing parameters must produce the same blob.
        Assert.True(Cv2.Norm(expected, actual, NormTypes.L1) < 1e-3, "blobs differ");
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void BlobFromImageWithParamsLetterbox()
    {
        using var img = LoadImage("lenna.png");

        var param = new Image2BlobParams(
            new Scalar(1.0 / 255), new Size(416, 416), new Scalar(0, 0, 0), swapRB: true)
        {
            PaddingMode = ImagePaddingMode.LETTERBOX,
        };
        using var blob = CvDnn.BlobFromImageWithParams(img, param);

        // NCHW: [1, 3, 416, 416]
        Assert.Equal(4, blob.Dims);
        Assert.Equal(1, blob.Size(0));
        Assert.Equal(3, blob.Size(1));
        Assert.Equal(416, blob.Size(2));
        Assert.Equal(416, blob.Size(3));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void ImagesFromBlobRoundTrip()
    {
        using var img1 = LoadImage("lenna.png");
        using var img2 = LoadImage("mandrill.png");

        using var blob = CvDnn.BlobFromImages(
            new[] { img1, img2 }, 1.0, new Size(100, 100), new Scalar(0, 0, 0), swapRB: false, crop: false);

        var images = CvDnn.ImagesFromBlob(blob);
        try
        {
            Assert.Equal(2, images.Length);
            foreach (var image in images)
            {
                Assert.Equal(100, image.Rows);
                Assert.Equal(100, image.Cols);
                Assert.Equal(3, image.Channels());
            }
        }
        finally
        {
            foreach (var image in images)
                image.Dispose();
        }
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void NMSBoxesBatched()
    {
        var bboxes = new[]
        {
            new Rect(10, 10, 20, 20),
            new Rect(100, 100, 20, 20),
            new Rect(1000, 1000, 20, 20),
        };
        var scores = new[] { 1.0f, 0.1f, 0.6f };
        var classIds = new[] { 0, 0, 0 };

        CvDnn.NMSBoxesBatched(bboxes, scores, classIds, 0.5f, 0.4f, out var indices);

        Assert.Equal(2, indices.Length);
        Assert.Equal(0, indices[0]);
        Assert.Equal(2, indices[1]);
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    public void SoftNMSBoxes()
    {
        var bboxes = new[]
        {
            new Rect(10, 10, 20, 20),
            new Rect(100, 100, 20, 20),
            new Rect(1000, 1000, 20, 20),
        };
        var scores = new[] { 1.0f, 0.1f, 0.6f };

        CvDnn.SoftNMSBoxes(bboxes, scores, out var updatedScores, 0.5f, 0.4f, out var indices);

        Assert.NotEmpty(indices);
        Assert.Equal(indices.Length, updatedScores.Length);
        Assert.All(updatedScores, s => Assert.True(s >= 0f));
    }

    [Fact(Skip = "Only runs on Windows or Linux", SkipUnless = nameof(IsWindowsOrLinux))]
    // ReSharper disable once InconsistentNaming
    public void ReadNetFromTFLiteInvalidBufferThrows()
    {
        // A non-tflite buffer must fail inside OpenCV (proves the native entry point is wired),
        // not with a P/Invoke EntryPointNotFoundException.
        var garbage = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        Assert.ThrowsAny<OpenCVException>(() => CvDnn.ReadNetFromTFLite(garbage));
    }
}
