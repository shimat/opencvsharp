using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// A rectangle with float type coordinates in 2D space
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
    // ReSharper disable once InconsistentNaming
    public struct Rect2f : IEquatable<Rect2f>
    {
#pragma warning disable 1591
        public float X;
        public float Y;
        public float Width;
        public float Height;
#pragma warning restore 1591

        /// <summary>
        /// Represents a Rect2f structure with its properties left uninitialized. 
        /// </summary>
        public static readonly Rect2f Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rect2f(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location"></param>
        /// <param name="size"></param>
        public Rect2f(Point2f location, Size2f size)
        {
            X = location.X;
            Y = location.Y;
            Width = size.Width;
            Height = size.Height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        // ReSharper disable once InconsistentNaming
        public static Rect2f FromLTRB(float left, float top, float right, float bottom)
        {
            var r = new Rect2f
            {
                X = left,
                Y = top,
                Width = right - left,
                Height = bottom - top
            };

            if (r.Width < 0)
                throw new ArgumentException("right > left");
            if (r.Height < 0)
                throw new ArgumentException("bottom > top");
            return r;
        }

        #region Operators

        #region == / !=

        /// <summary>
        /// Compares two Rect2f objects. The result specifies whether the members of each object are equal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are equal; otherwise, false.</returns>
        public static bool operator ==(Rect2f lhs, Rect2f rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two Rect2f objects. The result specifies whether the members of each object are unequal.
        /// </summary>
        /// <param name="lhs">A Point to compare.</param>
        /// <param name="rhs">A Point to compare.</param>
        /// <returns>This operator returns true if the members of left and right are unequal; otherwise, false.</returns>
        public static bool operator !=(Rect2f lhs, Rect2f rhs)
        {
            return !lhs.Equals(rhs);
        }

        #endregion

        #region + / -

        /// <summary>
        /// Shifts rectangle by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public readonly Rect2f Add(Point2f pt) => new (X + pt.X, Y + pt.Y, Width, Height);

        /// <summary>
        /// Shifts rectangle by a certain offset
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Rect2f operator +(Rect2f rect, Point2f pt) => rect.Add(pt);

        /// <summary>
        /// Shifts rectangle by a certain offset
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public readonly Rect2f Subtract(Point2f pt) => new (X - pt.X, Y - pt.Y, Width, Height);

        /// <summary>
        /// Shifts rectangle by a certain offset
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static Rect2f operator -(Rect2f rect, Point2f pt) => rect.Subtract(pt);

        /// <summary>
        /// Expands or shrinks rectangle by a certain amount
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public readonly Rect2f Add(Size2f size) => new (X, Y, Width + size.Width, Height + size.Height);

        /// <summary>
        /// Expands or shrinks rectangle by a certain amount
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Rect2f operator +(Rect2f rect, Size2f size) => rect.Add(size);

        /// <summary>
        /// Expands or shrinks rectangle by a certain amount
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public readonly Rect2f Subtract(Size2f size) => new (X, Y, Width - size.Width, Height - size.Height);

        /// <summary>
        /// Expands or shrinks rectangle by a certain amount
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Rect2f operator -(Rect2f rect, Size2f size) => rect.Subtract(size);

        #endregion

        #region & / |

        /// <summary>
        /// Determines the Rect2f structure that represents the intersection of two rectangles. 
        /// </summary>
        /// <param name="a">A rectangle to intersect. </param>
        /// <param name="b">A rectangle to intersect. </param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
        public static Rect2f operator &(Rect2f a, Rect2f b)
        {
            return Intersect(a, b);
        }

        /// <summary>
        /// Gets a Rect2f structure that contains the union of two Rect2f structures. 
        /// </summary>
        /// <param name="a">A rectangle to union. </param>
        /// <param name="b">A rectangle to union. </param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
        public static Rect2f operator |(Rect2f a, Rect2f b)
        {
            return Union(a, b);
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets the y-coordinate of the top edge of this Rect2f structure. 
        /// </summary>
        public float Top
        {
            get => Y;
            set => Y = value;
        }

        /// <summary>
        /// Gets the y-coordinate that is the sum of the Y and Height property values of this Rect2f structure.
        /// </summary>
        public float Bottom => Y + Height;

        /// <summary>
        /// Gets the x-coordinate of the left edge of this Rect2f structure. 
        /// </summary>
        public float Left
        {
            get => X;
            set => X = value;
        }

        /// <summary>
        /// Gets the x-coordinate that is the sum of X and Width property values of this Rect2f structure. 
        /// </summary>
        public float Right => X + Width;

        /// <summary>
        /// Coordinate of the left-most rectangle corner [Point2f(X, Y)]
        /// </summary>
        public Point2f Location
        {
            get => new (X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// Size of the rectangle [CvSize(Width, Height)]
        /// </summary>
        public Size2f Size
        {
            get => new (Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        /// <summary>
        /// Coordinate of the left-most rectangle corner [Point2f(X, Y)]
        /// </summary>
        public Point2f TopLeft => new (X, Y);

        /// <summary>
        /// Coordinate of the right-most rectangle corner [Point2f(X+Width, Y+Height)]
        /// </summary>
        public Point2f BottomRight => new (X + Width, Y + Height);

        #endregion

        #region Methods

        /// <summary>
        /// Determines if the specified point is contained within the rectangular region defined by this Rectangle. 
        /// </summary>
        /// <param name="x">x-coordinate of the point</param>
        /// <param name="y">y-coordinate of the point</param>
        /// <returns></returns>
        public readonly bool Contains(float x, float y)
        {
            return (X <= x && Y <= y && X + Width > x && Y + Height > y);
        }

        /// <summary>
        /// Determines if the specified point is contained within the rectangular region defined by this Rectangle. 
        /// </summary>
        /// <param name="pt">point</param>
        /// <returns></returns>
        public readonly bool Contains(Point2f pt)
        {
            return Contains(pt.X, pt.Y);
        }

        /// <summary>
        /// Determines if the specified rectangle is contained within the rectangular region defined by this Rectangle. 
        /// </summary>
        /// <param name="rect">rectangle</param>
        /// <returns></returns>
        public readonly bool Contains(Rect2f rect)
        {
            return X <= rect.X &&
                   (rect.X + rect.Width) <= (X + Width) &&
                   Y <= rect.Y &&
                   (rect.Y + rect.Height) <= (Y + Height);
        }

        /// <summary>
        /// Inflates this Rect by the specified amount. 
        /// </summary>
        /// <param name="width">The amount to inflate this Rectangle horizontally. </param>
        /// <param name="height">The amount to inflate this Rectangle vertically. </param>
        public void Inflate(float width, float height)
        {
            X -= width;
            Y -= height;
            Width += (2 * width);
            Height += (2 * height);
        }

        /// <summary>
        /// Inflates this Rect by the specified amount. 
        /// </summary>
        /// <param name="size">The amount to inflate this rectangle. </param>
        public void Inflate(Size2f size)
        {
            Inflate(size.Width, size.Height);
        }

        /// <summary>
        /// Creates and returns an inflated copy of the specified Rect2f structure.
        /// </summary>
        /// <param name="rect">The Rectangle with which to start. This rectangle is not modified. </param>
        /// <param name="x">The amount to inflate this Rectangle horizontally. </param>
        /// <param name="y">The amount to inflate this Rectangle vertically. </param>
        /// <returns></returns>
        public static Rect Inflate(Rect rect, int x, int y)
        {
            rect.Inflate(x, y);
            return rect;
        }

        /// <summary>
        /// Determines the Rect2f structure that represents the intersection of two rectangles. 
        /// </summary>
        /// <param name="a">A rectangle to intersect. </param>
        /// <param name="b">A rectangle to intersect. </param>
        /// <returns></returns>
        public static Rect2f Intersect(Rect2f a, Rect2f b)
        {
            var x1 = Math.Max(a.X, b.X);
            var x2 = Math.Min(a.X + a.Width, b.X + b.Width);
            var y1 = Math.Max(a.Y, b.Y);
            var y2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

            if (x2 >= x1 && y2 >= y1)
                return new Rect2f(x1, y1, x2 - x1, y2 - y1);
            return Empty;
        }

        /// <summary>
        /// Determines the Rect2f structure that represents the intersection of two rectangles. 
        /// </summary>
        /// <param name="rect">A rectangle to intersect. </param>
        /// <returns></returns>
        public readonly Rect2f Intersect(Rect2f rect)
        {
            return Intersect(this, rect);
        }

        /// <summary>
        /// Determines if this rectangle intersects with rect. 
        /// </summary>
        /// <param name="rect">Rectangle</param>
        /// <returns></returns>
        public readonly bool IntersectsWith(Rect2f rect)
        {
            return 
                (X < rect.X + rect.Width) &&
                (X + Width > rect.X) &&
                (Y < rect.Y + rect.Height) &&
                (Y + Height > rect.Y);
        }

        /// <summary>
        /// Gets a Rect2f structure that contains the union of two Rect2f structures. 
        /// </summary>
        /// <param name="rect">A rectangle to union. </param>
        /// <returns></returns>
        public readonly Rect2f Union(Rect2f rect)
        {
            return Union(this, rect);
        }

        /// <summary>
        /// Gets a Rect2f structure that contains the union of two Rect2f structures. 
        /// </summary>
        /// <param name="a">A rectangle to union. </param>
        /// <param name="b">A rectangle to union. </param>
        /// <returns></returns>
        public static Rect2f Union(Rect2f a, Rect2f b)
        {
            var x1 = Math.Min(a.X, b.X);
            var x2 = Math.Max(a.X + a.Width, b.X + b.Width);
            var y1 = Math.Min(a.Y, b.Y);
            var y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

            return new Rect2f(x1, y1, x2 - x1, y2 - y1);
        }
        
        /// <inheritdoc />
        public readonly bool Equals(Rect2f other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Width.Equals(other.Width) && Height.Equals(other.Height);
        }
        
        /// <inheritdoc />
        public override readonly bool Equals(object? obj)
        {
            return obj is Rect2f other && Equals(other);
        }
        
        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
#if NET48 || NETSTANDARD2_0
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Width.GetHashCode();
                hashCode = (hashCode * 397) ^ Height.GetHashCode();
                return hashCode;
            }
#else
            return HashCode.Combine(X, Y, Width, Height);
#endif
        }
        
        /// <inheritdoc />
        public override readonly string ToString()
        {
            return $"(x:{X} y:{Y} width:{Width} height:{Height})";
        }

        #endregion
    }
}
