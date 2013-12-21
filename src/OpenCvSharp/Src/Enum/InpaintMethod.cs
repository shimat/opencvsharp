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
	/// cvInpaintの修復方法
	/// </summary>
#else
    /// <summary>
    /// The inpainting method
    /// </summary>
#endif
    public enum InpaintMethod
    {
#if LANG_JP
		/// <summary>
		/// ナビエ・ストークス(Navier-Stokes)ベースの手法
        /// [CV_INPAINT_NS]
		/// </summary>
#else
        /// <summary>
        /// Navier-Stokes based method.
        /// [CV_INPAINT_NS]
        /// </summary>
#endif
        NS = CvConst.CV_INPAINT_NS,


#if LANG_JP
		/// <summary>
		/// Alexandru Teleaによる手法 
        /// [CV_INPAINT_TELEA]
		/// </summary>
#else
        /// <summary>
        /// The method by Alexandru Telea
        /// [CV_INPAINT_TELEA]
        /// </summary>
#endif
        Telea = CvConst.CV_INPAINT_TELEA,
    }
}
