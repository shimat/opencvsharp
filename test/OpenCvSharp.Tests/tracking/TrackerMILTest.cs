using Xunit;

namespace OpenCvSharp.Tests.Tracking;

// ReSharper disable once InconsistentNaming
public class TrackerMILTest : TrackerTestBase
{
    [Fact]
    public void Init()
    {
        using var tracker = TrackerMIL.Create();
        InitBase(tracker);
    }

    [Fact]
    public void Update()
    {
        using var tracker = TrackerMIL.Create();
        UpdateBase(tracker);
    }

    [Fact]
    public void GetTrackingScore()
    {
        using var tracker = TrackerMIL.Create();

        // Tracker::getTrackingScore() has a default virtual implementation that returns -1;
        // TrackerMIL does not override it.
        Assert.Equal(-1f, tracker.GetTrackingScore());
    }
}
