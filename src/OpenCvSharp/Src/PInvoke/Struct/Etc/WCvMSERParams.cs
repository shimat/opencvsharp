using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct WCvMSERParams
    {
        public int delta;
        public int maxArea;
        public int minArea;
        public float maxVariation;
        public float minDiversity;
        /* the next few params for MSER of color image */
        public int maxEvolution;
        public double areaThreshold;
        public double minMargin;
        public int edgeBlurSize;
    }
}
