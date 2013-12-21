using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct WCvStarDetectorParams
    {
        public int maxSize;
        public int responseThreshold;
        public int lineThresholdProjected;
        public int lineThresholdBinarized;
        public int suppressNonmaxSize;
    }
}
