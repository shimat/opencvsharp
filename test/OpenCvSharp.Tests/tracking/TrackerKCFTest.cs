using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking;

// ReSharper disable once InconsistentNaming
public class TrackerKCFTest : TrackerTestBase
{
    [Fact]
    public void Init()
    {
        using var tracker = TrackerKCF.Create();
        InitBase(tracker);
    }

    // https://github.com/shimat/opencvsharp/issues/459
    [Fact]
    public void Issue459()
    {
        var paras = new TrackerKCF.Params
        {
            CompressFeature = true,
            CompressedSize = 1,
            Resize = true,
            DescNpca = 1,
            DescPca = 1
        };

        using var tracker = TrackerKCF.Create(paras);
        GC.KeepAlive(tracker);
    }

    [Fact]
    public void Update()
    {
        using var tracker = TrackerKCF.Create();
        UpdateBase(tracker);
    }

    [Fact]
    public void SetFeatureExtractor()
    {
        // Custom-only (no Gray/CN) so this extractor is the sole descriptor - avoids having to match
        // whatever internal patch size the built-in Gray/CN descriptors happen to use.
        var parameters = new TrackerKCF.Params
        {
            DescNpca = (int)TrackerKCFMode.Custom,
        };

        using var tracker = TrackerKCF.Create(parameters);

        var callbackInvoked = false;
        tracker.SetFeatureExtractor((image, roi, features) =>
        {
            callbackInvoked = true;
            Assert.False(image.Empty());
            Assert.True(roi.Width > 0);
            Assert.True(roi.Height > 0);

            // Produce a plausibly-shaped feature matrix without cropping "image" at "roi": during
            // Update, cv::TrackerKCF passes an already-scaled/restricted working Mat (not necessarily
            // the original frame) and a roi in that Mat's own coordinate space, so roi is not
            // guaranteed to be in-bounds for image - build a synthetic patch instead.
            using var synthetic = new Mat(roi.Height, roi.Width, MatType.CV_32FC1, Scalar.All(0));
            synthetic.CopyTo(features);
        });

        using var image = LoadImage("lenna.png");
        var bb = new Rect(220, 60, 200, 220);
        tracker.Init(image, bb);
        tracker.Update(image, ref bb);

        Assert.True(callbackInvoked);
    }
}
