using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// structure contains the bounding box and confidence level for detected object 
    /// </summary>
#else
    /// <summary>
    /// structure contains the bounding box and confidence level for detected object 
    /// </summary>
#endif
    public class CvLatentSvmDetector : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and disposal
#if LANG_JP
        /// <summary>
        /// load trained detector from a file
        /// </summary>
        /// <param name="filename"></param>
#else
        /// <summary>
        /// load trained detector from a file
        /// </summary>
        /// <param name="filename"></param>
#endif
        public CvLatentSvmDetector(string filename)
        {
            ptr = NativeMethods.cvLoadLatentSvmDetector(filename);
            if (ptr == IntPtr.Zero)
            {
                throw new OpenCvSharpException("Failed to create CvLatentSvmDetector");
            }
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvLatentSvmDetector*</param>
#endif
        public CvLatentSvmDetector(IntPtr ptr)
        {
            this.ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#else
        /// <summary>
        /// Initializes from pointer
        /// </summary>
        /// <param name="ptr">struct CvLSH*</param>
#endif
        public static CvLatentSvmDetector FromPtr(IntPtr ptr)
        {
            return new CvLatentSvmDetector(ptr);
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
                        NativeMethods.cvReleaseLatentSvmDetector(ref ptr);
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
        #region DetectObjects
#if LANG_JP
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image"></param>
        /// <param name="storage"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image">image to detect objects in</param>
        /// <param name="storage">memory storage to store the resultant sequence of the object candidate rectangles</param>
        /// <returns></returns>      
#endif
        public CvSeq<CvObjectDetection> DetectObjects(IplImage image, CvMemStorage storage)
        {
            return Cv.LatentSvmDetectObjects(image, this, storage);
        }
#if LANG_JP
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image"></param>
        /// <param name="storage"></param>
        /// <param name="overlap_threshold"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image">image to detect objects in</param>
        /// <param name="storage">memory storage to store the resultant sequence of the object candidate rectangles</param>
        /// <param name="overlap_threshold">threshold for the non-maximum suppression algorithm 
        ///  = 0.5f [here will be the reference to original paper]</param>
        /// <returns></returns>   
#endif
        public CvSeq<CvObjectDetection> DetectObjects(IplImage image, CvMemStorage storage, float overlap_threshold)
        {
            return Cv.LatentSvmDetectObjects(image, this, storage, overlap_threshold);
        }
#if LANG_JP
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image"></param>
        /// <param name="storage"></param>
        /// <param name="overlap_threshold"></param>
        /// <param name="numThreads"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// find rectangular regions in the given image that are likely 
        /// to contain objects and corresponding confidence levels
        /// </summary>
        /// <param name="image">image to detect objects in</param>
        /// <param name="storage">memory storage to store the resultant sequence of the object candidate rectangles</param>
        /// <param name="overlap_threshold">threshold for the non-maximum suppression algorithm 
        ///  = 0.5f [here will be the reference to original paper]</param>
        /// <param name="numThreads"></param>
        /// <returns></returns>   
#endif
        public CvSeq<CvObjectDetection> DetectObjects(IplImage image, CvMemStorage storage, float overlap_threshold, int numThreads)
        {
            return Cv.LatentSvmDetectObjects(image, this, storage, overlap_threshold, numThreads);
        }
        #endregion
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int NumFilters
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)ptr)->num_filters;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)ptr)->num_filters = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int NumComponents
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)ptr)->num_components;
                }
            }
            set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)ptr)->num_components = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public unsafe int* NumPartFilters
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)ptr)->num_part_filters;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)ptr)->num_part_filters = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public IntPtr Filters
        {
            get
            {
                unsafe
                {
                    return (IntPtr)((WCvLatentSvmDetector*)ptr)->filters;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public unsafe float* B
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)ptr)->b;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)ptr)->b = value;
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public float ScoreThreshold
        {
            get
            {
                unsafe
                {
                    return ((WCvLatentSvmDetector*)ptr)->score_threshold;
                }
            }
            internal set
            {
                unsafe
                {
                    ((WCvLatentSvmDetector*)ptr)->score_threshold = value;
                }
            }
        }
        #endregion
    }
}
