using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class DescriptorExtractor : Algorithm, IDescriptorExtractor
    {
        private bool disposed;
        /// <summary>
        /// cv::Ptr&lt;DescriptorExtractor&gt;
        /// </summary>
        private Ptr<DescriptorExtractor> extractorPtr;

        /// <summary>
        /// 
        /// </summary>
        internal DescriptorExtractor()
        {
            extractorPtr = null;
            ptr = IntPtr.Zero;
        }
        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static DescriptorExtractor FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid DescriptorExtractor pointer");

            var ptrObj = new Ptr<DescriptorExtractor>(ptr);
            var extractor = new DescriptorExtractor
                {
                    extractorPtr = ptrObj,
                    ptr = ptrObj.Obj
                };
            return extractor;
        }
        /// <summary>
        /// Creates instance from raw T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static DescriptorExtractor FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid DescriptorExtractor pointer");
            var extractor = new DescriptorExtractor
                {
                    extractorPtr = null,
                    ptr = ptr
                };
            return extractor;
        }

        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    // releases managed resources
                    if (disposing)
                    {
                    }
                    // releases unmanaged resources
                    if (IsEnabledDispose)
                    {
                        if (extractorPtr != null)
                            extractorPtr.Dispose();
                        extractorPtr = null;
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        /// <summary>
        /// Compute the descriptors for a set of keypoints in an image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="keypoints">The input keypoints. Keypoints for which a descriptor cannot be computed are removed.</param>
        /// <param name="descriptors">Copmputed descriptors. Row i is the descriptor for keypoint i.</param>param>
        public virtual void Compute(Mat image, ref KeyPoint[] keypoints, Mat descriptors)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");

            using (VectorOfKeyPoint keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                NativeMethods.features2d_DescriptorExtractor_compute1(
                    ptr, image.CvPtr, keypointsVec.CvPtr, descriptors.CvPtr);
                keypoints = keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// Compute the descriptors for a keypoints collection detected in image collection.
        /// </summary>
        /// <param name="images">Image collection.</param>
        /// <param name="keypoints">Input keypoints collection. keypoints[i] is keypoints detected in images[i].
        /// Keypoints for which a descriptor cannot be computed are removed.</param>
        /// <param name="descriptors">Descriptor collection. descriptors[i] are descriptors computed for set keypoints[i].</param>
        public virtual void Compute(IEnumerable<Mat> images, ref KeyPoint[][] keypoints, IEnumerable<Mat> descriptors)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);
            IntPtr[] descriptorsPtrs = EnumerableEx.SelectPtrs(descriptors);

            using (var keypointsVec = new VectorOfVectorKeyPoint(keypoints))
            {
                NativeMethods.features2d_DescriptorExtractor_compute2(
                    ptr, imagesPtrs, imagesPtrs.Length, keypointsVec.CvPtr, 
                    descriptorsPtrs, descriptorsPtrs.Length);

                keypoints = keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// Return true if detector object is empty
        /// </summary>
        /// <returns></returns>
        public virtual bool Empty()
        {
            return NativeMethods.features2d_DescriptorExtractor_empty(ptr) != 0;
        }

        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get { return NativeMethods.features2d_DescriptorExtractor_info(ptr); }
        }

        /// <summary>
        /// Create feature detector by detector name.
        /// </summary>
        /// <param name="descriptorExtractorType">
        /// </param>
        /// <returns></returns>
        public static DescriptorExtractor Create(string descriptorExtractorType)
        {
            if (String.IsNullOrEmpty(descriptorExtractorType))
                throw new ArgumentNullException("descriptorExtractorType");

            // gets cv::Ptr<DescriptorExtractor>
            try
            {
                IntPtr ptr = NativeMethods.features2d_DescriptorExtractor_create(descriptorExtractorType);
                DescriptorExtractor detector = FromPtr(ptr);
                return detector;
            }
            catch (OpenCvSharpException)
            {
                throw new OpenCvSharpException(
                    "DescriptorExtractor name '{0}' is not valid.", descriptorExtractorType);
            }
        }
    }
}
