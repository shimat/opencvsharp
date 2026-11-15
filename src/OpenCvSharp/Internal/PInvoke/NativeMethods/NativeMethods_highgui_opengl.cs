using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable CA2101 // Match HighGUI's window name marshaling.
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus highgui_setOpenGlContext([MarshalAs(UnmanagedType.LPStr)] string windowName);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus highgui_updateWindow([MarshalAs(UnmanagedType.LPStr)] string windowName);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus highgui_setOpenGlDrawCallback([MarshalAs(UnmanagedType.LPStr)] string windowName, IntPtr callback, IntPtr userData);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus highgui_setOpenGlFreeCallback([MarshalAs(UnmanagedType.LPStr)] string windowName, IntPtr callback);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus highgui_getOpenGlDrawCallback([MarshalAs(UnmanagedType.LPStr)] string windowName, out IntPtr callback);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus highgui_getOpenGlUserData([MarshalAs(UnmanagedType.LPStr)] string windowName, out IntPtr userData);
}
