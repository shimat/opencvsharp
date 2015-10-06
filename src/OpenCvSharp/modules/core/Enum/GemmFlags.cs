using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
	/// cv::GEMMメソッドの操作フラグ
	/// </summary>
#else
    /// <summary>
    /// The operation flags for cv::GEMM
    /// </summary>
#endif
    [Flags]
    public enum GemmFlags : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

#if LANG_JP
		/// <summary>
		/// src1を転置 
		/// </summary>
#else
        /// <summary>
        /// Transpose src1
        /// </summary>
#endif

        A_T = 1,


#if LANG_JP
		/// <summary>
		/// src2を転置 
		/// </summary>
#else
        /// <summary>
        /// Transpose src2
        /// </summary>
#endif
        B_T = 2,


#if LANG_JP
		/// <summary>
		/// src3を転置 
		/// </summary>
#else
        /// <summary>
        /// Transpose src3
        /// </summary>
#endif
        C_T = 4,
    }
}
