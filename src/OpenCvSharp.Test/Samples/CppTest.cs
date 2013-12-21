using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// OpenCV2.0の C++ interface っぽい新インターフェイスの実験場
    /// </summary>
    class CppTest
    {
        public CppTest()
        {
            //PixelAccess();

            using (Mat mat = new Mat(Const.ImageLenna, LoadMode.Color))
            {
                //CvSize s;
                //CvPoint p;
                //mat.LocateROI(out s, out p);

                // CvMatへの変換
                CvMat m = mat.ToCvMat();
                Console.WriteLine(m);

                // 行を一部分切り出し
                Mat row = mat.RowRange(100, 200);

                // IplImageへ変換し、highguiにより描画
                IplImage img = row.ToIplImage();
                using (new CvWindow("highgui", img))
                {
                    Cv.WaitKey();
                }

                // Bitmapに変換して、WindowsFormで描画する
                using (Bitmap bitmap = mat.ToBitmap())
                using (Form form = new Form() { Text = "WindowsForms", ClientSize = new System.Drawing.Size(bitmap.Width, bitmap.Height) })
                using (PictureBox pb = new PictureBox() { Image = bitmap, Dock = DockStyle.Fill })
                {
                    form.Controls.Add(pb);
                    Application.Run(form);
                }

                // cv::imshowによる表示
                CvCpp.NamedWindow("imshow", WindowMode.AutoSize);
                CvCpp.ImShow("imshow", mat);
                CvCpp.WaitKey(0);
                Cv.DestroyAllWindows();
            }
        }

        private void PixelAccess()
        {
            using (Mat mat = new Mat(128, 128, MatrixType.U8C1))
            {
                for (int y = 0; y < mat.Rows; y++)
                {
                    for (int x = 0; x < mat.Cols; x++)
                    {
                        mat.Set<byte>(y, x, (byte)(y + x));
                    }
                }
                using (new CvWindow("PixelAccess", mat.ToIplImage()))
                {
                    Cv.WaitKey();
                }
            }
        }
    }
}