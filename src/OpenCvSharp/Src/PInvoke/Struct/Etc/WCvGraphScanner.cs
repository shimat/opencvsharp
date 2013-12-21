using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvGraphScanner
    {
        public void* vtx;
        public void* dst;
        public void* edge;

        public void* graph;
        public void* stack;
        public int index;
        public int mask;
    }
}
