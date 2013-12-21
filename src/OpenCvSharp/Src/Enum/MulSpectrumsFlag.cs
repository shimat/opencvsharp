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
    /// cvMulSpectrumsの変換フラグ
    /// </summary>
#else
    /// <summary>
    /// Operation flags for cvMulSpectrums
    /// </summary>
#endif
    [Flags]
    public enum MulSpectrumsFlag : int
    {
#if LANG_JP
        /// <summary>
        /// 配列の各行を個別のスペクトラムとして扱う.
        /// [CV_DXT_ROWS]
        /// </summary>
#else
        /// <summary>
        /// Treat each row of the arrays as a separate spectrum.
        /// [CV_DXT_ROWS]
        /// </summary>
#endif
        Rows = CvConst.CV_DXT_ROWS,


#if LANG_JP
        /// <summary>
        /// 乗算の前に2番目の入力配列の共役を計算する.
        /// [CV_DXT_MUL_CONJ]
        /// </summary>
#else
        /// <summary>
        /// Conjugate the second argument of cvMulSpectrums. 
        /// [CV_DXT_MUL_CONJ]
        /// </summary>
#endif
        MulConj = CvConst.CV_DXT_MUL_CONJ,
    }
}
