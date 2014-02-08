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
        private IntPtr detectorPtr;

        protected FeatureDetector()
        {
            detectorPtr = IntPtr.Zero;
        }
        protected FeatureDetector(IntPtr ptr)
        {
            detectorPtr = ptr;
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
            using (StdVectorKeyPoint keypoints = new StdVectorKeyPoint())
            {
                CppInvoke.features2d_FeatureDetector_detect(ptr, image.CvPtr, keypoints.CvPtr, GetCvPtr(mask));
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

            using (StdVectorVectorKeyPoint keypoints = new StdVectorVectorKeyPoint())
            {
                if (masks == null)
                {
                    CppInvoke.features2d_FeatureDetector_detect(ptr, imagesPtr, imagesArray.Length, keypoints.CvPtr, null);
                }
                else
                {
                    Mat[] masksArray = Util.ToArray(masks);
                    if(masksArray.Length != imagesArray.Length)
                        throw new ArgumentException("masks.Length != images.Length");
                    IntPtr[] masksPtr = new IntPtr[masksArray.Length];
                    for (int i = 0; i < masksArray.Length; i++)
                        masksPtr[i] = masksArray[i].CvPtr;
                    CppInvoke.features2d_FeatureDetector_detect(ptr, imagesPtr, imagesArray.Length, keypoints.CvPtr, masksPtr);
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
            return CppInvoke.features2d_FeatureDetector_empty(ptr) != 0;
        }

        /// <summary>
        /// Create feature detector by detector name.
        /// </summary>
        /// <param name="detectorType"></param>
        /// <returns></returns>
        public static FeatureDetector Create(string detectorType)
        {
            if(String.IsNullOrEmpty(detectorType))
                throw new ArgumentNullException("detectorType");
            IntPtr ptr = CppInvoke.features2d_FeatureDetector_create(detectorType);
            return new FeatureDetector(ptr);
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
                        if (detectorPtr != IntPtr.Zero)
                            CppInvoke.core_Ptr_FeatureDetector_delete(detectorPtr);
                        detectorPtr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
    }
}
