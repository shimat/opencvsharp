using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_matchGMS(
        Size size1, Size size2, IntPtr keypoints1, IntPtr keypoints2,
        IntPtr matches1to2, IntPtr matchesGMS,
        int withRotation, int withScale, double thresholdFactor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xfeatures2d_matchLOGOS(
        IntPtr keypoints1, IntPtr keypoints2, IntPtr nn1, IntPtr nn2, IntPtr matches1to2);
}
