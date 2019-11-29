using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // VideoCapture

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr videoio_VideoCapture_new1();

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr videoio_VideoCapture_new2([MarshalAs(UnmanagedType.LPStr)] string filename);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr videoio_VideoCapture_new3(int device);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void videoio_VideoCapture_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoCapture_open1(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoCapture_open2(IntPtr obj, int device);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoCapture_isOpened(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void videoio_VideoCapture_release(IntPtr obj);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoCapture_grab(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoCapture_retrieve(IntPtr obj, IntPtr image, int flag);
        
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void videoio_VideoCapture_operatorRightShift_Mat(IntPtr obj, IntPtr image);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void videoio_VideoCapture_operatorRightShift_UMat(IntPtr obj, IntPtr image);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoCapture_read(IntPtr obj, IntPtr image);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoCapture_set(IntPtr obj, int propId, double value);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double videoio_VideoCapture_get(IntPtr obj, int propId);


        // VideoWriter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr videoio_VideoWriter_new1();

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr videoio_VideoWriter_new2(
            [MarshalAs(UnmanagedType.LPStr)] string filename, int fourcc, double fps,
            Size frameSize, int isColor);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void videoio_VideoWriter_delete(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoWriter_open(
            IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename,
            int fourcc, double fps, Size frameSize, int isColor);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoWriter_isOpened(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void videoio_VideoWriter_release(IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void videoio_VideoWriter_OperatorLeftShift(IntPtr obj, IntPtr image);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void videoio_VideoWriter_write(IntPtr obj, IntPtr image);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoWriter_set(IntPtr obj, int propId, double value);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double videoio_VideoWriter_get(IntPtr obj, int propId);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int videoio_VideoWriter_fourcc(byte c1, byte c2, byte c3, byte c4);
    }
}