#if ENABLED_CUDA

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Cuda
{
#pragma warning disable 1591

    public enum FeatureSet
    {
        /// <summary>
        /// Compute Capability 1.0. The baseline for CUDA support (Tesla architecture).
        /// </summary>
        Compute10 = 10,

        /// <summary>
        /// Compute Capability 1.1. Introduced atomic functions operating on global memory.
        /// </summary>
        Compute11 = 11,

        /// <summary>
        /// Compute Capability 1.2. Introduced atomic functions operating on shared memory and warp vote functions.
        /// </summary>
        Compute12 = 12,

        /// <summary>
        /// Compute Capability 1.3. Introduced double precision floating point (FP64) support.
        /// </summary>
        Compute13 = 13,

        /// <summary>
        /// Compute Capability 2.0. Fermi architecture. Introduced L1/L2 cache, improved atomic performance, and concurrent kernel execution.
        /// </summary>
        Compute20 = 20,

        /// <summary>
        /// Compute Capability 2.1. Fermi refresh. Optimized for higher numbers of cores and throughput.
        /// </summary>
        Compute21 = 21,

        /// <summary>
        /// Compute Capability 3.0. Kepler architecture. Introduced Warp Shuffle functions and significantly higher core counts.
        /// </summary>
        Compute30 = 30,

        /// <summary>
        /// Compute Capability 3.5. Kepler refresh. Introduced Dynamic Parallelism (kernels launching kernels).
        /// </summary>
        Compute35 = 35,

        /// <summary>
        /// Hardware support for atomic operations on global memory (corresponds to Compute 1.1).
        /// </summary>
        GlobalAtomics = Compute11,

        /// <summary>
        /// Hardware support for atomic operations on shared memory (corresponds to Compute 1.2).
        /// </summary>
        SharedAtomics = Compute12,

        /// <summary>
        /// Hardware support for native 64-bit double precision floating point math (corresponds to Compute 1.3).
        /// </summary>
        NativeDouble = Compute13,

        /// <summary>
        /// Hardware support for __shfl, __shfl_up, __shfl_down, and __shfl_xor (corresponds to Compute 3.0).
        /// </summary>
        WarpShuffleFunctions = Compute30,

        /// <summary>
        /// Hardware support for kernels to launch other kernels directly on the GPU (corresponds to Compute 3.5).
        /// </summary>
        DynamicParallelism = Compute35
    }
}

#endif
