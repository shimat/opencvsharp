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
        /// この関数を、SIFT/SURF等のnonfreeの機能を使用する前に呼び出してください
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// You need to call this method before using SIFT/SURF functions.
        /// </summary>
        /// <returns></returns>
#endif
        public static bool InitModule_NonFree()
        {
            return NativeMethods.nonfree_initModule_nonfree() != 0;
        }
    }
}
