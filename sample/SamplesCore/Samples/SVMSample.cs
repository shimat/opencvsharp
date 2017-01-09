using System;
using OpenCvSharp;
using OpenCvSharp.ML;

namespace SamplesCore
{
    /// <summary>
    /// Support Vector Machine
    /// </summary>
    /// <remarks>http://opencv.jp/sample/svm.html#svm</remarks>
    internal class SVMSample : ISample
    {
        private static double f(double x)
        {
            return x + 50 * Math.Sin(x / 15.0);
        }

        public void Run()
        {
            // Training data          
            var points = new Point2f[500];
            var responses = new int[points.Length];
            var rand = new Random();
            for (int i = 0; i < responses.Length; i++)
            {
                float x = rand.Next(0, 300);
                float y = rand.Next(0, 300);
                points[i] = new Point2f(x, y);
                responses[i] = (y > f(x)) ? 1 : 2;
            }

            // Show training data and f(x)
            using (Mat pointsPlot = Mat.Zeros(300, 300, MatType.CV_8UC3))
            {
                for (int i = 0; i < points.Length; i++)
                {
                    int x = (int)points[i].X;
                    int y = (int)(300 - points[i].Y);
                    int res = responses[i];
                    Scalar color = (res == 1) ? Scalar.Red : Scalar.GreenYellow;
                    pointsPlot.Circle(x, y, 2, color, -1);
                }
                // f(x)
                for (int x = 1; x < 300; x++)
                {
                    int y1 = (int)(300 - f(x - 1));
                    int y2 = (int)(300 - f(x));
                    pointsPlot.Line(x - 1, y1, x, y2, Scalar.LightBlue, 1);
                }
                Window.ShowImages(pointsPlot);
            }

            // Train
            var dataMat = new Mat(points.Length, 2, MatType.CV_32FC1, points);
            var resMat = new Mat(responses.Length, 1, MatType.CV_32SC1, responses);
            using (var svm = SVM.Create())
            {
                // normalize data
                dataMat /= 300.0;

                // SVM parameters
                svm.Type = SVM.Types.CSvc;
                svm.KernelType = SVM.KernelTypes.Rbf;
                svm.TermCriteria = TermCriteria.Both(1000, 0.000001);
                svm.Degree = 100.0;
                svm.Gamma = 100.0;
                svm.Coef0 = 1.0;
                svm.C = 1.0;
                svm.Nu = 0.5;
                svm.P = 0.1;

                svm.Train(dataMat, SampleTypes.RowSample, resMat);

                // Predict for each 300x300 pixel
                using (Mat retPlot = Mat.Zeros(300, 300, MatType.CV_8UC3))
                {
                    for (int x = 0; x < 300; x++)
                    {
                        for (int y = 0; y < 300; y++)
                        {
                            float[] sample = {x / 300f, y / 300f};
                            var sampleMat = new Mat(1, 2, MatType.CV_32FC1, sample);
                            int ret = (int)svm.Predict(sampleMat);
                            var plotRect = new Rect(x, 300 - y, 1, 1);
                            if (ret == 1)
                                retPlot.Rectangle(plotRect, Scalar.Red);
                            else if (ret == 2)
                                retPlot.Rectangle(plotRect, Scalar.GreenYellow);
                        }
                    }
                    Window.ShowImages(retPlot);
                }
            }
        }

    }
}