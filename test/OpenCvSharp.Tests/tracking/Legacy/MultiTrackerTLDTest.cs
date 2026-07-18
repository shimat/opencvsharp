using OpenCvSharp.Tracking.Legacy;
using Xunit;

namespace OpenCvSharp.Tests.Tracking.Legacy;

// ReSharper disable once InconsistentNaming
public class MultiTrackerTLDTest : LegacyTrackerTestBase
{
    [Fact]
    public void AddTargetAndUpdateOpt()
    {
        // cv::legacy::MultiTrackerTLD::update_opt internally static_casts each tracked object to
        // tld::TrackerTLDImpl* (see multiTracker.cpp), so - unlike plain MultiTracker/MultiTracker_Alt,
        // which work with any legacy::Tracker - every target added here must actually be a
        // legacy::TrackerTLD; using a different tracker type crashes (invalid static_cast) rather
        // than throwing a catchable error, matching the upstream API's own documented pairing
        // (@sa Tracker, MultiTracker, TrackerTLD).
        using var multiTracker = new MultiTrackerTLD();
        using var tracker1 = TrackerTLD.Create();

        using var image = LoadImage("lenna.png");

        Assert.True(multiTracker.AddTarget(image, new Rect2d(220, 60, 200, 220), tracker1));
        Assert.Equal(1, multiTracker.TargetNum);

        Assert.True(multiTracker.UpdateOpt(image));

        var boxes = multiTracker.BoundingBoxes;
        Assert.Single(boxes);
        Assert.True(boxes[0].Width > 0);
        Assert.True(boxes[0].Height > 0);
    }
}
