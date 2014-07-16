using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stitching_Stitcher_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stitching_Stitcher_createDefault(int tryUseGpu);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_stitch1_InputArray(
            IntPtr obj, IntPtr images, IntPtr pano);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_stitch1_array(
            IntPtr obj, IntPtr[] images, int imagesCount, IntPtr pano);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_stitch2(
            IntPtr obj, IntPtr images, IntPtr rois, IntPtr pano);
    }
}