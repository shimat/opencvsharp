using OpenCvSharp.Tracking.Legacy;
using Xunit;

namespace OpenCvSharp.Tests.Tracking.Legacy;

// See the comment in TrackerMILTest.cs for why this alias must be placed after the file-scoped
// namespace declaration rather than above it.
using TrackerMIL = OpenCvSharp.Tracking.Legacy.TrackerMIL;

public class MultiTrackerAltTest : LegacyTrackerTestBase
{
    [Fact]
    public void AddTargetAndUpdate()
    {
        using var multiTracker = new MultiTrackerAlt();
        using var tracker1 = TrackerMIL.Create();
        using var tracker2 = TrackerKCF.Create();

        using var image = LoadImage("lenna.png");

        Assert.True(multiTracker.AddTarget(image, new Rect2d(220, 60, 200, 220), tracker1));
        Assert.True(multiTracker.AddTarget(image, new Rect2d(0, 0, 50, 50), tracker2));

        Assert.Equal(2, multiTracker.TargetNum);
        Assert.Equal(2, multiTracker.BoundingBoxes.Length);

        Assert.True(multiTracker.Update(image));

        var boxes = multiTracker.BoundingBoxes;
        Assert.Equal(2, boxes.Length);
        foreach (var box in boxes)
        {
            Assert.True(box.Width > 0);
            Assert.True(box.Height > 0);
        }
    }
}
