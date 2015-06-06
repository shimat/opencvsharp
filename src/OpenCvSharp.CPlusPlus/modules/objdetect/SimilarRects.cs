using System;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    /// <summary>
    /// Class for grouping object candidates, detected by Cascade Classifier, HOG etc.
    /// instance of the class is to be passed to cv::partition (see cxoperations.hpp)
    /// </summary>
    public static class SimilarRects 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eps"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public static bool Compare(double eps, Rect r1, Rect r2)
        {
            double delta = eps * (Math.Min(r1.Width, r2.Width) + Math.Min(r1.Height, r2.Height)) * 0.5;
            return Math.Abs(r1.X - r2.X) <= delta &&
                   Math.Abs(r1.Y - r2.Y) <= delta &&
                   Math.Abs(r1.X + r1.Width - r2.X - r2.Width) <= delta &&
                   Math.Abs(r1.Y + r1.Height - r2.Y - r2.Height) <= delta;
        }
    }

}
