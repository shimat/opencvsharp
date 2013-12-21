using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvHaarClassifier
    {
        public int count;
        public void* haar_feature;
        public float* threshold;
        public int* left;
        public int* right;
        public float* alpha;
    }
}
