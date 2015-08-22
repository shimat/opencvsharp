
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// Mat.DrawMarkerで用いるマーカーの形状
	/// </summary>
#else
    /// <summary>
    /// Marker styles for Mat.DrawMarker
    /// </summary>
#endif
    public enum MarkerStyle : int
    {
#if LANG_JP
		/// <summary>
		/// 円（線のみ）
		/// </summary>
#else
        /// <summary>
        /// A circle polyline
        /// </summary>
#endif
        CircleLine,

#if LANG_JP
		/// <summary>
		/// 円（塗りつぶし）
		/// </summary>
#else
        /// <summary>
        /// A filled circle
        /// </summary>
#endif
        CircleFilled,

#if LANG_JP
		/// <summary>
		/// 十字
		/// </summary>
#else
        /// <summary>
        /// A cross
        /// </summary>
#endif
        Cross,

#if LANG_JP
		/// <summary>
		/// バツ
		/// </summary>
#else
        /// <summary>
        /// A tilted cross
        /// </summary>
#endif
        TiltedCross,

#if LANG_JP
		/// <summary>
		/// 円と十字
		/// </summary>
#else
        /// <summary>
        /// A circle and a cross
        /// </summary>
#endif
        CircleAndCross,

#if LANG_JP
		/// <summary>
		/// 円とバツ
		/// </summary>
#else
        /// <summary>
        /// A circle and a tilted cross
        /// </summary>
#endif
        CircleAndTiltedCross,

#if LANG_JP
		/// <summary>
		/// 菱形（線のみ）
		/// </summary>
#else
        /// <summary>
        /// A diamond polyline
        /// </summary>
#endif
        DiamondLine,

#if LANG_JP
		/// <summary>
		/// 菱形（塗りつぶし）
		/// </summary>
#else
        /// <summary>
        /// A filled diamond
        /// </summary>
#endif
        DiamondFilled,

#if LANG_JP
		/// <summary>
		/// 正方形（線のみ）
		/// </summary>
#else
        /// <summary>
        /// A square polyline
        /// </summary>
#endif
        SquareLine,

#if LANG_JP
		/// <summary>
		/// 正方形（塗りつぶし）
		/// </summary>
#else
        /// <summary>
        /// A filledsquare
        /// </summary>
#endif
        SquareFilled,
    }
}
