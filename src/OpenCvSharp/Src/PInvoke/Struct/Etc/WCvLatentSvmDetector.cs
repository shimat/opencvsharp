/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

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
