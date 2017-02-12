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
        /// 引数がnullの時はIntPtr.Zeroに変換する
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static IntPtr ToPtr(ICvPtrHolder obj)
        {
            return obj?.CvPtr ?? IntPtr.Zero;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        internal static void CopyToList<T>(IEnumerable<T> src, IList<T> dst)
        {
            T[] srcArray = EnumerableEx.ToArray(src);

            T[] dstArray = dst as T[];
            List<T> dstList = dst as List<T>;
            if (dstArray != null)
            {
                Array.Resize(ref dstArray, srcArray.Length);
                Array.ConstrainedCopy(srcArray, 0, dstArray, 0, srcArray.Length);
            }
            else if (dstList != null)
            {
                dstList.Clear();
                dstList.AddRange(dstList);
            }
            else
            {
                dst.Clear();
                foreach (var k in dst)
                {
                    dst.Add(k);
                }
            }
        }
    }
}
