#if ENABLED_CUDA

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Cuda
{
#pragma warning disable 1591

    public enum FeatureSet
    {
        Compute10 = 10,
        Compute11 = 11,
        Compute12 = 12,
        Compute13 = 13,
        Compute20 = 20,
        Compute21 = 21,
        Compute30 = 30,
        Compute35 = 35,

        GlobalAtomics = Compute11,
        SharedAtomics = Compute12,
        NativeDouble = Compute13,
        WarpShuffleFunctions = Compute30,
        DynamicParallelism = Compute35
    }
}

#endif
