using OpenCvSharp.Tracking.Legacy;
using Xunit;

namespace OpenCvSharp.Tests.Tracking.Legacy;

// ReSharper disable once InconsistentNaming
public class TrackerKCFTest : LegacyTrackerTestBase
{
    [Fact]
    public void Init()
    {
        using var tracker = TrackerKCF.Create();
        InitBase(tracker);
    }

    [Fact]
    public void Update()
    {
        using var tracker = TrackerKCF.Create();
        UpdateBase(tracker);
    }

    [Fact]
    public void CreateWithParams()
    {
        var parameters = new TrackerKCF.Params
        {
            CompressFeature = true,
            CompressedSize = 1,
            Resize = true,
            DescNpca = 1,
            DescPca = 1,
        };

        using var tracker = TrackerKCF.Create(parameters);
        GC.KeepAlive(tracker);
    }
}
