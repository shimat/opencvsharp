using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Lucas & Kanade optical flow
    /// </summary>
    /// <remarks>http://opencv.jp/sample/optical_flow.html#optflowHSLK</remarks>
    class OpticalFlowLK
    {
        public OpticalFlowLK()
        {
            using (IplImage srcImg1 = Cv.LoadImage(FilePath.Image.Penguin1, LoadMode.GrayScale))
            using (IplImage srcImg2 = Cv.LoadImage(FilePath.Image.Penguin1b, LoadMode.GrayScale))
            using (IplImage dstImg = Cv.LoadImage(FilePath.Image.Penguin1b, LoadMode.Color))
            {
                // (1)
                int cols = srcImg1.Width;
                int rows = srcImg1.Height;
                using (CvMat velx = Cv.CreateMat(rows, cols, MatrixType.F32C1))
                using (CvMat vely = Cv.CreateMat(rows, cols, MatrixType.F32C1))
                {
                    Cv.SetZero(velx);
                    Cv.SetZero(vely);

                    // (2) calc optical flow
                    Cv.CalcOpticalFlowLK(srcImg1, srcImg2, Cv.Size(15, 15), velx, vely);

                    // (3) drawing
                    for (int i = 0; i < cols; i += 5)
                    {
                        for (int j = 0; j < rows; j += 5)
                        {
                            int dx = (int)Cv.GetReal2D(velx, j, i);
                            int dy = (int)Cv.GetReal2D(vely, j, i);
                            Cv.Line(dstImg, Cv.Point(i, j), Cv.Point(i + dx, j + dy), Cv.RGB(255, 0, 0), 1, Cv.AA, 0);
                        }
                    }

                    // (4) create window and show results
                    Cv.NamedWindow("ImageLK", WindowMode.AutoSize);
                    Cv.ShowImage("ImageLK", dstImg);
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
