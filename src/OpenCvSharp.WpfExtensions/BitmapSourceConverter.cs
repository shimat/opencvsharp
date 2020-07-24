#if WINDOWS && (NET461 || NET48 || NETCOREAPP3_1)
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using PixelFormat = System.Windows.Media.PixelFormat;

namespace OpenCvSharp.WpfExtensions
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
#if LANG_JP
        /// <summary>
        /// MatをBitmapSourceに変換する. 
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <returns>WPFのBitmapSource</returns>
#else
        /// <summary>
        /// Converts Mat to BitmapSource.
        /// </summary>
        /// <param name="src">Input IplImage</param>
        /// <returns>BitmapSource</returns>
#endif
        public static BitmapSource ToBitmapSource(
            this Mat src)
        {
            return src.ToWriteableBitmap();
        }

#if LANG_JP
        /// <summary>
        /// MatをBitmapSourceに変換する. 
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <param name="horizontalResolution"></param>
        /// <param name="verticalResolution"></param>
        /// <param name="pixelFormat"></param>
        /// <param name="palette"></param>
        /// <returns>WPFのBitmapSource</returns>
#else
        /// <summary>
        /// Converts Mat to BitmapSource.
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
            return src.ToWriteableBitmap(horizontalResolution, verticalResolution, pixelFormat, palette);
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
        /// <remarks>http://www.codeproject.com/Articles/104929/Bitmap-to-BitmapSource</remarks>
        /// <returns>BitmapSource</returns>
#endif
        public static BitmapSource ToBitmapSource(this Bitmap src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

            if (Application.Current?.Dispatcher == null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    src.Save(memoryStream, ImageFormat.Png);
                    return CreateBitmapSourceFromBitmap(memoryStream);
                }
            }

            using (var memoryStream = new MemoryStream())
            {
                // You need to specify the image format to fill the stream. 
                // I'm assuming it is PNG
                src.Save(memoryStream, ImageFormat.Png);
                memoryStream.Seek(0, SeekOrigin.Begin);

                // Make sure to create the bitmap in the UI thread
                if (IsInvokeRequired())
                    return (BitmapSource) Application.Current.Dispatcher.Invoke(
                        new Func<Stream, BitmapSource>(CreateBitmapSourceFromBitmap),
                        DispatcherPriority.Normal,
                        memoryStream);

                return CreateBitmapSourceFromBitmap(memoryStream);
            }
        }

        // http://www.codeproject.com/Articles/104929/Bitmap-to-BitmapSource
        private static bool IsInvokeRequired()
        {
            return Dispatcher.CurrentDispatcher != Application.Current.Dispatcher;
        }

        // http://www.codeproject.com/Articles/104929/Bitmap-to-BitmapSource
        private static BitmapSource CreateBitmapSourceFromBitmap(Stream stream)
        {
            var bitmapDecoder = BitmapDecoder.Create(
                stream,
                BitmapCreateOptions.PreservePixelFormat,
                BitmapCacheOption.OnLoad);

            // This will disconnect the stream from the image completely...
            var writable = new WriteableBitmap(bitmapDecoder.Frames.Single());
            writable.Freeze();

            return writable;
        }

        #region ToMat
#if LANG_JP
        /// <summary>
        /// BitmapSourceをMatに変換する
        /// </summary>
        /// <param name="src">変換するBitmapSource</param>
        /// <returns>OpenCvSharpで扱えるMat</returns>
#else
        /// <summary>
        /// Converts BitmapSource to Mat
        /// </summary>
        /// <param name="src">Input BitmapSource</param>
        /// <returns>IplImage</returns>
#endif
        public static Mat ToMat(this BitmapSource src)
        {
            if (src == null)
            {
                throw new ArgumentNullException(nameof(src));
            }

            int w = src.PixelWidth;
            int h = src.PixelHeight;
            MatType type = WriteableBitmapConverter.GetOptimumType(src.Format);
            Mat dst = new Mat(h, w, type);
            ToMat(src, dst);
            return dst;
        }
#if LANG_JP
        /// <summary>
        /// BitmapSourceをMatに変換する.
        /// </summary>
        /// <param name="src">変換するBitmapSource</param>
        /// <param name="dst">出力先のMat</param>
#else
        /// <summary>
        /// Converts BitmapSource to Mat
        /// </summary>
        /// <param name="src">Input BitmapSource</param>
        /// <param name="dst">Output Mat</param>
#endif
        public static void ToMat(this BitmapSource src, Mat dst)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (dst == null)
                throw new ArgumentNullException(nameof(dst));
            if (src.PixelWidth != dst.Width || src.PixelHeight != dst.Height)
                throw new ArgumentException("size of src must be equal to size of dst");
            if (dst.Dims > 2)
                throw new ArgumentException("Mat dimensions must be 2");

            int w = src.PixelWidth;
            int h = src.PixelHeight;
            int bpp = src.Format.BitsPerPixel;
            int channels = WriteableBitmapConverter.GetOptimumChannels(src.Format);
            if (dst.Channels() != channels)
            {
                throw new ArgumentException("nChannels of dst is invalid", nameof(dst));
            }

            bool submat = dst.IsSubmatrix();
            bool continuous = dst.IsContinuous();

            unsafe
            {
                byte* p = (byte*)(dst.Data);
                long step = dst.Step();

                // 1bppは手作業でコピー
                if (bpp == 1)
                {
                    if (submat)
                        throw new NotImplementedException("submatrix not supported");

                    // BitmapImageのデータを配列にコピー
                    // 要素1つに横8ピクセル分のデータが入っている。   
                    int stride = (w / 8) + 1;
                    byte[] pixels = new byte[h * stride];
                    src.CopyPixels(pixels, stride, 0);
                    int x = 0;
                    for (int y = 0; y < h; y++)
                    {
                        int offset = y * stride;
                        // この行の各バイトを調べていく
                        for (int bytePos = 0; bytePos < stride; bytePos++)
                        {
                            if (x < w)
                            {
                                // 現在の位置のバイトからそれぞれのビット8つを取り出す
                                byte b = pixels[offset + bytePos];
                                for (int i = 0; i < 8; i++)
                                {
                                    if (x >= w)
                                    {
                                        break;
                                    }
                                    p[step * y + x] = ((b & 0x80) == 0x80) ? (byte)255 : (byte)0;
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
                /*else if (bpp == 8)
                {
                    int stride = w;
                    byte[] pixels = new byte[h * stride];
                    src.CopyPixels(pixels, stride, 0);
                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            p[step * y + x] = pixels[y * stride + x];
                        }
                    }
                }*/
                // 24bpp, 32bpp, ...
                else
                {
                    int stride = w * ((bpp + 7) / 8);
                    if (!submat && continuous)
                    {
                        long imageSize = dst.DataEnd.ToInt64() - dst.Data.ToInt64();
                        if (imageSize < 0)
                            throw new OpenCvSharpException("The mat has invalid data pointer");
                        if (imageSize > int.MaxValue)
                            throw new OpenCvSharpException("Too big mat data");
                        src.CopyPixels(Int32Rect.Empty, dst.Data, (int)imageSize, stride);
                    }
                    else
                    {
                        // 高さ1pxの矩形ごと(≒1行ごと)にコピー
                        var roi = new Int32Rect { X = 0, Y = 0, Width = w, Height = 1 };
                        IntPtr dstData = dst.Data;
                        for (int y = 0; y < h; y++)
                        {
                            roi.Y = y;
                            src.CopyPixels(roi, dstData, stride, stride);
                            dstData = new IntPtr(dstData.ToInt64() + stride);
                        }
                    }
                }

            }
        }

#if LANG_JP
        /// <summary>
        /// System.Windows.Media.Imaging.BitmapSource から Mat へピクセルデータをコピーする
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="wb"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Copies pixel data from System.Windows.Media.Imaging.BitmapSource to IplImage instance
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="wb"></param>
        /// <returns></returns>
#endif
        public static void CopyFrom(this Mat mat, BitmapSource wb)
        {
            if (wb == null)
                throw new ArgumentNullException(nameof(wb));

            ToMat(wb, mat);
        }

        #endregion
    }
}
#endif
