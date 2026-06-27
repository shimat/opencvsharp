using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // RFFeatureGetter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createRFFeatureGetter(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_RFFeatureGetter_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_RFFeatureGetter_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_RFFeatureGetter_getFeatures(
        OpenCvSafeHandle obj, IntPtr src, IntPtr features,
        int gnrmRad, int gsmthRad, int shrink, int outNum, int gradNum);


    // StructuredEdgeDetection

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createStructuredEdgeDetection(
        [MarshalAs(UnmanagedType.LPStr)] string model, IntPtr howToGetFeatures, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_StructuredEdgeDetection_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_StructuredEdgeDetection_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_StructuredEdgeDetection_detectEdges(
        OpenCvSafeHandle obj, IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_StructuredEdgeDetection_computeOrientation(
        OpenCvSafeHandle obj, IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_StructuredEdgeDetection_edgesNms(
        OpenCvSafeHandle obj, IntPtr edge_image, IntPtr orientation_image, IntPtr dst,
        int r, int s, float m, int isParallel);


}
