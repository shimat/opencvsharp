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
    /// 凸包を構成するデータの並び
    /// </summary>
#else
    /// <summary>
    /// Orientation for Convex Hull function
    /// </summary>
#endif
    public enum ConvexHullOrientation : int
    {
#if LANG_JP
        /// <summary>
        /// 時計回り
        /// [CV_CLOCKWISE]
        /// </summary>
#else
        /// <summary>
        /// Clockwise
        /// [CV_CLOCKWISE]
        /// </summary>
#endif
        Clockwise = CvConst.CV_CLOCKWISE,


#if LANG_JP
        /// <summary>
        /// 反時計回り
        /// [CV_COUNTER_CLOCKWISE]
        /// </summary>
#else
        /// <summary>
        /// Counter clockwise
        /// [CV_COUNTER_CLOCKWISE]
        /// </summary>
#endif
        Counterclockwise = CvConst.CV_COUNTER_CLOCKWISE,
    }
}
