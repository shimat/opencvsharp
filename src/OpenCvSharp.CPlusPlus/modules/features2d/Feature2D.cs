using System;
using System.Collections.Generic;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class Feature2D : FeatureDetector, IDescriptorExtractor
    {
        private bool disposed;
        /// <summary>
        /// cv::Ptr&lt;Feature2D&gt;
        /// </summary>
        private Ptr<Feature2D> detectorPtr;

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
        internal static new Feature2D FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<Feature2D> pointer");
            var ptrObj = new Ptr<Feature2D>(ptr);
            var detector = new Feature2D
                {
                    detectorPtr = ptrObj, 
                    ptr = ptrObj.Obj
                };
            return detector;
        }
        /// <summary>
        /// Creates instance from raw pointer T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static new Feature2D FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid Feature2D pointer");
            var detector = new Feature2D
                {
                    detectorPtr = null, 
                    ptr = ptr
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
                        if (detectorPtr != null)
                            detectorPtr.Dispose();
                        detectorPtr = null;
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
            using (var keypointsVec = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_Feature2D_compute(ptr, image.CvPtr, keypointsVec.CvPtr, descriptors.CvPtr);
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
        /// Create feature detector by detector name.
        /// </summary>
        /// <param name="detectorType"></param>
        /// <returns></returns>
        public static new Feature2D Create(string detectorType)
        {
            if(String.IsNullOrEmpty(detectorType))
                throw new ArgumentNullException("detectorType");
            // gets cv::Ptr<Feature2D>
            IntPtr ptr = NativeMethods.features2d_Feature2D_create(detectorType);
            try
            {
                Feature2D detector = FromPtr(ptr);
                return detector;
            }
            catch (OpenCvSharpException)
            {
                throw new OpenCvSharpException("Detector name '{0}' is not valid.", detectorType);
            }
        }

    }
}
