using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

namespace OpenCvSharp
{
    /// <summary>
    /// Win32API Wrapper
    /// </summary>
    public static class Win32Api
    {
        [DllImport("kernel32")]
        public static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("kernel32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hLibModule);
    }
}
