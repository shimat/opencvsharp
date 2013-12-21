/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvNamedWindow関数によるHighGUIウィンドウのラッパー
    /// </summary>
#else
    /// <summary>
    /// Wrapper of HighGUI window
    /// </summary>
#endif
    public class CvWindow : DisposableObject
    {
        #region Fields
        static internal Dictionary<string, CvWindow> Windows = new Dictionary<string, CvWindow>();
        static private int windowCount = 0;

        private string _name;
        private CvArr _image;
        private CvMouseCallback _mouseCallback;
        private Dictionary<string, CvTrackbar> _trackbars;        
        private ScopedGCHandle _callbackHandle;
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool _disposed = false;
        #endregion

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// 適当なウィンドウ名で初期化
        /// </summary>
#else
        /// <summary>
        /// Creates a window with a random name
        /// </summary>
#endif
        public CvWindow()
            : this(DefaultName(), WindowMode.AutoSize, null)
        {
        }
#if LANG_JP
        /// <summary>
        /// 適当なウィンドウ名で、始めから表示しておく画像を指定して初期化
        /// </summary>
        /// <param name="image">ウィンドウに表示する画像</param>
#else
        /// <summary>
        /// Creates a window with a random name and a specified image
        /// </summary>
        /// <param name="image"></param>
#endif
        public CvWindow(CvArr image)
            : this(DefaultName(), WindowMode.AutoSize, image)
        {
        }
#if LANG_JP
        /// <summary>
        /// 適当なウィンドウ名で、画像の表示モードを指定して初期化
        /// </summary>
        /// <param name="flags">ウィンドウのフラグ</param>
        /// <param name="image">ウィンドウに表示する画像</param>
#else
        /// <summary>
        /// Creates a window with a specified image and flag
        /// </summary>
        /// <param name="flags">Flags of the window. Currently the only supported flag is WindowMode.AutoSize. 
        /// If it is set, window size is automatically adjusted to fit the displayed image (see cvShowImage), while user can not change the window size manually. </param>
        /// <param name="image"></param>
#endif
        public CvWindow(WindowMode flags, CvArr image)
            : this(DefaultName(), flags, image)
        {
        }
#if LANG_JP
        /// <summary>
        /// ウィンドウ名を指定して初期化
        /// </summary>
        /// <param name="name">ウィンドウの識別に用いられるウィンドウ名で，ウィンドウのタイトルバ ーに表示される．</param>
#else
        /// <summary>
        /// Creates a window
        /// </summary>
        /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
#endif
        public CvWindow(string name)
            : this(name, WindowMode.AutoSize, null)
        {
        }
#if LANG_JP
        /// <summary>
        /// ウィンドウ名と画像の表示モードを指定して初期化
        /// </summary>
        /// <param name="name">ウィンドウの識別に用いられるウィンドウ名で，ウィンドウのタイトルバ ーに表示される．</param>
        /// <param name="flags">ウィンドウのフラグ</param>
#else
        /// <summary>
        /// Creates a window
        /// </summary>
        /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
        /// <param name="flags">Flags of the window. Currently the only supported flag is WindowMode.AutoSize. 
        /// If it is set, window size is automatically adjusted to fit the displayed image (see cvShowImage), while user can not change the window size manually. </param>
#endif
        public CvWindow(string name, WindowMode flags)
            : this(name, flags, null)
        {
        }
#if LANG_JP
        /// <summary>
        /// ウィンドウ名と始めから表示しておく画像を指定して初期化
        /// </summary>
        /// <param name="name">ウィンドウの識別に用いられるウィンドウ名で，ウィンドウのタイトルバ ーに表示される．</param>
        /// <param name="image">ウィンドウに表示する画像</param>
#else
        /// <summary>
        /// Creates a window
        /// </summary>
        /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
        /// <param name="image">Image to be shown.</param>
#endif
        public CvWindow(string name, CvArr image)
            : this(name, WindowMode.AutoSize, image)
        {
        }
#if LANG_JP
        /// <summary>
        /// ウィンドウ名と画像の表示モードと始めから表示しておく画像を指定して初期化
        /// </summary>
        /// <param name="name">ウィンドウの識別に用いられるウィンドウ名で，ウィンドウのタイトルバ ーに表示される．</param>
        /// <param name="flags">ウィンドウのフラグ</param>
        /// <param name="image">ウィンドウに表示する画像</param>
#else
        /// <summary>
        /// Creates a window
        /// </summary>
        /// <param name="name">Name of the window which is used as window identifier and appears in the window caption. </param>
        /// <param name="flags">Flags of the window. Currently the only supported flag is WindowMode.AutoSize. 
        /// If it is set, window size is automatically adjusted to fit the displayed image (see cvShowImage), while user can not change the window size manually. </param>
        /// <param name="image">Image to be shown.</param>
#endif
        public CvWindow(string name, WindowMode flags, CvArr image)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            _name = name;
            int status = CvInvoke.cvNamedWindow(name, flags);
            if (status == 0)
            {
                throw new OpenCvSharpException("Failed to create CvWindow");
            }
            _image = image;
            ShowImage(image);
            _trackbars = new Dictionary<string, CvTrackbar>();
            if (!Windows.ContainsKey(name))
            {
                Windows.Add(name, this);
            }
            this._callbackHandle = null;
        }
        /// <summary>
        /// ウィンドウ名が指定されなかったときに、適当な名前を作成して返す.
        /// </summary>
        /// <returns></returns>
        static private string DefaultName()
        {
            return string.Format("window{0}", windowCount++);
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
                        foreach (KeyValuePair<string, CvTrackbar> pair in _trackbars)
                        {
                            if (pair.Value != null)
                            {
                                pair.Value.Dispose();
                            }
                        }
                        try
                        {
                            Windows.Remove(_name);
                        }
                        catch (Exception) { }
                        if (_callbackHandle != null && _callbackHandle.IsAllocated)
                        {
                            _callbackHandle.Dispose();
                        }
                    }
                    CvInvoke.cvDestroyWindow(_name);
                    this._disposed = true;
                }
                finally
                {
                    // 親の解放処理
                    base.Dispose(disposing);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// ウィンドウを閉じる
        /// </summary>
#else
        /// <summary>
        /// Destroys this window. 
        /// </summary>
#endif
        public void Close()
        {
            Dispose(true);
        }

#if LANG_JP
        /// <summary>
        /// 全ての HighGUI ウィンドウを破棄する
        /// </summary>
#else
        /// <summary>
        /// Destroys all the opened HighGUI windows. 
        /// </summary>
#endif
        public static void DestroyAllWindows()
        {
            foreach (KeyValuePair<string, CvWindow> wpair in Windows)
            {
                CvWindow w = wpair.Value;
                if (w == null || w.IsDisposed)
                {
                    continue;
                }
                CvInvoke.cvDestroyWindow(w._name);
                foreach (KeyValuePair<string, CvTrackbar> tpair in w._trackbars)
                {
                    if (tpair.Value != null)
                    {
                        tpair.Value.Dispose();
                    }
                }
                //w.Dispose();
            }
            Windows.Clear();
            CvInvoke.cvDestroyAllWindows();
        }
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
		/// 表示する画像を取得・設定する
		/// </summary>
#else
        /// <summary>
        /// Gets or sets an image to be shown
        /// </summary>
#endif
        public CvArr Image
        {
            get { return _image; }
            set { ShowImage(value); }
        }
#if LANG_JP
        /// <summary>
		/// ウィンドウの名前を取得する
        /// </summary>
#else
        /// <summary>
        /// Gets window name
        /// </summary>
#endif
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
#if LANG_JP
		/// <summary>
		/// ウィンドウハンドルを取得する
        /// </summary>
#else
        /// <summary>
        /// Gets window handle
        /// </summary>
#endif
        public IntPtr Handle
        {
            get { return CvInvoke.cvGetWindowHandle(_name); }
        }

        /// <summary>
        /// 
        /// </summary>
        internal CvMouseCallback MouseCallback
        {
            get { return _mouseCallback; }
            set
            {
                if (_callbackHandle != null && _callbackHandle.IsAllocated)
                {
                    _callbackHandle.Dispose();
                }
                _mouseCallback = value;
                _callbackHandle = new ScopedGCHandle(_mouseCallback, GCHandleType.Normal);
            }
        }
#if LANG_JP
       	/// <summary>
		/// マウスイベントが発生したときのイベントハンドラ
        /// </summary>
#else
        /// <summary>
        /// Event handler to be called every time mouse event occurs in the specified window. 
        /// </summary>
#endif
        public event CvMouseCallback OnMouseCallback
        {
            add
            {
                if (_callbackHandle != null && _callbackHandle.IsAllocated)
                {
                    _callbackHandle.Dispose();
                }
                _mouseCallback += value;
                _callbackHandle = new ScopedGCHandle(_mouseCallback, GCHandleType.Normal);
                CvInvoke.cvSetMouseCallback(_name, _mouseCallback);
            }
            remove
            {
                if (_callbackHandle != null && _callbackHandle.IsAllocated)
                {
                    _callbackHandle.Dispose();
                }
                _mouseCallback -= value;
                _callbackHandle = new ScopedGCHandle(_mouseCallback, GCHandleType.Normal);
                CvInvoke.cvSetMouseCallback(_name, _mouseCallback);
            }
        }

#if LANG_JP
        /// <summary>
        /// Qtを有効にしてビルドされたhighguiライブラリであればtrueを返す
        /// </summary>
#else
        /// <summary>
        /// Returns true if the library is compiled with Qt
        /// </summary>
#endif
        public static bool HasQt
        {
            get { return CvInvoke.HasQt; }
        }
        #endregion

        #region Methods
        #region CreateTrackbar
#if LANG_JP
        /// <summary>
        /// ウィンドウにトラックバーを作成し、作成したトラックバーを返す
        /// </summary>
        /// <param name="name">トラックバーの名前</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
#else
        /// <summary>
        /// Creates the trackbar and attaches it to this window
        /// </summary>
        /// <param name="name">Name of created trackbar. </param>
        /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
        /// <returns></returns>
#endif
        public CvTrackbar CreateTrackbar(string name, CvTrackbarCallback callback)
        {
            CvTrackbar trackbar = new CvTrackbar(name, this._name, callback);
            _trackbars.Add(name, trackbar);
            return trackbar;
        }
#if LANG_JP
        /// <summary>
        /// ウィンドウにトラックバーを作成し、作成したトラックバーを返す
        /// </summary>
        /// <param name="name">トラックバーの名前</param>
        /// <param name="value">スライダの初期位置</param>
        /// <param name="max">スライダの最大値．最小値は常に 0.</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
#else
        /// <summary>
        /// Creates the trackbar and attaches it to this window
        /// </summary>
        /// <param name="name">Name of created trackbar. </param>
        /// <param name="value">The position of the slider</param>
        /// <param name="max">Maximal position of the slider. Minimal position is always 0. </param>
        /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
        /// <returns></returns>
#endif
        public CvTrackbar CreateTrackbar(string name, int value, int max, CvTrackbarCallback callback)
        {
            CvTrackbar trackbar = new CvTrackbar(name, this._name, value, max, callback);
            _trackbars.Add(name, trackbar);
            return trackbar;
        }
#if LANG_JP
        /// <summary>
        /// ウィンドウにトラックバーを作成し、作成したトラックバーを返す
        /// </summary>
        /// <param name="name">トラックバーの名前</param>
        /// <param name="value">スライダの初期位置</param>
        /// <param name="max">スライダの最大値．最小値は常に 0.</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
        /// <param name="userdata"></param>
#else
        /// <summary>
        /// Creates the trackbar and attaches it to this window
        /// </summary>
        /// <param name="name">Name of created trackbar. </param>
        /// <param name="value">The position of the slider</param>
        /// <param name="max">Maximal position of the slider. Minimal position is always 0. </param>
        /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
        /// <param name="userdata"></param>
        /// <returns></returns>
#endif
        public CvTrackbar CreateTrackbar2(string name, int value, int max, CvTrackbarCallback2 callback, object userdata)
        {
            CvTrackbar trackbar = new CvTrackbar(name, this._name, value, max, callback, userdata);
            _trackbars.Add(name, trackbar);
            return trackbar;
        }
        #endregion
        #region DisplayOverlay
#if LANG_JP
        /// <summary>
        /// ウィンドウ画像上に，delay ミリ秒間だけテキストをオーバレイ表示します．これは，画像データを変更しません．テキストは画像の一番上に表示されます．
        /// </summary>
        /// <param name="text">ウィンドウ画像上に描画される，オーバレイテキスト．</param>
        /// <param name="delayms">オーバレイテキストを表示する時間．直前のオーバレイテキストがタイムアウトするより前に，この関数が呼ばれると，タイマーは再起動されてテキストが更新されます．この値が0の場合，テキストは表示されません．</param>
#else
        /// <summary>
        /// Display text on the window's image as an overlay for delay milliseconds. This is not editing the image's data. The text is display on the top of the image.
        /// </summary>
        /// <param name="text">Overlay text to write on the window’s image</param>
        /// <param name="delayms">Delay to display the overlay text. If this function is called before the previous overlay text time out, the timer is restarted and the text updated. . If this value is zero, the text never disapers.</param>
#endif
        public void DisplayOverlay(string text, int delayms)
        {
            Cv.DisplayOverlay(_name, text, delayms);
        }
        #endregion
        #region DisplayStatusBar
#if LANG_JP
        /// <summary>
        /// ウィンドウのステータスバーに，delay ミリ秒間だけテキストを表示します．
        /// </summary>
        /// <param name="text">ウィンドウのステータスバー上に描画されるテキスト．</param>
        /// <param name="delayms">テキストが表示される時間．直前のテキストがタイムアウトするより前に，この関数が呼ばれると，タイマーは再起動されてテキストが更新されます．この値が0の場合，テキストは表示されません．</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Text to write on the window’s statusbar</param>
        /// <param name="delayms">Delay to display the text. If this function is called before the previous text time out, the timer is restarted and the text updated. If this value is zero, the text never disapers.</param>
#endif
        public void DisplayStatusBar(string text, int delayms)
        {
            Cv.DisplayStatusBar(_name, text, delayms);
        }
        #endregion
        #region GetProperty
#if LANG_JP
        /// <summary>
        /// ウィンドウのプロパティを取得する
        /// </summary>
        /// <param name="prop_id">プロパティの種類</param>
        /// <returns>プロパティの値</returns>
#else
        /// <summary>
        /// Get Property of the window
        /// </summary>
        /// <param name="prop_id">Property identifier</param>
        /// <returns>Value of the specified property</returns>
#endif
        public double GetProperty(WindowProperty prop_id)
        {
            return CvInvoke.cvGetWindowProperty(_name, prop_id);
        }
        #endregion        
        #region LoadWindowParameters
#if LANG_JP
        /// <summary>
        /// ウィンドウのパラメータを読み込みます．
        /// </summary>
#else
        /// <summary>
        /// Load parameters of the window.
        /// </summary>
#endif
        public void LoadWindowParameters()
        {
            Cv.LoadWindowParameters(_name);
        }
        #endregion
        #region Move
#if LANG_JP
	    /// <summary>
	    /// ウィンドウの位置を変更する
	    /// </summary>
	    /// <param name="x">左上のコーナーの新しい x 座標</param>
        /// <param name="y">左上のコーナーの新しい y 座標</param>
#else
        /// <summary>
        /// Sets window position
        /// </summary>
        /// <param name="x">New x coordinate of top-left corner </param>
        /// <param name="y">New y coordinate of top-left corner </param>
#endif
        public void Move(int x, int y)
        {
            CvInvoke.cvMoveWindow(_name, x, y);
        }
        #endregion
        #region Resize
#if LANG_JP
	    /// <summary>
	    /// ウィンドウサイズを変更する
	    /// </summary>
	    /// <param name="width">新しい幅</param>
        /// <param name="height">新しい高さ</param>
#else
        /// <summary>
        /// Sets window size
        /// </summary>
        /// <param name="width">New width </param>
        /// <param name="height">New height </param>
#endif
        public void Resize(int width, int height)
        {
            CvInvoke.cvResizeWindow(_name, width, height);
        }
        #endregion
        #region SaveWindowParameters
#if LANG_JP
        /// <summary>
        /// ウィンドウのパラメータを保存します．
        /// </summary>
#else
        /// <summary>
        /// Save parameters of the window.
        /// </summary>
#endif
        public void SaveWindowParameters()
        {
            Cv.SaveWindowParameters(_name);
        }
        #endregion
        #region SetProperty
#if LANG_JP
        /// <summary>
        /// ウィンドウのプロパティを設定する
        /// </summary>
        /// <param name="prop_id">プロパティの種類</param>
        /// <param name="prop_value">プロパティに設定する値</param>
#else
        /// <summary>
        /// Set Property of the window
        /// </summary>
        /// <param name="prop_id">Property identifier</param>
        /// <param name="prop_value">New value of the specified property</param>
#endif
        public void SetProperty(WindowProperty prop_id, double prop_value)
        {
            CvInvoke.cvSetWindowProperty(_name, prop_id, prop_value);
        }
        #endregion
        #region ShowImage
#if LANG_JP
        /// <summary>
	    /// 指定したウィンドウ内に画像を表示する(cvShowImage相当)．
	    /// このウィンドウのフラグに AutoSize が指定されていた場合は，画像はオリジナルサイズで表示される．
	    /// それ以外の場合，ウィンドウサイズに合わせて 表示画像サイズが変更される． 
	    /// </summary>
        /// <param name="img">画像ヘッダ</param>
#else
        /// <summary>
        /// Shows the image in this window
        /// </summary>
        /// <param name="img">Image to be shown. </param>
#endif
        public void ShowImage(CvArr img)
        {
            if (img != null)
            {
                this._image = img;
                CvInvoke.cvShowImage(_name, img.CvPtr);
            }
        }
        #endregion
        #region WaitKey
#if LANG_JP
        /// <summary>
	    /// 何かキーが押されるまで待機する．
	    /// </summary>
        /// <returns>押されたキーのキーコード</returns>
#else
        /// <summary>
        /// Waits for a pressed key
        /// </summary>
        /// <returns>Key code</returns>
#endif
        static public int WaitKey()
        {
            return CvInvoke.cvWaitKey(0);
        }
#if LANG_JP
	    /// <summary>
	    /// 何かキーが押されるか、若しくはdelayで指定した時間(ミリ秒)待機する。
	    /// </summary>
	    /// <param name="delay">遅延時間（ミリ秒）</param>
        /// <returns>キーが押された場合はそのキーコードを，キーが押されないまま指定されたタイムアウト時間が過ぎてしまった場合は -1</returns>
#else
        /// <summary>
        /// Waits for a pressed key
        /// </summary>
        /// <param name="delay">Delay in milliseconds. </param>
        /// <returns>Key code</returns>
#endif
        static public int WaitKey(int delay)
        {
            return CvInvoke.cvWaitKey(delay);
        }
        #endregion

        #region ShowImages
#if LANG_JP
        /// <summary>
	    /// 引数に指定した画像をそれぞれ別のウィンドウで表示し、キー入力待ち状態にする。
	    /// </summary>
        /// <param name="images">表示させる画像。任意の個数を指定できる。</param>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="images"></param>
#endif
        public static void ShowImages(params CvArr[] images)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (images.Length == 0)
                return;
            
            List<CvWindow> windows = new List<CvWindow>();
            foreach (CvArr img in images)
            {
                windows.Add(new CvWindow(img));
            }

            Cv.WaitKey();

            foreach (CvWindow w in windows)
            {
                w.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="images"></param>
        /// <param name="names"></param>
        public static void ShowImages(IEnumerable<CvArr> images, IEnumerable<string> names)
        {
            if (images == null)
                throw new ArgumentNullException("images");
            if (names == null)
                throw new ArgumentNullException("names");

            CvArr[] imagesArray = ToArray(images);
            string[] namesArray = ToArray(names);

            if (imagesArray.Length == 0)
                return;
            if (namesArray.Length < imagesArray.Length)
                throw new ArgumentException("names.Length < images.Length");

            List<CvWindow> windows = new List<CvWindow>();
            for (int i = 0; i < imagesArray.Length; i++)
            {
                windows.Add(new CvWindow(namesArray[i], imagesArray[i]));
            }

            Cv.WaitKey();

            foreach (CvWindow w in windows)
            {
                w.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imagesAndNames"></param>
        public static void ShowImages(params object[] imagesAndNames)
        {
            if (imagesAndNames == null)
                return;
            if (imagesAndNames.Length % 2 != 0)
                throw new ArgumentException();

            string[] namesArray = new string[imagesAndNames.Length / 2];
            CvArr[] imagesArray = new CvArr[imagesAndNames.Length / 2];

            for (int i = 0; i < imagesAndNames.Length; i+=2)
            {
                string name = imagesAndNames[i + 0] as string;
                if (name == null)
                    throw new OpenCvSharpException("Invalid name argument");
                namesArray[i/2] = name;

                CvArr arr = imagesAndNames[i + 1] as CvArr;
                if(arr == null)
                    throw new OpenCvSharpException("Invalid CvArr argument");
                imagesArray[i/2] = arr;
            }
            ShowImages(imagesArray, namesArray);
        }
        private static T[] ToArray<T>(IEnumerable<T> enumerable)
        {
            T[] arr = enumerable as T[];
            if (arr != null)
                return arr;
            return new List<T>(enumerable).ToArray();
        }
        #endregion
        #region GetWindowByName
#if LANG_JP
        /// <summary>
        /// 指定した名前に対応するウィンドウを得る
        /// </summary>
        /// <param name="name"></param>
#else
        /// <summary>
        /// Retrieves a created window by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
#endif
        static public CvWindow GetWindowByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            if (Windows.ContainsKey(name))
            {
                return Windows[name];
            }
            else
            {
                return null;
            }
        }
        #endregion
        #endregion
    }
}