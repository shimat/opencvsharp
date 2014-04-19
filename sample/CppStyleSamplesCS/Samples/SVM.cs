using System;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// Support Vector Machine
    /// </summary>
    /// <remarks>http://opencv.jp/sample/svm.html#svm</remarks>
    internal class SVM : ISample
    {
        private static double f(double x)
        {
            return x + 50 * Math.Sin(x / 15.0);
        }

        public void Run()
        {
            // Training data          
            var points = new CvPoint2D32f[500];
            var responses = new int[points.Length];
            var rand = new Random();
            for (int i = 0; i < responses.Length; i++)
            {
                double x = rand.Next(0, 300);
                double y = rand.Next(0, 300);
                points[i] = new CvPoint2D32f(x, y);
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
            using (var svm = new CvSVM())
            {
                // normalize data
                dataMat /= 300.0;

                var criteria = TermCriteria.Both(1000, 0.000001);
                var param = new CvSVMParams(
                    SVMType.CSvc,
                    SVMKernelType.Rbf,
                    100.0, // degree
                    100.0, // gamma
                    1.0, // coeff0
                    1.0, // c
                    0.5, // nu
                    0.1, // p
                    null,
                    criteria);
                svm.Train(dataMat, resMat, null, null, param);

                // Predict for each 300x300 pixel
                using (Mat retPlot = Mat.Zeros(300, 300, MatType.CV_8UC3))
                {
                    for (int x = 0; x < 300; x++)
                    {
                        for (int y = 0; y < 300; y++)
                        {
                            float[] sample = {x / 300f, y / 300f};
                            var sampleMat = new CvMat(1, 2, MatrixType.F32C1, sample);
                            int ret = (int)svm.Predict(sampleMat);
                            var plotRect = new CvRect(x, 300 - y, 1, 1);
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