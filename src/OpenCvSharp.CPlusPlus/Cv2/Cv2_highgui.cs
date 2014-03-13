using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp.CPlusPlus
{
    public static partial class Cv2
    {
        #region NamedWindow
        /// <summary>
        /// Creates a window.
        /// </summary>
        /// <param name="winname">Name of the window in the window caption that may be used as a window identifier.</param>
        public static void NamedWindow(string winname)
        {
            NamedWindow(winname, WindowMode.None);
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
                CppInvoke.highgui_namedWindow(winname, (int)flags);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region DestroyWindow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="winName"></param>
        public static void DestroyWindow(string winName)
        {
            if (String.IsNullOrEmpty("winName"))
                throw new ArgumentNullException("winName");
            CppInvoke.highgui_destroyWindow(winName);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void DestroyAllWindows()
        {
            CppInvoke.highgui_destroyAllWindows();
        }
        #endregion
        #region ImShow
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
                CppInvoke.highgui_imshow(winname, mat.CvPtr);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion
        #region ImRead
        /// <summary>
        /// Loads an image from a file.
        /// </summary>
        /// <param name="fileName">Name of file to be loaded.</param>
        /// <param name="flags">Specifies color type of the loaded image</param>
        /// <returns></returns>
        public static Mat ImRead(string fileName, LoadMode flags = LoadMode.Color)
        {
            return new Mat(fileName, flags);
        }
        #endregion
        #region ImWrite
        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="img"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public static bool ImWrite(string fileName, Mat img, int[] prms = null)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");
            if (img == null)
                throw new ArgumentNullException("img");
            if (prms == null)
                prms = new int[0];
            try
            {
                return CppInvoke.highgui_imwrite(fileName, img.CvPtr, prms, prms.Length) != 0;
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="img"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        public static bool ImWrite(string fileName, Mat img, params ImageEncodingParam[] prms)
        {
            if (prms != null)
            {
                List<int> p = new List<int>();
                foreach (ImageEncodingParam item in prms)
                {
                    p.Add((int)item.EncodingID);
                    p.Add(item.Value);
                }
                return ImWrite(fileName, img, p.ToArray());
            }
            else
            {
                return ImWrite(fileName, img, (int[])null);
            }
        }
        #endregion
        #region ImDecode
        /// <summary>
        /// Reads image from the specified buffer in memory.
        /// </summary>
        /// <param name="buf">The input array of vector of bytes.</param>
        /// <param name="flags">The same flags as in imread</param>
        /// <returns></returns>
        public static Mat ImDecode(Mat buf, LoadMode flags)
        {
            if (buf == null)
                throw new ArgumentNullException("buf");
            IntPtr matPtr = CppInvoke.highgui_imdecode_Mat(buf.CvPtr, (int)flags);
            return new Mat(matPtr);
        }
        /// <summary>
        /// Reads image from the specified buffer in memory.
        /// </summary>
        /// <param name="buf">The input array of vector of bytes.</param>
        /// <param name="flags">The same flags as in imread</param>
        /// <returns></returns>
        public static Mat ImDecode(byte[] buf, LoadMode flags)
        {
            if (buf == null)
                throw new ArgumentNullException("buf");
            IntPtr matPtr = CppInvoke.highgui_imdecode_vector(
                buf, new IntPtr(buf.LongLength), (int)flags);
            return new Mat(matPtr);
        }
        #endregion
        #region ImEncode

        /// <summary>
        /// Compresses the image and stores it in the memory buffer
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="img">The image to be written</param>
        /// <param name="buf"></param>
        /// <param name="prms"></param>
        public static bool ImEncode(string ext, InputArray img, out byte[] buf, int[] prms = null)
        {
            if (string.IsNullOrEmpty(ext))
                throw new ArgumentNullException("ext");
            if (img == null)
                throw new ArgumentNullException("img");
            if (prms == null)
                prms = new int[0];
            img.ThrowIfDisposed();
            using (VectorOfByte bufVec = new VectorOfByte())
            {
                int ret = CppInvoke.highgui_imencode_vector(ext, img.CvPtr, bufVec.CvPtr, prms, prms.Length);
                buf = bufVec.ToArray();
                return ret != 0;
            }
        }

        /// <summary>
        /// Compresses the image and stores it in the memory buffer
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="img">The image to be written</param>
        /// <param name="buf"></param>
        /// <param name="prms"></param>
        public static void ImEncode(string ext, InputArray img, out byte[] buf, params ImageEncodingParam[] prms)
        {
            if (prms != null)
            {
                List<int> p = new List<int>();
                foreach (ImageEncodingParam item in prms)
                {
                    p.Add((int)item.EncodingID);
                    p.Add(item.Value);
                }
                ImEncode(ext, img, out buf, p.ToArray());
            }
            else
            {
                ImEncode(ext, img, out buf, (int[])null);
            }
        }
        #endregion
        #region StartWindowThread
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int StartWindowThread()
        {
            return CppInvoke.highgui_startWindowThread();
        }
        #endregion
        #region WaitKey
        /// <summary>
        /// Waits for a pressed key.
        /// </summary>
        /// <param name="delay">Delay in milliseconds. 0 is the special value that means ”forever”</param>
        /// <returns>Returns the code of the pressed key or -1 if no key was pressed before the specified time had elapsed.</returns>
        public static int WaitKey(int delay = 0)
        {
            try
            {
                return CppInvoke.highgui_waitKey(delay);
            }
            catch (BadImageFormatException ex)
            {
                throw PInvokeHelper.CreateException(ex);
            }
        }
        #endregion

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
            CppInvoke.highgui_resizeWindow(winName, width, height);
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
            CppInvoke.highgui_moveWindow(winName, x, y);
        }

        /// <summary>
        /// Changes parameters of a window dynamically.
        /// </summary>
        /// <param name="winName">Name of the window.</param>
        /// <param name="propId">Window property to retrieve.</param>
        /// <param name="propValue">New value of the window property.</param>
        public static void SetWindowProperty(string winName, WindowProperty propId, WindowPropertyValue propValue)
        {
            if (String.IsNullOrEmpty(winName))
                throw new ArgumentNullException("winName");
            CppInvoke.highgui_setWindowProperty(winName, (int)propId, (double)propValue);
        }

        /// <summary>
        /// Provides parameters of a window.
        /// </summary>
        /// <param name="winName">Name of the window.</param>
        /// <param name="propId">Window property to retrieve.</param>
        /// <returns></returns>
        public static WindowPropertyValue GetWindowProperty(string winName, WindowProperty propId)
        {
            if (String.IsNullOrEmpty(winName))
                throw new ArgumentNullException("winName");
            return (WindowPropertyValue)(int)CppInvoke.highgui_getWindowProperty(winName, (int)propId);
        }

        #region SetMouseCallback
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
        #endregion
    }
}
