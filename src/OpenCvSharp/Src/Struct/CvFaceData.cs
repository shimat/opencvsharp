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
    /// 
    /// </summary>
#else
    /// <summary>
    /// 
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CvFaceData : IEquatable<CvFaceData>
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        public CvRect MouthRect;
        /// <summary>
        /// 
        /// </summary>
        public CvRect LeftEyeRect;
        /// <summary>
        /// 
        /// </summary>
        public CvRect RightEyeRect;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mouthRect"></param>
        /// <param name="leftEyeRect"></param>
        /// <param name="rightEyeRect"></param>
        public CvFaceData(CvRect mouthRect, CvRect leftEyeRect, CvRect rightEyeRect)
        {
            this.MouthRect = mouthRect;
            this.LeftEyeRect = leftEyeRect;
            this.RightEyeRect = rightEyeRect;
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
        public bool Equals(CvFaceData obj)
        {
            return (this.MouthRect == obj.MouthRect && this.LeftEyeRect == obj.LeftEyeRect && this.RightEyeRect == obj.RightEyeRect);
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
        public static bool operator ==(CvFaceData lhs, CvFaceData rhs)
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
        public static bool operator !=(CvFaceData lhs, CvFaceData rhs)
        {
            return !lhs.Equals(rhs);
        }
#if LANG_JP
        /// <summary>
        /// CvRectへの暗黙のキャスト (互換性のため)
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// implicit cast to CvRect (for backward compatibility)
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static implicit operator CvRect(CvFaceData self)
        {
            return self.MouthRect;
        }
        #endregion

        #region Overrided Methods
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
            return MouthRect.GetHashCode() + LeftEyeRect.GetHashCode() + RightEyeRect.GetHashCode();
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
            return string.Format("CvFaceData (mouth:{0} left eye:{1} right eye:{2})", MouthRect, LeftEyeRect, RightEyeRect);
        }
        #endregion
    }
}
