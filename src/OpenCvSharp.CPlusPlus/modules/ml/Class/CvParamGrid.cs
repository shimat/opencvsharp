using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.CPlusPlus
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
		public CvParamGrid(double minVal, double maxVal, double logStep)
		{
			MinVal = minVal;
			MaxVal = maxVal;
			Step = logStep;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
			return NativeMethods.ml_CvParamGrid_check(this) != 0;
        }

#pragma warning disable 1591
// ReSharper disable InconsistentNaming
        public const int SVM_C = 0;
		public const int SVM_GAMMA = 1;
		public const int SVM_P = 2;
		public const int SVM_NU = 3;
		public const int SVM_COEF = 4;
		public const int SVM_DEGREE = 5;
#pragma warning restore 1591
    };
}

