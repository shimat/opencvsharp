
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// cvCopyMakeBorderで指定する, 境界線のタイプ
	/// </summary>
#else
    /// <summary>
    /// Type of the border to create around the copied source image rectangle
    /// </summary>
#endif
    public enum BorderType 
    {
#if LANG_JP
		/// <summary>
		/// 境界はこの関数の最後のパラメータとして渡された定数 value で埋められる. 
        /// [IPL_BORDER_CONSTANT]
		/// </summary>
#else
        /// <summary>
        /// Border is filled with the fixed value, passed as last parameter of the function.
        /// [IPL_BORDER_CONSTANT]
        /// </summary>
#endif
        Constant = CvConst.IPL_BORDER_CONSTANT,

#if LANG_JP
		/// <summary>
		/// 画像の最も上/下の行と最も左/右の列（画像領域の一番外側の値）を用いて境界線を生成する．
        /// [IPL_BORDER_REPLICATE]
		/// </summary>
#else
        /// <summary>
        /// The pixels from the top and bottom rows, the left-most and right-most columns are replicated to fill the border.
        /// [IPL_BORDER_REPLICATE]
        /// </summary>
#endif
        Replicate = CvConst.IPL_BORDER_REPLICATE,

        /// <summary>
        /// [IPL_BORDER_REFLECT]
        /// </summary>
        Reflect = CvConst.IPL_BORDER_REFLECT,

        /// <summary>
        /// [IPL_BORDER_REFLECT_101]
        /// </summary>
        Reflect101 = CvConst.IPL_BORDER_REFLECT_101,

        /// <summary>
        /// [IPL_BORDER_WRAP]
        /// </summary>
        Wrap = CvConst.IPL_BORDER_WRAP,

        /// <summary>
        /// [BORDER_DEFAULT]
        /// </summary>
        Default = CvConst.IPL_BORDER_DEFAULT,

        /// <summary>
        /// [cv::BORDER_ISOLATED]
        /// </summary>
        Isolated = CvConst.BORDER_ISOLATED,

        /// <summary>
        /// -1
        /// </summary>
        Auto = -1,
    }
}
