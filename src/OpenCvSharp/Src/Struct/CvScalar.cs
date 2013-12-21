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
	/// 4個までの数を納めるコンテナ. マネージdouble配列と可換。
	/// </summary>
#else
    /// <summary>
    /// A container for 1-,2-,3- or 4-tuples of numbers
    /// </summary>
#endif
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct CvScalar : IEquatable<CvScalar>
    {
        #region Fields
#if LANG_JP
        /// <summary>
		/// 1番目の要素
		/// </summary>
#else
        /// <summary>
        /// 1st element
        /// </summary>
#endif
		public double Val0;
#if LANG_JP
        /// <summary>
		/// 2番目の要素
		/// </summary>
#else
        /// <summary>
        /// 2nd element
        /// </summary>
#endif
        public double Val1;
#if LANG_JP
        /// <summary>
		/// 3番目の要素
		/// </summary>
#else
        /// <summary>
        /// 3rd element
        /// </summary>
#endif
        public double Val2;
#if LANG_JP
        /// <summary>
		/// 4番目の要素
		/// </summary>
#else
        /// <summary>
        /// 4th element
        /// </summary>
#endif
        public double Val3;

		/// <summary>
		/// sizeof(CvScalar) 
		/// </summary>
		public const int SizeOf = sizeof(double) * 4;
        #endregion

        #region Initializers
#if LANG_JP
        /// <summary>
        /// 1つのスカラー値を指定して初期化. 残りは0で埋める.
        /// </summary>
        /// <param name="val0"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val0"></param>
#endif
        public CvScalar(double val0)
            : this(val0, 0, 0, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 2つのスカラー値を指定して初期化. 残りは0で埋める.
        /// </summary>
        /// <param name="val0"></param>
        /// <param name="val1"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val0"></param>
        /// <param name="val1"></param>
#endif
        public CvScalar(double val0, double val1)
            : this(val0, val1, 0, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 3つのスカラー値を指定して初期化. 残りは0で埋める.
        /// </summary>
        /// <param name="val0"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val0"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
#endif
        public CvScalar(double val0, double val1, double val2)
            : this(val0, val1, val2, 0)
        {
        }
#if LANG_JP
        /// <summary>
	    /// すべてのスカラー値を指定して初期化
	    /// </summary>
	    /// <param name="val0"></param>
	    /// <param name="val1"></param>
	    /// <param name="val2"></param>
	    /// <param name="val3"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val0"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="val3"></param>
#endif
        public CvScalar(double val0, double val1, double val2, double val3)
        {
            this.Val0 = val0;
            this.Val1 = val1;
            this.Val2 = val2;
            this.Val3 = val3;
        }
#if LANG_JP
        /// <summary>
	    /// 指定した値を配列のすべての要素として初期化し、返す
	    /// </summary>
	    /// <param name="val0123"></param>
#else
        /// <summary>
        /// Initializes val[0]...val[3] with val0123
        /// </summary>
        /// <param name="val0123"></param>
        /// <returns></returns>
#endif
        public static CvScalar ScalarAll(double val0123)
        {
            return new CvScalar(val0123, val0123, val0123, val0123);
        }
#if LANG_JP
        /// <summary>
	    /// 指定した値を先頭要素とし、残りを0で初期化し、返す
	    /// </summary>
	    /// <param name="val0"></param>
#else
        /// <summary>
        /// Initializes val[0] with val0, val[1]...val[3] with zeros
        /// </summary>
        /// <param name="val0"></param>
        /// <returns></returns>
#endif
        public static CvScalar RealScalar(double val0)
        {
            return new CvScalar(val0, 0, 0, 0);
        }
        #endregion

        #region Properties
#if LANG_JP
		/// <summary>
		/// インデクサ
		/// </summary>
#else
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
#endif
        public double this[int index]{
			get {
				switch(index){
					case 0: return Val0;
					case 1: return Val1;
					case 2: return Val2;
					case 3: return Val3;
					default: throw new IndexOutOfRangeException();
				}
			}
			set {
				switch(index){
					case 0: Val0 = value; break;
					case 1: Val1 = value; break;
					case 2: Val2 = value; break;
					case 3: Val3 = value; break;
					default: throw new IndexOutOfRangeException();
				}
			}
        }
        #endregion

        #region Operators
#if LANG_JP
        /// <summary>
        /// マネージDouble配列から変換する明示的なキャスト
        /// </summary>
        /// <param name="obj">新しい CvScalar の値を指定する double 配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a CvScalar with the members of the specified array.
        /// </summary>
        /// <param name="obj">An array that specifies the members for the new CvScalar.</param>
        /// <returns></returns>
#endif
		public static explicit operator CvScalar(double[] obj)
        {
            if(obj.Length !=4){
                throw new ArgumentException();
            }
            return new CvScalar(obj[0], obj[1], obj[2], obj[3]);
        }
#if LANG_JP
        /// <summary>
        /// Double型の値から変換する暗黙のキャスト. RealScalarで初期化して返す.
        /// </summary>
        /// <param name="obj">新しい CvScalar の値を指定する double 配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates a CvScalar with the specified double value like cvRealScalar.
        /// </summary>
        /// <param name="obj">A double value that specifies the members for the new CvScalar.</param>
        /// <returns></returns>
#endif
		public static implicit operator CvScalar(double obj)
        {
            return CvScalar.RealScalar(obj);
        }
#if LANG_JP
        /// <summary>
        /// マネージDouble配列に変換する明示的なキャスト
        /// </summary>
        /// <param name="self">新しい Double配列 の値を指定する CvScalar 配列</param>
        /// <returns>double[4]</returns>
#else
        /// <summary>
        /// Creates a CvScalar with the specified double array.
        /// </summary>
        /// <param name="self">A CvScalar that specifies the members for the new array.</param>
        /// <returns>double[4]</returns>
#endif
		public static explicit operator double[](CvScalar self)
        {
            return new double[]{ self.Val0, self.Val1, self.Val2, self.Val3};
        }
#if LANG_JP
        /// <summary>
        /// Double型の値に変換する暗黙のキャスト. 先頭の要素を返す.
        /// </summary>
        /// <param name="self">新しい CvScalar の値を指定する double 配列</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Returns a double value with the specified CvScalar's Val0.
        /// </summary>
        /// <param name="self">A CvScalar that specifies the new double value.</param>
        /// <returns></returns>
#endif
		public static implicit operator double(CvScalar self)
        {
            return self.Val0;
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
        public bool Equals(CvScalar obj)
        {
            return (Val0 == obj.Val0 && Val1 == obj.Val1 && Val2 == obj.Val2 && Val3 == obj.Val3);
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
        public static bool operator ==(CvScalar lhs, CvScalar rhs)
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
        public static bool operator !=(CvScalar lhs, CvScalar rhs)
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
            return Val0.GetHashCode() + Val1.GetHashCode() + Val2.GetHashCode() + Val3.GetHashCode();
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
	    public override string  ToString()
	    {
		    return string.Format("{0}, {1}, {2}, {3}", Val0, Val1, Val2, Val3);
        }
        #endregion
    }

}
