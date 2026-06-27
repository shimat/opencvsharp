using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Tracking;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // TrackerKCF

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_TrackerKCF_create1(out IntPtr returnValue);

    // TrackerKCF.Params is a blittable struct whose layout matches cv::TrackerKCF::Params; pass by ref (pointer ABI).
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_TrackerKCF_create2(ref TrackerKCF.Params parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_Ptr_TrackerKCF_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_Ptr_TrackerKCF_get(IntPtr ptr, out IntPtr returnValue);


    // TrackerCSRT

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_TrackerCSRT_create1(out IntPtr returnValue);

    // WTrackerCSRTParams is the blittable mirror of native tracker_TrackerCSRT_Params (window_function as a char*).
    // The managed-friendly TrackerCSRT.Params is converted into it (with the string marshalled) in TrackerCSRT.Create.
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_TrackerCSRT_create2(ref WTrackerCSRTParams parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_Ptr_TrackerCSRT_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_Ptr_TrackerCSRT_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_TrackerCSRT_setInitialMask(IntPtr tracker, IntPtr mask);
}
