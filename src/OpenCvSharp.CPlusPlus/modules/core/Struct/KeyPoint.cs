using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 特徴点検出器のためのデータ構造体
    /// </summary>
#else
    /// <summary>
    /// Data structure for salient point detectors
    /// </summary>
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct KeyPoint : IEquatable<KeyPoint>
    {
        #region Properties

#if LANG_JP
    /// <summary>
    /// 特徴点の座標
    /// </summary>
#else
        /// <summary>
        /// Coordinate of the point
        /// </summary>
#endif
        public Point2f Pt;

#if LANG_JP
    /// <summary>
    /// 特徴点のサイズ
    /// </summary>
#else
        /// <summary>
        /// Feature size
        /// </summary>
#endif
        public float Size;

#if LANG_JP
    /// <summary>
    /// 特徴点の向き(度数法)。 向きが定義されない、若しくは計算されない場合には負数。
    /// </summary>
#else
        /// <summary>
        /// Feature orientation in degrees (has negative value if the orientation is not defined/not computed)
        /// </summary>
#endif
        public float Angle;

#if LANG_JP
    /// <summary>
    /// 特徴点の強さ（もっとも顕著なキーポイントを求めるために使われる）
    /// </summary>
#else
        /// <summary>
        /// Feature strength (can be used to select only the most prominent key points)
        /// </summary>
#endif
        public float Response;

#if LANG_JP
    /// <summary>
    /// 特徴点が見つかったscale-spaceのoctave。サイズと相関がある場合がある。
    /// </summary>
#else
        /// <summary>
        /// Scale-space octave in which the feature has been found; may correlate with the size
        /// </summary>
#endif
        public int Octave;

#if LANG_JP
    /// <summary>
    /// 特徴点のクラス（特徴点分類機または物体検出器において用いられる）
    /// </summary>
#else
        /// <summary>
        /// Point class (can be used by feature classifiers or object detectors)
        /// </summary>
#endif
        public int ClassId;

        #endregion

        #region Constructors

#if LANG_JP
    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="pt">特徴点の座標</param>
    /// <param name="size">特徴点のサイズ</param>
    /// <param name="angle">特徴点の向き(度数法)。 向きが定義されない、若しくは計算されない場合には負数。</param>
    /// <param name="response">特徴点の強さ（もっとも顕著なキーポイントを求めるために使われる）</param>
    /// <param name="octave">特徴点が見つかったscale-spaceのoctave。サイズと相関がある場合がある。</param>
    /// <param name="classId">特徴点のクラス（特徴点分類機または物体検出器において用いられる）</param>
#else
        /// <summary>
        /// Complete constructor
        /// </summary>
        /// <param name="pt">Coordinate of the point</param>
        /// <param name="size">Feature size</param>
        /// <param name="angle">Feature orientation in degrees (has negative value if the orientation is not defined/not computed)</param>
        /// <param name="response">Feature strength (can be used to select only the most prominent key points)</param>
        /// <param name="octave">Scale-space octave in which the feature has been found; may correlate with the size</param>
        /// <param name="classId">Point class (can be used by feature classifiers or object detectors)</param>
#endif
        public KeyPoint(Point2f pt, float size, float angle = -1, float response = 0, int octave = 0,
            int classId = -1)
        {
            Pt = pt;
            Size = size;
            Angle = angle;
            Response = response;
            Octave = octave;
            ClassId = classId;
        }

#if LANG_JP
    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="x">特徴点のx座標</param>
    /// <param name="y">特徴点のy座標</param>
    /// <param name="size">特徴点のサイズ</param>
    /// <param name="angle">特徴点の向き(度数法)。 向きが定義されない、若しくは計算されない場合には負数。</param>
    /// <param name="response">特徴点の強さ（もっとも顕著なキーポイントを求めるために使われる）</param>
    /// <param name="octave">特徴点が見つかったscale-spaceのoctave。サイズと相関がある場合がある。</param>
    /// <param name="classId">特徴点のクラス（特徴点分類機または物体検出器において用いられる）</param>
#else
        /// <summary>
        /// Complete constructor
        /// </summary>
        /// <param name="x">X-coordinate of the point</param>
        /// <param name="y">Y-coordinate of the point</param>
        /// <param name="size">Feature size</param>
        /// <param name="angle">Feature orientation in degrees (has negative value if the orientation is not defined/not computed)</param>
        /// <param name="response">Feature strength (can be used to select only the most prominent key points)</param>
        /// <param name="octave">Scale-space octave in which the feature has been found; may correlate with the size</param>
        /// <param name="classId">Point class (can be used by feature classifiers or object detectors)</param>
#endif
        public KeyPoint(float x, float y, float size, float angle = -1, float response = 0, int octave = 0,
            int classId = -1)
            : this(new Point2f(x, y), size, angle, response, octave, classId)
        {
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
        public bool Equals(KeyPoint obj)
        {
            return (
                this.Pt == obj.Pt &&
                this.Size == obj.Size &&
                this.Angle == obj.Angle &&
                this.Response == obj.Response &&
                this.Octave == obj.Octave &&
                this.ClassId == obj.ClassId
                );
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
        public static bool operator ==(KeyPoint lhs, KeyPoint rhs)
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
        public static bool operator !=(KeyPoint lhs, KeyPoint rhs)
        {
            return !lhs.Equals(rhs);
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
            unchecked
            {
                return (
                    this.Pt.GetHashCode() +
                    this.Size.GetHashCode() +
                    this.Angle.GetHashCode() +
                    this.Response.GetHashCode() +
                    this.Octave.GetHashCode() +
                    this.ClassId.GetHashCode()
                    );
            }
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
            return String.Format("[Pt:{0}, Size:{1}, Angle:{2}, Response:{3}, Octave:{4}, ClassId:{5}]", Pt, Size, Angle,
                Response, Octave, ClassId);
        }

        #endregion
    }
}
