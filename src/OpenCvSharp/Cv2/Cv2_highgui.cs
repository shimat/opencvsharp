using System;
using System.Collections.Generic;
using OpenCvSharp.Util;

namespace OpenCvSharp
{
    static partial class Cv2
    {
        /// <summary>
        /// Creates a window.
        /// </summary>
        /// <param name="winname">Name of the window in the window caption that may be used as a window identifier.</param>
        public static void NamedWindow(string winname)
        {
            NamedWindow(winname, WindowMode.Normal);
        }

        /// <summary>
        /// Creates a window.
        /// </summary>
        /// <param name="winname">Name of the window in the window caption that may be used as a window identifier.</param>
        /// <param name="flags">
        /// Flags of the window. Currently the only supported flag is CV WINDOW AUTOSIZE. If this is set, 
        /// the window size is automatically adjusted to fit the displayed image (see imshow ), and the user can not change the window size manually.
        /// </param>
        public static void NamedWindow(string winname, WindowMode flags)
        {
            if (string.IsNullOrEmpty(winname))
                throw new ArgumentNullException(nameof(winname));
            try
            {
                NativeMethods.highgui_namedWindow(winname, (int) flags);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// Destroys the specified window.
        /// </summary>
        /// <param name="winName"></param>
        public static void DestroyWindow(string winName)
        {
            if (String.IsNullOrEmpty("winName"))
                throw new ArgumentNullException(nameof(winName));
            NativeMethods.highgui_destroyWindow(winName);
        }

        /// <summary>
        /// Destroys all of the HighGUI windows.
        /// </summary>
        public static void DestroyAllWindows()
        {
            NativeMethods.highgui_destroyAllWindows();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int StartWindowThread()
        {
            return NativeMethods.highgui_startWindowThread();
        }

        /// <summary>
        /// Waits for a pressed key. 
        /// </summary>
        /// <param name="delay">Delay in milliseconds. 0 is the special value that means ”forever”</param>
        /// <returns>Returns the code of the pressed key or -1 if no key was pressed before the specified time had elapsed.</returns>
        public static int WaitKey(int delay = 0)
        {
            try
            {
                return NativeMethods.highgui_waitKey(delay);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
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
            try
            {
                return NativeMethods.highgui_waitKeyEx(delay);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }

        /// <summary>
        /// Resizes window to the specified size
        /// </summary>
        /// <param name="winName">Window name</param>
        /// <param name="width">The new window width</param>
        /// <param name="height">The new window height</param>
        public static void ResizeWindow(string winName, int width, int height)
        {
            if (String.IsNullOrEmpty(winName))
                throw new ArgumentNullException(nameof(winName));
            NativeMethods.highgui_resizeWindow(winName, width, height);
        }

        /// <summary>
        /// Moves window to the specified position
        /// </summary>
        /// <param name="winName">Window name</param>
        /// <param name="x">The new x-coordinate of the window</param>
        /// <param name="y">The new y-coordinate of the window</param>
        public static void MoveWindow(string winName, int x, int y)
        {
            if (String.IsNullOrEmpty(winName))
                throw new ArgumentNullException(nameof(winName));
            NativeMethods.highgui_moveWindow(winName, x, y);
        }

        /// <summary>
        /// Changes parameters of a window dynamically.
        /// </summary>
        /// <param name="winName">Name of the window.</param>
        /// <param name="propId">Window property to retrieve.</param>
        /// <param name="propValue">New value of the window property.</param>
        public static void SetWindowProperty(string winName, WindowProperty propId, double propValue)
        {
            if (String.IsNullOrEmpty(winName))
                throw new ArgumentNullException(nameof(winName));
            NativeMethods.highgui_setWindowProperty(winName, (int) propId, propValue);
        }

        /// <summary>
        /// Updates window title
        /// </summary>
        /// <param name="winname"></param>
        /// <param name="title"></param>
        public static void SetWindowTitle(string winname, string title)
        {
            if (String.IsNullOrEmpty(winname)) 
                throw new ArgumentNullException(nameof(winname));
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));
            NativeMethods.highgui_setWindowTitle(winname, title);
        }

        /// <summary>
        /// Provides parameters of a window.
        /// </summary>
        /// <param name="winName">Name of the window.</param>
        /// <param name="propId">Window property to retrieve.</param>
        /// <returns></returns>
        public static double GetWindowProperty(string winName, WindowProperty propId)
        {
            if (String.IsNullOrEmpty(winName))
                throw new ArgumentNullException(nameof(winName));
            return NativeMethods.highgui_getWindowProperty(winName, (int) propId);
        }

#if LANG_JP
    /// <summary>
    /// 指定されたウィンドウ内で発生するマウスイベントに対するコールバック関数を設定する
    /// </summary>
    /// <param name="windowName">ウィンドウの名前</param>
    /// <param name="onMouse">指定されたウィンドウ内でマウスイベントが発生するたびに呼ばれるデリゲート</param>
    /// <param name="userdata"></param>
#else
        /// <summary>
        /// Sets the callback function for mouse events occuting within the specified window.
        /// </summary>
        /// <param name="windowName">Name of the window. </param>
        /// <param name="onMouse">Reference to the function to be called every time mouse event occurs in the specified window. </param>
        /// <param name="userdata"></param>
#endif
        public static void SetMouseCallback(string windowName, CvMouseCallback onMouse, IntPtr userdata = default)
        {
            if (string.IsNullOrEmpty(windowName))
                throw new ArgumentNullException(nameof(windowName));
            if (onMouse == null)
                throw new ArgumentNullException(nameof(onMouse));

            NativeMethods.highgui_setMouseCallback(windowName, onMouse, userdata);
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
        public static int GetMouseWheelDelta(MouseEvent flags)
        {
            return NativeMethods.highgui_getMouseWheelDelta((int)flags);
        }

        /// <summary>
        /// Creates a trackbar and attaches it to the specified window.
        /// The function createTrackbar creates a trackbar(a slider or range control) with the specified name 
        /// and range, assigns a variable value to be a position synchronized with the trackbar and specifies 
        /// the callback function onChange to be called on the trackbar position change.The created trackbar is 
        /// displayed in the specified window winname.
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
        /// <param name="userdata">User data that is passed as is to the callback. It can be used to handle trackbar events without using global variables.</param>
        /// <returns></returns>
        public static int CreateTrackbar(string trackbarName, string winName,
            ref int value, int count, CvTrackbarCallback2 onChange = null, IntPtr userdata = default(IntPtr))
        {
            if (trackbarName == null)
                throw new ArgumentNullException(nameof(trackbarName));
            if (winName == null)
                throw new ArgumentNullException(nameof(winName));

            if (onChange == null)
                return NativeMethods.highgui_createTrackbar(trackbarName, winName, ref value, count, IntPtr.Zero, userdata);
            return NativeMethods.highgui_createTrackbar(trackbarName, winName, ref value, count, onChange, userdata);
        }

        /// <summary>
        /// Returns the trackbar position.
        /// </summary>
        /// <param name="trackbarName">Name of the trackbar.</param>
        /// <param name="winName">Name of the window that is the parent of the trackbar.</param>
        /// <returns>trackbar position</returns>
        public static int GetTrackbarPos(string trackbarName, string winName)
        {
            if (trackbarName == null)
                throw new ArgumentNullException(nameof(trackbarName));

            return NativeMethods.highgui_getTrackbarPos(trackbarName, winName);
        }

        /// <summary>
        /// Sets the trackbar position.
        /// </summary>
        /// <param name="trackbarName">Name of the trackbar.</param>
        /// <param name="winName">Name of the window that is the parent of trackbar.</param>
        /// <param name="pos">New position.</param>
        public static void SetTrackbarPos(string trackbarName, string winName, int pos)
        {
            if (trackbarName == null)
                throw new ArgumentNullException(nameof(trackbarName));

            NativeMethods.highgui_setTrackbarPos(trackbarName, winName, pos);
        }

        /// <summary>
        /// Sets the trackbar maximum position.
        /// The function sets the maximum position of the specified trackbar in the specified window.
        /// </summary>
        /// <param name="trackbarname">Name of the trackbar.</param>
        /// <param name="winname">Name of the window that is the parent of trackbar.</param>
        /// <param name="maxval">New maximum position.</param>
        public static void SetTrackbarMax(string trackbarname, string winname, int maxval)
        {
            if (trackbarname == null)
                throw new ArgumentNullException(nameof(trackbarname));

            NativeMethods.highgui_setTrackbarMax(trackbarname, winname, maxval);
        }

        /// <summary>
        /// Sets the trackbar minimum position.
        /// The function sets the minimum position of the specified trackbar in the specified window.
        /// </summary>
        /// <param name="trackbarname">Name of the trackbar.</param>
        /// <param name="winname">Name of the window that is the parent of trackbar.</param>
        /// <param name="minval">New minimum position.</param>
        public static void SetTrackbarMin(string trackbarname, string winname, int minval)
        {
            if (trackbarname == null)
                throw new ArgumentNullException(nameof(trackbarname));

            NativeMethods.highgui_setTrackbarMin(trackbarname, winname, minval);
        }

        /// <summary>
        /// Displays the image in the specified window
        /// </summary>
        /// <param name="winname">Name of the window.</param>
        /// <param name="mat">Image to be shown.</param>
        public static void ImShow(string winname, Mat mat)
        {
            if (string.IsNullOrEmpty(winname))
                throw new ArgumentNullException(nameof(winname));
            if (mat == null)
                throw new ArgumentNullException(nameof(mat));
            try
            {
                NativeMethods.highgui_imshow(winname, mat.CvPtr);
                GC.KeepAlive(mat);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
    }
}
