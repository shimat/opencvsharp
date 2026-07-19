using OpenCvSharp.Internal.Util;
using Xunit;

namespace OpenCvSharp.Tests;

public class SaturateCastTest
{
    [Theory]
    [InlineData(10, 10)]
    [InlineData(-1, 0)]
    [InlineData(256, 255)]
    public void ToByteFromInt(int from, byte to)
    {
        Assert.Equal(to, SaturateCast.ToByte(from));
    }

    [Theory]
    [InlineData(1.2345, 1)]
    [InlineData(-10000.98765, 0)]
    [InlineData(10000.12345, 255)]
    public void ToByteFromDouble(double from, byte to)
    {
        Assert.Equal(to, SaturateCast.ToByte(from));
    }

    [Theory]
    [InlineData(10.4f, 10u)]
    [InlineData(-1.5f, 0u)]
    [InlineData(-0.5f, 0u)]
    public void ToUInt32FromFloat(float from, uint to)
    {
        Assert.Equal(to, SaturateCast.ToUInt32(from));
    }

    [Theory]
    [InlineData(10.4, 10u)]
    [InlineData(-1.5, 0u)]
    [InlineData(-0.5, 0u)]
    public void ToUInt32FromDouble(double from, uint to)
    {
        Assert.Equal(to, SaturateCast.ToUInt32(from));
    }
}
