/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    internal static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_DescriptorMatcher_add(IntPtr obj, IntPtr[] descriptors,
            int descriptorLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_DescriptorMatcher_getTrainDescriptors(IntPtr obj,
            IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_DescriptorMatcher_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_DescriptorMatcher_empty(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_DescriptorMatcher_isMaskSupported(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_DescriptorMatcher_train(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_DescriptorMatcher_match(IntPtr obj,
            IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_DescriptorMatcher_knnMatch(IntPtr obj,
            IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, int k,
            IntPtr mask, int compactResult);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_DescriptorMatcher_radiusMatch(IntPtr obj,
            IntPtr queryDescriptors,IntPtr trainDescriptors, IntPtr matches, float maxDistance,
            IntPtr mask, int compactResult);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr features2d_DescriptorMatcher_create([MarshalAs(UnmanagedType.LPStr)] string descriptorMatcherType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_DescriptorMatcher_info(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_BFMatcher_new(int normType, int crossCheck);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_BFMatcher_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_BFMatcher_isMaskSupported(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_BFMatcher_info(IntPtr obj);

    }
}