using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Abstract base class for computing descriptors for image keypoints.
    /// </summary>
    public interface IDescriptorExtractor
    {
        /// <summary>
        /// Compute the descriptors for a set of keypoints in an image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors">Copmputed descriptors. Row i is the descriptor for keypoint i.</param>
        /// <returns>The input keypoints. Keypoints for which a descriptor cannot be computed are removed.</returns>
        void Compute(Mat image, ref KeyPoint[] keypoints, Mat descriptors);

        /// <summary>
        /// Compute the descriptors for a keypoints collection detected in image collection.
        /// </summary>
        /// <param name="images">Image collection.</param>
        /// <param name="keypoints">Input keypoints collection. keypoints[i] is keypoints detected in images[i].
        /// Keypoints for which a descriptor cannot be computed are removed.</param>
        /// <param name="descriptors">Descriptor collection. descriptors[i] are descriptors computed for set keypoints[i].</param>
        void Compute(IEnumerable<Mat> images, ref KeyPoint[][] keypoints, IEnumerable<Mat> descriptors);

        /// <summary>
        /// Return true if detector object is empty
        /// </summary>
        /// <returns></returns>
        bool Empty();
    }
}
