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
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        /// 
        /// </summary>
        public int X;

        /// <summary>
        /// 
        /// </summary>
        public int Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            X = (int) x;
            Y = (int) y;
        }

        #region Cast
        
#pragma warning disable 1591

        // ReSharper disable once InconsistentNaming
        public readonly Vec2i ToVec2i() => new(X, Y);

        public static implicit operator Vec2i(Point point) => point.ToVec2i();

        // ReSharper disable once InconsistentNaming
        public static Point FromVec2i(Vec2i vec) => new(vec.Item0, vec.Item1);

        public static implicit operator Point(Vec2i vec) => FromVec2i(vec);

#pragma warning restore 1591

        #endregion

        #region Operators

        #region == / !=

        /// <summary>
        /// Compares two Point objects. The result specifies whether the values of the X and Y properties of the two Point objects are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the X and Y values of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(Point lhs, Point rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two Point objects. The result specifies whether the values of the X or Y properties of the two Point objects are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the values of either the X properties or the Y properties of left and right differ; otherwise, false.</returns>
        public static bool operator !=(Point lhs, Point rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region + / -
        
        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point Plus() => this;

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point operator +(Point pt) => pt;

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point Negate() => new(-X, -Y);

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point operator -(Point pt) => pt.Negate();

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point Add(Point p) => new(X + p.X, Y + p.Y);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point operator +(Point p1, Point p2) => p1.Add(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point Subtract(Point p) => new(X - p.X, Y - p.Y);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point operator -(Point p1, Point p2) => p1.Subtract(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public readonly Point Multiply(double scale) => new(X * scale, Y * scale);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Point operator *(Point pt, double scale) => pt.Multiply(scale);

        #endregion

        #endregion

        #region Override

        /// <inheritdoc />
        public readonly bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Point other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
#if DOTNET_FRAMEWORK || NETSTANDARD2_0
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
#else
            return HashCode.Combine(X, Y);
#endif
        }

        /// <inheritdoc />
        public override readonly string ToString()
        {
            return $"(x:{X} y:{Y})";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the distance between the specified two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        /// <summary>
        /// Returns the distance between the specified two points
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly double DistanceTo(Point p)
        {
            return Distance(this, p);
        }

        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double DotProduct(Point p1, Point p2)
        {
            return p1.X*p2.X + p1.Y*p2.Y;
        }

        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly double DotProduct(Point p)
        {
            return DotProduct(this, p);
        }

        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double CrossProduct(Point p1, Point p2)
        {
            return p1.X*p2.Y - p2.X*p1.Y;
        }

        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly double CrossProduct(Point p)
        {
            return CrossProduct(this, p);
        }

        #endregion
    }
}