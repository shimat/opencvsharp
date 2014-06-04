using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class FeatureDetector : Algorithm
    {
        private bool disposed;
        /// <summary>
        /// cv::Ptr&lt;FeatureDetector&gt;
        /// </summary>
        private Ptr<FeatureDetector> detectorPtr;

        /// <summary>
        /// 
        /// </summary>
        internal FeatureDetector()
        {
            detectorPtr = null;
            ptr = IntPtr.Zero;
        }
        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static FeatureDetector FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FeatureDetector pointer");

            var ptrObj = new Ptr<FeatureDetector>(ptr);
            var detector = new FeatureDetector
                {
                    detectorPtr = ptrObj,
                    ptr = ptrObj.Obj
                };
            return detector;
        }
        /// <summary>
        /// Creates instance from raw T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static FeatureDetector FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid FeatureDetector pointer");
            var detector = new FeatureDetector
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
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get { return NativeMethods.features2d_FeatureDetector_info(ptr); }
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
            if(image == null)
                throw new ArgumentNullException("image");
            using (VectorOfKeyPoint keypoints = new VectorOfKeyPoint())
            {
                NativeMethods.features2d_FeatureDetector_detect(ptr, image.CvPtr, keypoints.CvPtr, Cv2.ToPtr(mask));
                return keypoints.ToArray();
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

            Mat[] imagesArray = Util.ToArray(images);
            IntPtr[] imagesPtr = new IntPtr[imagesArray.Length];
            for (int i = 0; i < imagesArray.Length; i++)
                imagesPtr[i] = imagesArray[i].CvPtr;

            using (VectorOfVectorKeyPoint keypoints = new VectorOfVectorKeyPoint())
            {
                if (masks == null)
                {
                    NativeMethods.features2d_FeatureDetector_detect(ptr, imagesPtr, imagesArray.Length, keypoints.CvPtr, null);
                }
                else
                {
                    Mat[] masksArray = Util.ToArray(masks);
                    if(masksArray.Length != imagesArray.Length)
                        throw new ArgumentException("masks.Length != images.Length");
                    IntPtr[] masksPtr = new IntPtr[masksArray.Length];
                    for (int i = 0; i < masksArray.Length; i++)
                        masksPtr[i] = masksArray[i].CvPtr;
                    NativeMethods.features2d_FeatureDetector_detect(ptr, imagesPtr, imagesArray.Length, keypoints.CvPtr, masksPtr);
                }
                return keypoints.ToArray();
            }
        }

        /// <summary>
        /// Return true if detector object is empty
        /// </summary>
        /// <returns></returns>
        public virtual bool Empty()
        {
            return NativeMethods.features2d_FeatureDetector_empty(ptr) != 0;
        }

        /*
        /// <summary>
        /// Create feature detector by detector name.
        /// </summary>
        /// <param name="detectorType">
        /// "FAST" – FastFeatureDetector, 
        /// "STAR" – StarFeatureDetector,
        /// "SIFT" – SIFT (nonfree module), 
        /// "SURF" – SURF (nonfree module), 
        /// "ORB" – ORB,
        /// "BRISK" – BRISK,
        /// "MSER" – MSER, 
        /// "GFTT" – GoodFeaturesToTrackDetector, 
        /// "HARRIS" – GoodFeaturesToTrackDetector with Harris detector enabled, 
        /// "Dense" – DenseFeatureDetector, 
        /// "SimpleBlob" – SimpleBlobDetector
        /// </param>
        /// <returns></returns>
        public static FeatureDetector Create(string detectorType)
        {
            if(String.IsNullOrEmpty(detectorType))
                throw new ArgumentNullException("detectorType");

            if (detectorType.Contains("Grid"))
                throw new NotImplementedException("GridAdaptedFeatureDetector not implemented");
            if (detectorType.Contains("Pyramid"))
                throw new NotImplementedException("PyramidAdaptedFeatureDetector not implemented");
            if (detectorType.Contains("Dynamic"))
                throw new NotImplementedException("DynamicAdaptedFeatureDetector not implemented");

            if (detectorType.Contains("HARRIS"))
            {
                var fd = Create("GFTT");
                fd.SetBool("useHarrisDetector", true);
                return fd;
            }

            return Algorithm.Create<FeatureDetector>("Feature2D." + detectorType);
        }
        */
    }
}
