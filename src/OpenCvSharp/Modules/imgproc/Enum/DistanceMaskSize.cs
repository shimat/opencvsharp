using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 距離変換 (distance transform) のマスクサイズ
    /// </summary>
#else
    /// <summary>
    /// Mask size for distance transform
    /// </summary>
#endif
    [Flags]
    public enum DistanceMaskSize : int
    {
        /// <summary>
        /// 3
        /// </summary>
        Mask3 = 3,

        /// <summary>
        /// 5
        /// </summary>
        Mask5 = 5,

        /// <summary>
        /// 
        /// </summary>
        Precise = 0,
    }
}
