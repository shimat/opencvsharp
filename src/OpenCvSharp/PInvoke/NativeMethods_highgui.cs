using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void highgui_namedWindow([MarshalAs(UnmanagedType.LPStr)] string winname, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void highgui_destroyWindow([MarshalAs(UnmanagedType.LPStr)] string winName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void highgui_destroyAllWindows();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void highgui_imshow([MarshalAs(UnmanagedType.LPStr)] string winname, IntPtr mat);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr highgui_imread(string filename, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int highgui_imwrite([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr img, [In] int[] @params, int paramsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_imdecode_Mat(IntPtr buf, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr highgui_imdecode_vector(byte[] buf, IntPtr bufLength, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void highgui_imencode_CvMat([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, out IntPtr buf, [In] int[] @params, int paramsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int highgui_imencode_vector([MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, IntPtr buf, [In] int[] @params, int paramsLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_startWindowThread();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int highgui_waitKey(int delay);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void highgui_resizeWindow([MarshalAs(UnmanagedType.LPStr)] string winName, int width, int height);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void highgui_moveWindow([MarshalAs(UnmanagedType.LPStr)] string winName, int x, int y);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void highgui_setWindowProperty([MarshalAs(UnmanagedType.LPStr)] string winName, int propId, double propValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern double highgui_getWindowProperty([MarshalAs(UnmanagedType.LPStr)] string winName, int propId);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void highgui_setMouseCallback(string winName, [MarshalAs(UnmanagedType.FunctionPtr)] CvMouseCallback onMouse, IntPtr userData);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int highgui_createTrackbar([MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName,
            ref int value, int count, IntPtr onChange, IntPtr userData);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int highgui_getTrackbarPos([MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void highgui_setTrackbarPos(string trackbarName, string winName, int pos);
    }
}