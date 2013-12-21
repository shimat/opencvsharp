/*
* (C) 2008-2013 Schima
* This code is licenced under the LGPL.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
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
    public enum MorphingMethod : int
    {
#if LANG_JP
		/// <summary>
		/// 
        /// [CvAdaptiveSkinDetector::MORPHING_METHOD_NONE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CvAdaptiveSkinDetector::MORPHING_METHOD_NONE]
        /// </summary>
#endif
        None = 0,

#if LANG_JP
        /// <summary>
        /// 
        /// [CvAdaptiveSkinDetector::MORPHING_METHOD_ERODE]
        /// </summary>
#else
        /// <summary>
        /// 
        /// [CvAdaptiveSkinDetector::MORPHING_METHOD_ERODE]
        /// </summary>
#endif
        Erode = 1,

#if LANG_JP
        /// <summary>
        /// 
        /// [CvAdaptiveSkinDetector::MORPHING_METHOD_ERODE_ERODE]
        /// </summary>
#else
        /// <summary>
        /// 
        /// [CvAdaptiveSkinDetector::MORPHING_METHOD_ERODE_ERODE]
        /// </summary>
#endif
        ErodeErode = 2,

#if LANG_JP
        /// <summary>
        /// 
        /// [CvAdaptiveSkinDetector::MORPHING_METHOD_ERODE_DILATE]
        /// </summary>
#else
        /// <summary>
        /// 
        /// [CvAdaptiveSkinDetector::MORPHING_METHOD_ERODE_DILATE]
        /// </summary>
#endif
        ErodeDilate = 3
    }
}


