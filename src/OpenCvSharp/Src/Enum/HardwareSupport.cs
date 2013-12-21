/*
* (C) 2008-2013 Schima
* This code is licenced under the LGPL.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{

#if LANG_JP
    /// <summary>
	/// 
	/// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    public enum HardwareSupport : int
    {
        /// <summary>
        /// 
        /// [CV_CPU_NONE]
        /// </summary>
        None = CvConst.CV_CPU_NONE,
        /// <summary>
        /// 
        /// [CV_CPU_MMX]
        /// </summary>
        MMX = CvConst.CV_CPU_MMX,
        /// <summary>
        /// 
        /// [CV_CPU_SSE]
        /// </summary>
        SSE = CvConst.CV_CPU_SSE,
        /// <summary>
        /// 
        /// [CV_CPU_SSE2]
        /// </summary>
        SSE2 = CvConst.CV_CPU_SSE2,
        /// <summary>
        /// 
        /// [CV_CPU_SSE3]
        /// </summary>
        SSE3 = CvConst.CV_CPU_SSE3,
        /// <summary>
        /// 
        /// [CV_CPU_SSSE3]
        /// </summary>
        SSSE3 = CvConst.CV_CPU_SSSE3,
        /// <summary>
        /// 
        /// [CV_CPU_SSE4_1]
        /// </summary>
        SSE4_1 = CvConst.CV_CPU_SSE4_1,
        /// <summary>
        /// 
        /// [CV_CPU_SSE4_2]
        /// </summary>
        SSE4_2 = CvConst.CV_CPU_SSE4_2,
        /// <summary>
        /// 
        /// [CV_CPU_POPCNT]
        /// </summary>
        POPCNT = CvConst.CV_CPU_POPCNT,
        /// <summary>
        /// 
        /// [CV_CPU_AVX]
        /// </summary>
        AVX = CvConst.CV_CPU_AVX,
        /// <summary>
        /// 
        /// [CV_HARDWARE_MAX_FEATURE]
        /// </summary>
        MaxFeature = CvConst.CV_HARDWARE_MAX_FEATURE,
    }
}


