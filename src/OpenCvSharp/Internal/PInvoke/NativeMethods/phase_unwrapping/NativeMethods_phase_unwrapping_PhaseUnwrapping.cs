using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    #region PhaseUnwrapping

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus phase_unwrapping_PhaseUnwrapping_unwrapPhaseMap(
        OpenCvSafeHandle obj, in InputArrayProxy wrappedPhaseMap, in OutputArrayProxy unwrappedPhaseMap, in InputArrayProxy shadowMask);

    #endregion
}
