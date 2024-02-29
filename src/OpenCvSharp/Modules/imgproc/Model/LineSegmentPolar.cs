using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// Polar line segment retrieved from cvHoughLines2
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public struct LineSegmentPolar : IEquatable<LineSegmentPolar>
{
    /// <summary>
    /// Length of the line
    /// </summary>
    public float Rho;

    /// <summary>
    /// Angle of the line (radian)
    /// </summary>
    public float Theta;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="rho">Length of the line</param>
    /// <param name="theta">Angle of the line (radian)</param>
    public LineSegmentPolar(float rho, float theta)
    {
        Rho = rho;
        Theta = theta;
    }

    #region Operators

    /// <summary>
    /// Specifies whether this object contains the same members as the specified Object.
    /// </summary>
    /// <param name="other">The Object to test.</param>
    /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
    public bool Equals(LineSegmentPolar other)
    {
        return (Math.Abs(Rho - other.Rho) < 1e-9 && 
                Math.Abs(Theta - other.Theta) < 1e-9);
    }

    /// <summary>
    /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
    /// </summary>
    /// <param name="lhs">A Point to compare.</param>
    /// <param name="rhs">A Point to compare.</param>
    /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
    public static bool operator ==(LineSegmentPolar lhs, LineSegmentPolar rhs)
    {
        return lhs.Equals(rhs);
    }

    /// <summary>
    /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
    /// </summary>
    /// <param name="lhs">A Point to compare.</param>
    /// <param name="rhs">A Point to compare.</param>
    /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
    public static bool operator !=(LineSegmentPolar lhs, LineSegmentPolar rhs)
    {
        return !lhs.Equals(rhs);
    }

    #endregion

    #region Overrided methods

    /// <summary>
    /// Specifies whether this object contains the same members as the specified Object.
    /// </summary>
    /// <param name="obj">The Object to test.</param>
    /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    /// <summary>
    /// Returns a hash code for this object.
    /// </summary>
    /// <returns>An integer value that specifies a hash value for this object.</returns>
    public override int GetHashCode()
    {
        return Rho.GetHashCode() + Theta.GetHashCode();
    }

    /// <summary>
    /// Converts this object to a human readable string.
    /// </summary>
    /// <returns>A string that represents this object.</returns>
    public override string ToString()
    {
        return $"CvLineSegmentPolar (Rho:{Rho} Theta:{Theta})";
    }
    #endregion

    #region Methods

    /// <summary>
    /// Calculates a intersection of the specified two lines
    /// </summary>
    /// <param name="line1"></param>
    /// <param name="line2"></param>
    /// <returns></returns>
    public static Point? LineIntersection(LineSegmentPolar line1, LineSegmentPolar line2)
    {
        var seg1 = line1.ToSegmentPoint(5000);
        var seg2 = line2.ToSegmentPoint(5000);
        return LineSegmentPoint.LineIntersection(seg1, seg2);
    }

    /// <summary>
    /// Calculates a intersection of the specified two lines
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public Point? LineIntersection(LineSegmentPolar line)
    {
        return LineIntersection(this, line);
    }

    /// <summary>
    /// Convert To LineSegmentPoint
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public LineSegmentPoint ToSegmentPoint(double scale)
    {
        var cos = Math.Cos(Theta);
        var sin = Math.Sin(Theta);
        var x0 = cos * Rho;
        var y0 = sin * Rho;
        var p1 = new Point { X = (int)Math.Round(x0 + scale * -sin), Y = (int)Math.Round(y0 + scale * cos) };
        var p2 = new Point { X = (int)Math.Round(x0 - scale * -sin), Y = (int)Math.Round(y0 - scale * cos) };
        return new LineSegmentPoint(p1, p2);
    }

    /// <summary>
    /// Converts to a line segment with the specified x coordinates at both ends
    /// </summary>
    /// <param name="x1"></param>
    /// <param name="x2"></param>
    /// <returns></returns>
    public LineSegmentPoint ToSegmentPointX(int x1, int x2)
    {
        if (x1 > x2)
            throw new ArgumentException($"{nameof(x1)} > {nameof(x2)}");

        var y1 = YPosOfLine(x1);
        var y2 = YPosOfLine(x2);
        if (!y1.HasValue || !y2.HasValue)
            throw new OpenCvSharpException("Failed to determine y coordinate.");

        var p1 = new Point(x1, y1.Value);
        var p2 = new Point(x2, y2.Value);
        return new LineSegmentPoint(p1, p2);
    }

    /// <summary>
    /// Converts to a line segment with the specified y coordinates at both ends
    /// </summary>
    /// <param name="y1"></param>
    /// <param name="y2"></param>
    /// <returns></returns>
    public LineSegmentPoint ToSegmentPointY(int y1, int y2)
    {
        if (y1 > y2)
            throw new ArgumentException($"{nameof(y1)} > {nameof(y2)}");

        var x1 = XPosOfLine(y1);
        var x2 = XPosOfLine(y2);
        if (!x1.HasValue || !x2.HasValue)
            throw new OpenCvSharpException("Failed to determine x coordinate.");

        var p1 = new Point(x1.Value, y1);
        var p2 = new Point(x2.Value, y2);
        return new LineSegmentPoint(p1, p2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    public int? XPosOfLine(int y)
    {
        var axis = new LineSegmentPolar(y, (float)(Math.PI / 2));     // 垂線90度 = x軸に平行       
        var node = LineIntersection(axis);
        return node?.X;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public int? YPosOfLine(int x)
    {
        var axis = new LineSegmentPolar(x, 0);     // 垂線0度 = y軸に平行       
        var node = LineIntersection(axis);
        return node?.Y;
    }

    #endregion
}
