using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
	/// 正規化のタイプ
	/// </summary>
#else
    /// <summary>
    /// Type of norm
    /// </summary>
#endif
    [Flags]
    public enum NormTypes : int
    {
        /// <summary>
        /// 
        /// </summary>

        INF = 1,

#if LANG_JP
        /// <summary>
        /// 配列のL1-norm（絶対値の合計）を正規化 
        /// </summary>
#else
        /// <summary>
        /// The L1-norm (sum of absolute values) of the array is normalized.
        /// </summary>
#endif
        L1 = 2,


#if LANG_JP
        /// <summary>
        /// 配列のL2-norm（ユークリッド距離）を正規化  
        /// </summary>
#else
        /// <summary>
        /// The (Euclidean) L2-norm of the array is normalized.
        /// </summary>
#endif
        L2 = 4,

        /// <summary>
        /// 
        /// </summary>
        L2SQR = 5,

        /// <summary>
        ///
        /// </summary>
        Hamming = 6,

        /// <summary>
        /// 
        /// </summary>
        Hamming2 = 7,

        /// <summary>
        /// 
        /// </summary>
        Relative = 8,

#if LANG_JP
        /// <summary>
        /// 配列の値が指定の範囲に収まるようにスケーリングとシフトを行う 
        /// </summary>
#else
        /// <summary>
        /// The array values are scaled and shifted to the specified range.
        /// </summary>
#endif
        MinMax = 32,
    }
}
