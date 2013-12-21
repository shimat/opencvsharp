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
    /// 視差を計算するためのアルゴリズム
    /// </summary>
#else
    /// <summary>
    /// Mode of correspondence retrieval
    /// </summary>
#endif
    public enum DisparityMode
    {
        /// <summary>
        /// [CV_DISPARITY_BIRCHFIELD]
        /// </summary>
        Birchfield = CvConst.CV_DISPARITY_BIRCHFIELD,
    }
}
