using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
    partial class InputArray 
    {
        /// <summary>
        /// computes the contour perimeter (closed=true) or a curve length
        /// </summary>
        /// <param name="closed"></param>
        /// <returns></returns>
        public double ArcLength(bool closed)
        {
            return Cv2.ArcLength(this, closed);
        }

        /// <summary>
        /// computes the bounding rectangle for a contour
        /// </summary>
        /// <returns></returns>
        public Rect BoundingRect()
        {
            return Cv2.BoundingRect(this);
        }

        /// <summary>
        /// computes the contour area
        /// </summary>
        /// <param name="oriented"></param>
        /// <returns></returns>
        public double ContourArea(bool oriented = false)
        {
            return Cv2.ContourArea(this, oriented);
        }

        /// <summary>
        /// computes the minimal rotated rectangle for a set of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public RotatedRect MinAreaRect(InputArray points)
        {
            return Cv2.MinAreaRect(this);
        }
        
        /// <summary>
        /// computes the minimal enclosing circle for a set of points
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public void MinEnclosingCircle(out Point2f center, out float radius)
        {
            Cv2.MinEnclosingCircle(this, out center, out radius);
        }

    }
}
