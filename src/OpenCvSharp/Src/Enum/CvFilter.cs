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
	/// 畳み込みに使うフィルタ
	/// </summary>
#else
    /// <summary>
    /// Filters used in pyramid decomposition
    /// </summary>
#endif
    public enum CvFilter : int
    {
#if LANG_JP
		/// <summary>
		/// [CV_GAUSSIAN_5x5]
		/// </summary>
#else
        /// <summary>
        /// [CV_GAUSSIAN_5x5]
        /// </summary>
#endif
        Gaussian5x5 = CvConst.CV_GAUSSIAN_5x5,
    }
}
