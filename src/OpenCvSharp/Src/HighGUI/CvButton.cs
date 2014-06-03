using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
        private bool disposed;
        private readonly string name;
        private object userdata;
        private readonly CvButtonCallback callback;
        private CvButtonCallbackNative callbackNative;
        private GCHandle gchCallback;
        private GCHandle gchCallbackNative;
        private GCHandle gchUserdata;  
        private int result;
        private static readonly List<CvButton> instances;

        /// <summary>
        /// 
        /// </summary>
        static CvButton()
        {
            instances = new List<CvButton>();
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
            this.name = name;
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
            IntPtr callbackPtr;
            if (callback != null)
            {
                // コールバックdelegateを、userdataをobjectとするように変換                
                callbackNative = delegate(int state, IntPtr ud)
                {
                    if (ud == IntPtr.Zero)
                    {
                        callback(state, null);
                    }
                    else
                    {
                        GCHandle gch = GCHandle.FromIntPtr(ud);
                        callback(state, gch.Target);
                    }
                };

                // コールバックdelegateをポインタに変換                
                gchCallback = GCHandle.Alloc(callback);
                gchCallbackNative = GCHandle.Alloc(callbackNative);
                callbackPtr = Marshal.GetFunctionPointerForDelegate(callbackNative);
            }
            else
            {
                callbackNative = null;
                callbackPtr = IntPtr.Zero;
            }

            result = NativeMethods.cvCreateButton(name, callbackPtr, userdataPtr, button_type, initial_button_state);
            if (result == 0)
                throw new OpenCvSharpException("Failed to create CvButton.");

            instances.Add(this);
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
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if (gchCallback.IsAllocated)
                            gchCallback.Free();
                        if (gchCallbackNative.IsAllocated)
                            gchCallbackNative.Free();
                        if (gchUserdata.IsAllocated)
                            gchUserdata.Free();
                        instances.Remove(this);
                    }
                    disposed = true;
                }
                finally
                {
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
            get { return name; }
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
            get { return callback; }
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
            get { return result; }
            private set { result = value; }
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
            get { return instances; }
        }
        #endregion
    }
}