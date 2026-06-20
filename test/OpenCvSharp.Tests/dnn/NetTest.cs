using OpenCvSharp.Dnn;
using Xunit;

namespace OpenCvSharp.Tests.Dnn;

public class NetTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public NetTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Empty()
    {
        using var net = new Net();
        Assert.True(net.Empty());
    }

    [Fact]
    public void GetLayerNames()
    {
        using var net = new Net();
        Assert.Empty(net.GetLayerNames());
    }
}
