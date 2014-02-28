using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Cv2
    {
        #region FAST/FASTX
        /// <summary>
        /// detects corners using FAST algorithm by E. Rosten
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSupression"></param>
// ReSharper disable InconsistentNaming
        public static void FAST(InputArray image, out KeyPoint[] keypoints, int threshold, bool nonmaxSupression = true)
// ReSharper restore InconsistentNaming
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();
            using (StdVectorKeyPoint kp = new StdVectorKeyPoint())
            {
                CppInvoke.features2d_FAST(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0);
                keypoints = kp.ToArray();
            }
        }

        /// <summary>
        /// detects corners using FAST algorithm by E. Rosten
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSupression"></param>
        /// <param name="type"></param>
// ReSharper disable InconsistentNaming
        public static void FASTX(InputArray image, out KeyPoint[] keypoints, int threshold, bool nonmaxSupression, int type)
// ReSharper restore InconsistentNaming
        {
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();
            using (StdVectorKeyPoint kp = new StdVectorKeyPoint())
            {
                CppInvoke.features2d_FASTX(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0, type);
                keypoints = kp.ToArray();
            }
        }
        #endregion
    }
}
