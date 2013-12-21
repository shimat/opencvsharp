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
	/// cvSVDの操作フラグ
	/// </summary>
#else
    /// <summary>
    /// Operation flags for cvSVD
    /// </summary>
#endif
    [Flags]
    public enum SVDFlag
    {
#if LANG_JP
		/// <summary>
		/// フラグ指定なし 
        /// [0]
		/// </summary>
#else
        /// <summary>
        /// No flags
        /// [0]
        /// </summary>
#endif
        Zero = 0,
#if LANG_JP
		/// <summary>
		/// 計算中に行列Aの変更を行うことができる．このフラグの指定は処理速度を向上させる．
        /// [CV_SVD_MODIFY_A]
		/// </summary>
#else
        /// <summary>
        /// enables modification of matrix src1 during the operation. It speeds up the processing. 
        /// [CV_SVD_MODIFY_A]
        /// </summary>
#endif
        ModifyA = CvConst.CV_SVD_MODIFY_A,
#if LANG_JP
		/// <summary>
		/// Uの転置行列を返すことを意味する．このフラグの指定は処理速度を向上させる．
        /// [CV_SVD_U_T]
		/// </summary>
#else
        /// <summary>
        /// means that the transposed matrix U is returned. Specifying the flag speeds up the processing. 
        /// [CV_SVD_U_T]
        /// </summary>
#endif
        U_T = CvConst.CV_SVD_U_T,
#if LANG_JP
		/// <summary>
		/// Vの転置行列を返すことを意味する．このフラグの指定は処理速度を向上させる．
        /// [CV_SVD_V_T]
		/// </summary>
#else
        /// <summary>
        /// means that the transposed matrix V is returned. Specifying the flag speeds up the processing. 
        /// [CV_SVD_V_T]
        /// </summary>
#endif
        V_T = CvConst.CV_SVD_V_T,
    }
}
