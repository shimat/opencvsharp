using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
    /// 距離変換 (distance transform) のマスクサイズ
    /// </summary>
#else
    /// <summary>
    /// Mask size for distance transform
    /// </summary>
#endif
    [Flags]
    public enum DistanceMaskSize : int
    {
#if LANG_JP
        /// <summary>
        /// 
        /// [CV_DIST_MASK_3]
        /// </summary>
#else
        /// <summary>
        /// 
        /// [CV_DIST_MASK_3]
        /// </summary>
#endif
        Mask3 = CppConst.CV_DIST_MASK_3,


#if LANG_JP
        /// <summary>
        /// 
        /// [CV_DIST_MASK_5]
        /// </summary>
#else
        /// <summary>
        /// 
        /// [CV_DIST_MASK_5]
        /// </summary>
#endif
        Mask5 = CppConst.CV_DIST_MASK_5,


#if LANG_JP
        /// <summary>
        /// 
        /// [CV_DIST_MASK_PRECISE]
        /// </summary>
#else
        /// <summary>
        /// 
        /// [CV_DIST_MASK_PRECISE]
        /// </summary>
#endif
        Precise = CppConst.CV_DIST_MASK_PRECISE,
    }
}
