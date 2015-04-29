using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Extensions
{
#if LANG_JP
    /// <summary>
    /// System.Windows.Media.Imaging.WriteableBitmapとOpenCVのIplImageとの間の相互変換メソッドを提供するクラス
    /// </summary>
#else
    /// <summary>
    /// Static class which provides conversion between System.Windows.Media.Imaging.BitmapSource and IplImage
    /// </summary>
#endif
    public static class BitmapSourceConverter
    {
        /// <summary>
        /// Delete a GDI object
        /// </summary>
        /// <param name="hObject">The poniter to the GDI object to be deleted</param>
        /// <returns></returns>
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr hObject);
        
#if LANG_JP
        /// <summary>
        /// IplImageをBitmapSourceに変換する. 
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <returns>WPFのBitmapSource</returns>
#else
        /// <summary>
        /// Converts IplImage to BitmapSource.
        /// </summary>
        /// <param name="src">Input IplImage</param>
        /// <returns>BitmapSource</returns>
#endif
        public static BitmapSource ToBitmapSource(
            this IplImage src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (src.IsDisposed)
                throw new ObjectDisposedException(typeof(IplImage).ToString());

            return ToBitmapSource(
                src,
                96, 
                96, 
                GetOptimumPixelFormats(src.Depth, src.NChannels), 
                null);
        }

#if LANG_JP
        /// <summary>
        /// IplImageをBitmapSourceに変換する. 
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="horizontalResolution"></param>
        /// <param name="verticalResolution"></param>
        /// <param name="pixelFormat"></param>
        /// <param name="palette"></param>
        /// <returns>WPFのBitmapSource</returns>
#else
        /// <summary>
        /// Converts IplImage to BitmapSource.
        /// </summary>
        /// <param name="src">Input IplImage</param>
        /// <param name="horizontalResolution"></param>
        /// <param name="verticalResolution"></param>
        /// <param name="pixelFormat"></param>
        /// <param name="palette"></param>
        /// <returns>BitmapSource</returns>
#endif
        public static BitmapSource ToBitmapSource(
            this IplImage src,
            int horizontalResolution,
            int verticalResolution,
            PixelFormat pixelFormat,
            BitmapPalette palette)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (src.IsDisposed)
                throw new ObjectDisposedException(typeof(IplImage).ToString());

            return BitmapSource.Create(
                src.Width,
                src.Height,
                horizontalResolution,
                verticalResolution,
                pixelFormat,
                palette,
                src.ImageData,
                src.WidthStep * src.Height,
                src.WidthStep);
        }

        #region ToBitmapSource
#if LANG_JP
        /// <summary>
        /// IplImageをBitmapSourceに変換する. 
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <returns>WPFのBitmapSource</returns>
#else
        /// <summary>
        /// Converts IplImage to BitmapSource.
        /// </summary>
        /// <param name="src">Input IplImage</param>
        /// <returns>BitmapSource</returns>
#endif
        public static BitmapSource ToBitmapSource(
            this Mat src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (src.IsDisposed)
                throw new ObjectDisposedException(typeof(Mat).ToString());

            return ToBitmapSource(
                src,
                96,
                96,
                GetOptimumPixelFormats(src.Type()),
                null);
        }

#if LANG_JP
        /// <summary>
        /// IplImageをBitmapSourceに変換する. 
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="horizontalResolution"></param>
        /// <param name="verticalResolution"></param>
        /// <param name="pixelFormat"></param>
        /// <param name="palette"></param>
        /// <returns>WPFのBitmapSource</returns>
#else
        /// <summary>
        /// Converts IplImage to BitmapSource.
        /// </summary>
        /// <param name="src">Input IplImage</param>
        /// <param name="horizontalResolution"></param>
        /// <param name="verticalResolution"></param>
        /// <param name="pixelFormat"></param>
        /// <param name="palette"></param>
        /// <returns>BitmapSource</returns>
#endif
        public static BitmapSource ToBitmapSource(
            this Mat src,
            int horizontalResolution,
            int verticalResolution,
            PixelFormat pixelFormat,
            BitmapPalette palette)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (src.IsDisposed)
                throw new ObjectDisposedException(typeof(Mat).ToString());
            if (src.Dims() != 2)
                throw new ArgumentException("src.Dims() != 2");

            long step = src.Step();
            return BitmapSource.Create(
                src.Width,
                src.Height,
                horizontalResolution,
                verticalResolution,
                pixelFormat,
                palette,
                src.Data,
                (int)(step * src.Rows),
                (int)step);
        }

#if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapをBitmapSourceに変換する. 
        /// </summary>
        /// <param name="src">変換するBitmap</param>
        /// <returns>WPFのBitmapSource</returns>
#else
        /// <summary>
        /// Converts System.Drawing.Bitmap to BitmapSource.
        /// </summary>
        /// <param name="src">Input System.Drawing.Bitmap</param>
        /// <returns>BitmapSource</returns>
#endif
        public static BitmapSource ToBitmapSource(this Bitmap src)
        {
            if (src == null)
                throw new ArgumentNullException("src");

            IntPtr hBitmap = IntPtr.Zero;
            try
            {
                hBitmap = src.GetHbitmap();
                BitmapSource bs = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                return bs;
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    DeleteObject(hBitmap);
                }
            }
        }

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
                            throw new ArgumentOutOfRangeException("c", "Not supported BitDepth and/or NChannels");
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
                            throw new ArgumentOutOfRangeException("c", "Not supported BitDepth and/or NChannels");
                    }
                case BitDepth.S32:
                    switch (c)
                    {
                        case 4:
                            return PixelFormats.Prgba64;
                        default:
                            throw new ArgumentOutOfRangeException("c", "Not supported BitDepth and/or NChannels");
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
                            throw new ArgumentOutOfRangeException("c", "Not supported BitDepth and/or NChannels");
                    }
                case BitDepth.F64:
                default:
                    throw new ArgumentOutOfRangeException("c", "Not supported BitDepth");
            }
        }

        /// <summary>
        /// 指定したIplImageのビット深度・チャンネル数に適合するPixelFormatを返す
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

            throw new ArgumentOutOfRangeException("type", "Not supported MatType");
        }

        #endregion
    }
}
