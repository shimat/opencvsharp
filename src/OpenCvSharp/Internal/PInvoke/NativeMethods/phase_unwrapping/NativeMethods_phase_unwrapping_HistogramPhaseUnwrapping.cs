using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    #region HistogramPhaseUnwrapping

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus phase_unwrapping_Ptr_HistogramPhaseUnwrapping_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus phase_unwrapping_Ptr_HistogramPhaseUnwrapping_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus phase_unwrapping_HistogramPhaseUnwrapping_create(
        ref HistogramPhaseUnwrapping.Params parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus phase_unwrapping_HistogramPhaseUnwrapping_getInverseReliabilityMap(
        OpenCvSafeHandle obj, in OutputArrayProxy reliabilityMap);

    #endregion
}
