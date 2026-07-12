using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace OpenCvSharp.AvaloniaExtensions;

/// <summary>
/// Static class which provides conversion between Avalonia.Media.Imaging.WriteableBitmap and Mat.
/// The default (Skia) rendering backend only supports a handful of pixel formats for WriteableBitmap
/// (Bgra8888/Rgba8888/Rgb32/Rgb565); see
/// https://github.com/AvaloniaUI/Avalonia/blob/master/src/Skia/Avalonia.Skia/SkiaSharpExtensions.cs.
/// This converter always writes Bgra8888 and reads Bgra8888/Rgba8888/Rgb32.
/// </summary>
public static class WriteableBitmapConverter
{
    /// <summary>
    /// Converts Mat to WriteableBitmap. 1/3/4-channel Mats are all accepted; 1 and 3-channel Mats
    /// are converted to BGRA first since Bgra8888 is the only format this method creates.
    /// </summary>
    /// <param name="src">Input Mat. Must have 1, 3, or 4 channels.</param>
    /// <param name="alphaFormat">Alpha format of the created WriteableBitmap.</param>
    /// <returns>WriteableBitmap</returns>
    public static WriteableBitmap ToWriteableBitmap(this Mat src, AlphaFormat alphaFormat = AlphaFormat.Opaque)
    {
        ArgumentNullException.ThrowIfNull(src);

        var dst = new WriteableBitmap(
            new PixelSize(src.Width, src.Height), new Vector(96, 96), PixelFormats.Bgra8888, alphaFormat);
        ToWriteableBitmap(src, dst);
        return dst;
    }

    /// <summary>
    /// Converts Mat to WriteableBitmap. This method is more efficient because a new instance of
    /// WriteableBitmap is not allocated.
    /// </summary>
    /// <param name="src">Input Mat. Must have 1, 3, or 4 channels.</param>
    /// <param name="dst">Output WriteableBitmap. Must be Bgra8888 or Rgba8888.</param>
    public static void ToWriteableBitmap(Mat src, WriteableBitmap dst)
    {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(dst);
        if (src.Width != dst.PixelSize.Width || src.Height != dst.PixelSize.Height)
            throw new ArgumentException("size of src must be equal to size of dst");
        if (src.Dims > 2)
            throw new ArgumentException("Mat dimensions must be 2");
        if (dst.Format != PixelFormats.Bgra8888 && dst.Format != PixelFormats.Rgba8888)
            throw new NotSupportedException($"Not supported PixelFormat for writing: {dst.Format}");

        var bgra = ToBgra(src);
        try
        {
            var toWrite = dst.Format == PixelFormats.Rgba8888 ? SwapRedBlue(bgra) : bgra;
            try
            {
                using var framebuffer = dst.Lock();
                toWrite.CopyPixelsTo(framebuffer.Address, framebuffer.RowBytes);
            }
            finally
            {
                if (toWrite != bgra)
                    toWrite.Dispose();
            }
        }
        finally
        {
            if (bgra != src)
                bgra.Dispose();
        }
    }

    /// <summary>
    /// Converts WriteableBitmap to Mat (CV_8UC4).
    /// </summary>
    /// <param name="src">Input WriteableBitmap. Must be Bgra8888, Rgba8888, or Rgb32.</param>
    /// <returns>Mat</returns>
    public static Mat ToMat(this WriteableBitmap src)
    {
        ArgumentNullException.ThrowIfNull(src);

        var dst = new Mat(src.PixelSize.Height, src.PixelSize.Width, MatType.CV_8UC4);
        ToMat(src, dst);
        return dst;
    }

    /// <summary>
    /// Converts WriteableBitmap to Mat.
    /// </summary>
    /// <param name="src">Input WriteableBitmap. Must be Bgra8888, Rgba8888, or Rgb32.</param>
    /// <param name="dst">Output Mat. Must have 4 channels.</param>
    public static void ToMat(this WriteableBitmap src, Mat dst)
    {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(dst);
        if (src.PixelSize.Width != dst.Width || src.PixelSize.Height != dst.Height)
            throw new ArgumentException("size of src must be equal to size of dst");
        if (dst.Channels() != 4)
            throw new ArgumentException("channels of dst must be 4", nameof(dst));
        if (src.Format == PixelFormats.Rgb565)
            throw new NotSupportedException(
                "Rgb565 has no lossless Mat equivalent and is not supported by ToMat");
        if (src.Format != PixelFormats.Bgra8888 && src.Format != PixelFormats.Rgba8888 &&
            src.Format != PixelFormats.Rgb32)
            throw new NotSupportedException($"Not supported PixelFormat: {src.Format}");

        using (var framebuffer = src.Lock())
        {
            dst.CopyPixelsFrom(framebuffer.Address, framebuffer.RowBytes);
        }

        // Rgba8888 and Rgb32 (SKColorType.Rgb888x: R,G,B,X byte order) are both red-first,
        // unlike Bgra8888; undo that here so dst stays in Mat's blue-first (BGR/BGRA) order.
        if (src.Format == PixelFormats.Rgba8888 || src.Format == PixelFormats.Rgb32)
            Cv2.CvtColor(dst, dst, ColorConversionCodes.BGRA2RGBA);
    }

    /// <summary>
    /// Converts src to a 4-channel (BGRA) Mat, reusing src as-is when it already has 4 channels.
    /// </summary>
    private static Mat ToBgra(Mat src)
    {
        switch (src.Channels())
        {
            case 4:
                return src;
            case 3:
            {
                var dst = new Mat();
                Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2BGRA);
                return dst;
            }
            case 1:
            {
                var dst = new Mat();
                Cv2.CvtColor(src, dst, ColorConversionCodes.GRAY2BGRA);
                return dst;
            }
            default:
                throw new ArgumentException("src must have 1, 3, or 4 channels", nameof(src));
        }
    }

    private static Mat SwapRedBlue(Mat src)
    {
        var dst = new Mat();
        Cv2.CvtColor(src, dst, ColorConversionCodes.BGRA2RGBA);
        return dst;
    }
}
