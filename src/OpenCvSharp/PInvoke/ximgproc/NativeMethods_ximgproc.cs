using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ximgproc_niBlackThreshold(
            IntPtr src, IntPtr dst, double maxValue, int type,
            int blockSize, double delta);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ximgproc_thinning(IntPtr src, IntPtr dst, int thinningType);
    }
}