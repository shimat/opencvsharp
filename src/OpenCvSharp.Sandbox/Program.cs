using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using OpenCvSharp.Blob;
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
            var s = Cv2.GetBuildInformation();
            s.ToString();

            FileStorageTest();
            //ShapeContextDistanceExtractorSaample();
            //CvBlobsSample();
            //HDR();
            //ConvertImageSample();
            //VideoCaptureSample();
            //MatchTemplateSample();
            //BackgroundSubtractorSample();
            //MatForEach();
            //LineSegmentDetectorSample();
            //LineIterator();
            //Feature();
            //Blob();

            Console.WriteLine("Press any key to exit");
            Console.Read();
        }

        private static void BowTest()
        {
            DescriptorMatcher matcher = new BFMatcher();
            Feature2D extractor = AKAZE.Create();
            Feature2D detector = AKAZE.Create();

            TermCriteria criteria = new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 10, 0.001);
            BOWKMeansTrainer bowTrainer = new BOWKMeansTrainer(200, criteria, 1);
            BOWImgDescriptorExtractor bowDescriptorExtractor = new BOWImgDescriptorExtractor(extractor, matcher);
            
            Mat img = null;

            KeyPoint[] keypoint = detector.Detect(img);
            Mat features = new Mat();
            extractor.Compute(img, ref keypoint, features);
            bowTrainer.Add(features);

            throw new NotImplementedException();
        }

        private static void FileStorageTest()
        {
            const string fileName = "foo.yml";
            using (var fs = new FileStorage(fileName, FileStorage.Mode.Write | FileStorage.Mode.FormatYaml))
            {
                fs.Write("int", 123);
                fs.Write("double", Math.PI);
                using (var tempMat = new Mat("data/lenna.png"))
                {
                    fs.Write("mat", tempMat);
                }
            }

            using (var fs = new FileStorage(fileName, FileStorage.Mode.Read))
            {
                Console.WriteLine("int: {0}", fs["int"].ReadInt());
                Console.WriteLine("double: {0}", (double)fs["double"]);
                using (var window = new Window("mat"))
                {
                    window.ShowImage(fs["mat"].ReadMat());
                    Cv2.WaitKey();
                }
            }
        }

        private static void ShapeContextDistanceExtractorSaample()
        {
            var src = Cv2.ImRead(@"data\shapes.png", ImreadModes.Color);
            var gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            var canny = gray.Canny(100, 200);

            Point[][] contours;
            HierarchyIndex[] hierarchy;
            canny.FindContours(
                out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            Mat dst = src.Clone();
            Cv2.DrawContours(dst, new Point[][] { contours[0] }, -1, Scalar.Red, 2);
            Cv2.DrawContours(dst, new Point[][] { contours[1] }, -1, Scalar.Yellow, 2);

            var distanceExtractor = ShapeContextDistanceExtractor.Create();

            using (var inputA = MatOfPoint.FromArray(contours[0]))
            using (var inputB = MatOfPoint.FromArray(contours[1]))
            {
                var distance = distanceExtractor.ComputeDistance(inputA, inputB);
                Console.WriteLine(distance); // always 0
            }

            Window.ShowImages(dst);
        }

        private static void HDR()
        {
            var hdr = CalibrateDebevec.Create();

            Mat[] images = new Mat[3];
            images[0] = Cv2.ImRead(@"data\lenna.png", ImreadModes.AnyColor);
            images[1] = Cv2.ImRead(@"data\lenna.png", ImreadModes.AnyColor);
            images[2] = Cv2.ImRead(@"data\lenna.png", ImreadModes.AnyColor);

            float[] speeds = new float[3];
            speeds[0] = 1;
            speeds[1] = 1;
            speeds[2] = 1;

            Mat dst = new Mat();

            hdr.Process(images, dst, speeds);

            dst.ToString();

            for (int i = 0; i < Math.Max(dst.Rows, dst.Cols); i++)
            {
                Console.WriteLine(dst.At<float>(i));
            }
        }

        private static void CvBlobsSample()
        {
            var src = new Mat("data/shapes.png", ImreadModes.GrayScale);
            var bin = src.Threshold(0, 255, ThresholdTypes.Otsu);
            var view = bin.CvtColor(ColorConversionCodes.GRAY2BGR);

            var blobs = new CvBlobs(bin);
            blobs.RenderBlobs(bin, view, RenderBlobsMode.Angle | RenderBlobsMode.BoundingBox | RenderBlobsMode.Color);
            Window.ShowImages(bin, view);
        }

        private static void ConvertImageSample()
        {
            var m = new Mat(100, 100, MatType.CV_32FC1);
            var rand = new Random();
            
            var indexer = m.GetGenericIndexer<float>();
            for (int r = 0; r < m.Rows; r++)
            {
                for (int c = 0; c < m.Cols; c++)
                {
                    indexer[r, c] = (float)rand.NextDouble();
                }
            }

            //Window.ShowImages(m);

            var conv = new Mat();
            Cv2.ConvertImage(m, conv);

            conv.SaveImage(@"C:\temp\float.png");
        }

        private static void VideoCaptureSample()
        {
            var cap = new VideoCapture(0);

            if (!cap.IsOpened())
            {
                Console.WriteLine("Can't use camera.");
                return;
            }

            var frame = new Mat();

            using (var window = new Window("window"))
            {
                while (true)
                {
                    cap.Read(frame);
                    window.ShowImage(frame);
                    int key = Cv2.WaitKey(50);
                    if (key == 'b')
                        break;
                }
            }
        }

        private static void MatchTemplateSample()
        {
            var src = new Mat(@"data\mt_src.png");
            var template = new Mat(@"data\template.png");
            var mask = new Mat(@"data\mask.png");
            var result = new Mat();
            Cv2.MatchTemplate(src, template, result, TemplateMatchModes.CCorrNormed, mask);

            double minVal, maxVal;
            Point minLoc, maxLoc;
            Cv2.MinMaxLoc(result, out minVal, out maxVal, out minLoc, out maxLoc);

            var view = src.Clone();
            view.Rectangle(maxLoc, new Point(maxLoc.X + template.Width, maxLoc.Y + template.Height), Scalar.Red, 2);

            Console.WriteLine(maxVal);
            Window.ShowImages(view);
        }

        private static void BackgroundSubtractorSample()
        {
            var mog = BackgroundSubtractorMOG2.Create();
            var mask = new Mat();
            var colorImage = Cv2.ImRead(@"data\shapes.png");

            mog.Apply(colorImage, mask);
            Window.ShowImages(mask);
        }

        private static void MatForEach()
        {
            var img = new Mat("data/lenna.png", ImreadModes.Color);

            var watch = Stopwatch.StartNew();
            unsafe
            {
                img.ForEachAsVec3b((value, position) =>
                {
                    value->Item0 = (byte)(255 - value->Item0);
                    value->Item1 = (byte)(255 - value->Item1);
                    value->Item2 = (byte)(255 - value->Item2);
                });
            }
            watch.Stop();

            Console.WriteLine("{0}ms", watch.ElapsedMilliseconds);
            Window.ShowImages(img);

            watch.Restart();

            var indexer = img.GetGenericIndexer<Vec3b>();
            int w = img.Width, h = img.Height;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Vec3b v = indexer[y, x];
                    v.Item0 = (byte)(255 - v.Item0);
                    v.Item1 = (byte)(255 - v.Item1);
                    v.Item2 = (byte)(255 - v.Item2);
                    indexer[y, x] = v;
                }
            }

            watch.Stop();
            Console.WriteLine("{0}ms", watch.ElapsedMilliseconds);
            Window.ShowImages(img);
        }

        private static void LineSegmentDetectorSample()
        {
            var img = new Mat("data/shapes.png", ImreadModes.GrayScale);
            var lines = new Mat();
            var view = img.Clone();

            var detector = LineSegmentDetector.Create();
            detector.Detect(img, lines);
            detector.DrawSegments(view, lines);

            Window.ShowImages(view);
        }

        private static void LineIterator()
        {
            var img = new Mat("data/lenna.png", ImreadModes.Color);
            var pt1 = new Point(100, 100);
            var pt2 = new Point(300, 300);
            var iterator = new LineIterator(img, pt1, pt2, PixelConnectivity.Connectivity8);

            // invert color
            foreach (var pixel in iterator)
            {
                Vec3b value = pixel.GetValue<Vec3b>();
                value.Item0 = (byte)~value.Item0;
                value.Item1 = (byte)~value.Item1;
                value.Item2 = (byte)~value.Item2;
                pixel.SetValue(value);
            }

            // re-enumeration works fine
            foreach (var pixel in iterator)
            {
                Vec3b value = pixel.GetValue<Vec3b>();
                Console.WriteLine("{0} = ({1},{2},{3})", pixel.Pos, value.Item0, value.Item1, value.Item2);
            }

            Window.ShowImages(img);
        }

        private static void Feature()
        {
            Mat img = new Mat("data/lenna.png", ImreadModes.GrayScale);
            KAZE kaze = KAZE.Create();

            
            KeyPoint[] keyPoints;
            Mat descriptors = new Mat();
            kaze.DetectAndCompute(img, null, out keyPoints, descriptors);

            Mat dst = new Mat();
            Cv2.DrawKeypoints(img, keyPoints, dst);
            Window.ShowImages(dst);
        }

        private static void Blob()
        {
            Mat src = new Mat("data/shapes.png", ImreadModes.Color);
            Mat gray = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat binary = gray.Threshold(0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);
            Mat labelView = new Mat();
            Mat rectView = binary.CvtColor(ColorConversionCodes.GRAY2BGR);

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
            Mat filtered = new Mat();
            cc.FilterByBlob(src, filtered, maxBlob);

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
            Mat src = new Mat("data/tsukuba_left.png", ImreadModes.GrayScale);
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
            Mat source = new Mat(@"C:\Penguins.jpg", ImreadModes.Color);
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
