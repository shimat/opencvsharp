using System;

namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// cvDFTの変換フラグ
	/// </summary>
#else
    /// <summary>
    /// Transformation flags for cvDFT
    /// </summary>
#endif
    [Flags]
    public enum DftFlags : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

#if LANG_JP
		/// <summary>
		/// 1次元または2次元の逆変換を行う．結果のスケーリングは行わない． 
		/// Forward と Inverse は，もちろん同時には指定できない．
		/// </summary>
#else
        /// <summary>
        /// Do inverse 1D or 2D transform. The result is not scaled. 
        /// (Forward and Inverse are mutually exclusive, of course.)
        /// </summary>
#endif
        Inverse = 1,


#if LANG_JP
		/// <summary>
		/// 結果を配列要素数で割り，スケーリングする．通常は Inverse と同時に用いる．
		/// ショートカットとして InvScale を用いても良い．
        /// [CV_DXT_SCALE]
		/// </summary>
#else
        /// <summary>
        /// Scale the result: divide it by the number of array elements. Usually, it is combined with Inverse.
        /// </summary>
#endif
        Scale = 2,

#if LANG_JP
		/// <summary>
		/// 入力配列のそれぞれの行に対して独立に，順変換あるいは逆変換を行う． 
		/// このフラグは複数のベクトルの同時変換を許可し，
		/// オーバーヘッド（一つの計算の何倍も大きくなることもある）を減らすためや，
		/// 3次元以上の高次元に対して変換を行うために使用される．
		/// </summary>
#else
        /// <summary>
        /// Do forward or inverse transform of every individual row of the input matrix. 
        /// This flag allows user to transform multiple vectors simultaneously and can be used to decrease the overhead
        /// (which is sometimes several times larger than the processing itself), to do 3D and higher-dimensional transforms etc.
        /// </summary>
#endif
        Rows = 4,

        /// <summary>
        /// performs a forward transformation of 1D or 2D real array; the result, 
        /// though being a complex array, has complex-conjugate symmetry (*CCS*, 
        /// see the function description below for details), and such an array can 
        /// be packed into a real array of the same size as input, which is the fastest 
        /// option and which is what the function does by default; however, you may 
        /// wish to get a full complex array (for simpler spectrum analysis, and so on) - 
        /// pass the flag to enable the function to produce a full-size complex output array.
        /// </summary>
        ComplexOutput = 16,

        /// <summary>
        /// performs an inverse transformation of a 1D or 2D complex array; 
        /// the result is normally a complex array of the same size, however, 
        /// if the input array has conjugate-complex symmetry (for example, 
        /// it is a result of forward transformation with DFT_COMPLEX_OUTPUT flag), 
        /// the output is a real array; while the function itself does not 
        /// check whether the input is symmetrical or not, you can pass the flag 
        /// and then the function will assume the symmetry and produce the real 
        /// output array (note that when the input is packed into a real array 
        /// and inverse transformation is executed, the function treats the input 
        /// as a packed complex-conjugate symmetrical array, and the output 
        /// will also be a real array).
        /// </summary>
        RealOutput = 32,
    }
}
