using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvBGCodeBookModel
    {
        public CvSize size;
        public int t;
        public fixed byte cbBounds[3];
        public fixed byte modMin[3];
        public fixed byte modMax[3];
        public WCvBGCodeBookElem** cbmap;
        public WCvMemStorage* storage;
        public WCvBGCodeBookElem* freeList;
    }
}
