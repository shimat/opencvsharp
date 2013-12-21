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
	/// テンプレートマッチングの方法
	/// </summary>
#else
    /// <summary>
    /// Specifies the way the template must be compared with image regions
    /// </summary>
#endif
    public enum MatchTemplateMethod : int
    {
        /// <summary>
        /// [CV_TM_SQDIFF]
        /// </summary>
        SqDiff = CvConst.CV_TM_SQDIFF,
        /// <summary>
        /// [CV_TM_SQDIFF_NORMED]
        /// </summary>
        SqDiffNormed = CvConst.CV_TM_SQDIFF_NORMED,
        /// <summary>
        /// [CV_TM_CCORR]
        /// </summary>
        CCorr = CvConst.CV_TM_CCORR,
        /// <summary>
        /// [CV_TM_CCORR_NORMED]
        /// </summary>
        CCorrNormed = CvConst.CV_TM_CCORR_NORMED,
        /// <summary>
        /// [CV_TM_CCOEFF]
        /// </summary>
        CCoeff = CvConst.CV_TM_CCOEFF,
        /// <summary>
        /// [CV_TM_CCOEFF_NORMED]
        /// </summary>
        CCoeffNormed = CvConst.CV_TM_CCOEFF_NORMED,
    }
}
