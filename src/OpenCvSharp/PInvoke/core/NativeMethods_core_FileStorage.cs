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
        public static extern void core_FileStorage_releaseAndGetString_stdString(
            IntPtr obj, IntPtr outString);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_getFirstTopLevelNode(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_root(IntPtr obj, int streamIdx);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr core_FileStorage_indexer(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string nodeName);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_writeRaw(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string fmt, IntPtr vec, IntPtr len);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_getDefaultObjectName(
            [MarshalAs(UnmanagedType.LPStr)] string filename, 
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int bufLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe sbyte* core_FileStorage_elname(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_startWriteStruct(
            IntPtr obj,
            [MarshalAs(UnmanagedType.LPStr)] string name,
            int flags,
            [MarshalAs(UnmanagedType.LPStr)] string typeName);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_endWriteStruct(IntPtr obj);

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
        

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_String(IntPtr fs, [MarshalAs(UnmanagedType.LPStr)] string val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_int(IntPtr fs, int val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_float(IntPtr fs, float val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_double(IntPtr fs, double val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Mat(IntPtr fs, IntPtr val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_SparseMat(IntPtr fs, IntPtr val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Range(IntPtr fs, Range val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_KeyPoint(IntPtr fs, KeyPoint val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_DMatch(IntPtr fs, DMatch val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_vectorOfKeyPoint(IntPtr fs, IntPtr val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_vectorOfDMatch(IntPtr fs, IntPtr val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Point2i(IntPtr fs, Point val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Point2f(IntPtr fs, Point2f val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Point2d(IntPtr fs, Point2d val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Point3i(IntPtr fs, Point3i val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Point3f(IntPtr fs, Point3f val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Point3d(IntPtr fs, Point3d val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Size2i(IntPtr fs, Size val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Size2f(IntPtr fs, Size2f val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Size2d(IntPtr fs, Size2d val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Rect2i(IntPtr fs, Rect val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Rect2f(IntPtr fs, Rect2f val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Rect2d(IntPtr fs, Rect2d val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Scalar(IntPtr fs, Scalar val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec2i(IntPtr fs, Vec2i val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec3i(IntPtr fs, Vec3i val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec4i(IntPtr fs, Vec4i val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec6i(IntPtr fs, Vec6i val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec2d(IntPtr fs, Vec2d val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec3d(IntPtr fs, Vec3d val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec4d(IntPtr fs, Vec4d val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec6d(IntPtr fs, Vec6d val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec2f(IntPtr fs, Vec2f val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec3f(IntPtr fs, Vec3f val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec4f(IntPtr fs, Vec4f val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec6f(IntPtr fs, Vec6f val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec2b(IntPtr fs, Vec2b val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec3b(IntPtr fs, Vec3b val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec4b(IntPtr fs, Vec4b val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec6b(IntPtr fs, Vec6b val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec2s(IntPtr fs, Vec2s val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec3s(IntPtr fs, Vec3s val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec4s(IntPtr fs, Vec4s val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec6s(IntPtr fs, Vec6s val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec2w(IntPtr fs, Vec2w val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec3w(IntPtr fs, Vec3w val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec4w(IntPtr fs, Vec4w val);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void core_FileStorage_shift_Vec6w(IntPtr fs, Vec6w val);
    }
}