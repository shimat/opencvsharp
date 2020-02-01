﻿using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct Size2f : IEquatable<Size2f>
    {
        /// <summary>
        /// 
        /// </summary>
        public float Width;

        /// <summary>
        /// 
        /// </summary>
        public float Height;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Size2f(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Size2f(double width, double height)
        {
            Width = (float) width;
            Height = (float) height;
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
        public static bool operator ==(Size2f lhs, Size2f rhs)
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
        public static bool operator !=(Size2f lhs, Size2f rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region Override
        
        /// <inheritdoc />
        public readonly bool Equals(Size2f other)
        {
            return Width.Equals(other.Width) && Height.Equals(other.Height);
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Size2f other && Equals(other);
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
