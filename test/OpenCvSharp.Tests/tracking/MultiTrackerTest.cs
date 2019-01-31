using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using OpenCvSharp.Tracking;
using Xunit;

namespace OpenCvSharp.Tests.Tracking
{
    public class MultiTrackerTest : TestBase
    {
        [Fact]
        public void Init()
        {
            using (var mt = MultiTracker.Create())
            {
                GC.KeepAlive(mt);
            }
        }

        [Fact]
        public void AddOne()
        {
            using (var mt = MultiTracker.Create())
            {
                using (var tracker = TrackerKCF.Create())
                using (var vc = Image("lenna.png"))
                {
                    var ret = mt.Add(tracker, vc, new Rect2d(220, 60, 200, 220));
                    Assert.True(ret);
                }
            }
        }

        [Fact]
        public void AddMany()
        {
            using (var mt = MultiTracker.Create())
            {
                using (var tracker1 = TrackerTLD.Create())
                using (var tracker2 = TrackerMIL.Create())
                using (var tracker3 = TrackerBoosting.Create())
                using (var vc = Image("lenna.png"))
                {
                    var ret = mt.Add(
                        new Tracker[]{tracker1, tracker2, tracker3}, 
                        vc, 
                        Enumerable.Repeat(new Rect2d(220, 60, 200, 220), 3).ToArray());
                    Assert.True(ret);
                }
            }
        }

        /// <summary>
        /// https://github.com/shimat/opencvsharp/issues/601
        /// </summary>
        [Fact]
        public void AddMany2()
        {
            var bbox1 = new Rect2d(10, 10, 200, 200);
            var bbox2 = new Rect2d(300, 300, 100, 100);
            var bboxArray = new Rect2d[] { bbox1, bbox2, };
            
            using (var mt = MultiTracker.Create())
            {
                using (var tracker1 = TrackerMIL.Create())
                using (var vc = Image("lenna.png"))
                {
                    var ret = mt.Add(
                        new Tracker[] { tracker1, tracker1, },
                        vc,
                        bboxArray);
                    Assert.False(ret); // duplicate init call
                }
            }
            
            using (var mt = MultiTracker.Create())
            {
                using (var tracker1 = TrackerMIL.Create())
                using (var tracker2 = TrackerMIL.Create())
                using (var vc = Image("lenna.png"))
                {
                    var ret = mt.Add(
                        new Tracker[] { tracker1, tracker2, },
                        vc,
                        bboxArray);
                    Assert.True(ret);
                }
            }
        }

        [Fact]
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

            using (var mt = MultiTracker.Create())
            using (var tracker1 = TrackerTLD.Create())
            using (var tracker2 = TrackerMIL.Create())
            using (var tracker3 = TrackerBoosting.Create())
            {
                var randomColors = Enumerable.Range(0, 3).Select(_ => Scalar.RandomColor()).ToArray();
                foreach (var i in Enumerable.Range(0, 21))
                {
                    var file = $"image_{i:D8}_0.png";
                    using (var mat = Image(Path.Combine(basedir, file)))
                    {
                        Rect2d[] boundingBoxes;
                        if (i == 0)
                        {
                            boundingBoxes = Enumerable.Repeat(bb, 3).ToArray();
                            mt.Add(
                                new Tracker[] { tracker1, tracker2, tracker3 },
                                mat,
                                boundingBoxes);
                        }
                        else
                        {
                            mt.Update(mat, out boundingBoxes);
                        }

                        if (Debugger.IsAttached)
                        {
                            Directory.CreateDirectory(path);
                            
                            for (int j = 0; j < boundingBoxes.Length; j++)
                            {
                                mat.Rectangle(boundingBoxes[j].ToRect(), randomColors[j]);
                            }
                            Cv2.ImWrite(Path.Combine(path, file), mat);
                        }
                    }
                }
            }
        }
    }
}