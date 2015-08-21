
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
    public enum BorderTypes : int
    {
#if LANG_JP
		/// <summary>
		/// 境界はこの関数の最後のパラメータとして渡された定数 value で埋められる. 
		/// `iiiiii|abcdefgh|iiiiiii`  with some specified `i`
		/// </summary>
#else
        /// <summary>
        /// Border is filled with the fixed value, passed as last parameter of the function.
        /// `iiiiii|abcdefgh|iiiiiii`  with some specified `i`
        /// </summary>
#endif
        Constant = 0,

#if LANG_JP
		/// <summary>
		/// 画像の最も上/下の行と最も左/右の列（画像領域の一番外側の値）を用いて境界線を生成する．
        /// `aaaaaa|abcdefgh|hhhhhhh`
		/// </summary>
#else
        /// <summary>
        /// The pixels from the top and bottom rows, the left-most and right-most columns are replicated to fill the border.
        /// `aaaaaa|abcdefgh|hhhhhhh`
        /// </summary>
#endif
        Replicate = 1,

        /// <summary>
        /// `fedcba|abcdefgh|hgfedcb`
        /// </summary>
        Reflect = 2,

        /// <summary>
        /// `cdefgh|abcdefgh|abcdefg`
        /// </summary>
        Wrap = 3,

        /// <summary>
        /// `gfedcb|abcdefgh|gfedcba`
        /// </summary>
        Reflect101 = 4,

        /// <summary>
        /// `uvwxyz|absdefgh|ijklmno`
        /// </summary>
        Transparent = 5, 
        
        /// <summary>
        /// same as BORDER_REFLECT_101
        /// </summary>
        Default = Reflect101,

        /// <summary>
        /// do not look outside of ROI
        /// </summary>
        Isolated = 16,
    }
}
