using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    //#define CV_HAAR_FEATURE_MAX  3

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvHaarFeature
    {
        public int tilted;

        public CvRect rect1_r;
        public float rect1_weight;
        public CvRect rect2_r;
        public float rect2_weight;
        public CvRect rect3_r;
        public float rect3_weight;
    }
}
