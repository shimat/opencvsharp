using System.Diagnostics;
using OpenCvSharp.Tracking.Legacy;
using Xunit;

namespace OpenCvSharp.Tests.Tracking.Legacy;

public abstract class LegacyTrackerTestBase : TestBase
{
    protected static void InitBase(LegacyTracker tracker)
    {
        ArgumentNullException.ThrowIfNull(tracker);

        using var vc = LoadImage("lenna.png");
        Assert.True(tracker.Init(vc, new Rect2d(220, 60, 200, 220)));
    }

    protected static void UpdateBase(LegacyTracker tracker)
    {
        ArgumentNullException.ThrowIfNull(tracker);

        // ETHZ dataset - see the sibling (modern) TrackerTestBase for details/licensing notes.
        var bb = new Rect2d(286, 146, 70, 180);

        const string path = @"_data/image/ETHZ/seq03-img-left";

        foreach (var i in Enumerable.Range(0, 21))
        {
            var file = $"image_{i:D8}_0.png";

            using var mat = new Mat(Path.Combine(path, file));
            if (i == 0)
            {
                Assert.True(tracker.Init(mat, bb));
            }
            else
            {
                tracker.Update(mat, ref bb);
            }

            if (Debugger.IsAttached)
            {
                Directory.CreateDirectory(path);
                Cv2.Rectangle(
                    mat,
                    new Point((int)bb.X, (int)bb.Y),
                    new Point((int)(bb.X + bb.Width), (int)(bb.Y + bb.Height)),
                    new Scalar(0, 0, 255));
                Cv2.ImWrite(Path.Combine(path, file), mat);
            }
        }
    }
}
