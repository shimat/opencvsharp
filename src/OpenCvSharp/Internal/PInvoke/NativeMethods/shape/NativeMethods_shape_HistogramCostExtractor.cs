using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // HistogramCostExtractor base class

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_HistogramCostExtractor_buildCostMatrix(
        IntPtr obj, IntPtr descriptors1, IntPtr descriptors2, IntPtr costMatrix);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_HistogramCostExtractor_setNDummies(IntPtr obj, int val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_HistogramCostExtractor_getNDummies(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_HistogramCostExtractor_setDefaultCost(IntPtr obj, float val);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_HistogramCostExtractor_getDefaultCost(IntPtr obj, out float returnValue);

    // Ptr<HistogramCostExtractor> lifetime management (shared across all subclasses)

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_Ptr_HistogramCostExtractor_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_Ptr_HistogramCostExtractor_get(IntPtr obj, out IntPtr returnValue);

    // NormHistogramCostExtractor

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_createNormHistogramCostExtractor(
        int flag, int nDummies, float defaultCost, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_NormHistogramCostExtractor_setNormFlag(IntPtr obj, int flag);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_NormHistogramCostExtractor_getNormFlag(IntPtr obj, out int returnValue);

    // EMDHistogramCostExtractor

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_createEMDHistogramCostExtractor(
        int flag, int nDummies, float defaultCost, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_EMDHistogramCostExtractor_setNormFlag(IntPtr obj, int flag);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_EMDHistogramCostExtractor_getNormFlag(IntPtr obj, out int returnValue);

    // ChiHistogramCostExtractor

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_createChiHistogramCostExtractor(
        int nDummies, float defaultCost, out IntPtr returnValue);

    // EMDL1HistogramCostExtractor

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_createEMDL1HistogramCostExtractor(
        int nDummies, float defaultCost, out IntPtr returnValue);

    // EMDL1 free function

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus shape_EMDL1(
        IntPtr signature1, IntPtr signature2, out float returnValue);
}