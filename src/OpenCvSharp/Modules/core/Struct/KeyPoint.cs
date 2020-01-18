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
        
        /// <inheritdoc />
        public readonly bool Equals(KeyPoint other)
        {
            return Pt.Equals(other.Pt) && Size.Equals(other.Size) && Angle.Equals(other.Angle) && Response.Equals(other.Response) && Octave == other.Octave && ClassId == other.ClassId;
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is KeyPoint other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
            unchecked
            {
                var hashCode = Pt.GetHashCode();
                hashCode = (hashCode * 397) ^ Size.GetHashCode();
                hashCode = (hashCode * 397) ^ Angle.GetHashCode();
                hashCode = (hashCode * 397) ^ Response.GetHashCode();
                hashCode = (hashCode * 397) ^ Octave;
                hashCode = (hashCode * 397) ^ ClassId;
                return hashCode;
            }
        }
        
        /// <inheritdoc />
        public override readonly string ToString()
        {
            // ReSharper disable once UseStringInterpolation
            return string.Format("[Pt:{0}, Size:{1}, Angle:{2}, Response:{3}, Octave:{4}, ClassId:{5}]",
                Pt, Size, Angle, Response, Octave, ClassId);
        }

        #endregion

    }
}
