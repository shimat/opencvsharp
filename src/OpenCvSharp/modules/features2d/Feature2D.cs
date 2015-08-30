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
        private bool disposed;

        /// <summary>
        /// cv::Ptr&lt;Feature2D&gt;
        /// </summary>
        private Ptr<Feature2D> ptrObj;

        /// <summary>
        /// 
        /// </summary>
        internal Feature2D()
            : base()
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
            var ptrObj = new Ptr<Feature2D>(ptr);
            var detector = new Feature2D
            {
                ptrObj = ptrObj,
                ptr = ptrObj.Get()
            };
            return detector;
        }

#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
    /// <param name="disposing">
    /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
    /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
    ///</param>
#else
        /// <summary>
        /// Releases the resources
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
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
                        if (ptrObj != null)
                            ptrObj.Dispose();
                        ptrObj = null;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int DescriptorSize
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
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
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.features2d_Feature2D_defaultNorm(ptr);
            }
        }

        /// <summary>
        /// Return true if detector object is empty
        /// </summary>
        /// <returns></returns>
        public new virtual bool Empty()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
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
                throw new ArgumentNullException("image");
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

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
                throw new ArgumentNullException("image");
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

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
                throw new ArgumentNullException("images");
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

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
                throw new ArgumentNullException("image");
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            using (var keypointsVec = new VectorOfKeyPoint(keypoints))
            {
                NativeMethods.features2d_Feature2D_compute1(ptr, image.CvPtr, keypointsVec.CvPtr, descriptors.CvPtr);
                keypoints = keypointsVec.ToArray();
            }
        }

        /// <summary>
        /// Compute the descriptors for a set of keypoints in an image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="inKeypoints">The input keypoints. Keypoints for which a descriptor cannot be computed are removed.</param>
        /// <param name="outKeypoints"></param>
        /// <param name="descriptors">Copmputed descriptors. Row i is the descriptor for keypoint i.</param>param>
        public virtual void Compute(InputArray image, KeyPoint[] inKeypoints, out KeyPoint[] outKeypoints,
            OutputArray descriptors)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            using (var keypointsVec = new VectorOfKeyPoint(inKeypoints))
            {
                NativeMethods.features2d_Feature2D_compute1(ptr, image.CvPtr, keypointsVec.CvPtr, descriptors.CvPtr);
                outKeypoints = keypointsVec.ToArray();
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
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (images == null)
                throw new ArgumentNullException("images");
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");

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
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            if (image == null)
                throw new ArgumentNullException("image");
            if (descriptors == null)
                throw new ArgumentNullException("descriptors");
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
    }
}
