using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Blob;
using OpenCvSharp;
using OpenCvSharp.Gpu;
using OpenCvSharp.Extensions;

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
            Feature();
            //Blob();

            Console.WriteLine("Press any key to exit");
            Console.Read();
        }

        private static void Feature()
        {
            Mat img = new Mat("data/lenna.png", LoadMode.GrayScale);
            KAZE kaze = KAZE.Create();

            
            KeyPoint[] keyPoints;
            Mat descriptors = new Mat();
            kaze.DetectAndCompute(img, null, out keyPoints, descriptors);
            descriptors.ToString();
        }

        private static void Blob()
        {
            Mat src = new Mat("data/shapes.png", LoadMode.Color);
            Mat gray = src.CvtColor(ColorConversion.BgrToGray);
            Mat binary = gray.Threshold(0, 255, ThresholdType.Otsu | ThresholdType.Binary);
            Mat labelView = src.EmptyClone();
            Mat rectView = binary.CvtColor(ColorConversion.GrayToBgr);

            ConnectedComponents cc = Cv2.ConnectedComponentsEx(binary);
            if (cc.LabelCount <= 1)
                return;

            // draw labels
            /*
            Scalar[] colors = cc.Blobs.Select(_ => Scalar.RandomColor()).ToArray();
            int height = cc.Labels.GetLength(0);
            int width = cc.Labels.GetLength(1);
            var labelViewIndexer = labelView.GetGenericIndexer<Vec3b>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int labelValue = cc.Labels[y, x];
                    labelViewIndexer[y, x] = colors[labelValue].ToVec3b();
                }
            }
            */
            cc.RenderBlobs(labelView);

            // draw bonding boxes except background
            foreach (var blob in cc.Blobs.Skip(1))
            {
                rectView.Rectangle(blob.Rect, Scalar.Red);
            }

            // filter maximum blob
            ConnectedComponents.Blob maxBlob = cc.GetLargestBlob();
                //cc.Blobs.Skip(1).OrderByDescending(b => b.Area).First();
            Mat filtered = cc.FilterByBlob(src, maxBlob);

            using (new Window("src", src))
            using (new Window("binary", binary))
            using (new Window("labels", labelView))
            using (new Window("bonding boxes", rectView))
            using (new Window("maximum blob", filtered))
            {
                Cv2.WaitKey();
            }
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

        /*
        private static void Surf()
        {
            Mat src = new Mat("data/match1.png");
            Mat src2 = new Mat("data/match2.png");
            //Detect the keypoints and generate their descriptors using SURF
            SURF surf = SURF.Create(500, 4, 2, true);
            KeyPoint[] keypoints1, keypoints2;
            MatOfFloat descriptors1 = new MatOfFloat();
            MatOfFloat descriptors2 = new MatOfFloat();
            surf.Compute(src, null, out keypoints1, descriptors1);
            surf.Compute(src2, null, out keypoints2, descriptors2);
            // Matching descriptor vectors with a brute force matcher
            BFMatcher matcher = new BFMatcher(NormType.L2, false);
            DMatch[] matches = matcher.Match(descriptors1, descriptors2);//例外が発生する箇所
            Mat view = new Mat();
            Cv2.DrawMatches(src, keypoints1, src2, keypoints2, matches, view);

            Window.ShowImages(view);
        }*/

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
                Cv2.WaitKey();
            }

            return mats.ToArray();
        }

        private static void Stitching(Mat[] images)
        {
            var stitcher = Stitcher.Create(false);

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
