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
    /// CV_FACE_ELEMENTS
	/// </summary>
#else
    /// <summary>
    /// CV_FACE_ELEMENTS
    /// </summary>
#endif
    public enum CvFaceElements : int
    {
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_FACE_MOUTH]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_FACE_MOUTH]
        /// </summary>
#endif
        Mouth = CvConst.CV_FACE_MOUTH,


#if LANG_JP
		/// <summary>
		/// 
        /// [CV_FACE_LEFT_EYE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_FACE_LEFT_EYE]
        /// </summary>
#endif
        LeftEye = CvConst.CV_FACE_LEFT_EYE,


#if LANG_JP
		/// <summary>
		/// 
        /// [CV_FACE_RIGHT_EYE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_FACE_RIGHT_EYE]
        /// </summary>
#endif
        RightEye = CvConst.CV_FACE_RIGHT_EYE,
    }
}
