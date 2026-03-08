using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_Algorithm_write(IntPtr obj, IntPtr fs);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_Algorithm_read(IntPtr obj, IntPtr fn);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_Algorithm_empty(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = true, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus core_Algorithm_save(IntPtr obj, string filename);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus core_Algorithm_getDefaultName(IntPtr obj, IntPtr buf);
}
