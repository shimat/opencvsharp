using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Horn & Schunck アルゴリズムによるオプティカルフローの計算
    /// </summary>
    /// <remarks>http://opencv.jp/sample/optical_flow.html#optflowHSLK</remarks>
    class OpticalFlowHS
    {
        public OpticalFlowHS()
        {
            using (IplImage srcImg1 = Cv.LoadImage(Const.ImagePenguin1, LoadMode.GrayScale))
            using (IplImage srcImg2 = Cv.LoadImage(Const.ImagePenguin1b, LoadMode.GrayScale))
            using (IplImage dstImg = Cv.LoadImage(Const.ImagePenguin1b, LoadMode.Color))
            {
                // (1)速度ベクトルを格納する構造体の確保，等
                int cols = srcImg1.Width;
                int rows = srcImg1.Height;
                using (CvMat velx = Cv.CreateMat(rows, cols, MatrixType.F32C1))
                using (CvMat vely = Cv.CreateMat(rows, cols, MatrixType.F32C1))
                {
                    Cv.SetZero(velx);
                    Cv.SetZero(vely);
                    CvTermCriteria criteria = Cv.TermCriteria(CriteriaType.Iteration | CriteriaType.Epsilon, 64, 0.01);

                    // (2)オプティカルフローを計算
                    Cv.CalcOpticalFlowHS(srcImg1, srcImg2, false, velx, vely, 100.0, criteria);

                    // (3)オプティカルフローを描画
                    for (int i = 0; i < cols; i += 5)
                    {
                        for (int j = 0; j < rows; j += 5)
                        {
                            int dx = (int)Cv.GetReal2D(velx, j, i);
                            int dy = (int)Cv.GetReal2D(vely, j, i);
                            Cv.Line(dstImg, Cv.Point(i, j), Cv.Point(i + dx, j + dy), Cv.RGB(255, 0, 0), 1, Cv.AA, 0);
                        }
                    }

                    // (4)オプティカルフローの表示
                    Cv.NamedWindow("ImageHS", WindowMode.AutoSize);
                    Cv.ShowImage("ImageHS", dstImg);
                    Cv.NamedWindow("velx", WindowMode.AutoSize);
                    Cv.ShowImage("velx", velx);
                    Cv.NamedWindow("vely", WindowMode.AutoSize);
                    Cv.ShowImage("vely", vely);
                    Cv.WaitKey(0);
                    Cv.DestroyAllWindows();
                }
            }

        }
    }
}
