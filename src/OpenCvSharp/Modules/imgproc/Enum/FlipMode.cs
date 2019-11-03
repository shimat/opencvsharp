
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 配列の反転方法
    /// </summary>
#else
    /// <summary>
    /// Specifies how to flip the array
    /// </summary>
#endif
    public enum FlipMode
    {
#if LANG_JP
        /// <summary>
        /// x軸周りでの反転
        /// </summary>
#else
        /// <summary>
        /// means flipping around x-axis
        /// </summary>
#endif
        X = 0,


#if LANG_JP
        /// <summary>
        /// y軸周りでの反転
        /// </summary>
#else
        /// <summary>
        /// means flipping around y-axis
        /// </summary>
#endif
        Y = 1,


#if LANG_JP
        /// <summary>
        /// 両軸周りでの反転
        /// </summary>
#else
        /// <summary>
        /// means flipping around both axises
        /// </summary>
#endif
        // ReSharper disable once InconsistentNaming
        XY = -1
    }
}
