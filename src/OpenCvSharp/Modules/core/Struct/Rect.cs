using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// Stores a set of four integers that represent the location and size of a rectangle
/// </summary>
/// <param name="X">The x-coordinate of the upper-left corner of the rectangle.</param>
/// <param name="Y">The y-coordinate of the upper-left corner of the rectangle.</param>
/// <param name="Width">The width of the rectangle.</param>
/// <param name="Height">The height of the rectangle.</param>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Rect(int X, int Y, int Width, int Height)
{
    /// <summary>
    /// The x-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    public int X = X;

    /// <summary>
    /// The y-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    public int Y = Y;

    /// <summary>
    /// The width of the rectangle.
    /// </summary>
    public int Width = Width;

    /// <summary>
    /// The height of the rectangle.
    /// </summary>
    public int Height = Height;

    /// <summary>
    /// Initializes a new instance of the Rectangle class with the specified location and size.
    /// </summary>
    /// <param name="location">A Point that represents the upper-left corner of the rectangular region.</param>
    /// <param name="size">A Size that represents the width and height of the rectangular region.</param>
    public Rect(Point location, Size size)
        : this(location.X, location.Y, size.Width, size.Height)
    {
    }

    /// <summary>
    /// Creates a Rectangle structure with the specified edge locations.
    /// </summary>
    /// <param name="left">The x-coordinate of the upper-left corner of this Rectangle structure.</param>
    /// <param name="top">The y-coordinate of the upper-left corner of this Rectangle structure.</param>
    /// <param name="right">The x-coordinate of the lower-right corner of this Rectangle structure.</param>
    /// <param name="bottom">The y-coordinate of the lower-right corner of this Rectangle structure.</param>
    // ReSharper disable once InconsistentNaming
    public static Rect FromLTRB(int left, int top, int right, int bottom)
    {
        var r = new Rect
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
    public static Rect operator +(Rect rect, Point pt) => rect.Add(pt);

    /// <summary>
    /// Shifts rectangle by a certain offset
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public readonly Rect Add(Point pt)
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
    public static Rect operator -(Rect rect, Point pt)
        => rect with
        {
            X = rect.X - pt.X,
            Y = rect.Y - pt.Y
        };

    /// <summary>
    /// Shifts rectangle by a certain offset
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public readonly Rect Subtract(Point pt)
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
    public static Rect operator +(Rect rect, Size size) =>
        rect with
        {
            Width = rect.Width + size.Width,
            Height = rect.Height + size.Height
        };

    /// <summary>
    /// Expands or shrinks rectangle by a certain amount
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public readonly Rect Add(Size size) => this with
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
    public static Rect operator -(Rect rect, Size size) =>
        rect with
        {
            Width = rect.Width - size.Width,
            Height = rect.Height - size.Height
        };

    /// <summary>
    /// Expands or shrinks rectangle by a certain amount
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public readonly Rect Subtract(Size size)
        => this with
        {
            Width = Width - size.Width,
            Height = Height - size.Height
        };

    #endregion

    #region & / |

    /// <summary>
    /// Determines the Rect structure that represents the intersection of two rectangles. 
    /// </summary>
    /// <param name="a">A rectangle to intersect. </param>
    /// <param name="b">A rectangle to intersect. </param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
    public static Rect operator &(Rect a, Rect b)
        => Intersect(a, b);

    /// <summary>
    /// Gets a Rect structure that contains the union of two Rect structures. 
    /// </summary>
    /// <param name="a">A rectangle to union. </param>
    /// <param name="b">A rectangle to union. </param>
    /// <returns></returns>
    [SuppressMessage("Microsoft.Design", "CA2225: Operator overloads have named alternates")]
    public static Rect operator |(Rect a, Rect b)
        => Union(a, b);

    #endregion

    #endregion

    #region Properties

    /// <summary>
    /// Gets the y-coordinate of the top edge of this Rect structure. 
    /// </summary>
    public int Top
    {
        readonly get => Y;
        set => Y = value;
    }

    /// <summary>
    /// Gets the y-coordinate that is the sum of the Y and Height property values of this Rect structure.
    /// </summary>
    public int Bottom => Y + Height;

    /// <summary>
    /// Gets the x-coordinate of the left edge of this Rect structure. 
    /// </summary>
    public int Left
    {
        get => X;
        set => X = value;
    }

    /// <summary>
    /// Gets the x-coordinate that is the sum of X and Width property values of this Rect structure. 
    /// </summary>
    public int Right => X + Width;

    /// <summary>
    /// Coordinate of the left-most rectangle corner [Point(X, Y)]
    /// </summary>
    public Point Location
    {
        get => new(X, Y);
        set
        {
            X = value.X;
            Y = value.Y;
        }
    }

    /// <summary>
    /// Size of the rectangle [CvSize(Width, Height)]
    /// </summary>
    public Size Size
    {
        get => new(Width, Height);
        set
        {
            Width = value.Width;
            Height = value.Height;
        }
    }

    /// <summary>
    /// Coordinate of the left-most rectangle corner [Point(X, Y)]
    /// </summary>
    public Point TopLeft => new(X, Y);

    /// <summary>
    /// Coordinate of the right-most rectangle corner [Point(X+Width, Y+Height)]
    /// </summary>
    public Point BottomRight => new(X + Width, Y + Height);

    #endregion

    #region Methods

    /// <summary>
    /// Determines if the specified point is contained within the rectangular region defined by this Rectangle. 
    /// </summary>
    /// <param name="x">x-coordinate of the point</param>
    /// <param name="y">y-coordinate of the point</param>
    /// <returns></returns>
    public readonly bool Contains(int x, int y)
        => (X <= x && Y <= y && X + Width > x && Y + Height > y);

    /// <summary>
    /// Determines if the specified point is contained within the rectangular region defined by this Rectangle. 
    /// </summary>
    /// <param name="pt">point</param>
    /// <returns></returns>
    public readonly bool Contains(Point pt)
        => Contains(pt.X, pt.Y);

    /// <summary>
    /// Determines if the specified rectangle is contained within the rectangular region defined by this Rectangle. 
    /// </summary>
    /// <param name="rect">rectangle</param>
    /// <returns></returns>
    public readonly bool Contains(Rect rect) =>
        X <= rect.X &&
        (rect.X + rect.Width) <= (X + Width) &&
        Y <= rect.Y &&
        (rect.Y + rect.Height) <= (Y + Height);

    /// <summary>
    /// Inflates this Rect by the specified amount. 
    /// </summary>
    /// <param name="width">The amount to inflate this Rectangle horizontally. </param>
    /// <param name="height">The amount to inflate this Rectangle vertically. </param>
    public void Inflate(int width, int height)
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
    public void Inflate(Size size) => Inflate(size.Width, size.Height);

    /// <summary>
    /// Creates and returns an inflated copy of the specified Rect structure.
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
    /// Determines the Rect structure that represents the intersection of two rectangles. 
    /// </summary>
    /// <param name="a">A rectangle to intersect. </param>
    /// <param name="b">A rectangle to intersect. </param>
    /// <returns></returns>
    public static Rect Intersect(Rect a, Rect b)
    {
        var x1 = Math.Max(a.X, b.X);
        var x2 = Math.Min(a.X + a.Width, b.X + b.Width);
        var y1 = Math.Max(a.Y, b.Y);
        var y2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

        if (x2 >= x1 && y2 >= y1)
            return new Rect(x1, y1, x2 - x1, y2 - y1);
        return default;
    }

    /// <summary>
    /// Determines the Rect structure that represents the intersection of two rectangles. 
    /// </summary>
    /// <param name="rect">A rectangle to intersect. </param>
    /// <returns></returns>
    public readonly Rect Intersect(Rect rect) => Intersect(this, rect);

    /// <summary>
    /// Determines if this rectangle intersects with rect. 
    /// </summary>
    /// <param name="rect">Rectangle</param>
    /// <returns></returns>
    public readonly bool IntersectsWith(Rect rect) =>
        (X < rect.X + rect.Width) &&
        (X + Width > rect.X) &&
        (Y < rect.Y + rect.Height) &&
        (Y + Height > rect.Y);

    /// <summary>
    /// Gets a Rect structure that contains the union of two Rect structures. 
    /// </summary>
    /// <param name="rect">A rectangle to union. </param>
    /// <returns></returns>
    public readonly Rect Union(Rect rect) => Union(this, rect);

    /// <summary>
    /// Gets a Rect structure that contains the union of two Rect structures. 
    /// </summary>
    /// <param name="a">A rectangle to union. </param>
    /// <param name="b">A rectangle to union. </param>
    /// <returns></returns>
    public static Rect Union(Rect a, Rect b)
    {
        var x1 = Math.Min(a.X, b.X);
        var x2 = Math.Max(a.X + a.Width, b.X + b.Width);
        var y1 = Math.Min(a.Y, b.Y);
        var y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

        return new Rect(x1, y1, x2 - x1, y2 - y1);
    }

    #endregion
}
