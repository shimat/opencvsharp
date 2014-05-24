using System;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.CPlusPlus.Flann;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// cv::flann
    /// </summary>
    class FlannSample : ISample
    {
        public void Run()
        {
            Console.WriteLine("===== FlannTest =====");

            // creates data set
            using (var features = new Mat(10000, 2, MatType.CV_32FC1))
            {
                var rand = new Random();
                for (int i = 0; i < features.Rows; i++)
                {
                    features.Set<float>(i, 0, rand.Next(10000));
                    features.Set<float>(i, 1, rand.Next(10000));
                }

                // query
                var queryPoint = new Point2f(7777, 7777);
                var queries = new Mat(1, 2, MatType.CV_32FC1);
                queries.Set<float>(0, 0, queryPoint.X);
                queries.Set<float>(0, 1, queryPoint.Y);
                Console.WriteLine("query:({0}, {1})", queryPoint.X, queryPoint.Y);
                Console.WriteLine("-----");

                // knnSearch
                using (var nnIndex = new Index(features, new KDTreeIndexParams(4)))
                {
                    const int Knn = 1;
                    int[] indices;
                    float[] dists;
                    nnIndex.KnnSearch(queries, out indices, out dists, Knn, new SearchParams(32));

                    for (int i = 0; i < Knn; i++)
                    {
                        int index = indices[i];
                        float dist = dists[i];
                        var pt = new Point2f(features.Get<float>(index, 0), features.Get<float>(index, 1));
                        Console.Write("No.{0}\t", i);
                        Console.Write("index:{0}", index);
                        Console.Write(" distance:{0}", dist);
                        Console.Write(" data:({0}, {1})", pt.X, pt.Y);
                        Console.WriteLine();
                    }
                }
            }
            Console.Read();
        }
    }
}