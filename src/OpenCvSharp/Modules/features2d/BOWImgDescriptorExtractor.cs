using System;
using System.Collections.Generic;

namespace OpenCvSharp
{
    // ReSharper disable once InconsistentNaming

    /// <summary>
    /// Brute-force descriptor matcher.
    /// For each descriptor in the first set, this matcher finds the closest descriptor in the second set by trying each one.
    /// </summary>
    public class BOWImgDescriptorExtractor : DisposableCvObject
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="dextractor">Descriptor extractor that is used to compute descriptors for an input image and its keypoints.</param>
        /// <param name="dmatcher">Descriptor matcher that is used to find the nearest word of the trained vocabulary for each keypoint descriptor of the image.</param>
        public BOWImgDescriptorExtractor(Feature2D dextractor, DescriptorMatcher dmatcher)
        {
            if (dextractor == null)
                throw new ArgumentNullException(nameof(dextractor));
            if (dmatcher == null)
                throw new ArgumentNullException(nameof(dmatcher));

            ptr = NativeMethods.features2d_BOWImgDescriptorExtractor_new1_RawPtr(dextractor.CvPtr, dmatcher.CvPtr);

            GC.KeepAlive(dextractor);
            GC.KeepAlive(dmatcher);
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="dmatcher">Descriptor matcher that is used to find the nearest word of the trained vocabulary for each keypoint descriptor of the image.</param>
        public BOWImgDescriptorExtractor(DescriptorMatcher dmatcher)
        {
            if (dmatcher == null)
                throw new ArgumentNullException(nameof(dmatcher));

            ptr = NativeMethods.features2d_BOWImgDescriptorExtractor_new2_RawPtr(dmatcher.CvPtr);
            GC.KeepAlive(dmatcher);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.features2d_BOWImgDescriptorExtractor_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// Sets a visual vocabulary.
        /// </summary>
        /// <param name="vocabulary">Vocabulary (can be trained using the inheritor of BOWTrainer ). 
        /// Each row of the vocabulary is a visual word(cluster center).</param>
        public void SetVocabulary(Mat vocabulary)
        {
            ThrowIfDisposed();
            if (vocabulary == null)
                throw new ArgumentNullException(nameof(vocabulary));
            NativeMethods.features2d_BOWImgDescriptorExtractor_setVocabulary(ptr, vocabulary.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(vocabulary);
        }

        /// <summary>
        /// Returns the set vocabulary.
        /// </summary>
        /// <returns></returns>
        public Mat GetVocabulary()
        {
            ThrowIfDisposed();
            IntPtr p = NativeMethods.features2d_BOWImgDescriptorExtractor_getVocabulary(ptr);
            GC.KeepAlive(this);
            return new Mat(p);
        }

        /// <summary>
        /// Computes an image descriptor using the set visual vocabulary.
        /// </summary>
        /// <param name="image">Image, for which the descriptor is computed.</param>
        /// <param name="keypoints">Keypoints detected in the input image.</param>
        /// <param name="imgDescriptor">Computed output image descriptor.</param>
        /// <param name="pointIdxsOfClusters">pointIdxsOfClusters Indices of keypoints that belong to the cluster. 
        /// This means that pointIdxsOfClusters[i] are keypoint indices that belong to the i -th cluster(word of vocabulary) returned if it is non-zero.</param>
        /// <param name="descriptors">Descriptors of the image keypoints that are returned if they are non-zero.</param>
        public void Compute(InputArray image, ref KeyPoint[] keypoints, OutputArray imgDescriptor,
            out int[][] pointIdxsOfClusters, Mat descriptors = null)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (imgDescriptor == null)
                throw new ArgumentNullException(nameof(imgDescriptor));

            using (var keypointsVec = new VectorOfKeyPoint(keypoints))
            using (var pointIdxsOfClustersVec = new VectorOfVectorInt())
            {
                NativeMethods.features2d_BOWImgDescriptorExtractor_compute11(ptr, image.CvPtr, keypointsVec.CvPtr, 
                    imgDescriptor.CvPtr, pointIdxsOfClustersVec.CvPtr, Cv2.ToPtr(descriptors));
                keypoints = keypointsVec.ToArray();
                pointIdxsOfClusters = pointIdxsOfClustersVec.ToArray();
            }
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(imgDescriptor);
            GC.KeepAlive(descriptors);
        }

        /// <summary>
        /// Computes an image descriptor using the set visual vocabulary.
        /// </summary>
        /// <param name="keypointDescriptors">Computed descriptors to match with vocabulary.</param>
        /// <param name="imgDescriptor">Computed output image descriptor.</param>
        /// <param name="pointIdxsOfClusters">Indices of keypoints that belong to the cluster. 
        /// This means that pointIdxsOfClusters[i] are keypoint indices that belong to the i -th cluster(word of vocabulary) returned if it is non-zero.</param>
        public void Compute(InputArray keypointDescriptors, OutputArray imgDescriptor, out int[][] pointIdxsOfClusters)
        {
            ThrowIfDisposed();
            if (keypointDescriptors == null)
                throw new ArgumentNullException(nameof(keypointDescriptors));
            if (imgDescriptor == null)
                throw new ArgumentNullException(nameof(imgDescriptor));

            using (var pointIdxsOfClustersVec = new VectorOfVectorInt())
            {
                NativeMethods.features2d_BOWImgDescriptorExtractor_compute12(
                    ptr, keypointDescriptors.CvPtr, imgDescriptor.CvPtr, pointIdxsOfClustersVec.CvPtr);
                pointIdxsOfClusters = pointIdxsOfClustersVec.ToArray();
            }
            GC.KeepAlive(this);
            GC.KeepAlive(keypointDescriptors);
            GC.KeepAlive(imgDescriptor);
        }

        /// <summary>
        /// Computes an image descriptor using the set visual vocabulary.
        /// </summary>
        /// <param name="image">Image, for which the descriptor is computed.</param>
        /// <param name="keypoints">Keypoints detected in the input image.</param>
        /// <param name="imgDescriptor">Computed output image descriptor.</param>
        public void Compute2(Mat image, ref KeyPoint[] keypoints, Mat imgDescriptor)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (imgDescriptor == null)
                throw new ArgumentNullException(nameof(imgDescriptor));

            using (var keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                NativeMethods.features2d_BOWImgDescriptorExtractor_compute2(
                    ptr, image.CvPtr, keypointsVec.CvPtr, imgDescriptor.CvPtr);
                keypoints = keypointsVec.ToArray();
            }
            GC.KeepAlive(this);
            GC.KeepAlive(image);
            GC.KeepAlive(imgDescriptor);
        }

        /// <summary>
        /// Returns an image descriptor size if the vocabulary is set. Otherwise, it returns 0.
        /// </summary>
        /// <returns></returns>
        public int DescriptorSize()
        {
            ThrowIfDisposed();
            var res = NativeMethods.features2d_BOWImgDescriptorExtractor_descriptorSize(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// Returns an image descriptor type.
        /// </summary>
        /// <returns></returns>
        public int DescriptorType()
        {
            ThrowIfDisposed();
            var res = NativeMethods.features2d_BOWImgDescriptorExtractor_descriptorType(ptr);
            GC.KeepAlive(this);
            return res;
        }
    }
}
