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
	/// 浮動小数点型（倍精度）座標系による2次元の点
	/// </summary>
#else
    /// <summary>
    /// 2D point with double precision floating-point coordinates
    /// </summary>
#endif
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
    public struct CvPoint2D64f : IEquatable<CvPoint2D64f>
    {
        #region Fields
#if LANG_JP
        /// <summary>
        /// x座標
        /// </summary>
#else
        /// <summary>
        /// x-coordinate, usually zero-based
        /// </summary>
#endif
        public double X;
#if LANG_JP
        /// <summary>
        /// y座標
        /// </summary>
#else
        /// <summary>
        /// y-coordinate, usually zero-based
        /// </summary>
#endif
        public double Y;

        /// <summary>
		/// sizeof(CvPoint2D64f)
		/// </summary>
        public const int SizeOf = sizeof(double) * 2;

#if LANG_JP
        /// <summary>
        /// プロパティを初期化しない状態の CvPoint2D64f 構造体を表す 
        /// </summary>
#else
        /// <summary>
        /// Represents a CvPoint2D64f structure with its properties left uninitialized. 
        /// </summary>
#endif
        public static readonly CvPoint2D64f Empty = new CvPoint2D64f();
        #endregion

        #region Constructors
#if LANG_JP
        /// <summary>
        /// 初期化 
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">x-coordinate, usually zero-based</param>
        /// <param name="y">y-coordinate, usually zero-based</param>
#endif
        public CvPoint2D64f(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion

        #region Operators
        #region Cast
#if LANG_JP
        /// <summary>
        /// CvPointへの暗黙のキャスト
        /// </summary>
        /// <param name="self">新しい CvPoint の値を指定する CvPoint2D64f</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a CvPoint with the coordinates of the specified CvPoint2D64f.
        /// </summary>
        /// <param name="self">A CvPoint2D64f that specifies the coordinates for the new CvPoint.</param>
        /// <returns></returns>
#endif
        public static implicit operator CvPoint(CvPoint2D64f self)
        {
            return new CvPoint(Convert.ToInt32(self.X), Convert.ToInt32(self.Y));
        }
#if LANG_JP
        /// <summary>
        /// CvPointからの明示的なキャスト
        /// </summary>
        /// <param name="p">新しい CvPoint2D64f の値を指定する CvPoint</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a CvPoint2D64f with the coordinates of the specified CvPoint.
        /// </summary>
        /// <param name="p">A CvPoint that specifies the coordinates for the new CvPoint2D64f.</param>
        /// <returns></returns>
#endif
        public static implicit operator CvPoint2D64f(CvPoint p)
        {
            return new CvPoint2D64f(p.X, p.Y);
        }
#if LANG_JP
        /// <summary>
        /// CvPoint2D32fへの暗黙のキャスト
        /// </summary>
        /// <param name="self">新しい CvPoint2D32f の値を指定する CvPoint2D64f</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a CvPoint2D32f with the coordinates of the specified CvPoint2D64f.
        /// </summary>
        /// <param name="self">A CvPoint2D64f that specifies the coordinates for the new CvPoint2D32f.</param>
        /// <returns></returns>
#endif
        public static implicit operator CvPoint2D32f(CvPoint2D64f self)
        {
            return new CvPoint2D32f(Convert.ToSingle(self.X), Convert.ToSingle(self.Y));
        }
#if LANG_JP
        /// <summary>
        /// CvPoint2D32fからの明示的なキャスト
        /// </summary>
        /// <param name="p">新しい CvPoint2D64f の値を指定する CvPoint2D32f</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a CvPoint2D64f with the coordinates of the specified CvPoint2D32f.
        /// </summary>
        /// <param name="p">A CvPoint2D32f that specifies the coordinates for the new CvPoint2D64f.</param>
        /// <returns></returns>
#endif
        public static implicit operator CvPoint2D64f(CvPoint2D32f p)
        {
            return new CvPoint2D64f(p.X, p.Y);
        }
        #endregion
        #region == / !=
#if LANG_JP
        /// <summary>
        /// 指定したオブジェクトと等しければtrueを返す 
        /// </summary>
        /// <param name="obj">比較するオブジェクト</param>
        /// <returns>型が同じで、メンバの値が等しければtrue</returns>
#else
        /// <summary>
        /// Specifies whether this object contains the same members as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
#endif
        public bool Equals(CvPoint2D64f obj)
        {
            return (this.X == obj.X && this.Y == obj.Y);
        }
#if LANG_JP
        /// <summary>
        /// == 演算子のオーバーロード。x,y座標値が等しければtrueを返す 
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the values of the X and Y properties of the two CvPoint objects are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the X and Y values of left and right are equal; otherwise, false.</returns>
#endif
        public static bool operator ==(CvPoint2D64f lhs, CvPoint2D64f rhs)
        {
            return lhs.Equals(rhs);
        }
#if LANG_JP
        /// <summary>
        /// != 演算子のオーバーロード。x,y座標値が等しくなければtrueを返す 
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しくなければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint2D64f objects. The result specifies whether the values of the X or Y properties of the two CvPoint2D64f objects are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the values of either the X properties or the Y properties of left and right differ; otherwise, false.</returns>
#endif
        public static bool operator !=(CvPoint2D64f lhs, CvPoint2D64f rhs)
        {
            return !lhs.Equals(rhs);
        }
        #endregion
        #region + / -
#if LANG_JP
        /// <summary>
        /// 単項プラス演算子
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
#endif
        public static CvPoint2D64f operator +(CvPoint2D64f pt)
        {
            return pt;
        }
#if LANG_JP
        /// <summary>
        /// 単項マイナス演算子
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
#endif
        public static CvPoint2D64f operator -(CvPoint2D64f pt)
        {
            return new CvPoint2D64f(-pt.X, -pt.Y);
        }
#if LANG_JP
        /// <summary>
        /// あるオフセットで点を移動させる
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
#endif
        public static CvPoint2D64f operator +(CvPoint2D64f p1, CvPoint2D64f p2)
        {
            return new CvPoint2D64f(p1.X + p2.X, p1.Y + p2.Y);
        }
#if LANG_JP
        /// <summary>
        /// あるオフセットで点を移動させる
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
#endif
        public static CvPoint2D64f operator -(CvPoint2D64f p1, CvPoint2D64f p2)
        {
            return new CvPoint2D64f(p1.X - p2.X, p1.Y - p2.Y);
        }
#if LANG_JP
        /// <summary>
        /// あるオフセットで点を移動させる
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
#endif
        public static CvPoint2D64f operator *(CvPoint2D64f pt, double scale)
        {
            return new CvPoint2D64f(pt.X * scale, pt.Y * scale);
        }
        #endregion
        #endregion

        #region Overrided methods
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
            return X.GetHashCode() + Y.GetHashCode();
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
            return string.Format("CvPoint2D64f (x:{0} y:{1})", X, Y);
        }
        #endregion
    }
}
