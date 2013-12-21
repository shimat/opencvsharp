using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Locality Sensitive Hashing
    /// </summary>
    /// <remarks>
    /// http://moscoso.org/pub/video/opencv/svn/opencvlibrary/trunk/opencv/tests/python/lsh_tests.py
    /// </remarks>
    class LSH
    {
        public LSH()
        {
            const int D = 64;
            const int N = 10000;
            const int K = 1;

            // constructs a LSH table
            using (CvLSH lsh = Cv.CreateMemoryLSH(D, N))
            {
                // creates test data
                Random rand = new Random();
                CvMat data = CreateRandomData(N, D, rand);
                CvMat queryPoints = CreateQueryPoints(data, rand);                

                // adds vectors to the LSH
                Cv.LSHAdd(lsh, data);

                // queries the LSH n times for at most k nearest points
                CvMat indices = new CvMat(N, K, MatrixType.S32C1);
                CvMat dist = new CvMat(N, K, MatrixType.F64C1);
                Cv.LSHQuery(lsh, queryPoints, indices, dist, K, 100);

                // calculates percent of correct results
                int correct = 0;
                for (int i = 0; i < N * K; i++)
                {
                    //Console.WriteLine(indices[i]);
                    if (indices[i] == i)
                        correct++;
                }
                double percent = (double)correct / (N*K) * 100;
                Console.WriteLine("correct: {0}%", percent);
            }

            Console.ReadLine();
        }

        private CvMat CreateRandomData(int n, int d, Random rand)
        {
            CvMat data = new CvMat(n, d, MatrixType.F64C1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    data[i, j] = rand.NextDouble() * 2 - 1;
                }
            }
            return data;
        }

        private CvMat CreateQueryPoints(CvMat data, Random rand)
        {
            const double R = 0.4;
            int n = data.Rows;
            int d = data.Cols;
            CvMat query = new CvMat(n, d, MatrixType.F64C1);

            for (int i = 0; i < n; i++)
            {
                double[] ra = CreateRandomArray(d, rand);
                double sqsum = Math.Sqrt(ra.Sum<double>(elem => elem * elem));

                for (int j = 0; j < d; j++)
                {
                    double add = (rand.NextDouble() * R * ra[j]) / sqsum;
                    query[i, j] = data[i, j] + add;
                }
            }
            return query;
        }

        private double[] CreateRandomArray(int length, Random rand)
        {
            double[] arr = new double[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = rand.NextDouble();
            }
            return arr;
        }
    }
}