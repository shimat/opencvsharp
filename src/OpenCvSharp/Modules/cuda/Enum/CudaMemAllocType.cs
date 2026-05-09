#if ENABLED_CUDA

using System;

namespace OpenCvSharp.Cuda
{
#pragma warning disable 1591

    [Flags]
    public enum CudaMemAllocType
    {
        /// <summary>
        /// 
        /// </summary>
        Locked = 1,

        /// <summary>
        /// 
        /// </summary>
        ZeroCopy = 2,

        /// <summary>
        /// 
        /// </summary>
        WhiteCombined = 4
    }
}

#endif
