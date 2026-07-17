using OpenCvSharp.Tracking.Legacy;
using Xunit;

namespace OpenCvSharp.Tests.Tracking.Legacy;

// See the comment in TrackerMILTest.cs for why this alias must be placed after the file-scoped
// namespace declaration rather than above it.
using TrackerMIL = OpenCvSharp.Tracking.Legacy.TrackerMIL;

public class MultiTrackerTest : LegacyTrackerTestBase
{
    [Fact]
    public void AddAndUpdate()
    {
        using var multiTracker = MultiTracker.Create();
        using var tracker1 = TrackerMIL.Create();
        using var tracker2 = TrackerKCF.Create();

        using var image = LoadImage("lenna.png");

        Assert.True(multiTracker.Add(tracker1, image, new Rect2d(220, 60, 200, 220)));
        Assert.True(multiTracker.Add(tracker2, image, new Rect2d(0, 0, 50, 50)));

        var objects = multiTracker.GetObjects();
        Assert.Equal(2, objects.Length);

        Assert.True(multiTracker.Update(image));

        objects = multiTracker.GetObjects();
        Assert.Equal(2, objects.Length);
        foreach (var obj in objects)
        {
            Assert.True(obj.Width > 0);
            Assert.True(obj.Height > 0);
        }
    }
}
