/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// System.Drawing.BitmapとMatの相互変換メソッドを提供するクラス
    /// </summary>
#else
    /// <summary>
    /// static class which provides conversion between System.Drawing.Bitmap and Mat
    /// </summary>
#endif
    public static class BitmapConverter2
    {
        #region ToMat
#if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapからOpenCVのMatへ変換して返す.
        /// </summary>
        /// <param name="src">変換するSystem.Drawing.Bitmap</param>
        /// <returns>変換結果のMat</returns>
#else
        /// <summary>
        /// Converts System.Drawing.Bitmap to Mat
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap object to be converted</param>
        /// <returns>A Mat object which is converted from System.Drawing.Bitmap</returns>
#endif
        public static Mat ToMat(Bitmap src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            
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

            Mat dst = new Mat(h, w, MatType.CV_8UC(channels));
            ToMat(src, dst);
            return dst;
        }

#if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapからOpenCVのMatへ変換して返す.
        /// </summary>
        /// <param name="src">変換するSystem.Drawing.Bitmap</param>
        /// <param name="dst">変換結果を格納するMat</param>
#else
        /// <summary>
        /// Converts System.Drawing.Bitmap to Mat
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap object to be converted</param>
        /// <param name="dst">A Mat object which is converted from System.Drawing.Bitmap</param>
#endif
        public static unsafe void ToMat(Bitmap src, Mat dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (dst.IsDisposed)
                throw new ArgumentException("The specified dst is disposed.", "dst");
            if (dst.Depth() != MatType.CV_8U)
                throw new NotSupportedException("Mat depth != CV_8U");
            if (dst.Dims() != 2)
                throw new NotSupportedException("Mat dims != 2");
            //if (dst.IsSubmatrix())
            //    throw new NotSupportedException("Submatrix is not supported");
            if (src.Width != dst.Width || src.Height != dst.Height)
                throw new ArgumentException("src.Size != dst.Size");

            int w = src.Width;
            int h = src.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);
            BitmapData bd = null;
            try
            {
                bd = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);

                byte* p = (byte*)bd.Scan0.ToPointer();
                int sstep = bd.Stride;
                int offset = sstep - (w / 8);
                uint dstep = (uint)dst.Step();
                byte* dstData = (byte*)dst.Data.ToPointer();

                switch (src.PixelFormat)
                {
                    case PixelFormat.Format1bppIndexed:
                    {
                        if (dst.Channels() != 1)
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
                            for (bytePos = 0; bytePos < sstep; bytePos++)
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
                                        dstData[dstep * y + x] = ((b & 0x80) == 0x80) ? (byte)255 : (byte)0;
                                        b <<= 1;
                                        x++;
                                    }
                                }
                            }
                            // 次の行へ
                            x = 0;
                            p += sstep;
                        }
                    }
                        break;

                    case PixelFormat.Format8bppIndexed:
                    case PixelFormat.Format24bppRgb:
                    {
                        if (dst.Channels() != 1)
                            throw new ArgumentException("Invalid nChannels");

                        // Mat幅が4の倍数なら一気にコピー
                        if (dstep % 4 == 0)
                        {
                            uint length = (uint)(dst.DataEnd.ToInt64() - dst.DataStart.ToInt64());
                            Util.CopyMemory(dst.DataStart, bd.Scan0, length);
                        }
                        else
                        {
                            // 各行ごとにdstの行バイト幅コピー
                            byte* sp = (byte*)bd.Scan0;
                            byte* dp = (byte*)dst.DataStart;
                            for (int y = 0; y < h; y++)
                            {
                                Util.CopyMemory(dp, sp, dstep);
                                sp += sstep;
                                dp += dstep;
                            }
                        }
                    }
                        break;

                    case PixelFormat.Format32bppRgb:
                    case PixelFormat.Format32bppArgb:
                    case PixelFormat.Format32bppPArgb:
                    {
                        // 4チャネルならアラインメント調整いらない(はず)
                        switch (dst.Channels())
                        {
                            case 4:
                                uint length = (uint)(dst.DataEnd.ToInt64() - dst.DataStart.ToInt64());
                                Util.CopyMemory(dst.DataStart, bd.Scan0, length);
                                break;
                            case 3:
                                for (int y = 0; y < h; y++)
                                {
                                    for (int x = 0; x < w; x++)
                                    {
                                        dstData[y * dstep + x * 3 + 0] = p[y * sstep + x * 4 + 0];
                                        dstData[y * dstep + x * 3 + 1] = p[y * sstep + x * 4 + 1];
                                        dstData[y * dstep + x * 3 + 2] = p[y * sstep + x * 4 + 2];
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
        #endregion

        #region ToBitmap
#if LANG_JP
        /// <summary>
        /// OpenCVのMatをSystem.Drawing.Bitmapに変換する
        /// </summary>
        /// <param name="src">変換するMat</param>
        /// <returns>System.Drawing.Bitmap</returns>
#else
        /// <summary>
        /// Converts Mat to System.Drawing.Bitmap
        /// </summary>
        /// <param name="src">Mat</param>
        /// <returns></returns>
#endif
        public static Bitmap ToBitmap(Mat src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            PixelFormat pf;
            switch (src.Channels())
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
        /// OpenCVのMatをSystem.Drawing.Bitmapに変換する
        /// </summary>
        /// <param name="src">変換するMat</param>
        /// <param name="pf">ピクセル深度</param>
        /// <returns>System.Drawing.Bitmap</returns>
#else
        /// <summary>
        /// Converts Mat to System.Drawing.Bitmap
        /// </summary>
        /// <param name="src">Mat</param>
        /// <param name="pf">Pixel Depth</param>
        /// <returns></returns>
#endif
        public static Bitmap ToBitmap(Mat src, PixelFormat pf)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();

            Bitmap bitmap = new Bitmap(src.Width, src.Height, pf);
            ToBitmap(src, bitmap);
            return bitmap;
        }

#if LANG_JP
        /// <summary>
        /// OpenCVのMatを指定した出力先にSystem.Drawing.Bitmapとして変換する
        /// </summary>
        /// <param name="src">変換するMat</param>
        /// <param name="dst">出力先のSystem.Drawing.Bitmap</param>
        /// <remarks>Author: shimat, Gummo (ROI support)</remarks>
#else
        /// <summary>
        /// Converts Mat to System.Drawing.Bitmap
        /// </summary>
        /// <param name="src">Mat</param>
        /// <param name="dst">Mat</param>
        /// <remarks>Author: shimat, Gummo (ROI support)</remarks>
#endif
        public static unsafe void ToBitmap(Mat src, Bitmap dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.IsDisposed)
                throw new ArgumentException("The image is disposed.", "src");
            if (src.Depth() != MatType.CV_8U)
                throw new ArgumentException("Depth of the image must be CV_8U");
            //if (src.IsSubmatrix())
            //    throw new ArgumentException("Submatrix is not supported");
            if (src.Width != dst.Width || src.Height != dst.Height)
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

            int w = src.Width;
            int h = src.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);
            BitmapData bd = null;

            try
            {
                bd = dst.LockBits(rect, ImageLockMode.WriteOnly, pf);


                byte* psrc = (byte*)(src.DataStart.ToPointer());
                byte* pdst = (byte*)(bd.Scan0.ToPointer());
                int ch = src.Channels();
                int sstep = (int)src.Step();
                int dstep = ((src.Width * ch) + 3) / 4 * 4; // 4の倍数に揃える
                int stride = bd.Stride;

                switch (pf)
                {
                    case PixelFormat.Format1bppIndexed:
                    {
                        // BitmapDataは4byte幅だが、IplImageは1byte幅
                        // 手作業で移し替える				 
                        //int offset = stride - (w / 8);
                        int x = 0;
                        int y;
                        int bytePos;
                        byte mask;
                        byte b = 0;
                        int i;
                        for (y = 0; y < h; y++)
                        {
                            for (bytePos = 0; bytePos < stride; bytePos++)
                            {
                                if (x < w)
                                {
                                    for (i = 0; i < 8; i++)
                                    {
                                        mask = (byte)(0x80 >> i);
                                        if (x < w && psrc[sstep * y + x] == 0)
                                            b &= (byte)(mask ^ 0xff);
                                        else
                                            b |= mask;

                                        x++;
                                    }
                                    pdst[bytePos] = b;
                                }
                            }
                            x = 0;
                            pdst += stride;
                        }
                        break;
                    }

                    case PixelFormat.Format8bppIndexed:
                    case PixelFormat.Format24bppRgb:
                    case PixelFormat.Format32bppArgb:
                        if (sstep == dstep)
                        {
                            uint imageSize = (uint)(src.DataEnd.ToInt64() - src.DataEnd.ToInt64());
                            Util.CopyMemory(pdst, psrc, imageSize);
                        }
                        else
                        {
                            for (int y = 0; y < h; y++)
                            {
                                int offsetSrc = (y * sstep);
                                int offsetDst = (y * dstep);
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
                dst.UnlockBits(bd);
            }
        }
        #endregion
    }
}
