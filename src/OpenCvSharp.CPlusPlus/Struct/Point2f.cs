using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Point2f
    {
        /// <summary>
        /// 
        /// </summary>
        public float X;
        /// <summary>
        /// 
        /// </summary>
        public float Y;
        /// <summary>
        /// 
        /// </summary>
        public const int SizeOf = sizeof(float) + sizeof(float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point2f(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static implicit operator CvPoint2D32f(Point2f self)
        {
            return new CvPoint2D32f(self.X, self.Y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static implicit operator Point2f(CvPoint2D32f point)
        {
            return new Point2f(point.X, point.Y);
        }
    }
}
