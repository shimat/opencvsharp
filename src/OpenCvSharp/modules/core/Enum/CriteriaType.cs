using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 終了条件の種類
	/// </summary>
#else
    /// <summary>
    /// Type of termination criteria 
    /// </summary>
#endif
    [Flags]
    public enum CriteriaType : int
    {
#if LANG_JP
    /// <summary>
    /// 繰り返し回数による条件
    /// </summary>
#else
        /// <summary>
        /// the maximum number of iterations or elements to compute
        /// </summary>
#endif
        Count = 1,


#if LANG_JP
    /// <summary>
    /// 繰り返し回数による条件
    /// </summary>
#else
        /// <summary>
        /// the maximum number of iterations or elements to compute
        /// </summary>
#endif
        MaxIter = Count,


#if LANG_JP
    /// <summary>
    /// 目標精度(ε)による条件
    /// </summary>
#else
        /// <summary>
        /// the desired accuracy or change in parameters at which the iterative algorithm stops
        /// </summary>
#endif
        Eps = 2,
    }
}