using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// CvWindowに貼り付けて操作するトラックバー
    /// </summary>
#else
    /// <summary>
    /// Trackbar that is shown on CvWindow
    /// </summary>
#endif
    public class CvTrackbar : DisposableObject
    {
        private readonly string name;
        private readonly string window;
        private int value;
        private readonly int max;
        private readonly int result;
        private readonly object userdata;
        private readonly Delegate callback;
        private CvTrackbarCallback2Native callbackNative;
        private GCHandle gchValue;
        private GCHandle gchCallback;
        private GCHandle gchCallbackNative;
        private GCHandle gchUserdata;

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
        public CvTrackbar(string name, string window, CvTrackbarCallback callback)
            : this(name, window, 0, 100, callback)
        {
        }

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
        public CvTrackbar(string name, string window, CvTrackbarCallback2 callback)
            : this(name, window, 0, 100, callback, null)
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
        /// <param name="name">Trackbar name</param>
        /// <param name="window">Window name</param>
        /// <param name="value">Initial slider position</param>
        /// <param name="max">The upper limit of the range this trackbar is working with. </param>
        /// <param name="callback">Callback handler</param>
#endif
        public CvTrackbar(string name, string window, int value, int max, CvTrackbarCallback callback)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(window))
                throw new ArgumentNullException(nameof(window));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            this.name = name;
            this.window = window;
            this.value = value;
            this.max = max;
            this.callback = callback;

            // userdata wrapper             
            callbackNative = delegate (int pos, IntPtr ud)
            {
                callback(pos);
            };

            //gchValue = GCHandle.Alloc(value, GCHandleType.Pinned);
            gchCallback = GCHandle.Alloc(callback);
            gchCallbackNative = GCHandle.Alloc(callbackNative);
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate(callbackNative);

            result = NativeMethods.highgui_createTrackbar(name, window, ref this.value, max, callbackPtr, IntPtr.Zero);

            if (result == 0)
                throw new OpenCvSharpException("Failed to create CvTrackbar.");
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
        /// <param name="userdata"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Trackbar name</param>
        /// <param name="window">Window name</param>
        /// <param name="value">Initial slider position</param>
        /// <param name="max">The upper limit of the range this trackbar is working with. </param>
        /// <param name="callback">Callback handler</param>
        /// <param name="userdata"></param>
#endif
        public CvTrackbar(string name, string window, int value, int max, CvTrackbarCallback2 callback, object userdata)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(window))
                throw new ArgumentNullException(nameof(window));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            this.name = name;
            this.window = window;
            this.value = value;
            this.max = max;
            this.callback = callback;
            this.userdata = userdata;

            // userdataをIntPtrに変換
            IntPtr userdataPtr;
            if (userdata != null)
            {
                gchUserdata = GCHandle.Alloc(userdata);
                userdataPtr = GCHandle.ToIntPtr(gchUserdata);
            }
            else
            {
                userdataPtr = IntPtr.Zero;
            }

            this.callback = callback;
            // コールバックdelegateを、userdataをobjectとするように変換                
            callbackNative = delegate (int pos, IntPtr ud)
            {
                if (ud == IntPtr.Zero)
                {
                    callback(pos, null);
                }
                else
                {
                    GCHandle gch = GCHandle.FromIntPtr(ud);
                    callback(pos, gch.Target);
                }
            };

            // コールバックdelegateをポインタに変換                
            gchCallback = GCHandle.Alloc(callback);
            gchCallbackNative = GCHandle.Alloc(callbackNative);
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate(callbackNative);

            //gchValue = GCHandle.Alloc(value, GCHandleType.Pinned);

            result = NativeMethods.highgui_createTrackbar(name, window, ref this.value, max, callbackPtr, userdataPtr);

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
            if (gchValue.IsAllocated)
                gchValue.Free();
            if (gchUserdata.IsAllocated)
                gchUserdata.Free();
            base.DisposeUnmanaged();
        }

        #endregion

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
        public string TrackbarName
        {
            get { return name; }
        }

#if LANG_JP
        /// <summary>
        /// 親ウィンドウの名前を取得する
        /// </summary>
#else
        /// <summary>
        /// Name of parent window
        /// </summary>
#endif
        public string WindowName
        {
            get { return window; }
        }

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
            get { return NativeMethods.highgui_getTrackbarPos(name, window); }
            set { NativeMethods.highgui_setTrackbarPos(name, window, value); }
        }

#if LANG_JP
        /// <summary>
        /// トラックバーの目盛りの最大値を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets the upper limit of the range this trackbar is working with. 
        /// </summary>
#endif
        public int Max
        {
            get { return max; }
        }

#if LANG_JP
        /// <summary>
        /// スライダが動いた際のコールバックイベントデリゲートを取得する
        /// </summary>
#else
        /// <summary>
        /// Gets the callback delegate which occurs when the Value property of a track bar changes, either by movement of the scroll box or by manipulation in code. 
        /// </summary>
#endif
        public Delegate Callback
        {
            get { return callback; }
        }

#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public object Userdata
        {
            get { return userdata; }
        }


#if LANG_JP
        /// <summary>
        /// 
        /// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        public int Result
        {
            get { return result; }
        }
        #endregion

    }
}