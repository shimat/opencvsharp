using System;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// The Base Class for Background/Foreground Segmentation.
    /// The class is only used to define the common interface for
    /// the whole family of background/foreground segmentation algorithms.
    /// </summary>
    public class BackgroundSubtractorGMG : BackgroundSubtractor
    {
        private Ptr<BackgroundSubtractorGMG> objectPtr;
        private bool disposed = false;

        #region Init & Disposal

        /// <summary>
        /// the default constructor
        /// </summary>
        public BackgroundSubtractorGMG()
        {
            IntPtr po = NativeMethods.video_BackgroundSubtractorGMG_new();
            if (po == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create BackgroundSubtractorGMG");
            objectPtr = new Ptr<BackgroundSubtractorGMG>(po);
            ptr = objectPtr.Obj;
        }

        internal BackgroundSubtractorGMG(Ptr<BackgroundSubtractorGMG> objectPtr, IntPtr ptr)
        {
            this.objectPtr = objectPtr;
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal new static BackgroundSubtractorGMG FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid BackgroundSubtractorGMG pointer");

            var ptrObj = new Ptr<BackgroundSubtractorGMG>(ptr);
            var obj = new BackgroundSubtractorGMG(ptrObj, ptrObj.Obj);
            return obj;
        }

        /// <summary>
        /// Creates instance from raw T*
        /// </summary>
        /// <param name="ptr"></param>
        internal new static BackgroundSubtractorGMG FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid BackgroundSubtractorGMG pointer");
            var obj = new BackgroundSubtractorGMG(null, ptr);
            return obj;
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
                        if (objectPtr != null)
                        {
                            objectPtr.Dispose();
                        }
                        else
                        {
                            if (ptr != IntPtr.Zero)
                                NativeMethods.video_BackgroundSubtractorGMG_delete(ptr);
                        }
                        objectPtr = null;
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

        #region Properties

        /// <summary>
        /// Total number of distinct colors to maintain in histogram.
        /// </summary>
        public int MaxFeatures
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.video_BackgroundSubtractorGMG_maxFeatures(ptr);
                }
            }

            set
            {
                unsafe
                {
                    *NativeMethods.video_BackgroundSubtractorGMG_maxFeatures(ptr) = value;
                }
            }
        }

        /// <summary>
        /// Set between 0.0 and 1.0, determines how quickly features are "forgotten" from histograms.
        /// </summary>
        public double LearningRate
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.video_BackgroundSubtractorGMG_learningRate(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.video_BackgroundSubtractorGMG_learningRate(ptr) = value;
                }
            }
        }

        /// <summary>
        /// Number of frames of video to use to initialize histograms.
        /// </summary>
        public int NumInitializationFrames
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.video_BackgroundSubtractorGMG_numInitializationFrames(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.video_BackgroundSubtractorGMG_numInitializationFrames(ptr) = value;
                }
            }
        }

        /// <summary>
        /// Number of discrete levels in each channel to be used in histograms.
        /// </summary>
        public int QuantizationLevels
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.video_BackgroundSubtractorGMG_quantizationLevels(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.video_BackgroundSubtractorGMG_quantizationLevels(ptr) = value;
                }
            }
        }

        /// <summary>
        /// Prior probability that any given pixel is a background pixel. A sensitivity parameter.
        /// </summary>
        public double BackgroundPrior
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.video_BackgroundSubtractorGMG_backgroundPrior(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.video_BackgroundSubtractorGMG_backgroundPrior(ptr) = value;
                }
            }
        }

        /// <summary>
        /// Value above which pixel is determined to be FG.
        /// </summary>
        public double DecisionThreshold
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.video_BackgroundSubtractorGMG_decisionThreshold(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.video_BackgroundSubtractorGMG_decisionThreshold(ptr) = value;
                }
            }
        }

        /// <summary>
        /// Smoothing radius, in pixels, for cleaning up FG image.
        /// </summary>
        public int SmoothingRadius
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.video_BackgroundSubtractorGMG_smoothingRadius(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.video_BackgroundSubtractorGMG_smoothingRadius(ptr) = value;
                }
            }
        }

        /// <summary>
        /// Perform background model update
        /// </summary>
        public bool UpdateBackgroundModel
        {
            get
            {
                return NativeMethods.video_BackgroundSubtractorGMG_updateBackgroundModel_get(ptr) != 0;
            }
            set
            {
                NativeMethods.video_BackgroundSubtractorGMG_updateBackgroundModel_set(ptr, value ? 1 : 0);
            }
        }

        #endregion

        /// <summary>
        /// Performs single-frame background subtraction and builds up a statistical background image
        /// </summary>
        /// <param name="image">Input image</param>
        /// <param name="fgmask">Output mask image representing foreground and background pixels</param>
        /// <param name="learningRate"></param>
        public override void Run(InputArray image, OutputArray fgmask, double learningRate = -1.0)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (fgmask == null)
                throw new ArgumentNullException("fgmask");
            image.ThrowIfDisposed();
            fgmask.ThrowIfNotReady();
            NativeMethods.video_BackgroundSubtractorGMG_operator(ptr, image.CvPtr, fgmask.CvPtr, learningRate);
            fgmask.Fix();
        }

        /// <summary>
        /// Validate parameters and set up data structures for appropriate image size.
        /// Must call before running on data.
        /// </summary>
        /// <param name="frameSize">input frame size</param>
        /// <param name="min">minimum value taken on by pixels in image sequence. Usually 0</param>
        /// <param name="max">maximum value taken on by pixels in image sequence. e.g. 1.0 or 255</param>
        public virtual void Initialize(Size frameSize, double min, double max)
        {
            NativeMethods.video_BackgroundSubtractorGMG_initialize(ptr, frameSize, min, max);
        }

        /// <summary>
        /// Releases all inner buffers.
        /// </summary>
        public new void Release()
        {
            NativeMethods.video_BackgroundSubtractorGMG_release(ptr);
        }

        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get { return NativeMethods.video_BackgroundSubtractorGMG_info(ptr); }
        }
    }
}