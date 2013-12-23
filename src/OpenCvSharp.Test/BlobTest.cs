using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp.Blob;

namespace OpenCvSharp.Test
{
    [TestClass]
    public class BlobTest
    {
        [TestMethod]
        [DeploymentItem(@"OpenCV\", "")]
        public void CheckPlatform()
        {
            Assert.Inconclusive("My platform is {0}", IntPtr.Size == 8 ? "x64" : "x86");
        }

        [TestMethod]
        [DeploymentItem(@"Image\Blob\shapes.png")]
        [DeploymentItem(@"OpenCV\", "")]
        public void SimpleTest()
        {
            using (var src = new IplImage("shapes.png", LoadMode.GrayScale))
            using (var binary = new IplImage(src.Size, BitDepth.U8, 1))
            using (var render = new IplImage(src.Size, BitDepth.U8, 3))
            {
                Cv.Threshold(src, binary, 0, 255, ThresholdType.Otsu);

                var labels = new int[src.Height, src.Width];
                var blobs = new CvBlobs(binary, labels);
                blobs.RenderBlobs(labels, src, render);
                using (new CvWindow(render))
                {
                    Cv.WaitKey();
                }
            }
        }

        [TestMethod]
        [DeploymentItem(@"Image\Blob\shapes.png")]
        [DeploymentItem(@"OpenCV\", "")]
        public void NewEqualsOld()
        {
            using (var src = new IplImage("shapes.png", LoadMode.GrayScale))
            using (var binary = new IplImage(src.Size, BitDepth.U8, 1))
            {
                Cv.Threshold(src, binary, 0, 255, ThresholdType.Otsu);

                // old labeling
                var labelsOld = new IplImage(src.Width, src.Height, BitDepth.F32, 1);
                var blobsOld = new OpenCvSharp.Blob.Old.CvBlobs(binary, labelsOld);

                // new labeling
                var labelsNew = new int[src.Height, src.Width];
                var blobsNew = new CvBlobs(binary, labelsNew);

                // compare labels value
                unsafe
                {
                    byte* p1 = (byte*)labelsOld.ImageDataPtr;
                    fixed (int* p2 = &labelsNew[0, 0])
                    {
                        memcmp(p1, (byte*)p2, src.Width * src.Height).Is(0);
                    }
                }

                // compare blobs
                blobsOld.Count.Is(blobsNew.Count);
                var keys1 = blobsOld.Keys.ToArray();
                var keys2 = blobsNew.Keys.ToArray();
                for (int i = 0; i < blobsNew.Count; i++)
                {
                    // label equality
                    var key1 = keys1[i];
                    var key2 = keys2[i];
                    ((int)key1).Is(key2);

                    // value equality
                    var val1 = blobsOld[key1];
                    var val2 = blobsNew[key2];
                    (val1.Centroid).Is(val2.Centroid);
                    (val1.Rect).Is(val2.Rect);
                    ((int)val1.Area).Is(val2.Area);
                    (val1.M10).Is(val2.M10);
                    (val1.M01).Is(val2.M01);
                    (val1.M11).Is(val2.M11);
                    (val1.M20).Is(val2.M20);
                    (val1.M02).Is(val2.M02);
                    (val1.U11).Is(val2.U11);
                    (val1.U20).Is(val2.U20);
                    (val1.U02).Is(val2.U02);
                }
            }
        }

        [DllImport("msvcrt.dll")]
        private static extern unsafe int memcmp(byte* b1, byte* b2, int count);
    }
}

