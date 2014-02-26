using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Cv2
    {
        #region Abs
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static MatExpr Abs(Mat src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_abs_Mat(src.CvPtr);
            return new MatExpr(retPtr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static MatExpr Abs(MatExpr src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            IntPtr retPtr = CppInvoke.core_abs_MatExpr(src.CvPtr);
            return new MatExpr(retPtr);
        }
        #endregion
        #region Add
#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の和を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">8ビット，シングルチャンネル配列のオプションの処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>        
#else
        /// <summary>
        /// Computes the per-element sum of two arrays or an array and a scalar.
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
#endif
        public static void Add(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_add(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype);
            dst.Fix();
        }
        #endregion
        #region Subtract
#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の差を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列．</param>
        /// <param name="mask">オプション．8ビット，シングルチャンネル配列の処理マスク．出力配列内の変更される要素を表します. [既定値はnull]</param>
#else
        /// <summary>
        /// Calculates per-element difference between two arrays or array and a scalar
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array. It must have the same size and same type as src1</param>
        /// <param name="dst">The destination array; it will have the same size and same type as src1</param>
        /// <param name="mask">The optional operation mask, 8-bit single channel array; specifies elements of the destination array to be changed. [By default this is null]</param>
#endif
        public static void Subtract(InputArray src1, InputArray src2, OutputArray dst, InputArray mask = null, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_subtract(src1.CvPtr, src2.CvPtr, dst.CvPtr, ToPtr(mask), dtype);
            dst.Fix();
        }
        #endregion
        #region Multiply
#if LANG_JP
        /// <summary>
        /// 2つの配列同士の，要素毎のスケーリングされた積を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src1 と同じサイズ，同じ型の出力配列</param>
        /// <param name="scale">オプションであるスケールファクタ. [既定値は1]</param>
#else
        /// <summary>
        /// Calculates the per-element scaled product of two arrays
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array of the same size and the same type as src1</param>
        /// <param name="dst">The destination array; will have the same size and the same type as src1</param>
        /// <param name="scale">The optional scale factor. [By default this is 1]</param>
#endif
        public static void Multiply(InputArray src1, InputArray src2, OutputArray dst, double scale = 1, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_multiply(src1.CvPtr, src2.CvPtr, dst.CvPtr, scale, dtype);
            dst.Fix();

        }
        #endregion
        #region Divide
#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の商を求めます．
        /// </summary>
        /// <param name="src1">1番目の入力配列</param>
        /// <param name="src2">src1 と同じサイズ，同じ型である2番目の入力配列</param>
        /// <param name="dst">src2 と同じサイズ，同じ型である出力配列</param>
        /// <param name="scale">スケールファクタ [既定値は1]</param>
#else
        /// <summary>
        /// Performs per-element division of two arrays or a scalar by an array.
        /// </summary>
        /// <param name="src1">The first source array</param>
        /// <param name="src2">The second source array; should have the same size and same type as src1</param>
        /// <param name="dst">The destination array; will have the same size and same type as src2</param>
        /// <param name="scale">Scale factor [By default this is 1]</param>
#endif
        public static void Divide(InputArray src1, InputArray src2, OutputArray dst, double scale = 1, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_divide(src1.CvPtr, src2.CvPtr, dst.CvPtr, scale, dtype);
            dst.Fix();
        }
#if LANG_JP
        /// <summary>
        /// 2つの配列同士，あるいは配列とスカラの 要素毎の商を求めます．
        /// </summary>
        /// <param name="scale">スケールファクタ</param>
        /// <param name="src2">1番目の入力配列</param>
        /// <param name="dst">src2 と同じサイズ，同じ型である出力配列</param>
#else
        /// <summary>
        /// Performs per-element division of two arrays or a scalar by an array.
        /// </summary>
        /// <param name="scale">Scale factor</param>
        /// <param name="src2">The first source array</param>
        /// <param name="dst">The destination array; will have the same size and same type as src2</param>
#endif
        public static void Divide(double scale, InputArray src2, OutputArray dst, int dtype = -1)
        {
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_divide(scale, src2.CvPtr, dst.CvPtr, dtype);
            dst.Fix();
        }
        #endregion
        #region ScaleAdd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="alpha"></param>
        /// <param name="src2"></param>
        /// <param name="dst"></param>
        public static void ScaleAdd(InputArray src1, double alpha, InputArray src2, OutputArray dst)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_scaleAdd(src1.CvPtr, alpha, src2.CvPtr, dst.CvPtr);
            dst.Fix();
        }
        #endregion
        #region AddWeighted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="alpha"></param>
        /// <param name="src2"></param>
        /// <param name="beta"></param>
        /// <param name="gamma"></param>
        /// <param name="dst"></param>
        /// <param name="dtype"></param>
        public static void AddWeighted(InputArray src1, double alpha, InputArray src2,
            double beta, double gamma, OutputArray dst, int dtype = -1)
        {
            if (src1 == null)
                throw new ArgumentNullException("src1");
            if (src2 == null)
                throw new ArgumentNullException("src2");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_addWeighted(src1.CvPtr, alpha, src2.CvPtr, beta, gamma, dst.CvPtr, dtype);
            dst.Fix();
        }
        #endregion

        #region ConvertScaleAbs
#if LANG_JP
        /// <summary>
        /// スケーリング後，絶対値を計算し，結果を結果を 8 ビットに変換します．
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列</param>
        /// <param name="alpha">オプションのスケールファクタ. [既定値は1]</param>
        /// <param name="beta">スケーリングされた値に加えられるオプション値. [既定値は0]</param>
#else
        /// <summary>
        /// Scales, computes absolute values and converts the result to 8-bit.
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="dst">The destination array</param>
        /// <param name="alpha">The optional scale factor. [By default this is 1]</param>
        /// <param name="beta">The optional delta added to the scaled values. [By default this is 0]</param>
#endif
        public static void ConvertScaleAbs(InputArray src, OutputArray dst, double alpha = 1, double beta = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_convertScaleAbs(src.CvPtr, dst.CvPtr, alpha, beta);
            dst.Fix();
        }
        #endregion
        #region LUT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="lut"></param>
        /// <param name="dst"></param>
        /// <param name="interpolation"></param>
        public static void LUT(InputArray src, InputArray lut, OutputArray dst, int interpolation = 0)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (lut == null)
                throw new ArgumentNullException("lut");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            lut.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_LUT(src.CvPtr, lut.CvPtr, dst.CvPtr, interpolation);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="lut"></param>
        /// <param name="dst"></param>
        /// <param name="interpolation"></param>
        public static void LUT(InputArray src, byte[] lut, OutputArray dst, int interpolation = 0)
        {
            if (lut == null)
                throw new ArgumentNullException("lut");
            if (lut.Length != 256)
                throw new ArgumentException("lut.Length != 256");
            using (Mat lutMat = new Mat(256, 1, MatType.CV_8UC1, lut))
            {
                LUT(src, lutMat, dst, interpolation);
            }
        }
        #endregion
        #region Sum
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Scalar Sum(InputArray src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            return CppInvoke.core_sum(src.CvPtr);
        }
        #endregion
        #region CountNonZero
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int CountNonZero(InputArray src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            return CppInvoke.core_countNonZero(src.CvPtr);
        }
        #endregion
        #region FindNonZero
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="idx"></param>
        public static void FindNonZero(InputArray src, OutputArray idx)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (idx == null)
                throw new ArgumentNullException("idx");
            src.ThrowIfDisposed();
            idx.ThrowIfNotReady();
            CppInvoke.core_findNonZero(src.CvPtr, idx.CvPtr);
            idx.Fix();
        }
        #endregion

        #region Normalize
        /// <summary>
        /// scales and shifts array elements so that either the specified norm (alpha) 
        /// or the minimum (alpha) and maximum (beta) array values get the specified values
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="normType"></param>
        /// <param name="dtype"></param>
        /// <param name="mask"></param>
        public static void Normalize( InputArray src, OutputArray dst, double alpha=1, double beta=0,
                             NormType normType=NormType.L2, int dtype=-1, InputArray mask=null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            CppInvoke.core_normalize(src.CvPtr, dst.CvPtr, alpha, beta, (int)normType, dtype, ToPtr(mask));
            dst.Fix();
        }
        #endregion

        #region MinMaxLoc
        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        public static void MinMaxLoc(InputArray src, out double minVal, out double maxVal)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            CppInvoke.core_minMaxLoc(src.CvPtr, out minVal, out maxVal);
        }
        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <param name="minLoc"></param>
        /// <param name="maxLoc"></param>
        /// <param name="mask"></param>
        public static void MinMaxLoc(InputArray src, out double minVal, out double maxVal,
            out Point minLoc, out Point maxLoc, InputArray mask = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            CvPoint minLoc0, maxLoc0;
            CppInvoke.core_minMaxLoc(src.CvPtr, out minVal, out maxVal, out minLoc0, out maxLoc0, ToPtr(mask));
            minLoc = minLoc0;
            maxLoc = maxLoc0;
        }
        #endregion

        #region MinMaxIdx
        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        public static void MinMaxIdx(InputArray src, out double minVal, out double maxVal)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            CppInvoke.core_minMaxIdx(src.CvPtr, out minVal, out maxVal);
        }
        /// <summary>
        /// finds global minimum and maximum array elements and returns their values and their locations
        /// </summary>
        /// <param name="src"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <param name="minIdx"></param>
        /// <param name="maxIdx"></param>
        /// <param name="mask"></param>
        public static void MinMaxIdx(InputArray src, out double minVal, out double maxVal,
            out int minIdx, out int maxIdx, InputArray mask = null)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            CppInvoke.core_minMaxIdx(src.CvPtr, out minVal, out maxVal, out minIdx, out maxIdx, ToPtr(mask));
        }
        #endregion

        #region Eigen
        /// <summary>
        /// finds eigenvalues of a symmetric matrix
        /// </summary>
        /// <param name="src"></param>
        /// <param name="eigenvalues"></param>
        /// <param name="lowindex"></param>
        /// <param name="highindex"></param>
        /// <returns></returns>
        public static bool Eigen(InputArray src, OutputArray eigenvalues, int lowindex=-1,
                      int highindex = -1)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (eigenvalues == null)
                throw new ArgumentNullException("eigenvalues");
            src.ThrowIfDisposed();
            eigenvalues.ThrowIfNotReady();
            int ret = CppInvoke.core_eigen(src.CvPtr, eigenvalues.CvPtr, lowindex, highindex);
            eigenvalues.Fix();
            return ret != 0;
        }
        /// <summary>
        /// finds eigenvalues and eigenvectors of a symmetric matrix
        /// </summary>
        /// <param name="src"></param>
        /// <param name="eigenvalues"></param>
        /// <param name="eigenvectors"></param>
        /// <param name="lowindex"></param>
        /// <param name="highindex"></param>
        /// <returns></returns>
        public static bool Eigen(InputArray src, OutputArray eigenvalues,
                              OutputArray eigenvectors,
                              int lowindex=-1, int highindex=-1)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (eigenvalues == null)
                throw new ArgumentNullException("eigenvalues");
            if (eigenvectors == null)
                throw new ArgumentNullException("eigenvectors");
            src.ThrowIfDisposed();
            eigenvalues.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            int ret = CppInvoke.core_eigen(src.CvPtr, eigenvalues.CvPtr, eigenvectors.CvPtr, lowindex, highindex);
            eigenvalues.Fix();
            eigenvectors.Fix();
            return ret != 0;
        }
        /// <summary>
        /// finds eigenvalues and eigenvectors of a symmetric matrix
        /// </summary>
        /// <param name="src"></param>
        /// <param name="computeEigenvectors"></param>
        /// <param name="eigenvalues"></param>
        /// <param name="eigenvectors"></param>
        /// <returns></returns>
        public static bool Eigen(InputArray src, bool computeEigenvectors,
                                OutputArray eigenvalues, OutputArray eigenvectors)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (eigenvalues == null)
                throw new ArgumentNullException("eigenvalues");
            if (eigenvectors == null)
                throw new ArgumentNullException("eigenvectors");
            src.ThrowIfDisposed();
            eigenvalues.ThrowIfNotReady();
            eigenvectors.ThrowIfNotReady();
            int ret = CppInvoke.core_eigen(src.CvPtr, computeEigenvectors, eigenvalues.CvPtr, eigenvectors.CvPtr);
            eigenvalues.Fix();
            eigenvectors.Fix();
            return ret != 0;
        }
        #endregion

        #region Drawing
        #region Line
#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1X">線分の1番目の端点x</param>
        /// <param name="pt1Y">線分の1番目の端点y</param>
        /// <param name="pt2X">線分の2番目の端点x</param>
        /// <param name="pt2Y">線分の2番目の端点y</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1X">First point's x-coordinate of the line segment. </param>
        /// <param name="pt1Y">First point's y-coordinate of the line segment. </param>
        /// <param name="pt2X">Second point's x-coordinate of the line segment. </param>
        /// <param name="pt2Y">Second point's y-coordinate of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Line(Mat img, int pt1X, int pt1Y, int pt2X, int pt2Y, Scalar color, 
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Line(img, new CvPoint(pt1X, pt1Y), new CvPoint(pt2X, pt2Y), color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 2点を結ぶ線分を画像上に描画する．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">線分の1番目の端点</param>
        /// <param name="pt2">線分の2番目の端点</param>
        /// <param name="color">線分の色</param>
        /// <param name="thickness">線分の太さ. [既定値は1]</param>
        /// <param name="lineType">線分の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Line(Mat img, Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            CppInvoke.core_line(img.CvPtr, pt1, pt2, color, thickness, (int)lineType, shift);
        }
        #endregion
        #region Rectangle
#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pt1">矩形の一つの頂点</param>
        /// <param name="pt2">矩形の反対側の頂点</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pt1">One of the rectangle vertices. </param>
        /// <param name="pt2">Opposite rectangle vertex. </param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(Mat img, Point pt1, Point pt2, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            CppInvoke.core_rectangle(img.CvPtr, pt1, pt2, color, thickness, (int)lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠のみ，もしくは塗りつぶされた矩形を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="rect">矩形</param>
        /// <param name="color">線の色(RGB)，もしくは輝度(グレースケール画像).</param>
        /// <param name="thickness">矩形を描く線の太さ．負の値を指定した場合は塗りつぶされる. [既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">座標の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple, thick or filled rectangle
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="rect">Rectangle.</param>
        /// <param name="color">Line color (RGB) or brightness (grayscale image). </param>
        /// <param name="thickness">Thickness of lines that make up the rectangle. Negative values make the function to draw a filled rectangle. [By default this is 1]</param>
        /// <param name="lineType">Type of the line, see cvLine description. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
#endif
        public static void Rectangle(Mat img, Rect rect, Scalar color, int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            CppInvoke.core_rectangle(img.CvPtr, rect, color, thickness, (int)lineType, shift);
        }
        #endregion
        #region Circle
#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="centerX">円の中心のx座標</param>
        /// <param name="centerY">円の中心のy座標</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="centerX">X-coordinate of the center of the circle. </param>
        /// <param name="centerY">Y-coordinate of the center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public static void Circle(Mat img, int centerX, int centerY, int radius, Scalar color, 
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            Circle(img, new Point(centerX, centerY), radius, color, thickness, lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 円を描画する
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="center">円の中心</param>
        /// <param name="radius">円の半径</param>
        /// <param name="color">円の色</param>
        /// <param name="thickness">線の幅．負の値を指定した場合は塗りつぶされる．[既定値は1]</param>
        /// <param name="lineType">線の種類. [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と半径の小数点以下の桁を表すビット数. [既定値は0]</param>
#else
        /// <summary>
        /// Draws a circle
        /// </summary>
        /// <param name="img">Image where the circle is drawn. </param>
        /// <param name="center">Center of the circle. </param>
        /// <param name="radius">Radius of the circle. </param>
        /// <param name="color">Circle color. </param>
        /// <param name="thickness">Thickness of the circle outline if positive, otherwise indicates that a filled circle has to be drawn. [By default this is 1]</param>
        /// <param name="lineType">Type of the circle boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and radius value. [By default this is 0]</param>
#endif
        public static void Circle(Mat img, Point center, int radius, Scalar color, 
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            CppInvoke.core_circle(img.CvPtr, center, radius, color, thickness, (int)lineType, shift);
        }
        #endregion
        #region Ellipse
#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，楕円弧，もしくは塗りつぶされた扇形の楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描画される画像</param>
        /// <param name="center">楕円の中心</param>
        /// <param name="axes">楕円の軸の長さ</param>
        /// <param name="angle">回転角度</param>
        /// <param name="startAngle">楕円弧の開始角度</param>
        /// <param name="endAngle">楕円弧の終了角度</param>
        /// <param name="color">楕円の色</param>
        /// <param name="thickness">楕円弧の線の幅 [既定値は1]</param>
        /// <param name="lineType">楕円弧の線の種類 [既定値はLineType.Link8]</param>
        /// <param name="shift">中心座標と軸の長さの小数点以下の桁を表すビット数 [既定値は0]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="center">Center of the ellipse. </param>
        /// <param name="axes">Length of the ellipse axes. </param>
        /// <param name="angle">Rotation angle. </param>
        /// <param name="startAngle">Starting angle of the elliptic arc. </param>
        /// <param name="endAngle">Ending angle of the elliptic arc. </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse arc. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the center coordinates and axes' values. [By default this is 0]</param>
#endif
        public static void Ellipse(Mat img, Point center, Size axes, double angle, double startAngle, double endAngle, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            CppInvoke.core_ellipse(img.CvPtr, center, axes, angle, startAngle, endAngle, color, thickness, (int)lineType, shift);
        }

#if LANG_JP
        /// <summary>
        /// 枠だけの楕円，もしくは塗りつぶされた楕円を描画する
        /// </summary>
        /// <param name="img">楕円が描かれる画像．</param>
        /// <param name="box">描画したい楕円を囲む矩形領域．</param>
        /// <param name="color">楕円の色．</param>
        /// <param name="thickness">楕円境界線の幅．[既定値は1]</param>
        /// <param name="lineType">楕円境界線の種類．[既定値はLineType.Link8]</param>
        /// <param name="shift">矩形領域の頂点座標の小数点以下の桁を表すビット数．[既定値は0]</param>
#else
        /// <summary>
        /// Draws simple or thick elliptic arc or fills ellipse sector
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="box">The enclosing box of the ellipse drawn </param>
        /// <param name="color">Ellipse color. </param>
        /// <param name="thickness">Thickness of the ellipse boundary. [By default this is 1]</param>
        /// <param name="lineType">Type of the ellipse boundary. [By default this is LineType.Link8]</param>
#endif
        public static void Ellipse(Mat img, RotatedRect box, Scalar color, 
            int thickness = 1, LineType lineType = LineType.Link8)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            CppInvoke.core_ellipse(img.CvPtr, box, color, thickness, (int)lineType);
        }
        #endregion
        #region FillConvexPoly
#if LANG_JP
        /// <summary>
        /// 塗りつぶされた凸ポリゴンを描きます．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pts">ポリゴンの頂点．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
#else
        /// <summary>
        /// Fills a convex polygon.
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="pts">The polygon vertices</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
#endif
        public static void FillConvexPoly(Mat img, IEnumerable<Point> pts, Scalar color, 
            LineType lineType = LineType.Link8, int shift = 0)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();

            Point[] ptsArray = Util.ToArray(pts);
            CppInvoke.core_fillConvexPoly(img.CvPtr, ptsArray, ptsArray.Length, color, (int)lineType, shift);
        }
        #endregion
        #region FillPoly
#if LANG_JP
        /// <summary>
        /// 1つ，または複数のポリゴンで区切られた領域を塗りつぶします．
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="pts">ポリゴンの配列．各要素は，点の配列で表現されます．</param>
        /// <param name="color">ポリゴンの色．</param>
        /// <param name="lineType">ポリゴンの枠線の種類，</param>
        /// <param name="shift">ポリゴンの頂点座標において，小数点以下の桁を表すビット数．</param>
        /// <param name="offset"></param>
#else
        /// <summary>
        /// Fills the area bounded by one or more polygons
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="pts">Array of polygons, each represented as an array of points</param>
        /// <param name="color">Polygon color</param>
        /// <param name="lineType">Type of the polygon boundaries</param>
        /// <param name="shift">The number of fractional bits in the vertex coordinates</param>
        /// <param name="offset"></param>
#endif
        public static void FillPoly(Mat img, IEnumerable<IEnumerable<Point>> pts, Scalar color, 
            LineType lineType = LineType.Link8, int shift = 0, Point? offset = null)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            img.ThrowIfDisposed();
            Point offset0 = offset.GetValueOrDefault(new Point());

            List<Point[]> ptsList = new List<Point[]>();
            List<int> nptsList = new List<int>();
            foreach (IEnumerable<Point> pts1 in pts)
            {
                Point[] pts1Arr = Util.ToArray(pts1);
                ptsList.Add(pts1Arr);
                nptsList.Add(pts1Arr.Length);
            }
            Point[][] ptsArr = ptsList.ToArray();
            int[] npts = nptsList.ToArray();
            int ncontours = ptsArr.Length;
            using (ArrayAddress2<Point> ptsPtr = new ArrayAddress2<Point>(ptsArr))
            {
                CppInvoke.core_fillPoly(img.CvPtr, ptsPtr.Pointer, npts, ncontours, color, (int)lineType, shift, offset0);
            }
        }
        #endregion
        #region ClipLine
#if LANG_JP
        /// <summary>
        /// 線分が画像矩形内に収まるように切り詰めます．
        /// </summary>
        /// <param name="imgSize">画像サイズ．</param>
        /// <param name="pt1">線分の1番目の端点．</param>
        /// <param name="pt2">線分の2番目の端点．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clips the line against the image rectangle
        /// </summary>
        /// <param name="imgSize">The image size</param>
        /// <param name="pt1">The first line point</param>
        /// <param name="pt2">The second line point</param>
        /// <returns></returns>
#endif
        public static bool ClipLine(Size imgSize, ref Point pt1, ref Point pt2)
        {
            return CppInvoke.core_clipLine(imgSize, ref pt1, ref pt2) != 0;
        }
#if LANG_JP
        /// <summary>
        /// 線分が画像矩形内に収まるように切り詰めます．
        /// </summary>
        /// <param name="imgRect">画像矩形．</param>
        /// <param name="pt1">線分の1番目の端点．</param>
        /// <param name="pt2">線分の2番目の端点．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Clips the line against the image rectangle
        /// </summary>
        /// <param name="imgRect">sThe image rectangle</param>
        /// <param name="pt1">The first line point</param>
        /// <param name="pt2">The second line point</param>
        /// <returns></returns>
#endif
        public static bool ClipLine(Rect imgRect, ref Point pt1, ref Point pt2)
        {
            return CppInvoke.core_clipLine(imgRect, ref pt1, ref pt2) != 0;
        }
        #endregion
        #region PutText
        /// <summary>
        /// renders text string in the image
        /// </summary>
        /// <param name="img"></param>
        /// <param name="text"></param>
        /// <param name="org"></param>
        /// <param name="fontFace"></param>
        /// <param name="fontScale"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        /// <param name="lineType"></param>
        /// <param name="bottomLeftOrigin"></param>
        public static void PutText(Mat img, string text, Point org,
            FontFace fontFace, double fontScale, Scalar color,
            int thickness = 1, LineType lineType = LineType.Link8, bool bottomLeftOrigin = false) 
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (String.IsNullOrEmpty(text))
                throw new ArgumentNullException(text); 
            img.ThrowIfDisposed();
            CppInvoke.core_putText(img.CvPtr, text, org, (int)fontFace, fontScale, color, 
                thickness, (int)lineType, bottomLeftOrigin ? 1 : 0);
        }
        #endregion
        #region GetTextSize
        /// <summary>
        /// returns bounding box of the text string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontFace"></param>
        /// <param name="fontScale"></param>
        /// <param name="thickness"></param>
        /// <param name="baseLine"></param>
        /// <returns></returns>
        public static Size GetTextSize(string text, FontFace fontFace,
            double fontScale, int thickness, out int baseLine)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentNullException(text);
            return CppInvoke.core_getTextSize(text, (int)fontFace, fontScale, thickness, out baseLine);
        }
        #endregion
        #endregion
        #region Miscellaneous
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nthreads"></param>
        public static void SetNumThreads(int nthreads)
        {
            CppInvoke.core_setNumThreads(nthreads);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetNumThreads()
        {
            return CppInvoke.core_getNumThreads();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetThreadNum()
        {
            return CppInvoke.core_getThreadNum();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetBuildInformation()
        {
            StringBuilder buf = new StringBuilder(1 << 16);
            CppInvoke.core_getBuildInformation(buf, (uint)buf.Capacity);
            return buf.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long GetTickCount()
        {
            return CppInvoke.core_getTickCount();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static double GetTickFrequency()
        {
            return CppInvoke.core_getTickFrequency();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long GetCpuTickCount()
        {
            return CppInvoke.core_getCPUTickCount();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        public static bool CheckHardwareSupport(HardwareSupport feature)
        {
            return CppInvoke.core_checkHardwareSupport(feature) != 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int FetNumberOfCpus()
        {
            return CppInvoke.core_getNumberOfCPUs();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufSize"></param>
        /// <returns></returns>
        public static IntPtr FastMalloc(long bufSize)
        {
            return CppInvoke.core_fastMalloc(new IntPtr(bufSize));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        public static void FastFree(IntPtr ptr)
        {
            CppInvoke.core_fastFree(ptr);
        }

        /// <summary>
        /// Turns on/off available optimization.
        /// The function turns on or off the optimized code in OpenCV. Some optimization can not be enabled
        /// or disabled, but, for example, most of SSE code in OpenCV can be temporarily turned on or off this way.
        /// </summary>
        /// <param name="onoff"></param>
        public static void SetUseOptimized(bool onoff)
        {
            CppInvoke.core_setUseOptimized(onoff ? 1 : 0);
        }

        /// <summary>
        /// Returns the current optimization status.
        /// The function returns the current optimization status, which is controlled by cv::setUseOptimized().
        /// </summary>
        /// <returns></returns>
        public static bool UseOptimized()
        {
            return CppInvoke.core_useOptimized() != 0;
        }

        #region CvArrToMat
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="copyData"></param>
        /// <param name="allowND"></param>
        /// <param name="coiMode"></param>
        /// <returns></returns>
        public static Mat CvArrToMat(CvArr arr, bool copyData = false, bool allowND = true, int coiMode = 0)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            arr.ThrowIfDisposed();
            IntPtr matPtr = CppInvoke.core_cvarrToMat(arr.CvPtr, copyData ? 1 : 0, allowND ? 1 : 0, coiMode);
            return new Mat(matPtr);
        }
        #endregion
        #region ExtractImageCOI
#if LANG_JP
        /// <summary>
        /// 選択されたチャンネルの画像を取り出す
        /// </summary>
        /// <param name="arr">入力配列. CvMat または IplImage の参照.</param>
        /// <param name="coiimg">出力行列. 1チャンネルで, 入力配列srcと同じサイズ・ビット深度を持つ.</param>
        /// <param name="coi">0以上の場合, 指定されたチャンネルについて取り出される。
        /// 0未満の場合, 入力配列srcがIplImageでCOIが指定されていれば, そのCOIについて取り出される. [既定値は-1]</param>
#else
        /// <summary>
        /// Extract the selected image channel
        /// </summary>
        /// <param name="arr">The source array. It should be a pointer to CvMat or IplImage</param>
        /// <param name="coiimg">The destination array; will have single-channel, and the same size and the same depth as src</param>
        /// <param name="coi">If the parameter is &gt;=0, it specifies the channel to extract; 
        /// If it is &lt;0, src must be a pointer to IplImage with valid COI set - then the selected COI is extracted. [By default this is -1]</param>
#endif
        public static void ExtractImageCOI(CvArr arr, OutputArray coiimg, int coi = -1)
        {
            if (arr == null)
                throw new ArgumentNullException("arr");
            if (coiimg == null)
                throw new ArgumentNullException("coiimg");
            arr.ThrowIfDisposed();
            coiimg.ThrowIfNotReady();
            CppInvoke.core_extractImageCOI(arr.CvPtr, coiimg.CvPtr, coi);
            coiimg.Fix();
        }
        #endregion
        #region InsertImageCOI
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coiimg"></param>
        /// <param name="arr"></param>
        /// <param name="coi">[既定値は-1]</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coiimg"></param>
        /// <param name="arr"></param>
        /// <param name="coi">[By default this is -1]</param>
#endif
        public static void InsertImageCOI(InputArray coiimg, CvArr arr, int coi = -1)
        {
            if (coiimg == null)
                throw new ArgumentNullException("coiimg");
            if (arr == null)
                throw new ArgumentNullException("arr");
            coiimg.ThrowIfDisposed();
            arr.ThrowIfDisposed();
            CppInvoke.core_insertImageCOI(coiimg.CvPtr, arr.CvPtr, coi);
        }
        #endregion
        #endregion
    }
}
