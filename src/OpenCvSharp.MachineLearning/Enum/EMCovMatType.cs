/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.MachineLearning
{
#if LANG_JP
    /// <summary>
	/// 混合分布共変動行列のタイプ
	/// </summary>
#else
	/// <summary>
	/// The type of the mixture covariation matrices
	/// </summary>
#endif
	public enum EMCovMatType : int
	{
#if LANG_JP
		/// <summary>
		/// それぞれの混合分布の共変動行列は任意の正定値対称行列であり， それぞれの行列における自由なパラメータ数は約d2/2である． 
		/// かなり正確なパラメータの推定初期値があるか，学習サンプル数が膨大でない限り，このオプションを使用することは推奨されない．
		/// [CvEM::COV_MAT_SPHERICAL]
		/// </summary>
#else
		/// <summary>
		/// A covariation matrix of each mixture is a scaled identity matrix, μk*I, 
		/// so the only parameter to be estimated is μk. The option may be used in special cases, 
		/// when the constraint is relevant, or as a first step in the optimization 
		/// (e.g. in case when the data is preprocessed with PCA). The results of such preliminary estimation 
		/// may be passed again to the optimization procedure, this time with cov_mat_type=Diagonal. 
		/// [CvEM::COV_MAT_SPHERICAL]
		/// </summary>
#endif
		Spherical = 0,
#if LANG_JP
		/// <summary>
		/// それぞれの行列の共変動行列は任意の正の対角要素を持つ対角行列であり，対角以外の要素は0となる． 
		/// そのため，自由なパラメータの数は，それぞれの行列でdである．これは良い推定結果をもたらすオプションとして一般的に最も使用される．
		/// [CvEM::COV_MAT_DIAGONAL]
		/// </summary>
#else
		/// <summary>
		/// A covariation matrix of each mixture may be arbitrary diagonal matrix with positive diagonal elements, 
		/// that is, non-diagonal elements are forced to be 0's, so the number of free parameters is d for each matrix. 
		/// This is most commonly used option yielding good estimation results.
		/// [CvEM::COV_MAT_DIAGONAL]
		/// </summary>
#endif
		Diagonal = 1,
#if LANG_JP
		/// <summary>
		/// それぞれの行列の共変動行列は，スケーリングされた単位行列μk*Iである． そのため推定されるパラメータはμkのみである．
		/// このオプションは制約条件が関連する特別なケースや，最適化の第1ステップとして（例えば，データがPCA  によって事前処理されている場合など）用いられることがある． 
		/// このような予備推定の結果は，さらにcov_mat_type=CvEM::COV_MAT_DIAGONALを指定した最適化処理に渡される．
		/// [CvEM::COV_MAT_GENERIC]
		/// </summary>
#else
		/// <summary>
		/// A covariation matrix of each mixture may be arbitrary symmetrical positively defined matrix, 
		/// so the number of free parameters in each matrix is about d^2/2. 
		/// It is not recommended to use this option, unless there is pretty accurate 
		/// initial estimation of the parameters and/or a huge number of training samples.
		/// [CvEM::COV_MAT_GENERIC]
		/// </summary>
#endif
		Generic = 2,
	}
}
