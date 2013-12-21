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
	/// SVMの種類
	/// </summary>
#else
	/// <summary>
	/// Type of SVM
	/// </summary>
#endif
	public enum SVMType : int
	{
#if LANG_JP
		/// <summary>
		/// はずれ値に対するペナルティ乗数 C を持ち， 不完全な分離を許容する n-クラス分類（n>=2）
		/// [CvSVM::C_SVC]
		/// </summary>
#else
		/// <summary>
		/// n-class classification (n>=2), allows imperfect separation of classes with penalty multiplier C for outliers.
		/// [CvSVM::C_SVC]
		/// </summary>
#endif
		CSvc = 100,


#if LANG_JP
		/// <summary>
		/// 完全な分離となる可能性がある n-クラス分類． C の代わりにパラメータ nu  （0..1 の範囲，大きい値ほど滑らかな判断境界を表す）が用いられる．
		/// [CvSVM::NU_SVC]
		/// </summary>
#else
		/// <summary>
		/// n-class classification with possible imperfect separation. Parameter nu (in the range 0..1, the larger the value, the smoother the decision boundary) is used instead of C.
		/// [CvSVM::NU_SVC]
		/// </summary>
#endif
		NuSvc = 101,


#if LANG_JP
		/// <summary>
		/// 1-クラス SVM．全学習データは同じクラスから得られ，SVMはそのクラスを特徴空間の他のクラスから分離する境界を求める．
		/// [CvSVM::ONE_CLASS]
		/// </summary>
#else
		/// <summary>
		/// one-class SVM. All the training data are from the same class, SVM builds a boundary that separates the class from the rest of the feature space.
		/// [CvSVM::ONE_CLASS]
		/// </summary>
#endif
		OneClass = 102,


#if LANG_JP
		/// <summary>
		/// 回帰．学習集合の特徴ベクトルと超平面との距離が p よりも短くなければならない． はずれ値に対してはペナルティ乗数 C が用いられる．
		/// [CvSVM::EPS_SVR]
		/// </summary>
#else
		/// <summary>
		/// regression. The distance between feature vectors from the training set and the fitting hyper-plane must be less than p. For outliers the penalty multiplier C is used.
		/// [CvSVM::EPS_SVR]
		/// </summary>
#endif
		EpsSvr = 103,


#if LANG_JP
		/// <summary>
		/// 回帰．p の代わり にnu が用いられる．
		/// [CvSVM::NU_SVR]
		/// </summary>
#else
		/// <summary>
		/// regression; nu is used instead of p. 
		/// [CvSVM::NU_SVR]
		/// </summary>
#endif
		NuSvr = 104,
	}
}
