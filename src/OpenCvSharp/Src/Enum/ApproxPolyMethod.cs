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
	/// ポリラインの近似方法
	/// </summary>
#else
    /// <summary>
    /// Approximation method
    /// </summary>
#endif
    public enum ApproxPolyMethod : int
    {
#if LANG_JP
		/// <summary>
        /// Douglas-Peuckerアルゴリズム
		/// [CV_POLY_APPROX_DP]
		/// </summary>
#else
        /// <summary>
        /// Corresponds to Douglas-Peucker algorithm. 
        /// [CV_POLY_APPROX_DP]
        /// </summary>
#endif
        DP = CvConst.CV_POLY_APPROX_DP,
    }
}
