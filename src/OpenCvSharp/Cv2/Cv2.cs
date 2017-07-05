using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    /// <summary>
    /// OpenCV Functions of C++ I/F (cv::xxx) 
    /// </summary>
    public static partial class Cv2
    {
        /// <summary>
        /// The ratio of a circle's circumference to its diameter
        /// </summary>
        public const double PI = 3.1415926535897932384626433832795;

        /// <summary>
        /// 
        /// </summary>
        public const double LOG2 = 0.69314718055994530941723212145818;

        /// <summary>
        /// 
        /// </summary>
        public const int FILLED = -1;

        /// <summary>
        /// set up P/Invoke settings only for .NET 2.0/3.0/3.5
        /// </summary>
        /// <returns></returns>
        public static void Initialize()
        {
            NativeMethods.TryPInvoke();
        }

        /// <summary>
        /// 引数がnullの時はIntPtr.Zeroに変換する
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static IntPtr ToPtr(ICvPtrHolder obj)
        {
            return obj?.CvPtr ?? IntPtr.Zero;
        }
    }
}
