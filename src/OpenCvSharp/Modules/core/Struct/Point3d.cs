using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>/// 
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Point3d(double X, double Y, double Z)
{
    /// <summary>
    /// 
    /// </summary>
    public double X = X;

    /// <summary>
    /// 
    /// </summary>
    public double Y = Y;

    /// <summary>
    /// 
    /// </summary>
    public double Z = Z;

    #region Cast

#pragma warning disable 1591

    public static explicit operator Point3i(Point3d self) => self.ToPoint3i();

    // ReSharper disable once InconsistentNaming
    public readonly Point3i ToPoint3i() => new((int)X, (int)Y, (int)Z);

    public static implicit operator Point3d(Point3i point) => FromPoint3i(point);

    // ReSharper disable once InconsistentNaming
    public static Point3d FromPoint3i(Point3i point) => new(point.X, point.Y, point.Z);

    public static implicit operator Vec3d(Point3d self) => self.ToVec3d();

    // ReSharper disable once InconsistentNaming
    public readonly Vec3d ToVec3d() => new(X, Y, Z);

    public static implicit operator Point3d(Vec3d vec) => FromVec3d(vec);

    // ReSharper disable once InconsistentNaming
    public static Point3d FromVec3d(Vec3d vec) => new(vec.Item0, vec.Item1, vec.Item2);

#pragma warning restore 1591

    #endregion

    #region Operators

    /// <summary>
    /// Unary plus operator
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public static Point3d operator +(Point3d pt) => pt;

    /// <summary>
    /// Unary plus operator
    /// </summary>
    /// <returns></returns>
    public readonly Point3d Plus() => this;

    /// <summary>
    /// Unary minus operator
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public static Point3d operator -(Point3d pt) => pt.Negate();

    /// <summary>
    /// Unary minus operator
    /// </summary>
    /// <returns></returns>
    public readonly Point3d Negate() => new(-X, -Y, -Z);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static Point3d operator +(Point3d p1, Point3d p2) => p1.Add(p2);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public readonly Point3d Add(Point3d p) => new(X + p.X, Y + p.Y, Z + p.Z);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static Point3d operator -(Point3d p1, Point3d p2) => p1.Subtract(p2);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public readonly Point3d Subtract(Point3d p) => new(X - p.X, Y - p.Y, Z - p.Z);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="pt"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static Point3d operator *(Point3d pt, double scale) => pt.Multiply(scale);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public readonly Point3d Multiply(double scale) => new(X * scale, Y * scale, Z * scale);

    #endregion
}
