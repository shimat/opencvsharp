using System;
using System.Diagnostics.Contracts;
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
        
#if DOTNET_FRAMEWORK
        private const CharSet DefaultCharSet = CharSet.Auto;
#else
        private const CharSet DefaultCharSet = CharSet.Unicode;
#endif

        [Pure, DllImport("kernel32", CallingConvention = CallingConvention.Winapi,
             SetLastError = true, CharSet = DefaultCharSet, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr LoadLibrary(string dllPath);

        [Pure, DllImport("kernel32")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [Pure, DllImport("kernel32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hLibModule);
    }
}
