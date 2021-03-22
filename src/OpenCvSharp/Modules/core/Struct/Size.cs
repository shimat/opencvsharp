using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
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

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(Size lhs, Size rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
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
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                return (Width * 397) ^ Height;
            }
#else
            return HashCode.Combine(Width, Height);
#endif
        }

        /// <inheritdoc />
        public override readonly string ToString()
        {
            return $"(width:{Width} height:{Height})";
        }
        #endregion

    }
}
