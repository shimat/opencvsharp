using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvStereoGCState
    {
        public int Ithreshold;
        public int interactionRadius;
        public float K, lambda, lambda1, lambda2;
        public int occlusionCost;
        public int minDisparity;
        public int numberOfDisparities;
        public int maxIters;

        public void* left;
        public void* right;
        public void* dispLeft;
        public void* dispRight;
        public void* ptrLeft;
        public void* ptrRight;
        public void* vtxBuf;
        public void* edgeBuf;
    }
}
