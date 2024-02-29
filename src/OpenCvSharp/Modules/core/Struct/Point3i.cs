using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// 
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
public record struct Point3i(int X, int Y, int Z)
{
    /// <summary>
    /// 
    /// </summary>
    public int X = X;

    /// <summary>
    /// 
    /// </summary>
    public int Y = Y;

    /// <summary>
    /// 
    /// </summary>
    public int Z = Z;

    #region Cast

#pragma warning disable 1591

    public static implicit operator Vec3i(Point3i point) => point.ToVec3i();

    // ReSharper disable once InconsistentNaming
    public readonly Vec3i ToVec3i() => new(X, Y, Z);

    public static implicit operator Point3i(Vec3i vec) => FromVec3i(vec);

    // ReSharper disable once InconsistentNaming
    public static Point3i FromVec3i(Vec3i vec) => new(vec.Item0, vec.Item1, vec.Item2);

#pragma warning restore 1591

    #endregion

    #region Operators

    /// <summary>
    /// Unary plus operator
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public static Point3i operator +(Point3i pt) => pt;

    /// <summary>
    /// Unary plus operator
    /// </summary>
    /// <returns></returns>
    public readonly Point3i Plus() => this;

    /// <summary>
    /// Unary minus operator
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public static Point3i operator -(Point3i pt)
    {
        return pt.Negate();
    }

    /// <summary>
    /// Unary minus operator
    /// </summary>
    /// <returns></returns>
    public readonly Point3i Negate() => new (-X, -Y, -Z);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static Point3i operator +(Point3i p1, Point3i p2) => p1.Add(p2);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public readonly Point3i Add(Point3i p) => new (X + p.X, Y + p.Y, Z + p.Z);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static Point3i operator -(Point3i p1, Point3i p2) => p1.Subtract(p2);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public readonly Point3i Subtract(Point3i p) => new (X - p.X, Y - p.Y, Z - p.Z);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="pt"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static Point3i operator *(Point3i pt, double scale) => pt.Multiply(scale);

    /// <summary>
    /// Shifts point by a certain offset
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public readonly Point3i Multiply(double scale) => new ((int)(X * scale), (int)(Y * scale), (int)(Z * scale));

    #endregion
}
