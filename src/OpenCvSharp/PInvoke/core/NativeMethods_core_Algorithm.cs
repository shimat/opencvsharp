using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_write(IntPtr obj, IntPtr fs);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_read(IntPtr obj, IntPtr fn);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int core_Algorithm_empty(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_save(IntPtr obj, string filename);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void core_Algorithm_getDefaultName(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);
    }
}