using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// 
    /// </summary>
    public abstract class DenseOpticalFlow : Algorithm
    {
        #region Init & Disposal

        /// <summary>
        /// 
        /// </summary>
        protected DenseOpticalFlow()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DenseOpticalFlow CreateOptFlow_DualTVL1()
        {
            IntPtr ptr = NativeMethods.video_createOptFlow_DualTVL1();
            return DenseOpticalFlowImpl.FromPtr(ptr);
        }

        #endregion

        /// <summary>
        /// Clear all inner buffers.
        /// </summary>
        public virtual void CollectGarbage()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame0"></param>
        /// <param name="frame1"></param>
        /// <param name="flow"></param>
        protected abstract void Calc(InputArray frame0, InputArray frame1, InputOutputArray flow);
    }
}
