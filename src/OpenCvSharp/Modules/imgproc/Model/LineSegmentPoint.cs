using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// Line segment structure retrieved from cvHoughLines2
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public struct LineSegmentPoint : IEquatable<LineSegmentPoint>
{
    /// <summary>
    /// 1st Point
    /// </summary>
    public Point P1;

    /// <summary>
    /// 2nd Point
    /// </summary>
    public Point P2;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="p1">1st Point</param>
    /// <param name="p2">2nd Point</param>
    public LineSegmentPoint(Point p1, Point p2)
    {
        P1 = p1;
        P2 = p2;
    }
        
    #region Operators

    /// <summary>
    /// Specifies whether this object contains the same members as the specified Object.
    /// </summary>
    /// <param name="other">The Object to test.</param>
    /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
    public bool Equals(LineSegmentPoint other)
    {
        return (P1 == other.P1 && P2 == other.P2);
    }

    /// <summary>
    /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
    /// </summary>
    /// <param name="lhs">A Point to compare.</param>
    /// <param name="rhs">A Point to compare.</param>
    /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
    public static bool operator ==(LineSegmentPoint lhs, LineSegmentPoint rhs)
    {
        return lhs.Equals(rhs);
    }

    /// <summary>
    /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
    /// </summary>
    /// <param name="lhs">A Point to compare.</param>
    /// <param name="rhs">A Point to compare.</param>
    /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
    public static bool operator !=(LineSegmentPoint lhs, LineSegmentPoint rhs)
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
        return P1.GetHashCode() + P2.GetHashCode();
    }

    /// <summary>
    /// Converts this object to a human readable string.
    /// </summary>
    /// <returns>A string that represents this object.</returns>
    public override string ToString()
    {
        return $"CvLineSegmentPoint (P1:{P1} P2:{P2})";
    }

    #endregion

    #region Methods

    #region Line and Line

    /// <summary>
    /// Calculates a intersection of the specified two lines
    /// </summary>
    /// <param name="line1"></param>
    /// <param name="line2"></param>
    /// <returns></returns>
    public static Point? LineIntersection(LineSegmentPoint line1, LineSegmentPoint line2)
    {
        var x1 = line1.P1.X;
        var y1 = line1.P1.Y;
        var f1 = line1.P2.X - line1.P1.X;
        var g1 = line1.P2.Y - line1.P1.Y;
        var x2 = line2.P1.X;
        var y2 = line2.P1.Y;
        var f2 = line2.P2.X - line2.P1.X;
        var g2 = line2.P2.Y - line2.P1.Y;

        double det = f2*g1 - f1*g2;
        if (Math.Abs(det) < 1e-9)
        {
            return null;
        }

        var dx = x2 - x1;
        var dy = y2 - y1;
        var t1 = (f2*dy - g2*dx)/det;
        //var t2 = (f1*dy - g1*dx)/det;

        return new Point
        {
            X = (int) Math.Round(x1 + (f1*t1)),
            Y = (int) Math.Round(y1 + (g1*t1))
        };
    }

    /// <summary>
    /// Calculates a intersection of the specified two lines
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public Point? LineIntersection(LineSegmentPoint line)
    {
        return LineIntersection(this, line);
    }

    #endregion

    #region Segment and Segment
        
    /// <summary>
    /// Calculates a intersection of the specified two segments
    /// </summary>
    /// <param name="seg1"></param>
    /// <param name="seg2"></param>
    /// <returns></returns>
    public static Point? SegmentIntersection(LineSegmentPoint seg1, LineSegmentPoint seg2)
    {
        if (IntersectedSegments(seg1, seg2))
            return LineIntersection(seg1, seg2);
        else
            return null;
    }
        
    /// <summary>
    /// Calculates a intersection of the specified two segments
    /// </summary>
    /// <param name="seg"></param>
    /// <returns></returns>
    public Point? SegmentIntersection(LineSegmentPoint seg)
    {
        return SegmentIntersection(this, seg);
    }
        
    /// <summary>
    /// Returns a boolean value indicating whether the specified two segments intersect.
    /// </summary>
    /// <param name="seg1"></param>
    /// <param name="seg2"></param>
    /// <returns></returns>
    public static bool IntersectedSegments(LineSegmentPoint seg1, LineSegmentPoint seg2)
    {
        var p1 = seg1.P1;
        var p2 = seg1.P2;
        var p3 = seg2.P1;
        var p4 = seg2.P2;

        checked
        {
            if (p1.X >= p2.X)
            {
                if ((p1.X < p3.X && p1.X < p4.X) || (p2.X > p3.X && p2.X > p4.X))
                    return false;
            }
            else
            {
                if ((p2.X < p3.X && p2.X < p4.X) || (p1.X > p3.X && p1.X > p4.X))
                    return false;
            }
            if (p1.Y >= p2.Y)
            {
                if ((p1.Y < p3.Y && p1.Y < p4.Y) || (p2.Y > p3.Y && p2.Y > p4.Y))
                    return false;
            }
            else
            {
                if ((p2.Y < p3.Y && p2.Y < p4.Y) || (p1.Y > p3.Y && p1.Y > p4.Y))
                    return false;
            }

            if (((long) (p1.X - p2.X)*(p3.Y - p1.Y) + (long) (p1.Y - p2.Y)*(p1.X - p3.X))*
                ((long) (p1.X - p2.X)*(p4.Y - p1.Y) + (long) (p1.Y - p2.Y)*(p1.X - p4.X)) > 0)
                return false;
            if (((long) (p3.X - p4.X)*(p1.Y - p3.Y) + (long) (p3.Y - p4.Y)*(p3.X - p1.X))*
                ((long) (p3.X - p4.X)*(p2.Y - p3.Y) + (long) (p3.Y - p4.Y)*(p3.X - p2.X)) > 0)
                return false;
        }
        return true;
    }

    /// <summary>
    /// Returns a boolean value indicating whether the specified two segments intersect.
    /// </summary>
    /// <param name="seg"></param>
    /// <returns></returns>
    public bool IntersectedSegments(LineSegmentPoint seg)
    {
        return IntersectedSegments(this, seg);
    }

    #endregion

    #region Line and Segment

    /// <summary>
    /// Returns a boolean value indicating whether a line and a segment intersect.
    /// </summary>
    /// <param name="line">Line</param>
    /// <param name="seg">Segment</param>
    /// <returns></returns>
    public static bool IntersectedLineAndSegment(LineSegmentPoint line, LineSegmentPoint seg)
    {
        var p1 = line.P1;
        var p2 = line.P2;
        var p3 = seg.P1;
        var p4 = seg.P2;
        if (((long) (p1.X - p2.X)*(p3.Y - p1.Y) + (long) (p1.Y - p2.Y)*(p1.X - p3.X))*
            ((long) (p1.X - p2.X)*(p4.Y - p1.Y) + (long) (p1.Y - p2.Y)*(p1.X - p4.X)) > 0)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Calculates a intersection of a line and a segment
    /// </summary>
    /// <param name="line"></param>
    /// <param name="seg"></param>
    /// <returns></returns>
    public static Point? LineAndSegmentIntersection(LineSegmentPoint line, LineSegmentPoint seg)
    {
        if (IntersectedLineAndSegment(line, seg))
            return LineIntersection(line, seg);
        else
            return null;
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public double Length()
    {
        return P1.DistanceTo(P2);
    }

    /// <summary>
    /// Translates the Point by the specified amount. 
    /// </summary>
    /// <param name="x">The amount to offset the x-coordinate. </param>
    /// <param name="y">The amount to offset the y-coordinate. </param>
    /// <returns></returns>
    public void Offset(int x, int y)
    {
        P1.X += x;
        P1.Y += y;
        P2.X += x;
        P2.Y += y;
    }

    /// <summary>
    /// Translates the Point by the specified amount. 
    /// </summary>
    /// <param name="p">The Point used offset this CvPoint.</param>
    /// <returns></returns>
    public void Offset(Point p)
    {
        Offset(p.X, p.Y);
    }

    #endregion
}
