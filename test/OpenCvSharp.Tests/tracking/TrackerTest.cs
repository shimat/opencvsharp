using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenCvSharp.Tracking;

namespace OpenCvSharp.Tests.Tracking
{
    // ReSharper disable once InconsistentNaming

    [TestFixture]
    public class TrackerTest : TestBase
    {

        [Test]
        public void Create()
        {
            foreach (TrackerTypes val in Enum.GetValues(typeof(TrackerTypes)))
            {
                var tracker = Tracker.Create(val);
                tracker.Dispose();
            }
        }

        [Test]
        public void Init()
        {
            using (var vc = Image("lenna.png"))
            using (var tracker = Tracker.Create(TrackerTypes.KCF))
                Assert.IsTrue(tracker.Init(vc, new Rect2d(320, 60, 200, 220)));
        }

        [Test]
        public void Update()
        {
            // ETHZ dataset
            // ETHZ is Eidgenössische Technische Hochschule Zürich, in Deutsch
            // https://data.vision.ee.ethz.ch/cvl/aess/cvpr2008/seq03-img-left.tar.gz
            // This video could be research data and it may not allow to use commercial use. 
            // This test can not track person perfectly but it is enough to test whether unit test works.

            // This rect indicates person who be captured in first frame
            var bb = new Rect2d(286, 146, 70, 180);

            // If you want to save markers image, you must change the following values.
            const string path = "C:\\TrackerTest_Update";

            const string basedir = "ETHZ\\seq03-img-left\\";
            using (var tracker = Tracker.Create(TrackerTypes.KCF))
                foreach (var i in Enumerable.Range(0, 21))
                {
                    var file = $"image_{i:D8}_0.png";
                    using (var mat = Image(Path.Combine(basedir, file)))
                    {
                        if (i == 0)
                        {
                            tracker.Init(mat, bb);
                        }
                        else
                        {
                            tracker.Update(mat, ref bb);
                        }

                        if (Debugger.IsAttached)
                        {
                            Directory.CreateDirectory(path);
                            mat.Rectangle(
                                new Point((int)bb.X, (int)bb.Y),
                                new Point((int)(bb.X + bb.Width), (int)(bb.Y + bb.Height)),
                                new Scalar(0, 0, 255));
                            Cv2.ImWrite(Path.Combine(path, file), mat);
                        }
                    }
                }
        }
    }
}
