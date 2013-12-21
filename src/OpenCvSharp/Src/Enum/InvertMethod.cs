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
	/// 逆行列を求める手法
	/// </summary>
#else
    /// <summary>
    /// Inversion methods
    /// </summary>
#endif
    public enum InvertMethod : int
    {
#if LANG_JP
		/// <summary>
		/// 最適なピボット選択によるガウスの消去法 
        /// [CV_LU]
		/// </summary>
#else
        /// <summary>
        /// Gaussian elimination with optimal pivot element chose
        /// [CV_LU]
        /// </summary>
#endif
        LU = CvConst.CV_LU,

#if LANG_JP
		/// <summary>
		/// 特異値分解 
        /// [CV_SVD]
		/// </summary>
#else
        /// <summary>
        /// Singular value decomposition (SVD) method
        /// [CV_SVD]
        /// </summary>
#endif
        Svd = CvConst.CV_SVD,

#if LANG_JP
		/// <summary>
		/// 
        /// [DECOMP_EIG]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [DECOMP_EIG]
        /// </summary>
#endif
        Eig = CvConst.DECOMP_EIG,

#if LANG_JP
		/// <summary>
		/// 対称正定値行列のための特異値分解
        /// [CV_SVD_SYM]
		/// </summary>
#else
        /// <summary>
        /// SVD method for a symmetric positively-defined matrix
        /// [CV_SVD_SYM]
        /// </summary>
#endif
        SvdSymmetric = CvConst.CV_SVD_SYM,

#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CHOLESKY]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CHOLESKY]
        /// </summary>
#endif
        Cholesky = CvConst.CV_CHOLESKY,

#if LANG_JP
		/// <summary>
		/// 
        /// [CV_QR]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_QR]
        /// </summary>
#endif
        QR = CvConst.CV_QR,

#if LANG_JP
		/// <summary>
		/// 
        /// [CV_NORMAL]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_NORMAL]
        /// </summary>
#endif
        Normal = CvConst.CV_NORMAL,
    }
}
