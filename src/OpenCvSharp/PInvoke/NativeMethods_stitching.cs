using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stitching_createStitcher(int try_use_cpu);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stitching_Ptr_Stitcher_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr stitching_Ptr_Stitcher_get(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double stitching_Stitcher_registrationResol(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stitching_Stitcher_setRegistrationResol(IntPtr obj, double resolMpx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double stitching_Stitcher_seamEstimationResol(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stitching_Stitcher_setSeamEstimationResol(IntPtr obj, double resolMpx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double stitching_Stitcher_compositingResol(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stitching_Stitcher_setCompositingResol(IntPtr obj, double resolMpx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double stitching_Stitcher_panoConfidenceThresh(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stitching_Stitcher_setPanoConfidenceThresh(IntPtr obj, double confThresh);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_waveCorrection(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stitching_Stitcher_setWaveCorrection(IntPtr obj, int flag);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_waveCorrectKind(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stitching_Stitcher_setWaveCorrectKind(IntPtr obj, int kind);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_estimateTransform_InputArray1(
            IntPtr obj, IntPtr images);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_estimateTransform_InputArray2(
            IntPtr obj, IntPtr images,
            IntPtr[] rois, int roisSize1, int[] roisSize2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_estimateTransform_MatArray1(
            IntPtr obj, IntPtr[] images, int imagesSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_estimateTransform_MatArray2(
            IntPtr obj, IntPtr[] images, int imagesSize,
            IntPtr[] rois, int roisSize1, int[] roisSize2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_composePanorama1(
            IntPtr obj, IntPtr pano);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_composePanorama2_InputArray(
            IntPtr obj, IntPtr images, IntPtr pano);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_composePanorama2_MatArray(
            IntPtr obj, IntPtr[] images, int imagesSize, IntPtr pano);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_stitch1_InputArray(
            IntPtr obj, IntPtr images, IntPtr pano);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_stitch1_MatArray(
            IntPtr obj, IntPtr[] images, int imagesSize, IntPtr pano);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_stitch2_InputArray(
            IntPtr obj, IntPtr images,
            IntPtr[] rois, int roisSize1, int[] roisSize2,
            IntPtr pano);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int stitching_Stitcher_stitch2_MatArray(
            IntPtr obj, IntPtr[] images, int imagesSize,
            IntPtr[] rois, int roisSize1, int[] roisSize2,
            IntPtr pano);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void stitching_Stitcher_component(IntPtr obj, out IntPtr pointer, out int length);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double stitching_Stitcher_workScale(IntPtr obj);
    }
}