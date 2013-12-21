using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;

namespace OpenCvSharp.UserInterface
{
#if LANG_JP
    /// <summary>
    /// highguiを用いない、System.Windows.FormsによるCvWindowの実装
    /// </summary>
#else
    /// <summary>
    /// Original CvWindow implementation without highgui
    /// </summary>
#endif
    public partial class CvWindowEx : Form, IDisposable
    {
        #region Fields
        private List<Keys> _pressedKeys;
        private static List<CvWindowEx> windows;
        #endregion

        #region Initialization and dispose
        /// <summary>
        /// static constructor
        /// </summary>
        static CvWindowEx()
        {
            windows = new List<CvWindowEx>();
        }

#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else 
        /// <summary>
        /// Default Constructor
        /// </summary>
#endif
        public CvWindowEx()
        {
            InitializeComponent();
            _pressedKeys = null;
            _pictureBox.Image = null;
            this.Show();
            windows.Add(this);
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="image"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image"></param>
#endif
        public CvWindowEx(IplImage image) : this()
        {
            Image = image;
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="sizeMode"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sizeMode"></param>
#endif
        public CvWindowEx(PictureBoxSizeMode sizeMode)
            : this()
        {
            _pictureBox.SizeMode = sizeMode;
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sizeMode"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sizeMode"></param>
#endif
        public CvWindowEx(IplImage image, PictureBoxSizeMode sizeMode)
            : this()
        {
            Image = image;
            _pictureBox.SizeMode = sizeMode;
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
#else
        /// <summary>
        /// Finalizer
        /// </summary>
#endif
        public new void Dispose()
        {
            base.Dispose();
            windows.Remove(this);
        }
        #endregion

        #region Event handlers
        private void CvWindowEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (_pressedKeys != null)
            {
                _pressedKeys.Add(e.KeyCode);
            }
        }
        #endregion

        #region Properties
#if LANG_JP
        /// <summary>
        /// 表示するIplImageを取得・設定する
        /// </summary>
#else
        /// <summary>
        /// Gets or sets an image to be shown
        /// </summary>
#endif
        public IplImage Image
        {
            get { return _pictureBox.ImageIpl; }
            set
            {
                if (value != null)
                {
                    CvSize size = value.Size;
                    size.Height += _panelTrackbar.ClientSize.Height;
                    SetClientSize(size);
                }
                _pictureBox.ImageIpl = value;
            }
        }
#if LANG_JP
        /// <summary>
        /// 画像を表示しているPictureBoxコントロールを取得する
        /// </summary>
#else
        /// <summary>
        /// Gets Picturebox control
        /// </summary>
#endif
        public PictureBox PictureBox
        {
            get
            {
                return _pictureBox;
            }
        }
#if LANG_JP
        /// <summary>
        /// CreateTrackbarで作成したトラックバーのリストを取得する
        /// </summary>
#else
        /// <summary>
        /// Gets all created trackbars
        /// </summary>
#endif
        public TrackbarWithLabel[] Trackbars
        {
            get
            {
                TrackbarWithLabel[] result = new TrackbarWithLabel[_panelTrackbar.Controls.Count];
                _panelTrackbar.Controls.CopyTo(result, 0);
                return result;
            }
        }
        #endregion

        #region Public methods
#if LANG_JP
        /// <summary>
        /// 指定したIplImageを表示する
        /// </summary>
        /// <param name="image"></param>
#else
        /// <summary>
        /// Shows the image in this window
        /// </summary>
        /// <param name="image">Image to be shown. </param>
#endif
        public void ShowImage(IplImage image)
        {
            Image = image;
        }
#if LANG_JP
        /// <summary>
        /// ウィンドウにトラックバーを作成し、作成したトラックバーを返す
        /// </summary>
        /// <param name="name">トラックバーの名前</param>
        /// <param name="value">スライダの初期位置</param>
        /// <param name="count">スライダの最大値．最小値は常に 0.</param>
        /// <param name="onChange">スライダの位置が変更されるたびに呼び出されるデリゲート</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Creates the trackbar and attaches it to this window
        /// </summary>
        /// <param name="name">Name of created trackbar. </param>
        /// <param name="value">The position of the slider</param>
        /// <param name="count">Maximal position of the slider. Minimal position is always 0. </param>
        /// <param name="onChange">the function to be called every time the slider changes the position. This function should be prototyped as void Foo(int);</param>
        /// <returns></returns>
#endif
        public TrackbarWithLabel CreateTrackbar(string name, int value, int count, CvTrackbarCallback onChange)
        {
            TrackbarWithLabel t = new TrackbarWithLabel(name, value, count, 0);
            t.Dock = DockStyle.Top;
            t.Trackbar.ValueChanged += delegate(object _o, EventArgs _e)
            {
                int pos = ((TrackBar)_o).Value;
                onChange(pos);
            };
            SetClientSize(new CvSize(ClientSize.Width, ClientSize.Height + t.Height));
            _panelTrackbar.Height += t.Height;
            _panelTrackbar.Controls.Add(t);
            return t;
        }

#if LANG_JP
        /// <summary>
	    /// 何かキーが押されるまで待機する．
	    /// </summary>
#else
        /// <summary>
        /// Waits for a pressed key
        /// </summary>
#endif
        public static Keys WaitKey()
        {
            return WaitKey(0);
        }
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
        public static Keys WaitKey(int delay)
        {
            Keys result = Keys.None;
            Stopwatch watch = Stopwatch.StartNew();

            foreach (CvWindowEx w in windows)
            {
                w.StartKeyCheck();
            }
            while (!ClosedAllWindows() && (delay <= 0 || watch.ElapsedMilliseconds < delay))
            {
                Application.DoEvents();
                Thread.Sleep(1);
                foreach (CvWindowEx w in windows)
                {
                    if (!w.Created)
                    {
                        continue;
                    }
                    Keys key = w.GetPressedKey();
                    if (key != Keys.None)
                    {
                        result = key;
                        goto END_WHILE;
                    }
                }                
            }
        END_WHILE:
            foreach (CvWindowEx w in windows)
            {
                w.EndKeyCheck();
            }

            return result;
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
        static public void ShowImages(params IplImage[] images)
        {
            if (images == null)
            {
                throw new ArgumentNullException("images");
            }
            if (images.Length == 0)
            {
                return;
            }
            List<CvWindowEx> windows = new List<CvWindowEx>();
            foreach (IplImage img in images)
            {
                windows.Add(new CvWindowEx(img));
            }
            WaitKey();
            foreach (CvWindowEx w in windows)
            {
                w.Close();
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        private void StartKeyCheck()
        {
            _pressedKeys = new List<Keys>();
        }
        /// <summary>
        /// 
        /// </summary>
        private void EndKeyCheck()
        {
            _pressedKeys = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool ClosedAllWindows()
        {
            foreach (CvWindowEx w in windows)
            {
                if (w.Created)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Keys GetPressedKey()
        {
            if (_pressedKeys == null || _pressedKeys.Count == 0)
                return Keys.None;
            else
                return _pressedKeys[0];
        }

        /// <summary>
        /// ClientSizeを画面からはみ出ない大きさに調整して設定する.
        /// </summary>
        /// <param name="size"></param>
        private void SetClientSize(CvSize size)
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            if (size.Width > screenSize.Width)
            {
                double ratio = (double)screenSize.Width / size.Width;
                size.Width = Convert.ToInt32(size.Width * ratio);
                size.Height = Convert.ToInt32(size.Height * ratio);
            }
            if (size.Height > screenSize.Height)
            {
                double ratio = (double)screenSize.Height / size.Height;
                size.Width = Convert.ToInt32(size.Width * ratio);
                size.Height = Convert.ToInt32(size.Height * ratio);
            }
            ClientSize = new Size(size.Width, size.Height);
        }
        #endregion

    }
}