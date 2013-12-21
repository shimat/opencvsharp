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
    /// QtによるCvWindowで利用するボタン
    /// </summary>
#else
    /// <summary>
    /// Button that is used on Qt Window
    /// </summary>
#endif
    public class CvButton : DisposableObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;
        private string _name;
        private object _userdata;
        private CvButtonCallback _callback;
        private CvButtonCallbackNative _callbackNative;
        private GCHandle _gchCallback;
        private GCHandle _gchCallbackNative;
        private GCHandle _gchUserdata;  
        private int _result;
        private static List<CvButton> _instances;

        /// <summary>
        /// 
        /// </summary>
        static CvButton()
        {
            _instances = new List<CvButton>();
        }

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Constructor
        /// </summary>
#endif
        public CvButton()
            : this(null, null, IntPtr.Zero, ButtonType.PushButton, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
#endif
        public CvButton(string name)
            : this(name, null, IntPtr.Zero, ButtonType.PushButton, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
        /// <param name="callback">ボタン状態が変更される度に呼び出されるデりゲート</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
        /// <param name="callback">Pointer to the function to be called every time the button changed its state.</param>
#endif
        public CvButton(string name, CvButtonCallback callback)
            : this(name, callback, IntPtr.Zero, ButtonType.PushButton, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
        /// <param name="callback">ボタン状態が変更される度に呼び出されるデりゲート</param>
        /// <param name="userdata">コールバック関数渡されるポインタ</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
        /// <param name="callback">Pointer to the function to be called every time the button changed its state.</param>
        /// <param name="userdata">object passed to the callback function. </param>
#endif
        public CvButton(string name, CvButtonCallback callback, object userdata)
            : this(name, callback, userdata, ButtonType.PushButton, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
        /// <param name="callback">ボタン状態が変更される度に呼び出されるデりゲート</param>
        /// <param name="userdata">コールバック関数渡されるポインタ</param>
        /// <param name="button_type">ボタンの種類</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
        /// <param name="callback">Pointer to the function to be called every time the button changed its state.</param>
        /// <param name="userdata">object passed to the callback function. </param>
        /// <param name="button_type">button type</param>
#endif
        public CvButton(string name, CvButtonCallback callback, object userdata, ButtonType button_type)
            : this(name, callback, userdata, button_type, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="name">ボタンの名前． （これが null の場合，”button &lt;number of boutton&gt;” という名前になります）</param>
        /// <param name="callback">ボタン状態が変更される度に呼び出されるデりゲート</param>
        /// <param name="userdata">コールバック関数に渡されるオブジェクト</param>
        /// <param name="button_type">ボタンの種類</param>
        /// <param name="initial_button_state">ボタンのデフォルトの状態．チェックボックスとラジオボックスの場合，これは 0 または 1 になります．</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the button ( if null, the name will be “button &lt;number of boutton&gt;”)</param>
        /// <param name="callback">Pointer to the function to be called every time the button changed its state.</param>
        /// <param name="userdata">object passed to the callback function. </param>
        /// <param name="button_type">button type</param>
        /// <param name="initial_button_state">Default state of the button. Use for checkbox and radiobox, its value could be 0 or 1. </param>
#endif
        public CvButton(string name, CvButtonCallback callback, object userdata, ButtonType button_type, int initial_button_state)
        {
            _name = name;
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
            IntPtr callbackPtr;
            if (_callback != null)
            {
                // コールバックdelegateを、userdataをobjectとするように変換                
                _callbackNative = delegate(int state, IntPtr ud)
                {
                    if (ud == IntPtr.Zero)
                    {
                        _callback(state, null);
                    }
                    else
                    {
                        GCHandle gch = GCHandle.FromIntPtr(ud);
                        _callback(state, gch.Target);
                    }
                };

                // コールバックdelegateをポインタに変換                
                _gchCallback = GCHandle.Alloc(_callback);
                _gchCallbackNative = GCHandle.Alloc(_callbackNative);
                callbackPtr = Marshal.GetFunctionPointerForDelegate(_callbackNative);
            }
            else
            {
                _callbackNative = null;
                callbackPtr = IntPtr.Zero;
            }

            _result = CvInvoke.cvCreateButton(name, callbackPtr, userdataPtr, button_type, initial_button_state);
            if (_result == 0)
                throw new OpenCvSharpException("Failed to create CvButton.");

            _instances.Add(this);
        }

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
                        if (_gchCallbackNative.IsAllocated)
                            _gchCallbackNative.Free();
                        if (_gchUserdata.IsAllocated)
                            _gchUserdata.Free();
                        _instances.Remove(this);
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
        public string ButtonName
        {
            get { return _name; }
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
        public CvButtonCallback Callback
        {
            get { return _callback; }
        }

#if LANG_JP
        /// <summary>
        /// 作成したすべてのボタン
        /// </summary>
#else
        /// <summary>
        /// All created buttons
        /// </summary>
#endif
        internal int Result
        {
            get { return _result; }
            private set { _result = value; }
        }

#if LANG_JP
        /// <summary>
        /// 作成したすべてのボタン
        /// </summary>
#else
        /// <summary>
        /// All created buttons
        /// </summary>
#endif
        public static IEnumerable<CvButton> Instances
        {
            get { return _instances; }
        }
        #endregion
    }
}