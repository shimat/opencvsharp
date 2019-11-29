using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr stitching_Stitcher_create(int mode);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void stitching_Ptr_Stitcher_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr stitching_Ptr_Stitcher_get(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double stitching_Stitcher_registrationResol(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void stitching_Stitcher_setRegistrationResol(IntPtr obj, double resolMpx);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double stitching_Stitcher_seamEstimationResol(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void stitching_Stitcher_setSeamEstimationResol(IntPtr obj, double resolMpx);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double stitching_Stitcher_compositingResol(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void stitching_Stitcher_setCompositingResol(IntPtr obj, double resolMpx);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double stitching_Stitcher_panoConfidenceThresh(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void stitching_Stitcher_setPanoConfidenceThresh(IntPtr obj, double confThresh);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_waveCorrection(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void stitching_Stitcher_setWaveCorrection(IntPtr obj, int flag);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_waveCorrectKind(IntPtr obj);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void stitching_Stitcher_setWaveCorrectKind(IntPtr obj, int kind);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_estimateTransform_InputArray1(
            IntPtr obj, IntPtr images);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_estimateTransform_InputArray2(
            IntPtr obj, IntPtr images,
            IntPtr[] rois, int roisSize1, int[] roisSize2);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_estimateTransform_MatArray1(
            IntPtr obj, IntPtr[] images, int imagesSize);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_estimateTransform_MatArray2(
            IntPtr obj, IntPtr[] images, int imagesSize,
            IntPtr[] rois, int roisSize1, int[] roisSize2);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_composePanorama1(
            IntPtr obj, IntPtr pano);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_composePanorama2_InputArray(
            IntPtr obj, IntPtr images, IntPtr pano);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_composePanorama2_MatArray(
            IntPtr obj, IntPtr[] images, int imagesSize, IntPtr pano);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_stitch1_InputArray(
            IntPtr obj, IntPtr images, IntPtr pano);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_stitch1_MatArray(
            IntPtr obj, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] images, int imagesSize, IntPtr pano);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_stitch2_InputArray(
            IntPtr obj, IntPtr images,
            IntPtr[] rois, int roisSize1, int[] roisSize2,
            IntPtr pano);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int stitching_Stitcher_stitch2_MatArray(
            IntPtr obj, IntPtr[] images, int imagesSize,
            IntPtr[] rois, int roisSize1, int[] roisSize2,
            IntPtr pano);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void stitching_Stitcher_component(IntPtr obj, out IntPtr pointer, out int length);
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double stitching_Stitcher_workScale(IntPtr obj);
    }
}