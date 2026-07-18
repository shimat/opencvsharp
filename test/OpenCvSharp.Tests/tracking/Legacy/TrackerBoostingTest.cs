using OpenCvSharp.Tracking.Legacy;
using Xunit;

namespace OpenCvSharp.Tests.Tracking.Legacy;

public class TrackerBoostingTest : LegacyTrackerTestBase
{
    [Fact]
    public void Init()
    {
        using var tracker = TrackerBoosting.Create();
        InitBase(tracker);
    }

    [Fact]
    public void Update()
    {
        using var tracker = TrackerBoosting.Create();
        UpdateBase(tracker);
    }

    [Fact]
    public void CreateWithParams()
    {
        // Same values as cv::legacy::TrackerBoosting::Params's own default constructor.
        var parameters = new TrackerBoosting.Params
        {
            NumClassifiers = 100,
            SamplerOverlap = 0.99f,
            SamplerSearchFactor = 1.8f,
            IterationInit = 50,
            FeatureSetNumFeatures = 100 * 10 + 50,
        };

        using var tracker = TrackerBoosting.Create(parameters);
        InitBase(tracker);
    }
}
