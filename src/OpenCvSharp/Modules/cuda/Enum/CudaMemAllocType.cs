#if ENABLED_CUDA

using System;

namespace OpenCvSharp.Cuda
{
#pragma warning disable 1591

    [Flags]
    public enum CudaMemAllocType
    {
        Locked = 1,
        ZeroCopy = 2,
        WhiteCombined = 4
    }
}

#endif
