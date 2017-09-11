using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    /// <summary>
    /// Abstract base class for 2D image feature detectors and descriptor extractors
    /// </summary>
    public class Feature2D : Algorithm
    {
        /// <summary>
        /// cv::Ptr&lt;T&gt;
        /// </summary>
        private Ptr ptrObj;

        //internal virtual IntPtr PtrObj => ptrObj.CvPtr;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        internal Feature2D()
        {
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static Feature2D FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<Feature2D> pointer");
            var ptrObj = new Ptr(ptr);
            var detector = new Feature2D
            {
                ptrObj = ptrObj,
                ptr = ptrObj.Get()
            };
            return detector;
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            ptrObj?.Dispose();
            ptrObj = null;
            base.DisposeManaged();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int DescriptorSize
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_Feature2D_descriptorSize(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int DescriptorType
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_Feature2D_descriptorType(ptr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int DefaultNorm
        {
            get
            {
                ThrowIfDisposed();
                return NativeMethods.features2d_Feature2D_defaultNorm(ptr);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Return true if detector object is empty
        /// </summary>
        /// <returns></returns>
        public new virtual bool Empty()
        {
            ThrowIfDisposed();
            return NativeMethods.features2d_Feature2D_empty(ptr) != 0;
        }

        /// <summary>
        /// Detect keypoints in an image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="mask">Mask specifying where to look for keypoints (optional). 
        /// Must be a char matrix with non-zero values in the region of interest.</param>
        /// <returns>The detected keypoints.</returns>
        public KeyPoint[] Detect(Mat image, Mat mask = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            ThrowIfDisposed();

            image.ThrowIfDisposed();
            try
            {
                using (var keypoints = new VectorOfKeyPoint())
                {
                    NativeMethods.features2d_Feature2D_detect_Mat1(ptr, image.CvPtr, keypoints.CvPtr, Cv2.ToPtr(mask));
                    return keypoints.ToArray();
                }
            }
            finally
            {
                GC.KeepAlive(image);
                GC.KeepAlive(mask);
            }
        }

        /// <summary>
        /// Detect keypoints in an image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="mask">Mask specifying where to look for keypoints (optional). 
        /// Must be a char matrix with non-zero values in the region of interest.</param>
        /// <returns>The detected keypoints.</returns>
        public KeyPoint[] Detect(InputArray image, Mat mask = null)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            ThrowIfDisposed();

            image.ThrowIfDisposed();
            try
            {
                using (var keypoints = new VectorOfKeyPoint())
                {
                    NativeMethods.features2d_Feature2D_detect_InputArray(ptr, image.CvPtr, keypoints.CvPtr,
                        Cv2.ToPtr(mask));
                    return keypoints.ToArray();
                }
            }
            finally
            {
                GC.KeepAlive(image);
                GC.KeepAlive(mask);
            }
        }

        /// <summary>
        /// Detect keypoints in an image set.
        /// </summary>
        /// <param name="images">Image collection.</param>
        /// <param name="masks">Masks for image set. masks[i] is a mask for images[i].</param>
        /// <returns>Collection of keypoints detected in an input images. keypoints[i] is a set of keypoints detected in an images[i].</returns>
        public KeyPoint[][] Detect(IEnumerable<Mat> images, IEnumerable<Mat> masks = null)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            ThrowIfDisposed();

            Mat[] imagesArray = EnumerableEx.ToArray(images);
            IntPtr[] imagesPtr = new IntPtr[imagesArray.Length];
            for (int i = 0; i < imagesArray.Length; i++)
                imagesPtr[i] = imagesArray[i].CvPtr;

            using (var keypoints = new VectorOfVectorKeyPoint())
            {
                if (masks == null)
                {
                    NativeMethods.features2d_Feature2D_detect_Mat2(
                        ptr, imagesPtr, imagesArray.Length, keypoints.CvPtr, null);
                }
                else
                {
                    IntPtr[] masksPtr = EnumerableEx.SelectPtrs(masks);
                    if (masksPtr.Length != imagesArray.Length)
                        throw new ArgumentException("masks.Length != images.Length");
                    NativeMethods.features2d_Feature2D_detect_Mat2(
                        ptr, imagesPtr, imagesArray.Length, keypoints.CvPtr, masksPtr);
                }
                return keypoints.ToArray();
            }
        }

        /// <summary>
        /// Compute the descriptors for a set of keypoints in an image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="keypoints">The input keypoints. Keypoints for which a descriptor cannot be computed are removed.</param>
        /// <param name="descriptors">Copmputed descriptors. Row i is the descriptor for keypoint i.</param>param>
        public virtual void Compute(InputArray image, ref KeyPoint[] keypoints, OutputArray descriptors)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            ThrowIfDisposed();

            using (var keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                NativeMethods.features2d_Feature2D_compute1(ptr, image.CvPtr, keypointsVec.CvPtr, descriptors.CvPtr);
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
            ThrowIfDisposed();
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (descriptors == null)
                throw new ArgumentNullException(nameof(descriptors));

            IntPtr[] imagesPtrs = EnumerableEx.SelectPtrs(images);
            IntPtr[] descriptorsPtrs = EnumerableEx.SelectPtrs(descriptors);

            using (var keypointsVec = new VectorOfVectorKeyPoint(keypoints))
            {
                NativeMethods.features2d_Feature2D_compute2(
                    ptr, imagesPtrs, imagesPtrs.Length, keypointsVec.CvPtr,
                    descriptorsPtrs, descriptorsPtrs.Length);

                keypoints = keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// Detects keypoints and computes the descriptors
        /// </summary>
        /// <param name="image"></param>
        /// <param name="mask"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
        /// <param name="useProvidedKeypoints"></param>
        public virtual void DetectAndCompute(
            InputArray image,
            InputArray mask,
            out KeyPoint[] keypoints,
            OutputArray descriptors,
            bool useProvidedKeypoints = false)
        {
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (descriptors == null)
                throw new ArgumentNullException(nameof(descriptors));
            image.ThrowIfDisposed();
            if (mask != null)
                mask.ThrowIfDisposed();

            using (var keypointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_Feature2D_detectAndCompute(
                    ptr, image.CvPtr, Cv2.ToPtr(mask), keypointsVec.CvPtr, descriptors.CvPtr, useProvidedKeypoints ? 1 : 0);
                keypoints = keypointsVec.ToArray();
            }

            GC.KeepAlive(image);
            GC.KeepAlive(mask);
            descriptors.Fix();
        }

        #endregion

        internal class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.features2d_Ptr_Feature2D_get(ptr);
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.features2d_Ptr_Feature2D_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}
