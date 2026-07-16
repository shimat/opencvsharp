using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_ContourFitting_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_ContourFitting_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createContourFitting(int ctr, int fd, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_ContourFitting_estimateTransformation(
        OpenCvSafeHandle obj, in InputArrayProxy src, in InputArrayProxy dst, in OutputArrayProxy alphaPhiST, out double dist, int fdContour);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_ContourFitting_setCtrSize(OpenCvSafeHandle obj, int n);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_ContourFitting_setFDSize(OpenCvSafeHandle obj, int n);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_ContourFitting_getCtrSize(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_ContourFitting_getFDSize(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_fourierDescriptor(
        in InputArrayProxy src, in OutputArrayProxy dst, int nbElt, int nbFD);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_transformFD(
        in InputArrayProxy src, in InputArrayProxy t, in OutputArrayProxy dst, int fdContour);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_contourSampling(
        in InputArrayProxy src, in OutputArrayProxy out_, int nbElt);
}
