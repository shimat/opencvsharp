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
	/// 閾値処理の種類
	/// </summary>
#else
    /// <summary>
    /// Thresholding type
    /// </summary>
#endif
    [Flags]
    public enum ThresholdType : int
    {
#if LANG_JP
		/// <summary>
		/// [CV_THRESH_BINARY]
		/// </summary>
#else
        /// <summary>
        /// [CV_THRESH_BINARY]
        /// </summary>
#endif
        Binary = CvConst.CV_THRESH_BINARY,
#if LANG_JP
		/// <summary>
		/// [CV_THRESH_BINARY_INV]
		/// </summary>
#else
        /// <summary>
        /// [CV_THRESH_BINARY_INV]
        /// </summary>
#endif
        BinaryInv = CvConst.CV_THRESH_BINARY_INV,
#if LANG_JP
		/// <summary>
		/// [CV_THRESH_TRUNC]
		/// </summary>
#else
        /// <summary>
        /// [CV_THRESH_TRUNC]
        /// </summary>
#endif
        Truncate = CvConst.CV_THRESH_TRUNC,
#if LANG_JP
		/// <summary>
		/// [CV_THRESH_TOZERO]
		/// </summary>
#else
        /// <summary>
        /// [CV_THRESH_TOZERO]
        /// </summary>
#endif
        ToZero = CvConst.CV_THRESH_TOZERO,
#if LANG_JP
		/// <summary>
		/// [CV_THRESH_TOZERO_INV]
		/// </summary>
#else
        /// <summary>
        /// [CV_THRESH_TOZERO_INV]
        /// </summary>
#endif
        ToZeroInv = CvConst.CV_THRESH_TOZERO_INV,
#if LANG_JP
		/// <summary>
		/// [CV_THRESH_MASK]
		/// </summary>
#else
        /// <summary>
        /// [CV_THRESH_MASK]
        /// </summary>
#endif
        Mask = CvConst.CV_THRESH_MASK,
#if LANG_JP
		/// <summary>
		/// 大津の手法
        /// [CV_THRESH_OTSU]
		/// </summary>
#else
        /// <summary>
        /// Otsu algorithm
        /// [CV_THRESH_OTSU]
        /// </summary>
#endif
        Otsu = CvConst.CV_THRESH_OTSU,
    }
}
