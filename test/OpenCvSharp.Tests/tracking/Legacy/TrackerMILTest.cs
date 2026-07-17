using OpenCvSharp.Tracking.Legacy;
using Xunit;

namespace OpenCvSharp.Tests.Tracking.Legacy;

// OpenCvSharp.TrackerMIL (the modern, video-module tracker) would otherwise win this simple name via
// the OpenCvSharp.Tests.Tracking.Legacy -> ... -> OpenCvSharp outer-scope nesting rule (a using-alias
// placed above a file-scoped `namespace X;` line resolves at compilation-unit/global scope, which is
// checked AFTER that outer-scope member match - so the alias must instead be placed after the
// file-scoped namespace declaration, where it resolves inside this namespace's own scope instead).
using TrackerMIL = OpenCvSharp.Tracking.Legacy.TrackerMIL;

// ReSharper disable once InconsistentNaming
public class TrackerMILTest : LegacyTrackerTestBase
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
    public void CreateWithParams()
    {
        var parameters = new TrackerMIL.Params
        {
            SamplerInitInRadius = 3,
            SamplerInitMaxNegNum = 65,
            SamplerSearchWinSize = 25,
            SamplerTrackInRadius = 4,
            SamplerTrackMaxPosNum = 100000,
            SamplerTrackMaxNegNum = 65,
            FeatureSetNumFeatures = 250,
        };

        using var tracker = TrackerMIL.Create(parameters);
        InitBase(tracker);
    }

    [Fact]
    public void Upgrade()
    {
        using var legacyTracker = TrackerMIL.Create();
        using var upgraded = LegacyTrackingApi.Upgrade(legacyTracker);

        using var image = LoadImage("lenna.png");
        upgraded.Init(image, new Rect(220, 60, 200, 220));
    }
}
