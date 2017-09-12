
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
                throw new ArgumentNullException(nameof(fileName));
#if !uwp
            if (!File.Exists(fileName))
                throw new FileNotFoundException("\""+ fileName + "\"not found", fileName);
#endif
            ptr = NativeMethods.objdetect_CascadeClassifier_newFromFile(fileName);  
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.objdetect_CascadeClassifier_delete(ptr);
            base.DisposeUnmanaged();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks whether the classifier has been loaded.
        /// </summary>
        /// <returns></returns>
        public virtual bool Empty()
        {
            ThrowIfDisposed();
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
            ThrowIfDisposed();
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
#if !uwp
            if (!File.Exists(fileName))
                throw new FileNotFoundException("\"" + fileName + "\"not found", fileName);
#endif
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
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
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
            ThrowIfDisposed();
            if (image == null)
                throw new ArgumentNullException(nameof(image));
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
            ThrowIfDisposed();
            return NativeMethods.objdetect_CascadeClassifier_isOldFormatCascade(ptr) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Size GetOriginalWindowSize()
        {
            ThrowIfDisposed();
            return NativeMethods.objdetect_CascadeClassifier_getOriginalWindowSize(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetFeatureType()
        {
            ThrowIfDisposed();
            return NativeMethods.objdetect_CascadeClassifier_getFeatureType(ptr);
        }

#endregion
    }

}
