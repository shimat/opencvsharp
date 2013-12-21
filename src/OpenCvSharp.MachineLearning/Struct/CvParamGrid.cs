/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.MachineLearning
{
#if LANG_JP
    /// <summary>
	/// SVMアルゴリズムのパラメータのグリッド
	/// </summary>
#else
    /// <summary>
	/// A grid for the SVM algorithm.
	/// </summary>
#endif
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct CvParamGrid
	{
		/// <summary>
		/// 
		/// </summary>
		public double MinVal;
		/// <summary>
		/// 
		/// </summary>
		public double MaxVal;
		/// <summary>
		/// 
		/// </summary>
		public double Step;


		/// <summary>
		/// Constructor
		/// </summary>
		public CvParamGrid(double min_val, double max_val, double log_step)
		{
			MinVal = min_val;
			MaxVal = max_val;
			Step = log_step;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
			return MLInvoke.CvParamGrid_check(this);
        }

#pragma warning disable 1591
        public const int SVM_C = 0;
		public const int SVM_GAMMA = 1;
		public const int SVM_P = 2;
		public const int SVM_NU = 3;
		public const int SVM_COEF = 4;
		public const int SVM_DEGREE = 5;
#pragma warning restore 1591
    };
}

