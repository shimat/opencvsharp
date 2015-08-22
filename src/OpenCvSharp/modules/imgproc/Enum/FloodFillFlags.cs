using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// floodFillの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// floodFill Operation flags. Lower bits contain a connectivity value, 4 (default) or 8, used within the function. Connectivity determines which neighbors of a pixel are considered. Upper bits can be 0 or a combination of the following flags:
    /// </summary>
#endif
    [Flags]
    public enum FloodFillFlags : int
    {
#if LANG_JP
		/// <summary>
		/// 4連結による線分
        /// [= 4]
		/// </summary>
#else
        /// <summary>
        /// 4-connected line.
        /// [= 4]
        /// </summary>
#endif
        Link4 = 4,

#if LANG_JP
		/// <summary>
		/// 8連結による線分
        /// [= 8]
		/// </summary>
#else
        /// <summary>
        /// 8-connected line.
        /// [= 8]
        /// </summary>
#endif
        Link8 = 8,

#if LANG_JP
		/// <summary>
		/// If set, the difference between the current pixel and seed pixel is considered. Otherwise, the difference between neighbor pixels is considered (that is, the range is floating).
        /// [CV_FLOODFILL_FIXED_RANGE]
		/// </summary>
#else
        /// <summary>
        /// If set, the difference between the current pixel and seed pixel is considered. Otherwise, the difference between neighbor pixels is considered (that is, the range is floating).
        /// [CV_FLOODFILL_FIXED_RANGE]
        /// </summary>
#endif
        FixedRange = 1 << 16,


#if LANG_JP
		/// <summary>
		/// If set, the function does not change the image ( newVal is ignored), but fills the mask. The flag can be used for the second variant only.
        /// [CV_FLOODFILL_MASK_ONLY]
		/// </summary>
#else
        /// <summary>
        /// If set, the function does not change the image ( newVal is ignored), but fills the mask. The flag can be used for the second variant only.
        /// [CV_FLOODFILL_MASK_ONLY]
        /// </summary>
#endif
        MaskOnly = 1 << 17,
    }
}
