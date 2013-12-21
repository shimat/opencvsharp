using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct WCvMat
    {
        public int type;
        public int step;

        public int* refcount;
        public int hdr_refcount;

        public void* data;

        public int rows;
        public int cols;
    }
}
