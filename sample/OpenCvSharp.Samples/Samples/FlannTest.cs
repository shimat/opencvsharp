using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.CPlusPlus.Flann;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// cv::flann
    /// </summary>
    class FlannTest
    {
        public FlannTest()
        {
            Console.WriteLine("===== FlannTest =====");

            // creates data set
            using (Mat features = new Mat(10000, 2, MatrixType.F32C1))
            {
                Random rand = new Random();
                for (int i = 0; i < features.Rows; i++)
                {
                    features.Set<float>(i, 0, rand.Next(10000));
                    features.Set<float>(i, 1, rand.Next(10000));
                }

                // query
                CvPoint2D32f queryPoint = new CvPoint2D32f(7777, 7777);
                Mat queries = new Mat(1, 2, MatrixType.F32C1);
                queries.Set<float>(0, 0, queryPoint.X);
                queries.Set<float>(0, 1, queryPoint.Y);
                Console.WriteLine("query:({0}, {1})", queryPoint.X, queryPoint.Y);
                Console.WriteLine("-----");

                // knnSearch
                using (Index nnIndex = new Index(features, new KDTreeIndexParams(4)))
                {
                    int knn = 1;
                    int[] indices;
                    float[] dists;
                    nnIndex.KnnSearch(queries, out indices, out dists, knn, new SearchParams(32));

                    for (int i = 0; i < knn; i++)
                    {
                        int index = indices[i];
                        float dist = dists[i];
                        CvPoint2D32f pt = new CvPoint2D32f(features.Get<float>(index, 0), features.Get<float>(index, 1));
                        Console.Write("No.{0}\t", i);
                        Console.Write("index:{0}", index);
                        Console.Write(" distance:{0}", dist);
                        Console.Write(" data:({0}, {1})", pt.X, pt.Y);
                        Console.WriteLine();
                    }
                    Console.Read();
                }
            }
        }
    }
}