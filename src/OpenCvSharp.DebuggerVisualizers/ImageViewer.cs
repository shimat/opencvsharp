using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCvSharp.DebuggerVisualizers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ImageViewer : Form
    {
        private readonly Bitmap bitmap;

        /// <summary>
        /// 
        /// </summary>
        public ImageViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        public ImageViewer(MatProxy proxy)
            : this()
        {
            bitmap = proxy.CreateBitmap();
        }

        /// <summary lang="zh-cn">
        /// 仅仅用于开发目的。
        /// </summary>
        /// <param name="proxy"></param>
        public ImageViewer(string imgFile)
            : this()
        {
            bitmap = new Bitmap(imgFile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var ratio = SetClientSize(new System.Drawing.Size(bitmap.Width, bitmap.Height));
            DisplayRatio(ratio);

            pictureBox.Image = bitmap;
        }

        /// <summary>
        /// ClientSizeを画面からはみ出ない大きさに調整して設定する.
        /// </summary>
        /// <param name="size"></param>
        private double SetClientSize(System.Drawing.Size size)
        {
            var screenSize = Screen.PrimaryScreen.Bounds.Size;
			var x_ratio = (double)screenSize.Width / size.Width;
			var y_ratio = (double)screenSize.Height / size.Height;
            var ratio = Math.Max(x_ratio, y_ratio);
			ratio = AutoZoom(ratio);
			size.Width = Convert.ToInt32(size.Width * ratio);
			size.Height = Convert.ToInt32(size.Height * ratio);
			ClientSize = size;
            pictureBox.Size = size;
            return ratio;
        }

        private double AutoZoom(double srcZoom)
        {
            var v1 = srcZoom;
            var lg2 = Math.Log(v1,2);
            var lgz = Math.Floor(lg2);
            var pw = lgz == lg2 ? lgz - 1 : lgz;
            var r = Math.Pow(2, pw);
            return r;
        }

        private void DisplayRatio(double ratio)
		{
            this.Text = $"ImageViewer Zoom: {ratio:P1}";
		}
	}
}
