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
    public enum DistTransformLabelType : int
    {
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_DIST_LABEL_CCOMP]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_DIST_LABEL_CCOMP]
        /// </summary>
#endif
        CComp = CvConst.CV_DIST_LABEL_CCOMP,


#if LANG_JP
		/// <summary>
		/// 
        /// [CV_DIST_LABEL_PIXEL]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_DIST_LABEL_PIXEL]
        /// </summary>
#endif
        Pixel = CvConst.CV_DIST_LABEL_PIXEL,
    }
}
