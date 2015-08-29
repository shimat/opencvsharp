
using System;
using System.IO;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    /// <summary>
    /// Cascade classifier class for object detection.
    /// </summary>
    public class CascadeClassifier : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal

        /// <summary>
        /// Default constructor
        /// </summary>
        public CascadeClassifier()
	    {
            ptr = NativeMethods.objdetect_CascadeClassifier_new();               
	    }

        /// <summary>
        /// Loads a classifier from a file.
        /// </summary>
        /// <param name="fileName">Name of the file from which the classifier is loaded.</param>
        public CascadeClassifier(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("\""+ fileName + "\"not found", fileName);
            ptr = NativeMethods.objdetect_CascadeClassifier_newFromFile(fileName);  
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
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.objdetect_CascadeClassifier_delete(ptr);
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
        /// Checks whether the classifier has been loaded.
        /// </summary>
        /// <returns></returns>
        public virtual bool Empty()
        {
            if (disposed)
                throw new ObjectDisposedException("CascadeClassifier");
            return NativeMethods.objdetect_CascadeClassifier_empty(ptr) != 0;
        }

        /// <summary>
        /// Loads a classifier from a file.
        /// </summary>
        /// <param name="fileName">Name of the file from which the classifier is loaded. 
        /// The file may contain an old HAAR classifier trained by the haartraining application 
        /// or a new cascade classifier trained by the traincascade application.</param>
        /// <returns></returns>
        public bool Load(string fileName)
        {
            if (disposed)
                throw new ObjectDisposedException("CascadeClassifier");
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            if (!File.Exists(fileName))
                throw new FileNotFoundException("\"" + fileName + "\"not found", fileName);
            return NativeMethods.objdetect_CascadeClassifier_load(ptr, fileName) != 0;
        }

        //public virtual bool read( const FileNode& node );

        /// <summary>
        /// Detects objects of different sizes in the input image. The detected objects are returned as a list of rectangles.
        /// </summary>
        /// <param name="image">Matrix of the type CV_8U containing an image where objects are detected.</param>
        /// <param name="scaleFactor">Parameter specifying how much the image size is reduced at each image scale.</param>
        /// <param name="minNeighbors">Parameter specifying how many neighbors each candidate rectangle should have to retain it.</param>
        /// <param name="flags">Parameter with the same meaning for an old cascade as in the function cvHaarDetectObjects. 
        /// It is not used for a new cascade.</param>
        /// <param name="minSize">Minimum possible object size. Objects smaller than that are ignored.</param>
        /// <param name="maxSize">Maximum possible object size. Objects larger than that are ignored.</param>
        /// <returns>Vector of rectangles where each rectangle contains the detected object.</returns>
        public virtual Rect[] DetectMultiScale(
            Mat image,
            double scaleFactor = 1.1,
            int minNeighbors = 3,
            HaarDetectionType flags = 0,
            Size? minSize = null,
            Size? maxSize = null)
        {
            if (disposed)
                throw new ObjectDisposedException("CascadeClassifier");
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            Size minSize0 = minSize.GetValueOrDefault(new Size());
            Size maxSize0 = maxSize.GetValueOrDefault(new Size());

            using (var objectsVec = new VectorOfRect())
            {
                NativeMethods.objdetect_CascadeClassifier_detectMultiScale1(
                    ptr, image.CvPtr, objectsVec.CvPtr, 
                    scaleFactor, minNeighbors, (int)flags, minSize0, maxSize0);
                return objectsVec.ToArray();
            }
        }

        /// <summary>
        /// Detects objects of different sizes in the input image. The detected objects are returned as a list of rectangles.
        /// </summary>
        /// <param name="image">Matrix of the type CV_8U containing an image where objects are detected.</param>
        /// <param name="rejectLevels"></param>
        /// <param name="levelWeights"></param>
        /// <param name="scaleFactor">Parameter specifying how much the image size is reduced at each image scale.</param>
        /// <param name="minNeighbors">Parameter specifying how many neighbors each candidate rectangle should have to retain it.</param>
        /// <param name="flags">Parameter with the same meaning for an old cascade as in the function cvHaarDetectObjects. 
        /// It is not used for a new cascade.</param>
        /// <param name="minSize">Minimum possible object size. Objects smaller than that are ignored.</param>
        /// <param name="maxSize">Maximum possible object size. Objects larger than that are ignored.</param>
        /// <param name="outputRejectLevels"></param>
        /// <returns>Vector of rectangles where each rectangle contains the detected object.</returns>
        public virtual Rect[] DetectMultiScale(
            Mat image,
            out int[] rejectLevels,
            out double[] levelWeights,
            double scaleFactor = 1.1,
            int minNeighbors = 3,
            HaarDetectionType flags = 0,
            Size? minSize = null,
            Size? maxSize = null,
            bool outputRejectLevels = false)
        {
            if (disposed)
                throw new ObjectDisposedException("CascadeClassifier");
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            Size minSize0 = minSize.GetValueOrDefault(new Size());
            Size maxSize0 = maxSize.GetValueOrDefault(new Size());

            using (var objectsVec = new VectorOfRect())
            using (var rejectLevelsVec = new VectorOfInt32())
            using (var levelWeightsVec = new VectorOfDouble())
            {
                NativeMethods.objdetect_CascadeClassifier_detectMultiScale2(
                    ptr, image.CvPtr, objectsVec.CvPtr, rejectLevelsVec.CvPtr, levelWeightsVec.CvPtr,
                    scaleFactor, minNeighbors, (int)flags, minSize0, maxSize0, outputRejectLevels ? 1 : 0);

                rejectLevels = rejectLevelsVec.ToArray();
                levelWeights = levelWeightsVec.ToArray();
                return objectsVec.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsOldFormatCascade()
        {
            if (disposed)
                throw new ObjectDisposedException("CascadeClassifier");
            return NativeMethods.objdetect_CascadeClassifier_isOldFormatCascade(ptr) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Size GetOriginalWindowSize()
        {
            if (disposed)
                throw new ObjectDisposedException("CascadeClassifier");
            return NativeMethods.objdetect_CascadeClassifier_getOriginalWindowSize(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetFeatureType()
        {
            if (disposed)
                throw new ObjectDisposedException("CascadeClassifier");
            return NativeMethods.objdetect_CascadeClassifier_getFeatureType(ptr);
        }

        #endregion
    }

}
