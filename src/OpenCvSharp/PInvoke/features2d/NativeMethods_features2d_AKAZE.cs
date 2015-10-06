using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_AKAZE_create(
            int descriptor_type, int descriptor_size, int descriptor_channels,
            float threshold, int nOctaves, int nOctaveLayers, int diffusivity);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Ptr_AKAZE_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_Ptr_AKAZE_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_AKAZE_setDescriptorType(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_AKAZE_getDescriptorType(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_AKAZE_setDescriptorSize(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_AKAZE_getDescriptorSize(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_AKAZE_setDescriptorChannels(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_AKAZE_getDescriptorChannels(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_AKAZE_setThreshold(IntPtr obj, double val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double features2d_AKAZE_getThreshold(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_AKAZE_setNOctaves(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_AKAZE_getNOctaves(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_AKAZE_setNOctaveLayers(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_AKAZE_getNOctaveLayers(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_AKAZE_setDiffusivity(IntPtr obj, int val);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_AKAZE_getDiffusivity(IntPtr obj);
    }
}
