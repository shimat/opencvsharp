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
	/// cvDistTransformで指定する距離の種類
	/// </summary>
#else
    /// <summary>
    /// Type of distance for cvDistTransform
    /// </summary>
#endif
    public enum DistanceType : int
    {
        /// <summary>
        /// User defined distance  [CV_DIST_USER]
        /// </summary>
        User = CvConst.CV_DIST_USER,
        /// <summary>
        /// distance = |x1-x2| + |y1-y2|  [CV_DIST_L1]
        /// </summary>
        L1 = CvConst.CV_DIST_L1,
        /// <summary>
        /// the simple euclidean distance  [CV_DIST_L2]
        /// </summary>
        L2 = CvConst.CV_DIST_L2,
        /// <summary>
        /// distance = max(|x1-x2|,|y1-y2|)  [CV_DIST_C]
        /// </summary>
        C = CvConst.CV_DIST_C,
        /// <summary>
        /// L1-L2 metric: distance = 2(sqrt(1+x*x/2) - 1))  [CV_DIST_L12]
        /// </summary>
        L12 = CvConst.CV_DIST_L12,
        /// <summary>
        /// distance = c^2(|x|/c-log(1+|x|/c)), c = 1.3998  [CV_DIST_FAIR]
        /// </summary>
        Fair = CvConst.CV_DIST_FAIR,
        /// <summary>
        /// distance = c^2/2(1-exp(-(x/c)^2)), c = 2.9846  [CV_DIST_WELSCH]
        /// </summary>
        Welsch = CvConst.CV_DIST_WELSCH,
        /// <summary>
        /// distance = |x|&lt;c ? x^2/2 : c(|x|-c/2), c=1.345  [CV_DIST_HUBER]
        /// </summary>
        Huber = CvConst.CV_DIST_HUBER,
    }
}
