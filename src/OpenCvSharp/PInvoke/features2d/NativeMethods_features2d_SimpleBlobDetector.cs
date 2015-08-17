using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_SimpleBlobDetector_create(
            ref SimpleBlobDetector.WParams parameters);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_Ptr_SimpleBlobDetector_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Ptr_SimpleBlobDetector_delete(IntPtr ptr);
    }
}