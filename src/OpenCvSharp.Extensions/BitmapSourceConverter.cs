using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

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
        /// IplImageをWriteableBitmapに変換する. 引数はWriteableBitmapのコンストラクタに相当する.
        /// </summary>
        /// <param name="src">変換するIplImage</param>
        /// <returns>WPFのWriteableBitmap</returns>
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
            
            using (System.Drawing.Bitmap bitmap = BitmapConverter.ToBitmap(src))
            {
                IntPtr hBitmap = bitmap.GetHbitmap();

                BitmapSource bs = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                );

                DeleteObject(hBitmap);
                return bs;
            }
        }
        #endregion
    }
}
