using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_namedWindow([MarshalAs(UnmanagedType.LPStr)] string winName, int flags);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_destroyWindow([MarshalAs(UnmanagedType.LPStr)] string winName);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_destroyAllWindows();
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_startWindowThread(out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_imshow([MarshalAs(UnmanagedType.LPStr)] string winName, IntPtr mat);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_imshow_umat([MarshalAs(UnmanagedType.LPStr)] string winName, IntPtr mat);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_waitKey(int delay, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_waitKeyEx(int delay, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_resizeWindow([MarshalAs(UnmanagedType.LPStr)] string winName, int width, int height);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_moveWindow([MarshalAs(UnmanagedType.LPStr)] string winName, int x, int y);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_setWindowProperty([MarshalAs(UnmanagedType.LPStr)] string winName, int propId, double propValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_setWindowTitle([MarshalAs(UnmanagedType.LPStr)] string winName, [MarshalAs(UnmanagedType.LPStr)] string title);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_getWindowProperty([MarshalAs(UnmanagedType.LPStr)] string winName, int propId, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_getWindowImageRect([MarshalAs(UnmanagedType.LPStr)] string winName, out Rect returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_setMouseCallback(string winName, [MarshalAs(UnmanagedType.FunctionPtr)] MouseCallback onMouse, IntPtr userData);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_getMouseWheelDelta(int flags, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_selectROI1(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, IntPtr img, int showCrosshair, int fromCenter, out Rect returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_selectROI2(IntPtr img, int showCrosshair, int fromCenter, out Rect returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_selectROIs(
        [MarshalAs(UnmanagedType.LPStr)] string windowName, IntPtr img, IntPtr boundingBoxes, int showCrosshair, int fromCenter);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_createTrackbar(
        [MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName,
        IntPtr value, int count, IntPtr onChange, IntPtr userData, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_createTrackbar(
        [MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName,
        IntPtr value, int count, TrackbarCallbackNative? onChange, IntPtr userData, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_createTrackbar(
        [MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName,
        ref int value, int count, TrackbarCallbackNative? onChange, IntPtr userData, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_getTrackbarPos(
        [MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_setTrackbarPos(string trackbarName, string winName, int pos);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_setTrackbarMax([MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName, int maxVal);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_setTrackbarMin([MarshalAs(UnmanagedType.LPStr)] string trackbarName, [MarshalAs(UnmanagedType.LPStr)] string winName, int minVal);

    //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    //public static extern ExceptionStatus highgui_createButton(
    //    [MarshalAs(UnmanagedType.LPStr)] string barName, IntPtr onChange, IntPtr userData, int type, int initialButtonState, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_cvGetWindowHandle([MarshalAs(UnmanagedType.LPStr)] string name, out IntPtr returnValue);

#if WINRT
    // MP! Added: To correctly support imShow under WinRT.
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus highgui_initContainer([MarshalAs(UnmanagedType.IUnknown)] Object panel);
#endif
}
