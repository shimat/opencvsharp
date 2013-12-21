using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvMatND
    {
        public int type;
        public int dims;

        public int* refcount;
        public int hdr_refcount;

        public void* data;

        public fixed int dim[CvConst.CV_MAX_DIM * 2];
    }

}
