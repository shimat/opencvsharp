using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking;

// ReSharper disable once InconsistentNaming
// ReSharper disable once IdentifierTypo
public class TrackerCSRTTest : TrackerTestBase
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
    public void CreateWithParams()
    {
        // Exercises the managed Params -> blittable WTrackerCSRTParams conversion,
        // including marshalling the WindowFunction string to the native char*.
        var paras = new TrackerCSRT.Params
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

        using var tracker = TrackerCSRT.Create(paras);
        InitBase(tracker);
    }
}
