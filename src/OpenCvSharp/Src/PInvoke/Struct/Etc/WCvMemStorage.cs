using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvMemStorage
    {
        public int signature;
        public void* bottom;
        public void* top;
        public void* parent;
        public int block_size;
        public int free_space;
    }
}
