using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
	/// <summary>
	/// cv::dft の変換フラグ
	/// </summary>
#else
    /// <summary>
    /// Transformation flags for cv::dft
    /// </summary>
#endif
    [Flags]
    public enum DftFlag2 : int
    {
#if LANG_JP
		/// <summary>
		/// Zero
        /// [0]
		/// </summary>
#else
        /// <summary>
        /// Zero
        /// [0]
        /// </summary>
#endif
        None = 0,

#if LANG_JP
		/// <summary>
		/// 1次元または2次元の逆変換を行う．結果のスケーリングは行わない． 
		/// Forward と Inverse は，もちろん同時には指定できない．
        /// [DFT_INVERSE]
		/// </summary>
#else
        /// <summary>
        /// Do inverse 1D or 2D transform. The result is not scaled. 
        /// (Forward and Inverse are mutually exclusive, of course.)
        /// [DFT_INVERSE]
        /// </summary>
#endif
        Inverse = CppConst.DFT_INVERSE,

#if LANG_JP
		/// <summary>
		/// 結果を配列要素数で割り，スケーリングする．通常は Inverse と同時に用いる．
		/// ショートカットとして InvScale を用いても良い．
        /// [DFT_SCALE]
		/// </summary>
#else
        /// <summary>
        /// Scale the result: divide it by the number of array elements. Usually, it is combined with Inverse.
        /// [DFT_SCALE]
        /// </summary>
#endif
        Scale = CppConst.DFT_SCALE,

#if LANG_JP
		/// <summary>
		/// 入力配列のそれぞれの行に対して独立に，順変換あるいは逆変換を行う． 
		/// このフラグは複数のベクトルの同時変換を許可し，
		/// オーバーヘッド（一つの計算の何倍も大きくなることもある）を減らすためや，
		/// 3次元以上の高次元に対して変換を行うために使用される．
        /// [CV_DXT_ROWS]
		/// </summary>
#else
        /// <summary>
        /// Do forward or inverse transform of every individual row of the input matrix. 
        /// This flag allows user to transform multiple vectors simultaneously and can be used to decrease the overhead
        /// (which is sometimes several times larger than the processing itself), to do 3D and higher-dimensional transforms etc.
        /// [CV_DXT_ROWS]
        /// </summary>
#endif
        Rows = CppConst.DFT_ROWS,


        /// <summary>
        /// then the function performs forward transformation of 1D or 2D real array, the result, 
        /// though being a complex array, has complex-conjugate symmetry ( CCS ), see the description below. 
        /// Such an array can be packed into real array of the same size as input, which is the fastest option 
        /// and which is what the function does by default. However, you may wish to get the full complex array 
        /// (for simpler spectrum analysis etc.). Pass the flag to tell the function to produce full-size complex output array.
        /// [DFT_COMPLEX_OUTPUT]
        /// </summary>
        ComplexOutput = CppConst.DFT_COMPLEX_OUTPUT,

        /// <summary>
        /// then the function performs inverse transformation of 1D or 2D complex array, the result is normally a complex array 
        /// of the same size. However, if the source array has conjugate-complex symmetry (for example, it is a result of 
        /// forward transformation with DFT_COMPLEX_OUTPUT flag), then the output is real array. While the function itself 
        /// does not check whether the input is symmetrical or not, you can pass the flag and then the function will assume 
        /// the symmetry and produce the real output array. Note that when the input is packed real array and 
        /// inverse transformation is executed, the function treats the input as packed complex-conjugate symmetrical array, 
        /// so the output will also be real array
        /// [DFT_REAL_OUTPUT]
        /// </summary>
        RealOutput = CppConst.DFT_REAL_OUTPUT,
    }
}
