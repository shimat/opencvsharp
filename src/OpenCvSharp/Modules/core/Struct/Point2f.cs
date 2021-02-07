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
    // ReSharper disable once InconsistentNaming
    public struct Point2f : IEquatable<Point2f>
    {
        /// <summary>
        /// 
        /// </summary>
        public float X;

        /// <summary>
        /// 
        /// </summary>
        public float Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point2f(float x, float y)
        {
            X = x;
            Y = y;
        }

        #region Cast

#pragma warning disable 1591

        // ReSharper disable once InconsistentNaming
        public readonly Point ToPoint() => new((int)X, (int)Y);

        public static explicit operator Point(Point2f self) => self.ToPoint();
        
        public static Point2f FromPoint(Point point) => new (point.X, point.Y);

        public static implicit operator Point2f(Point point) => FromPoint(point);

        // ReSharper disable once InconsistentNaming
        public readonly Vec2f ToVec2f() => new(X, Y);

        public static implicit operator Vec2f(Point2f point) => point.ToVec2f();

        // ReSharper disable once InconsistentNaming
        public static Point2f FromVec2f(Vec2f vec) => new(vec.Item0, vec.Item1);

        public static implicit operator Point2f(Vec2f vec) => FromVec2f(vec);

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
        public static bool operator ==(Point2f lhs, Point2f rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two CvPoint2D32f objects. The result specifies whether the values of the X or Y properties of the two CvPoint2D32f objects are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the values of either the X properties or the Y properties of left and right differ; otherwise, false.</returns>
        public static bool operator !=(Point2f lhs, Point2f rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region + / -

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point2f Plus() => this;

        /// <summary>
        /// Unary plus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point2f operator +(Point2f pt)
        {
            return pt;
        }
        
        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <returns></returns>
        public readonly Point2f Negate() => new(-X, -Y);

        /// <summary>
        /// Unary minus operator
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Point2f operator -(Point2f pt) => pt.Negate();

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point2f Add(Point2f p) => new(X + p.X, Y + p.Y);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point2f operator +(Point2f p1, Point2f p2) => p1.Add(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly Point2f Subtract(Point2f p) => new(X - p.X, Y - p.Y);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Point2f operator -(Point2f p1, Point2f p2) => p1.Subtract(p2);

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public readonly Point2f Multiply(double scale) => new((float)(X * scale), (float)(Y * scale));

        /// <summary>
        /// Shifts point by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Point2f operator *(Point2f pt, double scale) => pt.Multiply(scale);

        #endregion

        #endregion

        #region Override
        
        /// <inheritdoc />
        public readonly bool Equals(Point2f other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Point2f other && Equals(other);
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
        public static double Distance(Point2f p1, Point2f p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        /// <summary>
        /// Returns the distance between the specified two points
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly double DistanceTo(Point2f p)
        {
            return Distance(this, p);
        }

        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double DotProduct(Point2f p1, Point2f p2)
        {
            return p1.X*p2.X + p1.Y*p2.Y;
        }

        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly double DotProduct(Point2f p)
        {
            return DotProduct(this, p);
        }

        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double CrossProduct(Point2f p1, Point2f p2)
        {
            return p1.X*p2.Y - p2.X*p1.Y;
        }

        /// <summary>
        /// Calculates the cross product of two 2D vectors.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public readonly double CrossProduct(Point2f p)
        {
            return CrossProduct(this, p);
        }

        #endregion
    }
}
