using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ximgproc_weightedMedianFilter(
            IntPtr joint, IntPtr src, IntPtr dst,
            int r, double sigma, int weightType, IntPtr mask);
    }
}