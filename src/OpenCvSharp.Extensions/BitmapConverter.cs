/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.Extensions
{
#if LANG_JP
    /// <summary>
    /// System.Drawing.BitmapとIplImageの相互変換メソッドを提供するクラス
    /// </summary>
#else
    /// <summary>
    /// static class which provides conversion between System.Drawing.Bitmap and IplImage
    /// </summary>
#endif
    public static class BitmapConverter
    {
        #region ToIplImage
#if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapからOpenCVのIplImageへ変換して返す.
        /// </summary>
        /// <param name="src">変換するSystem.Drawing.Bitmap</param>
        /// <returns>変換結果のIplImage</returns>
#else
        /// <summary>
        /// Converts System.Drawing.Bitmap to IplImage
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap object to be converted</param>
        /// <returns>An IplImage object which is converted from System.Drawing.Bitmap</returns>
#endif
        public static IplImage ToIplImage(this Bitmap src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            int w = src.Width;
            int h = src.Height;
            int channels;
            switch (src.PixelFormat)
            {
                case PixelFormat.Format24bppRgb:
                case PixelFormat.Format32bppRgb:
                    channels = 3; break;
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                    channels = 3; break;
                case PixelFormat.Format8bppIndexed:
                case PixelFormat.Format1bppIndexed:
                    channels = 1; break;
                default:
                    throw new NotImplementedException();
            }
            IplImage dst = Cv.CreateImage(new CvSize(w, h), BitDepth.U8, channels);
            ToIplImage(src, dst);
            return dst;
        }

#if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapからOpenCVのIplImageへ変換して返す.
        /// </summary>
        /// <param name="src">変換するSystem.Drawing.Bitmap</param>
        /// <param name="dst">変換結果を格納するIplImage</param>
#else
        /// <summary>
        /// Converts System.Drawing.Bitmap to IplImage
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap object to be converted</param>
        /// <param name="dst">An IplImage object which is converted from System.Drawing.Bitmap</param>
#endif
        public static unsafe void ToIplImage(this Bitmap src, IplImage dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (dst.IsDisposed)
                throw new ArgumentException("The specified dst is disposed.", "dst");
            if (dst.Depth != BitDepth.U8)
                throw new NotSupportedException();
            if (src.Width != dst.Width || src.Height != dst.Height)
                throw new ArgumentException("Size of src must be equal to size of dst.");

            int w = src.Width;
            int h = src.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);
            BitmapData bd = null;
            try
            {
                bd = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);


                byte* p = (byte*)bd.Scan0.ToPointer();
                int stride = bd.Stride;
                int offset = stride - (w / 8);
                int widthStep = dst.WidthStep;
                byte* imageData = (byte*)dst.ImageData.ToPointer();

                switch (src.PixelFormat)
                {
                    case PixelFormat.Format1bppIndexed:
                    {
                        if (dst.NChannels != 1)
                        {
                            throw new ArgumentException("Invalid nChannels");
                        }
                        int x = 0;
                        int y;
                        int bytePos;
                        byte b;
                        int i;
                        for (y = 0; y < h; y++)
                        {
                            // 横は必ず4byte幅に切り上げられる。
                            // この行の各バイトを調べていく
                            for (bytePos = 0; bytePos < stride; bytePos++)
                            {
                                if (x < w)
                                {
                                    // 現在の位置のバイトからそれぞれのビット8つを取り出す
                                    b = p[bytePos];
                                    for (i = 0; i < 8; i++)
                                    {
                                        if (x >= w)
                                        {
                                            break;
                                        }
                                        // IplImageは8bit/pixel
                                        imageData[widthStep * y + x] = ((b & 0x80) == 0x80) ? (byte)255 : (byte)0;
                                        b <<= 1;
                                        x++;
                                    }
                                }
                            }
                            // 次の行へ
                            x = 0;
                            p += stride;
                        }
                    }
                        break;
                    case PixelFormat.Format8bppIndexed:
                    {
                        if (dst.NChannels != 1)
                        {
                            throw new ArgumentException("Invalid nChannels");
                        }
                        /*for (int y = 0; y < h; y++)
                            {
                                for (int x = 0; x < w; x++)
                                {
                                    imageData[y * widthStep + x] = p[y * stride + x];
                                }
                            }*/
                        Util.CopyMemory(dst.ImageData, bd.Scan0, dst.ImageSize);
                    }
                        break;
                    case PixelFormat.Format24bppRgb:
                    {
                        if (dst.NChannels != 3)
                        {
                            throw new ArgumentException("Invalid nChannels");
                        }
                        /*for (int y = 0; y < h; y++)
                            {
                                for (int x = 0; x < w; x++)
                                {
                                    imageData[y * widthStep + x * 3] = p[y * stride + x * 3];
                                    imageData[y * widthStep + x * 3 + 1] = p[y * stride + x * 3 + 1];
                                    imageData[y * widthStep + x * 3 + 2] = p[y * stride + x * 3 + 2];
                                }
                            }*/
                        Util.CopyMemory(dst.ImageData, bd.Scan0, dst.ImageSize);
                    }
                        break;
                    case PixelFormat.Format32bppRgb:
                    case PixelFormat.Format32bppArgb:
                    case PixelFormat.Format32bppPArgb:
                    {
                        switch (dst.NChannels)
                        {
                            case 4:
                                Util.CopyMemory(dst.ImageData, bd.Scan0, dst.ImageSize);
                                break;
                            case 3:
                                for (int y = 0; y < h; y++)
                                {
                                    for (int x = 0; x < w; x++)
                                    {
                                        imageData[y * widthStep + x * 3] = p[y * stride + x * 4 + 0];
                                        imageData[y * widthStep + x * 3 + 1] = p[y * stride + x * 4 + 1];
                                        imageData[y * widthStep + x * 3 + 2] = p[y * stride + x * 4 + 2];
                                    }
                                }
                                break;
                            default:
                                throw new ArgumentException("Invalid nChannels");
                        }
                    }
                        break;
                }
            }
            finally
            {
                if(bd != null)
                    src.UnlockBits(bd);
            }
        }

#if LANG_JP
        /// <summary>
        /// System.Drawing.Bitmap から IplImage へピクセルデータをコピーする
        /// </summary>
        /// <param name="ipl"></param>
        /// <param name="bitmap"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Copies pixel data from System.Drawing.Bitmap to IplImage instance
        /// </summary>
        /// <param name="ipl"></param>
        /// <param name="bitmap"></param>
        /// <returns></returns>
#endif
        public static void CopyFrom(this IplImage ipl, Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("bitmap");
            }
            ToIplImage(bitmap, ipl);
        }

        #endregion

        #region ToBitmap
#if LANG_JP
        /// <summary>
        /// OpenCVのIplImageをSystem.Drawing.Bitmapに変換する
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <returns>System.Drawing.Bitmap</returns>
#else
        /// <summary>
        /// Converts IplImage to System.Drawing.Bitmap
        /// </summary>
        /// <param name="src">Mat</param>
        /// <returns></returns>
#endif
        public static Bitmap ToBitmap(this IplImage src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            PixelFormat pf;
            switch (src.NChannels)
            {
                case 1:
                    pf = PixelFormat.Format8bppIndexed; break;
                case 3:
                    pf = PixelFormat.Format24bppRgb; break;
                case 4:
                    pf = PixelFormat.Format32bppArgb; break;
                default:
                    throw new ArgumentException("Number of channels must be 1, 3 or 4.", "src");
            }
            return ToBitmap(src, pf);
        }
#if LANG_JP
        /// <summary>
        /// OpenCVのIplImageをSystem.Drawing.Bitmapに変換する
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="pf">ピクセル深度</param>
        /// <returns>System.Drawing.Bitmap</returns>
#else
        /// <summary>
        /// Converts IplImage to System.Drawing.Bitmap
        /// </summary>
        /// <param name="src">Mat</param>
        /// <param name="pf">Pixel Depth</param>
        /// <returns></returns>
#endif
        public static Bitmap ToBitmap(this IplImage src, PixelFormat pf)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (src.Depth != BitDepth.U8)
            {
                //throw new ArgumentOutOfRangeException("Depth of the image must be BitDepth.U8");
            }
            Bitmap bitmap = new Bitmap(src.ROI.Width, src.ROI.Height, pf);
            ToBitmap(src, bitmap);
            return bitmap;
        }

#if LANG_JP
        /// <summary>
        /// OpenCVのIplImageを指定した出力先にSystem.Drawing.Bitmapとして変換する
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="dst">出力先のSystem.Drawing.Bitmap</param>
        /// <remarks>Author: shimat, Gummo (ROI support)</remarks>
#else
        /// <summary>
        /// Converts IplImage to System.Drawing.Bitmap
        /// </summary>
        /// <param name="src">Mat</param>
        /// <param name="dst">IplImage</param>
        /// <remarks>Author: shimat, Gummo (ROI support)</remarks>
#endif
        public static unsafe void ToBitmap(this IplImage src, Bitmap dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.IsDisposed)
                throw new ArgumentException("The image is disposed.", "src");
            //if (src.Depth != BitDepth.U8)
            //    throw new ArgumentOutOfRangeException("src");
            if (src.ROI.Width != dst.Width || src.ROI.Height != dst.Height)
                throw new ArgumentException("");

            PixelFormat pf = dst.PixelFormat;

            // 1プレーン用の場合、グレースケールのパレット情報を生成する
            if (pf == PixelFormat.Format8bppIndexed)
            {
                ColorPalette plt = dst.Palette;
                for (int x = 0; x < 256; x++)
                {
                    plt.Entries[x] = Color.FromArgb(x, x, x);
                }
                dst.Palette = plt;
            }

            // BitDepth.U8以外の場合はスケーリングする
            IplImage _src;
            if (src.Depth != BitDepth.U8)
            {
                _src = new IplImage(src.Size, BitDepth.U8, src.NChannels);
                using (IplImage f = src.Clone())
                {
                    if (src.Depth == BitDepth.F32 || src.Depth == BitDepth.F64)
                    {
                        Cv.Normalize(src, f, 255, 0, NormType.MinMax);
                    }
                    Cv.ConvertScaleAbs(f, _src);
                }
            }
            else
            {
                _src = src;
            }
            Bitmap _dst = dst;

            int w = _src.ROI.Width;
            int h = _src.ROI.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);
            BitmapData bd = null;

            try
            {
                bd = _dst.LockBits(rect, ImageLockMode.WriteOnly, pf);

                byte* psrc = (byte*)(_src.ImageData.ToPointer());
                byte* pdst = (byte*)(bd.Scan0.ToPointer());
                int xo = _src.ROI.X;
                int yo = _src.ROI.Y;
                int widthStepSrc = _src.WidthStep;
                int widthStepDst = ((_src.ROI.Width * _src.NChannels) + 3) / 4 * 4; // 4の倍数に揃える
                int stride = bd.Stride;
                int ch = _src.NChannels;

                switch (pf)
                {
                    case PixelFormat.Format1bppIndexed:
                    {
                        // BitmapDataは4byte幅だが、IplImageは1byte幅
                        // 手作業で移し替える				 
                        //int offset = stride - (w / 8);
                        int x = xo;
                        int y;
                        int bytePos;
                        byte mask;
                        byte b = 0;
                        int i;
                        for (y = yo; y < h; y++)
                        {
                            for (bytePos = 0; bytePos < stride; bytePos++)
                            {
                                if (x < w)
                                {
                                    for (i = 0; i < 8; i++)
                                    {
                                        mask = (byte)(0x80 >> i);
                                        if (x < w && psrc[widthStepSrc * y + x] == 0)
                                            b &= (byte)(mask ^ 0xff);
                                        else
                                            b |= mask;

                                        x++;
                                    }
                                    pdst[bytePos] = b;
                                }
                            }
                            x = xo;
                            pdst += stride;
                        }
                        break;
                    }

                    case PixelFormat.Format8bppIndexed:
                    case PixelFormat.Format24bppRgb:
                    case PixelFormat.Format32bppArgb:
                        if (widthStepSrc == widthStepDst && _src.ROI.Size == _src.Size)
                        {
                            Util.CopyMemory(pdst, psrc, _src.ImageSize);
                        }
                        else
                        {
                            for (int y = 0; y < h; y++)
                            {
                                int offsetSrc = ((y + yo) * widthStepSrc) + xo;
                                int offsetDst = (y * widthStepDst);

                                /*
                                for (int x = 0; x < _src.ROI.Width; x++)
                                {
                                    pdst[x + offset_dst] = psrc[x + offset_src];
                                }
                                //*/
                                // 一列ごとにコピー
                                Util.CopyMemory(pdst + offsetDst, psrc + offsetSrc, w * ch);
                            }
                        }
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            finally
            {
                _dst.UnlockBits(bd);
            }

            // 反転対策
            if (src.Origin == ImageOrigin.BottomLeft)
            {
                _dst.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }

            // スケーリングのために余分に作ったインスタンスの破棄
            if (_src != src)
            {
                _src.Dispose();
            }
        }
        #endregion

        #region DrawToHDC
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="hdc"></param>
        /// <param name="dstRect"></param>
        public static void DrawToHdc(this IplImage img, IntPtr hdc, CvRect dstRect)
        {
            if (Platform.OS == OS.Unix)
            {
                throw new PlatformNotSupportedException("This method is only for Windows.");
            }

            if (img == null)
                throw new ArgumentNullException("img");
            if (hdc == IntPtr.Zero)
                throw new ArgumentNullException("hdc");
            if (img.Depth != BitDepth.U8)
                throw new NotSupportedException();

            int bmpW = img.Width;
            int bmpH = img.Height;
            CvRect roi = Cv.GetImageROI(img);

            unsafe
            {
                int headerSize = sizeof(Win32API.BITMAPINFOHEADER) + 1024;
                IntPtr buffer = Marshal.AllocHGlobal(headerSize);
                Win32API.BITMAPINFO bmi = (Win32API.BITMAPINFO)Marshal.PtrToStructure(buffer, typeof(Win32API.BITMAPINFO));

                if (roi.Width == dstRect.Width && roi.Height == dstRect.Height)
                {
                    DrawToHdc(img, hdc, dstRect.X, dstRect.Y, dstRect.Width, dstRect.Height, roi.X, roi.Y);
                    return;
                }

                if (roi.Width > dstRect.Width)
                {
                    Win32API.SetStretchBltMode(hdc, Win32API.HALFTONE);
                }
                else
                {
                    Win32API.SetStretchBltMode(hdc, Win32API.COLORONCOLOR);
                }

                FillBitmapInfo(ref bmi, bmpW, bmpH, img.Bpp, (int)img.Origin);

                Win32API.StretchDIBits(
                    hdc,
                    dstRect.X, dstRect.Y, dstRect.Width, dstRect.Height,
                    roi.X, roi.Y, roi.Width, roi.Height,
                    img.ImageData, ref bmi, Win32API.DIB_RGB_COLORS, Win32API.SRCCOPY);

                Marshal.FreeHGlobal(buffer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="hdc"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="fromX"></param>
        /// <param name="fromY"></param>
        public static void DrawToHdc(this IplImage img, IntPtr hdc, int x, int y, int w, int h, int fromX, int fromY)
        {
            if (Platform.OS == OS.Unix)
            {
                throw new PlatformNotSupportedException("This method is only for Windows.");
            }

            if (img == null)
                throw new ArgumentNullException("img");
            if (hdc == IntPtr.Zero)
                throw new ArgumentNullException("hdc");
            if (img.Depth != BitDepth.U8)
                throw new NotSupportedException();

            int bmpW = img.Width;
            int bmpH = img.Height;

            unsafe
            {
                int headerSize = sizeof(Win32API.BITMAPINFOHEADER) + 1024;
                IntPtr buffer = Marshal.AllocHGlobal(headerSize);
                Win32API.BITMAPINFO bmi = (Win32API.BITMAPINFO)Marshal.PtrToStructure(buffer, typeof(Win32API.BITMAPINFO));

                FillBitmapInfo(ref bmi, bmpW, bmpH, img.Bpp, (int)img.Origin);

                fromX = Math.Min(Math.Max(fromX, 0), bmpW - 1);
                fromY = Math.Min(Math.Max(fromY, 0), bmpH - 1);

                uint sw = (uint)Math.Max(Math.Min(bmpW - fromX, w), 0);
                uint sh = (uint)Math.Max(Math.Min(bmpH - fromY, h), 0);

                Win32API.SetDIBitsToDevice(
                    hdc, x, y, sw, sh, fromX, fromY, (uint)fromY, sh,
                    new IntPtr(img.ImageData.ToInt32() + fromY * img.WidthStep),
                    ref bmi, Win32API.DIB_RGB_COLORS);

                Marshal.FreeHGlobal(buffer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="g"></param>
        /// <param name="dstRect"></param>
        public static void DrawToGraphics(this IplImage img, Graphics g, CvRect dstRect)
        {
            if (Platform.OS == OS.Unix)
            {
                throw new PlatformNotSupportedException("This method is only for Windows.");
            }

            IntPtr hdc = g.GetHdc();
            DrawToHdc(img, hdc, dstRect);
            g.ReleaseHdc(hdc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="fromX"></param>
        /// <param name="fromY"></param>
        public static void DrawToGraphics(this IplImage img, Graphics g, int x, int y, int w, int h, int fromX, int fromY)
        {
            if (Platform.OS == OS.Unix)
            {
                throw new PlatformNotSupportedException("This method is only for Windows.");
            }

            IntPtr hdc = g.GetHdc();
            DrawToHdc(img, hdc, x, y, w, h, fromX, fromY);
            g.ReleaseHdc(hdc);
        }

        private static unsafe void FillBitmapInfo(ref Win32API.BITMAPINFO bmi, int width, int height, int bpp, int origin)
        {
            Debug.Assert(width > 0 && height > 0 && (bpp == 8 || bpp == 24 || bpp == 32));

            Win32API.BITMAPINFOHEADER bmih = bmi.Header;
            using (ScopedGCHandle handle = new ScopedGCHandle(bmih, GCHandleType.Pinned))
            {
                //Win32API.FillMemory(handle.AddrOfPinnedObject(), Marshal.SizeOf(typeof(Win32API.BITMAPINFOHEADER)), 0);
                bmih.Size = (uint)sizeof(Win32API.BITMAPINFOHEADER);
                bmih.Width = width;
                bmih.Height = (origin != 0) ? Math.Abs(height) : -Math.Abs(height);
                bmih.Planes = 1;
                bmih.BitCount = (ushort)bpp;
                bmih.Compression = Win32API.BI_RGB;
                bmih.ClrImportant = 0;
                bmih.Compression = 0;
                bmih.SizeImage = 0;
                bmih.XPelsPerMeter = 0;
                bmih.YPelsPerMeter = 0;
                bmi.Header = bmih;
            }

            if (bpp == 8)
            {
                Win32API.RGBQUAD[] palette = bmi.Colors;
                for (int i = 0; i < palette.Length; i++)
                {
                    palette[i].Blue = palette[i].Green = palette[i].Red = (byte)i;
                    palette[i].Reserved = 0;
                }
                bmi.Colors = palette;
            }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public static class BitmapExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static IplImage FromBitmap(this Bitmap bitmap)
        {
            return BitmapConverter.ToIplImage(bitmap);
        }
    }
}
