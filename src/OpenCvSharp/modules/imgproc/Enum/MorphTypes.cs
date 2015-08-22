using System;

namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// モルフォロジー演算の種類
	/// </summary>
#else
    /// <summary>
    /// Type of morphological operation
    /// </summary>
#endif
    [Flags]
    public enum MorphTypes : int
    {
        /// <summary>
        /// 
        /// </summary>
        ERODE = 0,

        /// <summary>
        /// 
        /// </summary>
        DILATE = 1, 

#if LANG_JP
		/// <summary>
		/// オープニング [CV_MOP_OPEN].
		/// dst=open(src,element)=dilate(erode(src,element),element)
		/// </summary>
#else
        /// <summary>
        /// Opening 
        /// </summary>
#endif
        Open = 2,


#if LANG_JP
		/// <summary>
		/// クロージング [CV_MOP_CLOSE].
		/// dst=close(src,element)=erode(dilate(src,element),element)
		/// </summary>
#else
        /// <summary>
        /// Closing
        /// </summary>
#endif
        Close = 3,


#if LANG_JP
		/// <summary>
		/// モルフォロジー勾配（エッジ検出） [CV_MOP_GRADIENT].
		/// dst=morph_grad(src,element)=dilate(src,element)-erode(src,element)
		/// </summary>
#else
        /// <summary>
        /// Morphological gradient
        /// </summary>
#endif
        Gradient = 4,


#if LANG_JP
		/// <summary>
		/// トップハット変換(top hat) [CV_MOP_TOPHAT].
		/// dst=tophat(src,element)=src-open(src,element)
		/// </summary>
#else
        /// <summary>
        /// "Top hat"
        /// </summary>
#endif
        TopHat = 5,


#if LANG_JP
		/// <summary>
		/// ブラックハット変換(black hat) [CV_MOP_BLACKHAT]
		/// dst=blackhat(src,element)=close(src,element)-src
		/// </summary>
#else
        /// <summary>
        /// "Black hat"
        /// </summary>
#endif
        BlackHat = 6,
    }
}
