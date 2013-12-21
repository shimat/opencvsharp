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
    /// Structure describes the position of the filter in the feature pyramid
    /// </summary>
#else
    /// <summary>
    /// Structure describes the position of the filter in the feature pyramid
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CvLSVMFilterPosition : IEquatable<CvLSVMFilterPosition>
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
        public int X;
#if LANG_JP
        /// <summary>
        /// y座標
        /// </summary>
#else
        /// <summary>
        /// y-coordinate, usually zero-based
        /// </summary>
#endif
        public int Y;

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int L;

        /// <summary>
        /// sizeof(CvLSVMFilterPosition)
        /// </summary>
        public const int SizeOf = sizeof(int) * 3;
        #endregion

        #region Constructor
#if LANG_JP
        /// <summary>
        /// 初期化 
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="l"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">x-coordinate, usually zero-based</param>
        /// <param name="y">y-coordinate, usually zero-based</param>
        /// <param name="l"></param>
#endif
        public CvLSVMFilterPosition(int x, int y, int l)
        {
            this.X = x;
            this.Y = y;
            this.L = l;
        }
        #endregion

        #region Operators
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
        public bool Equals(CvLSVMFilterPosition obj)
        {
            return (this.X == obj.X && this.Y == obj.Y && this.L == obj.L);
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
        /// Compares two CvLSVMFilterPosition objects. 
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the X, Y and L values of left and right are equal; otherwise, false.</returns>
#endif
        public static bool operator ==(CvLSVMFilterPosition lhs, CvLSVMFilterPosition rhs)
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
        /// Compares two CvPoint objects. 
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns></returns>
#endif
        public static bool operator !=(CvLSVMFilterPosition lhs, CvLSVMFilterPosition rhs)
        {
            return !lhs.Equals(rhs);
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
            return X.GetHashCode() + Y.GetHashCode() + L.GetHashCode();
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
            return string.Format("CvLSVMFilterPosition (x:{0} y:{1} l:{2})", X, Y, L);
        }
        #endregion
    }
}
