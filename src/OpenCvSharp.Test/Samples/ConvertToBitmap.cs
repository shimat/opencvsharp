using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// System.Drawing.Bitmapへの変換
    /// </summary>
    class ConvertToBitmap
    {        
        public ConvertToBitmap()
        {
            Bitmap bitmap = null;

            // OpenCVによる画像処理 (Threshold)
            using (IplImage src = new IplImage(Const.ImageLenna, LoadMode.GrayScale))
            using (IplImage dst = new IplImage(src.Size, BitDepth.U8, 1))
            {
                src.Smooth(src, SmoothType.Gaussian, 5);
                src.Threshold(dst, 0, 255, ThresholdType.Otsu);
                // IplImage -> Bitmap
                bitmap = dst.ToBitmap();
                //bitmap = BitmapConverter.ToBitmap(dst);
            }

            // WindowsFormに表示してみる
            Form form = new Form
            {
                Text = "from IplImage to Bitmap",
                ClientSize = bitmap.Size,
            };
            PictureBox pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = bitmap
            };
            /*
            Imageプロパティに設定するのはもしかするとちょっと微妙、できればこのように
            pictureBox.Paint += delegate(object sender, PaintEventArgs e) {
                e.Graphics.DrawImage(bitmap, new Rectangle(new Point(0, 0), form.ClientSize));
            };
            */
            form.Controls.Add(pictureBox);
            form.ShowDialog();

            form.Dispose();
            bitmap.Dispose();
        }

    }
}
