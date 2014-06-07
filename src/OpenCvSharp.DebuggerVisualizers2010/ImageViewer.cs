using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCvSharp.DebuggerVisualizers2010
{
    /// <summary>
    /// IplImageを表示するビューア
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
        public ImageViewer(IplImageProxy proxy)
            : this()
        {
            bitmap = proxy.CreateBitmap();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetClientSize(new Size(bitmap.Width, bitmap.Height));            
            pictureBox.Image = bitmap;
        }

        /// <summary>
        /// ClientSizeを画面からはみ出ない大きさに調整して設定する.
        /// </summary>
        /// <param name="size"></param>
        private void SetClientSize(Size size)
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
            ClientSize = size;
        }
    }
}
