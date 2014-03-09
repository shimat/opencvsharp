/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.Utilities;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static partial class CppInvoke
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_namedWindow([MarshalAs(UnmanagedType.LPStr)] string winname, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_destroyWindow([MarshalAs(UnmanagedType.LPStr)] string winName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_destroyAllWindows();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_imshow([MarshalAs(UnmanagedType.LPStr)] string winname, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_imread(string filename, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_imwrite([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr img, [In] int[] @params, int paramsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_imdecode(IntPtr buf, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_imencode([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, out IntPtr buf, [In] int[] @params, int paramsLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_startWindowThread();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_waitKey(int delay);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_resizeWindow([MarshalAs(UnmanagedType.LPStr)] string winName, int width, int height);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_moveWindow([MarshalAs(UnmanagedType.LPStr)] string winName, int x, int y);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_setWindowProperty([MarshalAs(UnmanagedType.LPStr)] string winName, int propId, double propValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double highgui_getWindowProperty([MarshalAs(UnmanagedType.LPStr)] string winName, int propId);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_setMouseCallback(string winName, [MarshalAs(UnmanagedType.FunctionPtr)] CvMouseCallback onMouse, IntPtr userData);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_createTrackbar(string trackbarName, string winName,
            ref int value, int count, [MarshalAs(UnmanagedType.FunctionPtr)] CvTrackbarCallback2 onChange, IntPtr userData);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_getTrackbarPos(string trackbarName, string winName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_setTrackbarPos(string trackbarName, string winName, int pos);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_VideoCapture_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_VideoCapture_new_fromFile(string fileName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_VideoCapture_new_fromDevice(int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_VideoCapture_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_VideoCapture_open_fromFile(IntPtr obj, string fileName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_VideoCapture_open_fromDevice(IntPtr obj, int device);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_VideoCapture_isOpened(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_VideoCapture_release(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_VideoCapture_grab(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_VideoCapture_retrieve(IntPtr obj, IntPtr image, int channel);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_VideoCapture_read(IntPtr obj, IntPtr image);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_VideoCapture_set(IntPtr obj, int propId, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double highgui_VideoCapture_get(IntPtr obj, int propId);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_VideoWriter_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_VideoWriter_new2(string fileName, int fourcc,
            double fps, CvSize frameSize, int isColor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_VideoWriter_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_VideoWriter_open(IntPtr obj, string fileName, int fourcc, double fps,
            CvSize frameSize, int isColor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_VideoWriter_isOpened(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_VideoWriter_release(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_VideoWriter_write(IntPtr obj, IntPtr image);

    }
}