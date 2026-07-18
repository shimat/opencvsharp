using OpenCvSharp.Tracking.Legacy;
using Xunit;

namespace OpenCvSharp.Tests.Tracking.Legacy;

public class TrackerMedianFlowTest : LegacyTrackerTestBase
{
    [Fact]
    public void Init()
    {
        using var tracker = TrackerMedianFlow.Create();
        InitBase(tracker);
    }

    [Fact]
    public void Update()
    {
        using var tracker = TrackerMedianFlow.Create();
        UpdateBase(tracker);
    }

    [Fact]
    public void CreateWithParams()
    {
        var parameters = new TrackerMedianFlow.Params
        {
            PointsInGrid = 10,
            WinSize = new Size(3, 3),
            MaxLevel = 5,
            TermCriteria = new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 20, 0.3),
            WinSizeNCC = new Size(30, 30),
            MaxMedianLengthOfDisplacementDifference = 10,
        };

        using var tracker = TrackerMedianFlow.Create(parameters);
        InitBase(tracker);
    }
}
