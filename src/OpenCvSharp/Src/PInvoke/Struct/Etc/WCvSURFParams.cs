using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct WCvSURFParams
    {
        public int extended;
        public double hessianThreshold;
        public int nOctaves;
        public int nOctaveLayers;
    }
}
