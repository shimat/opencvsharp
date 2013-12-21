using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvHistogram
    {
        public int type;
        public void* bins;
        public fixed float thresh[CvConst.CV_MAX_DIM * 2];
        public float** thresh2;
        public WCvMatND mat;
    }
}
