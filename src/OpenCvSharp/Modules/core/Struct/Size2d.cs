using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Size2d : IEquatable<Size2d>
    {
        /// <summary>
        /// 
        /// </summary>
        public double Width;

        /// <summary>
        /// 
        /// </summary>
        public double Height;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Size2d(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Size2d(double width, double height)
        {
            Width = width;
            Height = height;
        }

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
        public static bool operator ==(Size2d lhs, Size2d rhs)
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
        public static bool operator !=(Size2d lhs, Size2d rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region Override
        
        /// <inheritdoc />
        public readonly bool Equals(Size2d other)
        {
            return Width.Equals(other.Width) && Height.Equals(other.Height);
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Size2d other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (Width.GetHashCode() * 397) ^ Height.GetHashCode();
            }
        }

        /// <inheritdoc />
        public override readonly string ToString()
        {
            return $"(width:{Width} height:{Height})";
        }

        #endregion

    }
}
