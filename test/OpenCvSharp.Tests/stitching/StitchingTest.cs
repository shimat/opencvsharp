using System;
using System.Collections.Generic;
using NUnit.Framework;

#pragma warning disable 162

namespace OpenCvSharp.Tests.Stitching
{
    [TestFixture]
    public class StitchingTest : TestBase
    {
        [Test]
        public void Run()
        {
            const bool debugMode = false;

            Mat[] images = SelectStitchingImages(200, 200, 40, show: debugMode);

            using (var stitcher = Stitcher.Create(false))
            using (var pano = new Mat())
            {
                Console.Write("Stitching start...");
                var status = stitcher.Stitch(images, pano);
                Console.WriteLine(" finish (status:{0})", status);
                Assert.That(status, Is.EqualTo(Stitcher.Status.OK));

                // ReSharper disable ConditionIsAlwaysTrueOrFalse
                if (debugMode)
                    Window.ShowImages(pano);
            }

            foreach (Mat image in images)
            {
                image.Dispose();
            }
        }

        private Mat[] SelectStitchingImages(int width, int height, int count, bool show = false)
        {
            var mats = new List<Mat>();

            using (Mat source = Image(@"lenna.png", ImreadModes.Color))
            using (Mat result = source.Clone())
            {
                var rand = new Random(123); // constant seed for test
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

                if (show)
                {
                    using (new Window(result))
                    {
                        Cv2.WaitKey();
                    }
                }
            }

            return mats.ToArray();
        }

    }
}

