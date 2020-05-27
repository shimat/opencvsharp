using System;
using System.Collections.Generic;
using OpenCvSharp.Detail;
using Xunit;
using Xunit.Abstractions;

#pragma warning disable 162

namespace OpenCvSharp.Tests.Stitching
{
    public class StitchingTest : TestBase
    {
        private readonly ITestOutputHelper testOutputHelper;

        public StitchingTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Run()
        {
            Mat[] images = SelectStitchingImages(200, 200, 12);

            using (var stitcher = Stitcher.Create(Stitcher.Mode.Scans))
            using (var pano = new Mat())
            {
                testOutputHelper.WriteLine("Stitching start...");
                var status = stitcher.Stitch(images, pano);
                testOutputHelper.WriteLine("finish (status:{0})", status);
                Assert.Equal(Stitcher.Status.OK, status);

                ShowImagesWhenDebugMode(pano);
            }

            foreach (Mat image in images)
            {
                image.Dispose();
            }
        }

        private static Mat[] SelectStitchingImages(int width, int height, int count)
        {
            var mats = new List<Mat>();

            using (var source = Image(@"lenna.png"))
            using (var result = source.Clone())
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

                ShowImagesWhenDebugMode(result);
            }

            return mats.ToArray();
        }

        [Fact]
        public void PropertyRegistrationResol()
        {
            using (var stitcher = Stitcher.Create())
            {
                const double value = 3.14159;
                stitcher.RegistrationResol = value;
                Assert.Equal(value, stitcher.RegistrationResol, 6);
            }
        }

        [Fact]
        public void PropertySeamEstimationResol()
        {
            using (var stitcher = Stitcher.Create())
            {
                const double value = 3.14159;
                stitcher.SeamEstimationResol = value;
                Assert.Equal(value, stitcher.SeamEstimationResol, 6);
            }
        }

        [Fact]
        public void PropertyRCompositingResol()
        {
            using (var stitcher = Stitcher.Create())
            {
                const double value = 3.14159;
                stitcher.CompositingResol = value;
                Assert.Equal(value, stitcher.CompositingResol, 6);
            }
        }

        [Fact]
        public void PropertyPanoConfidenceThresh()
        {
            using (var stitcher = Stitcher.Create())
            {
                const double value = 3.14159;
                stitcher.PanoConfidenceThresh = value;
                Assert.Equal(value, stitcher.PanoConfidenceThresh, 6);
            }
        }

        [Fact]
        public void PropertyWaveCorrection()
        {
            using (var stitcher = Stitcher.Create())
            {
                const bool value = true;
                stitcher.WaveCorrection = value;
                Assert.Equal(value, stitcher.WaveCorrection);
            }
        }

        [Fact]
        public void PropertyWaveCorrectKind()
        {
            using (var stitcher = Stitcher.Create())
            {
                const WaveCorrectKind value = WaveCorrectKind.Vertical;
                stitcher.WaveCorrectKind = value;
                Assert.Equal(value, stitcher.WaveCorrectKind);
            }
        }
    }
}

