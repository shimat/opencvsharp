using System;

namespace OpenCvSharp.CPlusPlus
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
	public enum MLPTrainingMethod : int
	{
#if LANG_JP
		/// <summary>
		/// 逐次型の誤差逆伝播アルゴリズム
		/// [CvANN_MLP_TrainParams::BACKPROP]
		/// </summary>
#else
		/// <summary>
		/// sequential backpropagation algorithm
		/// [CvANN_MLP_TrainParams::BACKPROP]
		/// </summary>
#endif
		BACKPROP = 0,


#if LANG_JP
		/// <summary>
		/// RPROPアルゴリズム，デフォルト値
		/// [CvANN_MLP_TrainParams::RPROP]
		/// </summary>
#else
		/// <summary>
		/// RPROP algorithm, default value
		/// [CvANN_MLP_TrainParams::RPROP]
		/// </summary>
#endif
		RPROP = 1,

	}
}
