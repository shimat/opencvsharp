using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp;

/// <summary>
/// circle structure retrieved from cvHoughCircle
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public struct CircleSegment : IEquatable<CircleSegment>
{
    #region Fields

    /// <summary>
    /// Center coordinate of the circle
    /// </summary>
    public Point2f Center;

    /// <summary>
    /// Radius
    /// </summary>
    public float Radius;

    #endregion

    #region Init

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="center">center</param>
    /// <param name="radius">radius</param>
    public CircleSegment(Point2f center, float radius)
    {
        Center = center;
        Radius = radius;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Specifies whether this object contains the same members as the specified Object.
    /// </summary>
    /// <param name="other">The Object to test.</param>
    /// <returns>This method returns true if obj is the same type as this object and has the same members as this object.</returns>
    public bool Equals(CircleSegment other)
    {
        return (Center == other.Center && 
                Math.Abs(Radius - other.Radius) < 1e-9);
    }

    /// <summary>
    /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
    /// </summary>
    /// <param name="lhs">A Point to compare.</param>
    /// <param name="rhs">A Point to compare.</param>
    /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
    public static bool operator ==(CircleSegment lhs, CircleSegment rhs)
    {
        return lhs.Equals(rhs);
    }

    /// <summary>
    /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
    /// </summary>
    /// <param name="lhs">A Point to compare.</param>
    /// <param name="rhs">A Point to compare.</param>
    /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
    public static bool operator !=(CircleSegment lhs, CircleSegment rhs)
    {
        return !lhs.Equals(rhs);
    }

    #endregion

    #region Overrided Methods

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
        return Center.GetHashCode() + Radius.GetHashCode();
    }

    /// <summary>
    /// Converts this object to a human readable string.
    /// </summary>
    /// <returns>A string that represents this object.</returns>
    public override string ToString()
    {
        return $"CvCircleSegment (Center:{Center} Radius:{Radius})";
    }

    #endregion
}
