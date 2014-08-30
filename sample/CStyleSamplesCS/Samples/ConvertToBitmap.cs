using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Image conversion to System.Drawing.Bitmap
    /// </summary>
    class ConvertToBitmap
    {        
        public ConvertToBitmap()
        {
            Bitmap bitmap = null;

            // do cvThreshold
            using (IplImage src = new IplImage(FilePath.Image.Lenna, LoadMode.GrayScale))
            using (IplImage dst = new IplImage(src.Size, BitDepth.U8, 1))
            {
                src.Smooth(src, SmoothType.Gaussian, 5);
                src.Threshold(dst, 0, 255, ThresholdType.Otsu);
                // IplImage -> Bitmap
                bitmap = dst.ToBitmap();
                //bitmap = BitmapConverter.ToBitmap(dst);
            }

            // visualize using WindowsForm
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

            form.Controls.Add(pictureBox);
            form.ShowDialog();

            form.Dispose();
            bitmap.Dispose();
        }

    }
}
