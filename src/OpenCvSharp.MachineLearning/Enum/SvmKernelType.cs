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
	/// SVMカーネルの種類
	/// </summary>
#else
	/// <summary>
	/// The kernel type of SVM
	/// </summary>
#endif
	public enum SVMKernelType : int
	{
#if LANG_JP
		/// <summary>
		/// マッピングは行われない．もとの特徴空間内で，線形分離（あるいは回帰）が行われる．最も高速なオプション．d(x,y) = x•y == (x,y) 
		/// [CvSVM::LINEAR]
		/// </summary>
#else
		/// <summary>
		/// no mapping is done, linear discrimination (or regression) is done in the original feature space. It is the fastest option. d(x,y) = x•y == (x,y) 
		/// [CvSVM::LINEAR]
		/// </summary>
#endif
		Linear = 0,

#if LANG_JP
		/// <summary>
		/// 多項式カーネル： d(x,y) = (gamma*(x•y)+coef0)^degree 
		/// [CvSVM::POLY]
		/// </summary>
#else
		/// <summary>
		/// polynomial kernel: d(x,y) = (gamma*(x•y)+coef0)^degree 
		/// [CvSVM::POLY]
		/// </summary>
#endif
		Poly = 1,

#if LANG_JP
		/// <summary>
		/// 動径基底関数カーネル．ほとんどの場合，適切に動作する： d(x,y) = exp(-gamma*|x-y|^2) 
		/// [CvSVM::RBF]
		/// </summary>
#else
		/// <summary>
		/// radial-basis-function kernel; a good choice in most cases: d(x,y) = exp(-gamma*|x-y|^2) 
		/// [CvSVM::RBF]
		/// </summary>
#endif
		Rbf = 2,

#if LANG_JP
		/// <summary>
		/// シグモイド関数がカーネルとして用いられる．d(x,y) = tanh(gamma*(x•y)+coef0) 
		/// [CvSVM::SIGMOID]
		/// </summary>
#else
		/// <summary>
		/// sigmoid function is used as a kernel: d(x,y) = tanh(gamma*(x•y)+coef0) 
		/// [CvSVM::SIGMOID]
		/// </summary>
#endif
		Sigmoid = 3,
	}
}
