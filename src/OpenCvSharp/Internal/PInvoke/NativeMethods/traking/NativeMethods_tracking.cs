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

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_TrackerKCF_create1(out IntPtr returnValue);

    // TrackerKCF.Params is a [StructLayout] class (reference type marshalled as a pointer), which
    // source-generated marshalling does not support; keep classic DllImport.
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_TrackerKCF_create2(TrackerKCF.Params parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_Ptr_TrackerKCF_delete(IntPtr ptr);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_Ptr_TrackerKCF_get(IntPtr ptr, out IntPtr returnValue);


    // TrackerCSRT

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_TrackerCSRT_create1(out IntPtr returnValue);

    // TrackerCSRT.Params contains a string field ([MarshalAs(LPStr)]), making it non-blittable;
    // source-generated marshalling does not support it, so keep classic DllImport.
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_TrackerCSRT_create2(ref TrackerCSRT.Params parameters, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_Ptr_TrackerCSRT_delete(IntPtr ptr);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_Ptr_TrackerCSRT_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus tracking_TrackerCSRT_setInitialMask(IntPtr tracker, IntPtr mask);
}
