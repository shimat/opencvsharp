
namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
	/// cvCmp, cvCmpS等のメソッドで用いる, CvArrの比較方法
    /// </summary>
#else
    /// <summary>
    /// The flag specifying the relation between the elements to be checked
    /// </summary>
#endif
    public enum CmpTypes : int
    {
#if LANG_JP
		/// <summary>
		/// src1(I) と value は等しい 
		/// </summary>
#else
        /// <summary>
        /// src1(I) "equal to" src2(I)
        /// </summary>
#endif
        EQ = 0,


#if LANG_JP
		/// <summary>
		/// src1(I) は value より大きい 
		/// </summary>
#else
        /// <summary>
        /// src1(I) "greater than" src2(I)
        /// </summary>
#endif
        GT = 1,


#if LANG_JP
		/// <summary>
		/// src1(I) は value より大きいか等しい 
		/// </summary>
#else
        /// <summary>
        /// src1(I) "greater or equal" src2(I)
        /// </summary>
#endif
        GE = 2,


#if LANG_JP
		/// <summary>
		/// src1(I) は value より小さい 
		/// </summary>
#else
        /// <summary>
        /// src1(I) "less than" src2(I)
        /// </summary>
#endif
        LT = 3,


#if LANG_JP
		/// <summary>
		/// src1(I) は value より小さいか等しい 
		/// </summary>
#else
        /// <summary>
        /// src1(I) "less or equal" src2(I)
        /// </summary>
#endif
        LE = 4,


#if LANG_JP
		/// <summary>
		/// src1(I) と value は等しくない 
		/// </summary>
#else
        /// <summary>
        /// src1(I) "not equal to" src2(I)
        /// </summary>
#endif
        NE = 5,
    }
}
