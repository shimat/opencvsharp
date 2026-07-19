using Xunit;

namespace OpenCvSharp.Tests.Core;

public class MatMemoryManagerTest : TestBase
{
    [Fact]
    public void DataOwnerWrapsOriginalMat()
    {
        using var mat = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });
        using var manager = new MatMemoryManager<byte>(mat, isDataOwner: true);

        var span = manager.GetSpan();
        Assert.Equal(4, span.Length);
        Assert.Equal(1, span[0]);
    }

    [Fact]
    public void NonDataOwnerWrapsSharedCopyOfMat()
    {
        using var mat = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 1, 2, 3, 4 });
        using var manager = new MatMemoryManager<byte>(mat, isDataOwner: false);

        var span = manager.GetSpan();
        Assert.Equal(4, span.Length);
        Assert.Equal(1, span[0]);

        mat.Set(0, 0, (byte)9);
        Assert.Equal(9, manager.GetSpan()[0]);
    }
}
