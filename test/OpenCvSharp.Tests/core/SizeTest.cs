using Xunit;

namespace OpenCvSharp.Tests.Core;

public class SizeTest
{
    [Fact]
    public void Size2f()
    {
        var obj = new Size2f(0.5, 0.5);
        Assert.Equal(0.5, obj.Width, 6);
        Assert.Equal(0.5, obj.Height, 6);

        obj = new Size2f(0.5f, 0.5f);
        Assert.Equal(0.5f, obj.Width, 1e-6);
        Assert.Equal(0.5f, obj.Height, 1e-6);
    } 
}
