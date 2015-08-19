using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_Ptr_Feature2D_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Ptr_Feature2D_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Feature2D_detect_Mat1(IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Feature2D_detect_Mat2(IntPtr detector, IntPtr[] images, int imageLength, IntPtr keypoints, IntPtr[] mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Feature2D_detect_InputArray(IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Feature2D_compute1(IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr descriptors);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Feature2D_compute2(
            IntPtr detector, IntPtr[] images, int imageLength,
            IntPtr keypoints, IntPtr[] descriptors, int descriptorsLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Feature2D_detectAndCompute(
            IntPtr detector, IntPtr image, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_Feature2D_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_Feature2D_descriptorType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_Feature2D_defaultNorm(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_Feature2D_empty(IntPtr obj);
    }
}