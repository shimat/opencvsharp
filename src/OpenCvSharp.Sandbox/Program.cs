using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Blob;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.CPlusPlus.Gpu;
using OpenCvSharp.Extensions;
using Point = OpenCvSharp.CPlusPlus.Point;
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
            Mat src = new Mat("data/lenna511.png", LoadMode.GrayScale);

            IplImage a = new IplImage(@"C:\\a.png");
            a.ROI = new CvRect(1, 1, 40, 40);
            var bmp = a.ToBitmap();
            bmp.Save("C:\\b.png", ImageFormat.Png);

            Mat zoom = new Mat();
            Mat f32 = new Mat();

            Cv2.Resize(src, zoom, new Size(960, 1280), 0, 0, Interpolation.Cubic);
            zoom.ConvertTo(f32, MatType.CV_32FC1);

            Scalar mean, stddev;
            Cv2.MeanStdDev(f32, out mean, out stddev);
            Console.WriteLine(mean[0]);
            Console.WriteLine(stddev[0]);

            Mat meanm = new Mat(), stddevm = new Mat();
            Cv2.MeanStdDev(f32, meanm, stddevm);
            Console.WriteLine(meanm.At<double>(0));
            Console.WriteLine(stddevm.At<double>(0));
            meanm.ToString();

            /*var img1 = new IplImage("data/lenna.png", LoadMode.Color);
            var img2 = new IplImage("data/match2.png", LoadMode.Color);
            Surf(img1, img2);*/

            //Mat[] mats = StitchingPreprocess(400, 400, 10);
            //Stitching(mats);
            //Track();
            //Run();
        }

        private static void Clahe()
        {
            Mat src = new Mat("data/tsukuba_left.png", LoadMode.GrayScale);
            Mat dst20 = new Mat();
            Mat dst40 = new Mat();
            Mat dst44 = new Mat();

            using (CLAHE clahe = Cv2.CreateCLAHE())
            {
                clahe.ClipLimit = 20;
                clahe.Apply(src, dst20);
                clahe.ClipLimit = 40;
                clahe.Apply(src, dst40);
                clahe.TilesGridSize = new Size(4, 4);
                clahe.Apply(src, dst44);
            }

            Window.ShowImages(src, dst20, dst40, dst44);
        }

        private static void Surf(IplImage img1, IplImage img2)
        {
            Mat src = new Mat(img1, true);
            Mat src2 = new Mat(img2, true);
            //Detect the keypoints and generate their descriptors using SURF
            SURF surf = new SURF(500, 4, 2, true);
            KeyPoint[] keypoints1, keypoints2;
            MatOfFloat descriptors1 = new MatOfFloat();
            MatOfFloat descriptors2 = new MatOfFloat();
            surf.Run(src, null, out keypoints1, descriptors1);
            surf.Run(src2, null, out keypoints2, descriptors2);
            // Matching descriptor vectors with a brute force matcher
            BFMatcher matcher = new BFMatcher(NormType.L2, false);
            DMatch[] matches = matcher.Match(descriptors1, descriptors2);//例外が発生する箇所
            Mat view = new Mat();
            Cv2.DrawMatches(src, keypoints1, src2, keypoints2, matches, view);

            Window.ShowImages(view);
        }

        private static Mat[] StitchingPreprocess(int width, int height, int count)
        {
            Mat source = new Mat(@"C:\Penguins.jpg", LoadMode.Color);
            Mat result = source.Clone();

            var rand = new Random();
            var mats = new List<Mat>();
            for (int i = 0; i < count; i++)
            {
                int x1 = rand.Next(source.Cols - width);
                int y1 = rand.Next(source.Rows - height);
                int x2 = x1 + width;
                int y2 = y1 + height;

                result.Line(new Point(x1, y1), new Point(x1, y2), new Scalar(0, 0, 255));
                result.Line(new Point(x1, y2), new Point(x2, y2), new Scalar(0, 0, 255));
                result.Line(new Point(x2, y2), new Point(x2, y1), new Scalar(0, 0, 255));
                result.Line(new Point(x2, y1), new Point(x1, y1), new Scalar(0, 0, 255));

                Mat m = source[new Rect(x1, y1, width, height)];
                mats.Add(m.Clone());
                //string outFile = String.Format(@"C:\temp\stitching\{0:D3}.png", i);
                //m.SaveImage(outFile);
            }

            result.SaveImage(@"C:\temp\parts.png");
            using (new Window(result))
            {
                Cv.WaitKey();
            }

            return mats.ToArray();
        }

        private static void Stitching(Mat[] images)
        {
            var stitcher = Stitcher.CreateDefault(false);

            Mat pano = new Mat();

            Console.Write("Stitching 処理開始...");
            var status = stitcher.Stitch(images, pano);
            Console.WriteLine(" 完了 {0}", status);

            pano.SaveImage(@"C:\temp\pano.png");
            Window.ShowImages(pano);

            foreach (Mat image in images)
            {
                image.Dispose();
            }
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

            string[] algoNames = Algorithm.GetList();
            Console.WriteLine(String.Join("\n", algoNames));

            SIFT al1 = new SIFT();
            string[] ppp = al1.GetParams();
            Console.WriteLine(ppp);
            var t = al1.ParamType("contrastThreshold");
            double d = al1.GetDouble("contrastThreshold");
            t.ToString();
            d.ToString();

            var src = new Mat("data/lenna.png");
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
