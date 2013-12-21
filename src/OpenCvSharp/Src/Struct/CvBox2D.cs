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
    /// 回転が考慮された2次元の箱
    /// </summary>
#else
    /// <summary>
    /// Rotated 2D box
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CvBox2D
    {
        #region Variables and Properties
#if LANG_JP
        /// <summary>
        /// 箱の中心
        /// </summary>
#else
        /// <summary>
        /// Center of the box.
        /// </summary>
#endif
        public CvPoint2D32f Center;
#if LANG_JP
        /// <summary>
        /// 箱の幅と長さ
        /// </summary>
#else
        /// <summary>
        /// Box width and length.
        /// </summary>
#endif
        public CvSize2D32f Size;
#if LANG_JP
        /// <summary>
        /// 水平軸と始めの辺（長さ方向の辺）との角度（度）
        /// </summary>
#else
        /// <summary>
        /// Angle between the horizontal axis and the first side (i.e. length) in degrees
        /// </summary>
#endif
        public float Angle ;
        /// <summary>
        /// sizeof(CvBox2D)
        /// </summary>
        public const int SizeOf = CvPoint2D32f.SizeOf + CvSize2D32f.SizeOf + sizeof(float);
        #endregion

        #region Init
/*#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvBox2D()
        {
            Center = default(CvPoint2D32f);
            Size = default(CvSize2D32f);
            Angle = default(float);
        }*/
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="center">箱の中心</param>
        /// <param name="size">箱の幅と長さ</param>
        /// <param name="angle">水平軸と始めの辺（長さ方向の辺）との角度（度）</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="center"></param>
        /// <param name="size"></param>
        /// <param name="angle"></param>
#endif
        public CvBox2D(CvPoint2D32f center, CvSize2D32f size, float angle)
        {
            Center = center;
            Size = size;
            Angle = angle;
        }
        #endregion

        #region Methods
        #region BoxPoints
#if LANG_JP
        /// <summary>
        /// 箱の頂点を見つける
        /// </summary>
#else
        /// <summary>
        /// Finds box vertices
        /// </summary>
        /// <returns>Array of vertices</returns>
#endif
        public CvPoint2D32f[] BoxPoints()
        {
            CvPoint2D32f[] pt;
            Cv.BoxPoints(this, out pt);
            return pt;
        }
        #endregion

        #region Override
#if LANG_JP
        /// <summary>
        /// Equalsのオーバーライド
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
#if LANG_JP
        /// <summary>
        /// GetHashCodeのオーバーライド
        /// </summary>
        /// <returns>このオブジェクトのハッシュ値を指定する整数値。</returns>
#else
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this object.</returns>
#endif
        public override int GetHashCode()
        {
            return Center.GetHashCode() + Size.GetHashCode();
        }
#if LANG_JP
        /// <summary>
        /// 文字列形式を返す 
        /// </summary>
        /// <returns>文字列形式</returns>
#else
        /// <summary>
        /// Converts this object to a human readable string.
        /// </summary>
        /// <returns>A string that represents this object.</returns>
#endif
        public override string ToString()
        {
            return string.Format("CvBox2D (Center:{0} Size:{1})", Center, Size);
        }
        #endregion
        #endregion
    }

}
