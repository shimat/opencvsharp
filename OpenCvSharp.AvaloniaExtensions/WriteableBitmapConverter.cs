#if NETCOREAPP3_1_OR_GREATER

using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Numerics;

namespace OpenCvSharp.AvaloniaExtensions;

public static class WriteableBitmapConverter
{
#pragma warning disable format
    static readonly Dictionary<PixelFormat, int> _optimumChannels = new()
    {
        { PixelFormat.Rgba8888, 4 },
        { PixelFormat.Bgra8888, 4 },
        { PixelFormat.Rgb565,   3 }
    };
    static readonly Dictionary<PixelFormat, MatType> _optimumTypes = new()
    {
        { PixelFormat.Rgba8888, MatType.CV_8UC4 },
        { PixelFormat.Bgra8888, MatType.CV_8UC4 },
        { PixelFormat.Rgb565,   MatType.CV_8UC3 }
    };
#pragma warning restore format

    #region exports

    public static WriteableBitmap ToWriteableBitmap(
        this Mat src,
        double dpiX,
        double dpiY,
        PixelFormat pixelFormat,
        AlphaFormat alphaFormat)
    {
        if (src is null) throw new ArgumentNullException(nameof(src));

        WriteableBitmap wbmp = new(new(src.Width, src.Height),
                                   new(dpiX, dpiY),
                                   pixelFormat,
                                   alphaFormat);

        ToWriteableBitmap(src, wbmp);

        return wbmp;
    }

    public static WriteableBitmap ToWriteableBitmap(
        this Mat src,
        PixelFormat pixelFormat,
        AlphaFormat alphaformat)
    {
        if (src is null) throw new ArgumentNullException(nameof(src));

        return src.ToWriteableBitmap(96.0, 96.0, pixelFormat, alphaformat);
    }

    public static WriteableBitmap ToWriteableBitmap(
        this Mat src,
        AlphaFormat alphaFormat)
    {
        if (src is null) throw new ArgumentNullException(nameof(src));

        PixelFormat pf = GetOptimumPixelFormat(src.Type());

        return src.ToWriteableBitmap(pf, alphaFormat);
    }

    public unsafe static void ToWriteableBitmap(
        Mat src,
        WriteableBitmap dst)
    {
        if (src is null) throw new ArgumentNullException(nameof(src));
        if (dst is null) throw new ArgumentNullException(nameof(dst));

        if (src.Width != dst.PixelSize.Width || src.Height != dst.PixelSize.Height)
            throw new ArgumentException("size of src mus be equal to size of dst");

        if (src.Dims > 2)
            throw new ArgumentException("Mat dimensions must be 2", nameof(src));

        if (!src.IsContinuous())
            throw new ArgumentException("Non-continuous mats are not supported", nameof(src));

        using ILockedFramebuffer dBuf = dst.Lock();

        int channels = src.Channels();

        if (channels != GetOptimumChannels(dBuf.Format))
            throw new ArgumentException("src.channels != dst.channels", nameof(dst));

        nint w = src.Width,
             h = src.Height,
             dstBpp = dBuf.Format switch
             {
                 PixelFormat.Bgra8888 or PixelFormat.Rgba8888 => sizeof(int),
                 PixelFormat.Rgb565 => sizeof(short),
                 _ => throw new ArgumentException("Unsupported pixelformat", nameof(dst))
             },
             srcBpp = (nint)(src.Step() / src.Cols);

        long srcStep = src.Step(),
             dstStep = dBuf.RowBytes,
             imageSize = src.DataEnd.ToInt64() - src.Data.ToInt64();

        if (imageSize < 0L)
            throw new OpenCvSharpException("The mat has invalid data pointer");
        if (imageSize > int.MaxValue || srcStep > int.MaxValue || dstStep > int.MaxValue)
            throw new OpenCvSharpException("Mat is too big");

        byte* pSrc = (byte*)src.Data,
              pDst = (byte*)dBuf.Address;

        MatType srcType = src.Type();

        if (srcType == MatType.CV_8UC4 && dBuf.Format is PixelFormat.Bgra8888 or PixelFormat.Rgba8888)
        {
            long bytesPerStride = w * channels;

            for (nint y = 0; y < h; y++)
            {
                Buffer.MemoryCopy(pSrc + y * srcStep,
                                  pDst + y * dstStep,
                                  bytesPerStride, bytesPerStride);
            }

            return;
        }

        nint srcIndex = 0,
             dstIndex = 0;

        // assuming only 8-bit depth images from here
        for (nint y = 0; y < h; y++)
        {
            for (nint x = 0; x < w; x++)
            {
                srcIndex = y * (nint)srcStep + x;
                srcIndex -= srcIndex % srcBpp;
                dstIndex = (x * (nint)dstStep + y) / dstBpp;

                int bgra32bit = GetBgra(pSrc, srcType, srcIndex);
                nint dstOffset = x + y * (nint)dstStep;

                switch (dBuf.Format)
                {
                    case PixelFormat.Bgra8888:
                        {
                            ((uint*)pDst)[dstIndex] = (uint)bgra32bit;
                        }
                        break;
                    case PixelFormat.Rgba8888:
                        {
                            uint rgba32bit = BitOperations.RotateLeft((uint)bgra32bit, 31);

                            ((uint*)pDst)[dstIndex] = rgba32bit;
                        }
                        break;
                    case PixelFormat.Rgb565:
                        {
                            // scale 24-bit bgr to 16-bit rgb
                            byte r = (byte)(((bgra32bit & 0x0000ff00) >> 8) * (2 << 5) / byte.MaxValue),
                                 g = (byte)(((bgra32bit & 0x00ff0000) >> 16) * (2 << 6) / byte.MaxValue),
                                 b = (byte)(((bgra32bit & 0xff000000) >> 24) * (2 << 5) / byte.MaxValue);

                            ushort rgb16bit = (ushort)(((r & 0x1f) << 11) |
                                                        ((g & 0x2f) << 5) |
                                                         (b & 0x1f));

                            ((ushort*)pDst)[dstIndex] = rgb16bit;
                        }
                        break;

                } // switch format
            } // for x
        } // for y
    }

    #endregion

    #region util

    internal static int GetOptimumChannels(PixelFormat f)
    {
        return _optimumChannels.ContainsKey(f)
               ? _optimumChannels[f]
               : throw new ArgumentException("Unsupported pixelformat");
    }

    static PixelFormat GetOptimumPixelFormat(MatType type)
    {
        if (type == MatType.CV_8UC1 || type == MatType.CV_8SC1 ||
            type == MatType.CV_8UC3 || type == MatType.CV_8SC3)
            return PixelFormat.Rgb565;

        if (type == MatType.CV_8UC4 || type == MatType.CV_8SC4)
            return PixelFormat.Bgra8888;

        throw new ArgumentOutOfRangeException(nameof(type), "Unsupported MatType");
    }

    /// <summary>
    /// Expand grayscale images to BGRA, otherwise fit to BGRA
    /// </summary>
    static unsafe int GetBgra(byte* ptr, MatType type, nint index)
    {
        int bgra = 0x00_00_00_ff;

        if (type == MatType.CV_8UC1)
        {
            byte val = ptr[index];
            bgra |= (val << 8) | (val << 16) | (val << 24);
        }
        else if (type == MatType.CV_8SC1)
        {
            sbyte* p = (sbyte*)ptr;
            byte val = (byte)(p[index] + byte.MaxValue / 2);
            bgra |= (val << 8) | (val << 16) | (val << 24);
        }
        else if (type == MatType.CV_8UC3)
        {
            bgra |= (ptr[index] << 24) | (ptr[index + 1] << 16) | (ptr[index + 2] << 8);
        }
        else if (type == MatType.CV_8SC3)
        {
            sbyte* p = (sbyte*)ptr;
            bgra |= (((byte)(p[index] + byte.MaxValue / 2)) << 24) |
                    (((byte)(p[index + 1] + byte.MaxValue / 2)) << 16) |
                    (((byte)(p[index + 2] + byte.MaxValue / 2)) << 8);
        }
        else if (type == MatType.CV_8UC4)
        {
            bgra = (ptr[index] << 24) | (ptr[index + 1] << 16) | (ptr[index + 2] << 8) | ptr[index + 3];
        }
        else if (type == MatType.CV_8SC4)
        {
            sbyte* p = (sbyte*)ptr;
            bgra |= (((byte)(p[index] + byte.MaxValue / 2)) << 24) |
                    (((byte)(p[index + 1] + byte.MaxValue / 2)) << 16) |
                    (((byte)(p[index + 2] + byte.MaxValue / 2)) << 8) |
                    ((byte)(p[index + 3] + byte.MaxValue / 2));
        }
        else throw new ArgumentException("Unsupported MatType", nameof(type));

        return bgra;
    }

    #endregion
}

#endif
