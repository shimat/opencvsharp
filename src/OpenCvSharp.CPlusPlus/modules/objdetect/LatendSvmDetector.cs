using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    /// <summary>
    /// Find rectangular regions in the given image that are likely
    /// to contain objects and corresponding confidence levels
    /// </summary>
    public class LatentSvmDetector : DisposableCvObject
    {
        /// <summary>
        /// Structure contains the detection information.
        /// </summary>
        public class ObjectDetection
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="rect"></param>
            /// <param name="score"></param>
            /// <param name="classId"></param>
            public ObjectDetection(Rect? rect = null, float score = 0, int classId = -1)
            {
                Rect = rect.GetValueOrDefault(new Rect());
                Score = score;
                ClassId = classId;
            }

            /// <summary>
            /// bounding box for a detected object
            /// </summary>
            public Rect Rect { get; set; }
            /// <summary>
            /// confidence level
            /// </summary>
            public float Score { get; set; }
            /// <summary>
            /// class (model or detector) ID that detect an object
            /// </summary>
            public int ClassId { get; set; }
        }

        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal

        /// <summary>
        /// Default constructor
        /// </summary>
        public LatentSvmDetector()
	    {
            ptr = NativeMethods.objdetect_LatentSvmDetector_new();               
	    }

        /// <summary>
        /// Creates the HOG descriptor and detector.
        /// </summary>
        /// <param name="fileNames">A set of filenames storing the trained detectors (models). Each file contains one model. 
        /// See examples of such files here /opencv_extra/testdata/cv/latentsvmdetector/models_VOC2007/.</param>
        /// <param name="classNames">A set of trained models names. If it’s empty then the name of each model will be 
        /// constructed from the name of file containing the model. E.g. the model stored in "/home/user/cat.xml" will get the name "cat".</param>
        public LatentSvmDetector(IEnumerable<string> fileNames, IEnumerable<string> classNames)
            : this()
        {
            Load(fileNames, classNames);
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
                        NativeMethods.objdetect_LatentSvmDetector_delete(ptr);
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
        /// Clear all trained models and their names stored in an class object.
        /// </summary>
        public virtual void Clear()
        {
            if (disposed)
                throw new ObjectDisposedException("LatentSvmDetector");
            NativeMethods.objdetect_LatentSvmDetector_clear(ptr);
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool Empty()
        {
            if (disposed)
                throw new ObjectDisposedException("LatentSvmDetector");
            return NativeMethods.objdetect_LatentSvmDetector_empty(ptr) != 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileNames">A set of filenames storing the trained detectors (models). Each file contains one model. 
        /// See examples of such files here /opencv_extra/testdata/cv/latentsvmdetector/models_VOC2007/.</param>
        /// <param name="classNames">A set of trained models names. If it’s empty then the name of each model will be 
        /// constructed from the name of file containing the model. E.g. the model stored in "/home/user/cat.xml" will get the name "cat".</param>
        public virtual bool Load(IEnumerable<string> fileNames, IEnumerable<string> classNames)
        {
            if (disposed)
                throw new ObjectDisposedException("LatentSvmDetector");
            if (fileNames == null)
                throw new ArgumentNullException("fileNames");
            if (classNames == null)
                throw new ArgumentNullException("classNames");

            using (var fn = new StringArrayAddress(fileNames))
            using (var cn = new StringArrayAddress(classNames))
            {
                return NativeMethods.objdetect_LatentSvmDetector_load(
                    ptr, fn.Pointer, fn.Dim1Length, cn.Pointer, cn.Dim1Length) != 0;
            }
        }

        /// <summary>
        /// Find rectangular regions in the given image that are likely to contain objects of 
        /// loaded classes (models) and corresponding confidence levels.
        /// </summary>
        /// <param name="image">An image.</param>
        /// <param name="overlapThreshold">Threshold for the non-maximum suppression algorithm.</param>
        /// <param name="numThreads">Number of threads used in parallel version of the algorithm.</param>
        /// <returns>The detections: rectangulars, scores and class IDs.</returns>
        public virtual ObjectDetection[] Detect(Mat image,
            float overlapThreshold = 0.5f, int numThreads = -1)
        {
            if (disposed)
                throw new ObjectDisposedException("LatentSvmDetector");
            if (image == null)
                throw new ArgumentNullException("image");
            image.ThrowIfDisposed();

            using (var odVec = new VectorOfVec6d())
            {
                NativeMethods.objdetect_LatentSvmDetector_detect(
                    ptr, image.CvPtr, odVec.CvPtr, overlapThreshold, numThreads);

                return EnumerableEx.SelectToArray(odVec.ToArray(), v => 
                    new ObjectDetection
                    {
                        Rect = new Rect((int)v.Item0, (int)v.Item1, (int)v.Item2, (int)v.Item3),
                        Score = (float)v.Item4,
                        ClassId = (int)v.Item5
                    }
                );
            }
        }

        /// <summary>
        /// Return the class (model) names that were passed in constructor or method load or extracted from models filenames in those methods.
        /// </summary>
        /// <returns></returns>
        public string[] GetClassNames()
        {
            using (var outVec = new VectorOfString())
            {
                NativeMethods.objdetect_LatentSvmDetector_getClassNames(ptr, outVec.CvPtr);
                return outVec.ToArray();
            }
        }

        /// <summary>
        /// Return a count of loaded models (classes).
        /// </summary>
        /// <returns></returns>
        public long GetClassCount()
        {
            if (disposed)
                throw new ObjectDisposedException("LatentSvmDetector");
            return NativeMethods.objdetect_LatentSvmDetector_getClassCount(ptr).ToInt64();
        }

        #endregion
    }

}
