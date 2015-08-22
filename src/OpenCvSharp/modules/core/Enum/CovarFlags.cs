using System;

namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// CovarMatrixの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// Operation flags for Covariation 
    /// </summary>
#endif
    [Flags]
    public enum CovarFlags : int
    {
#if LANG_JP
		/// <summary>
		/// scale * [vects[0]-avg,vects[1]-avg,...]^T * [vects[0]-avg,vects[1]-avg,...]   
        /// すなわち，共変動行列はcount×countである． そのような一般的でない共変動行列は，
        /// 非常に大きなベクトル集合に対する高速な主成分分析のために使用される（例えば，顔認識のための固有顔）．
        /// この「スクランブルされた」行列の固有値は，真共変動行列の固有値と一致し， 
        /// そして「真の」固有ベクトルは「スクランブルされた」共変動行列の固有ベクトルから容易に計算できる．
		/// </summary>
#else
        /// <summary>
        /// scale * [vects[0]-avg,vects[1]-avg,...]^T * [vects[0]-avg,vects[1]-avg,...]   
        /// that is, the covariation matrix is count×count. Such an unusual covariation matrix is used for fast PCA of a set of very large vectors
        /// (see, for example, Eigen Faces technique for face recognition). Eigenvalues of this "scrambled" matrix will match to the eigenvalues of
        /// the true covariation matrix and the "true" eigenvectors can be easily calculated from the eigenvectors of the "scrambled" covariation matrix.
        /// </summary>
#endif
        Scrambled = 0,


#if LANG_JP
		/// <summary>
		/// scale * [vects[0]-avg,vects[1]-avg,...]*[vects[0]-avg,vects[1]-avg,...]^T   
        /// つまり，cov_matはすべての入力ベクトルの要素の合計と同じサイズの一般的な共変動行列となる． 
        /// CV_COVAR_SCRAMBLEDとCV_COVAR_NORMALのどちらか一つは必ず指定されなくてはならない．
		/// </summary>
#else
        /// <summary>
        /// scale * [vects[0]-avg,vects[1]-avg,...]*[vects[0]-avg,vects[1]-avg,...]^T   
        /// that is, cov_mat will be a usual covariation matrix with the same linear size as the total number of elements in every input vector. 
        /// One and only one of CV_COVAR_SCRAMBLED and CV_COVAR_NORMAL must be specified
        /// </summary>
#endif
        Normal = 1,


#if LANG_JP
		/// <summary>
		/// このフラグが指定された場合，関数は入力ベクトルから平均を計算せず，引数で指定された平均ベクトルを使用する． 
        /// 平均が何らかの方法で既に計算されている場合，または共変動行列が部分的に計算されている場合 （この場合，avgは入力ベクトルの一部の平均ではなく，全ての平均ベクトルである）に有用である． 
		/// </summary>
#else
        /// <summary>
        /// If the flag is specified, the function does not calculate avg from the input vectors, 
        /// but, instead, uses the passed avg vector. This is useful if avg  has been already calculated somehow, 
        /// or if the covariation matrix is calculated by parts - in this case, avg is not a mean vector of the input sub-set of vectors, 
        /// but rather the mean vector of the whole set.
        /// </summary>
#endif
        UseAvg = 2,


#if LANG_JP
		/// <summary>
		/// このフラグが指定された場合， 共変動行列は入力ベクトルの数によってスケーリングされる．
		/// </summary>
#else
        /// <summary>
        /// If the flag is specified, the covariation matrix is scaled by the number of input vectors.
        /// </summary>
#endif
        Scale = 4,


#if LANG_JP
		/// <summary>
		/// 全ての入力ベクトルは単一の行列（vects[0]）の行として保存されることを意味する．
        /// そしてavgは適切な大きさの1行のベクトルでなければならない． 
		/// </summary>
#else
        /// <summary>
        /// Means that all the input vectors are stored as rows of a single matrix, vects[0].count is ignored in this case, 
        /// and avg should be a single-row vector of an appropriate size.
        /// </summary>
#endif
        Rows = 8,


#if LANG_JP
		/// <summary>
		/// 全ての入力ベクトルは単一の行列（vects[0]）の列として保存されることを意味する．そしてavgは適切な大きさの1列のベクトルでなければならない． 
		/// </summary>
#else
        /// <summary>
        /// Means that all the input vectors are stored as columns of a single matrix, vects[0].count is ignored in this case, 
        /// and avg should be a single-column vector of an appropriate size. 
        /// </summary>
#endif
        Cols = 16,
    }
}
