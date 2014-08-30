using System;
using System.Diagnostics;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System.Windows.Forms;
using OpenCvSharp.Extensions;
using SampleBase;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    class MatToBitmap : ISample
    {
        public void Run()
        {
            ToMat();
            ToMatGrayScale();
            ToBitmap();
            ToBitmapGrayScale();
        }

        public void ToBitmap()
        {
            Mat img = new Mat(FilePath.Image.Lenna511, LoadMode.Color); // width % 4 != 0

            Bitmap bitmap = BitmapConverter.ToBitmap(img);
            // Bitmap bitmap = img.ToBitmap();
            
            using (var form = new Form())
            using (var pb = new PictureBox())
            {
                pb.Image = bitmap;
                var size = new System.Drawing.Size(bitmap.Width, bitmap.Height);
                pb.ClientSize = size;
                form.ClientSize = size;
                form.Controls.Add(pb);
                form.KeyPreview = true;
                form.KeyDown += (sender, args) =>
                {
                    if (args.KeyCode.HasFlag(Keys.Enter))
                        ((Form)sender).Close();
                };
                form.Text = "Mat to Bitmap Test";

                form.ShowDialog();
            }
        }

        public void ToBitmapGrayScale()
        {
            Mat img = new Mat(FilePath.Image.Lenna511, LoadMode.GrayScale); // width % 4 != 0

            Bitmap bitmap = BitmapConverter.ToBitmap(img);
            // Bitmap bitmap = img.ToBitmap();

            using (var form = new Form())
            using (var pb = new PictureBox())
            {
                pb.Image = bitmap;
                var size = new System.Drawing.Size(bitmap.Width, bitmap.Height);
                pb.ClientSize = size;
                form.ClientSize = size;
                form.Controls.Add(pb);
                form.KeyPreview = true;
                form.KeyDown += (sender, args) =>
                {
                    if (args.KeyCode.HasFlag(Keys.Enter))
                        ((Form)sender).Close();
                };
                form.Text = "Grayscale Mat to Bitmap Test";

                form.ShowDialog();
            }
        }

        public void ToMat()
        {
            Bitmap bitmap = new Bitmap(FilePath.Image.Lenna511); // width % 4 != 0

            Mat converted = BitmapConverter.ToMat(bitmap);
            //Mat converted = Mat.FromBitmap(bitmap);

            using (new Window("Bitmap to Mat test", converted))
            {
                Cv2.WaitKey();
            }
        }

        public void ToMatGrayScale()
        {
            Mat img = new Mat(FilePath.Image.Lenna511, LoadMode.GrayScale);
            Bitmap bitmap = img.ToBitmap();

            Mat converted = BitmapConverter.ToMat(bitmap);
            //Mat converted = Mat.FromBitmap(bitmap);

            using (new Window("Grayscale Bitmap to Mat test", converted))
            {
                Cv2.WaitKey();
            }
        }
    }
}