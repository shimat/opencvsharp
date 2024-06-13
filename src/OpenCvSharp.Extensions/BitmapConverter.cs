using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Extensions;

/// <summary>
/// static class which provides conversion between System.Drawing.Bitmap and Mat
/// </summary>
public static class BitmapConverter
{
    #region ToMat

    /// <summary>
    /// Converts System.Drawing.Bitmap to Mat
    /// </summary>
    /// <param name="src">System.Drawing.Bitmap object to be converted</param>
    /// <returns>A Mat object which is converted from System.Drawing.Bitmap</returns>
#if NET5_0_OR_GREATER
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public static Mat ToMat(this Bitmap src)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            throw new NotSupportedException("Non-Windows OS are not supported");
        if (src is null)
            throw new ArgumentNullException(nameof(src));

        var w = src.Width;
        var h = src.Height;
        var channels = src.PixelFormat switch
        {
            PixelFormat.Format24bppRgb or PixelFormat.Format32bppRgb => 3,
            PixelFormat.Format32bppArgb or PixelFormat.Format32bppPArgb => 4,
            PixelFormat.Format8bppIndexed or PixelFormat.Format1bppIndexed => 1,
            _ => throw new NotImplementedException(),
        };
        var dst = new Mat(h, w, MatType.CV_8UC(channels));
        ToMat(src, dst);
        return dst;
    }

    /// <summary>
    /// Converts System.Drawing.Bitmap to Mat
    /// </summary>
    /// <param name="src">System.Drawing.Bitmap object to be converted</param>
    /// <param name="dst">A Mat object which is converted from System.Drawing.Bitmap</param>
#if NET5_0_OR_GREATER
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public static unsafe void ToMat(this Bitmap src, Mat dst)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            throw new NotSupportedException("Non-Windows OS are not supported");
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (dst.IsDisposed)
            throw new ArgumentException("The specified dst is disposed.", nameof(dst));
        if (dst.Depth() != MatType.CV_8U)
            throw new NotSupportedException("Mat depth != CV_8U");
        if (dst.Dims != 2)
            throw new NotSupportedException("Mat dims != 2");
        if (src.Width != dst.Width || src.Height != dst.Height)
            throw new ArgumentException("src.Size != dst.Size");

        var w = src.Width;
        var h = src.Height;
        var rect = new Rectangle(0, 0, w, h);
        BitmapData? bd = null;
        try
        {
            bd = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
                
            switch (src.PixelFormat)
            {
                case PixelFormat.Format1bppIndexed:
                    Format1bppIndexed();
                    break;

                case PixelFormat.Format8bppIndexed:
                    Format8bppIndexed();
                    break;

                case PixelFormat.Format24bppRgb:
                    Format24bppRgb();
                    break;

                case PixelFormat.Format32bppRgb:
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                    Format32bppRgb();
                    break;
            }
        }
        finally
        {
            if (bd is not null)
                src.UnlockBits(bd);
        }
            
        // ReSharper disable once InconsistentNaming
        void Format1bppIndexed()
        {
            if (dst.Channels() != 1)
                throw new ArgumentException("Invalid nChannels");
            if (dst.IsSubmatrix())
                throw new NotImplementedException("submatrix not supported");
            if (bd is null)
                throw new NotSupportedException("BitmapData is null (Format1bppIndexed)");
                
            var srcPtr = (byte*)bd.Scan0.ToPointer();
            var dstPtr = dst.DataPointer;
            var srcStep = bd.Stride;
            var dstStep = (uint)dst.Step();
            var x = 0;

            for (var y = 0; y < h; y++)
            {
                // 横は必ず4byte幅に切り上げられる。
                // この行の各バイトを調べていく
                for (var bytePos = 0; bytePos < srcStep; bytePos++)
                {
                    if (x < w)
                    {
                        // 現在の位置のバイトからそれぞれのビット8つを取り出す
                        var b = srcPtr[bytePos];
                        for (var i = 0; i < 8; i++)
                        {
                            if (x >= w)
                            {
                                break;
                            }
                            // IplImageは8bit/pixel
                            dstPtr[dstStep * y + x] = ((b & 0x80) == 0x80) ? (byte)255 : (byte)0;
                            b <<= 1;
                            x++;
                        }
                    }
                }
                // 次の行へ
                x = 0;
                srcPtr += srcStep;
            }
        }
            
        // ReSharper disable once InconsistentNaming
        void Format8bppIndexed()
        {
            static void Ch1(Mat dst, int height, int srcStep, uint dstStep, IntPtr srcData, byte[] palette)
            {
                if (dstStep == srcStep && !dst.IsSubmatrix() && dst.IsContinuous())
                {
                    // Read Bitmap pixel data to managed array
                    var length = dst.DataEnd.ToInt64() - dst.Data.ToInt64();
                    if (length > int.MaxValue)
                        throw new NotSupportedException("Too big dst Mat");
                    var buffer = new byte[length];
                    Marshal.Copy(srcData, buffer, 0, buffer.Length);
                    // Apply conversion by palette 
                    buffer = buffer.Select(b => palette[b]).ToArray();
                    // Write to dst Mat
                    Marshal.Copy(buffer, 0, dst.Data, buffer.Length);
                }
                else
                {
                    // Copy line bytes from src to dst for each line
                    var sp = (byte*) srcData;
                    var dp = (byte*) dst.Data;
                    var buffer = new byte[srcStep];
                    for (var y = 0; y < height; y++)
                    {
                        // Read Bitmap pixel data to managed array
                        Marshal.Copy(new IntPtr(sp), buffer, 0, buffer.Length);
                        // Apply conversion by palette 
                        buffer = buffer.Select(b => palette[b]).ToArray();
                        // Write to dst Mat
                        Marshal.Copy(buffer, 0, new IntPtr(dp), buffer.Length);

                        sp += srcStep;
                        dp += dstStep;
                    }
                }
            }

            var srcStep = bd.Stride;
            var dstStep = (uint)dst.Step();

            var channels = dst.Channels();
            if (channels == 1)
            {
                var palette = new byte[256];
                var paletteLength = Math.Min(256, src.Palette.Entries.Length);
                for (var i = 0; i < paletteLength; i++)
                {
                    // TODO src.Palette.Flags & 2 == 2
                    // https://docs.microsoft.com/ja-jp/dotnet/api/system.drawing.imaging.colorpalette.flags?view=netframework-4.8
                    palette[i] = src.Palette.Entries[i].R;
                }
                Ch1(dst, h, srcStep, dstStep, bd.Scan0, palette);
            }
            else if (channels == 3)
            {
                // Palette
                var paletteR = new byte[256];
                var paletteG = new byte[256];
                var paletteB = new byte[256];
                var paletteLength = Math.Min(256, src.Palette.Entries.Length);
                for (var i = 0; i < paletteLength; i++)
                {
                    var c = src.Palette.Entries[i];
                    paletteR[i] = c.R;
                    paletteG[i] = c.G;
                    paletteB[i] = c.B;
                }

                using var dstR = new Mat(h, w, MatType.CV_8UC1);
                using var dstG = new Mat(h, w, MatType.CV_8UC1);
                using var dstB = new Mat(h, w, MatType.CV_8UC1);

                Ch1(dstR, h, srcStep, (uint)dstR.Step(), bd.Scan0, paletteR);
                Ch1(dstG, h, srcStep, (uint)dstG.Step(), bd.Scan0, paletteG);
                Ch1(dstB, h, srcStep, (uint)dstB.Step(), bd.Scan0, paletteB);
                Cv2.Merge([dstB, dstG, dstR], dst);
            }
            else
            {
                throw new ArgumentException($"Invalid channels of dst Mat ({channels})");
            }
        }
            
        // ReSharper disable once InconsistentNaming
        void Format24bppRgb()
        {
            if (dst.Channels() != 3)
                throw new ArgumentException("Invalid nChannels");
            if (dst.Depth() != MatType.CV_8U && dst.Depth() != MatType.CV_8S)
                throw new ArgumentException("Invalid depth of dst Mat");
                
            var srcStep = bd.Stride;
            var dstStep = dst.Step();
            if (dstStep == srcStep && !dst.IsSubmatrix() && dst.IsContinuous())
            {
                var dstData = dst.Data;
                var bytesToCopy = dst.DataEnd.ToInt64() - dstData.ToInt64();
                Buffer.MemoryCopy(bd.Scan0.ToPointer(), dstData.ToPointer(), bytesToCopy, bytesToCopy);
            }
            else
            {
                // Copy line bytes from src to dst for each line
                var sp = (byte*) bd.Scan0;
                var dp = (byte*) dst.Data;
                for (var y = 0; y < h; y++)
                {
                    Buffer.MemoryCopy(sp, dp, dstStep, dstStep);
                    sp += srcStep;
                    dp += dstStep;
                }
            }
        }

        // ReSharper disable once InconsistentNaming
        void Format32bppRgb()
        {
            var srcStep = bd.Stride;
            var dstStep = dst.Step();

            switch (dst.Channels())
            {
                case 4:
                    if (!dst.IsSubmatrix() && dst.IsContinuous())
                    {
                        var dstData = dst.Data;
                        var bytesToCopy = dst.DataEnd.ToInt64() - dstData.ToInt64();
                        Buffer.MemoryCopy(bd.Scan0.ToPointer(), dstData.ToPointer(), bytesToCopy, bytesToCopy);
                    }
                    else
                    {
                        var sp = (byte*) bd.Scan0;
                        var dp = (byte*) dst.Data;
                        for (var y = 0; y < h; y++)
                        {
                            Buffer.MemoryCopy(sp, dp, dstStep, dstStep);
                            sp += srcStep;
                            dp += dstStep;
                        }
                    }

                    break;
                case 3:
                    var srcPtr = (byte*)bd.Scan0.ToPointer();
                    var dstPtr = (byte*)dst.Data.ToPointer();
                    for (var y = 0; y < h; y++)
                    {
                        for (var x = 0; x < w; x++)
                        {
                            dstPtr[y * dstStep + x * 3 + 0] = srcPtr[y * srcStep + x * 4 + 0];
                            dstPtr[y * dstStep + x * 3 + 1] = srcPtr[y * srcStep + x * 4 + 1];
                            dstPtr[y * dstStep + x * 3 + 2] = srcPtr[y * srcStep + x * 4 + 2];
                        }
                    }

                    break;
                default:
                    throw new ArgumentException("Invalid nChannels");
            }
        }
    }
    #endregion

    #region ToBitmap

    /// <summary>
    /// Converts Mat to System.Drawing.Bitmap
    /// </summary>
    /// <param name="src">Mat</param>
    /// <returns></returns>
#if NET5_0_OR_GREATER
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public static Bitmap ToBitmap(this Mat src)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            throw new NotSupportedException("Non-Windows OS are not supported");
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        var pf = src.Channels() switch
        {
            1 => PixelFormat.Format8bppIndexed,
            3 => PixelFormat.Format24bppRgb,
            4 => PixelFormat.Format32bppArgb,
            _ => throw new ArgumentException("Number of channels must be 1, 3 or 4.", nameof(src)),
        };
        return ToBitmap(src, pf);
    }

    /// <summary>
    /// Converts Mat to System.Drawing.Bitmap
    /// </summary>
    /// <param name="src">Mat</param>
    /// <param name="pf">Pixel Depth</param>
    /// <returns></returns>
#if NET5_0_OR_GREATER
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public static Bitmap ToBitmap(this Mat src, PixelFormat pf)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            throw new NotSupportedException("Non-Windows OS are not supported");
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        src.ThrowIfDisposed();

        var bitmap = new Bitmap(src.Width, src.Height, pf);
        ToBitmap(src, bitmap);
        return bitmap;
    }

    /// <summary>
    /// Converts Mat to System.Drawing.Bitmap
    /// </summary>
    /// <param name="src">Mat</param>
    /// <param name="dst">Mat</param>
    /// <remarks>Author: shimat, Gummo (ROI support)</remarks>
#if NET5_0_OR_GREATER
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public static unsafe void ToBitmap(this Mat src, Bitmap dst)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            throw new NotSupportedException("Non-Windows OS are not supported");
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        if (dst is null)
            throw new ArgumentNullException(nameof(dst));
        if (src.IsDisposed)
            throw new ArgumentException("The image is disposed.", nameof(src));
        if (src.Depth() != MatType.CV_8U)
            throw new ArgumentException("Depth of the image must be CV_8U");
        //if (src.IsSubmatrix())
        //    throw new ArgumentException("Submatrix is not supported");
        if (src.Width != dst.Width || src.Height != dst.Height)
            throw new ArgumentException("");

        var pf = dst.PixelFormat;

        // 1プレーン用の場合、グレースケールのパレット情報を生成する
        if (pf == PixelFormat.Format8bppIndexed)
        {
            var plt = dst.Palette;
            for (var x = 0; x < 256; x++)
            {
                plt.Entries[x] = Color.FromArgb(x, x, x);
            }
            dst.Palette = plt;
        }

        var w = src.Width;
        var h = src.Height;
        var rect = new Rectangle(0, 0, w, h);
        BitmapData? bd = null;

        var submat = src.IsSubmatrix();
        var continuous = src.IsContinuous();

        try
        {
            bd = dst.LockBits(rect, ImageLockMode.WriteOnly, pf);

            var srcData = src.Data;
            var pSrc = (byte*)(srcData.ToPointer());
            var pDst = (byte*)(bd.Scan0.ToPointer());
            var ch = src.Channels();
            var srcStep = (int)src.Step();
            var dstStep = ((src.Width * ch) + 3) / 4 * 4; // 4の倍数に揃える
            var stride = bd.Stride;

            switch (pf)
            {
                case PixelFormat.Format1bppIndexed:
                {
                    if (submat)
                        throw new NotImplementedException("submatrix not supported");

                    // BitmapDataは4byte幅だが、IplImageは1byte幅
                    // 手作業で移し替える                 
                    //int offset = stride - (w / 8);
                    int x = 0;
                    byte b = 0;
                    for (var y = 0; y < h; y++)
                    {
                        for (var bytePos = 0; bytePos < stride; bytePos++)
                        {
                            if (x < w)
                            {
                                for (int i = 0; i < 8; i++)
                                {
                                    var mask = (byte)(0x80 >> i);
                                    if (x < w && pSrc[srcStep * y + x] == 0)
                                        b &= (byte)(mask ^ 0xff);
                                    else
                                        b |= mask;

                                    x++;
                                }
                                pDst[bytePos] = b;
                            }
                        }
                        x = 0;
                        pDst += stride;
                    }
                    break;
                }

                case PixelFormat.Format8bppIndexed:
                case PixelFormat.Format24bppRgb:
                case PixelFormat.Format32bppArgb:
                    if (srcStep == dstStep && !submat && continuous)
                    {
                        long bytesToCopy = src.DataEnd.ToInt64() - src.Data.ToInt64();
                        Buffer.MemoryCopy(pSrc, pDst, bytesToCopy, bytesToCopy);
                    }
                    else
                    {
                        for (int y = 0; y < h; y++)
                        {
                            long offsetSrc = (y * srcStep);
                            long offsetDst = (y * dstStep);
                            long bytesToCopy = w * ch;
                            // 一列ごとにコピー
                            Buffer.MemoryCopy(pSrc + offsetSrc, pDst + offsetDst, bytesToCopy, bytesToCopy);
                        }
                    }
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
        finally
        {
            if (bd is not null)
                dst.UnlockBits(bd);
        }
    }
    #endregion
}
