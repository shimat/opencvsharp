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
        #region PerspectiveTransform
#if LANG_JP
        /// <summary>
        /// ベクトルの透視投影変換を行う
        /// </summary>
        /// <param name="src">3チャンネルの浮動小数点型入力配列</param>
        /// <param name="dst">3チャンネルの浮動小数点型出力配列</param>
        /// <param name="mat">3×3 または 4×4 の変換行列</param>
#else
        /// <summary>
        /// Performs perspective matrix transform of vector array
        /// </summary>
        /// <param name="src">The source three-channel floating-point array. </param>
        /// <param name="dst">The destination three-channel floating-point array. </param>
        /// <param name="mat">3×3 or 4×4 transformation matrix. </param>
#endif
        public static void PerspectiveTransform(CvArr src, CvArr dst, CvMat mat)
        {
            if (src == null)
                throw new ArgumentNullException("img");
            if (dst == null)
                throw new ArgumentNullException("pts");
            if (mat == null)
                throw new ArgumentNullException("pts");
            CvInvoke.cvPerspectiveTransform(src.CvPtr, dst.CvPtr, mat.CvPtr);
        }
        #endregion
        #region Point
#if LANG_JP
        /// <summary>
        /// 整数座標系による2次元の点を生成する (cvPoint相当)
        /// </summary>
        /// <param name="x">x 座標．通常は0が原点</param>
        /// <param name="y">y 座標．通常は0が原点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates 2D point with integer coordinates
        /// </summary>
        /// <param name="x">x-coordinate, usually zero-based</param>
        /// <param name="y">y-coordinate, usually zero-based</param>
        /// <returns></returns>
#endif
        public static CvPoint Point(int x, int y)
        {
            return new CvPoint(x, y);
        }
        #endregion
        #region Point2D32f
#if LANG_JP
        /// <summary>
        /// 浮動小数点型（単精度）座標系による2次元の点を生成する (cvPoint2D32f相当)
        /// </summary>
        /// <param name="x">x 座標．通常は0が原点</param>
        /// <param name="y">y 座標．通常は0が原点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates 2D point with floating-point coordinates
        /// </summary>
        /// <param name="x">x-coordinate, usually zero-based</param>
        /// <param name="y">y-coordinate, usually zero-based</param>
        /// <returns></returns>
#endif
        public static CvPoint2D32f Point2D32f(float x, float y)
        {
            return new CvPoint2D32f(x, y);
        }
        #endregion
        #region Point2D64f
#if LANG_JP
        /// <summary>
        /// 浮動小数点型（倍精度）座標系による2次元の点を生成する (cvPoint2D32f相当)
        /// </summary>
        /// <param name="x">x 座標．通常は0が原点</param>
        /// <param name="y">y 座標．通常は0が原点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates 2D point with double precision floating-point coordinates
        /// </summary>
        /// <param name="x">x-coordinate, usually zero-based</param>
        /// <param name="y">y-coordinate, usually zero-based</param>
        /// <returns></returns>
#endif
        public static CvPoint2D64f Point2D64f(double x, double y)
        {
            return new CvPoint2D64f(x, y);
        }
        #endregion
        #region Point3D32f
#if LANG_JP
        /// <summary>
        /// 浮動小数点型（単精度）座標系による3次元の点を生成する (cvPoint3D32f相当)
        /// </summary>
        /// <param name="x">x 座標．通常は0が原点</param>
        /// <param name="y">y 座標．通常は0が原点</param>
        /// <param name="z">z 座標．通常は0が原点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates3D point with floating-point coordinates
        /// </summary>
        /// <param name="x">x-coordinate, usually zero-based</param>
        /// <param name="y">y-coordinate, usually zero-based</param>
        /// <param name="z">z-coordinate, usually zero-based</param>
        /// <returns></returns>
#endif
        public static CvPoint3D32f Point3D32f(float x, float y, float z)
        {
            return new CvPoint3D32f(x, y, z);
        }
        #endregion
        #region Point3D64f
#if LANG_JP
        /// <summary>
        /// 浮動小数点型（倍精度）座標系による3次元の点を生成する (cvPoint3D64f相当)
        /// </summary>
        /// <param name="x">x 座標．通常は0が原点</param>
        /// <param name="y">y 座標．通常は0が原点</param>
        /// <param name="z">z 座標．通常は0が原点</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates 3D point with double precision floating-point coordinates
        /// </summary>
        /// <param name="x">x-coordinate, usually zero-based</param>
        /// <param name="y">y-coordinate, usually zero-based</param>
        /// <param name="z">z-coordinate, usually zero-based</param>
        /// <returns></returns>
#endif
        public static CvPoint3D64f Point3D64f(double x, double y, double z)
        {
            return new CvPoint3D64f(x, y, z);
        }
        #endregion
        #region PointPolygonTest
#if LANG_JP
        /// <summary>
        /// 点と輪郭の関係を調べる
        /// </summary>
        /// <param name="contour">入力輪郭</param>
        /// <param name="pt">入力輪郭に対して調べる点</param>
        /// <param name="measure_dist">非0の場合, この関数は与えた点に最も近い輪郭までの距離を求める.</param>
        /// <returns>点が輪郭の内側にあるか，外側にあるか，輪郭上に乗っている（あるいは，頂点と一致している）かを判別し，それぞれの場合に応じて正か負か0を返す．
        /// measure_dist=0の場合，戻り値はそれぞれ+1，-1，0である． measure_dist≠0の場合，点と最近傍輪郭までの符号付きの距離を返す．</returns>
#else
        /// <summary>
        /// Point in contour test
        /// </summary>
        /// <param name="contour">Input contour.</param>
        /// <param name="pt">The point tested against the contour.</param>
        /// <param name="measure_dist">If it is true, the function estimates distance from the point to the nearest contour edge.</param>
        /// <returns>The function cvPointPolygonTest determines whether the point is inside contour, outside, or lies on an edge (or coinsides with a vertex). It returns positive, negative or zero value, correspondingly. When measure_dist=0, the return value is +1, -1 and 0, respectively. When measure_dist≠0, it is a signed distance between the point and the nearest contour edge.</returns> 
#endif
        public static double PointPolygonTest(CvArr contour, CvPoint2D32f pt, bool measure_dist)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            return CvInvoke.cvPointPolygonTest(contour.CvPtr, pt, System.Convert.ToInt32(measure_dist));
        }
        #endregion
        #region PointSeqFromMat
#if LANG_JP
        /// <summary>
        /// 点のベクトルを用いて，点のシーケンスヘッダを初期化する
        /// </summary>
        /// <param name="seqKind">点のシーケンスの種類</param>
        /// <param name="mat">入力行列．点の連続的な1次元ベクトルで，CV_32SC2型かCV_32FC2型でなければならない．</param>
        /// <param name="contourHeader">輪郭ヘッダ．この関数で初期化される．</param>
        /// <param name="block">シーケンスブロックヘッダ．この関数で初期化される．</param>
#else
        /// <summary>
        /// Initializes point sequence header from a point vector
        /// </summary>
        /// <param name="seqKind">Type of the point sequence.</param>
        /// <param name="mat">Input matrix. It should be continuous 1-dimensional vector of points, that is, it should have type CV_32SC2 or CV_32FC2.</param>
        /// <param name="contourHeader">Contour header, initialized by the function. </param>
        /// <param name="block">Sequence block header, initialized by the function. </param>
#endif
        public static CvSeq PointSeqFromMat(SeqType seqKind, CvArr mat, out CvContour contourHeader, out CvSeqBlock block)
        {
            if (mat == null)
                throw new ArgumentNullException("mat");
            if (mat.ElemType != MatrixType.F32C2 && mat.ElemType != MatrixType.S32C2)
                throw new ArgumentException("mat should have type S32C2 or F32C2.");

            contourHeader = new CvContour();
            block = new CvSeqBlock();
            IntPtr result = CvInvoke.cvPointSeqFromMat(seqKind, mat.CvPtr, contourHeader.CvPtr, block.CvPtr);
            if (result == IntPtr.Zero)
                return null;
            else
                return new CvSeq(result);
        }
        #endregion
        #region PolarToCart
#if LANG_JP
        /// <summary>
        /// 極座標形式で表現された2次元ベクトルのデカルト座標を計算する
        /// </summary>
        /// <param name="magnitude">大きさの配列．nullの場合，大きさはすべて1と仮定される．</param>
        /// <param name="angle">角度の配列．単位はラジアン，または度である．</param>
        /// <param name="x">x座標の出力配列で，必要でなければnullがセットされる．</param>
        /// <param name="y">y座標の出力配列で，必要でなければnullがセットされる．</param>
#else
        /// <summary>
        /// Calculates cartesian coordinates of 2d vectors represented in polar form
        /// </summary>
        /// <param name="magnitude">The array of magnitudes. If it is null, the magnitudes are assumed all 1’s. </param>
        /// <param name="angle">The array of angles, whether in radians or degrees. </param>
        /// <param name="x">The destination array of x-coordinates, may be set to null if it is not needed. </param>
        /// <param name="y">The destination array of y-coordinates, mau be set to null if it is not needed. </param>
#endif
        public static void PolarToCart(CvArr magnitude, CvArr angle, CvArr x, CvArr y)
        {
            PolarToCart(magnitude, angle, x, y, AngleUnit.Radians);
        }
#if LANG_JP
        /// <summary>
        /// 極座標形式で表現された2次元ベクトルのデカルト座標を計算する
        /// </summary>
        /// <param name="magnitude">大きさの配列．nullの場合，大きさはすべて1と仮定される．</param>
        /// <param name="angle">角度の配列．単位はラジアン，または度である．</param>
        /// <param name="x">x座標の出力配列で，必要でなければnullがセットされる．</param>
        /// <param name="y">y座標の出力配列で，必要でなければnullがセットされる．</param>
        /// <param name="unit">角度を表すために，ラジアン（デフォルト値）または度のどちらを用いるかを示す．</param>
#else
        /// <summary>
        /// Calculates cartesian coordinates of 2d vectors represented in polar form
        /// </summary>
        /// <param name="magnitude">The array of magnitudes. If it is null, the magnitudes are assumed all 1’s. </param>
        /// <param name="angle">The array of angles, whether in radians or degrees. </param>
        /// <param name="x">The destination array of x-coordinates, may be set to null if it is not needed. </param>
        /// <param name="y">The destination array of y-coordinates, mau be set to null if it is not needed. </param>
        /// <param name="unit">The flag indicating whether the angles are measured in radians, which is default mode, or in degrees. </param>
#endif
        public static void PolarToCart(CvArr magnitude, CvArr angle, CvArr x, CvArr y, AngleUnit unit)
        {
            if (angle == null)
                throw new ArgumentNullException("angle");
            
            IntPtr magnitudePtr = (magnitude == null) ? IntPtr.Zero : magnitude.CvPtr;
            IntPtr xPtr = (x == null) ? IntPtr.Zero : x.CvPtr;
            IntPtr yPtr = (y == null) ? IntPtr.Zero : y.CvPtr;
            CvInvoke.cvPolarToCart(magnitudePtr, angle.CvPtr, xPtr, yPtr, unit);
        }
        #endregion
        #region PolyLine
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="img">ポリラインが描かれる画像</param>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
#endif
        public static void PolyLine(CvArr img, CvPoint[][] pts, bool isClosed, CvScalar color)
        {
            PolyLine(img, pts, isClosed, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="img">ポリラインが描かれる画像</param>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
#endif
        public static void PolyLine(CvArr img, CvPoint[][] pts, bool isClosed, CvScalar color, int thickness)
        {
            PolyLine(img, pts, isClosed, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="img">ポリラインが描かれる画像</param>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
        /// <param name="lineType">Type of the line segments.</param>
#endif
        public static void PolyLine(CvArr img, CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType)
        {
            PolyLine(img, pts, isClosed, color, thickness, lineType, 0);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="img">ポリラインが描かれる画像</param>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">頂点座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
        /// <param name="lineType">Type of the line segments.</param>
        /// <param name="shift">Number of fractional bits in the vertex coordinates. </param>
#endif
        public static void PolyLine(CvArr img, CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType, int shift)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (pts == null)
                throw new ArgumentNullException("pts");

            // pts(CvPoint[][])をIntPtr[]に変換する
            using (var ptsPtr = new ArrayAddress2<CvPoint>(pts))
            {
                // nptsの用意
                int[] npts = new int[pts.Length];
                for (int i = 0; i < pts.Length; i++)
                {
                    if (pts[i] == null)
                    {
                        throw new ArgumentNullException(string.Format("pts[{0}]", i));
                    }
                    npts[i] = pts[i].Length;
                }
                // 関数呼び出し
                CvInvoke.cvPolyLine(img.CvPtr, ptsPtr.Pointer, npts, pts.Length, isClosed, color, thickness, lineType, shift);
            }
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="img">ポリラインが描かれる画像</param>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
#endif
        public static void DrawPolyLine(CvArr img, CvPoint[][] pts, bool isClosed, CvScalar color)
        {
            PolyLine(img, pts, isClosed, color, 1, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="img">ポリラインが描かれる画像</param>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
#endif
        public static void DrawPolyLine(CvArr img, CvPoint[][] pts, bool isClosed, CvScalar color, int thickness)
        {
            PolyLine(img, pts, isClosed, color, thickness, LineType.Link8, 0);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="img">ポリラインが描かれる画像</param>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
        /// <param name="lineType">線の種類</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
        /// <param name="lineType">Type of the line segments.</param>
#endif
        public static void DrawPolyLine(CvArr img, CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType)
        {
            PolyLine(img, pts, isClosed, color, thickness, lineType, 0);
        }
#if LANG_JP
        /// <summary>
        /// ポリライン（枠だけのポリゴン）を描画する
        /// </summary>
        /// <param name="img">ポリラインが描かれる画像</param>
        /// <param name="pts">ポリラインの配列の配列</param>
        /// <param name="isClosed">ポリラインを閉じるかどうかを指定する．閉じる場合，それぞれの領域の最後の頂点と最初の頂点を結ぶ線分を描画する． </param>
        /// <param name="color">線の色</param>
        /// <param name="thickness">線の太さ</param>
        /// <param name="lineType">線の種類</param>
        /// <param name="shift">頂点座標の小数点以下の桁を表すビット数</param>
#else
        /// <summary>
        /// Draws simple or thick polygons
        /// </summary>
        /// <param name="img">Image. </param>
        /// <param name="pts">Array of pointers to polylines. </param>
        /// <param name="isClosed">Indicates whether the polylines must be drawn closed. If closed, the function draws the line from the last vertex of every contour to the first vertex. </param>
        /// <param name="color">Polyline color. </param>
        /// <param name="thickness">Thickness of the polyline edges. </param>
        /// <param name="lineType">Type of the line segments.</param>
        /// <param name="shift">Number of fractional bits in the vertex coordinates. </param>
#endif
        public static void DrawPolyLine(CvArr img, CvPoint[][] pts, bool isClosed, CvScalar color, int thickness, LineType lineType, int shift)
        {
            PolyLine(img, pts, isClosed, color, thickness, lineType, shift);
        }
        #endregion
        #region POSIT
#if LANG_JP
        /// <summary>
        /// POSITアルゴリズムの実装
        /// </summary>
        /// <param name="positObject">オブジェクト構造体</param>
        /// <param name="imagePoints">オブジェクト上の点を二次元画像平面上へ投影して得られる点群</param>
        /// <param name="focalLength">使用するカメラの焦点距離</param>
        /// <param name="criteria">反復POSITアルゴリズムの終了条件</param>
        /// <param name="rotationMatrix">回転行列</param>
        /// <param name="translationVector">並進ベクトル</param>
#else
        /// <summary>
        /// Implements POSIT algorithm
        /// </summary>
        /// <param name="positObject">Posit object structure.</param>
        /// <param name="imagePoints">Object points projections on the 2D image plane.</param>
        /// <param name="focalLength">Focal length of the camera used.</param>
        /// <param name="criteria">Termination criteria of the iterative POSIT algorithm.</param>
        /// <param name="rotationMatrix">Matrix of rotations.</param>
        /// <param name="translationVector">Translation vector.</param>
#endif
        public static void POSIT(CvPOSITObject positObject, CvPoint2D32f[] imagePoints, double focalLength,
              CvTermCriteria criteria, out float[,] rotationMatrix, out float[] translationVector)
        {
            if (positObject == null)
                throw new ArgumentNullException("positObject");
            rotationMatrix = new float[3, 3];
            translationVector = new float[3];
            CvInvoke.cvPOSIT(positObject.CvPtr, imagePoints, focalLength, criteria, rotationMatrix, translationVector);
        }
        #endregion
        #region PostBoostingFindFace
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
        public static CvSeq<CvFaceData> PostBoostingFindFace(IplImage image, CvMemStorage storage)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (storage == null)
                throw new ArgumentNullException("storage");

            IntPtr ptr = CvInvoke.cvPostBoostingFindFace(image.CvPtr, storage.CvPtr);
            if (ptr == IntPtr.Zero)
                return null;
            else
                return new CvSeq<CvFaceData>(ptr);
        }
        #endregion
        #region Pow
#if LANG_JP
        /// <summary>
        /// すべての配列要素を累乗する.
        /// </summary>
        /// <param name="src">入力配列</param>
        /// <param name="dst">出力配列．入力と同じタイプでなければならない.</param>
        /// <param name="power">累乗の指数</param>
#else
        /// <summary>
        /// Raises every array element to power
        /// </summary>
        /// <param name="src">The source array. </param>
        /// <param name="dst">The destination array, should be the same type as the source. </param>
        /// <param name="power">The exponent of power. </param>
#endif
        public static void Pow(CvArr src, CvArr dst, double power)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvPow(src.CvPtr, dst.CvPtr, power);
        }
        #endregion
        #region PreCornerDetect
#if LANG_JP
        /// <summary>
        /// コーナー検出のために，画像ブロックの最小固有値を計算する. 
        /// すべてのピクセルについて，隣接ブロックにおける導関数の共変動行列の最小固有値だけを求める関数である．
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="corners">コーナーの候補を保存する画像</param>
#else
        /// <summary>
        /// Calculates feature map for corner detection
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="corners">Image to store the corner candidates. </param>
#endif
        public static void PreCornerDetect(CvArr image, CvArr corners)
        {
            PreCornerDetect(image, corners, 0);
        }
#if LANG_JP
        /// <summary>
        /// コーナー検出のために，画像ブロックの最小固有値を計算する. 
        /// すべてのピクセルについて，隣接ブロックにおける導関数の共変動行列の最小固有値だけを求める関数である．
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="corners">コーナーの候補を保存する画像</param>
        /// <param name="apertureSize">Sobel演算子のアパーチャサイズ(cvSobel参照)．</param>
#else
        /// <summary>
        /// Calculates feature map for corner detection
        /// </summary>
        /// <param name="image">Input image. </param>
        /// <param name="corners">Image to store the corner candidates. </param>
        /// <param name="apertureSize">Aperture parameter for Sobel operator.</param>
#endif
        public static void PreCornerDetect(CvArr image, CvArr corners, ApertureSize apertureSize)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (corners == null)
                throw new ArgumentNullException("corners");
            CvInvoke.cvPreCornerDetect(image.CvPtr, corners.CvPtr, apertureSize);
        }
        #endregion
        #region PrevTreeNode
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを前のノードに移動させる．
        /// </summary>
        /// <param name="treeIterator">初期化されるツリーのイテレータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the previous node
        /// </summary>
        /// <param name="treeIterator">Tree iterator initialized by the function. </param>
        /// <returns></returns>
#endif
        public static IntPtr PrevTreeNode(CvTreeNodeIterator treeIterator)
        {
            if (treeIterator == null)
                throw new ArgumentNullException("treeIterator");
            
            return CvInvoke.cvPrevTreeNode(treeIterator);
        }
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを前のノードに移動させる．
        /// </summary>
        /// <param name="treeIterator">初期化されるツリーのイテレータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the previous node
        /// </summary>
        /// <param name="treeIterator">Tree iterator initialized by the function. </param>
        /// <returns></returns>
#endif
        public static T PrevTreeNode<T>(CvTreeNodeIterator treeIterator) where T : CvArr
        {
            if (treeIterator == null)
                throw new ArgumentNullException("treeIterator");
            
            IntPtr result = CvInvoke.cvPrevTreeNode(treeIterator);
            if (result == IntPtr.Zero)
                return null;
            else
                return Util.Cast<T>(result);
        }
#if LANG_JP
        /// <summary>
        /// 現在のノードを返し，イテレータを前のノードに移動させる．
        /// </summary>
        /// <param name="treeIterator">初期化されるツリーのイテレータ</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns the currently observed node and moves iterator toward the previous node
        /// </summary>
        /// <param name="treeIterator">Tree iterator initialized by the function. </param>
        /// <returns></returns>
#endif
        public static T PrevTreeNode<T>(CvTreeNodeIterator<T> treeIterator) where T : CvArr
        {
            return PrevTreeNode<T>((CvTreeNodeIterator)treeIterator);
        }
        #endregion
        #region ProjectPCA
#if LANG_JP
        /// <summary>
        /// 指定された部分空間にベクトルを投影する
        /// </summary>
        /// <param name="data">入力データ．それぞれのベクトルは単一行か，単一列である．</param>
        /// <param name="avg">平均ベクトル．単一行ベクトルの場合，それはdataの行として入力ベクトルが保存されていることを意味する． そうでない場合は，単一列ベクトルであり，そのときのベクトルはdataの列として保存されている．</param>
        /// <param name="eigenvects">固有ベクトル（主成分）．一つの行が一つのベクトルを意味する．</param>
        /// <param name="result">出力である分解係数の行列．行の数はベクトルの数と同じでなくてはならない．列の数はeigenvectorsの列の数より小さいか同じでなくてはならない．列の数が少ない場合，入力ベクトルは，第cols(result)主成分までを基底とする部分空間に投影される．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Projects vectors to the specified subspace
        /// </summary>
        /// <param name="data">The input data; each vector is either a single row or a single column. </param>
        /// <param name="avg">The mean (average) vector. If it is a single-row vector, it means that the output vectors are stored as rows of result; otherwise, it should be a single-column vector, then the vectors are stored as columns of result. </param>
        /// <param name="eigenvects">The eigenvectors (principal components); one vector per row. </param>
        /// <param name="result">The output matrix of decomposition coefficients. The number of rows must be the same as the number of vectors, the number of columns must be less than or equal to the number of rows in eigenvectors. That it is less, the input vectors are projected into subspace of the first cols(result) principal components.</param>
        /// <returns></returns>
#endif
        public static void ProjectPCA(CvArr data, CvArr avg, CvArr eigenvects, CvArr result)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (avg == null)
            {
                throw new ArgumentNullException("avg");
            }
            if (eigenvects == null)
            {
                throw new ArgumentNullException("eigenvects");
            }
            CvInvoke.cvProjectPCA(data.CvPtr, avg.CvPtr, eigenvects.CvPtr, result.CvPtr);
        }
        #endregion
        #region ProjectPoints2
#if LANG_JP
        /// <summary>
        /// 次元空間中の点を画像平面上に投影した際の座標を，内部パラメータと外部パラメータを用いて計算する．
        /// オプションとして，この関数は画像中の投影点の偏微分係数行列であるヤコビアンを求める．
        /// </summary>
        /// <remarks>
        /// 内部パラメータ及び/または外部パラメータを特別な値に設定すると，
        /// この関数を外部変換のみ，あるいは内部変換のみ（つまり，疎な点集 合の歪みを考慮したものに変換する）を計算するために利用することができる．
        /// </remarks>
        /// <param name="objectPoints">オブジェクトの点の配列でその大きさは3xNまたはNx3である．N は画像内の点の個数</param>
        /// <param name="rotationVector">回転ベクトル．1x3または3x1</param>
        /// <param name="translationVector">並進ベクトル．1x3または3x1</param>
        /// <param name="intrinsicMatrix">カメラマトリクス(A) [fx 0 cx; 0 fy cy; 0 0 1]</param>
        /// <param name="distortionCoeffs">歪み係数．4x1または1x4 [k1, k2, p1, p2]. NULLの場合，すべての歪み係数を0とする</param>
        /// <param name="imagePoints">画像平面上の点の出力配列で，その大きさは2xNまたはNx2である．ここでNはビュー上の点の数</param>
#else
        /// <summary>
        /// Computes projections of 3D points to the image plane given intrinsic and extrinsic camera parameters. 
        /// Optionally, the function computes jacobians - matrices of partial derivatives of image points as functions of all the input parameters w.r.t. the particular parameters, intrinsic and/or extrinsic. 
        /// </summary>
        /// <remarks>
        /// Note, that with intrinsic and/or extrinsic parameters set to special values, 
        /// the function can be used to compute just extrinsic transformation or just intrinsic transformation (i.e. distortion of a sparse set of points). 
        /// </remarks>
        /// <param name="objectPoints">The array of object points, 3xN or Nx3, where N is the number of points in the view. </param>
        /// <param name="rotationVector">The rotation vector, 1x3 or 3x1. </param>
        /// <param name="translationVector">The translation vector, 1x3 or 3x1. </param>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. If it is null, all distortion coefficients are considered 0's. </param>
        /// <param name="imagePoints">The output array of image points, 2xN or Nx2, where N is the total number of points in the view. </param>
#endif   
        public static void ProjectPoints2(CvMat objectPoints, CvMat rotationVector, CvMat translationVector, CvMat intrinsicMatrix, CvMat distortionCoeffs, CvMat imagePoints)
        {
            ProjectPoints2(objectPoints, rotationVector, translationVector, intrinsicMatrix, distortionCoeffs, imagePoints, null, null, null, null, null, 0);
        }
#if LANG_JP
        /// <summary>
        /// 次元空間中の点を画像平面上に投影した際の座標を，内部パラメータと外部パラメータを用いて計算する．
        /// オプションとして，この関数は画像中の投影点の偏微分係数行列であるヤコビアンを求める．
        /// </summary>
        /// <remarks>
        /// 内部パラメータ及び/または外部パラメータを特別な値に設定すると，
        /// この関数を外部変換のみ，あるいは内部変換のみ（つまり，疎な点集 合の歪みを考慮したものに変換する）を計算するために利用することができる．
        /// </remarks>
        /// <param name="objectPoints">オブジェクトの点の配列でその大きさは3xNまたはNx3である．N は画像内の点の個数</param>
        /// <param name="rotationVector">回転ベクトル．1x3または3x1</param>
        /// <param name="translationVector">並進ベクトル．1x3または3x1</param>
        /// <param name="intrinsicMatrix">カメラマトリクス(A) [fx 0 cx; 0 fy cy; 0 0 1]</param>
        /// <param name="distortionCoeffs">歪み係数．4x1または1x4 [k1, k2, p1, p2]. NULLの場合，すべての歪み係数を0とする</param>
        /// <param name="imagePoints">画像平面上の点の出力配列で，その大きさは2xNまたはNx2である．ここでNはビュー上の点の数</param>
        /// <param name="dpdrot">オプション：画像平面上の点の回転ベクトルの各要素に関する微分係数を表す2Nx3行列</param>
        /// <param name="dpdt">オプション：画像平面上の点の並進ベクトルの各要素に関する微分係数を表す2Nx3行列</param>
        /// <param name="dpdf">オプション：画像平面上の点のfx と fyに関する微分係数を表す2Nx2行列</param>
        /// <param name="dpdc">オプション：画像平面上の点のcx とcyに関する微分係数を表す2Nx2行列</param>
        /// <param name="dpddist">オプション：画像平面上の点の歪み係数に関する微分係数を表す2Nx4行列</param>
#else
        /// <summary>
        /// Computes projections of 3D points to the image plane given intrinsic and extrinsic camera parameters. 
        /// Optionally, the function computes jacobians - matrices of partial derivatives of image points as functions of all the input parameters w.r.t. the particular parameters, intrinsic and/or extrinsic. 
        /// </summary>
        /// <remarks>
        /// Note, that with intrinsic and/or extrinsic parameters set to special values, 
        /// the function can be used to compute just extrinsic transformation or just intrinsic transformation (i.e. distortion of a sparse set of points). 
        /// </remarks>
        /// <param name="objectPoints">The array of object points, 3xN or Nx3, where N is the number of points in the view. </param>
        /// <param name="rotationVector">The rotation vector, 1x3 or 3x1. </param>
        /// <param name="translationVector">The translation vector, 1x3 or 3x1. </param>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. If it is null, all distortion coefficients are considered 0's. </param>
        /// <param name="imagePoints">The output array of image points, 2xN or Nx2, where N is the total number of points in the view. </param>
        /// <param name="dpdrot">Optional Nx3 matrix of derivatives of image points with respect to components of the rotation vector. </param>
        /// <param name="dpdt">Optional Nx3 matrix of derivatives of image points w.r.t. components of the translation vector. </param>
        /// <param name="dpdf">Optional Nx2 matrix of derivatives of image points w.r.t. fx and fy. </param>
        /// <param name="dpdc">Optional Nx2 matrix of derivatives of image points w.r.t. cx and cy. </param>
        /// <param name="dpddist">Optional Nx4 matrix of derivatives of image points w.r.t. distortion coefficients. </param>
#endif
        public static void ProjectPoints2(CvMat objectPoints, CvMat rotationVector, CvMat translationVector, CvMat intrinsicMatrix, CvMat distortionCoeffs, CvMat imagePoints, CvMat dpdrot, CvMat dpdt, CvMat dpdf, CvMat dpdc, CvMat dpddist)
        {
            ProjectPoints2(objectPoints, rotationVector, translationVector, intrinsicMatrix, distortionCoeffs, imagePoints, dpdrot, dpdt, dpdf, dpdc, dpddist, 0);
        }
#if LANG_JP
        /// <summary>
        /// 次元空間中の点を画像平面上に投影した際の座標を，内部パラメータと外部パラメータを用いて計算する．
        /// オプションとして，この関数は画像中の投影点の偏微分係数行列であるヤコビアンを求める．
        /// </summary>
        /// <remarks>
        /// 内部パラメータ及び/または外部パラメータを特別な値に設定すると，
        /// この関数を外部変換のみ，あるいは内部変換のみ（つまり，疎な点集 合の歪みを考慮したものに変換する）を計算するために利用することができる．
        /// </remarks>
        /// <param name="objectPoints">オブジェクトの点の配列でその大きさは3xNまたはNx3である．N は画像内の点の個数</param>
        /// <param name="rotationVector">回転ベクトル．1x3または3x1</param>
        /// <param name="translationVector">並進ベクトル．1x3または3x1</param>
        /// <param name="intrinsicMatrix">カメラマトリクス(A) [fx 0 cx; 0 fy cy; 0 0 1]</param>
        /// <param name="distortionCoeffs">歪み係数．4x1または1x4 [k1, k2, p1, p2]. NULLの場合，すべての歪み係数を0とする</param>
        /// <param name="imagePoints">画像平面上の点の出力配列で，その大きさは2xNまたはNx2である．ここでNはビュー上の点の数</param>
        /// <param name="dpdrot">オプション：画像平面上の点の回転ベクトルの各要素に関する微分係数を表す2Nx3行列</param>
        /// <param name="dpdt">オプション：画像平面上の点の並進ベクトルの各要素に関する微分係数を表す2Nx3行列</param>
        /// <param name="dpdf">オプション：画像平面上の点のfx と fyに関する微分係数を表す2Nx2行列</param>
        /// <param name="dpdc">オプション：画像平面上の点のcx とcyに関する微分係数を表す2Nx2行列</param>
        /// <param name="dpddist">オプション：画像平面上の点の歪み係数に関する微分係数を表す2Nx4行列</param>
        /// <param name="aspectRatio"></param>
#else
        /// <summary>
        /// Computes projections of 3D points to the image plane given intrinsic and extrinsic camera parameters. 
        /// Optionally, the function computes jacobians - matrices of partial derivatives of image points as functions of all the input parameters w.r.t. the particular parameters, intrinsic and/or extrinsic. 
        /// </summary>
        /// <remarks>
        /// Note, that with intrinsic and/or extrinsic parameters set to special values, 
        /// the function can be used to compute just extrinsic transformation or just intrinsic transformation (i.e. distortion of a sparse set of points). 
        /// </remarks>
        /// <param name="objectPoints">The array of object points, 3xN or Nx3, where N is the number of points in the view. </param>
        /// <param name="rotationVector">The rotation vector, 1x3 or 3x1. </param>
        /// <param name="translationVector">The translation vector, 1x3 or 3x1. </param>
        /// <param name="intrinsicMatrix">The camera matrix (A) [fx 0 cx; 0 fy cy; 0 0 1]. </param>
        /// <param name="distortionCoeffs">The vector of distortion coefficients, 4x1 or 1x4 [k1, k2, p1, p2]. If it is null, all distortion coefficients are considered 0's. </param>
        /// <param name="imagePoints">The output array of image points, 2xN or Nx2, where N is the total number of points in the view. </param>
        /// <param name="dpdrot">Optional Nx3 matrix of derivatives of image points with respect to components of the rotation vector. </param>
        /// <param name="dpdt">Optional Nx3 matrix of derivatives of image points w.r.t. components of the translation vector. </param>
        /// <param name="dpdf">Optional Nx2 matrix of derivatives of image points w.r.t. fx and fy. </param>
        /// <param name="dpdc">Optional Nx2 matrix of derivatives of image points w.r.t. cx and cy. </param>
        /// <param name="dpddist">Optional Nx4 matrix of derivatives of image points w.r.t. distortion coefficients. </param>
        /// <param name="aspectRatio"></param>
#endif
        public static void ProjectPoints2(CvMat objectPoints, CvMat rotationVector, CvMat translationVector, CvMat intrinsicMatrix, CvMat distortionCoeffs, CvMat imagePoints, CvMat dpdrot, CvMat dpdt, CvMat dpdf, CvMat dpdc, CvMat dpddist, double aspectRatio)
        {
            if (objectPoints == null)
                throw new ArgumentNullException("objectPoints");
            if (rotationVector == null)
                throw new ArgumentNullException("rotationVector");
            if (translationVector == null)
                throw new ArgumentNullException("translationVector");
            if (intrinsicMatrix == null)
                throw new ArgumentNullException("intrinsicMatrix");
            if (imagePoints == null)
                throw new ArgumentNullException("imagePoints");
            IntPtr distortionCoeffsPtr = (distortionCoeffs == null) ? IntPtr.Zero : distortionCoeffs.CvPtr;
            IntPtr dpdrotPtr = (dpdrot == null) ? IntPtr.Zero : dpdrot.CvPtr;
            IntPtr dpdtPtr = (dpdt == null) ? IntPtr.Zero : dpdt.CvPtr;
            IntPtr dpdfPtr = (dpdf == null) ? IntPtr.Zero : dpdf.CvPtr;
            IntPtr dpdcPtr = (dpdc == null) ? IntPtr.Zero : dpdc.CvPtr;
            IntPtr dpddistPtr = (dpddist == null) ? IntPtr.Zero : dpddist.CvPtr;
            CvInvoke.cvProjectPoints2(objectPoints.CvPtr, rotationVector.CvPtr, translationVector.CvPtr, intrinsicMatrix.CvPtr, distortionCoeffsPtr, imagePoints.CvPtr, dpdrotPtr, dpdtPtr, dpdfPtr, dpdcPtr, dpddistPtr, aspectRatio);
        }
        #endregion
        #region Ptr*D
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr Ptr1D(CvArr arr, int idx0)
        {
            MatrixType type;
            return CvInvoke.cvPtr1D(arr.CvPtr, idx0, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="type">Type of matrix elements </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr Ptr1D(CvArr arr, int idx0, out MatrixType type)
        {
            return CvInvoke.cvPtr1D(arr.CvPtr, idx0, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr Ptr2D(CvArr arr, int idx0, int idx1)
        {
            MatrixType type;
            return CvInvoke.cvPtr2D(arr.CvPtr, idx0, idx1, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="type">Type of matrix elements </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr Ptr2D(CvArr arr, int idx0, int idx1, out MatrixType type)
        {
            return CvInvoke.cvPtr2D(arr.CvPtr, idx0, idx1, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr Ptr3D(CvArr arr, int idx0, int idx1, int idx2)
        {
            MatrixType type;
            return CvInvoke.cvPtr3D(arr.CvPtr, idx0, idx1, idx2, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx0">要素インデックスの，0を基準とした第1成分．</param>
        /// <param name="idx1">要素インデックスの，0を基準とした第2成分．</param>
        /// <param name="idx2">要素インデックスの，0を基準とした第3成分．</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx0">The first zero-based component of the element index </param>
        /// <param name="idx1">The second zero-based component of the element index </param>
        /// <param name="idx2">The third zero-based component of the element index </param>
        /// <param name="type">Type of matrix elements </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr Ptr3D(CvArr arr, int idx0, int idx1, int idx2, out MatrixType type)
        {
            return CvInvoke.cvPtr3D(arr.CvPtr, idx0, idx1, idx2, out type);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx">要素インデックスの配列(可変長引数)</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx">Array of the element indices </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr PtrND(CvArr arr, params int[] idx)
        {
            MatrixType type;
            return CvInvoke.cvPtrND(arr.CvPtr, idx, out type, true, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx">要素インデックスの配列</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx">Array of the element indices </param>
        /// <param name="type">Type of matrix elements </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr PtrND(CvArr arr, int[] idx, out MatrixType type)
        {
            return CvInvoke.cvPtrND(arr.CvPtr, idx, out type, true, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx">要素インデックスの配列</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <param name="createNode">疎な行列に対するオプションの入力パラメータ. trueの場合，指定された要素が存在しないときは要素を生成する.</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx">Array of the element indices </param>
        /// <param name="type">Type of matrix elements </param>
        /// <param name="createNode">Optional input parameter for sparse matrices. Non-zero value of the parameter means that the requested element is created if it does not exist already. </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr PtrND(CvArr arr, int[] idx, out MatrixType type, bool createNode)
        {
            return CvInvoke.cvPtrND(arr.CvPtr, idx, out type, createNode, IntPtr.Zero);
        }
#if LANG_JP
        /// <summary>
        /// 特定の配列要素へのポインタを返す．
        /// </summary>
        /// <param name="arr">入力配列</param>
        /// <param name="idx">要素インデックスの配列</param>
        /// <param name="type">行列要素のタイプ</param>
        /// <param name="createNode">疎な行列に対するオプションの入力パラメータ. trueの場合，指定された要素が存在しないときは要素を生成する.</param>
        /// <param name="precalcHashval">疎な行列に対するオプションの入力パラメータ．nullでないとき，関数はノードのハッシュ値を再計算せず，指定された場所から取ってくる． これにより，ペアワイズ操作の速度が向上する．</param>
        /// <returns>指定した要素のポインタ</returns>
#else
        /// <summary>
        /// Return pointer to the particular array element
        /// </summary>
        /// <param name="arr">Input array. </param>
        /// <param name="idx">Array of the element indices </param>
        /// <param name="type">Type of matrix elements </param>
        /// <param name="createNode">Optional input parameter for sparse matrices. Non-zero value of the parameter means that the requested element is created if it does not exist already. </param>
        /// <param name="precalcHashval">Optional input parameter for sparse matrices. If the pointer is not NULL, the function does not recalculate the node hash value, but takes it from the specified location. It is useful for speeding up pair-wise operations (TODO: provide an example) </param>
        /// <returns>pointer to the particular array element</returns>
#endif
        public static IntPtr PtrND(CvArr arr, int[] idx, out MatrixType type, bool createNode, uint? precalcHashval)
        {
            if (precalcHashval.HasValue)
            {
                return CvInvoke.cvPtrND(arr.CvPtr, idx, out type, createNode, IntPtr.Zero);
            }

            using (StructurePointer<uint> precalcHashvalPtr = new StructurePointer<uint>(precalcHashval.Value))
            {
                return CvInvoke.cvPtrND(arr.CvPtr, idx, out type, createNode, precalcHashvalPtr);
            }
        }
        #endregion
        #region PutText
#if LANG_JP
        /// <summary>
        /// 文字列を描画する
        /// </summary>
        /// <param name="img">入力画像</param>
        /// <param name="text">描画する文字列</param>
        /// <param name="org">最初の文字の左下の座標</param>
        /// <param name="font">フォント構造体</param>
        /// <param name="color">文字の色</param>
#else
        /// <summary>
        /// Draws text string
        /// </summary>
        /// <param name="img">Input image. </param>
        /// <param name="text">String to print. </param>
        /// <param name="org">Coordinates of the bottom-left corner of the first letter. </param>
        /// <param name="font">Pointer to the font structure. </param>
        /// <param name="color">Text color. </param>
#endif
        public static void PutText(CvArr img, string text, CvPoint org, CvFont font, CvScalar color)
        {
            if (img == null)
                throw new ArgumentNullException("img");
            if (text == null)
                throw new ArgumentNullException("text");
            if (font == null)
                throw new ArgumentNullException("font");
            CvInvoke.cvPutText(img.CvPtr, text, org, font.CvPtr, color);
        }
        #endregion
        #region PyrDown
#if LANG_JP
        /// <summary>
        /// 画像のダウンサンプリングを行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像．入力画像の1/2の幅と高さ．</param>
#else
        /// <summary>
        /// Downsamples image.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image, should have 2x smaller width and height than the source. </param>
#endif
        public static void PyrDown(CvArr src, CvArr dst)
        {
            PyrDown(src, dst, CvFilter.Gaussian5x5);
        }
#if LANG_JP
        /// <summary>
        /// 画像のダウンサンプリングを行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像．入力画像の1/2の幅と高さ．</param>
        /// <param name="filter">畳み込みに使うフィルタ．現在は CV_GAUSSIAN_5x5 のみサポート．</param>
#else
        /// <summary>
        /// Downsamples image.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image, should have 2x smaller width and height than the source. </param>
        /// <param name="filter">Type of the filter used for convolution; only CV_GAUSSIAN_5x5 is currently supported. </param>
#endif
        public static void PyrDown(CvArr src, CvArr dst, CvFilter filter)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvPyrDown(src.CvPtr, dst.CvPtr, filter);
        }
        #endregion
        #region PyrMeanShiftFiltering
#if LANG_JP
        /// <summary>
        /// 平均値シフト法による画像のセグメント化アルゴリズムのフィルタリング部分を実装する．
        /// </summary>
        /// <param name="src">入力画像．8ビット，3チャンネル</param>
        /// <param name="dst">出力画像．入力画像と同じフォーマット，同じサイズ</param>
        /// <param name="sp">空間ウィンドウの半径</param>
        /// <param name="sr">色空間ウィンドウの半径</param>
#else
        /// <summary>
        /// Does meanshift image segmentation.
        /// </summary>
        /// <param name="src">The source 8-bit 3-channel image. </param>
        /// <param name="dst">The destination image of the same format and the same size as the source. </param>
        /// <param name="sp">The spatial window radius. </param>
        /// <param name="sr">The color window radius. </param>
#endif
        public static void PyrMeanShiftFiltering(CvArr src, CvArr dst, double sp, double sr)
        {
            PyrMeanShiftFiltering(src, dst, sp, sr, 1, new CvTermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 5, 1));
        }
#if LANG_JP
        /// <summary>
        /// 平均値シフト法による画像のセグメント化アルゴリズムのフィルタリング部分を実装する．
        /// </summary>
        /// <param name="src">入力画像．8ビット，3チャンネル</param>
        /// <param name="dst">出力画像．入力画像と同じフォーマット，同じサイズ</param>
        /// <param name="sp">空間ウィンドウの半径</param>
        /// <param name="sr">色空間ウィンドウの半径</param>
        /// <param name="maxLevel">セグメント化のためのピラミッドの最大レベル</param>
#else
        /// <summary>
        /// Does meanshift image segmentation.
        /// </summary>
        /// <param name="src">The source 8-bit 3-channel image. </param>
        /// <param name="dst">The destination image of the same format and the same size as the source. </param>
        /// <param name="sp">The spatial window radius. </param>
        /// <param name="sr">The color window radius. </param>
        /// <param name="maxLevel">Maximum level of the pyramid for the segmentation. </param>
#endif
        public static void PyrMeanShiftFiltering(CvArr src, CvArr dst, double sp, double sr, int maxLevel)
        {
            PyrMeanShiftFiltering(src, dst, sp, sr, maxLevel, new CvTermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 5, 1));
        }
#if LANG_JP
        /// <summary>
        /// 平均値シフト法による画像のセグメント化アルゴリズムのフィルタリング部分を実装する．
        /// </summary>
        /// <param name="src">入力画像．8ビット，3チャンネル</param>
        /// <param name="dst">出力画像．入力画像と同じフォーマット，同じサイズ</param>
        /// <param name="sp">空間ウィンドウの半径</param>
        /// <param name="sr">色空間ウィンドウの半径</param>
        /// <param name="maxLevel">セグメント化のためのピラミッドの最大レベル</param>
        /// <param name="termcrit">終了条件．平均値シフトをいつまで繰り返すか</param>
#else
        /// <summary>
        /// Does meanshift image segmentation.
        /// </summary>
        /// <param name="src">The source 8-bit 3-channel image. </param>
        /// <param name="dst">The destination image of the same format and the same size as the source. </param>
        /// <param name="sp">The spatial window radius. </param>
        /// <param name="sr">The color window radius. </param>
        /// <param name="maxLevel">Maximum level of the pyramid for the segmentation. </param>
        /// <param name="termcrit">Termination criteria: when to stop meanshift iterations. </param>
#endif
        public static void PyrMeanShiftFiltering(CvArr src, CvArr dst, double sp, double sr, int maxLevel, CvTermCriteria termcrit)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvPyrMeanShiftFiltering(src.CvPtr, dst.CvPtr, sp, sr, maxLevel, termcrit);
        }
        #endregion
        #region PyrSegmentation
#if LANG_JP
        /// <summary>
        /// 画像ピラミッドによる画像のセグメント化を実装する．ピラミッドは，levelまで作成する．(out引数のcompがいらないときバージョン)
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="level">セグメント化のためのピラミッドの最大レベル</param>
        /// <param name="threshold1">リンク構築のための誤差閾値</param>
        /// <param name="threshold2">セグメントクラスタリングのための誤差閾値</param>
#else
        /// <summary>
        /// Does image segmentation by pyramids.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="level"></param>
        /// <param name="threshold1"></param>
        /// <param name="threshold2"></param>
#endif
        public static void PyrSegmentation(IplImage src, IplImage dst, int level, double threshold1, double threshold2)
        {
            CvMemStorage storage = new CvMemStorage();
            CvSeq comp;
            PyrSegmentation(src, dst, storage, out comp, level, threshold1, threshold2);
        }
#if LANG_JP
        /// <summary>
        /// 画像ピラミッドによる画像のセグメント化を実装する． ピラミッドは，levelまで作成する． 
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像</param>
        /// <param name="storage">結果として得られる連結成分のシーケンスを保存するための領域</param>
        /// <param name="comp">セグメント化された成分の出力シーケンスへのポインタ</param>
        /// <param name="level">セグメント化のためのピラミッドの最大レベル</param>
        /// <param name="threshold1">リンク構築のための誤差閾値</param>
        /// <param name="threshold2">セグメントクラスタリングのための誤差閾値</param>
#else
        /// <summary>
        /// Does image segmentation by pyramids.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image. </param>
        /// <param name="storage">Storage; stores the resulting sequence of connected components. </param>
        /// <param name="comp">Pointer to the output sequence of the segmented components. </param>
        /// <param name="level">Maximum level of the pyramid for the segmentation. </param>
        /// <param name="threshold1">Error threshold for establishing the links. </param>
        /// <param name="threshold2">Error threshold for the segments clustering. </param>
#endif
        public static void PyrSegmentation(IplImage src, IplImage dst, CvMemStorage storage, out CvSeq comp, int level, double threshold1, double threshold2)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            if (src == null)
                throw new ArgumentNullException("src");
            IntPtr compPtr;
            CvInvoke.cvPyrSegmentation(src.CvPtr, dst.CvPtr, storage.CvPtr, out compPtr, level, threshold1, threshold2);
            comp = new CvSeq(compPtr);
        }
        #endregion
        #region PyrUp
#if LANG_JP
        /// <summary>
        /// 画像のアップサンプリングを行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像．入力画像の1/2の幅と高さ．</param>
#else
        /// <summary>
        /// Upsamples image.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image, should have 2x smaller width and height than the source. </param>
#endif
        public static void PyrUp(CvArr src, CvArr dst)
        {
            PyrUp(src, dst, CvFilter.Gaussian5x5);
        }
#if LANG_JP
        /// <summary>
        /// 画像のアップサンプリングを行う
        /// </summary>
        /// <param name="src">入力画像</param>
        /// <param name="dst">出力画像．入力画像の1/2の幅と高さ．</param>
        /// <param name="filter">畳み込みに使うフィルタ．現在は CV_GAUSSIAN_5x5 のみサポート．</param>
#else
        /// <summary>
        /// Upsamples image.
        /// </summary>
        /// <param name="src">The source image. </param>
        /// <param name="dst">The destination image, should have 2x smaller width and height than the source. </param>
        /// <param name="filter">Type of the filter used for convolution; only CV_GAUSSIAN_5x5 is currently supported. </param>
#endif
        public static void PyrUp(CvArr src, CvArr dst, CvFilter filter)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");
            CvInvoke.cvPyrUp(src.CvPtr, dst.CvPtr, filter);
        }
        #endregion
    }
}
