using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region QualityBase

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityBase_compute(IntPtr obj, IntPtr img, out Scalar returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityBase_getQualityMap(IntPtr obj, IntPtr dst);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityBase_clear(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityBase_empty(IntPtr obj, out int returnValue);

    #endregion

    #region QualityPSNR

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_createQualityPSNR(IntPtr @ref, double maxPixelValue, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualityPSNR_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityPSNR_staticCompute(
        IntPtr @ref, IntPtr cmp, IntPtr qualityMap, double maxPixelValue, out Scalar returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityPSNR_getMaxPixelValue(IntPtr obj, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityPSNR_setMaxPixelValue(IntPtr obj, double val);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualityPSNR_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region QualitySSIM

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_createQualitySSIM(IntPtr @ref, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualitySSIM_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualitySSIM_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualitySSIM_staticCompute(
        IntPtr @ref, IntPtr cmp, IntPtr qualityMap, out Scalar returnValue);

    #endregion

    #region QualityGMSD

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_createQualityGMSD(IntPtr @ref, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualityGMSD_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualityGMSD_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityGMSD_staticCompute(
        IntPtr @ref, IntPtr cmp, IntPtr qualityMap, out Scalar returnValue);

    #endregion

    #region QualityMSE

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_createQualityMSE(IntPtr @ref, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualityMSE_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualityMSE_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityMSE_staticCompute(
        IntPtr @ref, IntPtr cmp, IntPtr qualityMap, out Scalar returnValue);

    #endregion

    #region QualityBRISQUE

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_createQualityBRISQUE1(
        [MarshalAs(UnmanagedType.LPStr)] string modelFilePath,
        [MarshalAs(UnmanagedType.LPStr)] string rangeFilePath, 
        out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_createQualityBRISQUE2(IntPtr model, IntPtr range, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualityBRISQUE_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_Ptr_QualityBRISQUE_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityBRISQUE_staticCompute(
        IntPtr @ref, 
        [MarshalAs(UnmanagedType.LPStr)] string modelFilePath, 
        [MarshalAs(UnmanagedType.LPStr)] string rangeFilePath,
        out Scalar returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus quality_QualityBRISQUE_computeFeatures(IntPtr img, IntPtr features);

    #endregion
}
