using System;
using System.Collections.Generic;
using System.Drawing;
using OpenCvSharp;

namespace OpenCvSharp.Extensions
{
    /// <summary>
    /// static class which provides functions for System.Drawing.Bitmap
    /// </summary>
    public static class BitmapExtension
    {
#if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapからOpenCVのIplImageへ変換して返す.
        /// </summary>
        /// <param name="src">変換するSystem.Drawing.Bitmap</param>
        /// <returns>OpenCvSharpで扱えるIplImage</returns>
#else
        /// <summary>
        /// Converts System.Drawing.Bitmap to IplImage
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap</param>
        /// <returns>IplImage</returns>
#endif
        public static IplImage ToIplImage(this Bitmap src)
        {
            return BitmapConverter.ToIplImage(src);
        }

        #if LANG_JP
        /// <summary>
        /// System.Drawing.BitmapからOpenCVのIplImageへ変換して返す.
        /// </summary>
        /// <param name="src">変換するSystem.Drawing.Bitmap</param>
        /// <param name="dst">IplImage</param>
#else
        /// <summary>
        /// Converts System.Drawing.Bitmap to IplImage
        /// </summary>
        /// <param name="src">System.Drawing.Bitmap</param>
        /// <param name="dst">IplImage</param>
#endif
        public static void ToIplImage(this Bitmap src, IplImage dst)
        {
            BitmapConverter.ToIplImage(src, dst);
        }
    }
}
