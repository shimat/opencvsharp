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
        public static BitmapSource ToBitmapSource(this IplImage src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            
            using (Bitmap bitmap = BitmapConverter.ToBitmap(src))
            {
                return ToBitmapSource(bitmap);
            }
        }

#if LANG_JP
        /// <summary>
        /// MatをBitmapSourceに変換する. 
        /// </summary>
        /// <param name="src">変換するMat</param>
        /// <returns>WPFのBitmapSource</returns>
#else
        /// <summary>
        /// Converts Mat to BitmapSource.
        /// </summary>
        /// <param name="src">Input Mat</param>
        /// <returns>BitmapSource</returns>
#endif
        public static BitmapSource ToBitmapSource(this Mat src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }

            using (Bitmap bitmap = BitmapConverter.ToBitmap(src))
            {
                return ToBitmapSource(bitmap);
            }
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
            {
                throw new ArgumentNullException("src");
            }

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
        #endregion
    }
}
