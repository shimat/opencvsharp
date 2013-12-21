using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// ブロックマッチングによるオプティカルフローの計算
    /// </summary>
    /// <remarks>http://opencv.jp/sample/optical_flow.html#optflowBM</remarks>
    class OpticalFlowBM
    {        
        public OpticalFlowBM()
        {
            // cvCalcOpticalFlowBM
            // ブロックマッチングによるオプティカルフローの計算

            const int BlockSize = 16;
            const int ShiftSize = 8;
            const int Range = 32;

            CvSize blockSize = new CvSize(BlockSize, BlockSize);
            CvSize shiftSize = new CvSize(ShiftSize, ShiftSize);
            CvSize maxRange = new CvSize(Range, Range);
            using (IplImage srcPrev = Cv.LoadImage(Const.ImagePenguin1, LoadMode.GrayScale))
            using (IplImage srcCurr = Cv.LoadImage(Const.ImagePenguin2, LoadMode.GrayScale))
            using (IplImage dst = Cv.LoadImage(Const.ImagePenguin2, LoadMode.Color))
            {               
                // (1)速度ベクトルを格納する構造体の確保  
                CvSize velSize = new CvSize
                {
                    Width = (srcPrev.Width - blockSize.Width + shiftSize.Width) / shiftSize.Width,
                    Height = (srcPrev.Height - blockSize.Height + shiftSize.Height) / shiftSize.Height
                };
                using (CvMat velx = Cv.CreateMat(velSize.Height, velSize.Width, MatrixType.F32C1))
                using (CvMat vely = Cv.CreateMat(velSize.Height, velSize.Width, MatrixType.F32C1))
                {
                    /*if (!CV_ARE_SIZES_EQ(srcA, srcB) ||
                        !CV_ARE_SIZES_EQ(velx, vely) ||
                        velx->width != velSize.width ||
                        vely->height != velSize.height)
                        CV_Error(CV_StsUnmatchedSizes, "");*/
                    if (srcPrev.Size != srcCurr.Size)
                        throw new Exception();
                    if (velx.Width != vely.Width)
                        throw new Exception();
                    if (velx.Height != vely.Height)
                        throw new Exception();
                    if (velx.Cols != velSize.Width)
                        throw new Exception();
                    if (vely.Rows != velSize.Height)
                        throw new Exception();

                    Cv.SetZero(velx);
                    Cv.SetZero(vely);
                    // (2)オプティカルフローの計算 
                    Cv.CalcOpticalFlowBM(srcPrev, srcCurr, blockSize, shiftSize, maxRange, false, velx, vely);
                    // (3)計算されたフローを描画  
                    for (int r = 0; r < velx.Rows; r++)
                    {
                        for (int c = 0; c < vely.Cols; c++)
                        {                            
                            int dx = (int)Cv.GetReal2D(velx, r, c);
                            int dy = (int)Cv.GetReal2D(vely, r, c);
                            //Console.WriteLine("i:{0} j:{1} dx:{2} dy:{3}", i, j, dx, dy);
                            if (dx != 0 || dy != 0)
                            {
                                CvPoint p1 = new CvPoint(c * ShiftSize, r * ShiftSize);
                                CvPoint p2 = new CvPoint(c * ShiftSize + dx, r * ShiftSize + dy);
                                Cv.Line(dst, p1, p2, CvColor.Red, 1, LineType.AntiAlias, 0);
                            }                            
                        }
                    }

                    using (CvWindow windowPrev = new CvWindow("prev", srcPrev))
                    using (CvWindow windowCurr = new CvWindow("curr", srcCurr))
                    using (CvWindow windowDst = new CvWindow("dst", dst))
                    //using (CvWindow windowVelX = new CvWindow("velx", velx))
                    //using (CvWindow windowVelY = new CvWindow("vely", vely))
                    {
                        Cv.WaitKey(0);
                    }
                }

            }
        }
    }
}
