using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // SuperpixelLSC

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_SuperpixelLSC_delete(
        IntPtr obj);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_SuperpixelLSC_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelLSC_getNumberOfSuperpixels(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelLSC_iterate(
        IntPtr obj, int num_iterations);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelLSC_getLabels(
        IntPtr obj, IntPtr labels_out);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelLSC_getLabelContourMask(
        IntPtr obj, IntPtr image, int thick_line);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelLSC_enforceLabelConnectivity(
        IntPtr obj, int min_element_size);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createSuperpixelLSC(
        IntPtr image, int region_size, float ratio, out IntPtr returnValue);


    // SuperpixelSEEDS

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_SuperpixelSEEDS_delete(
        IntPtr obj);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_SuperpixelSEEDS_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelSEEDS_getNumberOfSuperpixels(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelSEEDS_iterate(
        IntPtr obj, IntPtr img, int num_iterations);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelSEEDS_getLabels(
        IntPtr obj, IntPtr labels_out);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelSEEDS_getLabelContourMask(
        IntPtr obj, IntPtr image, int thick_line);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createSuperpixelSEEDS(
        int image_width, int image_height, int image_channels,
        int num_superpixels, int num_levels, int prior,
        int histogram_bins, int double_step,
        out IntPtr returnValue);


    // SuperpixelSLIC

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_SuperpixelSLIC_delete(
        IntPtr obj);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_SuperpixelSLIC_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelSLIC_getNumberOfSuperpixels(
        IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelSLIC_iterate(
        IntPtr obj, int num_iterations);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelSLIC_getLabels(
        IntPtr obj, IntPtr labels_out);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelSLIC_getLabelContourMask(
        IntPtr obj, IntPtr image, int thick_line);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_SuperpixelSLIC_enforceLabelConnectivity(
        IntPtr obj, int min_element_size);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createSuperpixelSLIC(
        IntPtr image, int algorithm, int region_size, float ruler, out IntPtr returnValue);



}
