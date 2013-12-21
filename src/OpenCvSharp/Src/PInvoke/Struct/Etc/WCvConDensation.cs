using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvConDensation
    {
        public int MP;
        public int DP;
        public float* DynamMatr;
        public float* State;
        public int SamplesNum;
        public float** flSamples;
        public float** flNewSamples;
        public float* flConfidence;
        public float* flCumulative;
        public float* Temp;
        public float* RandomSample;
        public void* RandS;
    }
}
