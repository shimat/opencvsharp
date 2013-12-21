using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvStereoBMState
    {
        public int preFilterType;
        public int preFilterSize;
        public int preFilterCap;

        public int SADWindowSize;
        public int minDisparity;
        public int numberOfDisparities;

        public int textureThreshold;
        public int uniquenessRatio;
        public int speckleWindowSize;
        public int speckleRange;

        public void* preFilteredImg0;
        public void* preFilteredImg1;
        public void* slidingSumBuf;
    }
}
