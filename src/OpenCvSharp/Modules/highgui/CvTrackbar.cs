using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// Windowに貼り付けて操作するトラックバー
    /// </summary>
#else
    /// <summary>
    /// Trackbar that is shown on OpenCV Window
    /// </summary>
#endif
    public class CvTrackbar : DisposableObject
    {
        private readonly int result;
        private TrackbarCallback callback;
        private TrackbarCallbackNative callbackNative;
        private GCHandle gchCallback;
        private GCHandle gchCallbackNative;
        
        #region Properties
#if LANG_JP
        /// <summary>
        /// トラックバーの名前を取得する
        /// </summary>
#else
        /// <summary>
        /// Name of this trackbar
        /// </summary>
#endif
        public string TrackbarName { get; }

#if LANG_JP
        /// <summary>
        /// 親ウィンドウの名前を取得する
        /// </summary>
#else
        /// <summary>
        /// Name of parent window
        /// </summary>
#endif
        public string WindowName { get; }

        /// <summary>
        /// 
        /// </summary>
        public TrackbarCallback Callback => callback;

#if LANG_JP
        /// <summary>
        /// トラックバーの現在の値を取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets or sets a numeric value that represents the current position of the scroll box on the track bar. 
        /// </summary>
#endif
        public int Pos
        {
            get
            {
                NativeMethods.HandleException(
                    NativeMethods.highgui_getTrackbarPos(TrackbarName, WindowName, out var ret));
                return ret;
            }
            set
            {
                NativeMethods.HandleException(
                    NativeMethods.highgui_setTrackbarPos(TrackbarName, WindowName, value));
            }
        }

        /// <summary>
        /// Result value of cv::createTrackbar
        /// </summary>
        public int Result => result;

        #endregion


        #region Init and Disposal
        
#if LANG_JP
        /// <summary>
        /// 初期化(目盛りは0~100)
        /// </summary>
        /// <param name="name">トラックバーの名前</param>
        /// <param name="window">トラックバーの親ウィンドウ名</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
#else
        /// <summary>
        /// Constructor (value=0, max=100)
        /// </summary>
        /// <param name="name">Trackbar name</param>
        /// <param name="window">Window name</param>
        /// <param name="callback">Callback handler</param>
#endif
        internal CvTrackbar(string name, string window, TrackbarCallback callback)
            : this(name, window, 0, 100, callback)
        {
        }
        
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="name">トラックバーの名前</param>
        /// <param name="window">トラックバーの親ウィンドウ名</param>
        /// <param name="value">スライダの初期位置</param>
        /// <param name="max">スライダの最大値．最小値は常に 0.</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="trackbarName">Trackbar name</param>
        /// <param name="windowName">Window name</param>
        /// <param name="initialPos">Initial slider position</param>
        /// <param name="max">The upper limit of the range this trackbar is working with. </param>
        /// <param name="callback">Callback handler</param>
#endif
        internal CvTrackbar(string trackbarName, string windowName, int initialPos, int max, TrackbarCallback callback)
        {
            if (string.IsNullOrEmpty(trackbarName))
                throw new ArgumentNullException(nameof(trackbarName));
            if (string.IsNullOrEmpty(windowName))
                throw new ArgumentNullException(nameof(windowName));

            this.callback = callback ?? throw new ArgumentNullException(nameof(callback));
            TrackbarName = trackbarName;
            WindowName = windowName;

            // userData wrapper             
            callbackNative = (pos, ud) => callback(pos);

            gchCallback = GCHandle.Alloc(callback);
            gchCallbackNative = GCHandle.Alloc(callbackNative);
            var callbackPtr = Marshal.GetFunctionPointerForDelegate(callbackNative);

            NativeMethods.HandleException(
                NativeMethods.highgui_createTrackbar(
                    trackbarName, windowName, IntPtr.Zero, max, callbackPtr, IntPtr.Zero, out result));
            
            // Set initial trackbar position
            NativeMethods.HandleException(
                NativeMethods.highgui_setTrackbarPos(
                    trackbarName, windowName, initialPos));

            if (result == 0)
                throw new OpenCvSharpException("Failed to create CvTrackbar.");
        }
        
        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            if (gchCallback.IsAllocated)
                gchCallback.Free();
            if (gchCallbackNative.IsAllocated)
                gchCallbackNative.Free();
            base.DisposeUnmanaged();
        }

        #endregion

        /// <summary>
        /// Sets the trackbar maximum position.
        /// The function sets the maximum position of the specified trackbar in the specified window.
        /// </summary>
        /// <param name="maxVal">New maximum position.</param>
        public void SetMax(int maxVal)
        {
            NativeMethods.HandleException(
                NativeMethods.highgui_setTrackbarMax(TrackbarName, WindowName, maxVal));
        }

        /// <summary>
        /// Sets the trackbar minimum position.
        /// The function sets the minimum position of the specified trackbar in the specified window.
        /// </summary>
        /// <param name="minVal">New minimum position.</param>
        public void SetMin(int minVal)
        {
            NativeMethods.HandleException(
                NativeMethods.highgui_setTrackbarMin(TrackbarName, WindowName, minVal));
        }
    }
}