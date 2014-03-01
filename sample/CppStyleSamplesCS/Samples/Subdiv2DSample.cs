using System;
using System.Collections.Generic;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    /// <summary>
    /// cv::Subdiv2D test
    /// </summary>
    class Subdiv2DSample : ISample
    {
        public void Run()
        {
            const int Size = 600;

            // Creates random point list
            var rand = new Random();
            var points = Enumerable.Range(0, 100).Select(_ =>
                new Point2f(rand.Next(0, Size), rand.Next(0, Size))).ToArray();

            Mat img = Mat.Zeros(Size, Size, MatType.CV_8UC3);
            foreach (var p in points)
            {
                img.Circle(p, 4, CvColor.Red, -1);
            }

            // Initializes Subdiv2D
            var subdiv = new Subdiv2D();
            subdiv.InitDelaunay(new Rect(0, 0, Size, Size));
            subdiv.Insert(points);

            // Draws voronoi diagram
            Point2f[][] facetList;
            Point2f[] facetCenters;
            subdiv.GetVoronoiFacetList(null, out facetList, out facetCenters);

            var vonoroi = img.Clone();
            foreach (var list in facetList)
            {
                var before = list.Last();
                foreach (var p in list)
                {
                    vonoroi.Line(before, p, new CvColor(64, 255, 128), 1);
                    before = p;
                }
            }

            // Draws delaunay diagram
            Vec4f[] edgeList = subdiv.GetEdgeList();
            var delaunay = img.Clone();
            foreach (var edge in edgeList)
            {
                var p1 = new Point(edge.Item0, edge.Item1);
                var p2 = new Point(edge.Item2, edge.Item3);
                delaunay.Line(p1, p2, new CvColor(64, 255, 128), 1);
            }

            Cv2.ImShow("voronoi", vonoroi);
            Cv2.ImShow("delaunay", delaunay);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}