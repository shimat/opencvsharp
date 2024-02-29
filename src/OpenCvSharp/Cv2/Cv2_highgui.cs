using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;

static partial class Cv2
{
    /// <summary>
    /// Creates a window.
    /// </summary>
    /// <param name="winName">Name of the window in the window caption that may be used as a window identifier.</param>
    /// <param name="flags">
    /// Flags of the window. Currently the only supported flag is CV WINDOW AUTOSIZE. If this is set, 
    /// the window size is automatically adjusted to fit the displayed image (see imshow ), and the user can not change the window size manually.
    /// </param>
    public static void NamedWindow(string winName, WindowFlags flags = WindowFlags.Normal)
    {
        if (string.IsNullOrEmpty(winName))
            throw new ArgumentException("null or empty string.", nameof(winName));

        NativeMethods.HandleException(
            NativeMethods.highgui_namedWindow(winName, (int) flags));
    }

    /// <summary>
    /// Destroys the specified window.
    /// </summary>
    /// <param name="winName"></param>
    public static void DestroyWindow(string winName)
    {
        if (string.IsNullOrEmpty(winName))
            throw new ArgumentException("null or empty string.", nameof(winName));

        NativeMethods.HandleException(
            NativeMethods.highgui_destroyWindow(winName));
    }

    /// <summary>
    /// Destroys all of the HighGUI windows.
    /// </summary>
    public static void DestroyAllWindows()
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_destroyAllWindows());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int StartWindowThread()
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_startWindowThread(out var ret));
        return ret;
    }

    /// <summary>
    /// Waits for a pressed key.
    /// Similar to #waitKey, but returns full key code. 
    /// Key code is implementation specific and depends on used backend: QT/GTK/Win32/etc
    /// </summary>
    /// <param name="delay">Delay in milliseconds. 0 is the special value that means ”forever”</param>
    /// <returns>Returns the code of the pressed key or -1 if no key was pressed before the specified time had elapsed.</returns>
    public static int WaitKeyEx(int delay = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_waitKeyEx(delay, out var ret));
        return ret;
    }

    /// <summary>
    /// Waits for a pressed key. 
    /// </summary>
    /// <param name="delay">Delay in milliseconds. 0 is the special value that means ”forever”</param>
    /// <returns>Returns the code of the pressed key or -1 if no key was pressed before the specified time had elapsed.</returns>
    public static int WaitKey(int delay = 0)
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_waitKey(delay, out var ret));
        return ret;
    }

    /// <summary>
    /// Displays the image in the specified window
    /// </summary>
    /// <param name="winName">Name of the window.</param>
    /// <param name="mat">Image to be shown.</param>
    public static void ImShow(string winName, Mat mat)
    {
        if (string.IsNullOrEmpty(winName))
            throw new ArgumentException("null or empty string.", nameof(winName));
        if (mat is null)
            throw new ArgumentNullException(nameof(mat));

        NativeMethods.HandleException(
            NativeMethods.highgui_imshow(winName, mat.CvPtr));
        GC.KeepAlive(mat);
    }

    /// <summary>
    /// Resizes window to the specified size
    /// </summary>
    /// <param name="winName">Window name</param>
    /// <param name="width">The new window width</param>
    /// <param name="height">The new window height</param>
    public static void ResizeWindow(string winName, int width, int height)
    {
        if (string.IsNullOrEmpty(winName))
            throw new ArgumentException("null or empty string.", nameof(winName));

        NativeMethods.HandleException(
            NativeMethods.highgui_resizeWindow(winName, width, height));
    }

    /// <summary>
    /// Resizes window to the specified size
    /// </summary>
    /// <param name="winName">Window name</param>
    /// <param name="size">The new window size</param>
    public static void ResizeWindow(string winName, Size size)
    {
        ResizeWindow(winName, size.Width, size.Height);
    }

    /// <summary>
    /// Moves window to the specified position
    /// </summary>
    /// <param name="winName">Window name</param>
    /// <param name="x">The new x-coordinate of the window</param>
    /// <param name="y">The new y-coordinate of the window</param>
    public static void MoveWindow(string winName, int x, int y)
    {
        if (string.IsNullOrEmpty(winName))
            throw new ArgumentException("null or empty string.", nameof(winName));

        NativeMethods.HandleException(
            NativeMethods.highgui_moveWindow(winName, x, y));
    }

    /// <summary>
    /// Changes parameters of a window dynamically.
    /// </summary>
    /// <param name="winName">Name of the window.</param>
    /// <param name="propId">Window property to retrieve.</param>
    /// <param name="propValue">New value of the window property.</param>
    public static void SetWindowProperty(string winName, WindowPropertyFlags propId, double propValue)
    {
        if (string.IsNullOrEmpty(winName))
            throw new ArgumentException("null or empty string.", nameof(winName));

        NativeMethods.HandleException(
            NativeMethods.highgui_setWindowProperty(winName, (int) propId, propValue));
    }

    /// <summary>
    /// Updates window title
    /// </summary>
    /// <param name="winName">Name of the window</param>
    /// <param name="title">New title</param>
    public static void SetWindowTitle(string winName, string title)
    {
        if (string.IsNullOrEmpty(winName))
            throw new ArgumentException("null or empty string.", nameof(winName));
        if (string.IsNullOrEmpty(title))
            throw new ArgumentException("null or empty string.", nameof(title));
            
        NativeMethods.HandleException(
            NativeMethods.highgui_setWindowTitle(winName, title));
    }

    /// <summary>
    /// Provides parameters of a window.
    /// </summary>
    /// <param name="winName">Name of the window.</param>
    /// <param name="propId">Window property to retrieve.</param>
    /// <returns></returns>
    public static double GetWindowProperty(string winName, WindowPropertyFlags propId)
    {
        if (string.IsNullOrEmpty(winName))
            throw new ArgumentException("null or empty string.", nameof(winName));
            
        NativeMethods.HandleException(
            NativeMethods.highgui_getWindowProperty(winName, (int) propId, out var ret));
        return ret;
    }

    /// <summary>
    /// Provides rectangle of image in the window.
    /// The function getWindowImageRect returns the client screen coordinates, width and height of the image rendering area.
    /// </summary>
    /// <param name="winName">Name of the window.</param>
    /// <returns></returns>
    public static Rect GetWindowImageRect(string winName)
    {
        if (string.IsNullOrEmpty(winName))
            throw new ArgumentException("null or empty string.", nameof(winName));
            
        NativeMethods.HandleException(
            NativeMethods.highgui_getWindowImageRect(winName, out var ret));
        return ret;
    }
        
    /// <summary>
    /// Sets the callback function for mouse events occuring within the specified window.
    /// </summary>
    /// <param name="windowName">Name of the window. </param>
    /// <param name="onMouse">Reference to the function to be called every time mouse event occurs in the specified window. </param>
    /// <param name="userData"></param>
    public static void SetMouseCallback(string windowName, MouseCallback onMouse, IntPtr userData = default)
    {
        if (string.IsNullOrEmpty(windowName))
            throw new ArgumentNullException(nameof(windowName));
        if (onMouse is null)
            throw new ArgumentNullException(nameof(onMouse));

        NativeMethods.HandleException(
            NativeMethods.highgui_setMouseCallback(windowName, onMouse, userData));
    }

    /// <summary>
    /// Gets the mouse-wheel motion delta, when handling mouse-wheel events cv::EVENT_MOUSEWHEEL and cv::EVENT_MOUSEHWHEEL.
    /// 
    /// For regular mice with a scroll-wheel, delta will be a multiple of 120. The value 120 corresponds to 
    /// a one notch rotation of the wheel or the threshold for action to be taken and one such action should 
    /// occur for each delta.Some high-precision mice with higher-resolution freely-rotating wheels may 
    /// generate smaller values. 
    /// 
    /// For cv::EVENT_MOUSEWHEEL positive and negative values mean forward and backward scrolling, 
    /// respectively.For cv::EVENT_MOUSEHWHEEL, where available, positive and negative values mean right and 
    /// left scrolling, respectively.
    /// </summary>
    /// <param name="flags">The mouse callback flags parameter.</param>
    /// <returns></returns>
    public static int GetMouseWheelDelta(MouseEventFlags flags)
    {
        NativeMethods.HandleException(
            NativeMethods.highgui_getMouseWheelDelta((int)flags, out var ret));
        return ret;
    }

    /// <summary>
    /// Selects ROI on the given image.
    /// Function creates a window and allows user to select a ROI using mouse.
    /// Controls: use `space` or `enter` to finish selection, use key `c` to cancel selection (function will return the zero cv::Rect).
    /// </summary>
    /// <param name="windowName">name of the window where selection process will be shown.</param>
    /// <param name="img">image to select a ROI.</param>
    /// <param name="showCrosshair">if true crosshair of selection rectangle will be shown.</param>
    /// <param name="fromCenter">if true center of selection will match initial mouse position. In opposite case a corner of
    /// selection rectangle will correspond to the initial mouse position.</param>
    /// <returns>selected ROI or empty rect if selection canceled.</returns>
    // ReSharper disable once InconsistentNaming
    public static Rect SelectROI(string windowName, InputArray img, bool showCrosshair = true, bool fromCenter = false)
    {
        if (string.IsNullOrEmpty(windowName))
            throw new ArgumentNullException(nameof(windowName));
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        img.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.highgui_selectROI1(windowName, img.CvPtr, showCrosshair ? 1 : 0, fromCenter ? 1 : 0, out var ret));

        GC.KeepAlive(img);
        return ret;
    }

    /// <summary>
    /// Selects ROI on the given image.
    /// Function creates a window and allows user to select a ROI using mouse.
    /// Controls: use `space` or `enter` to finish selection, use key `c` to cancel selection (function will return the zero cv::Rect).
    /// </summary>
    /// <param name="img">image to select a ROI.</param>
    /// <param name="showCrosshair">if true crosshair of selection rectangle will be shown.</param>
    /// <param name="fromCenter">if true center of selection will match initial mouse position. In opposite case a corner of
    /// selection rectangle will correspond to the initial mouse position.</param>
    /// <returns>selected ROI or empty rect if selection canceled.</returns>
    // ReSharper disable once InconsistentNaming
    public static Rect SelectROI(InputArray img, bool showCrosshair = true, bool fromCenter = false)
    {
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        img.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.highgui_selectROI2(img.CvPtr, showCrosshair ? 1 : 0, fromCenter ? 1 : 0, out var ret));

        GC.KeepAlive(img);
        return ret;
    }

    /// <summary>
    /// Selects ROIs on the given image.
    /// Function creates a window and allows user to select a ROIs using mouse.
    /// Controls: use `space` or `enter` to finish current selection and start a new one,
    /// use `esc` to terminate multiple ROI selection process.
    /// </summary>
    /// <param name="windowName">name of the window where selection process will be shown.</param>
    /// <param name="img">image to select a ROI.</param>
    /// <param name="showCrosshair">if true crosshair of selection rectangle will be shown.</param>
    /// <param name="fromCenter">if true center of selection will match initial mouse position. In opposite case a corner of
    /// selection rectangle will correspond to the initial mouse position.</param>
    /// <returns>selected ROIs.</returns>
    // ReSharper disable once InconsistentNaming
    public static  Rect[] SelectROIs(string windowName, InputArray img, bool showCrosshair = true, bool fromCenter = false)
    {
        if (string.IsNullOrEmpty(windowName))
            throw new ArgumentNullException(nameof(windowName));
        if (img is null)
            throw new ArgumentNullException(nameof(img));
        img.ThrowIfDisposed();

        using var boundingBoxesVec = new VectorOfRect();
        NativeMethods.HandleException(
            NativeMethods.highgui_selectROIs(windowName, img.CvPtr, boundingBoxesVec.CvPtr, showCrosshair ? 1 : 0, fromCenter ? 1 : 0));

        GC.KeepAlive(img);
        return boundingBoxesVec.ToArray();
    }

    /// <summary>
    /// Creates a trackbar and attaches it to the specified window.
    /// The function createTrackbar creates a trackbar(a slider or range control) with the specified name 
    /// and range, assigns a variable value to be a position synchronized with the trackbar and specifies 
    /// the callback function onChange to be called on the trackbar position change.The created trackbar is 
    /// displayed in the specified window winName.
    /// </summary>
    /// <param name="trackbarName">Name of the created trackbar.</param>
    /// <param name="winName">Name of the window that will be used as a parent of the created trackbar.</param>
    /// <param name="value">Optional pointer to an integer variable whose value reflects the position of the slider.Upon creation,
    ///  the slider position is defined by this variable.</param>
    /// <param name="count">Maximal position of the slider. The minimal position is always 0.</param>
    /// <param name="onChange">Pointer to the function to be called every time the slider changes position. 
    /// This function should be prototyped as void Foo(int, void\*); , where the first parameter is the trackbar 
    /// position and the second parameter is the user data(see the next parameter). If the callback is 
    /// the NULL pointer, no callbacks are called, but only value is updated.</param>
    /// <param name="userData">User data that is passed as is to the callback. It can be used to handle trackbar events without using global variables.</param>
    /// <returns></returns>
    public static int CreateTrackbar(string trackbarName, string winName,
        ref int value, int count, TrackbarCallbackNative? onChange = null, IntPtr userData = default)
    {
        if (trackbarName is null)
            throw new ArgumentNullException(nameof(trackbarName));
        if (winName is null)
            throw new ArgumentNullException(nameof(winName));

        NativeMethods.HandleException(
            NativeMethods.highgui_createTrackbar(trackbarName, winName, ref value, count, onChange, userData, out var ret));
        return ret;
    }
        
    /// <summary>
    /// Creates a trackbar and attaches it to the specified window.
    /// The function createTrackbar creates a trackbar(a slider or range control) with the specified name 
    /// and range, assigns a variable value to be a position synchronized with the trackbar and specifies 
    /// the callback function onChange to be called on the trackbar position change.The created trackbar is 
    /// displayed in the specified window winName.
    /// </summary>
    /// <param name="trackbarName">Name of the created trackbar.</param>
    /// <param name="winName">Name of the window that will be used as a parent of the created trackbar.</param>
    /// <param name="count">Maximal position of the slider. The minimal position is always 0.</param>
    /// <param name="onChange">Pointer to the function to be called every time the slider changes position. 
    /// This function should be prototyped as void Foo(int, void\*); , where the first parameter is the trackbar 
    /// position and the second parameter is the user data(see the next parameter). If the callback is 
    /// the NULL pointer, no callbacks are called, but only value is updated.</param>
    /// <param name="userData">User data that is passed as is to the callback. It can be used to handle trackbar events without using global variables.</param>
    /// <returns></returns>
    public static int CreateTrackbar(string trackbarName, string winName,
        int count, TrackbarCallbackNative? onChange = null, IntPtr userData = default)
    {
        if (trackbarName is null)
            throw new ArgumentNullException(nameof(trackbarName));
        if (winName is null)
            throw new ArgumentNullException(nameof(winName));

        NativeMethods.HandleException(
            NativeMethods.highgui_createTrackbar(trackbarName, winName, IntPtr.Zero, count, onChange, userData, out var ret));
        return ret;
    }

    /// <summary>
    /// Returns the trackbar position.
    /// </summary>
    /// <param name="trackbarName">Name of the trackbar.</param>
    /// <param name="winName">Name of the window that is the parent of the trackbar.</param>
    /// <returns>trackbar position</returns>
    public static int GetTrackbarPos(string trackbarName, string winName)
    {
        if (trackbarName is null)
            throw new ArgumentNullException(nameof(trackbarName));

        NativeMethods.HandleException(
            NativeMethods.highgui_getTrackbarPos(trackbarName, winName, out var ret));
        return ret;
    }

    /// <summary>
    /// Sets the trackbar position.
    /// </summary>
    /// <param name="trackbarName">Name of the trackbar.</param>
    /// <param name="winName">Name of the window that is the parent of trackbar.</param>
    /// <param name="pos">New position.</param>
    public static void SetTrackbarPos(string trackbarName, string winName, int pos)
    {
        if (trackbarName is null)
            throw new ArgumentNullException(nameof(trackbarName));

        NativeMethods.HandleException(
            NativeMethods.highgui_setTrackbarPos(trackbarName, winName, pos));
    }

    /// <summary>
    /// Sets the trackbar maximum position.
    /// The function sets the maximum position of the specified trackbar in the specified window.
    /// </summary>
    /// <param name="trackbarName">Name of the trackbar.</param>
    /// <param name="winName">Name of the window that is the parent of trackbar.</param>
    /// <param name="maxVal">New maximum position.</param>
    public static void SetTrackbarMax(string trackbarName, string winName, int maxVal)
    {
        if (trackbarName is null)
            throw new ArgumentNullException(nameof(trackbarName));

        NativeMethods.HandleException(
            NativeMethods.highgui_setTrackbarMax(trackbarName, winName, maxVal));
    }

    /// <summary>
    /// Sets the trackbar minimum position.
    /// The function sets the minimum position of the specified trackbar in the specified window.
    /// </summary>
    /// <param name="trackbarName">Name of the trackbar.</param>
    /// <param name="winName">Name of the window that is the parent of trackbar.</param>
    /// <param name="minVal">New minimum position.</param>
    public static void SetTrackbarMin(string trackbarName, string winName, int minVal)
    {
        if (trackbarName is null)
            throw new ArgumentNullException(nameof(trackbarName));

        NativeMethods.HandleException(
            NativeMethods.highgui_setTrackbarMin(trackbarName, winName, minVal));
    }

    /// <summary>
    /// get native window handle (HWND in case of Win32 and Widget in case of X Window) 
    /// </summary>
    /// <param name="windowName"></param>
    public static IntPtr GetWindowHandle(string windowName)
    {
        if (windowName is null)
            throw new ArgumentNullException(nameof(windowName));

        NativeMethods.HandleException(
            NativeMethods.highgui_cvGetWindowHandle(windowName, out var ret));
        return ret;
    }

#if WINRT
        // MP! Added: To correctly support imShow under WinRT.

        /// <summary>
        /// Initialize XAML container panel for use by ImShow
        /// </summary>
        /// <param name="panel">Panel container.</param>
        public static void InitContainer(object panel)
        {
            NativeMethods.HandleException(
                NativeMethods.highgui_initContainer(panel));
        }
#endif
}
