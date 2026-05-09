using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Internal;
#pragma warning disable 1591
static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_Event_new1(out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_Event_new2(int flags, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_Event_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_Event_record(IntPtr obj, IntPtr stream);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_Event_queryIfComplete(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_Event_waitForCompletion(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_Event_elapsedTime(IntPtr start, IntPtr end, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_Event_getEvent(IntPtr obj, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus cuda_Event_wrapEvent(IntPtr rawHandle, out IntPtr returnValue);
}
