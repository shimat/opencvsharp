/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

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
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;
        private string _name;
        private string _window;
        private int _value;
        private int _max;
        private int _result;
        private object _userdata;
        private Delegate _callback;
        private CvTrackbarCallback2Native _callbackNative;
        private GCHandle _gchValue;
        private GCHandle _gchCallback;
        private GCHandle _gchCallbackNative;
        private GCHandle _gchUserdata;

        #region Init and Disposal
        #region cvCreateTrackbar
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
                throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(window))
                throw new ArgumentNullException("window");
            if (callback == null)
                throw new ArgumentNullException("callback");

            _name = name;
            _window = window;
            _value = value;
            _max = max;
            _callback = callback;

            _gchValue = GCHandle.Alloc(value, GCHandleType.Pinned);
            _gchCallback = GCHandle.Alloc(callback);
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate(callback);
#if DEBUG
            int result = CvInvoke.cvCreateTrackbar(name, window, ref value, max, callback);
#else
            _result = CvInvoke.cvCreateTrackbar(name, window, ref value, max, callbackPtr);
#endif
            if (_result == 0)
                throw new OpenCvSharpException("Failed to create CvTrackbar.");
        }
        #endregion
        #region cvCreateTrackbar2
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
                throw new ArgumentNullException("name");
            if (string.IsNullOrEmpty(window))
                throw new ArgumentNullException("window");
            if (callback == null)
                throw new ArgumentNullException("callback");

            _name = name;
            _window = window;
            _value = value;
            _max = max;
            _callback = callback;
            _userdata = userdata;

            // userdataをIntPtrに変換
            IntPtr userdataPtr;
            if (userdata != null)
            {
                _gchUserdata = GCHandle.Alloc(_userdata);
                userdataPtr = GCHandle.ToIntPtr(_gchUserdata);
            }
            else
            {
                userdataPtr = IntPtr.Zero;
            }

            _callback = callback;
            // コールバックdelegateを、userdataをobjectとするように変換                
            _callbackNative = delegate(int pos, IntPtr ud)
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
            _gchCallback = GCHandle.Alloc(callback);
            _gchCallbackNative = GCHandle.Alloc(_callbackNative);
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate(_callbackNative);

            _gchValue = GCHandle.Alloc(value, GCHandleType.Pinned);
#if DEBUG
            int result = CvInvoke.cvCreateTrackbar2(name, window, ref value, max, _callbackNative, userdataPtr);
#else
            _result = CvInvoke.cvCreateTrackbar2(name, window, ref value, max, callbackPtr, userdataPtr);
#endif
            if (_result == 0)
                throw new OpenCvSharpException("Failed to create CvTrackbar.");
        }
        #endregion

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                // 継承したクラス独自の解放処理
                try
                {
                    if (disposing)
                    {
                        if (_gchCallback.IsAllocated)
                            _gchCallback.Free();
                        if (_gchValue.IsAllocated)
                            _gchValue.Free();
                        if (_gchUserdata.IsAllocated)
                            _gchUserdata.Free();
                    }
                    this._disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
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
            get { return _name; }
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
            get { return _window; }
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
            get { return CvInvoke.cvGetTrackbarPos(_name, _window); }
            set { CvInvoke.cvSetTrackbarPos(_name, _window, value); }
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
            get { return _max; }
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
            get { return _callback; }
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
            get { return _userdata; }
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
            get { return _result; }
        }
        #endregion

    }
}