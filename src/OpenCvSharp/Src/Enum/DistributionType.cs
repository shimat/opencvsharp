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
	/// cvRandArrメソッド等で用いる, 分布のタイプ
	/// </summary>
#else
    /// <summary>
    /// Distribution type for cvRandArr, etc.
    /// </summary>
#endif
    public enum DistributionType : int
    {
#if LANG_JP
		/// <summary>
		/// 一様分布 
        /// [CV_RAND_UNI]
		/// </summary>
#else
        /// <summary>
        /// Uniform distribution
        /// [CV_RAND_UNI]
        /// </summary>
#endif
        Uniform = CvConst.CV_RAND_UNI,


#if LANG_JP
		/// <summary>
		/// 正規分布（ガウス分布） 
        /// [CV_RAND_NORMAL]
		/// </summary>
#else
        /// <summary>
        /// Normal or Gaussian distribution
        /// [CV_RAND_NORMAL]
        /// </summary>
#endif
        Normal = CvConst.CV_RAND_NORMAL,
    }
}
