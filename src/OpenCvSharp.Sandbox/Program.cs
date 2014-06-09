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
            while (true)
            {
                Mat mmm = new Mat("data/lenna.png");
                Mat bin = mmm.CvtColor(ColorConversion.BgrToGray)
                    .Threshold(128, 255, ThresholdType.Binary);
                MatOfPoint[] cont = Cv2.FindContoursAsMat(bin, ContourRetrieval.External, ContourChain.ApproxSimple);
                cont.ToString();

                Console.Write("{0}MB", MyProcess.WorkingSet64 / 1024.0 / 1024.0);
                Console.CursorLeft = 0;
            }

            Track();
            Run();
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
                    //frame = video.QueryFrame();
                    if (frame == null)
                        frame = new IplImage("data/shapes.png");
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

            for (long i = 0;; i++)
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
