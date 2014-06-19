using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenCvSharp.Blob;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;
using Rect = OpenCvSharp.CPlusPlus.Rect;
using Size = OpenCvSharp.CPlusPlus.Size;

namespace OpenCvSharp.Sandbox
{
    /// <summary>
    /// Simple codes for debugging
    /// </summary>
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            string fileName = "C:\\perspective_chessboard.jpg";

            // Cv
            using (CvMat chessboard = new CvMat(fileName))
            {
                Cv.ShowImage("Input_Cv", chessboard);

                CvPoint2D32f[] corners;
                if (Cv.FindChessboardCorners(chessboard, new Size(10, 7), out corners))
                {
                    using (CvMat dest = new CvMat(chessboard.Rows, chessboard.Cols, MatrixType.U8C3))
                    {
                        CvPoint2D32f[] a = 
                        {
                            corners[0],
                            corners[60],
                            corners[69],
                            corners[9]
                        };

                        foreach (var corner in a)
                        {
                            Cv.Circle(chessboard, corner, 5, new CvScalar(0, 0, 255));
                        }
                        Cv.ShowImage("RectangleVertices_Cv", chessboard);

                        CvPoint2D32f[] b =
                        {
                            new CvPoint2D32f(0, 0),
                            new CvPoint2D32f(0, chessboard.Height),
                            new CvPoint2D32f(chessboard.Width, chessboard.Height),
                            new CvPoint2D32f(chessboard.Width, 0)
                        };

                        CvMat map_matrix;
                        Cv.GetPerspectiveTransform(a, b, out map_matrix);
                        Cv.WarpPerspective(chessboard, dest, map_matrix, Interpolation.Linear | Interpolation.FillOutliers, CvScalar.ScalarAll(255)); //Succeed
                        Cv.ReleaseMat(map_matrix);

                        Cv.ShowImage("Output_Cv", dest);
                    }

                    //Cv.WaitKey();
                }
            }

            //Cv2
            using (Mat chessboard = new Mat(fileName))
            {
                Point2f[] corners;
                if (Cv2.FindChessboardCorners(chessboard, new Size(10, 7), out corners))
                {
                    Point2f[] a =
                    {
                        corners[0],
                        corners[60],
                        corners[69],
                        corners[9]
                    };

                    foreach (var corner in a)
                    {
                        chessboard.Circle(corner, 5, new Scalar(0, 0, 255));
                    }
                    Cv2.ImShow("RectangleVertices_Cv2", chessboard);
                    //Cv2.WaitKey();

                    Point2f[] b =
                    {
                        new Point2f(0, 0),
                        new Point2f(0, chessboard.Height),
                        new Point2f(chessboard.Width, chessboard.Height),
                        new Point2f(chessboard.Width, 0)
                    };

                    using (Mat map_matrix = Cv2.GetPerspectiveTransform(a, b))
                    using (Mat dest = new Mat(new Size(640, 480), MatType.CV_8UC3))
                    {
                        Cv2.WarpPerspective(chessboard, dest, map_matrix, dest.Size(), Interpolation.Linear | Interpolation.FillOutliers, BorderType.Default, Scalar.All(255)); //AccessViolation
                        Cv2.ImShow("Output_Cv2", dest);
                    }

                    ////Another way (Using Mat.WarpPerspective())
                    //using (Mat map_matrix = Cv2.GetPerspectiveTransform(a, b))
                    //using (Mat dest = chessboard.WarpPerspective(map_matrix, new Size(640, 480), Interpolation.Linear | Interpolation.FillOutliers, BorderType.Default, Scalar.All(255))) //AccessViolation
                    //{
                    //    Cv2.ImShow("Output_Cv2", dest);
                    //}

                    Cv2.WaitKey();
                }
            }

            //Track();
            //Run();
        }

        private static void Track()
        {
            using (var video = new CvCapture("data/bach.mp4"))
            {
                IplImage frame = null;
                IplImage gray = null;
                IplImage binary = null;
                IplImage render = null;
                IplImage renderTracks = null;
                CvTracks tracks = new CvTracks();
                CvWindow window = new CvWindow("render");
                CvWindow windowTracks = new CvWindow("tracks");

                for (int i = 0; ; i++)
                {
                    frame = video.QueryFrame();
                    //if (frame == null)
                    //    frame = new IplImage("data/shapes.png");
                    if (gray == null)
                    {
                        gray = new IplImage(frame.Size, BitDepth.U8, 1);
                        binary = new IplImage(frame.Size, BitDepth.U8, 1);
                        render = new IplImage(frame.Size, BitDepth.U8, 3);
                        renderTracks = new IplImage(frame.Size, BitDepth.U8, 3);
                    }

                    render.Zero();
                    renderTracks.Zero();

                    Cv.CvtColor(frame, gray, ColorConversion.BgrToGray);
                    Cv.Threshold(gray, binary, 0, 255, ThresholdType.Otsu);

                    CvBlobs blobs = new CvBlobs(binary);
                    CvBlobs newBlobs = new CvBlobs(blobs
                        .OrderByDescending(pair => pair.Value.Area)
                        .Take(200)
                        .ToDictionary(pair => pair.Key, pair => pair.Value), blobs.Labels);
                    newBlobs.RenderBlobs(binary, render);
                    window.ShowImage(render);

                    newBlobs.UpdateTracks(tracks, 10.0, Int32.MaxValue);
                    tracks.Render(binary, renderTracks);
                    windowTracks.ShowImage(renderTracks);

                    Cv.WaitKey(200);
                    Console.WriteLine(i);
                }
            }
        }

        static string AspectRatioAsString(float f)
        {
            bool carryon = true;
            int index = 0;
            double roundedUpValue = 0;
            while (carryon)
            {
                index++;
                float upper = index * f;

                roundedUpValue = Math.Ceiling(upper);

                if (roundedUpValue - upper <= (double)0.1 || index > 20)
                {
                    carryon = false;
                }
            }

            return roundedUpValue + ":" + index;
        }

        private static void Run()
        {
            var dm = DescriptorMatcher.Create("BruteForce");
            dm.Clear();

            Console.WriteLine(Cv2.GetCudaEnabledDeviceCount());

            string[] algoNames = Algorithm.GetList();
            Console.WriteLine(String.Join("\n", algoNames));

            SIFT al1 = new SIFT();
            string[] ppp = al1.GetParams();
            Console.WriteLine(ppp);
            var t = al1.ParamType("contrastThreshold");
            double d = al1.GetDouble("contrastThreshold");
            t.ToString();
            d.ToString();

            var src = new Mat("img/lenna.png");
            var rand = new Random();
            var memory = new List<long>(100);

            var a1 = new Mat(src, Rect.FromLTRB(0, 0, 30, 40));
            var a2 = new Mat(src, Rect.FromLTRB(0, 0, 30, 40));
            var a3 = new Mat(src, Rect.FromLTRB(0, 0, 30, 40));
            a3.ToString();

            for (long i = 0; ; i++)
            {
                for (int j = 0; j < 200; j++)
                {
                    int c1 = rand.Next(100, 400);
                    int c2 = rand.Next(100, 400);
                    Mat temp = src.Row[c1];
                    src.Row[c1] = src.Row[c2];
                    src.Row[c2] = temp;
                }

                memory.Add(MyProcess.WorkingSet64);
                if (memory.Count >= 100)
                {
                    double average = memory.Average();
                    Console.WriteLine("{0:F3}MB", average / 1024.0 / 1024.0);
                    memory.Clear();
                    GC.Collect();
                }
            }

        }

    }
}
