using System;
using System.Collections.Generic;

namespace OpenCvSharp
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
        public abstract void Calc(InputArray frame0, InputArray frame1, InputOutputArray flow);
    }
}
