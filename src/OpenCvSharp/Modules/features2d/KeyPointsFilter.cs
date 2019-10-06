using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// A class filters a vector of keypoints.
    /// </summary>
    public static class KeyPointsFilter
    {
        /// <summary>
        /// Remove keypoints within borderPixels of an image edge.
        /// </summary>
        /// <param name="keypoints"></param>
        /// <param name="imageSize"></param>
        /// <param name="borderSize"></param>
        /// <returns></returns>
        public static KeyPoint[] RunByImageBorder(IEnumerable<KeyPoint> keypoints, Size imageSize, int borderSize)
        {
            if (keypoints == null) 
                throw new ArgumentNullException(nameof(keypoints));

            using (var keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                NativeMethods.features2d_KeyPointsFilter_runByImageBorder(
                    keypointsVec.CvPtr, imageSize, borderSize);
                return keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// Remove keypoints of sizes out of range.
        /// </summary>
        /// <param name="keypoints"></param>
        /// <param name="minSize"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public static KeyPoint[] RunByKeypointSize(IEnumerable<KeyPoint> keypoints, float minSize,
            float maxSize = float.MaxValue)
        {
            if (keypoints == null)
                throw new ArgumentNullException(nameof(keypoints));

            using (var keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                NativeMethods.features2d_KeyPointsFilter_runByKeypointSize(
                    keypointsVec.CvPtr, minSize, maxSize);
                return keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// Remove keypoints from some image by mask for pixels of this image.
        /// </summary>
        /// <param name="keypoints"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static KeyPoint[] RunByPixelsMask(IEnumerable<KeyPoint> keypoints, Mat mask)
        {
            if (keypoints == null)
                throw new ArgumentNullException(nameof(keypoints));
            if (mask == null) 
                throw new ArgumentNullException(nameof(mask));
            mask.ThrowIfDisposed();

            using (var keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                NativeMethods.features2d_KeyPointsFilter_runByPixelsMask(
                    keypointsVec.CvPtr, mask.CvPtr);
                GC.KeepAlive(mask);
                return keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// Remove duplicated keypoints.
        /// </summary>
        /// <param name="keypoints"></param>
        /// <returns></returns>
        public static KeyPoint[] RemoveDuplicated(IEnumerable<KeyPoint> keypoints)
        {
            if (keypoints == null)
                throw new ArgumentNullException(nameof(keypoints));

            using (var keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                NativeMethods.features2d_KeyPointsFilter_removeDuplicated(keypointsVec.CvPtr);
                return keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// Retain the specified number of the best keypoints (according to the response)
        /// </summary>
        /// <param name="keypoints"></param>
        /// <param name="npoints"></param>
        /// <returns></returns>
        public static KeyPoint[] RetainBest(IEnumerable<KeyPoint> keypoints, int npoints)
        {
            if (keypoints == null)
                throw new ArgumentNullException(nameof(keypoints));

            using (var keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                NativeMethods.features2d_KeyPointsFilter_retainBest(
                    keypointsVec.CvPtr, npoints);
                return keypointsVec.ToArray();
            }
        }
    }
}
