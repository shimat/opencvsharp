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
	/// cvCalcOpticalFlowPyrLKの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// Miscellaneous flags for cvCalcOpticalFlowPyrLK
    /// </summary>
#endif
    [Flags]
    public enum LKFlowFlag : int
    {
#if LANG_JP
		/// <summary>
		/// 1番目のフレームに対するピラミッドが事前に計算される
        /// [CV_LKFLOW_PYR_A_READY]
		/// </summary>
#else
        /// <summary>
        /// Pyramid for the first frame is pre-calculated before the call.
        /// [CV_LKFLOW_PYR_A_READY]
        /// </summary>
#endif
        PyrAReady = CvConst.CV_LKFLOW_PYR_A_READY,


#if LANG_JP
		/// <summary>
		/// 2番目のフレームに対するピラミッドが事前に計算される
        /// [CV_LKFLOW_PYR_B_READY]
		/// </summary>
#else
        /// <summary>
        /// Pyramid for the second frame is pre-calculated before the call.
        /// [CV_LKFLOW_PYR_B_READY]
        /// </summary>
#endif
        PyrBReady = CvConst.CV_LKFLOW_PYR_B_READY,


#if LANG_JP
		/// <summary>
		/// この関数呼び出し以前に，配列 curr_featuresは特徴の初期座標を持つ
        /// [CV_LKFLOW_INITIAL_GUESSES]
		/// </summary>
#else
        /// <summary>
        /// Array B contains initial coordinates of features before the function call. 
        /// [CV_LKFLOW_INITIAL_GUESSES]
        /// </summary>
#endif
        InitialGuesses = CvConst.CV_LKFLOW_INITIAL_GUESSES,


#if LANG_JP
		/// <summary>
		/// この関数呼び出し以前に，配列 curr_featuresは特徴の初期座標を持つ
        /// [cv::OPTFLOW_USE_INITIAL_FLOW]
		/// </summary>
#else
        /// <summary>
        /// Array B contains initial coordinates of features before the function call. 
        /// [cv::OPTFLOW_USE_INITIAL_FLOW]
        /// </summary>
#endif
        InitialFlow = CvConst.OPTFLOW_USE_INITIAL_FLOW,


#if LANG_JP
		/// <summary>
		/// 
        /// [CV_LKFLOW_GET_MIN_EIGENVALS]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_LKFLOW_GET_MIN_EIGENVALS]
        /// </summary>
#endif
        GetMinEigenVals = CvConst.CV_LKFLOW_GET_MIN_EIGENVALS,
    }
}
