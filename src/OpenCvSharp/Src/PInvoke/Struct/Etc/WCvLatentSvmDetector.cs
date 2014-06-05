using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvLatentSvmDetector
    {
        public int num_filters;
        public int num_components;
        public int* num_part_filters;
        public WCvLSVMFilterObject** filters;
        public float* b;
        public float score_threshold;
    }
}
