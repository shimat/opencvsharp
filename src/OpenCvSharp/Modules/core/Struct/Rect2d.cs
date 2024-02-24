using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// Stores a set of four double-precision floating-point numbers that represent the location and size of a rectangle
/// </summary>
/// <param name="X">The x-coordinate of the upper-left corner of the rectangle.</param>
/// <param name="Y">The y-coordinate of the upper-left corner of the rectangle.</param>
/// <param name="Width">The width of the rectangle.</param>
/// <param name="Height">The height of the rectangle.</param>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Rect2d(double X, double Y, double Width, double Height)
{
    /// <summary>
    /// The x-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    public double X = X;

    /// <summary>
    /// The y-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    public double Y = Y;

    /// <summary>
    /// The width of the rectangle.
    /// </summary>
    public double Width = Width;

    /// <summary>
    /// The height of the rectangle.
    /// </summary>
    public double Height = Height;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="location"></param>
    /// <param name="size"></param>
    public Rect2d(Point2d location, Size2d size)
        : this(location.X, location.Y, size.Width, size.Height)
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
    public static Rect2d FromLTRB(double left, double top, double right, double bottom)
    {
        var r = new Rect2d
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

    #region + / -

    /// <summary>
    /// Shifts rectangle by a certain offset
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="pt"></param>
    /// <returns></returns>
    public static Rect2d operator +(Rect2d rect, Point2d pt)
        => rect.Add(pt);

    /// <summary>
    /// Shifts rectangle by a certain offset
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public readonly Rect2d Add(Point2d pt)
        => this with
        {
            X = X + pt.X,
            Y = Y + pt.Y
        };

    /// <summary>
    /// Shifts rectangle by a certain offset
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="pt"></param>
    /// <returns></returns>
    public static Rect2d operator -(Rect2d rect, Point2d pt)
        => rect.Subtract(pt);

    /// <summary>
    /// Shifts rectangle by a certain offset
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public readonly Rect2d Subtract(Point2d pt)
        => this with
        {
            X = X - pt.X,
            Y = Y - pt.Y
        };

    /// <summary>
    /// Expands or shrinks rectangle by a certain amount
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static Rect2d operator +(Rect2d rect, Size2d size)
        => rect with
        {
            Width = rect.Width + size.Width,
            Height = rect.Height + size.Height
        };

    /// <summary>
    /// Shifts rectangle by a certain offset
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public readonly Rect2d Add(Size2d size)
        => this with
        {
            Width = Width + size.Width,
            Height = Height + size.Height
        };

    /// <summary>
    /// Expands or shrinks rectangle by a certain amount
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static Rect2d operator -(Rect2d rect, Size2d size)
        => rect with
        {
            Width = rect.Width - size.Width,
            Height = rect.Height - size.Height
        };

    /// <summary>
    /// Shifts rectangle by a certain offset
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public readonly Rect2d Subtract(Size2d size)
        => this with
        {
            Width = Width - size.Width,
            Height = Height - size.Height
        };

    #endregion

    #region & / |

    /// <summary>
    /// Determines the Rect2d structure that represents the intersection of two rectangles. 
    /// </summary>
    /// <param name="a">A rectangle to intersect. </param>
    /// <param name="b">A rectangle to intersect. </param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
    public static Rect2d operator &(Rect2d a, Rect2d b)
        => Intersect(a, b);

    /// <summary>
    /// Gets a Rect2d structure that contains the union of two Rect2d structures. 
    /// </summary>
    /// <param name="a">A rectangle to union. </param>
    /// <param name="b">A rectangle to union. </param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
    public static Rect2d operator |(Rect2d a, Rect2d b)
        => Union(a, b);

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets the y-coordinate of the top edge of this Rect2d structure. 
    /// </summary>
    public double Top
    {
        readonly get => Y;
        set => Y = value;
    }

    /// <summary>
    /// Gets the y-coordinate that is the sum of the Y and Height property values of this Rect2d structure.
    /// </summary>
    public readonly double Bottom => Y + Height;

    /// <summary>
    /// Gets the x-coordinate of the left edge of this Rect2d structure. 
    /// </summary>
    public double Left
    {
        readonly get => X;
        set => X = value;
    }

    /// <summary>
    /// Gets the x-coordinate that is the sum of X and Width property values of this Rect2d structure. 
    /// </summary>
    public readonly double Right => X + Width;

    /// <summary>
    /// Coordinate of the left-most rectangle corner [Point2d(X, Y)]
    /// </summary>
    public Point2d Location
    {
        readonly get => new(X, Y);
        set
        {
            X = value.X;
            Y = value.Y;
        }
    }

    /// <summary>
    /// Size of the rectangle [CvSize(Width, Height)]
    /// </summary>
    public Size2d Size
    {
        readonly get => new(Width, Height);
        set
        {
            Width = value.Width;
            Height = value.Height;
        }
    }

    /// <summary>
    /// Coordinate of the left-most rectangle corner [Point2d(X, Y)]
    /// </summary>
    public readonly Point2d TopLeft => new(X, Y);

    /// <summary>
    /// Coordinate of the right-most rectangle corner [Point2d(X+Width, Y+Height)]
    /// </summary>
    public readonly Point2d BottomRight => new(X + Width, Y + Height);

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly Rect ToRect()
        => new((int)X, (int)Y, (int)Width, (int)Height);

    /// <summary>
    /// Determines if the specified point is contained within the rectangular region defined by this Rectangle. 
    /// </summary>
    /// <param name="x">x-coordinate of the point</param>
    /// <param name="y">y-coordinate of the point</param>
    /// <returns></returns>
    public readonly bool Contains(double x, double y)
        => (X <= x && Y <= y && X + Width > x && Y + Height > y);

    /// <summary>
    /// Determines if the specified point is contained within the rectangular region defined by this Rectangle. 
    /// </summary>
    /// <param name="pt">point</param>
    /// <returns></returns>
    public readonly bool Contains(Point2d pt)
        => Contains(pt.X, pt.Y);

    /// <summary>
    /// Determines if the specified rectangle is contained within the rectangular region defined by this Rectangle. 
    /// </summary>
    /// <param name="rect">rectangle</param>
    /// <returns></returns>
    public readonly bool Contains(Rect2d rect) =>
        X <= rect.X &&
        (rect.X + rect.Width) <= (X + Width) &&
        Y <= rect.Y &&
        (rect.Y + rect.Height) <= (Y + Height);

    /// <summary>
    /// Inflates this Rect by the specified amount. 
    /// </summary>
    /// <param name="width">The amount to inflate this Rectangle horizontally. </param>
    /// <param name="height">The amount to inflate this Rectangle vertically. </param>
    public void Inflate(double width, double height)
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
    public void Inflate(Size2d size) => Inflate(size.Width, size.Height);

    /// <summary>
    /// Creates and returns an inflated copy of the specified Rect2d structure.
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
    /// Determines the Rect2d structure that represents the intersection of two rectangles. 
    /// </summary>
    /// <param name="a">A rectangle to intersect. </param>
    /// <param name="b">A rectangle to intersect. </param>
    /// <returns></returns>
    public static Rect2d Intersect(Rect2d a, Rect2d b)
    {
        var x1 = Math.Max(a.X, b.X);
        var x2 = Math.Min(a.X + a.Width, b.X + b.Width);
        var y1 = Math.Max(a.Y, b.Y);
        var y2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

        if (x2 >= x1 && y2 >= y1)
            return new Rect2d(x1, y1, x2 - x1, y2 - y1);
        return default;
    }

    /// <summary>
    /// Determines the Rect2d structure that represents the intersection of two rectangles. 
    /// </summary>
    /// <param name="rect">A rectangle to intersect. </param>
    /// <returns></returns>
    public readonly Rect2d Intersect(Rect2d rect) => Intersect(this, rect);

    /// <summary>
    /// Determines if this rectangle intersects with rect. 
    /// </summary>
    /// <param name="rect">Rectangle</param>
    /// <returns></returns>
    public readonly bool IntersectsWith(Rect2d rect) =>
        (X < rect.X + rect.Width) &&
        (X + Width > rect.X) &&
        (Y < rect.Y + rect.Height) &&
        (Y + Height > rect.Y);

    /// <summary>
    /// Gets a Rect2d structure that contains the union of two Rect2d structures. 
    /// </summary>
    /// <param name="rect">A rectangle to union. </param>
    /// <returns></returns>
    public readonly Rect2d Union(Rect2d rect) => Union(this, rect);

    /// <summary>
    /// Gets a Rect2d structure that contains the union of two Rect2d structures. 
    /// </summary>
    /// <param name="a">A rectangle to union. </param>
    /// <param name="b">A rectangle to union. </param>
    /// <returns></returns>
    public static Rect2d Union(Rect2d a, Rect2d b)
    {
        var x1 = Math.Min(a.X, b.X);
        var x2 = Math.Max(a.X + a.Width, b.X + b.Width);
        var y1 = Math.Min(a.Y, b.Y);
        var y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

        return new Rect2d(x1, y1, x2 - x1, y2 - y1);
    }

    #endregion
}
