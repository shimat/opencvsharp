using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvLSVMFilterObject
    {
        public CvLSVMFilterPosition V;
        public fixed float fineFunction[4];
        public int sizeX;
        public int sizeY;
        public int numFeatures;
        public float *H;
    }
}
