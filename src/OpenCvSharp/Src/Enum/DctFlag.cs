/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvDCTの変換フラグ
    /// </summary>
#else
    /// <summary>
    /// Transformation flags for cvDCT
    /// </summary>
#endif
    [Flags]
    public enum DCTFlag
    {
#if LANG_JP
        /// <summary>
        /// 1次元または2次元の順変換を行う．結果のスケーリングは行わない. 
        /// [CV_DXT_FORWARD]
        /// </summary>
#else
        /// <summary>
        /// Do forward 1D or 2D transform.
        /// (Forward and Inverse are mutually exclusive, of course.)
        /// [CV_DXT_FORWARD]
        /// </summary>
#endif
        Forward = CvConst.CV_DXT_FORWARD,


#if LANG_JP
        /// <summary>
        /// 1次元または2次元の逆変換を行う．結果のスケーリングは行わない． 
        /// Forward と Inverse は，もちろん同時には指定できない．
        /// [CV_DXT_INVERSE]
        /// </summary>
#else
        /// <summary>
        /// Do inverse 1D or 2D transform.
        /// (Forward and Inverse are mutually exclusive, of course.)
        /// [CV_DXT_INVERSE]
        /// </summary>
#endif
        Inverse = CvConst.CV_DXT_INVERSE,


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
        Rows = CvConst.CV_DXT_ROWS,
    }
}
