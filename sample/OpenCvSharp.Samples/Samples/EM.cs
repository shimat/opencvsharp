using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.MachineLearning;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// EMアルゴリズム
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/opencv-1.1.0/document/opencvref_ml_em.html#decl_CvEM
    /// </remarks>
    class EM
    {
        /*
        /// <summary>
        /// このサンプルの処理モード。適宜切り替えてください
        /// </summary>
        enum TrainMode
        {
            Spherical,
            Diagonal
        }
        static TrainMode Mode = TrainMode.Diagonal;


        // 定数
        const int N = 4;
        static readonly int N1 = (int)Math.Sqrt(N);
        static readonly CvColor[] COLORS = { new CvColor(0, 0, 255), new CvColor(0, 255, 0), new CvColor(255, 255, 0), new CvColor(0, 255, 255), };
        const int N_SAMPLES = 100;


        /// <summary>
        /// ここから処理開始
        /// </summary>
        public EM()
        {
            // CvEM
            // SVMを利用して2次元ベクトルの3クラス分類問題を解く

            CvRNG rng_state = new CvRNG((ulong)DateTime.Now.Ticks);
            CvMat samples = new CvMat(N_SAMPLES, 2, MatrixType.F32C1);
            CvMat labels = new CvMat(N_SAMPLES, 1, MatrixType.S32C1);
            IplImage img = new IplImage(500, 500, BitDepth.U8, 3);
            float[] _sample = new float[2];
            CvMat sample = new CvMat(1, 2, MatrixType.F32C1, _sample);

            Cv.Reshape(samples, samples, 2, 0);
            for (int i = 0; i < N; i++)
            {
                // 学習サンプルから
                CvMat samples_part;
                Cv.GetRows(samples, out samples_part, i * N_SAMPLES / N, (i + 1) * N_SAMPLES / N);
                CvScalar mean = new CvScalar(((i % N1) + 1.0) * img.Width / (N1 + 1), ((i / N1) + 1.0) * img.Height / (N1 + 1));
                CvScalar sigma = new CvScalar(30, 30);
                Cv.RandArr(rng_state, samples_part, DistributionType.Normal, mean, sigma);
            }
            Cv.Reshape(samples, samples, 1, 0);

            // モデルパラメータの初期化
            CvEMParams param = new CvEMParams()
            {
                Covs = null,
                Means = null,
                Weights = null,
                Probs = null,
                NClusters = N,
                CovMatType = EMCovMatType.Spherical,
                StartStep = EMStartStep.Auto,
                TermCrit = new CvTermCriteria(10, 0.1)
            };

            // データのクラスタリング
            switch (Mode)
            {
                case TrainMode.Spherical:
                    TestSpherical(samples, param, labels, sample, img);
                    break;
                case TrainMode.Diagonal:
                    TestDiagonal(samples, param, labels, sample, img);
                    break;
                default:
                    throw new Exception();
            }
            
            // クラスタリング後のサンプルを描画
            for (int i = 0; i < N_SAMPLES; i++)
            {
                CvPoint pt = new CvPoint()
                {
                    X = Cv.Round(samples.DataArraySingle[i * 2]),
                    Y = Cv.Round(samples.DataArraySingle[i * 2 + 1])
                };
                img.Circle(pt, 1, COLORS[labels.DataArrayInt32[i] % COLORS.Length], Cv.FILLED);
            }

            using (CvWindow window = new CvWindow("EM-clustering result"))
            {
                window.ShowImage(img);
                Cv.WaitKey();
            }

            img.Dispose();

        }

        /// <summary>
        /// 普通のTrain
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="param"></param>
        /// <param name="labels"></param>
        /// <param name="sample"></param>
        /// <param name="img"></param>
        private void TestSpherical(CvMat samples, CvEMParams param, CvMat labels, CvMat sample, IplImage img)
        {
            // データのクラスタリング
            using (CvEM em = new CvEM())
            {
                em.Train(samples, null, param, labels);

                // 画像の各ピクセルを分類する
                Cv.Zero(img);
                for (int i = 0; i < img.Height; i++)
                {
                    for (int j = 0; j < img.Width; j++)
                    {
                        CvPoint pt = new CvPoint(j, i);
                        sample.DataArraySingle[0] = (float)j;
                        sample.DataArraySingle[1] = (float)i;
                        int response = Cv.Round(em.Predict(sample, null));
                        CvColor c = COLORS[response % COLORS.Length];

                        img.Circle(pt, 1, new CvColor((byte)(c.R * 0.75), (byte)(c.G * 0.75), (byte)(c.B * 0.75)), Cv.FILLED);
                    }
                }
            }
        }

        /// <summary>
        /// 初期ステージの出力を第2ステージの入力として使用する場合に，
        /// 拘束の小さいパラメータ(COV_MAT_SPHERICALの代わりにCOV_MAT_DIAGONAL)を使って
        /// モデルの最適化の繰返しを行う例
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="param"></param>
        /// <param name="labels"></param>
        /// <param name="sample"></param>
        /// <param name="img"></param>
        private void TestDiagonal(CvMat samples, CvEMParams param, CvMat labels, CvMat sample, IplImage img)
        {
            // データのクラスタリング
            using (CvEM em = new CvEM())
            {
                em.Train(samples, null, param, labels);

                param.CovMatType = CvEM.COV_MAT_DIAGONAL;
                param.StartStep = CvEM.START_E_STEP;
                param.Means = em.GetMeans();
                param.Covs = em.GetCovs();
                param.Weights = em.GetWeights();

                using (CvEM em2 = new CvEM())
                {
                    em2.Train(samples, null, param, labels);

                    // 画像の各ピクセルを分類する
                    Cv.Zero(img);
                    for (int i = 0; i < img.Height; i++)
                    {
                        for (int j = 0; j < img.Width; j++)
                        {
                            CvPoint pt = new CvPoint(j, i);
                            sample.DataArraySingle[0] = (float)j;
                            sample.DataArraySingle[1] = (float)i;
                            int response = Cv.Round(em2.Predict(sample, null));
                            CvColor c = COLORS[response % COLORS.Length];

                            img.Circle(pt, 1, new CvColor((byte)(c.R * 0.75), (byte)(c.G * 0.75), (byte)(c.B * 0.75)), Cv.FILLED);
                        }
                    }
                }
            }
        }
        //*/
    }

}
