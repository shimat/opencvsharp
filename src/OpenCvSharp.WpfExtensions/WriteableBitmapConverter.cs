#if WINDOWS && (NET48 || NETCOREAPP3_1_OR_GREATER)
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OpenCvSharp.WpfExtensions;

/// <summary>
/// Static class which provides conversion between System.Windows.Media.Imaging.WriteableBitmap and Mat
/// </summary>
public static class WriteableBitmapConverter
{
    private static readonly Dictionary<PixelFormat, int> optimumChannels;
    private static readonly Dictionary<PixelFormat, MatType> optimumTypes;

#pragma warning disable CA1810 
    static WriteableBitmapConverter()
#pragma warning restore CA1810 
    {
        optimumChannels = new Dictionary<PixelFormat, int>();
        optimumChannels[PixelFormats.Gray2] =
        optimumChannels[PixelFormats.Gray4] =
        optimumChannels[PixelFormats.Gray8] =
        optimumChannels[PixelFormats.Gray16] =
        optimumChannels[PixelFormats.Gray32Float] =
        optimumChannels[PixelFormats.Indexed1] =
        optimumChannels[PixelFormats.Indexed2] =
        optimumChannels[PixelFormats.Indexed4] =
        optimumChannels[PixelFormats.Indexed8] =
        optimumChannels[PixelFormats.BlackWhite] = 1;
        optimumChannels[PixelFormats.Bgr24] =
        optimumChannels[PixelFormats.Bgr555] =
        optimumChannels[PixelFormats.Bgr565] =
        optimumChannels[PixelFormats.Rgb24] =
        optimumChannels[PixelFormats.Rgb48] =
        optimumChannels[PixelFormats.Rgb128Float] = 3;
        optimumChannels[PixelFormats.Bgr32] =
        optimumChannels[PixelFormats.Bgra32] =
        optimumChannels[PixelFormats.Cmyk32] =
        optimumChannels[PixelFormats.Pbgra32] =
        optimumChannels[PixelFormats.Prgba64] =
        optimumChannels[PixelFormats.Prgba128Float] =
        optimumChannels[PixelFormats.Rgba64] =
        optimumChannels[PixelFormats.Rgba128Float] = 4;

        optimumTypes = new Dictionary<PixelFormat, MatType>();
        optimumTypes[PixelFormats.Gray2] =
        optimumTypes[PixelFormats.Gray4] =
        optimumTypes[PixelFormats.Gray8] =
        optimumTypes[PixelFormats.Indexed1] =
        optimumTypes[PixelFormats.Indexed2] =
        optimumTypes[PixelFormats.Indexed4] =
        optimumTypes[PixelFormats.Indexed8] =
        optimumTypes[PixelFormats.BlackWhite] = MatType.CV_8UC1;
        optimumTypes[PixelFormats.Gray16] = MatType.CV_16UC1;
        optimumTypes[PixelFormats.Rgb48] = MatType.CV_16UC3;
        optimumTypes[PixelFormats.Rgba64] = MatType.CV_16UC4;
        optimumTypes[PixelFormats.Pbgra32] =
        optimumTypes[PixelFormats.Prgba64] = MatType.CV_32SC4;
        optimumTypes[PixelFormats.Gray32Float] = MatType.CV_32FC1;
        optimumTypes[PixelFormats.Rgb128Float] = MatType.CV_32FC3;
        optimumTypes[PixelFormats.Prgba128Float] =
        optimumTypes[PixelFormats.Rgba128Float] = MatType.CV_32FC4;
        optimumTypes[PixelFormats.Bgr24] =
        optimumTypes[PixelFormats.Rgb24] =
        optimumTypes[PixelFormats.Bgr555] =
        optimumTypes[PixelFormats.Bgr565] = MatType.CV_8UC3;
        optimumTypes[PixelFormats.Bgr32] =
        optimumTypes[PixelFormats.Bgra32] =
        optimumTypes[PixelFormats.Cmyk32] = MatType.CV_8UC4;
    }

    /// <summary>
    /// Returns the number of Mat channels that fit the specified PixelFormat
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    internal static int GetOptimumChannels(PixelFormat f)
    {
        if (optimumChannels.TryGetValue(f, out var ret))
            return ret;
        throw new ArgumentException("Not supported PixelFormat");
    }

    /// <summary>
    /// Returns the MatType that fits the specified PixelFormat
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    internal static MatType GetOptimumType(PixelFormat f)
    {
        if (optimumTypes.TryGetValue(f, out var ret))
            return ret;
        throw new ArgumentException("Not supported PixelFormat");
    }

    /// <summary>
    /// Returns the PixelFormat that fits the specified Mat's bit depth and channel count
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static PixelFormat GetOptimumPixelFormats(MatType type)
    {
        if (type == MatType.CV_8UC1 || type == MatType.CV_8SC1)
            return PixelFormats.Gray8;
        if (type == MatType.CV_8UC3 || type == MatType.CV_8SC3)
            return PixelFormats.Bgr24;
        if (type == MatType.CV_8UC4 || type == MatType.CV_8SC4)
            return PixelFormats.Bgra32;

        if (type == MatType.CV_16UC1 || type == MatType.CV_16SC1)
            return PixelFormats.Gray16;
        if (type == MatType.CV_16UC3 || type == MatType.CV_16SC3)
            return PixelFormats.Rgb48;
        if (type == MatType.CV_16UC4 || type == MatType.CV_16SC4)
            return PixelFormats.Rgba64;

        if (type == MatType.CV_32SC4)
            return PixelFormats.Prgba64;

        if (type == MatType.CV_32FC1)
            return PixelFormats.Gray32Float;
        if (type == MatType.CV_32FC3)
            return PixelFormats.Rgb128Float;
        if (type == MatType.CV_32FC4)
            return PixelFormats.Rgba128Float;

        throw new ArgumentOutOfRangeException(nameof(type), "Not supported MatType");
    }

    /// <summary>
    /// BGR -> RGB
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    private static Mat SwapChannelsIfNeeded(Mat src)
    {
        var type = src.Type();
        if (type == MatType.CV_16UC3 || type == MatType.CV_16SC3) // PixelFormats.Rgb48
        {
            var dst = new Mat();
            Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2RGB);
            return dst;
        }
        if (type == MatType.CV_16UC4 || type == MatType.CV_16SC4) // PixelFormats.Rgba64
        {
            var dst = new Mat();
            Cv2.CvtColor(src, dst, ColorConversionCodes.BGRA2RGBA);
            return dst;
        }
        return src;
    }

    #region ToWriteableBitmap

    /// <summary>
    /// Converts Mat to WriteableBitmap.
    /// The arguments of this method corresponds the consructor of WriteableBitmap.
    /// </summary>
    /// <param name="src">Input Mat</param>
    /// <param name="dpiX">Horizontal dots per inch</param>
    /// <param name="dpiY">Vertical dots per inch</param>
    /// <param name="pf">Pixel format of output WriteableBitmap</param>
    /// <param name="bp">Bitmap palette</param>
    /// <returns>WriteableBitmap</returns>
    public static WriteableBitmap ToWriteableBitmap(this Mat src, double dpiX, double dpiY, PixelFormat pf,
        BitmapPalette? bp)
    {
        ArgumentNullException.ThrowIfNull(src);
        
        var wb = new WriteableBitmap(src.Width, src.Height, dpiX, dpiY, pf, bp);
        ToWriteableBitmap(src, wb);
        return wb;
    }

    /// <summary>
    /// Converts Mat to WriteableBitmap (dpi=96, BitmapPalette=null)
    /// </summary>
    /// <param name="src">Input Mat</param>
    /// <param name="pf">Pixel format of output WriteableBitmap</param>
    /// <returns>WriteableBitmap</returns>
    public static WriteableBitmap ToWriteableBitmap(this Mat src, PixelFormat pf)
    {
        return ToWriteableBitmap(src, 96, 96, pf, null);
    }

    /// <summary>
    /// Converts Mat to WriteableBitmap (dpi=96, BitmapPalette=null)
    /// </summary>
    /// <param name="src">Input Mat</param>
    /// <returns>WriteableBitmap</returns>
    public static WriteableBitmap ToWriteableBitmap(this Mat src)
    {
        ArgumentNullException.ThrowIfNull(src);

        PixelFormat pf = GetOptimumPixelFormats(src.Type());
        Mat swappedMat = SwapChannelsIfNeeded(src);
        try
        {
            return ToWriteableBitmap(swappedMat, 96, 96, pf, null);
        }
        finally
        {
            if (src != swappedMat)
                swappedMat.Dispose();
        }
    }

    /// <summary>
    /// Converts Mat to WriteableBitmap.
    /// This method is more efficient because new instance of WriteableBitmap is not allocated.
    /// </summary>
    /// <param name="src">Input Mat</param>
    /// <param name="dst">Output WriteableBitmap</param>
    public static void ToWriteableBitmap(Mat src, WriteableBitmap dst)
    {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(dst);
        if (src.Width != dst.PixelWidth || src.Height != dst.PixelHeight)
            throw new ArgumentException("size of src must be equal to size of dst");
        //if (src.Depth != BitDepth.U8)
        //throw new ArgumentException("bit depth of src must be BitDepth.U8", "src");
        if (src.Dims > 2)
            throw new ArgumentException("Mat dimensions must be 2");

        int w = src.Width;
        int h = src.Height;
        int bpp = dst.Format.BitsPerPixel;

        int channels = GetOptimumChannels(dst.Format);
        if (src.Channels() != channels)
        {
            throw new ArgumentException("channels of dst != channels of PixelFormat", nameof(dst));
        }

        // 1bpp requires manual bit-packing, so copy it by hand
        if (bpp == 1)
        {
            if (src.IsSubmatrix())
                throw new NotImplementedException("submatrix not supported");

            int srcStep = (int)src.Step();

            // Transfer manually
            int stride = w / 8 + 1;
            if (stride < 2)
                stride = 2;

            byte[] pixels = new byte[h * stride];

            unsafe
            {
                byte* pSrc = (byte*)(src.Data);
                for (int x = 0, y = 0; y < h; y++)
                {
                    int offset = y * stride;
                    for (int bytePos = 0; bytePos < stride; bytePos++)
                    {
                        if (x < w)
                        {
                            byte b = 0;
                            // Check whether each of the next 8 pixels' bits is set, and pack them into one byte
                            for (int i = 0; i < 8; i++)
                            {
                                b <<= 1;
                                if (x < w && pSrc[srcStep * y + x] != 0)
                                {
                                    b |= 1;
                                }
                                x++;
                            }
                            pixels[offset + bytePos] = b;
                        }
                    }
                    x = 0;
                }
            }
            dst.WritePixels(new Int32Rect(0, 0, w, h), pixels, stride, 0);
            return;
        }

        try
        {
            dst.Lock();
            dst.AddDirtyRect(new Int32Rect(0, 0, dst.PixelWidth, dst.PixelHeight));
            src.CopyPixelsTo(dst.BackBuffer, dst.BackBufferStride);
        }
        finally
        {
            dst.Unlock();
        }
    }

    #endregion

    #region ToMat

    // https://github.com/shimat/opencvsharp_2410/blob/master/src/OpenCvSharp.Extensions/WriteableBitmapConverter_IplImage.cs#L167

    /// <summary>
    /// Converts WriteableBitmap to IplImage
    /// </summary>
    /// <param name="src">Input WriteableBitmap</param>
    /// <returns>IplImage</returns>
    public static Mat ToMat(this WriteableBitmap src)
    {
        ArgumentNullException.ThrowIfNull(src);

        var w = src.PixelWidth;
        var h = src.PixelHeight;
        var matType = GetOptimumType(src.Format);
        var dst = new Mat(new Size(w, h), matType);
        ToMat(src, dst);
        return dst;
    }

    /// <summary>
    /// Converts WriteableBitmap to Mat
    /// </summary>
    /// <param name="src">Input WriteableBitmap</param>
    /// <param name="dst">Output Mat</param>
    public static void ToMat(this WriteableBitmap src, Mat dst)
    {
        ArgumentNullException.ThrowIfNull(src);
        ArgumentNullException.ThrowIfNull(dst);
        if (src.PixelWidth != dst.Width || src.PixelHeight != dst.Height)
            throw new ArgumentException("size of src must be equal to size of dst");
        //if (dst.Depth != BitDepth.U8)
        //    throw new ArgumentException("bit depth of dst must be BitDepth.U8", "dst");

        int w = src.PixelWidth;
        int h = src.PixelHeight;
        int bpp = src.Format.BitsPerPixel;
        int channels = GetOptimumChannels(src.Format);
        if (dst.Channels() != channels)
            throw new ArgumentException("nChannels of dst is invalid", nameof(dst));

        // 1bpp is bit-packed, so unpack it by hand
        if (bpp == 1)
        {
            int widthStep = (int)dst.Step();
            // Each element holds data for 8 horizontal pixels
            int stride = (w / 8) + 1;
            byte[] pixels = new byte[h * stride];
            src.CopyPixels(pixels, stride, 0);

            unsafe
            {
                byte* p = (byte*)dst.Data.ToPointer();
                int x = 0;
                for (int y = 0; y < h; y++)
                {
                    int offset = y * stride;
                    // Inspect each byte of this row
                    for (int bytePos = 0; bytePos < stride; bytePos++)
                    {
                        if (x < w)
                        {
                            // Extract each of the 8 bits from the byte at the current position
                            byte b = pixels[offset + bytePos];
                            for (int i = 0; i < 8; i++)
                            {
                                if (x >= w)
                                {
                                    break;
                                }
                                // IplImage is 8bit/pixel
                                p[widthStep * y + x] = ((b & 0x80) == 0x80) ? (byte)255 : (byte)0;
                                b <<= 1;
                                x++;
                            }
                        }
                    }
                    // Move to the next row
                    x = 0;
                }
            }
            return;
        }

        // For 8bpp and above, read directly from the WriteableBitmap's buffer and copy
        try
        {
            src.Lock();
            dst.CopyPixelsFrom(src.BackBuffer, src.BackBufferStride);
        }
        finally
        {
            src.Unlock();
        }
    }

    #endregion
}
#endif
