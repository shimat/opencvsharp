using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // DescriptorExtractor
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorExtractor_delete(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorExtractor_compute1(
            IntPtr obj, IntPtr image, IntPtr keypoint, IntPtr descriptors);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_DescriptorExtractor_compute2(
            IntPtr obj, IntPtr[] images, int imagesSize, IntPtr keypoints, 
            IntPtr[] descriptors, int descriptorsSize);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_DescriptorExtractor_descriptorSize(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_DescriptorExtractor_descriptorType(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int features2d_DescriptorExtractor_empty(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_DescriptorExtractor_create(
            [MarshalAs(UnmanagedType.LPStr)] string descriptorExtractorType);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr features2d_Ptr_DescriptorExtractor_get(IntPtr ptr);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void features2d_Ptr_DescriptorExtractor_delete(IntPtr ptr);
    }
}