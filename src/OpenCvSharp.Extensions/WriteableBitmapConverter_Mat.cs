using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.Extensions
{
    static partial class WriteableBitmapConverter
    {
        #region ToWriteableBitmap
#if LANG_JP
        /// <summary>
        /// MatをWriteableBitmapに変換する. 引数はWriteableBitmapのコンストラクタに相当する.
        /// </summary>
        /// <param name="src">変換するMat</param>
        /// <param name="dpiX">ビットマップの水平ドット/インチ (dpi)</param>
        /// <param name="dpiY">ビットマップの垂直ドット/インチ (dpi)</param>
        /// <param name="pf">ビットマップの PixelFormat</param>
        /// <param name="bp">ビットマップの BitmapPalette</param>
        /// <returns>WPFのWriteableBitmap</returns>
#else
        /// <summary>
        /// Converts Mat to WriteableBitmap.
        /// The arguments of this method corresponds the consructor of WriteableBitmap.
        /// </summary>
        /// <param name="src">Input Mat</param>
        /// <param name="dpiX">Horizontal dots per inch</param>
        /// <param name="dpiY">Vertical dots per inch</param>
        /// <param name="pf">Pixel format of output WriteableBitmap</param>
        /// <param name="bp">Bitmap pallette</param>
        /// <returns>WriteableBitmap</returns>
#endif
        public static WriteableBitmap ToWriteableBitmap(this Mat src, double dpiX, double dpiY, PixelFormat pf, BitmapPalette bp)
        {
            if (src == null)
                throw new ArgumentNullException("src");

            var wb = new WriteableBitmap(src.Width, src.Height, dpiX, dpiY, pf, bp);
            ToWriteableBitmap(src, wb);
            return wb;
        }
#if LANG_JP
        /// <summary>
	    /// MatをWriteableBitmapに変換する (dpi=96, BitmapPalette=null)
        /// </summary>
        /// <param name="src">変換するMat</param>
        /// <param name="pf">ビットマップの PixelFormat</param>
        /// <returns>WPFのWriteableBitmap</returns>
#else
        /// <summary>
        /// Converts Mat to WriteableBitmap (dpi=96, BitmapPalette=null)
        /// </summary>
        /// <param name="src">Input Mat</param>
        /// <param name="pf">Pixel format of output WriteableBitmap</param>
        /// <returns>WriteableBitmap</returns>
#endif
        public static WriteableBitmap ToWriteableBitmap(this Mat src, PixelFormat pf)
        {
            return ToWriteableBitmap(src, 96, 96, pf, null);
        }
#if LANG_JP
        /// <summary>
	    /// MatをWriteableBitmapに変換する (dpi=96, BitmapPalette=null)
        /// </summary>
        /// <param name="src">変換するMat</param>
        /// <returns>WPFのWriteableBitmap</returns>
#else
        /// <summary>
        /// Converts Mat to WriteableBitmap (dpi=96, BitmapPalette=null)
        /// </summary>
        /// <param name="src">Input Mat</param>
        /// <returns>WriteableBitmap</returns>
#endif
        public static WriteableBitmap ToWriteableBitmap(this Mat src)
        {
            PixelFormat pf = GetOptimumPixelFormats(src.Type());
            return ToWriteableBitmap(src, 96, 96, pf, null);
        }

#if LANG_JP
        /// <summary>
        /// MatをWriteableBitmapに変換する.
        /// 返却値を新たに生成せず引数で指定したWriteableBitmapに格納するので、メモリ効率が良い。
        /// </summary>
        /// <param name="src">変換するMat</param>
        /// <param name="dst">変換結果を設定するWriteableBitmap</param>
#else
        /// <summary>
        /// Converts Mat to WriteableBitmap.
        /// This method is more efficient because new instance of WriteableBitmap is not allocated.
        /// </summary>
        /// <param name="src">Input Mat</param>
        /// <param name="dst">Output WriteableBitmap</param>
#endif
        public static void ToWriteableBitmap(Mat src, WriteableBitmap dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.Width != dst.PixelWidth || src.Height != dst.PixelHeight)
                throw new ArgumentException("size of src must be equal to size of dst");
            //if (src.Depth != BitDepth.U8)
            //throw new ArgumentException("bit depth of src must be BitDepth.U8", "src");
            if (src.Dims() > 2)
                throw new ArgumentException("Mat dimensions must be 2");

            int w = src.Width;
            int h = src.Height;
            int bpp = dst.Format.BitsPerPixel;

            int channels = GetOptimumChannels(dst.Format);
            if (src.Channels() != channels)
            {
                throw new ArgumentException("channels of dst != channels of PixelFormat", "dst");
            }

            bool submat = src.IsSubmatrix();
            bool continuous = src.IsContinuous();
            unsafe
            {
                byte* pSrc = (byte*)(src.Data);
                int sstep = (int)src.Step();

                if (bpp == 1)
                {
                    if (submat)
                        throw new NotImplementedException("submatrix not supported");

                    // 手作業で移し替える
                    int stride = w / 8 + 1;
                    if (stride < 2)
                        stride = 2;

                    byte[] pixels = new byte[h * stride];

                    for (int x = 0, y = 0; y < h; y++)
                    {
                        int offset = y * stride;
                        for (int bytePos = 0; bytePos < stride; bytePos++)
                        {
                            if (x < w)
                            {
                                byte b = 0;
                                // 現在の位置から横8ピクセル分、ビットがそれぞれ立っているか調べ、1つのbyteにまとめる
                                for (int i = 0; i < 8; i++)
                                {
                                    b <<= 1;
                                    if (x < w && pSrc[sstep * y + x] != 0)
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
                    dst.WritePixels(new Int32Rect(0, 0, w, h), pixels, stride, 0);
                    return;
                }

                // 一気にコピー            
                if (!submat && continuous)
                {
                    long imageSize = src.DataEnd.ToInt64() - src.Data.ToInt64();
                    if (imageSize < 0)
                        throw new OpenCvSharpException("The mat has invalid data pointer");
                    if (imageSize > Int32.MaxValue)
                        throw new OpenCvSharpException("Too big mat data");
                    dst.WritePixels(new Int32Rect(0, 0, w, h), src.Data, (int)imageSize, sstep);
                    return;
                }

                // 一列ごとにコピー
                try
                {
                    dst.Lock();

                    int dstep = dst.BackBufferStride;
                    byte* pDst = (byte*)dst.BackBuffer;

                    for (int y = 0; y < h; y++)
                    {
                        long offsetSrc = (y * sstep);
                        long offsetDst = (y * dstep);
                        Util.CopyMemory(pDst + offsetDst, pSrc + offsetSrc, w * channels);
                    }
                }
                finally
                {
                    dst.Unlock();
                }
            }
        }
        #endregion
    }
}
