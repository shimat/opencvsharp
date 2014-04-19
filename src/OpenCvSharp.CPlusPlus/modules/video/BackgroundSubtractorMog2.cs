using System;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// The Base Class for Background/Foreground Segmentation.
    /// The class is only used to define the common interface for
    /// the whole family of background/foreground segmentation algorithms.
    /// </summary>
    public class BackgroundSubtractorMOG2 : BackgroundSubtractor
    {
        /// <summary>
        /// cv::Ptr&lt;FeatureDetector&gt;
        /// </summary>
        private Ptr<BackgroundSubtractorMOG2> objectPtr;
        /// <summary>
        /// 
        /// </summary>
        private bool disposed = false;

        #region Init & Disposal
        /// <summary>
        /// the default constructor
        /// </summary>
        public BackgroundSubtractorMOG2()
        {
            IntPtr po = NativeMethods.video_BackgroundSubtractorMOG2_new1();
            if (po == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create BackgroundSubtractorMOG2");
            objectPtr = new Ptr<BackgroundSubtractorMOG2>(po);
            ptr = objectPtr.Obj;
        }
        /// <summary>
        /// the full constructor that takes the length of the history, the number of gaussian mixtures, the background ratio parameter and the noise strength
        /// </summary>
        /// <param name="history"></param>
        /// <param name="varThreshold"></param>
        /// <param name="bShadowDetection"></param>
        public BackgroundSubtractorMOG2(int history, float varThreshold, bool bShadowDetection = true)
        {
            IntPtr po = NativeMethods.video_BackgroundSubtractorMOG2_new2(history, varThreshold, bShadowDetection ? 1 : 0);
            if (po == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create BackgroundSubtractorMOG2");
            objectPtr = new Ptr<BackgroundSubtractorMOG2>(po);
            ptr = objectPtr.Obj;
        }

        internal BackgroundSubtractorMOG2(Ptr<BackgroundSubtractorMOG2> objectPtr, IntPtr ptr)
        {
            this.objectPtr = objectPtr;
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates instance from cv::Ptr&lt;T&gt; .
        /// ptr is disposed when the wrapper disposes. 
        /// </summary>
        /// <param name="ptr"></param>
        internal static new BackgroundSubtractorMOG2 FromPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid BackgroundSubtractorMOG2 pointer");

            var ptrObj = new Ptr<BackgroundSubtractorMOG2>(ptr);
            var obj = new BackgroundSubtractorMOG2(ptrObj, ptrObj.Obj);
            return obj;
        }
        /// <summary>
        /// Creates instance from raw T*
        /// </summary>
        /// <param name="ptr"></param>
        internal static new BackgroundSubtractorMOG2 FromRawPtr(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Invalid BackgroundSubtractorMOG2 pointer");
            var obj = new BackgroundSubtractorMOG2(null, ptr);
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
                                NativeMethods.video_BackgroundSubtractorMOG_delete(ptr);
                        }
                        objectPtr = null;
                        ptr = IntPtr.Zero;
                    }
                    disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        /// <summary>
        /// the update operator
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fgmask"></param>
        /// <param name="learningRate"></param>
        public override void Run(InputArray image, OutputArray fgmask, double learningRate = -1.0)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (fgmask == null)
                throw new ArgumentNullException("fgmask");
            image.ThrowIfDisposed();
            fgmask.ThrowIfNotReady();
            NativeMethods.video_BackgroundSubtractorMOG2_operator(ptr, image.CvPtr, fgmask.CvPtr, learningRate);
            fgmask.Fix();
        }

        /// <summary>
        /// computes a background image
        /// </summary>
        /// <param name="backgroundImage"></param>
        public override void GetBackgroundImage(OutputArray backgroundImage)
        {
            if (backgroundImage == null)
                throw new ArgumentNullException("backgroundImage");
            backgroundImage.ThrowIfNotReady();
            NativeMethods.video_BackgroundSubtractorMOG2_getBackgroundImage(ptr, backgroundImage.CvPtr);
            backgroundImage.Fix();
        }

        /// <summary>
        /// re-initiaization method
        /// </summary>
        /// <param name="frameSize"></param>
        /// <param name="frameType"></param>
        public virtual void Initialize(Size frameSize, int frameType)
        {
            NativeMethods.video_BackgroundSubtractorMOG2_initialize(ptr, frameSize, frameType);
        }

        /// <summary>
        /// Pointer to algorithm information (cv::AlgorithmInfo*)
        /// </summary>
        /// <returns></returns>
        public override IntPtr InfoPtr
        {
            get { return NativeMethods.video_BackgroundSubtractorMOG2_info(ptr); }
        }
    }
}