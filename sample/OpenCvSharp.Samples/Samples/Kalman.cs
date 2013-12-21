using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// カルマンフィルタ
    /// </summary>
    /// <remarks>http://opencv.jp/opencv-1.1.0/document/opencvref_cv_estimators.html#decl_CvKalman</remarks>
    class Kalman
    {
        public unsafe Kalman()
        {
            // cvKalmanPredict, cvKalmanCorrect
            // カルマンフィルタを用いて回転する点を追跡する

            // A matrix data
            float[] A = new float[] { 1, 1, 0, 1 };

            using (IplImage img = new IplImage(500, 500, BitDepth.U8, 3))
            using (CvKalman kalman = new CvKalman(2, 1, 0))
            using (CvWindow window = new CvWindow("Kalman", WindowMode.AutoSize))
            {
                // state is (phi, delta_phi) - angle and angle increment
                CvMat state = new CvMat(2, 1, MatrixType.F32C1);
                CvMat process_noise = new CvMat(2, 1, MatrixType.F32C1);
                // only phi (angle) is measured
                CvMat measurement = new CvMat(1, 1, MatrixType.F32C1);

                measurement.SetZero();
                CvRandState rng = new CvRandState(0, 1, -1, DistributionType.Uniform);
                int code = -1;

                for (; ; )
                {
                    Cv.RandSetRange(rng, 0, 0.1, 0);
                    rng.DistType = DistributionType.Normal;

                    Marshal.Copy(A, 0, kalman.TransitionMatrix.Data, A.Length);
                    kalman.MeasurementMatrix.SetIdentity(1);
                    kalman.ProcessNoiseCov.SetIdentity(1e-5);
                    kalman.MeasurementNoiseCov.SetIdentity(1e-1);
                    kalman.ErrorCovPost.SetIdentity(1);
                    // choose random initial state
                    Cv.Rand(rng, kalman.StatePost);
                    rng.DistType = DistributionType.Normal;

                    for (; ; )
                    {
                        float state_angle = state.DataSingle[0];
                        CvPoint state_pt = CalcPoint(img, state_angle);

                        // predict point position
                        CvMat prediction = kalman.Predict(null);
                        float predict_angle = prediction.DataSingle[0];
                        CvPoint predict_pt = CalcPoint(img, predict_angle);

                        Cv.RandSetRange(rng, 0, Math.Sqrt(kalman.MeasurementNoiseCov.DataSingle[0]), 0);
                        Cv.Rand(rng, measurement);

                        // generate measurement
                        Cv.MatMulAdd(kalman.MeasurementMatrix, state, measurement, measurement);

                        float measurement_angle = measurement.DataArraySingle[0];
                        CvPoint measurement_pt = CalcPoint(img, measurement_angle);

                        img.SetZero();
                        DrawCross(img, state_pt, CvColor.White, 3);
                        DrawCross(img, measurement_pt, CvColor.Red, 3);
                        DrawCross(img, predict_pt, CvColor.Green, 3);
                        img.Line(state_pt, measurement_pt, new CvColor(255, 0, 0), 3, LineType.AntiAlias, 0);
                        img.Line(state_pt, predict_pt, new CvColor(255, 255, 0), 3, LineType.AntiAlias, 0);

                        // adjust Kalman filter state
                        kalman.Correct(measurement);

                        Cv.RandSetRange(rng, 0, Math.Sqrt(kalman.ProcessNoiseCov.DataSingle[0]), 0);
                        Cv.Rand(rng, process_noise);
                        Cv.MatMulAdd(kalman.TransitionMatrix, state, process_noise, state);

                        window.ShowImage(img);
                        // break current simulation by pressing a key
                        code = CvWindow.WaitKey(100);
                        if (code > 0)
                        {
                            break;
                        }
                    }
                    // exit by ESCAPE
                    if (code == 27)
                    {
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private CvPoint CalcPoint(IplImage img, float angle)
        {
            return new CvPoint
            {
                X = (int)Math.Round(img.Width / 2.0 + img.Width / 3.0 * Math.Cos(angle)),
                Y = (int)Math.Round(img.Height / 2.0 - img.Width / 3.0 * Math.Sin(angle))
            };
        }
        /// <summary>
        /// 点をプロット
        /// </summary>
        /// <param name="img"></param>
        /// <param name="center"></param>
        /// <param name="color"></param>
        /// <param name="d"></param>
        private void DrawCross(IplImage img, CvPoint center, CvColor color, int d)
        {
            img.Line(center.X - d, center.Y - d, center.X + d, center.Y + d, color, 1, 0);
            img.Line(center.X + d, center.Y - d, center.X - d, center.Y + d, color, 1, 0);
        }

    }
}
