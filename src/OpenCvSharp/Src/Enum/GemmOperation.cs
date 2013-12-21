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
	/// cvGEMMメソッドの操作フラグ
	/// </summary>
#else
    /// <summary>
    /// The operation flags for cvGEMM
    /// </summary>
#endif
    [Flags]
    public enum GemmOperation : int
    {
#if LANG_JP
        /// <summary>
        /// = 0
        /// </summary>
#else
        /// <summary>
        /// = 0
        /// </summary>
#endif
        Zero = 0,


#if LANG_JP
		/// <summary>
		/// src1を転置 
        /// [CV_GEMM_A_T]
		/// </summary>
#else
        /// <summary>
        /// Transpose src1
        /// [CV_GEMM_A_T]
        /// </summary>
#endif
        A_T = CvConst.CV_GEMM_A_T,


#if LANG_JP
		/// <summary>
		/// src2を転置 
        /// [CV_GEMM_B_T]
		/// </summary>
#else
        /// <summary>
        /// Transpose src2
        /// [CV_GEMM_B_T]
        /// </summary>
#endif
        B_T = CvConst.CV_GEMM_B_T,


#if LANG_JP
		/// <summary>
		/// src3を転置 
        /// [CV_GEMM_C_T]
		/// </summary>
#else
        /// <summary>
        /// Transpose src3
        /// [CV_GEMM_C_T]
        /// </summary>
#endif
        C_T = CvConst.CV_GEMM_C_T,
    }
}
