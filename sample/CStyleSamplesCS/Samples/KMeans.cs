using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>http://opencv.jp/sample/misc.html#color-sub</remarks>
    class KMeans
    {
        public KMeans()
        {
            // cvKMeans2

            const int maxClusters = 32;

            using (IplImage srcImg = Cv.LoadImage(FilePath.Image.Lenna, LoadMode.Color))
            using (IplImage dstImg = Cv.CloneImage(srcImg))
            {
                int size = srcImg.Width * srcImg.Height;
                using (CvMat color = Cv.CreateMat(maxClusters, 1, MatrixType.F32C3))
                using (CvMat count = Cv.CreateMat(maxClusters, 1, MatrixType.S32C1))
                using (CvMat clusters = Cv.CreateMat(size, 1, MatrixType.S32C1))
                using (CvMat points = Cv.CreateMat(size, 1, MatrixType.F32C3))
                {
                    unsafe
                    {
                        float* pMat = (float*)points.Data;       // 行列の要素へのポインタ
                        byte* pImg = (byte*)srcImg.ImageData;   // 画像の画素へのポインタ
                        for (int i = 0; i < size; i++)
                        {
                            pMat[i * 3 + 0] = pImg[i * 3 + 0];
                            pMat[i * 3 + 1] = pImg[i * 3 + 1];
                            pMat[i * 3 + 2] = pImg[i * 3 + 2];
                        }
                    }

                    Cv.KMeans2(points, maxClusters, clusters, new CvTermCriteria(10, 1.0));

                    Cv.SetZero(color);
                    Cv.SetZero(count);
                    unsafe
                    {
                        int* pClu = clusters.DataInt32;    // cluster の要素へのポインタ
                        int* pCnt = count.DataInt32;       // count の要素へのポインタ
                        float* pClr = color.DataSingle;    // color の要素へのポインタ
                        float* pPnt = points.DataSingle;   // points の要素へのポインタ
                        for (int i = 0; i < size; i++)
                        {
                            int idx = pClu[i];     // clusters->data.i[i]
                            int j = ++pCnt[idx];   // ++count->data.i[idx];
                            pClr[idx * 3 + 0] = pClr[idx * 3 + 0] * (j - 1) / j + pPnt[i * 3 + 0] / j;
                            pClr[idx * 3 + 1] = pClr[idx * 3 + 1] * (j - 1) / j + pPnt[i * 3 + 1] / j;
                            pClr[idx * 3 + 2] = pClr[idx * 3 + 2] * (j - 1) / j + pPnt[i * 3 + 2] / j;
                        }
                    }

                    unsafe
                    {
                        int* pClu = clusters.DataInt32;        // cluster の要素へのポインタ
                        float* pClr = color.DataSingle;        // color の要素へのポインタ
                        byte* pDst = (byte*)dstImg.ImageData;     // dst の画素へのポインタ
                        for (int i = 0; i < size; i++)
                        {
                            int idx = pClu[i];
                            pDst[i * 3 + 0] = (byte)pClr[idx * 3 + 0];
                            pDst[i * 3 + 1] = (byte)pClr[idx * 3 + 1];
                            pDst[i * 3 + 2] = (byte)pClr[idx * 3 + 2];
                        }
                    }
                }

                using (new CvWindow("src", WindowMode.AutoSize, srcImg))
                using (new CvWindow("low-color", WindowMode.AutoSize, dstImg))
                {
                    Cv.WaitKey(0);
                }
            }
        }
    }
}
