using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region QualityBase

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_QualityBase_compute(OpenCvSafeHandle obj, in InputArrayProxy img, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_QualityBase_getQualityMap(OpenCvSafeHandle obj, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_QualityBase_clear(OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_QualityBase_empty(OpenCvSafeHandle obj, out int returnValue);

    #endregion

    #region QualityPSNR

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_createQualityPSNR(in InputArrayProxy @ref, double maxPixelValue, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualityPSNR_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_QualityPSNR_staticCompute(
        in InputArrayProxy @ref, in InputArrayProxy cmp, in OutputArrayProxy qualityMap, double maxPixelValue, out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_QualityPSNR_getMaxPixelValue(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_QualityPSNR_setMaxPixelValue(OpenCvSafeHandle obj, double val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualityPSNR_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region QualitySSIM

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_createQualitySSIM(in InputArrayProxy @ref, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualitySSIM_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualitySSIM_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_QualitySSIM_staticCompute(
        in InputArrayProxy @ref, in InputArrayProxy cmp, in OutputArrayProxy qualityMap, out Scalar returnValue);

    #endregion

    #region QualityGMSD

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_createQualityGMSD(in InputArrayProxy @ref, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualityGMSD_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualityGMSD_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_QualityGMSD_staticCompute(
        in InputArrayProxy @ref, in InputArrayProxy cmp, in OutputArrayProxy qualityMap, out Scalar returnValue);

    #endregion

    #region QualityMSE

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_createQualityMSE(in InputArrayProxy @ref, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualityMSE_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualityMSE_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_QualityMSE_staticCompute(
        in InputArrayProxy @ref, in InputArrayProxy cmp, in OutputArrayProxy qualityMap, out Scalar returnValue);

    #endregion

    #region QualityBRISQUE

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_createQualityBRISQUE1(
        [MarshalAs(UnmanagedType.LPStr)] string modelFilePath,
        [MarshalAs(UnmanagedType.LPStr)] string rangeFilePath, 
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_createQualityBRISQUE2(IntPtr model, IntPtr range, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualityBRISQUE_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus quality_Ptr_QualityBRISQUE_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_QualityBRISQUE_staticCompute(
        in InputArrayProxy @ref, 
        [MarshalAs(UnmanagedType.LPStr)] string modelFilePath, 
        [MarshalAs(UnmanagedType.LPStr)] string rangeFilePath,
        out Scalar returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus quality_QualityBRISQUE_computeFeatures(in InputArrayProxy img, in OutputArrayProxy features);

    #endregion
}
