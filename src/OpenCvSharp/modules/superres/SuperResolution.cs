using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
        protected FrameSource frameSource;
        /// <summary>
        /// 
        /// </summary>
        protected bool firstCall;

        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected SuperResolution()
        {
            frameSource = null;
            firstCall = true;
        }

        /// <summary>
        /// Create Bilateral TV-L1 Super Resolution.
        /// </summary>
        /// <returns></returns>
        public static SuperResolution CreateBTVL1()
        {
            IntPtr ptr = NativeMethods.superres_createSuperResolution_BTVL1();
            return SuperResolutionImpl.FromPtr(ptr);
        }
        /// <summary>
        /// Create Bilateral TV-L1 Super Resolution.
        /// </summary>
        /// <returns></returns>
        public static SuperResolution CreateBTVL1_CUDA()
        {
            IntPtr ptr = NativeMethods.superres_createSuperResolution_BTVL1_CUDA();
            return SuperResolutionImpl.FromPtr(ptr);
        }
        /// <summary>
        /// Create Bilateral TV-L1 Super Resolution.
        /// </summary>
        /// <returns></returns>
        public static SuperResolution CreateBTVL1_OCL()
        {
            throw new NotImplementedException();
            //IntPtr ptr = NativeMethods.superres_createSuperResolution_BTVL1_OCL();
            //return SuperResolutionImpl.FromPtr(ptr);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Set input frame source for Super Resolution algorithm.
        /// </summary>
        /// <param name="fs">Input frame source</param>
        public virtual void SetInput(FrameSource fs)
        {
            frameSource = fs;
        }

        /// <summary>
        /// Process next frame from input and return output result.
        /// </summary>
        /// <param name="frame">Output result</param>
        public virtual void NextFrame(OutputArray frame)
        {
            if (firstCall)
            {
                InitImpl(frameSource);
                firstCall = false;
            }

            ProcessImpl(frameSource, frame);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Reset()
        {
            frameSource.Reset();
            firstCall = true; 
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
