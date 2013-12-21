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
    /// cvCartToPolarで用いる、角度を表すためにラジアン，または度のどちらを用いるかを示すフラグ． 
    /// </summary>
#else
    /// <summary>
    /// Angle Unit for cvCartToPolar
    /// </summary>
#endif
    public enum AngleUnit : int
    {
#if LANG_JP
        /// <summary>
        /// ラジアン単位の角度
        /// </summary>
#else
        /// <summary>
        /// Angle in radians
        /// </summary>
#endif
        Radians = 0,


#if LANG_JP
        /// <summary>
        /// 度数単位の角度
        /// </summary>
#else
        /// <summary>
        /// Angle in degrees
        /// </summary>
#endif
        Degrees = 1,
    }
}
