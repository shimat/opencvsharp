using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using OpenCvSharp.Extensions;
using Xunit;

namespace OpenCvSharp.Tests.Extensions;

public class BitmapConverterTest : TestBase
{
    private readonly ITestOutputHelper testOutputHelper;

    public BitmapConverterTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void ToMat8bppIndexed()
    {
        using var bitmap = new Bitmap("_data/image/8bpp_indexed.png");
        Assert.Equal(PixelFormat.Format8bppIndexed, bitmap.PixelFormat);

        using var mat = BitmapConverter.ToMat(bitmap);
        Assert.NotNull(mat);
        Assert.False(mat.IsDisposed);
        Assert.False(mat.Empty());
        Assert.Equal(bitmap.Width, mat.Width);
        Assert.Equal(bitmap.Height, mat.Height);
        Assert.Equal(MatType.CV_8UC1, mat.Type());

        int width = bitmap.Width, height = bitmap.Height;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var bitmapPixel = bitmap.GetPixel(x, y);
                var matPixel = mat.Get<byte>(y, x);
                Assert.Equal(bitmapPixel.R, matPixel);
            }
        }
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void ToMat8bppIndexed8UC3()
    {
        using var bitmap = new Bitmap("_data/image/8bpp_indexed.png");
        Assert.Equal(PixelFormat.Format8bppIndexed, bitmap.PixelFormat);

        using var mat = new Mat(bitmap.Height, bitmap.Width, MatType.CV_8UC3);
        BitmapConverter.ToMat(bitmap, mat);
        Assert.NotNull(mat);
        Assert.False(mat.IsDisposed);
        Assert.False(mat.Empty());
        Assert.Equal(bitmap.Width, mat.Width);
        Assert.Equal(bitmap.Height, mat.Height);
        Assert.Equal(MatType.CV_8UC3, mat.Type());

        int width = bitmap.Width, height = bitmap.Height;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var bitmapPixel = bitmap.GetPixel(x, y);
                var matPixel = mat.Get<Vec3b>(y, x);
                Assert.Equal(bitmapPixel.R, matPixel.Item2);
                Assert.Equal(bitmapPixel.G, matPixel.Item1);
                Assert.Equal(bitmapPixel.B, matPixel.Item0);
            }
        }
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void ToMat24bppRgb()
    {
        using var bitmap = new Bitmap("_data/image/lenna.png");
        Assert.Equal(PixelFormat.Format24bppRgb, bitmap.PixelFormat);

        using var mat = BitmapConverter.ToMat(bitmap);
        Assert.NotNull(mat);
        Assert.False(mat.IsDisposed);
        Assert.False(mat.Empty());
        Assert.Equal(bitmap.Width, mat.Width);
        Assert.Equal(bitmap.Height, mat.Height);
        Assert.Equal(MatType.CV_8UC3, mat.Type());

        int width = bitmap.Width, height = bitmap.Height;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var bitmapPixel = bitmap.GetPixel(x, y);
                var matPixel = mat.Get<Vec3b>(y, x);
                Assert.Equal(bitmapPixel.R, matPixel.Item2);
                Assert.Equal(bitmapPixel.G, matPixel.Item1);
                Assert.Equal(bitmapPixel.B, matPixel.Item0);
            }
        }
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void ToMat32bppArgb()
    {
        using var bitmapOrg = new Bitmap("_data/image/issue/821.jpg");
        Assert.Equal(PixelFormat.Format24bppRgb, bitmapOrg.PixelFormat);

        // 24bpp -> 32bppArgb
        using var bitmap = new Bitmap(bitmapOrg.Width, bitmapOrg.Height, PixelFormat.Format32bppArgb);
        using (var graphics = Graphics.FromImage(bitmap))
        {
            graphics.DrawImage(bitmapOrg, new System.Drawing.Point(0, 0));
        }
        Assert.Equal(PixelFormat.Format32bppArgb, bitmap.PixelFormat);

        using var mat = BitmapConverter.ToMat(bitmap);
        Assert.NotNull(mat);
        Assert.False(mat.IsDisposed);
        Assert.False(mat.Empty());
        Assert.Equal(bitmap.Width, mat.Width);
        Assert.Equal(bitmap.Height, mat.Height);
        Assert.Equal(MatType.CV_8UC4, mat.Type());

        int width = bitmap.Width, height = bitmap.Height;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var bitmapPixel = bitmap.GetPixel(x, y);
                var matPixel = mat.Get<Vec4b>(y, x);
                Assert.Equal(bitmapPixel.A, matPixel.Item3);
                Assert.Equal(bitmapPixel.R, matPixel.Item2);
                Assert.Equal(bitmapPixel.G, matPixel.Item1);
                Assert.Equal(bitmapPixel.B, matPixel.Item0);
            }
        }
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void ToMat32bppRgb()
    {
        using var bitmapOrg = new Bitmap("_data/image/issue/821.jpg");
        Assert.Equal(PixelFormat.Format24bppRgb, bitmapOrg.PixelFormat);

        // 24bpp -> 32bppRgb
        using var bitmap = new Bitmap(bitmapOrg.Width, bitmapOrg.Height, PixelFormat.Format32bppRgb);
        using (var graphics = Graphics.FromImage(bitmap))
        {
            graphics.DrawImage(bitmapOrg, new System.Drawing.Point(0, 0));
        }
        Assert.Equal(PixelFormat.Format32bppRgb, bitmap.PixelFormat);

        using var mat = BitmapConverter.ToMat(bitmap);
        Assert.NotNull(mat);
        Assert.False(mat.IsDisposed);
        Assert.False(mat.Empty());
        Assert.Equal(bitmap.Width, mat.Width);
        Assert.Equal(bitmap.Height, mat.Height);
        Assert.Equal(MatType.CV_8UC3, mat.Type());

        int width = bitmap.Width, height = bitmap.Height;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var bitmapPixel = bitmap.GetPixel(x, y);
                var matPixel = mat.Get<Vec3b>(y, x);
                Assert.Equal(bitmapPixel.R, matPixel.Item2);
                Assert.Equal(bitmapPixel.G, matPixel.Item1);
                Assert.Equal(bitmapPixel.B, matPixel.Item0);
            }
        }
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void ToBitmap8bppIndexed()
    {
        using var mat = new Mat("_data/image/8bpp_indexed.png", ImreadModes.Grayscale);
        Assert.Equal(MatType.CV_8UC1, mat.Type());

        using var bitmap = BitmapConverter.ToBitmap(mat);
        Assert.NotNull(bitmap);
        Assert.Equal(mat.Width, bitmap.Width);
        Assert.Equal(mat.Height, bitmap.Height);
        Assert.Equal(PixelFormat.Format8bppIndexed, bitmap.PixelFormat);

        var matIndexer = mat.GetUnsafeGenericIndexer<byte>();
        int width = bitmap.Width, height = bitmap.Height;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var matPixel = matIndexer[y, x];
                var bitmapPixel = bitmap.GetPixel(x, y);
                Assert.Equal(matPixel, bitmapPixel.R);
            }
        }
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void ToBitmap24bppRgb()
    {
        using var mat = new Mat("_data/image/lenna.png", ImreadModes.Color);
        Assert.False(mat.Empty());
        Assert.Equal(MatType.CV_8UC3, mat.Type());

        using var bitmap = BitmapConverter.ToBitmap(mat);
        Assert.NotNull(bitmap);
        Assert.Equal(mat.Width, bitmap.Width);
        Assert.Equal(mat.Height, bitmap.Height);
        Assert.Equal(PixelFormat.Format24bppRgb, bitmap.PixelFormat);

        int width = bitmap.Width, height = bitmap.Height;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var matPixel = mat.Get<Vec3b>(y, x);
                var bitmapPixel = bitmap.GetPixel(x, y);
                Assert.Equal(matPixel.Item2, bitmapPixel.R);
                Assert.Equal(matPixel.Item1, bitmapPixel.G);
                Assert.Equal(matPixel.Item0, bitmapPixel.B);
            }
        }
    }

    [Fact]
    public void BitmapSource8Bit()
    {
        var blueColor8 = new Scalar(200, 0, 0);
        var greenColor8 = new Scalar(0, 200, 0);
        var redColor8 = new Scalar(0, 0, 200);

        using (var mat = new Mat(1, 1, MatType.CV_8UC3, blueColor8))
        {
            var bitmap = mat.ToBitmap();
            AssertPixelValue8bpp(blueColor8, bitmap);
        }
        using (var mat = new Mat(1, 1, MatType.CV_8UC3, greenColor8))
        {
            var bitmap = mat.ToBitmap();
            AssertPixelValue8bpp(greenColor8, bitmap);
        }
        using (var mat = new Mat(1, 1, MatType.CV_8UC3, redColor8))
        {
            var bitmap = mat.ToBitmap();
            AssertPixelValue8bpp(redColor8, bitmap);
        }
    }

    private void AssertPixelValue8bpp(Scalar expectedValue, Bitmap bitmap)
    {
        if (bitmap.Width != 1 || bitmap.Height != 1)
            throw new ArgumentException("1x1 image only");

        var pixels = new byte[3];
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, 1, 1), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        Marshal.Copy(bitmapData.Scan0, pixels, 0, 3);
        bitmap.UnlockBits(bitmapData);

        testOutputHelper.WriteLine("Expected: ({0},{1},{2})", expectedValue.Val0, expectedValue.Val1, expectedValue.Val2);
        testOutputHelper.WriteLine("Actual: ({0},{1},{2})", pixels[0], pixels[1], pixels[2]);
        Assert.Equal(expectedValue.Val0, Convert.ToDouble(pixels[0]), 9);
        Assert.Equal(expectedValue.Val1, Convert.ToDouble(pixels[1]), 9);
        Assert.Equal(expectedValue.Val2, Convert.ToDouble(pixels[2]), 9);
    }

    /// <summary>
    /// GDI+ pads 8bpp rows to a 4-byte boundary. ToMat must copy only the logical width of each row,
    /// otherwise it writes past the end of each dst row (and past the end of the dst buffer).
    /// </summary>
    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 3)]
    [InlineData(2, 2)]
    [InlineData(3, 4)]
    [InlineData(5, 3)]
    [InlineData(7, 2)]
    [InlineData(8, 2)]
    // ReSharper disable once InconsistentNaming
    public void ToMat8bppIndexedDoesNotWritePastDstRows(int width, int height)
    {
        const byte Guard = 0xCC;
        const int GuardLength = 8;

        using var bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
        var palette = bitmap.Palette;
        for (var i = 0; i < 256; i++)
            palette.Entries[i] = Color.FromArgb(i ^ 0x5A, i ^ 0x5A, i ^ 0x5A);
        bitmap.Palette = palette;

        var expected = new byte[width * height];
        var bits = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
        try
        {
            var stride = Math.Abs(bits.Stride);
            var row = new byte[stride];
            for (var y = 0; y < height; y++)
            {
                for (var i = 0; i < row.Length; i++)
                    row[i] = 0xFF; // padding bytes
                for (var x = 0; x < width; x++)
                {
                    var index = (byte)(y * width + x + 1);
                    row[x] = index;
                    expected[y * width + x] = (byte)(index ^ 0x5A);
                }
                Marshal.Copy(row, 0, bits.Scan0 + y * bits.Stride, stride);
            }
        }
        finally
        {
            bitmap.UnlockBits(bits);
        }

        var guarded = new byte[width * height + GuardLength];
        for (var i = 0; i < guarded.Length; i++)
            guarded[i] = Guard;
        using (var mat = Mat.FromPixelData(height, width, MatType.CV_8UC1, guarded))
        {
            BitmapConverter.ToMat(bitmap, mat);
        }

        for (var i = 0; i < expected.Length; i++)
            Assert.Equal(expected[i], guarded[i]);
        for (var i = expected.Length; i < guarded.Length; i++)
            Assert.Equal(Guard, guarded[i]);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(3, 2)]
    [InlineData(5, 3)]
    // ReSharper disable once InconsistentNaming
    public void ToMat8bppIndexed8UC3DoesNotCorruptMemory(int width, int height)
    {
        using var bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
        var palette = bitmap.Palette;
        for (var i = 0; i < 256; i++)
            palette.Entries[i] = Color.FromArgb(i, 255 - i, i / 2);
        bitmap.Palette = palette;
        var bits = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
        try
        {
            for (var y = 0; y < height; y++)
            {
                var row = new byte[Math.Abs(bits.Stride)];
                for (var x = 0; x < width; x++)
                    row[x] = (byte)(y * width + x + 1);
                Marshal.Copy(row, 0, bits.Scan0 + y * bits.Stride, row.Length);
            }
        }
        finally
        {
            bitmap.UnlockBits(bits);
        }

        using var mat = new Mat(height, width, MatType.CV_8UC3);
        BitmapConverter.ToMat(bitmap, mat);

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var i = y * width + x + 1;
                var v = mat.Get<Vec3b>(y, x);
                Assert.Equal(i / 2, v.Item0); // B
                Assert.Equal(255 - i, v.Item1); // G
                Assert.Equal(i, v.Item2); // R
            }
        }
    }
}
