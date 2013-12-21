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
    /// 矩形のピクセル精度でのサイズ
    /// </summary>
#else
    /// <summary>
    /// Pixel-accurate size of a rectangle
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CvSize : IEquatable<CvSize>
    {
        #region Fields
#if LANG_JP
        /// <summary>
        /// 矩形の幅
        /// </summary>
#else
        /// <summary>
        /// Width of the rectangle
        /// </summary>
#endif
        public int Width;
#if LANG_JP
        /// <summary>
        /// 矩形の高さ
        /// </summary>
#else
        /// <summary>
        /// Height of the rectangle
        /// </summary>
#endif
        public int Height;

        /// <summary>
        /// sizeof(CvSize)
        /// </summary>
        public const int SizeOf = sizeof(int) * 2;

#if LANG_JP
        /// <summary>
        /// プロパティを初期化しない状態の CvSize 構造体を表す 
        /// </summary>
#else
        /// <summary>
        /// Represents a CvSize structure with its properties left uninitialized. 
        /// </summary>
#endif
        public static readonly CvSize Empty = new CvSize();
        #endregion

        #region Constructors
#if LANG_JP
        /// <summary>
        /// 初期化 
        /// </summary>
        /// <param name="width">矩形の幅</param>
	    /// <param name="height">矩形の高さ</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
#endif
        public CvSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        #endregion

        #region Operators
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
        public bool Equals(CvSize obj)
        {
            return (this.Width == obj.Width && this.Height == obj.Height);
        }
#if LANG_JP
        /// <summary>
        /// == 演算子のオーバーロード
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
#endif
        public static bool operator ==(CvSize lhs, CvSize rhs)
        {
            return lhs.Equals(rhs);
        }
#if LANG_JP
        /// <summary>
        /// != 演算子のオーバーロード
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <returns>等しくなければtrue</returns>
#else
        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
#endif
        public static bool operator !=(CvSize lhs, CvSize rhs)
        {
            return !lhs.Equals(rhs);
        }
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
            return Width.GetHashCode() + Height.GetHashCode();
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
            return string.Format("CvSize (Width:{0} Height:{1})", Width, Height);
        }
        #endregion
    }
}
