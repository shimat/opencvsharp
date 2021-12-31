using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// Data structure for salient point detectors
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
    public struct KeyPoint : IEquatable<KeyPoint>
    {
        #region Properties

        /// <summary>
        /// Coordinate of the point
        /// </summary>
        public Point2f Pt;

        /// <summary>
        /// Feature size
        /// </summary>
        public float Size;

        /// <summary>
        /// Feature orientation in degrees (has negative value if the orientation is not defined/not computed)
        /// </summary>
        public float Angle;

        /// <summary>
        /// Feature strength (can be used to select only the most prominent key points)
        /// </summary>
        public float Response;

        /// <summary>
        /// Scale-space octave in which the feature has been found; may correlate with the size
        /// </summary>
        public int Octave;

        /// <summary>
        /// Point class (can be used by feature classifiers or object detectors)
        /// </summary>
        public int ClassId;

        #endregion

        #region Constructors

        /// <summary>
        /// Complete constructor
        /// </summary>
        /// <param name="pt">Coordinate of the point</param>
        /// <param name="size">Feature size</param>
        /// <param name="angle">Feature orientation in degrees (has negative value if the orientation is not defined/not computed)</param>
        /// <param name="response">Feature strength (can be used to select only the most prominent key points)</param>
        /// <param name="octave">Scale-space octave in which the feature has been found; may correlate with the size</param>
        /// <param name="classId">Point class (can be used by feature classifiers or object detectors)</param>
        public KeyPoint(Point2f pt, float size, float angle = -1, float response = 0, int octave = 0,
            int classId = -1)
        {
            Pt = pt;
            Size = size;
            Angle = angle;
            Response = response;
            Octave = octave;
            ClassId = classId;
        }

        /// <summary>
        /// Complete constructor
        /// </summary>
        /// <param name="x">X-coordinate of the point</param>
        /// <param name="y">Y-coordinate of the point</param>
        /// <param name="size">Feature size</param>
        /// <param name="angle">Feature orientation in degrees (has negative value if the orientation is not defined/not computed)</param>
        /// <param name="response">Feature strength (can be used to select only the most prominent key points)</param>
        /// <param name="octave">Scale-space octave in which the feature has been found; may correlate with the size</param>
        /// <param name="classId">Point class (can be used by feature classifiers or object detectors)</param>
        public KeyPoint(float x, float y, float size, float angle = -1, float response = 0, int octave = 0,
            int classId = -1)
            : this(new Point2f(x, y), size, angle, response, octave, classId)
        {
        }

        #endregion

        #region Operators

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(KeyPoint lhs, KeyPoint rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two CvPoint objects. The result specifies whether the members of each object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
        public static bool operator !=(KeyPoint lhs, KeyPoint rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region Overrided Methods
        
        /// <inheritdoc />
        public readonly bool Equals(KeyPoint other)
        {
            return Pt.Equals(other.Pt) && Size.Equals(other.Size) && Angle.Equals(other.Angle) && Response.Equals(other.Response) && Octave == other.Octave && ClassId == other.ClassId;
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is KeyPoint other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
#if NET48 || NETSTANDARD2_0
            unchecked
            {
                var hashCode = Pt.GetHashCode();
                hashCode = (hashCode * 397) ^ Size.GetHashCode();
                hashCode = (hashCode * 397) ^ Angle.GetHashCode();
                hashCode = (hashCode * 397) ^ Response.GetHashCode();
                hashCode = (hashCode * 397) ^ Octave;
                hashCode = (hashCode * 397) ^ ClassId;
                return hashCode;
            }
#else
            return HashCode.Combine(Pt, Size, Angle, Response, Octave, ClassId);
#endif
        }
        
        /// <inheritdoc />
        public override readonly string ToString()
        {
            // ReSharper disable once UseStringInterpolation
            return string.Format(
                CultureInfo.InvariantCulture,
                "[Pt:{0}, Size:{1}, Angle:{2}, Response:{3}, Octave:{4}, ClassId:{5}]",
                Pt, Size, Angle, Response, Octave, ClassId);
        }

        #endregion
    }
}
