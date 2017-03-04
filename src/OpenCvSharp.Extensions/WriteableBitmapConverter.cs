using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenCvSharp.Util;

namespace OpenCvSharp.Extensions
{
    /// <summary>
    /// Static class which provides conversion between System.Windows.Media.Imaging.WriteableBitmap and Mat
    /// </summary>
    public static class WriteableBitmapConverter
    {
        private static readonly Dictionary<PixelFormat, int> optimumChannels;
        private static readonly Dictionary<PixelFormat, MatType> optimumTypes;

        static WriteableBitmapConverter()
        {
            optimumChannels = new Dictionary<PixelFormat, int>();
            optimumChannels[PixelFormats.Indexed1] =
            optimumChannels[PixelFormats.Indexed8] =
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
            optimumTypes[PixelFormats.Indexed1] =
            optimumTypes[PixelFormats.Indexed8] =
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
        /// 指定したPixelFormatに適合するMatのチャンネル数を返す
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        internal static int GetOptimumChannels(PixelFormat f)
        {
            try
            {
                return optimumChannels[f];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("Not supported PixelFormat");
            }
        }

        /// <summary>
        /// 指定したPixelFormatに適合するMatTypeを返す
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        internal static MatType GetOptimumType(PixelFormat f)
        {
            try
            {
                return optimumTypes[f];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("Not supported PixelFormat");
            }
        }

        /// <summary>
        /// 指定したMatのビット深度・チャンネル数に適合するPixelFormatを返す
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
        public static WriteableBitmap ToWriteableBitmap(this Mat src, double dpiX, double dpiY, PixelFormat pf,
            BitmapPalette bp)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            
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
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
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
                throw new ArgumentException("channels of dst != channels of PixelFormat", nameof(dst));
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
                        MemoryHelper.CopyMemory(pDst + offsetDst, pSrc + offsetSrc, w * channels);
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
