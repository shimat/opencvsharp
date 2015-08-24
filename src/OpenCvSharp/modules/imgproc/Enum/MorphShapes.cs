
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 構造要素の形状
	/// </summary>
#else
    /// <summary>
    /// Shape of the structuring element
    /// </summary>
#endif
    public enum MorphShapes : int
    {
#if LANG_JP
		/// <summary>
		/// 矩形 
		/// </summary>
#else
        /// <summary>
        /// A rectangular element
        /// </summary>
#endif
        Rect = 0,


#if LANG_JP
		/// <summary>
		/// 十字型 
		/// </summary>
#else
        /// <summary>
        /// A cross-shaped element
        /// </summary>
#endif
        Cross = 1,


#if LANG_JP
		/// <summary>
		/// 楕円 
		/// </summary>
#else
        /// <summary>
        /// An elliptic element
        /// </summary>
#endif
        Ellipse = 2,
    }
}
