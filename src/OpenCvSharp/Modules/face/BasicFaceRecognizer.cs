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
            return NativeMethods.face_BasicFaceRecognizer_getNumComponents(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public virtual void SetNumComponents(int val)
        {
            ThrowIfDisposed();
            NativeMethods.face_BasicFaceRecognizer_setNumComponents(ptr, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new virtual double GetThreshold()
        {
            ThrowIfDisposed();
            return NativeMethods.face_BasicFaceRecognizer_getThreshold(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public new virtual void SetThreshold(double val)
        {
            ThrowIfDisposed();
            NativeMethods.face_BasicFaceRecognizer_setThreshold(ptr, val);
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

            protected override void DisposeUnmanaged()
            {
                NativeMethods.face_Ptr_BasicFaceRecognizer_delete(ptr);
                base.DisposeUnmanaged();
            }
        }
    }
}