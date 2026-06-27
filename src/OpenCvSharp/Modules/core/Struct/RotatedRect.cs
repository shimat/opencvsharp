using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <summary>
/// The class represents rotated (i.e. not up-right) rectangles on a plane.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public record struct RotatedRect
{
    /// <summary>
    /// the rectangle mass center
    /// </summary>
    public Point2f Center;

    /// <summary>
    /// width and height of the rectangle
    /// </summary>
    public Size2f Size;

    /// <summary>
    /// the rotation angle. When the angle is 0, 90, 180, 270 etc., the rectangle becomes an up-right rectangle.
    /// </summary>
    public float Angle;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="center"></param>
    /// <param name="size"></param>
    /// <param name="angle"></param>
    public RotatedRect(Point2f center, Size2f size, float angle)
    {
        Center = center;
        Size = size;
        Angle = angle;
    }

    /// <summary>
    /// Any 3 end points of the RotatedRect. They must be given in order (either clockwise or anticlockwise).
    /// </summary>
    public RotatedRect(Point2f point1, Point2f point2, Point2f point3)
    { // https://github.com/opencv/opencv/blob/6ad77b23193bdf7e40db83e6077789284ac08781/modules/core/src/types.cpp#LL147C20-L147C20
        var center = (point1 + point3) * 0.5;
        var vecs = new Vec2f[2];
        vecs[0] = (point1 - point2).ToVec2f();
        vecs[1] = (point2 - point3).ToVec2f();
        var x = Math.Max(Norm(point1), Math.Max(Norm(point2), Norm(point3)));
        var a = Math.Min(Norm(vecs[0]), Norm(vecs[1]));

        const float fltEpsilon = 1.19209290e-7f; // https://github.com/opencv/opencv/blob/6ad77b23193bdf7e40db83e6077789284ac08781/modules/dnn/src/math_utils.hpp#L39

        // check that given sides are perpendicular
        Debug.Assert(
            Math.Abs(Ddot(vecs[0], vecs[1])) * a <= fltEpsilon * 9 * x * (Norm(vecs[0]) * Norm(vecs[1])));

        // wd_i stores which vector (0,1) or (1,2) will make the width
        // One of them will definitely have slope within -1 to 1
        var wdI = 0;
        if (Math.Abs(vecs[1][1]) < Math.Abs(vecs[1][0]))
        {
            wdI = 1;
        }
        var htI = (wdI + 1) % 2;

        var angle = Math.Atan(vecs[wdI][1] / vecs[wdI][0]) * 180.0f / (float)Cv2.PI;
        var width = (float)Norm(vecs[wdI]);
        var height = (float)Norm(vecs[htI]);

        Center = center;
        Size = new(width, height);
        Angle = (float)angle;

        static double Ddot(Vec2f a, Vec2f b)
        { // https://github.com/opencv/opencv/blob/0052d46b8e33c7bfe0e1450e4bff28b88f455570/modules/core/include/opencv2/core/matx.hpp#L741
            var s = 0d;
            for (var i = 0; i < 2; i++)
            {
                s += (double)a[i] * b[i];
            }
            return s;
        }

        // core/types.hpp
        /*
        template<typename _Tp> static inline
        double norm(const Point_<_Tp>& pt)
        {
            return std::sqrt((double)pt.x*pt.x + (double)pt.y*pt.y);
        }
        */
        static double Norm(Point2f p)
        {
            return Math.Sqrt((double)p.X * p.X + (double)p.Y * p.Y);
        }
    }

    /// <summary>
    /// Any 3 end points of the RotatedRect. They must be given in order (either clockwise or anticlockwise).
    /// </summary>
    public static RotatedRect FromThreeVertexPoints(Point2f point1, Point2f point2, Point2f point3) 
        => NativeMethods.core_RotatedRect_byThreeVertexPoints(point1, point2, point3);

    /// <summary>
    /// returns 4 vertices of the rectangle
    /// </summary>
    /// <returns></returns>
    public readonly Point2f[] Points()
    {
        var angle = Angle*Math.PI/180.0;
        var b = (float) Math.Cos(angle)*0.5f;
        var a = (float) Math.Sin(angle)*0.5f;

        var pt = new Point2f[4];
        pt[0].X = Center.X - a*Size.Height - b*Size.Width;
        pt[0].Y = Center.Y + b*Size.Height - a*Size.Width;
        pt[1].X = Center.X + a*Size.Height - b*Size.Width;
        pt[1].Y = Center.Y - b*Size.Height - a*Size.Width;
        pt[2].X = 2*Center.X - pt[0].X;
        pt[2].Y = 2*Center.Y - pt[0].Y;
        pt[3].X = 2*Center.X - pt[1].X;
        pt[3].Y = 2*Center.Y - pt[1].Y;
        return pt;
    }

    /// <summary>
    /// returns the minimal up-right rectangle containing the rotated rectangle
    /// </summary>
    /// <returns></returns>
    public readonly Rect BoundingRect()
    {
        var pt = Points();
        var r = new Rect
        {
            X = (int)Math.Floor(Math.Min(Math.Min(Math.Min(pt[0].X, pt[1].X), pt[2].X), pt[3].X)),
            Y = (int)Math.Floor(Math.Min(Math.Min(Math.Min(pt[0].Y, pt[1].Y), pt[2].Y), pt[3].Y)),
            Width = (int)Math.Ceiling(Math.Max(Math.Max(Math.Max(pt[0].X, pt[1].X), pt[2].X), pt[3].X)),
            Height = (int)Math.Ceiling(Math.Max(Math.Max(Math.Max(pt[0].Y, pt[1].Y), pt[2].Y), pt[3].Y))
        };
        r.Width -= r.X - 1;
        r.Height -= r.Y - 1;
        return r;
    }
}
