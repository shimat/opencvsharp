using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CppStyleSamplesCS
{
    class Stitching : ISample
    {
        private static Mat[] SelectStitchingImages(int width, int height, int count)
        {
            Mat source = new Mat(@"img\Penguins.jpg", LoadMode.Color);
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
            }

            using (new Window(result))
            {
                Cv.WaitKey();
            }

            return mats.ToArray();
        }

        public void Run()
        {
            Mat[] images = SelectStitchingImages(400, 400, 10);

            var stitcher = Stitcher.CreateDefault(false);

            Mat pano = new Mat();

            Console.Write("Stitching start...");
            var status = stitcher.Stitch(images, pano);
            Console.WriteLine(" finish (status:{0})", status);

            Window.ShowImages(pano);

            foreach (Mat image in images)
            {
                image.Dispose();
            }
        }
    }
}
