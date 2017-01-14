using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Util;

namespace OpenCvSharp.Face
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseFaceRecognizer : FaceRecognizer
    {
        private bool disposed;

        /// <summary>
        ///
        /// </summary>
        private Ptr<BaseFaceRecognizer> recognizerPtr;

        #region Init & Disposal

        /// <summary>
        ///
        /// </summary>
        protected BaseFaceRecognizer()
        {
            recognizerPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes.
        /// </summary>
        /// <param name="ptr"></param>
        internal new static BaseFaceRecognizer FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(BaseFaceRecognizer)}> pointer");
            var ptrObj = new Ptr<BaseFaceRecognizer>(ptr);
            var detector = new BaseFaceRecognizer
            {
                recognizerPtr = ptrObj,
                ptr = ptrObj.Get()
            };
            return detector;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="numComponents"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static BaseFaceRecognizer CreateEigenFaceRecognizer(int numComponents = 0, double threshold = Double.MaxValue)
        {
            IntPtr p = NativeMethods.face_createEigenFaceRecognizer(numComponents, threshold);
            return FromPtr(p);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="numComponents"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static BaseFaceRecognizer CreateFisherFaceRecognizer(
            int numComponents = 0, double threshold = Double.MaxValue)
        {
            IntPtr p = NativeMethods.face_createFisherFaceRecognizer(numComponents, threshold);
            return FromPtr(p);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="neighbors"></param>
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static FaceRecognizer CreateLBPHFaceRecognizer(int radius = 1, int neighbors = 8,
            int gridX = 8, int gridY = 8, double threshold = Double.MaxValue)
        {
            IntPtr p = NativeMethods.face_createLBPHFaceRecognizer(radius, neighbors, gridX, gridY, threshold);
            return FromPtr(p);
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


        #endregion
    }
}