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
        #region GEMM
#if LANG_JP
        /// <summary>
        /// 汎用的な行列の乗算を行う.
        /// dst = alpha*op(src1)*op(src2) + beta*op(src3), ここで， op(X) は X あるいは X^t. 
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="alpha">乗算結果に対するスケーリング係数</param>
        /// <param name="src3">3番目の入力配列（シフト用）．もしシフトしない場合はNULLにできる</param>
        /// <param name="beta">3番目の入力配列に対するスケーリング係数</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs generalized matrix multiplication
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="alpha">Scale factor</param>
        /// <param name="src3">The third source array (shift). Can be null, if there is no shift. </param>
        /// <param name="beta">Scale factor</param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void GEMM(CvArr src1, CvArr src2, double alpha, CvArr src3, double beta, CvArr dst)
        {
            GEMM(src1, src2, alpha, src3, beta, dst, GemmOperation.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 汎用的な行列の乗算を行う.
        /// dst = alpha*op(src1)*op(src2) + beta*op(src3), ここで， op(X) は X あるいは X^t. 
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="alpha">乗算結果に対するスケーリング係数</param>
        /// <param name="src3">3番目の入力配列（シフト用）．もしシフトしない場合はNULLにできる</param>
        /// <param name="beta">3番目の入力配列に対するスケーリング係数</param>
        /// <param name="dst">出力配列</param>
        /// <param name="tAbc">操作フラグ</param>
#else
        /// <summary>
        /// Performs generalized matrix multiplication
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="alpha">Scale factor</param>
        /// <param name="src3">The third source array (shift). Can be null, if there is no shift. </param>
        /// <param name="beta">Scale factor</param>
        /// <param name="dst">The destination array. </param>
        /// <param name="tAbc">The operation flags</param>
#endif
        public static void GEMM(CvArr src1, CvArr src2, double alpha, CvArr src3, double beta, CvArr dst, GemmOperation tAbc)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            IntPtr src3Ptr = (src3 == null) ? IntPtr.Zero : src3.CvPtr;
            CvInvoke.cvGEMM(src1.CvPtr, src2.CvPtr, alpha, src3Ptr, beta, dst.CvPtr, tAbc);
        }
#if LANG_JP
        /// <summary>
        /// 行列の乗算を行う.
        /// dst = A*B.
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs generalized matrix multiplication
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void MatMul(CvArr src1, CvArr src2, CvArr dst)
        {
            MatMulAdd(src1, src2, null, dst);
        }
#if LANG_JP
        /// <summary>
        /// 行列の乗算を行う.
        /// dst = A*B + C, C is optional.
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="src3">3番目の入力配列（シフト用）．もしシフトしない場合はnullにできる</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs generalized matrix multiplication
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="src3">The third source array (shift). Can be null, if there is no shift. </param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void MatMulAdd(CvArr src1, CvArr src2, CvArr src3, CvArr dst)
        {
            GEMM(src1, src2, 1, src3, 1, dst, GemmOperation.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 汎用的な行列の乗算を行う.
        /// dst = alpha*op(src1)*op(src2) + beta*op(src3), ここで， op(X) は X あるいは X^t. 
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="alpha">乗算結果に対するスケーリング係数</param>
        /// <param name="src3">3番目の入力配列（シフト用）．もしシフトしない場合はNULLにできる</param>
        /// <param name="beta">3番目の入力配列に対するスケーリング係数</param>
        /// <param name="dst">出力配列</param>
#else
        /// <summary>
        /// Performs generalized matrix multiplication
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="alpha">Scale factor</param>
        /// <param name="src3">The third source array (shift). Can be null, if there is no shift. </param>
        /// <param name="beta">Scale factor</param>
        /// <param name="dst">The destination array. </param>
#endif
        public static void MatMulAddEx(CvArr src1, CvArr src2, double alpha, CvArr src3, double beta, CvArr dst)
        {
            GEMM(src1, src2, alpha, src3, beta, dst, GemmOperation.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 汎用的な行列の乗算を行う.
        /// dst = alpha*op(src1)*op(src2) + beta*op(src3), ここで， op(X) は X あるいは X^t. 
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">2番目の入力配列</param>
        /// <param name="alpha">乗算結果に対するスケーリング係数</param>
        /// <param name="src3">3番目の入力配列（シフト用）．もしシフトしない場合はNULLにできる</param>
        /// <param name="beta">3番目の入力配列に対するスケーリング係数</param>
        /// <param name="dst">出力配列</param>
        /// <param name="tAbc">操作フラグ</param>
#else
        /// <summary>
        /// Performs generalized matrix multiplication
        /// </summary>
        /// <param name="src1">The first source array. </param>
        /// <param name="src2">The second source array. </param>
        /// <param name="alpha">Scale factor</param>
        /// <param name="src3">The third source array (shift). Can be null, if there is no shift. </param>
        /// <param name="beta">Scale factor</param>
        /// <param name="dst">The destination array. </param>
        /// <param name="tAbc">The operation flags</param>
#endif
        public static void MatMulAddEx(CvArr src1, CvArr src2, double alpha, CvArr src3, double beta, CvArr dst, GemmOperation tAbc)
        {
            GEMM(src1, src2, alpha, src3, beta, dst, tAbc);
        }
        #endregion
        #region Get*D
#if LANG_JP
        /// <summary>
        /// 特定の配列要素を返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素の値. 疎な配列で，指定したノードが存在しない場合，0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <returns></returns>
#endif
        public static CvScalar Get1D(CvArr arr, int idx0)
        {
            return CvInvoke.cvGet1D(arr.CvPtr, idx0);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素を返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素の値. 疎な配列で，指定したノードが存在しない場合，0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <returns></returns>
#endif
        public static CvScalar Get2D(CvArr arr, int idx0, int idx1)
        {
            return CvInvoke.cvGet2D(arr.CvPtr, idx0, idx1);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素を返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素の値. 疎な配列で，指定したノードが存在しない場合，0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <returns></returns>
#endif
        public static CvScalar Get3D(CvArr arr, int idx0, int idx1, int idx2)
        {
            return CvInvoke.cvGet3D(arr.CvPtr, idx0, idx1, idx2);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素を返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素の値. </returns>
#else
        /// <summary>
        /// Return the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx">Array of the element indices </param>
        /// <returns>the particular array element</returns>
#endif
        public static CvScalar GetND(CvArr arr, params int[] idx)
        {
            return CvInvoke.cvGetND(arr.CvPtr, idx);
        }
        #endregion
        #region GetAffineTransform
#if LANG_JP
        /// <summary>
        /// 3点とそれぞれに対応する点からアフィン変換を計算する (2 x 3 のCV_32FC1型). 引数としてoutを取るオーバーロードの簡略版.
        /// おそらくoutで出てくる行列と関数の返り値は同じなので、out引数の方を省いたものである.
        /// </summary>
        /// <param name="src">入力（変換前）画像内に存在する三角形の3つの頂点座標を格納した配列</param>
        /// <param name="dst">出力（変換後）画像内に存在するsrcに対応した三角形の3つの頂点座標を格納した配列</param>
        /// <returns>求められた 2×3のアフィン変換行列</returns>
#else
        /// <summary>
        /// Calculates affine transform from 3 corresponding points.
        /// </summary>
        /// <param name="src">Coordinates of 3 triangle vertices in the source image. </param>
        /// <param name="dst">Coordinates of the 3 corresponding triangle vertices in the destination image. </param>
        /// <returns></returns>
#endif
        public static CvMat GetAffineTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst)
        {
            CvMat tmp;
            return GetAffineTransform(src, dst, out tmp);
        }
#if LANG_JP
        /// <summary>
        /// 3点とそれぞれに対応する点からアフィン変換を計算する (2 x 3 のCV_32FC1型).
        /// </summary>
        /// <param name="src">入力（変換前）画像内に存在する三角形の3つの頂点座標を格納した配列</param>
        /// <param name="dst">出力（変換後）画像内に存在するsrcに対応した三角形の3つの頂点座標を格納した配列</param>
        /// <param name="mapMatrix">出力される 2×3のアフィン変換行列</param>
        /// <returns>求められた 2×3のアフィン変換行列</returns>
#else
        /// <summary>
        /// Calculates affine transform from 3 corresponding points.
        /// </summary>
        /// <param name="src">Coordinates of 3 triangle vertices in the source image. </param>
        /// <param name="dst">Coordinates of the 3 corresponding triangle vertices in the destination image. </param>
        /// <param name="mapMatrix">Pointer to the destination 2×3 matrix. </param>
        /// <returns></returns>
#endif
        public static CvMat GetAffineTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, out CvMat mapMatrix)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.Length != 3 || dst.Length != 3)
                throw new ArgumentException("NChannels of src/dst must be 3.");

            IntPtr mapMatrixPtr = CvInvoke.cvCreateMat(2, 3, MatrixType.F32C1);
            CvInvoke.cvGetAffineTransform(src, dst, mapMatrixPtr);
            mapMatrix = new CvMat(mapMatrixPtr);
            return mapMatrix;
        }
        #endregion
        #region GetCaptureProperty
#if LANG_JP
        /// <summary>
        /// ビデオキャプチャのプロパティを取得する
        /// </summary>
        /// <param name="capture">ビデオキャプチャクラス</param>
        /// <param name="propertyID">プロパティID</param>
        /// <returns>プロパティの値</returns>
#else
        /// <summary>
        /// Retrieves the specified property of camera or video file. 
        /// </summary>
        /// <param name="capture">video capturing structure. </param>
        /// <param name="propertyID">property identifier.</param>
        /// <returns>property value</returns>
#endif
        public static double GetCaptureProperty(CvCapture capture, int propertyID)
        {
            if (capture == null)
            {
                throw new ArgumentNullException("capture");
            }
            return CvInvoke.cvGetCaptureProperty(capture.CvPtr, propertyID);
        }
#if LANG_JP
        /// <summary>
        /// ビデオキャプチャのプロパティを取得する
        /// </summary>
        /// <param name="capture">ビデオキャプチャクラス</param>
        /// <param name="propertyID">プロパティID</param>
        /// <returns>プロパティの値</returns>
#else
        /// <summary>
        /// Retrieves the specified property of camera or video file. 
        /// </summary>
        /// <param name="capture">video capturing structure. </param>
        /// <param name="propertyID">property identifier.</param>
        /// <returns>property value</returns>
#endif
        public static double GetCaptureProperty(CvCapture capture, CaptureProperty propertyID)
        {
            return GetCaptureProperty(capture, (int)propertyID);
        }
        #endregion
        #region GetCentralMoment
#if LANG_JP
        /// <summary>
        /// 画像モーメント構造体から中心モーメントを計算する
        /// </summary>
        /// <param name="moments">画像モーメント構造体へのポインタ</param>
        /// <param name="xOrder">取り出すモーメントのx方向の次数，x_order &gt;= 0. </param>
        /// <param name="yOrder">取り出すモーメントのy方向の次数， y_order &gt;= 0 かつ x_order + y_order &lt;= 3. </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves central moment from moment state structure
        /// </summary>
        /// <param name="moments">Moment state structure</param>
        /// <param name="xOrder">x order of the retrieved moment, x_order &gt;= 0</param>
        /// <param name="yOrder">y order of the retrieved moment, y_order &gt;= 0 and x_order + y_order &lt;= 3</param>
        /// <returns>Central moment</returns>
#endif
        public static double GetCentralMoment(CvMoments moments, int xOrder, int yOrder)
        {
            if (moments == null)
            {
                throw new ArgumentNullException("moments");
            }
            //return CvDll.cvGetCentralMoment(moments.CvPtr, x_order, y_order);
            return CvInvoke.cvGetCentralMoment(moments, xOrder, yOrder);
        }
        #endregion
        #region GetCol
#if LANG_JP
        /// <summary>
        /// 指定された列を返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="col">選択した列の，0を基準としたインデックス．</param>
        /// <returns>指定された範囲の列</returns>
#else
        /// <summary>
        /// Returns array column
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="submat">Reference to the resulting sub-array header. </param>
        /// <param name="col">Zero-based index of the selected column. </param>
        /// <returns></returns>
#endif
        public static CvMat GetCol(CvArr arr, out CvMat submat, int col)
        {
            return GetCols(arr, out submat, col, col + 1);
        }
#if LANG_JP
        /// <summary>
        /// 指定された範囲の列（複数列）を返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="startCol">範囲の最初の（この値を含む）列の，0を基準としたインデックス．</param>
        /// <param name="endCol">範囲の最後の（この値を含まない）列の，0を基準としたインデックス．</param>
        /// <returns>指定された範囲の列</returns>
#else
        /// <summary>
        /// Returns array column span
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="submat">Reference to the resulting sub-array header. </param>
        /// <param name="startCol">Zero-based index of the starting column (inclusive) of the span. </param>
        /// <param name="endCol">Zero-based index of the ending column (exclusive) of the span. </param>
        /// <returns></returns>
#endif
        public static CvMat GetCols(CvArr arr, out CvMat submat, int startCol, int endCol)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            submat = new CvMat(false);
            IntPtr result = CvInvoke.cvGetCols(arr.CvPtr, submat.CvPtr, startCol, endCol);
            return new CvMat(result, false);
        }
        #endregion
        #region GetDiag
#if LANG_JP
        /// <summary>
        /// 入力配列中の指定された対角列に相当するヘッダを返す. 
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <returns>結果として得られる部分配列のヘッダへの参照</returns>
#else
        /// <summary>
        /// Returns one of array diagonals
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="submat">Reference to the resulting sub-array header. </param>
        /// <returns></returns>
#endif
        public static CvMat GetDiag(CvArr arr, out CvMat submat)
        {
            return GetDiag(arr, out submat, 0);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列中の指定された対角列に相当するヘッダを返す. 
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="diag">対角配列の種類</param>
        /// <returns>結果として得られる部分配列のヘッダへの参照</returns>
#else
        /// <summary>
        /// Returns one of array diagonals
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="submat">Reference to the resulting sub-array header. </param>
        /// <param name="diag">Array diagonal. Zero corresponds to the main diagonal, -1 corresponds to the diagonal above the main etc., 1 corresponds to the diagonal below the main etc. </param>
        /// <returns></returns>
#endif
        public static CvMat GetDiag(CvArr arr, out CvMat submat, DiagType diag)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            submat = new CvMat(false);
            IntPtr result = CvInvoke.cvGetDiag(arr.CvPtr, submat.CvPtr, diag);
            return new CvMat(result, false);
        }
        #endregion
        #region GetDims
#if LANG_JP
        /// <summary>
        /// 配列の次元とそれらのサイズを返す．
        /// IplImageまたは CvMatの場合には，画像や行列の行数に関係なく常に 2 を返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <returns>配列の次元数</returns>
#else
        /// <summary>
        /// Return number of array dimensions and their sizes
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <returns>number of array dimensions.</returns>
#endif
        public static int GetDims(CvArr arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            return CvInvoke.cvGetDims(arr.CvPtr, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 配列の次元とそれらのサイズを返す．
        /// IplImageまたは CvMatの場合には，画像や行列の行数に関係なく常に 2 を返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="sizes">配列の次元の大きさを示すオプションの出力ベクトル．2次元配列の場合は1番目に行数（高さ），次は列数（幅）を示す．</param>
        /// <returns>配列の次元数</returns>
#else
        /// <summary>
        /// Return number of array dimensions and their sizes
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="sizes">Optional output vector of the array dimension sizes. For 2d arrays the number of rows (height) goes first, number of columns (width) next. </param>
        /// <returns>number of array dimensions.</returns>
#endif
        public static int GetDims(CvArr arr, out int[] sizes)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            sizes = new int[CvConst.CV_MAX_DIM];

            using (var sizesPtr = new ArrayAddress1<int>(sizes))
            {
                return CvInvoke.cvGetDims(arr.CvPtr, sizesPtr.Pointer);
            }
        }
        #endregion
        #region GetDimSize
#if LANG_JP
        /// <summary>
        /// 配列の指定された次元の要素数を返す. 
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="index">0を基準にした次元のインデックス（行列では0は行数，1は列数を示す．画像では0は高さ, 1は幅を示す）．</param>
        /// <returns>指定された次元の要素数</returns>
#else
        /// <summary>
        /// Return the size of particular dimension
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="index">Zero-based dimension index (for matrices 0 means number of rows, 1 means number of columns; for images 0 means height, 1 means width). </param>
        /// <returns>the particular dimension size (number of elements per that dimension).</returns>
#endif
        public static int GetDimSize(CvArr arr, int index)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            return CvInvoke.cvGetDimSize(arr.CvPtr, index);
        }
        #endregion
        #region GetElemType
#if LANG_JP
        /// <summary>
        /// 配列要素のタイプを返す. 
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <returns>配列要素のタイプ</returns>
#else
        /// <summary>
        /// Returns type of array elements
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <returns>type of the array elements</returns>
#endif
        public static MatrixType GetElemType(CvArr arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            return (MatrixType)CvInvoke.cvGetElemType(arr.CvPtr);
        }
        #endregion
        #region GetErrMode
#if LANG_JP
        /// <summary>
        /// 現在のエラーモードを返す
        /// </summary>
        /// <returns>現在のエラーモード</returns>
#else
        /// <summary>
        /// Returns the current error mode
        /// </summary>
        /// <returns>the current error mode</returns>
#endif
        public static ErrMode GetErrMode()
        {
            return CvInvoke.cvGetErrMode();
        }
        #endregion
        #region GetErrStatus
#if LANG_JP
        /// <summary>
        /// 現在のエラーステータスを返す
        /// </summary>
        /// <returns>現在のエラーステータス</returns>
#else
        /// <summary>
        /// Returns the current error status
        /// </summary>
        /// <returns>the current error status</returns>
#endif
        public static CvStatus GetErrStatus()
        {
            return CvInvoke.cvGetErrStatus();
        }
        #endregion
        #region GetFileNode
#if LANG_JP
        /// <summary>
        /// マップまたはファイルストレージ内のノードを見つける
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探す．もしmapとkeyの両方がnullの場合には， この関数はトップレベルノードを持つマップであるルートファイルノードを返す．</param>
        /// <param name="key">cvGetHashedKeyで取得されるノード名ヘの唯一のポインタ</param>
        /// <returns>与えたmap,keyに対するファイルノード</returns>
#else
        /// <summary>
        /// Finds node in the map or file storage
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. If both map and key are nulls, the function returns the root file node - a map that contains top-level nodes. </param>
        /// <param name="key">Unique pointer to the node name, retrieved with cvGetHashedKey. </param>
        /// <returns></returns>
#endif
        public static CvFileNode GetFileNode(CvFileStorage fs, CvFileNode map, CvStringHashNode key)
        {
            return GetFileNode(fs, map, key, false);
        }
#if LANG_JP
        /// <summary>
        /// マップまたはファイルストレージ内のノードを見つける
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数はトップレベルノードを探す．もしmapとkeyの両方がnullの場合には， この関数はトップレベルノードを持つマップであるルートファイルノードを返す．</param>
        /// <param name="key">cvGetHashedKeyで取得されるノード名ヘの唯一のポインタ</param>
        /// <param name="createMissing">absent keyをハッシュテーブルに追加するかどうかを指定するフラグ</param>
        /// <returns>与えたmap,keyに対するファイルノード</returns>
#else
        /// <summary>
        /// Finds node in the map or file storage
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches a top-level node. If both map and key are nulls, the function returns the root file node - a map that contains top-level nodes. </param>
        /// <param name="key">Unique pointer to the node name, retrieved with cvGetHashedKey. </param>
        /// <param name="createMissing">Flag that specifies, whether an absent node should be added to the map, or not. </param>
        /// <returns></returns>
#endif
        public static CvFileNode GetFileNode(CvFileStorage fs, CvFileNode map, CvStringHashNode key, bool createMissing)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            
            IntPtr mapPtr = (map == null) ? IntPtr.Zero : map.CvPtr;
            IntPtr keyPtr = (key == null) ? IntPtr.Zero : key.CvPtr;
            IntPtr result = CvInvoke.cvGetFileNode(fs.CvPtr, mapPtr, keyPtr, createMissing);
            if (result != IntPtr.Zero)
                return new CvFileNode(result);
            else
                return null;
        }
        #endregion
        #region GetFileNodeName
#if LANG_JP
        /// <summary>
        /// ファイルノードの名前を返す．ファイルノードが名前を持たないか，nodeがnullの場合にはnullを返す．
        /// </summary>
        /// <param name="node">ファイルノード</param>
        /// <returns>ファイルノードの名前</returns>
#else
        /// <summary>
        /// Returns name of file node
        /// </summary>
        /// <param name="node">File node.</param>
        /// <returns>name of the file node or null</returns>
#endif
        public static string GetFileNodeName(CvFileNode node)
        {
            IntPtr nodePtr = (node == null) ? IntPtr.Zero : node.CvPtr;
            return CvInvoke.cvGetFileNodeName(nodePtr);
        }
        #endregion
        #region GetFileNodeByName
#if LANG_JP
        /// <summary>
        /// マップ内またはファイルストレージ内からノードを探索する
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="map">親マップ．nullの場合，この関数は一番最初のものから開始して，全てのトップレベルノード(ストリーム)内を探索する．</param>
        /// <param name="name">ファイルノード名</param>
        /// <returns>名前がnameのファイルノード</returns>
#else
        /// <summary>
        /// Finds node in the map or file storage
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="map">The parent map. If it is null, the function searches in all the top-level nodes (streams), starting from the first one. </param>
        /// <param name="name">The file node name. </param>
        /// <returns></returns>
#endif
        public static CvFileNode GetFileNodeByName(CvFileStorage fs, CvFileNode map, string name)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            IntPtr mapPtr = (map == null) ? IntPtr.Zero : map.CvPtr;
            IntPtr result = CvInvoke.cvGetFileNodeByName(fs.CvPtr, mapPtr, name);
            if (result != IntPtr.Zero)
                return new CvFileNode(result);
            else
                return null;
        }
        #endregion
        #region GetGraphVtx
#if LANG_JP
        /// <summary>
        /// インデックスを用いてグラフの頂点を検索する
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtxIdx">頂点のインデックス</param>
        /// <returns>グラフの頂点</returns>
#else
        /// <summary>
        /// Finds graph vertex by index
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtxIdx">Index of the vertex. </param>
        /// <returns>The function cvGetGraphVtx finds the graph vertex by index and returns the pointer to it or null if the vertex does not belong to the graph.</returns>
#endif
        public static CvGraphVtx GetGraphVtx(CvGraph graph, int vtxIdx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }

            IntPtr vtx = GetSetElemInternal(graph, vtxIdx);

            if (vtx == IntPtr.Zero)
                return null;
            else
                return new CvGraphVtx(vtx);
        }
        #endregion
        #region GetHashedKey
#if LANG_JP
        /// <summary>
        /// 与えた名前に対するユニークなポインタを返す 
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="name">ファイルノード名</param>
        /// <returns>与えた名前に対するユニークなポインタ</returns>
#else
        /// <summary>
        /// Returns a unique pointer for given name
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Literal node name. </param>
        /// <returns>The unique pointer for each particular file node name.</returns>
#endif
        public static CvStringHashNode GetHashedKey(CvFileStorage fs, string name)
        {
            return GetHashedKey(fs, name, false);
        }
#if LANG_JP
        /// <summary>
        /// 与えた名前に対するユニークなポインタを返す 
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="name">ファイルノード名</param>
        /// <param name="createMissing">absent keyをハッシュテーブルに追加するかどうかを指定するフラグ</param>
        /// <returns>与えた名前に対するユニークなポインタ</returns>
#else
        /// <summary>
        /// Returns a unique pointer for given name
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="name">Literal node name. </param>
        /// <param name="createMissing">Length of the name (if it is known a priori), or -1 if it needs to be calculated. </param>
        /// <returns>The unique pointer for each particular file node name.</returns>
#endif
        public static CvStringHashNode GetHashedKey(CvFileStorage fs, string name, bool createMissing)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            IntPtr result = CvInvoke.cvGetHashedKey(fs.CvPtr, name, name.Length, createMissing);
            if (result != IntPtr.Zero)
                return new CvStringHashNode(result);
            else
                return null;
        }
        #endregion
        #region GetHistValue_*D
#if LANG_JP
        /// <summary>
        /// 1次元ヒストグラムの指定されたビンへのポインタを返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Returns pointer to histogram bin.
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="idx0">1st index of the bin.</param>
        /// <returns></returns>
#endif
        public static IntPtr GetHistValue_1D(CvHistogram hist, int idx0)
        {
            MatrixType type;
            return CvInvoke.cvPtr1D(hist.BinsPtr, idx0, out type);
        }
#if LANG_JP
        /// <summary>
        /// 2次元ヒストグラムの指定されたビンへのポインタを返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Returns pointer to histogram bin.
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="idx0">1st index of the bin.</param>
        /// <param name="idx1">2rd index of the bin.</param>
        /// <returns></returns>
#endif
        public static IntPtr GetHistValue_2D(CvHistogram hist, int idx0, int idx1)
        {
            MatrixType type;
            return CvInvoke.cvPtr2D(hist.BinsPtr, idx0, idx1, out type);
        }
#if LANG_JP
        /// <summary>
        /// 3次元ヒストグラムの指定されたビンへのポインタを返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Returns pointer to histogram bin.
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="idx0">1st index of the bin.</param>
        /// <param name="idx1">2nd index of the bin.</param>
        /// <param name="idx2">3rd index of the bin.</param>
        /// <returns></returns>
#endif
        public static IntPtr GetHistValue_3D(CvHistogram hist, int idx0, int idx1, int idx2)
        {
            MatrixType type;
            return CvInvoke.cvPtr3D(hist.BinsPtr, idx0, idx1, idx2, out type);
        }
#if LANG_JP
        /// <summary>
        /// n次元ヒストグラムの指定されたビンへのポインタを返す． 
        /// 疎なヒストグラムの場合で，既にビンが存在している場合以外は，この関数が新しいビンを作成し，0にセットする．
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Returns pointer to histogram bin.
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="idx">Indices of the bin. </param>
        /// <returns></returns>
#endif
        public static IntPtr GetHistValue_nD(CvHistogram hist, params int[] idx)
        {
            MatrixType type;
            return CvInvoke.cvPtrND(hist.BinsPtr, idx, out type, true, IntPtr.Zero);
        }
        #endregion
        #region GetHuMoments
#if LANG_JP
        /// <summary>
        /// ７つのHuモーメント不変量を計算する
        /// </summary>
        /// <param name="moments">画像モーメント構造体への参照</param>
        /// <param name="humoments">Huモーメント構造体への参照</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates seven Hu invariants
        /// </summary>
        /// <param name="moments">Moment state structure</param>
        /// <param name="humoments">Pointer to Hu moments structure</param>
#endif
        public static void GetHuMoments(CvMoments moments, out CvHuMoments humoments)
        {
            if (moments == null)
            {
                throw new ArgumentNullException("moments");
            }
            //CvDll.cvGetHuMoments(moments.CvPtr, humoments.CvPtr);
            humoments = new CvHuMoments();
            CvInvoke.cvGetHuMoments(moments, humoments);
        }
        #endregion
        #region GetImage
#if LANG_JP
        /// <summary>
        /// 任意の配列に対する画像ヘッダを返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <returns>入力配列に対する画像ヘッダ</returns>
#else
        /// <summary>
        /// Returns image header for arbitrary array
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <returns>returns the image header for the input array that can be a matrix</returns>
#endif
        public static IplImage GetImage(CvArr arr)
        {
            IplImage imageHeader;
            return GetImage(arr, out imageHeader);
        }
#if LANG_JP
        /// <summary>
        /// 任意の配列に対する画像ヘッダを返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="imageHeader">出力される画像ヘッダ</param>
        /// <returns>入力配列に対する画像ヘッダ</returns>
#else
        /// <summary>
        /// Returns image header for arbitrary array
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="imageHeader">IplImage structure used as a temporary buffer. </param>       
        /// <returns>returns the image header for the input array that can be a matrix</returns>
#endif
        public static IplImage GetImage(CvArr arr, out IplImage imageHeader)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            imageHeader = new IplImage(false);
            IntPtr ptr = CvInvoke.cvGetImage(arr.CvPtr, imageHeader.CvPtr);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new IplImage(ptr, false);
        }
        #endregion
        #region GetImageCOI
#if LANG_JP
        /// <summary>
        /// 画像の COI（channel of interest）を返す.
        /// 全チャンネルが選択される場合には，0 が返される）．
        /// </summary>
        /// <param name="image">画像ヘッダ</param>
        /// <returns>COI（channel of interest）を返す（全チャンネルが選択される場合には，0 が返される）.</returns>
#else
        /// <summary>
        /// Returns index of channel of interest
        /// </summary>
        /// <param name="image">Image header. </param>
        /// <returns>channel of interest of the image (it returns 0 if all the channels are selected)</returns>
#endif
        public static int GetImageCOI(IplImage image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            return CvInvoke.cvGetImageCOI(image.CvPtr);
        }
        #endregion
        #region GetImageROI
#if LANG_JP
        /// <summary>
        /// 画像の ROI 座標を返す．
        /// ROI が存在しない場合には，矩形 cvRect(0,0,image.Width,image.Height) が返される．
        /// </summary>
        /// <param name="image">画像ヘッダ</param>
        /// <returns>ROI</returns> 
#else
        /// <summary>
        /// Returns image ROI coordinates.
        /// The rectangle cvRect(0,0,image.Width,image.Height) is returned if there is no ROI.
        /// </summary>
        /// <param name="image">Image header. </param>
        /// <returns></returns>
#endif
        public static CvRect GetImageROI(IplImage image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            return CvInvoke.cvGetImageROI(image.CvPtr);
        }
        #endregion
        #region GetMat
#if LANG_JP
        /// <summary>
        /// 任意の配列に対する行列ヘッダを返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <returns>入力配列に対する行列ヘッダ</returns>
#else
        /// <summary>
        /// Returns matrix header for arbitrary array
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <returns>returns a matrix header for the input array that can be a matrix</returns>
#endif
        public static CvMat GetMat(CvArr arr)
        {
            CvMat header;
            int coi;
            return GetMat(arr, out header, out coi, false);
        }
#if LANG_JP
        /// <summary>
        /// 任意の配列に対する行列ヘッダを返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="header">出力されるCvMatヘッダ</param>
        /// <returns>入力配列に対する行列ヘッダ</returns>
#else
        /// <summary>
        /// Returns matrix header for arbitrary array
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="header">Pointer to CvMat structure used as a temporary buffer. </param>       
        /// <returns>returns a matrix header for the input array that can be a matrix</returns>
#endif
        public static CvMat GetMat(CvArr arr, out CvMat header)
        {
            int coi;
            return GetMat(arr, out header, out coi, false);
        }
#if LANG_JP
        /// <summary>
        /// 任意の配列に対する行列ヘッダを返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="header">出力されるCvMatヘッダ</param>
        /// <param name="coi">COIを記憶するための，オプションの出力パラメータ．</param>
        /// <returns>入力配列に対する行列ヘッダ</returns>
#else
        /// <summary>
        /// Returns matrix header for arbitrary array
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="header">Pointer to CvMat structure used as a temporary buffer. </param>       
        /// <param name="coi">Optional output parameter for storing COI. </param>
        /// <returns>returns a matrix header for the input array that can be a matrix</returns>
#endif
        public static CvMat GetMat(CvArr arr, out CvMat header, out int coi)
        {
            return GetMat(arr, out header, out coi, false);
        }
#if LANG_JP
        /// <summary>
        /// 任意の配列に対する行列ヘッダを返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="header">出力されるCvMatヘッダ</param>
        /// <param name="coi">COIを記憶するための，オプションの出力パラメータ．</param>
        /// <param name="allowND">これが 0 でない場合，この関数は多次元の密な配列（CvMatND*）を扱うことが可能で， 2次元行列（CvMatND が2次元の場合）あるいは 1次元行列（CvMatNDが 1次元，あるいは 2次元より大きい場合）を返す． 配列は連続でなければならない． </param>       
        /// <returns>入力配列に対する行列ヘッダ</returns>
#else
        /// <summary>
        /// Returns matrix header for arbitrary array
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="header">Pointer to CvMat structure used as a temporary buffer. </param>       
        /// <param name="coi">Optional output parameter for storing COI. </param>
        /// <param name="allowND">If true, the function accepts multi-dimensional dense arrays (CvMatND*) and returns 2D (if CvMatND has two dimensions) or 1D matrix (when CvMatND has 1 dimension or more than 2 dimensions). The array must be continuous. </param>       
        /// <returns>returns a matrix header for the input array that can be a matrix</returns>
#endif
        public static CvMat GetMat(CvArr arr, out CvMat header, out int coi, bool allowND)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            header = new CvMat(false);
            IntPtr ptr = CvInvoke.cvGetMat(arr.CvPtr, header.CvPtr, out coi, allowND);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvMat(ptr, false);
        }
        #endregion
        #region GetNextSparseNode
#if LANG_JP
        /// <summary>
        /// 疎な配列において次の要素のポインタを返す
        /// </summary>
        /// <param name="matIterator">疎な配列のイテレータ．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Moves iterator to the next sparse matrix element and returns pointer to it.
        /// </summary>
        /// <param name="matIterator">Sparse array iterator.</param>
        /// <returns></returns>
#endif
        public static CvSparseNode GetNextSparseNode(CvSparseMatIterator matIterator)
        {
            if (matIterator == null)
                throw new ArgumentNullException("matIterator");

            IntPtr result = IntPtr.Zero;
            unsafe
            {
                WCvSparseMatIterator* matIteratorP = (WCvSparseMatIterator*)matIterator.CvPtr;
                WCvSparseNode* node = (WCvSparseNode*)matIteratorP->node;
                WCvSparseMat* mat = (WCvSparseMat*)matIteratorP->mat;

                if (node->next != null)
                {
                    matIteratorP->node = node->next;
                    result = new IntPtr(node->next);
                }
                else
                {
                    for (int idx = ++matIteratorP->curidx; idx < mat->hashsize; idx++)
                    {
                        if (node != null)
                        {
                            matIteratorP->curidx = idx;
                            matIteratorP->node = node;
                            result = new IntPtr(node);
                            break;
                        }
                    }
                }
            }

            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSparseNode(result);
        }
        #endregion
        #region GetMinMaxHistValue
#if LANG_JP
        /// <summary>
        /// ヒストグラムのビンの最小値/最大値を求める． 
        /// 同じ値の最大値や最小値が複数存在する場合，辞書順に並べたときに最も先頭になるインデックスが返される． 
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="minValue">ヒストグラムの最小値の出力</param>
        /// <param name="maxValue">ヒストグラムの最大値の出力</param>
#else
        /// <summary>
        /// Finds minimum and maximum histogram bins.
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="minValue">The minimum value of the histogram.</param>
        /// <param name="maxValue">The maximum value of the histogram.</param>
#endif
        public static void GetMinMaxHistValue(CvHistogram hist, out float minValue, out float maxValue)
        {
            int[] minIdx, maxIdx;
            GetMinMaxHistValue(hist, out minValue, out maxValue, out minIdx, out maxIdx);
        }
#if LANG_JP
        /// <summary>
        /// ヒストグラムのビンの最小値/最大値とそれらの場所を求める． 
        /// 同じ値の最大値や最小値が複数存在する場合，辞書順に並べたときに最も先頭になるインデックスが返される． 
        /// </summary>
        /// <param name="hist">ヒストグラム</param>
        /// <param name="minValue">ヒストグラムの最小値の出力</param>
        /// <param name="maxValue">ヒストグラムの最大値の出力</param>
        /// <param name="minIdx">最小値の配列中のインデックスの出力</param>
        /// <param name="maxIdx">最大値の配列中のインデックスの出力</param>
#else
        /// <summary>
        /// Finds minimum and maximum histogram bins.
        /// </summary>
        /// <param name="hist">Histogram. </param>
        /// <param name="minValue">The minimum value of the histogram.</param>
        /// <param name="maxValue">The maximum value of the histogram.</param>
        /// <param name="minIdx">The array of coordinates for minimum.</param>
        /// <param name="maxIdx">The array of coordinates for maximum.</param>
#endif
        public static void GetMinMaxHistValue(CvHistogram hist, out float minValue, out float maxValue, out int[] minIdx, out int[] maxIdx)
        {
            if (hist == null)
            {
                throw new ArgumentNullException("hist");
            }
            float minValueTemp = 0;
            float maxValueTemp = 0;
            int[] minIdxTemp = new int[hist.Dim];
            int[] maxIdxTemp = new int[hist.Dim];
            CvInvoke.cvGetMinMaxHistValue(hist.CvPtr, ref minValueTemp, ref maxValueTemp, minIdxTemp, maxIdxTemp);
            minValue = minValueTemp;
            maxValue = maxValueTemp;
            minIdx = minIdxTemp;
            maxIdx = maxIdxTemp;
        }
        #endregion
        #region GetModuleInfo
#if LANG_JP
        /// <summary>
        /// 登録されたモジュールとプラグインの情報を取り出す
        /// </summary>
        /// <param name="moduleName">対象のモジュール名，nullの場合はすべてのモジュール．</param>
        /// <param name="version">出力パラメータ．モジュールについての情報（バージョンを含む）．</param>
        /// <param name="loadedAddonPlugins">CXCOREがロード可能な最適化プラグインの名前とバージョンのリスト．</param>
#else
        /// <summary>
        /// Retrieves information about the registered module(s) and plugins
        /// </summary>
        /// <param name="moduleName">Name of the module of interest, or null, which means all the modules. </param>
        /// <param name="version">The output parameter. Information about the module(s), including version. </param>
        /// <param name="loadedAddonPlugins">The list of names and versions of the optimized plugins that CXCORE was able to find and load. </param>
#endif
        public static void GetModuleInfo(string moduleName, out string version, out string loadedAddonPlugins)
        {
            IntPtr versionPtr = IntPtr.Zero;
            IntPtr loadedAddonPluginsPtr = IntPtr.Zero;

            CvInvoke.cvGetModuleInfo(moduleName, ref versionPtr, ref loadedAddonPluginsPtr);

            version = Marshal.PtrToStringAnsi(versionPtr);
            loadedAddonPlugins = Marshal.PtrToStringAnsi(loadedAddonPluginsPtr);
        }
        #endregion
        #region GetNormalizedCentralMoment
#if LANG_JP
        /// <summary>
        /// 画像モーメント構造体から正規化された中心モーメントを計算する
        /// </summary>
        /// <param name="moments">画像モーメント構造体への参照</param>
        /// <param name="xOrder">取り出すモーメントのx方向の次数，x_order &gt;= 0. </param>
        /// <param name="yOrder">取り出すモーメントのy方向の次数， y_order &gt;= 0 かつ x_order + y_order &lt;= 3. </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves normalized central moment from moment state structure
        /// </summary>
        /// <param name="moments">Moment state structure</param>
        /// <param name="xOrder">x order of the retrieved moment, x_order &gt;= 0</param>
        /// <param name="yOrder">y order of the retrieved moment, y_order &gt;= 0 and x_order + y_order &lt;= 3</param>
        /// <returns>Central moment</returns>
#endif
        public static double GetNormalizedCentralMoment(CvMoments moments, int xOrder, int yOrder)
        {
            if (moments == null)
            {
                throw new ArgumentNullException("moments");
            }
            //return CvDll.cvGetNormalizedCentralMoment(moments.CvPtr, x_order, y_order);
            return CvInvoke.cvGetNormalizedCentralMoment(moments, xOrder, yOrder);
        }
        #endregion
        #region GetNumThreads
#if LANG_JP
        /// <summary>
        /// OpenMPを用いて並列化されたOpenCV関数によって使用される現在のスレッド数を返す．
        /// </summary>
        /// <returns>現在使われているスレッド数</returns>
#else
        /// <summary>
        /// Returns the current number of threads that are used by parallelized (via OpenMP) OpenCV functions.
        /// </summary>
        /// <returns>the current number of threads used</returns>
#endif
        public static int GetNumThreads()
        {
            return CvInvoke.cvGetNumThreads();
        }
        #endregion
        #region GetOptimalDFTSize
#if LANG_JP
        /// <summary>
        /// 与えられたベクトルのサイズに対する最適なDFTのサイズを返す
        /// </summary>
        /// <param name="size0">ベクトルのサイズ</param>
        /// <returns>最適なDFTのサイズ</returns>
#else
        /// <summary>
        /// Returns optimal DFT size for given vector size
        /// </summary>
        /// <param name="size0">Vector size. </param>
        /// <returns>optimal DFT size for given vector size</returns>
#endif
        public static int GetOptimalDFTSize(int size0)
        {
            return CvInvoke.cvGetOptimalDFTSize(size0);
        }
        #endregion
        #region GetOptimalNewCameraMatrix
#if LANG_JP
        /// <summary>
        /// フリースケーリングパラメータに基づいて，新たなカメラ行列を返します
        /// </summary>
        /// <param name="cameraMatrix">入力されるカメラ行列</param>
        /// <param name="distCoeffs">入力される 4x1, 1x4, 5x1 または 1x5 の歪み係数ベクトル (k_1, k_2, p_1, p_2[, k_3])</param>
        /// <param name="imageSize">最適画像サイズ</param>
        /// <param name="alpha">フリースケーリングパラメータ．0（歪み補正された画像のすべてのピクセルが有効）から1（歪み補正された画像においても，元画像のすべてのピクセルを保持）の間の値をとります．</param>
        /// <param name="newCameraMatrix">出力される新たなカメラ行列</param>
#else
        /// <summary>
        /// Returns the new camera matrix based on the free scaling parameter
        /// </summary>
        /// <param name="cameraMatrix">The input camera matrix</param>
        /// <param name="distCoeffs">The input 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3])</param>
        /// <param name="imageSize">The original image size</param>
        /// <param name="alpha">The free scaling parameter between 0 (when all the pixels in the undistorted image will be valid) and 1 (when all the source image pixels will be retained in the undistorted image);</param>
        /// <param name="newCameraMatrix">The output new camera matrix.</param>
#endif
        public static void GetOptimalNewCameraMatrix(CvMat cameraMatrix, CvMat distCoeffs, CvSize imageSize, double alpha, CvMat newCameraMatrix)
        {
            CvRect roi;
            GetOptimalNewCameraMatrix(cameraMatrix, distCoeffs, imageSize, alpha, newCameraMatrix, new CvSize(0, 0), out roi);
        }
#if LANG_JP
        /// <summary>
        /// フリースケーリングパラメータに基づいて，新たなカメラ行列を返します
        /// </summary>
        /// <param name="cameraMatrix">入力されるカメラ行列</param>
        /// <param name="distCoeffs">入力される 4x1, 1x4, 5x1 または 1x5 の歪み係数ベクトル (k_1, k_2, p_1, p_2[, k_3])</param>
        /// <param name="imageSize">最適画像サイズ</param>
        /// <param name="alpha">フリースケーリングパラメータ．0（歪み補正された画像のすべてのピクセルが有効）から1（歪み補正された画像においても，元画像のすべてのピクセルを保持）の間の値をとります．</param>
        /// <param name="newCameraMatrix">出力される新たなカメラ行列</param>
        /// <param name="newImageSize">平行化された後の画像サイズ．デフォルトでは imageSize にセットされます</param>
#else
        /// <summary>
        /// Returns the new camera matrix based on the free scaling parameter
        /// </summary>
        /// <param name="cameraMatrix">The input camera matrix</param>
        /// <param name="distCoeffs">The input 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3])</param>
        /// <param name="imageSize">The original image size</param>
        /// <param name="alpha">The free scaling parameter between 0 (when all the pixels in the undistorted image will be valid) and 1 (when all the source image pixels will be retained in the undistorted image);</param>
        /// <param name="newCameraMatrix">The output new camera matrix.</param>
        /// <param name="newImageSize">The image size after rectification. By default it will be set to imageSize .</param>
#endif
        public static void GetOptimalNewCameraMatrix(CvMat cameraMatrix, CvMat distCoeffs, CvSize imageSize, double alpha, CvMat newCameraMatrix, CvSize newImageSize)
        {
            CvRect roi;
            GetOptimalNewCameraMatrix(cameraMatrix, distCoeffs, imageSize, alpha, newCameraMatrix, newImageSize, out roi);
        }
#if LANG_JP
        /// <summary>
        /// フリースケーリングパラメータに基づいて，新たなカメラ行列を返します
        /// </summary>
        /// <param name="cameraMatrix">入力されるカメラ行列</param>
        /// <param name="distCoeffs">入力される 4x1, 1x4, 5x1 または 1x5 の歪み係数ベクトル (k_1, k_2, p_1, p_2[, k_3])</param>
        /// <param name="imageSize">最適画像サイズ</param>
        /// <param name="alpha">フリースケーリングパラメータ．0（歪み補正された画像のすべてのピクセルが有効）から1（歪み補正された画像においても，元画像のすべてのピクセルを保持）の間の値をとります．</param>
        /// <param name="newCameraMatrix">出力される新たなカメラ行列</param>
        /// <param name="newImageSize">平行化された後の画像サイズ．デフォルトでは imageSize にセットされます</param>
        /// <param name="validPixROI">オプション出力．歪み補正された画像中のすべての有効なピクセル領域を囲む矩形．</param>
#else
        /// <summary>
        /// Returns the new camera matrix based on the free scaling parameter
        /// </summary>
        /// <param name="cameraMatrix">The input camera matrix</param>
        /// <param name="distCoeffs">The input 4x1, 1x4, 5x1 or 1x5 vector of distortion coefficients (k_1, k_2, p_1, p_2[, k_3])</param>
        /// <param name="imageSize">The original image size</param>
        /// <param name="alpha">The free scaling parameter between 0 (when all the pixels in the undistorted image will be valid) and 1 (when all the source image pixels will be retained in the undistorted image);</param>
        /// <param name="newCameraMatrix">The output new camera matrix.</param>
        /// <param name="newImageSize">The image size after rectification. By default it will be set to imageSize .</param>
        /// <param name="validPixROI">The optional output rectangle that will outline all-good-pixels region in the undistorted image.</param>
#endif
        public static void GetOptimalNewCameraMatrix(CvMat cameraMatrix, CvMat distCoeffs, CvSize imageSize, double alpha, CvMat newCameraMatrix, CvSize newImageSize, out CvRect validPixROI)
        {
            if (cameraMatrix == null)
                throw new ArgumentNullException("cameraMatrix");
            if (distCoeffs == null)
                throw new ArgumentNullException("distCoeffs");
            if (newCameraMatrix == null)
                throw new ArgumentNullException("newCameraMatrix");
            CvInvoke.cvGetOptimalNewCameraMatrix(cameraMatrix.CvPtr, distCoeffs.CvPtr, imageSize, alpha, newCameraMatrix.CvPtr, newImageSize, out validPixROI);
        }
        #endregion
        #region GetPerspectiveTransform
#if LANG_JP
        /// <summary>
        /// 4点とそれぞれに対応する点を用いて透視変換行列を求める (3 x 3 のCV_32FC1型). 引数としてoutを取るオーバーロードの簡略版.
        /// おそらくoutで出てくる行列と関数の返り値は同じなので、out引数の方を省いたものである.
        /// </summary>
        /// <param name="src">入力画像中の矩形の４頂点の座標</param>
        /// <param name="dst">出力画像中の対応する矩形の４頂点の座標</param>
        /// <returns>求められた 3×3の射影変換行列</returns>
#else
        /// <summary>
        /// Calculates perspective transform from 4 corresponding points.
        /// </summary>
        /// <param name="src">Coordinates of 4 quadrangle vertices in the source image. </param>
        /// <param name="dst">Coordinates of the 4 corresponding quadrangle vertices in the destination image. </param>
        /// <returns></returns>
#endif
        public static CvMat GetPerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst)
        {
            CvMat mapMatrix;
            return GetPerspectiveTransform(src, dst, out mapMatrix);
        }
#if LANG_JP
        /// <summary>
        /// 4点とそれぞれに対応する点を用いて透視変換行列を求める (3 x 3 のCV_32FC1型).
        /// </summary>
        /// <param name="src">入力画像中の矩形の４頂点の座標</param>
        /// <param name="dst">出力画像中の対応する矩形の４頂点の座標</param>
        /// <param name="mapMatrix">出力される 3×3の射影変換行列</param>
        /// <returns>求められた 3×3の射影変換行列</returns>
#else
        /// <summary>
        /// Calculates perspective transform from 4 corresponding points.
        /// </summary>
        /// <param name="src">Coordinates of 4 quadrangle vertices in the source image. </param>
        /// <param name="dst">Coordinates of the 4 corresponding quadrangle vertices in the destination image. </param>
        /// <param name="mapMatrix">Pointer to the destination 3×3 matrix. </param>
        /// <returns></returns>
#endif
        public static CvMat GetPerspectiveTransform(CvPoint2D32f[] src, CvPoint2D32f[] dst, out CvMat mapMatrix)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src.Length != 4 || dst.Length != 4)
                throw new ArgumentException("Length of src/dst must be 4.");

            IntPtr mapMatrixPtr = CvInvoke.cvCreateMat(3, 3, MatrixType.F32C1);
            CvInvoke.cvGetPerspectiveTransform(src, dst, mapMatrixPtr);
            mapMatrix = new CvMat(mapMatrixPtr);
            return mapMatrix;
        }
#if LANG_JP
        /// <summary>
        /// 4点とそれぞれに対応する点を用いて透視変換行列を求める (3 x 3 のCV_32FC1型). GetPerspectiveTransformのエイリアス.
        /// </summary>
        /// <param name="src">入力画像中の矩形の４頂点の座標</param>
        /// <param name="dst">出力画像中の対応する矩形の４頂点の座標</param>
        /// <returns>求められた 3×3の射影変換行列</returns>
#else
        /// <summary>
        /// Calculates perspective transform from 4 corresponding points.
        /// </summary>
        /// <param name="src">Coordinates of 4 quadrangle vertices in the source image. </param>
        /// <param name="dst">Coordinates of the 4 corresponding quadrangle vertices in the destination image. </param>
        /// <returns></returns>
#endif
        public static CvMat WarpPerspectiveQMatrix(CvPoint2D32f[] src, CvPoint2D32f[] dst)
        {
            return GetPerspectiveTransform(src, dst);
        }
#if LANG_JP
        /// <summary>
        /// 4点とそれぞれに対応する点を用いて透視変換行列を求める (3 x 3 のCV_32FC1型).GetPerspectiveTransformのエイリアス.
        /// </summary>
        /// <param name="src">入力画像中の矩形の４頂点の座標</param>
        /// <param name="dst">出力画像中の対応する矩形の４頂点の座標</param>
        /// <param name="mapMatrix">出力される 3×3の射影変換行列</param>
        /// <returns>求められた 3×3の射影変換行列</returns>
#else
        /// <summary>
        /// Calculates perspective transform from 4 corresponding points.
        /// </summary>
        /// <param name="src">Coordinates of 4 quadrangle vertices in the source image. </param>
        /// <param name="dst">Coordinates of the 4 corresponding quadrangle vertices in the destination image. </param>
        /// <param name="mapMatrix">Pointer to the destination 3×3 matrix. </param>
        /// <returns></returns>
#endif
        public static CvMat WarpPerspectiveQMatrix(CvPoint2D32f[] src, CvPoint2D32f[] dst, out CvMat mapMatrix)
        {
            return GetPerspectiveTransform(src, dst, out mapMatrix);
        }
        #endregion
        #region GetQuadrangleSubPix
#if LANG_JP
        /// <summary>
        /// 四角形領域のピクセル値を画像からサブピクセル精度で取得する（画像の回転＋並進移動を行なう）.
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">抽出された矩形</param>
        /// <param name="mapMatrix">2 × 3 の変換行列[A|b]</param>
#else
        /// <summary>
        /// Retrieves pixel quadrangle from image with sub-pixel accuracy.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Extracted quadrangle. </param>
        /// <param name="mapMatrix">The transformation 2 × 3 matrix [A|b]. </param>
#endif
        public static void GetQuadrangleSubPix(CvArr src, CvArr dst, CvMat mapMatrix)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (mapMatrix == null)
                throw new ArgumentNullException("mapMatrix");
            CvInvoke.cvGetQuadrangleSubPix(src.CvPtr, dst.CvPtr, mapMatrix.CvPtr);
        }
        #endregion
        #region GetRawData
#if LANG_JP
        /// <summary>
        /// 配列の低レベル情報を取り出す
        /// </summary>
        /// <param name="arr">配列ヘッダ.</param>
        /// <param name="data">出力である全画像の原点へのポインタ，あるいは ROI が設定されている場合は ROI の原点へのポインタ．</param>
#else
        /// <summary>
        /// Retrieves low-level information about the array
        /// </summary>
        /// <param name="arr">Array header. </param>
        /// <param name="data">Output pointer to the whole image origin or ROI origin if ROI is set. </param>
#endif
        public static void GetRawData(CvArr arr, out IntPtr data)
        {
            int step;
            CvSize roiSize;
            GetRawData(arr, out data, out step, out roiSize);
        }
#if LANG_JP
        /// <summary>
        /// 配列の低レベル情報を取り出す
        /// </summary>
        /// <param name="arr">配列ヘッダ.</param>
        /// <param name="data">出力である全画像の原点へのポインタ，あるいは ROI が設定されている場合は ROI の原点へのポインタ．</param>
        /// <param name="step">出力であるバイト単位で表された行の長さ．</param>
#else
        /// <summary>
        /// Retrieves low-level information about the array
        /// </summary>
        /// <param name="arr">Array header. </param>
        /// <param name="data">Output pointer to the whole image origin or ROI origin if ROI is set. </param>
        /// <param name="step">Output full row length in bytes. </param>
#endif
        public static void GetRawData(CvArr arr, out IntPtr data, out int step)
        {
            CvSize roiSize;
            GetRawData(arr, out data, out step, out roiSize);
        }
#if LANG_JP
        /// <summary>
        /// 配列の低レベル情報を取り出す
        /// </summary>
        /// <param name="arr">配列ヘッダ.</param>
        /// <param name="data">出力である全画像の原点へのポインタ，あるいは ROI が設定されている場合は ROI の原点へのポインタ．</param>
        /// <param name="step">出力であるバイト単位で表された行の長さ．</param>
        /// <param name="roiSize">出力であるROI サイズ．</param>
#else
        /// <summary>
        /// Retrieves low-level information about the array
        /// </summary>
        /// <param name="arr">Array header. </param>
        /// <param name="data">Output pointer to the whole image origin or ROI origin if ROI is set. </param>
        /// <param name="step">Output full row length in bytes. </param>
        /// <param name="roiSize">Output ROI size. </param>
#endif
        public static void GetRawData(CvArr arr, out IntPtr data, out int step, out CvSize roiSize)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            
            data = IntPtr.Zero;
            step = 1;
            roiSize = new CvSize();
            CvInvoke.cvGetRawData(arr.CvPtr, ref data, ref step, ref roiSize);
        }
        #endregion
        #region GetReal*D
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の特定の要素を返す．配列がマルチチャンネルの場合は，ランタイムエラーが発生する．
        /// </summary>
        /// <param name="arr">入力配列．シングルチャンネルでなくてはならない．</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素の値. 指定したノードが存在しなければ，この関数は0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel array
        /// </summary>
        /// <param name="arr">Input array. Must have a single channel. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <returns>the particular element of single-channel array.</returns>
#endif
        public static double GetReal1D(CvArr arr, int idx0)
        {
            return CvInvoke.cvGetReal1D(arr.CvPtr, idx0);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の特定の要素を返す．配列がマルチチャンネルの場合は，ランタイムエラーが発生する．
        /// </summary>
        /// <param name="arr">入力配列．シングルチャンネルでなくてはならない．</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素の値. 指定したノードが存在しなければ，この関数は0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel array
        /// </summary>
        /// <param name="arr">Input array. Must have a single channel. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <returns>the particular element of single-channel array.</returns>
#endif
        public static double GetReal2D(CvArr arr, int idx0, int idx1)
        {
            return CvInvoke.cvGetReal2D(arr.CvPtr, idx0, idx1);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の特定の要素を返す．配列がマルチチャンネルの場合は，ランタイムエラーが発生する．
        /// </summary>
        /// <param name="arr">入力配列．シングルチャンネルでなくてはならない．</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素の値. 指定したノードが存在しなければ，この関数は0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel array
        /// </summary>
        /// <param name="arr">Input array. Must have a single channel. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <returns>the particular element of single-channel array.</returns>
#endif
        public static double GetReal3D(CvArr arr, int idx0, int idx1, int idx2)
        {
            return CvInvoke.cvGetReal3D(arr.CvPtr, idx0, idx1, idx2);
        }
#if LANG_JP
        /// <summary>
        /// シングルチャンネルの配列の特定の要素を返す．配列がマルチチャンネルの場合は，ランタイムエラーが発生する．
        /// </summary>
        /// <param name="arr">入力配列．シングルチャンネルでなくてはならない．</param>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素の値. 指定したノードが存在しなければ，この関数は0を返す（この関数によって新しいノードは生成されない）．</returns>
#else
        /// <summary>
        /// Return the particular element of single-channel array
        /// </summary>
        /// <param name="arr">Input array. Must have a single channel. </param>
        /// <param name="idx">Array of the element indices </param>
        /// <returns>the particular element of single-channel array.</returns>
#endif
        public static double GetRealND(CvArr arr, params int[] idx)
        {
            return CvInvoke.cvGetRealND(arr.CvPtr, idx);
        }
        #endregion
        #region GetRectSubPix
#if LANG_JP
        /// <summary>
        /// 矩形領域のピクセル値を画像からサブピクセル精度で取得する（画像の並進移動を行なう）.
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">抽出された矩形</param>
        /// <param name="center">入力画像中にある抽出された矩形中心の浮動小数点型座標．中心は画像中になければならない．</param>
#else
        /// <summary>
        /// Retrieves pixel rectangle from image with sub-pixel accuracy.
        /// </summary>
        /// <param name="src">Source image. </param>
        /// <param name="dst">Extracted rectangle. </param>
        /// <param name="center">Floating point coordinates of the extracted rectangle center within the source image. The center must be inside the image. </param>
#endif
        public static void GetRectSubPix(CvArr src, CvArr dst, CvPoint2D32f center)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvGetRectSubPix(src.CvPtr, dst.CvPtr, center);
        }
        #endregion
        #region GetRootFileNode
#if LANG_JP
        /// <summary>
        /// トップレベルファイルノードの一つを返す．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <returns>トップレベルファイルノードの一つ</returns>
#else
        /// <summary>
        /// Retrieves one of top-level nodes of the file storage
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <returns>One of top-level file nodes</returns>
#endif
        public static CvFileNode GetRootFileNode(CvFileStorage fs)
        {
            return GetRootFileNode(fs, 0);
        }
#if LANG_JP
        /// <summary>
        /// トップレベルファイルノードの一つを返す．
        /// </summary>
        /// <param name="fs">ファイルストレージ</param>
        /// <param name="streamIndex">0から始まるストリームのインデックス．多くの場合，ファイル中に存在するのは一つのストームであるが，複数にもなり得る．</param>
        /// <returns>トップレベルファイルノードの一つ</returns>
#else
        /// <summary>
        /// Retrieves one of top-level nodes of the file storage
        /// </summary>
        /// <param name="fs">File storage. </param>
        /// <param name="streamIndex">Zero-based index of the stream. In most cases, there is only one stream in the file, however there can be several. </param>
        /// <returns>One of top-level file nodes</returns>
#endif
        public static CvFileNode GetRootFileNode(CvFileStorage fs, int streamIndex)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            IntPtr result = CvInvoke.cvGetRootFileNode(fs.CvPtr, streamIndex);
            if (result != IntPtr.Zero)
                return new CvFileNode(result);
            else
                return null;
        }
        #endregion
        #region GetRotationMatrix2D
#if LANG_JP
        /// <summary>
        /// 2次元回転のアフィン行列を計算する (2 x 3 のCV_32FC1型). 引数としてoutを取るオーバーロードの簡略版.
        /// おそらくoutで出てくる行列と関数の返り値は同じなので、out引数の方を省いたものである.
        /// </summary>
        /// <param name="center">入力画像内の回転中心 </param>
        /// <param name="angle">度（degree）単位の回転角度．正の値は反時計方向の回転を意味する（座標原点は左上にあると仮定）．</param>
        /// <param name="scale">等方性スケーリング係数（x,y方向とも同じ係数 scale を使う） </param>
        /// <returns>2x3の2次元回転のアフィン行列</returns>
#else
        /// <summary>
        /// Calculates affine matrix of 2d rotation.
        /// </summary>
        /// <param name="center">Center of the rotation in the source image. </param>
        /// <param name="angle">The rotation angle in degrees. Positive values mean couter-clockwise rotation (the coordiate origin is assumed at top-left corner). </param>
        /// <param name="scale">Isotropic scale factor. </param>
        /// <returns></returns>
#endif
        public static CvMat GetRotationMatrix2D(CvPoint2D32f center, double angle, double scale)
        {
            CvMat mapMatrix;
            return _2DRotationMatrix(center, angle, scale, out mapMatrix);
        }
#if LANG_JP
        /// <summary>
        /// 2次元回転のアフィン行列を計算する (2 x 3 のCV_32FC1型). 引数としてoutを取るオーバーロードの簡略版.
        /// おそらくoutで出てくる行列と関数の返り値は同じなので、out引数の方を省いたものである.
        /// </summary>
        /// <param name="center">入力画像内の回転中心 </param>
        /// <param name="angle">度（degree）単位の回転角度．正の値は反時計方向の回転を意味する（座標原点は左上にあると仮定）．</param>
        /// <param name="scale">等方性スケーリング係数（x,y方向とも同じ係数 scale を使う） </param>
        /// <returns>2x3の2次元回転のアフィン行列</returns>
#else
        /// <summary>
        /// Calculates affine matrix of 2d rotation.
        /// </summary>
        /// <param name="center">Center of the rotation in the source image. </param>
        /// <param name="angle">The rotation angle in degrees. Positive values mean couter-clockwise rotation (the coordiate origin is assumed at top-left corner). </param>
        /// <param name="scale">Isotropic scale factor. </param>
        /// <returns></returns>
#endif
        public static CvMat _2DRotationMatrix(CvPoint2D32f center, double angle, double scale)
        {
            CvMat mapMatrix;
            return _2DRotationMatrix(center, angle, scale, out mapMatrix);
        }
#if LANG_JP
        /// <summary>
        /// 2次元回転のアフィン行列を計算する (2 x 3 のCV_32FC1型). 
        /// </summary>
        /// <param name="center">入力画像内の回転中心 </param>
        /// <param name="angle">度（degree）単位の回転角度．正の値は反時計方向の回転を意味する（座標原点は左上にあると仮定）．</param>
        /// <param name="scale">等方性スケーリング係数（x,y方向とも同じ係数 scale を使う） </param>
        /// <param name="mapMatrix">出力される 2x3の行列</param>
        /// <returns>2x3の2次元回転のアフィン行列</returns>
#else
        /// <summary>
        /// Calculates affine matrix of 2d rotation.
        /// </summary>
        /// <param name="center">Center of the rotation in the source image. </param>
        /// <param name="angle">The rotation angle in degrees. Positive values mean couter-clockwise rotation (the coordiate origin is assumed at top-left corner). </param>
        /// <param name="scale">Isotropic scale factor. </param>
        /// <param name="mapMatrix">Pointer to the destination 2×3 matrix. </param>
        /// <returns>The transformation maps the rotation center to itself. If this is not the purpose, the shift should be adjusted.</returns>
#endif
        public static CvMat _2DRotationMatrix(CvPoint2D32f center, double angle, double scale, out CvMat mapMatrix)
        {
            IntPtr mapMatrixPtr = CvInvoke.cvCreateMat(2, 3, MatrixType.F32C1);
            CvInvoke.cv2DRotationMatrix(center, angle, scale, mapMatrixPtr);
            mapMatrix = new CvMat(mapMatrixPtr);
            return mapMatrix;
        }
        #endregion
        #region GetRow
#if LANG_JP
        /// <summary>
        /// 指定された行を返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="row">選択した行の，0を基準としたインデックス．</param>
        /// <returns>指定された範囲の行</returns>
#else
        /// <summary>
        /// Returns array row
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="submat">Reference to the resulting sub-array header. </param>
        /// <param name="row">Zero-based index of the selected row. </param>
        /// <returns></returns>
#endif
        public static CvMat GetRow(CvArr arr, out CvMat submat, int row)
        {
            return GetRows(arr, out submat, row, row + 1, 1);
        }
#if LANG_JP
        /// <summary>
        /// 指定された範囲の行（複数行）を返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="startRow">範囲の最初の（この値を含む）行の，0を基準としたインデックス．</param>
        /// <param name="endRow">範囲の最後の（この値を含まない）行の，0を基準としたインデックス．</param>
        /// <returns>指定された範囲の行</returns>
#else
        /// <summary>
        /// Returns array row span
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="submat">Reference to the resulting sub-array header. </param>
        /// <param name="startRow">Zero-based index of the starting row (inclusive) of the span. </param>
        /// <param name="endRow">Zero-based index of the ending row (exclusive) of the span. </param>
        /// <returns></returns>
#endif
        public static CvMat GetRows(CvArr arr, out CvMat submat, int startRow, int endRow)
        {
            return GetRows(arr, out submat, startRow, endRow, 1);
        }
#if LANG_JP
        /// <summary>
        /// 指定された範囲の行（複数行）を返す
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="startRow">範囲の最初の（この値を含む）行の，0を基準としたインデックス．</param>
        /// <param name="endRow">範囲の最後の（この値を含まない）行の，0を基準としたインデックス．</param>
        /// <param name="deltaRow">行の範囲のインデックス間隔． この関数は，start_rowからend_row（は含まない）まで，delta_row毎に行を抽出する. </param>
        /// <returns>指定された範囲の行</returns>
#else
        /// <summary>
        /// Returns array row span
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="submat">Reference to the resulting sub-array header. </param>
        /// <param name="startRow">Zero-based index of the starting row (inclusive) of the span. </param>
        /// <param name="endRow">Zero-based index of the ending row (exclusive) of the span. </param>
        /// <param name="deltaRow">Index step in the row span. That is, the function extracts every delta_row-th row from start_row and up to (but not including) end_row. </param>
        /// <returns></returns>
#endif
        public static CvMat GetRows(CvArr arr, out CvMat submat, int startRow, int endRow, int deltaRow)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            submat = new CvMat(false);
            IntPtr result = CvInvoke.cvGetRows(arr.CvPtr, submat.CvPtr, startRow, endRow, deltaRow);
            return new CvMat(result, false);
        }
        #endregion
        #region GetSeqElem
#if LANG_JP
        /// <summary>
        /// 与えられたインデックスを持つ要素をシーケンスの中から求め，その要素を返す．
        /// </summary>
        /// <typeparam name="T">出力オブジェクトの型</typeparam>
        /// <param name="seq">シーケンス</param>
        /// <param name="index">要素のインデックス. 負のインデックスの指定も可能で, 例えば，-1はシーケンスの最後の要素，-2は最後の一つ前を指す.</param>
        /// <returns>与えられたインデックスを持つ要素．要素が見つからない場合はnull．</returns>
#else
        /// <summary>
        /// Returns pointer to sequence element by its index
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="index">Index of element. </param>
        /// <returns></returns>
#endif
        public static T? GetSeqElem<T>(CvSeq seq, int index) where T : struct
        {
            if (seq == null)
            {
                throw new ArgumentNullException("seq");
            }
            IntPtr result = CvInvoke.cvGetSeqElem(seq.CvPtr, index);
            if (result == IntPtr.Zero)
                return null;
            else
                return Util.ToObject<T>(result);
        }
#if LANG_JP
        /// <summary>
        /// 与えられたインデックスを持つ要素をシーケンスの中から求め，その要素を返す．
        /// </summary>
        /// <typeparam name="T">出力オブジェクトの型</typeparam>
        /// <param name="seq">シーケンス</param>
        /// <param name="index">要素のインデックス. 負のインデックスの指定も可能で, 例えば，-1はシーケンスの最後の要素，-2は最後の一つ前を指す.</param>
        /// <returns>与えられたインデックスを持つ要素．要素が見つからない場合はnull．</returns>
#else
        /// <summary>
        /// Returns pointer to sequence element by its index
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="seq">Sequence. </param>
        /// <param name="index">Index of element. </param>
        /// <returns></returns>
#endif
        public static T? GetSeqElem<T>(CvSeq<T> seq, int index) where T : struct
        {
            return GetSeqElem<T>((CvSeq)seq, index);
        }
        #endregion
        #region GetSeqReaderPos
#if LANG_JP
        /// <summary>
        /// 現在のリーダの位置（0 ... reader->seq->total - 1 の範囲）を返す．
        /// </summary>
        /// <param name="reader">リーダの状態</param>
        /// <returns>リーダの位置</returns>
#else
        /// <summary>
        /// Returns the current reader position
        /// </summary>
        /// <param name="reader">Reader state. </param>
        /// <returns>the current reader position</returns>
#endif
        public static int GetSeqReaderPos(CvSeqReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            return CvInvoke.cvGetSeqReaderPos(reader.CvPtr);
        }
        #endregion
        #region GetSetElem
#if LANG_JP
        /// <summary>
        /// インデックスによってセットの要素を検索する
        /// </summary>
        /// <param name="setHeader">セット．</param>
        /// <param name="index">シーケンスの中のセットの要素のインデックス．</param>
        /// <returns>見つけた要素への参照</returns>
#else
        /// <summary>
        /// Finds set element by its index
        /// </summary>
        /// <param name="setHeader">Set. </param>
        /// <param name="index">Index of the set element within a sequence. </param>
        /// <returns>the pointer to it or null if the index is invalid or the corresponding node is free.</returns>
#endif
        public static CvSetElem GetSetElem(CvSet setHeader, int index)
        {
            if (setHeader == null)
                throw new ArgumentNullException("setHeader");

            IntPtr result = GetSetElemInternal(setHeader, index);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSetElem(result);
        }
        internal static IntPtr GetSetElemInternal(CvSet setHeader, int index)
        {
            unsafe
            {
                WCvSetElem* elem = (WCvSetElem*)CvInvoke.cvGetSeqElem(setHeader.CvPtr, index);
                IntPtr elemPtr = new IntPtr(elem);
                return (elem != null && IS_SET_ELEM(elemPtr)) ? elemPtr : IntPtr.Zero;
            }
        }
        #endregion
        #region GetSize
#if LANG_JP
        /// <summary>
        /// 行列または画像の ROI のサイズを返す
        /// </summary>
        /// <param name="arr">配列のヘッダ</param>
        /// <returns>サイズ</returns>
#else
        /// <summary>
        /// Returns size of matrix or image ROI
        /// </summary>
        /// <param name="arr">array header. </param>
        /// <returns></returns>
#endif
        public static CvSize GetSize(CvArr arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            return CvInvoke.cvGetSize(arr.CvPtr);
        }
        #endregion
        #region GetSpatialMoments
#if LANG_JP
        /// <summary>
        /// 画像モーメント構造体から空間モーメントを計算する
        /// </summary>
        /// <param name="moments">cvMoments によって得られる画像モーメント構造体．</param>
        /// <param name="xOrder">取り出すモーメントのx方向の次数，x_order >= 0. </param>
        /// <param name="yOrder">取り出すモーメントのy方向の次数， y_order >= 0 かつ x_order + y_order &lt;= 3. </param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves spatial moment from moment state structure
        /// </summary>
        /// <param name="moments">The moment state, calculated by cvMoments</param>
        /// <param name="xOrder">x order of the retrieved moment, x_order &gt;= 0</param>
        /// <param name="yOrder">y order of the retrieved moment, y_order &gt;= 0 and x_order + y_order &lt;= 3</param>
        /// <returns>Spatial moments</returns>
#endif
        public static double GetSpatialMoment(CvMoments moments, int xOrder, int yOrder)
        {
            if (moments == null)
            {
                throw new ArgumentNullException("moments");
            }
            //return CvDll.cvGetSpatialMoment(moments.CvPtr, x_order, y_order);
            return CvInvoke.cvGetSpatialMoment(moments, xOrder, yOrder);
        }
        #endregion
        #region GetStarKeypoints
#if LANG_JP
        /// <summary>
        /// StarDetectorアルゴリズムによりキーポイントを取得する
        /// </summary>
        /// <param name="img">8ビット グレースケールの入力画像</param>
        /// <param name="storage">キーポイントが格納されるメモリストレージ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves keypoints using the StarDetector algorithm.
        /// </summary>
        /// <param name="img">The input 8-bit grayscale image</param>
        /// <param name="storage">Memory storage where the keypoints will be stored</param>
        /// <returns></returns>
#endif
        public static CvSeq GetStarKeypoints(CvArr img, CvMemStorage storage)
        {
            return GetStarKeypoints(img, storage, new CvStarDetectorParams());
        }
#if LANG_JP
        /// <summary>
        /// StarDetectorアルゴリズムによりキーポイントを取得する
        /// </summary>
        /// <param name="img">8ビット グレースケールの入力画像</param>
        /// <param name="storage">キーポイントが格納されるメモリストレージ</param>
        /// <param name="params">CvStarDetectorParams構造体としてまとめて与えられる、アルゴリズムのための各種パラメータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Retrieves keypoints using the StarDetector algorithm.
        /// </summary>
        /// <param name="img">The input 8-bit grayscale image</param>
        /// <param name="storage">Memory storage where the keypoints will be stored</param>
        /// <param name="params">Various algorithm parameters given to the structure CvStarDetectorParams</param>
        /// <returns></returns>
#endif
        public static CvSeq<CvStarKeypoint> GetStarKeypoints(CvArr img, CvMemStorage storage, CvStarDetectorParams @params)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (storage == null)
                throw new ArgumentNullException("storage");
            if (@params == null)
                @params = new CvStarDetectorParams();

            IntPtr result = CvInvoke.cvGetStarKeypoints(img.CvPtr, storage.CvPtr, @params.Struct);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvStarKeypoint>(result);
        }
        #endregion
        #region GetSubRect
#if LANG_JP
        /// <summary>
        /// 入力配列中の指定した矩形領域に相当するヘッダを返す．
        /// つまり，入力配列の一部の矩形領域を，独立した配列として扱えるようにする．この関数では ROI を考慮し，実際には ROI の部分配列が取り出される.
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="rect">着目する矩形領域の，0 を基準とした座標</param>
        /// <returns>結果として得られる部分配列のヘッダへの参照</returns>
#else
        /// <summary>
        /// Returns matrix header corresponding to the rectangular sub-array of input image or matrix
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="submat">Reference to the resultant sub-array header. </param>
        /// <param name="rect">Zero-based coordinates of the rectangle of interest. </param>
        /// <returns>Reference to the header, corresponding to a specified rectangle of the input array.</returns>
#endif
        public static CvMat GetSubRect(CvArr arr, out CvMat submat, CvRect rect)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            submat = new CvMat(false);
            IntPtr result = CvInvoke.cvGetSubRect(arr.CvPtr, submat.CvPtr, rect);
            return new CvMat(result, false);
        }
#if LANG_JP
        /// <summary>
        /// 入力配列中の指定した矩形領域に相当するヘッダを返す．
        /// つまり，入力配列の一部の矩形領域を，独立した配列として扱えるようにする．この関数では ROI を考慮し，実際には ROI の部分配列が取り出される.
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="submat">結果として得られる部分配列のヘッダへの参照</param>
        /// <param name="rect">着目する矩形領域の，0 を基準とした座標</param>
        /// <returns>結果として得られる部分配列のヘッダへの参照</returns>
#else
        /// <summary>
        /// Returns matrix header corresponding to the rectangular sub-array of input image or matrix
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="submat">Reference to the resultant sub-array header. </param>
        /// <param name="rect">Zero-based coordinates of the rectangle of interest. </param>
        /// <returns>Reference to the header, corresponding to a specified rectangle of the input array.</returns>
#endif
        public static CvMat GetSubArr(CvArr arr, out CvMat submat, CvRect rect)
        {
            return GetSubRect(arr, out submat, rect);
        }
        #endregion
        #region GetTextSize
#if LANG_JP
        /// <summary>
        /// 文字列の幅と高さを取得する
        /// </summary>
        /// <param name="textString">入力文字列</param>
        /// <param name="font">フォント構造体への参照</param>
        /// <param name="textSize">結果として得られる文字列のサイズ．文字の高さには，ベースラインより下の部分の高さは含まれない．</param>
        /// <param name="baseline">文字の最下点から見たベースラインのy座標</param>
#else
        /// <summary>
        /// Retrieves width and height of text string
        /// </summary>
        /// <param name="textString">Input string. </param>
        /// <param name="font">Reference to the font structure. </param>
        /// <param name="textSize">Resultant size of the text string. Height of the text does not include the height of character parts that are below the baseline. </param>
        /// <param name="baseline">y-coordinate of the baseline relatively to the bottom-most text point. </param>
#endif
        public static void GetTextSize(string textString, CvFont font, out CvSize textSize, out int baseline)
        {
            if (textString == null)
                throw new ArgumentNullException("textString");
            if (font == null)
                throw new ArgumentNullException("font");
            CvInvoke.cvGetTextSize(textString, font.CvPtr, out textSize, out baseline);
        }
        #endregion
        #region GetTickCount
#if LANG_JP
        /// <summary>
        /// プラットフォーム依存の開始時点からのtics数（スタートアップからのCPU ticks数，1970年からのミリ秒等）を返す．
        /// </summary>
        /// <returns>プラットフォーム依存の開始時点からのticks数</returns>
#else
        /// <summary>
        /// Returns number of tics starting from some platform-dependent event (number of CPU ticks from the startup, number of milliseconds from 1970th year etc.).
        /// </summary>
        /// <returns>Number of tics</returns>
#endif
        public static long GetTickCount()
        {
            return CvInvoke.cvGetTickCount();
        }
        #endregion
        #region GetTickFrequency
#if LANG_JP
        /// <summary>
        /// 1マイクロ秒あたりのtics数を返す． 
        /// </summary>
        /// <returns>1マイクロ秒あたりのticks数</returns>
#else
        /// <summary>
        /// Returns number of tics per microsecond
        /// </summary>
        /// <returns>number of tics per microsecond.</returns>
#endif
        public static double GetTickFrequency()
        {
            return CvInvoke.cvGetTickFrequency();
        }
        #endregion
        #region GetThreadNum
#if LANG_JP
        /// <summary>
        /// 現在のスレッドのインデックスを返す
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns index of the current thread
        /// </summary>
        /// <returns></returns>
#endif
        public static int GetThreadNum()
        {
            return CvInvoke.cvGetThreadNum();
        }
        #endregion
        #region GetTrackbarPos
#if LANG_JP
        /// <summary>
        /// 指定されたトラックバーの現在位置を返す
        /// </summary>
        /// <param name="trackbarName">トラックバーの名前</param>
        /// <param name="windowName">トラックバーの親ウィンドウの名前</param>
        /// <returns>トラックバーの現在位置</returns>
#else
        /// <summary>
        /// Returns the current position of the specified trackbar.
        /// </summary>
        /// <param name="trackbarName">Name of trackbar. </param>
        /// <param name="windowName">Name of the window which is the parent of trackbar. </param>
        /// <returns>the current position of the specified trackbar.</returns>
#endif
        public static int GetTrackbarPos(string trackbarName, string windowName)
        {
            return CvInvoke.cvGetTrackbarPos(trackbarName, windowName);
        }
        #endregion
        #region GetValidDisparityROI
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi1"></param>
        /// <param name="roi2"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
        /// <param name="SADWindowSize"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roi1"></param>
        /// <param name="roi2"></param>
        /// <param name="minDisparity"></param>
        /// <param name="numberOfDisparities"></param>
        /// <param name="SADWindowSize"></param>
        /// <returns></returns>
#endif
// ReSharper disable InconsistentNaming
        public static CvRect GetValidDisparityROI(CvRect roi1, CvRect roi2, int minDisparity, int numberOfDisparities, int SADWindowSize)
// ReSharper restore InconsistentNaming
        {
            return CvInvoke.cvGetValidDisparityROI(roi1, roi2, minDisparity, numberOfDisparities, SADWindowSize);
        }
        #endregion
        #region GetWindowHandle
#if LANG_JP
        /// <summary>
        /// ネイティブウィンドウハンドル（Win32 の 場合は HWND，GTK+ の場合は GtkWidget）を返す.
        /// </summary>
        /// <param name="name">ウィンドウの名前</param>
        /// <returns>ウィンドウハンドル</returns>
#else
        /// <summary>
        /// Returns native window handle (HWND in case of Win32 and GtkWidget in case of GTK+). 
        /// </summary>
        /// <param name="name">Name of the window. </param>
        /// <returns>HWND in case of Win32 and GtkWidget in case of GTK+</returns>
#endif
        public static IntPtr GetWindowHandle(string name)
        {
            return CvInvoke.cvGetWindowHandle(name);
        }
        #endregion
        #region GetWindowName
#if LANG_JP
        /// <summary>
        /// 与えられたネイティブウィンドウハンドル（Win32 の場合は HWND，GTK+ の場合は GtkWidget）が示すウィンドウの名前を返す．
        /// </summary>
        /// <param name="windowHandle">ウィンドウのハンドル</param>
        /// <returns>ウィンドウの名前</returns>
#else
        /// <summary>
        /// Returns the name of window given its native handle (HWND in case of Win32 and GtkWidget in case of GTK+). 
        /// </summary>
        /// <param name="windowHandle">Handle of the window. </param>
        /// <returns>Window name</returns>
#endif
        public static string GetWindowName(IntPtr windowHandle)
        {
            return CvInvoke.cvGetWindowName(windowHandle);
        }
        #endregion
        #region GetWindowProperty
#if LANG_JP
        /// <summary>
        /// ウィンドウのプロパティを取得する
        /// </summary>
        /// <param name="name">ウィンドウ名</param>
        /// <param name="propID">プロパティの種類</param>
        /// <returns>プロパティの値</returns>
#else
        /// <summary>
        /// Get Property of the window
        /// </summary>
        /// <param name="name">Window name</param>
        /// <param name="propID">Property identifier</param>
        /// <returns>Value of the specified property</returns>
#endif
        public static double GetWindowProperty(string name, WindowProperty propID)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            return CvInvoke.cvGetWindowProperty(name, propID);
        }
        #endregion
        #region GoodFeaturesToTrack
#if LANG_JP
        /// <summary>
        /// 画像中から大きな固有値を持つコーナーを検出する．
        /// </summary>
        /// <param name="image">8ビット，または32ビット浮動小数点型シングルチャンネルの入力画像</param>
        /// <param name="eigImage">32ビット浮動小数点型のテンポラリ画像．サイズは image と同じである</param>
        /// <param name="tempImage">別のテンポラリ画像．サイズ・フォーマットともに eig_image と同じである</param>
        /// <param name="corners">出力パラメータ．検出されたコーナー</param>
        /// <param name="cornerCount">出力パラメータ．検出されたコーナーの数</param>
        /// <param name="qualityLevel">最大・最小の固有値に乗ずる定数（検出される画像コーナの許容最低品質を指定する）</param>
        /// <param name="minDistance">出力される画像コーナー間の許容最低距離（ユークリッド距離を用いる）</param>
#else
        /// <summary>
        /// Determines strong corners on image
        /// </summary>
        /// <param name="image">The source 8-bit or floating-point 32-bit, single-channel image. </param>
        /// <param name="eigImage">Temporary floating-point 32-bit image of the same size as image. </param>
        /// <param name="tempImage">Another temporary image of the same size and same format as eig_image. </param>
        /// <param name="corners">Output parameter. Detected corners. </param>
        /// <param name="cornerCount">Output parameter. Number of detected corners. </param>
        /// <param name="qualityLevel">Multiplier for the maxmin eigenvalue; specifies minimal accepted quality of image corners. </param>
        /// <param name="minDistance">Limit, specifying minimum possible distance between returned corners; Euclidian distance is used. </param>
#endif
        public static void GoodFeaturesToTrack(CvArr image, CvArr eigImage, CvArr tempImage, out CvPoint2D32f[] corners, ref int cornerCount, double qualityLevel, double minDistance)
        {
            GoodFeaturesToTrack(image, eigImage, tempImage, out corners, ref cornerCount, qualityLevel, minDistance, null, 3, false, 0.04);
        }
#if LANG_JP
        /// <summary>
        /// 画像中から大きな固有値を持つコーナーを検出する．
        /// </summary>
        /// <param name="image">8ビット，または32ビット浮動小数点型シングルチャンネルの入力画像</param>
        /// <param name="eigImage">32ビット浮動小数点型のテンポラリ画像．サイズは image と同じである</param>
        /// <param name="tempImage">別のテンポラリ画像．サイズ・フォーマットともに eig_image と同じである</param>
        /// <param name="corners">出力パラメータ．検出されたコーナー</param>
        /// <param name="cornerCount">出力パラメータ．検出されたコーナーの数</param>
        /// <param name="qualityLevel">最大・最小の固有値に乗ずる定数（検出される画像コーナの許容最低品質を指定する）</param>
        /// <param name="minDistance">出力される画像コーナー間の許容最低距離（ユークリッド距離を用いる）</param>
        /// <param name="mask">注目領域（ROI）．指定された領域またはmask が null の場合は画像全体から点を選ぶ</param>
#else
        /// <summary>
        /// Determines strong corners on image
        /// </summary>
        /// <param name="image">The source 8-bit or floating-point 32-bit, single-channel image. </param>
        /// <param name="eigImage">Temporary floating-point 32-bit image of the same size as image. </param>
        /// <param name="tempImage">Another temporary image of the same size and same format as eig_image. </param>
        /// <param name="corners">Output parameter. Detected corners. </param>
        /// <param name="cornerCount">Output parameter. Number of detected corners. </param>
        /// <param name="qualityLevel">Multiplier for the maxmin eigenvalue; specifies minimal accepted quality of image corners. </param>
        /// <param name="minDistance">Limit, specifying minimum possible distance between returned corners; Euclidian distance is used. </param>
        /// <param name="mask">Region of interest. The function selects points either in the specified region or in the whole image if the mask is null. </param>
#endif
        public static void GoodFeaturesToTrack(CvArr image, CvArr eigImage, CvArr tempImage, out CvPoint2D32f[] corners, ref int cornerCount, double qualityLevel, double minDistance, CvArr mask)
        {
            GoodFeaturesToTrack(image, eigImage, tempImage, out corners, ref cornerCount, qualityLevel, minDistance, mask, 3, false, 0.04);
        }
#if LANG_JP
        /// <summary>
        /// 画像中から大きな固有値を持つコーナーを検出する．
        /// </summary>
        /// <param name="image">8ビット，または32ビット浮動小数点型シングルチャンネルの入力画像</param>
        /// <param name="eigImage">32ビット浮動小数点型のテンポラリ画像．サイズは image と同じである</param>
        /// <param name="tempImage">別のテンポラリ画像．サイズ・フォーマットともに eig_image と同じである</param>
        /// <param name="corners">出力パラメータ．検出されたコーナー</param>
        /// <param name="cornerCount">出力パラメータ．検出されたコーナーの数</param>
        /// <param name="qualityLevel">最大・最小の固有値に乗ずる定数（検出される画像コーナの許容最低品質を指定する）</param>
        /// <param name="minDistance">出力される画像コーナー間の許容最低距離（ユークリッド距離を用いる）</param>
        /// <param name="mask">注目領域（ROI）．指定された領域またはmask が null の場合は画像全体から点を選ぶ</param>
        /// <param name="blockSize">平均化ブロックのサイズ．この関数で内部的に用いられる cvCornerMinEigenVal あるいは， cvCornerHarris に，この引数が渡される.</param>
#else
        /// <summary>
        /// Determines strong corners on image
        /// </summary>
        /// <param name="image">The source 8-bit or floating-point 32-bit, single-channel image. </param>
        /// <param name="eigImage">Temporary floating-point 32-bit image of the same size as image. </param>
        /// <param name="tempImage">Another temporary image of the same size and same format as eig_image. </param>
        /// <param name="corners">Output parameter. Detected corners. </param>
        /// <param name="cornerCount">Output parameter. Number of detected corners. </param>
        /// <param name="qualityLevel">Multiplier for the maxmin eigenvalue; specifies minimal accepted quality of image corners. </param>
        /// <param name="minDistance">Limit, specifying minimum possible distance between returned corners; Euclidian distance is used. </param>
        /// <param name="mask">Region of interest. The function selects points either in the specified region or in the whole image if the mask is null. </param>
        /// <param name="blockSize">Size of the averaging block, passed to underlying cvCornerMinEigenVal or cvCornerHarris used by the function. </param>
#endif
        public static void GoodFeaturesToTrack(CvArr image, CvArr eigImage, CvArr tempImage, out CvPoint2D32f[] corners, ref int cornerCount, double qualityLevel, double minDistance, CvArr mask, int blockSize)
        {
            GoodFeaturesToTrack(image, eigImage, tempImage, out corners, ref cornerCount, qualityLevel, minDistance, mask, blockSize, false, 0.04);
        }
#if LANG_JP
        /// <summary>
        /// 画像中から大きな固有値を持つコーナーを検出する．
        /// </summary>
        /// <param name="image">8ビット，または32ビット浮動小数点型シングルチャンネルの入力画像</param>
        /// <param name="eigImage">32ビット浮動小数点型のテンポラリ画像．サイズは image と同じである</param>
        /// <param name="tempImage">別のテンポラリ画像．サイズ・フォーマットともに eig_image と同じである</param>
        /// <param name="corners">出力パラメータ．検出されたコーナー</param>
        /// <param name="cornerCount">出力パラメータ．検出されたコーナーの数</param>
        /// <param name="qualityLevel">最大・最小の固有値に乗ずる定数（検出される画像コーナの許容最低品質を指定する）</param>
        /// <param name="minDistance">出力される画像コーナー間の許容最低距離（ユークリッド距離を用いる）</param>
        /// <param name="mask">注目領域（ROI）．指定された領域またはmask が null の場合は画像全体から点を選ぶ</param>
        /// <param name="blockSize">平均化ブロックのサイズ．この関数で内部的に用いられる cvCornerMinEigenVal あるいは， cvCornerHarris に，この引数が渡される.</param>
        /// <param name="useHarris">trueの場合は，デフォルトの cvCornerMinEigenVal の代わりに，Harris検出器（cvCornerHarris）を用いる</param>
#else
        /// <summary>
        /// Determines strong corners on image
        /// </summary>
        /// <param name="image">The source 8-bit or floating-point 32-bit, single-channel image. </param>
        /// <param name="eigImage">Temporary floating-point 32-bit image of the same size as image. </param>
        /// <param name="tempImage">Another temporary image of the same size and same format as eig_image. </param>
        /// <param name="corners">Output parameter. Detected corners. </param>
        /// <param name="cornerCount">Output parameter. Number of detected corners. </param>
        /// <param name="qualityLevel">Multiplier for the maxmin eigenvalue; specifies minimal accepted quality of image corners. </param>
        /// <param name="minDistance">Limit, specifying minimum possible distance between returned corners; Euclidian distance is used. </param>
        /// <param name="mask">Region of interest. The function selects points either in the specified region or in the whole image if the mask is null. </param>
        /// <param name="blockSize">Size of the averaging block, passed to underlying cvCornerMinEigenVal or cvCornerHarris used by the function. </param>
        /// <param name="useHarris">If true, Harris operator (cvCornerHarris) is used instead of default cvCornerMinEigenVal. </param>
#endif
        public static void GoodFeaturesToTrack(CvArr image, CvArr eigImage, CvArr tempImage, out CvPoint2D32f[] corners, ref int cornerCount, double qualityLevel, double minDistance, CvArr mask, int blockSize, bool useHarris)
        {
            GoodFeaturesToTrack(image, eigImage, tempImage, out corners, ref cornerCount, qualityLevel, minDistance, mask, blockSize, useHarris, 0.04);
        }
#if LANG_JP
        /// <summary>
        /// 画像中から大きな固有値を持つコーナーを検出する．
        /// </summary>
        /// <param name="image">8ビット，または32ビット浮動小数点型シングルチャンネルの入力画像</param>
        /// <param name="eigImage">32ビット浮動小数点型のテンポラリ画像．サイズは image と同じである</param>
        /// <param name="tempImage">別のテンポラリ画像．サイズ・フォーマットともに eig_image と同じである</param>
        /// <param name="corners">出力パラメータ．検出されたコーナー</param>
        /// <param name="cornerCount">出力パラメータ．検出されたコーナーの数</param>
        /// <param name="qualityLevel">最大・最小の固有値に乗ずる定数（検出される画像コーナの許容最低品質を指定する）</param>
        /// <param name="minDistance">出力される画像コーナー間の許容最低距離（ユークリッド距離を用いる）</param>
        /// <param name="mask">注目領域（ROI）．指定された領域またはmask が null の場合は画像全体から点を選ぶ</param>
        /// <param name="blockSize">平均化ブロックのサイズ．この関数で内部的に用いられる cvCornerMinEigenVal あるいは， cvCornerHarris に，この引数が渡される.</param>
        /// <param name="useHarris">trueの場合は，デフォルトの cvCornerMinEigenVal の代わりに，Harris検出器（cvCornerHarris）を用いる</param>
        /// <param name="k">Harris検出器のパラメータ（use_harris==true のときのみ使用）</param>
#else
        /// <summary>
        /// Determines strong corners on image
        /// </summary>
        /// <param name="image">The source 8-bit or floating-point 32-bit, single-channel image. </param>
        /// <param name="eigImage">Temporary floating-point 32-bit image of the same size as image. </param>
        /// <param name="tempImage">Another temporary image of the same size and same format as eig_image. </param>
        /// <param name="corners">Output parameter. Detected corners. </param>
        /// <param name="cornerCount">Output parameter. Number of detected corners. </param>
        /// <param name="qualityLevel">Multiplier for the maxmin eigenvalue; specifies minimal accepted quality of image corners. </param>
        /// <param name="minDistance">Limit, specifying minimum possible distance between returned corners; Euclidian distance is used. </param>
        /// <param name="mask">Region of interest. The function selects points either in the specified region or in the whole image if the mask is null. </param>
        /// <param name="blockSize">Size of the averaging block, passed to underlying cvCornerMinEigenVal or cvCornerHarris used by the function. </param>
        /// <param name="useHarris">If true, Harris operator (cvCornerHarris) is used instead of default cvCornerMinEigenVal. </param>
        /// <param name="k">Free parameter of Harris detector; used only if use_harris is true.</param>
#endif
        public static void GoodFeaturesToTrack(CvArr image, CvArr eigImage, CvArr tempImage, out CvPoint2D32f[] corners, ref int cornerCount, double qualityLevel, double minDistance, CvArr mask, int blockSize, bool useHarris, double k)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (eigImage == null)
                throw new ArgumentNullException("eigImage");
            if (tempImage == null)
                throw new ArgumentNullException("tempImage");
            if (cornerCount < 1)
                throw new ArgumentOutOfRangeException("corners");

            corners = new CvPoint2D32f[cornerCount];
            IntPtr maskPtr = (mask == null) ? IntPtr.Zero : mask.CvPtr;

            CvInvoke.cvGoodFeaturesToTrack(image.CvPtr, eigImage.CvPtr, tempImage.CvPtr, corners, ref cornerCount, qualityLevel, minDistance, maskPtr, blockSize, useHarris, k);
        }
        #endregion
        #region GrabFrame
#if LANG_JP
        /// <summary>
        /// カメラやファイルからフレームを取り出す．取り出されたフレームは内部的に保存される．
        /// 取り出されたフレームをユーザ側で利用するためには，cvRetrieveFrame を用いるべきである．
        /// </summary>
        /// <param name="capture">ビデオキャプチャクラス</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Grabs the frame from camera or file. The grabbed frame is stored internally. 
        /// The purpose of this function is to grab frame fast that is important for syncronization in case of reading from several cameras simultaneously. 
        /// The grabbed frames are not exposed because they may be stored in compressed format (as defined by camera/driver). 
        /// To retrieve the grabbed frame, cvRetrieveFrame should be used. 
        /// </summary>
        /// <param name="capture">video capturing structure. </param>
        /// <returns></returns>
#endif
        public static int GrabFrame(CvCapture capture)
        {
            if (capture == null)
            {
                throw new ArgumentNullException("capture");
            }
            return CvInvoke.cvGrabFrame(capture.CvPtr);
        }
        #endregion
        #region GraphAddVtx
#if LANG_JP
        /// <summary>
        /// グラフに頂点を追加する
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <returns>頂点のインデックス</returns>
#else
        /// <summary>
        /// Adds vertex to graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <returns>The function cvGraphAddVtx adds a vertex to the graph and returns the vertex index.</returns>
#endif
        public static int GraphAddVtx(CvGraph graph)
        {
            return GraphAddVtx(graph, null);
        }
#if LANG_JP
        /// <summary>
        /// グラフに頂点を追加する
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtx">追加される頂点の初期化に使用される，オプションの入力引数（sizeof(CvGraphVtx)の領域を超えたユーザー定義フィールドのみコピーされる）． </param>
        /// <returns>頂点のインデックス</returns>
#else
        /// <summary>
        /// Adds vertex to graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtx">Optional input argument used to initialize the added vertex (only user-defined fields beyond sizeof(CvGraphVtx) are copied). </param>
        /// <returns>The function cvGraphAddVtx adds a vertex to the graph and returns the vertex index.</returns>
#endif
        public static int GraphAddVtx(CvGraph graph, CvGraphVtx vtx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            IntPtr vtxPtr = (vtx == null) ? IntPtr.Zero : vtx.CvPtr;
            IntPtr insertedVtxPtr = IntPtr.Zero;
            return CvInvoke.cvGraphAddVtx(graph.CvPtr, vtxPtr, ref insertedVtxPtr);
        }
#if LANG_JP
        /// <summary>
        /// グラフに頂点を追加する
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtx">追加される頂点の初期化に使用される，オプションの入力引数（sizeof(CvGraphVtx)の領域を超えたユーザー定義フィールドのみコピーされる）． </param>
        /// <param name="insertedVtx">新しい頂点のアドレスがここに書かれる．</param>
        /// <returns>頂点のインデックス</returns>
#else
        /// <summary>
        /// Adds vertex to graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtx">Optional input argument used to initialize the added vertex (only user-defined fields beyond sizeof(CvGraphVtx) are copied). </param>
        /// <param name="insertedVtx">The address of the new vertex is written there. </param>
        /// <returns>The function cvGraphAddVtx adds a vertex to the graph and returns the vertex index.</returns>
#endif
        public static int GraphAddVtx(CvGraph graph, CvGraphVtx vtx, out CvGraphVtx insertedVtx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            IntPtr vtxPtr = (vtx == null) ? IntPtr.Zero : vtx.CvPtr;
            insertedVtx = new CvGraphVtx();
            IntPtr insertedVtxPtr = insertedVtx.CvPtr;
            return CvInvoke.cvGraphAddVtx(graph.CvPtr, vtxPtr, ref insertedVtxPtr);
        }
        #endregion
        #region GraphAddEdge
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（インデックス指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="startIdx">辺の始点を示すインデックス</param>
        /// <param name="endIdx">辺の終点を示すインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public static int GraphAddEdge(CvGraph graph, int startIdx, int endIdx)
        {
            return GraphAddEdge(graph, startIdx, endIdx, null);
        }
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（インデックス指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="startIdx">辺の始点を示すインデックス</param>
        /// <param name="endIdx">辺の終点を示すインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <param name="edge">オプションの入力パラメータ．辺の初期化のためのデータ． </param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <param name="edge">Optional input parameter, initialization data for the edge. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public static int GraphAddEdge(CvGraph graph, int startIdx, int endIdx, CvGraphEdge edge)
        {
            return GraphAddEdge(graph, startIdx, endIdx, edge, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（インデックス指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="startIdx">辺の始点を示すインデックス</param>
        /// <param name="endIdx">辺の終点を示すインデックス．無向グラフの場合，順序はどちらでもよい． </param>
        /// <param name="edge">オプションの入力パラメータ．辺の初期化のためのデータ． </param>
        /// <param name="insertedEdge">入力された辺のアドレスを保存するための，オプションの出力パラメータ． </param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <param name="edge">Optional input parameter, initialization data for the edge. </param>
        /// <param name="insertedEdge">Optional output parameter to contain the address of the inserted edge. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public static int GraphAddEdge(CvGraph graph, int startIdx, int endIdx, CvGraphEdge edge, IntPtr insertedEdge)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            IntPtr edgePtr = (edge == null) ? IntPtr.Zero : edge.CvPtr;

            return CvInvoke.cvGraphAddEdge(graph.CvPtr, startIdx, endIdx, edgePtr, ref insertedEdge);
        }
        #endregion
        #region GraphAddEdgeByPtr
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（ポインタ指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="startVtx">辺の始点を示す頂点</param>
        /// <param name="endVtx">辺の終点を示す頂点</param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public static int GraphAddEdgeByPtr(CvGraph graph, CvGraphEdge startVtx, CvGraphEdge endVtx)
        {
            return GraphAddEdgeByPtr(graph, startVtx, endVtx, null);
        }
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（ポインタ指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="startVtx">辺の始点を示す頂点</param>
        /// <param name="endVtx">辺の終点を示す頂点</param>
        /// <param name="edge">オプションの入力パラメータ，辺の初期化データ．</param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <param name="edge">Optional input parameter, initialization data for the edge. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public static int GraphAddEdgeByPtr(CvGraph graph, CvGraphEdge startVtx, CvGraphEdge endVtx, CvGraphEdge edge)
        {
            return GraphAddEdgeByPtr(graph, startVtx, endVtx, edge, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// グラフに辺を追加する（ポインタ指定）
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="startVtx">辺の始点を示す頂点</param>
        /// <param name="endVtx">辺の終点を示す頂点</param>
        /// <param name="edge">オプションの入力パラメータ，辺の初期化データ．</param>
        /// <param name="insertedEdge">辺の集合の中で入力された辺のアドレスを保存するための，オプションの出力パラメータ．</param>
        /// <returns>追加に成功すると1を返し，すでに二つの頂点を接続する辺が存在する場合は0を返し，頂点のどちらかが存在しない，始点と終点が同じとき，他の重大な問題があるときには-1を返す．</returns>
#else
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <param name="edge">Optional input parameter, initialization data for the edge. </param>
        /// <param name="insertedEdge">Optional output parameter to contain the address of the inserted edge. </param>
        /// <returns>The function cvGraphAddEdge connects two specified vertices. The function returns 1 if the edge has been added successfully, 0 if the edge connecting the two vertices exists already and -1 if either of the vertices was not found, the starting and the ending vertex are the same or there is some other critical situation. In the latter case (i.e. when the result is negative) the function also reports an error by default.</returns>
#endif
        public static int GraphAddEdgeByPtr(CvGraph graph, CvGraphEdge startVtx, CvGraphEdge endVtx, CvGraphEdge edge, IntPtr insertedEdge)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");
            if (startVtx == null)
                throw new ArgumentNullException("startVtx");
            if (endVtx == null)
                throw new ArgumentNullException("endVtx");

            IntPtr edgePtr = (edge == null) ? IntPtr.Zero : edge.CvPtr;

            return CvInvoke.cvGraphAddEdgeByPtr(graph.CvPtr, startVtx.CvPtr, endVtx.CvPtr, edgePtr, ref insertedEdge);
        }
        #endregion
        #region GraphEdgeIdx
#if LANG_JP
        /// <summary>
        /// グラフの辺のインデックスを返す
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="edge">辺への参照</param>
        /// <returns>グラフの辺のインデックス</returns>
#else
        /// <summary>
        /// Returns index of graph edge
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="edge">Graph edge. </param>
        /// <returns>The function cvGraphEdgeIdx returns index of the graph edge.</returns>
#endif
        public static int GraphEdgeIdx(CvGraph graph, CvGraphEdge edge)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            if (edge == null)
            {
                throw new ArgumentNullException("edge");
            }

            return ((int)edge.Flags & CvConst.CV_SET_ELEM_IDX_MASK);
        }
        #endregion
        #region GraphGetEdgeCount
#if LANG_JP
        /// <summary>
        /// Returns count of edges
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns count of edges
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <returns></returns>
#endif
        public static int GraphGetEdgeCount(CvGraph graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            return graph.Edges.ActiveCount;
        }
        #endregion
        #region GraphGetVtxCount
#if LANG_JP
        /// <summary>
        /// Returns count of vertex
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns count of vertex
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <returns></returns>
#endif
        public static int GraphGetVtxCount(CvGraph graph)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            return graph.ActiveCount;
        }
        #endregion
        #region GraphRemoveEdge
#if LANG_JP
        /// <summary>
        /// グラフから辺を削除する（インデックス指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="startIdx">辺の始点を示す頂点のインデックス． </param>
        /// <param name="endIdx">辺の終点を示す頂点のインデックス．無向グラフの場合，順序はどちらでもよい． </param>
#else
        /// <summary>
        /// Removes edge from graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startIdx">Index of the starting vertex of the edge. </param>
        /// <param name="endIdx">Index of the ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <remarks>The function cvGraphRemoveEdge removes the edge connecting two specified vertices. If the vertices are not connected [in that order], the function does nothing. </remarks>
#endif
        public static void GraphRemoveEdge(CvGraph graph, int startIdx, int endIdx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            CvInvoke.cvGraphRemoveEdge(graph.CvPtr, startIdx, endIdx);
        }
        #endregion
        #region GraphRemoveEdgeByPtr
#if LANG_JP
        /// <summary>
        /// グラフから辺を削除する（ポインタ指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="startVtx">辺の始点を示す頂点へのポインタ．</param>
        /// <param name="endVtx">辺の終点を示す頂点へのポインタ．無向グラフの場合，順序はどちらでもよい． </param>
#else
        /// <summary>
        /// Removes edge from graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="startVtx">Starting vertex of the edge. </param>
        /// <param name="endVtx">Ending vertex of the edge. For unoriented graph the order of the vertex parameters does not matter. </param>
        /// <remarks>The function cvGraphRemoveEdgeByPtr removes the edge connecting two specified vertices. If the vertices are not connected [in that order], the function does nothing.</remarks>
#endif
        public static void GraphRemoveEdgeByPtr(CvGraph graph, CvGraphVtx startVtx, CvGraphVtx endVtx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            if (startVtx == null)
            {
                throw new ArgumentNullException("startVtx");
            }
            if (endVtx == null)
            {
                throw new ArgumentNullException("endVtx");
            }
            CvInvoke.cvGraphRemoveEdgeByPtr(graph.CvPtr, startVtx.CvPtr, endVtx.CvPtr);
        }
        #endregion
        #region GraphRemoveVtx
#if LANG_JP
        /// <summary>
        /// グラフから頂点を削除する（インデックス指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="index">削除される頂点のインデックス</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Removes vertex from graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="index">Index of the removed vertex. </param>
        /// <returns>The function cvGraphRemoveAddVtx removes a vertex from the graph together with all the edges incident to it. The function reports an error, if the input vertex does not belong to the graph. The return value is number of edges deleted, or -1 if the vertex does not belong to the graph.</returns>
#endif
        public static int GraphRemoveVtx(CvGraph graph, int index)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            return CvInvoke.cvGraphRemoveVtx(graph.CvPtr, index);
        }
        #endregion
        #region GraphRemoveVtxByPtr
#if LANG_JP
        /// <summary>
        /// グラフから頂点を削除する（ポインタ指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtx">削除される頂点へのポインタ</param>
        /// <returns>削除された辺の数，あるいは頂点がグラフに存在しない場合は-1</returns>
#else
        /// <summary>
        /// Removes vertex from graph
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtx">Vertex to remove </param>
        /// <returns>The function cvGraphRemoveVtxByPtr removes a vertex from the graph together with all the edges incident to it. The function reports an error, if the vertex does not belong to the graph. The return value is number of edges deleted, or -1 if the vertex does not belong to the graph.</returns>
#endif
        public static int GraphRemoveVtxByPtr(CvGraph graph, CvGraphVtx vtx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            if (vtx == null)
            {
                throw new ArgumentNullException("vtx");
            }
            return CvInvoke.cvGraphRemoveVtxByPtr(graph.CvPtr, vtx.CvPtr);
        }
        #endregion
        #region GraphVtxDegree
#if LANG_JP
        /// <summary>
        /// 頂点に接続している辺の数を数える（インデックス指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtxIdx">頂点のインデックス</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Counts edges indicent to the vertex
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtxIdx">Index of the graph vertex.  </param>
        /// <returns>The function cvGraphVtxDegree returns the number of edges incident to the specified vertex, both incoming and outcoming. </returns>
#endif
        public static int GraphVtxDegree(CvGraph graph, int vtxIdx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            return CvInvoke.cvGraphVtxDegree(graph.CvPtr, vtxIdx);
        }
        #endregion
        #region GraphVtxDegreeByPtr
#if LANG_JP
        /// <summary>
        /// 頂点に接続している辺の数を数える（ポインタ指定）
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtx">頂点へのポインタ</param>
        /// <returns>指定した頂点に接続した（入る/出る両方向の）辺の数</returns>
#else
        /// <summary>
        /// Counts edges indicent to the vertex
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtx">Index of the graph vertex.  </param>
        /// <returns>The function cvGraphVtxDegree returns the number of edges incident to the specified vertex, both incoming and outcoming.</returns>
#endif
        public static int GraphVtxDegreeByPtr(CvGraph graph, CvGraphVtx vtx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            if (vtx == null)
            {
                throw new ArgumentNullException("vtx");
            }
            return CvInvoke.cvGraphVtxDegreeByPtr(graph.CvPtr, vtx.CvPtr);
        }
        #endregion
        #region GraphVtxIdx
#if LANG_JP
        /// <summary>
        /// グラフ頂点のインデックスを返す
        /// </summary>
        /// <param name="graph">グラフ</param>
        /// <param name="vtx">グラフ頂点への参照</param>
        /// <returns>グラフ頂点のインデックスを返す</returns>
#else
        /// <summary>
        /// Returns index of graph vertex
        /// </summary>
        /// <param name="graph">Graph. </param>
        /// <param name="vtx">Graph vertex. </param>
        /// <returns>The function cvGraphVtxIdx returns index of the graph vertex.</returns>
#endif
        public static int GraphVtxIdx(CvGraph graph, CvGraphVtx vtx)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("graph");
            }
            if (vtx == null)
            {
                throw new ArgumentNullException("vtx");
            }
            return ((int)vtx.Flags & CvConst.CV_SET_ELEM_IDX_MASK);
        }
        #endregion
    }
}