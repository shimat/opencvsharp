using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Util;

namespace OpenCvSharp.Face
{
    /// <summary>
    /// Abstract base class for all face recognition models.
    /// All face recognition models in OpenCV are derived from the abstract base class FaceRecognizer, which
    /// provides a unified access to all face recongition algorithms in OpenCV.
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
                throw new OpenCvSharpException($"Invalid cv::Ptr<{nameof(FaceRecognizer)}> pointer");
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

        /// <summary>
        /// Trains a FaceRecognizer with given data and associated labels.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="labels"></param>
        public virtual void Train(IEnumerable<Mat> src, IEnumerable<int> labels)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            IntPtr[] srcArray = EnumerableEx.SelectPtrs(src);
            int[] labelsArray = EnumerableEx.ToArray(labels);
            NativeMethods.face_FaceRecognizer_train(
                ptr, srcArray, srcArray.Length, labelsArray, labelsArray.Length);
        }

        /// <summary>
        /// Updates a FaceRecognizer with given data and associated labels.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="labels"></param>
        public void Update(IEnumerable<Mat> src, IEnumerable<int> labels)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
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
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
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
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            src.ThrowIfDisposed();
            NativeMethods.face_FaceRecognizer_predict2(ptr, src.CvPtr, out label, out confidence);
        }

        /// <summary>
        /// Serializes this object to a given filename.
        /// </summary>
        /// <param name="fileName"></param>
        public new virtual void Save(string fileName)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            NativeMethods.face_FaceRecognizer_save1(ptr, fileName);
        }

        /// <summary>
        /// Deserializes this object from a given filename.
        /// </summary>
        /// <param name="fileName"></param>
        public virtual void Load(string fileName)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            NativeMethods.face_FaceRecognizer_load1(ptr, fileName);
        }

        /// <summary>
        /// Serializes this object to a given cv::FileStorage.
        /// </summary>
        /// <param name="fs"></param>
        public virtual void Save(FileStorage fs)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (fs == null)
                throw new ArgumentNullException(nameof(fs));
            NativeMethods.face_FaceRecognizer_save2(ptr, fs.CvPtr);
        }

        /// <summary>
        /// Deserializes this object from a given cv::FileStorage.
        /// </summary>
        /// <param name="fs"></param>
        public virtual void Load(FileStorage fs)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (fs == null)
                throw new ArgumentNullException(nameof(fs));
            NativeMethods.face_FaceRecognizer_load2(ptr, fs.CvPtr);
        }

        /// <summary>
        /// Sets string info for the specified model's label.
        /// The string info is replaced by the provided value if it was set before for the specified label.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="strInfo"></param>
        public void SetLabelInfo(int label, string strInfo)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (strInfo == null)
                throw new ArgumentNullException(nameof(strInfo));
            NativeMethods.face_FaceRecognizer_setLabelInfo(ptr, label, strInfo);
        }

        /// <summary>
        /// Gets string information by label.
        /// If an unknown label id is provided or there is no label information associated with the specified 
        /// label id the method returns an empty string.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public string GetLabelInfo(int label)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            using (var resultVector = new VectorOfByte())
            {
                NativeMethods.face_FaceRecognizer_getLabelInfo(ptr, label, resultVector.CvPtr);
                return StringHelper.PtrToStringAnsi(resultVector.ElemPtr);
            }
        }

        /// <summary>
        /// Gets vector of labels by string.
        /// The function searches for the labels containing the specified sub-string in the associated string info.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int[] GetLabelsByString(string str)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            using (var resultVector = new VectorOfInt32())
            {
                NativeMethods.face_FaceRecognizer_getLabelsByString(ptr, str, resultVector.CvPtr);
                return resultVector.ToArray();
            }
        }

        /// <summary>
        /// threshold parameter accessor - required for default BestMinDist collector
        /// </summary>
        /// <returns></returns>
        public double GetThreshold()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            return NativeMethods.face_FaceRecognizer_getThreshold(ptr);
        }

        /// <summary>
        /// Sets threshold of model
        /// </summary>
        /// <param name="val"></param>
        public void SetThreshold(double val)
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FaceRecognizer));
            NativeMethods.face_FaceRecognizer_setThreshold(ptr, val);
        }

        #endregion
    }
}