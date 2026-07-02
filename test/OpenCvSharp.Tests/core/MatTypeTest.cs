using Xunit;

// ReSharper disable ReturnValueOfPureMethodIsNotUsed

namespace OpenCvSharp.Tests.Core;

public class MatTypeTest : TestBase
{
    [Fact]
    public void CreateByChannels()
    {
        Assert.Equal(MatType.CV_8UC1, MatType.CV_8UC(1));
        Assert.Equal(MatType.CV_8UC2, MatType.CV_8UC(2));
        Assert.Equal(MatType.CV_8UC3, MatType.CV_8UC(3));
        Assert.Equal(MatType.CV_8UC4, MatType.CV_8UC(4));
        Assert.Equal(MatType.CV_8SC1, MatType.CV_8SC(1));
        Assert.Equal(MatType.CV_8SC2, MatType.CV_8SC(2));
        Assert.Equal(MatType.CV_8SC3, MatType.CV_8SC(3));
        Assert.Equal(MatType.CV_8SC4, MatType.CV_8SC(4));
        Assert.Equal(MatType.CV_16UC1, MatType.CV_16UC(1));
        Assert.Equal(MatType.CV_16UC2, MatType.CV_16UC(2));
        Assert.Equal(MatType.CV_16UC3, MatType.CV_16UC(3));
        Assert.Equal(MatType.CV_16UC4, MatType.CV_16UC(4));
        Assert.Equal(MatType.CV_16SC1, MatType.CV_16SC(1));
        Assert.Equal(MatType.CV_16SC2, MatType.CV_16SC(2));
        Assert.Equal(MatType.CV_16SC3, MatType.CV_16SC(3));
        Assert.Equal(MatType.CV_16SC4, MatType.CV_16SC(4));
        Assert.Equal(MatType.CV_32SC1, MatType.CV_32SC(1));
        Assert.Equal(MatType.CV_32SC2, MatType.CV_32SC(2));
        Assert.Equal(MatType.CV_32SC3, MatType.CV_32SC(3));
        Assert.Equal(MatType.CV_32SC4, MatType.CV_32SC(4));
        Assert.Equal(MatType.CV_32FC1, MatType.CV_32FC(1));
        Assert.Equal(MatType.CV_32FC2, MatType.CV_32FC(2));
        Assert.Equal(MatType.CV_32FC3, MatType.CV_32FC(3));
        Assert.Equal(MatType.CV_32FC4, MatType.CV_32FC(4));
        Assert.Equal(MatType.CV_64FC1, MatType.CV_64FC(1));
        Assert.Equal(MatType.CV_64FC2, MatType.CV_64FC(2));
        Assert.Equal(MatType.CV_64FC3, MatType.CV_64FC(3));
        Assert.Equal(MatType.CV_64FC4, MatType.CV_64FC(4));
        Assert.Equal(MatType.CV_16FC1, MatType.CV_16FC(1));
        Assert.Equal(MatType.CV_16FC2, MatType.CV_16FC(2));
        Assert.Equal(MatType.CV_16FC3, MatType.CV_16FC(3));
        Assert.Equal(MatType.CV_16FC4, MatType.CV_16FC(4));
    }

    [Fact]
    public void MakeType()
    {
        Assert.Equal(MatType.CV_8UC(1), MatType.MakeType(MatType.CV_8U, 1));
        Assert.Equal(MatType.CV_8UC(2), MatType.MakeType(MatType.CV_8U, 2));
        Assert.Equal(MatType.CV_8UC(3), MatType.MakeType(MatType.CV_8U, 3));
        Assert.Equal(MatType.CV_8UC(4), MatType.MakeType(MatType.CV_8U, 4));
        Assert.Equal(MatType.CV_8UC(5), MatType.MakeType(MatType.CV_8U, 5));
        Assert.Equal(MatType.CV_8UC(6), MatType.MakeType(MatType.CV_8U, 6));
        Assert.Equal(MatType.CV_8SC(1), MatType.MakeType(MatType.CV_8S, 1));
        Assert.Equal(MatType.CV_8SC(2), MatType.MakeType(MatType.CV_8S, 2));
        Assert.Equal(MatType.CV_8SC(3), MatType.MakeType(MatType.CV_8S, 3));
        Assert.Equal(MatType.CV_8SC(4), MatType.MakeType(MatType.CV_8S, 4));
        Assert.Equal(MatType.CV_8SC(5), MatType.MakeType(MatType.CV_8S, 5));
        Assert.Equal(MatType.CV_8SC(6), MatType.MakeType(MatType.CV_8S, 6));
        Assert.Equal(MatType.CV_16UC(1), MatType.MakeType(MatType.CV_16U, 1));
        Assert.Equal(MatType.CV_16UC(2), MatType.MakeType(MatType.CV_16U, 2));
        Assert.Equal(MatType.CV_16UC(3), MatType.MakeType(MatType.CV_16U, 3));
        Assert.Equal(MatType.CV_16UC(4), MatType.MakeType(MatType.CV_16U, 4));
        Assert.Equal(MatType.CV_16UC(5), MatType.MakeType(MatType.CV_16U, 5));
        Assert.Equal(MatType.CV_16UC(6), MatType.MakeType(MatType.CV_16U, 6));
        Assert.Equal(MatType.CV_16SC(1), MatType.MakeType(MatType.CV_16S, 1));
        Assert.Equal(MatType.CV_16SC(2), MatType.MakeType(MatType.CV_16S, 2));
        Assert.Equal(MatType.CV_16SC(3), MatType.MakeType(MatType.CV_16S, 3));
        Assert.Equal(MatType.CV_16SC(4), MatType.MakeType(MatType.CV_16S, 4));
        Assert.Equal(MatType.CV_16SC(5), MatType.MakeType(MatType.CV_16S, 5));
        Assert.Equal(MatType.CV_16SC(6), MatType.MakeType(MatType.CV_16S, 6));
        Assert.Equal(MatType.CV_32SC(1), MatType.MakeType(MatType.CV_32S, 1));
        Assert.Equal(MatType.CV_32SC(2), MatType.MakeType(MatType.CV_32S, 2));
        Assert.Equal(MatType.CV_32SC(3), MatType.MakeType(MatType.CV_32S, 3));
        Assert.Equal(MatType.CV_32SC(4), MatType.MakeType(MatType.CV_32S, 4));
        Assert.Equal(MatType.CV_32SC(5), MatType.MakeType(MatType.CV_32S, 5));
        Assert.Equal(MatType.CV_32SC(6), MatType.MakeType(MatType.CV_32S, 6));
        Assert.Equal(MatType.CV_32FC(1), MatType.MakeType(MatType.CV_32F, 1));
        Assert.Equal(MatType.CV_32FC(2), MatType.MakeType(MatType.CV_32F, 2));
        Assert.Equal(MatType.CV_32FC(3), MatType.MakeType(MatType.CV_32F, 3));
        Assert.Equal(MatType.CV_32FC(4), MatType.MakeType(MatType.CV_32F, 4));
        Assert.Equal(MatType.CV_32FC(5), MatType.MakeType(MatType.CV_32F, 5));
        Assert.Equal(MatType.CV_32FC(6), MatType.MakeType(MatType.CV_32F, 6));
        Assert.Equal(MatType.CV_64FC(1), MatType.MakeType(MatType.CV_64F, 1));
        Assert.Equal(MatType.CV_64FC(2), MatType.MakeType(MatType.CV_64F, 2));
        Assert.Equal(MatType.CV_64FC(3), MatType.MakeType(MatType.CV_64F, 3));
        Assert.Equal(MatType.CV_64FC(4), MatType.MakeType(MatType.CV_64F, 4));
        Assert.Equal(MatType.CV_64FC(5), MatType.MakeType(MatType.CV_64F, 5));
        Assert.Equal(MatType.CV_64FC(6), MatType.MakeType(MatType.CV_64F, 6));
        Assert.Equal(MatType.CV_16FC(1), MatType.MakeType(MatType.CV_16F, 1));
        Assert.Equal(MatType.CV_16FC(2), MatType.MakeType(MatType.CV_16F, 2));
        Assert.Equal(MatType.CV_16FC(3), MatType.MakeType(MatType.CV_16F, 3));
        Assert.Equal(MatType.CV_16FC(4), MatType.MakeType(MatType.CV_16F, 4));
        Assert.Equal(MatType.CV_16FC(5), MatType.MakeType(MatType.CV_16F, 5));
        Assert.Equal(MatType.CV_16FC(6), MatType.MakeType(MatType.CV_16F, 6));
    }

    [Fact]
    public void DoNotCrash16F()
    {
        var matType = MatType.CV_16FC3;
        using var src = new Mat(4, 3, matType);
        using var dst = new Mat();
        // Transpose supports all types including CV_16F
        Cv2.Transpose(src, dst);
        Assert.Equal(matType, src.Type());
        Assert.Equal("CV_16FC3", matType.ToString());
    }

    // OpenCV 5 widened the depth field to 5 bits, so channels are shifted by 5 (CV_CN_SHIFT == 5).
    // These tests pin down the exact integer encoding to guard against accidental reverts to the
    // OpenCV 4 layout (shift 3).
    [Theory]
    [InlineData(MatType.CV_8U, 0)]
    [InlineData(MatType.CV_8S, 1)]
    [InlineData(MatType.CV_16U, 2)]
    [InlineData(MatType.CV_16S, 3)]
    [InlineData(MatType.CV_32S, 4)]
    [InlineData(MatType.CV_32F, 5)]
    [InlineData(MatType.CV_64F, 6)]
    [InlineData(MatType.CV_16F, 7)]
    [InlineData(MatType.CV_16BF, 8)]
    [InlineData(MatType.CV_Bool, 9)]
    [InlineData(MatType.CV_64U, 10)]
    [InlineData(MatType.CV_64S, 11)]
    [InlineData(MatType.CV_32U, 12)]
    public void DepthConstants(int depth, int expected)
    {
        Assert.Equal(expected, depth);
    }

    [Theory]
    // value == depth + ((channels - 1) << 5)
    [InlineData(0, 1, 0)]    // CV_8UC1
    [InlineData(0, 2, 32)]   // CV_8UC2
    [InlineData(0, 3, 64)]   // CV_8UC3
    [InlineData(0, 4, 96)]   // CV_8UC4
    [InlineData(1, 1, 1)]    // CV_8SC1
    [InlineData(5, 1, 5)]    // CV_32FC1
    [InlineData(5, 4, 101)]  // CV_32FC4 == 5 + (3 << 5)
    [InlineData(6, 1, 6)]    // CV_64FC1
    [InlineData(7, 3, 71)]   // CV_16FC3 == 7 + (2 << 5)
    public void MakeTypeEncoding(int depth, int channels, int expectedValue)
    {
        Assert.Equal(expectedValue, MatType.MakeType(depth, channels).Value);
    }

    [Theory]
    [InlineData(0, 1, MatType.CV_8U, 1)]
    [InlineData(0, 4, MatType.CV_8U, 4)]
    [InlineData(5, 4, MatType.CV_32F, 4)]   // CV_32FC4
    [InlineData(7, 3, MatType.CV_16F, 3)]   // CV_16FC3
    [InlineData(4, 64, MatType.CV_32S, 64)] // high channel count still decodes correctly
    public void DepthAndChannels(int depth, int channels, int expectedDepth, int expectedChannels)
    {
        var type = MatType.MakeType(depth, channels);
        Assert.Equal(expectedDepth, type.Depth);
        Assert.Equal(expectedChannels, type.Channels);
    }

    [Fact]
    public void NewDepthTypesRoundTrip()
    {
        Assert.Equal(MatType.CV_16BFC1, MatType.CV_16BFC(1));
        Assert.Equal(MatType.CV_16BFC4, MatType.CV_16BFC(4));
        Assert.Equal(MatType.CV_BoolC1, MatType.CV_BoolC(1));
        Assert.Equal(MatType.CV_BoolC4, MatType.CV_BoolC(4));
        Assert.Equal(MatType.CV_64UC1, MatType.CV_64UC(1));
        Assert.Equal(MatType.CV_64UC4, MatType.CV_64UC(4));
        Assert.Equal(MatType.CV_64SC1, MatType.CV_64SC(1));
        Assert.Equal(MatType.CV_64SC4, MatType.CV_64SC(4));
        Assert.Equal(MatType.CV_32UC1, MatType.CV_32UC(1));
        Assert.Equal(MatType.CV_32UC4, MatType.CV_32UC(4));
    }

    [Theory]
    [InlineData(MatType.CV_8U, 1, "CV_8UC1")]
    [InlineData(MatType.CV_8U, 3, "CV_8UC3")]
    [InlineData(MatType.CV_32F, 4, "CV_32FC4")]
    [InlineData(MatType.CV_16F, 3, "CV_16FC3")]
    [InlineData(MatType.CV_16BF, 1, "CV_16BFC1")]
    [InlineData(MatType.CV_Bool, 2, "CV_BoolC2")]
    [InlineData(MatType.CV_64U, 3, "CV_64UC3")]
    [InlineData(MatType.CV_64S, 4, "CV_64SC4")]
    [InlineData(MatType.CV_32U, 1, "CV_32UC1")]
    public void ToStringFormat(int depth, int channels, string expected)
    {
        Assert.Equal(expected, MatType.MakeType(depth, channels).ToString());
    }

    [Fact]
    public void ToStringManyChannels()
    {
        Assert.Equal("CV_8UC(8)", MatType.CV_8UC(8).ToString());
    }

    [Fact]
    public void MaxChannels()
    {
        // OpenCV 5 reduced CV_CN_MAX from 512 to 128.
        Assert.Equal(127, MatType.CV_8UC(127).Channels);
        Assert.Throws<OpenCvSharpException>(() => MatType.CV_8UC(128));
    }

    [Fact]
    public void IsIntegerCoversNewDepths()
    {
        // Integer depths (mirrors OpenCV's CV_IS_INT_TYPE bitmask 0x1e1f).
        Assert.True(MatType.CV_8UC1.IsInteger);
        Assert.True(MatType.CV_8SC1.IsInteger);
        Assert.True(MatType.CV_16UC1.IsInteger);
        Assert.True(MatType.CV_16SC1.IsInteger);
        Assert.True(MatType.CV_32SC1.IsInteger);
        Assert.True(MatType.CV_BoolC1.IsInteger);
        Assert.True(MatType.CV_64UC1.IsInteger);
        Assert.True(MatType.CV_64SC1.IsInteger);
        Assert.True(MatType.CV_32UC1.IsInteger);

        // Floating-point depths.
        Assert.False(MatType.CV_32FC1.IsInteger);
        Assert.False(MatType.CV_64FC1.IsInteger);
        Assert.False(MatType.CV_16FC1.IsInteger);
        Assert.False(MatType.CV_16BFC1.IsInteger);
    }
}
