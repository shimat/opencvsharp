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
	/// アルゴリズムをスタートする最初のステップ
	/// </summary>
#else
    /// <summary>
    /// The initial step the algorithm starts from
    /// </summary>
#endif
    public enum EMStartStep : int
    {
#if LANG_JP
		/// <summary>
		/// アルゴリズムはE-stepでスタートする. 少なくとも平均ベクトルの初期値 CvEMParams.Means が渡されなければならない． 
		/// オプションとして，ユーザは重み（CvEMParams.Weights）と/または共変動行列（CvEMParams.Covs）を与えることもできる．
		/// [CvEM::START_E_STEP]
		/// </summary>
#else
        /// <summary>
        /// The algorithm starts with E-step. 
        /// At least, the initial values of mean vectors, CvEMParams.Means must be passed. 
        /// Optionally, the user may also provide initial values for weights (CvEMParams.Weights) 
        /// and/or covariation matrices (CvEMParams.Covs).
        /// [CvEM::START_E_STEP]
        /// </summary>
#endif
        E = 1,
#if LANG_JP
		/// <summary>
		/// アルゴリズムはM-stepでスタートする.初期確率 p_i,k が与えられなければならない．
		/// [CvEM::START_M_STEP]
		/// </summary>
#else
        /// <summary>
        /// The algorithm starts with M-step. The initial probabilities p_i,k must be provided.
        /// [CvEM::START_M_STEP]
        /// </summary>
#endif
        M = 2,
#if LANG_JP
		/// <summary>
		/// ユーザから必要な値が指定されない場合，k-meansアルゴリズムが混合分布パラメータの初期値推定に用いられる．
		/// [CvEM::START_AUTO_STEP]
		/// </summary>
#else
        /// <summary>
        /// No values are required from the user, k-means algorithm is used to estimate initial mixtures parameters. 
        /// [CvEM::START_AUTO_STEP]
        /// </summary>
#endif
        Auto = 0,
    }
}
