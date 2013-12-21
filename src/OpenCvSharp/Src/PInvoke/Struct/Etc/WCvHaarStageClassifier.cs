using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvHaarStageClassifier
    {
        public int count;
        public float threshold;
        public void* classifier;

        public int next;
        public int child;
        public int parent;
    }
}
