/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// cvCovarMatrixの処理フラグ
	/// </summary>
#else
    /// <summary>
    /// Operation flags for cvCovarMatrix
    /// </summary>
#endif
    [Flags]
    public enum CovarMatrixFlag : int
    {
#if LANG_JP
		/// <summary>
		/// scale * [vects[0]-avg,vects[1]-avg,...]^T * [vects[0]-avg,vects[1]-avg,...]   
        /// すなわち，共変動行列はcount×countである． そのような一般的でない共変動行列は，
        /// 非常に大きなベクトル集合に対する高速な主成分分析のために使用される（例えば，顔認識のための固有顔）．
        /// この「スクランブルされた」行列の固有値は，真共変動行列の固有値と一致し， 
        /// そして「真の」固有ベクトルは「スクランブルされた」共変動行列の固有ベクトルから容易に計算できる．
        /// [CV_COVAR_SCRAMBLED]
		/// </summary>
#else
        /// <summary>
        /// scale * [vects[0]-avg,vects[1]-avg,...]^T * [vects[0]-avg,vects[1]-avg,...]   
        /// that is, the covariation matrix is count×count. Such an unusual covariation matrix is used for fast PCA of a set of very large vectors
        /// (see, for example, Eigen Faces technique for face recognition). Eigenvalues of this "scrambled" matrix will match to the eigenvalues of
        /// the true covariation matrix and the "true" eigenvectors can be easily calculated from the eigenvectors of the "scrambled" covariation matrix.
        /// [CV_COVAR_SCRAMBLED]
        /// </summary>
#endif
        Scrambled = CvConst.CV_COVAR_SCRAMBLED,


#if LANG_JP
		/// <summary>
		/// scale * [vects[0]-avg,vects[1]-avg,...]*[vects[0]-avg,vects[1]-avg,...]^T   
        /// つまり，cov_matはすべての入力ベクトルの要素の合計と同じサイズの一般的な共変動行列となる． 
        /// CV_COVAR_SCRAMBLEDとCV_COVAR_NORMALのどちらか一つは必ず指定されなくてはならない．
        /// [CV_COVAR_NORMAL]
		/// </summary>
#else
        /// <summary>
        /// scale * [vects[0]-avg,vects[1]-avg,...]*[vects[0]-avg,vects[1]-avg,...]^T   
        /// that is, cov_mat will be a usual covariation matrix with the same linear size as the total number of elements in every input vector. 
        /// One and only one of CV_COVAR_SCRAMBLED and CV_COVAR_NORMAL must be specified
        /// [CV_COVAR_NORMAL]
        /// </summary>
#endif
        Normal = CvConst.CV_COVAR_NORMAL,


#if LANG_JP
		/// <summary>
		/// このフラグが指定された場合，関数は入力ベクトルから平均を計算せず，引数で指定された平均ベクトルを使用する． 
        /// 平均が何らかの方法で既に計算されている場合，または共変動行列が部分的に計算されている場合 （この場合，avgは入力ベクトルの一部の平均ではなく，全ての平均ベクトルである）に有用である． 
        /// [CV_COVAR_USE_AVG]
		/// </summary>
#else
        /// <summary>
        /// If the flag is specified, the function does not calculate avg from the input vectors, 
        /// but, instead, uses the passed avg vector. This is useful if avg  has been already calculated somehow, 
        /// or if the covariation matrix is calculated by parts - in this case, avg is not a mean vector of the input sub-set of vectors, 
        /// but rather the mean vector of the whole set.
        /// [CV_COVAR_USE_AVG]
        /// </summary>
#endif
        UseAvg = CvConst.CV_COVAR_USE_AVG,


#if LANG_JP
		/// <summary>
		/// このフラグが指定された場合， 共変動行列は入力ベクトルの数によってスケーリングされる．
        /// [CV_COVAR_SCALE]
		/// </summary>
#else
        /// <summary>
        /// If the flag is specified, the covariation matrix is scaled by the number of input vectors.
        /// [CV_COVAR_SCALE]
        /// </summary>
#endif
        Scale = CvConst.CV_COVAR_SCALE,


#if LANG_JP
		/// <summary>
		/// 全ての入力ベクトルは単一の行列（vects[0]）の行として保存されることを意味する．
        /// そしてavgは適切な大きさの1行のベクトルでなければならない． 
        /// [CV_COVAR_ROWS]
		/// </summary>
#else
        /// <summary>
        /// Means that all the input vectors are stored as rows of a single matrix, vects[0].count is ignored in this case, 
        /// and avg should be a single-row vector of an appropriate size.
        /// [CV_COVAR_ROWS]
        /// </summary>
#endif
        Rows = CvConst.CV_COVAR_ROWS,


#if LANG_JP
		/// <summary>
		/// 全ての入力ベクトルは単一の行列（vects[0]）の列として保存されることを意味する．そしてavgは適切な大きさの1列のベクトルでなければならない． 
        /// [CV_COVAR_COLS]
		/// </summary>
#else
        /// <summary>
        /// Means that all the input vectors are stored as columns of a single matrix, vects[0].count is ignored in this case, 
        /// and avg should be a single-column vector of an appropriate size. 
        /// [CV_COVAR_COLS]
        /// </summary>
#endif
        Cols = CvConst.CV_COVAR_COLS,
    }
}
