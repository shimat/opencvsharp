using System;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// The Base Class for Background/Foreground Segmentation.
    /// The class is only used to define the common interface for
    /// the whole family of background/foreground segmentation algorithms.
    /// </summary>
    public class BackgroundSubtractorMOG : BackgroundSubtractor
    {
        /// <summary>
        /// sizeof(BackgroundSubtractorMOG)
        /// </summary>
        public static new readonly int SizeOf = NativeMethods.video_BackgroundSubtractorMOG_sizeof().ToInt32();

        #region Init
        /// <summary>
        /// the default constructor
        /// </summary>
        public BackgroundSubtractorMOG()
        {
            ptr = NativeMethods.video_BackgroundSubtractorMOG_new1();
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        /// <summary>
        /// the full constructor that takes the length of the history, the number of gaussian mixtures, the background ratio parameter and the noise strength
        /// </summary>
        /// <param name="history"></param>
        /// <param name="nmixtures"></param>
        /// <param name="backgroundRatio"></param>
        /// <param name="noiseSigma"></param>
        public BackgroundSubtractorMOG(int history, int nmixtures, double backgroundRatio, double noiseSigma=0)
        {
            ptr = NativeMethods.video_BackgroundSubtractorMOG_new2(history, nmixtures, backgroundRatio, noiseSigma);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException();
        }
        #endregion
        #region Dispose
#if LANG_JP
    /// <summary>
    /// リソースの解放
    /// </summary>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
#endif
        public void Release()
        {
            Dispose(true);
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
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {                        
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.video_BackgroundSubtractorMOG_delete(ptr);
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
        public override void Run(InputArray image, OutputArray fgmask, double learningRate = 0)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            if (fgmask == null)
                throw new ArgumentNullException("fgmask");
            image.ThrowIfDisposed();
            fgmask.ThrowIfNotReady();
            NativeMethods.video_BackgroundSubtractorMOG_operator(ptr, image.CvPtr, fgmask.CvPtr, learningRate);
            fgmask.Fix();
        }
    
        /// <summary>
        /// re-initiaization method
        /// </summary>
        /// <param name="frameSize"></param>
        /// <param name="frameType"></param>
        public virtual void Initialize(Size frameSize, int frameType)
        {
            NativeMethods.video_BackgroundSubtractorMOG_initialize(ptr, frameSize, frameType);
        }
        
        #region Properties
        /*
        /// <summary>
        /// 
        /// </summary>
        public CvSize FrameSize
        {
            get
            {
                return NativeMethods.BackgroundSubtractorMOG_frameSize_get(ptr);
            }
            set
            {
                NativeMethods.BackgroundSubtractorMOG_frameSize_set(ptr, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FrameType
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG_frameType(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG_frameType(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Mat BgModel
        {
            get
            {
                unsafe
                {
                    return new Mat(NativeMethods.BackgroundSubtractorMOG_bgmodel(ptr));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Nframes
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG_nframes(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG_nframes(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int History
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG_history(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG_history(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Nmixtures
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG_nmixtures(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG_nmixtures(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public double VarThreshold
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG_varThreshold(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG_varThreshold(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public double BackgroundRatio
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG_backgroundRatio(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG_backgroundRatio(ptr) = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public double NoiseSigma
        {
            get
            {
                unsafe
                {
                    return *NativeMethods.BackgroundSubtractorMOG_noiseSigma(ptr);
                }
            }
            set
            {
                unsafe
                {
                    *NativeMethods.BackgroundSubtractorMOG_noiseSigma(ptr) = value;
                }
            }
        }
        //*/
        #endregion
        
    }
}