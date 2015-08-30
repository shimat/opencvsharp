using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Util;

namespace OpenCvSharp.Face
{
    /// <summary>
    ///
    /// </summary>
    public class FaceRecognizer : Algorithm
    {
        private bool disposed;

        /// <summary>
        ///
        /// </summary>
        private Ptr<FaceRecognizer> recognizerPtr;

        #region Init & Disposal

        /// <summary>
        ///
        /// </summary>
        protected FaceRecognizer()
        {
            recognizerPtr = null;
            ptr = IntPtr.Zero;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes.
        /// </summary>
        /// <param name="ptr"></param>
        internal static FaceRecognizer FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid cv::Ptr<FaceRecognizer> pointer");
            var ptrObj = new Ptr<FaceRecognizer>(ptr);
            var detector = new FaceRecognizer
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
        public static FaceRecognizer CreateEigenFaceRecognizer(int numComponents = 0, double threshold = Double.MaxValue)
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
        public static FaceRecognizer CreateFisherFaceRecognizer(int numComponents = 0,
            double threshold = Double.MaxValue)
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
                        if (recognizerPtr != null)
                            recognizerPtr.Dispose();
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
        /// Trains a FaceRecognizer.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="labels"></param>
        public virtual void Train(IEnumerable<Mat> src, IEnumerable<int> labels)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (labels == null)
                throw new ArgumentNullException("labels");
            IntPtr[] srcArray = EnumerableEx.SelectPtrs(src);
            int[] labelsArray = EnumerableEx.ToArray(labels);
            NativeMethods.face_FaceRecognizer_train(
                ptr, srcArray, srcArray.Length, labelsArray, labelsArray.Length);
        }

        /// <summary>
        /// Updates a FaceRecognizer.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="labels"></param>
        public void Update(IEnumerable<Mat> src, IEnumerable<int> labels)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            if (labels == null)
                throw new ArgumentNullException("labels");
            IntPtr[] srcArray = EnumerableEx.SelectPtrs(src);
            int[] labelsArray = EnumerableEx.ToArray(labels);
            NativeMethods.face_FaceRecognizer_update(
                ptr, srcArray, srcArray.Length, labelsArray, labelsArray.Length);
        }

        /// <summary>
        /// Gets a prediction from a FaceRecognizer.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public virtual int Predict(InputArray src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            return NativeMethods.face_FaceRecognizer_predict1(ptr, src.CvPtr);
        }

        /// <summary>
        /// Predicts the label and confidence for a given sample.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="label"></param>
        /// <param name="confidence"></param>
        public virtual void Predict(InputArray src, out int label, out double confidence)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            src.ThrowIfDisposed();
            NativeMethods.face_FaceRecognizer_predict2(ptr, src.CvPtr, out label, out confidence);
        }

        /// <summary>
        /// Serializes this object to a given filename.
        /// </summary>
        /// <param name="fileName"></param>
        public virtual new void Save(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            NativeMethods.face_FaceRecognizer_save1(ptr, fileName);
        }

        /// <summary>
        /// Deserializes this object from a given filename.
        /// </summary>
        /// <param name="fileName"></param>
        public virtual void Load(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            NativeMethods.face_FaceRecognizer_load1(ptr, fileName);
        }

        /// <summary>
        /// Serializes this object to a given cv::FileStorage.
        /// </summary>
        /// <param name="fs"></param>
        public virtual void Save(FileStorage fs)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            NativeMethods.face_FaceRecognizer_save2(ptr, fs.CvPtr);
        }

        /// <summary>
        /// Deserializes this object from a given cv::FileStorage.
        /// </summary>
        /// <param name="fs"></param>
        public virtual void Load(FileStorage fs)
        {
            if (fs == null)
                throw new ArgumentNullException("fs");
            NativeMethods.face_FaceRecognizer_load2(ptr, fs.CvPtr);
        }

        #endregion
    }
}