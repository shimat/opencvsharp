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
                throw new ArgumentNullException("winname");
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
        /// 
        /// </summary>
        /// <param name="winName"></param>
        public static void DestroyWindow(string winName)
        {
            if (String.IsNullOrEmpty("winName"))
                throw new ArgumentNullException("winName");
            NativeMethods.highgui_destroyWindow(winName);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DestroyAllWindows()
        {
            NativeMethods.highgui_destroyAllWindows();
        }

        /// <summary>
        /// Displays the image in the specified window
        /// </summary>
        /// <param name="winname">Name of the window.</param>
        /// <param name="mat">Image to be shown.</param>
        public static void ImShow(string winname, Mat mat)
        {
            if (string.IsNullOrEmpty(winname))
                throw new ArgumentNullException("winname");
            if (mat == null)
                throw new ArgumentNullException("mat");
            try
            {
                NativeMethods.highgui_imshow(winname, mat.CvPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
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
        /// Resizes window to the specified size
        /// </summary>
        /// <param name="winName">Window name</param>
        /// <param name="width">The new window width</param>
        /// <param name="height">The new window height</param>
        public static void ResizeWindow(string winName, int width, int height)
        {
            if (String.IsNullOrEmpty(winName))
                throw new ArgumentNullException("winName");
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
                throw new ArgumentNullException("winName");
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
                throw new ArgumentNullException("winName");
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
                throw new ArgumentNullException("winname");
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException("title");
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
                throw new ArgumentNullException("winName");
            return NativeMethods.highgui_getWindowProperty(winName, (int) propId);
        }

#if LANG_JP
    /// <summary>
    /// 指定されたウィンドウ内で発生するマウスイベントに対するコールバック関数を設定する
    /// </summary>
    /// <param name="windowName">ウィンドウの名前</param>
    /// <param name="onMouse">指定されたウィンドウ内でマウスイベントが発生するたびに呼ばれるデリゲート</param>
#else
        /// <summary>
        /// Sets the callback function for mouse events occuting within the specified window.
        /// </summary>
        /// <param name="windowName">Name of the window. </param>
        /// <param name="onMouse">Reference to the function to be called every time mouse event occurs in the specified window. </param>
#endif
        public static void SetMouseCallback(string windowName, CvMouseCallback onMouse)
        {
            if (string.IsNullOrEmpty(windowName))
                throw new ArgumentNullException("windowName");
            if (onMouse == null)
                throw new ArgumentNullException("onMouse");

            Window window = Window.GetWindowByName(windowName);
            if (window != null)
            {
                window.OnMouseCallback += onMouse;
            }
        }
    }
}
