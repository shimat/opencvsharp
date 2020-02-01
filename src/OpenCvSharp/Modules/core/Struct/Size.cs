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
    public struct Size : IEquatable<Size>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Width;

        /// <summary>
        /// 
        /// </summary>
        public int Height;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Size(double width, double height)
        {
            Width = (int)width;
            Height = (int)height;
        }

        /// <summary>
        /// Zero size
        /// </summary>
        public static readonly Size Zero;

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
        public static bool operator ==(Size lhs, Size rhs)
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
        public static bool operator !=(Size lhs, Size rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region Override
        
        /// <inheritdoc />
        public readonly bool Equals(Size other)
        {
            return Width == other.Width && Height == other.Height;
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Size other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return (Width * 397) ^ Height;
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
