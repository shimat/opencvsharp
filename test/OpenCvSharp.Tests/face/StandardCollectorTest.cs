using OpenCvSharp.Face;
using Xunit;

namespace OpenCvSharp.Tests.Face;

public class StandardCollectorTest
{
    [Fact]
    public void CreateHasEmptyResult()
    {
        using var collector = StandardCollector.Create();

        Assert.Equal(-1, collector.MinLabel);
        Assert.Equal(double.MaxValue, collector.MinDistance);
        Assert.Empty(collector.GetResults());
        Assert.Empty(collector.GetResultsMap());
    }

    [Fact]
    public void InitAndCollectAreExposed()
    {
        using var collector = StandardCollector.Create();

        collector.Init(2);
        Assert.True(collector.Collect(4, 2.5));
        Assert.True(collector.Collect(8, 1.25));

        Assert.Equal(8, collector.MinLabel);
        Assert.Equal(1.25, collector.MinDistance);
    }
}
