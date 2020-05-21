using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // SuperpixelLSC

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_SuperpixelLSC_delete(
            IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_SuperpixelLSC_get(
            IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelLSC_getNumberOfSuperpixels(
            IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelLSC_iterate(
            IntPtr obj, int num_iterations);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelLSC_getLabels(
            IntPtr obj, IntPtr labels_out);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelLSC_getLabelContourMask(
            IntPtr obj, IntPtr image, int thick_line);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelLSC_enforceLabelConnectivity(
            IntPtr obj, int min_element_size);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createSuperpixelLSC(
            IntPtr image, int region_size, float ratio, out IntPtr returnValue);


        // SuperpixelSEEDS

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_SuperpixelSEEDS_delete(
            IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_SuperpixelSEEDS_get(
            IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelSEEDS_getNumberOfSuperpixels(
            IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelSEEDS_iterate(
            IntPtr obj, IntPtr img, int num_iterations);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelSEEDS_getLabels(
            IntPtr obj, IntPtr labels_out);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelSEEDS_getLabelContourMask(
            IntPtr obj, IntPtr image, int thick_line);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createSuperpixelSEEDS(
            int image_width, int image_height, int image_channels,
            int num_superpixels, int num_levels, int prior,
            int histogram_bins, int double_step,
            out IntPtr returnValue);


        // SuperpixelSLIC

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_SuperpixelSLIC_delete(
            IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_SuperpixelSLIC_get(
            IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelSLIC_getNumberOfSuperpixels(
            IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelSLIC_iterate(
            IntPtr obj, int num_iterations);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelSLIC_getLabels(
            IntPtr obj, IntPtr labels_out);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelSLIC_getLabelContourMask(
            IntPtr obj, IntPtr image, int thick_line);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_SuperpixelSLIC_enforceLabelConnectivity(
            IntPtr obj, int min_element_size);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createSuperpixelSLIC(
            IntPtr image, int algorithm, int region_size, float ruler, out IntPtr returnValue);
    }
}