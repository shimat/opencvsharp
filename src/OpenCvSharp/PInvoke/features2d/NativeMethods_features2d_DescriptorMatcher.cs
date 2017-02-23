using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // DescriptorMatcher
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_add(IntPtr obj, IntPtr[] descriptors,
            int descriptorLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_getTrainDescriptors(IntPtr obj,
            IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_DescriptorMatcher_empty(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_DescriptorMatcher_isMaskSupported(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_train(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_match1(IntPtr obj,
            IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_knnMatch1(IntPtr obj,
            IntPtr queryDescriptors, IntPtr trainDescriptors, IntPtr matches, int k,
            IntPtr mask, int compactResult);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_radiusMatch1(IntPtr obj,
            IntPtr queryDescriptors,IntPtr trainDescriptors, IntPtr matches, float maxDistance,
            IntPtr mask, int compactResult);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_match2(
            IntPtr obj, IntPtr queryDescriptors, IntPtr matches,
            IntPtr[] masks, int masksSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_knnMatch2(
            IntPtr obj, IntPtr queryDescriptors, IntPtr matches,
            int k, IntPtr[] masks, int masksSize, int compactResult);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorMatcher_radiusMatch2(
            IntPtr obj, IntPtr queryDescriptors, IntPtr matches,
            float maxDistance, IntPtr[] masks, int masksSize, int compactResult);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern IntPtr features2d_DescriptorMatcher_create([MarshalAs(UnmanagedType.LPStr)] string descriptorMatcherType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_Ptr_DescriptorMatcher_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_Ptr_DescriptorMatcher_delete(IntPtr ptr);

        // BFMatcher
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_BFMatcher_new(int normType, int crossCheck);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_BFMatcher_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_BFMatcher_isMaskSupported(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_Ptr_BFMatcher_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_Ptr_BFMatcher_delete(IntPtr ptr);

        // FlannBasedMatcher
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_FlannBasedMatcher_new(
            IntPtr indexParams, IntPtr searchParams);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_FlannBasedMatcher_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_FlannBasedMatcher_add(
            IntPtr obj, IntPtr[] descriptors, int descriptorsSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_FlannBasedMatcher_clear(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_FlannBasedMatcher_train(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_FlannBasedMatcher_isMaskSupported(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_Ptr_FlannBasedMatcher_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_Ptr_FlannBasedMatcher_delete(IntPtr ptr);

    }
}