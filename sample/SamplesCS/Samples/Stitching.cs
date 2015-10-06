using System;
using System.Collections.Generic;
using OpenCvSharp;

namespace SamplesCS
{
    class Stitching : ISample
    {
        private static Mat[] SelectStitchingImages(int width, int height, int count)
        {
            Mat source = new Mat(@"Data\Image\lenna.png", ImreadModes.Color);
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
                Cv2.WaitKey();
            }

            return mats.ToArray();
        }

        public void Run()
        {
            Mat[] images = SelectStitchingImages(200, 200, 10);

           var stitcher = Stitcher.Create(false);

            Mat pano = new Mat();

            Console.Write("Stitching start...");
            // TODO: does not work??
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
