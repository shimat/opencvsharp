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
	/// cvKMeans2の処理フラグ
	/// </summary>
#else
    /// <summary>
    /// Miscellaneous flags for cvKMeans2
    /// </summary>
#endif
    [Flags]
    public enum KMeansFlag : int
    {
#if LANG_JP
		/// <summary>
		/// 
        /// [= 0]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [= 0]
        /// </summary>
#endif
        Zero = 0,

#if LANG_JP
		/// <summary>
		/// 
        /// [CV_KMEANS_USE_INITIAL_LABELS]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_KMEANS_USE_INITIAL_LABELS]
        /// </summary>
#endif
        UseInitialLabels = CvConst.CV_KMEANS_USE_INITIAL_LABELS,
    }
}
