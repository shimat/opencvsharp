using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp.Util;

namespace OpenCvSharp.Extensions
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
    public static class BitmapConverter
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
        public static Mat ToMat(this Bitmap src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

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
                    channels = 4; break;
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
        public static unsafe void ToMat(this Bitmap src, Mat dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (dst.IsDisposed)
                throw new ArgumentException("The specified dst is disposed.", nameof(dst));
            if (dst.Depth() != MatType.CV_8U)
                throw new NotSupportedException("Mat depth != CV_8U");
            if (dst.Dims() != 2)
                throw new NotSupportedException("Mat dims != 2");
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
                IntPtr dstData = dst.Data;
                byte* dstPtr = (byte*)dstData.ToPointer();

                bool submat = dst.IsSubmatrix();
                bool continuous = dst.IsContinuous();

                switch (src.PixelFormat)
                {
                    case PixelFormat.Format1bppIndexed:
                        {
                            if (dst.Channels() != 1)
                                throw new ArgumentException("Invalid nChannels");
                            if (submat)
                                throw new NotImplementedException("submatrix not supported");

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
                                            dstPtr[dstep * y + x] = ((b & 0x80) == 0x80) ? (byte)255 : (byte)0;
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
                            if (src.PixelFormat == PixelFormat.Format8bppIndexed)
                                if (dst.Channels() != 1)
                                    throw new ArgumentException("Invalid nChannels");
                            if (src.PixelFormat == PixelFormat.Format24bppRgb)
                                if (dst.Channels() != 3)
                                    throw new ArgumentException("Invalid nChannels");

                            // ステップが同じで連続なら、一気にコピー
                            if (dstep == sstep && !submat && continuous)
                            {
                                uint length = (uint)(dst.DataEnd.ToInt64() - dstData.ToInt64());
                                MemoryHelper.CopyMemory(dstData, bd.Scan0, length);
                            }
                            else
                            {
                                // 各行ごとにdstの行バイト幅コピー
                                byte* sp = (byte*)bd.Scan0;
                                byte* dp = (byte*)dst.Data;
                                for (int y = 0; y < h; y++)
                                {
                                    MemoryHelper.CopyMemory(dp, sp, dstep);
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
                            switch (dst.Channels())
                            {
                                case 4:
                                    if (!submat && continuous)
                                    {
                                        uint length = (uint)(dst.DataEnd.ToInt64() - dstData.ToInt64());
                                        MemoryHelper.CopyMemory(dstData, bd.Scan0, length);
                                    }
                                    else
                                    {
                                        byte* sp = (byte*)bd.Scan0;
                                        byte* dp = (byte*)dst.Data;
                                        for (int y = 0; y < h; y++)
                                        {
                                            MemoryHelper.CopyMemory(dp, sp, dstep);
                                            sp += sstep;
                                            dp += dstep;
                                        }
                                    }
                                    break;
                                case 3:
                                    for (int y = 0; y < h; y++)
                                    {
                                        for (int x = 0; x < w; x++)
                                        {
                                            dstPtr[y * dstep + x * 3 + 0] = p[y * sstep + x * 4 + 0];
                                            dstPtr[y * dstep + x * 3 + 1] = p[y * sstep + x * 4 + 1];
                                            dstPtr[y * dstep + x * 3 + 2] = p[y * sstep + x * 4 + 2];
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
                if (bd != null)
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
        public static Bitmap ToBitmap(this Mat src)
        {
            if (src == null)
            {
                throw new ArgumentNullException(nameof(src));
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
                    throw new ArgumentException("Number of channels must be 1, 3 or 4.", nameof(src));
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
        public static Bitmap ToBitmap(this Mat src, PixelFormat pf)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
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
        public static unsafe void ToBitmap(this Mat src, Bitmap dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (src.IsDisposed)
                throw new ArgumentException("The image is disposed.", nameof(src));
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

            bool submat = src.IsSubmatrix();
            bool continuous = src.IsContinuous();

            try
            {
                bd = dst.LockBits(rect, ImageLockMode.WriteOnly, pf);

                IntPtr srcData = src.Data;
                byte* pSrc = (byte*)(srcData.ToPointer());
                byte* pDst = (byte*)(bd.Scan0.ToPointer());
                int ch = src.Channels();
                int sstep = (int)src.Step();
                int dstep = ((src.Width * ch) + 3) / 4 * 4; // 4の倍数に揃える
                int stride = bd.Stride;

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
                                            if (x < w && pSrc[sstep * y + x] == 0)
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
                        if (sstep == dstep && !submat && continuous)
                        {
                            uint imageSize = (uint)(src.DataEnd.ToInt64() - src.Data.ToInt64());
                            MemoryHelper.CopyMemory(pDst, pSrc, imageSize);
                        }
                        else
                        {
                            for (int y = 0; y < h; y++)
                            {
                                long offsetSrc = (y * sstep);
                                long offsetDst = (y * dstep);
                                // 一列ごとにコピー
                                MemoryHelper.CopyMemory(pDst + offsetDst, pSrc + offsetSrc, w * ch);
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
