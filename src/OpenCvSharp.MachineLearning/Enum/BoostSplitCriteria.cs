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
	/// 弱い木を構築するときの最適分岐を選択する際に用いられる分岐規則
	/// </summary>
#else
	/// <summary>
	/// Splitting criteria, used to choose optimal splits during a weak tree construction
	/// </summary>
#endif
	public enum BoostSplitCriteria : int
	{
#if LANG_JP
		/// <summary>
		/// 個々のブースティング手法におけるデフォルト規則を用いる
		/// [CvBoost::DEFAULT]
		/// </summary>
#else
		/// <summary>
		/// Use the default criteria for the particular boosting method.
		/// [CvBoost::DEFAULT]
		/// </summary>
#endif
		Default = 0,


#if LANG_JP
		/// <summary>
		/// ジニ指標（Gini index）を用いる．これはReal AdaBoost のデフォルトオプションである．Discrete AdaBoost でも用いられることがある．
		/// [CvBoost::GINI]
		/// </summary>
#else
		/// <summary>
		/// Use Gini index. This is default option for Real AdaBoost; may be also used for Discrete AdaBoost.
		/// [CvBoost::GINI]
		/// </summary>
#endif
		Gini = 1,


#if LANG_JP
		/// <summary>
		/// 誤判別率を用いる．これはDiscrete AdaBoost のデフォルトオプションである．Real AdaBoost でも用いられることがある．
		/// [CvBoost::MISCLASS]
		/// </summary>
#else
		/// <summary>
		/// Use misclassification rate. This is default option for Discrete AdaBoost; may be also used for Real AdaBoost.
		/// [CvBoost::MISCLASS]
		/// </summary>
#endif
		Misclass = 3,

		
#if LANG_JP
		/// <summary>
		/// これは LogitBoost および Gentle AdaBoost で用いられるデフォルトかつ唯一のオプションである．
		/// [CvBoost::SQERR]
		/// </summary>
#else
		/// <summary>
		/// Use least squares criteria. This is default and the only option for LogitBoost and Gentle AdaBoost.最小二乗基準を用いる．
		/// [CvBoost::SQERR]
		/// </summary>
#endif
		Sqerr = 4,
	}
}
