using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvBGCodeBookElem
    {
        public WCvBGCodeBookElem* next;
        public int tLastUpdate;
        public int stale;
        public fixed byte boxMin[3];
        public fixed byte boxMax[3];
        public fixed byte learnMin[3];
        public fixed byte learnMax[3];
    }
}
