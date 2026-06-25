using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // HistogramCostExtractor base class

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_HistogramCostExtractor_buildCostMatrix(
        IntPtr obj, IntPtr descriptors1, IntPtr descriptors2, IntPtr costMatrix);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_HistogramCostExtractor_setNDummies(IntPtr obj, int val);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_HistogramCostExtractor_getNDummies(IntPtr obj, out int returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_HistogramCostExtractor_setDefaultCost(IntPtr obj, float val);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_HistogramCostExtractor_getDefaultCost(IntPtr obj, out float returnValue);

    // Ptr<HistogramCostExtractor> lifetime management (shared across all subclasses)

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_HistogramCostExtractor_delete(IntPtr obj);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_Ptr_HistogramCostExtractor_get(IntPtr obj, out IntPtr returnValue);

    // NormHistogramCostExtractor

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_createNormHistogramCostExtractor(
        int flag, int nDummies, float defaultCost, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_NormHistogramCostExtractor_setNormFlag(IntPtr obj, int flag);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_NormHistogramCostExtractor_getNormFlag(IntPtr obj, out int returnValue);

    // EMDHistogramCostExtractor

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_createEMDHistogramCostExtractor(
        int flag, int nDummies, float defaultCost, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_EMDHistogramCostExtractor_setNormFlag(IntPtr obj, int flag);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_EMDHistogramCostExtractor_getNormFlag(IntPtr obj, out int returnValue);

    // ChiHistogramCostExtractor

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_createChiHistogramCostExtractor(
        int nDummies, float defaultCost, out IntPtr returnValue);

    // EMDL1HistogramCostExtractor

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_createEMDL1HistogramCostExtractor(
        int nDummies, float defaultCost, out IntPtr returnValue);

    // EMDL1 free function

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus shape_EMDL1(
        IntPtr signature1, IntPtr signature2, out float returnValue);
}