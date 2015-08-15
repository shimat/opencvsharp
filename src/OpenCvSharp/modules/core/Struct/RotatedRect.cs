using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RotatedRect
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
        /// 
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
        /// returns 4 vertices of the rectangle
        /// </summary>
        /// <returns></returns>
        public Point2f[] Points()
        {
            double angle = Angle*Math.PI/180.0;
            float b = (float) Math.Cos(angle)*0.5f;
            float a = (float) Math.Sin(angle)*0.5f;

            Point2f[] pt = new Point2f[4];
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
        public Rect BoundingRect()
        {
            Point2f[] pt = Points();
            Rect r = new Rect
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
}
