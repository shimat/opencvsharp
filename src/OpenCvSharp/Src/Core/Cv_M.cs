/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
    public static partial class Cv
    {
        #region Mahalanobis
#if LANG_JP
        /// <summary>
        /// 二つのベクトルのマハラノビス距離を計算する
        /// </summary>
        /// <param name="vec1">1番目の1次元入力ベクトル．</param>
        /// <param name="vec2">2番目の1次元入力ベクトル．</param>
        /// <param name="mat">逆共変動行列．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates Mahalanobis distance between two vectors
        /// </summary>
        /// <param name="vec1">The first 1D source vector. </param>
        /// <param name="vec2">The second 1D source vector. </param>
        /// <param name="mat">The inverse covariation matrix. </param>
        /// <returns>Mahalanobis distance</returns>
#endif
        public static double Mahalanobis(CvArr vec1, CvArr vec2, CvArr mat)
        {
            if (vec1 == null)
                throw new ArgumentNullException("vec1");
            if (vec2 == null)
                throw new ArgumentNullException("vec2");
            if (mat == null)
                throw new ArgumentNullException("mat");
            return CvInvoke.cvMahalanobis(vec1.CvPtr, vec2.CvPtr, mat.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 二つのベクトルのマハラノビス距離を計算する
        /// </summary>
        /// <param name="vec1">1番目の1次元入力ベクトル．</param>
        /// <param name="vec2">2番目の1次元入力ベクトル．</param>
        /// <param name="mat">逆共変動行列．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates Mahalonobis distance between two vectors
        /// </summary>
        /// <param name="vec1">The first 1D source vector. </param>
        /// <param name="vec2">The second 1D source vector. </param>
        /// <param name="mat">The inverse covariation matrix. </param>
        /// <returns>Mahalonobis distance</returns>
#endif
        public static double Mahalonobis(CvArr vec1, CvArr vec2, CvArr mat)
        {
            if (vec1 == null)
                throw new ArgumentNullException("vec1");
            if (vec2 == null)
                throw new ArgumentNullException("vec2");
            if (mat == null)
                throw new ArgumentNullException("mat");
            return CvInvoke.cvMahalanobis(vec1.CvPtr, vec2.CvPtr, mat.CvPtr);
        }
        #endregion
        #region MakeHistHeaderForArray
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dims"></param>
        /// <param name="sizes"></param>
        /// <param name="hist"></param>
        /// <param name="data"></param>
#else
        /// <summary>
        /// Makes a histogram out of array
        /// </summary>
        /// <param name="dims">Number of histogram dimensions. </param>
        /// <param name="sizes">Array of histogram dimension sizes. </param>
        /// <param name="hist">The histogram header initialized by the function. </param>
        /// <param name="data">Array that will be used to store histogram bins. </param>
#endif
        public static CvHistogram MakeHistHeaderForArray(int dims, int[] sizes, CvHistogram hist, float[] data)
        {
            return MakeHistHeaderForArray(dims, sizes, hist, data, null);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dims"></param>
        /// <param name="sizes"></param>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        /// <param name="ranges"></param>
#else
        /// <summary>
        /// Makes a histogram out of array
        /// </summary>
        /// <param name="dims">Number of histogram dimensions. </param>
        /// <param name="sizes">Array of histogram dimension sizes. </param>
        /// <param name="hist">The histogram header initialized by the function. </param>
        /// <param name="data">Array that will be used to store histogram bins. </param>
        /// <param name="ranges">Histogram bin ranges, see CreateHist. </param>
#endif
        public static CvHistogram MakeHistHeaderForArray(int dims, int[] sizes, CvHistogram hist, float[] data, float[][] ranges)
        {
            return MakeHistHeaderForArray(dims, sizes, hist, data, ranges, true);
        }
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dims"></param>
        /// <param name="sizes"></param>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        /// <param name="ranges"></param>
        /// <param name="uniform"></param>
#else
        /// <summary>
        /// Makes a histogram out of array
        /// </summary>
        /// <param name="dims">Number of histogram dimensions. </param>
        /// <param name="sizes">Array of histogram dimension sizes. </param>
        /// <param name="hist">The histogram header initialized by the function. </param>
        /// <param name="data">Array that will be used to store histogram bins. </param>
        /// <param name="ranges">Histogram bin ranges, see CreateHist. </param>
        /// <param name="uniform">Uniformity flag, see CreateHist. </param>
#endif
        public static CvHistogram MakeHistHeaderForArray(int dims, int[] sizes, CvHistogram hist, float[] data, float[][] ranges, bool uniform)
        {
            if (ranges == null)
            {
                return new CvHistogram(CvInvoke.cvMakeHistHeaderForArray(dims, sizes, hist.CvPtr, data, IntPtr.Zero, uniform));
            }
            else
            {
                ArrayAddress2<float> rangesPtr = new ArrayAddress2<float>(ranges);
                return new CvHistogram(CvInvoke.cvMakeHistHeaderForArray(dims, sizes, hist.CvPtr, data, rangesPtr, uniform));
            }
        }
        #endregion
        #region MakeScanlines
        #if LANG_JP
        /// <summary>
        /// 基礎行列から二つのカメラ間のスキャンライン座標を計算する
        /// </summary>
        /// <param name="matrix">基礎行列</param>
        /// <param name="imgSize">画像のサイズ</param>
        /// <param name="scanlines1">第1画像の計算されたスキャンラインが格納される配列へのポインタ</param>
        /// <param name="scanlines2">第2画像の計算されたスキャンラインが格納される配列へのポインタ</param>
        /// <param name="lengths1">第1画像スキャンラインの長さ（ピクセル単位）が格納される配列へのポインタ</param>
        /// <param name="lengths2">第2画像スキャンラインの長さ（ピクセル単位）が格納される配列へのポインタ</param>
        /// <param name="lineCount">スキャンライン数を格納する変数へのポインタ</param>
#else
        /// <summary>
        /// Calculates scanlines coordinates for two cameras by fundamental matrix
        /// </summary>
        /// <param name="matrix">Fundamental matrix. </param>
        /// <param name="imgSize">Size of the image. </param>
        /// <param name="scanlines1">Array of calculated scanlines of the first image. </param>
        /// <param name="scanlines2">Array of calculated scanlines of the second image. </param>
        /// <param name="lengths1">Array of calculated lengths (in pixels) of the first image scanlines. </param>
        /// <param name="lengths2">Array of calculated lengths (in pixels) of the second image scanlines. </param>
        /// <param name="lineCount">Variable that stores the number of scanlines. </param>
#endif
        public static void MakeScanlines(double[,] matrix, CvSize imgSize, int[] scanlines1, int[] scanlines2, int[] lengths1, int[] lengths2, out int lineCount)
        {
            CvInvoke.cvMakeScanlines(matrix, imgSize, scanlines1, scanlines2, lengths1, lengths2, out lineCount);
        }
        #endregion
        #region MakeSeqHeaderForArray
#if LANG_JP
        /// <summary>
        /// 配列からシーケンスを生成する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seqType">生成するシーケンスのタイプ．</param>
        /// <param name="headerSize">シーケンスヘッダのサイズ．パラメータseqは，このヘッダと同じサイズか，これより大きい構造体へのポインタを指していなければならない．</param>
        /// <param name="elemSize">シーケンス要素のサイズ．</param>
        /// <param name="elements">シーケンスを構成する要素．</param>
        /// <param name="seq">シーケンスヘッダとして用いられるローカル変数へのポインタ． </param>
        /// <param name="block">単一シーケンスブロックのヘッダを示すローカル変数へのポインタ． </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Constructs sequence from array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seqType">Type of the created sequence. </param>
        /// <param name="headerSize">Size of the header of the sequence. Parameter sequence must point to the structure of that size or greater size. </param>
        /// <param name="elemSize">Size of the sequence element. </param>
        /// <param name="elements">Elements that will form a sequence. </param>
        /// <param name="seq">Pointer to the local variable that is used as the sequence header. </param>
        /// <param name="block">Pointer to the local variable that is the header of the single sequence block. </param>
        /// <returns></returns>
#endif
        public static CvSeq MakeSeqHeaderForArray<T>(SeqType seqType, int headerSize, int elemSize, T[] elements, CvSeq seq, CvSeqBlock block) where T : struct
        {
            if (seq == null)
                throw new ArgumentNullException("seq");
            if (block == null)
                throw new ArgumentNullException("block");
            if (elements == null)
                throw new ArgumentNullException("elements");
            int total = elements.Length;
            using (var elementsPtr = new ArrayAddress1<T>(elements))
            {
                IntPtr result = CvInvoke.cvMakeSeqHeaderForArray(seqType, headerSize, elemSize, elementsPtr, total, seq.CvPtr, block.CvPtr);
                return new CvSeq(result);
            }
        }
        #endregion
        #region Mat
#if LANG_JP
        /// <summary>
        /// 行列ヘッダを初期化する（軽量版）
        /// </summary>
        /// <param name="rows">画像の幅と高さ</param>
        /// <param name="cols">画像のカラーデプス</param>
        /// <param name="type">チャンネル数</param>
        /// <returns>初期化された行列ヘッダ</returns>
#else
        /// <summary>
        /// Initializes matrix header (light-weight variant)
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements (see CreateMat). </param>
        /// <returns>The function cvMat is a fast inline substitution for cvInitMatHeader. </returns>
#endif
        public static CvMat Mat(int rows, int cols, MatrixType type)
        {
            return new CvMat(rows, cols, type);
        }
#if LANG_JP
        /// <summary>
        /// 行列ヘッダを初期化する（軽量版）
        /// </summary>
        /// <param name="rows">画像の幅と高さ</param>
        /// <param name="cols">画像のカラーデプス</param>
        /// <param name="type">チャンネル数</param>
        /// <param name="data">行列のヘッダで指定されるデータ配列. 長さがrows*cols*channelsの1次元配列を指定する.</param>
        /// <returns>初期化された行列ヘッダ</returns>
#else
        /// <summary>
        /// Initializes matrix header (light-weight variant)
        /// </summary>
        /// <param name="rows">Number of rows in the matrix. </param>
        /// <param name="cols">Number of columns in the matrix. </param>
        /// <param name="type">Type of the matrix elements (see CreateMat). </param>
        /// <param name="data">Optional data pointer assigned to the matrix header. </param>
        /// <returns>The function cvMat is a fast inline substitution for cvInitMatHeader. </returns>
#endif
        public static CvMat Mat<T>(int rows, int cols, MatrixType type, T[] data) where T : struct
        {
            return new CvMat(rows, cols, type, data);
        }
        #endregion
        #region MatchContourTrees
#if LANG_JP
        /// <summary>
        /// ツリー表現を使って2つの輪郭を比較する
        /// </summary>
        /// <param name="tree1">一つ目の輪郭の二分木.</param>
        /// <param name="tree2">二つ目の輪郭の二分木.</param>
        /// <param name="method">類似度．I1のみ利用可能．</param>
        /// <param name="threshold">類似度の閾値.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Compares two contours using their tree representations.
        /// </summary>
        /// <param name="tree1">First contour tree. </param>
        /// <param name="tree2">Second contour tree. </param>
        /// <param name="method">Similarity measure, only I1 is supported. </param>
        /// <param name="threshold">Similarity threshold. </param>
        /// <returns></returns>
#endif
        public static double MatchContourTrees(CvContourTree tree1, CvContourTree tree2, ContourTreesMatchMethod method, double threshold)
        {
            if (tree1 == null)
                throw new ArgumentNullException("tree1");
            if (tree2 == null)
                throw new ArgumentNullException("tree2");
            return CvInvoke.cvMatchContourTrees(tree1.CvPtr, tree2.CvPtr, method, threshold);
        }
        #endregion
        #region MatchShapes
#if LANG_JP
        /// <summary>
        /// 二つの形状を比較する
        /// </summary>
        /// <param name="object1">1番目の輪郭，あるいはグレースケール画像．</param>
        /// <param name="object2">2番目の輪郭，あるいはグレースケール画像．</param>
        /// <param name="method">比較方法.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Compares two shapes.
        /// </summary>
        /// <param name="object1">First contour or grayscale image.</param>
        /// <param name="object2">Second contour or grayscale image.</param>
        /// <param name="method">Comparison method.</param>
        /// <returns></returns>
#endif
        public static double MatchShapes(CvArr object1, CvArr object2, MatchShapesMethod method)
        {
            return MatchShapes(object1, object2, method, 0);
        }
#if LANG_JP
        /// <summary>
        /// 二つの形状を比較する
        /// </summary>
        /// <param name="object1">1番目の輪郭，あるいはグレースケール画像．</param>
        /// <param name="object2">2番目の輪郭，あるいはグレースケール画像．</param>
        /// <param name="method">比較方法.</param>
        /// <param name="parameter">それぞれの比較手法特有のパラメータ（現在未使用）.</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Compares two shapes.
        /// </summary>
        /// <param name="object1">First contour or grayscale image.</param>
        /// <param name="object2">Second contour or grayscale image.</param>
        /// <param name="method">Comparison method.</param>
        /// <param name="parameter">Method-specific parameter (is not used now). </param>
        /// <returns></returns>
#endif
        public static double MatchShapes(CvArr object1, CvArr object2, MatchShapesMethod method, double parameter)
        {
            if (object1 == null)
                throw new ArgumentNullException("object1");
            if (object2 == null)
                throw new ArgumentNullException("object2");
            return CvInvoke.cvMatchShapes(object1.CvPtr, object2.CvPtr, method, parameter);
        }
        #endregion
        #region MatchTemplate
#if LANG_JP
        /// <summary>
        /// テンプレートと重なった画像領域を比較する. 
        /// templを，image全体に対してスライドさせ，それとサイズ w×h で重なる領域とを指定された方法で比較し，その結果を result に保存する． 
        /// </summary>
        /// <param name="image">テンプレートマッチングを行う画像． 8ビットか32ビット浮動小数点型でなければならない．</param>
        /// <param name="templ">探索用テンプレート．画像より大きくてはならない，かつ画像と同じタイプである必要がある． </param>
        /// <param name="result">比較結果のマップ．シングルチャンネルの32ビット浮動小数点型データ．image が W×H で templ が w×h ならば， result は W-w+1×H-h+1のサイズが必要． </param>
        /// <param name="method">テンプレートマッチングの方法（以下を参照）．</param>
#else
        /// <summary>
        /// Compares template against overlapped image regions.
        /// </summary>
        /// <param name="image">Image where the search is running. It should be 8-bit or 32-bit floating-point. </param>
        /// <param name="templ">Searched template; must be not greater than the source image and the same data type as the image. </param>
        /// <param name="result">A map of comparison results; single-channel 32-bit floating-point. If image is W×H and templ is w×h then result must be W-w+1×H-h+1. </param>
        /// <param name="method">Specifies the way the template must be compared with image regions. </param>
#endif
        public static void MatchTemplate(CvArr image, CvArr templ, CvArr result, MatchTemplateMethod method)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (templ == null)
                throw new ArgumentNullException("templ");
            if (result == null)
                throw new ArgumentNullException("result");
            CvInvoke.cvMatchTemplate(image.CvPtr, templ.CvPtr, result.CvPtr, method);
        }
        #endregion
        #region Max
#if LANG_JP
        /// <summary>
        /// 二つの配列の各要素についての最大値を求める. 
        /// dst(I)=max(src1(I), src2(I)) 
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Finds per-element maximum of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Max(CvArr src1, CvArr src2, CvArr dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvMax(src1.CvPtr, src2.CvPtr, dst.CvPtr);
        }
        #endregion
        #region MaxRect
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect1"></param>
        /// <param name="rect2"></param>
#else
        /// <summary>
        /// Finds bounding rectangle for two given rectangles
        /// </summary>
        /// <param name="rect1">First rectangle </param>
        /// <param name="rect2">Second rectangle </param>
#endif
        public static CvRect MaxRect(CvRect rect1, CvRect rect2)
        {
            return CvInvoke.cvMaxRect(ref rect1, ref rect2);
        }
        #endregion
        #region MaxS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーについての最大値を求める. 
        /// dst(I)=max(src(I), value) 
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="value">スカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Finds per-element maximum of array and scalar
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="value">The scalar value. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void MaxS(CvArr src, double value, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvMaxS(src.CvPtr, value, dst.CvPtr);
        }
        #endregion
        #region MeanShift
#if LANG_JP
        /// <summary>
        /// バックプロジェクションでのオブジェクトの中心を検出する
        /// </summary>
        /// <param name="probImage">オブジェクトヒストグラムのバックプロジェクション</param>
        /// <param name="window">初期探索ウィンドウ</param>
        /// <param name="criteria">ウィンドウ探索を終了するための条件</param>
        /// <param name="comp">結果として得られる構造体．収束した探索ウィンドウの座標（comp->rect フィールド），および ウィンドウ内の全ピクセルの合計値（comp->area フィールド）が含まれる．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Finds object center on back projection
        /// </summary>
        /// <param name="probImage">Back projection of object histogram (see cvCalcBackProject). </param>
        /// <param name="window">Initial search window. </param>
        /// <param name="criteria">Criteria applied to determine when the window search should be finished. </param>
        /// <param name="comp">Resultant structure that contains converged search window coordinates (comp->rect field) and sum of all pixels inside the window (comp->area field). </param>
        /// <returns>The function returns number of iterations made within cvMeanShift. </returns>
#endif
        public static int MeanShift(CvArr probImage, CvRect window, CvTermCriteria criteria, CvConnectedComp comp)
        {
            if (probImage == null)
            {
                throw new ArgumentNullException("probImage");
            }
            if (comp == null)
            {
                throw new ArgumentNullException("comp");
            }
            return CvInvoke.cvMeanShift(probImage.CvPtr, window, criteria, comp.CvPtr);
        }
        #endregion
        #region MemStorageAlloc
#if LANG_JP
        /// <summary>
        /// ストレージ内にメモリバッファを確保する
        /// </summary>
        /// <param name="storage">ストレージへの参照</param>
        /// <param name="size">バッファサイズ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates memory buffer in the storage
        /// </summary>
        /// <param name="storage">Memory storage. </param>
        /// <param name="size">Buffer size. </param>
        /// <returns></returns>
#endif
        public static IntPtr MemStorageAlloc(CvMemStorage storage, uint size)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            return CvInvoke.cvMemStorageAlloc(storage.CvPtr, size);
        }
        #endregion
        #region MemStorageAllocString
#if LANG_JP
        /// <summary>
        /// ストレージ内にテキスト文字列を確保する
        /// </summary>
        /// <param name="storage">メモリストレージ</param>
        /// <param name="str">文字列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates text string in the storage
        /// </summary>
        /// <param name="storage">Memory storage</param>
        /// <param name="str">The string</param>
        /// <returns></returns>
#endif
        public static CvString MemStorageAllocString(CvMemStorage storage, string str)
        {
            if (storage == null)
                throw new ArgumentNullException("storage");
            if (str == null)
                throw new ArgumentNullException("str");
            unsafe
            {
                fixed (char* strPtr = str)
                {
                    return CvInvoke.cvMemStorageAllocString(storage.CvPtr, strPtr, str.Length);
                }
            }
        }
        #endregion
        #region Merge
#if LANG_JP
        /// <summary>
        /// 複数のシングルチャンネルの配列からマルチチャンネル配列を構成する．または，配列に一つのシングルチャンネルを挿入する
        /// </summary>
        /// <param name="src0">入力配列1</param>
        /// <param name="src1">入力配列2</param>
        /// <param name="src2">入力配列3</param>
        /// <param name="src3">入力配列4</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Composes multi-channel array from several single-channel arrays or inserts a single channel into the array
        /// </summary>
        /// <param name="src0">Input channel 0</param>
        /// <param name="src1">Input channel 1</param>
        /// <param name="src2">Input channel 2</param>
        /// <param name="src3">Input channel 3</param>
        /// <param name="dst">Destination array. </param>
#endif
        public static void Merge(CvArr src0, CvArr src1, CvArr src2, CvArr src3, CvArr dst)
        {
            if (dst == null)
            {
                throw new ArgumentNullException("dst");
            }
            IntPtr p0 = (src0 == null) ? IntPtr.Zero : src0.CvPtr;
            IntPtr p1 = (src1 == null) ? IntPtr.Zero : src1.CvPtr;
            IntPtr p2 = (src2 == null) ? IntPtr.Zero : src2.CvPtr;
            IntPtr p3 = (src3 == null) ? IntPtr.Zero : src3.CvPtr;
            CvInvoke.cvMerge(p0, p1, p2, p3, dst.CvPtr);
        }
#if LANG_JP
        /// <summary>
        /// 複数のシングルチャンネルの配列からマルチチャンネル配列を構成する．または，配列に一つのシングルチャンネルを挿入する
        /// </summary>
        /// <param name="src0">入力配列1</param>
        /// <param name="src1">入力配列2</param>
        /// <param name="src2">入力配列3</param>
        /// <param name="src3">入力配列4</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Composes multi-channel array from several single-channel arrays or inserts a single channel into the array
        /// </summary>
        /// <param name="src0">Input channel 0</param>
        /// <param name="src1">Input channel 1</param>
        /// <param name="src2">Input channel 2</param>
        /// <param name="src3">Input channel 3</param>
        /// <param name="dst">Destination array. </param>
#endif
        public static void CvtPlaneToPix(CvArr src0, CvArr src1, CvArr src2, CvArr src3, CvArr dst)
        {
            Merge(src0, src1, src2, src3, dst);
        }
        #endregion
        #region mGet
#if LANG_JP
        /// <summary>
        /// シングルチャンネル浮動小数点型行列の特定の要素を返す. cvGetReal2Dの高速化版関数である．
        /// </summary>
        /// <param name="mat">入力行列</param>
        /// <param name="row">行の0を基準としたインデックス</param>
        /// <param name="col">列の0を基準としたインデックス</param>
        /// <returns>指定した要素の値</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel floating-point matrix
        /// </summary>
        /// <param name="mat">Input matrix. </param>
        /// <param name="row">The zero-based index of row. </param>
        /// <param name="col">The zero-based index of column. </param>
        /// <returns></returns>
#endif
        public static double mGet(CvMat mat, int row, int col)
        {
#if DEBUG
            if ((uint)row >= (uint)mat.Rows || (uint)col >= (uint)mat.Cols)
            {
                throw new ArgumentOutOfRangeException();
            }
#endif
            unsafe
            {
                switch (MAT_TYPE(mat.Type))
                {
                    case CvConst.CV_32FC1:
                        return ((float*)(mat.DataByte + (uint)mat.Step * row))[col];
                    case CvConst.CV_64FC1:
                        return ((double*)(mat.DataByte + (uint)mat.Step * row))[col];

                    case CvConst.CV_32SC1:
                        return ((int*)(mat.DataByte + (uint)mat.Step * row))[col];
                    case CvConst.CV_16UC1:
                        return ((ushort*)(mat.DataByte + (uint)mat.Step * row))[col];
                    case CvConst.CV_16SC1:
                        return ((short*)(mat.DataByte + (uint)mat.Step * row))[col];
                    case CvConst.CV_8SC1:
                        return ((sbyte*)(mat.DataByte + (uint)mat.Step * row))[col];
                    case CvConst.CV_8UC1:
                        return ((byte*)(mat.DataByte + (uint)mat.Step * row))[col];

                    default:
                        throw new OpenCvSharpException("Cv.mGet supports only single-channel matrix.");
                }
            }
        }
        #endregion
        #region Min
#if LANG_JP
        /// <summary>
        /// 二つの配列の各要素についての最小値を求める. 
        /// dst(I)=min(src1(I), src2(I)) 
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Finds per-element minimum of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Min(CvArr src1, CvArr src2, CvArr dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvMin(src1.CvPtr, src2.CvPtr, dst.CvPtr);
        }
        #endregion
        #region MinMaxLoc
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="arr">入力配列（シングルチャンネルまたはCOIがセットされたマルチチャンネル）</param>
        /// <param name="minVal">戻り値の最小値</param>
        /// <param name="maxVal">戻り値の最大値</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="arr">The source array, single-channel or multi-channel with COI set. </param>
        /// <param name="minVal">Pointer to returned minimum value. </param>
        /// <param name="maxVal">Pointer to returned maximum value. </param>
#endif
        public static void MinMaxLoc(CvArr arr, out double minVal, out double maxVal)
        {
            CvPoint minLoc, maxLoc;
            MinMaxLoc(arr, out minVal, out maxVal, out minLoc, out maxLoc, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="arr">入力配列（シングルチャンネルまたはCOIがセットされたマルチチャンネル）</param>
        /// <param name="minVal">戻り値の最小値</param>
        /// <param name="maxVal">戻り値の最大値</param>
        /// <param name="mask">部分配列を指定するためのオプションのマスク</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="arr">The source array, single-channel or multi-channel with COI set. </param>
        /// <param name="minVal">Pointer to returned minimum value. </param>
        /// <param name="maxVal">Pointer to returned maximum value. </param>
        /// <param name="mask">The optional mask that is used to select a subarray. </param>
#endif
        public static void MinMaxLoc(CvArr arr, out double minVal, out double maxVal, CvArr mask)
        {
            CvPoint minLoc, maxLoc;
            MinMaxLoc(arr, out minVal, out maxVal, out minLoc, out maxLoc, mask);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="arr">入力配列（シングルチャンネルまたはCOIがセットされたマルチチャンネル）</param>
        /// <param name="minLoc">戻り値の最小値を持つ位置</param>
        /// <param name="maxLoc">戻り値の最大値を持つ位置</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="arr">The source array, single-channel or multi-channel with COI set. </param>
        /// <param name="minLoc">Pointer to returned minimum location. </param>
        /// <param name="maxLoc">Pointer to returned maximum location. </param>
#endif
        public static void MinMaxLoc(CvArr arr, out CvPoint minLoc, out CvPoint maxLoc)
        {
            double minVal, maxVal;
            MinMaxLoc(arr, out minVal, out maxVal, out minLoc, out maxLoc, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="arr">入力配列（シングルチャンネルまたはCOIがセットされたマルチチャンネル）</param>
        /// <param name="minLoc">戻り値の最小値を持つ位置</param>
        /// <param name="maxLoc">戻り値の最大値を持つ位置</param>
        /// <param name="mask">部分配列を指定するためのオプションのマスク</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="arr">The source array, single-channel or multi-channel with COI set. </param>
        /// <param name="minLoc">Pointer to returned minimum location. </param>
        /// <param name="maxLoc">Pointer to returned maximum location. </param>
        /// <param name="mask">The optional mask that is used to select a subarray. </param>
#endif
        public static void MinMaxLoc(CvArr arr, out CvPoint minLoc, out CvPoint maxLoc, CvArr mask)
        {
            double minVal, maxVal;
            MinMaxLoc(arr, out minVal, out maxVal, out minLoc, out maxLoc, mask);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="arr">入力配列（シングルチャンネルまたはCOIがセットされたマルチチャンネル）</param>
        /// <param name="minVal">戻り値の最小値</param>
        /// <param name="maxVal">戻り値の最大値</param>
        /// <param name="minLoc">戻り値の最小値を持つ位置</param>
        /// <param name="maxLoc">戻り値の最大値を持つ位置</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="arr">The source array, single-channel or multi-channel with COI set. </param>
        /// <param name="minVal">Pointer to returned minimum value. </param>
        /// <param name="maxVal">Pointer to returned maximum value. </param>
        /// <param name="minLoc">Pointer to returned minimum location. </param>
        /// <param name="maxLoc">Pointer to returned maximum location. </param>
#endif
        public static void MinMaxLoc(CvArr arr, out double minVal, out double maxVal, out CvPoint minLoc, out CvPoint maxLoc)
        {
            MinMaxLoc(arr, out minVal, out maxVal, out minLoc, out maxLoc, null);
        }
#if LANG_JP
        /// <summary>
        /// 配列あるいは部分配列内の最小値と最大値を求める
        /// </summary>
        /// <param name="arr">入力配列（シングルチャンネルまたはCOIがセットされたマルチチャンネル）</param>
        /// <param name="minVal">戻り値の最小値</param>
        /// <param name="maxVal">戻り値の最大値</param>
        /// <param name="minLoc">戻り値の最小値を持つ位置</param>
        /// <param name="maxLoc">戻り値の最大値を持つ位置</param>
        /// <param name="mask">部分配列を指定するためのオプションのマスク</param>
#else
        /// <summary>
        /// Finds global minimum and maximum in array or subarray
        /// </summary>
        /// <param name="arr">The source array, single-channel or multi-channel with COI set. </param>
        /// <param name="minVal">Pointer to returned minimum value. </param>
        /// <param name="maxVal">Pointer to returned maximum value. </param>
        /// <param name="minLoc">Pointer to returned minimum location. </param>
        /// <param name="maxLoc">Pointer to returned maximum location. </param>
        /// <param name="mask">The optional mask that is used to select a subarray. </param>
#endif
        public static void MinMaxLoc(CvArr arr, out double minVal, out double maxVal, out CvPoint minLoc, out CvPoint maxLoc, CvArr mask)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            minVal = 0;
            maxVal = 0;
            minLoc = new CvPoint();
            maxLoc = new CvPoint();
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvMinMaxLoc(arr.CvPtr, ref minVal, ref maxVal, ref minLoc, ref maxLoc, maskPtr);
        }
        #endregion
        #region MinAreaRect2
#if LANG_JP
        /// <summary>
        /// 与えられた2次元の点列を囲む最小矩形を求める
        /// </summary>
        /// <param name="points">点のシーケンスまたは配列</param>
        /// <returns>2次元の点列に対する最小矩形</returns>
#else
        /// <summary>
        /// Finds circumscribed rectangle of minimal area for given 2D point set
        /// </summary>
        /// <param name="points">Sequence or array of points. </param>
        /// <returns>The function cvMinAreaRect2 finds a circumscribed rectangle of the minimal area for 2D point set by building convex hull for the set and applying rotating calipers technique to the hull.</returns> 
#endif
        public static CvBox2D MinAreaRect2(CvArr points)
        {
            return MinAreaRect2(points, null);
        }
#if LANG_JP
        /// <summary>
        /// 与えられた2次元の点列を囲む最小矩形を求める
        /// </summary>
        /// <param name="points">点のシーケンスまたは配列</param>
        /// <param name="storage">一時的なメモリストレージ</param>
        /// <returns>2次元の点列に対する最小矩形</returns>
#else
        /// <summary>
        /// Finds circumscribed rectangle of minimal area for given 2D point set
        /// </summary>
        /// <param name="points">Sequence or array of points. </param>
        /// <param name="storage">The point tested against the contour.</param>
        /// <returns>The function cvMinAreaRect2 finds a circumscribed rectangle of the minimal area for 2D point set by building convex hull for the set and applying rotating calipers technique to the hull.</returns> 
#endif
        public static CvBox2D MinAreaRect2(CvArr points, CvMemStorage storage)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            IntPtr storagePtr = (storage == null) ? IntPtr.Zero : storage.CvPtr;
            return CvInvoke.cvMinAreaRect2(points.CvPtr, storagePtr);
        }
        #endregion
        #region MinEnclosingCircle
#if LANG_JP
        /// <summary>
        /// 与えられた2次元の点列を囲む最小円を求める
        /// </summary>
        /// <param name="points">2次元の点のシーケンスまたは配列．</param>
        /// <param name="center">出力パラメータ．囲む円の中心．</param>
        /// <param name="radius">出力パラメータ．囲む円の半径．</param>
        /// <returns>結果の円が全ての入力点を含む場合はtrueを返し， それ以外（すなわちアルゴリズムの失敗）の場合はfalseを返す．</returns>
#else
        /// <summary>
        /// Finds circumscribed rectangle of minimal area for given 2D point set
        /// </summary>
        /// <param name="points">Sequence or array of 2D points. </param>
        /// <param name="center">Output parameter. The center of the enclosing circle. </param>
        /// <param name="radius">Output parameter. The radius of the enclosing circle. </param>
        /// <returns>The function cvMinEnclosingCircle finds the minimal circumscribed circle for 2D point set using iterative algorithm. 
        /// It returns true if the resultant circle contains all the input points and false otherwise (i.e. algorithm failed). </returns> 
#endif
        public static bool MinEnclosingCircle(CvArr points, out CvPoint2D32f center, out float radius)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            center = new CvPoint2D32f();
            radius = default(float);
            return CvInvoke.cvMinEnclosingCircle(points.CvPtr, ref center, ref radius);
        }
        #endregion
        #region MinS
#if LANG_JP
        /// <summary>
        /// 配列の各要素とスカラーについての最小値を求める. 
        /// dst(I)=min(src(I), value) 
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="value">スカラー</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Finds per-element minimum of array and scalar
        /// </summary>
        /// <param name="src">The first source array. </param>
        /// <param name="value">The scalar value. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void MinS(CvArr src, double value, CvArr dst)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvMinS(src.CvPtr, value, dst.CvPtr);
        }
        #endregion
        #region MixChannels
#if LANG_JP
        /// <summary>
        /// 入力配列のチャンネルを出力配列の指定されたチャンネルにコピーする
        /// </summary>
        /// <param name="src">入力配列の配列</param>
        /// <param name="dst">出力配列の配列</param>
        /// <param name="fromTo">コピーされる平面（チャンネル）のインデックスのペア配列． from_to[k*2]は入力平面の0を基準としたインデックスで，from_to[k*2+1]は出力平面のインデックス．ここで，入力及び出力配列すべてについて，各平面への連続的な番号付けが行われる．from_to[k*2]が負のとき，対応する出力平面は0で埋められる．</param>
#else
        /// <summary>
        /// Copies several channels from input arrays to certain channels of output arrays
        /// </summary>
        /// <param name="src">The array of input arrays. </param>
        /// <param name="dst">The array of output arrays. </param>
        /// <param name="fromTo">The array of pairs of indices of the planes copied. from_to[k*2] is the 0-based index of the input plane, and from_to[k*2+1] is the index of the output plane, where the continuous numbering of the planes over all the input and over all the output arrays is used. When from_to[k*2] is negative, the corresponding output plane is filled with 0's. </param>
#endif
        public static void MixChannels(CvArr[] src, CvArr[] dst, int[] fromTo)
        {
            if (src == null || src.Length == 0)
                throw new ArgumentNullException("src");
            if (dst == null || dst.Length == 0)
                throw new ArgumentNullException("dst");
            if (fromTo == null)
                throw new ArgumentNullException("fromTo");

            IntPtr[] srcPtr = new IntPtr[src.Length];
            IntPtr[] dstPtr = new IntPtr[dst.Length];
            for (int i = 0; i < src.Length; i++)
                srcPtr[i] = src[i].CvPtr;
            for (int i = 0; i < dst.Length; i++)
                dstPtr[i] = dst[i].CvPtr;
            int pairCount = fromTo.Length / 2;

            CvInvoke.cvMixChannels(srcPtr, src.Length, dstPtr, dst.Length, fromTo, pairCount);
        }
        #endregion
        #region Moments
#if LANG_JP
        /// <summary>
        /// ポリゴンまたはラスタ形状の３次までのモーメントを計算する
        /// </summary>
        /// <param name="image">画像（1チャンネル，あるいはCOIをもつ3チャンネル画像） あるいはポリゴン （CvSeqで表される点群，または点のベクトル）．</param>
        /// <param name="moments">画像モーメントを表す構造体への参照</param>
        /// <param name="isBinary">（画像の場合のみ）このフラグがtrueの場合，値0のピクセルは0として，その他のピクセル値は1として扱われる． </param>
#else
        /// <summary>
        /// Moments
        /// </summary>
        /// <param name="image">Image (1-channel or 3-channel with COI set) or polygon (CvSeq of points or a vector of points)</param>
        /// <param name="moments">Returned moment state structure</param>
        /// <param name="isBinary">(For images only) If the flag is non-zero, all the zero pixel values are treated as zeroes, all the others are treated as 1’s</param>
#endif
        public static void Moments(CvArr image, out CvMoments moments, bool isBinary)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            
            moments = new CvMoments();
            CvInvoke.cvMoments(image.CvPtr, moments, isBinary);
        }
        #endregion
        #region MorphologyEx
#if LANG_JP
        /// <summary>
        /// 高度なモルフォロジー変換を実行する [iterations=1].
        /// 基本の演算として収縮と膨張を（組み合わせて）用いる高度なモルフォロジー変換を行うことができる．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="temp">テンポラリ画像（いくつかの処理で必要とされる）</param>
        /// <param name="element">構造要素</param>
        /// <param name="operation">モルフォロジー演算の種類</param>
#else
        /// <summary>
        /// Performs advanced morphological transformations using erosion and dilation as basic operations.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="temp">Temporary image, required in some cases. </param>
        /// <param name="element">Structuring element. </param>
        /// <param name="operation">Type of morphological operation.</param>
#endif
        public static void MorphologyEx(CvArr src, CvArr dst, CvArr temp, IplConvKernel element, MorphologyOperation operation)
        {
            MorphologyEx(src, dst, temp, element, operation, 1);
        }
#if LANG_JP
        /// <summary>
        /// 高度なモルフォロジー変換を実行する.
        /// 基本の演算として収縮と膨張を（組み合わせて）用いる高度なモルフォロジー変換を行うことができる．
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="temp">テンポラリ画像（いくつかの処理で必要とされる）</param>
        /// <param name="element">構造要素</param>
        /// <param name="operation">モルフォロジー演算の種類</param>
        /// <param name="iterations">収縮と膨張の繰り返し回数</param>
#else
        /// <summary>
        /// Performs advanced morphological transformations using erosion and dilation as basic operations.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Destination image. </param>
        /// <param name="temp">Temporary image, required in some cases. </param>
        /// <param name="element">Structuring element. </param>
        /// <param name="operation">Type of morphological operation.</param>
        /// <param name="iterations">Number of times erosion and dilation are applied. </param>
#endif
        public static void MorphologyEx(CvArr src, CvArr dst, CvArr temp, IplConvKernel element, MorphologyOperation operation, int iterations)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (temp == null)
                throw new ArgumentNullException("temp");
            CvInvoke.cvMorphologyEx(src.CvPtr, dst.CvPtr, temp.CvPtr, element.CvPtr, operation, iterations);
        }
        #endregion
        #region MoveWindow
#if LANG_JP
        /// <summary>
        /// ウィンドウの位置を変更する
        /// </summary>
        /// <param name="name">位置を変更するウィンドウの名前</param>
        /// <param name="x">左上のコーナーの新しい x 座標</param>
        /// <param name="y">左上のコーナーの新しい y 座標</param>
#else
        /// <summary>
        /// Changes position of the window. 
        /// </summary>
        /// <param name="name">Name of the window to be resized. </param>
        /// <param name="x">New x coordinate of top-left corner </param>
        /// <param name="y">New y coordinate of top-left corner </param>
#endif
        public static void MoveWindow(string name, int x, int y)
        {
            CvInvoke.cvMoveWindow(name, x, y);
        }
        #endregion
        #region MSERParams
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
#endif
        public static CvMSERParams MSERParams()
        {
            return new CvMSERParams();
        }
#if LANG_JP
        /// <summary>
        /// MSERのパラメータを生成する
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="minArea">prune the area which smaller than min_area</param>
        /// <param name="maxArea">prune the area which bigger than max_area</param>
        /// <param name="maxVariation">prune the area have simliar size to its children</param>
        /// <param name="minDiversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="maxEvolution">for color image, the evolution steps</param>
        /// <param name="areaThreshold">the area threshold to cause re-initialize</param>
        /// <param name="minMargin">ignore too small margin</param>
        /// <param name="edgeBlurSize">the aperture size for edge blur</param>
#else
        /// <summary>
        /// Creates MSER parameters
        /// </summary>
        /// <param name="delta">delta, in the code, it compares (size_{i}-size_{i-delta})/size_{i-delta}</param>
        /// <param name="minArea">prune the area which smaller than min_area</param>
        /// <param name="maxArea">prune the area which bigger than max_area</param>
        /// <param name="maxVariation">prune the area have simliar size to its children</param>
        /// <param name="minDiversity">trace back to cut off mser with diversity &lt; min_diversity</param>
        /// <param name="maxEvolution">for color image, the evolution steps</param>
        /// <param name="areaThreshold">the area threshold to cause re-initialize</param>
        /// <param name="minMargin">ignore too small margin</param>
        /// <param name="edgeBlurSize">the aperture size for edge blur</param>
#endif
        public static CvMSERParams MSERParams(int delta, int minArea, int maxArea, float maxVariation, float minDiversity, int maxEvolution, double areaThreshold, double minMargin, int edgeBlurSize)
        {
            return new CvMSERParams(delta, minArea, maxArea, maxVariation, minDiversity, maxEvolution, areaThreshold, minMargin, edgeBlurSize);
        }
        #endregion
        #region mSet
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの浮動小数点型行列の特定の要素の値を変更する.cvSetReal2Dの高速化版関数である．
        /// </summary>
        /// <param name="mat">入力行列</param>
        /// <param name="row">行の0を基準としたインデックス</param>
        /// <param name="col">列の0を基準としたインデックス</param>
        /// <param name="value">行列の要素の新しい値</param>
#else
        /// <summary>
        /// Return the particular element of single-channel floating-point matrix
        /// </summary>
        /// <param name="mat">The matrix. </param>
        /// <param name="row">The zero-based index of row. </param>
        /// <param name="col">The zero-based index of column. </param>
        /// <param name="value">The new value of the matrix element </param>
#endif
        public static void mSet(CvMat mat, int row, int col, double value)
        {
#if DEBUG
            if ((uint)row >= (uint)mat.Rows || (uint)col >= (uint)mat.Cols)
            {
                throw new ArgumentOutOfRangeException();
            }
#endif
            unsafe
            {
                switch (MAT_TYPE(mat.Type))
                {
                    case CvConst.CV_32FC1:
                        ((float*)(mat.DataByte + (uint)mat.Step * row))[col] = (float)value; break;
                    case CvConst.CV_64FC1:
                        ((double*)(mat.DataByte + (uint)mat.Step * row))[col] = (double)value; break;

                    case CvConst.CV_32SC1:
                        ((int*)(mat.DataByte + (uint)mat.Step * row))[col] = (int)value; break;
                    case CvConst.CV_16UC1:
                        ((ushort*)(mat.DataByte + (uint)mat.Step * row))[col] = (ushort)value; break;
                    case CvConst.CV_16SC1:
                        ((short*)(mat.DataByte + (uint)mat.Step * row))[col] = (short)value; break;
                    case CvConst.CV_8SC1:
                        ((sbyte*)(mat.DataByte + (uint)mat.Step * row))[col] = (sbyte)value; break;
                    case CvConst.CV_8UC1:
                        ((byte*)(mat.DataByte + (uint)mat.Step * row))[col] = (byte)value; break;

                    default:
                        throw new OpenCvSharpException("Cv.mSet supports only single-channel matrix.");
                }
            }
        }
        #endregion
        #region Mul
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素同士を乗算する (scale=1).
        /// dst(I) = scale * src1(I) * src2(I)
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Calculates per-element product of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void Mul(CvArr src1, CvArr src2, CvArr dst)
        {
            Mul(src1, src2, dst, 1d);
        }
#if LANG_JP
        /// <summary>
        /// 二つの配列の要素同士を乗算する.
        /// dst(I) = scale * src1(I) * src2(I)
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="scale">任意のスケーリング係数</param>
#else
        /// <summary>
        /// Calculates per-element product of two arrays
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
        /// <param name="scale">Optional scale factor </param>
#endif
        public static void Mul(CvArr src1, CvArr src2, CvArr dst, double scale)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvMul(src1.CvPtr, src2.CvPtr, dst.CvPtr, scale);
        }
        #endregion
        #region MulSpectrums
#if LANG_JP
        /// <summary>
        /// 二つのフーリエスペクトラムの要素ごとの乗算を行う
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">入力配列と同じタイプ・サイズの出力配列</param>
        /// <param name="flags">処理フラグ</param>
#else
        /// <summary>
        /// Performs per-element multiplication of two Fourier spectrums
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array of the same type and the same size of the sources. </param>
        /// <param name="flags"></param>
#endif
        public static void MulSpectrums(CvArr src1, CvArr src2, CvArr dst, MulSpectrumsFlag flags)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvMulSpectrums(src1.CvPtr, src2.CvPtr, dst.CvPtr, flags);
        }
        #endregion
        #region MultiplyAcc
#if LANG_JP
        /// <summary>
        /// アキュムレータに二つの入力画像の積を加算する
        /// </summary>
        /// <param name="image1">1番目の入力画像，1 または 3 チャンネル，8 ビットあるいは 32 ビッ ト浮動小数点型．（マルチチャンネル画像の各チャンネルは，個別に処理される）.</param>
        /// <param name="image2">2番目の入力画像．1番目画像と同様のフォーマット.</param>
        /// <param name="acc">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型.</param>
#else
        /// <summary>
        /// Adds product of two input images to accumulator
        /// </summary>
        /// <param name="image1">First input image, 1- or 3-channel, 8-bit or 32-bit floating point (each channel of multi-channel image is processed independently). </param>
        /// <param name="image2">Second input image, the same format as the first one. </param>
        /// <param name="acc">Accumulator of the same number of channels as input images, 32-bit or 64-bit floating-point. </param>
#endif
        public static void MultiplyAcc(CvArr image1, CvArr image2, CvArr acc)
        {
            MultiplyAcc(image1, image2, acc, null);
        }
#if LANG_JP
        /// <summary>
        /// アキュムレータに二つの入力画像の積を加算する
        /// </summary>
        /// <param name="image1">1番目の入力画像，1 または 3 チャンネル，8 ビットあるいは 32 ビッ ト浮動小数点型．（マルチチャンネル画像の各チャンネルは，個別に処理される）.</param>
        /// <param name="image2">2番目の入力画像．1番目画像と同様のフォーマット.</param>
        /// <param name="acc">入力画像と同じチャンネル数のアキュムレータ，32 ビットあるいは 64 ビット浮動小数点型.</param>
        /// <param name="mask">オプションの処理マスク.</param>
#else
        /// <summary>
        /// Adds product of two input images to accumulator
        /// </summary>
        /// <param name="image1">First input image, 1- or 3-channel, 8-bit or 32-bit floating point (each channel of multi-channel image is processed independently). </param>
        /// <param name="image2">Second input image, the same format as the first one. </param>
        /// <param name="acc">Accumulator of the same number of channels as input images, 32-bit or 64-bit floating-point. </param>
        /// <param name="mask">Optional operation mask. </param>
#endif
        public static void MultiplyAcc(CvArr image1, CvArr image2, CvArr acc, CvArr mask)
        {
            if (image1 == null)
                throw new ArgumentNullException("image1");
            if (image2 == null)
                throw new ArgumentNullException("image2");
            if (acc == null)
                throw new ArgumentNullException("acc");
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;
            CvInvoke.cvMultiplyAcc(image1.CvPtr, image2.CvPtr, acc.CvPtr, maskPtr);
        }
        #endregion
        #region MulTransposed
#if LANG_JP
        /// <summary>
        /// 行列と転置行列の乗算を行う
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">出力行列</param>
        /// <param name="order">転置した行列をかける順番を示すフラグ. falseの場合, dst=(src-delta)*(src-delta)^T, trueの場合, dst=(src-delta)^T*(src-delta)</param>
#else
        /// <summary>
        /// Calculates product of array and transposed array
        /// </summary>
        /// <param name="src">The source matrix. </param>
        /// <param name="dst">The destination matrix. </param>
        /// <param name="order">Order of multipliers. </param>
#endif
        public static void MulTransposed(CvArr src, CvArr dst, bool order)
        {
            MulTransposed(src, dst, order, null);
        }
#if LANG_JP
        /// <summary>
        /// 行列と転置行列の乗算を行う
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">出力行列</param>
        /// <param name="order">転置した行列をかける順番を示すフラグ. falseの場合, dst=(src-delta)*(src-delta)^T, trueの場合, dst=(src-delta)^T*(src-delta)</param>
        /// <param name="delta">オプション配列，乗算する前にsrcから引かれる.</param>
#else
        /// <summary>
        /// Calculates product of array and transposed array
        /// </summary>
        /// <param name="src">The source matrix. </param>
        /// <param name="dst">The destination matrix. </param>
        /// <param name="order">Order of multipliers. </param>
        /// <param name="delta">An optional array, subtracted from src before multiplication. </param>
#endif
        public static void MulTransposed(CvArr src, CvArr dst, bool order, CvArr delta)
        {
            MulTransposed(src, dst, order, delta, 1.0);
        }
#if LANG_JP
        /// <summary>
        /// 行列と転置行列の乗算を行う
        /// </summary>
        /// <param name="src">入力行列</param>
        /// <param name="dst">出力行列</param>
        /// <param name="order">転置した行列をかける順番を示すフラグ. falseの場合, dst=(src-delta)*(src-delta)^T, trueの場合, dst=(src-delta)^T*(src-delta)</param>
        /// <param name="delta">オプション配列，乗算する前にsrcから引かれる.</param>
        /// <param name="scale"></param>
#else
        /// <summary>
        /// Calculates product of array and transposed array
        /// </summary>
        /// <param name="src">The source matrix. </param>
        /// <param name="dst">The destination matrix. </param>
        /// <param name="order">Order of multipliers. </param>
        /// <param name="delta">An optional array, subtracted from src before multiplication. </param>
        /// <param name="scale"></param>
#endif
        public static void MulTransposed(CvArr src, CvArr dst, bool order, CvArr delta, double scale)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr deltaPtr = (delta == null) ? IntPtr.Zero : delta.CvPtr;
            CvInvoke.cvMulTransposed(src.CvPtr, dst.CvPtr, order, deltaPtr, scale);
        }
        #endregion
    }
}
