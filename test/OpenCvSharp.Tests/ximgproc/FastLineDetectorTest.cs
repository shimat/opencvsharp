using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCvSharp.XImgProc;

namespace OpenCvSharp.Tests.XImgProc
{
    [TestFixture]
    public class FastLineDetectorTest : TestBase
    {
        [Test]
        public void New1()
        {
            var fld = FastLineDetector.Create();
            fld.Dispose();
        }

        [Test]
        public void New2()
        {
            var fld = CvXImgProc.CreateFastLineDetector();
            fld.Dispose();
        }

        [Test]
        public void DetectUsingOutputArray()
        {
            using (var fld = FastLineDetector.Create())
            using (var image = Image("building.jpg", ImreadModes.GrayScale))
            using (var lines = new Mat())
            {
                fld.Detect(image, lines);
                Assert.That(lines.Empty, Is.False);
                Assert.That(lines.Type(), Is.EqualTo(MatType.CV_32FC4));
                Assert.That(lines.Rows, Is.GreaterThan(0));
            }
        }

        [Test]
        public void DetectUsingVector()
        {
            using (var fld = FastLineDetector.Create())
            using (var image = Image("building.jpg", ImreadModes.GrayScale))
            {
                Vec4f[] lines = fld.Detect(image);
                Assert.That(lines, Is.Not.Null.And.Length.GreaterThan(0));
            }
        }

        [Test]
        public void DrawSegmentsUsingInputArray()
        {
            using (var fld = FastLineDetector.Create())
            using (var image = Image("building.jpg", ImreadModes.GrayScale))
            using (var view = image.Clone())
            using (var lines = new Mat())
            {
                fld.Detect(image, lines);
                fld.DrawSegments(view, lines, true);
                //Window.ShowImages(view);
            }
        }

        [Test]
        public void DrawSegmentsUsingVector()
        {
            using (var fld = FastLineDetector.Create())
            using (var image = Image("building.jpg", ImreadModes.GrayScale))
            using (var view = image.Clone())
            {
                Vec4f[] lines = fld.Detect(image);
                fld.DrawSegments(view, lines, true);
                //Window.ShowImages(view);
            }
        }
    }
}

