using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.MachineLearning;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// サポートベクターマシン
    /// </summary>
    /// <remarks>http://opencv.jp/sample/svm.html#svm</remarks>
    class SVM
    {
        public SVM()
        {
            // CvSVM
            // SVMを利用して2次元ベクトルの3クラス分類問題を解く

            const int S = 1000;
            const int SIZE = 400;
            CvRNG rng = new CvRNG((ulong)DateTime.Now.Ticks);

            // (1)画像領域の確保と初期化
            using (IplImage img = new IplImage(SIZE, SIZE, BitDepth.U8, 3))
            {
                img.Zero();
                // (2)学習データの生成
                CvPoint[] pts = new CvPoint[S];
                int[] res = new int[S];
                for (int i = 0; i < S; i++)
                {
                    pts[i].X = (int)(rng.RandInt() % SIZE);
                    pts[i].Y = (int)(rng.RandInt() % SIZE);
                    if (pts[i].Y > 50 * Math.Cos(pts[i].X * Cv.PI / 100) + 200)
                    {
                        img.Line(new CvPoint(pts[i].X - 2, pts[i].Y - 2), new CvPoint(pts[i].X + 2, pts[i].Y + 2), new CvColor(255, 0, 0));
                        img.Line(new CvPoint(pts[i].X + 2, pts[i].Y - 2), new CvPoint(pts[i].X - 2, pts[i].Y + 2), new CvColor(255, 0, 0));
                        res[i] = 1;
                    }
                    else
                    {
                        if (pts[i].X > 200)
                        {
                            img.Line(new CvPoint(pts[i].X - 2, pts[i].Y - 2), new CvPoint(pts[i].X + 2, pts[i].Y + 2), new CvColor(0, 255, 0));
                            img.Line(new CvPoint(pts[i].X + 2, pts[i].Y - 2), new CvPoint(pts[i].X - 2, pts[i].Y + 2), new CvColor(0, 255, 0));
                            res[i] = 2;
                        }
                        else
                        {
                            img.Line(new CvPoint(pts[i].X - 2, pts[i].Y - 2), new CvPoint(pts[i].X + 2, pts[i].Y + 2), new CvColor(0, 0, 255));
                            img.Line(new CvPoint(pts[i].X + 2, pts[i].Y - 2), new CvPoint(pts[i].X - 2, pts[i].Y + 2), new CvColor(0, 0, 255));
                            res[i] = 3;
                        }
                    }
                }

                // (3)学習データの表示
                Cv.NamedWindow("SVM", WindowMode.AutoSize);
                Cv.ShowImage("SVM", img);
                Cv.WaitKey(0);

                // (4)学習パラメータの生成
                float[] data = new float[S * 2];
                for (int i = 0; i < S; i++)
                {
                    data[i * 2] = ((float)pts[i].X) / SIZE;
                    data[i * 2 + 1] = ((float)pts[i].Y) / SIZE;
                }

                // (5)SVMの学習
                using (CvSVM svm = new CvSVM())
                {
                    CvMat data_mat = new CvMat(S, 2, MatrixType.F32C1, data);
                    CvMat res_mat = new CvMat(S, 1, MatrixType.S32C1, res);
                    CvTermCriteria criteria = new CvTermCriteria(1000, float.Epsilon);
                    CvSVMParams param = new CvSVMParams(SVMType.CSvc, SVMKernelType.Rbf, 10.0, 8.0, 1.0, 10.0, 0.5, 0.1, null, criteria);
                    svm.Train(data_mat, res_mat, null, null, param);

                    // (6)学習結果の描画
                    for (int i = 0; i < SIZE; i++)
                    {
                        for (int j = 0; j < SIZE; j++)
                        {
                            float[] a = { (float)j / SIZE, (float)i / SIZE };
                            CvMat m = new CvMat(1, 2, MatrixType.F32C1, a);
                            float ret = svm.Predict(m);
                            CvColor color = new CvColor();
                            switch ((int)ret)
                            {
                                case 1:
                                    color = new CvColor(100, 0, 0); break;
                                case 2:
                                    color = new CvColor(0, 100, 0); break;
                                case 3:
                                    color = new CvColor(0, 0, 100); break;
                            }
                            img[i, j] = color;
                        }
                    }

                    // (7)トレーニングデータの再描画
                    for (int i = 0; i < S; i++)
                    {
                        CvColor color = new CvColor();
                        switch (res[i])
                        {
                            case 1:
                                color = new CvColor(255, 0, 0); break;
                            case 2:
                                color = new CvColor(0, 255, 0); break;
                            case 3:
                                color = new CvColor(0, 0, 255); break;
                        }
                        img.Line(new CvPoint(pts[i].X - 2, pts[i].Y - 2), new CvPoint(pts[i].X + 2, pts[i].Y + 2), color);
                        img.Line(new CvPoint(pts[i].X + 2, pts[i].Y - 2), new CvPoint(pts[i].X - 2, pts[i].Y + 2), color);
                    }

                    // (8)サポートベクターの描画
                    int sv_num = svm.GetSupportVectorCount();
                    for (int i = 0; i < sv_num; i++)
                    {
                        var support = svm.GetSupportVector(i);
                        img.Circle(new CvPoint((int)(support[0] * SIZE), (int)(support[1] * SIZE)), 5, new CvColor(200, 200, 200));
                    }

                    // (9)画像の表示
                    Cv.NamedWindow("SVM", WindowMode.AutoSize);
                    Cv.ShowImage("SVM", img);
                    Cv.WaitKey(0);
                    Cv.DestroyWindow("SVM");

                }
            }

        }
    }
}