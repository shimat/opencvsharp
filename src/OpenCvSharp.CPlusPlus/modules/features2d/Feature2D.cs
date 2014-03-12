using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// 
    /// </summary>
    public class Feature2D : FeatureDetector
    {
        private bool disposed;

        /// <summary>
        /// 
        /// </summary>
        internal Feature2D()
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptrObj"></param>
        internal Feature2D(IntPtr ptrObj)
            : base()
        {
            detectorPtr = new PtrOfFeatureDetector(ptrObj);
            ptr = detectorPtr.ObjPointer;
            if(ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid Feature2D pointer");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="keypoints"></param>
        /// <param name="descriptors"></param>
        public void Compute(Mat image, out KeyPoint[] keypoints, Mat descriptors)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            using (StdVectorKeyPoint keypointsVec = new StdVectorKeyPoint())
            {
                CppInvoke.features2d_Feature2D_compute(ptr, image.CvPtr, keypointsVec.CvPtr, descriptors.CvPtr);
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
            IntPtr ptr = CppInvoke.features2d_Feature2D_create(detectorType);
            try
            {
                Feature2D detector = new Feature2D(ptr);
                return detector;
            }
            catch (OpenCvSharpException)
            {
                throw new OpenCvSharpException("Detector name '{0}' is not valid.", detectorType);
            }
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
    }
}
