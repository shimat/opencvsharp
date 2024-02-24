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
    }

    // TODO
    /*[Fact]
    public void DoNotCrash16F()
    {
        var matType = MatType.MakeType(7, 3);
        using var src = new Mat(4, 3, matType);
        using var dst = new Mat();
        Cv2.Compare(src, src, dst, CmpTypes.EQ);
    }*/
}
