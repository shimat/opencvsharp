using System;
using OpenCvSharp.Internal;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Base class for Super Resolution algorithms.
    /// </summary>
    public abstract class SuperResolution : Algorithm
    {
        /// <summary>
        /// 
        /// </summary>
        protected FrameSource? FrameSource{ get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected bool FirstCall { get; private set; }

        #region Init & Disposal

        /// <summary>
        /// Constructor
        /// </summary>
        protected SuperResolution()
        {
            FrameSource = null;
            FirstCall = true;
        }

        /// <summary>
        /// Create Bilateral TV-L1 Super Resolution.
        /// </summary>
        /// <returns></returns>
        public static SuperResolution CreateBTVL1()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_createSuperResolution_BTVL1(out var ptr));
            return SuperResolutionImpl.FromPtr(ptr);
        }

        /// <summary>
        /// Create Bilateral TV-L1 Super Resolution.
        /// </summary>
        /// <returns></returns>
        public static SuperResolution CreateBTVL1_CUDA()
        {
            NativeMethods.HandleException(
                NativeMethods.superres_createSuperResolution_BTVL1_CUDA(out var ptr));
            return SuperResolutionImpl.FromPtr(ptr);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Set input frame source for Super Resolution algorithm.
        /// </summary>
        /// <param name="fs">Input frame source</param>
        public virtual void SetInput(FrameSource fs)
        {
            FrameSource = fs;
        }

        /// <summary>
        /// Process next frame from input and return output result.
        /// </summary>
        /// <param name="frame">Output result</param>
        public virtual void NextFrame(OutputArray frame)
        {
            if (FrameSource == null)
                throw new NotSupportedException("frameSource == null");

            if (FirstCall)
            {
                InitImpl(FrameSource);
                FirstCall = false;
            }

            ProcessImpl(FrameSource, frame);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Reset()
        {
            if (FrameSource == null)
                throw new NotSupportedException("frameSource == null");

            FrameSource.Reset();
            FirstCall = true; 
        }

        /// <summary>
        /// Clear all inner buffers.
        /// </summary>
        public virtual void CollectGarbage()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>
        protected abstract void InitImpl(FrameSource fs);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="output"></param>
        protected abstract void ProcessImpl(FrameSource fs, OutputArray output);

        #endregion
    }
}
