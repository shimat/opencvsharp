using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OpenCvSharp.Extensions
{
#if LANG_JP
    /// <summary>
    /// System.Windows.Media.Imaging.WriteableBitmapとOpenCVのIplImageとの間の相互変換メソッドを提供するクラス
    /// </summary>
#else
    /// <summary>
    /// A static class which provides conversion between System.Windows.Media.Imaging.WriteableBitmap and IplImage
    /// </summary>
#endif
    public static class WriteableBitmapConverter
    {
        private static Dictionary<PixelFormat, BitDepth> _optimumDepths;
        private static Dictionary<PixelFormat, int> _optimumChannels;

        /// <summary>
        /// 
        /// </summary>
        static WriteableBitmapConverter()
        {
            _optimumDepths = new Dictionary<PixelFormat, BitDepth>();
            _optimumDepths[PixelFormats.Indexed1] =
            _optimumDepths[PixelFormats.Indexed8] =
            _optimumDepths[PixelFormats.Gray2] =
            _optimumDepths[PixelFormats.Gray4] =
            _optimumDepths[PixelFormats.Gray8] =
            _optimumDepths[PixelFormats.Indexed1] =
            _optimumDepths[PixelFormats.Indexed2] =
            _optimumDepths[PixelFormats.Indexed4] =
            _optimumDepths[PixelFormats.Indexed8] =
            _optimumDepths[PixelFormats.BlackWhite] =
            _optimumDepths[PixelFormats.Bgr24] =
            _optimumDepths[PixelFormats.Bgr555] =
            _optimumDepths[PixelFormats.Bgr565] =
            _optimumDepths[PixelFormats.Rgb24] =
            _optimumDepths[PixelFormats.Bgra32] =
            _optimumDepths[PixelFormats.Cmyk32] =
            _optimumDepths[PixelFormats.Pbgra32] =
            _optimumDepths[PixelFormats.Bgr32] = BitDepth.U8;
            _optimumDepths[PixelFormats.Bgr101010] =
            _optimumDepths[PixelFormats.Gray16] =
            _optimumDepths[PixelFormats.Rgb48] =
            _optimumDepths[PixelFormats.Rgba64] = BitDepth.U16;
            _optimumDepths[PixelFormats.Gray32Float] =
            _optimumDepths[PixelFormats.Prgba128Float] =
            _optimumDepths[PixelFormats.Rgb128Float] =
            _optimumDepths[PixelFormats.Rgba128Float] = BitDepth.F32;
            _optimumDepths[PixelFormats.Prgba64] = BitDepth.S32;

            _optimumChannels = new Dictionary<PixelFormat, int>();
            _optimumChannels[PixelFormats.Indexed1] =
            _optimumChannels[PixelFormats.Indexed8] =
            _optimumChannels[PixelFormats.Gray2] =
            _optimumChannels[PixelFormats.Gray4] =
            _optimumChannels[PixelFormats.Gray8] =
            _optimumChannels[PixelFormats.Gray16] =
            _optimumChannels[PixelFormats.Gray32Float] =
            _optimumChannels[PixelFormats.Indexed1] =
            _optimumChannels[PixelFormats.Indexed2] =
            _optimumChannels[PixelFormats.Indexed4] =
            _optimumChannels[PixelFormats.Indexed8] =
            _optimumChannels[PixelFormats.BlackWhite] = 1;
            _optimumChannels[PixelFormats.Bgr24] =
            _optimumChannels[PixelFormats.Bgr555] =
            _optimumChannels[PixelFormats.Bgr565] =
            _optimumChannels[PixelFormats.Rgb24] =
            _optimumChannels[PixelFormats.Rgb48] =
            _optimumChannels[PixelFormats.Rgb128Float] = 3;
            _optimumChannels[PixelFormats.Bgr32] =
            _optimumChannels[PixelFormats.Bgra32] =
            _optimumChannels[PixelFormats.Cmyk32] =
            _optimumChannels[PixelFormats.Pbgra32] =
            _optimumChannels[PixelFormats.Prgba64] =
            _optimumChannels[PixelFormats.Prgba128Float] =
            _optimumChannels[PixelFormats.Rgba64] =
            _optimumChannels[PixelFormats.Rgba128Float] = 4;
        }

        #region ToIplImage
        /// <summary>
        /// 指定したPixelFormatに適合するIplImageのビット深度を返す
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private static BitDepth GetOptimumDepth(PixelFormat f)
        {
            try
            {
                return _optimumDepths[f];
            }
            catch (KeyNotFoundException)
            {
                throw new NotImplementedException("Not supported PixelFormat");
            }
        }
        /// <summary>
        /// 指定したPixelFormatに適合するIplImageのチャンネル数を返す
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private static int GetOptimumChannels(PixelFormat f)
        {
            try
            {
                return _optimumChannels[f];
            }
            catch (KeyNotFoundException)
            {
                throw new NotImplementedException("Not supported PixelFormat");
            }
        }
#if LANG_JP
        /// <summary>
        /// WriteableBitmapをIplImageに変換する
        /// </summary>
        /// <param name="src">変換するWriteableBitmap</param>
        /// <returns>OpenCvSharpで扱えるIplImage</returns>
#else
        /// <summary>
        /// Converts WriteableBitmap to IplImage
        /// </summary>
        /// <param name="src">Input WriteableBitmap</param>
        /// <returns>IplImage</returns>
#endif
        public static IplImage ToIplImage(this WriteableBitmap src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }

            int w = src.PixelWidth;
            int h = src.PixelHeight;            
            int bpp = src.Format.BitsPerPixel;
            int channels = GetOptimumChannels(src.Format);
            BitDepth depth = GetOptimumDepth(src.Format);
            IplImage dst = Cv.CreateImage(new CvSize(w, h), depth, channels);
            ToIplImage(src, dst);
            return dst;
        }
#if LANG_JP
        /// <summary>
        /// WriteableBitmapをIplImageに変換する.
        /// </summary>
        /// <param name="src">変換するWriteableBitmap</param>
        /// <param name="dst">出力先のIplImage</param>
#else
        /// <summary>
        /// Converts WriteableBitmap to IplImage
        /// </summary>
        /// <param name="src">Input WriteableBitmap</param>
        /// <param name="dst">Output IplImage</param>
#endif
        public static void ToIplImage(this WriteableBitmap src, IplImage dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.PixelWidth != dst.Width || src.PixelHeight != dst.Height)
                throw new ArgumentException("size of src must be equal to size of dst");
            //if (dst.Depth != BitDepth.U8)
            //    throw new ArgumentException("bit depth of dst must be BitDepth.U8", "dst");
            
            int w = src.PixelWidth;
            int h = src.PixelHeight;
            int bpp = src.Format.BitsPerPixel;
            int channels = GetOptimumChannels(src.Format);            
            if (dst.NChannels != channels)
            {
                throw new ArgumentException("nChannels of dst is invalid", "dst");
            }

            unsafe
            {
                byte* p = (byte*)(dst.ImageData.ToPointer());
                int widthStep = dst.WidthStep;

                // 1bppは手作業でコピー
                if (bpp == 1)
                {
                    // BitmapImageのデータを配列にコピー
                    // 要素1つに横8ピクセル分のデータが入っている。   
                    int stride = (w / 8) + 1;
                    byte[] pixels = new byte[h * stride];
                    src.CopyPixels(pixels, stride, 0);
                    int offset = 0;
                    int x = 0;
                    int y;
                    int byte_pos;
                    int i;
                    byte b;

                    for (y = 0; y < h; y++)
                    {
                        offset = y * stride;
                        // この行の各バイトを調べていく
                        for (byte_pos = 0; byte_pos < stride; byte_pos++)
                        {
                            if (x < w)
                            {
                                // 現在の位置のバイトからそれぞれのビット8つを取り出す
                                b = pixels[offset + byte_pos];
                                for (i = 0; i < 8; i++)
                                {
                                    if (x >= w)
                                    {
                                        break;
                                    }
                                    // IplImageは8bit/pixel
                                    p[widthStep * y + x] = ((b & 0x80) == 0x80) ? (byte)255 : (byte)0;
                                    b <<= 1;
                                    x++;
                                }
                            }
                        }
                        // 次の行へ
                        x = 0;
                    }

                }
                // 8bpp
                else if (bpp == 8)
                {
                    int stride = w;
                    byte[] pixels = new byte[h * stride];
                    src.CopyPixels(pixels, stride, 0);
                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            p[widthStep * y + x] = pixels[y * stride + x];
                        }
                    }
                }
                // 24bpp, 32bpp, ...
                else
                {
                    int stride = w * ((bpp + 7) / 8);
                    src.CopyPixels(Int32Rect.Empty, dst.ImageData, dst.ImageSize, stride);
                }

            }
        }
        #region CopyFrom
#if LANG_JP
        /// <summary>
        /// System.Windows.Media.Imaging.WriteableBitmapからこのインスタンスへデータをコピーする
        /// </summary>
        /// <param name="ipl"></param>
        /// <param name="wb"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Copies pixel data from System.Windows.Media.Imaging.WriteableBitmap to this instance
        /// </summary>
        /// <param name="ipl"></param>
        /// <param name="wb"></param>
        /// <returns></returns>
#endif
        public static void CopyFrom(this IplImage ipl, WriteableBitmap wb)
        {
            if (wb == null)
            {
                throw new ArgumentNullException("wb");
            }
            ToIplImage(wb, ipl);
        }
        #endregion
        #endregion

        #region ToWriteableBitmap
        /// <summary>
        /// 指定したIplImageのビット深度・チャンネル数に適合するPixelFormatを返す
        /// </summary>
        /// <param name="d"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static PixelFormat GetOptimumPixelFormats(BitDepth d, int c)
        {
            switch (d)
            {
                case BitDepth.U8:
                case BitDepth.S8:
                    switch (c)
                    {
                        case 1:
                            return PixelFormats.Gray8;
                        case 3:
                            return PixelFormats.Bgr24;
                        case 4:
                            return PixelFormats.Bgra32;
                        default:
                            throw new NotImplementedException("Not supported BitDepth and/or NChannels"); 
                    }
                case BitDepth.U16:
                case BitDepth.S16:
                    switch (c)
                    {
                        case 1:
                            return PixelFormats.Gray16;
                        case 3:
                            return PixelFormats.Rgb48;
                        case 4:
                            return PixelFormats.Rgba64;
                        default:
                            throw new NotImplementedException("Not supported BitDepth and/or NChannels"); 
                    }
                case BitDepth.S32:
                    switch (c)
                    {
                        case 4:
                            return PixelFormats.Prgba64;
                        default:
                            throw new NotImplementedException("Not supported BitDepth and/or NChannels");
                    }
                case BitDepth.F32:
                    switch (c)
                    {
                        case 1:
                            return PixelFormats.Gray32Float;
                        case 3:
                            return PixelFormats.Rgb128Float;
                        case 4:
                            return PixelFormats.Rgba128Float;
                        default:
                            throw new NotImplementedException("Not supported BitDepth and/or NChannels");
                    }
                case BitDepth.F64:
                default:
                    throw new NotImplementedException("Not supported BitDepth");
            }
        }
#if LANG_JP
        /// <summary>
        /// IplImageをWriteableBitmapに変換する. 引数はWriteableBitmapのコンストラクタに相当する.
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="dpiX">ビットマップの水平ドット/インチ (dpi)</param>
        /// <param name="dpiY">ビットマップの垂直ドット/インチ (dpi)</param>
        /// <param name="pf">ビットマップの PixelFormat</param>
        /// <param name="bp">ビットマップの BitmapPalette</param>
        /// <returns>WPFのWriteableBitmap</returns>
#else
        /// <summary>
        /// Converts IplImage to WriteableBitmap.
        /// The arguments of this method corresponds the consructor of WriteableBitmap.
        /// </summary>
        /// <param name="src">Input IplImage</param>
        /// <param name="dpiX">Horizontal dots per inch</param>
        /// <param name="dpiY">Vertical dots per inch</param>
        /// <param name="pf">Pixel format of output WriteableBitmap</param>
        /// <param name="bp">Bitmap pallette</param>
        /// <returns>WriteableBitmap</returns>
#endif
        public static WriteableBitmap ToWriteableBitmap(this IplImage src, double dpiX, double dpiY, PixelFormat pf, BitmapPalette bp)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            WriteableBitmap wb = new WriteableBitmap(src.Width, src.Height, dpiX, dpiY, pf, bp);
            ToWriteableBitmap(src, wb);
            return wb;
        }
#if LANG_JP
        /// <summary>
	    /// IplImageをWriteableBitmapに変換する (dpi=96, BitmapPalette=null)
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="pf">ビットマップの PixelFormat</param>
        /// <returns>WPFのWriteableBitmap</returns>
#else
        /// <summary>
        /// Converts IplImage to WriteableBitmap (dpi=96, BitmapPalette=null)
        /// </summary>
        /// <param name="src">Input IplImage</param>
        /// <param name="pf">Pixel format of output WriteableBitmap</param>
        /// <returns>WriteableBitmap</returns>
#endif
        public static WriteableBitmap ToWriteableBitmap(this IplImage src, PixelFormat pf)
        {
            return ToWriteableBitmap(src, 96, 96, pf, null);
        }
#if LANG_JP
        /// <summary>
	    /// IplImageをWriteableBitmapに変換する (dpi=96, BitmapPalette=null)
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <returns>WPFのWriteableBitmap</returns>
#else
        /// <summary>
        /// Converts IplImage to WriteableBitmap (dpi=96, BitmapPalette=null)
        /// </summary>
        /// <param name="src">Input IplImage</param>
        /// <returns>WriteableBitmap</returns>
#endif
        public static WriteableBitmap ToWriteableBitmap(this IplImage src)
        {
            PixelFormat pf = GetOptimumPixelFormats(src.Depth, src.NChannels);
            return ToWriteableBitmap(src, 96, 96, pf, null);
        }

#if LANG_JP
        /// <summary>
        /// IplImageをWriteableBitmapに変換する.
        /// 返却値を新たに生成せず引数で指定したWriteableBitmapに格納するので、メモリ効率が良い。
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="dst">変換結果を設定するWriteableBitmap</param>
#else
        /// <summary>
        /// Converts IplImage to WriteableBitmap.
        /// This method is more efficient because new instance of WriteableBitmap is not allocated.
        /// </summary>
        /// <param name="src">Input IplImage</param>
        /// <param name="dst">Output WriteableBitmap</param>
#endif
        public static void ToWriteableBitmap(IplImage src, WriteableBitmap dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.Width != dst.PixelWidth || src.Height != dst.PixelHeight)
                throw new ArgumentException("size of src must be equal to size of dst");
            //if (src.Depth != BitDepth.U8)
                //throw new ArgumentException("bit depth of src must be BitDepth.U8", "src");

            int w = src.Width;
            int h = src.Height;
            int bpp = dst.Format.BitsPerPixel;

            int channels = GetOptimumChannels(dst.Format);   
            if (src.NChannels != channels)
            {
                throw new ArgumentException("PixelFormat of dst is invalid", "dst");
            }

            // 左下原点の場合は上下反転する
            IplImage ipl = null;
            if (src.Origin == ImageOrigin.TopLeft)
            {
                ipl = src;
            }
            else
            {
                ipl = src.Clone();
                Cv.Flip(src, ipl, FlipMode.X);
            }

            if (bpp == 1)
            {
                unsafe
                {
                    // 手作業で移し替える
                    int stride = w / 8 + 1;
                    if (stride < 2)
                    {
                        stride = 2;
                    }
                    byte[] pixels = new byte[h * stride];
                    byte* p = (byte*)(ipl.ImageData.ToPointer());
                    int x = 0;
                    int y;
                    int byte_pos;
                    int offset;
                    byte b;
                    int i;
                    int widthStep = src.WidthStep;
                    for (y = 0; y < h; y++)
                    {
                        offset = y * stride;
                        for (byte_pos = 0; byte_pos < stride; byte_pos++)
                        {
                            if (x < w)
                            {
                                b = 0;
                                // 現在の位置から横8ピクセル分、ビットがそれぞれ立っているか調べ、1つのbyteにまとめる
                                for (i = 0; i < 8; i++)
                                {
                                    b <<= 1;
                                    if (x < w && p[widthStep * y + x] != 0)
                                    {
                                        b |= 1;
                                    }
                                    x++;
                                }
                                pixels[offset + byte_pos] = b;
                            }
                        }
                        x = 0;
                    }
                    dst.WritePixels(new Int32Rect(0, 0, w, h), pixels, stride, 0);
                }

                /*} else if(bpp == 8){
                    int stride = w;
                    array<Byte>^ pixels = gcnew array<Byte>(h * stride);
                    byte* p = (byte*)(void*)src->ImageData;
                    for (int y=0; y<h; y++) {
                        for(int x=0; x<w; x++){
                            pixels[y * stride + x] = p[src->WidthStep * y + x];
                        }
                    }
                    dst->WritePixels(Int32Rect(0, 0, w, h), pixels, stride, 0);
                */
            }
            else
            {
                dst.WritePixels(new Int32Rect(0, 0, w, h), ipl.ImageData, ipl.ImageSize, ipl.WidthStep);
            }

            if (src.Origin == ImageOrigin.BottomLeft)
            {
                ipl.Dispose();
            }
        }
        #endregion
    }
}
