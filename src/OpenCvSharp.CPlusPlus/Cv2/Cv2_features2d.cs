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
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSupression"></param>
        public static void FAST(Mat image, out KeyPoint[] keypoints, int threshold, bool nonmaxSupression = true)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            using (StdVectorKeyPoint kp = new StdVectorKeyPoint())
            {
                CppInvoke.features2d_FAST(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0);
                keypoints = kp.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="threshold"></param>
        /// <param name="nonmaxSupression"></param>
        public static void FASTX(Mat image, out KeyPoint[] keypoints, int threshold, bool nonmaxSupression, int type)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            using (StdVectorKeyPoint kp = new StdVectorKeyPoint())
            {
                CppInvoke.features2d_FASTX(image.CvPtr, kp.CvPtr, threshold, nonmaxSupression ? 1 : 0, type);
                keypoints = kp.ToArray();
            }
        }
        #endregion
    }
}
