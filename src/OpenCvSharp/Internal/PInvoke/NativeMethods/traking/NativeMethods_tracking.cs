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

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_TrackerKCF_create1(out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_TrackerKCF_create2(TrackerKCF.Params parameters, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_Ptr_TrackerKCF_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_Ptr_TrackerKCF_get(IntPtr ptr, out IntPtr returnValue);


    // TrackerCSRT

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_TrackerCSRT_create1(out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_TrackerCSRT_create2(ref TrackerCSRT.Params parameters, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_Ptr_TrackerCSRT_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_Ptr_TrackerCSRT_get(IntPtr ptr, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus tracking_TrackerCSRT_setInitialMask(IntPtr tracker, IntPtr mask);
}
