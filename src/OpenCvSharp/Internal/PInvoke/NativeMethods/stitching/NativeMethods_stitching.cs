using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_create(int mode, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Ptr_Stitcher_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Ptr_Stitcher_get(IntPtr obj, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_registrationResol(IntPtr obj, out double returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_setRegistrationResol(IntPtr obj, double resolMpx);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_seamEstimationResol(IntPtr obj, out double returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_setSeamEstimationResol(IntPtr obj, double resolMpx);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_compositingResol(IntPtr obj, out double returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_setCompositingResol(IntPtr obj, double resolMpx);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_panoConfidenceThresh(IntPtr obj, out double returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_setPanoConfidenceThresh(IntPtr obj, double confThresh);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_waveCorrection(IntPtr obj, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_setWaveCorrection(IntPtr obj, int flag);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_waveCorrectKind(IntPtr obj, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_setWaveCorrectKind(IntPtr obj, int kind);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_estimateTransform_InputArray1(
            IntPtr obj, IntPtr images, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_estimateTransform_InputArray2(
            IntPtr obj, IntPtr images,
            IntPtr[] rois, int roisSize1, int[] roisSize2, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_estimateTransform_MatArray1(
            IntPtr obj, IntPtr[] images, int imagesSize, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_estimateTransform_MatArray2(
            IntPtr obj, IntPtr[] images, int imagesSize,
            IntPtr[] rois, int roisSize1, int[] roisSize2, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_composePanorama1(
            IntPtr obj, IntPtr pano, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_composePanorama2_InputArray(
            IntPtr obj, IntPtr images, IntPtr pano, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_composePanorama2_MatArray(
            IntPtr obj, IntPtr[] images, int imagesSize, IntPtr pano, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_stitch1_InputArray(
            IntPtr obj, IntPtr images, IntPtr pano, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_stitch1_MatArray(
            IntPtr obj, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] images, int imagesSize, 
            IntPtr pano, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_stitch2_InputArray(
            IntPtr obj, IntPtr images,
            IntPtr[] rois, int roisSize1, int[] roisSize2,
            IntPtr pano, out int returnValue);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_stitch2_MatArray(
            IntPtr obj, IntPtr[] images, int imagesSize,
            IntPtr[] rois, int roisSize1, int[] roisSize2,
            IntPtr pano, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_component(IntPtr obj, IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus stitching_Stitcher_workScale(IntPtr obj, out double returnValue);
    }
}