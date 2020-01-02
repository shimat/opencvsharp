using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;
// ReSharper disable UnusedMember.Local

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// HighGUIウィンドウのラッパー
    /// </summary>
#else
    /// <summary>
    /// Wrapper of HighGUI window
    /// </summary>
#endif
    public class Window : DisposableObject
    {
        #region Field

        internal static Dictionary<string, Window> Windows = new Dictionary<string, Window>();
        private static uint windowCount;

        private string name;
        private Mat? image;
        private MouseCallback? mouseCallback;
        // ReSharper disable once IdentifierTypo
        private readonly Dictionary<string, CvTrackbar> trackbars;
        private ScopedGCHandle? callbackHandle;

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
        public Window()
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
        public Window(Mat image)
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
        public Window(WindowMode flags, Mat? image)
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
        public Window(string name)
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
        public Window(string name, WindowMode flags)
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
        public Window(string name, Mat? image)
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
        public Window(string name, WindowMode flags, Mat? image)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            NativeMethods.highgui_namedWindow(name, (int) flags);

            this.image = image;
            ShowImage(image);
            trackbars = new Dictionary<string, CvTrackbar>();
            if (!Windows.ContainsKey(name))
            {
                Windows.Add(name, this);
            }
            callbackHandle = null;
        }

        /// <summary>
        /// ウィンドウ名が指定されなかったときに、適当な名前を作成して返す.
        /// </summary>
        /// <returns></returns>
        private static string DefaultName()
        {
            return $"window{windowCount++}";
        }

        /// <summary>
        /// Releases managed resources
        /// </summary>
        protected override void DisposeManaged()
        {
            foreach (var pair in trackbars)
            {
                pair.Value?.Dispose();
            }
            if (Windows.ContainsKey(name))
            {
                Windows.Remove(name);
            }
            if (callbackHandle != null && callbackHandle.IsAllocated)
            {
                callbackHandle.Dispose();
            }
            base.DisposeManaged();
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
            Dispose();
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
            foreach (var window in Windows.Values)
            {
                if (window == null || window.IsDisposed)
                {
                    continue;
                }
                NativeMethods.highgui_destroyWindow(window.name);
                foreach (var trackbar in window.trackbars.Values)
                {
                    trackbar?.Dispose();
                }
                //w.Dispose();
            }
            Windows.Clear();
            NativeMethods.highgui_destroyAllWindows();
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
        public Mat? Image
        {
            get { return image; }
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
            get { return name; }
            private set { name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        internal MouseCallback? MouseCallback
        {
            get => mouseCallback;
            set
            {
                if (callbackHandle != null && callbackHandle.IsAllocated)
                {
                    callbackHandle.Dispose();
                }
                mouseCallback = value;
                callbackHandle = (mouseCallback == null) ? null : new ScopedGCHandle(mouseCallback, GCHandleType.Normal);
            }
        }

        #endregion

        #region Methods

        #region CreateTrackbar

#if LANG_JP
        /// <summary>
        /// ウィンドウにトラックバーを作成し、作成したトラックバーを返す
        /// </summary>
        /// <param name="trackbarName">トラックバーの名前</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
#else
        /// <summary>
        /// Creates the trackbar and attaches it to this window
        /// </summary>
        /// <param name="trackbarName">Name of created trackbar. </param>
        /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
        /// <returns></returns>
#endif
        public CvTrackbar CreateTrackbar(string trackbarName, CvTrackbarCallback callback)
        {
            var trackbar = new CvTrackbar(trackbarName, name, callback);
            trackbars.Add(trackbarName, trackbar);
            return trackbar;
        }

#if LANG_JP
        /// <summary>
        /// ウィンドウにトラックバーを作成し、作成したトラックバーを返す
        /// </summary>
        /// <param name="trackbarName">トラックバーの名前</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
#else
        /// <summary>
        /// Creates the trackbar and attaches it to this window
        /// </summary>
        /// <param name="trackbarName">Name of created trackbar. </param>
        /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
        /// <returns></returns>
#endif
        public CvTrackbar CreateTrackbar(string trackbarName, CvTrackbarCallback2 callback)
        {
            var trackbar = new CvTrackbar(trackbarName, name, callback);
            trackbars.Add(trackbarName, trackbar);
            return trackbar;
        }

#if LANG_JP
        /// <summary>
        /// ウィンドウにトラックバーを作成し、作成したトラックバーを返す
        /// </summary>
        /// <param name="trackbarName">トラックバーの名前</param>
        /// <param name="value">スライダの初期位置</param>
        /// <param name="max">スライダの最大値．最小値は常に 0.</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
#else
        /// <summary>
        /// Creates the trackbar and attaches it to this window
        /// </summary>
        /// <param name="trackbarName">Name of created trackbar. </param>
        /// <param name="value">The position of the slider</param>
        /// <param name="max">Maximal position of the slider. Minimal position is always 0. </param>
        /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
        /// <returns></returns>
#endif
        public CvTrackbar CreateTrackbar(string trackbarName, int value, int max, CvTrackbarCallback callback)
        {
            var trackbar = new CvTrackbar(trackbarName, name, value, max, callback);
            trackbars.Add(trackbarName, trackbar);
            return trackbar;
        }

#if LANG_JP
        /// <summary>
        /// ウィンドウにトラックバーを作成し、作成したトラックバーを返す
        /// </summary>
        /// <param name="trackbarName">トラックバーの名前</param>
        /// <param name="value">スライダの初期位置</param>
        /// <param name="max">スライダの最大値．最小値は常に 0.</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
#else
        /// <summary>
        /// Creates the trackbar and attaches it to this window
        /// </summary>
        /// <param name="trackbarName">Name of created trackbar. </param>
        /// <param name="value">The position of the slider</param>
        /// <param name="max">Maximal position of the slider. Minimal position is always 0. </param>
        /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
        /// <returns></returns>
#endif
        public CvTrackbar CreateTrackbar(string trackbarName, int value, int max, CvTrackbarCallback2 callback)
        {
            var trackbar = new CvTrackbar(trackbarName, name, value, max, callback, null);
            trackbars.Add(trackbarName, trackbar);
            return trackbar;
        }

#if LANG_JP
        /// <summary>
        /// ウィンドウにトラックバーを作成し、作成したトラックバーを返す
        /// </summary>
        /// <param name="trackbarName">トラックバーの名前</param>
        /// <param name="value">スライダの初期位置</param>
        /// <param name="max">スライダの最大値．最小値は常に 0.</param>
        /// <param name="callback">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
        /// <param name="userData"></param>
#else
        /// <summary>
        /// Creates the trackbar and attaches it to this window
        /// </summary>
        /// <param name="trackbarName">Name of created trackbar. </param>
        /// <param name="value">The position of the slider</param>
        /// <param name="max">Maximal position of the slider. Minimal position is always 0. </param>
        /// <param name="callback">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
        /// <param name="userData"></param>
        /// <returns></returns>
#endif
        public CvTrackbar CreateTrackbar2(string trackbarName, int value, int max, CvTrackbarCallback2 callback, object userData)
        {
            var trackbar = new CvTrackbar(trackbarName, name, value, max, callback, userData);
            trackbars.Add(trackbarName, trackbar);
            return trackbar;
        }

        #endregion

        #region DisplayOverlay

#if LANG_JP
        /// <summary>
        /// ウィンドウ画像上に，delay ミリ秒間だけテキストをオーバレイ表示します．これは，画像データを変更しません．テキストは画像の一番上に表示されます．
        /// </summary>
        /// <param name="text">ウィンドウ画像上に描画される，オーバレイテキスト．</param>
        /// <param name="delayMs">オーバレイテキストを表示する時間．直前のオーバレイテキストがタイムアウトするより前に，この関数が呼ばれると，タイマーは再起動されてテキストが更新されます．この値が0の場合，テキストは表示されません．</param>
#else
        /// <summary>
        /// Display text on the window's image as an overlay for delay milliseconds. This is not editing the image's data. The text is display on the top of the image.
        /// </summary>
        /// <param name="text">Overlay text to write on the window’s image</param>
        /// <param name="delayMs">Delay to display the overlay text. If this function is called before the previous overlay text time out, the timer is restarted and the text updated.
        /// If this value is zero, the text never disappears.</param>
#endif
        public void DisplayOverlay(string text, int delayMs)
        {
            throw new NotImplementedException();
            //Cv.DisplayOverlay(name, text, delayms);
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
            throw new NotImplementedException();
            //Cv.DisplayStatusBar(name, text, delayms);
        }

        #endregion

        #region GetProperty

#if LANG_JP
    /// <summary>
    /// ウィンドウのプロパティを取得する
    /// </summary>
    /// <param name="propId">プロパティの種類</param>
    /// <returns>プロパティの値</returns>
#else
        /// <summary>
        /// Get Property of the window
        /// </summary>
        /// <param name="propId">Property identifier</param>
        /// <returns>Value of the specified property</returns>
#endif
        public double GetProperty(WindowProperty propId)
        {
            return Cv2.GetWindowProperty(name, propId);
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
            throw new NotImplementedException();
            //Cv.LoadWindowParameters(name);
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
            NativeMethods.highgui_moveWindow(name, x, y);
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
            NativeMethods.highgui_resizeWindow(name, width, height);
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
            throw new NotImplementedException();
            //Cv.SaveWindowParameters(name);
        }

        #endregion

        #region SetProperty

#if LANG_JP
    /// <summary>
    /// ウィンドウのプロパティを設定する
    /// </summary>
    /// <param name="propId">プロパティの種類</param>
    /// <param name="propValue">プロパティに設定する値</param>
#else
        /// <summary>
        /// Set Property of the window
        /// </summary>
        /// <param name="propId">Property identifier</param>
        /// <param name="propValue">New value of the specified property</param>
#endif
        public void SetProperty(WindowProperty propId, double propValue)
        {
            Cv2.SetWindowProperty(name, propId, propValue);
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
        public void ShowImage(Mat? img)
        {
            if (img != null)
            {
                image = img;
                NativeMethods.highgui_imshow(name, img.CvPtr);
                GC.KeepAlive(img);
            }
        }

        #endregion

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
        public static int WaitKey(int delay = 0)
        {
            return Cv2.WaitKey(delay);
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
            return Cv2.WaitKeyEx(delay);
        }

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
        public static void ShowImages(params Mat[] images)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (images.Length == 0)
                return;

            var windows = new List<Window>();
            foreach (var img in images)
            {
                windows.Add(new Window(img));
            }

            WaitKey();

            foreach (var w in windows)
            {
                w.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images"></param>
        /// <param name="names"></param>
        public static void ShowImages(IEnumerable<Mat> images, IEnumerable<string> names)
        {
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (names == null)
                throw new ArgumentNullException(nameof(names));

            var imagesArray = images.ToArray();
            var namesArray = names.ToArray();

            if (imagesArray.Length == 0)
                return;
            if (namesArray.Length < imagesArray.Length)
                throw new ArgumentException("names.Length < images.Length");

            var windows = new List<Window>();
            for (var i = 0; i < imagesArray.Length; i++)
            {
                windows.Add(new Window(namesArray[i], imagesArray[i]));
            }

            Cv2.WaitKey();

            foreach (var w in windows)
            {
                w.Close();
            }
        }
        
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
        public static Window? GetWindowByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            
            if (Windows.ContainsKey(name))
                return Windows[name];
            
            return null;
        }

#if LANG_JP
        /// <summary>
        /// 指定されたウィンドウ内で発生するマウスイベントに対するコールバック関数を設定する
        /// </summary>
        /// <param name="onMouse">指定されたウィンドウ内でマウスイベントが発生するたびに呼ばれるデリゲート</param>
        /// <param name="userdata"></param>
#else
        /// <summary>
        /// Sets the callback function for mouse events occuting within the specified window.
        /// </summary>
        /// <param name="onMouse">Reference to the function to be called every time mouse event occurs in the specified window. </param>
        /// <param name="userData"></param>
#endif
        public void SetMouseCallback(MouseCallback onMouse, IntPtr userData = default)
        {
            Cv2.SetMouseCallback(name, onMouse, userData);
        }

        #endregion
    }
}