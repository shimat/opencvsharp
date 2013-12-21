/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region Xor
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの排他的論理和（XOR）を計算する. 
        /// dst(I)=src1(I)^src2(I)
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>am>
#endif
        public static void Xor(CvArr src1, CvArr src2, CvArr dst)
        {
            Xor(src1, src2, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの排他的論理和（XOR）を計算する. 
        /// dst(I)=src1(I)^src2(I) [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void Xor(CvArr src1, CvArr src2, CvArr dst, CvArr mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvXor(src1.CvPtr, src2.CvPtr, dst.CvPtr, maskPtr);
        }
        #endregion
        #region XorS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の排他的論理和(XOR)を計算する.
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)^value
        /// </summary>
        /// <param name="src1">入力配列</param>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on array and scalar
        /// </summary>
        /// <param name="src1">The source array. </param>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void XorS(CvArr src1, CvScalar value, CvArr dst)
        {
            XorS(src1, value, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の排他的論理和(XOR)を計算する. 
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)^value [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src1">入力配列</param>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Performs per-element bit-wise "exclusive or" operation on array and scalar
        /// </summary>
        /// <param name="src1">The source array. </param>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void XorS(CvArr src1, CvScalar value, CvArr dst, CvArr mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvXorS(src1.CvPtr, value, dst.CvPtr, maskPtr);
        }
        #endregion
    }
}