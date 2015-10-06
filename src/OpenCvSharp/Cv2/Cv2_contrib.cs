using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    static partial class Cv2
    {
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
#endif
        public static bool InitModule_Contrib()
        {
            return NativeMethods.contrib_initModule_contrib() != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="colormap"></param>
        public static void ApplyColorMap(InputArray src, OutputArray dst, ColorMapMode colormap)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.contrib_applyColorMap(src.CvPtr, dst.CvPtr, (int)colormap);
            dst.Fix();
        }
    }
}
