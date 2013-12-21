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
    /// シーケンスのスライス
    /// </summary>
#else
    /// <summary>
    /// A sequence slice
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct CvSlice : IEquatable<CvSlice>
    {
        #region Field
#if LANG_JP
        /// <summary>
        /// スライスの先頭値
        /// </summary>
#else
        /// <summary>
        /// start index (inclusive)
        /// </summary>
#endif
        public int StartIndex;
#if LANG_JP
        /// <summary>
        /// スライスの終端値
        /// </summary>
#else
        /// <summary>
        /// end index (exclusive)
        /// </summary>
#endif
        public int EndIndex;
        #endregion

        #region Constant
        /// <summary>
        /// sizeof(CvSlice)
        /// </summary>
        public const int SizeOf = sizeof(int) * 2;

        /// <summary>
        /// シーケンス全体をあらわすスライスのスライス長を取得する
        /// </summary>
        public const int WholeSeqEndIndex = CvConst.CV_WHOLE_SEQ_END_INDEX;

        /// <summary>
        /// シーケンス全体をあらわすスライスを取得する
        /// </summary>
        public static readonly CvSlice WholeSeq = new CvSlice(0, WholeSeqEndIndex);
        #endregion

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="start_index"></param>
        /// <param name="end_index"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="start_index"></param>
        /// <param name="end_index"></param>
#endif
        public CvSlice(int start_index, int end_index)
        {
            this.StartIndex = start_index;
            this.EndIndex = end_index;
        }

        #region Methods
        #region SliceLength
#if LANG_JP
        /// <summary>
        /// シーケンスのスライス長を計算する
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// Calculates the sequence slice length
        /// </summary>
        /// <param name="seq">Sequence</param>
        /// <returns></returns>
#endif
        public int SliceLength(CvSeq seq)
        {
            return Cv.SliceLength(this, seq);
        }
        #endregion
        #endregion

        #region IEquatable<T> Members
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
        public static bool operator==(CvSlice lhs, CvSlice rhs)
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
        public static bool operator !=(CvSlice lhs, CvSlice rhs)
        {
            return !lhs.Equals(rhs);
        }
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
        public bool Equals(CvSlice obj)
	    {
            return (this.StartIndex == obj.StartIndex && this.EndIndex == obj.EndIndex);
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
            return StartIndex.GetHashCode() + EndIndex.GetHashCode();
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
		    return string.Format("CvSlice (Start:{0} End:{1})", StartIndex, EndIndex);
        }
        #endregion
    }
}
