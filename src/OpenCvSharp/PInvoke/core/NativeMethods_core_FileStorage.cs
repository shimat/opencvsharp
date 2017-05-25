using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_new2(
            [MarshalAs(UnmanagedType.LPStr)] string source, 
            int flags, [MarshalAs(UnmanagedType.LPStr)] string encoding);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_newFromLegacy(IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileStorage_open(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, 
            int flags, [MarshalAs(UnmanagedType.LPStr)] string encoding);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileStorage_isOpened(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_release(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_releaseAndGetString(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_getFirstTopLevelNode(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_root(IntPtr obj, int streamIdx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_indexer(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string nodeName);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_toLegacy(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeRaw(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fmt, IntPtr vec, IntPtr len);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeObj(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_getDefaultObjectName(
            [MarshalAs(UnmanagedType.LPStr)] string filename, 
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe sbyte* core_FileStorage_elname(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_structs(IntPtr obj, out IntPtr resultLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int core_FileStorage_state(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_int(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_float(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, float value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_double(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_String(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_Mat(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_SparseMat(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_vectorOfKeyPoint(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_write_vectorOfDMatch(
            IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr value);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeScalar_int(IntPtr fs, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeScalar_float(IntPtr fs, float value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeScalar_double(IntPtr fs, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeScalar_String(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string value);
    }
}