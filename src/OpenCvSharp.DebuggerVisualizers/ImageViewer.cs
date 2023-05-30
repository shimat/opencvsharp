using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCvSharp.DebuggerVisualizers
{
    public partial class ImageViewer : Form
    {
        private readonly Bitmap bitmap;

        public ImageViewer()
        {
            InitializeComponent();
            this.MouseWheel += MainForm_MouseWheel;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MouseMove += MainForm_MouseMove;
            this.MouseDown += MainForm_MouseDown;
 
            this.MouseUp += MainForm_MouseUp;

            this.DoubleBuffered = true;

        }

        public ImageViewer(MatProxy proxy)
            : this()
        {
            bitmap = proxy.CreateBitmap();
        }

        /// <summary lang="zh-CN">
        /// 仅仅用于开发目的。
        /// </summary>
        /// <summary lang="ja-JP">
        /// デバッグのみを目的としています。
        /// </summary>
        /// <param name="imgFile"></param>
        public ImageViewer(string imgFile)
            : this()
        {
            bitmap = new Bitmap(imgFile);
        }

        private void DisposeBitmap()
        {
            bitmap?.Dispose();
        }
 

        /// <summary>
        /// 最小缩放尺寸
        /// </summary>
        int minZoom = 1;

        /// <summary>
        /// 缩放尺寸
        /// </summary>
        int zoom = 1;
        /// <summary>
        /// 滚动缩放图片,像素级别放大,不模糊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseWheel(object  sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoom++;
            }
            else
            { zoom--; }

            if (zoom < minZoom)
            {
                zoom = minZoom;
            }
            else if (zoom > 100)
            {
                zoom = 100;
            }

            Zoom();
        }
        /// <summary>
        /// 缩放图片的时候,更改winform的大小.
        /// </summary>
        private void Zoom()
        {
            if (bitmap != null)
            {
                var bitmap2 = new Bitmap(bitmap, bitmap.Width * zoom, bitmap.Height * zoom);
                using (Graphics graphics = Graphics.FromImage(bitmap2))
                {
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                    graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height));
                }
                this.BackgroundImage = bitmap2;
                this.ClientSize = bitmap2.Size;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.BackgroundImage = bitmap;
            this.BackgroundImageLayout = ImageLayout.Center;

            while (BackgroundImage.Size.Width < 120|| BackgroundImage.Size.Height<80)
            {
                zoom++;
                Zoom();
                minZoom = zoom;            }
            this.ClientSize = BackgroundImage.Size;

        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            //获取当前鼠标处的像素点的值
           
            if (isDragging)
            {
                this.Left += e.X - offsetX;
                this.Top += e.Y - offsetY;
            } 
            else if (bitmap != null)
            {
                try
                {
                    var color = bitmap.GetPixel(e.X / zoom, e.Y / zoom);
                    this.Text = $"看图-X:{e.X / zoom} Y:{e.Y / zoom} R:{color.R} G:{color.G} B:{color.B}";
                }
                catch (Exception ex)
                {

                }

            }

        }
        private bool isDragging;
        private int offsetX;
        private int offsetY;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offsetX = e.X;
                offsetY = e.Y;
            }
        }

      

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
