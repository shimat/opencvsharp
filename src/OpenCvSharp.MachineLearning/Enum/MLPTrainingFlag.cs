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
	/// MLPで用いる学習アルゴリズム
	/// </summary>
#else
	/// <summary>
	/// The MLP training algorithm to use
	/// </summary>
#endif
    [Flags]
	public enum MLPTrainingFlag : int
	{
#if LANG_JP
		/// <summary>
		/// フラグなし
		/// [0]
		/// </summary>
#else
		/// <summary>
		/// No flags
		/// [0]
		/// </summary>
#endif
		Zero = 0,

#if LANG_JP
		/// <summary>
		/// 1 - アルゴリズムはネットワークの重みを最初から計算せず，更新する （最初から計算する場合，重みはNguyen-Widrowアルゴリズムを使って初期化される）．
		/// [CvANN_MLP::UPDATE_WEIGHTS]
		/// </summary>
#else
		/// <summary>
		/// 1 - algorithm updates the network weights, rather than computes them from scratch 
		/// (in the latter case the weights are initialized using Nguyen-Widrow algorithm).
		/// [CvANN_MLP::UPDATE_WEIGHTS]
		/// </summary>
#endif
		UpdateWeights = 1,


#if LANG_JP
		/// <summary>
		/// アルゴリズムは入力ベクトルを正規化しない．
		/// このフラグをセットしない場合， 学習アルゴリズムは平均値が0，標準偏差が1となるように，各入力を自主的に正規化する． 
		/// 高頻度で更新されるネットワークの場合，新しい学習データは元のデータから大幅に異なる可能性がある． このような場合，ユーザは適切な正規化を導入する必要がある．
		/// [CvANN_MLP::NO_INPUT_SCALE]
		/// </summary>
#else
		/// <summary>
		/// algorithm does not normalize the input vectors. 
		/// If this flag is not set, the training algorithm normalizes each input feature independently, 
		/// shifting its mean value to 0 and making the standard deviation =1. If the network is assumed to be updated frequently, 
		/// the new training data could be much different from original one. In this case user should take care of proper normalization.
		/// [CvANN_MLP::NO_INPUT_SCALE]
		/// </summary>
#endif
		NoInputScale = 2,


#if LANG_JP
		/// <summary>
		/// アルゴリズムは出力ベクトルを正規化しない．
		/// このフラグをセットしない場合，学習アルゴリズムは使われた活性化関数に応じた範囲に納まるように，各出力を自主的に正規化する.
		/// [CvANN_MLP::NO_OUTPUT_SCALE]
		/// </summary>
#else
		/// <summary>
		/// algorithm does not normalize the output vectors. 
		/// If the flag is not set, the training algorithm normalizes each output features independently, 
		/// by transforming it to the certain range depending on the activation function used.
		/// [CvANN_MLP::NO_OUTPUT_SCALE]
		/// </summary>
#endif
		NoOutputScale = 4,

	}
}
