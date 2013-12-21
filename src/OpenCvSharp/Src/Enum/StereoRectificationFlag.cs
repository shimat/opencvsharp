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
	/// 輪郭の近似手法
	/// </summary>
#else
    /// <summary>
    /// The operation flags for cvStereoRectify
    /// </summary>
#endif
    public enum StereoRectificationFlag : int
    {
#if LANG_JP
		/// <summary>
        /// フラグなし (=0).
        /// 利用できる画像領域が最大になるように（エピポーラ線の傾きに従って）片方の画像を水平・垂直方向に移動する.
		/// </summary>
#else
        /// <summary>
        /// Default value (=0).
        /// the function can shift one of the image in horizontal or vertical direction (depending on the orientation of epipolar lines) in order to maximise the useful image area. 
        /// </summary>
#endif
        Zero = 0,


#if LANG_JP
		/// <summary>
        /// 平行化後のビューにおいて各カメラの主点（光学中心）が同じ座標になるようにする． 
        /// [CV_CALIB_ZERO_DISPARITY]
		/// </summary>
#else
        /// <summary>
        /// the function makes the principal points of each camera have the same pixel coordinates in the rectified views. 
        /// [CV_CALIB_ZERO_DISPARITY]
        /// </summary>
#endif
        ZeroDisparity = CvConst.CV_CALIB_ZERO_DISPARITY,
    };
}