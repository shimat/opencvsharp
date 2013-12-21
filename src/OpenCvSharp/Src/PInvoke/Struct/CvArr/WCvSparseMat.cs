using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvSparseMat
    {
        public int type;
        public int dims;
        public int* refcount;
        public int hdr_refcount;

        public void* heap;
        public void** hashtable;
        public int hashsize;
        public int valoffset;
        public int idxoffset;
        public fixed int size[CvConst.CV_MAX_DIM];
    }
}
