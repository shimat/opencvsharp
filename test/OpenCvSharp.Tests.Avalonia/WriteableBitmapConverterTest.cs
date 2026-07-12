using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Headless.XUnit;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using OpenCvSharp.AvaloniaExtensions;
using Xunit;

namespace OpenCvSharp.Tests.Avalonia;

public class WriteableBitmapConverterTest
{
    [AvaloniaFact]
    public void ToWriteableBitmapBgra()
    {
        var expected = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        using var mat = Mat.FromPixelData(1, 2, MatType.CV_8UC4, expected);

        using var wb = mat.ToWriteableBitmap();

        Assert.Equal(PixelFormats.Bgra8888, wb.Format);
        Assert.Equal(expected, ReadPixels(wb, expected.Length));
    }

    [AvaloniaFact]
    public void ToWriteableBitmapFromBgr()
    {
        // one BGR pixel: B=10, G=20, R=30
        var bgr = new byte[] { 10, 20, 30 };
        using var mat = Mat.FromPixelData(1, 1, MatType.CV_8UC3, bgr);

        using var wb = mat.ToWriteableBitmap();

        Assert.Equal(new byte[] { 10, 20, 30, 255 }, ReadPixels(wb, 4));
    }

    [AvaloniaFact]
    public void ToWriteableBitmapFromGray()
    {
        var gray = new byte[] { 42 };
        using var mat = Mat.FromPixelData(1, 1, MatType.CV_8UC1, gray);

        using var wb = mat.ToWriteableBitmap();

        Assert.Equal(new byte[] { 42, 42, 42, 255 }, ReadPixels(wb, 4));
    }

    [AvaloniaFact]
    public void ToWriteableBitmapSubmatrix()
    {
        var expected = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        using var mat = Mat.FromPixelData(3, 1, MatType.CV_8UC4, expected);
        using var submat = mat[1, 3, 0, 1];
        Assert.True(submat.IsSubmatrix());

        using var wb = submat.ToWriteableBitmap();

        Assert.Equal(expected[4..12], ReadPixels(wb, 8));
    }

    [AvaloniaFact]
    public void ToWriteableBitmapInPlaceReusesDestination()
    {
        using var mat1 = Mat.FromPixelData(1, 1, MatType.CV_8UC4, new byte[] { 1, 2, 3, 4 });
        using var mat2 = Mat.FromPixelData(1, 1, MatType.CV_8UC4, new byte[] { 5, 6, 7, 8 });
        using var wb = mat1.ToWriteableBitmap();

        WriteableBitmapConverter.ToWriteableBitmap(mat2, wb);

        Assert.Equal(new byte[] { 5, 6, 7, 8 }, ReadPixels(wb, 4));
    }

    [AvaloniaFact]
    public void ToWriteableBitmapUnsupportedDestinationFormatThrows()
    {
        using var mat = new Mat(1, 1, MatType.CV_8UC4);
        using var wb = new WriteableBitmap(new PixelSize(1, 1), new Vector(96, 96), PixelFormats.Rgb565);

        Assert.Throws<NotSupportedException>(() => WriteableBitmapConverter.ToWriteableBitmap(mat, wb));
    }

    [AvaloniaFact]
    public void ToMatBgra8888()
    {
        using var wb = new WriteableBitmap(new PixelSize(1, 1), new Vector(96, 96), PixelFormats.Bgra8888);
        WritePixels(wb, new byte[] { 11, 22, 33, 44 });

        using var mat = wb.ToMat();

        Assert.Equal(MatType.CV_8UC4, mat.Type());
        var indexer = mat.GetUnsafeGenericIndexer<Vec4b>();
        Assert.Equal(new Vec4b(11, 22, 33, 44), indexer[0, 0]);
    }

    [AvaloniaFact]
    public void ToMatRgba8888SwapsRedAndBlue()
    {
        using var wb = new WriteableBitmap(new PixelSize(1, 1), new Vector(96, 96), PixelFormats.Rgba8888);
        // R=11, G=22, B=33, A=44
        WritePixels(wb, new byte[] { 11, 22, 33, 44 });

        using var mat = wb.ToMat();

        // Mat is BGRA-ordered, so R and B must be swapped relative to the Rgba8888 source bytes.
        var indexer = mat.GetUnsafeGenericIndexer<Vec4b>();
        Assert.Equal(new Vec4b(33, 22, 11, 44), indexer[0, 0]);
    }

    [AvaloniaFact]
    public void ToMatRgb565Throws()
    {
        using var wb = new WriteableBitmap(new PixelSize(1, 1), new Vector(96, 96), PixelFormats.Rgb565);
        Assert.Throws<NotSupportedException>(() => wb.ToMat());
    }

    private static byte[] ReadPixels(WriteableBitmap wb, int byteCount)
    {
        using var framebuffer = wb.Lock();
        var buffer = new byte[byteCount];
        Marshal.Copy(framebuffer.Address, buffer, 0, byteCount);
        return buffer;
    }

    private static void WritePixels(WriteableBitmap wb, byte[] data)
    {
        using var framebuffer = wb.Lock();
        Marshal.Copy(data, 0, framebuffer.Address, data.Length);
    }
}
