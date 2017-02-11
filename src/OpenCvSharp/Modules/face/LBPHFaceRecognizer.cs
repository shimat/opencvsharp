using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Face
{
    /// <summary>
    /// 
    /// </summary>
    public class LBPHFaceRecognizer : FaceRecognizer
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
        protected LBPHFaceRecognizer()
        {
            recognizerPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes.
        /// </summary>
        /// <param name="ptr"></param>
        internal new static LBPHFaceRecognizer FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(LBPHFaceRecognizer)}> pointer");
            var ptrObj = new Ptr(ptr);
            var detector = new LBPHFaceRecognizer
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
        public virtual int GetGridX()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            return NativeMethods.face_LBPHFaceRecognizer_getGridX(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public virtual void SetGridX(int val)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            NativeMethods.face_LBPHFaceRecognizer_setGridX(ptr, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetGridY()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            return NativeMethods.face_LBPHFaceRecognizer_getGridY(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public virtual void SetGridY(int val)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            NativeMethods.face_LBPHFaceRecognizer_setGridY(ptr, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetRadius()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            return NativeMethods.face_LBPHFaceRecognizer_getRadius(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public virtual void SetRadius(int val)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            NativeMethods.face_LBPHFaceRecognizer_setRadius(ptr, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetNeighbors()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            return NativeMethods.face_LBPHFaceRecognizer_getNeighbors(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public virtual void SetNeighbors(int val)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            NativeMethods.face_LBPHFaceRecognizer_setNeighbors(ptr, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new virtual double GetThreshold()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            return NativeMethods.face_LBPHFaceRecognizer_getThreshold(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public new virtual void SetThreshold(double val)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            NativeMethods.face_LBPHFaceRecognizer_setThreshold(ptr, val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Mat[] GetHistograms()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            using (var resultVector = new VectorOfMat())
            {
                NativeMethods.face_LBPHFaceRecognizer_getHistograms(ptr, resultVector.CvPtr);
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
                throw new ObjectDisposedException(nameof(LBPHFaceRecognizer));
            Mat result = new Mat();
            NativeMethods.face_LBPHFaceRecognizer_getLabels(ptr, result.CvPtr);
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
                return NativeMethods.face_Ptr_LBPHFaceRecognizer_get(ptr);
            }

            protected override void Release()
            {
                NativeMethods.face_Ptr_LBPHFaceRecognizer_delete(ptr);
            }
        }
    }
}