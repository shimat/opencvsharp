using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvGraphEdge
    {
        public int flags;
        public float weight;

        public void* next1;
        public void* next2;

        public void* vtx1;
        public void* vtx2;
    }
}
