using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Face
{
    /// <summary>
    /// base for two FaceRecognizer classes
    /// </summary>
    public class BasicFaceRecognizer : FaceRecognizer
    {
        private bool disposed;

        /// <summary>
        ///
        /// </summary>
        private Ptr recognizerPtr;

        #region Init & Disposal

        /// <summary>
        ///
        /// </summary>
        protected BasicFaceRecognizer()
        {
            recognizerPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes.
        /// </summary>
        /// <param name="ptr"></param>
        internal new static BasicFaceRecognizer FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(BasicFaceRecognizer)}> pointer");
            var ptrObj = new Ptr(ptr);
            var detector = new BasicFaceRecognizer
            {
                recognizerPtr = ptrObj,
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
                        recognizerPtr?.Dispose();
                        recognizerPtr = null;
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

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetNumComponents()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(BasicFaceRecognizer));
            return NativeMethods.face_BasicFaceRecognizer_getNumComponents(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public virtual void SetNumComponents(int val)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(BasicFaceRecognizer));
            NativeMethods.face_BasicFaceRecognizer_setNumComponents(ptr, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new virtual double GetThreshold()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(BasicFaceRecognizer));
            return NativeMethods.face_BasicFaceRecognizer_getThreshold(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public new virtual void SetThreshold(double val)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(BasicFaceRecognizer));
            NativeMethods.face_BasicFaceRecognizer_setThreshold(ptr, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat[] GetProjections()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(BasicFaceRecognizer));
            using (var resultVector = new VectorOfMat())
            {
                NativeMethods.face_BasicFaceRecognizer_getProjections(ptr, resultVector.CvPtr);
                return resultVector.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetLabels()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(BasicFaceRecognizer));
            Mat result = new Mat();
            NativeMethods.face_BasicFaceRecognizer_getLabels(ptr, result.CvPtr);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetEigenValues()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(BasicFaceRecognizer));
            Mat result = new Mat();
            NativeMethods.face_BasicFaceRecognizer_getEigenValues(ptr, result.CvPtr);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetEigenVectors()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(BasicFaceRecognizer));
            Mat result = new Mat();
            NativeMethods.face_BasicFaceRecognizer_getEigenVectors(ptr, result.CvPtr);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetMean()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(BasicFaceRecognizer));
            Mat result = new Mat();
            NativeMethods.face_BasicFaceRecognizer_getMean(ptr, result.CvPtr);
            return result;
        }

        #endregion

        internal new class Ptr : OpenCvSharp.Ptr
        {
            public Ptr(IntPtr ptr) : base(ptr)
            {
            }

            public override IntPtr Get()
            {
                return NativeMethods.face_Ptr_BasicFaceRecognizer_get(ptr);
            }

            protected override void Release()
            {
                NativeMethods.face_Ptr_BasicFaceRecognizer_delete(ptr);
            }
        }
    }
}