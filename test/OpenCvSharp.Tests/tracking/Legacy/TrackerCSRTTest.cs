using OpenCvSharp.Tracking.Legacy;
using Xunit;

namespace OpenCvSharp.Tests.Tracking.Legacy;

// ReSharper disable once InconsistentNaming
public class TrackerCSRTTest : LegacyTrackerTestBase
{
    [Fact]
    public void Init()
    {
        using var tracker = TrackerCSRT.Create();
        InitBase(tracker);
    }

    [Fact]
    public void Update()
    {
        using var tracker = TrackerCSRT.Create();
        UpdateBase(tracker);
    }

    [Fact]
    public void SetInitialMask()
    {
        using var tracker = TrackerCSRT.Create();
        var roi = new Rect(220, 60, 200, 220);

        // The mask must match the initial bounding box's size.
        using var mask = Mat.OnesMat(roi.Size, MatType.CV_8UC1);
        tracker.SetInitialMask(mask);

        using var image = LoadImage("lenna.png");
        Assert.True(tracker.Init(image, new Rect2d(roi.X, roi.Y, roi.Width, roi.Height)));
    }

    [Fact]
    public void CreateWithParams()
    {
        var parameters = new TrackerCSRT.Params
        {
            UseHog = true,
            UseColorNames = true,
            UseGray = true,
            UseChannelWeights = true,
            UseSegmentation = true,
            WindowFunction = "hann",
            KaiserAlpha = 3.75f,
            TemplateSize = 200f,
            GslSigma = 1f,
            HogOrientations = 9f,
            HogClip = 0.2f,
            Padding = 3f,
            FilterLr = 0.02f,
            WeightsLr = 0.02f,
            NumHogChannelsUsed = 18,
            AdmmIterations = 4,
            HistogramBins = 16,
            HistogramLr = 0.04f,
            BackgroundRatio = 2,
            NumberOfScales = 33,
            ScaleSigmaFactor = 0.25f,
            ScaleModelMaxArea = 512f,
            ScaleLr = 0.025f,
            ScaleStep = 1.02f,
            PsrThreshold = 0.035f,
        };

        using var tracker = TrackerCSRT.Create(parameters);
        InitBase(tracker);
    }
}
