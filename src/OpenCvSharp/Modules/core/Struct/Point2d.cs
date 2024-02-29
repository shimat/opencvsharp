using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>/// 
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Point2d(double X, double Y)
{
    /// <summary>
    /// 
    /// </summary>
    public double X = X;

    /// <summary>
    /// 
    /// </summary>
    public double Y = Y;

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
