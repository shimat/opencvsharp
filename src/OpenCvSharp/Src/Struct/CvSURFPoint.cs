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
#if LANG_JP
    /// <summary>
    /// cvExtractSURFで出力されるキーポイント
    /// </summary>
#else
    /// <summary>
    /// SURF keypoints
    /// </summary>
#endif
    [StructLayout(LayoutKind.Sequential)]
    public struct CvSURFPoint
    {
        #region Fields
#if LANG_JP
        /// <summary>
        /// 画像中の特徴点の位置
        /// </summary>
#else
        /// <summary>
        /// Position of the feature within the image
        /// </summary>
#endif
        public CvPoint2D32f Pt;


#if LANG_JP
        /// <summary>
        ///-1，0，+1．その点におけるラプラシアンの符号．
        /// 特徴点の比較を高速化するために用いられる
        /// （通常，ラプラシアンの符号が異なる特徴同士は一致しない）
        /// </summary>
#else
        /// <summary>
        /// -1, 0 or +1. sign of the laplacian at the point.
        /// can be used to speedup feature comparison
        /// (normally features with laplacians of different signs can not match)
        /// </summary>
#endif
        public int Laplacian;


#if LANG_JP
        /// <summary>
        /// 特徴のサイズ
        /// </summary>
#else
        /// <summary>
        /// size of the feature
        /// </summary>
#endif
        public int Size;


#if LANG_JP
        /// <summary>
        /// 特徴の方向：0~360度
        /// </summary>
#else
        /// <summary>
        /// orientation of the feature: 0..360 degrees
        /// </summary>
#endif
        public float Dir;


#if LANG_JP
        /// <summary>
        /// ヘッシアン：ヘッセ行列の行列式
        /// （特徴の強さのおおよその推定に用いられる．params.hessianThreshold を参照）
        /// </summary>
#else
        /// <summary>
        /// value of the hessian (can be used to approximately estimate the feature strengths;
        /// see also params._hessianThreshold)
        /// </summary>
#endif
        public float Hessian;
        #endregion

        #region Constructors
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="pt">画像中の特徴点の位置</param>
        /// <param name="laplacian">-1，0，+1．その点におけるラプラシアンの符号．
        /// 特徴点の比較を高速化するために用いられる
        /// （通常，ラプラシアンの符号が異なる特徴同士は一致しない）</param>
        /// <param name="size">特徴のサイズ</param>
        /// <param name="dir">特徴の方向：0~360度</param>
        /// <param name="hessian">ヘッシアン：ヘッセ行列の行列式（特徴の強さのおおよその推定に用いられる．params.hessianThreshold を参照）</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pt">Position of the feature within the image</param>
        /// <param name="laplacian">-1, 0 or +1. sign of the laplacian at the point.
        /// can be used to speedup feature comparison
        /// (normally features with laplacians of different signs can not match)</param>
        /// <param name="size">size of the feature</param>
        /// <param name="dir">orientation of the feature: 0..360 degrees</param>
        /// <param name="hessian">value of the hessian (can be used to approximately estimate the feature strengths; see also params._hessianThreshold)</param>
#endif
        public CvSURFPoint(CvPoint2D32f pt, int laplacian, int size, float dir, float hessian)
        {
            Pt = pt;
            Laplacian = laplacian;
            Size = size;
            Dir = dir;
            Hessian = hessian;
        }
#if LANG_JP
        /// <summary>
        /// CvSURFPoint*から初期化
        /// </summary>
        /// <param name="ptr">CvSURFPoint*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">CvSURFPoint*</param>
#endif
        public CvSURFPoint(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentNullException("ptr");
            }
            try
            {
                CvSURFPoint p = (CvSURFPoint)Marshal.PtrToStructure(ptr, typeof(CvSURFPoint));
                Pt = p.Pt;
                Laplacian = p.Laplacian;
                Size = p.Size;
                Dir = p.Dir;
                Hessian = p.Hessian;
            }
            catch
            {
                throw new InvalidCastException();
            }
        }
#if LANG_JP
        /// <summary>
	    /// IntPtrからCvSURFPointへ変換して返す. 引数のポインタの実体がCvSURFPoint*でなければならない.
	    /// </summary>
	    /// <param name="ptr">IntPtr</param>
	    /// <returns>CvSURFPoint</returns>
#else
        /// <summary>
        /// Creates CvSURFPoint instance from native ponter
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
#endif
        public static CvSURFPoint FromPtr(IntPtr ptr)
        {
            return new CvSURFPoint(ptr);
        }
        #endregion
    }
}
