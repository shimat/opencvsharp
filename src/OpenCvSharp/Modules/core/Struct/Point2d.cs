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
    public struct Point2d : IEquatable<Point2d>
    {
        /// <summary>
        /// 
        /// </summary>
        public double X;

        /// <summary>
        /// 
        /// </summary>
        public double Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        #region Cast

#pragma warning disable 1591

        // ReSharper disable once InconsistentNaming
        public readonly Point ToPoint() => new((int)X, (int)Y);

        public static explicit operator Point(Point2d self) => new((int) self.X, (int) self.Y);

        public static Point2d FromPoint(Point point) => new(point.X, point.Y);

        public static implicit operator Point2d(Point point) => new(point.X, point.Y);

        // ReSharper disable once InconsistentNaming
        public readonly Vec2d ToVec2d() => new(X, Y);

        public static implicit operator Vec2d(Point2d point) => new(point.X, point.Y);

        // ReSharper disable once InconsistentNaming
        public static Point2d FromVec2d(Vec2d vec) => new(vec.Item0, vec.Item1);

        public static implicit operator Point2d(Vec2d vec) => new(vec.Item0, vec.Item1);

#pragma warning restore 1591

        #endregion

        #region Operators

        #region == / !=

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the values of the X and Y properties of the two CvPoint objects are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the X and Y values of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(Point2d lhs, Point2d rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two CvPoint2D32f objects. The result specifies whether the values of the X or Y properties of the two CvPoint2D32f objects are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the values of either the X properties or the Y properties of left and right differ; otherwise, false.</returns>
        public static bool operator !=(Point2d lhs, Point2d rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region + / -

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point2d Plus() => this;

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point2d operator +(Point2d pt) => pt;

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point2d Negate() => new(-X, -Y);

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point2d operator -(Point2d pt) => pt.Negate();

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point2d Add(Point2d p) => new(X + p.X, Y + p.Y);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point2d operator +(Point2d p1, Point2d p2) => p1.Add(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point2d Subtract(Point2d p) => new(X - p.X, Y - p.Y);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point2d operator -(Point2d p1, Point2d p2) => p1.Subtract(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public readonly Point2d Multiply(double scale) => new(X * scale, Y * scale);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Point2d operator *(Point2d pt, double scale) => pt.Multiply(scale);

        #endregion

        #endregion

        #region Override

        /// <inheritdoc />
        public readonly bool Equals(Point2d other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Point2d other && Equals(other);
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
        public static double Distance(Point2d p1, Point2d p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        /// <summary>
        /// Returns the distance between the specified two points
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly double DistanceTo(Point2d p)
        {
            return Distance(this, p);
        }

        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double DotProduct(Point2d p1, Point2d p2)
        {
            return p1.X*p2.X + p1.Y*p2.Y;
        }

        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly double DotProduct(Point2d p)
        {
            return DotProduct(this, p);
        }

        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double CrossProduct(Point2d p1, Point2d p2)
        {
            return p1.X*p2.Y - p2.X*p1.Y;
        }

        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly double CrossProduct(Point2d p)
        {
            return CrossProduct(this, p);
        }

        #endregion
    }
}
