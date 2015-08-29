
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
    public enum StereoRectificationFlags : int
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
        None = 0,


#if LANG_JP
		/// <summary>
        /// 平行化後のビューにおいて各カメラの主点（光学中心）が同じ座標になるようにする． 
		/// </summary>
#else
        /// <summary>
        /// the function makes the principal points of each camera have the same pixel coordinates in the rectified views. 
        /// </summary>
#endif
        ZeroDisparity = 1024,
    };
}