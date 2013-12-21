/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region AbsDiff
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの差の絶対値を計算する.
        /// dst(I) = abs(src1(I) - src2(I)).
        /// </summary>
        /// <param name="src1">1番目の入力画像</param>
        /// <param name="src2">2番目の入力画像</param>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Calculates absolute difference between two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void AbsDiff(CvArr src1, CvArr src2, CvArr dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvAbsDiff(src1.CvPtr, src2.CvPtr, dst.CvPtr);
        }
        #endregion
        #region AbsDiffS
#if LANG_JP
        /// <summary>
        /// 配列の要素の絶対値を計算する. 
        /// dst(I) = abs(src(I)).
        /// すべての配列は同じタイプ，同じサイズ（または同じROIサイズ）でなければならない．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
#else
        /// <summary>
        /// Calculates absolute difference between array and scalar
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Abs(CvArr src, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvAbsDiffS(src.CvPtr, dst.CvPtr, CvScalar.ScalarAll(0));
        }
#if LANG_JP
        /// <summary>
        /// 配列の要素と定数との差の絶対値を計算する. 
        /// dst(I) = abs(src(I) - value).
        /// </summary>
        /// <param name="src">1番目の入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="value">スカラー</param>
#else
        /// <summary>
        /// Calculates absolute difference between array and scalar
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="value">The scalar. </param>
#endif
        public static void AbsDiffS(CvArr src, CvArr dst, CvScalar value)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvAbsDiffS(src.CvPtr, dst.CvPtr, value);
        }
        #endregion
        #region Acc
#if LANG_JP
        /// <summary>
        /// アキュムレータにフレームを加算する
        /// </summary>
        /// <param name="image">入力画像．1 または 3 チャンネル，8 ビットあるいは 32 ビット浮動小数点型．</param>
        /// <param name="sum">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型．</param>
#else
        /// <summary>
        /// Adds frame to accumulator
        /// </summary>
        /// <param name="image">Input image, 1- or 3-channel, 8-bit or 32-bit floating point. (each channel of multi-channel image is processed independently). </param>
        /// <param name="sum">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
#endif
        public static void Acc(CvArr image, CvArr sum)
        {
            Acc(image, sum, null);
        }
#if LANG_JP
        /// <summary>
        /// アキュムレータにフレームを加算する
        /// </summary>
        /// <param name="image">入力画像．1 または 3 チャンネル，8 ビットあるいは 32 ビット浮動小数点型．</param>
        /// <param name="sum">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型．</param>
        /// <param name="mask">オプションの処理マスク．</param>
#else
        /// <summary>
        /// Adds frame to accumulator
        /// </summary>
        /// <param name="image">Input image, 1- or 3-channel, 8-bit or 32-bit floating point. (each channel of multi-channel image is processed independently). </param>
        /// <param name="sum">Accumulator of the same number of channels as input image, 32-bit or 64-bit floating-point. </param>
        /// <param name="mask">Optional operation mask. </param>
#endif
        public static void Acc(CvArr image, CvArr sum, CvArr mask)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (sum == null)
                throw new ArgumentNullException("sum");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvAcc(image.CvPtr, sum.CvPtr, maskPtr);
        }
        #endregion
        #region AdaptiveThreshold
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with Binary and BinaryInv. </param>
#endif
        public static void AdaptiveThreshold(CvArr src, CvArr dst, double maxValue)
        {
            AdaptiveThreshold(src, dst, maxValue, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 3, 5);
        }
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
        /// <param name="adaptiveMethod">適応的閾値処理で使用するアルゴリズム</param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with Binary and BinaryInv. </param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use: MeanC or GaussianC.</param>
#endif
        public static void AdaptiveThreshold(CvArr src, CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod)
        {
            AdaptiveThreshold(src, dst, maxValue, adaptiveMethod, ThresholdType.Binary, 3, 5);
        }
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
        /// <param name="adaptiveMethod">適応的閾値処理で使用するアルゴリズム</param>
        /// <param name="thresholdType">閾値処理の種類. BinaryかBinaryInvのどちらか</param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with Binary and BinaryInv. </param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use: MeanC or GaussianC.</param>
        /// <param name="thresholdType">Thresholding type.</param>
#endif
        public static void AdaptiveThreshold(CvArr src, CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType)
        {
            AdaptiveThreshold(src, dst, maxValue, adaptiveMethod, thresholdType, 3, 5);
        }
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
        /// <param name="adaptiveMethod">適応的閾値処理で使用するアルゴリズム</param>
        /// <param name="thresholdType">閾値処理の種類. BinaryかBinaryInvのどちらか</param>
        /// <param name="blockSize">ピクセルの閾値を計算するために用いる隣接領域のサイズ： 3, 5, 7, ... </param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with Binary and BinaryInv. </param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use: MeanC or GaussianC.</param>
        /// <param name="thresholdType">Thresholding type.</param>
        /// <param name="blockSize">The size of a pixel neighborhood that is used to calculate a threshold value for the pixel: 3, 5, 7, ... </param>
#endif
        public static void AdaptiveThreshold(CvArr src, CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType, int blockSize)
        {
            AdaptiveThreshold(src, dst, maxValue, adaptiveMethod, thresholdType, blockSize, 5);
        }
#if LANG_JP
        /// <summary>
        /// 適応的な閾値処理を行い、グレースケール画像を2値画像に変換する
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="maxValue">threshold_type がBinaryあるいはBinaryInvのときに用いる最大値</param>
        /// <param name="adaptiveMethod">適応的閾値処理で使用するアルゴリズム</param>
        /// <param name="thresholdType">閾値処理の種類. BinaryかBinaryInvのどちらか</param>
        /// <param name="blockSize">ピクセルの閾値を計算するために用いる隣接領域のサイズ： 3, 5, 7, ... </param>
        /// <param name="param1">各適応手法に応じたパラメータ. 適応手法がMeanCおよびGaussianCの場合は，平均値または重み付き平均値から引く定数. 負の値の場合もある.</param>
#else
        /// <summary>
        /// Applies adaptive threshold to array.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image. </param>
        /// <param name="maxValue">Maximum value that is used with Binary and BinaryInv. </param>
        /// <param name="adaptiveMethod">Adaptive thresholding algorithm to use: MeanC or GaussianC.</param>
        /// <param name="thresholdType">Thresholding type.</param>
        /// <param name="blockSize">The size of a pixel neighborhood that is used to calculate a threshold value for the pixel: 3, 5, 7, ... </param>
        /// <param name="param1">The method-dependent parameter. For the methods MeanC and GaussianC it is a constant subtracted from mean or weighted mean (see the discussion), though it may be negative. </param>
#endif
        public static void AdaptiveThreshold(CvArr src, CvArr dst, double maxValue, AdaptiveThresholdType adaptiveMethod, ThresholdType thresholdType, int blockSize, double param1)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            if (thresholdType != ThresholdType.Binary && thresholdType != ThresholdType.BinaryInv)
            {
                throw new ArgumentException("thresholdType == Binary || thresholdType == BinaryInv");
            }
            CvInvoke.cvAdaptiveThreshold(src.CvPtr, dst.CvPtr, maxValue, adaptiveMethod, thresholdType, blockSize, param1);
        }
        #endregion
        #region Add
#if LANG_JP
        /// <summary>
        /// 二つの配列を要素ごとに加算する. 
        /// dst(I)=src1(I)+src2(I)
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes per-element sum of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Add(CvArr src1, CvArr src2, CvArr dst)
        {
            Add(src1, src2, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列を要素ごとに加算する. 
        /// dst(I)=src1(I)+src2(I) [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Computes per-element sum of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void Add(CvArr src1, CvArr src2, CvArr dst, CvArr mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvAdd(src1.CvPtr, src2.CvPtr, dst.CvPtr, maskPtr);
        }
        #endregion
        #region AddS
#if LANG_JP
        /// <summary>
        /// 入力配列 src1 のすべての要素にスカラー value を加え，結果を dst に保存する．
        /// dst(I)=src(I)+value
        /// </summary>
        /// <param name="src1">入力配列</param>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes sum of array and scalar
        /// </summary>
        /// <param name="src1">The source array. </param>
        /// <param name="value">Added scalar. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void AddS(CvArr src1, CvScalar value, CvArr dst)
        {
            AddS(src1, value, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列 src1 のすべての要素にスカラー value を加え，結果を dst に保存する．
        /// dst(I)=src(I)+value [mask(I)!=0 の場合]
        /// </summary>
        /// <param name="src1">入力配列</param>
        /// <param name="value">加算するスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Computes sum of array and scalar
        /// </summary>
        /// <param name="src1">The source array. </param>
        /// <param name="value">Added scalar. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void AddS(CvArr src1, CvScalar value, CvArr dst, CvArr mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvAddS(src1.CvPtr, value, dst.CvPtr, maskPtr);
        }
        #endregion
        #region AddText
#if LANG_JP
        /// <summary>
        /// 画像上にテキストを描画します．
        /// </summary>
        /// <param name="img">文字列描画の対象となる画像．</param>
        /// <param name="text">画像上に描画されるテキスト．</param>
        /// <param name="location">画像上のテキストの開始位置 Point(x,y)．</param>
        /// <param name="font">テキストを描画するのに利用されるフォント．</param>
#else
        /// <summary>
        /// Create the font to be used to draw text on an image
        /// </summary>
        /// <param name="img">Image where the text should be drawn</param>
        /// <param name="text">Text to write on the image</param>
        /// <param name="location">Point(x,y) where the text should start on the image</param>
        /// <param name="font">Font to use to draw the text</param>
#endif
        public static void AddText(CvArr img, string text, CvPoint location, CvFont font)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (text == null)
                throw new ArgumentNullException("text");
            if (font == null)
                throw new ArgumentNullException("font");

            CvInvoke.cvAddText(img.CvPtr, text, location, font.CvPtr);
        }
        #endregion
        #region AddWeighted
#if LANG_JP
        /// <summary>
        /// 入力配列 src1 のすべての要素にスカラー value を加え，結果を dst に保存する．
        /// dst(I) = src1(I)*alpha + src2(I)*beta + gamma
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="alpha">1番目の配列要素への重み</param>
        /// <param name="src2">2番目の入力配列スカラー</param>
        /// <param name="beta">2番目の配列要素への重み</param>
        /// <param name="gamma">加算結果に，さらに加えられるスカラー値</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Computes weighted sum of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="alpha">Weight of the first array elements. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="beta">Weight of the second array elements. </param>
        /// <param name="gamma">Scalar, added to each sum. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void AddWeighted(CvArr src1, double alpha, CvArr src2, double beta, double gamma, CvArr dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvAddWeighted(src1.CvPtr, alpha, src2.CvPtr, beta, gamma, dst.CvPtr);
        }
        #endregion
        #region Alloc
#if LANG_JP
        /// <summary>
        /// メモリバッファの領域を確保する
        /// </summary>
        /// <param name="size">バッファサイズ（バイト単位）</param>
        /// <returns>メモリを確保した領域へのポインタ</returns>
#else
        /// <summary>
        /// Allocates memory buffer
        /// </summary>
        /// <param name="size">Buffer size in bytes. </param>
        /// <returns></returns>
#endif
        public static IntPtr Alloc(uint size)
        {
            return CvInvoke.cvAlloc(size);
        }
        #endregion
        #region And
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの論理積（AND）を計算する. 
        /// dst(I)=src1(I)&amp;src2(I)
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise conjunction of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void And(CvArr src1, CvArr src2, CvArr dst)
        {
            And(src1, src2, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素ごとの論理積（AND）を計算する. 
        /// dst(I)=src1(I)&amp;src2(I) [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）． </param>
#else
        /// <summary>
        /// Calculates per-element bit-wise conjunction of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void And(CvArr src1, CvArr src2, CvArr dst, CvArr mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvAnd(src1.CvPtr, src2.CvPtr, dst.CvPtr, maskPtr);
        }
        #endregion
        #region AndS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の論理積(AND)を計算する. 
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)&amp;value
        /// </summary>
        /// <param name="src1">入力配列</param>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise conjunction of array and scalar
        /// </summary>
        /// <param name="src1">The source array. </param>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void AndS(CvArr src1, CvScalar value, CvArr dst)
        {
            AndS(src1, value, dst, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーとのビット単位の論理積(AND)を計算する. 
        /// 実際の計算の前に，スカラーは配列と同じタイプに変換される．浮動小数点型配列の場合，それらのビット表現が処理に使われる．
        /// dst(I)=src(I)&amp;value [mask(I)!=0の場合]
        /// </summary>
        /// <param name="src1">入力配列</param>
        /// <param name="value">処理に用いるスカラー</param>
        /// <param name="dst">出力配列</param>
        /// <param name="mask">処理マスク．8ビットシングルチャンネル配列（出力配列のどの要素が変更されるかを指定する）．</param>
#else
        /// <summary>
        /// Calculates per-element bit-wise conjunction of array and scalar
        /// </summary>
        /// <param name="src1">The source array. </param>
        /// <param name="value">Scalar to use in the operation. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="mask">Operation mask, 8-bit single channel array; specifies elements of destination array to be changed. </param>
#endif
        public static void AndS(CvArr src1, CvScalar value, CvArr dst, CvArr mask)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvAndS(src1.CvPtr, value, dst.CvPtr, maskPtr);
        }
        #endregion
        #region ApproxChains
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="srcSeq">他のチェーンから参照可能なチェーンへの参照．</param>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="srcSeq">Freeman chain(s) </param>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> ApproxChains(CvChain srcSeq, CvMemStorage storage)
        {
            return ApproxChains(srcSeq, storage, ContourChain.ApproxSimple, 0, 0, false);
        }
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="srcSeq">他のチェーンから参照可能なチェーンへの参照．</param>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <param name="method">推定手法.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="srcSeq">Freeman chain(s) </param>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <param name="method">Approximation method.</param>
        /// /// <returns></returns>
#endif
        public static CvSeq<CvPoint> ApproxChains(CvChain srcSeq, CvMemStorage storage, ContourChain method)
        {
            return ApproxChains(srcSeq, storage, method, 0, 0, false);
        }
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="srcSeq">他のチェーンから参照可能なチェーンへの参照．</param>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <param name="method">推定手法.</param>
        /// <param name="parameter">メソッドパラメータ（現在は使われていない）．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="srcSeq">Freeman chain(s) </param>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <param name="method">Approximation method.</param>
        /// <param name="parameter">Method parameter (not used now). </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> ApproxChains(CvChain srcSeq, CvMemStorage storage, ContourChain method, double parameter)
        {
            return ApproxChains(srcSeq, storage, method, parameter, 0, false);
        }
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="srcSeq">他のチェーンから参照可能なチェーンへの参照．</param>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <param name="method">推定手法.</param>
        /// <param name="parameter">メソッドパラメータ（現在は使われていない）．</param>
        /// <param name="minimalPerimeter">minimal_perimeter以上の周囲長をもつ輪郭のみを計算する．その他のチェーンは結果の構造体から削除される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="srcSeq">Freeman chain(s) </param>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <param name="method">Approximation method.</param>
        /// <param name="parameter">Method parameter (not used now). </param>
        /// <param name="minimalPerimeter">Approximates only those contours whose perimeters are not less than minimal_perimeter. Other chains are removed from the resulting structure. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> ApproxChains(CvChain srcSeq, CvMemStorage storage, ContourChain method, double parameter, int minimalPerimeter)
        {
            return ApproxChains(srcSeq, storage, method, parameter, minimalPerimeter, false);
        }
#if LANG_JP
        /// <summary>
        /// フリーマンチェーン（Freeman chain）をポリラインで近似する
        /// </summary>
        /// <param name="srcSeq">他のチェーンから参照可能なチェーンへの参照．</param>
        /// <param name="storage">計算結果保存用のストレージ．</param>
        /// <param name="method">推定手法.</param>
        /// <param name="parameter">メソッドパラメータ（現在は使われていない）．</param>
        /// <param name="minimalPerimeter">minimal_perimeter以上の周囲長をもつ輪郭のみを計算する．その他のチェーンは結果の構造体から削除される．</param>
        /// <param name="recursive">trueの場合，src_seqからh_nextあるいはv_nextによって辿ることができる全てのチェーンを近似する．falseの場合，単一のチェーンを近似する． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Approximates Freeman chain(s) with polygonal curve
        /// </summary>
        /// <param name="srcSeq">Freeman chain(s) </param>
        /// <param name="storage">Storage location for the resulting polylines. </param>
        /// <param name="method">Approximation method.</param>
        /// <param name="parameter">Method parameter (not used now). </param>
        /// <param name="minimalPerimeter">Approximates only those contours whose perimeters are not less than minimal_perimeter. Other chains are removed from the resulting structure. </param>
        /// <param name="recursive">If true, the function approximates all chains that access can be obtained to from src_seq by h_next or v_next links. If false, the single chain is approximated. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> ApproxChains(CvChain srcSeq, CvMemStorage storage, ContourChain method, double parameter, int minimalPerimeter, bool recursive)
        {
            if (srcSeq == null)
                throw new ArgumentNullException("srcSeq");
            if (storage == null)
                throw new ArgumentNullException("storage");
            IntPtr resultPtr = CvInvoke.cvApproxChains(srcSeq.CvPtr, storage.CvPtr, method, parameter, minimalPerimeter, recursive);
            if (resultPtr == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                CvSeq<CvPoint> result = new CvSeq<CvPoint>(resultPtr);
                return result;
            }
        }
        #endregion
        #region ApproxPoly
#if LANG_JP
        /// <summary>
        /// 指定した精度でポリラインを近似する
        /// </summary>
        /// <param name="srcSeq">点のシーケンスまたは配列</param>
        /// <param name="headerSize">近似されたポリラインのヘッダサイズ．</param>
        /// <param name="storage">近似された輪郭の保存場所．nullの場合，入力シーケンスのストレージが使われる． </param>
        /// <param name="method">近似方法</param>
        /// <param name="parameter">近似方法に依存するパラメータ．CV_POLY_APPROX_DPの場合には，要求する近似精度である．</param>
        /// <returns>単一もしくは複数の近似曲線を計算した結果</returns>
#else
        /// <summary>
        /// Approximates polygonal curve(s) with desired precision.
        /// </summary>
        /// <param name="srcSeq">Sequence of array of points. </param>
        /// <param name="headerSize">Header size of approximated curve[s]. </param>
        /// <param name="storage">Container for approximated contours. If it is null, the input sequences' storage is used. </param>
        /// <param name="method">Approximation method; only ApproxPolyMethod.DP is supported, that corresponds to Douglas-Peucker algorithm. </param>
        /// <param name="parameter">Method-specific parameter; in case of CV_POLY_APPROX_DP it is a desired approximation accuracy. </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> ApproxPoly(CvSeq<CvPoint> srcSeq, int headerSize, CvMemStorage storage, ApproxPolyMethod method, double parameter)
        {
            return ApproxPoly(srcSeq, headerSize, storage, method, parameter, false);
        }
#if LANG_JP
        /// <summary>
        /// 指定した精度でポリラインを近似する
        /// </summary>
        /// <param name="srcSeq">点のシーケンスまたは配列</param>
        /// <param name="headerSize">近似されたポリラインのヘッダサイズ．</param>
        /// <param name="storage">近似された輪郭の保存場所．nullの場合，入力シーケンスのストレージが使われる． </param>
        /// <param name="method">近似方法</param>
        /// <param name="parameter">近似方法に依存するパラメータ．CV_POLY_APPROX_DPの場合には，要求する近似精度である．</param>
        /// <param name="parameter2">src_seqが点の配列（CvMat）の場合， このパラメータは輪郭が閉じている（parameter2=true）か，開いているか(parameter2=false)を指定する．</param>
        /// <returns>単一もしくは複数の近似曲線を計算した結果</returns>
#else
        /// <summary>
        /// Approximates polygonal curve(s) with desired precision.
        /// </summary>
        /// <param name="srcSeq">Sequence of array of points. </param>
        /// <param name="headerSize">Header size of approximated curve[s]. </param>
        /// <param name="storage">Container for approximated contours. If it is null, the input sequences' storage is used. </param>
        /// <param name="method">Approximation method; only ApproxPolyMethod.DP is supported, that corresponds to Douglas-Peucker algorithm. </param>
        /// <param name="parameter">Method-specific parameter; in case of CV_POLY_APPROX_DP it is a desired approximation accuracy. </param>
        /// <param name="parameter2">If case if src_seq is sequence it means whether the single sequence should be approximated 
        /// or all sequences on the same level or below src_seq (see cvFindContours for description of hierarchical contour structures). 
        /// And if src_seq is array (CvMat*) of points, the parameter specifies whether the curve is closed (parameter2==true) or not (parameter2==false). </param>
        /// <returns></returns>
#endif
        public static CvSeq<CvPoint> ApproxPoly(CvSeq<CvPoint> srcSeq, int headerSize, CvMemStorage storage, ApproxPolyMethod method, double parameter, bool parameter2)
        {
            if (srcSeq == null)
            {
                throw new ArgumentNullException("srcSeq");
            }
            IntPtr storagePtr = (storage == null) ? IntPtr.Zero : storage.CvPtr;
            IntPtr result = CvInvoke.cvApproxPoly(srcSeq.CvPtr, headerSize, storagePtr, method, parameter, parameter2);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvPoint>(result);
        }
        #endregion
        #region ArcLength
#if LANG_JP
        /// <summary>
        /// 輪郭の周囲長または曲線の長さを計算する
        /// </summary>
        /// <param name="curve">配列</param>
        /// <returns>輪郭の周囲長または曲線の長さ</returns>
#else
        /// <summary>
        /// Calculates contour perimeter or curve length
        /// </summary>
        /// <param name="curve">Sequence or array of the curve points. </param>
        /// <returns></returns>
#endif
        public static double ArcLength(CvArr curve)
        {
            return ArcLength(curve, CvSlice.WholeSeq, -1);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭の周囲長または曲線の長さを計算する
        /// </summary>
        /// <param name="curve">配列</param>
        /// <param name="slice">曲線の始点と終点．デフォルトでは曲線の全ての長さが計算される．</param>
        /// <returns>輪郭の周囲長または曲線の長さ</returns>
#else
        /// <summary>
        /// Calculates contour perimeter or curve length
        /// </summary>
        /// <param name="curve">Sequence or array of the curve points. </param>
        /// <param name="slice">Starting and ending points of the curve, by default the whole curve length is calculated. </param>
        /// <returns></returns>
#endif
        public static double ArcLength(CvArr curve, CvSlice slice)
        {
            return ArcLength(curve, slice, -1);
        }
#if LANG_JP
        /// <summary>
        /// 輪郭の周囲長または曲線の長さを計算する
        /// </summary>
        /// <param name="curve">配列</param>
        /// <param name="slice">曲線の始点と終点．デフォルトでは曲線の全ての長さが計算される．</param>
        /// <param name="isClosed">閉曲線かどうかを示す．次の3つの状態がある： 
        /// is_closed=0 - 曲線は閉曲線として扱われない． 
        /// is_closed&gt;0 - 曲線は閉曲線として扱われる． 
        /// is_closed&lt;0 - 曲線がシーケンスの場合， ((CvSeq*)curve)-&gt;flagsのフラグCV_SEQ_FLAG_CLOSEDから閉曲線かどうかを判別する．そうでない（曲線が点の配列（CvMat*）で表現される）場合，閉曲線として扱われない． 
        /// </param>
        /// <returns>輪郭の周囲長または曲線の長さ</returns>
#else
        /// <summary>
        /// Calculates contour perimeter or curve length
        /// </summary>
        /// <param name="curve">Sequence or array of the curve points. </param>
        /// <param name="slice">Starting and ending points of the curve, by default the whole curve length is calculated. </param>
        /// <param name="isClosed">Indicates whether the curve is closed or not. There are 3 cases:
        /// * is_closed=0 - the curve is assumed to be unclosed.
        /// * is_closed&gt;0 - the curve is assumed to be closed.
        /// * is_closed&lt;0 - if curve is sequence, the flag CV_SEQ_FLAG_CLOSED of ((CvSeq*)curve)-&gt;flags is checked to determine if the curve is closed or not, otherwise (curve is represented by array (CvMat*) of points) it is assumed to be unclosed. </param>
        /// <returns></returns>
#endif
        public static double ArcLength(CvArr curve, CvSlice slice, int isClosed)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("curve");
            }
            return CvInvoke.cvArcLength(curve.CvPtr, slice, isClosed);
        }
        #endregion
        #region AttrList
#if LANG_JP
        /// <summary>
        /// 構造体CvAttrListの初期化
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// initializes CvAttrList structure
        /// </summary>
        /// <returns></returns>
#endif
        public static CvAttrList AttrList()
        {
            return new CvAttrList();
        }
#if LANG_JP
        /// <summary>
        /// 構造体CvAttrListの初期化
        /// </summary>
        /// <param name="attr">(attribute_name,attribute_value)のペアからなる配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// initializes CvAttrList structure
        /// </summary>
        /// <param name="attr">array of (attribute_name,attribute_value) pairs</param>
        /// <returns></returns>
#endif
        public static CvAttrList AttrList(string[] attr)
        {
            return new CvAttrList(attr);
        }
#if LANG_JP
        /// <summary>
        /// 構造体CvAttrListの初期化
        /// </summary>
        /// <param name="attr">(attribute_name,attribute_value)のペアからなる配列</param>
        /// <param name="next">属性リストの次の塊へのポインタ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// initializes CvAttrList structure
        /// </summary>
        /// <param name="attr">array of (attribute_name,attribute_value) pairs</param>
        /// <param name="next">pointer to next chunk of the attributes list</param>
        /// <returns></returns>
#endif
        public static CvAttrList AttrList(string[] attr, Pointer<CvAttrList> next)
        {
            return new CvAttrList(attr, next);
        }
        #endregion
        #region Avg
#if LANG_JP
        /// <summary>
        /// 配列要素の平均値を各チャンネルで独立に計算する．
        /// </summary>
        /// <param name="arr">配列</param>
        /// <returns>平均値</returns>
#else
        /// <summary>
        /// Calculates average (mean) of array elements
        /// </summary>
        /// <param name="arr">The array. </param>
        /// <returns></returns>
#endif
        public static CvScalar Avg(CvArr arr)
        {
            return Avg(arr, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列要素の平均値を各チャンネルで独立に計算する．
        /// </summary>
        /// <param name="arr">配列</param>
        /// <param name="mask">オプションの処理マスク</param>
        /// <returns>平均値</returns>
#else
        /// <summary>
        /// Calculates average (mean) of array elements
        /// </summary>
        /// <param name="arr">The array. </param>
        /// <param name="mask">The optional operation mask. </param>
        /// <returns></returns>
#endif
        public static CvScalar Avg(CvArr arr, CvArr mask)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            return CvInvoke.cvAvg(arr.CvPtr, maskPtr);
        }
        #endregion
        #region AvgSdv
#if LANG_JP
        /// <summary>
        /// 配列要素の平均と標準偏差を各チャンネルで独立に計算する．
        /// </summary>
        /// <param name="arr">配列</param>
        /// <param name="mean">計算結果の平均値の出力</param>
        /// <param name="stdDev">計算結果の標準偏差の出力</param>
#else
        /// <summary>
        /// Calculates average (mean) of array elements
        /// </summary>
        /// <param name="arr">The array. </param>
        /// <param name="mean">Pointer to the mean value, may be null if it is not needed. </param>
        /// <param name="stdDev">Pointer to the standard deviation. </param>
#endif
        public static void AvgSdv(CvArr arr, out CvScalar mean, out CvScalar stdDev)
        {
            AvgSdv(arr, out mean, out stdDev, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列要素の平均と標準偏差を各チャンネルで独立に計算する．
        /// </summary>
        /// <param name="arr">配列</param>
        /// <param name="mean">計算結果の平均値の出力</param>
        /// <param name="stdDev">計算結果の標準偏差の出力</param>
        /// <param name="mask">オプションの処理マスク</param>
#else
        /// <summary>
        /// Calculates average (mean) of array elements
        /// </summary>
        /// <param name="arr">The array. </param>
        /// <param name="mean">Pointer to the mean value, may be null if it is not needed. </param>
        /// <param name="stdDev">Pointer to the standard deviation. </param>
        /// <param name="mask">The optional operation mask. </param>
#endif
        public static void AvgSdv(CvArr arr, out CvScalar mean, out CvScalar stdDev, CvArr mask)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            mean = new CvScalar();
            stdDev = new CvScalar();
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvAvgSdv(arr.CvPtr, ref mean, ref stdDev, maskPtr);
        }
        #endregion
    }
}