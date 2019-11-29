using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr objdetect_LatentSvmDetector_new();
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_LatentSvmDetector_delete(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_LatentSvmDetector_clear(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int objdetect_LatentSvmDetector_empty(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int objdetect_LatentSvmDetector_load(IntPtr obj,
            IntPtr[] fileNames, int fileNamesLength,
            IntPtr[] classNames, int classNamesLength);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_LatentSvmDetector_detect(
            IntPtr obj, IntPtr image, IntPtr objectDetections,
            float overlapThreshold, int numThreads);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_LatentSvmDetector_getClassNames(IntPtr obj, IntPtr outValues);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr objdetect_LatentSvmDetector_getClassCount(IntPtr obj);
    }
}