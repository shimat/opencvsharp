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

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            recognizerPtr?.Dispose();
            recognizerPtr = null;
            base.DisposeManaged();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetNumComponents()
        {
            ThrowIfDisposed();
            var res = NativeMethods.face_BasicFaceRecognizer_getNumComponents(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public virtual void SetNumComponents(int val)
        {
            ThrowIfDisposed();
            NativeMethods.face_BasicFaceRecognizer_setNumComponents(ptr, val);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new virtual double GetThreshold()
        {
            ThrowIfDisposed();
            var res = NativeMethods.face_BasicFaceRecognizer_getThreshold(ptr);
            GC.KeepAlive(this);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public new virtual void SetThreshold(double val)
        {
            ThrowIfDisposed();
            NativeMethods.face_BasicFaceRecognizer_setThreshold(ptr, val);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat[] GetProjections()
        {
            ThrowIfDisposed();
            using (var resultVector = new VectorOfMat())
            {
                NativeMethods.face_BasicFaceRecognizer_getProjections(ptr, resultVector.CvPtr);
                GC.KeepAlive(this);
                return resultVector.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetLabels()
        {
            ThrowIfDisposed();
            Mat result = new Mat();
            NativeMethods.face_BasicFaceRecognizer_getLabels(ptr, result.CvPtr);
            GC.KeepAlive(this);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetEigenValues()
        {
            ThrowIfDisposed();
            Mat result = new Mat();
            NativeMethods.face_BasicFaceRecognizer_getEigenValues(ptr, result.CvPtr);
            GC.KeepAlive(this);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetEigenVectors()
        {
            ThrowIfDisposed();
            Mat result = new Mat();
            NativeMethods.face_BasicFaceRecognizer_getEigenVectors(ptr, result.CvPtr);
            GC.KeepAlive(this);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat GetMean()
        {
            ThrowIfDisposed();
            Mat result = new Mat();
            NativeMethods.face_BasicFaceRecognizer_getMean(ptr, result.CvPtr);
            GC.KeepAlive(this);
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
                var res = NativeMethods.face_Ptr_BasicFaceRecognizer_get(ptr);
                GC.KeepAlive(this);
                return res;
            }

            protected override void DisposeUnmanaged()
            {
                NativeMethods.face_Ptr_BasicFaceRecognizer_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}