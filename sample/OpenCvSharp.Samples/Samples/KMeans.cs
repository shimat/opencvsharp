using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// クラスタリングによる減色処理
    /// </summary>
    /// <remarks>http://opencv.jp/sample/misc.html#color-sub</remarks>
    class KMeans
    {
        public KMeans()
        {
            // cvKMeans2
            // k-means法によるクラスタリングを利用して，非常に単純な減色を行う

            // クラスタ数。この値を変えると色数が変わる
            const int maxClusters = 32;

            // (1)画像を読み込む  
            using (IplImage srcImg = Cv.LoadImage(Const.ImageLenna, LoadMode.Color))
            using (IplImage dstImg = Cv.CloneImage(srcImg))
            {
                int size = srcImg.Width * srcImg.Height;
                using (CvMat color = Cv.CreateMat(maxClusters, 1, MatrixType.F32C3))
                using (CvMat count = Cv.CreateMat(maxClusters, 1, MatrixType.S32C1))
                using (CvMat clusters = Cv.CreateMat(size, 1, MatrixType.S32C1))
                using (CvMat points = Cv.CreateMat(size, 1, MatrixType.F32C3))
                {
                    // (2)ピクセルの値を行列へ代入
                    // unsafeコードを用いて、C/C++と同様にポインタで要素にアクセスする。
                    // ポインタがないVB.NETの場合は、Marshal.Copyでマネージ配列に移し替えてからアクセスし、再びMarshal.Copyで戻せばできる？
                    // (またはMarshal.WriteInt32とか)
                    unsafe
                    {
                        // 以下のように、ポインタ変数に移し替えてからアクセスした方が良いと思われる
                        float* pMat = (float*)points.Data;       // 行列の要素へのポインタ
                        byte* pImg = (byte*)srcImg.ImageData;   // 画像の画素へのポインタ
                        for (int i = 0; i < size; i++)
                        {
                            pMat[i * 3 + 0] = pImg[i * 3 + 0];
                            pMat[i * 3 + 1] = pImg[i * 3 + 1];
                            pMat[i * 3 + 2] = pImg[i * 3 + 2];
                        }
                    }
                    // (3)クラスタリング
                    Cv.KMeans2(points, maxClusters, clusters, new CvTermCriteria(10, 1.0));
                    // (4)各クラスタの平均値を計算
                    Cv.SetZero(color);
                    Cv.SetZero(count);
                    unsafe
                    {
                        // ポインタそのままで取得できるプロパティもある
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
                    // (5)クラスタ毎に色を描画
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
                // (6)画像を表示，キーが押されたときに終了
                using (new CvWindow("src", WindowMode.AutoSize, srcImg))
                using (new CvWindow("low-color", WindowMode.AutoSize, dstImg))
                {
                    Cv.WaitKey(0);
                }
            }
        }
    }
}
