
namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
	/// 逆行列を求める手法
	/// </summary>
#else
    /// <summary>
    /// Inversion methods
    /// </summary>
#endif
    public enum DecompTypes : int
    {
#if LANG_JP
		/// <summary>
		/// 最適なピボット選択によるガウスの消去法 
        /// [CV_LU]
		/// </summary>
#else
        /// <summary>
        /// Gaussian elimination with the optimal pivot element chosen.
        /// </summary>
#endif

        LU = 0,

#if LANG_JP
		/// <summary>
		/// 特異値分解 
        /// [CV_SVD]
		/// </summary>
#else
        /// <summary>
        /// singular value decomposition (SVD) method; 
        /// the system can be over-defined and/or the matrix src1 can be singular
        /// </summary>
#endif
        SVD = 1,

        /// <summary>
        /// eigenvalue decomposition; the matrix src1 must be symmetrical
        /// </summary>
        Eig = 2,

        /// <summary>
        /// Cholesky \f$LL^T\f$ factorization; the matrix src1 must be symmetrical 
        /// and positively defined
        /// </summary>
        Cholesky = 3,

        /// <summary>
        /// QR factorization; the system can be over-defined and/or the matrix 
        /// src1 can be singular 
        /// </summary>
        QR = 4,

        /// <summary>
        /// while all the previous flags are mutually exclusive, 
        /// this flag can be used together with any of the previous
        /// </summary>
        Normal = 16,
    }
}
