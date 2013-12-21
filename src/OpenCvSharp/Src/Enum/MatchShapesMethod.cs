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
    /// cvMatchShapesで用いる比較手法
    /// </summary>
#else
    /// <summary>
    /// Comparison methods for cvMatchShapes
    /// </summary>
#endif
    public enum MatchShapesMethod : int
    {
        /// <summary>
        /// [CV_CONTOURS_MATCH_I1]
        /// </summary>
        I1 = CvConst.CV_CONTOURS_MATCH_I1,
        /// <summary>
        /// [CV_CONTOURS_MATCH_I2]
        /// </summary>
        I2 = CvConst.CV_CONTOURS_MATCH_I2,
        /// <summary>
        /// [CV_CONTOURS_MATCH_I3]
        /// </summary>
        I3 = CvConst.CV_CONTOURS_MATCH_I3,
    }
}
