using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>/// 
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
// ReSharper disable once InconsistentNaming
public record struct Point3f(float X, float Y, float Z)
{
    /// <summary>
    /// 
    /// </summary>
    public float X = X;

    /// <summary>
    /// 
    /// </summary>
    public float Y = Y;

    /// <summary>
    /// 
    /// </summary>
    public float Z = Z;

    #region Cast

#pragma warning disable 1591

    public static explicit operator Point3i(Point3f self) => self.ToPoint3i();

    // ReSharper disable once InconsistentNaming
    public readonly Point3i ToPoint3i() => new ((int)X, (int)Y, (int)Z);

    public static implicit operator Point3f(Point3i point) => FromPoint3i(point);

    // ReSharper disable once InconsistentNaming
    public static Point3f FromPoint3i(Point3i point) => new (point.X, point.Y, point.Z);

    public static implicit operator Vec3f(Point3f self) => self.ToVec3f();

    // ReSharper disable once InconsistentNaming
    public readonly Vec3f ToVec3f() => new(X, Y, Z);

    public static implicit operator Point3f(Vec3f vec) => FromVec3f(vec);

    // ReSharper disable once InconsistentNaming
    public static Point3f FromVec3f(Vec3f vec) => new (vec.Item0, vec.Item1, vec.Item2);

#pragma warning restore 1591

    #endregion

    #region Operators
 
    /// <summary>
    /// Unary plus operator
    /// </summary>
    /// <returns></returns>
    public readonly Point3f Plus() => this;

    /// <summary>
    /// Unary plus operator
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public static Point3f operator +(Point3f pt) => pt;

    /// <summary>
    /// Unary minus operator
    /// </summary>
    /// <returns></returns>
    public readonly Point3f Negate() => new(-X, -Y, -Z);

    /// <summary>
    /// Unary minus operator
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public static Point3f operator -(Point3f pt) => pt.Negate();

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public readonly Point3f Add(Point3f p) => new(X + p.X, Y + p.Y, Z + p.Z);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static Point3f operator +(Point3f p1, Point3f p2) => p1.Add(p2);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public readonly Point3f Subtract(Point3f p) => new(X - p.X, Y - p.Y, Z - p.Z);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static Point3f operator -(Point3f p1, Point3f p2) => p1.Subtract(p2);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public readonly Point3f Multiply(double scale) 
        => new((float)(X * scale), (float)(Y * scale), (float)(Z * scale));

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="pt"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static Point3f operator *(Point3f pt, double scale) => pt.Multiply(scale);

    #endregion
}
