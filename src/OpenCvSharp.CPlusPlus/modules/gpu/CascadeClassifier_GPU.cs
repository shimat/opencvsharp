using System;

namespace OpenCvSharp.CPlusPlus.Gpu
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// The cascade classifier class for object detection: 
    /// supports old haar and new lbp xlm formats and nvbin for haar cascades only.
    /// </summary>
// ReSharper disable once InconsistentNaming
    public class CascadeClassifier_GPU : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Disposal
        /// <summary>
        /// Default constructor
        /// </summary>
        public CascadeClassifier_GPU()
        {
            Cv2Gpu.ThrowIfGpuNotAvailable();
            ptr = NativeMethods.gpu_CascadeClassifier_GPU_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }

        /// <summary>
        /// CascadeClassifier_GPU Constructor
        /// </summary>
        /// <param name="fileName"></param>
        public CascadeClassifier_GPU(string fileName)
        {
            Cv2Gpu.ThrowIfGpuNotAvailable();
            ptr = NativeMethods.gpu_CascadeClassifier_GPU_new2(fileName);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
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
        /// Clean up any resources being used.
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
                    if (IsEnabledDispose)
                    {
                        NativeMethods.gpu_CascadeClassifier_GPU_delete(ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool FindLargestObject
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.gpu_CascadeClassifier_GPU_findLargestObject_get(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.gpu_CascadeClassifier_GPU_findLargestObject_set(ptr, value ? 0 : 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool VisualizeInPlace
        {
            get
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                return NativeMethods.gpu_CascadeClassifier_GPU_visualizeInPlace_get(ptr) != 0;
            }
            set
            {
                if (disposed)
                    throw new ObjectDisposedException(GetType().Name);
                NativeMethods.gpu_CascadeClassifier_GPU_visualizeInPlace_set(ptr, value ? 0 : 1);
            }
        }

        #endregion

        #region Methods

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
#endif
        public void Release()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            NativeMethods.gpu_CascadeClassifier_GPU_release(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="objectsBuf"></param>
        /// <param name="scaleFactor"></param>
        /// <param name="minNeighbors"></param>
        /// <param name="minSize"></param>
        /// <returns>number of detected objects</returns>
        public int DetectMultiScale(
            GpuMat image, GpuMat objectsBuf, 
            double scaleFactor = 1.2, int minNeighbors = 4, Size? minSize = null)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            CvSize minSizeVal = minSize.GetValueOrDefault(new Size());

            int ret = NativeMethods.gpu_CascadeClassifier_GPU_detectMultiScale1(
                ptr, image.CvPtr, objectsBuf.CvPtr, scaleFactor, minNeighbors, minSizeVal);

            GC.KeepAlive(image);
            GC.KeepAlive(objectsBuf);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="objectsBuf"></param>
        /// <param name="maxObjectSize"></param>
        /// <param name="minSize"></param>
        /// <param name="scaleFactor"></param>
        /// <param name="minNeighbors"></param>
        /// <returns>number of detected objects</returns>
        public int DetectMultiScale(
            GpuMat image, GpuMat objectsBuf, 
            Size maxObjectSize, Size? minSize = null, double scaleFactor = 1.1, int minNeighbors = 4)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);

            CvSize minSizeVal = minSize.GetValueOrDefault(new Size());

            int ret = NativeMethods.gpu_CascadeClassifier_GPU_detectMultiScale2(
                ptr, image.CvPtr, objectsBuf.CvPtr, maxObjectSize, minSizeVal, 
                scaleFactor, minNeighbors);
            
            GC.KeepAlive(image);
            GC.KeepAlive(objectsBuf);
            return ret;
        }


        /// <summary>
        /// 
        /// </summary>
        public Size GetClassifierSize()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().Name);
            return NativeMethods.gpu_CascadeClassifier_GPU_getClassifierSize(ptr);
        }

        #endregion
    }
}
