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
    /// cvFindDominantPointsの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// Various operation flags for cvFindDominantPoints
    /// </summary>
#endif
    [Flags]
    public enum DominantsFlag : int
    {
#if LANG_JP
		/// <summary>
		///  
        /// [CV_DOMINANT_IPAN]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_DOMINANT_IPAN]
        /// </summary>
#endif
        IPAN = CvConst.CV_DOMINANT_IPAN,
    }
}
